namespace Triggernometry.Forms
{
    partial class ExportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportForm));
            this.rtbExportResults = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxSaveToFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSelectionToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxEverythingToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tslFormat = new System.Windows.Forms.ToolStripLabel();
            this.cbxFormat = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveToFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopy = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnSelectionToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEverythingToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.tlsMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbExportResults
            // 
            this.rtbExportResults.BackColor = System.Drawing.SystemColors.Window;
            this.rtbExportResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbExportResults.ContextMenuStrip = this.contextMenuStrip1;
            this.rtbExportResults.DetectUrls = false;
            this.rtbExportResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbExportResults.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbExportResults.Location = new System.Drawing.Point(0, 0);
            this.rtbExportResults.Name = "rtbExportResults";
            this.rtbExportResults.ReadOnly = true;
            this.rtbExportResults.Size = new System.Drawing.Size(562, 319);
            this.rtbExportResults.TabIndex = 0;
            this.rtbExportResults.Text = "";
            this.rtbExportResults.WordWrap = false;
            this.rtbExportResults.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxSaveToFile,
            this.toolStripSeparator3,
            this.ctxCopy});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(132, 54);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ctxSaveToFile
            // 
            this.ctxSaveToFile.Image = ((System.Drawing.Image)(resources.GetObject("ctxSaveToFile.Image")));
            this.ctxSaveToFile.Name = "ctxSaveToFile";
            this.ctxSaveToFile.Size = new System.Drawing.Size(131, 22);
            this.ctxSaveToFile.Text = "Save to file";
            this.ctxSaveToFile.Click += new System.EventHandler(this.saveToFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(128, 6);
            // 
            // ctxCopy
            // 
            this.ctxCopy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxSelectionToClipboard,
            this.ctxEverythingToClipboard});
            this.ctxCopy.Image = ((System.Drawing.Image)(resources.GetObject("ctxCopy.Image")));
            this.ctxCopy.Name = "ctxCopy";
            this.ctxCopy.Size = new System.Drawing.Size(131, 22);
            this.ctxCopy.Text = "Copy";
            // 
            // ctxSelectionToClipboard
            // 
            this.ctxSelectionToClipboard.Enabled = false;
            this.ctxSelectionToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("ctxSelectionToClipboard.Image")));
            this.ctxSelectionToClipboard.Name = "ctxSelectionToClipboard";
            this.ctxSelectionToClipboard.Size = new System.Drawing.Size(197, 22);
            this.ctxSelectionToClipboard.Text = "Selection to clipboard";
            // 
            // ctxEverythingToClipboard
            // 
            this.ctxEverythingToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("ctxEverythingToClipboard.Image")));
            this.ctxEverythingToClipboard.Name = "ctxEverythingToClipboard";
            this.ctxEverythingToClipboard.Size = new System.Drawing.Size(197, 22);
            this.ctxEverythingToClipboard.Text = "Everything to clipboard";
            // 
            // tlsMain
            // 
            this.tlsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslFormat,
            this.cbxFormat,
            this.toolStripSeparator1,
            this.btnSaveToFile,
            this.toolStripSeparator2,
            this.btnCopy});
            this.tlsMain.Location = new System.Drawing.Point(10, 10);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(564, 25);
            this.tlsMain.TabIndex = 1;
            // 
            // tslFormat
            // 
            this.tslFormat.Name = "tslFormat";
            this.tslFormat.Size = new System.Drawing.Size(45, 22);
            this.tslFormat.Text = "Format";
            // 
            // cbxFormat
            // 
            this.cbxFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFormat.Items.AddRange(new object[] {
            "Plain",
            "HTML encoded"});
            this.cbxFormat.Name = "cbxFormat";
            this.cbxFormat.Size = new System.Drawing.Size(121, 25);
            this.cbxFormat.SelectedIndexChanged += new System.EventHandler(this.cbxFormat_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveToFile.Image")));
            this.btnSaveToFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(84, 22);
            this.btnSaveToFile.Text = "Save to file";
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCopy
            // 
            this.btnCopy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSelectionToClipboard,
            this.btnEverythingToClipboard});
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(64, 22);
            this.btnCopy.Text = "Copy";
            // 
            // btnSelectionToClipboard
            // 
            this.btnSelectionToClipboard.Enabled = false;
            this.btnSelectionToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectionToClipboard.Image")));
            this.btnSelectionToClipboard.Name = "btnSelectionToClipboard";
            this.btnSelectionToClipboard.Size = new System.Drawing.Size(197, 22);
            this.btnSelectionToClipboard.Text = "Selection to clipboard";
            this.btnSelectionToClipboard.Click += new System.EventHandler(this.selectionToClipboardToolStripMenuItem_Click);
            // 
            // btnEverythingToClipboard
            // 
            this.btnEverythingToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("btnEverythingToClipboard.Image")));
            this.btnEverythingToClipboard.Name = "btnEverythingToClipboard";
            this.btnEverythingToClipboard.Size = new System.Drawing.Size(197, 22);
            this.btnEverythingToClipboard.Text = "Everything to clipboard";
            this.btnEverythingToClipboard.Click += new System.EventHandler(this.everythingToClipboardToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "TriggernometryExport.xml";
            this.saveFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.Title = "Save export results";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rtbExportResults);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 321);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 356);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(564, 10);
            this.panel3.TabIndex = 19;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.Location = new System.Drawing.Point(10, 366);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(564, 35);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tlsMain);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "ExportForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export results";
            this.contextMenuStrip1.ResumeLayout(false);
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripLabel tslFormat;
        private System.Windows.Forms.ToolStripComboBox cbxFormat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.RichTextBox rtbExportResults;
        private System.Windows.Forms.ToolStripDropDownButton btnCopy;
        private System.Windows.Forms.ToolStripMenuItem btnSelectionToClipboard;
        private System.Windows.Forms.ToolStripMenuItem btnEverythingToClipboard;
        private System.Windows.Forms.ToolStripMenuItem ctxSaveToFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ctxCopy;
        private System.Windows.Forms.ToolStripMenuItem ctxSelectionToClipboard;
        private System.Windows.Forms.ToolStripMenuItem ctxEverythingToClipboard;
        private System.Windows.Forms.ToolStripButton btnSaveToFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.Button btnClose;
    }
}