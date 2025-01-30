using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Threading;

namespace Triggernometry.CustomControls
{

    public partial class UserInterface : UserControl
    {

        public enum ImageIndices
        {
            FolderClosed = 0,
            FolderOpen = 1,
            Bolt = 2,
            RemoteRepo = 3,
            RemoteRepoUnavailable = 4,
            LimitedFolderClosed = 5,
            LimitedFolderOpen = 6,
            Readme = 7
        }

        internal WMPLib.WindowsMediaPlayer wmp;
        internal SpeechSynthesizer tts;
        internal RealPlugin plug;
        internal Configuration cfg;
        internal int numLoadedTriggers;
        internal int numLoadedFolders;
        internal Random r = new Random();
        internal Font _OriginalFont = null;
        internal Font _FontOverride = null;

        internal Queue<Toast> Toasts = new Queue<Toast>();

        internal object formmgmt = new object();
        internal Forms.LogForm formlog { get; set; } = null;
        internal Forms.SearchForm formsearch { get; set; } = null;
        internal string[] testInputHistoryLines = null;
        internal string testInputHistoryZone = "";

        private Color disabledNodeColor;

        public delegate string TempDelegate(object sender);
        private delegate void ProgressDelegate(int progress, string state);
        internal delegate void VoidDelegate(object sender, EventArgs e);
        internal delegate bool BoolDelegate(object sender, EventArgs e);

        public static ImageIndices GetImageIndexForClosedFolder(Folder f)
        {
            return f.IsLimited() ? ImageIndices.LimitedFolderClosed : ImageIndices.FolderClosed;
        }

        public static ImageIndices GetImageIndexForOpenFolder(Folder f)
        {
            return f.IsLimited() ? ImageIndices.LimitedFolderOpen : ImageIndices.FolderOpen;
        }

        public static ImageIndices GetImageIndexForClosedFolder(RepositoryFolder f)
        {
            return f.IsLimited() ? ImageIndices.LimitedFolderClosed : ImageIndices.FolderClosed;
        }

        public static ImageIndices GetImageIndexForOpenFolder(RepositoryFolder f)
        {
            return f.IsLimited() ? ImageIndices.LimitedFolderOpen : ImageIndices.FolderOpen;
        }

        // Create a node sorter that implements the IComparer interface.
        public class NodeSorter : IComparer
        {
            private bool DetermineSortOrder(TreeNode parent)
            {
                if (parent?.Tag is Folder folder)
                {
                    return folder._DescendingSort;
                }
                else
                {
                    return false;
                }
            }

            // Compare the length of the strings, or the strings
            // themselves, if they are the same length.
            public int Compare(object x, object y)
            {
                TreeNode tx = x as TreeNode;
                TreeNode ty = y as TreeNode;
                if (tx.Tag is Folder && ty.Tag is Trigger)
                {
                    return -1;
                }
                if (ty.Tag is Folder && tx.Tag is Trigger)
                {
                    return 1;
                }
                // Both folders / triggers:
                return DetermineSortOrder(tx.Parent) ? string.Compare(ty.Text, tx.Text) : string.Compare(tx.Text, ty.Text);
            }
        }
    
        public UserInterface()
        {
            InitializeComponent();
            linkLabel1.Tag = I18n.DoNotTranslate;
            numLoadedTriggers = 0;
            numLoadedFolders = 0;
            disabledNodeColor = Color.FromArgb(240, 96, 96);
            treeView1.TreeViewNodeSorter = new NodeSorter();
            DoubleBuffered = true;
            treeView1.ItemDrag += TreeView1_ItemDrag;
            treeView1.DragDrop += TreeView1_DragDrop;
            treeView1.DragEnter += TreeView1_DragEnter;
            treeView1.DragOver += TreeView1_DragOver;
            statusStrip1.VisibleChanged += StatusStrip1_VisibleChanged;
            ClearErrorCount();
            Disposed += UserInterface_Disposed;
        }

        private void UserInterface_Disposed(object sender, EventArgs e)
        {
            if (_FontOverride != null)
            {
                _FontOverride.Dispose();
                _FontOverride = null;
            }
        }

        private void StatusStrip1_VisibleChanged(object sender, EventArgs e)
        {
            if (prgStatus.Value == 0 && tlsStatus.Text == "" && statusStrip1.Visible == true)
            {
                statusStrip1.Visible = false;
            }            
        }

        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;
            return ContainsNode(node1, node2.Parent);
        }
        
        private bool IsPartOfRemote(TreeNode tn)
        {
            if (tn.Tag == cfg.RepositoryRoot)
            {
                return true;
            }
            return tn.Parent != null ? IsPartOfRemote(tn.Parent) : false;
        }

