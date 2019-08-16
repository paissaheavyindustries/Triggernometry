namespace Triggernometry.Forms
{
    partial class ActionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblActionType = new System.Windows.Forms.Label();
            this.cbxActionType = new System.Windows.Forms.ComboBox();
            this.grpGeneralSettings = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbcActionSettings = new System.Windows.Forms.TabControl();
            this.tabSystemBeep = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.expBeepLength = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expBeepFrequency = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblBeepLength = new System.Windows.Forms.Label();
            this.lblBeepFrequency = new System.Windows.Forms.Label();
            this.tabPlaySoundFile = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.chkSoundMyOutput = new System.Windows.Forms.CheckBox();
            this.chkSoundExclusive = new System.Windows.Forms.CheckBox();
            this.expSoundVolume = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblSoundVolume = new System.Windows.Forms.Label();
            this.lblSoundFile = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.expSoundFile = new Triggernometry.CustomControls.ExpressionTextBox();
            this.tabTextToSpeech = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.chkSpeechMyOutput = new System.Windows.Forms.CheckBox();
            this.chkSpeechExclusive = new System.Windows.Forms.CheckBox();
            this.expSpeechRate = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblSpeechRate = new System.Windows.Forms.Label();
            this.expSpeechVolume = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblSpeechVolume = new System.Windows.Forms.Label();
            this.lblTextToSay = new System.Windows.Forms.Label();
            this.expTextToSay = new Triggernometry.CustomControls.ExpressionTextBox();
            this.tabLaunchProcess = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxProcessWindowStyle = new System.Windows.Forms.ComboBox();
            this.lblProcessWindowStyle = new System.Windows.Forms.Label();
            this.expProcessWorkingDir = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblProcessWorkingDir = new System.Windows.Forms.Label();
            this.expProcessParameters = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblProcessParameters = new System.Windows.Forms.Label();
            this.lblProcessName = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.expProcessName = new Triggernometry.CustomControls.ExpressionTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblProcessWarning = new System.Windows.Forms.Label();
            this.tabTriggerOperation = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFiringOptions = new System.Windows.Forms.Label();
            this.expTriggerZone = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTriggerZone = new System.Windows.Forms.Label();
            this.lblTrigger = new System.Windows.Forms.Label();
            this.expTriggerText = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTriggerText = new System.Windows.Forms.Label();
            this.lblTriggerOp = new System.Windows.Forms.Label();
            this.cbxTriggerOp = new System.Windows.Forms.ComboBox();
            this.trvTrigger = new System.Windows.Forms.TreeView();
            this.cbxFiringOptions = new System.Windows.Forms.CheckedListBox();
            this.tabKeypress = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnKeycodesLink = new System.Windows.Forms.Button();
            this.txtKeyCodesLink = new System.Windows.Forms.TextBox();
            this.lblKeypressInfo = new System.Windows.Forms.Label();
            this.expKeypress = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expWindowTitle = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblKeypress = new System.Windows.Forms.Label();
            this.lblKeypressWindow = new System.Windows.Forms.Label();
            this.cbxKeypressMethod = new System.Windows.Forms.ComboBox();
            this.lblKeypressMethod = new System.Windows.Forms.Label();
            this.btnSendKeysLink = new System.Windows.Forms.Button();
            this.lblKeypresses = new System.Windows.Forms.Label();
            this.expKeypresses = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblKeypressesInfo = new System.Windows.Forms.Label();
            this.txtSendKeysLink = new System.Windows.Forms.TextBox();
            this.tabScript = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.expExecScriptAssemblies = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblExecScriptAssemblies = new System.Windows.Forms.Label();
            this.expExecScriptCode = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblExecScriptCode = new System.Windows.Forms.Label();
            this.lblExecScriptLang = new System.Windows.Forms.Label();
            this.cbxExecScriptLang = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblScriptWarning = new System.Windows.Forms.Label();
            this.tabMessageBox = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.expMessageBoxText = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblMessageBoxText = new System.Windows.Forms.Label();
            this.lblMessageBoxIcon = new System.Windows.Forms.Label();
            this.cbxMessageBoxIcon = new System.Windows.Forms.ComboBox();
            this.tabVariable = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.expVariableExpression = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblVariableExpression = new System.Windows.Forms.Label();
            this.expVariableName = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblVariableName = new System.Windows.Forms.Label();
            this.lblVariableOp = new System.Windows.Forms.Label();
            this.cbxVariableOp = new System.Windows.Forms.ComboBox();
            this.tabImageAura = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.btnHide = new System.Windows.Forms.Button();
            this.cbxAuraDisplay = new System.Windows.Forms.ComboBox();
            this.lblAuraDisplay = new System.Windows.Forms.Label();
            this.expAuraTTLTick = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expAuraOTick = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expAuraHTick = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expAuraWTick = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expAuraYTick = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expAuraXTick = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblUpdateTickExp = new System.Windows.Forms.Label();
            this.expAuraOIni = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expAuraHIni = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expAuraWIni = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblAuraTtl = new System.Windows.Forms.Label();
            this.lblAuraOpacity = new System.Windows.Forms.Label();
            this.lblAuraWidth = new System.Windows.Forms.Label();
            this.lblAuraHeight = new System.Windows.Forms.Label();
            this.btnBrowseAura = new System.Windows.Forms.Button();
            this.expAuraImage = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblAuraImage = new System.Windows.Forms.Label();
            this.expAuraYIni = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblAuraY = new System.Windows.Forms.Label();
            this.expAuraXIni = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblAuraX = new System.Windows.Forms.Label();
            this.expAuraName = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblAuraName = new System.Windows.Forms.Label();
            this.lblAuraOp = new System.Windows.Forms.Label();
            this.cbxAuraOp = new System.Windows.Forms.ComboBox();
            this.lblInitialValues = new System.Windows.Forms.Label();
            this.btnAuraGuide = new System.Windows.Forms.Button();
            this.tabFolderOperation = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFolder = new System.Windows.Forms.Label();
            this.lblFolderOp = new System.Windows.Forms.Label();
            this.cbxFolderOp = new System.Windows.Forms.ComboBox();
            this.trvFolder = new System.Windows.Forms.TreeView();
            this.tabEndEncounter = new System.Windows.Forms.TabPage();
            this.lblEndEncNoParams = new System.Windows.Forms.Label();
            this.tabDiscordWebhook = new System.Windows.Forms.TabPage();
            this.discordTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.cbxDiscordTts = new System.Windows.Forms.CheckBox();
            this.expDiscordMessage = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblDiscordMessage = new System.Windows.Forms.Label();
            this.lblDiscordUrl = new System.Windows.Forms.Label();
            this.expDiscordUrl = new Triggernometry.CustomControls.ExpressionTextBox();
            this.tabTextAura = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTextAuraOutline = new System.Windows.Forms.Label();
            this.btnTextAuraFont = new System.Windows.Forms.Button();
            this.lblTextAuraFont = new System.Windows.Forms.Label();
            this.btnTextAuraHide = new System.Windows.Forms.Button();
            this.cbxTextAuraAlignment = new System.Windows.Forms.ComboBox();
            this.lblTextAuraAlignment = new System.Windows.Forms.Label();
            this.expTextAuraTTLTick = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expTextAuraOTick = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expTextAuraHTick = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expTextAuraWTick = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expTextAuraYTick = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expTextAuraXTick = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTextAuraUpdValues = new System.Windows.Forms.Label();
            this.expTextAuraOIni = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expTextAuraHIni = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expTextAuraWIni = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTextAuraTtlExp = new System.Windows.Forms.Label();
            this.lblTextAuraOpacity = new System.Windows.Forms.Label();
            this.lblTextAuraWidth = new System.Windows.Forms.Label();
            this.lblTextAuraHeight = new System.Windows.Forms.Label();
            this.expTextAuraText = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTextAuraText = new System.Windows.Forms.Label();
            this.expTextAuraYIni = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTextAuraY = new System.Windows.Forms.Label();
            this.expTextAuraXIni = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTextAuraX = new System.Windows.Forms.Label();
            this.expTextAuraName = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTextAuraName = new System.Windows.Forms.Label();
            this.lblTextAuraOp = new System.Windows.Forms.Label();
            this.cbxTextAuraOp = new System.Windows.Forms.ComboBox();
            this.lblTextAuraIniValues = new System.Windows.Forms.Label();
            this.btnTextAuraGuide = new System.Windows.Forms.Button();
            this.txtTextAuraFont = new System.Windows.Forms.TextBox();
            this.colorSelector1 = new Triggernometry.CustomControls.ColorSelector();
            this.cbxTextAuraOutline = new System.Windows.Forms.CheckBox();
            this.tabLogMessage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxProcessLog = new System.Windows.Forms.CheckBox();
            this.lblLogMessageText = new System.Windows.Forms.Label();
            this.expLogMessageText = new Triggernometry.CustomControls.ExpressionTextBox();
            this.tabListVariable = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxLvarExpType = new System.Windows.Forms.ComboBox();
            this.lblLvarExpType = new System.Windows.Forms.Label();
            this.expLvarTarget = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblLvarTarget = new System.Windows.Forms.Label();
            this.expLvarIndex = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblLvarIndex = new System.Windows.Forms.Label();
            this.expLvarValue = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblLvarValue = new System.Windows.Forms.Label();
            this.expLvarName = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblLvarName = new System.Windows.Forms.Label();
            this.lblLvarOperation = new System.Windows.Forms.Label();
            this.cbxLvarOperation = new System.Windows.Forms.ComboBox();
            this.tabObsControl = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.expObsSourceName = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblObsSourceName = new System.Windows.Forms.Label();
            this.cbxObsOpType = new System.Windows.Forms.ComboBox();
            this.lblObsOpType = new System.Windows.Forms.Label();
            this.btnObsWebsocketLink = new System.Windows.Forms.Button();
            this.lblObsSceneName = new System.Windows.Forms.Label();
            this.expObsSceneName = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblObsWebsocketInfo = new System.Windows.Forms.Label();
            this.txtObsWebsocketLink = new System.Windows.Forms.TextBox();
            this.tabGenericJson = new System.Windows.Forms.TabPage();
            this.jsonTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblJsonInstructions = new System.Windows.Forms.Label();
            this.expJsonFiring = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblJsonFiring = new System.Windows.Forms.Label();
            this.expJsonPayload = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblJsonPayload = new System.Windows.Forms.Label();
            this.lblJsonEndpoint = new System.Windows.Forms.Label();
            this.expJsonEndpoint = new Triggernometry.CustomControls.ExpressionTextBox();
            this.tabWindowMessage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.expWmsgLparam = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblWmsgLparam = new System.Windows.Forms.Label();
            this.expWmsgWparam = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblWmsgWparam = new System.Windows.Forms.Label();
            this.expWmsgCode = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expWmsgTitle = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblWmsgCode = new System.Windows.Forms.Label();
            this.lblWmsgTitle = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblWmsgWarning = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnTest = new Triggernometry.CustomControls.SplitButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbcAction = new System.Windows.Forms.TabControl();
            this.tabActionSettings = new System.Windows.Forms.TabPage();
            this.tabActionCondition = new System.Windows.Forms.TabPage();
            this.cndCondition = new Triggernometry.CustomControls.ConditionViewer();
            this.tabScheduling = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.chkExecuteAsync = new System.Windows.Forms.CheckBox();
            this.lblExecutionDelay = new System.Windows.Forms.Label();
            this.cbxRefireOption2 = new System.Windows.Forms.ComboBox();
            this.cbxRefireOption1 = new System.Windows.Forms.ComboBox();
            this.lblRefireOption1 = new System.Windows.Forms.Label();
            this.expExecutionDelay = new Triggernometry.CustomControls.ExpressionTextBox();
            this.tabDebugging = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxLoggingLevel = new System.Windows.Forms.ComboBox();
            this.lblLoggingLevel = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.expressionTextBox1 = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expressionTextBox2 = new Triggernometry.CustomControls.ExpressionTextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblReadOnly = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpGeneralSettings.SuspendLayout();
            this.tbcActionSettings.SuspendLayout();
            this.tabSystemBeep.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPlaySoundFile.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabTextToSpeech.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabLaunchProcess.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabTriggerOperation.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tabKeypress.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tabScript.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabMessageBox.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tabVariable.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tabImageAura.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tabFolderOperation.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tabEndEncounter.SuspendLayout();
            this.tabDiscordWebhook.SuspendLayout();
            this.discordTableLayout.SuspendLayout();
            this.tabTextAura.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.tabLogMessage.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.tabListVariable.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.tabObsControl.SuspendLayout();
            this.tableLayoutPanel18.SuspendLayout();
            this.tabGenericJson.SuspendLayout();
            this.jsonTableLayout.SuspendLayout();
            this.tabWindowMessage.SuspendLayout();
            this.tableLayoutPanel19.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tbcAction.SuspendLayout();
            this.tabActionSettings.SuspendLayout();
            this.tabActionCondition.SuspendLayout();
            this.tabScheduling.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.tabDebugging.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.lblActionType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxActionType, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(544, 27);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblActionType
            // 
            this.lblActionType.AutoSize = true;
            this.lblActionType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActionType.Location = new System.Drawing.Point(3, 0);
            this.lblActionType.Name = "lblActionType";
            this.lblActionType.Size = new System.Drawing.Size(60, 27);
            this.lblActionType.TabIndex = 0;
            this.lblActionType.Text = "Action type";
            this.lblActionType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxActionType
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbxActionType, 2);
            this.cbxActionType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxActionType.FormattingEnabled = true;
            this.cbxActionType.Items.AddRange(new object[] {
            "System beep",
            "Play sound file",
            "Use text-to-speech",
            "Launch process",
            "Trigger operation",
            "Send keypresses to active window",
            "Execute script",
            "Show message box",
            "Scalar variable operation",
            "Image aura operation",
            "Folder operation",
            "End encounter",
            "Discord webhook",
            "Text aura operation",
            "Log message",
            "List variable operation",
            "OBS remote control operation",
            "Generic JSON operation",
            "Send window message"});
            this.cbxActionType.Location = new System.Drawing.Point(69, 3);
            this.cbxActionType.Name = "cbxActionType";
            this.cbxActionType.Size = new System.Drawing.Size(472, 21);
            this.cbxActionType.TabIndex = 1;
            this.cbxActionType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // grpGeneralSettings
            // 
            this.grpGeneralSettings.AutoSize = true;
            this.grpGeneralSettings.Controls.Add(this.tableLayoutPanel1);
            this.grpGeneralSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGeneralSettings.Location = new System.Drawing.Point(10, 10);
            this.grpGeneralSettings.Name = "grpGeneralSettings";
            this.grpGeneralSettings.Padding = new System.Windows.Forms.Padding(10);
            this.grpGeneralSettings.Size = new System.Drawing.Size(564, 60);
            this.grpGeneralSettings.TabIndex = 1;
            this.grpGeneralSettings.TabStop = false;
            this.grpGeneralSettings.Text = " General settings ";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 10);
            this.panel1.TabIndex = 3;
            // 
            // tbcActionSettings
            // 
            this.tbcActionSettings.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbcActionSettings.Controls.Add(this.tabSystemBeep);
            this.tbcActionSettings.Controls.Add(this.tabPlaySoundFile);
            this.tbcActionSettings.Controls.Add(this.tabTextToSpeech);
            this.tbcActionSettings.Controls.Add(this.tabLaunchProcess);
            this.tbcActionSettings.Controls.Add(this.tabTriggerOperation);
            this.tbcActionSettings.Controls.Add(this.tabKeypress);
            this.tbcActionSettings.Controls.Add(this.tabScript);
            this.tbcActionSettings.Controls.Add(this.tabMessageBox);
            this.tbcActionSettings.Controls.Add(this.tabVariable);
            this.tbcActionSettings.Controls.Add(this.tabImageAura);
            this.tbcActionSettings.Controls.Add(this.tabFolderOperation);
            this.tbcActionSettings.Controls.Add(this.tabEndEncounter);
            this.tbcActionSettings.Controls.Add(this.tabDiscordWebhook);
            this.tbcActionSettings.Controls.Add(this.tabTextAura);
            this.tbcActionSettings.Controls.Add(this.tabLogMessage);
            this.tbcActionSettings.Controls.Add(this.tabListVariable);
            this.tbcActionSettings.Controls.Add(this.tabObsControl);
            this.tbcActionSettings.Controls.Add(this.tabGenericJson);
            this.tbcActionSettings.Controls.Add(this.tabWindowMessage);
            this.tbcActionSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcActionSettings.Location = new System.Drawing.Point(3, 3);
            this.tbcActionSettings.Margin = new System.Windows.Forms.Padding(0);
            this.tbcActionSettings.Name = "tbcActionSettings";
            this.tbcActionSettings.SelectedIndex = 0;
            this.tbcActionSettings.Size = new System.Drawing.Size(550, 293);
            this.tbcActionSettings.TabIndex = 0;
            // 
            // tabSystemBeep
            // 
            this.tabSystemBeep.AutoScroll = true;
            this.tabSystemBeep.Controls.Add(this.tableLayoutPanel2);
            this.tabSystemBeep.Location = new System.Drawing.Point(4, 25);
            this.tabSystemBeep.Margin = new System.Windows.Forms.Padding(0);
            this.tabSystemBeep.Name = "tabSystemBeep";
            this.tabSystemBeep.Size = new System.Drawing.Size(542, 264);
            this.tabSystemBeep.TabIndex = 0;
            this.tabSystemBeep.Text = "System beep";
            this.tabSystemBeep.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.expBeepLength, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.expBeepFrequency, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblBeepLength, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblBeepFrequency, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(542, 52);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // expBeepLength
            // 
            this.expBeepLength.AutoSize = true;
            this.expBeepLength.Dock = System.Windows.Forms.DockStyle.Top;
            this.expBeepLength.Expression = "";
            this.expBeepLength.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expBeepLength.Location = new System.Drawing.Point(111, 29);
            this.expBeepLength.Name = "expBeepLength";
            this.expBeepLength.Size = new System.Drawing.Size(428, 20);
            this.expBeepLength.TabIndex = 13;
            // 
            // expBeepFrequency
            // 
            this.expBeepFrequency.AutoSize = true;
            this.expBeepFrequency.Dock = System.Windows.Forms.DockStyle.Top;
            this.expBeepFrequency.Expression = "";
            this.expBeepFrequency.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expBeepFrequency.Location = new System.Drawing.Point(111, 3);
            this.expBeepFrequency.Name = "expBeepFrequency";
            this.expBeepFrequency.Size = new System.Drawing.Size(428, 20);
            this.expBeepFrequency.TabIndex = 12;
            // 
            // lblBeepLength
            // 
            this.lblBeepLength.AutoSize = true;
            this.lblBeepLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBeepLength.Location = new System.Drawing.Point(3, 26);
            this.lblBeepLength.Name = "lblBeepLength";
            this.lblBeepLength.Size = new System.Drawing.Size(102, 26);
            this.lblBeepLength.TabIndex = 9;
            this.lblBeepLength.Text = "Beep length (ms)";
            this.lblBeepLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBeepFrequency
            // 
            this.lblBeepFrequency.AutoSize = true;
            this.lblBeepFrequency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBeepFrequency.Location = new System.Drawing.Point(3, 0);
            this.lblBeepFrequency.Name = "lblBeepFrequency";
            this.lblBeepFrequency.Size = new System.Drawing.Size(102, 26);
            this.lblBeepFrequency.TabIndex = 7;
            this.lblBeepFrequency.Text = "Beep frequency (hz)";
            this.lblBeepFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPlaySoundFile
            // 
            this.tabPlaySoundFile.AutoScroll = true;
            this.tabPlaySoundFile.Controls.Add(this.tableLayoutPanel3);
            this.tabPlaySoundFile.Location = new System.Drawing.Point(4, 25);
            this.tabPlaySoundFile.Margin = new System.Windows.Forms.Padding(0);
            this.tabPlaySoundFile.Name = "tabPlaySoundFile";
            this.tabPlaySoundFile.Size = new System.Drawing.Size(542, 315);
            this.tabPlaySoundFile.TabIndex = 1;
            this.tabPlaySoundFile.Text = "Play sound file";
            this.tabPlaySoundFile.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.Controls.Add(this.chkSoundMyOutput, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.chkSoundExclusive, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.expSoundVolume, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblSoundVolume, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblSoundFile, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.button3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.expSoundFile, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(542, 106);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // chkSoundMyOutput
            // 
            this.chkSoundMyOutput.AutoSize = true;
            this.chkSoundMyOutput.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel3.SetColumnSpan(this.chkSoundMyOutput, 3);
            this.chkSoundMyOutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkSoundMyOutput.Location = new System.Drawing.Point(3, 84);
            this.chkSoundMyOutput.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkSoundMyOutput.Name = "chkSoundMyOutput";
            this.chkSoundMyOutput.Size = new System.Drawing.Size(537, 17);
            this.chkSoundMyOutput.TabIndex = 20;
            this.chkSoundMyOutput.Text = "Use Triggernometry for output regardless of ACT hook configuration";
            this.chkSoundMyOutput.UseVisualStyleBackColor = true;
            // 
            // chkSoundExclusive
            // 
            this.chkSoundExclusive.AutoSize = true;
            this.chkSoundExclusive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel3.SetColumnSpan(this.chkSoundExclusive, 3);
            this.chkSoundExclusive.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkSoundExclusive.Location = new System.Drawing.Point(3, 57);
            this.chkSoundExclusive.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkSoundExclusive.Name = "chkSoundExclusive";
            this.chkSoundExclusive.Size = new System.Drawing.Size(537, 17);
            this.chkSoundExclusive.TabIndex = 17;
            this.chkSoundExclusive.Text = "Use exclusive sound player to prevent conflicts with other sounds";
            this.chkSoundExclusive.UseVisualStyleBackColor = true;
            // 
            // expSoundVolume
            // 
            this.expSoundVolume.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.expSoundVolume, 2);
            this.expSoundVolume.Dock = System.Windows.Forms.DockStyle.Top;
            this.expSoundVolume.Expression = "";
            this.expSoundVolume.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expSoundVolume.Location = new System.Drawing.Point(143, 29);
            this.expSoundVolume.Name = "expSoundVolume";
            this.expSoundVolume.Size = new System.Drawing.Size(396, 20);
            this.expSoundVolume.TabIndex = 16;
            // 
            // lblSoundVolume
            // 
            this.lblSoundVolume.AutoSize = true;
            this.lblSoundVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoundVolume.Location = new System.Drawing.Point(3, 26);
            this.lblSoundVolume.Name = "lblSoundVolume";
            this.lblSoundVolume.Size = new System.Drawing.Size(134, 26);
            this.lblSoundVolume.TabIndex = 15;
            this.lblSoundVolume.Text = "Sound volume (0 ... 100 %)";
            this.lblSoundVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSoundFile
            // 
            this.lblSoundFile.AutoSize = true;
            this.lblSoundFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoundFile.Location = new System.Drawing.Point(3, 0);
            this.lblSoundFile.Name = "lblSoundFile";
            this.lblSoundFile.Size = new System.Drawing.Size(134, 26);
            this.lblSoundFile.TabIndex = 7;
            this.lblSoundFile.Text = "Sound file to play";
            this.lblSoundFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(502, 0);
            this.button3.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(37, 26);
            this.button3.TabIndex = 13;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // expSoundFile
            // 
            this.expSoundFile.AutoSize = true;
            this.expSoundFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.expSoundFile.Expression = "";
            this.expSoundFile.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expSoundFile.Location = new System.Drawing.Point(143, 3);
            this.expSoundFile.Name = "expSoundFile";
            this.expSoundFile.Size = new System.Drawing.Size(356, 20);
            this.expSoundFile.TabIndex = 14;
            // 
            // tabTextToSpeech
            // 
            this.tabTextToSpeech.AutoScroll = true;
            this.tabTextToSpeech.Controls.Add(this.tableLayoutPanel4);
            this.tabTextToSpeech.Location = new System.Drawing.Point(4, 25);
            this.tabTextToSpeech.Name = "tabTextToSpeech";
            this.tabTextToSpeech.Size = new System.Drawing.Size(542, 315);
            this.tabTextToSpeech.TabIndex = 2;
            this.tabTextToSpeech.Text = "Use text-to-speech";
            this.tabTextToSpeech.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.chkSpeechMyOutput, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.chkSpeechExclusive, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.expSpeechRate, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.lblSpeechRate, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.expSpeechVolume, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblSpeechVolume, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblTextToSay, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.expTextToSay, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(542, 132);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // chkSpeechMyOutput
            // 
            this.chkSpeechMyOutput.AutoSize = true;
            this.chkSpeechMyOutput.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel4.SetColumnSpan(this.chkSpeechMyOutput, 3);
            this.chkSpeechMyOutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkSpeechMyOutput.Location = new System.Drawing.Point(3, 110);
            this.chkSpeechMyOutput.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkSpeechMyOutput.Name = "chkSpeechMyOutput";
            this.chkSpeechMyOutput.Size = new System.Drawing.Size(537, 17);
            this.chkSpeechMyOutput.TabIndex = 19;
            this.chkSpeechMyOutput.Text = "Use Triggernometry for output regardless of ACT hook configuration";
            this.chkSpeechMyOutput.UseVisualStyleBackColor = true;
            // 
            // chkSpeechExclusive
            // 
            this.chkSpeechExclusive.AutoSize = true;
            this.chkSpeechExclusive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel4.SetColumnSpan(this.chkSpeechExclusive, 3);
            this.chkSpeechExclusive.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkSpeechExclusive.Location = new System.Drawing.Point(3, 83);
            this.chkSpeechExclusive.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkSpeechExclusive.Name = "chkSpeechExclusive";
            this.chkSpeechExclusive.Size = new System.Drawing.Size(537, 17);
            this.chkSpeechExclusive.TabIndex = 18;
            this.chkSpeechExclusive.Text = "Use exclusive speech synthesizer to prevent conflicts with other speech";
            this.chkSpeechExclusive.UseVisualStyleBackColor = true;
            // 
            // expSpeechRate
            // 
            this.expSpeechRate.AutoSize = true;
            this.expSpeechRate.Dock = System.Windows.Forms.DockStyle.Top;
            this.expSpeechRate.Expression = "";
            this.expSpeechRate.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expSpeechRate.Location = new System.Drawing.Point(163, 55);
            this.expSpeechRate.Name = "expSpeechRate";
            this.expSpeechRate.Size = new System.Drawing.Size(376, 20);
            this.expSpeechRate.TabIndex = 16;
            // 
            // lblSpeechRate
            // 
            this.lblSpeechRate.AutoSize = true;
            this.lblSpeechRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSpeechRate.Location = new System.Drawing.Point(3, 52);
            this.lblSpeechRate.Name = "lblSpeechRate";
            this.lblSpeechRate.Size = new System.Drawing.Size(154, 26);
            this.lblSpeechRate.TabIndex = 15;
            this.lblSpeechRate.Text = "Speech speed rate (-10 ... +10)";
            this.lblSpeechRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expSpeechVolume
            // 
            this.expSpeechVolume.AutoSize = true;
            this.expSpeechVolume.Dock = System.Windows.Forms.DockStyle.Top;
            this.expSpeechVolume.Expression = "";
            this.expSpeechVolume.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expSpeechVolume.Location = new System.Drawing.Point(163, 29);
            this.expSpeechVolume.Name = "expSpeechVolume";
            this.expSpeechVolume.Size = new System.Drawing.Size(376, 20);
            this.expSpeechVolume.TabIndex = 14;
            // 
            // lblSpeechVolume
            // 
            this.lblSpeechVolume.AutoSize = true;
            this.lblSpeechVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSpeechVolume.Location = new System.Drawing.Point(3, 26);
            this.lblSpeechVolume.Name = "lblSpeechVolume";
            this.lblSpeechVolume.Size = new System.Drawing.Size(154, 26);
            this.lblSpeechVolume.TabIndex = 13;
            this.lblSpeechVolume.Text = "Speech volume (0 ... 100 %)";
            this.lblSpeechVolume.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTextToSay
            // 
            this.lblTextToSay.AutoSize = true;
            this.lblTextToSay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextToSay.Location = new System.Drawing.Point(3, 0);
            this.lblTextToSay.Name = "lblTextToSay";
            this.lblTextToSay.Size = new System.Drawing.Size(154, 26);
            this.lblTextToSay.TabIndex = 7;
            this.lblTextToSay.Text = "Text to say";
            this.lblTextToSay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTextToSay
            // 
            this.expTextToSay.AutoSize = true;
            this.expTextToSay.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextToSay.Expression = "";
            this.expTextToSay.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expTextToSay.Location = new System.Drawing.Point(163, 3);
            this.expTextToSay.Name = "expTextToSay";
            this.expTextToSay.Size = new System.Drawing.Size(376, 20);
            this.expTextToSay.TabIndex = 12;
            // 
            // tabLaunchProcess
            // 
            this.tabLaunchProcess.AutoScroll = true;
            this.tabLaunchProcess.Controls.Add(this.tableLayoutPanel5);
            this.tabLaunchProcess.Controls.Add(this.panel4);
            this.tabLaunchProcess.Location = new System.Drawing.Point(4, 25);
            this.tabLaunchProcess.Name = "tabLaunchProcess";
            this.tabLaunchProcess.Size = new System.Drawing.Size(542, 315);
            this.tabLaunchProcess.TabIndex = 3;
            this.tabLaunchProcess.Text = "Launch process";
            this.tabLaunchProcess.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.Controls.Add(this.cbxProcessWindowStyle, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.lblProcessWindowStyle, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.expProcessWorkingDir, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.lblProcessWorkingDir, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.expProcessParameters, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblProcessParameters, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblProcessName, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.button6, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.expProcessName, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 51);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(542, 105);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // cbxProcessWindowStyle
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.cbxProcessWindowStyle, 2);
            this.cbxProcessWindowStyle.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxProcessWindowStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProcessWindowStyle.FormattingEnabled = true;
            this.cbxProcessWindowStyle.Items.AddRange(new object[] {
            "Normal",
            "Hidden from view",
            "Minimized to taskbar",
            "Maximized to fullscreen"});
            this.cbxProcessWindowStyle.Location = new System.Drawing.Point(137, 81);
            this.cbxProcessWindowStyle.Name = "cbxProcessWindowStyle";
            this.cbxProcessWindowStyle.Size = new System.Drawing.Size(402, 21);
            this.cbxProcessWindowStyle.TabIndex = 20;
            // 
            // lblProcessWindowStyle
            // 
            this.lblProcessWindowStyle.AutoSize = true;
            this.lblProcessWindowStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProcessWindowStyle.Location = new System.Drawing.Point(3, 78);
            this.lblProcessWindowStyle.Name = "lblProcessWindowStyle";
            this.lblProcessWindowStyle.Size = new System.Drawing.Size(128, 27);
            this.lblProcessWindowStyle.TabIndex = 19;
            this.lblProcessWindowStyle.Text = "Process window";
            this.lblProcessWindowStyle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expProcessWorkingDir
            // 
            this.expProcessWorkingDir.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.expProcessWorkingDir, 2);
            this.expProcessWorkingDir.Dock = System.Windows.Forms.DockStyle.Top;
            this.expProcessWorkingDir.Expression = "";
            this.expProcessWorkingDir.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expProcessWorkingDir.Location = new System.Drawing.Point(137, 55);
            this.expProcessWorkingDir.Name = "expProcessWorkingDir";
            this.expProcessWorkingDir.Size = new System.Drawing.Size(402, 20);
            this.expProcessWorkingDir.TabIndex = 18;
            // 
            // lblProcessWorkingDir
            // 
            this.lblProcessWorkingDir.AutoSize = true;
            this.lblProcessWorkingDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProcessWorkingDir.Location = new System.Drawing.Point(3, 52);
            this.lblProcessWorkingDir.Name = "lblProcessWorkingDir";
            this.lblProcessWorkingDir.Size = new System.Drawing.Size(128, 26);
            this.lblProcessWorkingDir.TabIndex = 17;
            this.lblProcessWorkingDir.Text = "Working directory";
            this.lblProcessWorkingDir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expProcessParameters
            // 
            this.expProcessParameters.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.expProcessParameters, 2);
            this.expProcessParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.expProcessParameters.Expression = "";
            this.expProcessParameters.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expProcessParameters.Location = new System.Drawing.Point(137, 29);
            this.expProcessParameters.Name = "expProcessParameters";
            this.expProcessParameters.Size = new System.Drawing.Size(402, 20);
            this.expProcessParameters.TabIndex = 16;
            // 
            // lblProcessParameters
            // 
            this.lblProcessParameters.AutoSize = true;
            this.lblProcessParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProcessParameters.Location = new System.Drawing.Point(3, 26);
            this.lblProcessParameters.Name = "lblProcessParameters";
            this.lblProcessParameters.Size = new System.Drawing.Size(128, 26);
            this.lblProcessParameters.TabIndex = 15;
            this.lblProcessParameters.Text = "Command line parameters";
            this.lblProcessParameters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProcessName
            // 
            this.lblProcessName.AutoSize = true;
            this.lblProcessName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProcessName.Location = new System.Drawing.Point(3, 0);
            this.lblProcessName.Name = "lblProcessName";
            this.lblProcessName.Size = new System.Drawing.Size(128, 26);
            this.lblProcessName.TabIndex = 7;
            this.lblProcessName.Text = "Process to launch";
            this.lblProcessName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(502, 0);
            this.button6.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(37, 26);
            this.button6.TabIndex = 13;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // expProcessName
            // 
            this.expProcessName.AutoSize = true;
            this.expProcessName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expProcessName.Expression = "";
            this.expProcessName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expProcessName.Location = new System.Drawing.Point(137, 3);
            this.expProcessName.Name = "expProcessName";
            this.expProcessName.Size = new System.Drawing.Size(362, 20);
            this.expProcessName.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.lblProcessWarning);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel4.Size = new System.Drawing.Size(542, 51);
            this.panel4.TabIndex = 3;
            // 
            // lblProcessWarning
            // 
            this.lblProcessWarning.AutoEllipsis = true;
            this.lblProcessWarning.BackColor = System.Drawing.SystemColors.Info;
            this.lblProcessWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProcessWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProcessWarning.Location = new System.Drawing.Point(0, 0);
            this.lblProcessWarning.Name = "lblProcessWarning";
            this.lblProcessWarning.Size = new System.Drawing.Size(542, 41);
            this.lblProcessWarning.TabIndex = 0;
            this.lblProcessWarning.Text = "Actions of this type may be potentially dangerous and cause damage if, for exampl" +
    "e, the trigger is fired with parameters that fall outside of the expected values" +
    ". Please be aware of the risk.";
            this.lblProcessWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabTriggerOperation
            // 
            this.tabTriggerOperation.AutoScroll = true;
            this.tabTriggerOperation.Controls.Add(this.tableLayoutPanel10);
            this.tabTriggerOperation.Location = new System.Drawing.Point(4, 25);
            this.tabTriggerOperation.Name = "tabTriggerOperation";
            this.tabTriggerOperation.Size = new System.Drawing.Size(542, 315);
            this.tabTriggerOperation.TabIndex = 4;
            this.tabTriggerOperation.Text = "Trigger operation";
            this.tabTriggerOperation.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.AutoSize = true;
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.lblFiringOptions, 0, 3);
            this.tableLayoutPanel10.Controls.Add(this.expTriggerZone, 1, 2);
            this.tableLayoutPanel10.Controls.Add(this.lblTriggerZone, 0, 2);
            this.tableLayoutPanel10.Controls.Add(this.lblTrigger, 0, 5);
            this.tableLayoutPanel10.Controls.Add(this.expTriggerText, 1, 1);
            this.tableLayoutPanel10.Controls.Add(this.lblTriggerText, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.lblTriggerOp, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.cbxTriggerOp, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.trvTrigger, 1, 5);
            this.tableLayoutPanel10.Controls.Add(this.cbxFiringOptions, 1, 3);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 7;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(542, 315);
            this.tableLayoutPanel10.TabIndex = 7;
            // 
            // lblFiringOptions
            // 
            this.lblFiringOptions.AutoSize = true;
            this.lblFiringOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFiringOptions.Location = new System.Drawing.Point(3, 82);
            this.lblFiringOptions.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblFiringOptions.Name = "lblFiringOptions";
            this.lblFiringOptions.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblFiringOptions.Size = new System.Drawing.Size(101, 17);
            this.lblFiringOptions.TabIndex = 26;
            this.lblFiringOptions.Text = "Firing options";
            this.lblFiringOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTriggerZone
            // 
            this.expTriggerZone.AutoSize = true;
            this.expTriggerZone.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTriggerZone.Expression = "";
            this.expTriggerZone.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expTriggerZone.Location = new System.Drawing.Point(110, 56);
            this.expTriggerZone.Name = "expTriggerZone";
            this.expTriggerZone.Size = new System.Drawing.Size(429, 20);
            this.expTriggerZone.TabIndex = 25;
            this.expTriggerZone.EnabledChanged += new System.EventHandler(this.expTriggerZone_EnabledChanged);
            // 
            // lblTriggerZone
            // 
            this.lblTriggerZone.AutoSize = true;
            this.lblTriggerZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTriggerZone.Location = new System.Drawing.Point(3, 53);
            this.lblTriggerZone.Name = "lblTriggerZone";
            this.lblTriggerZone.Size = new System.Drawing.Size(101, 26);
            this.lblTriggerZone.TabIndex = 24;
            this.lblTriggerZone.Text = "Zone name for firing";
            this.lblTriggerZone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTrigger
            // 
            this.lblTrigger.AutoSize = true;
            this.lblTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrigger.Location = new System.Drawing.Point(3, 137);
            this.lblTrigger.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblTrigger.Name = "lblTrigger";
            this.lblTrigger.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblTrigger.Size = new System.Drawing.Size(101, 17);
            this.lblTrigger.TabIndex = 23;
            this.lblTrigger.Text = "Trigger";
            this.lblTrigger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTriggerText
            // 
            this.expTriggerText.AutoSize = true;
            this.expTriggerText.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTriggerText.Expression = "";
            this.expTriggerText.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expTriggerText.Location = new System.Drawing.Point(110, 30);
            this.expTriggerText.Name = "expTriggerText";
            this.expTriggerText.Size = new System.Drawing.Size(429, 20);
            this.expTriggerText.TabIndex = 16;
            this.expTriggerText.EnabledChanged += new System.EventHandler(this.expTriggerText_EnabledChanged);
            // 
            // lblTriggerText
            // 
            this.lblTriggerText.AutoSize = true;
            this.lblTriggerText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTriggerText.Location = new System.Drawing.Point(3, 27);
            this.lblTriggerText.Name = "lblTriggerText";
            this.lblTriggerText.Size = new System.Drawing.Size(101, 26);
            this.lblTriggerText.TabIndex = 15;
            this.lblTriggerText.Text = "Event text for firing";
            this.lblTriggerText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTriggerOp
            // 
            this.lblTriggerOp.AutoSize = true;
            this.lblTriggerOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTriggerOp.Location = new System.Drawing.Point(3, 0);
            this.lblTriggerOp.Name = "lblTriggerOp";
            this.lblTriggerOp.Size = new System.Drawing.Size(101, 27);
            this.lblTriggerOp.TabIndex = 7;
            this.lblTriggerOp.Text = "Operation";
            this.lblTriggerOp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxTriggerOp
            // 
            this.cbxTriggerOp.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxTriggerOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTriggerOp.FormattingEnabled = true;
            this.cbxTriggerOp.Items.AddRange(new object[] {
            "Fire the specified trigger",
            "Cancel all actions queued from the specified trigger",
            "Enable the specified trigger",
            "Disable the specified trigger",
            "Cancel all actions from all triggers"});
            this.cbxTriggerOp.Location = new System.Drawing.Point(110, 3);
            this.cbxTriggerOp.Name = "cbxTriggerOp";
            this.cbxTriggerOp.Size = new System.Drawing.Size(429, 21);
            this.cbxTriggerOp.TabIndex = 21;
            this.cbxTriggerOp.SelectedIndexChanged += new System.EventHandler(this.cbxTriggerOp_SelectedIndexChanged);
            // 
            // trvTrigger
            // 
            this.trvTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvTrigger.HideSelection = false;
            this.trvTrigger.Location = new System.Drawing.Point(110, 137);
            this.trvTrigger.MinimumSize = new System.Drawing.Size(4, 50);
            this.trvTrigger.Name = "trvTrigger";
            this.tableLayoutPanel10.SetRowSpan(this.trvTrigger, 2);
            this.trvTrigger.ShowNodeToolTips = true;
            this.trvTrigger.Size = new System.Drawing.Size(429, 175);
            this.trvTrigger.TabIndex = 22;
            this.trvTrigger.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvTrigger_BeforeCollapse);
            this.trvTrigger.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvTrigger_BeforeExpand);
            this.trvTrigger.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvTrigger_BeforeSelect);
            this.trvTrigger.EnabledChanged += new System.EventHandler(this.trvTrigger_EnabledChanged);
            // 
            // cbxFiringOptions
            // 
            this.cbxFiringOptions.CheckOnClick = true;
            this.cbxFiringOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxFiringOptions.FormattingEnabled = true;
            this.cbxFiringOptions.Items.AddRange(new object[] {
            "Ignore regular expression",
            "Ignore conditions",
            "Ignore refire delay",
            "Ignore parent folder restrictions",
            "Ignore enabled/disabled status"});
            this.cbxFiringOptions.Location = new System.Drawing.Point(110, 82);
            this.cbxFiringOptions.Name = "cbxFiringOptions";
            this.tableLayoutPanel10.SetRowSpan(this.cbxFiringOptions, 2);
            this.cbxFiringOptions.Size = new System.Drawing.Size(429, 49);
            this.cbxFiringOptions.TabIndex = 27;
            this.cbxFiringOptions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cbxFiringOptions_ItemCheck);
            this.cbxFiringOptions.EnabledChanged += new System.EventHandler(this.cbxFiringOptions_EnabledChanged);
            // 
            // tabKeypress
            // 
            this.tabKeypress.AutoScroll = true;
            this.tabKeypress.Controls.Add(this.tableLayoutPanel6);
            this.tabKeypress.Location = new System.Drawing.Point(4, 25);
            this.tabKeypress.Name = "tabKeypress";
            this.tabKeypress.Size = new System.Drawing.Size(542, 315);
            this.tabKeypress.TabIndex = 5;
            this.tabKeypress.Text = "Keypress";
            this.tabKeypress.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel6.Controls.Add(this.btnKeycodesLink, 3, 7);
            this.tableLayoutPanel6.Controls.Add(this.txtKeyCodesLink, 1, 7);
            this.tableLayoutPanel6.Controls.Add(this.lblKeypressInfo, 1, 6);
            this.tableLayoutPanel6.Controls.Add(this.expKeypress, 1, 5);
            this.tableLayoutPanel6.Controls.Add(this.expWindowTitle, 1, 4);
            this.tableLayoutPanel6.Controls.Add(this.lblKeypress, 0, 5);
            this.tableLayoutPanel6.Controls.Add(this.lblKeypressWindow, 0, 4);
            this.tableLayoutPanel6.Controls.Add(this.cbxKeypressMethod, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.lblKeypressMethod, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnSendKeysLink, 2, 3);
            this.tableLayoutPanel6.Controls.Add(this.lblKeypresses, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.expKeypresses, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.lblKeypressesInfo, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.txtSendKeysLink, 1, 3);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 8;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(542, 262);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // btnKeycodesLink
            // 
            this.btnKeycodesLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKeycodesLink.Image = ((System.Drawing.Image)(resources.GetObject("btnKeycodesLink.Image")));
            this.btnKeycodesLink.Location = new System.Drawing.Point(502, 236);
            this.btnKeycodesLink.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnKeycodesLink.Name = "btnKeycodesLink";
            this.btnKeycodesLink.Size = new System.Drawing.Size(37, 26);
            this.btnKeycodesLink.TabIndex = 29;
            this.btnKeycodesLink.UseVisualStyleBackColor = true;
            this.btnKeycodesLink.Click += new System.EventHandler(this.btnKeycodesLink_Click);
            // 
            // txtKeyCodesLink
            // 
            this.txtKeyCodesLink.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtKeyCodesLink.Location = new System.Drawing.Point(123, 239);
            this.txtKeyCodesLink.Name = "txtKeyCodesLink";
            this.txtKeyCodesLink.ReadOnly = true;
            this.txtKeyCodesLink.Size = new System.Drawing.Size(376, 20);
            this.txtKeyCodesLink.TabIndex = 28;
            this.txtKeyCodesLink.Text = "https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.keys";
            // 
            // lblKeypressInfo
            // 
            this.lblKeypressInfo.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.lblKeypressInfo, 2);
            this.lblKeypressInfo.Location = new System.Drawing.Point(123, 177);
            this.lblKeypressInfo.Name = "lblKeypressInfo";
            this.lblKeypressInfo.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.lblKeypressInfo.Size = new System.Drawing.Size(404, 59);
            this.lblKeypressInfo.TabIndex = 27;
            this.lblKeypressInfo.Text = "The window message format can send one key at a time, and modifier keys such as S" +
    "hift are represented as additions to the original keycode. Keycode constants are" +
    " described on this webpage:";
            // 
            // expKeypress
            // 
            this.expKeypress.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.expKeypress, 2);
            this.expKeypress.Dock = System.Windows.Forms.DockStyle.Top;
            this.expKeypress.Expression = "";
            this.expKeypress.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expKeypress.Location = new System.Drawing.Point(123, 154);
            this.expKeypress.Name = "expKeypress";
            this.expKeypress.Size = new System.Drawing.Size(416, 20);
            this.expKeypress.TabIndex = 26;
            // 
            // expWindowTitle
            // 
            this.expWindowTitle.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.expWindowTitle, 2);
            this.expWindowTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.expWindowTitle.Expression = "";
            this.expWindowTitle.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expWindowTitle.Location = new System.Drawing.Point(123, 128);
            this.expWindowTitle.Name = "expWindowTitle";
            this.expWindowTitle.Size = new System.Drawing.Size(416, 20);
            this.expWindowTitle.TabIndex = 25;
            // 
            // lblKeypress
            // 
            this.lblKeypress.AutoSize = true;
            this.lblKeypress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeypress.Location = new System.Drawing.Point(3, 151);
            this.lblKeypress.Name = "lblKeypress";
            this.lblKeypress.Size = new System.Drawing.Size(114, 26);
            this.lblKeypress.TabIndex = 24;
            this.lblKeypress.Text = "Keycode to send";
            this.lblKeypress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKeypressWindow
            // 
            this.lblKeypressWindow.AutoSize = true;
            this.lblKeypressWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeypressWindow.Location = new System.Drawing.Point(3, 125);
            this.lblKeypressWindow.Name = "lblKeypressWindow";
            this.lblKeypressWindow.Size = new System.Drawing.Size(114, 26);
            this.lblKeypressWindow.TabIndex = 23;
            this.lblKeypressWindow.Text = "Window title";
            this.lblKeypressWindow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxKeypressMethod
            // 
            this.tableLayoutPanel6.SetColumnSpan(this.cbxKeypressMethod, 2);
            this.cbxKeypressMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxKeypressMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKeypressMethod.FormattingEnabled = true;
            this.cbxKeypressMethod.Items.AddRange(new object[] {
            "SendKeys",
            "Window message"});
            this.cbxKeypressMethod.Location = new System.Drawing.Point(123, 3);
            this.cbxKeypressMethod.Name = "cbxKeypressMethod";
            this.cbxKeypressMethod.Size = new System.Drawing.Size(416, 21);
            this.cbxKeypressMethod.TabIndex = 22;
            this.cbxKeypressMethod.SelectedIndexChanged += new System.EventHandler(this.cbxKeypressMethod_SelectedIndexChanged);
            // 
            // lblKeypressMethod
            // 
            this.lblKeypressMethod.AutoSize = true;
            this.lblKeypressMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeypressMethod.Location = new System.Drawing.Point(3, 0);
            this.lblKeypressMethod.Name = "lblKeypressMethod";
            this.lblKeypressMethod.Size = new System.Drawing.Size(114, 27);
            this.lblKeypressMethod.TabIndex = 18;
            this.lblKeypressMethod.Text = "Keypress send method";
            this.lblKeypressMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSendKeysLink
            // 
            this.btnSendKeysLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSendKeysLink.Image = ((System.Drawing.Image)(resources.GetObject("btnSendKeysLink.Image")));
            this.btnSendKeysLink.Location = new System.Drawing.Point(502, 99);
            this.btnSendKeysLink.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnSendKeysLink.Name = "btnSendKeysLink";
            this.btnSendKeysLink.Size = new System.Drawing.Size(37, 26);
            this.btnSendKeysLink.TabIndex = 17;
            this.btnSendKeysLink.UseVisualStyleBackColor = true;
            this.btnSendKeysLink.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblKeypresses
            // 
            this.lblKeypresses.AutoSize = true;
            this.lblKeypresses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeypresses.Location = new System.Drawing.Point(3, 27);
            this.lblKeypresses.Name = "lblKeypresses";
            this.lblKeypresses.Size = new System.Drawing.Size(114, 26);
            this.lblKeypresses.TabIndex = 7;
            this.lblKeypresses.Text = "Keypresses to send";
            this.lblKeypresses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expKeypresses
            // 
            this.expKeypresses.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.expKeypresses, 2);
            this.expKeypresses.Dock = System.Windows.Forms.DockStyle.Top;
            this.expKeypresses.Expression = "";
            this.expKeypresses.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expKeypresses.Location = new System.Drawing.Point(123, 30);
            this.expKeypresses.Name = "expKeypresses";
            this.expKeypresses.Size = new System.Drawing.Size(416, 20);
            this.expKeypresses.TabIndex = 14;
            // 
            // lblKeypressesInfo
            // 
            this.lblKeypressesInfo.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.lblKeypressesInfo, 2);
            this.lblKeypressesInfo.Location = new System.Drawing.Point(123, 53);
            this.lblKeypressesInfo.Name = "lblKeypressesInfo";
            this.lblKeypressesInfo.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.lblKeypressesInfo.Size = new System.Drawing.Size(415, 46);
            this.lblKeypressesInfo.TabIndex = 15;
            this.lblKeypressesInfo.Text = "The SendKeys keypress format, including how to represent modifier keys such as Sh" +
    "ift, is described on this webpage:";
            // 
            // txtSendKeysLink
            // 
            this.txtSendKeysLink.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSendKeysLink.Location = new System.Drawing.Point(123, 102);
            this.txtSendKeysLink.Name = "txtSendKeysLink";
            this.txtSendKeysLink.ReadOnly = true;
            this.txtSendKeysLink.Size = new System.Drawing.Size(376, 20);
            this.txtSendKeysLink.TabIndex = 16;
            this.txtSendKeysLink.Text = "https://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.send.aspx";
            // 
            // tabScript
            // 
            this.tabScript.AutoScroll = true;
            this.tabScript.Controls.Add(this.tableLayoutPanel7);
            this.tabScript.Controls.Add(this.panel5);
            this.tabScript.Location = new System.Drawing.Point(4, 25);
            this.tabScript.Name = "tabScript";
            this.tabScript.Size = new System.Drawing.Size(542, 315);
            this.tabScript.TabIndex = 6;
            this.tabScript.Text = "Script";
            this.tabScript.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.expExecScriptAssemblies, 1, 2);
            this.tableLayoutPanel7.Controls.Add(this.lblExecScriptAssemblies, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.expExecScriptCode, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.lblExecScriptCode, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.lblExecScriptLang, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.cbxExecScriptLang, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 51);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(542, 79);
            this.tableLayoutPanel7.TabIndex = 5;
            // 
            // expExecScriptAssemblies
            // 
            this.expExecScriptAssemblies.AutoSize = true;
            this.expExecScriptAssemblies.Dock = System.Windows.Forms.DockStyle.Top;
            this.expExecScriptAssemblies.Expression = "";
            this.expExecScriptAssemblies.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expExecScriptAssemblies.Location = new System.Drawing.Point(158, 56);
            this.expExecScriptAssemblies.Name = "expExecScriptAssemblies";
            this.expExecScriptAssemblies.Size = new System.Drawing.Size(381, 20);
            this.expExecScriptAssemblies.TabIndex = 23;
            // 
            // lblExecScriptAssemblies
            // 
            this.lblExecScriptAssemblies.AutoSize = true;
            this.lblExecScriptAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExecScriptAssemblies.Location = new System.Drawing.Point(3, 53);
            this.lblExecScriptAssemblies.Name = "lblExecScriptAssemblies";
            this.lblExecScriptAssemblies.Size = new System.Drawing.Size(149, 26);
            this.lblExecScriptAssemblies.TabIndex = 22;
            this.lblExecScriptAssemblies.Text = "List of assemblies to reference";
            this.lblExecScriptAssemblies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expExecScriptCode
            // 
            this.expExecScriptCode.AutoSize = true;
            this.expExecScriptCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.expExecScriptCode.Expression = "";
            this.expExecScriptCode.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expExecScriptCode.Location = new System.Drawing.Point(158, 30);
            this.expExecScriptCode.Name = "expExecScriptCode";
            this.expExecScriptCode.Size = new System.Drawing.Size(381, 20);
            this.expExecScriptCode.TabIndex = 16;
            // 
            // lblExecScriptCode
            // 
            this.lblExecScriptCode.AutoSize = true;
            this.lblExecScriptCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExecScriptCode.Location = new System.Drawing.Point(3, 27);
            this.lblExecScriptCode.Name = "lblExecScriptCode";
            this.lblExecScriptCode.Size = new System.Drawing.Size(149, 26);
            this.lblExecScriptCode.TabIndex = 15;
            this.lblExecScriptCode.Text = "Script code";
            this.lblExecScriptCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExecScriptLang
            // 
            this.lblExecScriptLang.AutoSize = true;
            this.lblExecScriptLang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExecScriptLang.Location = new System.Drawing.Point(3, 0);
            this.lblExecScriptLang.Name = "lblExecScriptLang";
            this.lblExecScriptLang.Size = new System.Drawing.Size(149, 27);
            this.lblExecScriptLang.TabIndex = 7;
            this.lblExecScriptLang.Text = "Script language";
            this.lblExecScriptLang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxExecScriptLang
            // 
            this.cbxExecScriptLang.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxExecScriptLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxExecScriptLang.FormattingEnabled = true;
            this.cbxExecScriptLang.Items.AddRange(new object[] {
            "C#",
            "Visual Basic"});
            this.cbxExecScriptLang.Location = new System.Drawing.Point(158, 3);
            this.cbxExecScriptLang.Name = "cbxExecScriptLang";
            this.cbxExecScriptLang.Size = new System.Drawing.Size(381, 21);
            this.cbxExecScriptLang.TabIndex = 21;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.lblScriptWarning);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel5.Size = new System.Drawing.Size(542, 51);
            this.panel5.TabIndex = 4;
            // 
            // lblScriptWarning
            // 
            this.lblScriptWarning.AutoEllipsis = true;
            this.lblScriptWarning.BackColor = System.Drawing.SystemColors.Info;
            this.lblScriptWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScriptWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScriptWarning.Location = new System.Drawing.Point(0, 0);
            this.lblScriptWarning.Name = "lblScriptWarning";
            this.lblScriptWarning.Size = new System.Drawing.Size(542, 41);
            this.lblScriptWarning.TabIndex = 0;
            this.lblScriptWarning.Text = "Actions of this type may be potentially dangerous and cause damage if, for exampl" +
    "e, the trigger is fired with parameters that fall outside of the expected values" +
    ". Please be aware of the risk.";
            this.lblScriptWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabMessageBox
            // 
            this.tabMessageBox.AutoScroll = true;
            this.tabMessageBox.Controls.Add(this.tableLayoutPanel8);
            this.tabMessageBox.Location = new System.Drawing.Point(4, 25);
            this.tabMessageBox.Name = "tabMessageBox";
            this.tabMessageBox.Size = new System.Drawing.Size(542, 315);
            this.tabMessageBox.TabIndex = 7;
            this.tabMessageBox.Text = "MessageBox";
            this.tabMessageBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.AutoSize = true;
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.expMessageBoxText, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.lblMessageBoxText, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.lblMessageBoxIcon, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.cbxMessageBoxIcon, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(542, 53);
            this.tableLayoutPanel8.TabIndex = 6;
            // 
            // expMessageBoxText
            // 
            this.expMessageBoxText.AutoSize = true;
            this.expMessageBoxText.Dock = System.Windows.Forms.DockStyle.Top;
            this.expMessageBoxText.Expression = "";
            this.expMessageBoxText.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expMessageBoxText.Location = new System.Drawing.Point(102, 30);
            this.expMessageBoxText.Name = "expMessageBoxText";
            this.expMessageBoxText.Size = new System.Drawing.Size(437, 20);
            this.expMessageBoxText.TabIndex = 16;
            // 
            // lblMessageBoxText
            // 
            this.lblMessageBoxText.AutoSize = true;
            this.lblMessageBoxText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessageBoxText.Location = new System.Drawing.Point(3, 27);
            this.lblMessageBoxText.Name = "lblMessageBoxText";
            this.lblMessageBoxText.Size = new System.Drawing.Size(93, 26);
            this.lblMessageBoxText.TabIndex = 15;
            this.lblMessageBoxText.Text = "Text to display";
            this.lblMessageBoxText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMessageBoxIcon
            // 
            this.lblMessageBoxIcon.AutoSize = true;
            this.lblMessageBoxIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessageBoxIcon.Location = new System.Drawing.Point(3, 0);
            this.lblMessageBoxIcon.Name = "lblMessageBoxIcon";
            this.lblMessageBoxIcon.Size = new System.Drawing.Size(93, 27);
            this.lblMessageBoxIcon.TabIndex = 7;
            this.lblMessageBoxIcon.Text = "Message box icon";
            this.lblMessageBoxIcon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxMessageBoxIcon
            // 
            this.cbxMessageBoxIcon.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxMessageBoxIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMessageBoxIcon.FormattingEnabled = true;
            this.cbxMessageBoxIcon.Items.AddRange(new object[] {
            "None",
            "Error",
            "Question",
            "Warning",
            "Information"});
            this.cbxMessageBoxIcon.Location = new System.Drawing.Point(102, 3);
            this.cbxMessageBoxIcon.Name = "cbxMessageBoxIcon";
            this.cbxMessageBoxIcon.Size = new System.Drawing.Size(437, 21);
            this.cbxMessageBoxIcon.TabIndex = 21;
            // 
            // tabVariable
            // 
            this.tabVariable.Controls.Add(this.tableLayoutPanel9);
            this.tabVariable.Location = new System.Drawing.Point(4, 25);
            this.tabVariable.Name = "tabVariable";
            this.tabVariable.Size = new System.Drawing.Size(542, 315);
            this.tabVariable.TabIndex = 8;
            this.tabVariable.Text = "Variable";
            this.tabVariable.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.AutoSize = true;
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.expVariableExpression, 1, 2);
            this.tableLayoutPanel9.Controls.Add(this.lblVariableExpression, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.expVariableName, 1, 1);
            this.tableLayoutPanel9.Controls.Add(this.lblVariableName, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.lblVariableOp, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.cbxVariableOp, 1, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(542, 79);
            this.tableLayoutPanel9.TabIndex = 6;
            // 
            // expVariableExpression
            // 
            this.expVariableExpression.AutoSize = true;
            this.expVariableExpression.Dock = System.Windows.Forms.DockStyle.Top;
            this.expVariableExpression.Expression = "";
            this.expVariableExpression.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expVariableExpression.Location = new System.Drawing.Point(115, 56);
            this.expVariableExpression.Name = "expVariableExpression";
            this.expVariableExpression.Size = new System.Drawing.Size(424, 20);
            this.expVariableExpression.TabIndex = 23;
            this.expVariableExpression.EnabledChanged += new System.EventHandler(this.expVariableExpression_EnabledChanged);
            // 
            // lblVariableExpression
            // 
            this.lblVariableExpression.AutoSize = true;
            this.lblVariableExpression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVariableExpression.Location = new System.Drawing.Point(3, 53);
            this.lblVariableExpression.Name = "lblVariableExpression";
            this.lblVariableExpression.Size = new System.Drawing.Size(106, 26);
            this.lblVariableExpression.TabIndex = 22;
            this.lblVariableExpression.Text = "Expression";
            this.lblVariableExpression.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expVariableName
            // 
            this.expVariableName.AutoSize = true;
            this.expVariableName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expVariableName.Expression = "";
            this.expVariableName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expVariableName.Location = new System.Drawing.Point(115, 30);
            this.expVariableName.Name = "expVariableName";
            this.expVariableName.Size = new System.Drawing.Size(424, 20);
            this.expVariableName.TabIndex = 16;
            this.expVariableName.EnabledChanged += new System.EventHandler(this.expVariableName_EnabledChanged);
            // 
            // lblVariableName
            // 
            this.lblVariableName.AutoSize = true;
            this.lblVariableName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVariableName.Location = new System.Drawing.Point(3, 27);
            this.lblVariableName.Name = "lblVariableName";
            this.lblVariableName.Size = new System.Drawing.Size(106, 26);
            this.lblVariableName.TabIndex = 15;
            this.lblVariableName.Text = "Scalar variable name";
            this.lblVariableName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVariableOp
            // 
            this.lblVariableOp.AutoSize = true;
            this.lblVariableOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVariableOp.Location = new System.Drawing.Point(3, 0);
            this.lblVariableOp.Name = "lblVariableOp";
            this.lblVariableOp.Size = new System.Drawing.Size(106, 27);
            this.lblVariableOp.TabIndex = 7;
            this.lblVariableOp.Text = "Operation type";
            this.lblVariableOp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxVariableOp
            // 
            this.cbxVariableOp.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxVariableOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVariableOp.FormattingEnabled = true;
            this.cbxVariableOp.Items.AddRange(new object[] {
            "Unset scalar variable",
            "Set scalar variable value with string expression",
            "Set scalar variable value with numeric expression",
            "Unset all scalar variables"});
            this.cbxVariableOp.Location = new System.Drawing.Point(115, 3);
            this.cbxVariableOp.Name = "cbxVariableOp";
            this.cbxVariableOp.Size = new System.Drawing.Size(424, 21);
            this.cbxVariableOp.TabIndex = 21;
            this.cbxVariableOp.SelectedIndexChanged += new System.EventHandler(this.cbxVariableOp_SelectedIndexChanged);
            // 
            // tabImageAura
            // 
            this.tabImageAura.AutoScroll = true;
            this.tabImageAura.Controls.Add(this.tableLayoutPanel11);
            this.tabImageAura.Location = new System.Drawing.Point(4, 25);
            this.tabImageAura.Name = "tabImageAura";
            this.tabImageAura.Size = new System.Drawing.Size(542, 315);
            this.tabImageAura.TabIndex = 9;
            this.tabImageAura.Text = "Aura";
            this.tabImageAura.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.AutoSize = true;
            this.tableLayoutPanel11.ColumnCount = 4;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel11.Controls.Add(this.btnHide, 3, 1);
            this.tableLayoutPanel11.Controls.Add(this.cbxAuraDisplay, 1, 3);
            this.tableLayoutPanel11.Controls.Add(this.lblAuraDisplay, 0, 3);
            this.tableLayoutPanel11.Controls.Add(this.expAuraTTLTick, 2, 10);
            this.tableLayoutPanel11.Controls.Add(this.expAuraOTick, 2, 9);
            this.tableLayoutPanel11.Controls.Add(this.expAuraHTick, 2, 8);
            this.tableLayoutPanel11.Controls.Add(this.expAuraWTick, 2, 7);
            this.tableLayoutPanel11.Controls.Add(this.expAuraYTick, 2, 6);
            this.tableLayoutPanel11.Controls.Add(this.expAuraXTick, 2, 5);
            this.tableLayoutPanel11.Controls.Add(this.lblUpdateTickExp, 2, 4);
            this.tableLayoutPanel11.Controls.Add(this.expAuraOIni, 1, 9);
            this.tableLayoutPanel11.Controls.Add(this.expAuraHIni, 1, 8);
            this.tableLayoutPanel11.Controls.Add(this.expAuraWIni, 1, 7);
            this.tableLayoutPanel11.Controls.Add(this.lblAuraTtl, 0, 10);
            this.tableLayoutPanel11.Controls.Add(this.lblAuraOpacity, 0, 9);
            this.tableLayoutPanel11.Controls.Add(this.lblAuraWidth, 0, 7);
            this.tableLayoutPanel11.Controls.Add(this.lblAuraHeight, 0, 8);
            this.tableLayoutPanel11.Controls.Add(this.btnBrowseAura, 3, 2);
            this.tableLayoutPanel11.Controls.Add(this.expAuraImage, 1, 2);
            this.tableLayoutPanel11.Controls.Add(this.lblAuraImage, 0, 2);
            this.tableLayoutPanel11.Controls.Add(this.expAuraYIni, 1, 6);
            this.tableLayoutPanel11.Controls.Add(this.lblAuraY, 0, 6);
            this.tableLayoutPanel11.Controls.Add(this.expAuraXIni, 1, 5);
            this.tableLayoutPanel11.Controls.Add(this.lblAuraX, 0, 5);
            this.tableLayoutPanel11.Controls.Add(this.expAuraName, 1, 1);
            this.tableLayoutPanel11.Controls.Add(this.lblAuraName, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.lblAuraOp, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.cbxAuraOp, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.lblInitialValues, 1, 4);
            this.tableLayoutPanel11.Controls.Add(this.btnAuraGuide, 1, 11);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 12;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(542, 311);
            this.tableLayoutPanel11.TabIndex = 8;
            // 
            // btnHide
            // 
            this.btnHide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHide.Location = new System.Drawing.Point(460, 27);
            this.btnHide.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(79, 26);
            this.btnHide.TabIndex = 50;
            this.btnHide.Text = "Hide";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // cbxAuraDisplay
            // 
            this.tableLayoutPanel11.SetColumnSpan(this.cbxAuraDisplay, 3);
            this.cbxAuraDisplay.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxAuraDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAuraDisplay.FormattingEnabled = true;
            this.cbxAuraDisplay.Items.AddRange(new object[] {
            "Normal",
            "Stretched to fill",
            "Centered",
            "Zoomed to fill respecting Aspect Ratio"});
            this.cbxAuraDisplay.Location = new System.Drawing.Point(123, 82);
            this.cbxAuraDisplay.Name = "cbxAuraDisplay";
            this.cbxAuraDisplay.Size = new System.Drawing.Size(416, 21);
            this.cbxAuraDisplay.TabIndex = 13;
            this.cbxAuraDisplay.EnabledChanged += new System.EventHandler(this.cbxAuraDisplay_EnabledChanged);
            // 
            // lblAuraDisplay
            // 
            this.lblAuraDisplay.AutoSize = true;
            this.lblAuraDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuraDisplay.Location = new System.Drawing.Point(3, 79);
            this.lblAuraDisplay.Name = "lblAuraDisplay";
            this.lblAuraDisplay.Size = new System.Drawing.Size(114, 27);
            this.lblAuraDisplay.TabIndex = 49;
            this.lblAuraDisplay.Text = "Display method";
            this.lblAuraDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expAuraTTLTick
            // 
            this.expAuraTTLTick.AutoSize = true;
            this.tableLayoutPanel11.SetColumnSpan(this.expAuraTTLTick, 2);
            this.expAuraTTLTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraTTLTick.Expression = "";
            this.expAuraTTLTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraTTLTick.Location = new System.Drawing.Point(225, 259);
            this.expAuraTTLTick.Name = "expAuraTTLTick";
            this.expAuraTTLTick.Size = new System.Drawing.Size(314, 20);
            this.expAuraTTLTick.TabIndex = 24;
            this.expAuraTTLTick.EnabledChanged += new System.EventHandler(this.expAuraTTLTick_EnabledChanged);
            // 
            // expAuraOTick
            // 
            this.expAuraOTick.AutoSize = true;
            this.tableLayoutPanel11.SetColumnSpan(this.expAuraOTick, 2);
            this.expAuraOTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraOTick.Expression = "";
            this.expAuraOTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraOTick.Location = new System.Drawing.Point(225, 233);
            this.expAuraOTick.Name = "expAuraOTick";
            this.expAuraOTick.Size = new System.Drawing.Size(314, 20);
            this.expAuraOTick.TabIndex = 23;
            this.expAuraOTick.EnabledChanged += new System.EventHandler(this.expAuraOTick_EnabledChanged);
            // 
            // expAuraHTick
            // 
            this.expAuraHTick.AutoSize = true;
            this.tableLayoutPanel11.SetColumnSpan(this.expAuraHTick, 2);
            this.expAuraHTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraHTick.Expression = "";
            this.expAuraHTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraHTick.Location = new System.Drawing.Point(225, 207);
            this.expAuraHTick.Name = "expAuraHTick";
            this.expAuraHTick.Size = new System.Drawing.Size(314, 20);
            this.expAuraHTick.TabIndex = 21;
            this.expAuraHTick.EnabledChanged += new System.EventHandler(this.expAuraHTick_EnabledChanged);
            // 
            // expAuraWTick
            // 
            this.expAuraWTick.AutoSize = true;
            this.tableLayoutPanel11.SetColumnSpan(this.expAuraWTick, 2);
            this.expAuraWTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraWTick.Expression = "";
            this.expAuraWTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraWTick.Location = new System.Drawing.Point(225, 181);
            this.expAuraWTick.Name = "expAuraWTick";
            this.expAuraWTick.Size = new System.Drawing.Size(314, 20);
            this.expAuraWTick.TabIndex = 19;
            this.expAuraWTick.EnabledChanged += new System.EventHandler(this.expAuraWTick_EnabledChanged);
            // 
            // expAuraYTick
            // 
            this.expAuraYTick.AutoSize = true;
            this.tableLayoutPanel11.SetColumnSpan(this.expAuraYTick, 2);
            this.expAuraYTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraYTick.Expression = "";
            this.expAuraYTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraYTick.Location = new System.Drawing.Point(225, 155);
            this.expAuraYTick.Name = "expAuraYTick";
            this.expAuraYTick.Size = new System.Drawing.Size(314, 20);
            this.expAuraYTick.TabIndex = 17;
            this.expAuraYTick.EnabledChanged += new System.EventHandler(this.expAuraYTick_EnabledChanged);
            // 
            // expAuraXTick
            // 
            this.expAuraXTick.AutoSize = true;
            this.tableLayoutPanel11.SetColumnSpan(this.expAuraXTick, 2);
            this.expAuraXTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraXTick.Expression = "";
            this.expAuraXTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraXTick.Location = new System.Drawing.Point(225, 129);
            this.expAuraXTick.Name = "expAuraXTick";
            this.expAuraXTick.Size = new System.Drawing.Size(314, 20);
            this.expAuraXTick.TabIndex = 15;
            this.expAuraXTick.EnabledChanged += new System.EventHandler(this.expAuraXTick_EnabledChanged);
            // 
            // lblUpdateTickExp
            // 
            this.lblUpdateTickExp.BackColor = System.Drawing.SystemColors.Info;
            this.lblUpdateTickExp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel11.SetColumnSpan(this.lblUpdateTickExp, 2);
            this.lblUpdateTickExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpdateTickExp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUpdateTickExp.Location = new System.Drawing.Point(225, 106);
            this.lblUpdateTickExp.Name = "lblUpdateTickExp";
            this.lblUpdateTickExp.Size = new System.Drawing.Size(314, 20);
            this.lblUpdateTickExp.TabIndex = 41;
            this.lblUpdateTickExp.Text = "Update tick (20 ms) expressions";
            this.lblUpdateTickExp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // expAuraOIni
            // 
            this.expAuraOIni.AutoSize = true;
            this.expAuraOIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraOIni.Expression = "";
            this.expAuraOIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraOIni.Location = new System.Drawing.Point(123, 233);
            this.expAuraOIni.Name = "expAuraOIni";
            this.expAuraOIni.Size = new System.Drawing.Size(96, 20);
            this.expAuraOIni.TabIndex = 22;
            // 
            // expAuraHIni
            // 
            this.expAuraHIni.AutoSize = true;
            this.expAuraHIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraHIni.Expression = "";
            this.expAuraHIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraHIni.Location = new System.Drawing.Point(123, 207);
            this.expAuraHIni.Name = "expAuraHIni";
            this.expAuraHIni.Size = new System.Drawing.Size(96, 20);
            this.expAuraHIni.TabIndex = 20;
            // 
            // expAuraWIni
            // 
            this.expAuraWIni.AutoSize = true;
            this.expAuraWIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraWIni.Expression = "";
            this.expAuraWIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraWIni.Location = new System.Drawing.Point(123, 181);
            this.expAuraWIni.Name = "expAuraWIni";
            this.expAuraWIni.Size = new System.Drawing.Size(96, 20);
            this.expAuraWIni.TabIndex = 18;
            // 
            // lblAuraTtl
            // 
            this.lblAuraTtl.AutoSize = true;
            this.lblAuraTtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuraTtl.Location = new System.Drawing.Point(3, 256);
            this.lblAuraTtl.Name = "lblAuraTtl";
            this.lblAuraTtl.Size = new System.Drawing.Size(114, 26);
            this.lblAuraTtl.TabIndex = 35;
            this.lblAuraTtl.Text = "Time-to-live expression";
            this.lblAuraTtl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAuraOpacity
            // 
            this.lblAuraOpacity.AutoSize = true;
            this.lblAuraOpacity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuraOpacity.Location = new System.Drawing.Point(3, 230);
            this.lblAuraOpacity.Name = "lblAuraOpacity";
            this.lblAuraOpacity.Size = new System.Drawing.Size(114, 26);
            this.lblAuraOpacity.TabIndex = 34;
            this.lblAuraOpacity.Text = "Opacity expression";
            this.lblAuraOpacity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAuraWidth
            // 
            this.lblAuraWidth.AutoSize = true;
            this.lblAuraWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuraWidth.Location = new System.Drawing.Point(3, 178);
            this.lblAuraWidth.Name = "lblAuraWidth";
            this.lblAuraWidth.Size = new System.Drawing.Size(114, 26);
            this.lblAuraWidth.TabIndex = 33;
            this.lblAuraWidth.Text = "Width expression";
            this.lblAuraWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAuraHeight
            // 
            this.lblAuraHeight.AutoSize = true;
            this.lblAuraHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuraHeight.Location = new System.Drawing.Point(3, 204);
            this.lblAuraHeight.Name = "lblAuraHeight";
            this.lblAuraHeight.Size = new System.Drawing.Size(114, 26);
            this.lblAuraHeight.TabIndex = 32;
            this.lblAuraHeight.Text = "Height expression";
            this.lblAuraHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowseAura
            // 
            this.btnBrowseAura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrowseAura.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseAura.Image")));
            this.btnBrowseAura.Location = new System.Drawing.Point(460, 53);
            this.btnBrowseAura.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnBrowseAura.Name = "btnBrowseAura";
            this.btnBrowseAura.Size = new System.Drawing.Size(79, 26);
            this.btnBrowseAura.TabIndex = 12;
            this.btnBrowseAura.UseVisualStyleBackColor = true;
            this.btnBrowseAura.Click += new System.EventHandler(this.button2_Click);
            // 
            // expAuraImage
            // 
            this.expAuraImage.AutoSize = true;
            this.tableLayoutPanel11.SetColumnSpan(this.expAuraImage, 2);
            this.expAuraImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraImage.Expression = "";
            this.expAuraImage.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expAuraImage.Location = new System.Drawing.Point(123, 56);
            this.expAuraImage.Name = "expAuraImage";
            this.expAuraImage.Size = new System.Drawing.Size(334, 20);
            this.expAuraImage.TabIndex = 11;
            this.expAuraImage.EnabledChanged += new System.EventHandler(this.expAuraImage_EnabledChanged);
            // 
            // lblAuraImage
            // 
            this.lblAuraImage.AutoSize = true;
            this.lblAuraImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuraImage.Location = new System.Drawing.Point(3, 53);
            this.lblAuraImage.Name = "lblAuraImage";
            this.lblAuraImage.Size = new System.Drawing.Size(114, 26);
            this.lblAuraImage.TabIndex = 28;
            this.lblAuraImage.Text = "Image to display";
            this.lblAuraImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expAuraYIni
            // 
            this.expAuraYIni.AutoSize = true;
            this.expAuraYIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraYIni.Expression = "";
            this.expAuraYIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraYIni.Location = new System.Drawing.Point(123, 155);
            this.expAuraYIni.Name = "expAuraYIni";
            this.expAuraYIni.Size = new System.Drawing.Size(96, 20);
            this.expAuraYIni.TabIndex = 16;
            // 
            // lblAuraY
            // 
            this.lblAuraY.AutoSize = true;
            this.lblAuraY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuraY.Location = new System.Drawing.Point(3, 152);
            this.lblAuraY.Name = "lblAuraY";
            this.lblAuraY.Size = new System.Drawing.Size(114, 26);
            this.lblAuraY.TabIndex = 26;
            this.lblAuraY.Text = "Y location expression";
            this.lblAuraY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expAuraXIni
            // 
            this.expAuraXIni.AutoSize = true;
            this.expAuraXIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraXIni.Expression = "";
            this.expAuraXIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraXIni.Location = new System.Drawing.Point(123, 129);
            this.expAuraXIni.Name = "expAuraXIni";
            this.expAuraXIni.Size = new System.Drawing.Size(96, 20);
            this.expAuraXIni.TabIndex = 14;
            // 
            // lblAuraX
            // 
            this.lblAuraX.AutoSize = true;
            this.lblAuraX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuraX.Location = new System.Drawing.Point(3, 126);
            this.lblAuraX.Name = "lblAuraX";
            this.lblAuraX.Size = new System.Drawing.Size(114, 26);
            this.lblAuraX.TabIndex = 24;
            this.lblAuraX.Text = "X location expression";
            this.lblAuraX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expAuraName
            // 
            this.expAuraName.AutoSize = true;
            this.tableLayoutPanel11.SetColumnSpan(this.expAuraName, 2);
            this.expAuraName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraName.Expression = "";
            this.expAuraName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expAuraName.Location = new System.Drawing.Point(123, 30);
            this.expAuraName.Name = "expAuraName";
            this.expAuraName.Size = new System.Drawing.Size(334, 20);
            this.expAuraName.TabIndex = 10;
            this.expAuraName.EnabledChanged += new System.EventHandler(this.expAuraName_EnabledChanged);
            // 
            // lblAuraName
            // 
            this.lblAuraName.AutoSize = true;
            this.lblAuraName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuraName.Location = new System.Drawing.Point(3, 27);
            this.lblAuraName.Name = "lblAuraName";
            this.lblAuraName.Size = new System.Drawing.Size(114, 26);
            this.lblAuraName.TabIndex = 15;
            this.lblAuraName.Text = "Unique identifier";
            this.lblAuraName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAuraOp
            // 
            this.lblAuraOp.AutoSize = true;
            this.lblAuraOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuraOp.Location = new System.Drawing.Point(3, 0);
            this.lblAuraOp.Name = "lblAuraOp";
            this.lblAuraOp.Size = new System.Drawing.Size(114, 27);
            this.lblAuraOp.TabIndex = 7;
            this.lblAuraOp.Text = "Operation";
            this.lblAuraOp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxAuraOp
            // 
            this.tableLayoutPanel11.SetColumnSpan(this.cbxAuraOp, 3);
            this.cbxAuraOp.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxAuraOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAuraOp.FormattingEnabled = true;
            this.cbxAuraOp.Items.AddRange(new object[] {
            "Activate or modify the specified image aura",
            "Deactivate the specified image aura",
            "Deactivate all image auras"});
            this.cbxAuraOp.Location = new System.Drawing.Point(123, 3);
            this.cbxAuraOp.Name = "cbxAuraOp";
            this.cbxAuraOp.Size = new System.Drawing.Size(416, 21);
            this.cbxAuraOp.TabIndex = 9;
            this.cbxAuraOp.SelectedIndexChanged += new System.EventHandler(this.cbxAuraOp_SelectedIndexChanged);
            // 
            // lblInitialValues
            // 
            this.lblInitialValues.BackColor = System.Drawing.SystemColors.Info;
            this.lblInitialValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInitialValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInitialValues.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblInitialValues.Location = new System.Drawing.Point(123, 106);
            this.lblInitialValues.Name = "lblInitialValues";
            this.lblInitialValues.Size = new System.Drawing.Size(96, 20);
            this.lblInitialValues.TabIndex = 40;
            this.lblInitialValues.Text = "Initial values";
            this.lblInitialValues.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAuraGuide
            // 
            this.tableLayoutPanel11.SetColumnSpan(this.btnAuraGuide, 3);
            this.btnAuraGuide.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAuraGuide.Enabled = false;
            this.btnAuraGuide.Location = new System.Drawing.Point(123, 285);
            this.btnAuraGuide.Name = "btnAuraGuide";
            this.btnAuraGuide.Size = new System.Drawing.Size(416, 23);
            this.btnAuraGuide.TabIndex = 25;
            this.btnAuraGuide.Text = "Use visual guide for placement (right-click for more options)";
            this.btnAuraGuide.UseVisualStyleBackColor = true;
            this.btnAuraGuide.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabFolderOperation
            // 
            this.tabFolderOperation.Controls.Add(this.tableLayoutPanel12);
            this.tabFolderOperation.Location = new System.Drawing.Point(4, 25);
            this.tabFolderOperation.Name = "tabFolderOperation";
            this.tabFolderOperation.Size = new System.Drawing.Size(542, 315);
            this.tabFolderOperation.TabIndex = 10;
            this.tabFolderOperation.Text = "Folder";
            this.tabFolderOperation.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.AutoSize = true;
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Controls.Add(this.lblFolder, 0, 1);
            this.tableLayoutPanel12.Controls.Add(this.lblFolderOp, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.cbxFolderOp, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.trvFolder, 1, 1);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 3;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(542, 315);
            this.tableLayoutPanel12.TabIndex = 8;
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFolder.Location = new System.Drawing.Point(3, 30);
            this.lblFolder.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblFolder.Size = new System.Drawing.Size(53, 17);
            this.lblFolder.TabIndex = 23;
            this.lblFolder.Text = "Folder";
            this.lblFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFolderOp
            // 
            this.lblFolderOp.AutoSize = true;
            this.lblFolderOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFolderOp.Location = new System.Drawing.Point(3, 0);
            this.lblFolderOp.Name = "lblFolderOp";
            this.lblFolderOp.Size = new System.Drawing.Size(53, 27);
            this.lblFolderOp.TabIndex = 7;
            this.lblFolderOp.Text = "Operation";
            this.lblFolderOp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxFolderOp
            // 
            this.cbxFolderOp.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxFolderOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFolderOp.FormattingEnabled = true;
            this.cbxFolderOp.Items.AddRange(new object[] {
            "Enable the specified folder",
            "Disable the specified folder"});
            this.cbxFolderOp.Location = new System.Drawing.Point(62, 3);
            this.cbxFolderOp.Name = "cbxFolderOp";
            this.cbxFolderOp.Size = new System.Drawing.Size(477, 21);
            this.cbxFolderOp.TabIndex = 21;
            this.cbxFolderOp.SelectedIndexChanged += new System.EventHandler(this.cbxFolderOp_SelectedIndexChanged);
            // 
            // trvFolder
            // 
            this.trvFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvFolder.HideSelection = false;
            this.trvFolder.Location = new System.Drawing.Point(62, 30);
            this.trvFolder.MinimumSize = new System.Drawing.Size(4, 50);
            this.trvFolder.Name = "trvFolder";
            this.tableLayoutPanel12.SetRowSpan(this.trvFolder, 2);
            this.trvFolder.ShowNodeToolTips = true;
            this.trvFolder.Size = new System.Drawing.Size(477, 282);
            this.trvFolder.TabIndex = 22;
            this.trvFolder.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvFolder_BeforeCollapse);
            this.trvFolder.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvFolder_BeforeExpand);
            this.trvFolder.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvFolder_BeforeSelect);
            // 
            // tabEndEncounter
            // 
            this.tabEndEncounter.Controls.Add(this.lblEndEncNoParams);
            this.tabEndEncounter.Location = new System.Drawing.Point(4, 25);
            this.tabEndEncounter.Name = "tabEndEncounter";
            this.tabEndEncounter.Size = new System.Drawing.Size(542, 315);
            this.tabEndEncounter.TabIndex = 11;
            this.tabEndEncounter.Text = "End";
            this.tabEndEncounter.UseVisualStyleBackColor = true;
            // 
            // lblEndEncNoParams
            // 
            this.lblEndEncNoParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEndEncNoParams.Location = new System.Drawing.Point(0, 0);
            this.lblEndEncNoParams.Name = "lblEndEncNoParams";
            this.lblEndEncNoParams.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.lblEndEncNoParams.Size = new System.Drawing.Size(542, 315);
            this.lblEndEncNoParams.TabIndex = 16;
            this.lblEndEncNoParams.Text = "This action has no configurable parameters.";
            this.lblEndEncNoParams.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabDiscordWebhook
            // 
            this.tabDiscordWebhook.Controls.Add(this.discordTableLayout);
            this.tabDiscordWebhook.Location = new System.Drawing.Point(4, 25);
            this.tabDiscordWebhook.Name = "tabDiscordWebhook";
            this.tabDiscordWebhook.Size = new System.Drawing.Size(542, 315);
            this.tabDiscordWebhook.TabIndex = 13;
            this.tabDiscordWebhook.Text = "Discord";
            this.tabDiscordWebhook.UseVisualStyleBackColor = true;
            // 
            // discordTableLayout
            // 
            this.discordTableLayout.AutoSize = true;
            this.discordTableLayout.ColumnCount = 2;
            this.discordTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.discordTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.discordTableLayout.Controls.Add(this.cbxDiscordTts, 0, 2);
            this.discordTableLayout.Controls.Add(this.expDiscordMessage, 1, 1);
            this.discordTableLayout.Controls.Add(this.lblDiscordMessage, 0, 1);
            this.discordTableLayout.Controls.Add(this.lblDiscordUrl, 0, 0);
            this.discordTableLayout.Controls.Add(this.expDiscordUrl, 1, 0);
            this.discordTableLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.discordTableLayout.Location = new System.Drawing.Point(0, 0);
            this.discordTableLayout.Name = "discordTableLayout";
            this.discordTableLayout.RowCount = 3;
            this.discordTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.discordTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.discordTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.discordTableLayout.Size = new System.Drawing.Size(542, 79);
            this.discordTableLayout.TabIndex = 2;
            // 
            // cbxDiscordTts
            // 
            this.cbxDiscordTts.AutoSize = true;
            this.cbxDiscordTts.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.discordTableLayout.SetColumnSpan(this.cbxDiscordTts, 3);
            this.cbxDiscordTts.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxDiscordTts.Location = new System.Drawing.Point(3, 57);
            this.cbxDiscordTts.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.cbxDiscordTts.Name = "cbxDiscordTts";
            this.cbxDiscordTts.Size = new System.Drawing.Size(537, 17);
            this.cbxDiscordTts.TabIndex = 18;
            this.cbxDiscordTts.Text = "Send as a text-to-speech message";
            this.cbxDiscordTts.UseVisualStyleBackColor = true;
            // 
            // expDiscordMessage
            // 
            this.expDiscordMessage.AutoSize = true;
            this.expDiscordMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.expDiscordMessage.Expression = "";
            this.expDiscordMessage.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expDiscordMessage.Location = new System.Drawing.Point(97, 29);
            this.expDiscordMessage.Name = "expDiscordMessage";
            this.expDiscordMessage.Size = new System.Drawing.Size(442, 20);
            this.expDiscordMessage.TabIndex = 16;
            // 
            // lblDiscordMessage
            // 
            this.lblDiscordMessage.AutoSize = true;
            this.lblDiscordMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiscordMessage.Location = new System.Drawing.Point(3, 26);
            this.lblDiscordMessage.Name = "lblDiscordMessage";
            this.lblDiscordMessage.Size = new System.Drawing.Size(88, 26);
            this.lblDiscordMessage.TabIndex = 15;
            this.lblDiscordMessage.Text = "Message to send";
            this.lblDiscordMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiscordUrl
            // 
            this.lblDiscordUrl.AutoSize = true;
            this.lblDiscordUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiscordUrl.Location = new System.Drawing.Point(3, 0);
            this.lblDiscordUrl.Name = "lblDiscordUrl";
            this.lblDiscordUrl.Size = new System.Drawing.Size(88, 26);
            this.lblDiscordUrl.TabIndex = 7;
            this.lblDiscordUrl.Text = "Webhook URL";
            this.lblDiscordUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expDiscordUrl
            // 
            this.expDiscordUrl.AutoSize = true;
            this.expDiscordUrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.expDiscordUrl.Expression = "";
            this.expDiscordUrl.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expDiscordUrl.Location = new System.Drawing.Point(97, 3);
            this.expDiscordUrl.Name = "expDiscordUrl";
            this.expDiscordUrl.Size = new System.Drawing.Size(442, 20);
            this.expDiscordUrl.TabIndex = 14;
            // 
            // tabTextAura
            // 
            this.tabTextAura.AutoScroll = true;
            this.tabTextAura.Controls.Add(this.tableLayoutPanel13);
            this.tabTextAura.Location = new System.Drawing.Point(4, 25);
            this.tabTextAura.Name = "tabTextAura";
            this.tabTextAura.Size = new System.Drawing.Size(542, 315);
            this.tabTextAura.TabIndex = 12;
            this.tabTextAura.Text = "TextAura";
            this.tabTextAura.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.AutoSize = true;
            this.tableLayoutPanel13.ColumnCount = 4;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraOutline, 0, 5);
            this.tableLayoutPanel13.Controls.Add(this.btnTextAuraFont, 3, 3);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraFont, 0, 3);
            this.tableLayoutPanel13.Controls.Add(this.btnTextAuraHide, 3, 1);
            this.tableLayoutPanel13.Controls.Add(this.cbxTextAuraAlignment, 1, 4);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraAlignment, 0, 4);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraTTLTick, 2, 12);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraOTick, 2, 11);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraHTick, 2, 10);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraWTick, 2, 9);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraYTick, 2, 8);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraXTick, 2, 7);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraUpdValues, 2, 6);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraOIni, 1, 11);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraHIni, 1, 10);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraWIni, 1, 9);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraTtlExp, 0, 12);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraOpacity, 0, 11);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraWidth, 0, 9);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraHeight, 0, 10);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraText, 1, 2);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraText, 0, 2);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraYIni, 1, 8);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraY, 0, 8);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraXIni, 1, 7);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraX, 0, 7);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraName, 1, 1);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraName, 0, 1);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraOp, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.cbxTextAuraOp, 1, 0);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraIniValues, 1, 6);
            this.tableLayoutPanel13.Controls.Add(this.btnTextAuraGuide, 1, 13);
            this.tableLayoutPanel13.Controls.Add(this.txtTextAuraFont, 2, 3);
            this.tableLayoutPanel13.Controls.Add(this.colorSelector1, 1, 3);
            this.tableLayoutPanel13.Controls.Add(this.cbxTextAuraOutline, 1, 5);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 14;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.Size = new System.Drawing.Size(525, 364);
            this.tableLayoutPanel13.TabIndex = 9;
            // 
            // lblTextAuraOutline
            // 
            this.lblTextAuraOutline.AutoSize = true;
            this.lblTextAuraOutline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraOutline.Location = new System.Drawing.Point(3, 132);
            this.lblTextAuraOutline.Name = "lblTextAuraOutline";
            this.lblTextAuraOutline.Size = new System.Drawing.Size(114, 27);
            this.lblTextAuraOutline.TabIndex = 55;
            this.lblTextAuraOutline.Text = "Display outline";
            this.lblTextAuraOutline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTextAuraFont
            // 
            this.btnTextAuraFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTextAuraFont.Location = new System.Drawing.Point(450, 79);
            this.btnTextAuraFont.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnTextAuraFont.Name = "btnTextAuraFont";
            this.btnTextAuraFont.Size = new System.Drawing.Size(72, 26);
            this.btnTextAuraFont.TabIndex = 52;
            this.btnTextAuraFont.Text = "...";
            this.btnTextAuraFont.UseVisualStyleBackColor = true;
            this.btnTextAuraFont.Click += new System.EventHandler(this.btnTextAuraFont_Click);
            // 
            // lblTextAuraFont
            // 
            this.lblTextAuraFont.AutoSize = true;
            this.lblTextAuraFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraFont.Location = new System.Drawing.Point(3, 79);
            this.lblTextAuraFont.Name = "lblTextAuraFont";
            this.lblTextAuraFont.Size = new System.Drawing.Size(114, 26);
            this.lblTextAuraFont.TabIndex = 51;
            this.lblTextAuraFont.Text = "Font";
            this.lblTextAuraFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTextAuraHide
            // 
            this.btnTextAuraHide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTextAuraHide.Location = new System.Drawing.Point(450, 27);
            this.btnTextAuraHide.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnTextAuraHide.Name = "btnTextAuraHide";
            this.btnTextAuraHide.Size = new System.Drawing.Size(72, 26);
            this.btnTextAuraHide.TabIndex = 50;
            this.btnTextAuraHide.Text = "Hide";
            this.btnTextAuraHide.UseVisualStyleBackColor = true;
            this.btnTextAuraHide.Click += new System.EventHandler(this.btnTextAuraHide_Click);
            // 
            // cbxTextAuraAlignment
            // 
            this.tableLayoutPanel13.SetColumnSpan(this.cbxTextAuraAlignment, 3);
            this.cbxTextAuraAlignment.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxTextAuraAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTextAuraAlignment.FormattingEnabled = true;
            this.cbxTextAuraAlignment.Items.AddRange(new object[] {
            "Top left",
            "Top center",
            "Top right",
            "Middle left",
            "Middle center",
            "Middle right",
            "Bottom left",
            "Bottom center",
            "Bottom right"});
            this.cbxTextAuraAlignment.Location = new System.Drawing.Point(123, 108);
            this.cbxTextAuraAlignment.Name = "cbxTextAuraAlignment";
            this.cbxTextAuraAlignment.Size = new System.Drawing.Size(399, 21);
            this.cbxTextAuraAlignment.TabIndex = 13;
            this.cbxTextAuraAlignment.EnabledChanged += new System.EventHandler(this.cbxTextAuraAlignment_EnabledChanged);
            // 
            // lblTextAuraAlignment
            // 
            this.lblTextAuraAlignment.AutoSize = true;
            this.lblTextAuraAlignment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraAlignment.Location = new System.Drawing.Point(3, 105);
            this.lblTextAuraAlignment.Name = "lblTextAuraAlignment";
            this.lblTextAuraAlignment.Size = new System.Drawing.Size(114, 27);
            this.lblTextAuraAlignment.TabIndex = 49;
            this.lblTextAuraAlignment.Text = "Text alignment";
            this.lblTextAuraAlignment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTextAuraTTLTick
            // 
            this.expTextAuraTTLTick.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.expTextAuraTTLTick, 2);
            this.expTextAuraTTLTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraTTLTick.Expression = "";
            this.expTextAuraTTLTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraTTLTick.Location = new System.Drawing.Point(222, 312);
            this.expTextAuraTTLTick.Name = "expTextAuraTTLTick";
            this.expTextAuraTTLTick.Size = new System.Drawing.Size(300, 20);
            this.expTextAuraTTLTick.TabIndex = 24;
            this.expTextAuraTTLTick.EnabledChanged += new System.EventHandler(this.expTextAuraTTLTick_EnabledChanged);
            // 
            // expTextAuraOTick
            // 
            this.expTextAuraOTick.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.expTextAuraOTick, 2);
            this.expTextAuraOTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraOTick.Expression = "";
            this.expTextAuraOTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraOTick.Location = new System.Drawing.Point(222, 286);
            this.expTextAuraOTick.Name = "expTextAuraOTick";
            this.expTextAuraOTick.Size = new System.Drawing.Size(300, 20);
            this.expTextAuraOTick.TabIndex = 23;
            this.expTextAuraOTick.EnabledChanged += new System.EventHandler(this.expTextAuraOTick_EnabledChanged);
            // 
            // expTextAuraHTick
            // 
            this.expTextAuraHTick.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.expTextAuraHTick, 2);
            this.expTextAuraHTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraHTick.Expression = "";
            this.expTextAuraHTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraHTick.Location = new System.Drawing.Point(222, 260);
            this.expTextAuraHTick.Name = "expTextAuraHTick";
            this.expTextAuraHTick.Size = new System.Drawing.Size(300, 20);
            this.expTextAuraHTick.TabIndex = 21;
            this.expTextAuraHTick.EnabledChanged += new System.EventHandler(this.expTextAuraHTick_EnabledChanged);
            // 
            // expTextAuraWTick
            // 
            this.expTextAuraWTick.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.expTextAuraWTick, 2);
            this.expTextAuraWTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraWTick.Expression = "";
            this.expTextAuraWTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraWTick.Location = new System.Drawing.Point(222, 234);
            this.expTextAuraWTick.Name = "expTextAuraWTick";
            this.expTextAuraWTick.Size = new System.Drawing.Size(300, 20);
            this.expTextAuraWTick.TabIndex = 19;
            this.expTextAuraWTick.EnabledChanged += new System.EventHandler(this.expTextAuraWTick_EnabledChanged);
            // 
            // expTextAuraYTick
            // 
            this.expTextAuraYTick.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.expTextAuraYTick, 2);
            this.expTextAuraYTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraYTick.Expression = "";
            this.expTextAuraYTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraYTick.Location = new System.Drawing.Point(222, 208);
            this.expTextAuraYTick.Name = "expTextAuraYTick";
            this.expTextAuraYTick.Size = new System.Drawing.Size(300, 20);
            this.expTextAuraYTick.TabIndex = 17;
            this.expTextAuraYTick.EnabledChanged += new System.EventHandler(this.expTextAuraYTick_EnabledChanged);
            // 
            // expTextAuraXTick
            // 
            this.expTextAuraXTick.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.expTextAuraXTick, 2);
            this.expTextAuraXTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraXTick.Expression = "";
            this.expTextAuraXTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraXTick.Location = new System.Drawing.Point(222, 182);
            this.expTextAuraXTick.Name = "expTextAuraXTick";
            this.expTextAuraXTick.Size = new System.Drawing.Size(300, 20);
            this.expTextAuraXTick.TabIndex = 15;
            this.expTextAuraXTick.EnabledChanged += new System.EventHandler(this.expTextAuraXTick_EnabledChanged);
            // 
            // lblTextAuraUpdValues
            // 
            this.lblTextAuraUpdValues.BackColor = System.Drawing.SystemColors.Info;
            this.lblTextAuraUpdValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel13.SetColumnSpan(this.lblTextAuraUpdValues, 2);
            this.lblTextAuraUpdValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraUpdValues.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTextAuraUpdValues.Location = new System.Drawing.Point(222, 159);
            this.lblTextAuraUpdValues.Name = "lblTextAuraUpdValues";
            this.lblTextAuraUpdValues.Size = new System.Drawing.Size(300, 20);
            this.lblTextAuraUpdValues.TabIndex = 41;
            this.lblTextAuraUpdValues.Text = "Update tick (20 ms) expressions";
            this.lblTextAuraUpdValues.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // expTextAuraOIni
            // 
            this.expTextAuraOIni.AutoSize = true;
            this.expTextAuraOIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraOIni.Expression = "";
            this.expTextAuraOIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraOIni.Location = new System.Drawing.Point(123, 286);
            this.expTextAuraOIni.Name = "expTextAuraOIni";
            this.expTextAuraOIni.Size = new System.Drawing.Size(93, 20);
            this.expTextAuraOIni.TabIndex = 22;
            // 
            // expTextAuraHIni
            // 
            this.expTextAuraHIni.AutoSize = true;
            this.expTextAuraHIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraHIni.Expression = "";
            this.expTextAuraHIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraHIni.Location = new System.Drawing.Point(123, 260);
            this.expTextAuraHIni.Name = "expTextAuraHIni";
            this.expTextAuraHIni.Size = new System.Drawing.Size(93, 20);
            this.expTextAuraHIni.TabIndex = 20;
            // 
            // expTextAuraWIni
            // 
            this.expTextAuraWIni.AutoSize = true;
            this.expTextAuraWIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraWIni.Expression = "";
            this.expTextAuraWIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraWIni.Location = new System.Drawing.Point(123, 234);
            this.expTextAuraWIni.Name = "expTextAuraWIni";
            this.expTextAuraWIni.Size = new System.Drawing.Size(93, 20);
            this.expTextAuraWIni.TabIndex = 18;
            // 
            // lblTextAuraTtlExp
            // 
            this.lblTextAuraTtlExp.AutoSize = true;
            this.lblTextAuraTtlExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraTtlExp.Location = new System.Drawing.Point(3, 309);
            this.lblTextAuraTtlExp.Name = "lblTextAuraTtlExp";
            this.lblTextAuraTtlExp.Size = new System.Drawing.Size(114, 26);
            this.lblTextAuraTtlExp.TabIndex = 35;
            this.lblTextAuraTtlExp.Text = "Time-to-live expression";
            this.lblTextAuraTtlExp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTextAuraOpacity
            // 
            this.lblTextAuraOpacity.AutoSize = true;
            this.lblTextAuraOpacity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraOpacity.Location = new System.Drawing.Point(3, 283);
            this.lblTextAuraOpacity.Name = "lblTextAuraOpacity";
            this.lblTextAuraOpacity.Size = new System.Drawing.Size(114, 26);
            this.lblTextAuraOpacity.TabIndex = 34;
            this.lblTextAuraOpacity.Text = "Opacity expression";
            this.lblTextAuraOpacity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTextAuraWidth
            // 
            this.lblTextAuraWidth.AutoSize = true;
            this.lblTextAuraWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraWidth.Location = new System.Drawing.Point(3, 231);
            this.lblTextAuraWidth.Name = "lblTextAuraWidth";
            this.lblTextAuraWidth.Size = new System.Drawing.Size(114, 26);
            this.lblTextAuraWidth.TabIndex = 33;
            this.lblTextAuraWidth.Text = "Width expression";
            this.lblTextAuraWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTextAuraHeight
            // 
            this.lblTextAuraHeight.AutoSize = true;
            this.lblTextAuraHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraHeight.Location = new System.Drawing.Point(3, 257);
            this.lblTextAuraHeight.Name = "lblTextAuraHeight";
            this.lblTextAuraHeight.Size = new System.Drawing.Size(114, 26);
            this.lblTextAuraHeight.TabIndex = 32;
            this.lblTextAuraHeight.Text = "Height expression";
            this.lblTextAuraHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTextAuraText
            // 
            this.expTextAuraText.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.expTextAuraText, 3);
            this.expTextAuraText.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraText.Expression = "";
            this.expTextAuraText.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expTextAuraText.Location = new System.Drawing.Point(123, 56);
            this.expTextAuraText.Name = "expTextAuraText";
            this.expTextAuraText.Size = new System.Drawing.Size(399, 20);
            this.expTextAuraText.TabIndex = 11;
            this.expTextAuraText.EnabledChanged += new System.EventHandler(this.expTextAuraText_EnabledChanged);
            // 
            // lblTextAuraText
            // 
            this.lblTextAuraText.AutoSize = true;
            this.lblTextAuraText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraText.Location = new System.Drawing.Point(3, 53);
            this.lblTextAuraText.Name = "lblTextAuraText";
            this.lblTextAuraText.Size = new System.Drawing.Size(114, 26);
            this.lblTextAuraText.TabIndex = 28;
            this.lblTextAuraText.Text = "Text to display";
            this.lblTextAuraText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTextAuraYIni
            // 
            this.expTextAuraYIni.AutoSize = true;
            this.expTextAuraYIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraYIni.Expression = "";
            this.expTextAuraYIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraYIni.Location = new System.Drawing.Point(123, 208);
            this.expTextAuraYIni.Name = "expTextAuraYIni";
            this.expTextAuraYIni.Size = new System.Drawing.Size(93, 20);
            this.expTextAuraYIni.TabIndex = 16;
            // 
            // lblTextAuraY
            // 
            this.lblTextAuraY.AutoSize = true;
            this.lblTextAuraY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraY.Location = new System.Drawing.Point(3, 205);
            this.lblTextAuraY.Name = "lblTextAuraY";
            this.lblTextAuraY.Size = new System.Drawing.Size(114, 26);
            this.lblTextAuraY.TabIndex = 26;
            this.lblTextAuraY.Text = "Y location expression";
            this.lblTextAuraY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTextAuraXIni
            // 
            this.expTextAuraXIni.AutoSize = true;
            this.expTextAuraXIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraXIni.Expression = "";
            this.expTextAuraXIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraXIni.Location = new System.Drawing.Point(123, 182);
            this.expTextAuraXIni.Name = "expTextAuraXIni";
            this.expTextAuraXIni.Size = new System.Drawing.Size(93, 20);
            this.expTextAuraXIni.TabIndex = 14;
            // 
            // lblTextAuraX
            // 
            this.lblTextAuraX.AutoSize = true;
            this.lblTextAuraX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraX.Location = new System.Drawing.Point(3, 179);
            this.lblTextAuraX.Name = "lblTextAuraX";
            this.lblTextAuraX.Size = new System.Drawing.Size(114, 26);
            this.lblTextAuraX.TabIndex = 24;
            this.lblTextAuraX.Text = "X location expression";
            this.lblTextAuraX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTextAuraName
            // 
            this.expTextAuraName.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.expTextAuraName, 2);
            this.expTextAuraName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraName.Expression = "";
            this.expTextAuraName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expTextAuraName.Location = new System.Drawing.Point(123, 30);
            this.expTextAuraName.Name = "expTextAuraName";
            this.expTextAuraName.Size = new System.Drawing.Size(324, 20);
            this.expTextAuraName.TabIndex = 10;
            this.expTextAuraName.EnabledChanged += new System.EventHandler(this.expTextAuraName_EnabledChanged);
            // 
            // lblTextAuraName
            // 
            this.lblTextAuraName.AutoSize = true;
            this.lblTextAuraName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraName.Location = new System.Drawing.Point(3, 27);
            this.lblTextAuraName.Name = "lblTextAuraName";
            this.lblTextAuraName.Size = new System.Drawing.Size(114, 26);
            this.lblTextAuraName.TabIndex = 15;
            this.lblTextAuraName.Text = "Unique identifier";
            this.lblTextAuraName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTextAuraOp
            // 
            this.lblTextAuraOp.AutoSize = true;
            this.lblTextAuraOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraOp.Location = new System.Drawing.Point(3, 0);
            this.lblTextAuraOp.Name = "lblTextAuraOp";
            this.lblTextAuraOp.Size = new System.Drawing.Size(114, 27);
            this.lblTextAuraOp.TabIndex = 7;
            this.lblTextAuraOp.Text = "Operation";
            this.lblTextAuraOp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxTextAuraOp
            // 
            this.tableLayoutPanel13.SetColumnSpan(this.cbxTextAuraOp, 3);
            this.cbxTextAuraOp.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxTextAuraOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTextAuraOp.FormattingEnabled = true;
            this.cbxTextAuraOp.Items.AddRange(new object[] {
            "Activate or modify the specified text aura",
            "Deactivate the specified text aura",
            "Deactivate all text auras"});
            this.cbxTextAuraOp.Location = new System.Drawing.Point(123, 3);
            this.cbxTextAuraOp.Name = "cbxTextAuraOp";
            this.cbxTextAuraOp.Size = new System.Drawing.Size(399, 21);
            this.cbxTextAuraOp.TabIndex = 9;
            this.cbxTextAuraOp.SelectedIndexChanged += new System.EventHandler(this.cbxTextAuraOp_SelectedIndexChanged);
            // 
            // lblTextAuraIniValues
            // 
            this.lblTextAuraIniValues.BackColor = System.Drawing.SystemColors.Info;
            this.lblTextAuraIniValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTextAuraIniValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraIniValues.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTextAuraIniValues.Location = new System.Drawing.Point(123, 159);
            this.lblTextAuraIniValues.Name = "lblTextAuraIniValues";
            this.lblTextAuraIniValues.Size = new System.Drawing.Size(93, 20);
            this.lblTextAuraIniValues.TabIndex = 40;
            this.lblTextAuraIniValues.Text = "Initial values";
            this.lblTextAuraIniValues.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTextAuraGuide
            // 
            this.tableLayoutPanel13.SetColumnSpan(this.btnTextAuraGuide, 3);
            this.btnTextAuraGuide.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTextAuraGuide.Enabled = false;
            this.btnTextAuraGuide.Location = new System.Drawing.Point(123, 338);
            this.btnTextAuraGuide.Name = "btnTextAuraGuide";
            this.btnTextAuraGuide.Size = new System.Drawing.Size(399, 23);
            this.btnTextAuraGuide.TabIndex = 25;
            this.btnTextAuraGuide.Text = "Use visual guide for placement (right-click for more options)";
            this.btnTextAuraGuide.UseVisualStyleBackColor = true;
            this.btnTextAuraGuide.Click += new System.EventHandler(this.button8_Click);
            // 
            // txtTextAuraFont
            // 
            this.txtTextAuraFont.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTextAuraFont.Location = new System.Drawing.Point(222, 82);
            this.txtTextAuraFont.Name = "txtTextAuraFont";
            this.txtTextAuraFont.ReadOnly = true;
            this.txtTextAuraFont.Size = new System.Drawing.Size(225, 20);
            this.txtTextAuraFont.TabIndex = 53;
            // 
            // colorSelector1
            // 
            this.colorSelector1.AutoSize = true;
            this.colorSelector1.BackgroundColor = System.Drawing.Color.Empty;
            this.colorSelector1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorSelector1.ChangeBackgroundColor = true;
            this.colorSelector1.ChangeTextColor = true;
            this.colorSelector1.ChangeTextOutlineColor = true;
            this.colorSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorSelector1.Location = new System.Drawing.Point(123, 82);
            this.colorSelector1.Name = "colorSelector1";
            this.colorSelector1.Size = new System.Drawing.Size(93, 20);
            this.colorSelector1.TabIndex = 54;
            this.colorSelector1.TextColor = System.Drawing.Color.Empty;
            this.colorSelector1.TextOutlineColor = System.Drawing.Color.Empty;
            this.colorSelector1.EnabledChanged += new System.EventHandler(this.colorSelector1_EnabledChanged);
            // 
            // cbxTextAuraOutline
            // 
            this.cbxTextAuraOutline.AutoSize = true;
            this.cbxTextAuraOutline.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel13.SetColumnSpan(this.cbxTextAuraOutline, 3);
            this.cbxTextAuraOutline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxTextAuraOutline.Location = new System.Drawing.Point(123, 135);
            this.cbxTextAuraOutline.Name = "cbxTextAuraOutline";
            this.cbxTextAuraOutline.Padding = new System.Windows.Forms.Padding(0, 3, 0, 4);
            this.cbxTextAuraOutline.Size = new System.Drawing.Size(399, 21);
            this.cbxTextAuraOutline.TabIndex = 56;
            this.cbxTextAuraOutline.UseVisualStyleBackColor = true;
            this.cbxTextAuraOutline.EnabledChanged += new System.EventHandler(this.cbxTextAuraOutline_EnabledChanged);
            // 
            // tabLogMessage
            // 
            this.tabLogMessage.Controls.Add(this.tableLayoutPanel14);
            this.tabLogMessage.Location = new System.Drawing.Point(4, 25);
            this.tabLogMessage.Name = "tabLogMessage";
            this.tabLogMessage.Size = new System.Drawing.Size(542, 315);
            this.tabLogMessage.TabIndex = 14;
            this.tabLogMessage.Text = "LogMessage";
            this.tabLogMessage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.AutoSize = true;
            this.tableLayoutPanel14.ColumnCount = 2;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Controls.Add(this.cbxProcessLog, 0, 1);
            this.tableLayoutPanel14.Controls.Add(this.lblLogMessageText, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.expLogMessageText, 1, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 2;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.Size = new System.Drawing.Size(542, 53);
            this.tableLayoutPanel14.TabIndex = 2;
            // 
            // cbxProcessLog
            // 
            this.cbxProcessLog.AutoSize = true;
            this.cbxProcessLog.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel14.SetColumnSpan(this.cbxProcessLog, 3);
            this.cbxProcessLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxProcessLog.Location = new System.Drawing.Point(3, 31);
            this.cbxProcessLog.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.cbxProcessLog.Name = "cbxProcessLog";
            this.cbxProcessLog.Size = new System.Drawing.Size(537, 17);
            this.cbxProcessLog.TabIndex = 19;
            this.cbxProcessLog.Text = "Process message as log line";
            this.cbxProcessLog.UseVisualStyleBackColor = true;
            // 
            // lblLogMessageText
            // 
            this.lblLogMessageText.AutoSize = true;
            this.lblLogMessageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogMessageText.Location = new System.Drawing.Point(3, 0);
            this.lblLogMessageText.Name = "lblLogMessageText";
            this.lblLogMessageText.Size = new System.Drawing.Size(79, 26);
            this.lblLogMessageText.TabIndex = 7;
            this.lblLogMessageText.Text = "Message to log";
            this.lblLogMessageText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expLogMessageText
            // 
            this.expLogMessageText.AutoSize = true;
            this.expLogMessageText.Dock = System.Windows.Forms.DockStyle.Top;
            this.expLogMessageText.Expression = "";
            this.expLogMessageText.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expLogMessageText.Location = new System.Drawing.Point(88, 3);
            this.expLogMessageText.Name = "expLogMessageText";
            this.expLogMessageText.Size = new System.Drawing.Size(451, 20);
            this.expLogMessageText.TabIndex = 14;
            // 
            // tabListVariable
            // 
            this.tabListVariable.Controls.Add(this.tableLayoutPanel17);
            this.tabListVariable.Location = new System.Drawing.Point(4, 25);
            this.tabListVariable.Name = "tabListVariable";
            this.tabListVariable.Size = new System.Drawing.Size(542, 315);
            this.tabListVariable.TabIndex = 15;
            this.tabListVariable.Text = "ListVariable";
            this.tabListVariable.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.AutoSize = true;
            this.tableLayoutPanel17.ColumnCount = 2;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.Controls.Add(this.cbxLvarExpType, 1, 2);
            this.tableLayoutPanel17.Controls.Add(this.lblLvarExpType, 0, 2);
            this.tableLayoutPanel17.Controls.Add(this.expLvarTarget, 1, 5);
            this.tableLayoutPanel17.Controls.Add(this.lblLvarTarget, 0, 5);
            this.tableLayoutPanel17.Controls.Add(this.expLvarIndex, 1, 4);
            this.tableLayoutPanel17.Controls.Add(this.lblLvarIndex, 0, 4);
            this.tableLayoutPanel17.Controls.Add(this.expLvarValue, 1, 3);
            this.tableLayoutPanel17.Controls.Add(this.lblLvarValue, 0, 3);
            this.tableLayoutPanel17.Controls.Add(this.expLvarName, 1, 1);
            this.tableLayoutPanel17.Controls.Add(this.lblLvarName, 0, 1);
            this.tableLayoutPanel17.Controls.Add(this.lblLvarOperation, 0, 0);
            this.tableLayoutPanel17.Controls.Add(this.cbxLvarOperation, 1, 0);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 6;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel17.Size = new System.Drawing.Size(542, 158);
            this.tableLayoutPanel17.TabIndex = 7;
            // 
            // cbxLvarExpType
            // 
            this.cbxLvarExpType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxLvarExpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLvarExpType.FormattingEnabled = true;
            this.cbxLvarExpType.Items.AddRange(new object[] {
            "String",
            "Numeric"});
            this.cbxLvarExpType.Location = new System.Drawing.Point(119, 56);
            this.cbxLvarExpType.Name = "cbxLvarExpType";
            this.cbxLvarExpType.Size = new System.Drawing.Size(420, 21);
            this.cbxLvarExpType.TabIndex = 29;
            this.cbxLvarExpType.SelectedIndexChanged += new System.EventHandler(this.cbxLvarExpType_SelectedIndexChanged);
            this.cbxLvarExpType.EnabledChanged += new System.EventHandler(this.cbxLvarExpType_EnabledChanged);
            // 
            // lblLvarExpType
            // 
            this.lblLvarExpType.AutoSize = true;
            this.lblLvarExpType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLvarExpType.Location = new System.Drawing.Point(3, 53);
            this.lblLvarExpType.Name = "lblLvarExpType";
            this.lblLvarExpType.Size = new System.Drawing.Size(110, 27);
            this.lblLvarExpType.TabIndex = 28;
            this.lblLvarExpType.Text = "Expression type";
            this.lblLvarExpType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expLvarTarget
            // 
            this.expLvarTarget.AutoSize = true;
            this.expLvarTarget.Dock = System.Windows.Forms.DockStyle.Top;
            this.expLvarTarget.Expression = "";
            this.expLvarTarget.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expLvarTarget.Location = new System.Drawing.Point(119, 135);
            this.expLvarTarget.Name = "expLvarTarget";
            this.expLvarTarget.Size = new System.Drawing.Size(420, 20);
            this.expLvarTarget.TabIndex = 27;
            this.expLvarTarget.EnabledChanged += new System.EventHandler(this.expLvarTarget_EnabledChanged);
            // 
            // lblLvarTarget
            // 
            this.lblLvarTarget.AutoSize = true;
            this.lblLvarTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLvarTarget.Location = new System.Drawing.Point(3, 132);
            this.lblLvarTarget.Name = "lblLvarTarget";
            this.lblLvarTarget.Size = new System.Drawing.Size(110, 26);
            this.lblLvarTarget.TabIndex = 26;
            this.lblLvarTarget.Text = "Target variable name";
            this.lblLvarTarget.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expLvarIndex
            // 
            this.expLvarIndex.AutoSize = true;
            this.expLvarIndex.Dock = System.Windows.Forms.DockStyle.Top;
            this.expLvarIndex.Expression = "";
            this.expLvarIndex.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expLvarIndex.Location = new System.Drawing.Point(119, 109);
            this.expLvarIndex.Name = "expLvarIndex";
            this.expLvarIndex.Size = new System.Drawing.Size(420, 20);
            this.expLvarIndex.TabIndex = 25;
            this.expLvarIndex.EnabledChanged += new System.EventHandler(this.expLvarIndex_EnabledChanged);
            // 
            // lblLvarIndex
            // 
            this.lblLvarIndex.AutoSize = true;
            this.lblLvarIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLvarIndex.Location = new System.Drawing.Point(3, 106);
            this.lblLvarIndex.Name = "lblLvarIndex";
            this.lblLvarIndex.Size = new System.Drawing.Size(110, 26);
            this.lblLvarIndex.TabIndex = 24;
            this.lblLvarIndex.Text = "List index number";
            this.lblLvarIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expLvarValue
            // 
            this.expLvarValue.AutoSize = true;
            this.expLvarValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.expLvarValue.Expression = "";
            this.expLvarValue.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expLvarValue.Location = new System.Drawing.Point(119, 83);
            this.expLvarValue.Name = "expLvarValue";
            this.expLvarValue.Size = new System.Drawing.Size(420, 20);
            this.expLvarValue.TabIndex = 23;
            this.expLvarValue.EnabledChanged += new System.EventHandler(this.expLvarValue_EnabledChanged);
            // 
            // lblLvarValue
            // 
            this.lblLvarValue.AutoSize = true;
            this.lblLvarValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLvarValue.Location = new System.Drawing.Point(3, 80);
            this.lblLvarValue.Name = "lblLvarValue";
            this.lblLvarValue.Size = new System.Drawing.Size(110, 26);
            this.lblLvarValue.TabIndex = 22;
            this.lblLvarValue.Text = "Expression";
            this.lblLvarValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expLvarName
            // 
            this.expLvarName.AutoSize = true;
            this.expLvarName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expLvarName.Expression = "";
            this.expLvarName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expLvarName.Location = new System.Drawing.Point(119, 30);
            this.expLvarName.Name = "expLvarName";
            this.expLvarName.Size = new System.Drawing.Size(420, 20);
            this.expLvarName.TabIndex = 16;
            this.expLvarName.EnabledChanged += new System.EventHandler(this.expLvarName_EnabledChanged);
            // 
            // lblLvarName
            // 
            this.lblLvarName.AutoSize = true;
            this.lblLvarName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLvarName.Location = new System.Drawing.Point(3, 27);
            this.lblLvarName.Name = "lblLvarName";
            this.lblLvarName.Size = new System.Drawing.Size(110, 26);
            this.lblLvarName.TabIndex = 15;
            this.lblLvarName.Text = "Source variable name";
            this.lblLvarName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLvarOperation
            // 
            this.lblLvarOperation.AutoSize = true;
            this.lblLvarOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLvarOperation.Location = new System.Drawing.Point(3, 0);
            this.lblLvarOperation.Name = "lblLvarOperation";
            this.lblLvarOperation.Size = new System.Drawing.Size(110, 27);
            this.lblLvarOperation.TabIndex = 7;
            this.lblLvarOperation.Text = "Operation type";
            this.lblLvarOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxLvarOperation
            // 
            this.cbxLvarOperation.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxLvarOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLvarOperation.FormattingEnabled = true;
            this.cbxLvarOperation.Items.AddRange(new object[] {
            "Unset list variable",
            "Push value to the end of the list variable",
            "Insert value to the given index of the list variable",
            "Set value at the given index of the list variable",
            "Remove value at the given index of the list variable",
            "Pop last value from list variable into a scalar variable (stack)",
            "Pop first value from list variable into a scalar variable (queue)",
            "Sort list in an alphabetically ascending order",
            "Sort list in an alphabetically descending order",
            "Sort list in an ascending order based on FFXIV party job order",
            "Sort list in a descending order based on FFXIV party job order",
            "Copy whole list variable to another list variable",
            "Insert list variable into another list variable at the given index",
            "Join all values in the list variable into a scalar variable (separator in express" +
                "ion)",
            "Split a scalar variable into a list variable (separator in expression)",
            "Unset all list variables"});
            this.cbxLvarOperation.Location = new System.Drawing.Point(119, 3);
            this.cbxLvarOperation.Name = "cbxLvarOperation";
            this.cbxLvarOperation.Size = new System.Drawing.Size(420, 21);
            this.cbxLvarOperation.TabIndex = 21;
            this.cbxLvarOperation.SelectedIndexChanged += new System.EventHandler(this.cbxLvarOperation_SelectedIndexChanged);
            // 
            // tabObsControl
            // 
            this.tabObsControl.Controls.Add(this.tableLayoutPanel18);
            this.tabObsControl.Location = new System.Drawing.Point(4, 25);
            this.tabObsControl.Name = "tabObsControl";
            this.tabObsControl.Size = new System.Drawing.Size(542, 315);
            this.tabObsControl.TabIndex = 16;
            this.tabObsControl.Text = "OBS";
            this.tabObsControl.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.AutoSize = true;
            this.tableLayoutPanel18.ColumnCount = 3;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel18.Controls.Add(this.expObsSourceName, 1, 3);
            this.tableLayoutPanel18.Controls.Add(this.lblObsSourceName, 0, 3);
            this.tableLayoutPanel18.Controls.Add(this.cbxObsOpType, 1, 0);
            this.tableLayoutPanel18.Controls.Add(this.lblObsOpType, 0, 0);
            this.tableLayoutPanel18.Controls.Add(this.btnObsWebsocketLink, 2, 5);
            this.tableLayoutPanel18.Controls.Add(this.lblObsSceneName, 0, 1);
            this.tableLayoutPanel18.Controls.Add(this.expObsSceneName, 1, 1);
            this.tableLayoutPanel18.Controls.Add(this.lblObsWebsocketInfo, 1, 4);
            this.tableLayoutPanel18.Controls.Add(this.txtObsWebsocketLink, 1, 5);
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 6;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel18.Size = new System.Drawing.Size(542, 151);
            this.tableLayoutPanel18.TabIndex = 3;
            // 
            // expObsSourceName
            // 
            this.expObsSourceName.AutoSize = true;
            this.tableLayoutPanel18.SetColumnSpan(this.expObsSourceName, 2);
            this.expObsSourceName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expObsSourceName.Expression = "";
            this.expObsSourceName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expObsSourceName.Location = new System.Drawing.Point(85, 56);
            this.expObsSourceName.Name = "expObsSourceName";
            this.expObsSourceName.Size = new System.Drawing.Size(454, 20);
            this.expObsSourceName.TabIndex = 24;
            // 
            // lblObsSourceName
            // 
            this.lblObsSourceName.AutoSize = true;
            this.lblObsSourceName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblObsSourceName.Location = new System.Drawing.Point(3, 53);
            this.lblObsSourceName.Name = "lblObsSourceName";
            this.lblObsSourceName.Size = new System.Drawing.Size(76, 26);
            this.lblObsSourceName.TabIndex = 23;
            this.lblObsSourceName.Text = "Source name";
            this.lblObsSourceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxObsOpType
            // 
            this.tableLayoutPanel18.SetColumnSpan(this.cbxObsOpType, 2);
            this.cbxObsOpType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxObsOpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxObsOpType.FormattingEnabled = true;
            this.cbxObsOpType.Items.AddRange(new object[] {
            "Start streaming",
            "Stop streaming",
            "Start/stop streaming (toggle)",
            "Start recording",
            "Stop recording",
            "Start/stop recording (toggle)",
            "Start replay buffer",
            "Stop replay buffer",
            "Start/stop replay buffer (toggle)",
            "Save replay buffer",
            "Set scene",
            "Show source",
            "Hide source"});
            this.cbxObsOpType.Location = new System.Drawing.Point(85, 3);
            this.cbxObsOpType.Name = "cbxObsOpType";
            this.cbxObsOpType.Size = new System.Drawing.Size(454, 21);
            this.cbxObsOpType.TabIndex = 22;
            this.cbxObsOpType.SelectedIndexChanged += new System.EventHandler(this.cbxObsOpType_SelectedIndexChanged);
            // 
            // lblObsOpType
            // 
            this.lblObsOpType.AutoSize = true;
            this.lblObsOpType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblObsOpType.Location = new System.Drawing.Point(3, 0);
            this.lblObsOpType.Name = "lblObsOpType";
            this.lblObsOpType.Size = new System.Drawing.Size(76, 27);
            this.lblObsOpType.TabIndex = 18;
            this.lblObsOpType.Text = "Operation type";
            this.lblObsOpType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnObsWebsocketLink
            // 
            this.btnObsWebsocketLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnObsWebsocketLink.Image = ((System.Drawing.Image)(resources.GetObject("btnObsWebsocketLink.Image")));
            this.btnObsWebsocketLink.Location = new System.Drawing.Point(502, 125);
            this.btnObsWebsocketLink.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnObsWebsocketLink.Name = "btnObsWebsocketLink";
            this.btnObsWebsocketLink.Size = new System.Drawing.Size(37, 26);
            this.btnObsWebsocketLink.TabIndex = 17;
            this.btnObsWebsocketLink.UseVisualStyleBackColor = true;
            this.btnObsWebsocketLink.Click += new System.EventHandler(this.button5_Click);
            // 
            // lblObsSceneName
            // 
            this.lblObsSceneName.AutoSize = true;
            this.lblObsSceneName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblObsSceneName.Location = new System.Drawing.Point(3, 27);
            this.lblObsSceneName.Name = "lblObsSceneName";
            this.lblObsSceneName.Size = new System.Drawing.Size(76, 26);
            this.lblObsSceneName.TabIndex = 7;
            this.lblObsSceneName.Text = "Scene name";
            this.lblObsSceneName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expObsSceneName
            // 
            this.expObsSceneName.AutoSize = true;
            this.tableLayoutPanel18.SetColumnSpan(this.expObsSceneName, 2);
            this.expObsSceneName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expObsSceneName.Expression = "";
            this.expObsSceneName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expObsSceneName.Location = new System.Drawing.Point(85, 30);
            this.expObsSceneName.Name = "expObsSceneName";
            this.expObsSceneName.Size = new System.Drawing.Size(454, 20);
            this.expObsSceneName.TabIndex = 14;
            // 
            // lblObsWebsocketInfo
            // 
            this.lblObsWebsocketInfo.AutoSize = true;
            this.tableLayoutPanel18.SetColumnSpan(this.lblObsWebsocketInfo, 2);
            this.lblObsWebsocketInfo.Location = new System.Drawing.Point(85, 79);
            this.lblObsWebsocketInfo.Name = "lblObsWebsocketInfo";
            this.lblObsWebsocketInfo.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.lblObsWebsocketInfo.Size = new System.Drawing.Size(452, 46);
            this.lblObsWebsocketInfo.TabIndex = 15;
            this.lblObsWebsocketInfo.Text = "To use OBS remote control features, you will have to install the OBS WebSocket pl" +
    "ugin. There is a simple installer available at:";
            // 
            // txtObsWebsocketLink
            // 
            this.txtObsWebsocketLink.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtObsWebsocketLink.Location = new System.Drawing.Point(85, 128);
            this.txtObsWebsocketLink.Name = "txtObsWebsocketLink";
            this.txtObsWebsocketLink.ReadOnly = true;
            this.txtObsWebsocketLink.Size = new System.Drawing.Size(414, 20);
            this.txtObsWebsocketLink.TabIndex = 16;
            this.txtObsWebsocketLink.Text = "https://obsproject.com/forum/resources/obs-websocket-remote-control-of-obs-studio" +
    "-made-easy.466/";
            // 
            // tabGenericJson
            // 
            this.tabGenericJson.Controls.Add(this.jsonTableLayout);
            this.tabGenericJson.Location = new System.Drawing.Point(4, 25);
            this.tabGenericJson.Name = "tabGenericJson";
            this.tabGenericJson.Size = new System.Drawing.Size(542, 315);
            this.tabGenericJson.TabIndex = 17;
            this.tabGenericJson.Text = "JSON";
            this.tabGenericJson.UseVisualStyleBackColor = true;
            // 
            // jsonTableLayout
            // 
            this.jsonTableLayout.AutoSize = true;
            this.jsonTableLayout.ColumnCount = 2;
            this.jsonTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.jsonTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.jsonTableLayout.Controls.Add(this.lblJsonInstructions, 1, 3);
            this.jsonTableLayout.Controls.Add(this.expJsonFiring, 1, 2);
            this.jsonTableLayout.Controls.Add(this.lblJsonFiring, 0, 2);
            this.jsonTableLayout.Controls.Add(this.expJsonPayload, 1, 1);
            this.jsonTableLayout.Controls.Add(this.lblJsonPayload, 0, 1);
            this.jsonTableLayout.Controls.Add(this.lblJsonEndpoint, 0, 0);
            this.jsonTableLayout.Controls.Add(this.expJsonEndpoint, 1, 0);
            this.jsonTableLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.jsonTableLayout.Location = new System.Drawing.Point(0, 0);
            this.jsonTableLayout.Name = "jsonTableLayout";
            this.jsonTableLayout.RowCount = 4;
            this.jsonTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.jsonTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.jsonTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.jsonTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.jsonTableLayout.Size = new System.Drawing.Size(542, 189);
            this.jsonTableLayout.TabIndex = 3;
            // 
            // lblJsonInstructions
            // 
            this.lblJsonInstructions.AutoSize = true;
            this.lblJsonInstructions.Location = new System.Drawing.Point(142, 78);
            this.lblJsonInstructions.Name = "lblJsonInstructions";
            this.lblJsonInstructions.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.lblJsonInstructions.Size = new System.Drawing.Size(395, 111);
            this.lblJsonInstructions.TabIndex = 21;
            this.lblJsonInstructions.Text = resources.GetString("lblJsonInstructions.Text");
            // 
            // expJsonFiring
            // 
            this.expJsonFiring.AutoSize = true;
            this.expJsonFiring.Dock = System.Windows.Forms.DockStyle.Top;
            this.expJsonFiring.Expression = "";
            this.expJsonFiring.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expJsonFiring.Location = new System.Drawing.Point(142, 55);
            this.expJsonFiring.Name = "expJsonFiring";
            this.expJsonFiring.Size = new System.Drawing.Size(397, 20);
            this.expJsonFiring.TabIndex = 20;
            // 
            // lblJsonFiring
            // 
            this.lblJsonFiring.AutoSize = true;
            this.lblJsonFiring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJsonFiring.Location = new System.Drawing.Point(3, 52);
            this.lblJsonFiring.Name = "lblJsonFiring";
            this.lblJsonFiring.Size = new System.Drawing.Size(133, 26);
            this.lblJsonFiring.TabIndex = 19;
            this.lblJsonFiring.Text = "Response firing expression";
            this.lblJsonFiring.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expJsonPayload
            // 
            this.expJsonPayload.AutoSize = true;
            this.expJsonPayload.Dock = System.Windows.Forms.DockStyle.Top;
            this.expJsonPayload.Expression = "";
            this.expJsonPayload.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expJsonPayload.Location = new System.Drawing.Point(142, 29);
            this.expJsonPayload.Name = "expJsonPayload";
            this.expJsonPayload.Size = new System.Drawing.Size(397, 20);
            this.expJsonPayload.TabIndex = 16;
            // 
            // lblJsonPayload
            // 
            this.lblJsonPayload.AutoSize = true;
            this.lblJsonPayload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJsonPayload.Location = new System.Drawing.Point(3, 26);
            this.lblJsonPayload.Name = "lblJsonPayload";
            this.lblJsonPayload.Size = new System.Drawing.Size(133, 26);
            this.lblJsonPayload.TabIndex = 15;
            this.lblJsonPayload.Text = "Payload to send";
            this.lblJsonPayload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblJsonEndpoint
            // 
            this.lblJsonEndpoint.AutoSize = true;
            this.lblJsonEndpoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJsonEndpoint.Location = new System.Drawing.Point(3, 0);
            this.lblJsonEndpoint.Name = "lblJsonEndpoint";
            this.lblJsonEndpoint.Size = new System.Drawing.Size(133, 26);
            this.lblJsonEndpoint.TabIndex = 7;
            this.lblJsonEndpoint.Text = "Endpoint URL";
            this.lblJsonEndpoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expJsonEndpoint
            // 
            this.expJsonEndpoint.AutoSize = true;
            this.expJsonEndpoint.Dock = System.Windows.Forms.DockStyle.Top;
            this.expJsonEndpoint.Expression = "";
            this.expJsonEndpoint.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expJsonEndpoint.Location = new System.Drawing.Point(142, 3);
            this.expJsonEndpoint.Name = "expJsonEndpoint";
            this.expJsonEndpoint.Size = new System.Drawing.Size(397, 20);
            this.expJsonEndpoint.TabIndex = 14;
            // 
            // tabWindowMessage
            // 
            this.tabWindowMessage.Controls.Add(this.tableLayoutPanel19);
            this.tabWindowMessage.Controls.Add(this.panel7);
            this.tabWindowMessage.Location = new System.Drawing.Point(4, 25);
            this.tabWindowMessage.Name = "tabWindowMessage";
            this.tabWindowMessage.Padding = new System.Windows.Forms.Padding(3);
            this.tabWindowMessage.Size = new System.Drawing.Size(542, 315);
            this.tabWindowMessage.TabIndex = 18;
            this.tabWindowMessage.Text = "Wmsg";
            this.tabWindowMessage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel19
            // 
            this.tableLayoutPanel19.AutoSize = true;
            this.tableLayoutPanel19.ColumnCount = 3;
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel19.Controls.Add(this.expWmsgLparam, 1, 3);
            this.tableLayoutPanel19.Controls.Add(this.lblWmsgLparam, 0, 3);
            this.tableLayoutPanel19.Controls.Add(this.expWmsgWparam, 1, 2);
            this.tableLayoutPanel19.Controls.Add(this.lblWmsgWparam, 0, 2);
            this.tableLayoutPanel19.Controls.Add(this.expWmsgCode, 1, 1);
            this.tableLayoutPanel19.Controls.Add(this.expWmsgTitle, 1, 0);
            this.tableLayoutPanel19.Controls.Add(this.lblWmsgCode, 0, 1);
            this.tableLayoutPanel19.Controls.Add(this.lblWmsgTitle, 0, 0);
            this.tableLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel19.Location = new System.Drawing.Point(3, 54);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            this.tableLayoutPanel19.RowCount = 4;
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.Size = new System.Drawing.Size(536, 104);
            this.tableLayoutPanel19.TabIndex = 3;
            // 
            // expWmsgLparam
            // 
            this.expWmsgLparam.AutoSize = true;
            this.tableLayoutPanel19.SetColumnSpan(this.expWmsgLparam, 2);
            this.expWmsgLparam.Dock = System.Windows.Forms.DockStyle.Top;
            this.expWmsgLparam.Expression = "";
            this.expWmsgLparam.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expWmsgLparam.Location = new System.Drawing.Point(86, 81);
            this.expWmsgLparam.Name = "expWmsgLparam";
            this.expWmsgLparam.Size = new System.Drawing.Size(447, 20);
            this.expWmsgLparam.TabIndex = 30;
            // 
            // lblWmsgLparam
            // 
            this.lblWmsgLparam.AutoSize = true;
            this.lblWmsgLparam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWmsgLparam.Location = new System.Drawing.Point(3, 78);
            this.lblWmsgLparam.Name = "lblWmsgLparam";
            this.lblWmsgLparam.Size = new System.Drawing.Size(77, 26);
            this.lblWmsgLparam.TabIndex = 29;
            this.lblWmsgLparam.Text = "LParam";
            this.lblWmsgLparam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expWmsgWparam
            // 
            this.expWmsgWparam.AutoSize = true;
            this.tableLayoutPanel19.SetColumnSpan(this.expWmsgWparam, 2);
            this.expWmsgWparam.Dock = System.Windows.Forms.DockStyle.Top;
            this.expWmsgWparam.Expression = "";
            this.expWmsgWparam.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expWmsgWparam.Location = new System.Drawing.Point(86, 55);
            this.expWmsgWparam.Name = "expWmsgWparam";
            this.expWmsgWparam.Size = new System.Drawing.Size(447, 20);
            this.expWmsgWparam.TabIndex = 28;
            // 
            // lblWmsgWparam
            // 
            this.lblWmsgWparam.AutoSize = true;
            this.lblWmsgWparam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWmsgWparam.Location = new System.Drawing.Point(3, 52);
            this.lblWmsgWparam.Name = "lblWmsgWparam";
            this.lblWmsgWparam.Size = new System.Drawing.Size(77, 26);
            this.lblWmsgWparam.TabIndex = 27;
            this.lblWmsgWparam.Text = "WParam";
            this.lblWmsgWparam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expWmsgCode
            // 
            this.expWmsgCode.AutoSize = true;
            this.tableLayoutPanel19.SetColumnSpan(this.expWmsgCode, 2);
            this.expWmsgCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.expWmsgCode.Expression = "";
            this.expWmsgCode.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expWmsgCode.Location = new System.Drawing.Point(86, 29);
            this.expWmsgCode.Name = "expWmsgCode";
            this.expWmsgCode.Size = new System.Drawing.Size(447, 20);
            this.expWmsgCode.TabIndex = 26;
            // 
            // expWmsgTitle
            // 
            this.expWmsgTitle.AutoSize = true;
            this.tableLayoutPanel19.SetColumnSpan(this.expWmsgTitle, 2);
            this.expWmsgTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.expWmsgTitle.Expression = "";
            this.expWmsgTitle.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expWmsgTitle.Location = new System.Drawing.Point(86, 3);
            this.expWmsgTitle.Name = "expWmsgTitle";
            this.expWmsgTitle.Size = new System.Drawing.Size(447, 20);
            this.expWmsgTitle.TabIndex = 25;
            // 
            // lblWmsgCode
            // 
            this.lblWmsgCode.AutoSize = true;
            this.lblWmsgCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWmsgCode.Location = new System.Drawing.Point(3, 26);
            this.lblWmsgCode.Name = "lblWmsgCode";
            this.lblWmsgCode.Size = new System.Drawing.Size(77, 26);
            this.lblWmsgCode.TabIndex = 24;
            this.lblWmsgCode.Text = "Message code";
            this.lblWmsgCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWmsgTitle
            // 
            this.lblWmsgTitle.AutoSize = true;
            this.lblWmsgTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWmsgTitle.Location = new System.Drawing.Point(3, 0);
            this.lblWmsgTitle.Name = "lblWmsgTitle";
            this.lblWmsgTitle.Size = new System.Drawing.Size(77, 26);
            this.lblWmsgTitle.TabIndex = 23;
            this.lblWmsgTitle.Text = "Window title";
            this.lblWmsgTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.Controls.Add(this.lblWmsgWarning);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel7.Size = new System.Drawing.Size(536, 51);
            this.panel7.TabIndex = 5;
            // 
            // lblWmsgWarning
            // 
            this.lblWmsgWarning.AutoEllipsis = true;
            this.lblWmsgWarning.BackColor = System.Drawing.SystemColors.Info;
            this.lblWmsgWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWmsgWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWmsgWarning.Location = new System.Drawing.Point(0, 0);
            this.lblWmsgWarning.Name = "lblWmsgWarning";
            this.lblWmsgWarning.Size = new System.Drawing.Size(536, 41);
            this.lblWmsgWarning.TabIndex = 0;
            this.lblWmsgWarning.Text = "Actions of this type may be potentially dangerous and cause damage if, for exampl" +
    "e, the trigger is fired with parameters that fall outside of the expected values" +
    ". Please be aware of the risk.";
            this.lblWmsgWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(10, 456);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(564, 10);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnOk);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 466);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(564, 35);
            this.panel3.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnTest);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(150, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel6.Size = new System.Drawing.Size(264, 35);
            this.panel6.TabIndex = 2;
            // 
            // btnTest
            // 
            this.btnTest.AutoSize = true;
            this.btnTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTest.Location = new System.Drawing.Point(10, 0);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(244, 35);
            this.btnTest.TabIndex = 102;
            this.btnTest.Text = "Test action";
            this.btnTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(414, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 35);
            this.btnCancel.TabIndex = 102;
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
            this.btnOk.TabIndex = 100;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Sound files (*.wav, *.mp3)|*.wav;*.mp3|All files (*.*)|*.*";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "Select sound file to play";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "Executables (*.exe)|*.exe|All files (*.*)|*.*";
            this.openFileDialog2.RestoreDirectory = true;
            this.openFileDialog2.Title = "Select process to launch";
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.Filter = "Image files (*.gif, *.bmp, *.png, *.jpg, *.jpeg)|*.gif;*.bmp;*.png;*.jpg;*.jpeg|A" +
    "ll files (*.*)|*.*";
            this.openFileDialog3.RestoreDirectory = true;
            this.openFileDialog3.Title = "Select image file to display";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbcAction
            // 
            this.tbcAction.Controls.Add(this.tabActionSettings);
            this.tbcAction.Controls.Add(this.tabActionCondition);
            this.tbcAction.Controls.Add(this.tabScheduling);
            this.tbcAction.Controls.Add(this.tabDebugging);
            this.tbcAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcAction.Location = new System.Drawing.Point(10, 131);
            this.tbcAction.Name = "tbcAction";
            this.tbcAction.SelectedIndex = 0;
            this.tbcAction.Size = new System.Drawing.Size(564, 325);
            this.tbcAction.TabIndex = 7;
            // 
            // tabActionSettings
            // 
            this.tabActionSettings.Controls.Add(this.tbcActionSettings);
            this.tabActionSettings.Location = new System.Drawing.Point(4, 22);
            this.tabActionSettings.Name = "tabActionSettings";
            this.tabActionSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabActionSettings.Size = new System.Drawing.Size(556, 299);
            this.tabActionSettings.TabIndex = 0;
            this.tabActionSettings.Text = "Action-specific settings";
            this.tabActionSettings.UseVisualStyleBackColor = true;
            // 
            // tabActionCondition
            // 
            this.tabActionCondition.Controls.Add(this.cndCondition);
            this.tabActionCondition.Location = new System.Drawing.Point(4, 22);
            this.tabActionCondition.Name = "tabActionCondition";
            this.tabActionCondition.Padding = new System.Windows.Forms.Padding(3);
            this.tabActionCondition.Size = new System.Drawing.Size(556, 350);
            this.tabActionCondition.TabIndex = 4;
            this.tabActionCondition.Text = "Action condition";
            this.tabActionCondition.UseVisualStyleBackColor = true;
            // 
            // cndCondition
            // 
            this.cndCondition.ConditionToEdit = null;
            this.cndCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cndCondition.Location = new System.Drawing.Point(3, 3);
            this.cndCondition.Name = "cndCondition";
            this.cndCondition.Size = new System.Drawing.Size(550, 344);
            this.cndCondition.TabIndex = 0;
            // 
            // tabScheduling
            // 
            this.tabScheduling.Controls.Add(this.tableLayoutPanel15);
            this.tabScheduling.Location = new System.Drawing.Point(4, 22);
            this.tabScheduling.Name = "tabScheduling";
            this.tabScheduling.Padding = new System.Windows.Forms.Padding(7);
            this.tabScheduling.Size = new System.Drawing.Size(556, 350);
            this.tabScheduling.TabIndex = 2;
            this.tabScheduling.Text = "Scheduling";
            this.tabScheduling.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.AutoSize = true;
            this.tableLayoutPanel15.ColumnCount = 2;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel15.Controls.Add(this.chkExecuteAsync, 0, 3);
            this.tableLayoutPanel15.Controls.Add(this.lblExecutionDelay, 0, 2);
            this.tableLayoutPanel15.Controls.Add(this.cbxRefireOption2, 1, 1);
            this.tableLayoutPanel15.Controls.Add(this.cbxRefireOption1, 1, 0);
            this.tableLayoutPanel15.Controls.Add(this.lblRefireOption1, 0, 0);
            this.tableLayoutPanel15.Controls.Add(this.expExecutionDelay, 1, 2);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(7, 7);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 4;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.Size = new System.Drawing.Size(542, 107);
            this.tableLayoutPanel15.TabIndex = 1;
            // 
            // chkExecuteAsync
            // 
            this.chkExecuteAsync.AutoSize = true;
            this.chkExecuteAsync.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel15.SetColumnSpan(this.chkExecuteAsync, 2);
            this.chkExecuteAsync.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkExecuteAsync.Location = new System.Drawing.Point(3, 85);
            this.chkExecuteAsync.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkExecuteAsync.Name = "chkExecuteAsync";
            this.chkExecuteAsync.Size = new System.Drawing.Size(537, 17);
            this.chkExecuteAsync.TabIndex = 8;
            this.chkExecuteAsync.Text = "Execute asynchronously without blocking other actions from executing";
            this.chkExecuteAsync.UseVisualStyleBackColor = true;
            // 
            // lblExecutionDelay
            // 
            this.lblExecutionDelay.AutoSize = true;
            this.lblExecutionDelay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExecutionDelay.Location = new System.Drawing.Point(3, 54);
            this.lblExecutionDelay.Name = "lblExecutionDelay";
            this.lblExecutionDelay.Size = new System.Drawing.Size(263, 26);
            this.lblExecutionDelay.TabIndex = 6;
            this.lblExecutionDelay.Text = "Execution delay from last action (ms)";
            this.lblExecutionDelay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxRefireOption2
            // 
            this.cbxRefireOption2.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxRefireOption2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRefireOption2.FormattingEnabled = true;
            this.cbxRefireOption2.Items.AddRange(new object[] {
            "...and do not queue a new instance this action",
            "...and queue a new instance this action"});
            this.cbxRefireOption2.Location = new System.Drawing.Point(272, 30);
            this.cbxRefireOption2.Name = "cbxRefireOption2";
            this.cbxRefireOption2.Size = new System.Drawing.Size(267, 21);
            this.cbxRefireOption2.TabIndex = 4;
            // 
            // cbxRefireOption1
            // 
            this.cbxRefireOption1.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxRefireOption1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRefireOption1.FormattingEnabled = true;
            this.cbxRefireOption1.Items.AddRange(new object[] {
            "Interrupt all previously queued instances...",
            "Keep all previously queued instances..."});
            this.cbxRefireOption1.Location = new System.Drawing.Point(272, 3);
            this.cbxRefireOption1.Name = "cbxRefireOption1";
            this.cbxRefireOption1.Size = new System.Drawing.Size(267, 21);
            this.cbxRefireOption1.TabIndex = 3;
            // 
            // lblRefireOption1
            // 
            this.lblRefireOption1.AutoSize = true;
            this.lblRefireOption1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRefireOption1.Location = new System.Drawing.Point(3, 0);
            this.lblRefireOption1.Name = "lblRefireOption1";
            this.lblRefireOption1.Size = new System.Drawing.Size(263, 27);
            this.lblRefireOption1.TabIndex = 2;
            this.lblRefireOption1.Text = "If the trigger fires again while this action is still in queue";
            this.lblRefireOption1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expExecutionDelay
            // 
            this.expExecutionDelay.AutoSize = true;
            this.expExecutionDelay.Dock = System.Windows.Forms.DockStyle.Top;
            this.expExecutionDelay.Expression = "";
            this.expExecutionDelay.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expExecutionDelay.Location = new System.Drawing.Point(272, 57);
            this.expExecutionDelay.Name = "expExecutionDelay";
            this.expExecutionDelay.Size = new System.Drawing.Size(267, 20);
            this.expExecutionDelay.TabIndex = 7;
            // 
            // tabDebugging
            // 
            this.tabDebugging.Controls.Add(this.tableLayoutPanel16);
            this.tabDebugging.Location = new System.Drawing.Point(4, 22);
            this.tabDebugging.Name = "tabDebugging";
            this.tabDebugging.Padding = new System.Windows.Forms.Padding(7);
            this.tabDebugging.Size = new System.Drawing.Size(556, 350);
            this.tabDebugging.TabIndex = 3;
            this.tabDebugging.Text = "Debugging";
            this.tabDebugging.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.AutoSize = true;
            this.tableLayoutPanel16.ColumnCount = 2;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.Controls.Add(this.cbxLoggingLevel, 1, 0);
            this.tableLayoutPanel16.Controls.Add(this.lblLoggingLevel, 0, 0);
            this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel16.Location = new System.Drawing.Point(7, 7);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 1;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(542, 27);
            this.tableLayoutPanel16.TabIndex = 2;
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
            "Verbose debug",
            "(inherit from trigger)"});
            this.cbxLoggingLevel.Location = new System.Drawing.Point(115, 3);
            this.cbxLoggingLevel.Name = "cbxLoggingLevel";
            this.cbxLoggingLevel.Size = new System.Drawing.Size(424, 21);
            this.cbxLoggingLevel.TabIndex = 3;
            // 
            // lblLoggingLevel
            // 
            this.lblLoggingLevel.AutoSize = true;
            this.lblLoggingLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoggingLevel.Location = new System.Drawing.Point(3, 0);
            this.lblLoggingLevel.Name = "lblLoggingLevel";
            this.lblLoggingLevel.Size = new System.Drawing.Size(106, 27);
            this.lblLoggingLevel.TabIndex = 2;
            this.lblLoggingLevel.Text = "Logging filtering level";
            this.lblLoggingLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fontDialog1
            // 
            this.fontDialog1.AllowScriptChange = false;
            // 
            // expressionTextBox1
            // 
            this.expressionTextBox1.AutoSize = true;
            this.expressionTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.expressionTextBox1.Expression = "";
            this.expressionTextBox1.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expressionTextBox1.Location = new System.Drawing.Point(97, 3);
            this.expressionTextBox1.Name = "expressionTextBox1";
            this.expressionTextBox1.Size = new System.Drawing.Size(405, 20);
            this.expressionTextBox1.TabIndex = 14;
            // 
            // expressionTextBox2
            // 
            this.expressionTextBox2.AutoSize = true;
            this.expressionTextBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.expressionTextBox2.Expression = "";
            this.expressionTextBox2.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expressionTextBox2.Location = new System.Drawing.Point(68, 3);
            this.expressionTextBox2.Name = "expressionTextBox2";
            this.expressionTextBox2.Size = new System.Drawing.Size(474, 20);
            this.expressionTextBox2.TabIndex = 14;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Control;
            this.panel8.Controls.Add(this.lblReadOnly);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(10, 80);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel8.Size = new System.Drawing.Size(564, 51);
            this.panel8.TabIndex = 15;
            this.panel8.Visible = false;
            // 
            // lblReadOnly
            // 
            this.lblReadOnly.AutoEllipsis = true;
            this.lblReadOnly.BackColor = System.Drawing.SystemColors.Info;
            this.lblReadOnly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReadOnly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReadOnly.Location = new System.Drawing.Point(0, 0);
            this.lblReadOnly.Name = "lblReadOnly";
            this.lblReadOnly.Size = new System.Drawing.Size(564, 41);
            this.lblReadOnly.TabIndex = 0;
            this.lblReadOnly.Text = "You are in read-only mode, as the configuration of remote triggers can\'t be edite" +
    "d locally. If you wish to edit the action, you will need to make a local copy of" +
    " the trigger.";
            this.lblReadOnly.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ActionForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(584, 511);
            this.Controls.Add(this.tbcAction);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpGeneralSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(600, 550);
            this.Name = "ActionForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.grpGeneralSettings.ResumeLayout(false);
            this.grpGeneralSettings.PerformLayout();
            this.tbcActionSettings.ResumeLayout(false);
            this.tabSystemBeep.ResumeLayout(false);
            this.tabSystemBeep.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPlaySoundFile.ResumeLayout(false);
            this.tabPlaySoundFile.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabTextToSpeech.ResumeLayout(false);
            this.tabTextToSpeech.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tabLaunchProcess.ResumeLayout(false);
            this.tabLaunchProcess.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tabTriggerOperation.ResumeLayout(false);
            this.tabTriggerOperation.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tabKeypress.ResumeLayout(false);
            this.tabKeypress.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tabScript.ResumeLayout(false);
            this.tabScript.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.tabMessageBox.ResumeLayout(false);
            this.tabMessageBox.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tabVariable.ResumeLayout(false);
            this.tabVariable.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tabImageAura.ResumeLayout(false);
            this.tabImageAura.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tabFolderOperation.ResumeLayout(false);
            this.tabFolderOperation.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.tabEndEncounter.ResumeLayout(false);
            this.tabDiscordWebhook.ResumeLayout(false);
            this.tabDiscordWebhook.PerformLayout();
            this.discordTableLayout.ResumeLayout(false);
            this.discordTableLayout.PerformLayout();
            this.tabTextAura.ResumeLayout(false);
            this.tabTextAura.PerformLayout();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.tabLogMessage.ResumeLayout(false);
            this.tabLogMessage.PerformLayout();
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            this.tabListVariable.ResumeLayout(false);
            this.tabListVariable.PerformLayout();
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            this.tabObsControl.ResumeLayout(false);
            this.tabObsControl.PerformLayout();
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel18.PerformLayout();
            this.tabGenericJson.ResumeLayout(false);
            this.tabGenericJson.PerformLayout();
            this.jsonTableLayout.ResumeLayout(false);
            this.jsonTableLayout.PerformLayout();
            this.tabWindowMessage.ResumeLayout(false);
            this.tabWindowMessage.PerformLayout();
            this.tableLayoutPanel19.ResumeLayout(false);
            this.tableLayoutPanel19.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tbcAction.ResumeLayout(false);
            this.tabActionSettings.ResumeLayout(false);
            this.tabActionCondition.ResumeLayout(false);
            this.tabScheduling.ResumeLayout(false);
            this.tabScheduling.PerformLayout();
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.tabDebugging.ResumeLayout(false);
            this.tabDebugging.PerformLayout();
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblActionType;
        private System.Windows.Forms.ComboBox cbxActionType;
        private System.Windows.Forms.GroupBox grpGeneralSettings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tbcActionSettings;
        private System.Windows.Forms.TabPage tabSystemBeep;
        private System.Windows.Forms.TabPage tabPlaySoundFile;
        private System.Windows.Forms.TabPage tabTextToSpeech;
        private System.Windows.Forms.TabPage tabLaunchProcess;
        private System.Windows.Forms.TabPage tabTriggerOperation;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblBeepLength;
        private System.Windows.Forms.Label lblBeepFrequency;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblSoundFile;
        private System.Windows.Forms.Button button3;
        private CustomControls.ExpressionTextBox expressionTextBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblTextToSay;
        private CustomControls.ExpressionTextBox expressionTextBox2;
        private CustomControls.ExpressionTextBox expSoundFile;
        private CustomControls.ExpressionTextBox expTextToSay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblProcessName;
        private System.Windows.Forms.Button button6;
        private CustomControls.ExpressionTextBox expProcessName;
        private CustomControls.ExpressionTextBox expProcessParameters;
        private System.Windows.Forms.Label lblProcessParameters;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblProcessWarning;
        private CustomControls.ExpressionTextBox expBeepLength;
        private CustomControls.ExpressionTextBox expBeepFrequency;
        internal System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private CustomControls.ExpressionTextBox expSpeechRate;
        private System.Windows.Forms.Label lblSpeechRate;
        private CustomControls.ExpressionTextBox expSpeechVolume;
        private System.Windows.Forms.Label lblSpeechVolume;
        private CustomControls.ExpressionTextBox expSoundVolume;
        private System.Windows.Forms.Label lblSoundVolume;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.CheckBox chkSoundExclusive;
        private System.Windows.Forms.CheckBox chkSpeechExclusive;
        private CustomControls.ExpressionTextBox expProcessWorkingDir;
        private System.Windows.Forms.Label lblProcessWorkingDir;
        private System.Windows.Forms.ComboBox cbxProcessWindowStyle;
        private System.Windows.Forms.Label lblProcessWindowStyle;
        private System.Windows.Forms.TabPage tabKeypress;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lblKeypresses;
        private CustomControls.ExpressionTextBox expKeypresses;
        private System.Windows.Forms.TabPage tabScript;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private CustomControls.ExpressionTextBox expExecScriptCode;
        private System.Windows.Forms.Label lblExecScriptCode;
        private System.Windows.Forms.Label lblExecScriptLang;
        private System.Windows.Forms.ComboBox cbxExecScriptLang;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblScriptWarning;
        private CustomControls.ExpressionTextBox expExecScriptAssemblies;
        private System.Windows.Forms.Label lblExecScriptAssemblies;
        private System.Windows.Forms.TabPage tabMessageBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private CustomControls.ExpressionTextBox expMessageBoxText;
        private System.Windows.Forms.Label lblMessageBoxText;
        private System.Windows.Forms.Label lblMessageBoxIcon;
        private System.Windows.Forms.ComboBox cbxMessageBoxIcon;
        private System.Windows.Forms.TabPage tabVariable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private CustomControls.ExpressionTextBox expVariableExpression;
        private System.Windows.Forms.Label lblVariableExpression;
        private CustomControls.ExpressionTextBox expVariableName;
        private System.Windows.Forms.Label lblVariableName;
        private System.Windows.Forms.Label lblVariableOp;
        private System.Windows.Forms.ComboBox cbxVariableOp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label lblTrigger;
        private CustomControls.ExpressionTextBox expTriggerText;
        private System.Windows.Forms.Label lblTriggerText;
        private System.Windows.Forms.Label lblTriggerOp;
        private System.Windows.Forms.ComboBox cbxTriggerOp;
        private CustomControls.ExpressionTextBox expTriggerZone;
        private System.Windows.Forms.Label lblTriggerZone;
        internal System.Windows.Forms.TreeView trvTrigger;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblKeypressesInfo;
        private System.Windows.Forms.Button btnSendKeysLink;
        private System.Windows.Forms.TextBox txtSendKeysLink;
        private System.Windows.Forms.TabPage tabImageAura;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private CustomControls.ExpressionTextBox expAuraOIni;
        private CustomControls.ExpressionTextBox expAuraHIni;
        private CustomControls.ExpressionTextBox expAuraWIni;
        private System.Windows.Forms.Label lblAuraTtl;
        private System.Windows.Forms.Label lblAuraOpacity;
        private System.Windows.Forms.Label lblAuraWidth;
        private System.Windows.Forms.Label lblAuraHeight;
        private System.Windows.Forms.Button btnBrowseAura;
        private CustomControls.ExpressionTextBox expAuraImage;
        private System.Windows.Forms.Label lblAuraImage;
        private CustomControls.ExpressionTextBox expAuraYIni;
        private System.Windows.Forms.Label lblAuraY;
        private CustomControls.ExpressionTextBox expAuraXIni;
        private System.Windows.Forms.Label lblAuraX;
        private CustomControls.ExpressionTextBox expAuraName;
        private System.Windows.Forms.Label lblAuraName;
        private System.Windows.Forms.Label lblAuraOp;
        private System.Windows.Forms.ComboBox cbxAuraOp;
        private System.Windows.Forms.Label lblUpdateTickExp;
        private System.Windows.Forms.Label lblInitialValues;
        private CustomControls.ExpressionTextBox expAuraTTLTick;
        private CustomControls.ExpressionTextBox expAuraOTick;
        private CustomControls.ExpressionTextBox expAuraHTick;
        private CustomControls.ExpressionTextBox expAuraWTick;
        private CustomControls.ExpressionTextBox expAuraYTick;
        private CustomControls.ExpressionTextBox expAuraXTick;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.Label lblAuraDisplay;
        private System.Windows.Forms.ComboBox cbxAuraDisplay;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Timer timer1;
        private CustomControls.SplitButton btnTest;
        private System.Windows.Forms.TabPage tabFolderOperation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.Label lblFolderOp;
        private System.Windows.Forms.ComboBox cbxFolderOp;
        internal System.Windows.Forms.TreeView trvFolder;
        private System.Windows.Forms.TabPage tabEndEncounter;
        private System.Windows.Forms.Label lblEndEncNoParams;
        private System.Windows.Forms.TabPage tabTextAura;
        private System.Windows.Forms.Button btnAuraGuide;
        private System.Windows.Forms.TabControl tbcAction;
        private System.Windows.Forms.TabPage tabActionSettings;
        private System.Windows.Forms.TabPage tabDiscordWebhook;
        private System.Windows.Forms.TableLayoutPanel discordTableLayout;
        private CustomControls.ExpressionTextBox expDiscordMessage;
        private System.Windows.Forms.Label lblDiscordMessage;
        private System.Windows.Forms.Label lblDiscordUrl;
        private CustomControls.ExpressionTextBox expDiscordUrl;
        private System.Windows.Forms.Label lblFiringOptions;
        private System.Windows.Forms.CheckedListBox cbxFiringOptions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.Button btnTextAuraHide;
        private System.Windows.Forms.ComboBox cbxTextAuraAlignment;
        private System.Windows.Forms.Label lblTextAuraAlignment;
        private CustomControls.ExpressionTextBox expTextAuraTTLTick;
        private CustomControls.ExpressionTextBox expTextAuraOTick;
        private CustomControls.ExpressionTextBox expTextAuraHTick;
        private CustomControls.ExpressionTextBox expTextAuraWTick;
        private CustomControls.ExpressionTextBox expTextAuraYTick;
        private CustomControls.ExpressionTextBox expTextAuraXTick;
        private System.Windows.Forms.Label lblTextAuraUpdValues;
        private CustomControls.ExpressionTextBox expTextAuraOIni;
        private CustomControls.ExpressionTextBox expTextAuraHIni;
        private CustomControls.ExpressionTextBox expTextAuraWIni;
        private System.Windows.Forms.Label lblTextAuraTtlExp;
        private System.Windows.Forms.Label lblTextAuraOpacity;
        private System.Windows.Forms.Label lblTextAuraWidth;
        private System.Windows.Forms.Label lblTextAuraHeight;
        private CustomControls.ExpressionTextBox expTextAuraText;
        private System.Windows.Forms.Label lblTextAuraText;
        private CustomControls.ExpressionTextBox expTextAuraYIni;
        private System.Windows.Forms.Label lblTextAuraY;
        private CustomControls.ExpressionTextBox expTextAuraXIni;
        private System.Windows.Forms.Label lblTextAuraX;
        private CustomControls.ExpressionTextBox expTextAuraName;
        private System.Windows.Forms.Label lblTextAuraName;
        private System.Windows.Forms.Label lblTextAuraOp;
        private System.Windows.Forms.ComboBox cbxTextAuraOp;
        private System.Windows.Forms.Label lblTextAuraIniValues;
        private System.Windows.Forms.Button btnTextAuraGuide;
        private System.Windows.Forms.Button btnTextAuraFont;
        private System.Windows.Forms.Label lblTextAuraFont;
        private System.Windows.Forms.TextBox txtTextAuraFont;
        private System.Windows.Forms.FontDialog fontDialog1;
        private CustomControls.ColorSelector colorSelector1;
        private System.Windows.Forms.Label lblTextAuraOutline;
        private System.Windows.Forms.CheckBox cbxTextAuraOutline;
        private System.Windows.Forms.TabPage tabLogMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.Label lblLogMessageText;
        private CustomControls.ExpressionTextBox expLogMessageText;
        private System.Windows.Forms.CheckBox cbxDiscordTts;
        private System.Windows.Forms.TabPage tabScheduling;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.CheckBox chkExecuteAsync;
        private System.Windows.Forms.Label lblExecutionDelay;
        private System.Windows.Forms.ComboBox cbxRefireOption2;
        private System.Windows.Forms.ComboBox cbxRefireOption1;
        private System.Windows.Forms.Label lblRefireOption1;
        private CustomControls.ExpressionTextBox expExecutionDelay;
        private System.Windows.Forms.TabPage tabDebugging;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.ComboBox cbxLoggingLevel;
        private System.Windows.Forms.Label lblLoggingLevel;
        private System.Windows.Forms.TabPage tabListVariable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.ComboBox cbxLvarExpType;
        private System.Windows.Forms.Label lblLvarExpType;
        private CustomControls.ExpressionTextBox expLvarTarget;
        private System.Windows.Forms.Label lblLvarTarget;
        private CustomControls.ExpressionTextBox expLvarIndex;
        private System.Windows.Forms.Label lblLvarIndex;
        private CustomControls.ExpressionTextBox expLvarValue;
        private System.Windows.Forms.Label lblLvarValue;
        private CustomControls.ExpressionTextBox expLvarName;
        private System.Windows.Forms.Label lblLvarName;
        private System.Windows.Forms.Label lblLvarOperation;
        private System.Windows.Forms.ComboBox cbxLvarOperation;
        private System.Windows.Forms.TabPage tabObsControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.ComboBox cbxObsOpType;
        private System.Windows.Forms.Label lblObsOpType;
        private System.Windows.Forms.Button btnObsWebsocketLink;
        private System.Windows.Forms.Label lblObsSceneName;
        private CustomControls.ExpressionTextBox expObsSceneName;
        private System.Windows.Forms.Label lblObsWebsocketInfo;
        private System.Windows.Forms.TextBox txtObsWebsocketLink;
        private System.Windows.Forms.CheckBox cbxProcessLog;
        private System.Windows.Forms.CheckBox chkSoundMyOutput;
        private System.Windows.Forms.CheckBox chkSpeechMyOutput;
        private System.Windows.Forms.TabPage tabGenericJson;
        private System.Windows.Forms.TableLayoutPanel jsonTableLayout;
        private System.Windows.Forms.Label lblJsonInstructions;
        private CustomControls.ExpressionTextBox expJsonFiring;
        private System.Windows.Forms.Label lblJsonFiring;
        private CustomControls.ExpressionTextBox expJsonPayload;
        private System.Windows.Forms.Label lblJsonPayload;
        private System.Windows.Forms.Label lblJsonEndpoint;
        private CustomControls.ExpressionTextBox expJsonEndpoint;
        private System.Windows.Forms.TabPage tabActionCondition;
        private CustomControls.ConditionViewer cndCondition;
        private System.Windows.Forms.ComboBox cbxKeypressMethod;
        private System.Windows.Forms.Label lblKeypressMethod;
        private System.Windows.Forms.Button btnKeycodesLink;
        private System.Windows.Forms.TextBox txtKeyCodesLink;
        private System.Windows.Forms.Label lblKeypressInfo;
        private CustomControls.ExpressionTextBox expKeypress;
        private CustomControls.ExpressionTextBox expWindowTitle;
        private System.Windows.Forms.Label lblKeypress;
        private System.Windows.Forms.Label lblKeypressWindow;
        private CustomControls.ExpressionTextBox expObsSourceName;
        private System.Windows.Forms.Label lblObsSourceName;
        private System.Windows.Forms.TabPage tabWindowMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel19;
        private CustomControls.ExpressionTextBox expWmsgCode;
        private CustomControls.ExpressionTextBox expWmsgTitle;
        private System.Windows.Forms.Label lblWmsgCode;
        private System.Windows.Forms.Label lblWmsgTitle;
        private CustomControls.ExpressionTextBox expWmsgLparam;
        private System.Windows.Forms.Label lblWmsgLparam;
        private CustomControls.ExpressionTextBox expWmsgWparam;
        private System.Windows.Forms.Label lblWmsgWparam;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblWmsgWarning;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblReadOnly;
    }
}