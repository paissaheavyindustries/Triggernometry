using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triggernometry.Forms
{

    public partial class RepositoryForm : MemoryForm<RepositoryForm>
    {

        private bool cancomplain = false;
        internal RealPlugin plug { get; set; }

        public RepositoryForm()
        {
            InitializeComponent();
            RestoredSavedDimensions();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            CheckOkButton();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            CheckOkButton();
        }

        private void CheckOkButton()
        {
            btnOk.Enabled = (txtName.Text.Trim().Length > 0 && txtAddress.Text.Trim().Length > 0);
        }

        internal void SettingsFromRepository(Repository r)
        {
            if (r == null)
            {
                txtName.Text = "";
                txtAddress.Text = "";
                chkAllowProcess.Checked = false;
                chkAllowScript.Checked = false;
                chkAllowWmsg.Checked = false;
                chkAllowObs.Checked = false;
                cbxNewBehavior.SelectedIndex = 0;
                cbxUpdatePolicy.SelectedIndex = 0;
                cbxAudioOverride.SelectedIndex = 2;
                chkKeepLocal.Checked = true;
                txtCacheFilename.Text = "";
                txtContentSize.Text = "";
                txtLastUpdated.Text = "";
                txtLog.Text = "";
            }
            else
            {
                txtName.Text = r.Name;
                txtAddress.Text = r.Address;
                chkAllowProcess.Checked = r.AllowProcessLaunch;
                chkAllowScript.Checked = r.AllowScriptExecution;
                chkAllowWmsg.Checked = r.AllowWindowMessages;
                chkAllowObs.Checked = r.AllowObsControl;
                cbxNewBehavior.SelectedIndex = (int)r.NewBehavior;
                cbxUpdatePolicy.SelectedIndex = (int)r.UpdatePolicy;
                cbxAudioOverride.SelectedIndex = (int)r.AudioOutput;
                chkKeepLocal.Checked = r.KeepLocalBackup;
                txtCacheFilename.Text = plug.GetRepositoryBackupFilename(r);
                txtLastUpdated.Text = r.LastUpdated == DateTime.MinValue ? I18n.Translate("internal/RepositoryForm/unavailable", "Unavailable") : r.LastUpdated.ToString(CultureInfo.InvariantCulture);
                txtContentSize.Text = r.ContentSize == 0 ? I18n.Translate("internal/RepositoryForm/unavailable", "Unavailable") : r.ContentSize.ToString(CultureInfo.InvariantCulture);
                lock (r.UpdateLog)
                {
                    txtLog.Text = String.Join(Environment.NewLine, r.UpdateLog);
                }
            }
        }

        internal void SettingsToRepository(Repository r)
        {
            r.Name = txtName.Text;
            r.Address = txtAddress.Text;
            r.AllowProcessLaunch = chkAllowProcess.Checked;
            r.AllowScriptExecution = chkAllowScript.Checked;
            r.AllowWindowMessages = chkAllowWmsg.Checked;
            r.AllowObsControl = chkAllowObs.Checked;
            r.KeepLocalBackup = chkKeepLocal.Checked;
            r.AudioOutput = (Repository.AudioOutputEnum)cbxAudioOverride.SelectedIndex;
            r.NewBehavior = (Repository.NewBehaviorEnum)cbxNewBehavior.SelectedIndex;
            r.UpdatePolicy = (Repository.UpdatePolicyEnum)cbxUpdatePolicy.SelectedIndex;
        }

        private void chkAllowProcess_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllowProcess.Checked == false || cancomplain == false)
            {
                return;
            }
            if (MessageBox.Show(this, I18n.Translate("internal/RepositoryForm/allowprocesswarn", "Allowing triggers from a repository to launch processes can be extremely risky, as the repository may have triggers (or may add some later) that prove to be dangerous and/or malicious. Are you sure you want to allow this?"), I18n.Translate("internal/RepositoryForm/warning", "Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                chkAllowProcess.Checked = false;
            }
        }

        private void chkAllowScript_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllowScript.Checked == false || cancomplain == false)
            {
                return;
            }
            if (MessageBox.Show(this, I18n.Translate("internal/RepositoryForm/allowscriptwarn", "Allowing triggers from a repository to execute scripts can be extremely risky, as the repository may have triggers (or may add some later) that prove to be dangerous and/or malicious. Are you sure you want to allow this?"), I18n.Translate("internal/RepositoryForm/warning", "Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                chkAllowScript.Checked = false;
            }
        }

        private void chkAllowWmsg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllowWmsg.Checked == false || cancomplain == false)
            {
                return;
            }
            if (MessageBox.Show(this, I18n.Translate("internal/RepositoryForm/allowwmsgwarn", "Allowing triggers from a repository to send window messages can be extremely risky, as the repository may have triggers (or may add some later) that prove to be dangerous and/or malicious. Are you sure you want to allow this?"), I18n.Translate("internal/RepositoryForm/warning", "Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                chkAllowWmsg.Checked = false;
            }
        }

        private void chkAllowObs_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllowObs.Checked == false || cancomplain == false)
            {
                return;
            }
            if (MessageBox.Show(this, I18n.Translate("internal/RepositoryForm/allowobswarn", "Allowing triggers from a repository to control OBS can be extremely risky, as the repository may have triggers (or may add some later) that prove to be dangerous and/or malicious. Are you sure you want to allow this?"), I18n.Translate("internal/RepositoryForm/warning", "Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                chkAllowObs.Checked = false;
            }
        }

        private void RepositoryForm_Shown(object sender, EventArgs e)
        {
            cancomplain = true;
        }

        private void txtCacheFilename_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = (txtCacheFilename.Text.Length > 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtCacheFilename.Text) == true)
            {
                string argument = "/select, \"" + txtCacheFilename.Text + "\"";
                System.Diagnostics.Process.Start("explorer.exe", argument);
            }
        }

        private void btnCopy_DropDownOpening(object sender, EventArgs e)
        {
            btnSelectionToClipboard.Enabled = (txtLog.SelectionLength > 0);
        }

        private void selectionToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSelectionToClipboard_Click(sender, e);
        }

        private void everythingToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEverythingToClipboard_Click(sender, e);
        }

        private void btnSelectionToClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtLog.SelectedText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, I18n.Translate("internal/RepositoryForm/exception", "Exception"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEverythingToClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtLog.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, I18n.Translate("internal/RepositoryForm/exception", "Exception"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            ctxSelectionToClipboard.Enabled = (txtLog.SelectionLength > 0);
        }

    }

}
