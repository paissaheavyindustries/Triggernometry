using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Triggernometry.Variables;

namespace Triggernometry.Forms
{

    public partial class ConfigurationForm : MemoryForm<ConfigurationForm>
    {

        bool cancomplain;
        internal RealPlugin plug;
        private bool firstchange = true;
        private List<Configuration.Substitution> subs = new List<Configuration.Substitution>();
        private Trigger template = new Trigger();
        private Dictionary<string, VariableScalar> consts = new Dictionary<string, VariableScalar>();

        public ConfigurationForm()
        {
            InitializeComponent();
            cancomplain = false;
            SetupJobOrder(null);
            label5.Tag = I18n.DoNotTranslate;
            label6.Tag = I18n.DoNotTranslate;
            RestoredSavedDimensions();
            tbcMain.TabPages.Remove(tabEndpoint);
        }

        internal void SecuritySettingsFromConfiguration(Configuration cfg)
        {
            IEnumerable<Configuration.APIUsage> apis = cfg.GetAPIUsages();
            if (apis == null)
            {
                apis = plug.GetDefaultAPIUsages();
            }
            foreach (Configuration.APIUsage ap in apis)
            {
                dgvApiAccess.Rows.Add(new object[] { ap.Name, ap.AllowLocal, ap.AllowRemote, ap.AllowAdmin });
            }
        }

        internal void SettingsFromConfiguration(Configuration a)
        {
            if (a == null)
            {
                Configuration c = new Configuration();
                trbSoundVolume.Value = 100;
                trbTtsVolume.Value = 100;
                cbxLoggingLevel.SelectedIndex = 2;
                chkActTts.Checked = false;
                chkActSoundFiles.Checked = false;
                chkClipboard.Checked = false;
                cbxDevMode.Checked = false;
                txtSeparator.Text = "";
                cbxFfxivJobMethod.SelectedIndex = 0;                
                chkWelcome.Checked = true;
                chkUpdates.Checked = false;
                cbxUpdateMethod.SelectedIndex = 1;
                chkWarnAdmin.Checked = true;
                cbxTestLive.Checked = false;
                cbxActionAsync.Checked = true;
                chkLogNormalEvents.Checked = true;
                chkLogVariableExpansions.Checked = false;
                chkFfxivLogNetwork.Checked = false;
                cbxEnableHwAccel.Checked = false;
                txtMonitorWindow.Text = "";
                nudCacheImageExpiry.Value = 518400;
                nudCacheSoundExpiry.Value = 518400;
                nudCacheJsonExpiry.Value = 10080;
                nudCacheRepoExpiry.Value = 518400;
                nudCacheFileExpiry.Value = 518400;
                dgvSubstitutions.RowCount = 0;
                cbxAutosaveConfig.Checked = false;
                nudAutosaveMinutes.Value = 5;
                SecuritySettingsFromConfiguration(null);
                SetupConsts(null);
            }
            else
            {
                trbSoundVolume.Value = a.SfxVolumeAdjustment;                
                trbTtsVolume.Value = a.TtsVolumeAdjustment;
                cbxLoggingLevel.SelectedIndex = (int)a.DebugLevel;
                chkActTts.Checked = a.UseACTForTTS;
                chkActSoundFiles.Checked = a.UseACTForSound;
                chkClipboard.Checked = a.UseOsClipboard;
                txtSeparator.Text = a.EventSeparator;
                cbxDevMode.Checked = a.DeveloperMode;
                cbxFfxivJobMethod.SelectedIndex = (int)a.FfxivPartyOrdering;
                chkWelcome.Checked = a.ShowWelcome;
                chkWarnAdmin.Checked = a.WarnAdmin;
                cbxTestLive.Checked = a.TestLiveByDefault;
                cbxActionAsync.Checked = a.ActionAsyncByDefault;
                chkUpdates.Checked = (a.UpdateNotifications == Configuration.UpdateNotificationsEnum.Yes);
                cbxUpdateMethod.SelectedIndex = (int)a.UpdateCheckMethod;
                chkLogNormalEvents.Checked = a.LogNormalEvents;
                chkLogVariableExpansions.Checked = a.LogVariableExpansions;
                chkFfxivLogNetwork.Checked = a.FfxivLogNetwork;
                cbxEnableHwAccel.Checked = a.UseScarborough;
                txtMonitorWindow.Text = a.WindowToMonitor;
                nudCacheImageExpiry.Value = a.CacheImageExpiry;
                nudCacheSoundExpiry.Value = a.CacheSoundExpiry;
                nudCacheJsonExpiry.Value = a.CacheJsonExpiry;
                nudCacheRepoExpiry.Value = a.CacheRepoExpiry;
                nudCacheFileExpiry.Value = a.CacheFileExpiry;
                subs.AddRange(a.Substitutions);
                subs.Sort();
                dgvSubstitutions.RowCount = a.Substitutions.Count;
                cbxAutosaveConfig.Checked = a.AutosaveEnabled;
                nudAutosaveMinutes.Value = a.AutosaveInterval;
                cbxTriggerTemplate.Checked = a.UseTemplateTrigger;
                a.TemplateTrigger.CopySettingsTo(template);
                SetupJobOrder(a);
                SecuritySettingsFromConfiguration(a);
                SetupConsts(plug.cfg.Constants);
            }
            if (a.StartupTriggerType == Configuration.StartupTriggerTypeEnum.Trigger)
            {
                TreeNode tn = plug.LocateNodeHostingTriggerId(trvTrigger.Nodes[0], a.StartupTriggerId, null);
                if (tn != null)
                {
                    tn.EnsureVisible();
                    trvTrigger.SelectedNode = tn;
                    trvTrigger.Update();
                }
            }
            if (a.StartupTriggerType == Configuration.StartupTriggerTypeEnum.Folder)
            {
                TreeNode tn = plug.LocateNodeHostingFolderId(trvTrigger.Nodes[0], a.StartupTriggerId, null);
                if (tn != null)
                {
                    tn.EnsureVisible();
                    trvTrigger.SelectedNode = tn;
                    trvTrigger.Update();
                }
            }
        }

