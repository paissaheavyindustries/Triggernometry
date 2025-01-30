using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Triggernometry.CustomControls;

namespace Triggernometry.Forms
{

    public partial class LogForm : MemoryForm<LogForm>
    {

        internal RealPlugin plug = RealPlugin.plug;

        internal List<InternalLog> logData;
        internal List<InternalLog> virtualData;
        internal bool startWithErrorSearch = false;

        public LogForm()
        {
            InitializeComponent();
            splitContainer1.SplitterDistance = (int)(splitContainer1.Width * 0.75);
            logData = new List<InternalLog>();
            Shown += LogForm_Shown;
            RestoredSavedDimensions();
            if (dgvLog.VirtualMode == true)
            {
                dgvLog.CellValueNeeded += DgvLog_CellValueNeeded;
                dgvLog.CellFormatting += DgvLog_CellFormatting;
            }
            rexSearch.OnEnterKeyHit += RexSearch_OnEnter;
        }

        private void RexSearch_OnEnter()
        {
            btnSearch_Click(null, null);
        }

        internal static Color BgRed = Color.FromArgb(255, 210, 210);  
        internal static Color BgYellow = Color.FromArgb(255, 240, 195);  
        internal static Color BgGreen = Color.FromArgb(195, 255, 225);
        internal static Color BgBlue = Color.FromArgb(195, 225, 255);
        internal static Color BgGray = Color.FromArgb(225, 225, 225); 

        private void DgvLog_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            InternalLog il = virtualData[e.RowIndex];
            switch (il.Level)
            {
                case RealPlugin.DebugLevelEnum.Verbose:
                    e.CellStyle.BackColor = BgGray;
                    break;
                case RealPlugin.DebugLevelEnum.Info:
                    e.CellStyle.BackColor = Color.White;
                    break;
                case RealPlugin.DebugLevelEnum.Warning:
                    e.CellStyle.BackColor = BgYellow; 
                    break;
                case RealPlugin.DebugLevelEnum.Error:
                    e.CellStyle.BackColor = BgRed;
                    break;
                case RealPlugin.DebugLevelEnum.Custom:
                    e.CellStyle.BackColor = BgGreen;
                    break;
                case RealPlugin.DebugLevelEnum.Custom2:
                    e.CellStyle.BackColor = BgBlue;
                    break;
            }
            e.CellStyle.ForeColor = Color.Black;
            e.FormattingApplied = true;
        }

