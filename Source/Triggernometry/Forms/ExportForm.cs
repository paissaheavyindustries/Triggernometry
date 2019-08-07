using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Triggernometry.Forms
{

    public partial class ExportForm : MemoryForm<ExportForm>
    {

        private string _ShownText;
        internal string ShownText
        {
            get
            {
                return _ShownText;
            }
            set
            {
                _ShownText = value;
                UpdateDisplay();
            }
        }


        public ExportForm()
        {
            InitializeComponent();
            cbxFormat.SelectedIndex = 0;
            RestoredSavedDimensions();
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            btnSelectionToClipboard.Enabled = (rtbExportResults.SelectionLength > 0);            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            ctxSelectionToClipboard.Enabled = btnSelectionToClipboard.Enabled;
            ctxEverythingToClipboard.Enabled = btnEverythingToClipboard.Enabled;
        }

        private void copySelectionToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectionToClipboardToolStripMenuItem_Click(sender, e);
        }

        private void copyAllToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            everythingToClipboardToolStripMenuItem_Click(sender, e);
        }

        private void cbxFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            switch (cbxFormat.SelectedIndex)
            {
                case 0:
                    rtbExportResults.Text = ShownText;
                    break;
                case 1:
                    rtbExportResults.Text = WebUtility.HtmlEncode(ShownText);
                    break;
            }
        }

        private void selectionToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(rtbExportResults.SelectedText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, I18n.Translate("internal/ExportForm/exception", "Exception"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void everythingToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(rtbExportResults.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, I18n.Translate("internal/ExportForm/exception", "Exception"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSaveToFile_Click(sender, e);
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, rtbExportResults.Text);
            }
        }

    }

}
