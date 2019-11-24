using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triggernometry.Forms
{

    public partial class ConfigurationForm : MemoryForm<ConfigurationForm>
    {

        bool cancomplain;
        internal RealPlugin plug;
        private bool firstchange = true;

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

        internal void SettingsFromConfiguration(Configuration a)
        {
            if (a == null)
            {
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
                chkWarnAdmin.Checked = true;
                cbxTestLive.Checked = false;
                chkLogNormalEvents.Checked = true;
                chkFfxivLogNetwork.Checked = false;
                cbxEnableHwAccel.Checked = false;
                txtMonitorWindow.Text = "";
                nudCacheImageExpiry.Value = 518400;
                nudCacheSoundExpiry.Value = 518400;
                nudCacheJsonExpiry.Value = 10080;
                nudCacheRepoExpiry.Value = 518400;
                nudCacheFileExpiry.Value = 518400;
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
                chkUpdates.Checked = (a.UpdateNotifications == Configuration.UpdateNotificationsEnum.Yes);
                chkLogNormalEvents.Checked = a.LogNormalEvents;
                chkFfxivLogNetwork.Checked = a.FfxivLogNetwork;
                cbxEnableHwAccel.Checked = a.UseScarborough;
                txtMonitorWindow.Text = a.WindowToMonitor;
                nudCacheImageExpiry.Value = a.CacheImageExpiry;
                nudCacheSoundExpiry.Value = a.CacheSoundExpiry;
                int dummy = (int)nudCacheJsonExpiry.Value;                
                nudCacheJsonExpiry.Value = a.CacheJsonExpiry;
                dummy = (int)nudCacheJsonExpiry.Value;
                nudCacheRepoExpiry.Value = a.CacheRepoExpiry;
                nudCacheFileExpiry.Value = a.CacheFileExpiry;
                SetupJobOrder(a);
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
            a.LogNormalEvents = chkLogNormalEvents.Checked;
            a.FfxivLogNetwork = chkFfxivLogNetwork.Checked;
            a.DeveloperMode = cbxDevMode.Checked;
            a.UseScarborough = cbxEnableHwAccel.Checked;
            a.WindowToMonitor = txtMonitorWindow.Text;
            a.CacheImageExpiry = (int)nudCacheImageExpiry.Value;
            a.CacheSoundExpiry = (int)nudCacheSoundExpiry.Value;            
            a.CacheJsonExpiry = (int)nudCacheJsonExpiry.Value;            
            a.CacheRepoExpiry = (int)nudCacheRepoExpiry.Value;
            a.CacheFileExpiry = (int)nudCacheFileExpiry.Value;
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
            order.Add(new FfxivJobOrderItem() { Name = "Monk", JobId = 20 });
            order.Add(new FfxivJobOrderItem() { Name = "Pugilist", JobId = 2 });
            order.Add(new FfxivJobOrderItem() { Name = "Dragoon", JobId = 22 });
            order.Add(new FfxivJobOrderItem() { Name = "Lancer", JobId = 4 });
            order.Add(new FfxivJobOrderItem() { Name = "Ninja", JobId = 30 });
            order.Add(new FfxivJobOrderItem() { Name = "Rogue", JobId = 29 });
            order.Add(new FfxivJobOrderItem() { Name = "Samurai", JobId = 34 });
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

    }

}
