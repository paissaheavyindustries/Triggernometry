namespace Triggernometry.Forms
{
    partial class LogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvLog = new Triggernometry.CustomControls.DataGridViewEx();
            this.colTimestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSelectionToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxEverythingToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rexSearch = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblRegularExpression = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkError = new System.Windows.Forms.CheckBox();
            this.chkWarning = new System.Windows.Forms.CheckBox();
            this.chkInfo = new System.Windows.Forms.CheckBox();
            this.chkVerbose = new System.Windows.Forms.CheckBox();
            this.chkCustom = new System.Windows.Forms.CheckBox();
            this.chkCustom2 = new System.Windows.Forms.CheckBox();
            this.panelBar = new System.Windows.Forms.Panel();
            this.capSearch = new Triggernometry.CustomControls.PrettyCaption();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.btnCopy = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnSelectionToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEverythingToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.btnSearchOptions = new System.Windows.Forms.ToolStripButton();
            this.lblStatus = new System.Windows.Forms.ToolStripLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tlsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Controls.Add(this.tlsMain);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(734, 461);
            this.panel2.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(10, 35);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvLog);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Panel2.Controls.Add(this.capSearch);
            this.splitContainer1.Size = new System.Drawing.Size(714, 371);
            this.splitContainer1.SplitterDistance = 510;
            this.splitContainer1.TabIndex = 18;
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.AllowUserToResizeRows = false;
            this.dgvLog.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTimestamp,
            this.colLevel,
            this.colMessage});
            this.dgvLog.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLog.Location = new System.Drawing.Point(0, 0);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowHeadersVisible = false;
            this.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLog.ShowCellErrors = false;
            this.dgvLog.ShowEditingIcon = false;
            this.dgvLog.ShowRowErrors = false;
            this.dgvLog.Size = new System.Drawing.Size(510, 371);
            this.dgvLog.TabIndex = 0;
            this.dgvLog.VirtualMode = true;
            // 
            // colTimestamp
            // 
            this.colTimestamp.HeaderText = "Timestamp";
            this.colTimestamp.Name = "colTimestamp";
            this.colTimestamp.ReadOnly = true;
            this.colTimestamp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTimestamp.Width = 140;
            // 
            // colLevel
            // 
            this.colLevel.HeaderText = "Level";
            this.colLevel.Name = "colLevel";
            this.colLevel.ReadOnly = true;
            this.colLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colLevel.Width = 60;
            // 
            // colMessage
            // 
            this.colMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMessage.HeaderText = "Message";
            this.colMessage.Name = "colMessage";
            this.colMessage.ReadOnly = true;
            this.colMessage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxCopy});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(103, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ctxCopy
            // 
            this.ctxCopy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxSelectionToClipboard,
            this.ctxEverythingToClipboard});
            this.ctxCopy.Image = ((System.Drawing.Image)(resources.GetObject("ctxCopy.Image")));
            this.ctxCopy.Name = "ctxCopy";
            this.ctxCopy.Size = new System.Drawing.Size(102, 22);
            this.ctxCopy.Text = "Copy";
            // 
            // ctxSelectionToClipboard
            // 
            this.ctxSelectionToClipboard.Enabled = false;
            this.ctxSelectionToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("ctxSelectionToClipboard.Image")));
            this.ctxSelectionToClipboard.Name = "ctxSelectionToClipboard";
            this.ctxSelectionToClipboard.Size = new System.Drawing.Size(197, 22);
            this.ctxSelectionToClipboard.Text = "Selection to clipboard";
            this.ctxSelectionToClipboard.Click += new System.EventHandler(this.copySelectionToClipboardToolStripMenuItem_Click);
            // 
            // ctxEverythingToClipboard
            // 
            this.ctxEverythingToClipboard.Image = ((System.Drawing.Image)(resources.GetObject("ctxEverythingToClipboard.Image")));
            this.ctxEverythingToClipboard.Name = "ctxEverythingToClipboard";
            this.ctxEverythingToClipboard.Size = new System.Drawing.Size(197, 22);
            this.ctxEverythingToClipboard.Text = "Everything to clipboard";
            this.ctxEverythingToClipboard.Click += new System.EventHandler(this.copyAllToClipboardToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 61);
            this.panel1.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(0, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(200, 35);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.rexSearch, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblRegularExpression, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 113);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 55);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // rexSearch
            // 
            this.rexSearch.AutoSize = true;
            this.rexSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.rexSearch.Expression = "";
            this.rexSearch.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Regex;
            this.rexSearch.Location = new System.Drawing.Point(3, 32);
            this.rexSearch.Name = "rexSearch";
            this.rexSearch.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.rexSearch.ReadOnly = false;
            this.rexSearch.Size = new System.Drawing.Size(194, 20);
            this.rexSearch.TabIndex = 8;
            // 
            // lblRegularExpression
            // 
            this.lblRegularExpression.AutoSize = true;
            this.lblRegularExpression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRegularExpression.Location = new System.Drawing.Point(3, 0);
            this.lblRegularExpression.Name = "lblRegularExpression";
            this.lblRegularExpression.Padding = new System.Windows.Forms.Padding(5, 15, 5, 8);
            this.lblRegularExpression.Size = new System.Drawing.Size(194, 29);
            this.lblRegularExpression.TabIndex = 0;
            this.lblRegularExpression.Text = "Regular expression";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.chkError, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkWarning, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkCustom, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.chkCustom2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.chkInfo, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.chkVerbose, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.panelBar, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.chkAll, 0, 7);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 83);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // chkError
            // 
            this.chkError.AutoSize = true;
            this.chkError.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.chkError.Margin = new System.Windows.Forms.Padding(20, 17, 20, 3);
            this.chkError.Name = "chkError";
            this.chkError.Text = "Error";
            this.chkError.UseVisualStyleBackColor = true;
            this.chkError.CheckedChanged += new System.EventHandler(this.ChkOther_CheckedChanged);
            this.chkError.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChkOther_RightClick);
            // 
            // chkWarning
            // 
            this.chkWarning.AutoSize = true;
            this.chkWarning.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(128)))), ((int)(((byte)(24)))));
            this.chkWarning.Margin = new System.Windows.Forms.Padding(20, 7, 20, 3);
            this.chkWarning.Name = "chkWarning";
            this.chkWarning.Text = "Warning";
            this.chkWarning.UseVisualStyleBackColor = true;
            this.chkWarning.CheckedChanged += new System.EventHandler(this.ChkOther_CheckedChanged);
            this.chkWarning.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChkOther_RightClick);
            // 
            // chkCustom
            // 
            this.chkCustom.AutoSize = true;
            this.chkCustom.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCustom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(144)))), ((int)(((byte)(72)))));
            this.chkCustom.Margin = new System.Windows.Forms.Padding(20, 7, 20, 3);
            this.chkCustom.Name = "chkCustom";
            this.chkCustom.Text = "Custom";
            this.chkCustom.UseVisualStyleBackColor = true;
            this.chkCustom.CheckedChanged += new System.EventHandler(this.ChkOther_CheckedChanged);
            this.chkCustom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChkOther_RightClick);
            // 
            // chkCustom2
            // 
            this.chkCustom2.AutoSize = true;
            this.chkCustom2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCustom2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCustom2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(72)))), ((int)(((byte)(144)))));
            this.chkCustom2.Margin = new System.Windows.Forms.Padding(20, 7, 20, 3);
            this.chkCustom2.Name = "chkCustom2";
            this.chkCustom2.Text = "Custom 2";
            this.chkCustom2.UseVisualStyleBackColor = true;
            this.chkCustom2.CheckedChanged += new System.EventHandler(this.ChkOther_CheckedChanged);
            this.chkCustom2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChkOther_RightClick);
            // 
            // chkInfo
            // 
            this.chkInfo.AutoSize = true;
            this.chkInfo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.chkInfo.Margin = new System.Windows.Forms.Padding(20, 7, 20, 3);
            this.chkInfo.Name = "chkInfo";
            this.chkInfo.Text = "Info";
            this.chkInfo.UseVisualStyleBackColor = true;
            this.chkInfo.CheckedChanged += new System.EventHandler(this.ChkOther_CheckedChanged);
            this.chkInfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChkOther_RightClick);
            // 
            // chkVerbose
            // 
            this.chkVerbose.AutoSize = true;
            this.chkVerbose.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVerbose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkVerbose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.chkVerbose.Margin = new System.Windows.Forms.Padding(20, 7, 20, 3);
            this.chkVerbose.Name = "chkVerbose";
            this.chkVerbose.Text = "Verbose";
            this.chkVerbose.UseVisualStyleBackColor = true;
            this.chkVerbose.CheckedChanged += new System.EventHandler(this.ChkOther_CheckedChanged);
            this.chkVerbose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChkOther_RightClick);
            // 
            // panelBar
            // 
            this.panelBar.AutoSize = true;
            this.panelBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panelBar.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.panelBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBar.Name = "panelBar";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.chkAll.Margin = new System.Windows.Forms.Padding(20, 17, 20, 3);
            this.chkAll.Name = "chkAll";
            this.chkAll.Text = "Select All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.ChkAll_CheckedChanged);
            this.chkAll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChkAll_RightClick);
            // 
            // capSearch
            // 
            this.capSearch.Caption = "Search options";
            this.capSearch.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capSearch.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.capSearch.Location = new System.Drawing.Point(0, 0);
            this.capSearch.Name = "capSearch";
            this.capSearch.Size = new System.Drawing.Size(200, 30);
            this.capSearch.TabIndex = 5;
            // 
            // tlsMain
            // 
            this.tlsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCopy,
            this.toolStripSeparator3,
            this.btnClear,
            this.btnSearchOptions,
            this.lblStatus});
            this.tlsMain.Location = new System.Drawing.Point(10, 10);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(714, 25);
            this.tlsMain.TabIndex = 3;
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
            this.btnCopy.DropDownOpening += new System.EventHandler(this.toolStripDropDownButton1_DropDownOpening);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(74, 22);
            this.btnClear.Text = "Clear log";
            this.btnClear.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // btnSearchOptions
            // 
            this.btnSearchOptions.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSearchOptions.Checked = true;
            this.btnSearchOptions.CheckOnClick = true;
            this.btnSearchOptions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnSearchOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchOptions.Image")));
            this.btnSearchOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearchOptions.Name = "btnSearchOptions";
            this.btnSearchOptions.Size = new System.Drawing.Size(105, 22);
            this.btnSearchOptions.Text = "Search options";
            this.btnSearchOptions.CheckedChanged += new System.EventHandler(this.btnSearchOptions_CheckedChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 22);
            this.lblStatus.Text = "Status";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 406);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(714, 10);
            this.panel3.TabIndex = 17;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.Location = new System.Drawing.Point(10, 416);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(714, 35);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "LogForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Triggernometry log";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripDropDownButton btnCopy;
        private System.Windows.Forms.ToolStripMenuItem btnSelectionToClipboard;
        private System.Windows.Forms.ToolStripMenuItem btnEverythingToClipboard;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ctxCopy;
        private System.Windows.Forms.ToolStripMenuItem ctxSelectionToClipboard;
        private System.Windows.Forms.ToolStripMenuItem ctxEverythingToClipboard;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnClear;
        private CustomControls.DataGridViewEx dgvLog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton btnSearchOptions;
        private CustomControls.PrettyCaption capSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkError;
        private System.Windows.Forms.CheckBox chkWarning;
        private System.Windows.Forms.CheckBox chkInfo;
        private System.Windows.Forms.CheckBox chkVerbose;
        private System.Windows.Forms.CheckBox chkCustom;
        private System.Windows.Forms.CheckBox chkCustom2;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomControls.ExpressionTextBox rexSearch;
        private System.Windows.Forms.Label lblRegularExpression;
        private System.Windows.Forms.ToolStripLabel lblStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMessage;
    }
}