        private void DgvLog_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            InternalLog il = virtualData[e.RowIndex];
            switch (e.ColumnIndex)
            {
                case 0:
                    e.Value = RealPlugin.FormatDateTime(il.Timestamp);
                    break;
                case 1:
                    e.Value = I18n.Translate($"LogForm/chk{il.Level}", $"{il.Level}");
                    break;
                case 2:
                    e.Value = il.Message;
                    break;
            }
        }

        private void LogForm_Shown(object sender, EventArgs e)
        {
            if (startWithErrorSearch == true)
            {
                chkAll.Checked = false;
                chkError.Checked = true;
                chkWarning.Checked = true;
                chkInfo.Checked = false;
                chkVerbose.Checked = false;
                chkCustom.Checked = false;
                chkCustom2.Checked = false;
            }
            else
            {
                chkAll.Checked = false;
                chkError.Checked = true;
                chkWarning.Checked = true;
                chkInfo.Checked = true;
                chkVerbose.Checked = false;
                chkCustom.Checked = true;
                chkCustom2.Checked = true;
            }
            RefreshLog();
            rexSearch.Focus();
        }

        private void RefreshLog()
        {
            logData.Clear();
            foreach (var pair in plug.log)
            {
                var queue = pair.Value;
                lock (queue)
                {
                    logData.AddRange(queue);
                }
                
            }
            logData.Sort((a, b) => b.Timestamp.CompareTo(a.Timestamp));
            if (dgvLog.VirtualMode == true)
            {
                RefreshViewVirtual();
            }
            else
            {
                RefreshViewStatic(); 
            }
        }

        private List<InternalLog> BuildDataset()
        {
            Regex rex = null;
            if (rexSearch.Text != null && rexSearch.Text.Trim().Length > 0)
            {
                rex = new Regex(rexSearch.Text, RegexOptions.IgnoreCase);
            }
            return logData.Where(ix =>
                (
                    chkAll.Checked ||
                    (chkError.Checked && ix.Level == RealPlugin.DebugLevelEnum.Error) ||
                    (chkWarning.Checked && ix.Level == RealPlugin.DebugLevelEnum.Warning) ||
                    (chkInfo.Checked && ix.Level == RealPlugin.DebugLevelEnum.Info) ||
                    (chkVerbose.Checked && ix.Level == RealPlugin.DebugLevelEnum.Verbose) ||
                    (chkCustom.Checked && ix.Level == RealPlugin.DebugLevelEnum.Custom) ||
                    (chkCustom2.Checked && ix.Level == RealPlugin.DebugLevelEnum.Custom2) 
                ) && (rex == null || rex.IsMatch(ix.Message))
            ).ToList();
        }

        private void RefreshViewVirtual()
        {
            List<InternalLog> p1 = BuildDataset();
            dgvLog.RowCount = 0;
            if (virtualData != null)
            {
                virtualData.Clear();
                virtualData = null;
            }
            virtualData = p1;
            dgvLog.RowCount = p1.Count;
            dgvLog.Refresh();
            lblStatus.Text = I18n.Translate("internal/LogForm/displaying", "Displaying {0} out of {1}", p1.Count, logData.Count);
        }

        // is this actually used?
        private void RefreshViewStatic() 
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            List<InternalLog> p1 = BuildDataset();
            foreach (InternalLog il in p1)
            {
                DataGridViewRow row = (DataGridViewRow)dgvLog.RowTemplate.Clone();
                row.CreateCells(dgvLog, RealPlugin.FormatDateTime(il.Timestamp), I18n.Translate($"LogForm/chk{il.Level}", $"{il.Level}"));
                switch (il.Level)
                {
                    case RealPlugin.DebugLevelEnum.Verbose:
                        row.DefaultCellStyle.BackColor = BgGray;
                        break;
                    case RealPlugin.DebugLevelEnum.Info:
                        row.DefaultCellStyle.BackColor = Color.White;
                        break;
                    case RealPlugin.DebugLevelEnum.Warning:
                        row.DefaultCellStyle.BackColor = BgYellow;
                        break;
                    case RealPlugin.DebugLevelEnum.Error:
                        row.DefaultCellStyle.BackColor = BgRed;
                        break;
                    case RealPlugin.DebugLevelEnum.Custom:
                        row.DefaultCellStyle.BackColor = BgGreen;
                        break;
                    case RealPlugin.DebugLevelEnum.Custom2:
                        row.DefaultCellStyle.BackColor = BgBlue;
                        break;
                }
                rows.Add(row);
            }
            dgvLog.Rows.Clear();
            dgvLog.Rows.AddRange(rows.ToArray());
            dgvLog.ClearSelection();
            lblStatus.Text = I18n.Translate("internal/LogForm/displaying", "Displaying {0} out of {1}", p1.Count, logData.Count);
        }

        private void selectionToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(dgvLog.GetClipboardContent().GetText());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, I18n.Translate("internal/LogForm/exception", "Exception"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void everythingToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvLog.SelectAll();
                Clipboard.SetText(dgvLog.GetClipboardContent().GetText());
                dgvLog.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, I18n.Translate("internal/LogForm/exception", "Exception"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void copySelectionToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectionToClipboardToolStripMenuItem_Click(sender, e);
        }

        private void copyAllToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            everythingToClipboardToolStripMenuItem_Click(sender, e);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            ctxSelectionToClipboard.Enabled = (dgvLog.SelectedRows.Count > 0);
            ctxEverythingToClipboard.Enabled = btnEverythingToClipboard.Enabled;
        }

        private void toolStripDropDownButton1_DropDownOpening(object sender, EventArgs e)
        {
            btnSelectionToClipboard.Enabled = (dgvLog.SelectedRows.Count > 0);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            plug.ClearLog();
            RefreshLog();
        }

        private void btnSearchOptions_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = (btnSearchOptions.Checked == false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshLog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool isChkProgrammaticChange = false;

        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (isChkProgrammaticChange) { return; }
            bool checkState = chkAll.Checked;

            isChkProgrammaticChange = true;
            chkError.Checked = checkState;
            chkWarning.Checked = checkState;
            chkInfo.Checked = checkState;
            chkVerbose.Checked = checkState;
            chkCustom.Checked = checkState;
            chkCustom2.Checked = checkState;
            isChkProgrammaticChange = false;
            RefreshLog();
        }

        private void ChkOther_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox currentChkBox = sender as CheckBox;
            if (isChkProgrammaticChange || currentChkBox == null) { return; }
            isChkProgrammaticChange = true;
            if (chkError.Checked && chkWarning.Checked && chkInfo.Checked && chkVerbose.Checked && chkCustom.Checked && chkCustom2.Checked)
            {
                chkAll.Checked = true;
            }
            else 
            {
                chkAll.Checked = false;
            }
            isChkProgrammaticChange = false;
            RefreshLog();
        }

        private void ChkAll_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isChkProgrammaticChange = true;
                chkAll.Checked = true;
                chkError.Checked = true;
                chkWarning.Checked = true;
                chkInfo.Checked = true;
                chkVerbose.Checked = true;
                chkCustom.Checked = true;
                chkCustom2.Checked = true;
                isChkProgrammaticChange = false;
                RefreshLog();
            }
        }

        private void ChkOther_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isChkProgrammaticChange = true;
                chkAll.Checked = false;
                chkError.Checked = false;
                chkWarning.Checked = false;
                chkInfo.Checked = false;
                chkVerbose.Checked = false;
                chkCustom.Checked = false;
                chkCustom2.Checked = false;
                CheckBox currentChkBox = sender as CheckBox;
                currentChkBox.Checked = true;
                isChkProgrammaticChange = false;
                RefreshLog();
            }
        }

    }

}
