namespace Triggernometry.Forms
{
    partial class ImportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.grpImportSource = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radExistingActTriggers = new System.Windows.Forms.RadioButton();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.radLoadFromFileURI = new System.Windows.Forms.RadioButton();
            this.radImportFromText = new System.Windows.Forms.RadioButton();
            this.txtImportFile = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtImportSource = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxPasteFromClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsDirectPaste = new System.Windows.Forms.ToolStrip();
            this.btnPaste = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.lblWarning = new System.Windows.Forms.Label();
            this.tlsImport = new System.Windows.Forms.ToolStrip();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRemove = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel4.SuspendLayout();
            this.grpImportSource.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.tlsDirectPaste.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tlsImport.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 306);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(564, 10);
            this.panel3.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnNext);
            this.panel4.Controls.Add(this.btnBack);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 316);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(564, 35);
            this.panel4.TabIndex = 14;
            // 
            // btnNext
            // 
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(414, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(150, 35);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next >";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBack.Location = new System.Drawing.Point(0, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 35);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Cancel";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // grpImportSource
            // 
            this.grpImportSource.AutoSize = true;
            this.grpImportSource.Controls.Add(this.tableLayoutPanel1);
            this.grpImportSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpImportSource.Location = new System.Drawing.Point(3, 3);
            this.grpImportSource.Name = "grpImportSource";
            this.grpImportSource.Padding = new System.Windows.Forms.Padding(10);
            this.grpImportSource.Size = new System.Drawing.Size(550, 261);
            this.grpImportSource.TabIndex = 15;
            this.grpImportSource.TabStop = false;
            this.grpImportSource.Text = " Specify import source ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Controls.Add(this.radExistingActTriggers, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnBrowseFile, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.radLoadFromFileURI, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.radImportFromText, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtImportFile, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(530, 228);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // radExistingActTriggers
            // 
            this.radExistingActTriggers.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radExistingActTriggers, 3);
            this.radExistingActTriggers.Dock = System.Windows.Forms.DockStyle.Top;
            this.radExistingActTriggers.Location = new System.Drawing.Point(3, 208);
            this.radExistingActTriggers.Name = "radExistingActTriggers";
            this.radExistingActTriggers.Size = new System.Drawing.Size(524, 17);
            this.radExistingActTriggers.TabIndex = 17;
            this.radExistingActTriggers.TabStop = true;
            this.radExistingActTriggers.Text = "Existing ACT triggers";
            this.radExistingActTriggers.UseVisualStyleBackColor = true;
            this.radExistingActTriggers.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrowseFile.Enabled = false;
            this.btnBrowseFile.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseFile.Image")));
            this.btnBrowseFile.Location = new System.Drawing.Point(490, 179);
            this.btnBrowseFile.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(37, 26);
            this.btnBrowseFile.TabIndex = 14;
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.button3_Click);
            // 
            // radLoadFromFileURI
            // 
            this.radLoadFromFileURI.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radLoadFromFileURI, 3);
            this.radLoadFromFileURI.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLoadFromFileURI.Location = new System.Drawing.Point(3, 159);
            this.radLoadFromFileURI.Name = "radLoadFromFileURI";
            this.radLoadFromFileURI.Size = new System.Drawing.Size(524, 17);
            this.radLoadFromFileURI.TabIndex = 3;
            this.radLoadFromFileURI.TabStop = true;
            this.radLoadFromFileURI.Text = "Load from file or URI";
            this.radLoadFromFileURI.UseVisualStyleBackColor = true;
            this.radLoadFromFileURI.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radImportFromText
            // 
            this.radImportFromText.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radImportFromText, 3);
            this.radImportFromText.Dock = System.Windows.Forms.DockStyle.Top;
            this.radImportFromText.Location = new System.Drawing.Point(3, 3);
            this.radImportFromText.Name = "radImportFromText";
            this.radImportFromText.Size = new System.Drawing.Size(524, 17);
            this.radImportFromText.TabIndex = 1;
            this.radImportFromText.TabStop = true;
            this.radImportFromText.Text = "Directly from text";
            this.radImportFromText.UseVisualStyleBackColor = true;
            this.radImportFromText.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // txtImportFile
            // 
            this.txtImportFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtImportFile.Enabled = false;
            this.txtImportFile.Location = new System.Drawing.Point(33, 182);
            this.txtImportFile.Name = "txtImportFile";
            this.txtImportFile.Size = new System.Drawing.Size(454, 20);
            this.txtImportFile.TabIndex = 15;
            this.txtImportFile.TextChanged += new System.EventHandler(this.txtImportFile_TextChanged);
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.tlsDirectPaste);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(33, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 127);
            this.panel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtImportSource);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(494, 102);
            this.panel2.TabIndex = 1;
            // 
            // txtImportSource
            // 
            this.txtImportSource.BackColor = System.Drawing.SystemColors.Window;
            this.txtImportSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtImportSource.ContextMenuStrip = this.contextMenuStrip2;
            this.txtImportSource.DetectUrls = false;
            this.txtImportSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtImportSource.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImportSource.Location = new System.Drawing.Point(0, 0);
            this.txtImportSource.Name = "txtImportSource";
            this.txtImportSource.Size = new System.Drawing.Size(492, 100);
            this.txtImportSource.TabIndex = 1;
            this.txtImportSource.Text = "";
            this.txtImportSource.WordWrap = false;
            this.txtImportSource.TextChanged += new System.EventHandler(this.txtImportSource_TextChanged);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxPasteFromClipboard});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(185, 26);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // ctxPasteFromClipboard
            // 
            this.ctxPasteFromClipboard.Image = ((System.Drawing.Image)(resources.GetObject("ctxPasteFromClipboard.Image")));
            this.ctxPasteFromClipboard.Name = "ctxPasteFromClipboard";
            this.ctxPasteFromClipboard.Size = new System.Drawing.Size(184, 22);
            this.ctxPasteFromClipboard.Text = "Paste from clipboard";
            this.ctxPasteFromClipboard.Click += new System.EventHandler(this.pasteFromClipboardToolStripMenuItem_Click);
            // 
            // tlsDirectPaste
            // 
            this.tlsDirectPaste.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsDirectPaste.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPaste});
            this.tlsDirectPaste.Location = new System.Drawing.Point(0, 0);
            this.tlsDirectPaste.Name = "tlsDirectPaste";
            this.tlsDirectPaste.Size = new System.Drawing.Size(494, 25);
            this.tlsDirectPaste.TabIndex = 0;
            // 
            // btnPaste
            // 
            this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            this.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(137, 22);
            this.btnPaste.Text = "Paste from clipboard";
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(564, 296);
            this.tabControl1.TabIndex = 16;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpImportSource);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(556, 267);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Source";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.treeView1);
            this.tabPage2.Controls.Add(this.lblWarning);
            this.tabPage2.Controls.Add(this.tlsImport);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(556, 267);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Import";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 88);
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(556, 179);
            this.treeView1.TabIndex = 3;
            this.treeView1.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeCollapse);
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxEdit,
            this.toolStripSeparator2,
            this.ctxRemove});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 54);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ctxEdit
            // 
            this.ctxEdit.Image = ((System.Drawing.Image)(resources.GetObject("ctxEdit.Image")));
            this.ctxEdit.Name = "ctxEdit";
            this.ctxEdit.Size = new System.Drawing.Size(117, 22);
            this.ctxEdit.Text = "Edit";
            this.ctxEdit.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(114, 6);
            // 
            // ctxRemove
            // 
            this.ctxRemove.Image = ((System.Drawing.Image)(resources.GetObject("cxtRemove.Image")));
            this.ctxRemove.Name = "cxtRemove";
            this.ctxRemove.Size = new System.Drawing.Size(117, 22);
            this.ctxRemove.Text = "Remove";
            this.ctxRemove.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // lblWarning
            // 
            this.lblWarning.AutoEllipsis = true;
            this.lblWarning.BackColor = System.Drawing.SystemColors.Info;
            this.lblWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWarning.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWarning.Location = new System.Drawing.Point(0, 25);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(956, 63);
            this.lblWarning.TabIndex = 4;
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWarning.Visible = false;
            // 
            // tlsImport
            // 
            this.tlsImport.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsImport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEdit,
            this.toolStripSeparator1,
            this.btnRemove});
            this.tlsImport.Location = new System.Drawing.Point(0, 0);
            this.tlsImport.Name = "tlsImport";
            this.tlsImport.Size = new System.Drawing.Size(556, 25);
            this.tlsImport.TabIndex = 5;
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(47, 22);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(70, 22);
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "TriggernometryExport.xml";
            this.openFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "Select file to import";
            // 
            // ImportForm
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnBack;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "ImportForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import";
            this.panel4.ResumeLayout(false);
            this.grpImportSource.ResumeLayout(false);
            this.grpImportSource.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.tlsDirectPaste.ResumeLayout(false);
            this.tlsDirectPaste.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tlsImport.ResumeLayout(false);
            this.tlsImport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnNext;
        internal System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox grpImportSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton radLoadFromFileURI;
        private System.Windows.Forms.RadioButton radImportFromText;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.TextBox txtImportFile;
        private System.Windows.Forms.RadioButton radExistingActTriggers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip tlsDirectPaste;
        private System.Windows.Forms.RichTextBox txtImportSource;
        private System.Windows.Forms.ToolStripButton btnPaste;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        internal System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.ToolStrip tlsImport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnRemove;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ctxEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ctxRemove;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem ctxPasteFromClipboard;
    }
}