        internal void SettingsToConfiguration(Configuration a)
        {
            a.SfxVolumeAdjustment = trbSoundVolume.Value;
            a.TtsVolumeAdjustment = trbTtsVolume.Value;
            a.DebugLevel = (RealPlugin.DebugLevelEnum)cbxLoggingLevel.SelectedIndex;
            a.UseACTForTTS = chkActTts.Checked;
            a.UseACTForSound = chkActSoundFiles.Checked;
            a.EventSeparator = txtSeparator.Text;
            a.UseOsClipboard = chkClipboard.Checked;
            a.ShowWelcome = chkWelcome.Checked;
            a.WarnAdmin = chkWarnAdmin.Checked;
            a.TestLiveByDefault = cbxTestLive.Checked;
            a.ActionAsyncByDefault = cbxActionAsync.Checked;
            a.LogNormalEvents = chkLogNormalEvents.Checked;
            a.LogVariableExpansions = chkLogVariableExpansions.Checked;
            a.FfxivLogNetwork = chkFfxivLogNetwork.Checked;
            a.DeveloperMode = cbxDevMode.Checked;
            a.UseScarborough = cbxEnableHwAccel.Checked;
            a.WindowToMonitor = txtMonitorWindow.Text;
            a.CacheImageExpiry = (int)nudCacheImageExpiry.Value;
            a.CacheSoundExpiry = (int)nudCacheSoundExpiry.Value;            
            a.CacheJsonExpiry = (int)nudCacheJsonExpiry.Value;            
            a.CacheRepoExpiry = (int)nudCacheRepoExpiry.Value;
            a.CacheFileExpiry = (int)nudCacheFileExpiry.Value;
            a.AutosaveEnabled = cbxAutosaveConfig.Checked;
            a.AutosaveInterval = (int)nudAutosaveMinutes.Value;
            a.UseTemplateTrigger = cbxTriggerTemplate.Checked;
            template.CopySettingsTo(a.TemplateTrigger);
            a.FfxivPartyOrdering = (Configuration.FfxivPartyOrderingEnum)cbxFfxivJobMethod.SelectedIndex;
            if (chkUpdates.Checked == true)
            {
                a.UpdateNotifications = Configuration.UpdateNotificationsEnum.Yes;
            }
            else
            {
                if (a.UpdateNotifications != Configuration.UpdateNotificationsEnum.Undefined)
                {
                    a.UpdateNotifications = Configuration.UpdateNotificationsEnum.No;
                }
            }
            a.UpdateCheckMethod = (Configuration.UpdateCheckMethodEnum)cbxUpdateMethod.SelectedIndex;
            TreeNode tn = trvTrigger.SelectedNode;
            if (tn != null)
            {
                if (tn.Tag is Trigger)
                {
                    a.StartupTriggerId = ((Trigger)tn.Tag).Id;
                    a.StartupTriggerType = Configuration.StartupTriggerTypeEnum.Trigger;
                }
                if (tn.Tag is Folder)
                {
                    a.StartupTriggerId = ((Folder)tn.Tag).Id;
                    a.StartupTriggerType = Configuration.StartupTriggerTypeEnum.Folder;
                }
            }
            else
            {
                a.StartupTriggerId = Guid.Empty;
            }
            List<string> temp = new List<string>();
            foreach (FfxivJobOrderItem oi in lstFfxivJobOrder.Items)
            {
                temp.Add(oi.JobId.ToString()); 
            }
            a.FfxivCustomPartyOrder = String.Join(", ", temp);
            a.Substitutions.Clear();
            a.Substitutions.AddRange(subs);
            MethodInfo setter = a.GetType().GetMethod("AddAPIUsage", BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (DataGridViewRow r in dgvApiAccess.Rows)
            {
                Configuration.APIUsage au = new Configuration.APIUsage()
                {
                    Name = (string)r.Cells[0].Value,
                    AllowLocal = (bool)r.Cells[1].Value,
                    AllowRemote = (bool)r.Cells[2].Value,
                    AllowAdmin = (bool)r.Cells[3].Value
                };
                setter.Invoke(a, new object[] { au, true });
            }
            lock (plug.cfg.Constants)
            {
                plug.cfg.Constants.Clear();
                foreach (KeyValuePair<string, VariableScalar> kp in consts)
                {
                    plug.cfg.Constants[kp.Key] = kp.Value;
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label5.Text = trbSoundVolume.Value + " %";
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label6.Text = trbTtsVolume.Value + " %";
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1_Scroll(sender, e);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            trackBar2_Scroll(sender, e);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActTts.Checked == false || cancomplain == false)
            {
                return;
            }
            if (MessageBox.Show(this, I18n.Translate("internal/ConfigurationForm/actttswarn", "Using ACT for text-to-speech will cause the rate and volume options on text-to-speech actions to be ignored. Change anyway?"), I18n.Translate("internal/ConfigurationForm/warning", "Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                chkActTts.Checked = false;
            }
        }

        private void ConfigurationForm_Shown(object sender, EventArgs e)
        {
            cancomplain = true;
            cbxAutosaveConfig_CheckedChanged(null, null);
            RefreshCacheStates();
        }

        private void trvTrigger_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag is Folder)
            {
                e.Node.ImageIndex = (int)CustomControls.UserInterface.GetImageIndexForClosedFolder((Folder)e.Node.Tag);
                e.Node.SelectedImageIndex = e.Node.ImageIndex;
            }
        }

        private void trvTrigger_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag is Folder)
            {
                e.Node.ImageIndex = (int)CustomControls.UserInterface.GetImageIndexForOpenFolder((Folder)e.Node.Tag);
                e.Node.SelectedImageIndex = e.Node.ImageIndex;
            }
        }