        internal void TreeView1_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));
            treeView1.SelectedNode = treeView1.GetNodeAt(targetPoint);
            if (treeView1.SelectedNode == null || IsPartOfRemote(treeView1.SelectedNode))
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        internal void TreeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect; 
        }

        private delegate Toast ToastDelegate();

        private Toast PopToast()
        {
            if (pnlToastSpace.InvokeRequired == true)
            {
                return (Toast)pnlToastSpace.Invoke(new ToastDelegate(PopToast));
            }
            Toast t = null;
            lock (Toasts)
            {
                if (Toasts.Count > 0)
                {
                    t = Toasts.Dequeue();
                }
            }
            if (t != null)
            {
                pnlToastSpace.Controls.Add(t);
                t.Dock = DockStyle.Fill;
                t.OnYes += HideToast;
                t.OnNo += HideToast;
                pnlToastSpace.Visible = true;
            }
            return t;
        }

        private void HideToast(Toast t, bool result)
        {
            pnlToastSpace.Controls.Remove(t);
            Toast x = PopToast();
            if (x == null)
            {
                pnlToastSpace.Visible = false;
            }
            t.Dispose();
            plug.CornerHideHook();
        }

        internal void QueueToast(Toast t)
        {
            lock (Toasts)
            {
                Toasts.Enqueue(t);
            }
            if (pnlToastSpace.Controls.Count == 0)
            {
                if (PopToast() != null)
                {
                    plug.CornerShowHook();
                }
            }
        }

        internal void TreeView1_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = treeView1.GetNodeAt(targetPoint);
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (targetNode.Tag is Trigger)
            {
                targetNode = targetNode.Parent;
            }

            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                if (e.Effect == DragDropEffects.Move)
                {
                    Folder tf = (Folder)targetNode.Tag;
                    if (draggedNode.Tag is Trigger)
                    {
                        Trigger t = (Trigger)draggedNode.Tag;
                        t.Parent.Triggers.Remove(t);
                        t.Parent = tf;
                        tf.Triggers.Add(t);                        
                    }
                    else
                    {
                        Folder f = (Folder)draggedNode.Tag;
                        f.Parent.Folders.Remove(f);
                        f.Parent = tf;
                        tf.Folders.Add(f);
                    }
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);
                    RecolorStartingFromNode(targetNode, targetNode.Checked, true);
                }
                targetNode.Expand();
                treeView1.SelectedNode = draggedNode;
            }
        }

        internal void TreeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {                
                if (treeView1.Nodes.Contains((TreeNode)e.Item) == false && IsPartOfRemote((TreeNode)e.Item) == false)
                { 
                    DoDragDrop(e.Item, DragDropEffects.Move);
                }
            }
        }

        private void SetupAutoUpdates(Toast t, bool result)
        {
            if (result == true)
            {
                cfg.UpdateNotifications = Configuration.UpdateNotificationsEnum.Yes;
                plug.CheckForUpdates();
            }
            else
            {
                cfg.UpdateNotifications = Configuration.UpdateNotificationsEnum.No;
            }
        }

        private void AddDefaultRepository()
        {
            btnAddRepoList_Click(null, null);
        }

        private void SetupDefaultRepository(Toast t, bool result)
        {
            if (result == true)
            {
                cfg.DefaultRepository = Configuration.UpdateNotificationsEnum.Yes;
                AddDefaultRepository();
            }
            else
            {
                cfg.DefaultRepository = Configuration.UpdateNotificationsEnum.No;
            }
        }

        internal void SetupToasts()
        {
            if (cfg.UpdateNotifications == Configuration.UpdateNotificationsEnum.Undefined)
            {
                Toast tx = new Toast() { ToastText = I18n.Translate("internal/UserInterface/updatenotifs", "Would you like to receive notifications when Triggernometry updates?") };
                tx.OnNo += SetupAutoUpdates;
                tx.OnYes += SetupAutoUpdates;
                tx.ToastType = Toast.ToastTypeEnum.YesNo;
                QueueToast(tx);
            }
            if (cfg.DefaultRepository == Configuration.UpdateNotificationsEnum.Undefined)
            {
                Toast tx = new Toast() { ToastText = I18n.Translate("internal/UserInterface/adddefaultrepo", "Would you like to add some trigger repositories to get started?") };
                tx.OnNo += SetupDefaultRepository;
                tx.OnYes += SetupDefaultRepository;
                tx.ToastType = Toast.ToastTypeEnum.YesNo;
                QueueToast(tx);
            }
        }

        internal void ComplainAboutReload()
        {
            Toast tx = new Toast() { ToastText = I18n.Translate("internal/UserInterface/restartafterupdate", "You have updated Triggernometry without restarting ACT - new features may not be available until you restart.") };
            tx.ToastType = Toast.ToastTypeEnum.OK;
            QueueToast(tx);
        }

        internal void BuildFullTreeFromConfiguration()
        {
            BuildTreeFromConfiguration(null, null, false);
            plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Info, I18n.Translate("internal/UserInterface/loadedfromconfig", "{0} folder(s) and {1} trigger(s) loaded from configuration", numLoadedFolders, numLoadedTriggers));
            treeView1.Sort();
            foreach (TreeNode tn in treeView1.Nodes)
            {
                tn.Expand();
            }
            lock (plug.Triggers)
            {
                foreach (Trigger t in plug.Triggers)
                {
                    foreach (Action a in t.Actions)
                    {
                        if (a.Conditions != null)
                        {
                            a.Conditions = null;
                        }
                    }
                    if (t.Conditions != null)
                    {
                        t.Conditions = null;
                    }
                }
            }
        }

        private void RetranslateTreeRoots()
        {
            foreach (TreeNode tn in treeView1.Nodes)
            {
                if (tn.Tag == cfg.Root)
                {
                    tn.Text = I18n.Translate("internal/UserInterface/local", "Local triggers");
                }
                else if (tn.Tag == cfg.RepositoryRoot)
                {
                    tn.Text = I18n.Translate("internal/UserInterface/remote", "Remote triggers");
                }
            }
        }

        internal void BuildTreeFromConfiguration(TreeNode parentnode, Folder parentfolder, bool parentdis)
        {
            if (parentnode == null && parentfolder == null)
            {
                TreeNode tn = new TreeNode();
                tn.Text = I18n.Translate("internal/UserInterface/local", "Local triggers");
                tn.Tag = cfg.Root;
                tn.Checked = cfg.Root.Enabled;
                tn.ForeColor = (tn.Checked == true) ? treeView1.ForeColor : disabledNodeColor;
                parentdis = (tn.Checked == false);
                tn.ImageIndex = (int)GetImageIndexForClosedFolder(cfg.Root);
                treeView1.Nodes.Add(tn);
                parentfolder = cfg.Root;
                parentnode = tn;
                tn = new TreeNode();
                tn.Text = I18n.Translate("internal/UserInterface/remote", "Remote triggers");
                tn.Tag = cfg.RepositoryRoot;
                tn.Checked = cfg.RepositoryRoot.Enabled;
                tn.ForeColor = (tn.Checked == true) ? treeView1.ForeColor : disabledNodeColor;
                tn.ImageIndex = (int)GetImageIndexForClosedFolder(cfg.RepositoryRoot);
                treeView1.Nodes.Add(tn);
                foreach (Repository r in cfg.RepositoryRoot.Repositories)
                {
                    TreeNode rtn = new TreeNode();
                    rtn.Text = r.Name;
                    rtn.Tag = r;
                    r.Parent = cfg.RepositoryRoot;
                    rtn.Checked = r.Enabled;
                    rtn.ForeColor = (rtn.Checked == true && cfg.RepositoryRoot.Enabled == true) ? treeView1.ForeColor : disabledNodeColor;
                    rtn.ImageIndex = (int)ImageIndices.RemoteRepoUnavailable;
                    rtn.SelectedImageIndex = rtn.ImageIndex;
                    tn.Nodes.Add(rtn);
                    //BuildTreeFromConfiguration(tn, fx, parentdis == true || tn.Checked == false);
                }
            }
            var ix1 = from pxx in parentfolder.Folders
                      orderby pxx.Name ascending
                      select pxx;
            foreach (Folder fx in ix1)
            {
                numLoadedFolders++;
                TreeNode tn = new TreeNode();
                tn.Text = fx.Name;
                tn.Tag = fx;
                tn.Checked = fx.Enabled;
                tn.ForeColor = (tn.Checked == true && parentdis == false) ? treeView1.ForeColor : disabledNodeColor;
                tn.ImageIndex = (int)GetImageIndexForClosedFolder(fx);
                tn.SelectedImageIndex = tn.ImageIndex;
                parentnode.Nodes.Add(tn);
                fx.Parent = parentfolder;
                BuildTreeFromConfiguration(tn, fx, parentdis == true || tn.Checked == false);                
            }
            var ix2 = from pxx in parentfolder.Triggers
                      orderby pxx.Name ascending
                      select pxx;     
            foreach (Trigger tx in ix2)
            {
                numLoadedTriggers++;
                TreeNode tn = new TreeNode();
                tn.Text = tx.Name;
                tn.Tag = tx;
                tn.Checked = tx.Enabled;
                tn.ForeColor = (tn.Checked == true && parentdis == false) ? treeView1.ForeColor : disabledNodeColor;
                tn.ImageIndex = (int)ImageIndices.Bolt;
                tn.SelectedImageIndex = tn.ImageIndex;
                tx.Parent = parentfolder;
                parentnode.Nodes.Add(tn);
                plug.AddTrigger(tx, tx.Parent.ParentsEnabled());
                if (tx._Condition != null)
                {
                    ConditionGroup.RebuildParentage(tx._Condition);
                }
                foreach (Action a in tx.Actions)
                {
                    if (a._Condition != null)
                    {
                        ConditionGroup.RebuildParentage(a._Condition);
                    }
                }
            }
        }

        internal void btnAddTriggerFolder_Click(object sender, EventArgs e)
        {
            using (Forms.FolderForm ff = new Forms.FolderForm())
            {
                ff.plug = plug;
                ff.SettingsFromFolder(null);
                ff.Text = I18n.Translate("internal/UserInterface/addfolder", "Add new folder");
                ff.btnOk.Text = I18n.Translate("internal/UserInterface/add", "Add");
                if (ff.ShowDialog() == DialogResult.OK)
                {
                    Folder f = new Folder();
                    ff.SettingsToFolder(f);
                    TreeNode tn = new TreeNode();
                    tn.Text = f.Name;
                    tn.Tag = f;
                    tn.Checked = f.Enabled;
                    tn.ImageIndex = (int)GetImageIndexForClosedFolder(f);
                    tn.SelectedImageIndex = tn.ImageIndex;
                    TreeNode parent = treeView1.SelectedNode;
                    if (parent.Tag is Trigger)
                    {
                        parent = parent.Parent;
                    }
                    parent.Nodes.Add(tn);
                    parent.Expand();
                    f.Parent = (Folder)parent.Tag;
                    f.Parent.Folders.Add(f);
                    RecolorStartingFromNode(tn.Parent, tn.Parent.Checked, true);
                    treeView1.Sort();
                    treeView1.SelectedNode = tn;
                }
            }
        }

        internal void btnAddTrigger_Click(object sender, EventArgs e)
        {
            Trigger srcTrigger = cfg.UseTemplateTrigger ? cfg.TemplateTrigger : null;
            using (Forms.TriggerForm tf = new Forms.TriggerForm(srcTrigger))
            {
                tf.Text = I18n.Translate("internal/UserInterface/addtrigger", "Add new trigger");
                tf.imgs = imageList1;
                tf.trv = treeView1;
                tf.wmp = wmp;
                tf.tts = tts;
                if (tf.ShowDialog() == DialogResult.OK)
                {
                    Trigger t = new Trigger();
                    t.Enabled = true;
                    tf.SettingsToTrigger(t);
                    TreeNode tn = new TreeNode();
                    tn.Text = t.Name;
                    tn.Tag = t;
                    tn.Checked = t.Enabled;
                    tn.ImageIndex = (int)ImageIndices.Bolt;
                    tn.SelectedImageIndex = tn.ImageIndex;
                    TreeNode parent = treeView1.SelectedNode;
                    if (parent.Tag is Trigger)
                    {
                        parent = parent.Parent;
                    }
                    parent.Nodes.Add(tn);
                    parent.Expand();
                    t.Parent = (Folder)parent.Tag;
                    t.Parent.Triggers.Add(t);
                    treeView1.Sort();
                    treeView1.SelectedNode = tn;
                    t.ZoneBlocked = (t.PassesZoneRestriction(plug.currentZone) == false);
                    plug.AddTrigger(t, t.Parent.ParentsEnabled());
                    RecolorStartingFromNode(tn.Parent, tn.Parent.Checked, true);
                    if (t._EditAutofire == true)
                    {
                        if (t._EditAutofireAllowCondition)
                            ForceFireTrigger(t, Action.TriggerForceTypeEnum.SkipExceptConditions);
                        else
                            ForceFireTrigger(t, Action.TriggerForceTypeEnum.SkipAll);
                    }
                }
            }
        }

        internal void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnRemoveTrigger.Enabled = false;
                btnEdit.Enabled = false;
                btnImportTrigger.Enabled = false;
                btnExportTrigger.Enabled = false;
            }
            else
            {
                object o = treeView1.SelectedNode.Tag;
                if (o == plug.cfg.RepositoryRoot)
                {
                    btnAdd.Enabled = true;
                    btnUpdate.Enabled = true;
                    btnAddTrigger.Visible = false;
                    btnAddTriggerFolder.Visible = false;
                    btnAddRepo.Visible = true;
                    btnAddRepoList.Visible = true;
                    btnAddTrigger.Enabled = false;
                    btnAddTriggerFolder.Enabled = false;
                    btnAddRepo.Enabled = true;
                    btnAddRepoList.Enabled = true;
                    btnRemoveTrigger.Enabled = false;
                    btnEdit.Enabled = false;
                    btnImportTrigger.Enabled = false;
                    btnExportTrigger.Enabled = true;
                }
                else
                {                    
                    if (treeView1.SelectedNode.Tag is Repository)
                    {
                        btnAdd.Enabled = false;
                        btnUpdate.Enabled = true;
                        btnRemoveTrigger.Enabled = true;
                        btnEdit.Enabled = true;
                        btnImportTrigger.Enabled = false;
                        btnExportTrigger.Enabled = true;
                    }
                    else if (treeView1.SelectedNode.Tag is Trigger)
                    {
                        bool isLocal = !IsPartOfRemote(treeView1.SelectedNode); 
                        btnAdd.Enabled = isLocal;
                        btnAddTrigger.Visible = isLocal;
                        btnAddTriggerFolder.Visible = isLocal;
                        btnAddRepo.Visible = false;
                        btnAddRepoList.Visible = false;
                        btnAddTrigger.Enabled = isLocal;
                        btnAddTriggerFolder.Enabled = isLocal;
                        btnAddRepo.Enabled = false;
                        btnAddRepoList.Enabled = false;
                        btnUpdate.Enabled = false;
                        btnRemoveTrigger.Enabled = isLocal;
                        btnEdit.Enabled = true;
                        btnImportTrigger.Enabled = false;
                        btnExportTrigger.Enabled = (treeView1.SelectedNode.ImageIndex != (int)ImageIndices.Readme);
                    }
                    else if (treeView1.SelectedNode.Tag is Folder)
                    {
                        btnAdd.Enabled = (IsPartOfRemote(treeView1.SelectedNode) == false);
                        btnUpdate.Enabled = false;
                        btnAddTrigger.Visible = true;
                        btnAddTriggerFolder.Visible = true;
                        btnAddRepo.Visible = false;
                        btnAddRepoList.Visible = false;
                        btnAddTrigger.Enabled = true;
                        btnAddTriggerFolder.Enabled = true;
                        btnAddRepo.Enabled = false;
                        btnAddRepoList.Enabled = false;
                        btnRemoveTrigger.Enabled = (treeView1.SelectedNode.Parent != null && IsPartOfRemote(treeView1.SelectedNode) == false);
                        btnEdit.Enabled = true;
                        btnImportTrigger.Enabled = (IsPartOfRemote(treeView1.SelectedNode) == false);
                        btnExportTrigger.Enabled = true;
                    }
                }
            }
        }

        internal void btnEdit_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag is Trigger t)
            {
                bool readOnly = IsPartOfRemote(treeView1.SelectedNode);
                bool readMe = t.Repo != null && treeView1.SelectedNode.ImageIndex == (int)ImageIndices.Readme;
                using (Forms.TriggerForm tf = new Forms.TriggerForm(t, readOnly, readMe))
                {
                    Trigger.TriggerSourceEnum oldSource = t._Source;
                    tf.imgs = imageList1;
                    tf.trv = treeView1;
                    tf.Text = readMe 
                        ? I18n.Translate("internal/UserInterface/edittriggerreadme", "Instructions for repository '{0}'", t.Repo.Name) 
                        : tf.Text = I18n.Translate("internal/UserInterface/edittrigger", "Edit trigger '{0}'", t.Name);
                    tf.wmp = wmp;
                    tf.tts = tts;
                    if (tf.ShowDialog() == DialogResult.OK)
                    {
                        lock (t) // verified
                        {
                            tf.SettingsToTrigger(t);
                            if (oldSource != t._Source)
                            {
                                plug.SourceChange(t, oldSource, t._Source);
                            }
                        }
                        if (t._EditAutofire == true)
                        {
                            if (t._EditAutofireAllowCondition)
                                ForceFireTrigger(t, Action.TriggerForceTypeEnum.SkipExceptConditions);
                            else
                                ForceFireTrigger(t, Action.TriggerForceTypeEnum.SkipAll);
                        }
                        TreeNode tn = treeView1.SelectedNode;
                        tn.Text = t.Name;
                        treeView1.Sort();
                        treeView1.SelectedNode = tn;
                    }
                }
            }
            else if (treeView1.SelectedNode.Tag is Repository r)
            {
                using (Forms.RepositoryForm rf = new Forms.RepositoryForm())
                {
                    rf.plug = plug;
                    rf.SettingsFromRepository(r);
                    rf.Text = I18n.Translate("internal/UserInterface/editrepository", "Edit repository '{0}'", r.Name);
                    rf.btnOk.Text = I18n.Translate("internal/UserInterface/savechanges", "Save changes");
                    if (rf.ShowDialog() == DialogResult.OK)
                    {
                        rf.SettingsToRepository(r);
                        TreeNode tn = treeView1.SelectedNode;
                        tn.Text = r.Name;
                        treeView1.Sort();
                        treeView1.SelectedNode = tn;
                    }
                }
            }
            else if (treeView1.SelectedNode.Tag is Folder && treeView1.SelectedNode.Parent != null)
            {
                using (Forms.FolderForm ff = new Forms.FolderForm())
                {
                    ff.plug = plug;
                    Folder f = (Folder)treeView1.SelectedNode.Tag;
                    ff.SettingsFromFolder(f);
                    if (IsPartOfRemote(treeView1.SelectedNode) == true)
                    {
                        ff.SetReadOnly();
                    }
                    ff.Text = I18n.Translate("internal/UserInterface/editfolder", "Edit folder '{0}'", f.Name);
                    ff.btnOk.Text = I18n.Translate("internal/UserInterface/savechanges", "Save changes");
                    if (ff.ShowDialog() == DialogResult.OK)
                    {                        
                        ff.SettingsToFolder(f);
                        TreeNode tn = treeView1.SelectedNode;
                        tn.Text = f.Name;
                        if (tn.ImageIndex == (int)ImageIndices.FolderClosed || tn.ImageIndex == (int)ImageIndices.LimitedFolderClosed)
                        {
                            tn.ImageIndex = (int)GetImageIndexForClosedFolder(f);                            
                        }
                        else if (tn.ImageIndex == (int)ImageIndices.FolderOpen || tn.ImageIndex == (int)ImageIndices.LimitedFolderOpen)
                        {
                            tn.ImageIndex = (int)GetImageIndexForOpenFolder(f);
                        }
                        tn.SelectedImageIndex = tn.ImageIndex;
                        treeView1.Sort();
                        treeView1.SelectedNode = tn;
                    }
                    plug.ZoneChanged(plug.currentZone);
                }
            }
        }

        internal void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddTriggerFolder_Click(sender, e);
        }

        internal void triggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddTrigger_Click(sender, e);
        }

        internal void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRemoveTrigger_Click(sender, e);
        }

        internal void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        internal void ctxDescendingSort_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode?.Tag is Folder f)
            {
                f._DescendingSort = !f._DescendingSort;
                treeView1.Sort();
            }
        }

        internal void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnImportTrigger_Click(sender, e);
        }

        internal void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnExportTrigger_Click(sender, e);
        }

        internal void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.ImageIndex == (int)ImageIndices.Readme)
            {
                ctxAdd.Visible = false;
                ctxUpdate.Visible = false;
                ctxEdit.Visible = false;
                ctxDescendingSort.Visible = false;
                ctxFire.Visible = false;
                ctxFireAllowCondition.Visible = false;
                ctxCollapse.Visible = false;
                ctxExpand.Visible = false;
                ctxImport.Visible = false;
                ctxExport.Visible = false;
                ctxCopy.Visible = false;
                ctxPaste.Visible = false;
                ctxDelete.Visible = false;
                ctxReadme.Visible = true;
                toolStripSeparator2.Visible = false;
                toolStripSeparator4.Visible = false;
                toolStripSeparator7.Visible = false;
                toolStripSeparator11.Visible = false;
                toolStripSeparator12.Visible = false;
            }
            else
            {
                var folder = treeView1.SelectedNode.Tag as Folder;
                ctxAdd.Visible = true;
                ctxUpdate.Visible = true;
                ctxEdit.Visible = true;
                ctxDescendingSort.Visible = folder != null;
                ctxDescendingSort.Checked = folder != null && folder._DescendingSort;
                ctxFire.Visible = true;
                ctxFireAllowCondition.Visible = true;
                ctxCollapse.Visible = true;
                ctxExpand.Visible = true;
                ctxImport.Visible = true;
                ctxExport.Visible = true;
                ctxCopy.Visible = true;
                ctxPaste.Visible = true;
                ctxDelete.Visible = true;
                ctxReadme.Visible = false;
                toolStripSeparator2.Visible = true;
                toolStripSeparator4.Visible = true;
                toolStripSeparator7.Visible = true;
                toolStripSeparator11.Visible = true;
                toolStripSeparator12.Visible = true;
                ctxAdd.Enabled = btnAdd.Enabled;
                ctxEdit.Enabled = btnEdit.Enabled;
                ctxUpdate.Enabled = btnUpdate.Enabled;
                ctxAddTrigger.Visible = btnAddTrigger.Enabled;
                ctxAddTrigger.Enabled = btnAdd.Enabled && btnAddTrigger.Enabled;
                ctxAddFolder.Enabled = btnAddTriggerFolder.Enabled;
                ctxAddFolder.Visible = btnAdd.Enabled && btnAddTriggerFolder.Enabled;
                ctxAddRepo.Enabled = btnAddRepo.Enabled;
                ctxAddRepo.Visible = btnAdd.Enabled && btnAddRepo.Enabled;
                ctxAddRepoList.Enabled = btnAddRepo.Enabled;
                ctxAddRepoList.Visible = btnAdd.Enabled && btnAddRepo.Enabled;
                ctxDelete.Enabled = btnRemoveTrigger.Enabled;
                ctxImport.Enabled = btnImportTrigger.Enabled;
                ctxExport.Enabled = btnExportTrigger.Enabled;
                ctxFire.Visible = true; // cfg.DeveloperMode;
                ctxFireAllowCondition.Visible = true; // cfg.DeveloperMode;
                toolStripSeparator12.Visible = true; // cfg.DeveloperMode;
                ctxCopy.Enabled = (treeView1.SelectedNode != null);
                ctxPaste.Enabled = (ctxAddTrigger.Enabled == true && System.Windows.Forms.Clipboard.ContainsText() == true);
                if (treeView1.SelectedNode != null)
                {
                    ctxCollapse.Enabled = (treeView1.SelectedNode.Nodes.Count > 0);
                    ctxExpand.Enabled = ctxCollapse.Enabled;
                    ctxFire.Enabled = (treeView1.SelectedNode.Tag is Trigger);
                    ctxFireAllowCondition.Enabled = (treeView1.SelectedNode.Tag is Trigger);
                }
                else
                {
                    ctxCollapse.Enabled = true;
                    ctxExpand.Enabled = true;
                    ctxFire.Enabled = false;
                    ctxFireAllowCondition.Enabled = false;
                }
            }
        }

        internal void CountItems(Folder f, ref int numfolders, ref int numtriggers)
        {
            numfolders++;
            numtriggers += f.Triggers.Count;
            foreach (Folder fx in f.Folders)
            { 
                CountItems(fx, ref numfolders, ref numtriggers);
            }
        }

        internal void RemoveAllTriggers(Folder f)
        {
            foreach (Trigger t in f.Triggers)
            {
                plug.RemoveTrigger(t);
            }
            foreach (Folder fx in f.Folders)
            {
                RemoveAllTriggers(fx);
            }
        }

        private delegate void RepoTreeDelegate(Repository r);

        internal void ClearRepositoryInTree(Repository r)
        {
            if (treeView1.InvokeRequired == true)
            {
                treeView1.Invoke(new RepoTreeDelegate(ClearRepositoryInTree), r);
                return;
            }
            foreach (TreeNode tn in treeView1.Nodes[1].Nodes)
            {
                if (tn.Tag == r)
                {
                    tn.Nodes.Clear();
                }
            }
        }

        internal void ClearRepository(Repository r)
        {
            RemoveAllTriggers(r.Root);
            r.Root.Triggers.Clear();
            r.Root.Folders.Clear();
            ClearRepositoryInTree(r);
        }

        internal void CopySelected()
        {
            try
            {
                string data = ExportSelection().Serialize();
                System.Windows.Forms.Clipboard.SetText(data);
            }
            catch (Exception ex)
            {
                plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/UserInterface/copyfail", "Tree copy failed due to exception: {0}", ex.Message));
            }
        }

        internal void btnRemoveTrigger_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag is Trigger)
            {
                Trigger t = (Trigger)treeView1.SelectedNode.Tag;
                switch (MessageBox.Show(this, I18n.Translate("internal/UserInterface/areyousuretrigger", "Are you sure you want to remove trigger '{0}'?", t.Name), I18n.Translate("internal/UserInterface/confirm", "Confirm removal"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes:
                        TreeNode tn = treeView1.SelectedNode;
                        tn.Parent.Nodes.Remove(tn);
                        t.Parent.Triggers.Remove(t);
                        plug.RemoveTrigger(t);
                        return;
                    case DialogResult.No:
                        return;
                }
            }
            else if (treeView1.SelectedNode.Tag is Repository)
            {
                Repository r = (Repository)treeView1.SelectedNode.Tag;
                switch (MessageBox.Show(this, I18n.Translate("internal/UserInterface/areyousurerepo", "Are you sure you want to remove repository '{0}'?", r.Name), I18n.Translate("internal/UserInterface/confirm", "Confirm removal"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes:
                        TreeNode tn = treeView1.SelectedNode;
                        tn.Parent.Nodes.Remove(tn);
                        r.Parent.Repositories.Remove(r);
                        RemoveAllTriggers(r.Root);
                        return;
                    case DialogResult.No:
                        return;
                }
            }
            else if (treeView1.SelectedNode.Tag is Folder)
            {
                int numfolders = 0;
                int numtriggers = 0;
                Folder f = (Folder)treeView1.SelectedNode.Tag;
                CountItems(f, ref numfolders, ref numtriggers);
                string temp = I18n.Translate("internal/UserInterface/areyousurefolder", "Are you sure you want to remove folder '{0}'?", f.Name);
                if (numfolders > 1 || numtriggers > 0)
                {
                    temp += Environment.NewLine + Environment.NewLine + I18n.Translate("internal/UserInterface/operationwillremove", "This operation will remove:") + Environment.NewLine;
                    if (numfolders > 1)
                    {
                        temp += Environment.NewLine + "∙ " + I18n.Translate("internal/UserInterface/folderplural", "{0} folders", numfolders);
                    }
                    else if (numfolders > 0)
                    {
                        temp += Environment.NewLine + "∙ " + I18n.Translate("internal/UserInterface/foldersingular", "{0} folder", numfolders);
                    }
                    if (numtriggers > 1)
                    {
                        temp += Environment.NewLine + "∙ " + I18n.Translate("internal/UserInterface/triggerplural", "{0} triggers", numtriggers);
                    }
                    else if (numtriggers > 0)
                    {
                        temp += Environment.NewLine + "∙ " + I18n.Translate("internal/UserInterface/triggersingular", "{0} trigger", numtriggers);
                    }
                }
                switch (MessageBox.Show(this, temp, I18n.Translate("internal/UserInterface/confirm", "Confirm removal"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes:
                        TreeNode tn = treeView1.SelectedNode;
                        tn.Parent.Nodes.Remove(tn);
                        f.Parent.Folders.Remove(f);
                        RemoveAllTriggers(f);
                        return;
                    case DialogResult.No:
                        return;
                }
            }
        }

        internal void ImportResultsFromForm(Forms.ImportForm imf)
        {
            TreeNode tn = treeView1.SelectedNode;
            Folder df;
            if (tn.Tag is Folder)
            {
                df = (Folder)tn.Tag;
            }
            else
            {
                df = ((Trigger)tn.Tag).Parent;
                treeView1.SelectedNode = treeView1.SelectedNode.Parent;
            }            
            Folder f = null;
            Trigger t = null;
            Dictionary<Guid, Guid> renamedFolders = new Dictionary<Guid, Guid>();
            if (imf.treeView1.Nodes[0].Tag is Folder)
            {
                f = (Folder)imf.treeView1.Nodes[0].Tag;
                List<Folder> newFolders = ConstructFolderList(null, f);
                List<Folder> exFolders = ConstructFolderList(null, cfg.Root);
                foreach (Folder fr in newFolders)
                {
                    Folder trx = (from tx in exFolders where tx.Id == fr.Id select tx).FirstOrDefault();
                    if (trx != null)
                    {
                        fr.Id = Guid.NewGuid();
                        renamedFolders[trx.Id] = fr.Id;
                        plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/UserInterface/folderidreassign", "Reassigning new id ({0}) for folder ({1}) due to already assigned id ({2}) on folder ({3})", fr.Id, fr.Name, trx.Id, trx.Name));
                    }

                }
                df.Folders.Add(f);
                f.Parent = df;
            }
            if (imf.treeView1.Nodes[0].Tag is Trigger)
            {
                t = (Trigger)imf.treeView1.Nodes[0].Tag;
                df.Triggers.Add(t);
                t.Parent = df;
            }
            TreeNode tnx = (TreeNode)imf.treeView1.Nodes[0].Clone();
            ResetBackgrounds(tnx);
            TreeNode tmp = treeView1.SelectedNode;
            treeView1.SelectedNode.Nodes.Add(tnx);
            treeView1.Sort();
            RecolorStartingFromNode(tmp, tmp.Checked, false);
            treeView1.SelectedNode = tnx;
            tnx.Collapse(false); 
            tnx.Expand();           // collapse all subfolders and only expand the imported folder
            List<Trigger> newTrigs = new List<Trigger>();
            Dictionary<Guid, Guid> renamedTriggers = new Dictionary<Guid, Guid>();
            if (f != null)
            {
                AddAllTriggersFromFolder(f, ref newTrigs);
            }
            else
            {
                newTrigs.Add(t);
            }
            lock (plug.Triggers)
            {
                foreach (Trigger nt in newTrigs)
                {
                    Trigger trx = (from tx in plug.Triggers where tx.Id == nt.Id && tx.Repo == null select tx).FirstOrDefault();
                    if (trx != null)
                    {
                        nt.Id = Guid.NewGuid();
                        renamedTriggers[trx.Id] = nt.Id;
                        plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/UserInterface/idreassign", "Reassigning new id ({0}) for trigger ({1}) due to already assigned id ({2}) on trigger ({3})", nt.Id, nt.Name, trx.Id, trx.Name));
                    }
                }
            }
            int fdjs = 0, tdjs = 0;
            foreach (Trigger nt in newTrigs)
            {
                foreach (Action a in nt.Actions)
                {
                    if (renamedTriggers.ContainsKey(a._TriggerId) == true)
                    {
                        a._TriggerId = renamedTriggers[a._TriggerId];
                        tdjs++;
                    }
                    if (renamedFolders.ContainsKey(a._FolderId) == true)
                    {
                        a._FolderId = renamedFolders[a._FolderId];
                        fdjs++;
                    }
                }
                plug.AddTrigger(nt, nt.Parent.ParentsEnabled());
            }
            if (fdjs > 0 || tdjs > 0)
            {
                plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/UserInterface/idreassigncount", "Adjusted {0} trigger and {1} folder references on actions due to collisions", tdjs, fdjs));
            }
        }

        internal List<Folder> ConstructFolderList(List<Folder> cur, Folder f)
        {
            bool reting = false;
            if (cur == null)
            {
                cur = new List<Folder>();
                reting = true;
            }
            cur.Add(f);
            foreach (Folder sf in f.Folders)
            {
                ConstructFolderList(cur, sf);
            }
            return (reting == true) ? cur : null;
        }

        internal void btnImportTrigger_Click(object sender, EventArgs e)
        {
            using (Forms.ImportForm imf = new Forms.ImportForm(plug))
            {
                imf.imgs = imageList1;
                imf.trv = treeView1;
                imf.Text = I18n.Translate("internal/UserInterface/importunder", "Import under '{0}'", treeView1.SelectedNode.Text);
                imf.wmp = wmp;
                imf.tts = tts;
                imf.ui = this;
                if (imf.ShowDialog() == DialogResult.OK)
                {
                    ImportResultsFromForm(imf);
                }
            }
        }

        internal void ResetBackgrounds(TreeNode tn)
        {
            tn.BackColor = Color.Empty;
            foreach (TreeNode tnc in tn.Nodes)
            {
                ResetBackgrounds(tnc);
            }
        }

        internal void AddAllTriggersFromFolder(Folder f, ref List<Trigger> trigs)
        {
            foreach (Folder sf in f.Folders)
            {
                AddAllTriggersFromFolder(sf, ref trigs);
            }
            foreach (Trigger t in f.Triggers)
            {                
                trigs.Add(t);
            }
        }

        internal TriggernometryExport ExportSelection()
        {
            TriggernometryExport exp = new TriggernometryExport();
            exp.PluginVersion = RealPlugin.plug.cfg.PluginVersion;
            if (treeView1.SelectedNode.Tag is Trigger)
            {
                Trigger t = (Trigger)treeView1.SelectedNode.Tag;
                exp.ExportedTrigger = t;
            }
            else if (treeView1.SelectedNode.Tag is Folder)
            {
                if (treeView1.SelectedNode.Tag is RepositoryFolder)
                {
                    RepositoryFolder f = (RepositoryFolder)treeView1.SelectedNode.Tag;
                    exp.ExportedFolder = f.ConvertToFolder();
                }
                else
                {
                    Folder f = (Folder)treeView1.SelectedNode.Tag;
                    exp.ExportedFolder = f;
                }
            }
            else if (treeView1.SelectedNode.Tag is Repository)
            {
                Repository f = (Repository)treeView1.SelectedNode.Tag;
                exp.ExportedFolder = f.Root;
            }
            return exp;
        }

        internal void btnExportTrigger_Click(object sender, EventArgs e)
        {
            string exps = ExportSelection().Serialize();
            using (Forms.ExportForm ef = new Forms.ExportForm())
            {
                ef.ShownText = exps;                
                ef.ShowDialog();
            }
        }

        internal void clearActionQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plug.ClearActionQueue();
        }

        internal void enabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (plug.QueueProcessingLock) // verified
            {
                btnActionQueueEnabled.Checked = true;
                btnActionQueueDisabled.Checked = false;
                plug.QueueProcessing = true;
                plug.ActionUpdateEvent.Set();
            }
        }

        internal void disabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (plug.QueueProcessingLock) // verified
            {
                btnActionQueueEnabled.Checked = false;
                btnActionQueueDisabled.Checked = true;
                plug.QueueProcessing = false;
                plug.ActionUpdateEvent.Set();
            }
        }

        private void CloseTree(TreeNode tn)
        {
            if (tn.Tag is Folder)
            {
                tn.ImageIndex = (int)GetImageIndexForClosedFolder((Folder)tn.Tag);
                tn.SelectedImageIndex = tn.ImageIndex;
            }
            foreach (TreeNode tc in tn.Nodes)
            {
                CloseTree(tc);
            }
        }

        internal void UpdateUiFont()
        {
            if (_OriginalFont == null)
            {
                _OriginalFont = Font;
            }
            if (cfg.UiFontDefault == false)
            {
                try
                {
                    Font oldf = _FontOverride;
                    _FontOverride = RealPlugin.CreateFontFromDefinition(cfg.UiFontName, cfg.UiFontSize, cfg.UiFontEffect);
                    RealPlugin.ApplyFontOverrideToControl(this, _FontOverride);
                    if (oldf != null)
                    {
                        oldf.Dispose();
                    }
                }
                catch (Exception)
                {
                }
            }
            else
            {
                if (_FontOverride != null)
                {
                    RealPlugin.ApplyFontOverrideToControl(this, _OriginalFont);
                    _FontOverride.Dispose();
                    _FontOverride = null;                    
                }
            }
        }

        internal void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Forms.ConfigurationForm2 cf = new Forms.ConfigurationForm2())
            {
                cf.plug = plug;
                cf.trvTrigger.ImageList = imageList1;
                cf.trvTrigger.Nodes.Add((TreeNode)treeView1.Nodes[0].Clone());
                CloseTree(cf.trvTrigger.Nodes[0]);
                cf.SettingsFromConfiguration(plug.cfg);
                if (cf.ShowDialog() == DialogResult.OK)
                {
                    lock (plug.cfg) // verified
                    {
                        cf.SettingsToConfiguration(plug.cfg);
                    }
                    UpdateUiFont();
                }
            }
        }

        internal void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag is Folder)
            {
                e.Node.ImageIndex = (int)GetImageIndexForClosedFolder((Folder)e.Node.Tag);
                e.Node.SelectedImageIndex = e.Node.ImageIndex;
            }
        }

        internal void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag is Folder)
            {
                e.Node.ImageIndex = (int)GetImageIndexForOpenFolder((Folder)e.Node.Tag);
                e.Node.SelectedImageIndex = e.Node.ImageIndex;
            }
        }

        internal void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {            
            if (e.Button == MouseButtons.Right)
            {
                treeView1.SelectedNode = e.Node;
            }
        }

        internal void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Forms.AboutForm af = new Forms.AboutForm())
            {
                af.ShowDialog();
            }
        }

        internal void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == treeView1.SelectedNode && (treeView1.SelectedNode != null) && btnEdit.Enabled == true && (treeView1.SelectedNode.Tag is Trigger))
            {
                btnEdit_Click(sender, null);
            }
        }

        internal void OpenLogForm(bool errorSearch)
        {
            lock (formmgmt)
            {
                if (formlog == null)
                {
                    formlog = new Forms.LogForm();
                    formlog.startWithErrorSearch = errorSearch;
                    formlog.FormClosed += Formlog_FormClosed;
                    formlog.Show(plug.mainform);
                }
                else
                {
                    formlog.BringToFront();
                    formlog.Focus();
                }
            }
        }

        internal void OpenSearchForm()
        {
            lock (formmgmt)
            {
                if (formsearch == null)
                {
                    formsearch = new Forms.SearchForm();
                    formsearch.plug = plug;
                    formsearch.FormClosed += Formsearch_FormClosed;
                    formsearch.Show(plug.mainform);
                }
                else
                {
                    formsearch.BringToFront();
                    formsearch.Focus();
                }
            }
        }

        internal void viewLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLogForm(false);
        }

        private void Formlog_FormClosed(object sender, FormClosedEventArgs e)
        {
            lock (formlog)
            {
                formlog.Dispose();
                formlog = null;
            }
        }

        private void Formsearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            lock (formsearch)
            {
                formsearch.Dispose();
                formsearch = null;
            }
        }

        private void killExecutingActionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plug.RefreshCancellationToken();
            plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/UserInterface/triedfullinterrupt", "Tried to interrupt executing actions"));
        }

        private void viewVariablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Forms.StateForm vf = new Forms.StateForm())
            {
                vf.plug = plug;
                vf.ShowDialog();
            }
        }

        private void RecolorStartingFromNode(TreeNode tn, bool pstate, bool refreshActives)
        {
            object o = tn.Tag;
            TreeNode tnx = tn.Parent;            
            while (tnx != null && pstate == true)
            {
                pstate = tnx.Checked;
                tnx = tnx.Parent;
            }
            if (tn.ImageIndex == (int)ImageIndices.Readme)
            {
                tn.ForeColor = treeView1.ForeColor;
                tn.BackColor = tn.Checked == true ? Color.Yellow : Color.White;
                return;
            }
            else
            {
                tn.ForeColor = (tn.Checked == true && pstate == true) ? treeView1.ForeColor : disabledNodeColor;
            }
            if (o is Trigger)
            {
                Trigger t = (Trigger)o;
                bool reallyEnabled = (tn.Checked == true && pstate == true);
                t.Enabled = tn.Checked;
                if (refreshActives == true)
                {
                    if (reallyEnabled == true)
                    {
                        plug.TriggerEnabled(t);
                    }
                    else
                    {
                        plug.TriggerDisabled(t);
                    }                        
                }
            }
            else
            {
                if (o is Repository)
                {
                    Repository r = (Repository)o;
                    r.Enabled = tn.Checked;
                    foreach (TreeNode tnn in tn.Nodes)
                    {
                        RecolorStartingFromNode(tnn, (tn.Checked == true && pstate == true), refreshActives);
                    }
                }
                else
                {
                    if (o is RepositoryFolder)
                    {
                        RepositoryFolder r = (RepositoryFolder)o;
                        r.Enabled = tn.Checked;
                        foreach (TreeNode tnn in tn.Nodes)
                        {
                            RecolorStartingFromNode(tnn, (tn.Checked == true && pstate == true), refreshActives);
                        }
                    }
                    else
                    {
                        Folder f = (Folder)o;
                        f.Enabled = tn.Checked;
                        foreach (TreeNode tnn in tn.Nodes)
                        {
                            RecolorStartingFromNode(tnn, (tn.Checked == true && pstate == true), refreshActives);
                        }
                    }
                }
            }
        }

        private Folder GetTopLevelFolder(Trigger t)
        {
            return GetTopLevelFolder(t.Parent);
        }

        private Folder GetTopLevelFolder(Folder f)
        {
            return (f.Parent != null) ? GetTopLevelFolder(f.Parent) : f;
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode tn = e.Node, ptn;
            if (IsPartOfRemote(tn) == true)
            {
                Folder rf;
                object x = null;
                if (tn.Tag is Folder)
                {
                    x = (Folder)tn.Tag;
                    rf = GetTopLevelFolder((Folder)x);
                }
                else if (tn.Tag is Trigger)
                {
                    x = (Trigger)tn.Tag;
                    rf = GetTopLevelFolder((Trigger)x);
                }
                else
                {
                    RecolorStartingFromNode(e.Node, e.Node.Checked, true);
                    return;
                }
                ptn = tn;
                while ((ptn.Tag is Repository) == false)
                {
                    ptn = ptn.Parent;
                }
                Repository r = (Repository)ptn.Tag;
                if (x is Folder)
                {
                    var temp = (from ix in r.FolderStates where ix.Id == ((Folder)x).Id select ix).ToList();
                    foreach (Repository.RepositoryItem ri in temp)
                    {
                        ri.Enabled = tn.Checked;
                    }
                }
                if (x is Trigger)
                {
                    var temp = (from ix in r.TriggerStates where ix.Id == ((Trigger)x).Id select ix).ToList();
                    foreach (Repository.RepositoryItem ri in temp)
                    {
                        ri.Enabled = tn.Checked;
                    }
                }
            }
            RecolorStartingFromNode(e.Node, e.Node.Checked, true);
        }

        private void deactivateAllAurasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Context fakectx = new Context();
            fakectx.plug = plug;
            Action a = new Action();
            a._AuraOp = Action.AuraOpEnum.DeactivateAllAura;
            a._TextAuraOp = Action.AuraOpEnum.DeactivateAllAura;
            plug.ImageAuraManagement(fakectx, a);
            plug.TextAuraManagement(fakectx, a);
        }

        private void testInputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Forms.TestInputForm ti = new Forms.TestInputForm())
            {
                if (cfg.TestInputDestination != -1)
                {
                    ti.cbxEventDestination.SelectedIndex = cfg.TestInputDestination;
                }
                if (cfg.TestInputZoneType != -1)
                {
                    ti.cbxZoneType.SelectedIndex = cfg.TestInputZoneType;
                }
                if (testInputHistoryLines != null)
                {
                    ti.txtEvent.Lines = testInputHistoryLines;
                }
                ti.txtZoneName.Text = testInputHistoryZone;
                ti.plug = plug;
                switch (ti.ShowDialog())
                {
                    case DialogResult.OK:
                        string[] lines = ti.txtEvent.Lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
                        testInputHistoryLines = lines;
                        testInputHistoryZone = ti.txtZoneName.Text;
                        plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/UserInterface/loglinequeue", "Queueing {0} user log lines", lines.Length));
                        LogEvent.SourceEnum src = LogEvent.SourceEnum.Log;
                        cfg.TestInputDestination = ti.cbxEventDestination.SelectedIndex;
                        cfg.TestInputZoneType = ti.cbxZoneType.SelectedIndex;
                        switch (ti.cbxEventDestination.SelectedIndex)
                        {
                            case 0:
                                src = LogEvent.SourceEnum.Log;
                                break;
                            case 1:
                                src = LogEvent.SourceEnum.NetworkFFXIV;
                                break;
                            case 2:
                                src = LogEvent.SourceEnum.ACT;
                                break;
                            case 3:
                                src = LogEvent.SourceEnum.Endpoint;
                                break;
                        }
                        plug.LogLineQueuerMass(lines, ti.txtZoneName.Text, src, true, ti.cbxZoneType.SelectedIndex == 1);
                        plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/UserInterface/loglinequeuedone", "Done"));
                        /*
                        foreach (string line in lines)
                        {
                            plug.FilteredAddToLog(Plugin.DebugLevelEnum.Verbose, "User log line: (" + line + ")");
                            plug.LogLineQueuer(line, ti.txtZone.Text);
                        }*/
                        break;
                }
            }
        }

        internal void CloseForms()
        {
            lock (formmgmt)
            {
                if (formlog != null)
                {
                    formlog.Close();
                }
                if (formsearch != null)
                {
                    formsearch.Close();
                }
            }
        }

        private void runBenchmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Forms.BenchmarkForm bf = new Forms.BenchmarkForm())
            {
                bf.plug = plug;
                bf.ShowDialog();
            }
        }

        private int _newErrorCount = 0;
        /// <summary> Should only use this property on the main UI thread. </summary>
        private int NewErrorCount {
            get => _newErrorCount;
            set 
            {
                _newErrorCount = value;
                UpdateErrorCount();
            }
        }

        private void UpdateErrorCount()
        {
            if (NewErrorCount == 0)
            {
                errThing1.Text = I18n.Translate("internal/UserInterface/errorCount0", "No new errors");
                var resources = new ComponentResourceManager(typeof(UserInterface));
                errThing1.Image = (Image)resources.GetObject("btnViewLog.Image");
            }
            else if (NewErrorCount == 1)
            {
                errThing1.Text = I18n.Translate("internal/UserInterface/errorCount1", "1 error");
                var resources = new ComponentResourceManager(typeof(UserInterface));
                errThing1.Image = (Image)resources.GetObject("errThing1.Image");
            }
            else if (NewErrorCount > 10000)
            {
                return; // avoid a infinitely looped error continuously invoking this method and freezing the UI
            }
            else if (NewErrorCount == 10000)
            {
                errThing1.Text = I18n.Translate("internal/UserInterface/errorCountN", "{0} errors", "9999+");
            }
            else
            {
                errThing1.Text = I18n.Translate("internal/UserInterface/errorCountN", "{0} errors", NewErrorCount);
                return;
            }
        }

        internal void ClearErrorCount()
        {
            if (this.IsDisposed) return;
            if (this.InvokeRequired)
            {
                this.Invoke(new System.Action(ClearErrorCount));
            }
            else
            {
                NewErrorCount = 0;
            }
        }

        internal void IncrementErrorCount()
        {
            if (this.IsDisposed) return;
            if (this.InvokeRequired)
            {
                this.Invoke(new System.Action(IncrementErrorCount));
            }
            else
            {
                NewErrorCount += 1;
            }
        }

        internal void PasteSelected()
        {
            string data = null;
            try
            {                
                data = System.Windows.Forms.Clipboard.GetText(TextDataFormat.UnicodeText);
                if (data != null && data.Length > 0)
                {
                    TriggernometryExport exp = TriggernometryExport.Unserialize(data);
                    using (Forms.ImportForm ifo = new Forms.ImportForm(plug))
                    {
                        ifo.BuildTreeFromExport(exp, null, null, false);
                        ImportResultsFromForm(ifo);
                    }
                }
            }
            catch (Exception ex)
            {
                plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/UserInterface/pastefail", "Tree paste failed due to exception: {0}", ex.Message));
            }
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                CopySelected();
            }
            else if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                if (btnAdd.Enabled == true && btnAddTrigger.Enabled == true)
                {
                    PasteSelected();
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (btnRemoveTrigger.Enabled == true)
                {
                    btnRemoveTrigger_Click(this, null);
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopySelected();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnAdd.Enabled == true && btnAddTrigger.Enabled == true)
            {
                PasteSelected();
            }
        }

        internal void ClearAllVariables()
        {
            var result = MessageBox.Show(I18n.Translate("internal/UserInterface/clearvar", "Are you sure you want to clear the session variables?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            lock (plug.sessionvars.Scalar)
            {
                plug.sessionvars.Scalar.Clear();
            }
            lock (plug.sessionvars.List)
            {
                plug.sessionvars.List.Clear();
            }
            lock (plug.sessionvars.Table)
            {
                plug.sessionvars.Table.Clear();
            }
            lock (plug.sessionvars.Dict)
            {
                plug.sessionvars.Dict.Clear();
            }
        }

        private void clearAllVariablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearAllVariables();
        }

        private void saveConfigurationManuallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (plug.configBroken == false)
            {
                plug.SaveCurrentConfig();
            }
            else
            {
                string exx = I18n.Translate("internal/UserInterface/warnbeforemanualsave", "Errors were encountered when loading configuration on startup. Saving configuration in this state may lead to it being corrupted beyond repair. Are you sure you want to save configuration anyway?");
                if (MessageBox.Show(this, exx, I18n.Translate("internal/UserInterface/saveconfigmanually", "Save configuration manually"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    plug.SaveCurrentConfig();
                    plug.configBroken = false;
                }
            }
        }

        private void btnCloseWelcome_Click(object sender, EventArgs e)
        {
            cfg.ShowWelcome = chkWelcome.Checked;
            btnOptions.Enabled = true;
            pnlUi.Visible = true;
            pnlWelcome.Visible = false;
            toolStrip1.SendToBack();
            treeView1.SelectedNode = treeView1.Nodes[0];
            treeView1.Focus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }

        private void goToConfigurationFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pth = plug.path;
            Process.Start(pth);
        }

        private void remoteTriggerRepositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Forms.RepositoryForm rf = new Forms.RepositoryForm())
            {
                rf.plug = plug;
                rf.SettingsFromRepository(null);
                rf.Text = I18n.Translate("internal/UserInterface/addrepo", "Add new repository");
                rf.btnOk.Text = I18n.Translate("internal/UserInterface/add", "Add");
                if (rf.ShowDialog() == DialogResult.OK)
                {
                    Repository r = new Repository();
                    r.Enabled = true;
                    rf.SettingsToRepository(r);
                    TreeNode tn = new TreeNode();
                    tn.Text = r.Name;
                    tn.Tag = r;
                    tn.Checked = r.Enabled;
                    tn.ImageIndex = (int)ImageIndices.RemoteRepoUnavailable;
                    tn.SelectedImageIndex = tn.ImageIndex;
                    RepositoryFolder rfo = (RepositoryFolder)treeView1.SelectedNode.Tag;
                    rfo.Repositories.Add(r);
                    r.Parent = rfo;
                    treeView1.SelectedNode.Nodes.Add(tn);
                    treeView1.SelectedNode.Expand();
                    treeView1.Sort();
                    treeView1.SelectedNode = tn;
                    RecolorStartingFromNode(tn.Parent, tn.Parent.Checked, true);
                    btnUpdate_Click(sender, e);
                }
            }
        }

        private void repositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            remoteTriggerRepositoryToolStripMenuItem_Click(sender, e);
        }

        internal void SetupLanguageMenu()
        {
            if (I18n.RegisteredLanguages.Count > 0)
            {
                foreach (KeyValuePair<string, Language> kp in I18n.RegisteredLanguages)
                {
                    if (kp.Value.IsDefault == true)
                    {
                        continue;
                    }
                    if (toolStripSeparator10.Visible == false)
                    {
                        toolStripSeparator10.Visible = true;
                    }
                    ToolStripMenuItem tsi = new ToolStripMenuItem();
                    tsi.Text = kp.Value.LanguageName;
                    if (I18n.CurrentLanguage != null)
                    {
                        if (I18n.CurrentLanguage.LanguageName == tsi.Text)
                        {
                            if (btnDefaultLanguage.Checked == true)
                            {
                                btnDefaultLanguage.Checked = false;
                                btnDefaultLanguage.Enabled = true;
                            }
                            tsi.Checked = true;
                            tsi.Enabled = false;
                        }
                    }
                    tsi.CheckOnClick = true;
                    tsi.CheckedChanged += Tsi_CheckedChanged;
                    btnLanguages.DropDownItems.Add(tsi);
                }
            }
            btnDefaultLanguage.CheckedChanged += Tsi_CheckedChanged;
            foreach (ToolStripItem tsi in btnLanguages.DropDownItems)
            {
                tsi.Tag = I18n.DoNotTranslate;
            }
        }

        private void Tsi_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem tsi = (ToolStripMenuItem)sender;
            if (tsi.Checked == true)
            {
                tsi.Enabled = false;
                foreach (ToolStripItem tsim in btnLanguages.DropDownItems)
                {
                    if (tsim == tsi)
                    {
                        continue;
                    }
                    if (tsim is ToolStripMenuItem)
                    {
                        ToolStripMenuItem tsimm = (ToolStripMenuItem)tsim;
                        tsimm.Checked = false;
                    }
                }
                if (tsi == btnDefaultLanguage)
                {
                    plug.ChangeLanguage(null);
                    RetranslateTreeRoots();
                    I18n.TranslateControl("Plugin", this);
                }
                else
                {
                    plug.ChangeLanguage(sender.ToString());
                    RetranslateTreeRoots();
                    I18n.TranslateControl("Plugin", this);
                }
            }
            else
            {
                tsi.Enabled = true;
            }
        }

        internal void ShowProgress(int progress, string state)
        {
            if (statusStrip1.InvokeRequired == true)
            {
                statusStrip1.Invoke(new ProgressDelegate(ShowProgress), progress, state);
                return;
            }
            if (progress == 0 && state == "" && statusStrip1.Visible == true)
            {
                statusStrip1.Visible = false;
                return;
            }
            if (progress == -1)
            {
                prgStatus.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                prgStatus.Style = ProgressBarStyle.Continuous;
                if (progress < prgStatus.Minimum)
                {
                    progress = prgStatus.Minimum;
                }
                if (progress > prgStatus.Maximum)
                {
                    progress = prgStatus.Maximum;
                }
                prgStatus.Value = progress;
            }
            tlsStatus.Text = state;
            if (progress != 0 && statusStrip1.Visible == false)
            {
                statusStrip1.Visible = true;
            }
        }

        private delegate void RepoTreeBuilderDelegate(TriggernometryExport exp, Repository r);

        internal void BuildTreeForRepository(TriggernometryExport exp, Repository r)
        {
            if (treeView1.InvokeRequired == true)
            {
                treeView1.Invoke(new RepoTreeBuilderDelegate(BuildTreeForRepository), exp, r);
                return;
            }
            using (Forms.ImportForm ifo = new Forms.ImportForm(plug))
            {
                foreach (TreeNode tn in treeView1.Nodes[1].Nodes)
                {
                    if (tn.Tag == r)
                    {
                        ifo.BuildTreeFromExport(exp, tn, r.Root, true);
                        tn.ImageIndex = (int)ImageIndices.RemoteRepo;
                        tn.SelectedImageIndex = tn.ImageIndex;
                        if (r.ReadmeTriggers.Count > 0)
                        {
                            foreach (Trigger t in r.ReadmeTriggers)
                            {
                                TreeNode tx = plug.LocateNodeHostingTrigger(tn, t);
                                if (tx != null)
                                {
                                    TreeNode rn = new TreeNode();
                                    rn.Text = tx.Text;
                                    rn.Checked = tx.Checked;
                                    rn.Tag = tx.Tag;
                                    rn.ImageIndex = (int)ImageIndices.Readme;
                                    rn.SelectedImageIndex = (int)ImageIndices.Readme;                                    
                                    tn.Nodes.Add(rn);
                                    rn.EnsureVisible();
                                }
                            }
                        }
                        RecolorStartingFromNode(tn, r.Enabled, false);
                        return;
                    }
                }
            }
        }

        private void ForceUpdateRepository(TreeNode tnupdate)
        {
            if (tnupdate == null)
            {
                return;
            }
            if (tnupdate.Tag is RepositoryFolder)
            {
                RepositoryFolder rfo = (RepositoryFolder)tnupdate.Tag;
                foreach (TreeNode tn in tnupdate.Nodes)
                {
                    tn.ImageIndex = (int)ImageIndices.RemoteRepoUnavailable;
                    tn.SelectedImageIndex = tn.ImageIndex;
                }
                Task tx = new Task(() =>
                {
                    plug.AllRepositoryUpdates(false);
                });
                tx.Start();
            }
            if (tnupdate.Tag is Repository)
            {
                Repository rfo = (Repository)tnupdate.Tag;
                tnupdate.ImageIndex = (int)ImageIndices.RemoteRepoUnavailable;
                tnupdate.SelectedImageIndex = tnupdate.ImageIndex;
                Task tx = new Task(() =>
                {
                    plug.RepositoryUpdate(rfo, true, false);
                });
                tx.Start();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ForceUpdateRepository(treeView1.SelectedNode);
        }

        private void ctxUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate_Click(sender, e);
        }

        private void btnAddRepoList_Click(object sender, EventArgs e)
        {
            using (Forms.RepositoryListForm rlf = new Forms.RepositoryListForm())
            {
                rlf.plug = plug;
                rlf.Text = I18n.Translate("internal/UserInterface/addrepolist", "Add new repository from list");
                if (rlf.ShowDialog() == DialogResult.OK)
                {
                    foreach (RepositoryList.Repository rta in rlf.ReposToAdd)
                    {
                        Repository r = new Repository();
                        r.Enabled = true;
                        r.Address = rta.Address;
                        r.AllowProcessLaunch = false;
                        r.AllowWindowMessages = false;
                        r.AllowScriptExecution = false;
                        r.AllowObsControl = false;
                        r.AllowDiskOperations = false;
                        r.KeepLocalBackup = true;
                        r.Name = rta.Name;
                        r.NewBehavior = Repository.NewBehaviorEnum.AsDefined;
                        r.UpdatePolicy = Repository.UpdatePolicyEnum.Startup;
                        r.AudioOutput = Repository.AudioOutputEnum.NeverOverride;
                        TreeNode tn = new TreeNode();
                        tn.Text = r.Name;
                        tn.Tag = r;
                        tn.Checked = r.Enabled;
                        tn.ImageIndex = (int)ImageIndices.RemoteRepoUnavailable;
                        tn.SelectedImageIndex = tn.ImageIndex;
                        RepositoryFolder rfo = (RepositoryFolder)treeView1.Nodes[1].Tag;
                        rfo.Repositories.Add(r);
                        r.Parent = rfo;
                        treeView1.Nodes[1].Nodes.Add(tn);
                        treeView1.Nodes[1].Expand();
                        RecolorStartingFromNode(tn.Parent, tn.Parent.Checked, true);
                        treeView1.Sort();
                        ForceUpdateRepository(tn);
                    }
                }
            }
        }

        private void ctxAddRepoList_Click(object sender, EventArgs e)
        {
            btnAddRepoList_Click(sender, e);
        }

        private void errThing1_Click(object sender, EventArgs e)
        {
            OpenLogForm(true);
            NewErrorCount = 0;
        }

        private void ctxCollapse_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.Collapse(false);
            }
            else
            {
                treeView1.CollapseAll();
            }
        }

        private void ctxExpand_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.ExpandAll();
            }
            else
            {
                treeView1.ExpandAll();
            }
        }

        private void btnOptions_DropDownOpening(object sender, EventArgs e)
        {
            btnActionQueueProcessing.Visible = cfg.DeveloperMode;
            btnTryInterrupt.Visible = cfg.DeveloperMode;
            btnClearActionQueue.Visible = cfg.DeveloperMode;
            btnClearVars.Visible = cfg.DeveloperMode;
            btnTestInput.Visible = cfg.DeveloperMode;
            btnDeactivateAllAuras.Visible = cfg.DeveloperMode;
            toolStripSeparator5.Visible = cfg.DeveloperMode;
            btnBenchmark.Visible = cfg.DeveloperMode;
            btnViewVariables.Visible = cfg.DeveloperMode;
            btnSearch.Visible = cfg.DeveloperMode;
        }

        private void ctxFire_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                TreeNode tn = treeView1.SelectedNode;
                if (tn.Tag is Trigger)
                {
                    Trigger t = (Trigger)tn.Tag;
                    ForceFireTrigger(t, Action.TriggerForceTypeEnum.SkipAll);
                }
            }
        }

        private void ctxFireAllowCondition_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                TreeNode tn = treeView1.SelectedNode;
                if (tn.Tag is Trigger)
                {
                    Trigger t = (Trigger)tn.Tag;
                    ForceFireTrigger(t, Action.TriggerForceTypeEnum.SkipExceptConditions);
                }
            }
        }

        private void ForceFireTrigger(Trigger t, Action.TriggerForceTypeEnum force)
        {
            Context ctx = new Context();
            ctx.plug = plug;
            ctx.testByPlaceholder = false;
            ctx.trig = t;
            ctx.soundhook = plug.SoundPlaybackSmart;
            ctx.ttshook = plug.TtsPlaybackSmart;
            ctx.triggered = DateTime.UtcNow;
            ctx.force = force;
            if ((t._TestInput?.Length ?? 0) == 0)
            {
                t.Fire(plug, ctx, null);
            }
            else
            {
                string[] lines = ctx.EvaluateStringExpression(t.TriggerContextLogger, plug, t._TestInput).Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                force = Action.TriggerForceTypeEnum.SkipActive | Action.TriggerForceTypeEnum.SkipRefire | Action.TriggerForceTypeEnum.SkipParent;
                LogEvent.SourceEnum source;
                switch (t._Source)
                {
                    case Trigger.TriggerSourceEnum.ACT:
                        source = LogEvent.SourceEnum.ACT;
                        break;
                    case Trigger.TriggerSourceEnum.Endpoint:
                        source = LogEvent.SourceEnum.Endpoint;
                        break;
                    case Trigger.TriggerSourceEnum.FFXIVNetwork:
                        source = LogEvent.SourceEnum.NetworkFFXIV;
                        break;
                    case Trigger.TriggerSourceEnum.Log:
                        source = LogEvent.SourceEnum.Log;
                        break;
                    default:
                    case Trigger.TriggerSourceEnum.None:
                        force |= Action.TriggerForceTypeEnum.SkipRegexp;
                        source = LogEvent.SourceEnum.Log;
                        break;
                }
                foreach (string line in lines)
                {
                    LogEvent le = new LogEvent() { Text = line, Timestamp = DateTime.Now, TestMode = true, ZoneName = "", ZoneId = null, Source = source };
                    plug.TestTrigger(t, le, force);
                }
            }
        }

        private void btnCornerPopup_Click(object sender, EventArgs e)
        {
            TabPage tp = (TabPage)btnCornerPopup.Tag;
            plug.TabLocateHook(tp);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OpenSearchForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        internal void LocateTreeNode(TreeNode tn)
        {
            treeView1.SelectedNode = tn;
            treeView1.SelectedNode.EnsureVisible();
            treeView1.Focus();
            FindForm().Focus();
        }

        private void ctxReadme_Click(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void btnUpdateCheck_Click(object sender, EventArgs e)
        {
            plug.CheckForUpdates(isManual: true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RepositoryFolder rfo = (RepositoryFolder)treeView1.Nodes[1].Tag;
            List<Repository> upds = new List<Repository>();
            foreach (Repository r in rfo.Repositories)
            {
                if (r.Enabled == true && r.AutoUpdate == true && r.LastUpdatedTrig.AddMinutes(r.UpdateInterval) < DateTime.Now)
                {
                    upds.Add(r);
                }
            }
            if (upds.Count > 0)
            {
                Task tx = new Task(() =>
                {
                    plug.RepositoryUpdates(upds, false);
                });
                tx.Start();                
            }
            if (cfg.AutosaveEnabled == true && plug.lastConfigSave.AddMinutes(cfg.AutosaveInterval) < DateTime.Now)
            {
                if (plug.configBroken == false)
                {
                    plug.SaveCurrentConfig();
                }
            }
        }

    }

}
