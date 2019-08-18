namespace Triggernometry.Forms
{
    partial class ConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.grpVolAdjustment = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trbTtsVolume = new System.Windows.Forms.TrackBar();
            this.trbSoundVolume = new System.Windows.Forms.TrackBar();
            this.lblSoundVolume = new System.Windows.Forms.Label();
            this.lblTtsVolume = new System.Windows.Forms.Label();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.chkLogNormalEvents = new System.Windows.Forms.CheckBox();
            this.lblLoggingLevel = new System.Windows.Forms.Label();
            this.cbxLoggingLevel = new System.Windows.Forms.ComboBox();
            this.trvTrigger = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxClearSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.grpActHooks = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkActSoundFiles = new System.Windows.Forms.CheckBox();
            this.chkActTts = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grpFutureProofing = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSeparator = new System.Windows.Forms.TextBox();
            this.lblSeparator = new System.Windows.Forms.Label();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.grpStartupTrigger = new System.Windows.Forms.GroupBox();
            this.tlsDirectPaste = new System.Windows.Forms.ToolStrip();
            this.btnClearSelection = new System.Windows.Forms.ToolStripButton();
            this.lblFolderReminder = new System.Windows.Forms.ToolStripLabel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.grpStartup = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.chkWarnAdmin = new System.Windows.Forms.CheckBox();
            this.chkUpdates = new System.Windows.Forms.CheckBox();
            this.chkWelcome = new System.Windows.Forms.CheckBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tabAudio = new System.Windows.Forms.TabPage();
            this.tabEndpoint = new System.Windows.Forms.TabPage();
            this.grpEndpointSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.lblEndpointStartup = new System.Windows.Forms.Label();
            this.chkEndpointStartup = new System.Windows.Forms.CheckBox();
            this.lblEndpointPort = new System.Windows.Forms.Label();
            this.txtEndpointPassword = new System.Windows.Forms.TextBox();
            this.lblEndpointPassword = new System.Windows.Forms.Label();
            this.nudEndpointPort = new System.Windows.Forms.NumericUpDown();
            this.panel7 = new System.Windows.Forms.Panel();
            this.grpEndpointState = new System.Windows.Forms.GroupBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblEndpointState = new System.Windows.Forms.Label();
            this.btnEndpointStart = new System.Windows.Forms.Button();
            this.btnEndpointStop = new System.Windows.Forms.Button();
            this.tabFFXIV = new System.Windows.Forms.TabPage();
            this.grpPartyListOrder = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFfxivJobOrder = new System.Windows.Forms.Label();
            this.lblFfxivJobMethod = new System.Windows.Forms.Label();
            this.cbxFfxivJobMethod = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstFfxivJobOrder = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFfxivJobUp = new System.Windows.Forms.ToolStripButton();
            this.btnFfxivJobDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFfxivJobRestore = new System.Windows.Forms.ToolStripButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.grpFfxivEventLogging = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.chkFfxivLogNetwork = new System.Windows.Forms.CheckBox();
            this.tabMisc = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxEnableHwAccel = new System.Windows.Forms.CheckBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.grpUserInterface = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxTestLive = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.grpClipboard = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.chkClipboard = new System.Windows.Forms.CheckBox();
            this.lblMonitorWindow = new System.Windows.Forms.Label();
            this.txtMonitorWindow = new System.Windows.Forms.TextBox();
            this.panel4.SuspendLayout();
            this.grpVolAdjustment.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbTtsVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSoundVolume)).BeginInit();
            this.grpGeneral.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.grpActHooks.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpFutureProofing.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tbcMain.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.grpStartupTrigger.SuspendLayout();
            this.tlsDirectPaste.SuspendLayout();
            this.grpStartup.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tabAudio.SuspendLayout();
            this.tabEndpoint.SuspendLayout();
            this.grpEndpointSettings.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndpointPort)).BeginInit();
            this.grpEndpointState.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tabFFXIV.SuspendLayout();
            this.grpPartyListOrder.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.grpFfxivEventLogging.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tabMisc.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.grpUserInterface.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.grpClipboard.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 426);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(564, 10);
            this.panel3.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnOk);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 436);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(564, 35);
            this.panel4.TabIndex = 14;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(414, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOk.Location = new System.Drawing.Point(0, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 35);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // grpVolAdjustment
            // 
            this.grpVolAdjustment.AutoSize = true;
            this.grpVolAdjustment.Controls.Add(this.tableLayoutPanel2);
            this.grpVolAdjustment.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpVolAdjustment.Location = new System.Drawing.Point(7, 7);
            this.grpVolAdjustment.Name = "grpVolAdjustment";
            this.grpVolAdjustment.Padding = new System.Windows.Forms.Padding(10);
            this.grpVolAdjustment.Size = new System.Drawing.Size(542, 89);
            this.grpVolAdjustment.TabIndex = 15;
            this.grpVolAdjustment.TabStop = false;
            this.grpVolAdjustment.Text = " Global volume adjustment ";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.trbTtsVolume, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.trbSoundVolume, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSoundVolume, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTtsVolume, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(522, 56);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(475, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 28);
            this.label6.TabIndex = 9;
            this.label6.Text = "100 %";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoEllipsis = true;
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(475, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 28);
            this.label5.TabIndex = 8;
            this.label5.Text = "100 %";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trbTtsVolume
            // 
            this.trbTtsVolume.AutoSize = false;
            this.trbTtsVolume.Dock = System.Windows.Forms.DockStyle.Top;
            this.trbTtsVolume.Location = new System.Drawing.Point(109, 31);
            this.trbTtsVolume.Maximum = 100;
            this.trbTtsVolume.Name = "trbTtsVolume";
            this.trbTtsVolume.Size = new System.Drawing.Size(360, 22);
            this.trbTtsVolume.TabIndex = 7;
            this.trbTtsVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbTtsVolume.Value = 100;
            this.trbTtsVolume.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            this.trbTtsVolume.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // trbSoundVolume
            // 
            this.trbSoundVolume.AutoSize = false;
            this.trbSoundVolume.Dock = System.Windows.Forms.DockStyle.Top;
            this.trbSoundVolume.Location = new System.Drawing.Point(109, 3);
            this.trbSoundVolume.Maximum = 100;
            this.trbSoundVolume.Name = "trbSoundVolume";
            this.trbSoundVolume.Size = new System.Drawing.Size(360, 22);
            this.trbSoundVolume.TabIndex = 6;
            this.trbSoundVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbSoundVolume.Value = 100;
            this.trbSoundVolume.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trbSoundVolume.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // lblSoundVolume
            // 
            this.lblSoundVolume.AutoEllipsis = true;
            this.lblSoundVolume.AutoSize = true;
            this.lblSoundVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoundVolume.Location = new System.Drawing.Point(3, 0);
            this.lblSoundVolume.Name = "lblSoundVolume";
            this.lblSoundVolume.Size = new System.Drawing.Size(100, 28);
            this.lblSoundVolume.TabIndex = 4;
            this.lblSoundVolume.Text = "Sound file playback";
            this.lblSoundVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTtsVolume
            // 
            this.lblTtsVolume.AutoEllipsis = true;
            this.lblTtsVolume.AutoSize = true;
            this.lblTtsVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTtsVolume.Location = new System.Drawing.Point(3, 28);
            this.lblTtsVolume.Name = "lblTtsVolume";
            this.lblTtsVolume.Size = new System.Drawing.Size(100, 28);
            this.lblTtsVolume.TabIndex = 2;
            this.lblTtsVolume.Text = "Text-to-speech";
            this.lblTtsVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpGeneral
            // 
            this.grpGeneral.AutoSize = true;
            this.grpGeneral.Controls.Add(this.tableLayoutPanel3);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGeneral.Location = new System.Drawing.Point(7, 7);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Padding = new System.Windows.Forms.Padding(10);
            this.grpGeneral.Size = new System.Drawing.Size(542, 83);
            this.grpGeneral.TabIndex = 16;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = " Logging ";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.chkLogNormalEvents, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblLoggingLevel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbxLoggingLevel, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(522, 50);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // chkLogNormalEvents
            // 
            this.chkLogNormalEvents.AutoSize = true;
            this.chkLogNormalEvents.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel3.SetColumnSpan(this.chkLogNormalEvents, 3);
            this.chkLogNormalEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLogNormalEvents.Location = new System.Drawing.Point(3, 30);
            this.chkLogNormalEvents.Name = "chkLogNormalEvents";
            this.chkLogNormalEvents.Size = new System.Drawing.Size(516, 17);
            this.chkLogNormalEvents.TabIndex = 26;
            this.chkLogNormalEvents.Text = "Log normal log lines";
            this.chkLogNormalEvents.UseVisualStyleBackColor = true;
            // 
            // lblLoggingLevel
            // 
            this.lblLoggingLevel.AutoEllipsis = true;
            this.lblLoggingLevel.AutoSize = true;
            this.lblLoggingLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoggingLevel.Location = new System.Drawing.Point(3, 0);
            this.lblLoggingLevel.Name = "lblLoggingLevel";
            this.lblLoggingLevel.Size = new System.Drawing.Size(106, 27);
            this.lblLoggingLevel.TabIndex = 24;
            this.lblLoggingLevel.Text = "Logging filtering level";
            this.lblLoggingLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxLoggingLevel
            // 
            this.cbxLoggingLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxLoggingLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLoggingLevel.FormattingEnabled = true;
            this.cbxLoggingLevel.Items.AddRange(new object[] {
            "Nothing",
            "Errors only",
            "Errors and warnings",
            "All informational messages",
            "Verbose debug"});
            this.cbxLoggingLevel.Location = new System.Drawing.Point(115, 3);
            this.cbxLoggingLevel.Name = "cbxLoggingLevel";
            this.cbxLoggingLevel.Size = new System.Drawing.Size(404, 21);
            this.cbxLoggingLevel.TabIndex = 25;
            // 
            // trvTrigger
            // 
            this.trvTrigger.ContextMenuStrip = this.contextMenuStrip1;
            this.trvTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvTrigger.HideSelection = false;
            this.trvTrigger.Location = new System.Drawing.Point(10, 48);
            this.trvTrigger.MinimumSize = new System.Drawing.Size(4, 50);
            this.trvTrigger.Name = "trvTrigger";
            this.trvTrigger.ShowNodeToolTips = true;
            this.trvTrigger.Size = new System.Drawing.Size(522, 113);
            this.trvTrigger.TabIndex = 23;
            this.trvTrigger.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvTrigger_BeforeCollapse);
            this.trvTrigger.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvTrigger_BeforeExpand);
            this.trvTrigger.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvTrigger_BeforeSelect);
            this.trvTrigger.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTrigger_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxClearSelection});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(152, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ctxClearSelection
            // 
            this.ctxClearSelection.Image = ((System.Drawing.Image)(resources.GetObject("ctxClearSelection.Image")));
            this.ctxClearSelection.Name = "ctxClearSelection";
            this.ctxClearSelection.Size = new System.Drawing.Size(151, 22);
            this.ctxClearSelection.Text = "Clear selection";
            this.ctxClearSelection.Click += new System.EventHandler(this.clearSelectionToolStripMenuItem_Click);
            // 
            // grpActHooks
            // 
            this.grpActHooks.AutoSize = true;
            this.grpActHooks.Controls.Add(this.tableLayoutPanel1);
            this.grpActHooks.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpActHooks.Location = new System.Drawing.Point(7, 106);
            this.grpActHooks.Name = "grpActHooks";
            this.grpActHooks.Padding = new System.Windows.Forms.Padding(10);
            this.grpActHooks.Size = new System.Drawing.Size(542, 79);
            this.grpActHooks.TabIndex = 18;
            this.grpActHooks.TabStop = false;
            this.grpActHooks.Text = " ACT hooks ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.chkActSoundFiles, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkActTts, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(522, 46);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // chkActSoundFiles
            // 
            this.chkActSoundFiles.AutoSize = true;
            this.chkActSoundFiles.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkActSoundFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkActSoundFiles.Location = new System.Drawing.Point(3, 3);
            this.chkActSoundFiles.Name = "chkActSoundFiles";
            this.chkActSoundFiles.Size = new System.Drawing.Size(516, 17);
            this.chkActSoundFiles.TabIndex = 6;
            this.chkActSoundFiles.Text = "Use ACT for playing sound files";
            this.chkActSoundFiles.UseVisualStyleBackColor = true;
            // 
            // chkActTts
            // 
            this.chkActTts.AutoSize = true;
            this.chkActTts.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkActTts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkActTts.Location = new System.Drawing.Point(3, 26);
            this.chkActTts.Name = "chkActTts";
            this.chkActTts.Size = new System.Drawing.Size(516, 17);
            this.chkActTts.TabIndex = 5;
            this.chkActTts.Text = "Use ACT for text-to-speech";
            this.chkActTts.UseVisualStyleBackColor = true;
            this.chkActTts.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(7, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(542, 10);
            this.panel2.TabIndex = 19;
            // 
            // grpFutureProofing
            // 
            this.grpFutureProofing.AutoSize = true;
            this.grpFutureProofing.Controls.Add(this.tableLayoutPanel4);
            this.grpFutureProofing.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFutureProofing.Location = new System.Drawing.Point(7, 73);
            this.grpFutureProofing.Name = "grpFutureProofing";
            this.grpFutureProofing.Padding = new System.Windows.Forms.Padding(10);
            this.grpFutureProofing.Size = new System.Drawing.Size(542, 59);
            this.grpFutureProofing.TabIndex = 21;
            this.grpFutureProofing.TabStop = false;
            this.grpFutureProofing.Text = " Future proofing ";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.txtSeparator, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblSeparator, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(522, 26);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // txtSeparator
            // 
            this.txtSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSeparator.Location = new System.Drawing.Point(111, 3);
            this.txtSeparator.Name = "txtSeparator";
            this.txtSeparator.Size = new System.Drawing.Size(408, 20);
            this.txtSeparator.TabIndex = 7;
            // 
            // lblSeparator
            // 
            this.lblSeparator.AutoEllipsis = true;
            this.lblSeparator.AutoSize = true;
            this.lblSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSeparator.Location = new System.Drawing.Point(3, 0);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(102, 26);
            this.lblSeparator.TabIndex = 6;
            this.lblSeparator.Text = "Event text separator";
            this.lblSeparator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tabGeneral);
            this.tbcMain.Controls.Add(this.tabAudio);
            this.tbcMain.Controls.Add(this.tabEndpoint);
            this.tbcMain.Controls.Add(this.tabFFXIV);
            this.tbcMain.Controls.Add(this.tabMisc);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.Location = new System.Drawing.Point(10, 10);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(564, 416);
            this.tbcMain.TabIndex = 23;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.grpStartupTrigger);
            this.tabGeneral.Controls.Add(this.panel11);
            this.tabGeneral.Controls.Add(this.grpStartup);
            this.tabGeneral.Controls.Add(this.panel10);
            this.tabGeneral.Controls.Add(this.grpGeneral);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(7);
            this.tabGeneral.Size = new System.Drawing.Size(556, 390);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // grpStartupTrigger
            // 
            this.grpStartupTrigger.AutoSize = true;
            this.grpStartupTrigger.Controls.Add(this.trvTrigger);
            this.grpStartupTrigger.Controls.Add(this.tlsDirectPaste);
            this.grpStartupTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStartupTrigger.Location = new System.Drawing.Point(7, 212);
            this.grpStartupTrigger.Name = "grpStartupTrigger";
            this.grpStartupTrigger.Padding = new System.Windows.Forms.Padding(10);
            this.grpStartupTrigger.Size = new System.Drawing.Size(542, 171);
            this.grpStartupTrigger.TabIndex = 27;
            this.grpStartupTrigger.TabStop = false;
            this.grpStartupTrigger.Text = " Startup trigger/folder ";
            // 
            // tlsDirectPaste
            // 
            this.tlsDirectPaste.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsDirectPaste.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClearSelection,
            this.lblFolderReminder});
            this.tlsDirectPaste.Location = new System.Drawing.Point(10, 23);
            this.tlsDirectPaste.Name = "tlsDirectPaste";
            this.tlsDirectPaste.Size = new System.Drawing.Size(522, 25);
            this.tlsDirectPaste.TabIndex = 24;
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.Enabled = false;
            this.btnClearSelection.Image = ((System.Drawing.Image)(resources.GetObject("btnClearSelection.Image")));
            this.btnClearSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(104, 22);
            this.btnClearSelection.Text = "Clear selection";
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // lblFolderReminder
            // 
            this.lblFolderReminder.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblFolderReminder.Image = ((System.Drawing.Image)(resources.GetObject("lblFolderReminder.Image")));
            this.lblFolderReminder.Name = "lblFolderReminder";
            this.lblFolderReminder.Size = new System.Drawing.Size(301, 22);
            this.lblFolderReminder.Text = "Selecting a folder will fire all triggers inside the folder";
            this.lblFolderReminder.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.lblFolderReminder.Visible = false;
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(7, 202);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(542, 10);
            this.panel11.TabIndex = 28;
            // 
            // grpStartup
            // 
            this.grpStartup.AutoSize = true;
            this.grpStartup.Controls.Add(this.tableLayoutPanel7);
            this.grpStartup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpStartup.Location = new System.Drawing.Point(7, 100);
            this.grpStartup.Name = "grpStartup";
            this.grpStartup.Padding = new System.Windows.Forms.Padding(10);
            this.grpStartup.Size = new System.Drawing.Size(542, 102);
            this.grpStartup.TabIndex = 25;
            this.grpStartup.TabStop = false;
            this.grpStartup.Text = " Startup ";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.chkWarnAdmin, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.chkUpdates, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.chkWelcome, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(522, 69);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // chkWarnAdmin
            // 
            this.chkWarnAdmin.AutoSize = true;
            this.chkWarnAdmin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkWarnAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkWarnAdmin.Location = new System.Drawing.Point(3, 49);
            this.chkWarnAdmin.Name = "chkWarnAdmin";
            this.chkWarnAdmin.Size = new System.Drawing.Size(516, 17);
            this.chkWarnAdmin.TabIndex = 8;
            this.chkWarnAdmin.Text = "Warn if not running as Administrator";
            this.chkWarnAdmin.UseVisualStyleBackColor = true;
            // 
            // chkUpdates
            // 
            this.chkUpdates.AutoSize = true;
            this.chkUpdates.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkUpdates.Location = new System.Drawing.Point(3, 26);
            this.chkUpdates.Name = "chkUpdates";
            this.chkUpdates.Size = new System.Drawing.Size(516, 17);
            this.chkUpdates.TabIndex = 7;
            this.chkUpdates.Text = "Check for updates on startup";
            this.chkUpdates.UseVisualStyleBackColor = true;
            // 
            // chkWelcome
            // 
            this.chkWelcome.AutoSize = true;
            this.chkWelcome.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkWelcome.Location = new System.Drawing.Point(3, 3);
            this.chkWelcome.Name = "chkWelcome";
            this.chkWelcome.Size = new System.Drawing.Size(516, 17);
            this.chkWelcome.TabIndex = 6;
            this.chkWelcome.Text = "Show Welcome Screen on startup";
            this.chkWelcome.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(7, 90);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(542, 10);
            this.panel10.TabIndex = 26;
            // 
            // tabAudio
            // 
            this.tabAudio.Controls.Add(this.grpActHooks);
            this.tabAudio.Controls.Add(this.panel2);
            this.tabAudio.Controls.Add(this.grpVolAdjustment);
            this.tabAudio.Location = new System.Drawing.Point(4, 22);
            this.tabAudio.Name = "tabAudio";
            this.tabAudio.Padding = new System.Windows.Forms.Padding(7);
            this.tabAudio.Size = new System.Drawing.Size(556, 390);
            this.tabAudio.TabIndex = 1;
            this.tabAudio.Text = "Audio";
            this.tabAudio.UseVisualStyleBackColor = true;
            // 
            // tabEndpoint
            // 
            this.tabEndpoint.Controls.Add(this.grpEndpointSettings);
            this.tabEndpoint.Controls.Add(this.panel7);
            this.tabEndpoint.Controls.Add(this.grpEndpointState);
            this.tabEndpoint.Location = new System.Drawing.Point(4, 22);
            this.tabEndpoint.Name = "tabEndpoint";
            this.tabEndpoint.Padding = new System.Windows.Forms.Padding(7);
            this.tabEndpoint.Size = new System.Drawing.Size(556, 390);
            this.tabEndpoint.TabIndex = 4;
            this.tabEndpoint.Text = "Endpoint";
            this.tabEndpoint.UseVisualStyleBackColor = true;
            // 
            // grpEndpointSettings
            // 
            this.grpEndpointSettings.AutoSize = true;
            this.grpEndpointSettings.Controls.Add(this.tableLayoutPanel8);
            this.grpEndpointSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEndpointSettings.Enabled = false;
            this.grpEndpointSettings.Location = new System.Drawing.Point(7, 80);
            this.grpEndpointSettings.Name = "grpEndpointSettings";
            this.grpEndpointSettings.Padding = new System.Windows.Forms.Padding(10);
            this.grpEndpointSettings.Size = new System.Drawing.Size(542, 108);
            this.grpEndpointSettings.TabIndex = 22;
            this.grpEndpointSettings.TabStop = false;
            this.grpEndpointSettings.Text = " Endpoint settings ";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.AutoSize = true;
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.lblEndpointStartup, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.chkEndpointStartup, 1, 2);
            this.tableLayoutPanel8.Controls.Add(this.lblEndpointPort, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.txtEndpointPassword, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.lblEndpointPassword, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.nudEndpointPort, 1, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.Size = new System.Drawing.Size(522, 75);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // lblEndpointStartup
            // 
            this.lblEndpointStartup.AutoEllipsis = true;
            this.lblEndpointStartup.AutoSize = true;
            this.lblEndpointStartup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEndpointStartup.Location = new System.Drawing.Point(3, 52);
            this.lblEndpointStartup.Name = "lblEndpointStartup";
            this.lblEndpointStartup.Size = new System.Drawing.Size(123, 23);
            this.lblEndpointStartup.TabIndex = 11;
            this.lblEndpointStartup.Text = "Start endpoint on startup";
            this.lblEndpointStartup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkEndpointStartup
            // 
            this.chkEndpointStartup.AutoSize = true;
            this.chkEndpointStartup.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEndpointStartup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkEndpointStartup.Location = new System.Drawing.Point(132, 55);
            this.chkEndpointStartup.Name = "chkEndpointStartup";
            this.chkEndpointStartup.Size = new System.Drawing.Size(387, 17);
            this.chkEndpointStartup.TabIndex = 10;
            this.chkEndpointStartup.Text = "  ";
            this.chkEndpointStartup.UseVisualStyleBackColor = true;
            // 
            // lblEndpointPort
            // 
            this.lblEndpointPort.AutoEllipsis = true;
            this.lblEndpointPort.AutoSize = true;
            this.lblEndpointPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEndpointPort.Location = new System.Drawing.Point(3, 26);
            this.lblEndpointPort.Name = "lblEndpointPort";
            this.lblEndpointPort.Size = new System.Drawing.Size(123, 26);
            this.lblEndpointPort.TabIndex = 8;
            this.lblEndpointPort.Text = "Port";
            this.lblEndpointPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEndpointPassword
            // 
            this.txtEndpointPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEndpointPassword.Location = new System.Drawing.Point(132, 3);
            this.txtEndpointPassword.Name = "txtEndpointPassword";
            this.txtEndpointPassword.Size = new System.Drawing.Size(387, 20);
            this.txtEndpointPassword.TabIndex = 7;
            // 
            // lblEndpointPassword
            // 
            this.lblEndpointPassword.AutoEllipsis = true;
            this.lblEndpointPassword.AutoSize = true;
            this.lblEndpointPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEndpointPassword.Location = new System.Drawing.Point(3, 0);
            this.lblEndpointPassword.Name = "lblEndpointPassword";
            this.lblEndpointPassword.Size = new System.Drawing.Size(123, 26);
            this.lblEndpointPassword.TabIndex = 6;
            this.lblEndpointPassword.Text = "Password";
            this.lblEndpointPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudEndpointPort
            // 
            this.nudEndpointPort.Dock = System.Windows.Forms.DockStyle.Right;
            this.nudEndpointPort.Location = new System.Drawing.Point(399, 29);
            this.nudEndpointPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudEndpointPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEndpointPort.Name = "nudEndpointPort";
            this.nudEndpointPort.Size = new System.Drawing.Size(120, 20);
            this.nudEndpointPort.TabIndex = 9;
            this.nudEndpointPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudEndpointPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(7, 70);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(542, 10);
            this.panel7.TabIndex = 24;
            // 
            // grpEndpointState
            // 
            this.grpEndpointState.AutoSize = true;
            this.grpEndpointState.Controls.Add(this.panel8);
            this.grpEndpointState.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEndpointState.Enabled = false;
            this.grpEndpointState.Location = new System.Drawing.Point(7, 7);
            this.grpEndpointState.Name = "grpEndpointState";
            this.grpEndpointState.Padding = new System.Windows.Forms.Padding(10);
            this.grpEndpointState.Size = new System.Drawing.Size(542, 63);
            this.grpEndpointState.TabIndex = 23;
            this.grpEndpointState.TabStop = false;
            this.grpEndpointState.Text = " Status ";
            // 
            // panel8
            // 
            this.panel8.AutoSize = true;
            this.panel8.Controls.Add(this.lblEndpointState);
            this.panel8.Controls.Add(this.btnEndpointStart);
            this.panel8.Controls.Add(this.btnEndpointStop);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(10, 23);
            this.panel8.MinimumSize = new System.Drawing.Size(0, 30);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(522, 30);
            this.panel8.TabIndex = 1;
            // 
            // lblEndpointState
            // 
            this.lblEndpointState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEndpointState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEndpointState.Location = new System.Drawing.Point(0, 0);
            this.lblEndpointState.Name = "lblEndpointState";
            this.lblEndpointState.Size = new System.Drawing.Size(362, 30);
            this.lblEndpointState.TabIndex = 2;
            this.lblEndpointState.Text = "Endpoint is not running.";
            this.lblEndpointState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnEndpointStart
            // 
            this.btnEndpointStart.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEndpointStart.Image = ((System.Drawing.Image)(resources.GetObject("btnEndpointStart.Image")));
            this.btnEndpointStart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEndpointStart.Location = new System.Drawing.Point(362, 0);
            this.btnEndpointStart.Name = "btnEndpointStart";
            this.btnEndpointStart.Size = new System.Drawing.Size(80, 30);
            this.btnEndpointStart.TabIndex = 0;
            this.btnEndpointStart.Text = "Start";
            this.btnEndpointStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEndpointStart.UseVisualStyleBackColor = true;
            // 
            // btnEndpointStop
            // 
            this.btnEndpointStop.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEndpointStop.Image = ((System.Drawing.Image)(resources.GetObject("btnEndpointStop.Image")));
            this.btnEndpointStop.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEndpointStop.Location = new System.Drawing.Point(442, 0);
            this.btnEndpointStop.Name = "btnEndpointStop";
            this.btnEndpointStop.Size = new System.Drawing.Size(80, 30);
            this.btnEndpointStop.TabIndex = 1;
            this.btnEndpointStop.Text = "Stop";
            this.btnEndpointStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEndpointStop.UseVisualStyleBackColor = true;
            // 
            // tabFFXIV
            // 
            this.tabFFXIV.Controls.Add(this.grpPartyListOrder);
            this.tabFFXIV.Controls.Add(this.panel9);
            this.tabFFXIV.Controls.Add(this.grpFfxivEventLogging);
            this.tabFFXIV.Location = new System.Drawing.Point(4, 22);
            this.tabFFXIV.Name = "tabFFXIV";
            this.tabFFXIV.Padding = new System.Windows.Forms.Padding(7);
            this.tabFFXIV.Size = new System.Drawing.Size(556, 390);
            this.tabFFXIV.TabIndex = 2;
            this.tabFFXIV.Text = "Final Fantasy XIV";
            this.tabFFXIV.UseVisualStyleBackColor = true;
            // 
            // grpPartyListOrder
            // 
            this.grpPartyListOrder.AutoSize = true;
            this.grpPartyListOrder.Controls.Add(this.tableLayoutPanel5);
            this.grpPartyListOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPartyListOrder.Location = new System.Drawing.Point(7, 73);
            this.grpPartyListOrder.Name = "grpPartyListOrder";
            this.grpPartyListOrder.Padding = new System.Windows.Forms.Padding(10);
            this.grpPartyListOrder.Size = new System.Drawing.Size(542, 310);
            this.grpPartyListOrder.TabIndex = 16;
            this.grpPartyListOrder.TabStop = false;
            this.grpPartyListOrder.Text = " Party list ordering ";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.lblFfxivJobOrder, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblFfxivJobMethod, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.cbxFfxivJobMethod, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(522, 277);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // lblFfxivJobOrder
            // 
            this.lblFfxivJobOrder.AutoEllipsis = true;
            this.lblFfxivJobOrder.AutoSize = true;
            this.lblFfxivJobOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFfxivJobOrder.Location = new System.Drawing.Point(3, 27);
            this.lblFfxivJobOrder.Name = "lblFfxivJobOrder";
            this.lblFfxivJobOrder.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblFfxivJobOrder.Size = new System.Drawing.Size(85, 250);
            this.lblFfxivJobOrder.TabIndex = 7;
            this.lblFfxivJobOrder.Text = "Job order";
            // 
            // lblFfxivJobMethod
            // 
            this.lblFfxivJobMethod.AutoEllipsis = true;
            this.lblFfxivJobMethod.AutoSize = true;
            this.lblFfxivJobMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFfxivJobMethod.Location = new System.Drawing.Point(3, 0);
            this.lblFfxivJobMethod.Name = "lblFfxivJobMethod";
            this.lblFfxivJobMethod.Size = new System.Drawing.Size(85, 27);
            this.lblFfxivJobMethod.TabIndex = 4;
            this.lblFfxivJobMethod.Text = "Ordering method";
            this.lblFfxivJobMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxFfxivJobMethod
            // 
            this.cbxFfxivJobMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxFfxivJobMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFfxivJobMethod.FormattingEnabled = true;
            this.cbxFfxivJobMethod.Items.AddRange(new object[] {
            "Player first, rest unordered (legacy)",
            "Player first, sort the rest by custom party order",
            "Sort everyone by custom party order"});
            this.cbxFfxivJobMethod.Location = new System.Drawing.Point(94, 3);
            this.cbxFfxivJobMethod.Name = "cbxFfxivJobMethod";
            this.cbxFfxivJobMethod.Size = new System.Drawing.Size(425, 21);
            this.cbxFfxivJobMethod.TabIndex = 5;
            this.cbxFfxivJobMethod.SelectedIndexChanged += new System.EventHandler(this.cbxFfxivJobMethod_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lstFfxivJobOrder);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(94, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 244);
            this.panel1.TabIndex = 8;
            // 
            // lstFfxivJobOrder
            // 
            this.lstFfxivJobOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFfxivJobOrder.FormattingEnabled = true;
            this.lstFfxivJobOrder.IntegralHeight = false;
            this.lstFfxivJobOrder.Location = new System.Drawing.Point(0, 25);
            this.lstFfxivJobOrder.Name = "lstFfxivJobOrder";
            this.lstFfxivJobOrder.Size = new System.Drawing.Size(425, 219);
            this.lstFfxivJobOrder.TabIndex = 18;
            this.lstFfxivJobOrder.SelectedIndexChanged += new System.EventHandler(this.lstFfxivJobOrder_SelectedIndexChanged);
            this.lstFfxivJobOrder.EnabledChanged += new System.EventHandler(this.lstFfxivJobOrder_EnabledChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFfxivJobUp,
            this.btnFfxivJobDown,
            this.toolStripSeparator1,
            this.btnFfxivJobRestore});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(425, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // btnFfxivJobUp
            // 
            this.btnFfxivJobUp.Enabled = false;
            this.btnFfxivJobUp.Image = ((System.Drawing.Image)(resources.GetObject("btnFfxivJobUp.Image")));
            this.btnFfxivJobUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFfxivJobUp.Name = "btnFfxivJobUp";
            this.btnFfxivJobUp.Size = new System.Drawing.Size(74, 22);
            this.btnFfxivJobUp.Text = "Move up";
            this.btnFfxivJobUp.Click += new System.EventHandler(this.btnFfxivJobUp_Click);
            // 
            // btnFfxivJobDown
            // 
            this.btnFfxivJobDown.Enabled = false;
            this.btnFfxivJobDown.Image = ((System.Drawing.Image)(resources.GetObject("btnFfxivJobDown.Image")));
            this.btnFfxivJobDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFfxivJobDown.Name = "btnFfxivJobDown";
            this.btnFfxivJobDown.Size = new System.Drawing.Size(90, 22);
            this.btnFfxivJobDown.Text = "Move down";
            this.btnFfxivJobDown.Click += new System.EventHandler(this.btnFfxivJobDown_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFfxivJobRestore
            // 
            this.btnFfxivJobRestore.Image = ((System.Drawing.Image)(resources.GetObject("btnFfxivJobRestore.Image")));
            this.btnFfxivJobRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFfxivJobRestore.Name = "btnFfxivJobRestore";
            this.btnFfxivJobRestore.Size = new System.Drawing.Size(106, 22);
            this.btnFfxivJobRestore.Text = "Restore default";
            this.btnFfxivJobRestore.Click += new System.EventHandler(this.btnFfxivJobRestore_Click);
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(7, 63);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(542, 10);
            this.panel9.TabIndex = 20;
            // 
            // grpFfxivEventLogging
            // 
            this.grpFfxivEventLogging.AutoSize = true;
            this.grpFfxivEventLogging.Controls.Add(this.tableLayoutPanel9);
            this.grpFfxivEventLogging.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFfxivEventLogging.Location = new System.Drawing.Point(7, 7);
            this.grpFfxivEventLogging.Name = "grpFfxivEventLogging";
            this.grpFfxivEventLogging.Padding = new System.Windows.Forms.Padding(10);
            this.grpFfxivEventLogging.Size = new System.Drawing.Size(542, 56);
            this.grpFfxivEventLogging.TabIndex = 19;
            this.grpFfxivEventLogging.TabStop = false;
            this.grpFfxivEventLogging.Text = " Event logging ";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.AutoSize = true;
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.chkFfxivLogNetwork, 0, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.Size = new System.Drawing.Size(522, 23);
            this.tableLayoutPanel9.TabIndex = 1;
            // 
            // chkFfxivLogNetwork
            // 
            this.chkFfxivLogNetwork.AutoSize = true;
            this.chkFfxivLogNetwork.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFfxivLogNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkFfxivLogNetwork.Location = new System.Drawing.Point(3, 3);
            this.chkFfxivLogNetwork.Name = "chkFfxivLogNetwork";
            this.chkFfxivLogNetwork.Size = new System.Drawing.Size(516, 17);
            this.chkFfxivLogNetwork.TabIndex = 5;
            this.chkFfxivLogNetwork.Text = "Log network events";
            this.chkFfxivLogNetwork.UseVisualStyleBackColor = true;
            // 
            // tabMisc
            // 
            this.tabMisc.Controls.Add(this.groupBox1);
            this.tabMisc.Controls.Add(this.panel12);
            this.tabMisc.Controls.Add(this.grpUserInterface);
            this.tabMisc.Controls.Add(this.panel6);
            this.tabMisc.Controls.Add(this.grpFutureProofing);
            this.tabMisc.Controls.Add(this.panel5);
            this.tabMisc.Controls.Add(this.grpClipboard);
            this.tabMisc.Location = new System.Drawing.Point(4, 22);
            this.tabMisc.Name = "tabMisc";
            this.tabMisc.Padding = new System.Windows.Forms.Padding(7);
            this.tabMisc.Size = new System.Drawing.Size(556, 390);
            this.tabMisc.TabIndex = 3;
            this.tabMisc.Text = "Miscellaneous";
            this.tabMisc.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel11);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(7, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(542, 82);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Beta ";
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.AutoSize = true;
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.txtMonitorWindow, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.lblMonitorWindow, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.cbxEnableHwAccel, 0, 1);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.Size = new System.Drawing.Size(522, 49);
            this.tableLayoutPanel11.TabIndex = 2;
            // 
            // cbxEnableHwAccel
            // 
            this.cbxEnableHwAccel.AutoSize = true;
            this.cbxEnableHwAccel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel11.SetColumnSpan(this.cbxEnableHwAccel, 2);
            this.cbxEnableHwAccel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxEnableHwAccel.Location = new System.Drawing.Point(3, 29);
            this.cbxEnableHwAccel.Name = "cbxEnableHwAccel";
            this.cbxEnableHwAccel.Size = new System.Drawing.Size(516, 17);
            this.cbxEnableHwAccel.TabIndex = 6;
            this.cbxEnableHwAccel.Text = "Enable aura hardware acceleration";
            this.cbxEnableHwAccel.UseVisualStyleBackColor = true;
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(7, 198);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(542, 10);
            this.panel12.TabIndex = 26;
            // 
            // grpUserInterface
            // 
            this.grpUserInterface.AutoSize = true;
            this.grpUserInterface.Controls.Add(this.tableLayoutPanel10);
            this.grpUserInterface.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpUserInterface.Location = new System.Drawing.Point(7, 142);
            this.grpUserInterface.Name = "grpUserInterface";
            this.grpUserInterface.Padding = new System.Windows.Forms.Padding(10);
            this.grpUserInterface.Size = new System.Drawing.Size(542, 56);
            this.grpUserInterface.TabIndex = 25;
            this.grpUserInterface.TabStop = false;
            this.grpUserInterface.Text = " User interface ";
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.AutoSize = true;
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.cbxTestLive, 0, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(522, 23);
            this.tableLayoutPanel10.TabIndex = 2;
            // 
            // cbxTestLive
            // 
            this.cbxTestLive.AutoSize = true;
            this.cbxTestLive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxTestLive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxTestLive.Location = new System.Drawing.Point(3, 3);
            this.cbxTestLive.Name = "cbxTestLive";
            this.cbxTestLive.Size = new System.Drawing.Size(516, 17);
            this.cbxTestLive.TabIndex = 6;
            this.cbxTestLive.Text = "Set testing with live values as the default action test method";
            this.cbxTestLive.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(7, 132);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(542, 10);
            this.panel6.TabIndex = 24;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(7, 63);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(542, 10);
            this.panel5.TabIndex = 22;
            // 
            // grpClipboard
            // 
            this.grpClipboard.AutoSize = true;
            this.grpClipboard.Controls.Add(this.tableLayoutPanel6);
            this.grpClipboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpClipboard.Location = new System.Drawing.Point(7, 7);
            this.grpClipboard.Name = "grpClipboard";
            this.grpClipboard.Padding = new System.Windows.Forms.Padding(10);
            this.grpClipboard.Size = new System.Drawing.Size(542, 56);
            this.grpClipboard.TabIndex = 23;
            this.grpClipboard.TabStop = false;
            this.grpClipboard.Text = " Clipboard ";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.chkClipboard, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(522, 23);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // chkClipboard
            // 
            this.chkClipboard.AutoSize = true;
            this.chkClipboard.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkClipboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkClipboard.Location = new System.Drawing.Point(3, 3);
            this.chkClipboard.Name = "chkClipboard";
            this.chkClipboard.Size = new System.Drawing.Size(516, 17);
            this.chkClipboard.TabIndex = 6;
            this.chkClipboard.Text = "Use operating system clipboard";
            this.chkClipboard.UseVisualStyleBackColor = true;
            // 
            // lblMonitorWindow
            // 
            this.lblMonitorWindow.AutoEllipsis = true;
            this.lblMonitorWindow.AutoSize = true;
            this.lblMonitorWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMonitorWindow.Location = new System.Drawing.Point(3, 0);
            this.lblMonitorWindow.Name = "lblMonitorWindow";
            this.lblMonitorWindow.Size = new System.Drawing.Size(195, 26);
            this.lblMonitorWindow.TabIndex = 7;
            this.lblMonitorWindow.Text = "Monitor window for showing/hiding aura";
            this.lblMonitorWindow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMonitorWindow
            // 
            this.txtMonitorWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMonitorWindow.Location = new System.Drawing.Point(204, 3);
            this.txtMonitorWindow.Name = "txtMonitorWindow";
            this.txtMonitorWindow.Size = new System.Drawing.Size(315, 20);
            this.txtMonitorWindow.TabIndex = 8;
            // 
            // ConfigurationForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(584, 481);
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(600, 520);
            this.Name = "ConfigurationForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
            this.Shown += new System.EventHandler(this.ConfigurationForm_Shown);
            this.panel4.ResumeLayout(false);
            this.grpVolAdjustment.ResumeLayout(false);
            this.grpVolAdjustment.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbTtsVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSoundVolume)).EndInit();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.grpActHooks.ResumeLayout(false);
            this.grpActHooks.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.grpFutureProofing.ResumeLayout(false);
            this.grpFutureProofing.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tbcMain.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.grpStartupTrigger.ResumeLayout(false);
            this.grpStartupTrigger.PerformLayout();
            this.tlsDirectPaste.ResumeLayout(false);
            this.tlsDirectPaste.PerformLayout();
            this.grpStartup.ResumeLayout(false);
            this.grpStartup.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tabAudio.ResumeLayout(false);
            this.tabAudio.PerformLayout();
            this.tabEndpoint.ResumeLayout(false);
            this.tabEndpoint.PerformLayout();
            this.grpEndpointSettings.ResumeLayout(false);
            this.grpEndpointSettings.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndpointPort)).EndInit();
            this.grpEndpointState.ResumeLayout(false);
            this.grpEndpointState.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.tabFFXIV.ResumeLayout(false);
            this.tabFFXIV.PerformLayout();
            this.grpPartyListOrder.ResumeLayout(false);
            this.grpPartyListOrder.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grpFfxivEventLogging.ResumeLayout(false);
            this.grpFfxivEventLogging.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tabMisc.ResumeLayout(false);
            this.tabMisc.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.grpUserInterface.ResumeLayout(false);
            this.grpUserInterface.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.grpClipboard.ResumeLayout(false);
            this.grpClipboard.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox grpVolAdjustment;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trbTtsVolume;
        private System.Windows.Forms.TrackBar trbSoundVolume;
        private System.Windows.Forms.Label lblSoundVolume;
        private System.Windows.Forms.Label lblTtsVolume;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox grpActHooks;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chkActTts;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkActSoundFiles;
        private System.Windows.Forms.GroupBox grpFutureProofing;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox txtSeparator;
        private System.Windows.Forms.Label lblSeparator;
        internal System.Windows.Forms.TreeView trvTrigger;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ctxClearSelection;
        private System.Windows.Forms.Label lblLoggingLevel;
        private System.Windows.Forms.ComboBox cbxLoggingLevel;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabAudio;
        private System.Windows.Forms.TabPage tabFFXIV;
        private System.Windows.Forms.TabPage tabMisc;
        private System.Windows.Forms.GroupBox grpPartyListOrder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblFfxivJobOrder;
        private System.Windows.Forms.Label lblFfxivJobMethod;
        private System.Windows.Forms.ComboBox cbxFfxivJobMethod;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstFfxivJobOrder;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnFfxivJobUp;
        private System.Windows.Forms.ToolStripButton btnFfxivJobDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFfxivJobRestore;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox grpClipboard;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.CheckBox chkClipboard;
        private System.Windows.Forms.GroupBox grpStartup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.CheckBox chkWelcome;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox chkUpdates;
        private System.Windows.Forms.TabPage tabEndpoint;
        private System.Windows.Forms.GroupBox grpEndpointSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label lblEndpointPort;
        private System.Windows.Forms.TextBox txtEndpointPassword;
        private System.Windows.Forms.Label lblEndpointPassword;
        private System.Windows.Forms.Label lblEndpointStartup;
        private System.Windows.Forms.CheckBox chkEndpointStartup;
        private System.Windows.Forms.NumericUpDown nudEndpointPort;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.GroupBox grpEndpointState;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnEndpointStop;
        private System.Windows.Forms.Button btnEndpointStart;
        private System.Windows.Forms.Label lblEndpointState;
        private System.Windows.Forms.GroupBox grpFfxivEventLogging;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.CheckBox chkFfxivLogNetwork;
        private System.Windows.Forms.CheckBox chkLogNormalEvents;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.GroupBox grpStartupTrigger;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.ToolStrip tlsDirectPaste;
        private System.Windows.Forms.ToolStripButton btnClearSelection;
        private System.Windows.Forms.ToolStripLabel lblFolderReminder;
        private System.Windows.Forms.CheckBox chkWarnAdmin;
        private System.Windows.Forms.GroupBox grpUserInterface;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.CheckBox cbxTestLive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.CheckBox cbxEnableHwAccel;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.TextBox txtMonitorWindow;
        private System.Windows.Forms.Label lblMonitorWindow;
    }
}