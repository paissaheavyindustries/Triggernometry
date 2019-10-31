using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Speech.Synthesis;
using System.Net;

namespace Triggernometry.Forms
{

    public partial class ImportForm : MemoryForm<ImportForm>
    {

        // Create a node sorter that implements the IComparer interface.
        public class NodeSorter : IComparer
        {
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
                }                // If they are the same length, call Compare.
                return string.Compare(tx.Text, ty.Text);
            }
        }

        internal WMPLib.WindowsMediaPlayer wmp;
        internal SpeechSynthesizer tts;
        internal RealPlugin plug;
        private int importMethod;
        private string importData;
        internal ImageList imgs;
        internal TreeView trv;

        private CustomControls.UserInterface _ui;
        internal CustomControls.UserInterface ui {
            get
            {
                return _ui;
            }
            set
            {
                _ui = value;
                treeView1.ImageList = _ui.imageList1;
            }
        }

        public ImportForm(RealPlugin p)
        {
            InitializeComponent();
            plug = p;
            if (DesignMode == false)
            {
                tabControl1.ItemSize = new Size(0, 1);
                tabControl1.SizeMode = TabSizeMode.Fixed;
            }
            radImportFromText.Select();
            radExistingActTriggers.Enabled = plug.CustomTriggerCheckHook();
            treeView1.TreeViewNodeSorter = new NodeSorter();
            treeView1.ItemDrag += TreeView1_ItemDrag;
            treeView1.DragDrop += TreeView1_DragDrop;
            treeView1.DragEnter += TreeView1_DragEnter;
            treeView1.DragOver += TreeView1_DragOver;
            RestoredSavedDimensions();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText() == true)
            {
                txtImportSource.Text = Clipboard.GetText();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = radImportFromText.Checked;
            btnNext.Enabled = (txtImportSource.Text.Length > 0);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtImportFile.Enabled = radLoadFromFileURI.Checked;
            btnBrowseFile.Enabled = radLoadFromFileURI.Checked;
            btnNext.Enabled = (txtImportFile.Text.Length > 0);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                btnBack.Text = I18n.Translate("internal/ImportForm/cancel", "Cancel");
                btnBack.DialogResult = DialogResult.Cancel;
            }
            else
            {
                btnBack.Text = I18n.Translate("internal/ImportForm/back", "< Back");
                btnBack.DialogResult = DialogResult.None;
            }
            if (e.TabPageIndex == tabControl1.TabCount - 1)
            {
                btnNext.Text = I18n.Translate("internal/ImportForm/import", "Import");
                btnNext.DialogResult = DialogResult.OK;
            }
            else
            {
                btnNext.Text = I18n.Translate("internal/ImportForm/next", "Next >");
                btnNext.DialogResult = DialogResult.None;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                treeView1.Nodes.Clear();
                lblWarning.Visible = false;
                importMethod = (radImportFromText.Checked == true ? 1 : (radLoadFromFileURI.Checked == true ? 2 : 3));
                switch (importMethod)
                {
                    case 1:
                        importData = txtImportSource.Text;
                        break;
                    case 2:
                        try
                        {
                            Uri uriResult;
                            bool result = (
                                Uri.TryCreate(txtImportFile.Text, UriKind.Absolute, out uriResult)
                                &&
                                (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)
                            );
                            if (result == true)
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    byte[] rawdata = wc.DownloadData(uriResult);
                                    importData = Encoding.UTF8.GetString(rawdata);
                                }
                            }
                            else
                            {
                                importData = File.ReadAllText(txtImportFile.Text);
                            }                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, I18n.Translate("internal/ImportForm/importexception", "An exception occurred: {0}", ex.Message), I18n.Translate("internal/ImportForm/exception", "Exception"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                    case 3:
                        importData = "";
                        break;
                }
                if (TryImport() == false)
                {
                    return;
                }
            }
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex++;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
            if (tabControl1.SelectedIndex > 0)
            {
                tabControl1.SelectedIndex--;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtImportFile.Text = openFileDialog1.FileName;
            }
        }

        private void txtImportFile_TextChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = (txtImportFile.Text.Length > 0);
        }

        private void txtImportSource_TextChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = (txtImportSource.Text.Length > 0);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
        }

        private bool TryImport()
        {
            try
            {
                if (importMethod == 1 || importMethod == 2)
                {
                    TryImportText();
                }
                else
                { 
                    TryImportAct();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, I18n.Translate("internal/ImportForm/importerrortext", "An error occurred while attempting to import:") + Environment.NewLine + Environment.NewLine + ex.Message, I18n.Translate("internal/ImportForm/importerror", "Import error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void TryImportText()
        {
            try
            {
                TriggernometryExport tex = TriggernometryExport.Unserialize(importData);
                if (tex != null)
                {
                    TryImportExport(tex);
                    return;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                TriggernometryExport tex = TriggernometryExport.Unserialize(WebUtility.HtmlDecode(importData));
                if (tex != null)
                {
                    TryImportExport(tex);
                    return;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                string nex = "<ActWrapper>" + importData + "</ActWrapper>";
                TryImportActWrapper(nex);
                return;
            }
            catch (Exception)
            {
            }
            try
            {
                string nex = "&lt;ActWrapper&gt;" + importData + "&lt;/ActWrapper&gt;";
                TryImportActWrapper(WebUtility.HtmlDecode(nex));
                return;
            }
            catch (Exception)
            {
            }
            try
            {
                Configuration cfg = null;
                XmlSerializer xs = new XmlSerializer(typeof(Configuration));
                using (MemoryStream ms = new MemoryStream(UTF8Encoding.UTF8.GetBytes(importData)))
                {
                    cfg = (Configuration)xs.Deserialize(ms);
                    TriggernometryExport tex = new TriggernometryExport();
                    tex.ExportedFolder = cfg.Root;
                    tex.ExportedFolder.Name = I18n.Translate("internal/ImportForm/importedconfigfile", "Imported configuration file ({0})", DateTime.Now);
                    tex.ExportedTrigger = null;
                    TryImportExport(tex);
                    return;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                Configuration cfg = null;
                XmlSerializer xs = new XmlSerializer(typeof(Configuration));
                using (MemoryStream ms = new MemoryStream(UTF8Encoding.UTF8.GetBytes(WebUtility.HtmlDecode(importData))))
                {
                    cfg = (Configuration)xs.Deserialize(ms);
                    TriggernometryExport tex = new TriggernometryExport();
                    tex.ExportedFolder = cfg.Root;
                    tex.ExportedFolder.Name = I18n.Translate("internal/ImportForm/importedconfigfile", "Imported configuration file ({0})", DateTime.Now);
                    tex.ExportedTrigger = null;
                    TryImportExport(tex);
                    return;
                }
            }
            catch (Exception)
            {
            }
            throw new Exception(I18n.Translate("internal/ImportForm/importcantrecognize", "Can't recognize the provided data as any valid, importable format. You may be trying to import newer triggers to an older version of Triggernometry. Make sure you are using the latest version."));
        }

        private bool HasWmsgTriggers(Folder f)
        {
            foreach (Folder sf in f.Folders)
            {
                if (HasWmsgTriggers(sf) == true)
                {
                    return true;
                }
            }
            foreach (Trigger t in f.Triggers)
            {
                if (IsWmsgTrigger(t) == true)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsWmsgTrigger(Trigger t)
        {
            var ix = from ax in t.Actions where ax.ActionType == Action.ActionTypeEnum.WindowMessage select ax;
            return (ix.Count() > 0);
        }

        private bool HasLaunchTriggers(Folder f)
        {            
            foreach (Folder sf in f.Folders)
            {
                if (HasLaunchTriggers(sf) == true)
                {
                    return true;
                }
            }
            foreach (Trigger t in f.Triggers)
            {
                if (IsLaunchTrigger(t) == true)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsLaunchTrigger(Trigger t)
        {
            var ix = from ax in t.Actions where ax.ActionType == Action.ActionTypeEnum.LaunchProcess select ax;
            return (ix.Count() > 0);
        }

        private bool HasScriptTriggers(Folder f)
        {
            foreach (Folder sf in f.Folders)
            {
                if (HasScriptTriggers(sf) == true)
                {
                    return true;
                }
            }
            foreach (Trigger t in f.Triggers)
            {
                if (IsScriptTrigger(t) == true)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsScriptTrigger(Trigger t)
        {
            var ix = from ax in t.Actions where ax.ActionType == Action.ActionTypeEnum.ExecuteScript select ax;
            return (ix.Count() > 0);
        }

        private bool HasWmsgTriggers(TriggernometryExport tex)
        {
            return (tex.ExportedFolder != null ? HasWmsgTriggers(tex.ExportedFolder) : IsWmsgTrigger(tex.ExportedTrigger));
        }

        private bool HasScriptTriggers(TriggernometryExport tex)
        {
            return (tex.ExportedFolder != null ? HasScriptTriggers(tex.ExportedFolder) : IsScriptTrigger(tex.ExportedTrigger));
        }

        private bool HasLaunchTriggers(TriggernometryExport tex)
        {
            return (tex.ExportedFolder != null ? HasLaunchTriggers(tex.ExportedFolder) : IsLaunchTrigger(tex.ExportedTrigger));
        }

        private void TryImportExport(TriggernometryExport tex)
        {
            string warning = "";
            bool includesLaunch = HasLaunchTriggers(tex);
            bool includesScript = HasScriptTriggers(tex);
            bool includesWmsg = HasWmsgTriggers(tex);
            BuildTreeFromExport(tex, null, null, false);
            treeView1.ExpandAll();
            if (includesLaunch == true || includesScript == true || includesWmsg == true)
            {                
                if (includesLaunch == true)
                {
                    if (includesScript == true)
                    {
                        if (includesWmsg == true)
                        {
                            warning = I18n.Translate("internal/ImportForm/dangerprocscriptwmsg", "Some of the imported triggers include triggers which launch arbitrary processes, execute arbitrary scripts, and send arbitrary window messages. These triggers can be dangerous and malicious triggers may even compromise your system and security. The items in question have been highlighted below.");
                        }
                        else
                        {
                            warning = I18n.Translate("internal/ImportForm/dangerprocscript", "Some of the imported triggers include triggers which launch arbitrary processes and execute arbitrary scripts. These triggers can be dangerous and malicious triggers may even compromise your system and security. The items in question have been highlighted below.");
                        }
                    }
                    else
                    {
                        if (includesWmsg == true)
                        {
                            warning = I18n.Translate("internal/ImportForm/dangerprocwmsg", "Some of the imported triggers include triggers which launch arbitrary processes and send arbitrary window messages. These triggers can be dangerous and malicious triggers may even compromise your system and security. The items in question have been highlighted below.");
                        }
                        else
                        {
                            warning = I18n.Translate("internal/ImportForm/dangerproc", "Some of the imported triggers include triggers which launch arbitrary processes. These triggers can be dangerous and malicious triggers may even compromise your system and security. The items in question have been highlighted below.");
                        }
                    }
                }
                else if (includesScript == true)
                {
                    if (includesWmsg == true)
                    {
                        warning = I18n.Translate("internal/ImportForm/dangerscriptwmsg", "Some of the imported triggers include triggers which execute arbitrary scripts and send arbitrary window messages. These triggers can be dangerous and malicious triggers may even compromise your system and security. The items in question have been highlighted below.");
                    }
                    else
                    {
                        warning = I18n.Translate("internal/ImportForm/dangerscript", "Some of the imported triggers include triggers which execute arbitrary scripts. These triggers can be dangerous and malicious triggers may even compromise your system and security. The items in question have been highlighted below.");
                    }
                }
                else if (includesWmsg == true)
                {
                    warning = I18n.Translate("internal/ImportForm/dangerwmsg", "Some of the imported triggers include triggers which send arbitrary window messages. These triggers can be dangerous and malicious triggers may even compromise your system and security. The items in question have been highlighted below.");
                }
            }
            if (warning.Length > 0)
            {
                lblWarning.Text = warning;
                lblWarning.Visible = true;
            }
        }

        internal void BuildTreeFromExport(TriggernometryExport tex, TreeNode parentnode, Folder parentfolder, bool isRemote)
        {
            if (parentfolder == null)
            {
                TreeNode tn = new TreeNode();
                treeView1.Nodes.Add(tn);
                if (tex.ExportedFolder != null)
                {
                    tn.ImageIndex = 0;
                    tn.SelectedImageIndex = 0;
                    tn.Text = tex.ExportedFolder.Name;
                    tn.Checked = tex.ExportedFolder.Enabled;
                    tn.Tag = tex.ExportedFolder;
                    BuildTreeFromExport(tex, tn, tex.ExportedFolder, isRemote);
                    return;
                }
                else
                {
                    tn.ImageIndex = 2;
                    tn.SelectedImageIndex = 2;
                    tn.Text = tex.ExportedTrigger.Name;
                    tn.Checked = tex.ExportedTrigger.Enabled;
                    tn.Tag = tex.ExportedTrigger;
                    return;
                }                
            }
            foreach (Folder f in parentfolder.Folders)
            {
                TreeNode tn = new TreeNode();
                tn.Text = f.Name;
                tn.Checked = f.Enabled;
                tn.Tag = f;
                tn.ImageIndex = 0;
                tn.SelectedImageIndex = 0;
                parentnode.Nodes.Add(tn);
                f.Parent = parentfolder;
                BuildTreeFromExport(tex, tn, f, isRemote);
            }
            foreach (Trigger t in parentfolder.Triggers)
            {
                TreeNode tn = new TreeNode();
                tn.Text = t.Name;
                tn.Checked = t.Enabled;
                tn.Tag = t;
                tn.ImageIndex = 2;
                tn.SelectedImageIndex = 2;
                if ((IsLaunchTrigger(t) == true || IsScriptTrigger(t) == true || IsWmsgTrigger(t) == true) && isRemote == false)
                {
                    tn.BackColor = Color.Yellow;
                }
                parentnode.Nodes.Add(tn);
                t.Parent = parentfolder;
            }
        }

        private void TryImportAct()
        {
            string warning = "";
            bool includesTabs = false;
            bool includesTimers = false;
            Folder rootf = new Folder();
            rootf.Name = I18n.Translate("internal/ImportForm/importedacttriggers", "Imported ACT triggers ({0})", DateTime.Now);
            TreeNode root = new TreeNode();
            root.Text = rootf.Name;
            root.Tag = rootf;
            rootf.Enabled = true;
            root.Checked = true;
            root.ImageIndex = 0;
            root.SelectedImageIndex = 0;
            treeView1.Nodes.Add(root);
            var trigs = plug.CustomTriggerHook();
            foreach (var trig in trigs)
            {
                Folder f = new Folder();
                f.Name = trig.Category;
                if (trig.RestrictToCategoryZone == true)
                {
                    f.ZoneFilterEnabled = true;
                    f.ZoneFilterRegularExpression = f.Name;
                }
                f.Name += (trig.RestrictToCategoryZone == true ? " (" + I18n.Translate("internal/ImportForm/restrictedtozone", "restricted to zone") +")" : "");
                TreeNode fn = new TreeNode();
                fn.Text = f.Name;
                f.Enabled = true;
                fn.Checked = true;
                fn.Tag = f;
                fn.ImageIndex = 0;
                fn.SelectedImageIndex = 0;
                root.Nodes.Add(fn);
                rootf.Folders.Add(f);
                f.Parent = rootf;                
                foreach (RealPlugin.CustomTriggerProxy ct in trig.Items)
                {
                    TreeNode tn = new TreeNode();
                    Trigger t = new Trigger();                    
                    t = ImportActTrigger(ct.Active, ct.ShortRegexString, ct.SoundData, ct.SoundType, ct.TimerName, ct.Tabbed, ct.Timer);
                    includesTabs = (includesTabs == true || ct.Tabbed == true);
                    includesTimers = (includesTimers == true || ct.Timer == true);
                    if (ct.Tabbed == true || ct.Timer == true)
                    {                        
                        tn.BackColor = Color.Yellow;
                    }                                  
                    tn.Text = t.Name;
                    tn.Tag = t;
                    tn.Checked = t.Enabled;
                    tn.ImageIndex = 2;
                    tn.SelectedImageIndex = 2;
                    fn.Nodes.Add(tn);
                    f.Triggers.Add(t);
                    t.Parent = f;
                }
            }
            treeView1.ExpandAll();
            if (includesTabs == true || includesTimers == true)
            {
                // todo 18n this
                warning = "Some of the imported ACT triggers include triggers which ";
                if (includesTabs == true)
                {
                    warning += "add results to a tab";
                    if (includesTimers == true)
                    {
                        warning += " and fire timers.";
                    }
                }
                else if (includesTimers == true)
                {
                    warning += "fire timers.";
                }
                warning += " However, importing these options is currently not supported. The affected items have been highlighted below.";
            }
            if (warning.Length > 0)
            {
                lblWarning.Text = warning;
                lblWarning.Visible = true;
            }
        }

        private Trigger ImportActTrigger(bool active, string regex, string soundData, int soundType, string tabname, bool tabbed, bool timer)
        {
            Trigger t = new Trigger();
            t.RegularExpression = regex;
            t.Name = t.RegularExpression;
            t.Enabled = active;
            t.PrevActions = Trigger.PrevActionsEnum.Keep;
            t.PrevActionsRefire = Trigger.RefireEnum.Allow;
            t.Scheduling = Trigger.SchedulingEnum.FromFire;
            t.PeriodRefire = Trigger.RefireEnum.Allow;
            t.RefirePeriodExpression = "";
            string tag = "";
            if (tabbed == true)
            {
                tag += "unsupported tabs";                
                if (timer == true)
                {
                    tag += " and timers";                    
                }
            }
            else if (timer == true)
            {
                tag += "unsupported timers";
            }
            if (tag.Length > 0)
            {
                t.Name += " (" + tag + ")";
            }
            switch (soundType)
            {
                case 0:
                    break;
                case 1:
                    {
                        Action a = new Action();
                        a.ActionType = Action.ActionTypeEnum.SystemBeep;
                        a.SystemBeepFreqExpression = "1000";
                        a.SystemBeepLengthExpression = "100";
                        a.OrderNumber = 1;
                        t.Actions.Add(a);
                    }
                    break;
                case 2:
                    {
                        Action a = new Action();
                        a.ActionType = Action.ActionTypeEnum.PlaySound;
                        a._PlaySoundExclusive = true;
                        a.PlaySoundFileExpression = soundData;
                        a.PlaySoundVolumeExpression = "100";
                        a.OrderNumber = 1;
                        t.Actions.Add(a);
                    }
                    break;
                case 3:
                    {
                        Action a = new Action();
                        a.ActionType = Action.ActionTypeEnum.UseTTS;
                        a._UseTTSExclusive = true;
                        a.UseTTSTextExpression = soundData;
                        a.UseTTSVolumeExpression = "100";
                        a.UseTTSRateExpression = "0";
                        a.OrderNumber = 1;
                        t.Actions.Add(a);
                    }
                    break;
            }
            return t;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                btnEdit.Enabled = false;
                btnRemove.Enabled = false;
            }
            else
            {
                if (treeView1.SelectedNode.ImageIndex == 2)
                {
                    btnEdit.Enabled = true;
                    btnRemove.Enabled = (treeView1.SelectedNode.Parent != null);
                }
                else if (treeView1.SelectedNode.ImageIndex == 0 || treeView1.SelectedNode.ImageIndex == 1)
                {
                    btnEdit.Enabled = true;
                    btnRemove.Enabled = (treeView1.SelectedNode.Parent != null);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.ImageIndex == 2)
            {
                Trigger t = (Trigger)treeView1.SelectedNode.Tag;
                TreeNode tn = treeView1.SelectedNode;
                tn.Parent.Nodes.Remove(tn);
                t.Parent.Triggers.Remove(t);
            }
            else if (treeView1.SelectedNode.ImageIndex == 0 || treeView1.SelectedNode.ImageIndex == 1)
            {
                Folder f = (Folder)treeView1.SelectedNode.Tag;
                TreeNode tn = treeView1.SelectedNode;
                tn.Parent.Nodes.Remove(tn);
                f.Parent.Folders.Remove(f);
            }
            btnNext.Enabled = (treeView1.Nodes[0].Nodes.Count > 0);
        }

        private void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ImageIndex = 0;
            e.Node.SelectedImageIndex = 0;
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ImageIndex = 1;
            e.Node.SelectedImageIndex = 1;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView1.SelectedNode = e.Node;
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == treeView1.SelectedNode && (treeView1.SelectedNode != null) && btnEdit.Enabled == true && (treeView1.SelectedNode.ImageIndex == 2))
            {
                btnEdit_Click(sender, null);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.ImageIndex == 2)
            {
                using (Forms.TriggerForm tf = new Forms.TriggerForm())
                {
                    Trigger t = (Trigger)treeView1.SelectedNode.Tag;
                    tf.trv = trv;
                    tf.imgs = imgs;
                    tf.SettingsFromTrigger(t);
                    tf.plug = plug;
                    tf.fakectx.plug = plug;
                    tf.Text = I18n.Translate("internal/ImportForm/editimportedtrigger", "Edit imported trigger '{0}'", t.Name);
                    tf.btnOk.Text = I18n.Translate("internal/ImportForm/savechanges", "Save changes");
                    tf.wmp = wmp;
                    tf.tts = tts;
                    if (tf.ShowDialog() == DialogResult.OK)
                    {
                        lock (t) // verified
                        {
                            tf.SettingsToTrigger(t);
                        }
                        TreeNode tn = treeView1.SelectedNode;
                        tn.Text = t.Name;
                        treeView1.Sort();
                        treeView1.SelectedNode = tn;
                    }
                }
            }
            else if (treeView1.SelectedNode.ImageIndex == 0 || treeView1.SelectedNode.ImageIndex == 1)
            {
                using (Forms.FolderForm ff = new Forms.FolderForm())
                {
                    ff.plug = plug;
                    Folder f = (Folder)treeView1.SelectedNode.Tag;
                    ff.SettingsFromFolder(f);
                    ff.Text = I18n.Translate("internal/ImportForm/editimportedfolder", "Edit imported folder '{0}'", f.Name);
                    ff.btnOk.Text = I18n.Translate("internal/ImportForm/savechanges", "Save changes");
                    if (ff.ShowDialog() == DialogResult.OK)
                    {
                        ff.SettingsToFolder(f);
                        TreeNode tn = treeView1.SelectedNode;
                        tn.Text = f.Name;
                        treeView1.Sort();
                        treeView1.SelectedNode = tn;
                    }
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRemove_Click(sender, e);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            ctxEdit.Enabled = btnEdit.Enabled;
            cxtRemove.Enabled = btnRemove.Enabled;
        }

        private void TryImportActWrapper(string data)
        {
            string warning = "";
            bool includesTabs = false;
            bool includesTimers = false;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);
            XmlNode xroot = doc.SelectSingleNode("./ActWrapper");
            XmlNodeList triggers = xroot.SelectNodes("./Trigger");
            if (triggers.Count == 0)
            {
                throw new ArgumentException(I18n.Translate("internal/ImportForm/sourcenotactformat", "The provided source does not appear to contain any triggers in ACT's export format."));
            }
            Dictionary<string, List<Tuple<bool, bool, string, Trigger>>> trx = new Dictionary<string, List<Tuple<bool, bool, string, Trigger>>>();
            foreach (XmlNode trigger in triggers)
            {
                bool active = true;
                string regex = trigger.Attributes["R"].Value;
                string soundData = trigger.Attributes["SD"].Value;
                int soundType = Int32.Parse(trigger.Attributes["ST"].Value);
                bool zoneRestr = (trigger.Attributes["CR"].Value == "T" ? true : false);
                string category = trigger.Attributes["C"].Value;
                string tabname = trigger.Attributes["TN"].Value;
                bool tabbed = (trigger.Attributes["Ta"].Value == "T" ? true : false);
                bool timer = (trigger.Attributes["T"].Value == "T" ? true : false);
                Trigger t = ImportActTrigger(active, regex, soundData, soundType, tabname, tabbed, timer);
                includesTabs = (includesTabs == true || tabbed == true);
                includesTimers = (includesTimers == true || timer == true);
                string catname = zoneRestr + "|" + category;
                if (trx.ContainsKey(catname) == false)
                {
                    trx[catname] = new List<Tuple<bool, bool, string, Trigger>>();
                }
                trx[catname].Add(new Tuple<bool, bool, string, Trigger>(zoneRestr, (tabbed || timer), category, t));
            }
            XmlNodeList spells = xroot.SelectNodes("./Spell");
            if (spells.Count > 0)
            {
                includesTimers = true;
            }
            Folder rootf = new Folder();
            rootf.Name = I18n.Translate("internal/ImportForm/importedacttriggers", "Imported ACT triggers ({0})", DateTime.Now);
            TreeNode root = new TreeNode();
            root.Text = rootf.Name;
            root.Tag = rootf;
            root.ImageIndex = 0;
            root.Checked = true;
            root.SelectedImageIndex = 0;
            treeView1.Nodes.Add(root);
            foreach (KeyValuePair<string, List<Tuple<bool, bool, string, Trigger>>> kp in trx)
            {
                Folder f = new Folder();
                f.Enabled = true;
                f.Name = kp.Value[0].Item3;
                if (kp.Value[0].Item1 == true)
                {
                    f.ZoneFilterEnabled = true;
                    f.ZoneFilterRegularExpression = kp.Value[0].Item3;
                }
                f.Name += (kp.Value[0].Item1 == true ? " (" + I18n.Translate("internal/ImportForm/restrictedtozone", "restricted to zone") + ")" : "");
                TreeNode fn = new TreeNode();
                fn.Text = f.Name;
                fn.Tag = f;
                fn.ImageIndex = 0;
                fn.Checked = f.Enabled;
                fn.SelectedImageIndex = 0;
                root.Nodes.Add(fn);
                rootf.Folders.Add(f);
                f.Parent = rootf;
                foreach (Tuple<bool, bool, string, Trigger> tupp in kp.Value)
                {
                    Trigger t = tupp.Item4;
                    TreeNode tn = new TreeNode();
                    if (tupp.Item2 == true)
                    {
                        tn.BackColor = Color.Yellow;
                    }
                    tn.Text = t.Name;
                    tn.Tag = t;
                    tn.ImageIndex = 2;
                    tn.Checked = t.Enabled;
                    tn.SelectedImageIndex = 2;
                    fn.Nodes.Add(tn);
                    f.Triggers.Add(t);
                    t.Parent = f;
                }
            }
            treeView1.ExpandAll();
            if (includesTabs == true || includesTimers == true)
            {
                if (includesTabs == true)
                {
                    if (includesTimers == true)
                    {
                        warning = I18n.Translate("internal/ImportForm/warnacttabtimers", "Some of the imported ACT triggers include triggers which add results to a tab and fire timers. However, importing these options is currently not supported. The affected items have been highlighted below.");
                    }
                    else
                    {
                        warning = I18n.Translate("internal/ImportForm/warnacttab", "Some of the imported ACT triggers include triggers which add results to a tab. However, importing these options is currently not supported. The affected items have been highlighted below.");
                    }
                }
                else if (includesTimers == true)
                {
                    warning = I18n.Translate("internal/ImportForm/warnacttimers", "Some of the imported ACT triggers include triggers which fire timers. However, importing these options is currently not supported. The affected items have been highlighted below.");
                }
            }
            if (warning.Length > 0)
            {
                lblWarning.Text = warning;
                lblWarning.Visible = true;
            }
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            ctxPasteFromClipboard.Enabled = btnPaste.Enabled;
        }

        private void pasteFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPaste_Click(sender, e);
        }

        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;
            return ContainsNode(node1, node2.Parent);
        }

        private void TreeView1_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));
            treeView1.SelectedNode = treeView1.GetNodeAt(targetPoint);
            if (treeView1.SelectedNode.Tag is Trigger)
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void TreeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void TreeView1_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = treeView1.GetNodeAt(targetPoint);
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode) && !(targetNode.Tag is Trigger))
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
                }
                targetNode.Expand();
            }
        }

        private void TreeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Item != treeView1.Nodes[0])
                {
                    DoDragDrop(e.Item, DragDropEffects.Move);
                }
            }
        }

    }

}
