namespace Triggernometry.Forms
{
    partial class ConfigurationForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm2));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnMisc = new Triggernometry.CustomControls.MenuButton();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tabStartup = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.trvTrigger = new System.Windows.Forms.TreeView();
            this.ctxStartupTrigger = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxClearSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsStartupTrigger = new System.Windows.Forms.ToolStrip();
            this.btnClearSelection = new System.Windows.Forms.ToolStripButton();
            this.lblFolderReminder = new System.Windows.Forms.ToolStripLabel();
            this.capStartupTrigger = new Triggernometry.CustomControls.PrettyCaption();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lblUpdates = new System.Windows.Forms.Label();
            this.lblWarnAdmin = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.chkWarnAdmin = new System.Windows.Forms.CheckBox();
            this.chkUpdates = new System.Windows.Forms.CheckBox();
            this.chkWelcome = new System.Windows.Forms.CheckBox();
            this.capStartupOptions = new Triggernometry.CustomControls.PrettyCaption();
            this.tabUserInterface = new System.Windows.Forms.TabPage();
            this.panel32 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDevMode = new System.Windows.Forms.Label();
            this.lblAutoComplete = new System.Windows.Forms.Label();
            this.lblActionAsync = new System.Windows.Forms.Label();
            this.lblTestIgnoreConditions = new System.Windows.Forms.Label();
            this.lblTestLive = new System.Windows.Forms.Label();
            this.cbxAutoComplete = new System.Windows.Forms.CheckBox();
            this.cbxDevMode = new System.Windows.Forms.CheckBox();
            this.cbxActionAsync = new System.Windows.Forms.CheckBox();
            this.cbxTestIgnoreConditions = new System.Windows.Forms.CheckBox();
            this.cbxTestLive = new System.Windows.Forms.CheckBox();
            this.capBehavior = new Triggernometry.CustomControls.PrettyCaption();
            this.panel31 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lblUiFontDefault = new System.Windows.Forms.Label();
            this.cbxUiFontDefault = new System.Windows.Forms.CheckBox();
            this.lblUiFont = new System.Windows.Forms.Label();
            this.txtUiFontDesc = new System.Windows.Forms.TextBox();
            this.btnUiFont = new System.Windows.Forms.Button();
            this.capAppearance = new Triggernometry.CustomControls.PrettyCaption();
            this.tabAudio = new System.Windows.Forms.TabPage();
            this.panel22 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTtsRepV = new System.Windows.Forms.Label();
            this.trbTtsRepetition = new System.Windows.Forms.TrackBar();
            this.lblTtsRepetition = new System.Windows.Forms.Label();
            this.txtTtsPathArgs = new System.Windows.Forms.TextBox();
            this.lblTtsPathArgs = new System.Windows.Forms.Label();
            this.btnTtsPath = new System.Windows.Forms.Button();
            this.txtTtsPath = new System.Windows.Forms.TextBox();
            this.cbxTtsMethod = new System.Windows.Forms.ComboBox();
            this.lblTtsPath = new System.Windows.Forms.Label();
            this.lblTtsMethod = new System.Windows.Forms.Label();
            this.lblTtsVolP = new System.Windows.Forms.Label();
            this.trbTtsVolume = new System.Windows.Forms.TrackBar();
            this.lblTtsVolume = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.lblExternalTtsWarn = new System.Windows.Forms.Label();
            this.lblActTtsWarn = new System.Windows.Forms.Label();
            this.prettyCaption2 = new Triggernometry.CustomControls.PrettyCaption();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSoundRepV = new System.Windows.Forms.Label();
            this.trbSoundRepetition = new System.Windows.Forms.TrackBar();
            this.lblSoundRepetition = new System.Windows.Forms.Label();
            this.txtSoundPathArgs = new System.Windows.Forms.TextBox();
            this.lblSoundPathArgs = new System.Windows.Forms.Label();
            this.panel30 = new System.Windows.Forms.Panel();
            this.lblExternalSoundWarn = new System.Windows.Forms.Label();
            this.btnSoundPath = new System.Windows.Forms.Button();
            this.lblSoundPath = new System.Windows.Forms.Label();
            this.lblSoundMethod = new System.Windows.Forms.Label();
            this.lblSoundVolP = new System.Windows.Forms.Label();
            this.trbSoundVolume = new System.Windows.Forms.TrackBar();
            this.lblSoundVolume = new System.Windows.Forms.Label();
            this.cbxSoundMethod = new System.Windows.Forms.ComboBox();
            this.txtSoundPath = new System.Windows.Forms.TextBox();
            this.prettyCaption1 = new Triggernometry.CustomControls.PrettyCaption();
            this.tabLogging = new System.Windows.Forms.TabPage();
            this.panel23 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLogNormalEvents = new System.Windows.Forms.Label();
            this.lblLogVariableExpansions = new System.Windows.Forms.Label();
            this.chkLogVariableExpansions = new System.Windows.Forms.CheckBox();
            this.chkLogNormalEvents = new System.Windows.Forms.CheckBox();
            this.lblLoggingLevel = new System.Windows.Forms.Label();
            this.cbxLoggingLevel = new System.Windows.Forms.ComboBox();
            this.capLogging = new Triggernometry.CustomControls.PrettyCaption();
            this.tabShortcuts = new System.Windows.Forms.TabPage();
            this.panel11 = new System.Windows.Forms.Panel();
            this.tableLayoutPanelShortCutExpression = new System.Windows.Forms.TableLayoutPanel();
            this.lblShortcutWrapTextWhenSelected = new System.Windows.Forms.Label();
            this.lblShortcutUseAbbrevInTemplates = new System.Windows.Forms.Label();
            this.lblShortcutEnableTemplates = new System.Windows.Forms.Label();
            this.chkShortcutEnableTemplates = new System.Windows.Forms.CheckBox();
            this.chkShortcutUseAbbrevInTemplates = new System.Windows.Forms.CheckBox();
            this.chkShortcutWrapTextWhenSelected = new System.Windows.Forms.CheckBox();
            this.capExpressions = new Triggernometry.CustomControls.PrettyCaption();
            this.tabCaching = new System.Windows.Forms.TabPage();
            this.panel17 = new System.Windows.Forms.Panel();
            this.tableLayoutPanelDownloads = new System.Windows.Forms.TableLayoutPanel();
            this.btnCacheFileBrowse = new System.Windows.Forms.Button();
            this.btnCacheFileClear = new System.Windows.Forms.Button();
            this.txtCacheFileSize = new System.Windows.Forms.TextBox();
            this.lblCacheFileSize = new System.Windows.Forms.Label();
            this.lblCacheFileCount = new System.Windows.Forms.Label();
            this.lblCacheFileExpiry = new System.Windows.Forms.Label();
            this.nudCacheFileExpiry = new System.Windows.Forms.NumericUpDown();
            this.txtCacheFileCount = new System.Windows.Forms.TextBox();
            this.capDownloads = new Triggernometry.CustomControls.PrettyCaption();
            this.panel15 = new System.Windows.Forms.Panel();
            this.tableLayoutPanelRepo = new System.Windows.Forms.TableLayoutPanel();
            this.btnCacheRepoBrowse = new System.Windows.Forms.Button();
            this.btnCacheRepoClear = new System.Windows.Forms.Button();
            this.txtCacheRepoSize = new System.Windows.Forms.TextBox();
            this.lblCacheRepoSize = new System.Windows.Forms.Label();
            this.lblCacheRepoCount = new System.Windows.Forms.Label();
            this.lblCacheRepoExpiry = new System.Windows.Forms.Label();
            this.nudCacheRepoExpiry = new System.Windows.Forms.NumericUpDown();
            this.txtCacheRepoCount = new System.Windows.Forms.TextBox();
            this.capRepoBackups = new Triggernometry.CustomControls.PrettyCaption();
            this.panel14 = new System.Windows.Forms.Panel();
            this.tableLayoutPanelJason = new System.Windows.Forms.TableLayoutPanel();
            this.nudCacheJsonExpiry = new System.Windows.Forms.NumericUpDown();
            this.btnCacheJsonBrowse = new System.Windows.Forms.Button();
            this.btnCacheJsonClear = new System.Windows.Forms.Button();
            this.txtCacheJsonSize = new System.Windows.Forms.TextBox();
            this.lblCacheJsonSize = new System.Windows.Forms.Label();
            this.lblCacheJsonCount = new System.Windows.Forms.Label();
            this.lblCacheJsonExpiry = new System.Windows.Forms.Label();
            this.txtCacheJsonCount = new System.Windows.Forms.TextBox();
            this.capJason = new Triggernometry.CustomControls.PrettyCaption();
            this.panel13 = new System.Windows.Forms.Panel();
            this.tableLayoutPanelSound = new System.Windows.Forms.TableLayoutPanel();
            this.btnCacheSoundBrowse = new System.Windows.Forms.Button();
            this.btnCacheSoundClear = new System.Windows.Forms.Button();
            this.txtCacheSoundSize = new System.Windows.Forms.TextBox();
            this.lblCacheSoundSize = new System.Windows.Forms.Label();
            this.lblCacheSoundCount = new System.Windows.Forms.Label();
            this.lblCacheSoundExpiry = new System.Windows.Forms.Label();
            this.nudCacheSoundExpiry = new System.Windows.Forms.NumericUpDown();
            this.txtCacheSoundCount = new System.Windows.Forms.TextBox();
            this.capSoundFiles = new Triggernometry.CustomControls.PrettyCaption();
            this.panel16 = new System.Windows.Forms.Panel();
            this.tableLayoutPanelImages = new System.Windows.Forms.TableLayoutPanel();
            this.btnCacheImageBrowse = new System.Windows.Forms.Button();
            this.txtCacheImageSize = new System.Windows.Forms.TextBox();
            this.lblCacheImageSize = new System.Windows.Forms.Label();
            this.lblCacheImageCount = new System.Windows.Forms.Label();
            this.lblCacheImageExpiry = new System.Windows.Forms.Label();
            this.nudCacheImageExpiry = new System.Windows.Forms.NumericUpDown();
            this.txtCacheImageCount = new System.Windows.Forms.TextBox();
            this.btnCacheImageClear = new System.Windows.Forms.Button();
            this.capImageFiles = new Triggernometry.CustomControls.PrettyCaption();
            this.tabUpdates = new System.Windows.Forms.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblExternalUpdateWarn = new System.Windows.Forms.Label();
            this.txtUpdateChannelUri = new System.Windows.Forms.TextBox();
            this.cbxUpdateMethod = new System.Windows.Forms.ComboBox();
            this.lblUpdateChannelUri = new System.Windows.Forms.Label();
            this.lblUpdateMethod = new System.Windows.Forms.Label();
            this.btnUpdateCheck = new System.Windows.Forms.Button();
            this.capUpdateChannel = new Triggernometry.CustomControls.PrettyCaption();
            this.tabEndpoint = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgvEndpointHistory = new Triggernometry.CustomControls.DataGridViewEx();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlsEndpointHistory = new System.Windows.Forms.ToolStrip();
            this.btnEndpointHistUpdate = new System.Windows.Forms.ToolStripButton();
            this.tlsEndpointHistoryRecv = new System.Windows.Forms.ToolStripLabel();
            this.tlsEndpointHistoryCount = new System.Windows.Forms.ToolStripLabel();
            this.prettyCaption3 = new Triggernometry.CustomControls.PrettyCaption();
            this.panel28 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.lblEndpointLog = new System.Windows.Forms.Label();
            this.lblEndpointStartup = new System.Windows.Forms.Label();
            this.chkEndpointStartup = new System.Windows.Forms.CheckBox();
            this.chkEndpointLog = new System.Windows.Forms.CheckBox();
            this.txtEndpoint = new System.Windows.Forms.TextBox();
            this.lblEndpoint = new System.Windows.Forms.Label();
            this.capEndpointSettings = new Triggernometry.CustomControls.PrettyCaption();
            this.panel27 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.btnEndpointStart = new System.Windows.Forms.Button();
            this.btnEndpointStop = new System.Windows.Forms.Button();
            this.txtEndpointStatus = new System.Windows.Forms.TextBox();
            this.capEndpointStatus = new Triggernometry.CustomControls.PrettyCaption();
            this.tabConstants = new System.Windows.Forms.TabPage();
            this.dgvConstVariables = new Triggernometry.CustomControls.DataGridViewEx();
            this.colScalarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScalarValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlsConstant = new System.Windows.Forms.ToolStrip();
            this.btnConstAdd = new System.Windows.Forms.ToolStripButton();
            this.btnConstEdit = new System.Windows.Forms.ToolStripButton();
            this.btnConstRemove = new System.Windows.Forms.ToolStripButton();
            this.tabSubs = new System.Windows.Forms.TabPage();
            this.dgvSubstitutions = new Triggernometry.CustomControls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlsSubstitutions = new System.Windows.Forms.ToolStrip();
            this.btnSubAdd = new System.Windows.Forms.ToolStripButton();
            this.btnSubEdit = new System.Windows.Forms.ToolStripButton();
            this.btnSubRemove = new System.Windows.Forms.ToolStripButton();
            this.tabGameSpecific = new System.Windows.Forms.TabPage();
            this.tbcGames = new System.Windows.Forms.TabControl();
            this.tabFFXIV = new System.Windows.Forms.TabPage();
            this.panel25 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFfxivJobOrder = new System.Windows.Forms.Label();
            this.lblFfxivJobMethod = new System.Windows.Forms.Label();
            this.cbxFfxivJobMethod = new System.Windows.Forms.ComboBox();
            this.panel26 = new System.Windows.Forms.Panel();
            this.lstFfxivJobOrder = new System.Windows.Forms.ListBox();
            this.tlsFfxivPartyOrder = new System.Windows.Forms.ToolStrip();
            this.btnFfxivJobUp = new System.Windows.Forms.ToolStripButton();
            this.btnFfxivJobDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFfxivJobRestore = new System.Windows.Forms.ToolStripButton();
            this.capFfxivPartyOrder = new Triggernometry.CustomControls.PrettyCaption();
            this.panel24 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFfxivLogNetwork = new System.Windows.Forms.Label();
            this.chkFfxivLogNetwork = new System.Windows.Forms.CheckBox();
            this.capFfxivLogging = new Triggernometry.CustomControls.PrettyCaption();
            this.tabSecurity = new System.Windows.Forms.TabPage();
            this.panel19 = new System.Windows.Forms.Panel();
            this.dgvAdditionalFeatures = new Triggernometry.CustomControls.DataGridViewEx();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgvApiAccess = new Triggernometry.CustomControls.DataGridViewEx();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel18 = new System.Windows.Forms.Panel();
            this.btnUnlockSecurity = new System.Windows.Forms.Button();
            this.capScripting = new Triggernometry.CustomControls.PrettyCaption();
            this.tabMiscellaneous = new System.Windows.Forms.TabPage();
            this.panel12 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.lblEnableHwAccel = new System.Windows.Forms.Label();
            this.txtMonitorWindow = new System.Windows.Forms.TextBox();
            this.lblMonitorWindow = new System.Windows.Forms.Label();
            this.cbxEnableHwAccel = new System.Windows.Forms.CheckBox();
            this.capAuraManagement = new Triggernometry.CustomControls.PrettyCaption();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAutosaveConfig = new System.Windows.Forms.Label();
            this.lblAutosaveInterval = new System.Windows.Forms.Label();
            this.cbxAutosaveConfig = new System.Windows.Forms.CheckBox();
            this.nudAutosaveMinutes = new System.Windows.Forms.NumericUpDown();
            this.capAutosaving = new Triggernometry.CustomControls.PrettyCaption();
            this.panel20 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTriggerTemplate = new System.Windows.Forms.Label();
            this.cbxTriggerTemplate = new System.Windows.Forms.CheckBox();
            this.btnTriggerTemplate = new System.Windows.Forms.Button();
            this.capTemplate = new Triggernometry.CustomControls.PrettyCaption();
            this.btnSecurity = new Triggernometry.CustomControls.MenuButton();
            this.btnGameSpecific = new Triggernometry.CustomControls.MenuButton();
            this.btnSubstitutions = new Triggernometry.CustomControls.MenuButton();
            this.btnConstants = new Triggernometry.CustomControls.MenuButton();
            this.btnEndpoint = new Triggernometry.CustomControls.MenuButton();
            this.btnUpdates = new Triggernometry.CustomControls.MenuButton();
            this.btnCaching = new Triggernometry.CustomControls.MenuButton();
            this.btnShortcuts = new Triggernometry.CustomControls.MenuButton();
            this.btnLogging = new Triggernometry.CustomControls.MenuButton();
            this.btnAudio = new Triggernometry.CustomControls.MenuButton();
            this.btnUserInterface = new Triggernometry.CustomControls.MenuButton();
            this.btnStartup = new Triggernometry.CustomControls.MenuButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.pnlMenu.SuspendLayout();
            this.tbcMain.SuspendLayout();
            this.tabStartup.SuspendLayout();
            this.panel9.SuspendLayout();
            this.ctxStartupTrigger.SuspendLayout();
            this.tlsStartupTrigger.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tabUserInterface.SuspendLayout();
            this.panel32.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.panel31.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tabAudio.SuspendLayout();
            this.panel22.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbTtsRepetition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTtsVolume)).BeginInit();
            this.panel21.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbSoundRepetition)).BeginInit();
            this.panel30.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbSoundVolume)).BeginInit();
            this.tabLogging.SuspendLayout();
            this.panel23.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabShortcuts.SuspendLayout();
            this.panel11.SuspendLayout();
            this.tableLayoutPanelShortCutExpression.SuspendLayout();
            this.tabCaching.SuspendLayout();
            this.panel17.SuspendLayout();
            this.tableLayoutPanelDownloads.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheFileExpiry)).BeginInit();
            this.panel15.SuspendLayout();
            this.tableLayoutPanelRepo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheRepoExpiry)).BeginInit();
            this.panel14.SuspendLayout();
            this.tableLayoutPanelJason.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheJsonExpiry)).BeginInit();
            this.panel13.SuspendLayout();
            this.tableLayoutPanelSound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheSoundExpiry)).BeginInit();
            this.panel16.SuspendLayout();
            this.tableLayoutPanelImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheImageExpiry)).BeginInit();
            this.tabUpdates.SuspendLayout();
            this.panel10.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabEndpoint.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEndpointHistory)).BeginInit();
            this.tlsEndpointHistory.SuspendLayout();
            this.panel28.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.panel27.SuspendLayout();
            this.tableLayoutPanel18.SuspendLayout();
            this.tabConstants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstVariables)).BeginInit();
            this.tlsConstant.SuspendLayout();
            this.tabSubs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubstitutions)).BeginInit();
            this.tlsSubstitutions.SuspendLayout();
            this.tabGameSpecific.SuspendLayout();
            this.tbcGames.SuspendLayout();
            this.tabFFXIV.SuspendLayout();
            this.panel25.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel26.SuspendLayout();
            this.tlsFfxivPartyOrder.SuspendLayout();
            this.panel24.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tabSecurity.SuspendLayout();
            this.panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdditionalFeatures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApiAccess)).BeginInit();
            this.tabMiscellaneous.SuspendLayout();
            this.panel12.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutosaveMinutes)).BeginInit();
            this.panel20.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.AutoScroll = true;
            this.pnlMenu.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pnlMenu.Controls.Add(this.btnMisc);
            this.pnlMenu.Controls.Add(this.btnSecurity);
            this.pnlMenu.Controls.Add(this.btnGameSpecific);
            this.pnlMenu.Controls.Add(this.btnSubstitutions);
            this.pnlMenu.Controls.Add(this.btnConstants);
            this.pnlMenu.Controls.Add(this.btnEndpoint);
            this.pnlMenu.Controls.Add(this.btnUpdates);
            this.pnlMenu.Controls.Add(this.btnCaching);
            this.pnlMenu.Controls.Add(this.btnShortcuts);
            this.pnlMenu.Controls.Add(this.btnLogging);
            this.pnlMenu.Controls.Add(this.btnAudio);
            this.pnlMenu.Controls.Add(this.btnUserInterface);
            this.pnlMenu.Controls.Add(this.btnStartup);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(220, 661);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnMisc
            // 
            this.btnMisc.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnMisc.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnMisc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMisc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMisc.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnMisc.IconCharacter = "@";
            this.btnMisc.IconFont = new System.Drawing.Font("Webdings", 18F);
            this.btnMisc.Location = new System.Drawing.Point(0, 480);
            this.btnMisc.Name = "btnMisc";
            this.btnMisc.Size = new System.Drawing.Size(220, 40);
            this.btnMisc.TabControl = this.tbcMain;
            this.btnMisc.TabIndex = 14;
            this.btnMisc.TabNumber = 12;
            this.btnMisc.Text = "Miscellaneous";
            this.btnMisc.UseVisualStyleBackColor = false;
            // 
            // tbcMain
            // 
            this.tbcMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbcMain.Controls.Add(this.tabStartup);
            this.tbcMain.Controls.Add(this.tabUserInterface);
            this.tbcMain.Controls.Add(this.tabAudio);
            this.tbcMain.Controls.Add(this.tabLogging);
            this.tbcMain.Controls.Add(this.tabShortcuts);
            this.tbcMain.Controls.Add(this.tabCaching);
            this.tbcMain.Controls.Add(this.tabUpdates);
            this.tbcMain.Controls.Add(this.tabEndpoint);
            this.tbcMain.Controls.Add(this.tabConstants);
            this.tbcMain.Controls.Add(this.tabSubs);
            this.tbcMain.Controls.Add(this.tabGameSpecific);
            this.tbcMain.Controls.Add(this.tabSecurity);
            this.tbcMain.Controls.Add(this.tabMiscellaneous);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.Location = new System.Drawing.Point(8, 8);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(648, 545);
            this.tbcMain.TabIndex = 2;
            this.tbcMain.TabStop = false;
            // 
            // tabStartup
            // 
            this.tabStartup.AutoScroll = true;
            this.tabStartup.Controls.Add(this.panel9);
            this.tabStartup.Controls.Add(this.capStartupTrigger);
            this.tabStartup.Controls.Add(this.panel6);
            this.tabStartup.Controls.Add(this.capStartupOptions);
            this.tabStartup.Location = new System.Drawing.Point(4, 25);
            this.tabStartup.Name = "tabStartup";
            this.tabStartup.Size = new System.Drawing.Size(640, 516);
            this.tabStartup.TabIndex = 0;
            this.tabStartup.Text = "Startup";
            this.tabStartup.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.trvTrigger);
            this.panel9.Controls.Add(this.tlsStartupTrigger);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 154);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(640, 362);
            this.panel9.TabIndex = 10;
            // 
            // trvTrigger
            // 
            this.trvTrigger.ContextMenuStrip = this.ctxStartupTrigger;
            this.trvTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvTrigger.HideSelection = false;
            this.trvTrigger.Location = new System.Drawing.Point(0, 35);
            this.trvTrigger.MinimumSize = new System.Drawing.Size(4, 50);
            this.trvTrigger.Name = "trvTrigger";
            this.trvTrigger.ShowNodeToolTips = true;
            this.trvTrigger.Size = new System.Drawing.Size(640, 327);
            this.trvTrigger.TabIndex = 2;
            this.trvTrigger.TabStop = false;
            this.trvTrigger.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvTrigger_BeforeCollapse);
            this.trvTrigger.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvTrigger_BeforeExpand);
            this.trvTrigger.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvTrigger_BeforeSelect);
            this.trvTrigger.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTrigger_AfterSelect);
            // 
            // ctxStartupTrigger
            // 
            this.ctxStartupTrigger.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxClearSelection});
            this.ctxStartupTrigger.Name = "contextMenuStrip1";
            this.ctxStartupTrigger.Size = new System.Drawing.Size(152, 26);
            this.ctxStartupTrigger.Opening += new System.ComponentModel.CancelEventHandler(this.ctxStartupTrigger_Opening);
            // 
            // ctxClearSelection
            // 
            this.ctxClearSelection.Image = ((System.Drawing.Image)(resources.GetObject("ctxClearSelection.Image")));
            this.ctxClearSelection.Name = "ctxClearSelection";
            this.ctxClearSelection.Size = new System.Drawing.Size(151, 22);
            this.ctxClearSelection.Text = "Clear selection";
            this.ctxClearSelection.Click += new System.EventHandler(this.clearSelectionToolStripMenuItem_Click);
            // 
            // tlsStartupTrigger
            // 
            this.tlsStartupTrigger.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsStartupTrigger.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClearSelection,
            this.lblFolderReminder});
            this.tlsStartupTrigger.Location = new System.Drawing.Point(0, 0);
            this.tlsStartupTrigger.Name = "tlsStartupTrigger";
            this.tlsStartupTrigger.Padding = new System.Windows.Forms.Padding(2);
            this.tlsStartupTrigger.Size = new System.Drawing.Size(640, 35);
            this.tlsStartupTrigger.TabIndex = 3;
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.Enabled = false;
            this.btnClearSelection.Image = ((System.Drawing.Image)(resources.GetObject("btnClearSelection.Image")));
            this.btnClearSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Padding = new System.Windows.Forms.Padding(4);
            this.btnClearSelection.Size = new System.Drawing.Size(112, 28);
            this.btnClearSelection.Text = "Clear selection";
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // lblFolderReminder
            // 
            this.lblFolderReminder.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblFolderReminder.Image = ((System.Drawing.Image)(resources.GetObject("lblFolderReminder.Image")));
            this.lblFolderReminder.Name = "lblFolderReminder";
            this.lblFolderReminder.Size = new System.Drawing.Size(301, 28);
            this.lblFolderReminder.Text = "Selecting a folder will fire all triggers inside the folder";
            this.lblFolderReminder.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.lblFolderReminder.Visible = false;
            // 
            // capStartupTrigger
            // 
            this.capStartupTrigger.Caption = "Startup trigger/folder";
            this.capStartupTrigger.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capStartupTrigger.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capStartupTrigger.Collapsed = false;
            this.capStartupTrigger.Collapsee = null;
            this.capStartupTrigger.Collapsible = false;
            this.capStartupTrigger.Dock = System.Windows.Forms.DockStyle.Top;
            this.capStartupTrigger.Location = new System.Drawing.Point(0, 124);
            this.capStartupTrigger.Name = "capStartupTrigger";
            this.capStartupTrigger.Size = new System.Drawing.Size(640, 30);
            this.capStartupTrigger.TabIndex = 9;
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.Controls.Add(this.tableLayoutPanel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 30);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.panel6.Size = new System.Drawing.Size(640, 94);
            this.panel6.TabIndex = 8;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.lblUpdates, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.lblWarnAdmin, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.lblWelcome, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.chkWarnAdmin, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.chkUpdates, 1, 2);
            this.tableLayoutPanel7.Controls.Add(this.chkWelcome, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(640, 78);
            this.tableLayoutPanel7.TabIndex = 8;
            // 
            // lblUpdates
            // 
            this.lblUpdates.AutoEllipsis = true;
            this.lblUpdates.AutoSize = true;
            this.lblUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpdates.Location = new System.Drawing.Point(3, 52);
            this.lblUpdates.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblUpdates.Name = "lblUpdates";
            this.lblUpdates.Size = new System.Drawing.Size(174, 26);
            this.lblUpdates.TabIndex = 15;
            this.lblUpdates.Text = "Check for updates";
            this.lblUpdates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWarnAdmin
            // 
            this.lblWarnAdmin.AutoEllipsis = true;
            this.lblWarnAdmin.AutoSize = true;
            this.lblWarnAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWarnAdmin.Location = new System.Drawing.Point(3, 26);
            this.lblWarnAdmin.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblWarnAdmin.Name = "lblWarnAdmin";
            this.lblWarnAdmin.Size = new System.Drawing.Size(174, 26);
            this.lblWarnAdmin.TabIndex = 14;
            this.lblWarnAdmin.Text = "Warn if not running as Administrator";
            this.lblWarnAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoEllipsis = true;
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWelcome.Location = new System.Drawing.Point(3, 0);
            this.lblWelcome.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(174, 26);
            this.lblWelcome.TabIndex = 13;
            this.lblWelcome.Text = "Show Welcome Screen";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkWarnAdmin
            // 
            this.chkWarnAdmin.AutoSize = true;
            this.chkWarnAdmin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkWarnAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkWarnAdmin.Location = new System.Drawing.Point(183, 29);
            this.chkWarnAdmin.Name = "chkWarnAdmin";
            this.chkWarnAdmin.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chkWarnAdmin.Size = new System.Drawing.Size(454, 20);
            this.chkWarnAdmin.TabIndex = 2;
            this.chkWarnAdmin.TabStop = false;
            this.chkWarnAdmin.UseVisualStyleBackColor = true;
            // 
            // chkUpdates
            // 
            this.chkUpdates.AutoSize = true;
            this.chkUpdates.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkUpdates.Location = new System.Drawing.Point(183, 55);
            this.chkUpdates.Name = "chkUpdates";
            this.chkUpdates.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chkUpdates.Size = new System.Drawing.Size(454, 20);
            this.chkUpdates.TabIndex = 3;
            this.chkUpdates.TabStop = false;
            this.chkUpdates.UseVisualStyleBackColor = true;
            // 
            // chkWelcome
            // 
            this.chkWelcome.AutoSize = true;
            this.chkWelcome.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkWelcome.Location = new System.Drawing.Point(183, 3);
            this.chkWelcome.Name = "chkWelcome";
            this.chkWelcome.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chkWelcome.Size = new System.Drawing.Size(454, 20);
            this.chkWelcome.TabIndex = 4;
            this.chkWelcome.TabStop = false;
            this.chkWelcome.UseVisualStyleBackColor = true;
            // 
            // capStartupOptions
            // 
            this.capStartupOptions.Caption = "Startup options";
            this.capStartupOptions.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capStartupOptions.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capStartupOptions.Collapsed = false;
            this.capStartupOptions.Collapsee = null;
            this.capStartupOptions.Collapsible = false;
            this.capStartupOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.capStartupOptions.Location = new System.Drawing.Point(0, 0);
            this.capStartupOptions.Name = "capStartupOptions";
            this.capStartupOptions.Size = new System.Drawing.Size(640, 30);
            this.capStartupOptions.TabIndex = 6;
            // 
            // tabUserInterface
            // 
            this.tabUserInterface.Controls.Add(this.panel32);
            this.tabUserInterface.Controls.Add(this.capBehavior);
            this.tabUserInterface.Controls.Add(this.panel31);
            this.tabUserInterface.Controls.Add(this.capAppearance);
            this.tabUserInterface.Location = new System.Drawing.Point(4, 25);
            this.tabUserInterface.Name = "tabUserInterface";
            this.tabUserInterface.Size = new System.Drawing.Size(640, 516);
            this.tabUserInterface.TabIndex = 12;
            this.tabUserInterface.Text = "User interface";
            this.tabUserInterface.UseVisualStyleBackColor = true;
            // 
            // panel32
            // 
            this.panel32.AutoSize = true;
            this.panel32.Controls.Add(this.tableLayoutPanel12);
            this.panel32.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel32.Location = new System.Drawing.Point(0, 131);
            this.panel32.Name = "panel32";
            this.panel32.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panel32.Size = new System.Drawing.Size(640, 138);
            this.panel32.TabIndex = 10;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.AutoSize = true;
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Controls.Add(this.lblDevMode, 0, 4);
            this.tableLayoutPanel12.Controls.Add(this.lblAutoComplete, 0, 3);
            this.tableLayoutPanel12.Controls.Add(this.lblActionAsync, 0, 2);
            this.tableLayoutPanel12.Controls.Add(this.lblTestIgnoreConditions, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.lblTestLive, 0, 1);
            this.tableLayoutPanel12.Controls.Add(this.cbxAutoComplete, 1, 3);
            this.tableLayoutPanel12.Controls.Add(this.cbxDevMode, 1, 4);
            this.tableLayoutPanel12.Controls.Add(this.cbxActionAsync, 1, 2);
            this.tableLayoutPanel12.Controls.Add(this.cbxTestIgnoreConditions, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.cbxTestLive, 1, 1);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 5;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.Size = new System.Drawing.Size(640, 130);
            this.tableLayoutPanel12.TabIndex = 2;
            // 
            // lblDevMode
            // 
            this.lblDevMode.AutoEllipsis = true;
            this.lblDevMode.AutoSize = true;
            this.lblDevMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDevMode.Location = new System.Drawing.Point(3, 104);
            this.lblDevMode.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblDevMode.Name = "lblDevMode";
            this.lblDevMode.Size = new System.Drawing.Size(289, 26);
            this.lblDevMode.TabIndex = 15;
            this.lblDevMode.Text = "Developer mode";
            this.lblDevMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAutoComplete
            // 
            this.lblAutoComplete.AutoEllipsis = true;
            this.lblAutoComplete.AutoSize = true;
            this.lblAutoComplete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAutoComplete.Location = new System.Drawing.Point(3, 78);
            this.lblAutoComplete.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblAutoComplete.Name = "lblAutoComplete";
            this.lblAutoComplete.Size = new System.Drawing.Size(289, 26);
            this.lblAutoComplete.TabIndex = 14;
            this.lblAutoComplete.Text = "Enable autocomplete on text fields";
            this.lblAutoComplete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblActionAsync
            // 
            this.lblActionAsync.AutoEllipsis = true;
            this.lblActionAsync.AutoSize = true;
            this.lblActionAsync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActionAsync.Location = new System.Drawing.Point(3, 52);
            this.lblActionAsync.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblActionAsync.Name = "lblActionAsync";
            this.lblActionAsync.Size = new System.Drawing.Size(289, 26);
            this.lblActionAsync.TabIndex = 13;
            this.lblActionAsync.Text = "New actions asynchronous by default";
            this.lblActionAsync.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTestIgnoreConditions
            // 
            this.lblTestIgnoreConditions.AutoEllipsis = true;
            this.lblTestIgnoreConditions.AutoSize = true;
            this.lblTestIgnoreConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTestIgnoreConditions.Location = new System.Drawing.Point(3, 0);
            this.lblTestIgnoreConditions.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblTestIgnoreConditions.Name = "lblTestIgnoreConditions";
            this.lblTestIgnoreConditions.Size = new System.Drawing.Size(289, 26);
            this.lblTestIgnoreConditions.TabIndex = 12;
            this.lblTestIgnoreConditions.Text = "Ignore conditions as default when testing actions";
            this.lblTestIgnoreConditions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTestLive
            // 
            this.lblTestLive.AutoEllipsis = true;
            this.lblTestLive.AutoSize = true;
            this.lblTestLive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTestLive.Location = new System.Drawing.Point(3, 26);
            this.lblTestLive.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblTestLive.Name = "lblTestLive";
            this.lblTestLive.Size = new System.Drawing.Size(289, 26);
            this.lblTestLive.TabIndex = 11;
            this.lblTestLive.Text = "Set testing with live values as the default action test method";
            this.lblTestLive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxAutoComplete
            // 
            this.cbxAutoComplete.AutoSize = true;
            this.cbxAutoComplete.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxAutoComplete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxAutoComplete.Location = new System.Drawing.Point(298, 81);
            this.cbxAutoComplete.Name = "cbxAutoComplete";
            this.cbxAutoComplete.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cbxAutoComplete.Size = new System.Drawing.Size(339, 20);
            this.cbxAutoComplete.TabIndex = 10;
            this.cbxAutoComplete.TabStop = false;
            this.cbxAutoComplete.UseVisualStyleBackColor = true;
            // 
            // cbxDevMode
            // 
            this.cbxDevMode.AutoSize = true;
            this.cbxDevMode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxDevMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxDevMode.Location = new System.Drawing.Point(298, 107);
            this.cbxDevMode.Name = "cbxDevMode";
            this.cbxDevMode.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cbxDevMode.Size = new System.Drawing.Size(339, 20);
            this.cbxDevMode.TabIndex = 9;
            this.cbxDevMode.TabStop = false;
            this.cbxDevMode.UseVisualStyleBackColor = true;
            // 
            // cbxActionAsync
            // 
            this.cbxActionAsync.AutoSize = true;
            this.cbxActionAsync.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxActionAsync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxActionAsync.Location = new System.Drawing.Point(298, 55);
            this.cbxActionAsync.Name = "cbxActionAsync";
            this.cbxActionAsync.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cbxActionAsync.Size = new System.Drawing.Size(339, 20);
            this.cbxActionAsync.TabIndex = 8;
            this.cbxActionAsync.TabStop = false;
            this.cbxActionAsync.UseVisualStyleBackColor = true;
            // 
            // cbxTestIgnoreConditions
            // 
            this.cbxTestIgnoreConditions.AutoSize = true;
            this.cbxTestIgnoreConditions.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxTestIgnoreConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxTestIgnoreConditions.Location = new System.Drawing.Point(298, 3);
            this.cbxTestIgnoreConditions.Name = "cbxTestIgnoreConditions";
            this.cbxTestIgnoreConditions.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cbxTestIgnoreConditions.Size = new System.Drawing.Size(339, 20);
            this.cbxTestIgnoreConditions.TabIndex = 7;
            this.cbxTestIgnoreConditions.UseVisualStyleBackColor = true;
            // 
            // cbxTestLive
            // 
            this.cbxTestLive.AutoSize = true;
            this.cbxTestLive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxTestLive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxTestLive.Location = new System.Drawing.Point(298, 29);
            this.cbxTestLive.Name = "cbxTestLive";
            this.cbxTestLive.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cbxTestLive.Size = new System.Drawing.Size(339, 20);
            this.cbxTestLive.TabIndex = 6;
            this.cbxTestLive.TabStop = false;
            this.cbxTestLive.UseVisualStyleBackColor = true;
            // 
            // capBehavior
            // 
            this.capBehavior.Caption = "Behavior";
            this.capBehavior.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capBehavior.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capBehavior.Collapsed = false;
            this.capBehavior.Collapsee = null;
            this.capBehavior.Collapsible = false;
            this.capBehavior.Dock = System.Windows.Forms.DockStyle.Top;
            this.capBehavior.Location = new System.Drawing.Point(0, 101);
            this.capBehavior.Name = "capBehavior";
            this.capBehavior.Size = new System.Drawing.Size(640, 30);
            this.capBehavior.TabIndex = 9;
            // 
            // panel31
            // 
            this.panel31.AutoSize = true;
            this.panel31.Controls.Add(this.tableLayoutPanel6);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel31.Location = new System.Drawing.Point(0, 30);
            this.panel31.Name = "panel31";
            this.panel31.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.panel31.Size = new System.Drawing.Size(640, 71);
            this.panel31.TabIndex = 8;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel6.Controls.Add(this.lblUiFontDefault, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.cbxUiFontDefault, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.lblUiFont, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.txtUiFontDesc, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.btnUiFont, 2, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(640, 55);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // lblUiFontDefault
            // 
            this.lblUiFontDefault.AutoEllipsis = true;
            this.lblUiFontDefault.AutoSize = true;
            this.lblUiFontDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUiFontDefault.Location = new System.Drawing.Point(3, 0);
            this.lblUiFontDefault.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblUiFontDefault.Name = "lblUiFontDefault";
            this.lblUiFontDefault.Size = new System.Drawing.Size(150, 26);
            this.lblUiFontDefault.TabIndex = 5;
            this.lblUiFontDefault.Text = "Use default font";
            this.lblUiFontDefault.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxUiFontDefault
            // 
            this.cbxUiFontDefault.AutoSize = true;
            this.cbxUiFontDefault.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel6.SetColumnSpan(this.cbxUiFontDefault, 2);
            this.cbxUiFontDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxUiFontDefault.Location = new System.Drawing.Point(159, 3);
            this.cbxUiFontDefault.Name = "cbxUiFontDefault";
            this.cbxUiFontDefault.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cbxUiFontDefault.Size = new System.Drawing.Size(478, 20);
            this.cbxUiFontDefault.TabIndex = 0;
            this.cbxUiFontDefault.TabStop = false;
            this.cbxUiFontDefault.UseVisualStyleBackColor = true;
            this.cbxUiFontDefault.CheckedChanged += new System.EventHandler(this.cbxUiFontDefault_CheckedChanged);
            // 
            // lblUiFont
            // 
            this.lblUiFont.AutoEllipsis = true;
            this.lblUiFont.AutoSize = true;
            this.lblUiFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUiFont.Location = new System.Drawing.Point(3, 26);
            this.lblUiFont.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblUiFont.Name = "lblUiFont";
            this.lblUiFont.Size = new System.Drawing.Size(150, 29);
            this.lblUiFont.TabIndex = 2;
            this.lblUiFont.Text = "Custom font";
            this.lblUiFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUiFontDesc
            // 
            this.txtUiFontDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtUiFontDesc.Location = new System.Drawing.Point(159, 29);
            this.txtUiFontDesc.Name = "txtUiFontDesc";
            this.txtUiFontDesc.ReadOnly = true;
            this.txtUiFontDesc.Size = new System.Drawing.Size(428, 20);
            this.txtUiFontDesc.TabIndex = 3;
            // 
            // btnUiFont
            // 
            this.btnUiFont.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUiFont.Image = ((System.Drawing.Image)(resources.GetObject("btnUiFont.Image")));
            this.btnUiFont.Location = new System.Drawing.Point(593, 29);
            this.btnUiFont.Name = "btnUiFont";
            this.btnUiFont.Size = new System.Drawing.Size(44, 23);
            this.btnUiFont.TabIndex = 4;
            this.btnUiFont.UseVisualStyleBackColor = true;
            this.btnUiFont.Click += new System.EventHandler(this.btnUiFont_Click);
            // 
            // capAppearance
            // 
            this.capAppearance.Caption = "Appearance";
            this.capAppearance.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capAppearance.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capAppearance.Collapsed = false;
            this.capAppearance.Collapsee = null;
            this.capAppearance.Collapsible = false;
            this.capAppearance.Dock = System.Windows.Forms.DockStyle.Top;
            this.capAppearance.Location = new System.Drawing.Point(0, 0);
            this.capAppearance.Name = "capAppearance";
            this.capAppearance.Size = new System.Drawing.Size(640, 30);
            this.capAppearance.TabIndex = 7;
            // 
            // tabAudio
            // 
            this.tabAudio.AutoScroll = true;
            this.tabAudio.Controls.Add(this.panel22);
            this.tabAudio.Controls.Add(this.prettyCaption2);
            this.tabAudio.Controls.Add(this.panel4);
            this.tabAudio.Controls.Add(this.prettyCaption1);
            this.tabAudio.Location = new System.Drawing.Point(4, 25);
            this.tabAudio.Name = "tabAudio";
            this.tabAudio.Size = new System.Drawing.Size(640, 516);
            this.tabAudio.TabIndex = 1;
            this.tabAudio.Text = "Audio";
            this.tabAudio.UseVisualStyleBackColor = true;
            // 
            // panel22
            // 
            this.panel22.AutoSize = true;
            this.panel22.Controls.Add(this.tableLayoutPanel3);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel22.Location = new System.Drawing.Point(0, 277);
            this.panel22.Name = "panel22";
            this.panel22.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panel22.Size = new System.Drawing.Size(623, 269);
            this.panel22.TabIndex = 12;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.Controls.Add(this.lblTtsRepV, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.trbTtsRepetition, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblTtsRepetition, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtTtsPathArgs, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.lblTtsPathArgs, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.btnTtsPath, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.txtTtsPath, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.cbxTtsMethod, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTtsPath, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.lblTtsMethod, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTtsVolP, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.trbTtsVolume, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblTtsVolume, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel21, 1, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(623, 261);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // lblTtsRepV
            // 
            this.lblTtsRepV.AutoEllipsis = true;
            this.lblTtsRepV.AutoSize = true;
            this.lblTtsRepV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTtsRepV.Location = new System.Drawing.Point(566, 55);
            this.lblTtsRepV.Name = "lblTtsRepV";
            this.lblTtsRepV.Size = new System.Drawing.Size(54, 28);
            this.lblTtsRepV.TabIndex = 33;
            this.lblTtsRepV.Text = "500 ms";
            this.lblTtsRepV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trbTtsRepetition
            // 
            this.trbTtsRepetition.AutoSize = false;
            this.trbTtsRepetition.Dock = System.Windows.Forms.DockStyle.Top;
            this.trbTtsRepetition.LargeChange = 250;
            this.trbTtsRepetition.Location = new System.Drawing.Point(159, 58);
            this.trbTtsRepetition.Maximum = 3000;
            this.trbTtsRepetition.Name = "trbTtsRepetition";
            this.trbTtsRepetition.Size = new System.Drawing.Size(401, 22);
            this.trbTtsRepetition.SmallChange = 100;
            this.trbTtsRepetition.TabIndex = 32;
            this.trbTtsRepetition.TabStop = false;
            this.trbTtsRepetition.TickFrequency = 100;
            this.trbTtsRepetition.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbTtsRepetition.Value = 500;
            this.trbTtsRepetition.Scroll += new System.EventHandler(this.trbTtsRepetition_Scroll);
            this.trbTtsRepetition.ValueChanged += new System.EventHandler(this.trbTtsRepetition_ValueChanged);
            // 
            // lblTtsRepetition
            // 
            this.lblTtsRepetition.AutoEllipsis = true;
            this.lblTtsRepetition.AutoSize = true;
            this.lblTtsRepetition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTtsRepetition.Location = new System.Drawing.Point(3, 55);
            this.lblTtsRepetition.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblTtsRepetition.Name = "lblTtsRepetition";
            this.lblTtsRepetition.Size = new System.Drawing.Size(150, 28);
            this.lblTtsRepetition.TabIndex = 31;
            this.lblTtsRepetition.Text = "Repetition cooldown";
            this.lblTtsRepetition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTtsPathArgs
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.txtTtsPathArgs, 2);
            this.txtTtsPathArgs.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTtsPathArgs.Location = new System.Drawing.Point(159, 238);
            this.txtTtsPathArgs.Name = "txtTtsPathArgs";
            this.txtTtsPathArgs.Size = new System.Drawing.Size(461, 20);
            this.txtTtsPathArgs.TabIndex = 29;
            // 
            // lblTtsPathArgs
            // 
            this.lblTtsPathArgs.AutoEllipsis = true;
            this.lblTtsPathArgs.AutoSize = true;
            this.lblTtsPathArgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTtsPathArgs.Location = new System.Drawing.Point(3, 235);
            this.lblTtsPathArgs.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblTtsPathArgs.Name = "lblTtsPathArgs";
            this.lblTtsPathArgs.Size = new System.Drawing.Size(150, 26);
            this.lblTtsPathArgs.TabIndex = 28;
            this.lblTtsPathArgs.Text = "Arguments";
            this.lblTtsPathArgs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTtsPath
            // 
            this.btnTtsPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTtsPath.Image = ((System.Drawing.Image)(resources.GetObject("btnTtsPath.Image")));
            this.btnTtsPath.Location = new System.Drawing.Point(563, 209);
            this.btnTtsPath.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnTtsPath.Name = "btnTtsPath";
            this.btnTtsPath.Size = new System.Drawing.Size(57, 26);
            this.btnTtsPath.TabIndex = 23;
            this.btnTtsPath.TabStop = false;
            this.btnTtsPath.UseVisualStyleBackColor = true;
            // 
            // txtTtsPath
            // 
            this.txtTtsPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTtsPath.Location = new System.Drawing.Point(159, 212);
            this.txtTtsPath.Name = "txtTtsPath";
            this.txtTtsPath.Size = new System.Drawing.Size(401, 20);
            this.txtTtsPath.TabIndex = 22;
            // 
            // cbxTtsMethod
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.cbxTtsMethod, 2);
            this.cbxTtsMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxTtsMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTtsMethod.FormattingEnabled = true;
            this.cbxTtsMethod.Items.AddRange(new object[] {
            "None (disabled)",
            "Windows Speech API",
            "ACT",
            "External application"});
            this.cbxTtsMethod.Location = new System.Drawing.Point(159, 3);
            this.cbxTtsMethod.Name = "cbxTtsMethod";
            this.cbxTtsMethod.Size = new System.Drawing.Size(461, 21);
            this.cbxTtsMethod.TabIndex = 12;
            this.cbxTtsMethod.SelectedIndexChanged += new System.EventHandler(this.cbxTtsMethod_SelectedIndexChanged);
            // 
            // lblTtsPath
            // 
            this.lblTtsPath.AutoEllipsis = true;
            this.lblTtsPath.AutoSize = true;
            this.lblTtsPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTtsPath.Location = new System.Drawing.Point(3, 209);
            this.lblTtsPath.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblTtsPath.Name = "lblTtsPath";
            this.lblTtsPath.Size = new System.Drawing.Size(150, 26);
            this.lblTtsPath.TabIndex = 11;
            this.lblTtsPath.Text = "Application path";
            this.lblTtsPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTtsMethod
            // 
            this.lblTtsMethod.AutoEllipsis = true;
            this.lblTtsMethod.AutoSize = true;
            this.lblTtsMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTtsMethod.Location = new System.Drawing.Point(3, 0);
            this.lblTtsMethod.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblTtsMethod.Name = "lblTtsMethod";
            this.lblTtsMethod.Size = new System.Drawing.Size(150, 27);
            this.lblTtsMethod.TabIndex = 9;
            this.lblTtsMethod.Text = "Playback method";
            this.lblTtsMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTtsVolP
            // 
            this.lblTtsVolP.AutoEllipsis = true;
            this.lblTtsVolP.AutoSize = true;
            this.lblTtsVolP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTtsVolP.Location = new System.Drawing.Point(566, 27);
            this.lblTtsVolP.Name = "lblTtsVolP";
            this.lblTtsVolP.Size = new System.Drawing.Size(54, 28);
            this.lblTtsVolP.TabIndex = 7;
            this.lblTtsVolP.Text = "100 %";
            this.lblTtsVolP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trbTtsVolume
            // 
            this.trbTtsVolume.AutoSize = false;
            this.trbTtsVolume.Dock = System.Windows.Forms.DockStyle.Top;
            this.trbTtsVolume.Location = new System.Drawing.Point(159, 30);
            this.trbTtsVolume.Maximum = 100;
            this.trbTtsVolume.Name = "trbTtsVolume";
            this.trbTtsVolume.Size = new System.Drawing.Size(401, 22);
            this.trbTtsVolume.TabIndex = 6;
            this.trbTtsVolume.TabStop = false;
            this.trbTtsVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbTtsVolume.Value = 100;
            this.trbTtsVolume.Scroll += new System.EventHandler(this.trbTtsVolume_Scroll);
            this.trbTtsVolume.ValueChanged += new System.EventHandler(this.trbTtsVolume_ValueChanged);
            // 
            // lblTtsVolume
            // 
            this.lblTtsVolume.AutoEllipsis = true;
            this.lblTtsVolume.AutoSize = true;
            this.lblTtsVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTtsVolume.Location = new System.Drawing.Point(3, 27);
            this.lblTtsVolume.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblTtsVolume.Name = "lblTtsVolume";
            this.lblTtsVolume.Size = new System.Drawing.Size(150, 28);
            this.lblTtsVolume.TabIndex = 5;
            this.lblTtsVolume.Text = "Volume";
            this.lblTtsVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel21
            // 
            this.panel21.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.panel21, 2);
            this.panel21.Controls.Add(this.lblExternalTtsWarn);
            this.panel21.Controls.Add(this.lblActTtsWarn);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel21.Location = new System.Drawing.Point(159, 86);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(461, 120);
            this.panel21.TabIndex = 30;
            // 
            // lblExternalTtsWarn
            // 
            this.lblExternalTtsWarn.AutoEllipsis = true;
            this.lblExternalTtsWarn.BackColor = System.Drawing.SystemColors.Info;
            this.lblExternalTtsWarn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExternalTtsWarn.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblExternalTtsWarn.Location = new System.Drawing.Point(0, 60);
            this.lblExternalTtsWarn.Name = "lblExternalTtsWarn";
            this.lblExternalTtsWarn.Padding = new System.Windows.Forms.Padding(8);
            this.lblExternalTtsWarn.Size = new System.Drawing.Size(461, 60);
            this.lblExternalTtsWarn.TabIndex = 30;
            this.lblExternalTtsWarn.Text = "This option will make Triggernometry launch an external application. Use this opt" +
    "ion with caution, and only if you understand what you are doing, as this may exp" +
    "ose your system to risk of malware.";
            this.lblExternalTtsWarn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblActTtsWarn
            // 
            this.lblActTtsWarn.AutoEllipsis = true;
            this.lblActTtsWarn.BackColor = System.Drawing.SystemColors.Info;
            this.lblActTtsWarn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblActTtsWarn.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblActTtsWarn.Location = new System.Drawing.Point(0, 0);
            this.lblActTtsWarn.Name = "lblActTtsWarn";
            this.lblActTtsWarn.Padding = new System.Windows.Forms.Padding(8);
            this.lblActTtsWarn.Size = new System.Drawing.Size(461, 60);
            this.lblActTtsWarn.TabIndex = 29;
            this.lblActTtsWarn.Text = "Using ACT for text-to-speech will cause the rate and volume options on text-to-sp" +
    "eech actions to be ignored.";
            this.lblActTtsWarn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prettyCaption2
            // 
            this.prettyCaption2.Caption = "Text-to-speech";
            this.prettyCaption2.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.prettyCaption2.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.prettyCaption2.Collapsed = false;
            this.prettyCaption2.Collapsee = null;
            this.prettyCaption2.Collapsible = false;
            this.prettyCaption2.Dock = System.Windows.Forms.DockStyle.Top;
            this.prettyCaption2.Location = new System.Drawing.Point(0, 247);
            this.prettyCaption2.Name = "prettyCaption2";
            this.prettyCaption2.Size = new System.Drawing.Size(623, 30);
            this.prettyCaption2.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.tableLayoutPanel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 30);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.panel4.Size = new System.Drawing.Size(623, 217);
            this.panel4.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Controls.Add(this.lblSoundRepV, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.trbSoundRepetition, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSoundRepetition, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSoundPathArgs, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblSoundPathArgs, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel30, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSoundPath, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblSoundPath, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblSoundMethod, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSoundVolP, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.trbSoundVolume, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSoundVolume, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxSoundMethod, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSoundPath, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(623, 201);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblSoundRepV
            // 
            this.lblSoundRepV.AutoEllipsis = true;
            this.lblSoundRepV.AutoSize = true;
            this.lblSoundRepV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoundRepV.Location = new System.Drawing.Point(566, 55);
            this.lblSoundRepV.Name = "lblSoundRepV";
            this.lblSoundRepV.Size = new System.Drawing.Size(54, 28);
            this.lblSoundRepV.TabIndex = 31;
            this.lblSoundRepV.Text = "500 ms";
            this.lblSoundRepV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trbSoundRepetition
            // 
            this.trbSoundRepetition.AutoSize = false;
            this.trbSoundRepetition.Dock = System.Windows.Forms.DockStyle.Top;
            this.trbSoundRepetition.LargeChange = 250;
            this.trbSoundRepetition.Location = new System.Drawing.Point(159, 58);
            this.trbSoundRepetition.Maximum = 3000;
            this.trbSoundRepetition.Name = "trbSoundRepetition";
            this.trbSoundRepetition.Size = new System.Drawing.Size(401, 22);
            this.trbSoundRepetition.SmallChange = 100;
            this.trbSoundRepetition.TabIndex = 30;
            this.trbSoundRepetition.TabStop = false;
            this.trbSoundRepetition.TickFrequency = 100;
            this.trbSoundRepetition.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbSoundRepetition.Value = 500;
            this.trbSoundRepetition.Scroll += new System.EventHandler(this.trbSoundRepetition_Scroll);
            this.trbSoundRepetition.ValueChanged += new System.EventHandler(this.trbSoundRepetition_ValueChanged);
            // 
            // lblSoundRepetition
            // 
            this.lblSoundRepetition.AutoEllipsis = true;
            this.lblSoundRepetition.AutoSize = true;
            this.lblSoundRepetition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoundRepetition.Location = new System.Drawing.Point(3, 55);
            this.lblSoundRepetition.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblSoundRepetition.Name = "lblSoundRepetition";
            this.lblSoundRepetition.Size = new System.Drawing.Size(150, 28);
            this.lblSoundRepetition.TabIndex = 29;
            this.lblSoundRepetition.Text = "Repetition cooldown";
            this.lblSoundRepetition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSoundPathArgs
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtSoundPathArgs, 2);
            this.txtSoundPathArgs.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSoundPathArgs.Location = new System.Drawing.Point(159, 178);
            this.txtSoundPathArgs.Name = "txtSoundPathArgs";
            this.txtSoundPathArgs.Size = new System.Drawing.Size(461, 20);
            this.txtSoundPathArgs.TabIndex = 28;
            // 
            // lblSoundPathArgs
            // 
            this.lblSoundPathArgs.AutoEllipsis = true;
            this.lblSoundPathArgs.AutoSize = true;
            this.lblSoundPathArgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoundPathArgs.Location = new System.Drawing.Point(3, 175);
            this.lblSoundPathArgs.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblSoundPathArgs.Name = "lblSoundPathArgs";
            this.lblSoundPathArgs.Size = new System.Drawing.Size(150, 26);
            this.lblSoundPathArgs.TabIndex = 27;
            this.lblSoundPathArgs.Text = "Arguments";
            this.lblSoundPathArgs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel30
            // 
            this.panel30.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.panel30, 2);
            this.panel30.Controls.Add(this.lblExternalSoundWarn);
            this.panel30.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel30.Location = new System.Drawing.Point(159, 86);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(461, 60);
            this.panel30.TabIndex = 26;
            // 
            // lblExternalSoundWarn
            // 
            this.lblExternalSoundWarn.AutoEllipsis = true;
            this.lblExternalSoundWarn.BackColor = System.Drawing.SystemColors.Info;
            this.lblExternalSoundWarn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExternalSoundWarn.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblExternalSoundWarn.Location = new System.Drawing.Point(0, 0);
            this.lblExternalSoundWarn.Name = "lblExternalSoundWarn";
            this.lblExternalSoundWarn.Padding = new System.Windows.Forms.Padding(8);
            this.lblExternalSoundWarn.Size = new System.Drawing.Size(461, 60);
            this.lblExternalSoundWarn.TabIndex = 28;
            this.lblExternalSoundWarn.Text = "This option will make Triggernometry launch an external application. Use this opt" +
    "ion with caution, and only if you understand what you are doing, as this may exp" +
    "ose your system to risk of malware.";
            this.lblExternalSoundWarn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSoundPath
            // 
            this.btnSoundPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSoundPath.Image = ((System.Drawing.Image)(resources.GetObject("btnSoundPath.Image")));
            this.btnSoundPath.Location = new System.Drawing.Point(563, 149);
            this.btnSoundPath.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnSoundPath.Name = "btnSoundPath";
            this.btnSoundPath.Size = new System.Drawing.Size(57, 26);
            this.btnSoundPath.TabIndex = 20;
            this.btnSoundPath.TabStop = false;
            this.btnSoundPath.UseVisualStyleBackColor = true;
            // 
            // lblSoundPath
            // 
            this.lblSoundPath.AutoEllipsis = true;
            this.lblSoundPath.AutoSize = true;
            this.lblSoundPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoundPath.Location = new System.Drawing.Point(3, 149);
            this.lblSoundPath.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblSoundPath.Name = "lblSoundPath";
            this.lblSoundPath.Size = new System.Drawing.Size(150, 26);
            this.lblSoundPath.TabIndex = 10;
            this.lblSoundPath.Text = "Application path";
            this.lblSoundPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSoundMethod
            // 
            this.lblSoundMethod.AutoEllipsis = true;
            this.lblSoundMethod.AutoSize = true;
            this.lblSoundMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoundMethod.Location = new System.Drawing.Point(3, 0);
            this.lblSoundMethod.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblSoundMethod.Name = "lblSoundMethod";
            this.lblSoundMethod.Size = new System.Drawing.Size(150, 27);
            this.lblSoundMethod.TabIndex = 8;
            this.lblSoundMethod.Text = "Playback method";
            this.lblSoundMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSoundVolP
            // 
            this.lblSoundVolP.AutoEllipsis = true;
            this.lblSoundVolP.AutoSize = true;
            this.lblSoundVolP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoundVolP.Location = new System.Drawing.Point(566, 27);
            this.lblSoundVolP.Name = "lblSoundVolP";
            this.lblSoundVolP.Size = new System.Drawing.Size(54, 28);
            this.lblSoundVolP.TabIndex = 7;
            this.lblSoundVolP.Text = "100 %";
            this.lblSoundVolP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trbSoundVolume
            // 
            this.trbSoundVolume.AutoSize = false;
            this.trbSoundVolume.Dock = System.Windows.Forms.DockStyle.Top;
            this.trbSoundVolume.Location = new System.Drawing.Point(159, 30);
            this.trbSoundVolume.Maximum = 100;
            this.trbSoundVolume.Name = "trbSoundVolume";
            this.trbSoundVolume.Size = new System.Drawing.Size(401, 22);
            this.trbSoundVolume.TabIndex = 6;
            this.trbSoundVolume.TabStop = false;
            this.trbSoundVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbSoundVolume.Value = 100;
            this.trbSoundVolume.Scroll += new System.EventHandler(this.trbSoundVolume_Scroll);
            this.trbSoundVolume.ValueChanged += new System.EventHandler(this.trbSoundVolume_ValueChanged);
            // 
            // lblSoundVolume
            // 
            this.lblSoundVolume.AutoEllipsis = true;
            this.lblSoundVolume.AutoSize = true;
            this.lblSoundVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoundVolume.Location = new System.Drawing.Point(3, 27);
            this.lblSoundVolume.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblSoundVolume.Name = "lblSoundVolume";
            this.lblSoundVolume.Size = new System.Drawing.Size(150, 28);
            this.lblSoundVolume.TabIndex = 5;
            this.lblSoundVolume.Text = "Volume";
            this.lblSoundVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxSoundMethod
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbxSoundMethod, 2);
            this.cbxSoundMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxSoundMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSoundMethod.FormattingEnabled = true;
            this.cbxSoundMethod.Items.AddRange(new object[] {
            "None (disabled)",
            "Windows Media Player API",
            "ACT",
            "External application"});
            this.cbxSoundMethod.Location = new System.Drawing.Point(159, 3);
            this.cbxSoundMethod.Name = "cbxSoundMethod";
            this.cbxSoundMethod.Size = new System.Drawing.Size(461, 21);
            this.cbxSoundMethod.TabIndex = 9;
            this.cbxSoundMethod.SelectedIndexChanged += new System.EventHandler(this.cbxSoundMethod_SelectedIndexChanged);
            // 
            // txtSoundPath
            // 
            this.txtSoundPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSoundPath.Location = new System.Drawing.Point(159, 152);
            this.txtSoundPath.Name = "txtSoundPath";
            this.txtSoundPath.Size = new System.Drawing.Size(401, 20);
            this.txtSoundPath.TabIndex = 21;
            // 
            // prettyCaption1
            // 
            this.prettyCaption1.Caption = "Sound playback";
            this.prettyCaption1.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.prettyCaption1.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.prettyCaption1.Collapsed = false;
            this.prettyCaption1.Collapsee = null;
            this.prettyCaption1.Collapsible = false;
            this.prettyCaption1.Dock = System.Windows.Forms.DockStyle.Top;
            this.prettyCaption1.Location = new System.Drawing.Point(0, 0);
            this.prettyCaption1.Name = "prettyCaption1";
            this.prettyCaption1.Size = new System.Drawing.Size(623, 30);
            this.prettyCaption1.TabIndex = 9;
            // 
            // tabLogging
            // 
            this.tabLogging.AutoScroll = true;
            this.tabLogging.Controls.Add(this.panel23);
            this.tabLogging.Controls.Add(this.capLogging);
            this.tabLogging.Location = new System.Drawing.Point(4, 25);
            this.tabLogging.Name = "tabLogging";
            this.tabLogging.Size = new System.Drawing.Size(640, 516);
            this.tabLogging.TabIndex = 2;
            this.tabLogging.Text = "Logging";
            this.tabLogging.UseVisualStyleBackColor = true;
            // 
            // panel23
            // 
            this.panel23.AutoSize = true;
            this.panel23.Controls.Add(this.tableLayoutPanel4);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel23.Location = new System.Drawing.Point(0, 30);
            this.panel23.Name = "panel23";
            this.panel23.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panel23.Size = new System.Drawing.Size(640, 87);
            this.panel23.TabIndex = 10;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.lblLogNormalEvents, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblLogVariableExpansions, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.chkLogVariableExpansions, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.chkLogNormalEvents, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblLoggingLevel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cbxLoggingLevel, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(640, 79);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // lblLogNormalEvents
            // 
            this.lblLogNormalEvents.AutoEllipsis = true;
            this.lblLogNormalEvents.AutoSize = true;
            this.lblLogNormalEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogNormalEvents.Location = new System.Drawing.Point(3, 27);
            this.lblLogNormalEvents.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblLogNormalEvents.Name = "lblLogNormalEvents";
            this.lblLogNormalEvents.Size = new System.Drawing.Size(150, 26);
            this.lblLogNormalEvents.TabIndex = 5;
            this.lblLogNormalEvents.Text = "Log normal log lines";
            this.lblLogNormalEvents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLogVariableExpansions
            // 
            this.lblLogVariableExpansions.AutoEllipsis = true;
            this.lblLogVariableExpansions.AutoSize = true;
            this.lblLogVariableExpansions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogVariableExpansions.Location = new System.Drawing.Point(3, 53);
            this.lblLogVariableExpansions.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblLogVariableExpansions.Name = "lblLogVariableExpansions";
            this.lblLogVariableExpansions.Size = new System.Drawing.Size(150, 26);
            this.lblLogVariableExpansions.TabIndex = 4;
            this.lblLogVariableExpansions.Text = "Log variable expansions";
            this.lblLogVariableExpansions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkLogVariableExpansions
            // 
            this.chkLogVariableExpansions.AutoSize = true;
            this.chkLogVariableExpansions.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLogVariableExpansions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLogVariableExpansions.Location = new System.Drawing.Point(159, 56);
            this.chkLogVariableExpansions.Name = "chkLogVariableExpansions";
            this.chkLogVariableExpansions.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chkLogVariableExpansions.Size = new System.Drawing.Size(478, 20);
            this.chkLogVariableExpansions.TabIndex = 0;
            this.chkLogVariableExpansions.TabStop = false;
            this.chkLogVariableExpansions.UseVisualStyleBackColor = true;
            // 
            // chkLogNormalEvents
            // 
            this.chkLogNormalEvents.AutoSize = true;
            this.chkLogNormalEvents.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLogNormalEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLogNormalEvents.Location = new System.Drawing.Point(159, 30);
            this.chkLogNormalEvents.Name = "chkLogNormalEvents";
            this.chkLogNormalEvents.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chkLogNormalEvents.Size = new System.Drawing.Size(478, 20);
            this.chkLogNormalEvents.TabIndex = 1;
            this.chkLogNormalEvents.TabStop = false;
            this.chkLogNormalEvents.UseVisualStyleBackColor = true;
            // 
            // lblLoggingLevel
            // 
            this.lblLoggingLevel.AutoEllipsis = true;
            this.lblLoggingLevel.AutoSize = true;
            this.lblLoggingLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoggingLevel.Location = new System.Drawing.Point(3, 0);
            this.lblLoggingLevel.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblLoggingLevel.Name = "lblLoggingLevel";
            this.lblLoggingLevel.Size = new System.Drawing.Size(150, 27);
            this.lblLoggingLevel.TabIndex = 2;
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
            "Above custom",
            "Above custom 2",
            "All informational messages",
            "Verbose debug"});
            this.cbxLoggingLevel.Location = new System.Drawing.Point(159, 3);
            this.cbxLoggingLevel.Name = "cbxLoggingLevel";
            this.cbxLoggingLevel.Size = new System.Drawing.Size(478, 21);
            this.cbxLoggingLevel.TabIndex = 3;
            this.cbxLoggingLevel.TabStop = false;
            // 
            // capLogging
            // 
            this.capLogging.Caption = "Logging settings";
            this.capLogging.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capLogging.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capLogging.Collapsed = false;
            this.capLogging.Collapsee = null;
            this.capLogging.Collapsible = false;
            this.capLogging.Dock = System.Windows.Forms.DockStyle.Top;
            this.capLogging.Location = new System.Drawing.Point(0, 0);
            this.capLogging.Name = "capLogging";
            this.capLogging.Size = new System.Drawing.Size(640, 30);
            this.capLogging.TabIndex = 9;
            // 
            // tabShortcuts
            // 
            this.tabShortcuts.AutoScroll = true;
            this.tabShortcuts.Controls.Add(this.panel11);
            this.tabShortcuts.Controls.Add(this.capExpressions);
            this.tabShortcuts.Location = new System.Drawing.Point(4, 25);
            this.tabShortcuts.Name = "tabShortcuts";
            this.tabShortcuts.Size = new System.Drawing.Size(640, 516);
            this.tabShortcuts.TabIndex = 3;
            this.tabShortcuts.Text = "Shortcuts";
            this.tabShortcuts.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.AutoSize = true;
            this.panel11.Controls.Add(this.tableLayoutPanelShortCutExpression);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 30);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panel11.Size = new System.Drawing.Size(640, 86);
            this.panel11.TabIndex = 9;
            // 
            // tableLayoutPanelShortCutExpression
            // 
            this.tableLayoutPanelShortCutExpression.AutoSize = true;
            this.tableLayoutPanelShortCutExpression.ColumnCount = 2;
            this.tableLayoutPanelShortCutExpression.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelShortCutExpression.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelShortCutExpression.Controls.Add(this.lblShortcutWrapTextWhenSelected, 0, 2);
            this.tableLayoutPanelShortCutExpression.Controls.Add(this.lblShortcutUseAbbrevInTemplates, 0, 1);
            this.tableLayoutPanelShortCutExpression.Controls.Add(this.lblShortcutEnableTemplates, 0, 0);
            this.tableLayoutPanelShortCutExpression.Controls.Add(this.chkShortcutEnableTemplates, 1, 0);
            this.tableLayoutPanelShortCutExpression.Controls.Add(this.chkShortcutUseAbbrevInTemplates, 1, 1);
            this.tableLayoutPanelShortCutExpression.Controls.Add(this.chkShortcutWrapTextWhenSelected, 1, 2);
            this.tableLayoutPanelShortCutExpression.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelShortCutExpression.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanelShortCutExpression.Name = "tableLayoutPanelShortCutExpression";
            this.tableLayoutPanelShortCutExpression.RowCount = 3;
            this.tableLayoutPanelShortCutExpression.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelShortCutExpression.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelShortCutExpression.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelShortCutExpression.Size = new System.Drawing.Size(640, 78);
            this.tableLayoutPanelShortCutExpression.TabIndex = 1;
            // 
            // lblShortcutWrapTextWhenSelected
            // 
            this.lblShortcutWrapTextWhenSelected.AutoEllipsis = true;
            this.lblShortcutWrapTextWhenSelected.AutoSize = true;
            this.lblShortcutWrapTextWhenSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShortcutWrapTextWhenSelected.Location = new System.Drawing.Point(3, 52);
            this.lblShortcutWrapTextWhenSelected.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblShortcutWrapTextWhenSelected.Name = "lblShortcutWrapTextWhenSelected";
            this.lblShortcutWrapTextWhenSelected.Size = new System.Drawing.Size(257, 26);
            this.lblShortcutWrapTextWhenSelected.TabIndex = 5;
            this.lblShortcutWrapTextWhenSelected.Text = "Wrap selected text in template expressions";
            this.lblShortcutWrapTextWhenSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShortcutUseAbbrevInTemplates
            // 
            this.lblShortcutUseAbbrevInTemplates.AutoEllipsis = true;
            this.lblShortcutUseAbbrevInTemplates.AutoSize = true;
            this.lblShortcutUseAbbrevInTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShortcutUseAbbrevInTemplates.Location = new System.Drawing.Point(3, 26);
            this.lblShortcutUseAbbrevInTemplates.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblShortcutUseAbbrevInTemplates.Name = "lblShortcutUseAbbrevInTemplates";
            this.lblShortcutUseAbbrevInTemplates.Size = new System.Drawing.Size(257, 26);
            this.lblShortcutUseAbbrevInTemplates.TabIndex = 4;
            this.lblShortcutUseAbbrevInTemplates.Text = "Use abbreviation expressions in template expressions";
            this.lblShortcutUseAbbrevInTemplates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShortcutEnableTemplates
            // 
            this.lblShortcutEnableTemplates.AutoEllipsis = true;
            this.lblShortcutEnableTemplates.AutoSize = true;
            this.lblShortcutEnableTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShortcutEnableTemplates.Location = new System.Drawing.Point(3, 0);
            this.lblShortcutEnableTemplates.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblShortcutEnableTemplates.Name = "lblShortcutEnableTemplates";
            this.lblShortcutEnableTemplates.Size = new System.Drawing.Size(257, 26);
            this.lblShortcutEnableTemplates.TabIndex = 3;
            this.lblShortcutEnableTemplates.Text = "Enable shortcuts to input template expressions";
            this.lblShortcutEnableTemplates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkShortcutEnableTemplates
            // 
            this.chkShortcutEnableTemplates.AutoSize = true;
            this.chkShortcutEnableTemplates.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShortcutEnableTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShortcutEnableTemplates.Location = new System.Drawing.Point(266, 3);
            this.chkShortcutEnableTemplates.Name = "chkShortcutEnableTemplates";
            this.chkShortcutEnableTemplates.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chkShortcutEnableTemplates.Size = new System.Drawing.Size(371, 20);
            this.chkShortcutEnableTemplates.TabIndex = 0;
            this.chkShortcutEnableTemplates.TabStop = false;
            this.chkShortcutEnableTemplates.UseVisualStyleBackColor = true;
            // 
            // chkShortcutUseAbbrevInTemplates
            // 
            this.chkShortcutUseAbbrevInTemplates.AutoSize = true;
            this.chkShortcutUseAbbrevInTemplates.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShortcutUseAbbrevInTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShortcutUseAbbrevInTemplates.Location = new System.Drawing.Point(266, 29);
            this.chkShortcutUseAbbrevInTemplates.Name = "chkShortcutUseAbbrevInTemplates";
            this.chkShortcutUseAbbrevInTemplates.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chkShortcutUseAbbrevInTemplates.Size = new System.Drawing.Size(371, 20);
            this.chkShortcutUseAbbrevInTemplates.TabIndex = 1;
            this.chkShortcutUseAbbrevInTemplates.TabStop = false;
            this.chkShortcutUseAbbrevInTemplates.UseVisualStyleBackColor = true;
            // 
            // chkShortcutWrapTextWhenSelected
            // 
            this.chkShortcutWrapTextWhenSelected.AutoSize = true;
            this.chkShortcutWrapTextWhenSelected.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShortcutWrapTextWhenSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShortcutWrapTextWhenSelected.Location = new System.Drawing.Point(266, 55);
            this.chkShortcutWrapTextWhenSelected.Name = "chkShortcutWrapTextWhenSelected";
            this.chkShortcutWrapTextWhenSelected.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chkShortcutWrapTextWhenSelected.Size = new System.Drawing.Size(371, 20);
            this.chkShortcutWrapTextWhenSelected.TabIndex = 2;
            this.chkShortcutWrapTextWhenSelected.TabStop = false;
            this.chkShortcutWrapTextWhenSelected.UseVisualStyleBackColor = true;
            // 
            // capExpressions
            // 
            this.capExpressions.Caption = "Expressions";
            this.capExpressions.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capExpressions.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capExpressions.Collapsed = false;
            this.capExpressions.Collapsee = null;
            this.capExpressions.Collapsible = false;
            this.capExpressions.Dock = System.Windows.Forms.DockStyle.Top;
            this.capExpressions.Location = new System.Drawing.Point(0, 0);
            this.capExpressions.Name = "capExpressions";
            this.capExpressions.Size = new System.Drawing.Size(640, 30);
            this.capExpressions.TabIndex = 8;
            // 
            // tabCaching
            // 
            this.tabCaching.AutoScroll = true;
            this.tabCaching.Controls.Add(this.panel17);
            this.tabCaching.Controls.Add(this.capDownloads);
            this.tabCaching.Controls.Add(this.panel15);
            this.tabCaching.Controls.Add(this.capRepoBackups);
            this.tabCaching.Controls.Add(this.panel14);
            this.tabCaching.Controls.Add(this.capJason);
            this.tabCaching.Controls.Add(this.panel13);
            this.tabCaching.Controls.Add(this.capSoundFiles);
            this.tabCaching.Controls.Add(this.panel16);
            this.tabCaching.Controls.Add(this.capImageFiles);
            this.tabCaching.Location = new System.Drawing.Point(4, 25);
            this.tabCaching.Name = "tabCaching";
            this.tabCaching.Size = new System.Drawing.Size(640, 516);
            this.tabCaching.TabIndex = 4;
            this.tabCaching.Text = "Caching";
            this.tabCaching.UseVisualStyleBackColor = true;
            // 
            // panel17
            // 
            this.panel17.AutoSize = true;
            this.panel17.Controls.Add(this.tableLayoutPanelDownloads);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(0, 670);
            this.panel17.Name = "panel17";
            this.panel17.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panel17.Size = new System.Drawing.Size(623, 122);
            this.panel17.TabIndex = 27;
            // 
            // tableLayoutPanelDownloads
            // 
            this.tableLayoutPanelDownloads.AutoSize = true;
            this.tableLayoutPanelDownloads.ColumnCount = 3;
            this.tableLayoutPanelDownloads.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelDownloads.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDownloads.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDownloads.Controls.Add(this.btnCacheFileBrowse, 2, 3);
            this.tableLayoutPanelDownloads.Controls.Add(this.btnCacheFileClear, 1, 3);
            this.tableLayoutPanelDownloads.Controls.Add(this.txtCacheFileSize, 1, 2);
            this.tableLayoutPanelDownloads.Controls.Add(this.lblCacheFileSize, 0, 2);
            this.tableLayoutPanelDownloads.Controls.Add(this.lblCacheFileCount, 0, 1);
            this.tableLayoutPanelDownloads.Controls.Add(this.lblCacheFileExpiry, 0, 0);
            this.tableLayoutPanelDownloads.Controls.Add(this.nudCacheFileExpiry, 1, 0);
            this.tableLayoutPanelDownloads.Controls.Add(this.txtCacheFileCount, 1, 1);
            this.tableLayoutPanelDownloads.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelDownloads.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanelDownloads.Name = "tableLayoutPanelDownloads";
            this.tableLayoutPanelDownloads.RowCount = 4;
            this.tableLayoutPanelDownloads.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDownloads.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDownloads.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDownloads.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDownloads.Size = new System.Drawing.Size(623, 114);
            this.tableLayoutPanelDownloads.TabIndex = 1;
            // 
            // btnCacheFileBrowse
            // 
            this.btnCacheFileBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCacheFileBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnCacheFileBrowse.Image")));
            this.btnCacheFileBrowse.Location = new System.Drawing.Point(392, 81);
            this.btnCacheFileBrowse.Name = "btnCacheFileBrowse";
            this.btnCacheFileBrowse.Size = new System.Drawing.Size(228, 30);
            this.btnCacheFileBrowse.TabIndex = 0;
            this.btnCacheFileBrowse.TabStop = false;
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
            this.btnCacheFileClear.Location = new System.Drawing.Point(159, 81);
            this.btnCacheFileClear.Name = "btnCacheFileClear";
            this.btnCacheFileClear.Size = new System.Drawing.Size(227, 30);
            this.btnCacheFileClear.TabIndex = 1;
            this.btnCacheFileClear.TabStop = false;
            this.btnCacheFileClear.Text = "Clear cache";
            this.btnCacheFileClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCacheFileClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCacheFileClear.UseMnemonic = false;
            this.btnCacheFileClear.UseVisualStyleBackColor = true;
            this.btnCacheFileClear.Click += new System.EventHandler(this.btnCacheFileClear_Click);
            // 
            // txtCacheFileSize
            // 
            this.tableLayoutPanelDownloads.SetColumnSpan(this.txtCacheFileSize, 2);
            this.txtCacheFileSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheFileSize.Location = new System.Drawing.Point(159, 55);
            this.txtCacheFileSize.Name = "txtCacheFileSize";
            this.txtCacheFileSize.ReadOnly = true;
            this.txtCacheFileSize.Size = new System.Drawing.Size(461, 20);
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
            this.lblCacheFileSize.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblCacheFileSize.Name = "lblCacheFileSize";
            this.lblCacheFileSize.Size = new System.Drawing.Size(150, 26);
            this.lblCacheFileSize.TabIndex = 14;
            this.lblCacheFileSize.Text = "Current disk size in bytes";
            this.lblCacheFileSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheFileCount
            // 
            this.lblCacheFileCount.AutoEllipsis = true;
            this.lblCacheFileCount.AutoSize = true;
            this.lblCacheFileCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheFileCount.Location = new System.Drawing.Point(3, 26);
            this.lblCacheFileCount.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblCacheFileCount.Name = "lblCacheFileCount";
            this.lblCacheFileCount.Size = new System.Drawing.Size(150, 26);
            this.lblCacheFileCount.TabIndex = 15;
            this.lblCacheFileCount.Text = "Current item count";
            this.lblCacheFileCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheFileExpiry
            // 
            this.lblCacheFileExpiry.AutoEllipsis = true;
            this.lblCacheFileExpiry.AutoSize = true;
            this.lblCacheFileExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheFileExpiry.Location = new System.Drawing.Point(3, 0);
            this.lblCacheFileExpiry.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblCacheFileExpiry.Name = "lblCacheFileExpiry";
            this.lblCacheFileExpiry.Size = new System.Drawing.Size(150, 26);
            this.lblCacheFileExpiry.TabIndex = 16;
            this.lblCacheFileExpiry.Text = "Expiration in minutes";
            this.lblCacheFileExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudCacheFileExpiry
            // 
            this.tableLayoutPanelDownloads.SetColumnSpan(this.nudCacheFileExpiry, 2);
            this.nudCacheFileExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudCacheFileExpiry.Location = new System.Drawing.Point(159, 3);
            this.nudCacheFileExpiry.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudCacheFileExpiry.Name = "nudCacheFileExpiry";
            this.nudCacheFileExpiry.Size = new System.Drawing.Size(461, 20);
            this.nudCacheFileExpiry.TabIndex = 17;
            this.nudCacheFileExpiry.TabStop = false;
            this.nudCacheFileExpiry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCacheFileExpiry.Value = new decimal(new int[] {
            518400,
            0,
            0,
            0});
            // 
            // txtCacheFileCount
            // 
            this.tableLayoutPanelDownloads.SetColumnSpan(this.txtCacheFileCount, 2);
            this.txtCacheFileCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheFileCount.Location = new System.Drawing.Point(159, 29);
            this.txtCacheFileCount.Name = "txtCacheFileCount";
            this.txtCacheFileCount.ReadOnly = true;
            this.txtCacheFileCount.Size = new System.Drawing.Size(461, 20);
            this.txtCacheFileCount.TabIndex = 11;
            this.txtCacheFileCount.Text = "0";
            this.txtCacheFileCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // capDownloads
            // 
            this.capDownloads.Caption = "File downloads";
            this.capDownloads.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capDownloads.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capDownloads.Collapsed = false;
            this.capDownloads.Collapsee = null;
            this.capDownloads.Collapsible = false;
            this.capDownloads.Dock = System.Windows.Forms.DockStyle.Top;
            this.capDownloads.Location = new System.Drawing.Point(0, 640);
            this.capDownloads.Name = "capDownloads";
            this.capDownloads.Size = new System.Drawing.Size(623, 30);
            this.capDownloads.TabIndex = 26;
            // 
            // panel15
            // 
            this.panel15.AutoSize = true;
            this.panel15.Controls.Add(this.tableLayoutPanelRepo);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 510);
            this.panel15.Name = "panel15";
            this.panel15.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.panel15.Size = new System.Drawing.Size(623, 130);
            this.panel15.TabIndex = 25;
            // 
            // tableLayoutPanelRepo
            // 
            this.tableLayoutPanelRepo.AutoSize = true;
            this.tableLayoutPanelRepo.ColumnCount = 3;
            this.tableLayoutPanelRepo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRepo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelRepo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelRepo.Controls.Add(this.btnCacheRepoBrowse, 2, 3);
            this.tableLayoutPanelRepo.Controls.Add(this.btnCacheRepoClear, 1, 3);
            this.tableLayoutPanelRepo.Controls.Add(this.txtCacheRepoSize, 1, 2);
            this.tableLayoutPanelRepo.Controls.Add(this.lblCacheRepoSize, 0, 2);
            this.tableLayoutPanelRepo.Controls.Add(this.lblCacheRepoCount, 0, 1);
            this.tableLayoutPanelRepo.Controls.Add(this.lblCacheRepoExpiry, 0, 0);
            this.tableLayoutPanelRepo.Controls.Add(this.nudCacheRepoExpiry, 1, 0);
            this.tableLayoutPanelRepo.Controls.Add(this.txtCacheRepoCount, 1, 1);
            this.tableLayoutPanelRepo.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelRepo.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanelRepo.Name = "tableLayoutPanelRepo";
            this.tableLayoutPanelRepo.RowCount = 4;
            this.tableLayoutPanelRepo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRepo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRepo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRepo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRepo.Size = new System.Drawing.Size(623, 114);
            this.tableLayoutPanelRepo.TabIndex = 1;
            // 
            // btnCacheRepoBrowse
            // 
            this.btnCacheRepoBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCacheRepoBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnCacheRepoBrowse.Image")));
            this.btnCacheRepoBrowse.Location = new System.Drawing.Point(392, 81);
            this.btnCacheRepoBrowse.Name = "btnCacheRepoBrowse";
            this.btnCacheRepoBrowse.Size = new System.Drawing.Size(228, 30);
            this.btnCacheRepoBrowse.TabIndex = 0;
            this.btnCacheRepoBrowse.TabStop = false;
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
            this.btnCacheRepoClear.Location = new System.Drawing.Point(159, 81);
            this.btnCacheRepoClear.Name = "btnCacheRepoClear";
            this.btnCacheRepoClear.Size = new System.Drawing.Size(227, 30);
            this.btnCacheRepoClear.TabIndex = 1;
            this.btnCacheRepoClear.TabStop = false;
            this.btnCacheRepoClear.Text = "Clear cache";
            this.btnCacheRepoClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCacheRepoClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCacheRepoClear.UseMnemonic = false;
            this.btnCacheRepoClear.UseVisualStyleBackColor = true;
            this.btnCacheRepoClear.Click += new System.EventHandler(this.btnCacheRepoClear_Click);
            // 
            // txtCacheRepoSize
            // 
            this.tableLayoutPanelRepo.SetColumnSpan(this.txtCacheRepoSize, 2);
            this.txtCacheRepoSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheRepoSize.Location = new System.Drawing.Point(159, 55);
            this.txtCacheRepoSize.Name = "txtCacheRepoSize";
            this.txtCacheRepoSize.ReadOnly = true;
            this.txtCacheRepoSize.Size = new System.Drawing.Size(461, 20);
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
            this.lblCacheRepoSize.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblCacheRepoSize.Name = "lblCacheRepoSize";
            this.lblCacheRepoSize.Size = new System.Drawing.Size(150, 26);
            this.lblCacheRepoSize.TabIndex = 14;
            this.lblCacheRepoSize.Text = "Current disk size in bytes";
            this.lblCacheRepoSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheRepoCount
            // 
            this.lblCacheRepoCount.AutoEllipsis = true;
            this.lblCacheRepoCount.AutoSize = true;
            this.lblCacheRepoCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheRepoCount.Location = new System.Drawing.Point(3, 26);
            this.lblCacheRepoCount.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblCacheRepoCount.Name = "lblCacheRepoCount";
            this.lblCacheRepoCount.Size = new System.Drawing.Size(150, 26);
            this.lblCacheRepoCount.TabIndex = 15;
            this.lblCacheRepoCount.Text = "Current item count";
            this.lblCacheRepoCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheRepoExpiry
            // 
            this.lblCacheRepoExpiry.AutoEllipsis = true;
            this.lblCacheRepoExpiry.AutoSize = true;
            this.lblCacheRepoExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheRepoExpiry.Location = new System.Drawing.Point(3, 0);
            this.lblCacheRepoExpiry.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblCacheRepoExpiry.Name = "lblCacheRepoExpiry";
            this.lblCacheRepoExpiry.Size = new System.Drawing.Size(150, 26);
            this.lblCacheRepoExpiry.TabIndex = 16;
            this.lblCacheRepoExpiry.Text = "Expiration in minutes";
            this.lblCacheRepoExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudCacheRepoExpiry
            // 
            this.tableLayoutPanelRepo.SetColumnSpan(this.nudCacheRepoExpiry, 2);
            this.nudCacheRepoExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudCacheRepoExpiry.Location = new System.Drawing.Point(159, 3);
            this.nudCacheRepoExpiry.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudCacheRepoExpiry.Name = "nudCacheRepoExpiry";
            this.nudCacheRepoExpiry.Size = new System.Drawing.Size(461, 20);
            this.nudCacheRepoExpiry.TabIndex = 17;
            this.nudCacheRepoExpiry.TabStop = false;
            this.nudCacheRepoExpiry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCacheRepoExpiry.Value = new decimal(new int[] {
            518400,
            0,
            0,
            0});
            // 
            // txtCacheRepoCount
            // 
            this.tableLayoutPanelRepo.SetColumnSpan(this.txtCacheRepoCount, 2);
            this.txtCacheRepoCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheRepoCount.Location = new System.Drawing.Point(159, 29);
            this.txtCacheRepoCount.Name = "txtCacheRepoCount";
            this.txtCacheRepoCount.ReadOnly = true;
            this.txtCacheRepoCount.Size = new System.Drawing.Size(461, 20);
            this.txtCacheRepoCount.TabIndex = 11;
            this.txtCacheRepoCount.Text = "0";
            this.txtCacheRepoCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // capRepoBackups
            // 
            this.capRepoBackups.Caption = "Repository backups";
            this.capRepoBackups.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capRepoBackups.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capRepoBackups.Collapsed = false;
            this.capRepoBackups.Collapsee = null;
            this.capRepoBackups.Collapsible = false;
            this.capRepoBackups.Dock = System.Windows.Forms.DockStyle.Top;
            this.capRepoBackups.Location = new System.Drawing.Point(0, 480);
            this.capRepoBackups.Name = "capRepoBackups";
            this.capRepoBackups.Size = new System.Drawing.Size(623, 30);
            this.capRepoBackups.TabIndex = 24;
            // 
            // panel14
            // 
            this.panel14.AutoSize = true;
            this.panel14.Controls.Add(this.tableLayoutPanelJason);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 350);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.panel14.Size = new System.Drawing.Size(623, 130);
            this.panel14.TabIndex = 23;
            // 
            // tableLayoutPanelJason
            // 
            this.tableLayoutPanelJason.AutoSize = true;
            this.tableLayoutPanelJason.ColumnCount = 3;
            this.tableLayoutPanelJason.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelJason.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelJason.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelJason.Controls.Add(this.nudCacheJsonExpiry, 1, 0);
            this.tableLayoutPanelJason.Controls.Add(this.btnCacheJsonBrowse, 2, 3);
            this.tableLayoutPanelJason.Controls.Add(this.btnCacheJsonClear, 1, 3);
            this.tableLayoutPanelJason.Controls.Add(this.txtCacheJsonSize, 1, 2);
            this.tableLayoutPanelJason.Controls.Add(this.lblCacheJsonSize, 0, 2);
            this.tableLayoutPanelJason.Controls.Add(this.lblCacheJsonCount, 0, 1);
            this.tableLayoutPanelJason.Controls.Add(this.lblCacheJsonExpiry, 0, 0);
            this.tableLayoutPanelJason.Controls.Add(this.txtCacheJsonCount, 1, 1);
            this.tableLayoutPanelJason.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelJason.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanelJason.Name = "tableLayoutPanelJason";
            this.tableLayoutPanelJason.RowCount = 4;
            this.tableLayoutPanelJason.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelJason.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelJason.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelJason.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelJason.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelJason.Size = new System.Drawing.Size(623, 114);
            this.tableLayoutPanelJason.TabIndex = 1;
            // 
            // nudCacheJsonExpiry
            // 
            this.tableLayoutPanelJason.SetColumnSpan(this.nudCacheJsonExpiry, 2);
            this.nudCacheJsonExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudCacheJsonExpiry.Location = new System.Drawing.Point(159, 3);
            this.nudCacheJsonExpiry.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudCacheJsonExpiry.Name = "nudCacheJsonExpiry";
            this.nudCacheJsonExpiry.Size = new System.Drawing.Size(461, 20);
            this.nudCacheJsonExpiry.TabIndex = 0;
            this.nudCacheJsonExpiry.TabStop = false;
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
            this.btnCacheJsonBrowse.Location = new System.Drawing.Point(392, 81);
            this.btnCacheJsonBrowse.Name = "btnCacheJsonBrowse";
            this.btnCacheJsonBrowse.Size = new System.Drawing.Size(228, 30);
            this.btnCacheJsonBrowse.TabIndex = 1;
            this.btnCacheJsonBrowse.TabStop = false;
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
            this.btnCacheJsonClear.Location = new System.Drawing.Point(159, 81);
            this.btnCacheJsonClear.Name = "btnCacheJsonClear";
            this.btnCacheJsonClear.Size = new System.Drawing.Size(227, 30);
            this.btnCacheJsonClear.TabIndex = 2;
            this.btnCacheJsonClear.TabStop = false;
            this.btnCacheJsonClear.Text = "Clear cache";
            this.btnCacheJsonClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCacheJsonClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCacheJsonClear.UseMnemonic = false;
            this.btnCacheJsonClear.UseVisualStyleBackColor = true;
            this.btnCacheJsonClear.Click += new System.EventHandler(this.btnCacheJsonClear_Click);
            // 
            // txtCacheJsonSize
            // 
            this.tableLayoutPanelJason.SetColumnSpan(this.txtCacheJsonSize, 2);
            this.txtCacheJsonSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheJsonSize.Location = new System.Drawing.Point(159, 55);
            this.txtCacheJsonSize.Name = "txtCacheJsonSize";
            this.txtCacheJsonSize.ReadOnly = true;
            this.txtCacheJsonSize.Size = new System.Drawing.Size(461, 20);
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
            this.lblCacheJsonSize.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblCacheJsonSize.Name = "lblCacheJsonSize";
            this.lblCacheJsonSize.Size = new System.Drawing.Size(150, 26);
            this.lblCacheJsonSize.TabIndex = 14;
            this.lblCacheJsonSize.Text = "Current disk size in bytes";
            this.lblCacheJsonSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheJsonCount
            // 
            this.lblCacheJsonCount.AutoEllipsis = true;
            this.lblCacheJsonCount.AutoSize = true;
            this.lblCacheJsonCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheJsonCount.Location = new System.Drawing.Point(3, 26);
            this.lblCacheJsonCount.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblCacheJsonCount.Name = "lblCacheJsonCount";
            this.lblCacheJsonCount.Size = new System.Drawing.Size(150, 26);
            this.lblCacheJsonCount.TabIndex = 15;
            this.lblCacheJsonCount.Text = "Current item count";
            this.lblCacheJsonCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheJsonExpiry
            // 
            this.lblCacheJsonExpiry.AutoEllipsis = true;
            this.lblCacheJsonExpiry.AutoSize = true;
            this.lblCacheJsonExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheJsonExpiry.Location = new System.Drawing.Point(3, 0);
            this.lblCacheJsonExpiry.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblCacheJsonExpiry.Name = "lblCacheJsonExpiry";
            this.lblCacheJsonExpiry.Size = new System.Drawing.Size(150, 26);
            this.lblCacheJsonExpiry.TabIndex = 16;
            this.lblCacheJsonExpiry.Text = "Expiration in minutes";
            this.lblCacheJsonExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCacheJsonCount
            // 
            this.tableLayoutPanelJason.SetColumnSpan(this.txtCacheJsonCount, 2);
            this.txtCacheJsonCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheJsonCount.Location = new System.Drawing.Point(159, 29);
            this.txtCacheJsonCount.Name = "txtCacheJsonCount";
            this.txtCacheJsonCount.ReadOnly = true;
            this.txtCacheJsonCount.Size = new System.Drawing.Size(461, 20);
            this.txtCacheJsonCount.TabIndex = 11;
            this.txtCacheJsonCount.Text = "0";
            this.txtCacheJsonCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // capJason
            // 
            this.capJason.Caption = "JSON responses";
            this.capJason.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capJason.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capJason.Collapsed = false;
            this.capJason.Collapsee = null;
            this.capJason.Collapsible = false;
            this.capJason.Dock = System.Windows.Forms.DockStyle.Top;
            this.capJason.Location = new System.Drawing.Point(0, 320);
            this.capJason.Name = "capJason";
            this.capJason.Size = new System.Drawing.Size(623, 30);
            this.capJason.TabIndex = 22;
            // 
            // panel13
            // 
            this.panel13.AutoSize = true;
            this.panel13.Controls.Add(this.tableLayoutPanelSound);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 190);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.panel13.Size = new System.Drawing.Size(623, 130);
            this.panel13.TabIndex = 21;
            // 
            // tableLayoutPanelSound
            // 
            this.tableLayoutPanelSound.AutoSize = true;
            this.tableLayoutPanelSound.ColumnCount = 3;
            this.tableLayoutPanelSound.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelSound.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSound.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSound.Controls.Add(this.btnCacheSoundBrowse, 2, 3);
            this.tableLayoutPanelSound.Controls.Add(this.btnCacheSoundClear, 1, 3);
            this.tableLayoutPanelSound.Controls.Add(this.txtCacheSoundSize, 1, 2);
            this.tableLayoutPanelSound.Controls.Add(this.lblCacheSoundSize, 0, 2);
            this.tableLayoutPanelSound.Controls.Add(this.lblCacheSoundCount, 0, 1);
            this.tableLayoutPanelSound.Controls.Add(this.lblCacheSoundExpiry, 0, 0);
            this.tableLayoutPanelSound.Controls.Add(this.nudCacheSoundExpiry, 1, 0);
            this.tableLayoutPanelSound.Controls.Add(this.txtCacheSoundCount, 1, 1);
            this.tableLayoutPanelSound.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelSound.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanelSound.Name = "tableLayoutPanelSound";
            this.tableLayoutPanelSound.RowCount = 4;
            this.tableLayoutPanelSound.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSound.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSound.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSound.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelSound.Size = new System.Drawing.Size(623, 114);
            this.tableLayoutPanelSound.TabIndex = 1;
            // 
            // btnCacheSoundBrowse
            // 
            this.btnCacheSoundBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCacheSoundBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnCacheSoundBrowse.Image")));
            this.btnCacheSoundBrowse.Location = new System.Drawing.Point(392, 81);
            this.btnCacheSoundBrowse.Name = "btnCacheSoundBrowse";
            this.btnCacheSoundBrowse.Size = new System.Drawing.Size(228, 30);
            this.btnCacheSoundBrowse.TabIndex = 0;
            this.btnCacheSoundBrowse.TabStop = false;
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
            this.btnCacheSoundClear.Location = new System.Drawing.Point(159, 81);
            this.btnCacheSoundClear.Name = "btnCacheSoundClear";
            this.btnCacheSoundClear.Size = new System.Drawing.Size(227, 30);
            this.btnCacheSoundClear.TabIndex = 1;
            this.btnCacheSoundClear.TabStop = false;
            this.btnCacheSoundClear.Text = "Clear cache";
            this.btnCacheSoundClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCacheSoundClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCacheSoundClear.UseMnemonic = false;
            this.btnCacheSoundClear.UseVisualStyleBackColor = true;
            this.btnCacheSoundClear.Click += new System.EventHandler(this.btnCacheSoundClear_Click);
            // 
            // txtCacheSoundSize
            // 
            this.tableLayoutPanelSound.SetColumnSpan(this.txtCacheSoundSize, 2);
            this.txtCacheSoundSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheSoundSize.Location = new System.Drawing.Point(159, 55);
            this.txtCacheSoundSize.Name = "txtCacheSoundSize";
            this.txtCacheSoundSize.ReadOnly = true;
            this.txtCacheSoundSize.Size = new System.Drawing.Size(461, 20);
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
            this.lblCacheSoundSize.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblCacheSoundSize.Name = "lblCacheSoundSize";
            this.lblCacheSoundSize.Size = new System.Drawing.Size(150, 26);
            this.lblCacheSoundSize.TabIndex = 14;
            this.lblCacheSoundSize.Text = "Current disk size in bytes";
            this.lblCacheSoundSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheSoundCount
            // 
            this.lblCacheSoundCount.AutoEllipsis = true;
            this.lblCacheSoundCount.AutoSize = true;
            this.lblCacheSoundCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheSoundCount.Location = new System.Drawing.Point(3, 26);
            this.lblCacheSoundCount.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblCacheSoundCount.Name = "lblCacheSoundCount";
            this.lblCacheSoundCount.Size = new System.Drawing.Size(150, 26);
            this.lblCacheSoundCount.TabIndex = 15;
            this.lblCacheSoundCount.Text = "Current item count";
            this.lblCacheSoundCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheSoundExpiry
            // 
            this.lblCacheSoundExpiry.AutoEllipsis = true;
            this.lblCacheSoundExpiry.AutoSize = true;
            this.lblCacheSoundExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheSoundExpiry.Location = new System.Drawing.Point(3, 0);
            this.lblCacheSoundExpiry.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblCacheSoundExpiry.Name = "lblCacheSoundExpiry";
            this.lblCacheSoundExpiry.Size = new System.Drawing.Size(150, 26);
            this.lblCacheSoundExpiry.TabIndex = 16;
            this.lblCacheSoundExpiry.Text = "Expiration in minutes";
            this.lblCacheSoundExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudCacheSoundExpiry
            // 
            this.tableLayoutPanelSound.SetColumnSpan(this.nudCacheSoundExpiry, 2);
            this.nudCacheSoundExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudCacheSoundExpiry.Location = new System.Drawing.Point(159, 3);
            this.nudCacheSoundExpiry.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudCacheSoundExpiry.Name = "nudCacheSoundExpiry";
            this.nudCacheSoundExpiry.Size = new System.Drawing.Size(461, 20);
            this.nudCacheSoundExpiry.TabIndex = 17;
            this.nudCacheSoundExpiry.TabStop = false;
            this.nudCacheSoundExpiry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCacheSoundExpiry.Value = new decimal(new int[] {
            518400,
            0,
            0,
            0});
            // 
            // txtCacheSoundCount
            // 
            this.tableLayoutPanelSound.SetColumnSpan(this.txtCacheSoundCount, 2);
            this.txtCacheSoundCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheSoundCount.Location = new System.Drawing.Point(159, 29);
            this.txtCacheSoundCount.Name = "txtCacheSoundCount";
            this.txtCacheSoundCount.ReadOnly = true;
            this.txtCacheSoundCount.Size = new System.Drawing.Size(461, 20);
            this.txtCacheSoundCount.TabIndex = 11;
            this.txtCacheSoundCount.Text = "0";
            this.txtCacheSoundCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // capSoundFiles
            // 
            this.capSoundFiles.Caption = "Sound files";
            this.capSoundFiles.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capSoundFiles.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capSoundFiles.Collapsed = false;
            this.capSoundFiles.Collapsee = null;
            this.capSoundFiles.Collapsible = false;
            this.capSoundFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.capSoundFiles.Location = new System.Drawing.Point(0, 160);
            this.capSoundFiles.Name = "capSoundFiles";
            this.capSoundFiles.Size = new System.Drawing.Size(623, 30);
            this.capSoundFiles.TabIndex = 20;
            // 
            // panel16
            // 
            this.panel16.AutoSize = true;
            this.panel16.Controls.Add(this.tableLayoutPanelImages);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(0, 30);
            this.panel16.Name = "panel16";
            this.panel16.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.panel16.Size = new System.Drawing.Size(623, 130);
            this.panel16.TabIndex = 19;
            // 
            // tableLayoutPanelImages
            // 
            this.tableLayoutPanelImages.AutoSize = true;
            this.tableLayoutPanelImages.ColumnCount = 3;
            this.tableLayoutPanelImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelImages.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelImages.Controls.Add(this.btnCacheImageBrowse, 2, 3);
            this.tableLayoutPanelImages.Controls.Add(this.txtCacheImageSize, 1, 2);
            this.tableLayoutPanelImages.Controls.Add(this.lblCacheImageSize, 0, 2);
            this.tableLayoutPanelImages.Controls.Add(this.lblCacheImageCount, 0, 1);
            this.tableLayoutPanelImages.Controls.Add(this.lblCacheImageExpiry, 0, 0);
            this.tableLayoutPanelImages.Controls.Add(this.nudCacheImageExpiry, 1, 0);
            this.tableLayoutPanelImages.Controls.Add(this.txtCacheImageCount, 1, 1);
            this.tableLayoutPanelImages.Controls.Add(this.btnCacheImageClear, 1, 3);
            this.tableLayoutPanelImages.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelImages.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanelImages.Name = "tableLayoutPanelImages";
            this.tableLayoutPanelImages.RowCount = 4;
            this.tableLayoutPanelImages.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelImages.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelImages.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelImages.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelImages.Size = new System.Drawing.Size(623, 114);
            this.tableLayoutPanelImages.TabIndex = 1;
            // 
            // btnCacheImageBrowse
            // 
            this.btnCacheImageBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCacheImageBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnCacheImageBrowse.Image")));
            this.btnCacheImageBrowse.Location = new System.Drawing.Point(392, 81);
            this.btnCacheImageBrowse.Name = "btnCacheImageBrowse";
            this.btnCacheImageBrowse.Size = new System.Drawing.Size(228, 30);
            this.btnCacheImageBrowse.TabIndex = 0;
            this.btnCacheImageBrowse.TabStop = false;
            this.btnCacheImageBrowse.Text = "Browse";
            this.btnCacheImageBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCacheImageBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCacheImageBrowse.UseMnemonic = false;
            this.btnCacheImageBrowse.UseVisualStyleBackColor = true;
            this.btnCacheImageBrowse.Click += new System.EventHandler(this.btnCacheImageBrowse_Click);
            // 
            // txtCacheImageSize
            // 
            this.tableLayoutPanelImages.SetColumnSpan(this.txtCacheImageSize, 2);
            this.txtCacheImageSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheImageSize.Location = new System.Drawing.Point(159, 55);
            this.txtCacheImageSize.Name = "txtCacheImageSize";
            this.txtCacheImageSize.ReadOnly = true;
            this.txtCacheImageSize.Size = new System.Drawing.Size(461, 20);
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
            this.lblCacheImageSize.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblCacheImageSize.Name = "lblCacheImageSize";
            this.lblCacheImageSize.Size = new System.Drawing.Size(150, 26);
            this.lblCacheImageSize.TabIndex = 14;
            this.lblCacheImageSize.Text = "Current disk size in bytes";
            this.lblCacheImageSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheImageCount
            // 
            this.lblCacheImageCount.AutoEllipsis = true;
            this.lblCacheImageCount.AutoSize = true;
            this.lblCacheImageCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheImageCount.Location = new System.Drawing.Point(3, 26);
            this.lblCacheImageCount.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblCacheImageCount.Name = "lblCacheImageCount";
            this.lblCacheImageCount.Size = new System.Drawing.Size(150, 26);
            this.lblCacheImageCount.TabIndex = 15;
            this.lblCacheImageCount.Text = "Current item count";
            this.lblCacheImageCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCacheImageExpiry
            // 
            this.lblCacheImageExpiry.AutoEllipsis = true;
            this.lblCacheImageExpiry.AutoSize = true;
            this.lblCacheImageExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCacheImageExpiry.Location = new System.Drawing.Point(3, 0);
            this.lblCacheImageExpiry.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblCacheImageExpiry.Name = "lblCacheImageExpiry";
            this.lblCacheImageExpiry.Size = new System.Drawing.Size(150, 26);
            this.lblCacheImageExpiry.TabIndex = 16;
            this.lblCacheImageExpiry.Text = "Expiration in minutes";
            this.lblCacheImageExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudCacheImageExpiry
            // 
            this.tableLayoutPanelImages.SetColumnSpan(this.nudCacheImageExpiry, 2);
            this.nudCacheImageExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudCacheImageExpiry.Location = new System.Drawing.Point(159, 3);
            this.nudCacheImageExpiry.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudCacheImageExpiry.Name = "nudCacheImageExpiry";
            this.nudCacheImageExpiry.Size = new System.Drawing.Size(461, 20);
            this.nudCacheImageExpiry.TabIndex = 17;
            this.nudCacheImageExpiry.TabStop = false;
            this.nudCacheImageExpiry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCacheImageExpiry.Value = new decimal(new int[] {
            518400,
            0,
            0,
            0});
            // 
            // txtCacheImageCount
            // 
            this.tableLayoutPanelImages.SetColumnSpan(this.txtCacheImageCount, 2);
            this.txtCacheImageCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCacheImageCount.Location = new System.Drawing.Point(159, 29);
            this.txtCacheImageCount.Name = "txtCacheImageCount";
            this.txtCacheImageCount.ReadOnly = true;
            this.txtCacheImageCount.Size = new System.Drawing.Size(461, 20);
            this.txtCacheImageCount.TabIndex = 11;
            this.txtCacheImageCount.Text = "0";
            this.txtCacheImageCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCacheImageClear
            // 
            this.btnCacheImageClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCacheImageClear.Image = ((System.Drawing.Image)(resources.GetObject("btnCacheImageClear.Image")));
            this.btnCacheImageClear.Location = new System.Drawing.Point(159, 81);
            this.btnCacheImageClear.Name = "btnCacheImageClear";
            this.btnCacheImageClear.Size = new System.Drawing.Size(227, 30);
            this.btnCacheImageClear.TabIndex = 18;
            this.btnCacheImageClear.TabStop = false;
            this.btnCacheImageClear.Text = "Clear cache";
            this.btnCacheImageClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCacheImageClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCacheImageClear.UseMnemonic = false;
            this.btnCacheImageClear.UseVisualStyleBackColor = true;
            this.btnCacheImageClear.Click += new System.EventHandler(this.btnCacheImageClear_Click);
            // 
            // capImageFiles
            // 
            this.capImageFiles.Caption = "Image files";
            this.capImageFiles.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capImageFiles.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capImageFiles.Collapsed = false;
            this.capImageFiles.Collapsee = null;
            this.capImageFiles.Collapsible = false;
            this.capImageFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.capImageFiles.Location = new System.Drawing.Point(0, 0);
            this.capImageFiles.Name = "capImageFiles";
            this.capImageFiles.Size = new System.Drawing.Size(623, 30);
            this.capImageFiles.TabIndex = 18;
            // 
            // tabUpdates
            // 
            this.tabUpdates.AutoScroll = true;
            this.tabUpdates.Controls.Add(this.panel10);
            this.tabUpdates.Controls.Add(this.capUpdateChannel);
            this.tabUpdates.Location = new System.Drawing.Point(4, 25);
            this.tabUpdates.Name = "tabUpdates";
            this.tabUpdates.Size = new System.Drawing.Size(640, 516);
            this.tabUpdates.TabIndex = 5;
            this.tabUpdates.Text = "Updates";
            this.tabUpdates.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.AutoSize = true;
            this.panel10.Controls.Add(this.tableLayoutPanel2);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 30);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panel10.Size = new System.Drawing.Size(640, 150);
            this.panel10.TabIndex = 20;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblExternalUpdateWarn, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtUpdateChannelUri, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbxUpdateMethod, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblUpdateChannelUri, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblUpdateMethod, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnUpdateCheck, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(640, 142);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblExternalUpdateWarn
            // 
            this.lblExternalUpdateWarn.AutoSize = true;
            this.lblExternalUpdateWarn.BackColor = System.Drawing.SystemColors.Info;
            this.lblExternalUpdateWarn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExternalUpdateWarn.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblExternalUpdateWarn.Location = new System.Drawing.Point(159, 27);
            this.lblExternalUpdateWarn.Name = "lblExternalUpdateWarn";
            this.lblExternalUpdateWarn.Padding = new System.Windows.Forms.Padding(8);
            this.lblExternalUpdateWarn.Size = new System.Drawing.Size(478, 60);
            this.lblExternalUpdateWarn.TabIndex = 29;
            this.lblExternalUpdateWarn.Text = resources.GetString("lblExternalUpdateWarn.Text");
            this.lblExternalUpdateWarn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUpdateChannelUri
            // 
            this.txtUpdateChannelUri.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtUpdateChannelUri.Location = new System.Drawing.Point(159, 90);
            this.txtUpdateChannelUri.Name = "txtUpdateChannelUri";
            this.txtUpdateChannelUri.Size = new System.Drawing.Size(478, 20);
            this.txtUpdateChannelUri.TabIndex = 22;
            // 
            // cbxUpdateMethod
            // 
            this.cbxUpdateMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxUpdateMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUpdateMethod.FormattingEnabled = true;
            this.cbxUpdateMethod.Items.AddRange(new object[] {
            "Built-in Github check (legacy)",
            "Official (recommended)",
            "External third party"});
            this.cbxUpdateMethod.Location = new System.Drawing.Point(159, 3);
            this.cbxUpdateMethod.Name = "cbxUpdateMethod";
            this.cbxUpdateMethod.Size = new System.Drawing.Size(478, 21);
            this.cbxUpdateMethod.TabIndex = 12;
            this.cbxUpdateMethod.SelectedIndexChanged += new System.EventHandler(this.cbxUpdateChannel_SelectedIndexChanged);
            // 
            // lblUpdateChannelUri
            // 
            this.lblUpdateChannelUri.AutoEllipsis = true;
            this.lblUpdateChannelUri.AutoSize = true;
            this.lblUpdateChannelUri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpdateChannelUri.Location = new System.Drawing.Point(3, 87);
            this.lblUpdateChannelUri.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblUpdateChannelUri.Name = "lblUpdateChannelUri";
            this.lblUpdateChannelUri.Size = new System.Drawing.Size(150, 26);
            this.lblUpdateChannelUri.TabIndex = 11;
            this.lblUpdateChannelUri.Text = "Channel URI";
            this.lblUpdateChannelUri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUpdateMethod
            // 
            this.lblUpdateMethod.AutoEllipsis = true;
            this.lblUpdateMethod.AutoSize = true;
            this.lblUpdateMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpdateMethod.Location = new System.Drawing.Point(3, 0);
            this.lblUpdateMethod.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblUpdateMethod.Name = "lblUpdateMethod";
            this.lblUpdateMethod.Size = new System.Drawing.Size(150, 27);
            this.lblUpdateMethod.TabIndex = 9;
            this.lblUpdateMethod.Text = "Update method";
            this.lblUpdateMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUpdateCheck
            // 
            this.btnUpdateCheck.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpdateCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateCheck.Image")));
            this.btnUpdateCheck.Location = new System.Drawing.Point(159, 116);
            this.btnUpdateCheck.Name = "btnUpdateCheck";
            this.btnUpdateCheck.Size = new System.Drawing.Size(478, 23);
            this.btnUpdateCheck.TabIndex = 30;
            this.btnUpdateCheck.Text = "Check for updates";
            this.btnUpdateCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdateCheck.UseVisualStyleBackColor = true;
            this.btnUpdateCheck.Click += new System.EventHandler(this.btnUpdateCheck_Click);
            // 
            // capUpdateChannel
            // 
            this.capUpdateChannel.Caption = "Update channel";
            this.capUpdateChannel.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capUpdateChannel.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capUpdateChannel.Collapsed = false;
            this.capUpdateChannel.Collapsee = null;
            this.capUpdateChannel.Collapsible = false;
            this.capUpdateChannel.Dock = System.Windows.Forms.DockStyle.Top;
            this.capUpdateChannel.Location = new System.Drawing.Point(0, 0);
            this.capUpdateChannel.Name = "capUpdateChannel";
            this.capUpdateChannel.Size = new System.Drawing.Size(640, 30);
            this.capUpdateChannel.TabIndex = 19;
            // 
            // tabEndpoint
            // 
            this.tabEndpoint.AutoScroll = true;
            this.tabEndpoint.Controls.Add(this.panel7);
            this.tabEndpoint.Controls.Add(this.prettyCaption3);
            this.tabEndpoint.Controls.Add(this.panel28);
            this.tabEndpoint.Controls.Add(this.capEndpointSettings);
            this.tabEndpoint.Controls.Add(this.panel27);
            this.tabEndpoint.Controls.Add(this.capEndpointStatus);
            this.tabEndpoint.Location = new System.Drawing.Point(4, 25);
            this.tabEndpoint.Name = "tabEndpoint";
            this.tabEndpoint.Size = new System.Drawing.Size(640, 516);
            this.tabEndpoint.TabIndex = 6;
            this.tabEndpoint.Text = "Endpoint";
            this.tabEndpoint.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.Controls.Add(this.dgvEndpointHistory);
            this.panel7.Controls.Add(this.tlsEndpointHistory);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 278);
            this.panel7.MinimumSize = new System.Drawing.Size(0, 150);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(640, 238);
            this.panel7.TabIndex = 26;
            // 
            // dgvEndpointHistory
            // 
            this.dgvEndpointHistory.AllowUserToAddRows = false;
            this.dgvEndpointHistory.AllowUserToDeleteRows = false;
            this.dgvEndpointHistory.AllowUserToResizeColumns = false;
            this.dgvEndpointHistory.AllowUserToResizeRows = false;
            this.dgvEndpointHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEndpointHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9});
            this.dgvEndpointHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEndpointHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEndpointHistory.Location = new System.Drawing.Point(0, 35);
            this.dgvEndpointHistory.Name = "dgvEndpointHistory";
            this.dgvEndpointHistory.RowHeadersVisible = false;
            this.dgvEndpointHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEndpointHistory.Size = new System.Drawing.Size(640, 203);
            this.dgvEndpointHistory.TabIndex = 2;
            this.dgvEndpointHistory.TabStop = false;
            this.dgvEndpointHistory.VirtualMode = true;
            this.dgvEndpointHistory.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvEndpointHistory_CellValueNeeded);
            // 
            // Column8
            // 
            this.Column8.Frozen = true;
            this.Column8.HeaderText = "Timestamp";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 150;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.HeaderText = "Data";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // tlsEndpointHistory
            // 
            this.tlsEndpointHistory.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsEndpointHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEndpointHistUpdate,
            this.tlsEndpointHistoryRecv,
            this.tlsEndpointHistoryCount});
            this.tlsEndpointHistory.Location = new System.Drawing.Point(0, 0);
            this.tlsEndpointHistory.Name = "tlsEndpointHistory";
            this.tlsEndpointHistory.Padding = new System.Windows.Forms.Padding(2);
            this.tlsEndpointHistory.Size = new System.Drawing.Size(640, 35);
            this.tlsEndpointHistory.TabIndex = 3;
            // 
            // btnEndpointHistUpdate
            // 
            this.btnEndpointHistUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnEndpointHistUpdate.Image")));
            this.btnEndpointHistUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEndpointHistUpdate.Name = "btnEndpointHistUpdate";
            this.btnEndpointHistUpdate.Padding = new System.Windows.Forms.Padding(4);
            this.btnEndpointHistUpdate.Size = new System.Drawing.Size(73, 28);
            this.btnEndpointHistUpdate.Text = "Update";
            this.btnEndpointHistUpdate.Click += new System.EventHandler(this.btnEndpointHistUpdate_Click);
            // 
            // tlsEndpointHistoryRecv
            // 
            this.tlsEndpointHistoryRecv.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tlsEndpointHistoryRecv.Name = "tlsEndpointHistoryRecv";
            this.tlsEndpointHistoryRecv.Size = new System.Drawing.Size(114, 28);
            this.tlsEndpointHistoryRecv.Text = "telegram(s) received";
            // 
            // tlsEndpointHistoryCount
            // 
            this.tlsEndpointHistoryCount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tlsEndpointHistoryCount.Name = "tlsEndpointHistoryCount";
            this.tlsEndpointHistoryCount.Size = new System.Drawing.Size(13, 28);
            this.tlsEndpointHistoryCount.Text = "0";
            // 
            // prettyCaption3
            // 
            this.prettyCaption3.Caption = "History";
            this.prettyCaption3.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.prettyCaption3.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.prettyCaption3.Collapsed = false;
            this.prettyCaption3.Collapsee = null;
            this.prettyCaption3.Collapsible = false;
            this.prettyCaption3.Dock = System.Windows.Forms.DockStyle.Top;
            this.prettyCaption3.Location = new System.Drawing.Point(0, 248);
            this.prettyCaption3.Name = "prettyCaption3";
            this.prettyCaption3.Size = new System.Drawing.Size(640, 30);
            this.prettyCaption3.TabIndex = 25;
            // 
            // panel28
            // 
            this.panel28.AutoScroll = true;
            this.panel28.AutoSize = true;
            this.panel28.Controls.Add(this.tableLayoutPanel8);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel28.Location = new System.Drawing.Point(0, 154);
            this.panel28.Name = "panel28";
            this.panel28.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.panel28.Size = new System.Drawing.Size(640, 94);
            this.panel28.TabIndex = 24;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.AutoSize = true;
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.lblEndpointLog, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.lblEndpointStartup, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.chkEndpointStartup, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.chkEndpointLog, 1, 2);
            this.tableLayoutPanel8.Controls.Add(this.txtEndpoint, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.lblEndpoint, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(640, 78);
            this.tableLayoutPanel8.TabIndex = 2;
            // 
            // lblEndpointLog
            // 
            this.lblEndpointLog.AutoEllipsis = true;
            this.lblEndpointLog.AutoSize = true;
            this.lblEndpointLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEndpointLog.Location = new System.Drawing.Point(3, 52);
            this.lblEndpointLog.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblEndpointLog.Name = "lblEndpointLog";
            this.lblEndpointLog.Size = new System.Drawing.Size(150, 26);
            this.lblEndpointLog.TabIndex = 10;
            this.lblEndpointLog.Text = "Log received data";
            this.lblEndpointLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndpointStartup
            // 
            this.lblEndpointStartup.AutoEllipsis = true;
            this.lblEndpointStartup.AutoSize = true;
            this.lblEndpointStartup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEndpointStartup.Location = new System.Drawing.Point(3, 26);
            this.lblEndpointStartup.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblEndpointStartup.Name = "lblEndpointStartup";
            this.lblEndpointStartup.Size = new System.Drawing.Size(150, 26);
            this.lblEndpointStartup.TabIndex = 9;
            this.lblEndpointStartup.Text = "Start endpoint on launch";
            this.lblEndpointStartup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkEndpointStartup
            // 
            this.chkEndpointStartup.AutoSize = true;
            this.chkEndpointStartup.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEndpointStartup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkEndpointStartup.Location = new System.Drawing.Point(159, 29);
            this.chkEndpointStartup.Name = "chkEndpointStartup";
            this.chkEndpointStartup.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chkEndpointStartup.Size = new System.Drawing.Size(478, 20);
            this.chkEndpointStartup.TabIndex = 0;
            this.chkEndpointStartup.TabStop = false;
            this.chkEndpointStartup.UseVisualStyleBackColor = true;
            // 
            // chkEndpointLog
            // 
            this.chkEndpointLog.AutoSize = true;
            this.chkEndpointLog.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEndpointLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkEndpointLog.Location = new System.Drawing.Point(159, 55);
            this.chkEndpointLog.Name = "chkEndpointLog";
            this.chkEndpointLog.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chkEndpointLog.Size = new System.Drawing.Size(478, 20);
            this.chkEndpointLog.TabIndex = 1;
            this.chkEndpointLog.TabStop = false;
            this.chkEndpointLog.UseVisualStyleBackColor = true;
            // 
            // txtEndpoint
            // 
            this.txtEndpoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEndpoint.Location = new System.Drawing.Point(159, 3);
            this.txtEndpoint.Name = "txtEndpoint";
            this.txtEndpoint.Size = new System.Drawing.Size(478, 20);
            this.txtEndpoint.TabIndex = 7;
            // 
            // lblEndpoint
            // 
            this.lblEndpoint.AutoEllipsis = true;
            this.lblEndpoint.AutoSize = true;
            this.lblEndpoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEndpoint.Location = new System.Drawing.Point(3, 0);
            this.lblEndpoint.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblEndpoint.Name = "lblEndpoint";
            this.lblEndpoint.Size = new System.Drawing.Size(150, 26);
            this.lblEndpoint.TabIndex = 8;
            this.lblEndpoint.Text = "HTTP endpoint";
            this.lblEndpoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // capEndpointSettings
            // 
            this.capEndpointSettings.Caption = "Settings";
            this.capEndpointSettings.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capEndpointSettings.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capEndpointSettings.Collapsed = false;
            this.capEndpointSettings.Collapsee = null;
            this.capEndpointSettings.Collapsible = false;
            this.capEndpointSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.capEndpointSettings.Location = new System.Drawing.Point(0, 124);
            this.capEndpointSettings.Name = "capEndpointSettings";
            this.capEndpointSettings.Size = new System.Drawing.Size(640, 30);
            this.capEndpointSettings.TabIndex = 23;
            // 
            // panel27
            // 
            this.panel27.AutoSize = true;
            this.panel27.Controls.Add(this.tableLayoutPanel18);
            this.panel27.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel27.Location = new System.Drawing.Point(0, 30);
            this.panel27.Name = "panel27";
            this.panel27.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.panel27.Size = new System.Drawing.Size(640, 94);
            this.panel27.TabIndex = 22;
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.AutoSize = true;
            this.tableLayoutPanel18.ColumnCount = 2;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel18.Controls.Add(this.btnEndpointStart, 1, 0);
            this.tableLayoutPanel18.Controls.Add(this.btnEndpointStop, 1, 1);
            this.tableLayoutPanel18.Controls.Add(this.txtEndpointStatus, 0, 0);
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 2;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(640, 78);
            this.tableLayoutPanel18.TabIndex = 1;
            // 
            // btnEndpointStart
            // 
            this.btnEndpointStart.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEndpointStart.Image = ((System.Drawing.Image)(resources.GetObject("btnEndpointStart.Image")));
            this.btnEndpointStart.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEndpointStart.Location = new System.Drawing.Point(557, 3);
            this.btnEndpointStart.Name = "btnEndpointStart";
            this.btnEndpointStart.Size = new System.Drawing.Size(80, 33);
            this.btnEndpointStart.TabIndex = 0;
            this.btnEndpointStart.TabStop = false;
            this.btnEndpointStart.Text = "Start";
            this.btnEndpointStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEndpointStart.UseVisualStyleBackColor = true;
            this.btnEndpointStart.Click += new System.EventHandler(this.btnEndpointStart_Click);
            // 
            // btnEndpointStop
            // 
            this.btnEndpointStop.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEndpointStop.Image = ((System.Drawing.Image)(resources.GetObject("btnEndpointStop.Image")));
            this.btnEndpointStop.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEndpointStop.Location = new System.Drawing.Point(557, 42);
            this.btnEndpointStop.Name = "btnEndpointStop";
            this.btnEndpointStop.Size = new System.Drawing.Size(80, 33);
            this.btnEndpointStop.TabIndex = 1;
            this.btnEndpointStop.TabStop = false;
            this.btnEndpointStop.Text = "Stop";
            this.btnEndpointStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEndpointStop.UseVisualStyleBackColor = true;
            this.btnEndpointStop.Click += new System.EventHandler(this.btnEndpointStop_Click);
            // 
            // txtEndpointStatus
            // 
            this.txtEndpointStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEndpointStatus.Location = new System.Drawing.Point(3, 3);
            this.txtEndpointStatus.Multiline = true;
            this.txtEndpointStatus.Name = "txtEndpointStatus";
            this.txtEndpointStatus.ReadOnly = true;
            this.tableLayoutPanel18.SetRowSpan(this.txtEndpointStatus, 2);
            this.txtEndpointStatus.Size = new System.Drawing.Size(548, 72);
            this.txtEndpointStatus.TabIndex = 2;
            // 
            // capEndpointStatus
            // 
            this.capEndpointStatus.Caption = "Status";
            this.capEndpointStatus.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capEndpointStatus.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capEndpointStatus.Collapsed = false;
            this.capEndpointStatus.Collapsee = null;
            this.capEndpointStatus.Collapsible = false;
            this.capEndpointStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.capEndpointStatus.Location = new System.Drawing.Point(0, 0);
            this.capEndpointStatus.Name = "capEndpointStatus";
            this.capEndpointStatus.Size = new System.Drawing.Size(640, 30);
            this.capEndpointStatus.TabIndex = 21;
            // 
            // tabConstants
            // 
            this.tabConstants.AutoScroll = true;
            this.tabConstants.Controls.Add(this.dgvConstVariables);
            this.tabConstants.Controls.Add(this.tlsConstant);
            this.tabConstants.Location = new System.Drawing.Point(4, 25);
            this.tabConstants.Name = "tabConstants";
            this.tabConstants.Size = new System.Drawing.Size(640, 516);
            this.tabConstants.TabIndex = 7;
            this.tabConstants.Text = "Constants";
            this.tabConstants.UseVisualStyleBackColor = true;
            // 
            // dgvConstVariables
            // 
            this.dgvConstVariables.AllowUserToAddRows = false;
            this.dgvConstVariables.AllowUserToDeleteRows = false;
            this.dgvConstVariables.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvConstVariables.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvConstVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConstVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colScalarName,
            this.colScalarValue});
            this.dgvConstVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConstVariables.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvConstVariables.Location = new System.Drawing.Point(0, 35);
            this.dgvConstVariables.Name = "dgvConstVariables";
            this.dgvConstVariables.RowHeadersVisible = false;
            this.dgvConstVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConstVariables.ShowCellErrors = false;
            this.dgvConstVariables.ShowEditingIcon = false;
            this.dgvConstVariables.ShowRowErrors = false;
            this.dgvConstVariables.Size = new System.Drawing.Size(640, 481);
            this.dgvConstVariables.TabIndex = 2;
            this.dgvConstVariables.TabStop = false;
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
            // tlsConstant
            // 
            this.tlsConstant.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsConstant.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConstAdd,
            this.btnConstEdit,
            this.btnConstRemove});
            this.tlsConstant.Location = new System.Drawing.Point(0, 0);
            this.tlsConstant.Name = "tlsConstant";
            this.tlsConstant.Padding = new System.Windows.Forms.Padding(2);
            this.tlsConstant.Size = new System.Drawing.Size(640, 35);
            this.tlsConstant.TabIndex = 3;
            // 
            // btnConstAdd
            // 
            this.btnConstAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnConstAdd.Image")));
            this.btnConstAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConstAdd.Name = "btnConstAdd";
            this.btnConstAdd.Padding = new System.Windows.Forms.Padding(4);
            this.btnConstAdd.Size = new System.Drawing.Size(106, 28);
            this.btnConstAdd.Text = "Add constant";
            this.btnConstAdd.Click += new System.EventHandler(this.btnConstAdd_Click);
            // 
            // btnConstEdit
            // 
            this.btnConstEdit.Enabled = false;
            this.btnConstEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnConstEdit.Image")));
            this.btnConstEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConstEdit.Name = "btnConstEdit";
            this.btnConstEdit.Padding = new System.Windows.Forms.Padding(4);
            this.btnConstEdit.Size = new System.Drawing.Size(104, 28);
            this.btnConstEdit.Text = "Edit constant";
            this.btnConstEdit.Click += new System.EventHandler(this.btnConstEdit_Click);
            // 
            // btnConstRemove
            // 
            this.btnConstRemove.Enabled = false;
            this.btnConstRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnConstRemove.Image")));
            this.btnConstRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConstRemove.Name = "btnConstRemove";
            this.btnConstRemove.Padding = new System.Windows.Forms.Padding(4);
            this.btnConstRemove.Size = new System.Drawing.Size(127, 28);
            this.btnConstRemove.Text = "Remove constant";
            this.btnConstRemove.ToolTipText = "Remove value";
            this.btnConstRemove.Click += new System.EventHandler(this.btnConstRemove_Click);
            // 
            // tabSubs
            // 
            this.tabSubs.AutoScroll = true;
            this.tabSubs.Controls.Add(this.dgvSubstitutions);
            this.tabSubs.Controls.Add(this.tlsSubstitutions);
            this.tabSubs.Location = new System.Drawing.Point(4, 25);
            this.tabSubs.Name = "tabSubs";
            this.tabSubs.Size = new System.Drawing.Size(640, 516);
            this.tabSubs.TabIndex = 11;
            this.tabSubs.Text = "Substitutions";
            this.tabSubs.UseVisualStyleBackColor = true;
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
            this.dgvSubstitutions.Location = new System.Drawing.Point(0, 35);
            this.dgvSubstitutions.Name = "dgvSubstitutions";
            this.dgvSubstitutions.RowHeadersVisible = false;
            this.dgvSubstitutions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubstitutions.ShowCellErrors = false;
            this.dgvSubstitutions.ShowEditingIcon = false;
            this.dgvSubstitutions.ShowRowErrors = false;
            this.dgvSubstitutions.Size = new System.Drawing.Size(640, 481);
            this.dgvSubstitutions.TabIndex = 2;
            this.dgvSubstitutions.TabStop = false;
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
            this.tlsSubstitutions.Location = new System.Drawing.Point(0, 0);
            this.tlsSubstitutions.Name = "tlsSubstitutions";
            this.tlsSubstitutions.Padding = new System.Windows.Forms.Padding(2);
            this.tlsSubstitutions.Size = new System.Drawing.Size(640, 35);
            this.tlsSubstitutions.TabIndex = 3;
            // 
            // btnSubAdd
            // 
            this.btnSubAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnSubAdd.Image")));
            this.btnSubAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSubAdd.Name = "btnSubAdd";
            this.btnSubAdd.Padding = new System.Windows.Forms.Padding(4);
            this.btnSubAdd.Size = new System.Drawing.Size(123, 28);
            this.btnSubAdd.Text = "Add substitution";
            this.btnSubAdd.Click += new System.EventHandler(this.btnSubAdd_Click);
            // 
            // btnSubEdit
            // 
            this.btnSubEdit.Enabled = false;
            this.btnSubEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnSubEdit.Image")));
            this.btnSubEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSubEdit.Name = "btnSubEdit";
            this.btnSubEdit.Padding = new System.Windows.Forms.Padding(4);
            this.btnSubEdit.Size = new System.Drawing.Size(121, 28);
            this.btnSubEdit.Text = "Edit substitution";
            this.btnSubEdit.Click += new System.EventHandler(this.btnSubEdit_Click);
            // 
            // btnSubRemove
            // 
            this.btnSubRemove.Enabled = false;
            this.btnSubRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnSubRemove.Image")));
            this.btnSubRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSubRemove.Name = "btnSubRemove";
            this.btnSubRemove.Padding = new System.Windows.Forms.Padding(4);
            this.btnSubRemove.Size = new System.Drawing.Size(144, 28);
            this.btnSubRemove.Text = "Remove substitution";
            this.btnSubRemove.Click += new System.EventHandler(this.btnSubRemove_Click);
            // 
            // tabGameSpecific
            // 
            this.tabGameSpecific.AutoScroll = true;
            this.tabGameSpecific.Controls.Add(this.tbcGames);
            this.tabGameSpecific.Location = new System.Drawing.Point(4, 25);
            this.tabGameSpecific.Name = "tabGameSpecific";
            this.tabGameSpecific.Size = new System.Drawing.Size(640, 516);
            this.tabGameSpecific.TabIndex = 8;
            this.tabGameSpecific.Text = "Game-specific";
            this.tabGameSpecific.UseVisualStyleBackColor = true;
            // 
            // tbcGames
            // 
            this.tbcGames.Controls.Add(this.tabFFXIV);
            this.tbcGames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcGames.Location = new System.Drawing.Point(0, 0);
            this.tbcGames.Name = "tbcGames";
            this.tbcGames.SelectedIndex = 0;
            this.tbcGames.Size = new System.Drawing.Size(640, 516);
            this.tbcGames.TabIndex = 0;
            // 
            // tabFFXIV
            // 
            this.tabFFXIV.Controls.Add(this.panel25);
            this.tabFFXIV.Controls.Add(this.capFfxivPartyOrder);
            this.tabFFXIV.Controls.Add(this.panel24);
            this.tabFFXIV.Controls.Add(this.capFfxivLogging);
            this.tabFFXIV.Location = new System.Drawing.Point(4, 22);
            this.tabFFXIV.Name = "tabFFXIV";
            this.tabFFXIV.Padding = new System.Windows.Forms.Padding(8);
            this.tabFFXIV.Size = new System.Drawing.Size(632, 490);
            this.tabFFXIV.TabIndex = 0;
            this.tabFFXIV.Text = "Final Fantasy XIV";
            this.tabFFXIV.UseVisualStyleBackColor = true;
            // 
            // panel25
            // 
            this.panel25.Controls.Add(this.tableLayoutPanel5);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel25.Location = new System.Drawing.Point(8, 110);
            this.panel25.Name = "panel25";
            this.panel25.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panel25.Size = new System.Drawing.Size(616, 372);
            this.panel25.TabIndex = 23;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.lblFfxivJobOrder, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblFfxivJobMethod, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.cbxFfxivJobMethod, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.panel26, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(616, 364);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // lblFfxivJobOrder
            // 
            this.lblFfxivJobOrder.AutoEllipsis = true;
            this.lblFfxivJobOrder.AutoSize = true;
            this.lblFfxivJobOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFfxivJobOrder.Location = new System.Drawing.Point(3, 27);
            this.lblFfxivJobOrder.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblFfxivJobOrder.Name = "lblFfxivJobOrder";
            this.lblFfxivJobOrder.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblFfxivJobOrder.Size = new System.Drawing.Size(150, 337);
            this.lblFfxivJobOrder.TabIndex = 0;
            this.lblFfxivJobOrder.Text = "Job order";
            // 
            // lblFfxivJobMethod
            // 
            this.lblFfxivJobMethod.AutoEllipsis = true;
            this.lblFfxivJobMethod.AutoSize = true;
            this.lblFfxivJobMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFfxivJobMethod.Location = new System.Drawing.Point(3, 0);
            this.lblFfxivJobMethod.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblFfxivJobMethod.Name = "lblFfxivJobMethod";
            this.lblFfxivJobMethod.Size = new System.Drawing.Size(150, 27);
            this.lblFfxivJobMethod.TabIndex = 1;
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
            this.cbxFfxivJobMethod.Location = new System.Drawing.Point(159, 3);
            this.cbxFfxivJobMethod.Name = "cbxFfxivJobMethod";
            this.cbxFfxivJobMethod.Size = new System.Drawing.Size(454, 21);
            this.cbxFfxivJobMethod.TabIndex = 2;
            this.cbxFfxivJobMethod.TabStop = false;
            this.cbxFfxivJobMethod.SelectedIndexChanged += new System.EventHandler(this.cbxFfxivJobMethod_SelectedIndexChanged);
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.lstFfxivJobOrder);
            this.panel26.Controls.Add(this.tlsFfxivPartyOrder);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel26.Location = new System.Drawing.Point(159, 30);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(454, 331);
            this.panel26.TabIndex = 3;
            // 
            // lstFfxivJobOrder
            // 
            this.lstFfxivJobOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFfxivJobOrder.FormattingEnabled = true;
            this.lstFfxivJobOrder.IntegralHeight = false;
            this.lstFfxivJobOrder.Location = new System.Drawing.Point(0, 35);
            this.lstFfxivJobOrder.Name = "lstFfxivJobOrder";
            this.lstFfxivJobOrder.Size = new System.Drawing.Size(454, 296);
            this.lstFfxivJobOrder.TabIndex = 0;
            this.lstFfxivJobOrder.TabStop = false;
            this.lstFfxivJobOrder.SelectedIndexChanged += new System.EventHandler(this.lstFfxivJobOrder_SelectedIndexChanged);
            this.lstFfxivJobOrder.EnabledChanged += new System.EventHandler(this.lstFfxivJobOrder_EnabledChanged);
            // 
            // tlsFfxivPartyOrder
            // 
            this.tlsFfxivPartyOrder.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsFfxivPartyOrder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFfxivJobUp,
            this.btnFfxivJobDown,
            this.toolStripSeparator1,
            this.btnFfxivJobRestore});
            this.tlsFfxivPartyOrder.Location = new System.Drawing.Point(0, 0);
            this.tlsFfxivPartyOrder.Name = "tlsFfxivPartyOrder";
            this.tlsFfxivPartyOrder.Padding = new System.Windows.Forms.Padding(2);
            this.tlsFfxivPartyOrder.Size = new System.Drawing.Size(454, 35);
            this.tlsFfxivPartyOrder.TabIndex = 1;
            // 
            // btnFfxivJobUp
            // 
            this.btnFfxivJobUp.Enabled = false;
            this.btnFfxivJobUp.Image = ((System.Drawing.Image)(resources.GetObject("btnFfxivJobUp.Image")));
            this.btnFfxivJobUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFfxivJobUp.Name = "btnFfxivJobUp";
            this.btnFfxivJobUp.Padding = new System.Windows.Forms.Padding(4);
            this.btnFfxivJobUp.Size = new System.Drawing.Size(82, 28);
            this.btnFfxivJobUp.Text = "Move up";
            this.btnFfxivJobUp.Click += new System.EventHandler(this.btnFfxivJobUp_Click);
            // 
            // btnFfxivJobDown
            // 
            this.btnFfxivJobDown.Enabled = false;
            this.btnFfxivJobDown.Image = ((System.Drawing.Image)(resources.GetObject("btnFfxivJobDown.Image")));
            this.btnFfxivJobDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFfxivJobDown.Name = "btnFfxivJobDown";
            this.btnFfxivJobDown.Padding = new System.Windows.Forms.Padding(4);
            this.btnFfxivJobDown.Size = new System.Drawing.Size(98, 28);
            this.btnFfxivJobDown.Text = "Move down";
            this.btnFfxivJobDown.Click += new System.EventHandler(this.btnFfxivJobDown_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnFfxivJobRestore
            // 
            this.btnFfxivJobRestore.Image = ((System.Drawing.Image)(resources.GetObject("btnFfxivJobRestore.Image")));
            this.btnFfxivJobRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFfxivJobRestore.Name = "btnFfxivJobRestore";
            this.btnFfxivJobRestore.Padding = new System.Windows.Forms.Padding(4);
            this.btnFfxivJobRestore.Size = new System.Drawing.Size(114, 28);
            this.btnFfxivJobRestore.Text = "Restore default";
            this.btnFfxivJobRestore.Click += new System.EventHandler(this.btnFfxivJobRestore_Click);
            // 
            // capFfxivPartyOrder
            // 
            this.capFfxivPartyOrder.Caption = "Party list ordering";
            this.capFfxivPartyOrder.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capFfxivPartyOrder.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capFfxivPartyOrder.Collapsed = false;
            this.capFfxivPartyOrder.Collapsee = null;
            this.capFfxivPartyOrder.Collapsible = false;
            this.capFfxivPartyOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.capFfxivPartyOrder.Location = new System.Drawing.Point(8, 80);
            this.capFfxivPartyOrder.Name = "capFfxivPartyOrder";
            this.capFfxivPartyOrder.Size = new System.Drawing.Size(616, 30);
            this.capFfxivPartyOrder.TabIndex = 22;
            // 
            // panel24
            // 
            this.panel24.AutoSize = true;
            this.panel24.Controls.Add(this.tableLayoutPanel9);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel24.Location = new System.Drawing.Point(8, 38);
            this.panel24.Name = "panel24";
            this.panel24.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.panel24.Size = new System.Drawing.Size(616, 42);
            this.panel24.TabIndex = 21;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.AutoSize = true;
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.lblFfxivLogNetwork, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.chkFfxivLogNetwork, 1, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.Size = new System.Drawing.Size(616, 26);
            this.tableLayoutPanel9.TabIndex = 1;
            // 
            // lblFfxivLogNetwork
            // 
            this.lblFfxivLogNetwork.AutoEllipsis = true;
            this.lblFfxivLogNetwork.AutoSize = true;
            this.lblFfxivLogNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFfxivLogNetwork.Location = new System.Drawing.Point(3, 0);
            this.lblFfxivLogNetwork.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblFfxivLogNetwork.Name = "lblFfxivLogNetwork";
            this.lblFfxivLogNetwork.Size = new System.Drawing.Size(150, 26);
            this.lblFfxivLogNetwork.TabIndex = 10;
            this.lblFfxivLogNetwork.Text = "Log network events";
            this.lblFfxivLogNetwork.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkFfxivLogNetwork
            // 
            this.chkFfxivLogNetwork.AutoSize = true;
            this.chkFfxivLogNetwork.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFfxivLogNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkFfxivLogNetwork.Location = new System.Drawing.Point(159, 3);
            this.chkFfxivLogNetwork.Name = "chkFfxivLogNetwork";
            this.chkFfxivLogNetwork.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.chkFfxivLogNetwork.Size = new System.Drawing.Size(454, 20);
            this.chkFfxivLogNetwork.TabIndex = 0;
            this.chkFfxivLogNetwork.TabStop = false;
            this.chkFfxivLogNetwork.UseVisualStyleBackColor = true;
            // 
            // capFfxivLogging
            // 
            this.capFfxivLogging.Caption = "Logging";
            this.capFfxivLogging.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capFfxivLogging.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capFfxivLogging.Collapsed = false;
            this.capFfxivLogging.Collapsee = null;
            this.capFfxivLogging.Collapsible = false;
            this.capFfxivLogging.Dock = System.Windows.Forms.DockStyle.Top;
            this.capFfxivLogging.Location = new System.Drawing.Point(8, 8);
            this.capFfxivLogging.Name = "capFfxivLogging";
            this.capFfxivLogging.Size = new System.Drawing.Size(616, 30);
            this.capFfxivLogging.TabIndex = 20;
            // 
            // tabSecurity
            // 
            this.tabSecurity.AutoScroll = true;
            this.tabSecurity.Controls.Add(this.panel19);
            this.tabSecurity.Controls.Add(this.capScripting);
            this.tabSecurity.Location = new System.Drawing.Point(4, 25);
            this.tabSecurity.Name = "tabSecurity";
            this.tabSecurity.Size = new System.Drawing.Size(640, 516);
            this.tabSecurity.TabIndex = 10;
            this.tabSecurity.Text = "Security";
            this.tabSecurity.UseVisualStyleBackColor = true;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.dgvAdditionalFeatures);
            this.panel19.Controls.Add(this.panel8);
            this.panel19.Controls.Add(this.dgvApiAccess);
            this.panel19.Controls.Add(this.panel18);
            this.panel19.Controls.Add(this.btnUnlockSecurity);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel19.Location = new System.Drawing.Point(0, 30);
            this.panel19.Name = "panel19";
            this.panel19.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panel19.Size = new System.Drawing.Size(640, 486);
            this.panel19.TabIndex = 10;
            // 
            // dgvAdditionalFeatures
            // 
            this.dgvAdditionalFeatures.AllowUserToAddRows = false;
            this.dgvAdditionalFeatures.AllowUserToDeleteRows = false;
            this.dgvAdditionalFeatures.AllowUserToResizeColumns = false;
            this.dgvAdditionalFeatures.AllowUserToResizeRows = false;
            this.dgvAdditionalFeatures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdditionalFeatures.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewCheckBoxColumn3});
            this.dgvAdditionalFeatures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAdditionalFeatures.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAdditionalFeatures.Enabled = false;
            this.dgvAdditionalFeatures.Location = new System.Drawing.Point(0, 254);
            this.dgvAdditionalFeatures.Name = "dgvAdditionalFeatures";
            this.dgvAdditionalFeatures.ReadOnly = true;
            this.dgvAdditionalFeatures.RowHeadersVisible = false;
            this.dgvAdditionalFeatures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdditionalFeatures.ShowCellErrors = false;
            this.dgvAdditionalFeatures.ShowEditingIcon = false;
            this.dgvAdditionalFeatures.ShowRowErrors = false;
            this.dgvAdditionalFeatures.Size = new System.Drawing.Size(640, 232);
            this.dgvAdditionalFeatures.TabIndex = 5;
            this.dgvAdditionalFeatures.TabStop = false;
            this.dgvAdditionalFeatures.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdditionalFeatures_CellContentClick);
            this.dgvAdditionalFeatures.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdditionalFeatures_CellContentDoubleClick);
            this.dgvAdditionalFeatures.SelectionChanged += new System.EventHandler(this.dgvAdditionalFeatures_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Additional features";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "Allow for local triggers";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.HeaderText = "Allow for remote triggers";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.HeaderText = "Allow if running as admin";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.ReadOnly = true;
            this.dataGridViewCheckBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 246);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(640, 8);
            this.panel8.TabIndex = 6;
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
            this.dgvApiAccess.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvApiAccess.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvApiAccess.Enabled = false;
            this.dgvApiAccess.Location = new System.Drawing.Point(0, 46);
            this.dgvApiAccess.Name = "dgvApiAccess";
            this.dgvApiAccess.ReadOnly = true;
            this.dgvApiAccess.RowHeadersVisible = false;
            this.dgvApiAccess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApiAccess.ShowCellErrors = false;
            this.dgvApiAccess.ShowEditingIcon = false;
            this.dgvApiAccess.ShowRowErrors = false;
            this.dgvApiAccess.Size = new System.Drawing.Size(640, 200);
            this.dgvApiAccess.TabIndex = 7;
            this.dgvApiAccess.TabStop = false;
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
            this.panel18.Location = new System.Drawing.Point(0, 38);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(640, 8);
            this.panel18.TabIndex = 8;
            // 
            // btnUnlockSecurity
            // 
            this.btnUnlockSecurity.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUnlockSecurity.Image = ((System.Drawing.Image)(resources.GetObject("btnUnlockSecurity.Image")));
            this.btnUnlockSecurity.Location = new System.Drawing.Point(0, 8);
            this.btnUnlockSecurity.Name = "btnUnlockSecurity";
            this.btnUnlockSecurity.Size = new System.Drawing.Size(640, 30);
            this.btnUnlockSecurity.TabIndex = 9;
            this.btnUnlockSecurity.TabStop = false;
            this.btnUnlockSecurity.Text = "Unlock security settings for editing";
            this.btnUnlockSecurity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUnlockSecurity.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUnlockSecurity.UseVisualStyleBackColor = true;
            this.btnUnlockSecurity.Click += new System.EventHandler(this.btnUnlockSecurity_Click);
            // 
            // capScripting
            // 
            this.capScripting.Caption = "Scripting API access";
            this.capScripting.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capScripting.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capScripting.Collapsed = false;
            this.capScripting.Collapsee = null;
            this.capScripting.Collapsible = false;
            this.capScripting.Dock = System.Windows.Forms.DockStyle.Top;
            this.capScripting.Location = new System.Drawing.Point(0, 0);
            this.capScripting.Name = "capScripting";
            this.capScripting.Size = new System.Drawing.Size(640, 30);
            this.capScripting.TabIndex = 9;
            // 
            // tabMiscellaneous
            // 
            this.tabMiscellaneous.AutoScroll = true;
            this.tabMiscellaneous.Controls.Add(this.panel12);
            this.tabMiscellaneous.Controls.Add(this.capAuraManagement);
            this.tabMiscellaneous.Controls.Add(this.panel5);
            this.tabMiscellaneous.Controls.Add(this.capAutosaving);
            this.tabMiscellaneous.Controls.Add(this.panel20);
            this.tabMiscellaneous.Controls.Add(this.capTemplate);
            this.tabMiscellaneous.Location = new System.Drawing.Point(4, 25);
            this.tabMiscellaneous.Name = "tabMiscellaneous";
            this.tabMiscellaneous.Size = new System.Drawing.Size(640, 516);
            this.tabMiscellaneous.TabIndex = 9;
            this.tabMiscellaneous.Text = "Miscellaneous";
            this.tabMiscellaneous.UseVisualStyleBackColor = true;
            // 
            // panel12
            // 
            this.panel12.AutoSize = true;
            this.panel12.Controls.Add(this.tableLayoutPanel11);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 203);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.panel12.Size = new System.Drawing.Size(640, 60);
            this.panel12.TabIndex = 27;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.AutoSize = true;
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.lblEnableHwAccel, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.txtMonitorWindow, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.lblMonitorWindow, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.cbxEnableHwAccel, 1, 1);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(640, 52);
            this.tableLayoutPanel11.TabIndex = 1;
            // 
            // lblEnableHwAccel
            // 
            this.lblEnableHwAccel.AutoEllipsis = true;
            this.lblEnableHwAccel.AutoSize = true;
            this.lblEnableHwAccel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEnableHwAccel.Location = new System.Drawing.Point(3, 26);
            this.lblEnableHwAccel.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblEnableHwAccel.Name = "lblEnableHwAccel";
            this.lblEnableHwAccel.Size = new System.Drawing.Size(213, 26);
            this.lblEnableHwAccel.TabIndex = 11;
            this.lblEnableHwAccel.Text = "Enable overlay hardware acceleration";
            this.lblEnableHwAccel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMonitorWindow
            // 
            this.txtMonitorWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMonitorWindow.Location = new System.Drawing.Point(222, 3);
            this.txtMonitorWindow.Name = "txtMonitorWindow";
            this.txtMonitorWindow.Size = new System.Drawing.Size(415, 20);
            this.txtMonitorWindow.TabIndex = 8;
            // 
            // lblMonitorWindow
            // 
            this.lblMonitorWindow.AutoEllipsis = true;
            this.lblMonitorWindow.AutoSize = true;
            this.lblMonitorWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMonitorWindow.Location = new System.Drawing.Point(3, 0);
            this.lblMonitorWindow.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblMonitorWindow.Name = "lblMonitorWindow";
            this.lblMonitorWindow.Size = new System.Drawing.Size(213, 26);
            this.lblMonitorWindow.TabIndex = 9;
            this.lblMonitorWindow.Text = "Monitor window for showing/hiding overlays";
            this.lblMonitorWindow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxEnableHwAccel
            // 
            this.cbxEnableHwAccel.AutoSize = true;
            this.cbxEnableHwAccel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxEnableHwAccel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxEnableHwAccel.Location = new System.Drawing.Point(222, 29);
            this.cbxEnableHwAccel.Name = "cbxEnableHwAccel";
            this.cbxEnableHwAccel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cbxEnableHwAccel.Size = new System.Drawing.Size(415, 20);
            this.cbxEnableHwAccel.TabIndex = 10;
            this.cbxEnableHwAccel.TabStop = false;
            this.cbxEnableHwAccel.UseVisualStyleBackColor = true;
            // 
            // capAuraManagement
            // 
            this.capAuraManagement.Caption = "Overlay management";
            this.capAuraManagement.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capAuraManagement.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capAuraManagement.Collapsed = false;
            this.capAuraManagement.Collapsee = null;
            this.capAuraManagement.Collapsible = false;
            this.capAuraManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.capAuraManagement.Location = new System.Drawing.Point(0, 173);
            this.capAuraManagement.Name = "capAuraManagement";
            this.capAuraManagement.Size = new System.Drawing.Size(640, 30);
            this.capAuraManagement.TabIndex = 26;
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Controls.Add(this.tableLayoutPanel10);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 105);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.panel5.Size = new System.Drawing.Size(640, 68);
            this.panel5.TabIndex = 25;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.AutoSize = true;
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.lblAutosaveConfig, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.lblAutosaveInterval, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.cbxAutosaveConfig, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.nudAutosaveMinutes, 1, 1);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.Size = new System.Drawing.Size(640, 52);
            this.tableLayoutPanel10.TabIndex = 1;
            // 
            // lblAutosaveConfig
            // 
            this.lblAutosaveConfig.AutoEllipsis = true;
            this.lblAutosaveConfig.AutoSize = true;
            this.lblAutosaveConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAutosaveConfig.Location = new System.Drawing.Point(3, 0);
            this.lblAutosaveConfig.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblAutosaveConfig.Name = "lblAutosaveConfig";
            this.lblAutosaveConfig.Size = new System.Drawing.Size(169, 26);
            this.lblAutosaveConfig.TabIndex = 8;
            this.lblAutosaveConfig.Text = "Enable configuration auto-save";
            this.lblAutosaveConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAutosaveInterval
            // 
            this.lblAutosaveInterval.AutoEllipsis = true;
            this.lblAutosaveInterval.AutoSize = true;
            this.lblAutosaveInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAutosaveInterval.Location = new System.Drawing.Point(3, 26);
            this.lblAutosaveInterval.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblAutosaveInterval.Name = "lblAutosaveInterval";
            this.lblAutosaveInterval.Size = new System.Drawing.Size(169, 26);
            this.lblAutosaveInterval.TabIndex = 2;
            this.lblAutosaveInterval.Text = "Autosaving time interval in minutes";
            this.lblAutosaveInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxAutosaveConfig
            // 
            this.cbxAutosaveConfig.AutoSize = true;
            this.cbxAutosaveConfig.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxAutosaveConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxAutosaveConfig.Location = new System.Drawing.Point(178, 3);
            this.cbxAutosaveConfig.Name = "cbxAutosaveConfig";
            this.cbxAutosaveConfig.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cbxAutosaveConfig.Size = new System.Drawing.Size(459, 20);
            this.cbxAutosaveConfig.TabIndex = 3;
            this.cbxAutosaveConfig.TabStop = false;
            this.cbxAutosaveConfig.UseVisualStyleBackColor = true;
            this.cbxAutosaveConfig.CheckedChanged += new System.EventHandler(this.cbxAutosaveConfig_CheckedChanged);
            // 
            // nudAutosaveMinutes
            // 
            this.nudAutosaveMinutes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudAutosaveMinutes.Location = new System.Drawing.Point(178, 29);
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
            this.nudAutosaveMinutes.Size = new System.Drawing.Size(459, 20);
            this.nudAutosaveMinutes.TabIndex = 7;
            this.nudAutosaveMinutes.TabStop = false;
            this.nudAutosaveMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAutosaveMinutes.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // capAutosaving
            // 
            this.capAutosaving.Caption = "Autosaving";
            this.capAutosaving.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capAutosaving.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capAutosaving.Collapsed = false;
            this.capAutosaving.Collapsee = null;
            this.capAutosaving.Collapsible = false;
            this.capAutosaving.Dock = System.Windows.Forms.DockStyle.Top;
            this.capAutosaving.Location = new System.Drawing.Point(0, 75);
            this.capAutosaving.Name = "capAutosaving";
            this.capAutosaving.Size = new System.Drawing.Size(640, 30);
            this.capAutosaving.TabIndex = 24;
            // 
            // panel20
            // 
            this.panel20.AutoSize = true;
            this.panel20.Controls.Add(this.tableLayoutPanel17);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel20.Location = new System.Drawing.Point(0, 30);
            this.panel20.Name = "panel20";
            this.panel20.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.panel20.Size = new System.Drawing.Size(640, 45);
            this.panel20.TabIndex = 23;
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.AutoSize = true;
            this.tableLayoutPanel17.ColumnCount = 3;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel17.Controls.Add(this.lblTriggerTemplate, 0, 0);
            this.tableLayoutPanel17.Controls.Add(this.cbxTriggerTemplate, 1, 0);
            this.tableLayoutPanel17.Controls.Add(this.btnTriggerTemplate, 2, 0);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 2;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel17.Size = new System.Drawing.Size(640, 29);
            this.tableLayoutPanel17.TabIndex = 1;
            // 
            // lblTriggerTemplate
            // 
            this.lblTriggerTemplate.AutoEllipsis = true;
            this.lblTriggerTemplate.AutoSize = true;
            this.lblTriggerTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTriggerTemplate.Location = new System.Drawing.Point(3, 0);
            this.lblTriggerTemplate.MinimumSize = new System.Drawing.Size(150, 0);
            this.lblTriggerTemplate.Name = "lblTriggerTemplate";
            this.lblTriggerTemplate.Size = new System.Drawing.Size(185, 29);
            this.lblTriggerTemplate.TabIndex = 9;
            this.lblTriggerTemplate.Text = "Use template trigger for default values";
            this.lblTriggerTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxTriggerTemplate
            // 
            this.cbxTriggerTemplate.AutoSize = true;
            this.cbxTriggerTemplate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxTriggerTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxTriggerTemplate.Location = new System.Drawing.Point(194, 3);
            this.cbxTriggerTemplate.Name = "cbxTriggerTemplate";
            this.cbxTriggerTemplate.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cbxTriggerTemplate.Size = new System.Drawing.Size(243, 23);
            this.cbxTriggerTemplate.TabIndex = 0;
            this.cbxTriggerTemplate.TabStop = false;
            this.cbxTriggerTemplate.UseVisualStyleBackColor = true;
            // 
            // btnTriggerTemplate
            // 
            this.btnTriggerTemplate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTriggerTemplate.Location = new System.Drawing.Point(443, 3);
            this.btnTriggerTemplate.Name = "btnTriggerTemplate";
            this.btnTriggerTemplate.Size = new System.Drawing.Size(194, 23);
            this.btnTriggerTemplate.TabIndex = 1;
            this.btnTriggerTemplate.TabStop = false;
            this.btnTriggerTemplate.Text = "Edit template trigger";
            this.btnTriggerTemplate.UseVisualStyleBackColor = true;
            this.btnTriggerTemplate.Click += new System.EventHandler(this.btnTriggerTemplate_Click);
            // 
            // capTemplate
            // 
            this.capTemplate.Caption = "Templates";
            this.capTemplate.CaptionHighlightColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.capTemplate.CaptionShadowColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.capTemplate.Collapsed = false;
            this.capTemplate.Collapsee = null;
            this.capTemplate.Collapsible = false;
            this.capTemplate.Dock = System.Windows.Forms.DockStyle.Top;
            this.capTemplate.Location = new System.Drawing.Point(0, 0);
            this.capTemplate.Name = "capTemplate";
            this.capTemplate.Size = new System.Drawing.Size(640, 30);
            this.capTemplate.TabIndex = 22;
            // 
            // btnSecurity
            // 
            this.btnSecurity.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnSecurity.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnSecurity.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSecurity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecurity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSecurity.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnSecurity.IconCharacter = "d";
            this.btnSecurity.IconFont = new System.Drawing.Font("Webdings", 18F);
            this.btnSecurity.Location = new System.Drawing.Point(0, 440);
            this.btnSecurity.Name = "btnSecurity";
            this.btnSecurity.Size = new System.Drawing.Size(220, 40);
            this.btnSecurity.TabControl = this.tbcMain;
            this.btnSecurity.TabIndex = 13;
            this.btnSecurity.TabNumber = 11;
            this.btnSecurity.Text = "Security";
            this.btnSecurity.UseVisualStyleBackColor = false;
            // 
            // btnGameSpecific
            // 
            this.btnGameSpecific.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnGameSpecific.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnGameSpecific.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGameSpecific.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGameSpecific.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGameSpecific.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnGameSpecific.IconCharacter = "Ä";
            this.btnGameSpecific.IconFont = new System.Drawing.Font("Webdings", 18F);
            this.btnGameSpecific.Location = new System.Drawing.Point(0, 400);
            this.btnGameSpecific.Name = "btnGameSpecific";
            this.btnGameSpecific.Size = new System.Drawing.Size(220, 40);
            this.btnGameSpecific.TabControl = this.tbcMain;
            this.btnGameSpecific.TabIndex = 12;
            this.btnGameSpecific.TabNumber = 10;
            this.btnGameSpecific.Text = "Game-specific";
            this.btnGameSpecific.UseVisualStyleBackColor = false;
            // 
            // btnSubstitutions
            // 
            this.btnSubstitutions.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnSubstitutions.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnSubstitutions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubstitutions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubstitutions.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubstitutions.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnSubstitutions.IconCharacter = ">";
            this.btnSubstitutions.IconFont = new System.Drawing.Font("Webdings", 18F);
            this.btnSubstitutions.Location = new System.Drawing.Point(0, 360);
            this.btnSubstitutions.Name = "btnSubstitutions";
            this.btnSubstitutions.Size = new System.Drawing.Size(220, 40);
            this.btnSubstitutions.TabControl = this.tbcMain;
            this.btnSubstitutions.TabIndex = 15;
            this.btnSubstitutions.TabNumber = 9;
            this.btnSubstitutions.Text = "Substitutions";
            this.btnSubstitutions.UseVisualStyleBackColor = false;
            // 
            // btnConstants
            // 
            this.btnConstants.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnConstants.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnConstants.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConstants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConstants.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConstants.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnConstants.IconCharacter = "Ï";
            this.btnConstants.IconFont = new System.Drawing.Font("Webdings", 18F);
            this.btnConstants.Location = new System.Drawing.Point(0, 320);
            this.btnConstants.Name = "btnConstants";
            this.btnConstants.Size = new System.Drawing.Size(220, 40);
            this.btnConstants.TabControl = this.tbcMain;
            this.btnConstants.TabIndex = 11;
            this.btnConstants.TabNumber = 8;
            this.btnConstants.Text = "Constants";
            this.btnConstants.UseVisualStyleBackColor = false;
            // 
            // btnEndpoint
            // 
            this.btnEndpoint.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnEndpoint.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnEndpoint.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEndpoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndpoint.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnEndpoint.IconCharacter = "Â";
            this.btnEndpoint.IconFont = new System.Drawing.Font("Webdings", 18F);
            this.btnEndpoint.Location = new System.Drawing.Point(0, 280);
            this.btnEndpoint.Name = "btnEndpoint";
            this.btnEndpoint.Size = new System.Drawing.Size(220, 40);
            this.btnEndpoint.TabControl = this.tbcMain;
            this.btnEndpoint.TabIndex = 10;
            this.btnEndpoint.TabNumber = 7;
            this.btnEndpoint.Text = "Endpoint";
            this.btnEndpoint.UseVisualStyleBackColor = false;
            // 
            // btnUpdates
            // 
            this.btnUpdates.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnUpdates.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnUpdates.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdates.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnUpdates.IconCharacter = "q";
            this.btnUpdates.IconFont = new System.Drawing.Font("Webdings", 18F);
            this.btnUpdates.Location = new System.Drawing.Point(0, 240);
            this.btnUpdates.Name = "btnUpdates";
            this.btnUpdates.Size = new System.Drawing.Size(220, 40);
            this.btnUpdates.TabControl = this.tbcMain;
            this.btnUpdates.TabIndex = 9;
            this.btnUpdates.TabNumber = 6;
            this.btnUpdates.Text = "Updates";
            this.btnUpdates.UseVisualStyleBackColor = false;
            // 
            // btnCaching
            // 
            this.btnCaching.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnCaching.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnCaching.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCaching.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaching.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaching.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnCaching.IconCharacter = "Í";
            this.btnCaching.IconFont = new System.Drawing.Font("Webdings", 18F);
            this.btnCaching.Location = new System.Drawing.Point(0, 200);
            this.btnCaching.Name = "btnCaching";
            this.btnCaching.Size = new System.Drawing.Size(220, 40);
            this.btnCaching.TabControl = this.tbcMain;
            this.btnCaching.TabIndex = 8;
            this.btnCaching.TabNumber = 5;
            this.btnCaching.Text = "Caching";
            this.btnCaching.UseVisualStyleBackColor = false;
            // 
            // btnShortcuts
            // 
            this.btnShortcuts.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnShortcuts.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnShortcuts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShortcuts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShortcuts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShortcuts.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnShortcuts.IconCharacter = "i";
            this.btnShortcuts.IconFont = new System.Drawing.Font("Webdings", 18F);
            this.btnShortcuts.Location = new System.Drawing.Point(0, 160);
            this.btnShortcuts.Name = "btnShortcuts";
            this.btnShortcuts.Size = new System.Drawing.Size(220, 40);
            this.btnShortcuts.TabControl = this.tbcMain;
            this.btnShortcuts.TabIndex = 7;
            this.btnShortcuts.TabNumber = 4;
            this.btnShortcuts.Text = "Shortcuts";
            this.btnShortcuts.UseVisualStyleBackColor = false;
            // 
            // btnLogging
            // 
            this.btnLogging.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnLogging.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnLogging.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogging.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogging.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogging.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnLogging.IconCharacter = "¥";
            this.btnLogging.IconFont = new System.Drawing.Font("Webdings", 18F);
            this.btnLogging.Location = new System.Drawing.Point(0, 120);
            this.btnLogging.Name = "btnLogging";
            this.btnLogging.Size = new System.Drawing.Size(220, 40);
            this.btnLogging.TabControl = this.tbcMain;
            this.btnLogging.TabIndex = 6;
            this.btnLogging.TabNumber = 3;
            this.btnLogging.Text = "Logging";
            this.btnLogging.UseVisualStyleBackColor = false;
            // 
            // btnAudio
            // 
            this.btnAudio.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnAudio.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnAudio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAudio.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnAudio.IconCharacter = "X";
            this.btnAudio.IconFont = new System.Drawing.Font("Webdings", 18F);
            this.btnAudio.Location = new System.Drawing.Point(0, 80);
            this.btnAudio.Name = "btnAudio";
            this.btnAudio.Size = new System.Drawing.Size(220, 40);
            this.btnAudio.TabControl = this.tbcMain;
            this.btnAudio.TabIndex = 5;
            this.btnAudio.TabNumber = 2;
            this.btnAudio.Text = "Audio";
            this.btnAudio.UseVisualStyleBackColor = false;
            // 
            // btnUserInterface
            // 
            this.btnUserInterface.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnUserInterface.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnUserInterface.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUserInterface.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserInterface.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserInterface.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnUserInterface.IconCharacter = "2";
            this.btnUserInterface.IconFont = new System.Drawing.Font("Webdings", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnUserInterface.Location = new System.Drawing.Point(0, 40);
            this.btnUserInterface.Name = "btnUserInterface";
            this.btnUserInterface.Size = new System.Drawing.Size(220, 40);
            this.btnUserInterface.TabControl = this.tbcMain;
            this.btnUserInterface.TabIndex = 16;
            this.btnUserInterface.TabNumber = 1;
            this.btnUserInterface.Text = "User interface";
            this.btnUserInterface.UseVisualStyleBackColor = false;
            // 
            // btnStartup
            // 
            this.btnStartup.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnStartup.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnStartup.Checked = true;
            this.btnStartup.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStartup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartup.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnStartup.IconCharacter = "~";
            this.btnStartup.IconFont = new System.Drawing.Font("Webdings", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnStartup.Location = new System.Drawing.Point(0, 0);
            this.btnStartup.Name = "btnStartup";
            this.btnStartup.Size = new System.Drawing.Size(220, 40);
            this.btnStartup.TabControl = this.tbcMain;
            this.btnStartup.TabIndex = 4;
            this.btnStartup.TabNumber = 0;
            this.btnStartup.TabStop = true;
            this.btnStartup.Text = "Startup";
            this.btnStartup.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.lblHeader);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(220, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(664, 50);
            this.panel2.TabIndex = 1;
            // 
            // lblHeader
            // 
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblHeader.Size = new System.Drawing.Size(664, 50);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Configuration";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.tbcMain);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(220, 50);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(8);
            this.panel3.Size = new System.Drawing.Size(664, 561);
            this.panel3.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(220, 611);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8, 0, 8, 8);
            this.panel1.Size = new System.Drawing.Size(664, 50);
            this.panel1.TabIndex = 4;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(416, 0);
            this.btnOk.Margin = new System.Windows.Forms.Padding(8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 42);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(536, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 42);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 60000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 500;
            this.toolTip.ShowAlways = true;
            // 
            // fontDialog1
            // 
            this.fontDialog1.AllowScriptChange = false;
            // 
            // ConfigurationForm2
            // 
            this.AcceptButton = this.btnCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "ConfigurationForm2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
            this.Shown += new System.EventHandler(this.ConfigurationForm2_Shown);
            this.pnlMenu.ResumeLayout(false);
            this.tbcMain.ResumeLayout(false);
            this.tabStartup.ResumeLayout(false);
            this.tabStartup.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ctxStartupTrigger.ResumeLayout(false);
            this.tlsStartupTrigger.ResumeLayout(false);
            this.tlsStartupTrigger.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tabUserInterface.ResumeLayout(false);
            this.tabUserInterface.PerformLayout();
            this.panel32.ResumeLayout(false);
            this.panel32.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.panel31.ResumeLayout(false);
            this.panel31.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tabAudio.ResumeLayout(false);
            this.tabAudio.PerformLayout();
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbTtsRepetition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTtsVolume)).EndInit();
            this.panel21.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbSoundRepetition)).EndInit();
            this.panel30.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trbSoundVolume)).EndInit();
            this.tabLogging.ResumeLayout(false);
            this.tabLogging.PerformLayout();
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tabShortcuts.ResumeLayout(false);
            this.tabShortcuts.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.tableLayoutPanelShortCutExpression.ResumeLayout(false);
            this.tableLayoutPanelShortCutExpression.PerformLayout();
            this.tabCaching.ResumeLayout(false);
            this.tabCaching.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.tableLayoutPanelDownloads.ResumeLayout(false);
            this.tableLayoutPanelDownloads.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheFileExpiry)).EndInit();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.tableLayoutPanelRepo.ResumeLayout(false);
            this.tableLayoutPanelRepo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheRepoExpiry)).EndInit();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.tableLayoutPanelJason.ResumeLayout(false);
            this.tableLayoutPanelJason.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheJsonExpiry)).EndInit();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.tableLayoutPanelSound.ResumeLayout(false);
            this.tableLayoutPanelSound.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheSoundExpiry)).EndInit();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.tableLayoutPanelImages.ResumeLayout(false);
            this.tableLayoutPanelImages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCacheImageExpiry)).EndInit();
            this.tabUpdates.ResumeLayout(false);
            this.tabUpdates.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabEndpoint.ResumeLayout(false);
            this.tabEndpoint.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEndpointHistory)).EndInit();
            this.tlsEndpointHistory.ResumeLayout(false);
            this.tlsEndpointHistory.PerformLayout();
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.panel27.ResumeLayout(false);
            this.panel27.PerformLayout();
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel18.PerformLayout();
            this.tabConstants.ResumeLayout(false);
            this.tabConstants.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConstVariables)).EndInit();
            this.tlsConstant.ResumeLayout(false);
            this.tlsConstant.PerformLayout();
            this.tabSubs.ResumeLayout(false);
            this.tabSubs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubstitutions)).EndInit();
            this.tlsSubstitutions.ResumeLayout(false);
            this.tlsSubstitutions.PerformLayout();
            this.tabGameSpecific.ResumeLayout(false);
            this.tbcGames.ResumeLayout(false);
            this.tabFFXIV.ResumeLayout(false);
            this.tabFFXIV.PerformLayout();
            this.panel25.ResumeLayout(false);
            this.panel25.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.panel26.ResumeLayout(false);
            this.panel26.PerformLayout();
            this.tlsFfxivPartyOrder.ResumeLayout(false);
            this.tlsFfxivPartyOrder.PerformLayout();
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tabSecurity.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdditionalFeatures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApiAccess)).EndInit();
            this.tabMiscellaneous.ResumeLayout(false);
            this.tabMiscellaneous.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutosaveMinutes)).EndInit();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tabStartup;
        private System.Windows.Forms.TabPage tabAudio;
        private System.Windows.Forms.Panel panel3;
        private CustomControls.MenuButton btnLogging;
        private CustomControls.MenuButton btnAudio;
        private CustomControls.MenuButton btnStartup;
        private CustomControls.MenuButton btnConstants;
        private CustomControls.MenuButton btnEndpoint;
        private CustomControls.MenuButton btnUpdates;
        private CustomControls.MenuButton btnCaching;
        private CustomControls.MenuButton btnShortcuts;
        private CustomControls.MenuButton btnMisc;
        private CustomControls.MenuButton btnSecurity;
        private CustomControls.MenuButton btnGameSpecific;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabPage tabLogging;
        private System.Windows.Forms.TabPage tabShortcuts;
        private System.Windows.Forms.TabPage tabCaching;
        private System.Windows.Forms.TabPage tabUpdates;
        private System.Windows.Forms.TabPage tabEndpoint;
        private System.Windows.Forms.TabPage tabConstants;
        private System.Windows.Forms.TabPage tabGameSpecific;
        private System.Windows.Forms.TabPage tabSecurity;
        private System.Windows.Forms.TabPage tabMiscellaneous;
        private System.Windows.Forms.TabPage tabSubs;
        private CustomControls.MenuButton btnSubstitutions;
        private CustomControls.DataGridViewEx dgvConstVariables;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScalarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScalarValue;
        private System.Windows.Forms.ToolStrip tlsConstant;
        private System.Windows.Forms.ToolStripButton btnConstAdd;
        private System.Windows.Forms.ToolStripButton btnConstEdit;
        private System.Windows.Forms.ToolStripButton btnConstRemove;
        private CustomControls.PrettyCaption capStartupTrigger;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.CheckBox chkWarnAdmin;
        private System.Windows.Forms.CheckBox chkUpdates;
        private System.Windows.Forms.CheckBox chkWelcome;
        private CustomControls.PrettyCaption capStartupOptions;
        private System.Windows.Forms.Panel panel9;
        internal System.Windows.Forms.TreeView trvTrigger;
        private System.Windows.Forms.ToolStrip tlsStartupTrigger;
        private System.Windows.Forms.ToolStripButton btnClearSelection;
        private System.Windows.Forms.ToolStripLabel lblFolderReminder;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomControls.PrettyCaption prettyCaption1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelShortCutExpression;
        private System.Windows.Forms.CheckBox chkShortcutEnableTemplates;
        private System.Windows.Forms.CheckBox chkShortcutUseAbbrevInTemplates;
        private System.Windows.Forms.CheckBox chkShortcutWrapTextWhenSelected;
        private CustomControls.PrettyCaption capExpressions;
        private CustomControls.PrettyCaption capImageFiles;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelImages;
        private System.Windows.Forms.Button btnCacheImageBrowse;
        private System.Windows.Forms.TextBox txtCacheImageSize;
        private System.Windows.Forms.Label lblCacheImageSize;
        private System.Windows.Forms.Label lblCacheImageCount;
        private System.Windows.Forms.Label lblCacheImageExpiry;
        private System.Windows.Forms.NumericUpDown nudCacheImageExpiry;
        private System.Windows.Forms.TextBox txtCacheImageCount;
        private System.Windows.Forms.Button btnCacheImageClear;
        private CustomControls.PrettyCaption capSoundFiles;
        private System.Windows.Forms.Panel panel13;
        private CustomControls.PrettyCaption capJason;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSound;
        private System.Windows.Forms.Button btnCacheSoundBrowse;
        private System.Windows.Forms.Button btnCacheSoundClear;
        private System.Windows.Forms.TextBox txtCacheSoundSize;
        private System.Windows.Forms.Label lblCacheSoundSize;
        private System.Windows.Forms.Label lblCacheSoundCount;
        private System.Windows.Forms.Label lblCacheSoundExpiry;
        private System.Windows.Forms.NumericUpDown nudCacheSoundExpiry;
        private System.Windows.Forms.TextBox txtCacheSoundCount;
        private System.Windows.Forms.Panel panel15;
        private CustomControls.PrettyCaption capRepoBackups;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelJason;
        private System.Windows.Forms.NumericUpDown nudCacheJsonExpiry;
        private System.Windows.Forms.Button btnCacheJsonBrowse;
        private System.Windows.Forms.Button btnCacheJsonClear;
        private System.Windows.Forms.TextBox txtCacheJsonSize;
        private System.Windows.Forms.Label lblCacheJsonSize;
        private System.Windows.Forms.Label lblCacheJsonCount;
        private System.Windows.Forms.Label lblCacheJsonExpiry;
        private System.Windows.Forms.TextBox txtCacheJsonCount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRepo;
        private System.Windows.Forms.Button btnCacheRepoBrowse;
        private System.Windows.Forms.Button btnCacheRepoClear;
        private System.Windows.Forms.TextBox txtCacheRepoSize;
        private System.Windows.Forms.Label lblCacheRepoSize;
        private System.Windows.Forms.Label lblCacheRepoCount;
        private System.Windows.Forms.Label lblCacheRepoExpiry;
        private System.Windows.Forms.NumericUpDown nudCacheRepoExpiry;
        private System.Windows.Forms.TextBox txtCacheRepoCount;
        private System.Windows.Forms.Panel panel17;
        private CustomControls.PrettyCaption capDownloads;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDownloads;
        private System.Windows.Forms.Button btnCacheFileBrowse;
        private System.Windows.Forms.Button btnCacheFileClear;
        private System.Windows.Forms.TextBox txtCacheFileSize;
        private System.Windows.Forms.Label lblCacheFileSize;
        private System.Windows.Forms.Label lblCacheFileCount;
        private System.Windows.Forms.Label lblCacheFileExpiry;
        private System.Windows.Forms.NumericUpDown nudCacheFileExpiry;
        private System.Windows.Forms.TextBox txtCacheFileCount;
        private System.Windows.Forms.Panel panel19;
        private CustomControls.DataGridViewEx dgvAdditionalFeatures;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.Panel panel8;
        private CustomControls.DataGridViewEx dgvApiAccess;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Button btnUnlockSecurity;
        private CustomControls.PrettyCaption capScripting;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblTtsVolP;
        private System.Windows.Forms.TrackBar trbTtsVolume;
        private System.Windows.Forms.Label lblTtsVolume;
        private CustomControls.PrettyCaption prettyCaption2;
        private System.Windows.Forms.Label lblSoundVolP;
        private System.Windows.Forms.TrackBar trbSoundVolume;
        private System.Windows.Forms.Label lblSoundVolume;
        private System.Windows.Forms.Label lblTtsMethod;
        private System.Windows.Forms.Label lblSoundPath;
        private System.Windows.Forms.Label lblSoundMethod;
        private System.Windows.Forms.ComboBox cbxSoundMethod;
        private System.Windows.Forms.Button btnSoundPath;
        private System.Windows.Forms.TextBox txtSoundPath;
        private System.Windows.Forms.Button btnTtsPath;
        private System.Windows.Forms.TextBox txtTtsPath;
        private System.Windows.Forms.ComboBox cbxTtsMethod;
        private System.Windows.Forms.Label lblTtsPath;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtUpdateChannelUri;
        private System.Windows.Forms.ComboBox cbxUpdateMethod;
        private System.Windows.Forms.Label lblUpdateChannelUri;
        private System.Windows.Forms.Label lblUpdateMethod;
        private CustomControls.PrettyCaption capUpdateChannel;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox chkLogNormalEvents;
        private System.Windows.Forms.Label lblLoggingLevel;
        private System.Windows.Forms.ComboBox cbxLoggingLevel;
        private CustomControls.PrettyCaption capLogging;
        private System.Windows.Forms.TabControl tbcGames;
        private System.Windows.Forms.TabPage tabFFXIV;
        private CustomControls.PrettyCaption capFfxivLogging;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.CheckBox chkFfxivLogNetwork;
        private System.Windows.Forms.Panel panel25;
        private CustomControls.PrettyCaption capFfxivPartyOrder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblFfxivJobOrder;
        private System.Windows.Forms.Label lblFfxivJobMethod;
        private System.Windows.Forms.ComboBox cbxFfxivJobMethod;
        private System.Windows.Forms.Panel panel26;
        private System.Windows.Forms.ListBox lstFfxivJobOrder;
        private System.Windows.Forms.ToolStrip tlsFfxivPartyOrder;
        private System.Windows.Forms.ToolStripButton btnFfxivJobUp;
        private System.Windows.Forms.ToolStripButton btnFfxivJobDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFfxivJobRestore;
        private System.Windows.Forms.Panel panel7;
        private CustomControls.DataGridViewEx dgvEndpointHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.ToolStrip tlsEndpointHistory;
        private System.Windows.Forms.ToolStripButton btnEndpointHistUpdate;
        private System.Windows.Forms.ToolStripLabel tlsEndpointHistoryRecv;
        private System.Windows.Forms.ToolStripLabel tlsEndpointHistoryCount;
        private CustomControls.PrettyCaption prettyCaption3;
        private System.Windows.Forms.Panel panel28;
        private CustomControls.PrettyCaption capEndpointSettings;
        private System.Windows.Forms.Panel panel27;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.Button btnEndpointStart;
        private System.Windows.Forms.Button btnEndpointStop;
        private System.Windows.Forms.TextBox txtEndpointStatus;
        private CustomControls.PrettyCaption capEndpointStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.CheckBox chkEndpointStartup;
        private System.Windows.Forms.CheckBox chkEndpointLog;
        private System.Windows.Forms.TextBox txtEndpoint;
        private System.Windows.Forms.Label lblEndpoint;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.CheckBox cbxTriggerTemplate;
        private System.Windows.Forms.Button btnTriggerTemplate;
        private CustomControls.PrettyCaption capTemplate;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TextBox txtMonitorWindow;
        private System.Windows.Forms.Label lblMonitorWindow;
        private System.Windows.Forms.CheckBox cbxEnableHwAccel;
        private CustomControls.PrettyCaption capAuraManagement;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label lblAutosaveInterval;
        private System.Windows.Forms.CheckBox cbxAutosaveConfig;
        private System.Windows.Forms.NumericUpDown nudAutosaveMinutes;
        private CustomControls.PrettyCaption capAutosaving;
        private System.Windows.Forms.Panel panel30;
        private System.Windows.Forms.Label lblExternalSoundWarn;
        private CustomControls.DataGridViewEx dgvSubstitutions;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ToolStrip tlsSubstitutions;
        private System.Windows.Forms.ToolStripButton btnSubAdd;
        private System.Windows.Forms.ToolStripButton btnSubEdit;
        private System.Windows.Forms.ToolStripButton btnSubRemove;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ContextMenuStrip ctxStartupTrigger;
        private System.Windows.Forms.ToolStripMenuItem ctxClearSelection;
        private System.Windows.Forms.Label lblExternalUpdateWarn;
        private System.Windows.Forms.TextBox txtTtsPathArgs;
        private System.Windows.Forms.Label lblTtsPathArgs;
        private System.Windows.Forms.TextBox txtSoundPathArgs;
        private System.Windows.Forms.Label lblSoundPathArgs;
        private CustomControls.MenuButton btnUserInterface;
        private System.Windows.Forms.TabPage tabUserInterface;
        private System.Windows.Forms.Panel panel31;
        private CustomControls.PrettyCaption capAppearance;
        private System.Windows.Forms.Panel panel32;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private CustomControls.PrettyCaption capBehavior;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.CheckBox cbxUiFontDefault;
        private System.Windows.Forms.Label lblUiFont;
        private System.Windows.Forms.TextBox txtUiFontDesc;
        private System.Windows.Forms.Button btnUiFont;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.CheckBox cbxAutoComplete;
        private System.Windows.Forms.CheckBox cbxDevMode;
        private System.Windows.Forms.CheckBox cbxActionAsync;
        private System.Windows.Forms.CheckBox cbxTestIgnoreConditions;
        private System.Windows.Forms.CheckBox cbxTestLive;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Label lblExternalTtsWarn;
        private System.Windows.Forms.Label lblActTtsWarn;
        private System.Windows.Forms.Label lblLogNormalEvents;
        private System.Windows.Forms.Label lblLogVariableExpansions;
        private System.Windows.Forms.CheckBox chkLogVariableExpansions;
        private System.Windows.Forms.Label lblUiFontDefault;
        private System.Windows.Forms.Label lblDevMode;
        private System.Windows.Forms.Label lblAutoComplete;
        private System.Windows.Forms.Label lblActionAsync;
        private System.Windows.Forms.Label lblTestIgnoreConditions;
        private System.Windows.Forms.Label lblTestLive;
        private System.Windows.Forms.Label lblUpdates;
        private System.Windows.Forms.Label lblWarnAdmin;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblShortcutWrapTextWhenSelected;
        private System.Windows.Forms.Label lblShortcutUseAbbrevInTemplates;
        private System.Windows.Forms.Label lblShortcutEnableTemplates;
        private System.Windows.Forms.Label lblEndpointStartup;
        private System.Windows.Forms.Label lblEndpointLog;
        private System.Windows.Forms.Label lblFfxivLogNetwork;
        private System.Windows.Forms.Label lblEnableHwAccel;
        private System.Windows.Forms.Label lblAutosaveConfig;
        private System.Windows.Forms.Label lblTriggerTemplate;
        private System.Windows.Forms.Button btnUpdateCheck;
        private System.Windows.Forms.Label lblSoundRepetition;
        private System.Windows.Forms.TrackBar trbTtsRepetition;
        private System.Windows.Forms.Label lblTtsRepetition;
        private System.Windows.Forms.Label lblSoundRepV;
        private System.Windows.Forms.TrackBar trbSoundRepetition;
        private System.Windows.Forms.Label lblTtsRepV;
    }
}