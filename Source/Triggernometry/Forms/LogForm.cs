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

namespace Triggernometry.Forms
{

    public partial class LogForm : MemoryForm<LogForm>
    {

        internal RealPlugin plug;

        internal List<InternalLog> logData;
        internal List<InternalLog> virtualData;
        internal bool startWithErrorSearch = false;

        public LogForm()
        {
            InitializeComponent();
            logData = new List<InternalLog>();
            Shown += LogForm_Shown;
            cbxLevel.Items.Add(I18n.Translate("internal/Plugin/loglevel" + RealPlugin.DebugLevelEnum.Error.ToString(), "{0}", RealPlugin.DebugLevelEnum.Error.ToString()));
            cbxLevel.Items.Add(I18n.Translate("internal/Plugin/loglevel" + RealPlugin.DebugLevelEnum.Warning.ToString(), "{0}", RealPlugin.DebugLevelEnum.Warning.ToString()));
            cbxLevel.Items.Add(I18n.Translate("internal/Plugin/loglevel" + RealPlugin.DebugLevelEnum.Info.ToString(), "{0}", RealPlugin.DebugLevelEnum.Info.ToString()));
            cbxLevel.Items.Add(I18n.Translate("internal/Plugin/loglevel" + RealPlugin.DebugLevelEnum.Verbose.ToString(), "{0}", RealPlugin.DebugLevelEnum.Verbose.ToString()));
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

        private void DgvLog_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            InternalLog il = virtualData[e.RowIndex];
            switch (il.Level)
            {
                case RealPlugin.DebugLevelEnum.Verbose:
                    e.CellStyle.BackColor = Color.LightGray;
                    e.CellStyle.ForeColor = Color.Black;
                    break;
                case RealPlugin.DebugLevelEnum.Info:
                    e.CellStyle.BackColor = Color.White;
                    e.CellStyle.ForeColor = Color.Black;
                    break;
                case RealPlugin.DebugLevelEnum.Warning:
                    e.CellStyle.BackColor = Color.Yellow;
                    e.CellStyle.ForeColor = Color.Black;
                    break;
                case RealPlugin.DebugLevelEnum.Error:
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.Yellow;
                    break;
            }
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
                    e.Value = I18n.Translate("internal/Plugin/loglevel" + il.Level.ToString(), "{0}", il.Level.ToString());
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
                cbxLevelMethod.SelectedIndex = 2;
                cbxLevel.SelectedIndex = 0;
            }
            else
            {
                cbxLevelMethod.SelectedIndex = 3;
                cbxLevel.SelectedIndex = 3;
            }
            RefreshLog();
            rexSearch.Focus();
        }

        private void RefreshLog()
        {
            logData.Clear();
            lock (plug.log)
            {
                logData.AddRange(plug.log);
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
            List<InternalLog> p1 = new List<InternalLog>();
            RealPlugin.DebugLevelEnum level = (RealPlugin.DebugLevelEnum)(cbxLevel.SelectedIndex + 1);
            Regex rex = null;
            if (rexSearch.Text != null && rexSearch.Text.Trim().Length > 0)
            {
                rex = new Regex(rexSearch.Text);
            }
            switch (cbxLevelMethod.SelectedIndex)
            {
                case 0:
                    p1.AddRange(from ix in logData where ix.Level > level && (rex == null || rex.IsMatch(ix.Message) == true) select ix);
                    break;
                case 1:
                    p1.AddRange(from ix in logData where ix.Level >= level && (rex == null || rex.IsMatch(ix.Message) == true) select ix);
                    break;
                case 2:
                    p1.AddRange(from ix in logData where ix.Level == level && (rex == null || rex.IsMatch(ix.Message) == true) select ix);
                    break;
                case 3:
                    p1.AddRange(from ix in logData where ix.Level <= level && (rex == null || rex.IsMatch(ix.Message) == true) select ix);
                    break;
                case 4:
                    p1.AddRange(from ix in logData where ix.Level < level && (rex == null || rex.IsMatch(ix.Message) == true) select ix);
                    break;
                case 5:
                    p1.AddRange(from ix in logData where ix.Level != level && (rex == null || rex.IsMatch(ix.Message) == true) select ix);
                    break;
            }
            return p1;
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

        private void RefreshViewStatic()
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            List<InternalLog> p1 = BuildDataset();
            foreach (InternalLog il in p1)
            {
                DataGridViewRow row = (DataGridViewRow)dgvLog.RowTemplate.Clone();
                row.CreateCells(dgvLog, RealPlugin.FormatDateTime(il.Timestamp), I18n.Translate("internal/Plugin/loglevel" + il.Level.ToString(), "{0}", il.Level.ToString()), il.Message);
                switch (il.Level)
                {
                    case RealPlugin.DebugLevelEnum.Verbose:
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                    case RealPlugin.DebugLevelEnum.Info:
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                    case RealPlugin.DebugLevelEnum.Warning:
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                    case RealPlugin.DebugLevelEnum.Error:
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.Yellow;
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

    }

}
