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
using Triggernometry.CustomControls;
using System.Text.RegularExpressions;
using System.Globalization;

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
            string starting = importData.Length > 100 ? importData.Substring(0, 100) : importData;
            starting = starting.TrimStart();
            bool isHtml;

            if (starting.StartsWith("<"))
                isHtml = false;
            else if (starting.StartsWith("&lt;"))
                isHtml = true;
            else
                throw new Exception(I18n.Translate("internal/ImportForm/importerrornotxml",
                    "The provided data does not show any XML characteristics. Please open the file and examine it, or check if the pasted data is complete."));

            string data = isHtml ? WebUtility.HtmlDecode(importData) : importData;
            starting = data.Length > 100 ? data.Substring(0, 100) : data;
            starting = starting.Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ").TrimStart();

            Match match = new Regex("(?:<\\?xml[^>]*> *)?<(?<root>[^ >]+)").Match(starting);
            string rootNodeName = match.Groups["root"].Value;
            
            switch (rootNodeName)
            {
                case "TriggernometryExport":
                    {
                        TriggernometryExport tex = TriggernometryExport.Unserialize(importData);
                        if (tex.Corrupted)
                        {
                            throw new Exception(I18n.Translate("internal/ImportForm/importerrortrig",
                                "The TriggernometryExport data was from version {0}. " +
                                "Please make sure you are running the latest version of Triggernometry. " +
                                "If you are already running the latest version, the data might have been corrupted.",
                                tex.PluginVersionDescription));
                        }
                        TryImportExport(tex);
                        return;
                    }
                case "Configuration":
                    {
                        Configuration cfg;
                        XmlSerializer xs = new XmlSerializer(typeof(Configuration));
                        using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data)))
                        {
                            try
                            {
                                cfg = (Configuration)xs.Deserialize(ms);
                            }
                            catch
                            {
                                throw new Exception(I18n.Translate("internal/ImportForm/importerrorconfig",
                                    "Please make sure you are running the latest version of Triggernometry. " + 
                                    "If you are already running the latest version, " +
                                    "the imported config data might have been corrupted."));
                            }
                            TriggernometryExport tex = new TriggernometryExport();
                            tex.PluginVersion = cfg.Constants.ContainsKey("TriggernometryVersionMajor")
                                ? $"{cfg.Constants["TriggernometryVersionMajor"]}.{cfg.Constants["TriggernometryVersionMinor"]}.{cfg.Constants["TriggernometryVersionBuild"]}.{cfg.Constants["TriggernometryVersionRevision"]}"
                                : $"1.1.6.6";
                            tex.ExportedFolder = cfg.Root;
                            tex.ExportedFolder.Name = I18n.Translate("internal/ImportForm/importedconfigfile", "Imported configuration file ({0})", DateTime.Now);
                            tex.ExportedTrigger = null;
                            TryImportExport(tex);
                            return;
                        }
                    }
                case "Trigger":
                    {
                        string nex = "<ActWrapper>" + importData + "</ActWrapper>";
                        try
                        {
                            TryImportActWrapper(nex);
                        }
                        catch
                        {
                            throw new Exception(I18n.Translate("internal/ImportForm/importerroracttrigger",
                                "The native ACT triggers cannot be read, possibly due to corrupted content."));
                        }
                        return;
                    }
                case "Language":
                    switch (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToLower())
                    {   
                        case "fr": throw new Exception("Vous essayez d'importer un fichier de localisation et non un déclencheur. Les fichiers de localisation doivent être placés dans le même répertoire que Triggernometry.dll.");
                        case "jp": throw new Exception("トリガーではなく、ローカライズファイルをインポートしようとしています。ローカライズファイルは Triggernometry.dll と同じディレクトリに配置する必要があります。");
                        case "zh": throw new Exception("你导入了汉化文件，而非触发器。汉化文件应直接置于 Triggernometry.dll 同目录下。");
                        // case ...
                        default:   throw new Exception("You are attempting to import a localization file instead of a trigger. Localization files should be placed in the same directory as Triggernometry.dll.");
                    }
                default:
                    throw new Exception(I18n.Translate("internal/ImportForm/importerrorunknownroot",
                        "The XML contains data of a {0} object, which is not designed to be imported by Triggernometry.", rootNodeName));
            }
        }

        private bool IsActionTypeTrigger(Trigger trigger, Action.ActionTypeEnum actionType)
            => trigger.Actions.Any(action => action._ActionType == actionType);

        private bool HasActionTypeTrigger(Folder folder, Action.ActionTypeEnum actionType)
            => folder.Triggers.Any(trigger => IsActionTypeTrigger(trigger, actionType)) ||
               folder.Folders.Any(subfolder => HasActionTypeTrigger(subfolder, actionType));

        private bool HasActionTypeTrigger(TriggernometryExport tex, Action.ActionTypeEnum actionType)
            => tex.ExportedFolder != null ? HasActionTypeTrigger(tex.ExportedFolder, actionType)
                                          : IsActionTypeTrigger(tex.ExportedTrigger, actionType);

        private void TryImportExport(TriggernometryExport tex)
        {
            BuildTreeFromExport(tex, null, null, false);
            treeView1.ExpandAll();

            lblWarning.Text = I18n.Translate("internal/ImportForm/version", 
                "Source plugin version: {0}    Current plugin version: {1}",
                tex.PluginVersionDescription, RealPlugin.plug.cfg.PluginVersion);

            List<string> warningComponents = new List<string>();

            if (HasActionTypeTrigger(tex, Action.ActionTypeEnum.DiskFile))
                warningComponents.Add(I18n.Translate("internal/ImportForm/dangerDisk", "perform file operations"));
            if (HasActionTypeTrigger(tex, Action.ActionTypeEnum.LaunchProcess))
                warningComponents.Add(I18n.Translate("internal/ImportForm/dangerProc", "launch arbitrary processes"));
            if (HasActionTypeTrigger(tex, Action.ActionTypeEnum.ExecuteScript))
                warningComponents.Add(I18n.Translate("internal/ImportForm/dangerScript", "execute arbitrary scripts"));
            if (HasActionTypeTrigger(tex, Action.ActionTypeEnum.WindowMessage))
                warningComponents.Add(I18n.Translate("internal/ImportForm/dangerWmsg", "send arbitrary window messages"));

            if (warningComponents.Count > 0)
            {
                string dangerDescriptions = string.Join(I18n.Translate("internal/ImportForm/dangerDescJoiner", ", "), warningComponents);
                string warning = I18n.Translate("internal/ImportForm/danger",
                    "Some of the imported triggers include triggers which {0}. \n" +
                    "These triggers can be dangerous and malicious triggers may even compromise your system and security. " +
                    "The items in question have been highlighted below.",
                    dangerDescriptions);
                lblWarning.Text += "\n\n" + warning;
            }
            lblWarning.Visible = true;
        }

        internal void BuildTreeFromExport(TriggernometryExport tex, TreeNode parentnode, Folder parentfolder, bool isRemote)
        {
            if (parentfolder == null)
            {
                TreeNode tn = new TreeNode();
                treeView1.Nodes.Add(tn);
                if (tex.ExportedFolder != null)
                {
                    tn.ImageIndex = (int)CustomControls.UserInterface.GetImageIndexForClosedFolder(tex.ExportedFolder);
                    tn.SelectedImageIndex = tn.ImageIndex;
                    tn.Text = tex.ExportedFolder.Name;
                    tn.Checked = tex.ExportedFolder.Enabled;
                    tn.Tag = tex.ExportedFolder;
                    BuildTreeFromExport(tex, tn, tex.ExportedFolder, isRemote);
                    return;
                }
                else
                {
                    tn.ImageIndex = (int)CustomControls.UserInterface.ImageIndices.Bolt;
                    tn.SelectedImageIndex = tn.ImageIndex;
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
                tn.ImageIndex = (int)CustomControls.UserInterface.GetImageIndexForClosedFolder(f);
                tn.SelectedImageIndex = tn.ImageIndex;
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
                tn.ImageIndex = (int)CustomControls.UserInterface.ImageIndices.Bolt;
                tn.SelectedImageIndex = tn.ImageIndex;
                if ((IsActionTypeTrigger(t, Action.ActionTypeEnum.DiskFile) ||
                     IsActionTypeTrigger(t, Action.ActionTypeEnum.LaunchProcess) ||
                     IsActionTypeTrigger(t, Action.ActionTypeEnum.ExecuteScript) ||
                     IsActionTypeTrigger(t, Action.ActionTypeEnum.WindowMessage)) && !isRemote)
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
            root.ImageIndex = (int)CustomControls.UserInterface.GetImageIndexForClosedFolder(rootf);
            root.SelectedImageIndex = root.ImageIndex;
            treeView1.Nodes.Add(root);
            var trigs = plug.CustomTriggerHook();
            foreach (var trig in trigs)
            {
                Folder f = new Folder();
                f.Name = trig.Category;
                if (trig.RestrictToCategoryZone == true)
                {
                    f._ZoneFilterEnabled = true;
                    f.ZoneFilterRegularExpression = f.Name;
                }
                f.Name += (trig.RestrictToCategoryZone == true ? " (" + I18n.Translate("internal/ImportForm/restrictedtozone", "restricted to zone") +")" : "");
                TreeNode fn = new TreeNode();
                fn.Text = f.Name;
                f.Enabled = true;
                fn.Checked = true;
                fn.Tag = f;
                fn.ImageIndex = (int)CustomControls.UserInterface.GetImageIndexForClosedFolder(f);
                fn.SelectedImageIndex = fn.ImageIndex;
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
                    tn.ImageIndex = (int)CustomControls.UserInterface.ImageIndices.Bolt;
                    tn.SelectedImageIndex = tn.ImageIndex;
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
            t._PrevActions = Trigger.PrevActionsEnum.Keep;
            t._PrevActionsRefire = Trigger.RefireEnum.Allow;
            t._Scheduling = Trigger.SchedulingEnum.FromFire;
            t._PeriodRefire = Trigger.RefireEnum.Allow;
            t._RefirePeriodExpression = "";
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
                        a._ActionType = Action.ActionTypeEnum.SystemBeep;
                        a._SystemBeepFreqExpression = "1046.5"; // C6
                        a._SystemBeepLengthExpression = "100";
                        a.OrderNumber = 1;
                        t.Actions.Add(a);
                    }
                    break;
                case 2:
                    {
                        Action a = new Action();
                        a._ActionType = Action.ActionTypeEnum.PlaySound;
                        a._PlaySoundExclusive = true;
                        a._PlaySoundFileExpression = soundData;
                        a._PlaySoundVolumeExpression = "100";
                        a.OrderNumber = 1;
                        t.Actions.Add(a);
                    }
                    break;
                case 3:
                    {
                        Action a = new Action();
                        a._ActionType = Action.ActionTypeEnum.UseTTS;
                        a._UseTTSExclusive = true;
                        a._UseTTSTextExpression = soundData;
                        a._UseTTSVolumeExpression = "100";
                        a._UseTTSRateExpression = "0";
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
            else if (
                (treeView1.SelectedNode.Tag is Trigger)
                ||
                (treeView1.SelectedNode.Tag is Folder)
            )
            {
                btnEdit.Enabled = true;
                btnRemove.Enabled = (treeView1.SelectedNode.Parent != null);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag is Trigger)
            {
                Trigger t = (Trigger)treeView1.SelectedNode.Tag;
                TreeNode tn = treeView1.SelectedNode;
                tn.Parent.Nodes.Remove(tn);
                t.Parent.Triggers.Remove(t);
            }
            else if (treeView1.SelectedNode.Tag is Folder)
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
            if (e.Node.Tag is Folder)
            {
                e.Node.ImageIndex = (int)CustomControls.UserInterface.GetImageIndexForClosedFolder((Folder)e.Node.Tag);
                e.Node.SelectedImageIndex = e.Node.ImageIndex;
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag is Folder)
            {
                e.Node.ImageIndex = (int)CustomControls.UserInterface.GetImageIndexForOpenFolder((Folder)e.Node.Tag);
                e.Node.SelectedImageIndex = e.Node.ImageIndex;
            }
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
            if (e.Node == treeView1.SelectedNode && (treeView1.SelectedNode != null) && btnEdit.Enabled == true && (treeView1.SelectedNode.Tag is Trigger))
            {
                btnEdit_Click(sender, null);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag is Trigger t)
            {
                using (Forms.TriggerForm tf = new Forms.TriggerForm(t))
                {
                    tf.trv = trv;
                    tf.imgs = imgs;
                    tf.Text = I18n.Translate("internal/ImportForm/editimportedtrigger", "Edit imported trigger '{0}'", t.Name);
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
            else if (treeView1.SelectedNode.Tag is Folder)
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
            ctxRemove.Enabled = btnRemove.Enabled;
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
            root.ImageIndex = (int)CustomControls.UserInterface.GetImageIndexForClosedFolder(rootf);
            root.SelectedImageIndex = root.ImageIndex;
            root.Checked = true;
            treeView1.Nodes.Add(root);
            foreach (KeyValuePair<string, List<Tuple<bool, bool, string, Trigger>>> kp in trx)
            {
                Folder f = new Folder();
                f.Enabled = true;
                f.Name = kp.Value[0].Item3;
                if (kp.Value[0].Item1 == true)
                {
                    f._ZoneFilterEnabled = true;
                    f.ZoneFilterRegularExpression = kp.Value[0].Item3;
                }
                f.Name += (kp.Value[0].Item1 == true ? " (" + I18n.Translate("internal/ImportForm/restrictedtozone", "restricted to zone") + ")" : "");
                TreeNode fn = new TreeNode();
                fn.Text = f.Name;
                fn.Tag = f;
                fn.ImageIndex = (int)CustomControls.UserInterface.GetImageIndexForClosedFolder(f);
                fn.SelectedImageIndex = fn.ImageIndex;
                fn.Checked = f.Enabled;
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
                    tn.ImageIndex = (int)CustomControls.UserInterface.ImageIndices.Bolt;
                    tn.SelectedImageIndex = tn.ImageIndex;
                    tn.Checked = t.Enabled;
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
