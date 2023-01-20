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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.chkLogVariableExpansions = new System.Windows.Forms.CheckBox();
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
            this.cbxUpdateMethod = new System.Windows.Forms.ComboBox();
            this.lblUpdateMethod = new System.Windows.Forms.Label();
            this.chkWarnAdmin = new System.Windows.Forms.CheckBox();
            this.chkUpdates = new System.Windows.Forms.CheckBox();
            this.chkWelcome = new System.Windows.Forms.CheckBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tabAudio = new System.Windows.Forms.TabPage();
            this.tabCaching = new System.Windows.Forms.TabPage();
            this.panel16 = new System.Windows.Forms.Panel();
            this.grpCacheFile = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCacheFileBrowse = new System.Windows.Forms.Button();
            this.btnCacheFileClear = new System.Windows.Forms.Button();
            this.txtCacheFileSize = new System.Windows.Forms.TextBox();
            this.lblCacheFileSize = new System.Windows.Forms.Label();
            this.lblCacheFileCount = new System.Windows.Forms.Label();
            this.lblCacheFileExpiry = new System.Windows.Forms.Label();
            this.nudCacheFileExpiry = new System.Windows.Forms.NumericUpDown();
            this.txtCacheFileCount = new System.Windows.Forms.TextBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.grpCacheRepo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCacheRepoBrowse = new System.Windows.Forms.Button();
            this.btnCacheRepoClear = new System.Windows.Forms.Button();
            this.txtCacheRepoSize = new System.Windows.Forms.TextBox();
            this.lblCacheRepoSize = new System.Windows.Forms.Label();
            this.lblCacheRepoCount = new System.Windows.Forms.Label();
            this.lblCacheRepoExpiry = new System.Windows.Forms.Label();
            this.nudCacheRepoExpiry = new System.Windows.Forms.NumericUpDown();
            this.txtCacheRepoCount = new System.Windows.Forms.TextBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.grpCacheJSON = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.nudCacheJsonExpiry = new System.Windows.Forms.NumericUpDown();
            this.btnCacheJsonBrowse = new System.Windows.Forms.Button();
            this.btnCacheJsonClear = new System.Windows.Forms.Button();
            this.txtCacheJsonSize = new System.Windows.Forms.TextBox();
            this.lblCacheJsonSize = new System.Windows.Forms.Label();
            this.lblCacheJsonCount = new System.Windows.Forms.Label();
            this.lblCacheJsonExpiry = new System.Windows.Forms.Label();
            this.txtCacheJsonCount = new System.Windows.Forms.TextBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.grpCacheSound = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCacheSoundBrowse = new System.Windows.Forms.Button();
            this.btnCacheSoundClear = new System.Windows.Forms.Button();
            this.txtCacheSoundSize = new System.Windows.Forms.TextBox();
            this.lblCacheSoundSize = new System.Windows.Forms.Label();
            this.lblCacheSoundCount = new System.Windows.Forms.Label();
            this.lblCacheSoundExpiry = new System.Windows.Forms.Label();
            this.nudCacheSoundExpiry = new System.Windows.Forms.NumericUpDown();
            this.txtCacheSoundCount = new System.Windows.Forms.TextBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.grpCacheImage = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCacheImageBrowse = new System.Windows.Forms.Button();
            this.txtCacheImageSize = new System.Windows.Forms.TextBox();
            this.lblCacheImageSize = new System.Windows.Forms.Label();
            this.lblCacheImageCount = new System.Windows.Forms.Label();
            this.lblCacheImageExpiry = new System.Windows.Forms.Label();
            this.nudCacheImageExpiry = new System.Windows.Forms.NumericUpDown();
            this.txtCacheImageCount = new System.Windows.Forms.TextBox();
            this.btnCacheImageClear = new System.Windows.Forms.Button();
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
            this.tabSubstitutions = new System.Windows.Forms.TabPage();
            this.dgvSubstitutions = new Triggernometry.CustomControls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlsSubstitutions = new System.Windows.Forms.ToolStrip();
            this.btnSubAdd = new System.Windows.Forms.ToolStripButton();
            this.btnSubEdit = new System.Windows.Forms.ToolStripButton();
            this.btnSubRemove = new System.Windows.Forms.ToolStripButton();
            this.tabConsts = new System.Windows.Forms.TabPage();
            this.panel19 = new System.Windows.Forms.Panel();
            this.dgvConstVariables = new Triggernometry.CustomControls.DataGridViewEx();
            this.colScalarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScalarValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlsScalar = new System.Windows.Forms.ToolStrip();
            this.btnConstAdd = new System.Windows.Forms.ToolStripButton();
            this.btnConstEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConstRemove = new System.Windows.Forms.ToolStripButton();
            this.tabSecurity = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvApiAccess = new Triggernometry.CustomControls.DataGridViewEx();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel18 = new System.Windows.Forms.Panel();
            this.btnUnlockSecurity = new System.Windows.Forms.Button();
            this.tabMisc = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMonitorWindow = new System.Windows.Forms.TextBox();
            this.lblMonitorWindow = new System.Windows.Forms.Label();
            this.cbxEnableHwAccel = new System.Windows.Forms.CheckBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.grpUserInterface = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.chkClipboard = new System.Windows.Forms.CheckBox();
            this.lblAutosaveInterval = new System.Windows.Forms.Label();
            this.cbxAutosaveConfig = new System.Windows.Forms.CheckBox();
            this.cbxDevMode = new System.Windows.Forms.CheckBox();
            this.cbxTestLive = new System.Windows.Forms.CheckBox();
            this.nudAutosaveMinutes = new System.Windows.Forms.NumericUpDown();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.grpDefaultSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxTriggerTemplate = new System.Windows.Forms.CheckBox();
            this.btnTriggerTemplate = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.cbxActionAsync = new System.Windows.Forms.CheckBox();
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
            this.tabCaching.SuspendLayout();
            this.panel16.SuspendLayout();
            this.grpCacheFile.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheFileExpiry)).BeginInit();
            this.grpCacheRepo.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheRepoExpiry)).BeginInit();
            this.grpCacheJSON.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheJsonExpiry)).BeginInit();
            this.grpCacheSound.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheSoundExpiry)).BeginInit();
            this.grpCacheImage.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheImageExpiry)).BeginInit();
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
            this.tabSubstitutions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubstitutions)).BeginInit();
            this.tlsSubstitutions.SuspendLayout();
            this.tabConsts.SuspendLayout();
            this.panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstVariables)).BeginInit();
            this.tlsScalar.SuspendLayout();
            this.tabSecurity.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApiAccess)).BeginInit();
            this.tabMisc.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.grpUserInterface.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutosaveMinutes)).BeginInit();
            this.grpDefaultSettings.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 606);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(764, 10);
            this.panel3.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnOk);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 616);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(764, 35);
            this.panel4.TabIndex = 14;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(614, 0);
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
            // 
            // grpVolAdjustment
            // 
            this.grpVolAdjustment.AutoSize = true;
            this.grpVolAdjustment.Controls.Add(this.tableLayoutPanel2);
            this.grpVolAdjustment.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpVolAdjustment.Location = new System.Drawing.Point(7, 7);
            this.grpVolAdjustment.Name = "grpVolAdjustment";
            this.grpVolAdjustment.Padding = new System.Windows.Forms.Padding(10);
            this.grpVolAdjustment.Size = new System.Drawing.Size(742, 89);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(722, 56);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(675, 28);
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
            this.label5.Location = new System.Drawing.Point(675, 0);
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
            this.trbTtsVolume.Size = new System.Drawing.Size(560, 22);
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
            this.trbSoundVolume.Size = new System.Drawing.Size(560, 22);
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
            this.grpGeneral.Size = new System.Drawing.Size(742, 106);
            this.grpGeneral.TabIndex = 16;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = " Logging ";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.chkLogVariableExpansions, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.chkLogNormalEvents, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblLoggingLevel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbxLoggingLevel, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(722, 73);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // chkLogVariableExpansions
            // 
            this.chkLogVariableExpansions.AutoSize = true;
            this.chkLogVariableExpansions.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel3.SetColumnSpan(this.chkLogVariableExpansions, 3);
            this.chkLogVariableExpansions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLogVariableExpansions.Location = new System.Drawing.Point(3, 53);
            this.chkLogVariableExpansions.Name = "chkLogVariableExpansions";
            this.chkLogVariableExpansions.Size = new System.Drawing.Size(716, 17);
            this.chkLogVariableExpansions.TabIndex = 27;
            this.chkLogVariableExpansions.Text = "Log variable expansions";
            this.chkLogVariableExpansions.UseVisualStyleBackColor = true;
            // 
            // chkLogNormalEvents
            // 
            this.chkLogNormalEvents.AutoSize = true;
            this.chkLogNormalEvents.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel3.SetColumnSpan(this.chkLogNormalEvents, 3);
            this.chkLogNormalEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLogNormalEvents.Location = new System.Drawing.Point(3, 30);
            this.chkLogNormalEvents.Name = "chkLogNormalEvents";
            this.chkLogNormalEvents.Size = new System.Drawing.Size(716, 17);
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
            this.lblLoggingLevel.Size = new System.Drawing.Size(355, 27);
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
            this.cbxLoggingLevel.Location = new System.Drawing.Point(364, 3);
            this.cbxLoggingLevel.Name = "cbxLoggingLevel";
            this.cbxLoggingLevel.Size = new System.Drawing.Size(355, 21);
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
            this.trvTrigger.Size = new System.Drawing.Size(722, 243);
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
            this.grpActHooks.Size = new System.Drawing.Size(742, 79);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(722, 46);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // chkActSoundFiles
            // 
            this.chkActSoundFiles.AutoSize = true;
            this.chkActSoundFiles.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkActSoundFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkActSoundFiles.Location = new System.Drawing.Point(3, 3);
            this.chkActSoundFiles.Name = "chkActSoundFiles";
            this.chkActSoundFiles.Size = new System.Drawing.Size(716, 17);
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
            this.chkActTts.Size = new System.Drawing.Size(716, 17);
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
            this.panel2.Size = new System.Drawing.Size(742, 10);
            this.panel2.TabIndex = 19;
            // 
            // grpFutureProofing
            // 
            this.grpFutureProofing.AutoSize = true;
            this.grpFutureProofing.Controls.Add(this.tableLayoutPanel4);
            this.grpFutureProofing.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFutureProofing.Location = new System.Drawing.Point(7, 79);
            this.grpFutureProofing.Name = "grpFutureProofing";
            this.grpFutureProofing.Padding = new System.Windows.Forms.Padding(10);
            this.grpFutureProofing.Size = new System.Drawing.Size(742, 59);
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
            this.tableLayoutPanel4.Size = new System.Drawing.Size(722, 26);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // txtSeparator
            // 
            this.txtSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSeparator.Location = new System.Drawing.Point(111, 3);
            this.txtSeparator.Name = "txtSeparator";
            this.txtSeparator.Size = new System.Drawing.Size(608, 20);
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
            this.tbcMain.Controls.Add(this.tabCaching);
            this.tbcMain.Controls.Add(this.tabEndpoint);
            this.tbcMain.Controls.Add(this.tabFFXIV);
            this.tbcMain.Controls.Add(this.tabSubstitutions);
            this.tbcMain.Controls.Add(this.tabConsts);
            this.tbcMain.Controls.Add(this.tabSecurity);
            this.tbcMain.Controls.Add(this.tabMisc);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.Location = new System.Drawing.Point(10, 10);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(764, 596);
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
            this.tabGeneral.Size = new System.Drawing.Size(756, 570);
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
            this.grpStartupTrigger.Location = new System.Drawing.Point(7, 262);
            this.grpStartupTrigger.Name = "grpStartupTrigger";
            this.grpStartupTrigger.Padding = new System.Windows.Forms.Padding(10);
            this.grpStartupTrigger.Size = new System.Drawing.Size(742, 301);
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
            this.tlsDirectPaste.Size = new System.Drawing.Size(722, 25);
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
            this.panel11.Location = new System.Drawing.Point(7, 252);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(742, 10);
            this.panel11.TabIndex = 28;
            // 
            // grpStartup
            // 
            this.grpStartup.AutoSize = true;
            this.grpStartup.Controls.Add(this.tableLayoutPanel7);
            this.grpStartup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpStartup.Location = new System.Drawing.Point(7, 123);
            this.grpStartup.Name = "grpStartup";
            this.grpStartup.Padding = new System.Windows.Forms.Padding(10);
            this.grpStartup.Size = new System.Drawing.Size(742, 129);
            this.grpStartup.TabIndex = 25;
            this.grpStartup.TabStop = false;
            this.grpStartup.Text = " Startup ";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.cbxUpdateMethod, 1, 3);
            this.tableLayoutPanel7.Controls.Add(this.lblUpdateMethod, 0, 3);
            this.tableLayoutPanel7.Controls.Add(this.chkWarnAdmin, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.chkUpdates, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.chkWelcome, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 4;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(722, 96);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // cbxUpdateMethod
            // 
            this.cbxUpdateMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxUpdateMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUpdateMethod.FormattingEnabled = true;
            this.cbxUpdateMethod.Items.AddRange(new object[] {
            "Built-in (legacy)",
            "ACT"});
            this.cbxUpdateMethod.Location = new System.Drawing.Point(364, 72);
            this.cbxUpdateMethod.Name = "cbxUpdateMethod";
            this.cbxUpdateMethod.Size = new System.Drawing.Size(355, 21);
            this.cbxUpdateMethod.TabIndex = 26;
            // 
            // lblUpdateMethod
            // 
            this.lblUpdateMethod.AutoEllipsis = true;
            this.lblUpdateMethod.AutoSize = true;
            this.lblUpdateMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpdateMethod.Location = new System.Drawing.Point(3, 69);
            this.lblUpdateMethod.Name = "lblUpdateMethod";
            this.lblUpdateMethod.Size = new System.Drawing.Size(355, 27);
            this.lblUpdateMethod.TabIndex = 25;
            this.lblUpdateMethod.Text = "Plugin update check method";
            this.lblUpdateMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkWarnAdmin
            // 
            this.chkWarnAdmin.AutoSize = true;
            this.chkWarnAdmin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel7.SetColumnSpan(this.chkWarnAdmin, 2);
            this.chkWarnAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkWarnAdmin.Location = new System.Drawing.Point(3, 26);
            this.chkWarnAdmin.Name = "chkWarnAdmin";
            this.chkWarnAdmin.Size = new System.Drawing.Size(716, 17);
            this.chkWarnAdmin.TabIndex = 8;
            this.chkWarnAdmin.Text = "Warn if not running as Administrator";
            this.chkWarnAdmin.UseVisualStyleBackColor = true;
            // 
            // chkUpdates
            // 
            this.chkUpdates.AutoSize = true;
            this.chkUpdates.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel7.SetColumnSpan(this.chkUpdates, 2);
            this.chkUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkUpdates.Location = new System.Drawing.Point(3, 49);
            this.chkUpdates.Name = "chkUpdates";
            this.chkUpdates.Size = new System.Drawing.Size(716, 17);
            this.chkUpdates.TabIndex = 7;
            this.chkUpdates.Text = "Check for updates on startup";
            this.chkUpdates.UseVisualStyleBackColor = true;
            // 
            // chkWelcome
            // 
            this.chkWelcome.AutoSize = true;
            this.chkWelcome.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel7.SetColumnSpan(this.chkWelcome, 2);
            this.chkWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkWelcome.Location = new System.Drawing.Point(3, 3);
            this.chkWelcome.Name = "chkWelcome";
            this.chkWelcome.Size = new System.Drawing.Size(716, 17);
            this.chkWelcome.TabIndex = 6;
            this.chkWelcome.Text = "Show Welcome Screen on startup";
            this.chkWelcome.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(7, 113);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(742, 10);
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
            this.tabAudio.Size = new System.Drawing.Size(756, 570);
            this.tabAudio.TabIndex = 1;
            this.tabAudio.Text = "Audio";
            this.tabAudio.UseVisualStyleBackColor = true;
            // 
            // tabCaching
            // 
            this.tabCaching.Controls.Add(this.panel16);
            this.tabCaching.Location = new System.Drawing.Point(4, 22);
            this.tabCaching.Name = "tabCaching";
            this.tabCaching.Padding = new System.Windows.Forms.Padding(7);
            this.tabCaching.Size = new System.Drawing.Size(756, 570);
            this.tabCaching.TabIndex = 5;
            this.tabCaching.Text = "Caching";
            this.tabCaching.UseVisualStyleBackColor = true;
            // 
            // panel16
            // 
            this.panel16.AutoScroll = true;
            this.panel16.Controls.Add(this.grpCacheFile);
            this.panel16.Controls.Add(this.panel17);
            this.panel16.Controls.Add(this.grpCacheRepo);
            this.panel16.Controls.Add(this.panel15);
            this.panel16.Controls.Add(this.grpCacheJSON);
            this.panel16.Controls.Add(this.panel14);
            this.panel16.Controls.Add(this.grpCacheSound);
            this.panel16.Controls.Add(this.panel13);
            this.panel16.Controls.Add(this.grpCacheImage);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(7, 7);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(742, 556);
            this.panel16.TabIndex = 30;
            // 
            // grpCacheFile
            // 
            this.grpCacheFile.AutoSize = true;
            this.grpCacheFile.Controls.Add(this.tableLayoutPanel16);
            this.grpCacheFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCacheFile.Location = new System.Drawing.Point(0, 600);
            this.grpCacheFile.Name = "grpCacheFile";
            this.grpCacheFile.Padding = new System.Windows.Forms.Padding(10);
            this.grpCacheFile.Size = new System.Drawing.Size(725, 140);
            this.grpCacheFile.TabIndex = 34;
            this.grpCacheFile.TabStop = false;
            this.grpCacheFile.Text = " File downloads ";
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.AutoSize = true;
            this.tableLayoutPanel16.ColumnCount = 3;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel16.Controls.Add(this.btnCacheFileBrowse, 2, 3);
            this.tableLayoutPanel16.Controls.Add(this.btnCacheFileClear, 1, 3);
            this.tableLayoutPanel16.Controls.Add(this.txtCacheFileSize, 1, 2);
            this.tableLayoutPanel16.Controls.Add(this.lblCacheFileSize, 0, 2);
            this.tableLayoutPanel16.Controls.Add(this.lblCacheFileCount, 0, 1);
            this.tableLayoutPanel16.Controls.Add(this.lblCacheFileExpiry, 0, 0);
            this.tableLayoutPanel16.Controls.Add(this.nudCacheFileExpiry, 1, 0);
            this.tableLayoutPanel16.Controls.Add(this.txtCacheFileCount, 1, 1);
            this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel16.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 4;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.Size = new System.Drawing.Size(705, 107);
            this.tableLayoutPanel16.TabIndex = 0;
            // 
            // btnCacheFileBrowse
            // 
            this.btnCacheFileBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCacheFileBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnCacheFileBrowse.Image")));
            this.btnCacheFileBrowse.Location = new System.Drawing.Point(420, 81);
            this.btnCacheFileBrowse.Name = "btnCacheFileBrowse";
            this.btnCacheFileBrowse.Size = new System.Drawing.Size(282, 23);
            this.btnCacheFileBrowse.TabIndex = 18;
            this.btnCacheFileBrowse.Text = "Browse";
            this.btnCacheFileBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCacheFileBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCacheFileBrowse.UseMnemonic = false;
            this.btnCacheFileBrowse.UseVisualStyleBackColor = true;
            this.btnCacheFileBrowse.Click += new System.EventHandler(this.btnCacheFileBrowse_Click);
            // 
            // btnCacheFileClear
            // 
            this.btnCacheFileClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCacheFileClear.Image = ((System.Drawing.Image)(resources.GetObject("btnCacheFileClear.Image")));
            this.btnCacheFileClear.Location = new System.Drawing.Point(132, 81);
            this.btnCacheFileClear.Name = "btnCacheFileClear";
            this.btnCacheFileClear.Size = new System.Drawing.Size(282, 23);
            this.btnCacheFileClear.TabIndex = 17;
            this.btnCacheFileClear.Text = "Clear cache";
            this.btnCacheFileClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCacheFileClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCacheFileClear.UseMnemonic = false;
            this.btnCacheFileClear.UseVisualStyleBackColor = true;
            this.btnCacheFileClear.Click += new System.EventHandler(this.btnCacheFileClear_Click);
            // 
            // txtCacheFileSize
            // 
            this.tableLayoutPanel16.SetColumnSpan(this.txtCacheFileSize, 2);
            this.txtCacheFileSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheFileSize.Location = new System.Drawing.Point(132, 55);
            this.txtCacheFileSize.Name = "txtCacheFileSize";
            this.txtCacheFileSize.ReadOnly = true;
            this.txtCacheFileSize.Size = new System.Drawing.Size(570, 20);
            this.txtCacheFileSize.TabIndex = 13;
            this.txtCacheFileSize.Text = "0";
            this.txtCacheFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCacheFileSize
            // 
            this.lblCacheFileSize.AutoEllipsis = true;
            this.lblCacheFileSize.AutoSize = true;
            this.lblCacheFileSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheFileSize.Location = new System.Drawing.Point(3, 52);
            this.lblCacheFileSize.Name = "lblCacheFileSize";
            this.lblCacheFileSize.Size = new System.Drawing.Size(123, 26);
            this.lblCacheFileSize.TabIndex = 12;
            this.lblCacheFileSize.Text = "Current disk size in bytes";
            this.lblCacheFileSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheFileCount
            // 
            this.lblCacheFileCount.AutoEllipsis = true;
            this.lblCacheFileCount.AutoSize = true;
            this.lblCacheFileCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheFileCount.Location = new System.Drawing.Point(3, 26);
            this.lblCacheFileCount.Name = "lblCacheFileCount";
            this.lblCacheFileCount.Size = new System.Drawing.Size(123, 26);
            this.lblCacheFileCount.TabIndex = 10;
            this.lblCacheFileCount.Text = "Current item count";
            this.lblCacheFileCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheFileExpiry
            // 
            this.lblCacheFileExpiry.AutoEllipsis = true;
            this.lblCacheFileExpiry.AutoSize = true;
            this.lblCacheFileExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheFileExpiry.Location = new System.Drawing.Point(3, 0);
            this.lblCacheFileExpiry.Name = "lblCacheFileExpiry";
            this.lblCacheFileExpiry.Size = new System.Drawing.Size(123, 26);
            this.lblCacheFileExpiry.TabIndex = 8;
            this.lblCacheFileExpiry.Text = "Expiration in minutes";
            this.lblCacheFileExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudCacheFileExpiry
            // 
            this.tableLayoutPanel16.SetColumnSpan(this.nudCacheFileExpiry, 2);
            this.nudCacheFileExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudCacheFileExpiry.Location = new System.Drawing.Point(132, 3);
            this.nudCacheFileExpiry.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudCacheFileExpiry.Name = "nudCacheFileExpiry";
            this.nudCacheFileExpiry.Size = new System.Drawing.Size(570, 20);
            this.nudCacheFileExpiry.TabIndex = 9;
            this.nudCacheFileExpiry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCacheFileExpiry.Value = new decimal(new int[] {
            518400,
            0,
            0,
            0});
            // 
            // txtCacheFileCount
            // 
            this.tableLayoutPanel16.SetColumnSpan(this.txtCacheFileCount, 2);
            this.txtCacheFileCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheFileCount.Location = new System.Drawing.Point(132, 29);
            this.txtCacheFileCount.Name = "txtCacheFileCount";
            this.txtCacheFileCount.ReadOnly = true;
            this.txtCacheFileCount.Size = new System.Drawing.Size(570, 20);
            this.txtCacheFileCount.TabIndex = 11;
            this.txtCacheFileCount.Text = "0";
            this.txtCacheFileCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel17
            // 
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(0, 590);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(725, 10);
            this.panel17.TabIndex = 33;
            // 
            // grpCacheRepo
            // 
            this.grpCacheRepo.AutoSize = true;
            this.grpCacheRepo.Controls.Add(this.tableLayoutPanel15);
            this.grpCacheRepo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCacheRepo.Location = new System.Drawing.Point(0, 450);
            this.grpCacheRepo.Name = "grpCacheRepo";
            this.grpCacheRepo.Padding = new System.Windows.Forms.Padding(10);
            this.grpCacheRepo.Size = new System.Drawing.Size(725, 140);
            this.grpCacheRepo.TabIndex = 32;
            this.grpCacheRepo.TabStop = false;
            this.grpCacheRepo.Text = " Repository backups ";
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.AutoSize = true;
            this.tableLayoutPanel15.ColumnCount = 3;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel15.Controls.Add(this.btnCacheRepoBrowse, 2, 3);
            this.tableLayoutPanel15.Controls.Add(this.btnCacheRepoClear, 1, 3);
            this.tableLayoutPanel15.Controls.Add(this.txtCacheRepoSize, 1, 2);
            this.tableLayoutPanel15.Controls.Add(this.lblCacheRepoSize, 0, 2);
            this.tableLayoutPanel15.Controls.Add(this.lblCacheRepoCount, 0, 1);
            this.tableLayoutPanel15.Controls.Add(this.lblCacheRepoExpiry, 0, 0);
            this.tableLayoutPanel15.Controls.Add(this.nudCacheRepoExpiry, 1, 0);
            this.tableLayoutPanel15.Controls.Add(this.txtCacheRepoCount, 1, 1);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 4;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.Size = new System.Drawing.Size(705, 107);
            this.tableLayoutPanel15.TabIndex = 0;
            // 
            // btnCacheRepoBrowse
            // 
            this.btnCacheRepoBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCacheRepoBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnCacheRepoBrowse.Image")));
            this.btnCacheRepoBrowse.Location = new System.Drawing.Point(420, 81);
            this.btnCacheRepoBrowse.Name = "btnCacheRepoBrowse";
            this.btnCacheRepoBrowse.Size = new System.Drawing.Size(282, 23);
            this.btnCacheRepoBrowse.TabIndex = 18;
            this.btnCacheRepoBrowse.Text = "Browse";
            this.btnCacheRepoBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCacheRepoBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCacheRepoBrowse.UseMnemonic = false;
            this.btnCacheRepoBrowse.UseVisualStyleBackColor = true;
            this.btnCacheRepoBrowse.Click += new System.EventHandler(this.btnCacheRepoBrowse_Click);
            // 
            // btnCacheRepoClear
            // 
            this.btnCacheRepoClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCacheRepoClear.Image = ((System.Drawing.Image)(resources.GetObject("btnCacheRepoClear.Image")));
            this.btnCacheRepoClear.Location = new System.Drawing.Point(132, 81);
            this.btnCacheRepoClear.Name = "btnCacheRepoClear";
            this.btnCacheRepoClear.Size = new System.Drawing.Size(282, 23);
            this.btnCacheRepoClear.TabIndex = 17;
            this.btnCacheRepoClear.Text = "Clear cache";
            this.btnCacheRepoClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCacheRepoClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCacheRepoClear.UseMnemonic = false;
            this.btnCacheRepoClear.UseVisualStyleBackColor = true;
            this.btnCacheRepoClear.Click += new System.EventHandler(this.btnCacheRepoClear_Click);
            // 
            // txtCacheRepoSize
            // 
            this.tableLayoutPanel15.SetColumnSpan(this.txtCacheRepoSize, 2);
            this.txtCacheRepoSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheRepoSize.Location = new System.Drawing.Point(132, 55);
            this.txtCacheRepoSize.Name = "txtCacheRepoSize";
            this.txtCacheRepoSize.ReadOnly = true;
            this.txtCacheRepoSize.Size = new System.Drawing.Size(570, 20);
            this.txtCacheRepoSize.TabIndex = 13;
            this.txtCacheRepoSize.Text = "0";
            this.txtCacheRepoSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCacheRepoSize
            // 
            this.lblCacheRepoSize.AutoEllipsis = true;
            this.lblCacheRepoSize.AutoSize = true;
            this.lblCacheRepoSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheRepoSize.Location = new System.Drawing.Point(3, 52);
            this.lblCacheRepoSize.Name = "lblCacheRepoSize";
            this.lblCacheRepoSize.Size = new System.Drawing.Size(123, 26);
            this.lblCacheRepoSize.TabIndex = 12;
            this.lblCacheRepoSize.Text = "Current disk size in bytes";
            this.lblCacheRepoSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheRepoCount
            // 
            this.lblCacheRepoCount.AutoEllipsis = true;
            this.lblCacheRepoCount.AutoSize = true;
            this.lblCacheRepoCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheRepoCount.Location = new System.Drawing.Point(3, 26);
            this.lblCacheRepoCount.Name = "lblCacheRepoCount";
            this.lblCacheRepoCount.Size = new System.Drawing.Size(123, 26);
            this.lblCacheRepoCount.TabIndex = 10;
            this.lblCacheRepoCount.Text = "Current item count";
            this.lblCacheRepoCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheRepoExpiry
            // 
            this.lblCacheRepoExpiry.AutoEllipsis = true;
            this.lblCacheRepoExpiry.AutoSize = true;
            this.lblCacheRepoExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheRepoExpiry.Location = new System.Drawing.Point(3, 0);
            this.lblCacheRepoExpiry.Name = "lblCacheRepoExpiry";
            this.lblCacheRepoExpiry.Size = new System.Drawing.Size(123, 26);
            this.lblCacheRepoExpiry.TabIndex = 8;
            this.lblCacheRepoExpiry.Text = "Expiration in minutes";
            this.lblCacheRepoExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudCacheRepoExpiry
            // 
            this.tableLayoutPanel15.SetColumnSpan(this.nudCacheRepoExpiry, 2);
            this.nudCacheRepoExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudCacheRepoExpiry.Location = new System.Drawing.Point(132, 3);
            this.nudCacheRepoExpiry.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudCacheRepoExpiry.Name = "nudCacheRepoExpiry";
            this.nudCacheRepoExpiry.Size = new System.Drawing.Size(570, 20);
            this.nudCacheRepoExpiry.TabIndex = 9;
            this.nudCacheRepoExpiry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCacheRepoExpiry.Value = new decimal(new int[] {
            518400,
            0,
            0,
            0});
            // 
            // txtCacheRepoCount
            // 
            this.tableLayoutPanel15.SetColumnSpan(this.txtCacheRepoCount, 2);
            this.txtCacheRepoCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheRepoCount.Location = new System.Drawing.Point(132, 29);
            this.txtCacheRepoCount.Name = "txtCacheRepoCount";
            this.txtCacheRepoCount.ReadOnly = true;
            this.txtCacheRepoCount.Size = new System.Drawing.Size(570, 20);
            this.txtCacheRepoCount.TabIndex = 11;
            this.txtCacheRepoCount.Text = "0";
            this.txtCacheRepoCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel15
            // 
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 440);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(725, 10);
            this.panel15.TabIndex = 31;
            // 
            // grpCacheJSON
            // 
            this.grpCacheJSON.AutoSize = true;
            this.grpCacheJSON.Controls.Add(this.tableLayoutPanel13);
            this.grpCacheJSON.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCacheJSON.Location = new System.Drawing.Point(0, 300);
            this.grpCacheJSON.Name = "grpCacheJSON";
            this.grpCacheJSON.Padding = new System.Windows.Forms.Padding(10);
            this.grpCacheJSON.Size = new System.Drawing.Size(725, 140);
            this.grpCacheJSON.TabIndex = 30;
            this.grpCacheJSON.TabStop = false;
            this.grpCacheJSON.Text = " JSON responses ";
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.AutoSize = true;
            this.tableLayoutPanel13.ColumnCount = 3;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel13.Controls.Add(this.nudCacheJsonExpiry, 1, 0);
            this.tableLayoutPanel13.Controls.Add(this.btnCacheJsonBrowse, 2, 3);
            this.tableLayoutPanel13.Controls.Add(this.btnCacheJsonClear, 1, 3);
            this.tableLayoutPanel13.Controls.Add(this.txtCacheJsonSize, 1, 2);
            this.tableLayoutPanel13.Controls.Add(this.lblCacheJsonSize, 0, 2);
            this.tableLayoutPanel13.Controls.Add(this.lblCacheJsonCount, 0, 1);
            this.tableLayoutPanel13.Controls.Add(this.lblCacheJsonExpiry, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.txtCacheJsonCount, 1, 1);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 4;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(705, 107);
            this.tableLayoutPanel13.TabIndex = 0;
            // 
            // nudCacheJsonExpiry
            // 
            this.tableLayoutPanel13.SetColumnSpan(this.nudCacheJsonExpiry, 2);
            this.nudCacheJsonExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudCacheJsonExpiry.Location = new System.Drawing.Point(132, 3);
            this.nudCacheJsonExpiry.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudCacheJsonExpiry.Name = "nudCacheJsonExpiry";
            this.nudCacheJsonExpiry.Size = new System.Drawing.Size(570, 20);
            this.nudCacheJsonExpiry.TabIndex = 18;
            this.nudCacheJsonExpiry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCacheJsonExpiry.Value = new decimal(new int[] {
            10800,
            0,
            0,
            0});
            // 
            // btnCacheJsonBrowse
            // 
            this.btnCacheJsonBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCacheJsonBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnCacheJsonBrowse.Image")));
            this.btnCacheJsonBrowse.Location = new System.Drawing.Point(420, 81);
            this.btnCacheJsonBrowse.Name = "btnCacheJsonBrowse";
            this.btnCacheJsonBrowse.Size = new System.Drawing.Size(282, 23);
            this.btnCacheJsonBrowse.TabIndex = 17;
            this.btnCacheJsonBrowse.Text = "Browse";
            this.btnCacheJsonBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCacheJsonBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCacheJsonBrowse.UseMnemonic = false;
            this.btnCacheJsonBrowse.UseVisualStyleBackColor = true;
            this.btnCacheJsonBrowse.Click += new System.EventHandler(this.btnCacheJsonBrowse_Click);
            // 
            // btnCacheJsonClear
            // 
            this.btnCacheJsonClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCacheJsonClear.Image = ((System.Drawing.Image)(resources.GetObject("btnCacheJsonClear.Image")));
            this.btnCacheJsonClear.Location = new System.Drawing.Point(132, 81);
            this.btnCacheJsonClear.Name = "btnCacheJsonClear";
            this.btnCacheJsonClear.Size = new System.Drawing.Size(282, 23);
            this.btnCacheJsonClear.TabIndex = 16;
            this.btnCacheJsonClear.Text = "Clear cache";
            this.btnCacheJsonClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCacheJsonClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCacheJsonClear.UseMnemonic = false;
            this.btnCacheJsonClear.UseVisualStyleBackColor = true;
            this.btnCacheJsonClear.Click += new System.EventHandler(this.btnCacheJsonClear_Click);
            // 
            // txtCacheJsonSize
            // 
            this.tableLayoutPanel13.SetColumnSpan(this.txtCacheJsonSize, 2);
            this.txtCacheJsonSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheJsonSize.Location = new System.Drawing.Point(132, 55);
            this.txtCacheJsonSize.Name = "txtCacheJsonSize";
            this.txtCacheJsonSize.ReadOnly = true;
            this.txtCacheJsonSize.Size = new System.Drawing.Size(570, 20);
            this.txtCacheJsonSize.TabIndex = 13;
            this.txtCacheJsonSize.Text = "0";
            this.txtCacheJsonSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCacheJsonSize
            // 
            this.lblCacheJsonSize.AutoEllipsis = true;
            this.lblCacheJsonSize.AutoSize = true;
            this.lblCacheJsonSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheJsonSize.Location = new System.Drawing.Point(3, 52);
            this.lblCacheJsonSize.Name = "lblCacheJsonSize";
            this.lblCacheJsonSize.Size = new System.Drawing.Size(123, 26);
            this.lblCacheJsonSize.TabIndex = 12;
            this.lblCacheJsonSize.Text = "Current disk size in bytes";
            this.lblCacheJsonSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheJsonCount
            // 
            this.lblCacheJsonCount.AutoEllipsis = true;
            this.lblCacheJsonCount.AutoSize = true;
            this.lblCacheJsonCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheJsonCount.Location = new System.Drawing.Point(3, 26);
            this.lblCacheJsonCount.Name = "lblCacheJsonCount";
            this.lblCacheJsonCount.Size = new System.Drawing.Size(123, 26);
            this.lblCacheJsonCount.TabIndex = 10;
            this.lblCacheJsonCount.Text = "Current item count";
            this.lblCacheJsonCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheJsonExpiry
            // 
            this.lblCacheJsonExpiry.AutoEllipsis = true;
            this.lblCacheJsonExpiry.AutoSize = true;
            this.lblCacheJsonExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheJsonExpiry.Location = new System.Drawing.Point(3, 0);
            this.lblCacheJsonExpiry.Name = "lblCacheJsonExpiry";
            this.lblCacheJsonExpiry.Size = new System.Drawing.Size(123, 26);
            this.lblCacheJsonExpiry.TabIndex = 8;
            this.lblCacheJsonExpiry.Text = "Expiration in minutes";
            this.lblCacheJsonExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCacheJsonCount
            // 
            this.tableLayoutPanel13.SetColumnSpan(this.txtCacheJsonCount, 2);
            this.txtCacheJsonCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheJsonCount.Location = new System.Drawing.Point(132, 29);
            this.txtCacheJsonCount.Name = "txtCacheJsonCount";
            this.txtCacheJsonCount.ReadOnly = true;
            this.txtCacheJsonCount.Size = new System.Drawing.Size(570, 20);
            this.txtCacheJsonCount.TabIndex = 11;
            this.txtCacheJsonCount.Text = "0";
            this.txtCacheJsonCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 290);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(725, 10);
            this.panel14.TabIndex = 29;
            // 
            // grpCacheSound
            // 
            this.grpCacheSound.AutoSize = true;
            this.grpCacheSound.Controls.Add(this.tableLayoutPanel14);
            this.grpCacheSound.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCacheSound.Location = new System.Drawing.Point(0, 150);
            this.grpCacheSound.Name = "grpCacheSound";
            this.grpCacheSound.Padding = new System.Windows.Forms.Padding(10);
            this.grpCacheSound.Size = new System.Drawing.Size(725, 140);
            this.grpCacheSound.TabIndex = 28;
            this.grpCacheSound.TabStop = false;
            this.grpCacheSound.Text = " Sound files ";
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.AutoSize = true;
            this.tableLayoutPanel14.ColumnCount = 3;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.Controls.Add(this.btnCacheSoundBrowse, 2, 3);
            this.tableLayoutPanel14.Controls.Add(this.btnCacheSoundClear, 1, 3);
            this.tableLayoutPanel14.Controls.Add(this.txtCacheSoundSize, 1, 2);
            this.tableLayoutPanel14.Controls.Add(this.lblCacheSoundSize, 0, 2);
            this.tableLayoutPanel14.Controls.Add(this.lblCacheSoundCount, 0, 1);
            this.tableLayoutPanel14.Controls.Add(this.lblCacheSoundExpiry, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.nudCacheSoundExpiry, 1, 0);
            this.tableLayoutPanel14.Controls.Add(this.txtCacheSoundCount, 1, 1);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 4;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.Size = new System.Drawing.Size(705, 107);
            this.tableLayoutPanel14.TabIndex = 0;
            // 
            // btnCacheSoundBrowse
            // 
            this.btnCacheSoundBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCacheSoundBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnCacheSoundBrowse.Image")));
            this.btnCacheSoundBrowse.Location = new System.Drawing.Point(420, 81);
            this.btnCacheSoundBrowse.Name = "btnCacheSoundBrowse";
            this.btnCacheSoundBrowse.Size = new System.Drawing.Size(282, 23);
            this.btnCacheSoundBrowse.TabIndex = 16;
            this.btnCacheSoundBrowse.Text = "Browse";
            this.btnCacheSoundBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCacheSoundBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCacheSoundBrowse.UseMnemonic = false;
            this.btnCacheSoundBrowse.UseVisualStyleBackColor = true;
            this.btnCacheSoundBrowse.Click += new System.EventHandler(this.btnCacheSoundBrowse_Click);
            // 
            // btnCacheSoundClear
            // 
            this.btnCacheSoundClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCacheSoundClear.Image = ((System.Drawing.Image)(resources.GetObject("btnCacheSoundClear.Image")));
            this.btnCacheSoundClear.Location = new System.Drawing.Point(132, 81);
            this.btnCacheSoundClear.Name = "btnCacheSoundClear";
            this.btnCacheSoundClear.Size = new System.Drawing.Size(282, 23);
            this.btnCacheSoundClear.TabIndex = 15;
            this.btnCacheSoundClear.Text = "Clear cache";
            this.btnCacheSoundClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCacheSoundClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCacheSoundClear.UseMnemonic = false;
            this.btnCacheSoundClear.UseVisualStyleBackColor = true;
            this.btnCacheSoundClear.Click += new System.EventHandler(this.btnCacheSoundClear_Click);
            // 
            // txtCacheSoundSize
            // 
            this.tableLayoutPanel14.SetColumnSpan(this.txtCacheSoundSize, 2);
            this.txtCacheSoundSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheSoundSize.Location = new System.Drawing.Point(132, 55);
            this.txtCacheSoundSize.Name = "txtCacheSoundSize";
            this.txtCacheSoundSize.ReadOnly = true;
            this.txtCacheSoundSize.Size = new System.Drawing.Size(570, 20);
            this.txtCacheSoundSize.TabIndex = 13;
            this.txtCacheSoundSize.Text = "0";
            this.txtCacheSoundSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCacheSoundSize
            // 
            this.lblCacheSoundSize.AutoEllipsis = true;
            this.lblCacheSoundSize.AutoSize = true;
            this.lblCacheSoundSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheSoundSize.Location = new System.Drawing.Point(3, 52);
            this.lblCacheSoundSize.Name = "lblCacheSoundSize";
            this.lblCacheSoundSize.Size = new System.Drawing.Size(123, 26);
            this.lblCacheSoundSize.TabIndex = 12;
            this.lblCacheSoundSize.Text = "Current disk size in bytes";
            this.lblCacheSoundSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheSoundCount
            // 
            this.lblCacheSoundCount.AutoEllipsis = true;
            this.lblCacheSoundCount.AutoSize = true;
            this.lblCacheSoundCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheSoundCount.Location = new System.Drawing.Point(3, 26);
            this.lblCacheSoundCount.Name = "lblCacheSoundCount";
            this.lblCacheSoundCount.Size = new System.Drawing.Size(123, 26);
            this.lblCacheSoundCount.TabIndex = 10;
            this.lblCacheSoundCount.Text = "Current item count";
            this.lblCacheSoundCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheSoundExpiry
            // 
            this.lblCacheSoundExpiry.AutoEllipsis = true;
            this.lblCacheSoundExpiry.AutoSize = true;
            this.lblCacheSoundExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheSoundExpiry.Location = new System.Drawing.Point(3, 0);
            this.lblCacheSoundExpiry.Name = "lblCacheSoundExpiry";
            this.lblCacheSoundExpiry.Size = new System.Drawing.Size(123, 26);
            this.lblCacheSoundExpiry.TabIndex = 8;
            this.lblCacheSoundExpiry.Text = "Expiration in minutes";
            this.lblCacheSoundExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudCacheSoundExpiry
            // 
            this.tableLayoutPanel14.SetColumnSpan(this.nudCacheSoundExpiry, 2);
            this.nudCacheSoundExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudCacheSoundExpiry.Location = new System.Drawing.Point(132, 3);
            this.nudCacheSoundExpiry.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudCacheSoundExpiry.Name = "nudCacheSoundExpiry";
            this.nudCacheSoundExpiry.Size = new System.Drawing.Size(570, 20);
            this.nudCacheSoundExpiry.TabIndex = 9;
            this.nudCacheSoundExpiry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCacheSoundExpiry.Value = new decimal(new int[] {
            518400,
            0,
            0,
            0});
            // 
            // txtCacheSoundCount
            // 
            this.tableLayoutPanel14.SetColumnSpan(this.txtCacheSoundCount, 2);
            this.txtCacheSoundCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheSoundCount.Location = new System.Drawing.Point(132, 29);
            this.txtCacheSoundCount.Name = "txtCacheSoundCount";
            this.txtCacheSoundCount.ReadOnly = true;
            this.txtCacheSoundCount.Size = new System.Drawing.Size(570, 20);
            this.txtCacheSoundCount.TabIndex = 11;
            this.txtCacheSoundCount.Text = "0";
            this.txtCacheSoundCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel13
            // 
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 140);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(725, 10);
            this.panel13.TabIndex = 25;
            // 
            // grpCacheImage
            // 
            this.grpCacheImage.AutoSize = true;
            this.grpCacheImage.Controls.Add(this.tableLayoutPanel12);
            this.grpCacheImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCacheImage.Location = new System.Drawing.Point(0, 0);
            this.grpCacheImage.Name = "grpCacheImage";
            this.grpCacheImage.Padding = new System.Windows.Forms.Padding(10);
            this.grpCacheImage.Size = new System.Drawing.Size(725, 140);
            this.grpCacheImage.TabIndex = 24;
            this.grpCacheImage.TabStop = false;
            this.grpCacheImage.Text = " Image files ";
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.AutoSize = true;
            this.tableLayoutPanel12.ColumnCount = 3;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.Controls.Add(this.btnCacheImageBrowse, 2, 3);
            this.tableLayoutPanel12.Controls.Add(this.txtCacheImageSize, 1, 2);
            this.tableLayoutPanel12.Controls.Add(this.lblCacheImageSize, 0, 2);
            this.tableLayoutPanel12.Controls.Add(this.lblCacheImageCount, 0, 1);
            this.tableLayoutPanel12.Controls.Add(this.lblCacheImageExpiry, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.nudCacheImageExpiry, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.txtCacheImageCount, 1, 1);
            this.tableLayoutPanel12.Controls.Add(this.btnCacheImageClear, 1, 3);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 4;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.Size = new System.Drawing.Size(705, 107);
            this.tableLayoutPanel12.TabIndex = 0;
            // 
            // btnCacheImageBrowse
            // 
            this.btnCacheImageBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCacheImageBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnCacheImageBrowse.Image")));
            this.btnCacheImageBrowse.Location = new System.Drawing.Point(420, 81);
            this.btnCacheImageBrowse.Name = "btnCacheImageBrowse";
            this.btnCacheImageBrowse.Size = new System.Drawing.Size(282, 23);
            this.btnCacheImageBrowse.TabIndex = 15;
            this.btnCacheImageBrowse.Text = "Browse";
            this.btnCacheImageBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCacheImageBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCacheImageBrowse.UseMnemonic = false;
            this.btnCacheImageBrowse.UseVisualStyleBackColor = true;
            this.btnCacheImageBrowse.Click += new System.EventHandler(this.btnCacheImageBrowse_Click);
            // 
            // txtCacheImageSize
            // 
            this.tableLayoutPanel12.SetColumnSpan(this.txtCacheImageSize, 2);
            this.txtCacheImageSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheImageSize.Location = new System.Drawing.Point(132, 55);
            this.txtCacheImageSize.Name = "txtCacheImageSize";
            this.txtCacheImageSize.ReadOnly = true;
            this.txtCacheImageSize.Size = new System.Drawing.Size(570, 20);
            this.txtCacheImageSize.TabIndex = 13;
            this.txtCacheImageSize.Text = "0";
            this.txtCacheImageSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCacheImageSize
            // 
            this.lblCacheImageSize.AutoEllipsis = true;
            this.lblCacheImageSize.AutoSize = true;
            this.lblCacheImageSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheImageSize.Location = new System.Drawing.Point(3, 52);
            this.lblCacheImageSize.Name = "lblCacheImageSize";
            this.lblCacheImageSize.Size = new System.Drawing.Size(123, 26);
            this.lblCacheImageSize.TabIndex = 12;
            this.lblCacheImageSize.Text = "Current disk size in bytes";
            this.lblCacheImageSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheImageCount
            // 
            this.lblCacheImageCount.AutoEllipsis = true;
            this.lblCacheImageCount.AutoSize = true;
            this.lblCacheImageCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheImageCount.Location = new System.Drawing.Point(3, 26);
            this.lblCacheImageCount.Name = "lblCacheImageCount";
            this.lblCacheImageCount.Size = new System.Drawing.Size(123, 26);
            this.lblCacheImageCount.TabIndex = 10;
            this.lblCacheImageCount.Text = "Current item count";
            this.lblCacheImageCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheImageExpiry
            // 
            this.lblCacheImageExpiry.AutoEllipsis = true;
            this.lblCacheImageExpiry.AutoSize = true;
            this.lblCacheImageExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheImageExpiry.Location = new System.Drawing.Point(3, 0);
            this.lblCacheImageExpiry.Name = "lblCacheImageExpiry";
            this.lblCacheImageExpiry.Size = new System.Drawing.Size(123, 26);
            this.lblCacheImageExpiry.TabIndex = 8;
            this.lblCacheImageExpiry.Text = "Expiration in minutes";
            this.lblCacheImageExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudCacheImageExpiry
            // 
            this.tableLayoutPanel12.SetColumnSpan(this.nudCacheImageExpiry, 2);
            this.nudCacheImageExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudCacheImageExpiry.Location = new System.Drawing.Point(132, 3);
            this.nudCacheImageExpiry.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudCacheImageExpiry.Name = "nudCacheImageExpiry";
            this.nudCacheImageExpiry.Size = new System.Drawing.Size(570, 20);
            this.nudCacheImageExpiry.TabIndex = 9;
            this.nudCacheImageExpiry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCacheImageExpiry.Value = new decimal(new int[] {
            518400,
            0,
            0,
            0});
            // 
            // txtCacheImageCount
            // 
            this.tableLayoutPanel12.SetColumnSpan(this.txtCacheImageCount, 2);
            this.txtCacheImageCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheImageCount.Location = new System.Drawing.Point(132, 29);
            this.txtCacheImageCount.Name = "txtCacheImageCount";
            this.txtCacheImageCount.ReadOnly = true;
            this.txtCacheImageCount.Size = new System.Drawing.Size(570, 20);
            this.txtCacheImageCount.TabIndex = 11;
            this.txtCacheImageCount.Text = "0";
            this.txtCacheImageCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCacheImageClear
            // 
            this.btnCacheImageClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCacheImageClear.Image = ((System.Drawing.Image)(resources.GetObject("btnCacheImageClear.Image")));
            this.btnCacheImageClear.Location = new System.Drawing.Point(132, 81);
            this.btnCacheImageClear.Name = "btnCacheImageClear";
            this.btnCacheImageClear.Size = new System.Drawing.Size(282, 23);
            this.btnCacheImageClear.TabIndex = 14;
            this.btnCacheImageClear.Text = "Clear cache";
            this.btnCacheImageClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCacheImageClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCacheImageClear.UseMnemonic = false;
            this.btnCacheImageClear.UseVisualStyleBackColor = true;
            this.btnCacheImageClear.Click += new System.EventHandler(this.btnCacheImageClear_Click);
            // 
            // tabEndpoint
            // 
            this.tabEndpoint.Controls.Add(this.grpEndpointSettings);
            this.tabEndpoint.Controls.Add(this.panel7);
            this.tabEndpoint.Controls.Add(this.grpEndpointState);
            this.tabEndpoint.Location = new System.Drawing.Point(4, 22);
            this.tabEndpoint.Name = "tabEndpoint";
            this.tabEndpoint.Padding = new System.Windows.Forms.Padding(7);
            this.tabEndpoint.Size = new System.Drawing.Size(756, 570);
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
            this.grpEndpointSettings.Size = new System.Drawing.Size(742, 108);
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
            this.tableLayoutPanel8.Size = new System.Drawing.Size(722, 75);
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
            this.chkEndpointStartup.Size = new System.Drawing.Size(587, 17);
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
            this.txtEndpointPassword.Size = new System.Drawing.Size(587, 20);
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
            this.nudEndpointPort.Location = new System.Drawing.Point(599, 29);
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
            this.panel7.Size = new System.Drawing.Size(742, 10);
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
            this.grpEndpointState.Size = new System.Drawing.Size(742, 63);
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
            this.panel8.Size = new System.Drawing.Size(722, 30);
            this.panel8.TabIndex = 1;
            // 
            // lblEndpointState
            // 
            this.lblEndpointState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEndpointState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEndpointState.Location = new System.Drawing.Point(0, 0);
            this.lblEndpointState.Name = "lblEndpointState";
            this.lblEndpointState.Size = new System.Drawing.Size(562, 30);
            this.lblEndpointState.TabIndex = 2;
            this.lblEndpointState.Text = "Endpoint is not running.";
            this.lblEndpointState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnEndpointStart
            // 
            this.btnEndpointStart.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEndpointStart.Image = ((System.Drawing.Image)(resources.GetObject("btnEndpointStart.Image")));
            this.btnEndpointStart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEndpointStart.Location = new System.Drawing.Point(562, 0);
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
            this.btnEndpointStop.Location = new System.Drawing.Point(642, 0);
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
            this.tabFFXIV.Size = new System.Drawing.Size(756, 570);
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
            this.grpPartyListOrder.Size = new System.Drawing.Size(742, 490);
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
            this.tableLayoutPanel5.Size = new System.Drawing.Size(722, 457);
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
            this.lblFfxivJobOrder.Size = new System.Drawing.Size(85, 571);
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
            this.cbxFfxivJobMethod.Size = new System.Drawing.Size(625, 21);
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
            this.panel1.Size = new System.Drawing.Size(625, 565);
            this.panel1.TabIndex = 8;
            // 
            // lstFfxivJobOrder
            // 
            this.lstFfxivJobOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFfxivJobOrder.FormattingEnabled = true;
            this.lstFfxivJobOrder.IntegralHeight = false;
            this.lstFfxivJobOrder.Location = new System.Drawing.Point(0, 25);
            this.lstFfxivJobOrder.Name = "lstFfxivJobOrder";
            this.lstFfxivJobOrder.Size = new System.Drawing.Size(625, 540);
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
            this.toolStrip1.Size = new System.Drawing.Size(625, 25);
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
            this.panel9.Size = new System.Drawing.Size(742, 10);
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
            this.grpFfxivEventLogging.Size = new System.Drawing.Size(742, 56);
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
            this.tableLayoutPanel9.Size = new System.Drawing.Size(722, 23);
            this.tableLayoutPanel9.TabIndex = 1;
            // 
            // chkFfxivLogNetwork
            // 
            this.chkFfxivLogNetwork.AutoSize = true;
            this.chkFfxivLogNetwork.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFfxivLogNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkFfxivLogNetwork.Location = new System.Drawing.Point(3, 3);
            this.chkFfxivLogNetwork.Name = "chkFfxivLogNetwork";
            this.chkFfxivLogNetwork.Size = new System.Drawing.Size(716, 17);
            this.chkFfxivLogNetwork.TabIndex = 5;
            this.chkFfxivLogNetwork.Text = "Log network events";
            this.chkFfxivLogNetwork.UseVisualStyleBackColor = true;
            // 
            // tabSubstitutions
            // 
            this.tabSubstitutions.Controls.Add(this.dgvSubstitutions);
            this.tabSubstitutions.Controls.Add(this.tlsSubstitutions);
            this.tabSubstitutions.Location = new System.Drawing.Point(4, 22);
            this.tabSubstitutions.Name = "tabSubstitutions";
            this.tabSubstitutions.Padding = new System.Windows.Forms.Padding(7);
            this.tabSubstitutions.Size = new System.Drawing.Size(756, 570);
            this.tabSubstitutions.TabIndex = 6;
            this.tabSubstitutions.Text = "Substitutions";
            this.tabSubstitutions.UseVisualStyleBackColor = true;
            // 
            // dgvSubstitutions
            // 
            this.dgvSubstitutions.AllowUserToAddRows = false;
            this.dgvSubstitutions.AllowUserToDeleteRows = false;
            this.dgvSubstitutions.AllowUserToResizeRows = false;
            this.dgvSubstitutions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubstitutions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvSubstitutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubstitutions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSubstitutions.Location = new System.Drawing.Point(7, 32);
            this.dgvSubstitutions.Name = "dgvSubstitutions";
            this.dgvSubstitutions.RowHeadersVisible = false;
            this.dgvSubstitutions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubstitutions.ShowCellErrors = false;
            this.dgvSubstitutions.ShowEditingIcon = false;
            this.dgvSubstitutions.ShowRowErrors = false;
            this.dgvSubstitutions.Size = new System.Drawing.Size(742, 531);
            this.dgvSubstitutions.TabIndex = 20;
            this.dgvSubstitutions.VirtualMode = true;
            this.dgvSubstitutions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubstitutions_CellDoubleClick);
            this.dgvSubstitutions.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvSubstitutions_CellValueNeeded);
            this.dgvSubstitutions.SelectionChanged += new System.EventHandler(this.dgvSubstitutions_SelectionChanged);
            this.dgvSubstitutions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSubstitutions_KeyDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Search for";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Replace with";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Scope";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tlsSubstitutions
            // 
            this.tlsSubstitutions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsSubstitutions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSubAdd,
            this.btnSubEdit,
            this.btnSubRemove});
            this.tlsSubstitutions.Location = new System.Drawing.Point(7, 7);
            this.tlsSubstitutions.Name = "tlsSubstitutions";
            this.tlsSubstitutions.Size = new System.Drawing.Size(742, 25);
            this.tlsSubstitutions.TabIndex = 19;
            // 
            // btnSubAdd
            // 
            this.btnSubAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnSubAdd.Image")));
            this.btnSubAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSubAdd.Name = "btnSubAdd";
            this.btnSubAdd.Size = new System.Drawing.Size(115, 22);
            this.btnSubAdd.Text = "Add substitution";
            this.btnSubAdd.Click += new System.EventHandler(this.btnSubAdd_Click);
            // 
            // btnSubEdit
            // 
            this.btnSubEdit.Enabled = false;
            this.btnSubEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnSubEdit.Image")));
            this.btnSubEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSubEdit.Name = "btnSubEdit";
            this.btnSubEdit.Size = new System.Drawing.Size(113, 22);
            this.btnSubEdit.Text = "Edit substitution";
            this.btnSubEdit.Click += new System.EventHandler(this.btnSubEdit_Click);
            // 
            // btnSubRemove
            // 
            this.btnSubRemove.Enabled = false;
            this.btnSubRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnSubRemove.Image")));
            this.btnSubRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSubRemove.Name = "btnSubRemove";
            this.btnSubRemove.Size = new System.Drawing.Size(136, 22);
            this.btnSubRemove.Text = "Remove substitution";
            this.btnSubRemove.Click += new System.EventHandler(this.btnSubRemove_Click);
            // 
            // tabConsts
            // 
            this.tabConsts.Controls.Add(this.panel19);
            this.tabConsts.Location = new System.Drawing.Point(4, 22);
            this.tabConsts.Name = "tabConsts";
            this.tabConsts.Padding = new System.Windows.Forms.Padding(7);
            this.tabConsts.Size = new System.Drawing.Size(756, 570);
            this.tabConsts.TabIndex = 8;
            this.tabConsts.Text = "Constants";
            this.tabConsts.UseVisualStyleBackColor = true;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.dgvConstVariables);
            this.panel19.Controls.Add(this.tlsScalar);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel19.Location = new System.Drawing.Point(7, 7);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(742, 556);
            this.panel19.TabIndex = 23;
            // 
            // dgvConstVariables
            // 
            this.dgvConstVariables.AllowUserToAddRows = false;
            this.dgvConstVariables.AllowUserToDeleteRows = false;
            this.dgvConstVariables.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvConstVariables.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConstVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConstVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colScalarName,
            this.colScalarValue});
            this.dgvConstVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConstVariables.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvConstVariables.Location = new System.Drawing.Point(0, 25);
            this.dgvConstVariables.Name = "dgvConstVariables";
            this.dgvConstVariables.RowHeadersVisible = false;
            this.dgvConstVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConstVariables.ShowCellErrors = false;
            this.dgvConstVariables.ShowEditingIcon = false;
            this.dgvConstVariables.ShowRowErrors = false;
            this.dgvConstVariables.Size = new System.Drawing.Size(742, 531);
            this.dgvConstVariables.TabIndex = 21;
            this.dgvConstVariables.VirtualMode = true;
            this.dgvConstVariables.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConstVariables_CellDoubleClick);
            this.dgvConstVariables.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvConstVariables_CellValueNeeded);
            this.dgvConstVariables.SelectionChanged += new System.EventHandler(this.dgvConstVariables_SelectionChanged);
            this.dgvConstVariables.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvConstVariables_KeyDown);
            // 
            // colScalarName
            // 
            this.colScalarName.Frozen = true;
            this.colScalarName.HeaderText = "Name";
            this.colScalarName.Name = "colScalarName";
            this.colScalarName.ReadOnly = true;
            this.colScalarName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colScalarName.Width = 200;
            // 
            // colScalarValue
            // 
            this.colScalarValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colScalarValue.HeaderText = "Value";
            this.colScalarValue.Name = "colScalarValue";
            this.colScalarValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tlsScalar
            // 
            this.tlsScalar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsScalar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConstAdd,
            this.btnConstEdit,
            this.toolStripSeparator2,
            this.btnConstRemove});
            this.tlsScalar.Location = new System.Drawing.Point(0, 0);
            this.tlsScalar.Name = "tlsScalar";
            this.tlsScalar.Size = new System.Drawing.Size(742, 25);
            this.tlsScalar.TabIndex = 20;
            // 
            // btnConstAdd
            // 
            this.btnConstAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnConstAdd.Image")));
            this.btnConstAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConstAdd.Name = "btnConstAdd";
            this.btnConstAdd.Size = new System.Drawing.Size(98, 22);
            this.btnConstAdd.Text = "Add constant";
            this.btnConstAdd.Click += new System.EventHandler(this.btnConstAdd_Click);
            // 
            // btnConstEdit
            // 
            this.btnConstEdit.Enabled = false;
            this.btnConstEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnConstEdit.Image")));
            this.btnConstEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConstEdit.Name = "btnConstEdit";
            this.btnConstEdit.Size = new System.Drawing.Size(96, 22);
            this.btnConstEdit.Text = "Edit constant";
            this.btnConstEdit.Click += new System.EventHandler(this.btnConstEdit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnConstRemove
            // 
            this.btnConstRemove.Enabled = false;
            this.btnConstRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnConstRemove.Image")));
            this.btnConstRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConstRemove.Name = "btnConstRemove";
            this.btnConstRemove.Size = new System.Drawing.Size(119, 22);
            this.btnConstRemove.Text = "Remove constant";
            this.btnConstRemove.ToolTipText = "Remove value";
            this.btnConstRemove.Click += new System.EventHandler(this.btnConstRemove_Click);
            // 
            // tabSecurity
            // 
            this.tabSecurity.Controls.Add(this.groupBox2);
            this.tabSecurity.Location = new System.Drawing.Point(4, 22);
            this.tabSecurity.Name = "tabSecurity";
            this.tabSecurity.Padding = new System.Windows.Forms.Padding(7);
            this.tabSecurity.Size = new System.Drawing.Size(756, 570);
            this.tabSecurity.TabIndex = 7;
            this.tabSecurity.Text = "Security";
            this.tabSecurity.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.dgvApiAccess);
            this.groupBox2.Controls.Add(this.panel18);
            this.groupBox2.Controls.Add(this.btnUnlockSecurity);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(7, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(742, 556);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Scripting API access ";
            // 
            // dgvApiAccess
            // 
            this.dgvApiAccess.AllowUserToAddRows = false;
            this.dgvApiAccess.AllowUserToDeleteRows = false;
            this.dgvApiAccess.AllowUserToResizeColumns = false;
            this.dgvApiAccess.AllowUserToResizeRows = false;
            this.dgvApiAccess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApiAccess.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvApiAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvApiAccess.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvApiAccess.Enabled = false;
            this.dgvApiAccess.Location = new System.Drawing.Point(10, 63);
            this.dgvApiAccess.Name = "dgvApiAccess";
            this.dgvApiAccess.ReadOnly = true;
            this.dgvApiAccess.RowHeadersVisible = false;
            this.dgvApiAccess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApiAccess.ShowCellErrors = false;
            this.dgvApiAccess.ShowEditingIcon = false;
            this.dgvApiAccess.ShowRowErrors = false;
            this.dgvApiAccess.Size = new System.Drawing.Size(722, 483);
            this.dgvApiAccess.TabIndex = 0;
            this.dgvApiAccess.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApiAccess_CellContentClick);
            this.dgvApiAccess.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApiAccess_CellContentDoubleClick);
            this.dgvApiAccess.SelectionChanged += new System.EventHandler(this.dgvApiAccess_SelectionChanged);
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Namespace";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Allow for local triggers";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Allow for remote triggers";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Allow if running as admin";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // panel18
            // 
            this.panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(10, 53);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(722, 10);
            this.panel18.TabIndex = 25;
            // 
            // btnUnlockSecurity
            // 
            this.btnUnlockSecurity.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUnlockSecurity.Image = ((System.Drawing.Image)(resources.GetObject("btnUnlockSecurity.Image")));
            this.btnUnlockSecurity.Location = new System.Drawing.Point(10, 23);
            this.btnUnlockSecurity.Name = "btnUnlockSecurity";
            this.btnUnlockSecurity.Size = new System.Drawing.Size(722, 30);
            this.btnUnlockSecurity.TabIndex = 26;
            this.btnUnlockSecurity.Text = "Unlock security settings for editing";
            this.btnUnlockSecurity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUnlockSecurity.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUnlockSecurity.UseVisualStyleBackColor = true;
            this.btnUnlockSecurity.Click += new System.EventHandler(this.btnUnlockSecurity_Click);
            // 
            // tabMisc
            // 
            this.tabMisc.Controls.Add(this.groupBox1);
            this.tabMisc.Controls.Add(this.panel12);
            this.tabMisc.Controls.Add(this.grpUserInterface);
            this.tabMisc.Controls.Add(this.panel6);
            this.tabMisc.Controls.Add(this.grpFutureProofing);
            this.tabMisc.Controls.Add(this.panel5);
            this.tabMisc.Controls.Add(this.grpDefaultSettings);
            this.tabMisc.Location = new System.Drawing.Point(4, 22);
            this.tabMisc.Name = "tabMisc";
            this.tabMisc.Padding = new System.Windows.Forms.Padding(7);
            this.tabMisc.Size = new System.Drawing.Size(756, 570);
            this.tabMisc.TabIndex = 3;
            this.tabMisc.Text = "Miscellaneous";
            this.tabMisc.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.tableLayoutPanel11);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(7, 332);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(742, 82);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Aura control ";
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
            this.tableLayoutPanel11.Size = new System.Drawing.Size(722, 49);
            this.tableLayoutPanel11.TabIndex = 2;
            // 
            // txtMonitorWindow
            // 
            this.txtMonitorWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMonitorWindow.Location = new System.Drawing.Point(204, 3);
            this.txtMonitorWindow.Name = "txtMonitorWindow";
            this.txtMonitorWindow.Size = new System.Drawing.Size(515, 20);
            this.txtMonitorWindow.TabIndex = 8;
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
            // cbxEnableHwAccel
            // 
            this.cbxEnableHwAccel.AutoSize = true;
            this.cbxEnableHwAccel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel11.SetColumnSpan(this.cbxEnableHwAccel, 2);
            this.cbxEnableHwAccel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxEnableHwAccel.Location = new System.Drawing.Point(3, 29);
            this.cbxEnableHwAccel.Name = "cbxEnableHwAccel";
            this.cbxEnableHwAccel.Size = new System.Drawing.Size(716, 17);
            this.cbxEnableHwAccel.TabIndex = 6;
            this.cbxEnableHwAccel.Text = "Enable aura hardware acceleration";
            this.cbxEnableHwAccel.UseVisualStyleBackColor = true;
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(7, 322);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(742, 10);
            this.panel12.TabIndex = 26;
            // 
            // grpUserInterface
            // 
            this.grpUserInterface.AutoSize = true;
            this.grpUserInterface.Controls.Add(this.tableLayoutPanel10);
            this.grpUserInterface.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpUserInterface.Location = new System.Drawing.Point(7, 148);
            this.grpUserInterface.Name = "grpUserInterface";
            this.grpUserInterface.Padding = new System.Windows.Forms.Padding(10);
            this.grpUserInterface.Size = new System.Drawing.Size(742, 174);
            this.grpUserInterface.TabIndex = 25;
            this.grpUserInterface.TabStop = false;
            this.grpUserInterface.Text = " User interface ";
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.AutoSize = true;
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel10.Controls.Add(this.cbxActionAsync, 0, 2);
            this.tableLayoutPanel10.Controls.Add(this.chkClipboard, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.lblAutosaveInterval, 0, 5);
            this.tableLayoutPanel10.Controls.Add(this.cbxAutosaveConfig, 0, 4);
            this.tableLayoutPanel10.Controls.Add(this.cbxDevMode, 0, 3);
            this.tableLayoutPanel10.Controls.Add(this.cbxTestLive, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.nudAutosaveMinutes, 1, 5);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 6;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.Size = new System.Drawing.Size(722, 141);
            this.tableLayoutPanel10.TabIndex = 2;
            // 
            // chkClipboard
            // 
            this.chkClipboard.AutoSize = true;
            this.chkClipboard.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel10.SetColumnSpan(this.chkClipboard, 2);
            this.chkClipboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkClipboard.Location = new System.Drawing.Point(3, 3);
            this.chkClipboard.Name = "chkClipboard";
            this.chkClipboard.Size = new System.Drawing.Size(716, 17);
            this.chkClipboard.TabIndex = 6;
            this.chkClipboard.Text = "Use operating system clipboard";
            this.chkClipboard.UseVisualStyleBackColor = true;
            // 
            // lblAutosaveInterval
            // 
            this.lblAutosaveInterval.AutoEllipsis = true;
            this.lblAutosaveInterval.AutoSize = true;
            this.lblAutosaveInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAutosaveInterval.Location = new System.Drawing.Point(3, 115);
            this.lblAutosaveInterval.Name = "lblAutosaveInterval";
            this.lblAutosaveInterval.Size = new System.Drawing.Size(616, 26);
            this.lblAutosaveInterval.TabIndex = 9;
            this.lblAutosaveInterval.Text = "Autosaving time interval in minutes";
            this.lblAutosaveInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxAutosaveConfig
            // 
            this.cbxAutosaveConfig.AutoSize = true;
            this.cbxAutosaveConfig.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel10.SetColumnSpan(this.cbxAutosaveConfig, 2);
            this.cbxAutosaveConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxAutosaveConfig.Location = new System.Drawing.Point(3, 95);
            this.cbxAutosaveConfig.Name = "cbxAutosaveConfig";
            this.cbxAutosaveConfig.Size = new System.Drawing.Size(716, 17);
            this.cbxAutosaveConfig.TabIndex = 8;
            this.cbxAutosaveConfig.Text = "Enable configuration auto-save";
            this.cbxAutosaveConfig.UseVisualStyleBackColor = true;
            this.cbxAutosaveConfig.CheckedChanged += new System.EventHandler(this.cbxAutosaveConfig_CheckedChanged);
            // 
            // cbxDevMode
            // 
            this.cbxDevMode.AutoSize = true;
            this.cbxDevMode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel10.SetColumnSpan(this.cbxDevMode, 2);
            this.cbxDevMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxDevMode.Location = new System.Drawing.Point(3, 72);
            this.cbxDevMode.Name = "cbxDevMode";
            this.cbxDevMode.Size = new System.Drawing.Size(716, 17);
            this.cbxDevMode.TabIndex = 7;
            this.cbxDevMode.Text = "Developer mode";
            this.cbxDevMode.UseVisualStyleBackColor = true;
            // 
            // cbxTestLive
            // 
            this.cbxTestLive.AutoSize = true;
            this.cbxTestLive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel10.SetColumnSpan(this.cbxTestLive, 2);
            this.cbxTestLive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxTestLive.Location = new System.Drawing.Point(3, 26);
            this.cbxTestLive.Name = "cbxTestLive";
            this.cbxTestLive.Size = new System.Drawing.Size(716, 17);
            this.cbxTestLive.TabIndex = 6;
            this.cbxTestLive.Text = "Set testing with live values as the default action test method";
            this.cbxTestLive.UseVisualStyleBackColor = true;
            // 
            // nudAutosaveMinutes
            // 
            this.nudAutosaveMinutes.Location = new System.Drawing.Point(625, 118);
            this.nudAutosaveMinutes.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudAutosaveMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAutosaveMinutes.Name = "nudAutosaveMinutes";
            this.nudAutosaveMinutes.Size = new System.Drawing.Size(94, 20);
            this.nudAutosaveMinutes.TabIndex = 10;
            this.nudAutosaveMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAutosaveMinutes.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(7, 138);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(742, 10);
            this.panel6.TabIndex = 24;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(7, 69);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(742, 10);
            this.panel5.TabIndex = 22;
            // 
            // grpDefaultSettings
            // 
            this.grpDefaultSettings.AutoSize = true;
            this.grpDefaultSettings.Controls.Add(this.tableLayoutPanel17);
            this.grpDefaultSettings.Controls.Add(this.tableLayoutPanel6);
            this.grpDefaultSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDefaultSettings.Location = new System.Drawing.Point(7, 7);
            this.grpDefaultSettings.Name = "grpDefaultSettings";
            this.grpDefaultSettings.Padding = new System.Windows.Forms.Padding(10);
            this.grpDefaultSettings.Size = new System.Drawing.Size(742, 62);
            this.grpDefaultSettings.TabIndex = 23;
            this.grpDefaultSettings.TabStop = false;
            this.grpDefaultSettings.Text = " Default settings ";
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.AutoSize = true;
            this.tableLayoutPanel17.ColumnCount = 2;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel17.Controls.Add(this.cbxTriggerTemplate, 0, 0);
            this.tableLayoutPanel17.Controls.Add(this.btnTriggerTemplate, 1, 0);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 2;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel17.Size = new System.Drawing.Size(722, 29);
            this.tableLayoutPanel17.TabIndex = 3;
            // 
            // cbxTriggerTemplate
            // 
            this.cbxTriggerTemplate.AutoSize = true;
            this.cbxTriggerTemplate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxTriggerTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxTriggerTemplate.Location = new System.Drawing.Point(3, 3);
            this.cbxTriggerTemplate.Name = "cbxTriggerTemplate";
            this.cbxTriggerTemplate.Size = new System.Drawing.Size(516, 23);
            this.cbxTriggerTemplate.TabIndex = 6;
            this.cbxTriggerTemplate.Text = "Use template trigger for default values";
            this.cbxTriggerTemplate.UseVisualStyleBackColor = true;
            // 
            // btnTriggerTemplate
            // 
            this.btnTriggerTemplate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTriggerTemplate.Location = new System.Drawing.Point(525, 3);
            this.btnTriggerTemplate.Name = "btnTriggerTemplate";
            this.btnTriggerTemplate.Size = new System.Drawing.Size(194, 23);
            this.btnTriggerTemplate.TabIndex = 7;
            this.btnTriggerTemplate.Text = "Edit template trigger";
            this.btnTriggerTemplate.UseVisualStyleBackColor = true;
            this.btnTriggerTemplate.Click += new System.EventHandler(this.btnTriggerTemplate_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(722, 29);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // fontDialog1
            // 
            this.fontDialog1.AllowScriptChange = false;
            // 
            // cbxActionAsync
            // 
            this.cbxActionAsync.AutoSize = true;
            this.cbxActionAsync.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel10.SetColumnSpan(this.cbxActionAsync, 2);
            this.cbxActionAsync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxActionAsync.Location = new System.Drawing.Point(3, 49);
            this.cbxActionAsync.Name = "cbxActionAsync";
            this.cbxActionAsync.Size = new System.Drawing.Size(716, 17);
            this.cbxActionAsync.TabIndex = 11;
            this.cbxActionAsync.Text = "New actions asynchronous by default";
            this.cbxActionAsync.UseVisualStyleBackColor = true;
            // 
            // ConfigurationForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(600, 600);
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
            this.tabCaching.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.grpCacheFile.ResumeLayout(false);
            this.grpCacheFile.PerformLayout();
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheFileExpiry)).EndInit();
            this.grpCacheRepo.ResumeLayout(false);
            this.grpCacheRepo.PerformLayout();
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheRepoExpiry)).EndInit();
            this.grpCacheJSON.ResumeLayout(false);
            this.grpCacheJSON.PerformLayout();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheJsonExpiry)).EndInit();
            this.grpCacheSound.ResumeLayout(false);
            this.grpCacheSound.PerformLayout();
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheSoundExpiry)).EndInit();
            this.grpCacheImage.ResumeLayout(false);
            this.grpCacheImage.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheImageExpiry)).EndInit();
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
            this.tabSubstitutions.ResumeLayout(false);
            this.tabSubstitutions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubstitutions)).EndInit();
            this.tlsSubstitutions.ResumeLayout(false);
            this.tlsSubstitutions.PerformLayout();
            this.tabConsts.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstVariables)).EndInit();
            this.tlsScalar.ResumeLayout(false);
            this.tlsScalar.PerformLayout();
            this.tabSecurity.ResumeLayout(false);
            this.tabSecurity.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApiAccess)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.nudAutosaveMinutes)).EndInit();
            this.grpDefaultSettings.ResumeLayout(false);
            this.grpDefaultSettings.PerformLayout();
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
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
        private System.Windows.Forms.GroupBox grpDefaultSettings;
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
        private System.Windows.Forms.CheckBox cbxDevMode;
        private System.Windows.Forms.TabPage tabCaching;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.GroupBox grpCacheRepo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.Button btnCacheRepoClear;
        private System.Windows.Forms.TextBox txtCacheRepoSize;
        private System.Windows.Forms.Label lblCacheRepoSize;
        private System.Windows.Forms.Label lblCacheRepoCount;
        private System.Windows.Forms.Label lblCacheRepoExpiry;
        private System.Windows.Forms.NumericUpDown nudCacheRepoExpiry;
        private System.Windows.Forms.TextBox txtCacheRepoCount;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.GroupBox grpCacheJSON;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.Button btnCacheJsonClear;
        private System.Windows.Forms.TextBox txtCacheJsonSize;
        private System.Windows.Forms.Label lblCacheJsonSize;
        private System.Windows.Forms.Label lblCacheJsonCount;
        private System.Windows.Forms.Label lblCacheJsonExpiry;
        private System.Windows.Forms.TextBox txtCacheJsonCount;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.GroupBox grpCacheSound;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.Button btnCacheSoundClear;
        private System.Windows.Forms.TextBox txtCacheSoundSize;
        private System.Windows.Forms.Label lblCacheSoundSize;
        private System.Windows.Forms.Label lblCacheSoundCount;
        private System.Windows.Forms.Label lblCacheSoundExpiry;
        private System.Windows.Forms.NumericUpDown nudCacheSoundExpiry;
        private System.Windows.Forms.TextBox txtCacheSoundCount;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.GroupBox grpCacheImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.TextBox txtCacheImageSize;
        private System.Windows.Forms.Label lblCacheImageSize;
        private System.Windows.Forms.Label lblCacheImageCount;
        private System.Windows.Forms.Label lblCacheImageExpiry;
        private System.Windows.Forms.NumericUpDown nudCacheImageExpiry;
        private System.Windows.Forms.TextBox txtCacheImageCount;
        private System.Windows.Forms.Button btnCacheImageClear;
        private System.Windows.Forms.Button btnCacheRepoBrowse;
        private System.Windows.Forms.Button btnCacheJsonBrowse;
        private System.Windows.Forms.Button btnCacheSoundBrowse;
        private System.Windows.Forms.Button btnCacheImageBrowse;
        private System.Windows.Forms.NumericUpDown nudCacheJsonExpiry;
        private System.Windows.Forms.GroupBox grpCacheFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.Button btnCacheFileBrowse;
        private System.Windows.Forms.Button btnCacheFileClear;
        private System.Windows.Forms.TextBox txtCacheFileSize;
        private System.Windows.Forms.Label lblCacheFileSize;
        private System.Windows.Forms.Label lblCacheFileCount;
        private System.Windows.Forms.Label lblCacheFileExpiry;
        private System.Windows.Forms.NumericUpDown nudCacheFileExpiry;
        private System.Windows.Forms.TextBox txtCacheFileCount;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.TabPage tabSubstitutions;
        private CustomControls.DataGridViewEx dgvSubstitutions;
        private System.Windows.Forms.ToolStrip tlsSubstitutions;
        private System.Windows.Forms.ToolStripButton btnSubAdd;
        private System.Windows.Forms.ToolStripButton btnSubEdit;
        private System.Windows.Forms.ToolStripButton btnSubRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.CheckBox chkLogVariableExpansions;
        private System.Windows.Forms.TabPage tabSecurity;
        private System.Windows.Forms.GroupBox groupBox2;
        private CustomControls.DataGridViewEx dgvApiAccess;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Button btnUnlockSecurity;
        private System.Windows.Forms.ComboBox cbxUpdateMethod;
        private System.Windows.Forms.Label lblUpdateMethod;
        private System.Windows.Forms.Label lblAutosaveInterval;
        private System.Windows.Forms.CheckBox cbxAutosaveConfig;
        private System.Windows.Forms.NumericUpDown nudAutosaveMinutes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.CheckBox cbxTriggerTemplate;
        private System.Windows.Forms.Button btnTriggerTemplate;
        private System.Windows.Forms.TabPage tabConsts;
        private System.Windows.Forms.Panel panel19;
        private CustomControls.DataGridViewEx dgvConstVariables;
        private System.Windows.Forms.ToolStrip tlsScalar;
        private System.Windows.Forms.ToolStripButton btnConstAdd;
        private System.Windows.Forms.ToolStripButton btnConstEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnConstRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScalarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScalarValue;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.CheckBox cbxActionAsync;
    }
}