        private void trvTrigger_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node == trvTrigger.Nodes[0])
            {
                e.Cancel = true;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            ctxClearSelection.Enabled = (trvTrigger.SelectedNode != null);
        }

        private void clearSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trvTrigger.SelectedNode = null;
            btnClearSelection.Enabled = false;
            lblFolderReminder.Visible = false;
        }

        private void cbxFfxivJobMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxFfxivJobMethod.SelectedIndex)
            {
                case 0:
                    toolStrip1.Enabled = false;
                    lstFfxivJobOrder.Enabled = false;
                    break;
                case 1:
                    toolStrip1.Enabled = true;
                    lstFfxivJobOrder.Enabled = true;                    
                    break;
                case 2:
                    if (firstchange == false)
                    {
                        switch (MessageBox.Show(this, I18n.Translate("internal/ConfigurationForm/partyorderwarn", "Setting this option may break old triggers that rely on the player being the first party member on the list. Are you sure you would like to proceed?"), I18n.Translate("internal/ConfigurationForm/warning", "Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            case DialogResult.Yes:
                                break;
                            case DialogResult.No:
                                cbxFfxivJobMethod.SelectedIndex = (int)cbxFfxivJobMethod.Tag;
                                return;
                        }
                    }
                    toolStrip1.Enabled = true;
                    lstFfxivJobOrder.Enabled = true;
                    break;
            }
            cbxFfxivJobMethod.Tag = cbxFfxivJobMethod.SelectedIndex;
            firstchange = false;
        }

        private void lstFfxivJobOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFfxivJobUp.Enabled = (lstFfxivJobOrder.SelectedIndex > 0);
            btnFfxivJobDown.Enabled = (lstFfxivJobOrder.SelectedIndex >= 0 && lstFfxivJobOrder.SelectedIndex < lstFfxivJobOrder.Items.Count - 1);
        }

        private void lstFfxivJobOrder_EnabledChanged(object sender, EventArgs e)
        {
            if (lstFfxivJobOrder.Enabled == false)
            {
                lstFfxivJobOrder.ClearSelected();
            }
        }

        internal class FfxivJobOrderItem
        {

            public string Name { get; set; }
            public int JobId { get; set; }

            public override string ToString()
            {
                return Name;
            }

        }

        private void SetupJobOrder(Configuration cx)
        {
            lstFfxivJobOrder.Items.Clear();
            List<FfxivJobOrderItem> order = new List<FfxivJobOrderItem>();            
            order.Add(new FfxivJobOrderItem() { Name = "Paladin", JobId = 19 });
            order.Add(new FfxivJobOrderItem() { Name = "Gladiator", JobId = 1 });
            order.Add(new FfxivJobOrderItem() { Name = "Warrior", JobId = 21 });
            order.Add(new FfxivJobOrderItem() { Name = "Marauder", JobId = 3 });
            order.Add(new FfxivJobOrderItem() { Name = "Dark Knight", JobId = 32 });
            order.Add(new FfxivJobOrderItem() { Name = "Gunbreaker", JobId = 37 });
            order.Add(new FfxivJobOrderItem() { Name = "White Mage", JobId = 24 });
            order.Add(new FfxivJobOrderItem() { Name = "Conjurer", JobId = 6 });
            order.Add(new FfxivJobOrderItem() { Name = "Scholar", JobId = 28 });
            order.Add(new FfxivJobOrderItem() { Name = "Astrologian", JobId = 33 });
            order.Add(new FfxivJobOrderItem() { Name = "Sage", JobId = 40 });
            order.Add(new FfxivJobOrderItem() { Name = "Monk", JobId = 20 });
            order.Add(new FfxivJobOrderItem() { Name = "Pugilist", JobId = 2 });
            order.Add(new FfxivJobOrderItem() { Name = "Dragoon", JobId = 22 });
            order.Add(new FfxivJobOrderItem() { Name = "Lancer", JobId = 4 });
            order.Add(new FfxivJobOrderItem() { Name = "Ninja", JobId = 30 });
            order.Add(new FfxivJobOrderItem() { Name = "Rogue", JobId = 29 });
            order.Add(new FfxivJobOrderItem() { Name = "Samurai", JobId = 34 });
            order.Add(new FfxivJobOrderItem() { Name = "Reaper", JobId = 39 });
            order.Add(new FfxivJobOrderItem() { Name = "Bard", JobId = 23 });
            order.Add(new FfxivJobOrderItem() { Name = "Archer", JobId = 5 });
            order.Add(new FfxivJobOrderItem() { Name = "Machinist", JobId = 31 });
            order.Add(new FfxivJobOrderItem() { Name = "Dancer", JobId = 38 });
            order.Add(new FfxivJobOrderItem() { Name = "Black Mage", JobId = 25 });
            order.Add(new FfxivJobOrderItem() { Name = "Thaumaturge", JobId = 7 });
            order.Add(new FfxivJobOrderItem() { Name = "Summoner", JobId = 27 });
            order.Add(new FfxivJobOrderItem() { Name = "Arcanist", JobId = 26 });
            order.Add(new FfxivJobOrderItem() { Name = "Red Mage", JobId = 35 });
            order.Add(new FfxivJobOrderItem() { Name = "Blue Mage", JobId = 36 });
            foreach (FfxivJobOrderItem i in order)
            {
                i.Name = I18n.Translate(GetType().Name + "/lstFfxivJobOrder[" + i.Name + "]", i.Name);
            }
            if (cx != null)
            {
                order.Sort((a, b) =>
                {
                    int av = cx.GetPartyOrderValue(a.JobId);
                    int bv = cx.GetPartyOrderValue(b.JobId);
                    if (av < bv)
                    {
                        return -1;
                    }
                    if (av > bv)
                    {
                        return 1;
                    }
                    return a.Name.CompareTo(b.Name);
                });
            }
            foreach (FfxivJobOrderItem x in order)
            {
                lstFfxivJobOrder.Items.Add(x);
            }
        }

        private void btnFfxivJobRestore_Click(object sender, EventArgs e)
        {
            SetupJobOrder(null);
        }

        private void btnFfxivJobUp_Click(object sender, EventArgs e)
        {
            MoveItem(-1);
        }

        private void btnFfxivJobDown_Click(object sender, EventArgs e)
        {
            MoveItem(1);
        }

        public void MoveItem(int direction)
        {
            // Checking selected item
            if (lstFfxivJobOrder.SelectedItem == null || lstFfxivJobOrder.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = lstFfxivJobOrder.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= lstFfxivJobOrder.Items.Count)
                return; // Index out of range - nothing to do

            object selected = lstFfxivJobOrder.SelectedItem;

            // Removing removable element
            lstFfxivJobOrder.Items.Remove(selected);
            // Insert it in new position
            lstFfxivJobOrder.Items.Insert(newIndex, selected);
            // Restore selection
            lstFfxivJobOrder.SetSelected(newIndex, true);
        }

        private void trvTrigger_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvTrigger.SelectedNode != null)
            {
                if (trvTrigger.SelectedNode.Tag is Folder)
                {
                    lblFolderReminder.Visible = true;
                }
                else
                {
                    lblFolderReminder.Visible = false;
                }
                btnClearSelection.Enabled = true;
            }
            else
            {
                btnClearSelection.Enabled = false;
            }
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            clearSelectionToolStripMenuItem_Click(sender, e);
        }

        private void RefreshCacheStates()
        {
            RefreshImageCacheState();
            RefreshSoundCacheState();
            RefreshJsonCacheState();
            RefreshRepoCacheState();
            RefreshFileCacheState();
        }

        private void RefreshImageCacheState()
        {
            string path = Path.Combine(plug.path, "TriggernometryRemoteImages");
            RefreshCacheState(path, txtCacheImageCount, txtCacheImageSize, btnCacheImageClear, btnCacheImageBrowse);
        }

        private void RefreshSoundCacheState()
        {
            string path = Path.Combine(plug.path, "TriggernometryRemoteSounds");
            RefreshCacheState(path, txtCacheSoundCount, txtCacheSoundSize, btnCacheSoundClear, btnCacheSoundBrowse);
        }

        private void RefreshJsonCacheState()
        {
            string path = Path.Combine(plug.path, "TriggernometryJsonCache");
            RefreshCacheState(path, txtCacheJsonCount, txtCacheJsonSize, btnCacheJsonClear, btnCacheJsonBrowse);
        }

        private void RefreshRepoCacheState()
        {
            string path = Path.Combine(plug.path, "TriggernometryRepoBackups");
            RefreshCacheState(path, txtCacheRepoCount, txtCacheRepoSize, btnCacheRepoClear, btnCacheRepoBrowse);
        }

        private void RefreshFileCacheState()
        {
            string path = Path.Combine(plug.path, "TriggernometryFileCache");
            RefreshCacheState(path, txtCacheFileCount, txtCacheFileSize, btnCacheFileClear, btnCacheFileBrowse);
        }

        private void RefreshCacheState(string path, TextBox count, TextBox size, Button clear, Button browse)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            if (di.Exists == true)
            {
                FileInfo[] fis = di.GetFiles();
                long totalSize = 0;
                foreach (FileInfo fi in fis)
                {
                    totalSize += fi.Length;
                }
                count.Text = fis.Length.ToString();
                size.Text = totalSize.ToString();
                clear.Enabled = (fis.Length > 0);
                browse.Enabled = true;
            }
            else
            {
                count.Text = "0";
                size.Text = "0";
                clear.Enabled = false;
                browse.Enabled = false;
            }
        }

        private void btnCacheImageClear_Click(object sender, EventArgs e)
        {
            if (plug.ClearCache("TriggernometryRemoteImages", 0) > 0)
            {
                RefreshImageCacheState();
            }
        }

        private void btnCacheSoundClear_Click(object sender, EventArgs e)
        {
            if (plug.ClearCache("TriggernometryRemoteSounds", 0) > 0)
            {
                RefreshSoundCacheState();
            }
        }

        private void btnCacheJsonClear_Click(object sender, EventArgs e)
        {
            if (plug.ClearCache("TriggernometryJsonCache", 0) > 0)
            {
                RefreshJsonCacheState();
            }
        }

        private void btnCacheRepoClear_Click(object sender, EventArgs e)
        {
            if (plug.ClearCache("TriggernometryRepoBackups", 0) > 0)
            {
                RefreshRepoCacheState();
            }
        }

        private void btnCacheFileClear_Click(object sender, EventArgs e)
        {
            if (plug.ClearCache("TriggernometryFileCache", 0) > 0)
            {
                RefreshFileCacheState();
            }
        }

        private void btnCacheImageBrowse_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(plug.path, "TriggernometryRemoteImages");
            if (Directory.Exists(path) == true)
            {
                Process.Start("explorer.exe", path);
            }
        }

        private void btnCacheSoundBrowse_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(plug.path, "TriggernometryRemoteSounds");
            if (Directory.Exists(path) == true)
            {
                Process.Start("explorer.exe", path);
            }
        }

        private void btnCacheJsonBrowse_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(plug.path, "TriggernometryJsonCache");
            if (Directory.Exists(path) == true)
            {
                Process.Start("explorer.exe", path);
            }
        }

        private void btnCacheRepoBrowse_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(plug.path, "TriggernometryRepoBackups");
            if (Directory.Exists(path) == true)
            {
                Process.Start("explorer.exe", path);
            }
        }

        private void btnCacheFileBrowse_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(plug.path, "TriggernometryFileCache");
            if (Directory.Exists(path) == true)
            {
                Process.Start("explorer.exe", path);
            }
        }

        private void dgvSubstitutions_SelectionChanged(object sender, EventArgs e)
        {
            btnSubEdit.Enabled = (dgvSubstitutions.SelectedRows.Count == 1);
            btnSubRemove.Enabled = (dgvSubstitutions.SelectedRows.Count > 0);
        }

        private void dgvSubstitutions_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= subs.Count)
            {
                return;
            }
            Configuration.Substitution sub = subs.ElementAt(e.RowIndex);
            switch (e.ColumnIndex)
            {
                case 0:
                    e.Value = sub.SearchFor;
                    break;
                case 1:
                    e.Value = sub.ReplaceWith;
                    break;
                case 2:
                    {
                        List<string> items = new List<string>();
                        if ((sub.Scope & Configuration.Substitution.SubstitutionScopeEnum.CaptureGroup) ==  Configuration.Substitution.SubstitutionScopeEnum.CaptureGroup)
                        {
                            items.Add(I18n.Translate("internal/ConfigurationForm/subsregexgroup", "capture groups"));
                        }
                        if ((sub.Scope & Configuration.Substitution.SubstitutionScopeEnum.NumericExpression) == Configuration.Substitution.SubstitutionScopeEnum.NumericExpression)
                        {
                            items.Add(I18n.Translate("internal/ConfigurationForm/subsnumexpr", "numeric expressions"));
                        }
                        if ((sub.Scope & Configuration.Substitution.SubstitutionScopeEnum.StringExpression) == Configuration.Substitution.SubstitutionScopeEnum.StringExpression)
                        {
                            items.Add(I18n.Translate("internal/ConfigurationForm/subsstrexpr", "string expressions"));
                        }
                        if ((sub.Scope & Configuration.Substitution.SubstitutionScopeEnum.TextToSpeech) == Configuration.Substitution.SubstitutionScopeEnum.TextToSpeech)
                        {
                            items.Add(I18n.Translate("internal/ConfigurationForm/substts", "text to speech"));
                        }
                        if (items.Count > 0)
                        {
                            e.Value = Capitalize(String.Join(", ", items));
                        }
                        else
                        {
                            e.Value = I18n.Translate("internal/ConfigurationForm/subsnone", "None (inactive)");
                        }
                    }                    
                    break;
            }
        }

        private string Capitalize(string str)
        {
            if (str == null)
            {
                return null;
            }
            if (str.Length > 1)
            {
                return char.ToUpper(str[0]) + str.Substring(1);
            }
            return str.ToUpper();
        }

        private void btnSubAdd_Click(object sender, EventArgs e)
        {
            using (Forms.SubstitutionForm sf = new Forms.SubstitutionForm())
            {
                sf.SettingsFromSubstitution(null);
                sf.Text = I18n.Translate("internal/UserInterface/addsubstitution", "Add new substitution");
                sf.btnOk.Text = I18n.Translate("internal/UserInterface/add", "Add");
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    Configuration.Substitution sub = new Configuration.Substitution();
                    sf.SettingsToSubstitution(sub);
                    subs.Add(sub);
                    subs.Sort();
                    dgvSubstitutions.RowCount = subs.Count;
                    dgvSubstitutions.Refresh();
                    for (int i = 0; i < subs.Count; i++)
                    {
                        if (subs[i].CompareTo(sub) == 0)
                        {
                            dgvSubstitutions.ClearSelection();
                            dgvSubstitutions.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }
        }

        private void btnSubEdit_Click(object sender, EventArgs e)
        {
            using (Forms.SubstitutionForm sf = new Forms.SubstitutionForm())
            {
                DataGridViewRow r = dgvSubstitutions.SelectedRows[0];
                Configuration.Substitution sub = subs[r.Index];
                sf.SettingsFromSubstitution(sub);
                sf.Text = I18n.Translate("internal/UserInterface/editsubstitution", "Edit substitution '{0}'", sub.SearchFor);
                sf.btnOk.Text = I18n.Translate("internal/UserInterface/savechanges", "Save changes");
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    sf.SettingsToSubstitution(sub);
                    subs.Sort();
                    dgvSubstitutions.Refresh();
                    for (int i = 0; i < subs.Count; i++)
                    {
                        if (subs[i].CompareTo(sub) == 0)
                        {
                            dgvSubstitutions.ClearSelection();
                            dgvSubstitutions.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }
        }

        private void btnSubRemove_Click(object sender, EventArgs e)
        {
            string temp;
            if (dgvSubstitutions.SelectedRows.Count > 1)
            {
                temp = I18n.Translate("internal/ConfigurationForm/areyousurepluralsub", "Are you sure you want to remove the selected substitutions?");
            }
            else
            {
                temp = I18n.Translate("internal/ConfigurationForm/areyousuresingularsub", "Are you sure you want to remove the selected substitution?");
            }
            switch (MessageBox.Show(this, temp, I18n.Translate("internal/ConfigurationForm/confirmremoval", "Confirm removal"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    List<Configuration.Substitution> toRem = new List<Configuration.Substitution>();
                    foreach (DataGridViewRow r in dgvSubstitutions.SelectedRows)
                    {
                        toRem.Add(subs[r.Index]);
                    }
                    foreach (Configuration.Substitution sub in toRem)
                    {
                        subs.Remove(sub);
                    }
                    dgvSubstitutions.ClearSelection();
                    dgvSubstitutions.RowCount = subs.Count;
                    dgvSubstitutions.Refresh();
                    break;
            }
        }

        private void dgvSubstitutions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (btnSubRemove.Enabled == true)
                {
                    btnSubRemove_Click(this, null);
                }
            }
        }

        private void dgvSubstitutions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvSubstitutions.ClearSelection();
            dgvSubstitutions.Rows[e.RowIndex].Selected = true;
            btnSubEdit_Click(sender, null);
        }

        private void dgvApiAccess_SelectionChanged(object sender, EventArgs e)
        {
            dgvApiAccess.ClearSelection();
        }

        private void btnUnlockSecurity_Click(object sender, EventArgs e)
        {
            string temp = I18n.Translate("internal/ConfigurationForm/securityunlockwarning", "Altering any of the security settings below may expose your system to outsiders, and in the worst case, malicious users may be able to render your system inoperable or gain access to your personal information. Are you sure you understand the risks involved and know what you are doing, and still wish to continue altering these settings?");
            switch (MessageBox.Show(this, temp, I18n.Translate("internal/ConfigurationForm/confirmsecurityunlock", "Confirm unlock"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    dgvApiAccess.Enabled = true;
                    dgvApiAccess.ReadOnly = false;
                    btnUnlockSecurity.Visible = false;
                    panel18.Visible = false;
                    break;
            }
        }

        private void dgvApiAccess_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgvApiAccess.Rows[e.RowIndex];
            DataGridViewCell c = r.Cells[e.ColumnIndex];
            c.Value = ((bool)c.Value == false);
        }

        private void dgvApiAccess_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvApiAccess_CellContentClick(sender, e);
        }

        private void cbxAutosaveConfig_CheckedChanged(object sender, EventArgs e)
        {
            lblAutosaveInterval.Enabled = cbxAutosaveConfig.Checked;
            nudAutosaveMinutes.Enabled = cbxAutosaveConfig.Checked;
        }

        private void btnTriggerTemplate_Click(object sender, EventArgs e)
        {
            using (Forms.TriggerForm tf = new Forms.TriggerForm())
            {
                Trigger t = template;
                Trigger.TriggerSourceEnum oldSource = t._Source;
                tf.AllowAnonymousTrigger = true;
                tf.plug = plug;
                tf.fakectx.trig = t;
                tf.fakectx.plug = plug;
                tf.SettingsFromTrigger(t);
                tf.imgs = plug.ui.imageList1;
                tf.trv = plug.ui.treeView1;
                tf.Text = I18n.Translate("internal/UserInterface/edittemplatetrigger", "Edit template trigger");
                tf.btnOk.Text = I18n.Translate("internal/UserInterface/savechanges", "Save changes");
                tf.wmp = plug.wmp;
                tf.tts = plug.tts;
                if (tf.ShowDialog() == DialogResult.OK)
                {
                    lock (t) // verified
                    {
                        tf.SettingsToTrigger(t);
                    }
                }
            }
        }

        private Variable OpenVariableEditor(Variable v, ref string name, bool isNew)
        {
            using (VariableEditorForm vef = new VariableEditorForm())
            {
                vef.VariableName = name;
                vef.VariableToEdit = v.Duplicate();
                vef.IsNew = isNew;
                if (vef.ShowDialog() == DialogResult.OK)
                {
                    name = vef.VariableName;
                    vef.VariableToEdit.LastChanged = DateTime.Now;
                    vef.VariableToEdit.LastChanger = I18n.Translate("internal/VariableForm/variableeditortag", "Variable editor");
                    return vef.VariableToEdit;
                }
            }
            return null;
        }

        private void SetupConsts(SerializableDictionary<string, VariableScalar> constants)
        {
            Configuration dummy = new Configuration();
            foreach (KeyValuePair<string, VariableScalar> kp in dummy.Constants)
            {
                consts[kp.Key] = new VariableScalar() { Value = kp.Value.Value, LastChanged = kp.Value.LastChanged, LastChanger = kp.Value.LastChanger };
            }
            if (constants != null)
            {
                foreach (KeyValuePair<string, VariableScalar> kp in constants)
                {
                    consts[kp.Key] = new VariableScalar() { Value = kp.Value.Value, LastChanged = kp.Value.LastChanged, LastChanger = kp.Value.LastChanger };
                }
            }
            RefreshConsts();
        }

        private void RefreshConsts()
        {
            dgvConstVariables.RowCount = consts.Count;
            Refresh();
        }

        private void btnConstAdd_Click(object sender, EventArgs e)
        {
            VariableScalar v = new VariableScalar();
            string varname = "";
            v = (VariableScalar)OpenVariableEditor(v, ref varname, true);
            if (v != null)
            {
                consts[varname] = v;
                RefreshConsts();
            }
        }

        private void btnConstEdit_Click(object sender, EventArgs e)
        {
            string varname = "";
            foreach (DataGridViewRow r in dgvConstVariables.SelectedRows)
            {
                varname = r.Cells[0].Value.ToString();
            }
            VariableScalar v = null;
            if (consts.ContainsKey(varname) == true)
            {
                v = consts[varname];
            }
            if (v == null)
            {
                v = new VariableScalar();
            }
            string varname2 = varname;
            v = (VariableScalar)OpenVariableEditor(v, ref varname2, false);
            if (v != null)
            {
                if (varname != varname2)
                {
                    if (consts.ContainsKey(varname) == true)
                    {
                        consts.Remove(varname);
                    }
                }
                consts[varname2] = v;
                RefreshConsts();
            }
        }

        private void btnConstRemove_Click(object sender, EventArgs e)
        {
            string temp;
            if (dgvConstVariables.SelectedRows.Count > 1)
            {
                temp = I18n.Translate("internal/ConfigurationForm/areyousureplural", "Are you sure you want to remove the selected constants?");
            }
            else
            {
                temp = I18n.Translate("internal/ConfigurationForm/areyousuresingular", "Are you sure you want to remove the selected constant?");
            }
            switch (MessageBox.Show(this, temp, I18n.Translate("internal/ConfigurationForm/confirmremoval", "Confirm removal"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    List<string> varnames = new List<string>();
                    foreach (DataGridViewRow r in dgvConstVariables.SelectedRows)
                    {
                        varnames.Add(r.Cells[0].Value.ToString());
                    }
                    foreach (string varname in varnames)
                    {
                        if (consts.ContainsKey(varname) == true)
                        {
                            consts.Remove(varname);
                        }
                    }
                    dgvConstVariables.RowCount = consts.Count;
                    dgvConstVariables.ClearSelection();
                    dgvConstVariables.Refresh();
                    break;
            }
        }

        private void dgvConstVariables_SelectionChanged(object sender, EventArgs e)
        {
            btnConstEdit.Enabled = (dgvConstVariables.SelectedRows.Count == 1);
            btnConstRemove.Enabled = (dgvConstVariables.SelectedRows.Count > 0);
        }

        private void dgvConstVariables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            dgvConstVariables.ClearSelection();
            dgvConstVariables.Rows[e.RowIndex].Selected = true;
            btnConstEdit_Click(sender, null);
        }

        private void dgvConstVariables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (btnConstRemove.Enabled == true)
                {
                    btnConstRemove_Click(this, null);
                }
            }
        }

        private void dgvConstVariables_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= consts.Count)
            {
                return;
            }
            KeyValuePair<string, VariableScalar> kp = consts.ElementAt(e.RowIndex);
            switch (e.ColumnIndex)
            {
                case 0:
                    e.Value = kp.Key;
                    break;
                case 1:
                    e.Value = kp.Value.Value;
                    break;
            }
        }

    }

}
