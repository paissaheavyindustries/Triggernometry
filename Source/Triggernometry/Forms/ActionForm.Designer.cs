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
            this.cbxSoundMethod = new System.Windows.Forms.ComboBox();
            this.lblSoundMethod = new System.Windows.Forms.Label();
            this.chkSoundExclusive = new System.Windows.Forms.CheckBox();
            this.expSoundVolume = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblSoundVolume = new System.Windows.Forms.Label();
            this.lblSoundFile = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.expSoundFile = new Triggernometry.CustomControls.ExpressionTextBox();
            this.tabTextToSpeech = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxTtsMethod = new System.Windows.Forms.ComboBox();
            this.lblSpeechRouting = new System.Windows.Forms.Label();
            this.chkSpeechExclusive = new System.Windows.Forms.CheckBox();
            this.expSpeechRate = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblSpeechRate = new System.Windows.Forms.Label();
            this.expSpeechVolume = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblSpeechVolume = new System.Windows.Forms.Label();
            this.lblTextToSay = new System.Windows.Forms.Label();
            this.expTextToSay = new Triggernometry.CustomControls.ExpressionTextBox();
            this.tabVariable = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.prsScalarTarget = new Triggernometry.CustomControls.PersistenceSwitch();
            this.expVariableTarget = new Triggernometry.CustomControls.ExpressionTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.expVariableExpression = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblVariableExpression = new System.Windows.Forms.Label();
            this.expVariableName = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblVariableName = new System.Windows.Forms.Label();
            this.lblVariableOp = new System.Windows.Forms.Label();
            this.cbxVariableOp = new System.Windows.Forms.ComboBox();
            this.prsScalarName = new Triggernometry.CustomControls.PersistenceSwitch();
            this.tabListVariable = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.prsListTarget = new Triggernometry.CustomControls.PersistenceSwitch();
            this.prsListSource = new Triggernometry.CustomControls.PersistenceSwitch();
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
            this.tabTableVariable = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel21 = new System.Windows.Forms.TableLayoutPanel();
            this.prsTableTarget = new Triggernometry.CustomControls.PersistenceSwitch();
            this.prsTableSource = new Triggernometry.CustomControls.PersistenceSwitch();
            this.expTvarRow = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTvarRow = new System.Windows.Forms.Label();
            this.cbxTvarExpType = new System.Windows.Forms.ComboBox();
            this.lblTvarExpType = new System.Windows.Forms.Label();
            this.expTvarTarget = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTvarTarget = new System.Windows.Forms.Label();
            this.expTvarColumn = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTvarColumn = new System.Windows.Forms.Label();
            this.expTvarValue = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTvarValue = new System.Windows.Forms.Label();
            this.expTvarName = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTvarName = new System.Windows.Forms.Label();
            this.lblTvarOpType = new System.Windows.Forms.Label();
            this.cbxTvarOpType = new System.Windows.Forms.ComboBox();
            this.tabDictVariable = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelDict = new System.Windows.Forms.TableLayoutPanel();
            this.lblDictOpType = new System.Windows.Forms.Label();
            this.cbxDictOpType = new System.Windows.Forms.ComboBox();
            this.lblDictName = new System.Windows.Forms.Label();
            this.expDictName = new Triggernometry.CustomControls.ExpressionTextBox();
            this.prsDictSource = new Triggernometry.CustomControls.PersistenceSwitch();
            this.lblDictLength = new System.Windows.Forms.Label();
            this.expDictLength = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblDictKeyType = new System.Windows.Forms.Label();
            this.cbxDictKeyType = new System.Windows.Forms.ComboBox();
            this.lblDictKey = new System.Windows.Forms.Label();
            this.expDictKey = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblDictValueType = new System.Windows.Forms.Label();
            this.cbxDictValueType = new System.Windows.Forms.ComboBox();
            this.lblDictValue = new System.Windows.Forms.Label();
            this.expDictValue = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblDictTarget = new System.Windows.Forms.Label();
            this.expDictTarget = new Triggernometry.CustomControls.ExpressionTextBox();
            this.prsDictTarget = new Triggernometry.CustomControls.PersistenceSwitch();
            this.tabMessageBox = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.expMessageBoxText = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblMessageBoxText = new System.Windows.Forms.Label();
            this.lblMessageBoxIcon = new System.Windows.Forms.Label();
            this.cbxMessageBoxIcon = new System.Windows.Forms.ComboBox();
            this.tabLogMessage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLogMessageText = new System.Windows.Forms.Label();
            this.expLogMessageText = new Triggernometry.CustomControls.ExpressionTextBox();
            this.chkProcessLog = new System.Windows.Forms.CheckBox();
            this.chkProcessLogACT = new System.Windows.Forms.CheckBox();
            this.lblLogMessageLevel = new System.Windows.Forms.Label();
            this.cbxLogMessageLevel = new System.Windows.Forms.ComboBox();
            this.lblLogMessageTarget = new System.Windows.Forms.Label();
            this.cbxLogMessageTarget = new System.Windows.Forms.ComboBox();
            this.tabTextAura = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTextAuraOp = new System.Windows.Forms.Label();
            this.cbxTextAuraOp = new System.Windows.Forms.ComboBox();
            this.lblTextAuraName = new System.Windows.Forms.Label();
            this.expTextAuraName = new Triggernometry.CustomControls.ExpressionTextBox();
            this.btnTextAuraHide = new System.Windows.Forms.Button();
            this.lblTextAuraText = new System.Windows.Forms.Label();
            this.expTextAuraText = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTextAuraFont = new System.Windows.Forms.Label();
            this.colorSelector1 = new Triggernometry.CustomControls.ColorSelector();
            this.txtTextAuraFont = new System.Windows.Forms.TextBox();
            this.btnTextAuraFont = new System.Windows.Forms.Button();
            this.lblTextAuraAlignment = new System.Windows.Forms.Label();
            this.cbxTextAuraAlignment = new System.Windows.Forms.ComboBox();
            this.lblTextColor = new System.Windows.Forms.Label();
            this.tableTextColor = new System.Windows.Forms.TableLayoutPanel();
            this.lblTextForeColor = new System.Windows.Forms.Label();
            this.expTextForeColor = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTextBackColor = new System.Windows.Forms.Label();
            this.expTextBackColor = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTextOutlineColor = new System.Windows.Forms.Label();
            this.expTextOutlineColor = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTextAuraIniValues = new System.Windows.Forms.Label();
            this.lblTextAuraUpdValues = new System.Windows.Forms.Label();
            this.lblTextAuraX = new System.Windows.Forms.Label();
            this.expTextAuraXIni = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expTextAuraXTick = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTextAuraY = new System.Windows.Forms.Label();
            this.expTextAuraYIni = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expTextAuraYTick = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTextAuraWidth = new System.Windows.Forms.Label();
            this.expTextAuraWIni = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expTextAuraWTick = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTextAuraHeight = new System.Windows.Forms.Label();
            this.expTextAuraHIni = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expTextAuraHTick = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTextAuraOpacity = new System.Windows.Forms.Label();
            this.expTextAuraOIni = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expTextAuraOTick = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblTextAuraTtlExp = new System.Windows.Forms.Label();
            this.expTextAuraTTLTick = new Triggernometry.CustomControls.ExpressionTextBox();
            this.btnTextAuraGuide = new System.Windows.Forms.Button();
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
            this.tabMouse = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel25 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxMouseCoord = new System.Windows.Forms.ComboBox();
            this.expMouseY = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblMouseY = new System.Windows.Forms.Label();
            this.lblMouseX = new System.Windows.Forms.Label();
            this.expMouseX = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblMouseCoord = new System.Windows.Forms.Label();
            this.lblMouseOp = new System.Windows.Forms.Label();
            this.cbxMouseOp = new System.Windows.Forms.ComboBox();
            this.tabKeypress = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lblKeypressMethod = new System.Windows.Forms.Label();
            this.cbxKeypressMethod = new System.Windows.Forms.ComboBox();
            this.lblKeypressProcId = new System.Windows.Forms.Label();
            this.expKeypressProcId = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblKeypresses = new System.Windows.Forms.Label();
            this.expKeypresses = new Triggernometry.CustomControls.ExpressionTextBox();
            this.btnSendKeysListen = new System.Windows.Forms.Button();
            this.lblKeypressWindow = new System.Windows.Forms.Label();
            this.expWindowTitle = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblKeypress = new System.Windows.Forms.Label();
            this.expKeypress = new Triggernometry.CustomControls.ExpressionTextBox();
            this.btnKeycodesListen = new System.Windows.Forms.Button();
            this.txtSendKeysLink = new System.Windows.Forms.TextBox();
            this.btnSendKeysLink = new System.Windows.Forms.Button();
            this.tabNamedCallback = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel24 = new System.Windows.Forms.TableLayoutPanel();
            this.expCallbackParam = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblCallbackParam = new System.Windows.Forms.Label();
            this.lblCallbackName = new System.Windows.Forms.Label();
            this.expCallbackName = new Triggernometry.CustomControls.ExpressionTextBox();
            this.tabWindowMessage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.expWmsgProcid = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblWmsgProcid = new System.Windows.Forms.Label();
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
            this.tabFile = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel20 = new System.Windows.Forms.TableLayoutPanel();
            this.prsFileVariable = new Triggernometry.CustomControls.PersistenceSwitch();
            this.cbxFileOpCache = new System.Windows.Forms.CheckBox();
            this.expFileOpVariable = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblFileOpVariable = new System.Windows.Forms.Label();
            this.cbxFileOpType = new System.Windows.Forms.ComboBox();
            this.lblFileOpType = new System.Windows.Forms.Label();
            this.lblFileOpName = new System.Windows.Forms.Label();
            this.expFileOpName = new Triggernometry.CustomControls.ExpressionTextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblFileWarning = new System.Windows.Forms.Label();
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
            this.tabScript = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lblScriptExtEditor = new System.Windows.Forms.Label();
            this.expExecScriptAssemblies = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblExecScriptAssemblies = new System.Windows.Forms.Label();
            this.expExecScriptCode = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblExecScriptCode = new System.Windows.Forms.Label();
            this.btnScriptExternalEditor = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblScriptWarning = new System.Windows.Forms.Label();
            this.tabMutex = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel22 = new System.Windows.Forms.TableLayoutPanel();
            this.expMutexName = new Triggernometry.CustomControls.ExpressionTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxMutexOp = new System.Windows.Forms.ComboBox();
            this.tabLoop = new System.Windows.Forms.TabPage();
            this.actionViewer1 = new Triggernometry.CustomControls.ActionViewer();
            this.tableLayoutPanel26 = new System.Windows.Forms.TableLayoutPanel();
            this.expLoopIncr = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expLoopInit = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblLoopIncr = new System.Windows.Forms.Label();
            this.lblLoopInit = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.expLoopIterationDelay = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblLoopDelay = new System.Windows.Forms.Label();
            this.cndLoopCondition = new Triggernometry.CustomControls.ConditionViewer();
            this.tabGenericJson = new System.Windows.Forms.TabPage();
            this.jsonTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.prsJsonVariable = new Triggernometry.CustomControls.PersistenceSwitch();
            this.expJsonVariable = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblJsonVariable = new System.Windows.Forms.Label();
            this.expJsonHeaders = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblJsonHeaders = new System.Windows.Forms.Label();
            this.cbxJsonType = new System.Windows.Forms.ComboBox();
            this.lblJsonType = new System.Windows.Forms.Label();
            this.cbxJsonCache = new System.Windows.Forms.CheckBox();
            this.expJsonFiring = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblJsonFiring = new System.Windows.Forms.Label();
            this.expJsonPayload = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblJsonPayload = new System.Windows.Forms.Label();
            this.lblJsonEndpoint = new System.Windows.Forms.Label();
            this.expJsonEndpoint = new Triggernometry.CustomControls.ExpressionTextBox();
            this.tabDiscordWebhook = new System.Windows.Forms.TabPage();
            this.discordTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.cbxDiscordTts = new System.Windows.Forms.CheckBox();
            this.expDiscordMessage = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblDiscordMessage = new System.Windows.Forms.Label();
            this.lblDiscordUrl = new System.Windows.Forms.Label();
            this.expDiscordUrl = new Triggernometry.CustomControls.ExpressionTextBox();
            this.tabLiveSplitControl = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelLs = new System.Windows.Forms.TableLayoutPanel();
            this.lblLsCustPayload = new System.Windows.Forms.Label();
            this.expLSCustPayload = new Triggernometry.CustomControls.ExpressionTextBox();
            this.cbxLsOpType = new System.Windows.Forms.ComboBox();
            this.lblLsOpType = new System.Windows.Forms.Label();
            this.tabObsControl = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.expObsPassword = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblObsPassword = new System.Windows.Forms.Label();
            this.expObsEndpoint = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblObsEndpoint = new System.Windows.Forms.Label();
            this.lblObsJSONPayload = new System.Windows.Forms.Label();
            this.expObsJSONPayload = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expObsSourceName = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblObsSourceName = new System.Windows.Forms.Label();
            this.cbxObsOpType = new System.Windows.Forms.ComboBox();
            this.lblObsOpType = new System.Windows.Forms.Label();
            this.btnObsWebsocketLink = new System.Windows.Forms.Button();
            this.lblObsSceneName = new System.Windows.Forms.Label();
            this.expObsSceneName = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblObsWebsocketInfo = new System.Windows.Forms.Label();
            this.txtObsWebsocketLink = new System.Windows.Forms.TextBox();
            this.tabActInteraction = new System.Windows.Forms.TabPage();
            this.tableActInteraction = new System.Windows.Forms.TableLayoutPanel();
            this.lblActOpType = new System.Windows.Forms.Label();
            this.cbxActOpType = new System.Windows.Forms.ComboBox();
            this.lblActOpBoolParam = new System.Windows.Forms.Label();
            this.cbxActOpBoolParam = new System.Windows.Forms.ComboBox();
            this.lblActOpStringParam = new System.Windows.Forms.Label();
            this.expActOpStringParam = new Triggernometry.CustomControls.ExpressionTextBox();
            this.tabTriggerOperation = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTriggerZoneType = new System.Windows.Forms.Label();
            this.cbxTriggerZoneType = new System.Windows.Forms.ComboBox();
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
            this.tabFolderOperation = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFolder = new System.Windows.Forms.Label();
            this.lblFolderOp = new System.Windows.Forms.Label();
            this.cbxFolderOp = new System.Windows.Forms.ComboBox();
            this.trvFolder = new System.Windows.Forms.TreeView();
            this.tabRepo = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel27 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRepositoryLink = new System.Windows.Forms.Label();
            this.lblRepositoryOp = new System.Windows.Forms.Label();
            this.cbxRepositoryOp = new System.Windows.Forms.ComboBox();
            this.trvRepositoryLink = new System.Windows.Forms.TreeView();
            this.tabPlaceholder = new System.Windows.Forms.TabPage();
            this.lblPlaceholderNoParams = new System.Windows.Forms.Label();
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
            this.stsMouseHelp = new System.Windows.Forms.StatusStrip();
            this.tlsMouseLocation = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.tabDescription = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel23 = new System.Windows.Forms.TableLayoutPanel();
            this.chkOverrideDesc = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescBgColor = new System.Windows.Forms.Label();
            this.expDescBgColor = new Triggernometry.CustomControls.ExpressionTextBox();
            this.lblDescTextColor = new System.Windows.Forms.Label();
            this.expDescTextColor = new Triggernometry.CustomControls.ExpressionTextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblReadOnly = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.expressionTextBox1 = new Triggernometry.CustomControls.ExpressionTextBox();
            this.expressionTextBox2 = new Triggernometry.CustomControls.ExpressionTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpGeneralSettings.SuspendLayout();
            this.tbcActionSettings.SuspendLayout();
            this.tabSystemBeep.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPlaySoundFile.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabTextToSpeech.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tabVariable.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tabListVariable.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.tabTableVariable.SuspendLayout();
            this.tableLayoutPanel21.SuspendLayout();
            this.tabDictVariable.SuspendLayout();
            this.tableLayoutPanelDict.SuspendLayout();
            this.tabMessageBox.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tabLogMessage.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.tabTextAura.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.tableTextColor.SuspendLayout();
            this.tabImageAura.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tabMouse.SuspendLayout();
            this.tableLayoutPanel25.SuspendLayout();
            this.tabKeypress.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tabNamedCallback.SuspendLayout();
            this.tableLayoutPanel24.SuspendLayout();
            this.tabWindowMessage.SuspendLayout();
            this.tableLayoutPanel19.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabFile.SuspendLayout();
            this.tableLayoutPanel20.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tabLaunchProcess.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabScript.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabMutex.SuspendLayout();
            this.tableLayoutPanel22.SuspendLayout();
            this.tabLoop.SuspendLayout();
            this.tableLayoutPanel26.SuspendLayout();
            this.tabGenericJson.SuspendLayout();
            this.jsonTableLayout.SuspendLayout();
            this.tabDiscordWebhook.SuspendLayout();
            this.discordTableLayout.SuspendLayout();
            this.tabLiveSplitControl.SuspendLayout();
            this.tableLayoutPanelLs.SuspendLayout();
            this.tabObsControl.SuspendLayout();
            this.tableLayoutPanel18.SuspendLayout();
            this.tabActInteraction.SuspendLayout();
            this.tableActInteraction.SuspendLayout();
            this.tabTriggerOperation.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tabFolderOperation.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tabRepo.SuspendLayout();
            this.tableLayoutPanel27.SuspendLayout();
            this.tabPlaceholder.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tbcAction.SuspendLayout();
            this.tabActionSettings.SuspendLayout();
            this.stsMouseHelp.SuspendLayout();
            this.tabActionCondition.SuspendLayout();
            this.tabScheduling.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.tabDebugging.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.tabDescription.SuspendLayout();
            this.tableLayoutPanel23.SuspendLayout();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(744, 27);
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
            "Scalar variable operation",
            "List variable operation",
            "Table variable operation",
            "Dict variable operation",
            "Show message box",
            "Log message",
            "Text aura operation",
            "Image aura operation",
            "Mouse operation",
            "Send keypresses to active window",
            "Named callback operation",
            "Send window message",
            "File operation",
            "Launch process",
            "Execute script",
            "Mutex operation",
            "Loop",
            "Generic JSON operation",
            "Discord webhook",
            "LiveSplit remote control operation",
            "OBS remote control operation",
            "ACT Interaction",
            "Trigger operation",
            "Folder operation",
            "Repository operation",
            "Placeholder"});
            this.cbxActionType.Location = new System.Drawing.Point(69, 3);
            this.cbxActionType.Name = "cbxActionType";
            this.cbxActionType.Size = new System.Drawing.Size(672, 21);
            this.cbxActionType.TabIndex = 1;
            this.cbxActionType.TabStop = false;
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
            this.grpGeneralSettings.Size = new System.Drawing.Size(764, 60);
            this.grpGeneralSettings.TabIndex = 1;
            this.grpGeneralSettings.TabStop = false;
            this.grpGeneralSettings.Text = " General settings ";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 10);
            this.panel1.TabIndex = 3;
            // 
            // tbcActionSettings
            // 
            this.tbcActionSettings.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbcActionSettings.Controls.Add(this.tabSystemBeep);
            this.tbcActionSettings.Controls.Add(this.tabPlaySoundFile);
            this.tbcActionSettings.Controls.Add(this.tabTextToSpeech);
            this.tbcActionSettings.Controls.Add(this.tabVariable);
            this.tbcActionSettings.Controls.Add(this.tabListVariable);
            this.tbcActionSettings.Controls.Add(this.tabTableVariable);
            this.tbcActionSettings.Controls.Add(this.tabDictVariable);
            this.tbcActionSettings.Controls.Add(this.tabMessageBox);
            this.tbcActionSettings.Controls.Add(this.tabLogMessage);
            this.tbcActionSettings.Controls.Add(this.tabTextAura);
            this.tbcActionSettings.Controls.Add(this.tabImageAura);
            this.tbcActionSettings.Controls.Add(this.tabMouse);
            this.tbcActionSettings.Controls.Add(this.tabKeypress);
            this.tbcActionSettings.Controls.Add(this.tabNamedCallback);
            this.tbcActionSettings.Controls.Add(this.tabWindowMessage);
            this.tbcActionSettings.Controls.Add(this.tabFile);
            this.tbcActionSettings.Controls.Add(this.tabLaunchProcess);
            this.tbcActionSettings.Controls.Add(this.tabScript);
            this.tbcActionSettings.Controls.Add(this.tabMutex);
            this.tbcActionSettings.Controls.Add(this.tabLoop);
            this.tbcActionSettings.Controls.Add(this.tabGenericJson);
            this.tbcActionSettings.Controls.Add(this.tabDiscordWebhook);
            this.tbcActionSettings.Controls.Add(this.tabLiveSplitControl);
            this.tbcActionSettings.Controls.Add(this.tabObsControl);
            this.tbcActionSettings.Controls.Add(this.tabActInteraction);
            this.tbcActionSettings.Controls.Add(this.tabTriggerOperation);
            this.tbcActionSettings.Controls.Add(this.tabFolderOperation);
            this.tbcActionSettings.Controls.Add(this.tabRepo);
            this.tbcActionSettings.Controls.Add(this.tabPlaceholder);
            this.tbcActionSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcActionSettings.Location = new System.Drawing.Point(3, 3);
            this.tbcActionSettings.Margin = new System.Windows.Forms.Padding(0);
            this.tbcActionSettings.Name = "tbcActionSettings";
            this.tbcActionSettings.SelectedIndex = 0;
            this.tbcActionSettings.Size = new System.Drawing.Size(750, 443);
            this.tbcActionSettings.TabIndex = 0;
            this.tbcActionSettings.TabStop = false;
            // 
            // tabSystemBeep
            // 
            this.tabSystemBeep.AutoScroll = true;
            this.tabSystemBeep.Controls.Add(this.tableLayoutPanel2);
            this.tabSystemBeep.Location = new System.Drawing.Point(4, 25);
            this.tabSystemBeep.Margin = new System.Windows.Forms.Padding(0);
            this.tabSystemBeep.Name = "tabSystemBeep";
            this.tabSystemBeep.Size = new System.Drawing.Size(742, 414);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(742, 52);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // expBeepLength
            // 
            this.expBeepLength.AutocompleteAvailable = true;
            this.expBeepLength.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expBeepLength.AutoSize = true;
            this.expBeepLength.Dock = System.Windows.Forms.DockStyle.Top;
            this.expBeepLength.Expression = "";
            this.expBeepLength.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expBeepLength.IsPersistent = false;
            this.expBeepLength.Location = new System.Drawing.Point(111, 29);
            this.expBeepLength.Name = "expBeepLength";
            this.expBeepLength.ReadOnly = false;
            this.expBeepLength.Size = new System.Drawing.Size(628, 20);
            this.expBeepLength.TabIndex = 13;
            // 
            // expBeepFrequency
            // 
            this.expBeepFrequency.AutocompleteAvailable = true;
            this.expBeepFrequency.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expBeepFrequency.AutoSize = true;
            this.expBeepFrequency.Dock = System.Windows.Forms.DockStyle.Top;
            this.expBeepFrequency.Expression = "";
            this.expBeepFrequency.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expBeepFrequency.IsPersistent = false;
            this.expBeepFrequency.Location = new System.Drawing.Point(111, 3);
            this.expBeepFrequency.Name = "expBeepFrequency";
            this.expBeepFrequency.ReadOnly = false;
            this.expBeepFrequency.Size = new System.Drawing.Size(628, 20);
            this.expBeepFrequency.TabIndex = 12;
            // 
            // lblBeepLength
            // 
            this.lblBeepLength.AutoSize = true;
            this.lblBeepLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBeepLength.Location = new System.Drawing.Point(3, 26);
            this.lblBeepLength.Name = "lblBeepLength";
            this.lblBeepLength.Size = new System.Drawing.Size(102, 26);
            this.lblBeepLength.TabIndex = 14;
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
            this.lblBeepFrequency.TabIndex = 15;
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
            this.tabPlaySoundFile.Size = new System.Drawing.Size(742, 414);
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
            this.tableLayoutPanel3.Controls.Add(this.cbxSoundMethod, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.lblSoundMethod, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.chkSoundExclusive, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.expSoundVolume, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblSoundVolume, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblSoundFile, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.button3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.expSoundFile, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(742, 106);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // cbxSoundMethod
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.cbxSoundMethod, 2);
            this.cbxSoundMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxSoundMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSoundMethod.FormattingEnabled = true;
            this.cbxSoundMethod.Items.AddRange(new object[] {
            "Default",
            "Windows Media Player API",
            "ACT"});
            this.cbxSoundMethod.Location = new System.Drawing.Point(143, 82);
            this.cbxSoundMethod.Name = "cbxSoundMethod";
            this.cbxSoundMethod.Size = new System.Drawing.Size(596, 21);
            this.cbxSoundMethod.TabIndex = 22;
            // 
            // lblSoundMethod
            // 
            this.lblSoundMethod.AutoSize = true;
            this.lblSoundMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoundMethod.Location = new System.Drawing.Point(3, 79);
            this.lblSoundMethod.Name = "lblSoundMethod";
            this.lblSoundMethod.Size = new System.Drawing.Size(134, 27);
            this.lblSoundMethod.TabIndex = 21;
            this.lblSoundMethod.Text = "Audio output method";
            this.lblSoundMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.chkSoundExclusive.Size = new System.Drawing.Size(737, 17);
            this.chkSoundExclusive.TabIndex = 1;
            this.chkSoundExclusive.TabStop = false;
            this.chkSoundExclusive.Text = "Use exclusive sound player to prevent conflicts with other sounds";
            this.chkSoundExclusive.UseVisualStyleBackColor = true;
            // 
            // expSoundVolume
            // 
            this.expSoundVolume.AutocompleteAvailable = true;
            this.expSoundVolume.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expSoundVolume.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.expSoundVolume, 2);
            this.expSoundVolume.Dock = System.Windows.Forms.DockStyle.Top;
            this.expSoundVolume.Expression = "";
            this.expSoundVolume.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expSoundVolume.IsPersistent = false;
            this.expSoundVolume.Location = new System.Drawing.Point(143, 29);
            this.expSoundVolume.Name = "expSoundVolume";
            this.expSoundVolume.ReadOnly = false;
            this.expSoundVolume.Size = new System.Drawing.Size(596, 20);
            this.expSoundVolume.TabIndex = 16;
            // 
            // lblSoundVolume
            // 
            this.lblSoundVolume.AutoSize = true;
            this.lblSoundVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoundVolume.Location = new System.Drawing.Point(3, 26);
            this.lblSoundVolume.Name = "lblSoundVolume";
            this.lblSoundVolume.Size = new System.Drawing.Size(134, 26);
            this.lblSoundVolume.TabIndex = 17;
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
            this.lblSoundFile.TabIndex = 18;
            this.lblSoundFile.Text = "Sound file to play";
            this.lblSoundFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(702, 0);
            this.button3.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(37, 26);
            this.button3.TabIndex = 19;
            this.button3.TabStop = false;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // expSoundFile
            // 
            this.expSoundFile.AutocompleteAvailable = true;
            this.expSoundFile.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expSoundFile.AutoSize = true;
            this.expSoundFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.expSoundFile.Expression = "";
            this.expSoundFile.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expSoundFile.IsPersistent = false;
            this.expSoundFile.Location = new System.Drawing.Point(143, 3);
            this.expSoundFile.Name = "expSoundFile";
            this.expSoundFile.ReadOnly = false;
            this.expSoundFile.Size = new System.Drawing.Size(556, 20);
            this.expSoundFile.TabIndex = 14;
            // 
            // tabTextToSpeech
            // 
            this.tabTextToSpeech.AutoScroll = true;
            this.tabTextToSpeech.Controls.Add(this.tableLayoutPanel4);
            this.tabTextToSpeech.Location = new System.Drawing.Point(4, 25);
            this.tabTextToSpeech.Name = "tabTextToSpeech";
            this.tabTextToSpeech.Size = new System.Drawing.Size(742, 414);
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
            this.tableLayoutPanel4.Controls.Add(this.cbxTtsMethod, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.lblSpeechRouting, 0, 5);
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
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(742, 132);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // cbxTtsMethod
            // 
            this.cbxTtsMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxTtsMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTtsMethod.FormattingEnabled = true;
            this.cbxTtsMethod.Items.AddRange(new object[] {
            "Default",
            "Windows Speech API",
            "ACT"});
            this.cbxTtsMethod.Location = new System.Drawing.Point(163, 108);
            this.cbxTtsMethod.Name = "cbxTtsMethod";
            this.cbxTtsMethod.Size = new System.Drawing.Size(576, 21);
            this.cbxTtsMethod.TabIndex = 21;
            // 
            // lblSpeechRouting
            // 
            this.lblSpeechRouting.AutoSize = true;
            this.lblSpeechRouting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSpeechRouting.Location = new System.Drawing.Point(3, 105);
            this.lblSpeechRouting.Name = "lblSpeechRouting";
            this.lblSpeechRouting.Size = new System.Drawing.Size(154, 27);
            this.lblSpeechRouting.TabIndex = 20;
            this.lblSpeechRouting.Text = "Audio output method";
            this.lblSpeechRouting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.chkSpeechExclusive.Size = new System.Drawing.Size(737, 17);
            this.chkSpeechExclusive.TabIndex = 1;
            this.chkSpeechExclusive.TabStop = false;
            this.chkSpeechExclusive.Text = "Use exclusive speech synthesizer to prevent conflicts with other speech";
            this.chkSpeechExclusive.UseVisualStyleBackColor = true;
            // 
            // expSpeechRate
            // 
            this.expSpeechRate.AutocompleteAvailable = true;
            this.expSpeechRate.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expSpeechRate.AutoSize = true;
            this.expSpeechRate.Dock = System.Windows.Forms.DockStyle.Top;
            this.expSpeechRate.Expression = "";
            this.expSpeechRate.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expSpeechRate.IsPersistent = false;
            this.expSpeechRate.Location = new System.Drawing.Point(163, 55);
            this.expSpeechRate.Name = "expSpeechRate";
            this.expSpeechRate.ReadOnly = false;
            this.expSpeechRate.Size = new System.Drawing.Size(576, 20);
            this.expSpeechRate.TabIndex = 16;
            // 
            // lblSpeechRate
            // 
            this.lblSpeechRate.AutoSize = true;
            this.lblSpeechRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSpeechRate.Location = new System.Drawing.Point(3, 52);
            this.lblSpeechRate.Name = "lblSpeechRate";
            this.lblSpeechRate.Size = new System.Drawing.Size(154, 26);
            this.lblSpeechRate.TabIndex = 17;
            this.lblSpeechRate.Text = "Speech speed rate (-10 ... +10)";
            this.lblSpeechRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expSpeechVolume
            // 
            this.expSpeechVolume.AutocompleteAvailable = true;
            this.expSpeechVolume.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expSpeechVolume.AutoSize = true;
            this.expSpeechVolume.Dock = System.Windows.Forms.DockStyle.Top;
            this.expSpeechVolume.Expression = "";
            this.expSpeechVolume.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expSpeechVolume.IsPersistent = false;
            this.expSpeechVolume.Location = new System.Drawing.Point(163, 29);
            this.expSpeechVolume.Name = "expSpeechVolume";
            this.expSpeechVolume.ReadOnly = false;
            this.expSpeechVolume.Size = new System.Drawing.Size(576, 20);
            this.expSpeechVolume.TabIndex = 14;
            // 
            // lblSpeechVolume
            // 
            this.lblSpeechVolume.AutoSize = true;
            this.lblSpeechVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSpeechVolume.Location = new System.Drawing.Point(3, 26);
            this.lblSpeechVolume.Name = "lblSpeechVolume";
            this.lblSpeechVolume.Size = new System.Drawing.Size(154, 26);
            this.lblSpeechVolume.TabIndex = 18;
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
            this.lblTextToSay.TabIndex = 19;
            this.lblTextToSay.Text = "Text to say";
            this.lblTextToSay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTextToSay
            // 
            this.expTextToSay.AutocompleteAvailable = true;
            this.expTextToSay.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTextToSay.AutoSize = true;
            this.expTextToSay.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextToSay.Expression = "";
            this.expTextToSay.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expTextToSay.IsPersistent = false;
            this.expTextToSay.Location = new System.Drawing.Point(163, 3);
            this.expTextToSay.Name = "expTextToSay";
            this.expTextToSay.ReadOnly = false;
            this.expTextToSay.Size = new System.Drawing.Size(576, 20);
            this.expTextToSay.TabIndex = 12;
            // 
            // tabVariable
            // 
            this.tabVariable.Controls.Add(this.tableLayoutPanel9);
            this.tabVariable.Location = new System.Drawing.Point(4, 25);
            this.tabVariable.Name = "tabVariable";
            this.tabVariable.Size = new System.Drawing.Size(742, 414);
            this.tabVariable.TabIndex = 3;
            this.tabVariable.Text = "Variable";
            this.tabVariable.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.AutoSize = true;
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel9.Controls.Add(this.prsScalarTarget, 2, 3);
            this.tableLayoutPanel9.Controls.Add(this.expVariableTarget, 1, 3);
            this.tableLayoutPanel9.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel9.Controls.Add(this.expVariableExpression, 1, 2);
            this.tableLayoutPanel9.Controls.Add(this.lblVariableExpression, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.expVariableName, 1, 1);
            this.tableLayoutPanel9.Controls.Add(this.lblVariableName, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.lblVariableOp, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.cbxVariableOp, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.prsScalarName, 2, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 4;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.Size = new System.Drawing.Size(742, 105);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // prsScalarTarget
            // 
            this.prsScalarTarget.AutoSize = true;
            this.prsScalarTarget.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prsScalarTarget.BackgroundImage")));
            this.prsScalarTarget.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.prsScalarTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prsScalarTarget.IsPersistent = false;
            this.prsScalarTarget.Location = new System.Drawing.Point(715, 82);
            this.prsScalarTarget.Name = "prsScalarTarget";
            this.prsScalarTarget.RelatedTextbox = null;
            this.prsScalarTarget.Size = new System.Drawing.Size(24, 20);
            this.prsScalarTarget.TabIndex = 0;
            this.prsScalarTarget.TabStop = false;
            this.prsScalarTarget.Tag = ((object)(resources.GetObject("prsScalarTarget.Tag")));
            // 
            // expVariableTarget
            // 
            this.expVariableTarget.AutocompleteAvailable = true;
            this.expVariableTarget.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expVariableTarget.AutoSize = true;
            this.expVariableTarget.Dock = System.Windows.Forms.DockStyle.Top;
            this.expVariableTarget.Expression = "";
            this.expVariableTarget.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expVariableTarget.IsPersistent = false;
            this.expVariableTarget.Location = new System.Drawing.Point(116, 82);
            this.expVariableTarget.Name = "expVariableTarget";
            this.expVariableTarget.ReadOnly = false;
            this.expVariableTarget.Size = new System.Drawing.Size(593, 20);
            this.expVariableTarget.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 26);
            this.label6.TabIndex = 25;
            this.label6.Text = "Target variable name";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expVariableExpression
            // 
            this.expVariableExpression.AutocompleteAvailable = true;
            this.expVariableExpression.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expVariableExpression.AutoSize = true;
            this.tableLayoutPanel9.SetColumnSpan(this.expVariableExpression, 2);
            this.expVariableExpression.Dock = System.Windows.Forms.DockStyle.Top;
            this.expVariableExpression.Expression = "";
            this.expVariableExpression.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expVariableExpression.IsPersistent = false;
            this.expVariableExpression.Location = new System.Drawing.Point(116, 56);
            this.expVariableExpression.Name = "expVariableExpression";
            this.expVariableExpression.ReadOnly = false;
            this.expVariableExpression.Size = new System.Drawing.Size(623, 20);
            this.expVariableExpression.TabIndex = 23;
            this.expVariableExpression.EnabledChanged += new System.EventHandler(this.expVariableExpression_EnabledChanged);
            // 
            // lblVariableExpression
            // 
            this.lblVariableExpression.AutoSize = true;
            this.lblVariableExpression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVariableExpression.Location = new System.Drawing.Point(3, 53);
            this.lblVariableExpression.Name = "lblVariableExpression";
            this.lblVariableExpression.Size = new System.Drawing.Size(107, 26);
            this.lblVariableExpression.TabIndex = 27;
            this.lblVariableExpression.Text = "Expression";
            this.lblVariableExpression.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expVariableName
            // 
            this.expVariableName.AutocompleteAvailable = true;
            this.expVariableName.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expVariableName.AutoSize = true;
            this.expVariableName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expVariableName.Expression = "";
            this.expVariableName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expVariableName.IsPersistent = false;
            this.expVariableName.Location = new System.Drawing.Point(116, 30);
            this.expVariableName.Name = "expVariableName";
            this.expVariableName.ReadOnly = false;
            this.expVariableName.Size = new System.Drawing.Size(593, 20);
            this.expVariableName.TabIndex = 16;
            this.expVariableName.EnabledChanged += new System.EventHandler(this.expVariableName_EnabledChanged);
            // 
            // lblVariableName
            // 
            this.lblVariableName.AutoSize = true;
            this.lblVariableName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVariableName.Location = new System.Drawing.Point(3, 27);
            this.lblVariableName.Name = "lblVariableName";
            this.lblVariableName.Size = new System.Drawing.Size(107, 26);
            this.lblVariableName.TabIndex = 28;
            this.lblVariableName.Text = "Scalar variable name";
            this.lblVariableName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVariableOp
            // 
            this.lblVariableOp.AutoSize = true;
            this.lblVariableOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVariableOp.Location = new System.Drawing.Point(3, 0);
            this.lblVariableOp.Name = "lblVariableOp";
            this.lblVariableOp.Size = new System.Drawing.Size(107, 27);
            this.lblVariableOp.TabIndex = 29;
            this.lblVariableOp.Text = "Operation type";
            this.lblVariableOp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxVariableOp
            // 
            this.tableLayoutPanel9.SetColumnSpan(this.cbxVariableOp, 2);
            this.cbxVariableOp.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxVariableOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVariableOp.FormattingEnabled = true;
            this.cbxVariableOp.Items.AddRange(new object[] {
            "Unset scalar variable",
            "Set scalar variable value with string expression",
            "Set scalar variable value with numeric expression",
            "Increment scalar variable value",
            "Copy scalar variable or expression to the clipboard",
            "Unset all scalar variables",
            "Unset scalar variables matching regular expression",
            "Unset all types of variables matching regular expression",
            "Query variable with JSONPath and store scalar value",
            "Query variable with JSONPath and store list value"});
            this.cbxVariableOp.Location = new System.Drawing.Point(116, 3);
            this.cbxVariableOp.Name = "cbxVariableOp";
            this.cbxVariableOp.Size = new System.Drawing.Size(623, 21);
            this.cbxVariableOp.TabIndex = 30;
            this.cbxVariableOp.TabStop = false;
            this.cbxVariableOp.SelectedIndexChanged += new System.EventHandler(this.cbxVariableOp_SelectedIndexChanged);
            // 
            // prsScalarName
            // 
            this.prsScalarName.AutoSize = true;
            this.prsScalarName.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prsScalarName.BackgroundImage")));
            this.prsScalarName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.prsScalarName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prsScalarName.IsPersistent = false;
            this.prsScalarName.Location = new System.Drawing.Point(715, 30);
            this.prsScalarName.Name = "prsScalarName";
            this.prsScalarName.RelatedTextbox = null;
            this.prsScalarName.Size = new System.Drawing.Size(24, 20);
            this.prsScalarName.TabIndex = 31;
            this.prsScalarName.TabStop = false;
            this.prsScalarName.Tag = ((object)(resources.GetObject("prsScalarName.Tag")));
            // 
            // tabListVariable
            // 
            this.tabListVariable.Controls.Add(this.tableLayoutPanel17);
            this.tabListVariable.Location = new System.Drawing.Point(4, 25);
            this.tabListVariable.Name = "tabListVariable";
            this.tabListVariable.Size = new System.Drawing.Size(742, 414);
            this.tabListVariable.TabIndex = 4;
            this.tabListVariable.Text = "ListVariable";
            this.tabListVariable.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.AutoSize = true;
            this.tableLayoutPanel17.ColumnCount = 3;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel17.Controls.Add(this.prsListTarget, 2, 5);
            this.tableLayoutPanel17.Controls.Add(this.prsListSource, 2, 1);
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
            this.tableLayoutPanel17.Size = new System.Drawing.Size(742, 158);
            this.tableLayoutPanel17.TabIndex = 0;
            // 
            // prsListTarget
            // 
            this.prsListTarget.AutoSize = true;
            this.prsListTarget.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prsListTarget.BackgroundImage")));
            this.prsListTarget.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.prsListTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prsListTarget.IsPersistent = false;
            this.prsListTarget.Location = new System.Drawing.Point(715, 135);
            this.prsListTarget.Name = "prsListTarget";
            this.prsListTarget.RelatedTextbox = null;
            this.prsListTarget.Size = new System.Drawing.Size(24, 20);
            this.prsListTarget.TabIndex = 0;
            this.prsListTarget.TabStop = false;
            this.prsListTarget.Tag = ((object)(resources.GetObject("prsListTarget.Tag")));
            // 
            // prsListSource
            // 
            this.prsListSource.AutoSize = true;
            this.prsListSource.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prsListSource.BackgroundImage")));
            this.prsListSource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.prsListSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prsListSource.IsPersistent = false;
            this.prsListSource.Location = new System.Drawing.Point(715, 30);
            this.prsListSource.Name = "prsListSource";
            this.prsListSource.RelatedTextbox = null;
            this.prsListSource.Size = new System.Drawing.Size(24, 20);
            this.prsListSource.TabIndex = 1;
            this.prsListSource.TabStop = false;
            this.prsListSource.Tag = ((object)(resources.GetObject("prsListSource.Tag")));
            // 
            // cbxLvarExpType
            // 
            this.tableLayoutPanel17.SetColumnSpan(this.cbxLvarExpType, 2);
            this.cbxLvarExpType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxLvarExpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLvarExpType.FormattingEnabled = true;
            this.cbxLvarExpType.Items.AddRange(new object[] {
            "String",
            "Numeric"});
            this.cbxLvarExpType.Location = new System.Drawing.Point(119, 56);
            this.cbxLvarExpType.Name = "cbxLvarExpType";
            this.cbxLvarExpType.Size = new System.Drawing.Size(620, 21);
            this.cbxLvarExpType.TabIndex = 2;
            this.cbxLvarExpType.TabStop = false;
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
            this.lblLvarExpType.TabIndex = 3;
            this.lblLvarExpType.Text = "Expression type";
            this.lblLvarExpType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expLvarTarget
            // 
            this.expLvarTarget.AutocompleteAvailable = true;
            this.expLvarTarget.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expLvarTarget.AutoSize = true;
            this.expLvarTarget.Dock = System.Windows.Forms.DockStyle.Top;
            this.expLvarTarget.Expression = "";
            this.expLvarTarget.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expLvarTarget.IsPersistent = false;
            this.expLvarTarget.Location = new System.Drawing.Point(119, 135);
            this.expLvarTarget.Name = "expLvarTarget";
            this.expLvarTarget.ReadOnly = false;
            this.expLvarTarget.Size = new System.Drawing.Size(590, 20);
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
            this.lblLvarTarget.TabIndex = 28;
            this.lblLvarTarget.Text = "Target variable name";
            this.lblLvarTarget.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expLvarIndex
            // 
            this.expLvarIndex.AutocompleteAvailable = true;
            this.expLvarIndex.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expLvarIndex.AutoSize = true;
            this.tableLayoutPanel17.SetColumnSpan(this.expLvarIndex, 2);
            this.expLvarIndex.Dock = System.Windows.Forms.DockStyle.Top;
            this.expLvarIndex.Expression = "";
            this.expLvarIndex.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expLvarIndex.IsPersistent = false;
            this.expLvarIndex.Location = new System.Drawing.Point(119, 109);
            this.expLvarIndex.Name = "expLvarIndex";
            this.expLvarIndex.ReadOnly = false;
            this.expLvarIndex.Size = new System.Drawing.Size(620, 20);
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
            this.lblLvarIndex.TabIndex = 29;
            this.lblLvarIndex.Text = "List index number";
            this.lblLvarIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expLvarValue
            // 
            this.expLvarValue.AutocompleteAvailable = true;
            this.expLvarValue.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expLvarValue.AutoSize = true;
            this.tableLayoutPanel17.SetColumnSpan(this.expLvarValue, 2);
            this.expLvarValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.expLvarValue.Expression = "";
            this.expLvarValue.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expLvarValue.IsPersistent = false;
            this.expLvarValue.Location = new System.Drawing.Point(119, 83);
            this.expLvarValue.Name = "expLvarValue";
            this.expLvarValue.ReadOnly = false;
            this.expLvarValue.Size = new System.Drawing.Size(620, 20);
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
            this.lblLvarValue.TabIndex = 30;
            this.lblLvarValue.Text = "Expression";
            this.lblLvarValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expLvarName
            // 
            this.expLvarName.AutocompleteAvailable = true;
            this.expLvarName.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expLvarName.AutoSize = true;
            this.expLvarName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expLvarName.Expression = "";
            this.expLvarName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expLvarName.IsPersistent = false;
            this.expLvarName.Location = new System.Drawing.Point(119, 30);
            this.expLvarName.Name = "expLvarName";
            this.expLvarName.ReadOnly = false;
            this.expLvarName.Size = new System.Drawing.Size(590, 20);
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
            this.lblLvarName.TabIndex = 31;
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
            this.lblLvarOperation.TabIndex = 32;
            this.lblLvarOperation.Text = "Operation type";
            this.lblLvarOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxLvarOperation
            // 
            this.tableLayoutPanel17.SetColumnSpan(this.cbxLvarOperation, 2);
            this.cbxLvarOperation.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxLvarOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLvarOperation.FormattingEnabled = true;
            this.cbxLvarOperation.Items.AddRange(new object[] {
            "Unset list variable",
            "Push value to the end of the list variable",
            "Insert value to the given index of the list variable",
            "Set value at the given index of the list variable",
            "Set all values on the list variable to the expression",
            "Remove value at the given index of the list variable",
            "Pop the given index from list variable into a scalar variable",
            "Pop and insert a value from a list into another list",
            "Pop and set a value from a list into another list",
            "Build a list variable from the expression separated by its first character",
            "Filter elements into another list",
            "Join all values in the list variable into a scalar variable (separator in express" +
                "ion)",
            "Split a scalar variable into a list variable (separator in expression)",
            "Copy whole list variable to another list variable",
            "Insert list variable into another list variable at the given index",
            "Sort list in a numerically ascending order",
            "Sort list in a numerically descending order",
            "Sort list in an alphabetically ascending order",
            "Sort list in an alphabetically descending order",
            "Sort list in an ascending order based on FFXIV party job order",
            "Sort list in a descending order based on FFXIV party job order",
            "Sort list by the key functions",
            "Unset all list variables",
            "Unset list variables matching regular expression"});
            this.cbxLvarOperation.Location = new System.Drawing.Point(119, 3);
            this.cbxLvarOperation.Name = "cbxLvarOperation";
            this.cbxLvarOperation.Size = new System.Drawing.Size(620, 21);
            this.cbxLvarOperation.TabIndex = 33;
            this.cbxLvarOperation.TabStop = false;
            this.cbxLvarOperation.SelectedIndexChanged += new System.EventHandler(this.cbxLvarOperation_SelectedIndexChanged);
            // 
            // tabTableVariable
            // 
            this.tabTableVariable.Controls.Add(this.tableLayoutPanel21);
            this.tabTableVariable.Location = new System.Drawing.Point(4, 25);
            this.tabTableVariable.Name = "tabTableVariable";
            this.tabTableVariable.Size = new System.Drawing.Size(742, 414);
            this.tabTableVariable.TabIndex = 5;
            this.tabTableVariable.Text = "TableVariable";
            this.tabTableVariable.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel21
            // 
            this.tableLayoutPanel21.AutoSize = true;
            this.tableLayoutPanel21.ColumnCount = 3;
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel21.Controls.Add(this.prsTableTarget, 2, 6);
            this.tableLayoutPanel21.Controls.Add(this.prsTableSource, 2, 1);
            this.tableLayoutPanel21.Controls.Add(this.expTvarRow, 1, 5);
            this.tableLayoutPanel21.Controls.Add(this.lblTvarRow, 0, 5);
            this.tableLayoutPanel21.Controls.Add(this.cbxTvarExpType, 1, 2);
            this.tableLayoutPanel21.Controls.Add(this.lblTvarExpType, 0, 2);
            this.tableLayoutPanel21.Controls.Add(this.expTvarTarget, 1, 6);
            this.tableLayoutPanel21.Controls.Add(this.lblTvarTarget, 0, 6);
            this.tableLayoutPanel21.Controls.Add(this.expTvarColumn, 1, 4);
            this.tableLayoutPanel21.Controls.Add(this.lblTvarColumn, 0, 4);
            this.tableLayoutPanel21.Controls.Add(this.expTvarValue, 1, 3);
            this.tableLayoutPanel21.Controls.Add(this.lblTvarValue, 0, 3);
            this.tableLayoutPanel21.Controls.Add(this.expTvarName, 1, 1);
            this.tableLayoutPanel21.Controls.Add(this.lblTvarName, 0, 1);
            this.tableLayoutPanel21.Controls.Add(this.lblTvarOpType, 0, 0);
            this.tableLayoutPanel21.Controls.Add(this.cbxTvarOpType, 1, 0);
            this.tableLayoutPanel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel21.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel21.Name = "tableLayoutPanel21";
            this.tableLayoutPanel21.RowCount = 7;
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel21.Size = new System.Drawing.Size(742, 184);
            this.tableLayoutPanel21.TabIndex = 0;
            // 
            // prsTableTarget
            // 
            this.prsTableTarget.AutoSize = true;
            this.prsTableTarget.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prsTableTarget.BackgroundImage")));
            this.prsTableTarget.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.prsTableTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prsTableTarget.IsPersistent = false;
            this.prsTableTarget.Location = new System.Drawing.Point(715, 161);
            this.prsTableTarget.Name = "prsTableTarget";
            this.prsTableTarget.RelatedTextbox = null;
            this.prsTableTarget.Size = new System.Drawing.Size(24, 20);
            this.prsTableTarget.TabIndex = 0;
            this.prsTableTarget.TabStop = false;
            this.prsTableTarget.Tag = ((object)(resources.GetObject("prsTableTarget.Tag")));
            // 
            // prsTableSource
            // 
            this.prsTableSource.AutoSize = true;
            this.prsTableSource.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prsTableSource.BackgroundImage")));
            this.prsTableSource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.prsTableSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prsTableSource.IsPersistent = false;
            this.prsTableSource.Location = new System.Drawing.Point(715, 30);
            this.prsTableSource.Name = "prsTableSource";
            this.prsTableSource.RelatedTextbox = null;
            this.prsTableSource.Size = new System.Drawing.Size(24, 20);
            this.prsTableSource.TabIndex = 1;
            this.prsTableSource.TabStop = false;
            this.prsTableSource.Tag = ((object)(resources.GetObject("prsTableSource.Tag")));
            // 
            // expTvarRow
            // 
            this.expTvarRow.AutocompleteAvailable = true;
            this.expTvarRow.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTvarRow.AutoSize = true;
            this.tableLayoutPanel21.SetColumnSpan(this.expTvarRow, 2);
            this.expTvarRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTvarRow.Expression = "";
            this.expTvarRow.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTvarRow.IsPersistent = false;
            this.expTvarRow.Location = new System.Drawing.Point(119, 135);
            this.expTvarRow.Name = "expTvarRow";
            this.expTvarRow.ReadOnly = false;
            this.expTvarRow.Size = new System.Drawing.Size(620, 20);
            this.expTvarRow.TabIndex = 26;
            this.expTvarRow.EnabledChanged += new System.EventHandler(this.expTvarRow_EnabledChanged);
            // 
            // lblTvarRow
            // 
            this.lblTvarRow.AutoSize = true;
            this.lblTvarRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTvarRow.Location = new System.Drawing.Point(3, 132);
            this.lblTvarRow.Name = "lblTvarRow";
            this.lblTvarRow.Size = new System.Drawing.Size(110, 26);
            this.lblTvarRow.TabIndex = 27;
            this.lblTvarRow.Text = "Row definition";
            this.lblTvarRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxTvarExpType
            // 
            this.tableLayoutPanel21.SetColumnSpan(this.cbxTvarExpType, 2);
            this.cbxTvarExpType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxTvarExpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTvarExpType.FormattingEnabled = true;
            this.cbxTvarExpType.Items.AddRange(new object[] {
            "String",
            "Numeric"});
            this.cbxTvarExpType.Location = new System.Drawing.Point(119, 56);
            this.cbxTvarExpType.Name = "cbxTvarExpType";
            this.cbxTvarExpType.Size = new System.Drawing.Size(620, 21);
            this.cbxTvarExpType.TabIndex = 28;
            this.cbxTvarExpType.TabStop = false;
            this.cbxTvarExpType.SelectedIndexChanged += new System.EventHandler(this.cbxTvarExpType_SelectedIndexChanged);
            this.cbxTvarExpType.EnabledChanged += new System.EventHandler(this.cbxTvarExpType_EnabledChanged);
            // 
            // lblTvarExpType
            // 
            this.lblTvarExpType.AutoSize = true;
            this.lblTvarExpType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTvarExpType.Location = new System.Drawing.Point(3, 53);
            this.lblTvarExpType.Name = "lblTvarExpType";
            this.lblTvarExpType.Size = new System.Drawing.Size(110, 27);
            this.lblTvarExpType.TabIndex = 29;
            this.lblTvarExpType.Text = "Expression type";
            this.lblTvarExpType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTvarTarget
            // 
            this.expTvarTarget.AutocompleteAvailable = true;
            this.expTvarTarget.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTvarTarget.AutoSize = true;
            this.expTvarTarget.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTvarTarget.Expression = "";
            this.expTvarTarget.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expTvarTarget.IsPersistent = false;
            this.expTvarTarget.Location = new System.Drawing.Point(119, 161);
            this.expTvarTarget.Name = "expTvarTarget";
            this.expTvarTarget.ReadOnly = false;
            this.expTvarTarget.Size = new System.Drawing.Size(590, 20);
            this.expTvarTarget.TabIndex = 27;
            this.expTvarTarget.EnabledChanged += new System.EventHandler(this.expTvarTarget_EnabledChanged);
            // 
            // lblTvarTarget
            // 
            this.lblTvarTarget.AutoSize = true;
            this.lblTvarTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTvarTarget.Location = new System.Drawing.Point(3, 158);
            this.lblTvarTarget.Name = "lblTvarTarget";
            this.lblTvarTarget.Size = new System.Drawing.Size(110, 26);
            this.lblTvarTarget.TabIndex = 30;
            this.lblTvarTarget.Text = "Target variable name";
            this.lblTvarTarget.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTvarColumn
            // 
            this.expTvarColumn.AutocompleteAvailable = true;
            this.expTvarColumn.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTvarColumn.AutoSize = true;
            this.tableLayoutPanel21.SetColumnSpan(this.expTvarColumn, 2);
            this.expTvarColumn.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTvarColumn.Expression = "";
            this.expTvarColumn.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTvarColumn.IsPersistent = false;
            this.expTvarColumn.Location = new System.Drawing.Point(119, 109);
            this.expTvarColumn.Name = "expTvarColumn";
            this.expTvarColumn.ReadOnly = false;
            this.expTvarColumn.Size = new System.Drawing.Size(620, 20);
            this.expTvarColumn.TabIndex = 25;
            this.expTvarColumn.EnabledChanged += new System.EventHandler(this.expTvarColumn_EnabledChanged);
            // 
            // lblTvarColumn
            // 
            this.lblTvarColumn.AutoSize = true;
            this.lblTvarColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTvarColumn.Location = new System.Drawing.Point(3, 106);
            this.lblTvarColumn.Name = "lblTvarColumn";
            this.lblTvarColumn.Size = new System.Drawing.Size(110, 26);
            this.lblTvarColumn.TabIndex = 31;
            this.lblTvarColumn.Text = "Column definition";
            this.lblTvarColumn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTvarValue
            // 
            this.expTvarValue.AutocompleteAvailable = true;
            this.expTvarValue.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTvarValue.AutoSize = true;
            this.tableLayoutPanel21.SetColumnSpan(this.expTvarValue, 2);
            this.expTvarValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTvarValue.Expression = "";
            this.expTvarValue.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expTvarValue.IsPersistent = false;
            this.expTvarValue.Location = new System.Drawing.Point(119, 83);
            this.expTvarValue.Name = "expTvarValue";
            this.expTvarValue.ReadOnly = false;
            this.expTvarValue.Size = new System.Drawing.Size(620, 20);
            this.expTvarValue.TabIndex = 23;
            this.expTvarValue.EnabledChanged += new System.EventHandler(this.expTvarValue_EnabledChanged);
            // 
            // lblTvarValue
            // 
            this.lblTvarValue.AutoSize = true;
            this.lblTvarValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTvarValue.Location = new System.Drawing.Point(3, 80);
            this.lblTvarValue.Name = "lblTvarValue";
            this.lblTvarValue.Size = new System.Drawing.Size(110, 26);
            this.lblTvarValue.TabIndex = 32;
            this.lblTvarValue.Text = "Expression";
            this.lblTvarValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTvarName
            // 
            this.expTvarName.AutocompleteAvailable = true;
            this.expTvarName.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTvarName.AutoSize = true;
            this.expTvarName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTvarName.Expression = "";
            this.expTvarName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expTvarName.IsPersistent = false;
            this.expTvarName.Location = new System.Drawing.Point(119, 30);
            this.expTvarName.Name = "expTvarName";
            this.expTvarName.ReadOnly = false;
            this.expTvarName.Size = new System.Drawing.Size(590, 20);
            this.expTvarName.TabIndex = 16;
            this.expTvarName.EnabledChanged += new System.EventHandler(this.expTvarName_EnabledChanged);
            // 
            // lblTvarName
            // 
            this.lblTvarName.AutoSize = true;
            this.lblTvarName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTvarName.Location = new System.Drawing.Point(3, 27);
            this.lblTvarName.Name = "lblTvarName";
            this.lblTvarName.Size = new System.Drawing.Size(110, 26);
            this.lblTvarName.TabIndex = 33;
            this.lblTvarName.Text = "Source variable name";
            this.lblTvarName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTvarOpType
            // 
            this.lblTvarOpType.AutoSize = true;
            this.lblTvarOpType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTvarOpType.Location = new System.Drawing.Point(3, 0);
            this.lblTvarOpType.Name = "lblTvarOpType";
            this.lblTvarOpType.Size = new System.Drawing.Size(110, 27);
            this.lblTvarOpType.TabIndex = 34;
            this.lblTvarOpType.Text = "Operation type";
            this.lblTvarOpType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxTvarOpType
            // 
            this.tableLayoutPanel21.SetColumnSpan(this.cbxTvarOpType, 2);
            this.cbxTvarOpType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxTvarOpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTvarOpType.FormattingEnabled = true;
            this.cbxTvarOpType.Items.AddRange(new object[] {
            "Unset table variable",
            "Set value to the given row and column on the table variable",
            "Set all values in the table variable",
            "Set all values in the selected rows and columns",
            "Resize table variable",
            "Build from the expression",
            "Set values to the given col or row",
            "Insert values at the given col or row",
            "Remove the given column or row",
            "Filter elements into another list",
            "Filter rows/cols into another table",
            "Copy whole table variable to another table variable",
            "Append whole table variable to another table vertically",
            "Append whole table variable to another table horizontally",
            "Sort the rows/cols by the key functions",
            "Get specified properties for specified FFXIV entities",
            "Unset all table variables",
            "Unset table variables matching regular expression"});
            this.cbxTvarOpType.Location = new System.Drawing.Point(119, 3);
            this.cbxTvarOpType.Name = "cbxTvarOpType";
            this.cbxTvarOpType.Size = new System.Drawing.Size(620, 21);
            this.cbxTvarOpType.TabIndex = 35;
            this.cbxTvarOpType.TabStop = false;
            this.cbxTvarOpType.SelectedIndexChanged += new System.EventHandler(this.cbxTvarOpType_SelectedIndexChanged);
            // 
            // tabDictVariable
            // 
            this.tabDictVariable.Controls.Add(this.tableLayoutPanelDict);
            this.tabDictVariable.Location = new System.Drawing.Point(4, 25);
            this.tabDictVariable.Name = "tabDictVariable";
            this.tabDictVariable.Size = new System.Drawing.Size(742, 414);
            this.tabDictVariable.TabIndex = 6;
            this.tabDictVariable.Text = "DictVariable";
            this.tabDictVariable.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelDict
            // 
            this.tableLayoutPanelDict.AutoSize = true;
            this.tableLayoutPanelDict.ColumnCount = 3;
            this.tableLayoutPanelDict.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelDict.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDict.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelDict.Controls.Add(this.lblDictOpType, 0, 0);
            this.tableLayoutPanelDict.Controls.Add(this.cbxDictOpType, 1, 0);
            this.tableLayoutPanelDict.Controls.Add(this.lblDictName, 0, 1);
            this.tableLayoutPanelDict.Controls.Add(this.expDictName, 1, 1);
            this.tableLayoutPanelDict.Controls.Add(this.prsDictSource, 2, 1);
            this.tableLayoutPanelDict.Controls.Add(this.lblDictLength, 0, 2);
            this.tableLayoutPanelDict.Controls.Add(this.expDictLength, 1, 2);
            this.tableLayoutPanelDict.Controls.Add(this.lblDictKeyType, 0, 3);
            this.tableLayoutPanelDict.Controls.Add(this.cbxDictKeyType, 1, 3);
            this.tableLayoutPanelDict.Controls.Add(this.lblDictKey, 0, 4);
            this.tableLayoutPanelDict.Controls.Add(this.expDictKey, 1, 4);
            this.tableLayoutPanelDict.Controls.Add(this.lblDictValueType, 0, 5);
            this.tableLayoutPanelDict.Controls.Add(this.cbxDictValueType, 1, 5);
            this.tableLayoutPanelDict.Controls.Add(this.lblDictValue, 0, 6);
            this.tableLayoutPanelDict.Controls.Add(this.expDictValue, 1, 6);
            this.tableLayoutPanelDict.Controls.Add(this.lblDictTarget, 0, 7);
            this.tableLayoutPanelDict.Controls.Add(this.expDictTarget, 1, 7);
            this.tableLayoutPanelDict.Controls.Add(this.prsDictTarget, 2, 7);
            this.tableLayoutPanelDict.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelDict.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelDict.Name = "tableLayoutPanelDict";
            this.tableLayoutPanelDict.RowCount = 8;
            this.tableLayoutPanelDict.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDict.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDict.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDict.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDict.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDict.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDict.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDict.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDict.Size = new System.Drawing.Size(742, 211);
            this.tableLayoutPanelDict.TabIndex = 0;
            // 
            // lblDictOpType
            // 
            this.lblDictOpType.AutoSize = true;
            this.lblDictOpType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDictOpType.Location = new System.Drawing.Point(3, 0);
            this.lblDictOpType.Name = "lblDictOpType";
            this.lblDictOpType.Size = new System.Drawing.Size(110, 27);
            this.lblDictOpType.TabIndex = 0;
            this.lblDictOpType.Text = "Operation type";
            this.lblDictOpType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxDictOpType
            // 
            this.tableLayoutPanelDict.SetColumnSpan(this.cbxDictOpType, 2);
            this.cbxDictOpType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxDictOpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDictOpType.FormattingEnabled = true;
            this.cbxDictOpType.Items.AddRange(new object[] {
            "Unset dictionary variable",
            "Set value of the given key",
            "Remove the given key",
            "Set all keys and values",
            "Build from the expression",
            "Filter into another dictionary",
            "Merge two dictionaries (keep)",
            "Merge two dictionaries (overwrite)",
            "Get specified properties of a specified FFXIV entity",
            "Unset all dictionary variables",
            "Unset dictionary variables matching regular expression"});
            this.cbxDictOpType.Location = new System.Drawing.Point(119, 3);
            this.cbxDictOpType.Name = "cbxDictOpType";
            this.cbxDictOpType.Size = new System.Drawing.Size(620, 21);
            this.cbxDictOpType.TabIndex = 1;
            this.cbxDictOpType.TabStop = false;
            this.cbxDictOpType.SelectedIndexChanged += new System.EventHandler(this.cbxDictOpType_SelectedIndexChanged);
            // 
            // lblDictName
            // 
            this.lblDictName.AutoSize = true;
            this.lblDictName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDictName.Location = new System.Drawing.Point(3, 27);
            this.lblDictName.Name = "lblDictName";
            this.lblDictName.Size = new System.Drawing.Size(110, 26);
            this.lblDictName.TabIndex = 2;
            this.lblDictName.Text = "Source variable name";
            this.lblDictName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expDictName
            // 
            this.expDictName.AutocompleteAvailable = true;
            this.expDictName.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expDictName.AutoSize = true;
            this.expDictName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expDictName.Expression = "";
            this.expDictName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expDictName.IsPersistent = false;
            this.expDictName.Location = new System.Drawing.Point(119, 30);
            this.expDictName.Name = "expDictName";
            this.expDictName.ReadOnly = false;
            this.expDictName.Size = new System.Drawing.Size(590, 20);
            this.expDictName.TabIndex = 16;
            this.expDictName.EnabledChanged += new System.EventHandler(this.expDictName_EnabledChanged);
            // 
            // prsDictSource
            // 
            this.prsDictSource.AutoSize = true;
            this.prsDictSource.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prsDictSource.BackgroundImage")));
            this.prsDictSource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.prsDictSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prsDictSource.IsPersistent = false;
            this.prsDictSource.Location = new System.Drawing.Point(715, 30);
            this.prsDictSource.Name = "prsDictSource";
            this.prsDictSource.RelatedTextbox = null;
            this.prsDictSource.Size = new System.Drawing.Size(24, 20);
            this.prsDictSource.TabIndex = 17;
            this.prsDictSource.TabStop = false;
            this.prsDictSource.Tag = ((object)(resources.GetObject("prsDictSource.Tag")));
            // 
            // lblDictLength
            // 
            this.lblDictLength.AutoSize = true;
            this.lblDictLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDictLength.Location = new System.Drawing.Point(3, 53);
            this.lblDictLength.Name = "lblDictLength";
            this.lblDictLength.Size = new System.Drawing.Size(110, 26);
            this.lblDictLength.TabIndex = 18;
            this.lblDictLength.Text = "Length";
            this.lblDictLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expDictLength
            // 
            this.expDictLength.AutocompleteAvailable = true;
            this.expDictLength.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expDictLength.AutoSize = true;
            this.tableLayoutPanelDict.SetColumnSpan(this.expDictLength, 2);
            this.expDictLength.Dock = System.Windows.Forms.DockStyle.Top;
            this.expDictLength.Expression = "";
            this.expDictLength.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expDictLength.IsPersistent = false;
            this.expDictLength.Location = new System.Drawing.Point(119, 56);
            this.expDictLength.Name = "expDictLength";
            this.expDictLength.ReadOnly = false;
            this.expDictLength.Size = new System.Drawing.Size(620, 20);
            this.expDictLength.TabIndex = 23;
            this.expDictLength.EnabledChanged += new System.EventHandler(this.expDictLength_EnabledChanged);
            // 
            // lblDictKeyType
            // 
            this.lblDictKeyType.AutoSize = true;
            this.lblDictKeyType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDictKeyType.Location = new System.Drawing.Point(3, 79);
            this.lblDictKeyType.Name = "lblDictKeyType";
            this.lblDictKeyType.Size = new System.Drawing.Size(110, 27);
            this.lblDictKeyType.TabIndex = 24;
            this.lblDictKeyType.Text = "Key Expr type";
            this.lblDictKeyType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxDictKeyType
            // 
            this.tableLayoutPanelDict.SetColumnSpan(this.cbxDictKeyType, 2);
            this.cbxDictKeyType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxDictKeyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDictKeyType.FormattingEnabled = true;
            this.cbxDictKeyType.Items.AddRange(new object[] {
            "String",
            "Numeric"});
            this.cbxDictKeyType.Location = new System.Drawing.Point(119, 82);
            this.cbxDictKeyType.Name = "cbxDictKeyType";
            this.cbxDictKeyType.Size = new System.Drawing.Size(620, 21);
            this.cbxDictKeyType.TabIndex = 25;
            this.cbxDictKeyType.TabStop = false;
            this.cbxDictKeyType.SelectedIndexChanged += new System.EventHandler(this.cbxDictKeyType_SelectedIndexChanged);
            this.cbxDictKeyType.EnabledChanged += new System.EventHandler(this.cbxDictKeyType_EnabledChanged);
            // 
            // lblDictKey
            // 
            this.lblDictKey.AutoSize = true;
            this.lblDictKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDictKey.Location = new System.Drawing.Point(3, 106);
            this.lblDictKey.Name = "lblDictKey";
            this.lblDictKey.Size = new System.Drawing.Size(110, 26);
            this.lblDictKey.TabIndex = 26;
            this.lblDictKey.Text = "Key";
            this.lblDictKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expDictKey
            // 
            this.expDictKey.AutocompleteAvailable = true;
            this.expDictKey.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expDictKey.AutoSize = true;
            this.tableLayoutPanelDict.SetColumnSpan(this.expDictKey, 2);
            this.expDictKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.expDictKey.Expression = "";
            this.expDictKey.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expDictKey.IsPersistent = false;
            this.expDictKey.Location = new System.Drawing.Point(119, 109);
            this.expDictKey.Name = "expDictKey";
            this.expDictKey.ReadOnly = false;
            this.expDictKey.Size = new System.Drawing.Size(620, 20);
            this.expDictKey.TabIndex = 23;
            this.expDictKey.EnabledChanged += new System.EventHandler(this.expDictKey_EnabledChanged);
            // 
            // lblDictValueType
            // 
            this.lblDictValueType.AutoSize = true;
            this.lblDictValueType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDictValueType.Location = new System.Drawing.Point(3, 132);
            this.lblDictValueType.Name = "lblDictValueType";
            this.lblDictValueType.Size = new System.Drawing.Size(110, 27);
            this.lblDictValueType.TabIndex = 27;
            this.lblDictValueType.Text = "Value Expr type";
            this.lblDictValueType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxDictValueType
            // 
            this.tableLayoutPanelDict.SetColumnSpan(this.cbxDictValueType, 2);
            this.cbxDictValueType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxDictValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDictValueType.FormattingEnabled = true;
            this.cbxDictValueType.Items.AddRange(new object[] {
            "String",
            "Numeric"});
            this.cbxDictValueType.Location = new System.Drawing.Point(119, 135);
            this.cbxDictValueType.Name = "cbxDictValueType";
            this.cbxDictValueType.Size = new System.Drawing.Size(620, 21);
            this.cbxDictValueType.TabIndex = 28;
            this.cbxDictValueType.TabStop = false;
            this.cbxDictValueType.SelectedIndexChanged += new System.EventHandler(this.cbxDictValueType_SelectedIndexChanged);
            this.cbxDictValueType.EnabledChanged += new System.EventHandler(this.cbxDictValueType_EnabledChanged);
            // 
            // lblDictValue
            // 
            this.lblDictValue.AutoSize = true;
            this.lblDictValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDictValue.Location = new System.Drawing.Point(3, 159);
            this.lblDictValue.Name = "lblDictValue";
            this.lblDictValue.Size = new System.Drawing.Size(110, 26);
            this.lblDictValue.TabIndex = 29;
            this.lblDictValue.Text = "Value";
            this.lblDictValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expDictValue
            // 
            this.expDictValue.AutocompleteAvailable = true;
            this.expDictValue.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expDictValue.AutoSize = true;
            this.tableLayoutPanelDict.SetColumnSpan(this.expDictValue, 2);
            this.expDictValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.expDictValue.Expression = "";
            this.expDictValue.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expDictValue.IsPersistent = false;
            this.expDictValue.Location = new System.Drawing.Point(119, 162);
            this.expDictValue.Name = "expDictValue";
            this.expDictValue.ReadOnly = false;
            this.expDictValue.Size = new System.Drawing.Size(620, 20);
            this.expDictValue.TabIndex = 23;
            this.expDictValue.EnabledChanged += new System.EventHandler(this.expDictValue_EnabledChanged);
            // 
            // lblDictTarget
            // 
            this.lblDictTarget.AutoSize = true;
            this.lblDictTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDictTarget.Location = new System.Drawing.Point(3, 185);
            this.lblDictTarget.Name = "lblDictTarget";
            this.lblDictTarget.Size = new System.Drawing.Size(110, 26);
            this.lblDictTarget.TabIndex = 30;
            this.lblDictTarget.Text = "Target variable name";
            this.lblDictTarget.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expDictTarget
            // 
            this.expDictTarget.AutocompleteAvailable = true;
            this.expDictTarget.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expDictTarget.AutoSize = true;
            this.expDictTarget.Dock = System.Windows.Forms.DockStyle.Top;
            this.expDictTarget.Expression = "";
            this.expDictTarget.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expDictTarget.IsPersistent = false;
            this.expDictTarget.Location = new System.Drawing.Point(119, 188);
            this.expDictTarget.Name = "expDictTarget";
            this.expDictTarget.ReadOnly = false;
            this.expDictTarget.Size = new System.Drawing.Size(590, 20);
            this.expDictTarget.TabIndex = 27;
            this.expDictTarget.EnabledChanged += new System.EventHandler(this.expDictTarget_EnabledChanged);
            // 
            // prsDictTarget
            // 
            this.prsDictTarget.AutoSize = true;
            this.prsDictTarget.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prsDictTarget.BackgroundImage")));
            this.prsDictTarget.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.prsDictTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prsDictTarget.IsPersistent = false;
            this.prsDictTarget.Location = new System.Drawing.Point(715, 188);
            this.prsDictTarget.Name = "prsDictTarget";
            this.prsDictTarget.RelatedTextbox = null;
            this.prsDictTarget.Size = new System.Drawing.Size(24, 20);
            this.prsDictTarget.TabIndex = 31;
            this.prsDictTarget.TabStop = false;
            this.prsDictTarget.Tag = ((object)(resources.GetObject("prsDictTarget.Tag")));
            // 
            // tabMessageBox
            // 
            this.tabMessageBox.AutoScroll = true;
            this.tabMessageBox.Controls.Add(this.tableLayoutPanel8);
            this.tabMessageBox.Location = new System.Drawing.Point(4, 25);
            this.tabMessageBox.Name = "tabMessageBox";
            this.tabMessageBox.Size = new System.Drawing.Size(742, 414);
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
            this.tableLayoutPanel8.Size = new System.Drawing.Size(742, 53);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // expMessageBoxText
            // 
            this.expMessageBoxText.AutocompleteAvailable = true;
            this.expMessageBoxText.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expMessageBoxText.AutoSize = true;
            this.expMessageBoxText.Dock = System.Windows.Forms.DockStyle.Top;
            this.expMessageBoxText.Expression = "";
            this.expMessageBoxText.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expMessageBoxText.IsPersistent = false;
            this.expMessageBoxText.Location = new System.Drawing.Point(102, 30);
            this.expMessageBoxText.Name = "expMessageBoxText";
            this.expMessageBoxText.ReadOnly = false;
            this.expMessageBoxText.Size = new System.Drawing.Size(637, 20);
            this.expMessageBoxText.TabIndex = 16;
            // 
            // lblMessageBoxText
            // 
            this.lblMessageBoxText.AutoSize = true;
            this.lblMessageBoxText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessageBoxText.Location = new System.Drawing.Point(3, 27);
            this.lblMessageBoxText.Name = "lblMessageBoxText";
            this.lblMessageBoxText.Size = new System.Drawing.Size(93, 26);
            this.lblMessageBoxText.TabIndex = 17;
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
            this.lblMessageBoxIcon.TabIndex = 18;
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
            this.cbxMessageBoxIcon.Size = new System.Drawing.Size(637, 21);
            this.cbxMessageBoxIcon.TabIndex = 19;
            this.cbxMessageBoxIcon.TabStop = false;
            // 
            // tabLogMessage
            // 
            this.tabLogMessage.Controls.Add(this.tableLayoutPanel14);
            this.tabLogMessage.Location = new System.Drawing.Point(4, 25);
            this.tabLogMessage.Name = "tabLogMessage";
            this.tabLogMessage.Size = new System.Drawing.Size(742, 414);
            this.tabLogMessage.TabIndex = 8;
            this.tabLogMessage.Text = "LogMessage";
            this.tabLogMessage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.AutoSize = true;
            this.tableLayoutPanel14.ColumnCount = 2;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Controls.Add(this.lblLogMessageText, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.expLogMessageText, 1, 0);
            this.tableLayoutPanel14.Controls.Add(this.chkProcessLog, 0, 1);
            this.tableLayoutPanel14.Controls.Add(this.chkProcessLogACT, 0, 2);
            this.tableLayoutPanel14.Controls.Add(this.lblLogMessageLevel, 0, 3);
            this.tableLayoutPanel14.Controls.Add(this.cbxLogMessageLevel, 1, 3);
            this.tableLayoutPanel14.Controls.Add(this.lblLogMessageTarget, 0, 4);
            this.tableLayoutPanel14.Controls.Add(this.cbxLogMessageTarget, 1, 4);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 4;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(742, 127);
            this.tableLayoutPanel14.TabIndex = 0;
            // 
            // lblLogMessageText
            // 
            this.lblLogMessageText.AutoSize = true;
            this.lblLogMessageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogMessageText.Location = new System.Drawing.Point(3, 0);
            this.lblLogMessageText.Name = "lblLogMessageText";
            this.lblLogMessageText.Size = new System.Drawing.Size(122, 26);
            this.lblLogMessageText.TabIndex = 0;
            this.lblLogMessageText.Text = "Message to log";
            this.lblLogMessageText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expLogMessageText
            // 
            this.expLogMessageText.AutocompleteAvailable = true;
            this.expLogMessageText.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expLogMessageText.AutoSize = true;
            this.expLogMessageText.Dock = System.Windows.Forms.DockStyle.Top;
            this.expLogMessageText.Expression = "";
            this.expLogMessageText.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expLogMessageText.IsPersistent = false;
            this.expLogMessageText.Location = new System.Drawing.Point(131, 3);
            this.expLogMessageText.Name = "expLogMessageText";
            this.expLogMessageText.ReadOnly = false;
            this.expLogMessageText.Size = new System.Drawing.Size(608, 20);
            this.expLogMessageText.TabIndex = 14;
            // 
            // chkProcessLog
            // 
            this.chkProcessLog.AutoSize = true;
            this.chkProcessLog.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel14.SetColumnSpan(this.chkProcessLog, 2);
            this.chkProcessLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkProcessLog.Location = new System.Drawing.Point(3, 31);
            this.chkProcessLog.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkProcessLog.Name = "chkProcessLog";
            this.chkProcessLog.Size = new System.Drawing.Size(737, 17);
            this.chkProcessLog.TabIndex = 15;
            this.chkProcessLog.TabStop = false;
            this.chkProcessLog.Text = "Process message as log line";
            this.chkProcessLog.UseVisualStyleBackColor = true;
            this.chkProcessLog.CheckedChanged += new System.EventHandler(this.chkProcessLog_CheckedChanged);
            // 
            // chkProcessLogACT
            // 
            this.chkProcessLogACT.AutoSize = true;
            this.chkProcessLogACT.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel14.SetColumnSpan(this.chkProcessLogACT, 2);
            this.chkProcessLogACT.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkProcessLogACT.Location = new System.Drawing.Point(3, 58);
            this.chkProcessLogACT.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkProcessLogACT.Name = "chkProcessLogACT";
            this.chkProcessLogACT.Size = new System.Drawing.Size(737, 17);
            this.chkProcessLogACT.TabIndex = 16;
            this.chkProcessLogACT.TabStop = false;
            this.chkProcessLogACT.Text = "Add the log message to ACT combat log";
            this.chkProcessLogACT.UseVisualStyleBackColor = true;
            // 
            // lblLogMessageLevel
            // 
            this.lblLogMessageLevel.AutoSize = true;
            this.lblLogMessageLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogMessageLevel.Location = new System.Drawing.Point(3, 80);
            this.lblLogMessageLevel.Name = "lblLogMessageLevel";
            this.lblLogMessageLevel.Size = new System.Drawing.Size(122, 27);
            this.lblLogMessageLevel.TabIndex = 17;
            this.lblLogMessageLevel.Text = "Level to log message on";
            this.lblLogMessageLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxLogMessageLevel
            // 
            this.cbxLogMessageLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxLogMessageLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLogMessageLevel.FormattingEnabled = true;
            this.cbxLogMessageLevel.Items.AddRange(new object[] {
            "Error",
            "Warning",
            "Custom",
            "Custom 2",
            "Info",
            "Verbose"});
            this.cbxLogMessageLevel.Location = new System.Drawing.Point(131, 83);
            this.cbxLogMessageLevel.Name = "cbxLogMessageLevel";
            this.cbxLogMessageLevel.Size = new System.Drawing.Size(608, 21);
            this.cbxLogMessageLevel.TabIndex = 18;
            this.cbxLogMessageLevel.TabStop = false;
            // 
            // lblLogMessageTarget
            // 
            this.lblLogMessageTarget.AutoSize = true;
            this.lblLogMessageTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogMessageTarget.Location = new System.Drawing.Point(3, 107);
            this.lblLogMessageTarget.Name = "lblLogMessageTarget";
            this.lblLogMessageTarget.Size = new System.Drawing.Size(122, 20);
            this.lblLogMessageTarget.TabIndex = 19;
            this.lblLogMessageTarget.Text = "Target event source";
            this.lblLogMessageTarget.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxLogMessageTarget
            // 
            this.cbxLogMessageTarget.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxLogMessageTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLogMessageTarget.FormattingEnabled = true;
            this.cbxLogMessageTarget.Items.AddRange(new object[] {
            "Normal log line",
            "FFXIV network event",
            "ACT event"});
            this.cbxLogMessageTarget.Location = new System.Drawing.Point(131, 110);
            this.cbxLogMessageTarget.Name = "cbxLogMessageTarget";
            this.cbxLogMessageTarget.Size = new System.Drawing.Size(608, 21);
            this.cbxLogMessageTarget.TabIndex = 20;
            this.cbxLogMessageTarget.TabStop = false;
            // 
            // tabTextAura
            // 
            this.tabTextAura.AutoScroll = true;
            this.tabTextAura.Controls.Add(this.tableLayoutPanel13);
            this.tabTextAura.Location = new System.Drawing.Point(4, 25);
            this.tabTextAura.Name = "tabTextAura";
            this.tabTextAura.Size = new System.Drawing.Size(742, 414);
            this.tabTextAura.TabIndex = 9;
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
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraOp, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.cbxTextAuraOp, 1, 0);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraName, 0, 1);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraName, 1, 1);
            this.tableLayoutPanel13.Controls.Add(this.btnTextAuraHide, 3, 1);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraText, 0, 2);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraText, 1, 2);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraFont, 0, 3);
            this.tableLayoutPanel13.Controls.Add(this.colorSelector1, 1, 3);
            this.tableLayoutPanel13.Controls.Add(this.txtTextAuraFont, 2, 3);
            this.tableLayoutPanel13.Controls.Add(this.btnTextAuraFont, 3, 3);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraAlignment, 0, 4);
            this.tableLayoutPanel13.Controls.Add(this.cbxTextAuraAlignment, 1, 4);
            this.tableLayoutPanel13.Controls.Add(this.lblTextColor, 0, 5);
            this.tableLayoutPanel13.Controls.Add(this.tableTextColor, 1, 5);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraIniValues, 1, 6);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraUpdValues, 2, 6);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraX, 0, 7);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraXIni, 1, 7);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraXTick, 2, 7);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraY, 0, 8);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraYIni, 1, 8);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraYTick, 2, 8);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraWidth, 0, 9);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraWIni, 1, 9);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraWTick, 2, 9);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraHeight, 0, 10);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraHIni, 1, 10);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraHTick, 2, 10);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraOpacity, 0, 11);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraOIni, 1, 11);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraOTick, 2, 11);
            this.tableLayoutPanel13.Controls.Add(this.lblTextAuraTtlExp, 0, 12);
            this.tableLayoutPanel13.Controls.Add(this.expTextAuraTTLTick, 2, 12);
            this.tableLayoutPanel13.Controls.Add(this.btnTextAuraGuide, 1, 13);
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
            this.tableLayoutPanel13.Size = new System.Drawing.Size(742, 369);
            this.tableLayoutPanel13.TabIndex = 0;
            // 
            // lblTextAuraOp
            // 
            this.lblTextAuraOp.AutoSize = true;
            this.lblTextAuraOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraOp.Location = new System.Drawing.Point(3, 0);
            this.lblTextAuraOp.Name = "lblTextAuraOp";
            this.lblTextAuraOp.Size = new System.Drawing.Size(114, 27);
            this.lblTextAuraOp.TabIndex = 0;
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
            "Deactivate all text auras",
            "Deactivate text auras by regular expression"});
            this.cbxTextAuraOp.Location = new System.Drawing.Point(123, 3);
            this.cbxTextAuraOp.Name = "cbxTextAuraOp";
            this.cbxTextAuraOp.Size = new System.Drawing.Size(616, 21);
            this.cbxTextAuraOp.TabIndex = 1;
            this.cbxTextAuraOp.TabStop = false;
            this.cbxTextAuraOp.SelectedIndexChanged += new System.EventHandler(this.cbxTextAuraOp_SelectedIndexChanged);
            // 
            // lblTextAuraName
            // 
            this.lblTextAuraName.AutoSize = true;
            this.lblTextAuraName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraName.Location = new System.Drawing.Point(3, 27);
            this.lblTextAuraName.Name = "lblTextAuraName";
            this.lblTextAuraName.Size = new System.Drawing.Size(114, 26);
            this.lblTextAuraName.TabIndex = 2;
            this.lblTextAuraName.Text = "Unique identifier";
            this.lblTextAuraName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTextAuraName
            // 
            this.expTextAuraName.AutocompleteAvailable = true;
            this.expTextAuraName.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTextAuraName.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.expTextAuraName, 2);
            this.expTextAuraName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraName.Expression = "";
            this.expTextAuraName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expTextAuraName.IsPersistent = false;
            this.expTextAuraName.Location = new System.Drawing.Point(123, 30);
            this.expTextAuraName.Name = "expTextAuraName";
            this.expTextAuraName.ReadOnly = false;
            this.expTextAuraName.Size = new System.Drawing.Size(534, 20);
            this.expTextAuraName.TabIndex = 8;
            this.expTextAuraName.EnabledChanged += new System.EventHandler(this.expTextAuraName_EnabledChanged);
            // 
            // btnTextAuraHide
            // 
            this.btnTextAuraHide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTextAuraHide.Location = new System.Drawing.Point(660, 27);
            this.btnTextAuraHide.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnTextAuraHide.Name = "btnTextAuraHide";
            this.btnTextAuraHide.Size = new System.Drawing.Size(79, 26);
            this.btnTextAuraHide.TabIndex = 9;
            this.btnTextAuraHide.TabStop = false;
            this.btnTextAuraHide.Text = "Hide";
            this.btnTextAuraHide.UseVisualStyleBackColor = true;
            this.btnTextAuraHide.Click += new System.EventHandler(this.btnTextAuraHide_Click);
            // 
            // lblTextAuraText
            // 
            this.lblTextAuraText.AutoSize = true;
            this.lblTextAuraText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraText.Location = new System.Drawing.Point(3, 53);
            this.lblTextAuraText.Name = "lblTextAuraText";
            this.lblTextAuraText.Size = new System.Drawing.Size(114, 26);
            this.lblTextAuraText.TabIndex = 10;
            this.lblTextAuraText.Text = "Text to display";
            this.lblTextAuraText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTextAuraText
            // 
            this.expTextAuraText.AutocompleteAvailable = true;
            this.expTextAuraText.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTextAuraText.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.expTextAuraText, 3);
            this.expTextAuraText.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraText.Expression = "";
            this.expTextAuraText.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expTextAuraText.IsPersistent = false;
            this.expTextAuraText.Location = new System.Drawing.Point(123, 56);
            this.expTextAuraText.Name = "expTextAuraText";
            this.expTextAuraText.ReadOnly = false;
            this.expTextAuraText.Size = new System.Drawing.Size(616, 20);
            this.expTextAuraText.TabIndex = 9;
            this.expTextAuraText.EnabledChanged += new System.EventHandler(this.expTextAuraText_EnabledChanged);
            // 
            // lblTextAuraFont
            // 
            this.lblTextAuraFont.AutoSize = true;
            this.lblTextAuraFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraFont.Location = new System.Drawing.Point(3, 79);
            this.lblTextAuraFont.Name = "lblTextAuraFont";
            this.lblTextAuraFont.Size = new System.Drawing.Size(114, 26);
            this.lblTextAuraFont.TabIndex = 11;
            this.lblTextAuraFont.Text = "Font";
            this.lblTextAuraFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.colorSelector1.Size = new System.Drawing.Size(156, 20);
            this.colorSelector1.TabIndex = 12;
            this.colorSelector1.TabStop = false;
            this.colorSelector1.TextColor = System.Drawing.Color.Empty;
            this.colorSelector1.TextOutlineColor = System.Drawing.Color.Empty;
            this.colorSelector1.EnabledChanged += new System.EventHandler(this.colorSelector1_EnabledChanged);
            // 
            // txtTextAuraFont
            // 
            this.txtTextAuraFont.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTextAuraFont.Location = new System.Drawing.Point(285, 82);
            this.txtTextAuraFont.Name = "txtTextAuraFont";
            this.txtTextAuraFont.ReadOnly = true;
            this.txtTextAuraFont.Size = new System.Drawing.Size(372, 20);
            this.txtTextAuraFont.TabIndex = 13;
            this.txtTextAuraFont.TabStop = false;
            // 
            // btnTextAuraFont
            // 
            this.btnTextAuraFont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTextAuraFont.Location = new System.Drawing.Point(660, 79);
            this.btnTextAuraFont.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnTextAuraFont.Name = "btnTextAuraFont";
            this.btnTextAuraFont.Size = new System.Drawing.Size(79, 26);
            this.btnTextAuraFont.TabIndex = 14;
            this.btnTextAuraFont.TabStop = false;
            this.btnTextAuraFont.Text = "...";
            this.btnTextAuraFont.UseVisualStyleBackColor = true;
            this.btnTextAuraFont.Click += new System.EventHandler(this.btnTextAuraFont_Click);
            // 
            // lblTextAuraAlignment
            // 
            this.lblTextAuraAlignment.AutoSize = true;
            this.lblTextAuraAlignment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraAlignment.Location = new System.Drawing.Point(3, 105);
            this.lblTextAuraAlignment.Name = "lblTextAuraAlignment";
            this.lblTextAuraAlignment.Size = new System.Drawing.Size(114, 27);
            this.lblTextAuraAlignment.TabIndex = 15;
            this.lblTextAuraAlignment.Text = "Text alignment";
            this.lblTextAuraAlignment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cbxTextAuraAlignment.Size = new System.Drawing.Size(616, 21);
            this.cbxTextAuraAlignment.TabIndex = 16;
            this.cbxTextAuraAlignment.TabStop = false;
            this.cbxTextAuraAlignment.EnabledChanged += new System.EventHandler(this.cbxTextAuraAlignment_EnabledChanged);
            // 
            // lblTextColor
            // 
            this.lblTextColor.AutoSize = true;
            this.lblTextColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextColor.Location = new System.Drawing.Point(3, 132);
            this.lblTextColor.Name = "lblTextColor";
            this.lblTextColor.Size = new System.Drawing.Size(114, 32);
            this.lblTextColor.TabIndex = 17;
            this.lblTextColor.Text = "Colors";
            this.lblTextColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableTextColor
            // 
            this.tableTextColor.AutoSize = true;
            this.tableTextColor.ColumnCount = 6;
            this.tableLayoutPanel13.SetColumnSpan(this.tableTextColor, 3);
            this.tableTextColor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableTextColor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableTextColor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableTextColor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableTextColor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableTextColor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableTextColor.Controls.Add(this.lblTextForeColor, 0, 0);
            this.tableTextColor.Controls.Add(this.expTextForeColor, 1, 0);
            this.tableTextColor.Controls.Add(this.lblTextBackColor, 2, 0);
            this.tableTextColor.Controls.Add(this.expTextBackColor, 3, 0);
            this.tableTextColor.Controls.Add(this.lblTextOutlineColor, 4, 0);
            this.tableTextColor.Controls.Add(this.expTextOutlineColor, 5, 0);
            this.tableTextColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableTextColor.Location = new System.Drawing.Point(123, 135);
            this.tableTextColor.Name = "tableTextColor";
            this.tableTextColor.RowCount = 1;
            this.tableTextColor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableTextColor.Size = new System.Drawing.Size(616, 26);
            this.tableTextColor.TabIndex = 18;
            // 
            // lblTextForeColor
            // 
            this.lblTextForeColor.AutoSize = true;
            this.lblTextForeColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextForeColor.Location = new System.Drawing.Point(3, 0);
            this.lblTextForeColor.Name = "lblTextForeColor";
            this.lblTextForeColor.Size = new System.Drawing.Size(28, 26);
            this.lblTextForeColor.TabIndex = 0;
            this.lblTextForeColor.Text = "Text";
            this.lblTextForeColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTextForeColor
            // 
            this.expTextForeColor.AutocompleteAvailable = true;
            this.expTextForeColor.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTextForeColor.AutoSize = true;
            this.expTextForeColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expTextForeColor.Expression = "";
            this.expTextForeColor.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Color;
            this.expTextForeColor.IsPersistent = false;
            this.expTextForeColor.Location = new System.Drawing.Point(37, 3);
            this.expTextForeColor.Name = "expTextForeColor";
            this.expTextForeColor.ReadOnly = false;
            this.expTextForeColor.Size = new System.Drawing.Size(160, 20);
            this.expTextForeColor.TabIndex = 10;
            // 
            // lblTextBackColor
            // 
            this.lblTextBackColor.AutoSize = true;
            this.lblTextBackColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextBackColor.Location = new System.Drawing.Point(203, 0);
            this.lblTextBackColor.Name = "lblTextBackColor";
            this.lblTextBackColor.Size = new System.Drawing.Size(32, 26);
            this.lblTextBackColor.TabIndex = 11;
            this.lblTextBackColor.Text = "Back";
            this.lblTextBackColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTextBackColor
            // 
            this.expTextBackColor.AutocompleteAvailable = true;
            this.expTextBackColor.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTextBackColor.AutoSize = true;
            this.expTextBackColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expTextBackColor.Expression = "";
            this.expTextBackColor.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Color;
            this.expTextBackColor.IsPersistent = false;
            this.expTextBackColor.Location = new System.Drawing.Point(241, 3);
            this.expTextBackColor.Name = "expTextBackColor";
            this.expTextBackColor.ReadOnly = false;
            this.expTextBackColor.Size = new System.Drawing.Size(160, 20);
            this.expTextBackColor.TabIndex = 11;
            // 
            // lblTextOutlineColor
            // 
            this.lblTextOutlineColor.AutoSize = true;
            this.lblTextOutlineColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextOutlineColor.Location = new System.Drawing.Point(407, 0);
            this.lblTextOutlineColor.Name = "lblTextOutlineColor";
            this.lblTextOutlineColor.Size = new System.Drawing.Size(40, 26);
            this.lblTextOutlineColor.TabIndex = 12;
            this.lblTextOutlineColor.Text = "Outline";
            this.lblTextOutlineColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTextOutlineColor
            // 
            this.expTextOutlineColor.AutocompleteAvailable = true;
            this.expTextOutlineColor.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTextOutlineColor.AutoSize = true;
            this.expTextOutlineColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expTextOutlineColor.Expression = "";
            this.expTextOutlineColor.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Color;
            this.expTextOutlineColor.IsPersistent = false;
            this.expTextOutlineColor.Location = new System.Drawing.Point(453, 3);
            this.expTextOutlineColor.Name = "expTextOutlineColor";
            this.expTextOutlineColor.ReadOnly = false;
            this.expTextOutlineColor.Size = new System.Drawing.Size(160, 20);
            this.expTextOutlineColor.TabIndex = 12;
            // 
            // lblTextAuraIniValues
            // 
            this.lblTextAuraIniValues.BackColor = System.Drawing.SystemColors.Info;
            this.lblTextAuraIniValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTextAuraIniValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraIniValues.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTextAuraIniValues.Location = new System.Drawing.Point(123, 164);
            this.lblTextAuraIniValues.Name = "lblTextAuraIniValues";
            this.lblTextAuraIniValues.Size = new System.Drawing.Size(156, 20);
            this.lblTextAuraIniValues.TabIndex = 19;
            this.lblTextAuraIniValues.Text = "Initial values";
            this.lblTextAuraIniValues.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTextAuraUpdValues
            // 
            this.lblTextAuraUpdValues.BackColor = System.Drawing.SystemColors.Info;
            this.lblTextAuraUpdValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel13.SetColumnSpan(this.lblTextAuraUpdValues, 2);
            this.lblTextAuraUpdValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraUpdValues.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTextAuraUpdValues.Location = new System.Drawing.Point(285, 164);
            this.lblTextAuraUpdValues.Name = "lblTextAuraUpdValues";
            this.lblTextAuraUpdValues.Size = new System.Drawing.Size(454, 20);
            this.lblTextAuraUpdValues.TabIndex = 20;
            this.lblTextAuraUpdValues.Text = "Update tick (20 ms) expressions";
            this.lblTextAuraUpdValues.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTextAuraX
            // 
            this.lblTextAuraX.AutoSize = true;
            this.lblTextAuraX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraX.Location = new System.Drawing.Point(3, 184);
            this.lblTextAuraX.Name = "lblTextAuraX";
            this.lblTextAuraX.Size = new System.Drawing.Size(114, 26);
            this.lblTextAuraX.TabIndex = 21;
            this.lblTextAuraX.Text = "X location expression";
            this.lblTextAuraX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTextAuraXIni
            // 
            this.expTextAuraXIni.AutocompleteAvailable = true;
            this.expTextAuraXIni.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTextAuraXIni.AutoSize = true;
            this.expTextAuraXIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraXIni.Expression = "";
            this.expTextAuraXIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraXIni.IsPersistent = false;
            this.expTextAuraXIni.Location = new System.Drawing.Point(123, 187);
            this.expTextAuraXIni.Name = "expTextAuraXIni";
            this.expTextAuraXIni.ReadOnly = false;
            this.expTextAuraXIni.Size = new System.Drawing.Size(156, 20);
            this.expTextAuraXIni.TabIndex = 14;
            // 
            // expTextAuraXTick
            // 
            this.expTextAuraXTick.AutocompleteAvailable = true;
            this.expTextAuraXTick.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTextAuraXTick.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.expTextAuraXTick, 2);
            this.expTextAuraXTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraXTick.Expression = "";
            this.expTextAuraXTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraXTick.IsPersistent = false;
            this.expTextAuraXTick.Location = new System.Drawing.Point(285, 187);
            this.expTextAuraXTick.Name = "expTextAuraXTick";
            this.expTextAuraXTick.ReadOnly = false;
            this.expTextAuraXTick.Size = new System.Drawing.Size(454, 20);
            this.expTextAuraXTick.TabIndex = 19;
            this.expTextAuraXTick.EnabledChanged += new System.EventHandler(this.expTextAuraXTick_EnabledChanged);
            // 
            // lblTextAuraY
            // 
            this.lblTextAuraY.AutoSize = true;
            this.lblTextAuraY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraY.Location = new System.Drawing.Point(3, 210);
            this.lblTextAuraY.Name = "lblTextAuraY";
            this.lblTextAuraY.Size = new System.Drawing.Size(114, 26);
            this.lblTextAuraY.TabIndex = 22;
            this.lblTextAuraY.Text = "Y location expression";
            this.lblTextAuraY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTextAuraYIni
            // 
            this.expTextAuraYIni.AutocompleteAvailable = true;
            this.expTextAuraYIni.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTextAuraYIni.AutoSize = true;
            this.expTextAuraYIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraYIni.Expression = "";
            this.expTextAuraYIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraYIni.IsPersistent = false;
            this.expTextAuraYIni.Location = new System.Drawing.Point(123, 213);
            this.expTextAuraYIni.Name = "expTextAuraYIni";
            this.expTextAuraYIni.ReadOnly = false;
            this.expTextAuraYIni.Size = new System.Drawing.Size(156, 20);
            this.expTextAuraYIni.TabIndex = 15;
            // 
            // expTextAuraYTick
            // 
            this.expTextAuraYTick.AutocompleteAvailable = true;
            this.expTextAuraYTick.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTextAuraYTick.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.expTextAuraYTick, 2);
            this.expTextAuraYTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraYTick.Expression = "";
            this.expTextAuraYTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraYTick.IsPersistent = false;
            this.expTextAuraYTick.Location = new System.Drawing.Point(285, 213);
            this.expTextAuraYTick.Name = "expTextAuraYTick";
            this.expTextAuraYTick.ReadOnly = false;
            this.expTextAuraYTick.Size = new System.Drawing.Size(454, 20);
            this.expTextAuraYTick.TabIndex = 20;
            this.expTextAuraYTick.EnabledChanged += new System.EventHandler(this.expTextAuraYTick_EnabledChanged);
            // 
            // lblTextAuraWidth
            // 
            this.lblTextAuraWidth.AutoSize = true;
            this.lblTextAuraWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraWidth.Location = new System.Drawing.Point(3, 236);
            this.lblTextAuraWidth.Name = "lblTextAuraWidth";
            this.lblTextAuraWidth.Size = new System.Drawing.Size(114, 26);
            this.lblTextAuraWidth.TabIndex = 23;
            this.lblTextAuraWidth.Text = "Width expression";
            this.lblTextAuraWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTextAuraWIni
            // 
            this.expTextAuraWIni.AutocompleteAvailable = true;
            this.expTextAuraWIni.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTextAuraWIni.AutoSize = true;
            this.expTextAuraWIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraWIni.Expression = "";
            this.expTextAuraWIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraWIni.IsPersistent = false;
            this.expTextAuraWIni.Location = new System.Drawing.Point(123, 239);
            this.expTextAuraWIni.Name = "expTextAuraWIni";
            this.expTextAuraWIni.ReadOnly = false;
            this.expTextAuraWIni.Size = new System.Drawing.Size(156, 20);
            this.expTextAuraWIni.TabIndex = 16;
            // 
            // expTextAuraWTick
            // 
            this.expTextAuraWTick.AutocompleteAvailable = true;
            this.expTextAuraWTick.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTextAuraWTick.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.expTextAuraWTick, 2);
            this.expTextAuraWTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraWTick.Expression = "";
            this.expTextAuraWTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraWTick.IsPersistent = false;
            this.expTextAuraWTick.Location = new System.Drawing.Point(285, 239);
            this.expTextAuraWTick.Name = "expTextAuraWTick";
            this.expTextAuraWTick.ReadOnly = false;
            this.expTextAuraWTick.Size = new System.Drawing.Size(454, 20);
            this.expTextAuraWTick.TabIndex = 21;
            this.expTextAuraWTick.EnabledChanged += new System.EventHandler(this.expTextAuraWTick_EnabledChanged);
            // 
            // lblTextAuraHeight
            // 
            this.lblTextAuraHeight.AutoSize = true;
            this.lblTextAuraHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraHeight.Location = new System.Drawing.Point(3, 262);
            this.lblTextAuraHeight.Name = "lblTextAuraHeight";
            this.lblTextAuraHeight.Size = new System.Drawing.Size(114, 26);
            this.lblTextAuraHeight.TabIndex = 24;
            this.lblTextAuraHeight.Text = "Height expression";
            this.lblTextAuraHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTextAuraHIni
            // 
            this.expTextAuraHIni.AutocompleteAvailable = true;
            this.expTextAuraHIni.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTextAuraHIni.AutoSize = true;
            this.expTextAuraHIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraHIni.Expression = "";
            this.expTextAuraHIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraHIni.IsPersistent = false;
            this.expTextAuraHIni.Location = new System.Drawing.Point(123, 265);
            this.expTextAuraHIni.Name = "expTextAuraHIni";
            this.expTextAuraHIni.ReadOnly = false;
            this.expTextAuraHIni.Size = new System.Drawing.Size(156, 20);
            this.expTextAuraHIni.TabIndex = 17;
            // 
            // expTextAuraHTick
            // 
            this.expTextAuraHTick.AutocompleteAvailable = true;
            this.expTextAuraHTick.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTextAuraHTick.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.expTextAuraHTick, 2);
            this.expTextAuraHTick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expTextAuraHTick.Expression = "";
            this.expTextAuraHTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraHTick.IsPersistent = false;
            this.expTextAuraHTick.Location = new System.Drawing.Point(285, 265);
            this.expTextAuraHTick.Name = "expTextAuraHTick";
            this.expTextAuraHTick.ReadOnly = false;
            this.expTextAuraHTick.Size = new System.Drawing.Size(454, 20);
            this.expTextAuraHTick.TabIndex = 22;
            this.expTextAuraHTick.EnabledChanged += new System.EventHandler(this.expTextAuraHTick_EnabledChanged);
            // 
            // lblTextAuraOpacity
            // 
            this.lblTextAuraOpacity.AutoSize = true;
            this.lblTextAuraOpacity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraOpacity.Location = new System.Drawing.Point(3, 288);
            this.lblTextAuraOpacity.Name = "lblTextAuraOpacity";
            this.lblTextAuraOpacity.Size = new System.Drawing.Size(114, 26);
            this.lblTextAuraOpacity.TabIndex = 25;
            this.lblTextAuraOpacity.Text = "Opacity expression";
            this.lblTextAuraOpacity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTextAuraOIni
            // 
            this.expTextAuraOIni.AutocompleteAvailable = true;
            this.expTextAuraOIni.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTextAuraOIni.AutoSize = true;
            this.expTextAuraOIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTextAuraOIni.Expression = "";
            this.expTextAuraOIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraOIni.IsPersistent = false;
            this.expTextAuraOIni.Location = new System.Drawing.Point(123, 291);
            this.expTextAuraOIni.Name = "expTextAuraOIni";
            this.expTextAuraOIni.ReadOnly = false;
            this.expTextAuraOIni.Size = new System.Drawing.Size(156, 20);
            this.expTextAuraOIni.TabIndex = 18;
            // 
            // expTextAuraOTick
            // 
            this.expTextAuraOTick.AutocompleteAvailable = true;
            this.expTextAuraOTick.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTextAuraOTick.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.expTextAuraOTick, 2);
            this.expTextAuraOTick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expTextAuraOTick.Expression = "";
            this.expTextAuraOTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraOTick.IsPersistent = false;
            this.expTextAuraOTick.Location = new System.Drawing.Point(285, 291);
            this.expTextAuraOTick.Name = "expTextAuraOTick";
            this.expTextAuraOTick.ReadOnly = false;
            this.expTextAuraOTick.Size = new System.Drawing.Size(454, 20);
            this.expTextAuraOTick.TabIndex = 23;
            this.expTextAuraOTick.EnabledChanged += new System.EventHandler(this.expTextAuraOTick_EnabledChanged);
            // 
            // lblTextAuraTtlExp
            // 
            this.lblTextAuraTtlExp.AutoSize = true;
            this.lblTextAuraTtlExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTextAuraTtlExp.Location = new System.Drawing.Point(3, 314);
            this.lblTextAuraTtlExp.Name = "lblTextAuraTtlExp";
            this.lblTextAuraTtlExp.Size = new System.Drawing.Size(114, 26);
            this.lblTextAuraTtlExp.TabIndex = 26;
            this.lblTextAuraTtlExp.Text = "Time-to-live expression";
            this.lblTextAuraTtlExp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTextAuraTTLTick
            // 
            this.expTextAuraTTLTick.AutocompleteAvailable = true;
            this.expTextAuraTTLTick.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTextAuraTTLTick.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.expTextAuraTTLTick, 2);
            this.expTextAuraTTLTick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expTextAuraTTLTick.Expression = "";
            this.expTextAuraTTLTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expTextAuraTTLTick.IsPersistent = false;
            this.expTextAuraTTLTick.Location = new System.Drawing.Point(285, 317);
            this.expTextAuraTTLTick.Name = "expTextAuraTTLTick";
            this.expTextAuraTTLTick.ReadOnly = false;
            this.expTextAuraTTLTick.Size = new System.Drawing.Size(454, 20);
            this.expTextAuraTTLTick.TabIndex = 24;
            this.expTextAuraTTLTick.EnabledChanged += new System.EventHandler(this.expTextAuraTTLTick_EnabledChanged);
            // 
            // btnTextAuraGuide
            // 
            this.tableLayoutPanel13.SetColumnSpan(this.btnTextAuraGuide, 3);
            this.btnTextAuraGuide.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTextAuraGuide.Enabled = false;
            this.btnTextAuraGuide.Location = new System.Drawing.Point(123, 343);
            this.btnTextAuraGuide.Name = "btnTextAuraGuide";
            this.btnTextAuraGuide.Size = new System.Drawing.Size(616, 23);
            this.btnTextAuraGuide.TabIndex = 27;
            this.btnTextAuraGuide.TabStop = false;
            this.btnTextAuraGuide.Text = "Use visual guide for placement (right-click for more options)";
            this.btnTextAuraGuide.UseVisualStyleBackColor = true;
            this.btnTextAuraGuide.Click += new System.EventHandler(this.button8_Click);
            // 
            // tabImageAura
            // 
            this.tabImageAura.AutoScroll = true;
            this.tabImageAura.Controls.Add(this.tableLayoutPanel11);
            this.tabImageAura.Location = new System.Drawing.Point(4, 25);
            this.tabImageAura.Name = "tabImageAura";
            this.tabImageAura.Size = new System.Drawing.Size(742, 414);
            this.tabImageAura.TabIndex = 10;
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
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
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
            this.tableLayoutPanel11.Size = new System.Drawing.Size(742, 311);
            this.tableLayoutPanel11.TabIndex = 0;
            // 
            // btnHide
            // 
            this.btnHide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHide.Location = new System.Drawing.Point(650, 27);
            this.btnHide.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(89, 26);
            this.btnHide.TabIndex = 0;
            this.btnHide.TabStop = false;
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
            this.cbxAuraDisplay.Size = new System.Drawing.Size(616, 21);
            this.cbxAuraDisplay.TabIndex = 1;
            this.cbxAuraDisplay.TabStop = false;
            this.cbxAuraDisplay.EnabledChanged += new System.EventHandler(this.cbxAuraDisplay_EnabledChanged);
            // 
            // lblAuraDisplay
            // 
            this.lblAuraDisplay.AutoSize = true;
            this.lblAuraDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuraDisplay.Location = new System.Drawing.Point(3, 79);
            this.lblAuraDisplay.Name = "lblAuraDisplay";
            this.lblAuraDisplay.Size = new System.Drawing.Size(114, 27);
            this.lblAuraDisplay.TabIndex = 2;
            this.lblAuraDisplay.Text = "Display method";
            this.lblAuraDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expAuraTTLTick
            // 
            this.expAuraTTLTick.AutocompleteAvailable = true;
            this.expAuraTTLTick.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expAuraTTLTick.AutoSize = true;
            this.tableLayoutPanel11.SetColumnSpan(this.expAuraTTLTick, 2);
            this.expAuraTTLTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraTTLTick.Expression = "";
            this.expAuraTTLTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraTTLTick.IsPersistent = false;
            this.expAuraTTLTick.Location = new System.Drawing.Point(282, 259);
            this.expAuraTTLTick.Name = "expAuraTTLTick";
            this.expAuraTTLTick.ReadOnly = false;
            this.expAuraTTLTick.Size = new System.Drawing.Size(457, 20);
            this.expAuraTTLTick.TabIndex = 24;
            this.expAuraTTLTick.EnabledChanged += new System.EventHandler(this.expAuraTTLTick_EnabledChanged);
            // 
            // expAuraOTick
            // 
            this.expAuraOTick.AutocompleteAvailable = true;
            this.expAuraOTick.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expAuraOTick.AutoSize = true;
            this.tableLayoutPanel11.SetColumnSpan(this.expAuraOTick, 2);
            this.expAuraOTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraOTick.Expression = "";
            this.expAuraOTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraOTick.IsPersistent = false;
            this.expAuraOTick.Location = new System.Drawing.Point(282, 233);
            this.expAuraOTick.Name = "expAuraOTick";
            this.expAuraOTick.ReadOnly = false;
            this.expAuraOTick.Size = new System.Drawing.Size(457, 20);
            this.expAuraOTick.TabIndex = 23;
            this.expAuraOTick.EnabledChanged += new System.EventHandler(this.expAuraOTick_EnabledChanged);
            // 
            // expAuraHTick
            // 
            this.expAuraHTick.AutocompleteAvailable = true;
            this.expAuraHTick.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expAuraHTick.AutoSize = true;
            this.tableLayoutPanel11.SetColumnSpan(this.expAuraHTick, 2);
            this.expAuraHTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraHTick.Expression = "";
            this.expAuraHTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraHTick.IsPersistent = false;
            this.expAuraHTick.Location = new System.Drawing.Point(282, 207);
            this.expAuraHTick.Name = "expAuraHTick";
            this.expAuraHTick.ReadOnly = false;
            this.expAuraHTick.Size = new System.Drawing.Size(457, 20);
            this.expAuraHTick.TabIndex = 22;
            this.expAuraHTick.EnabledChanged += new System.EventHandler(this.expAuraHTick_EnabledChanged);
            // 
            // expAuraWTick
            // 
            this.expAuraWTick.AutocompleteAvailable = true;
            this.expAuraWTick.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expAuraWTick.AutoSize = true;
            this.tableLayoutPanel11.SetColumnSpan(this.expAuraWTick, 2);
            this.expAuraWTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraWTick.Expression = "";
            this.expAuraWTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraWTick.IsPersistent = false;
            this.expAuraWTick.Location = new System.Drawing.Point(282, 181);
            this.expAuraWTick.Name = "expAuraWTick";
            this.expAuraWTick.ReadOnly = false;
            this.expAuraWTick.Size = new System.Drawing.Size(457, 20);
            this.expAuraWTick.TabIndex = 21;
            this.expAuraWTick.EnabledChanged += new System.EventHandler(this.expAuraWTick_EnabledChanged);
            // 
            // expAuraYTick
            // 
            this.expAuraYTick.AutocompleteAvailable = true;
            this.expAuraYTick.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expAuraYTick.AutoSize = true;
            this.tableLayoutPanel11.SetColumnSpan(this.expAuraYTick, 2);
            this.expAuraYTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraYTick.Expression = "";
            this.expAuraYTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraYTick.IsPersistent = false;
            this.expAuraYTick.Location = new System.Drawing.Point(282, 155);
            this.expAuraYTick.Name = "expAuraYTick";
            this.expAuraYTick.ReadOnly = false;
            this.expAuraYTick.Size = new System.Drawing.Size(457, 20);
            this.expAuraYTick.TabIndex = 20;
            this.expAuraYTick.EnabledChanged += new System.EventHandler(this.expAuraYTick_EnabledChanged);
            // 
            // expAuraXTick
            // 
            this.expAuraXTick.AutocompleteAvailable = true;
            this.expAuraXTick.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expAuraXTick.AutoSize = true;
            this.tableLayoutPanel11.SetColumnSpan(this.expAuraXTick, 2);
            this.expAuraXTick.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraXTick.Expression = "";
            this.expAuraXTick.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraXTick.IsPersistent = false;
            this.expAuraXTick.Location = new System.Drawing.Point(282, 129);
            this.expAuraXTick.Name = "expAuraXTick";
            this.expAuraXTick.ReadOnly = false;
            this.expAuraXTick.Size = new System.Drawing.Size(457, 20);
            this.expAuraXTick.TabIndex = 19;
            this.expAuraXTick.EnabledChanged += new System.EventHandler(this.expAuraXTick_EnabledChanged);
            // 
            // lblUpdateTickExp
            // 
            this.lblUpdateTickExp.BackColor = System.Drawing.SystemColors.Info;
            this.lblUpdateTickExp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel11.SetColumnSpan(this.lblUpdateTickExp, 2);
            this.lblUpdateTickExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpdateTickExp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUpdateTickExp.Location = new System.Drawing.Point(282, 106);
            this.lblUpdateTickExp.Name = "lblUpdateTickExp";
            this.lblUpdateTickExp.Size = new System.Drawing.Size(457, 20);
            this.lblUpdateTickExp.TabIndex = 25;
            this.lblUpdateTickExp.Text = "Update tick (20 ms) expressions";
            this.lblUpdateTickExp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // expAuraOIni
            // 
            this.expAuraOIni.AutocompleteAvailable = true;
            this.expAuraOIni.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expAuraOIni.AutoSize = true;
            this.expAuraOIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraOIni.Expression = "";
            this.expAuraOIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraOIni.IsPersistent = false;
            this.expAuraOIni.Location = new System.Drawing.Point(123, 233);
            this.expAuraOIni.Name = "expAuraOIni";
            this.expAuraOIni.ReadOnly = false;
            this.expAuraOIni.Size = new System.Drawing.Size(153, 20);
            this.expAuraOIni.TabIndex = 18;
            // 
            // expAuraHIni
            // 
            this.expAuraHIni.AutocompleteAvailable = true;
            this.expAuraHIni.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expAuraHIni.AutoSize = true;
            this.expAuraHIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraHIni.Expression = "";
            this.expAuraHIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraHIni.IsPersistent = false;
            this.expAuraHIni.Location = new System.Drawing.Point(123, 207);
            this.expAuraHIni.Name = "expAuraHIni";
            this.expAuraHIni.ReadOnly = false;
            this.expAuraHIni.Size = new System.Drawing.Size(153, 20);
            this.expAuraHIni.TabIndex = 17;
            // 
            // expAuraWIni
            // 
            this.expAuraWIni.AutocompleteAvailable = true;
            this.expAuraWIni.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expAuraWIni.AutoSize = true;
            this.expAuraWIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraWIni.Expression = "";
            this.expAuraWIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraWIni.IsPersistent = false;
            this.expAuraWIni.Location = new System.Drawing.Point(123, 181);
            this.expAuraWIni.Name = "expAuraWIni";
            this.expAuraWIni.ReadOnly = false;
            this.expAuraWIni.Size = new System.Drawing.Size(153, 20);
            this.expAuraWIni.TabIndex = 16;
            // 
            // lblAuraTtl
            // 
            this.lblAuraTtl.AutoSize = true;
            this.lblAuraTtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuraTtl.Location = new System.Drawing.Point(3, 256);
            this.lblAuraTtl.Name = "lblAuraTtl";
            this.lblAuraTtl.Size = new System.Drawing.Size(114, 26);
            this.lblAuraTtl.TabIndex = 26;
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
            this.lblAuraOpacity.TabIndex = 27;
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
            this.lblAuraWidth.TabIndex = 28;
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
            this.lblAuraHeight.TabIndex = 29;
            this.lblAuraHeight.Text = "Height expression";
            this.lblAuraHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowseAura
            // 
            this.btnBrowseAura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrowseAura.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseAura.Image")));
            this.btnBrowseAura.Location = new System.Drawing.Point(650, 53);
            this.btnBrowseAura.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnBrowseAura.Name = "btnBrowseAura";
            this.btnBrowseAura.Size = new System.Drawing.Size(89, 26);
            this.btnBrowseAura.TabIndex = 30;
            this.btnBrowseAura.TabStop = false;
            this.btnBrowseAura.UseVisualStyleBackColor = true;
            this.btnBrowseAura.Click += new System.EventHandler(this.button2_Click);
            // 
            // expAuraImage
            // 
            this.expAuraImage.AutocompleteAvailable = true;
            this.expAuraImage.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expAuraImage.AutoSize = true;
            this.tableLayoutPanel11.SetColumnSpan(this.expAuraImage, 2);
            this.expAuraImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraImage.Expression = "";
            this.expAuraImage.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expAuraImage.IsPersistent = false;
            this.expAuraImage.Location = new System.Drawing.Point(123, 56);
            this.expAuraImage.Name = "expAuraImage";
            this.expAuraImage.ReadOnly = false;
            this.expAuraImage.Size = new System.Drawing.Size(524, 20);
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
            this.lblAuraImage.TabIndex = 31;
            this.lblAuraImage.Text = "Image to display";
            this.lblAuraImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expAuraYIni
            // 
            this.expAuraYIni.AutocompleteAvailable = true;
            this.expAuraYIni.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expAuraYIni.AutoSize = true;
            this.expAuraYIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraYIni.Expression = "";
            this.expAuraYIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraYIni.IsPersistent = false;
            this.expAuraYIni.Location = new System.Drawing.Point(123, 155);
            this.expAuraYIni.Name = "expAuraYIni";
            this.expAuraYIni.ReadOnly = false;
            this.expAuraYIni.Size = new System.Drawing.Size(153, 20);
            this.expAuraYIni.TabIndex = 15;
            // 
            // lblAuraY
            // 
            this.lblAuraY.AutoSize = true;
            this.lblAuraY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuraY.Location = new System.Drawing.Point(3, 152);
            this.lblAuraY.Name = "lblAuraY";
            this.lblAuraY.Size = new System.Drawing.Size(114, 26);
            this.lblAuraY.TabIndex = 32;
            this.lblAuraY.Text = "Y location expression";
            this.lblAuraY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expAuraXIni
            // 
            this.expAuraXIni.AutocompleteAvailable = true;
            this.expAuraXIni.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expAuraXIni.AutoSize = true;
            this.expAuraXIni.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraXIni.Expression = "";
            this.expAuraXIni.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expAuraXIni.IsPersistent = false;
            this.expAuraXIni.Location = new System.Drawing.Point(123, 129);
            this.expAuraXIni.Name = "expAuraXIni";
            this.expAuraXIni.ReadOnly = false;
            this.expAuraXIni.Size = new System.Drawing.Size(153, 20);
            this.expAuraXIni.TabIndex = 14;
            // 
            // lblAuraX
            // 
            this.lblAuraX.AutoSize = true;
            this.lblAuraX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAuraX.Location = new System.Drawing.Point(3, 126);
            this.lblAuraX.Name = "lblAuraX";
            this.lblAuraX.Size = new System.Drawing.Size(114, 26);
            this.lblAuraX.TabIndex = 33;
            this.lblAuraX.Text = "X location expression";
            this.lblAuraX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expAuraName
            // 
            this.expAuraName.AutocompleteAvailable = true;
            this.expAuraName.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expAuraName.AutoSize = true;
            this.tableLayoutPanel11.SetColumnSpan(this.expAuraName, 2);
            this.expAuraName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expAuraName.Expression = "";
            this.expAuraName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expAuraName.IsPersistent = false;
            this.expAuraName.Location = new System.Drawing.Point(123, 30);
            this.expAuraName.Name = "expAuraName";
            this.expAuraName.ReadOnly = false;
            this.expAuraName.Size = new System.Drawing.Size(524, 20);
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
            this.lblAuraName.TabIndex = 34;
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
            this.lblAuraOp.TabIndex = 35;
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
            "Deactivate all image auras",
            "Deactivate image auras by regular expression"});
            this.cbxAuraOp.Location = new System.Drawing.Point(123, 3);
            this.cbxAuraOp.Name = "cbxAuraOp";
            this.cbxAuraOp.Size = new System.Drawing.Size(616, 21);
            this.cbxAuraOp.TabIndex = 36;
            this.cbxAuraOp.TabStop = false;
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
            this.lblInitialValues.Size = new System.Drawing.Size(153, 20);
            this.lblInitialValues.TabIndex = 37;
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
            this.btnAuraGuide.Size = new System.Drawing.Size(616, 23);
            this.btnAuraGuide.TabIndex = 38;
            this.btnAuraGuide.TabStop = false;
            this.btnAuraGuide.Text = "Use visual guide for placement (right-click for more options)";
            this.btnAuraGuide.UseVisualStyleBackColor = true;
            this.btnAuraGuide.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabMouse
            // 
            this.tabMouse.Controls.Add(this.tableLayoutPanel25);
            this.tabMouse.Location = new System.Drawing.Point(4, 25);
            this.tabMouse.Name = "tabMouse";
            this.tabMouse.Size = new System.Drawing.Size(742, 414);
            this.tabMouse.TabIndex = 11;
            this.tabMouse.Text = "Mouse";
            this.tabMouse.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel25
            // 
            this.tableLayoutPanel25.AutoSize = true;
            this.tableLayoutPanel25.ColumnCount = 2;
            this.tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel25.Controls.Add(this.cbxMouseCoord, 1, 1);
            this.tableLayoutPanel25.Controls.Add(this.expMouseY, 1, 3);
            this.tableLayoutPanel25.Controls.Add(this.lblMouseY, 0, 3);
            this.tableLayoutPanel25.Controls.Add(this.lblMouseX, 0, 2);
            this.tableLayoutPanel25.Controls.Add(this.expMouseX, 1, 2);
            this.tableLayoutPanel25.Controls.Add(this.lblMouseCoord, 0, 1);
            this.tableLayoutPanel25.Controls.Add(this.lblMouseOp, 0, 0);
            this.tableLayoutPanel25.Controls.Add(this.cbxMouseOp, 1, 0);
            this.tableLayoutPanel25.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel25.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel25.Name = "tableLayoutPanel25";
            this.tableLayoutPanel25.RowCount = 4;
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel25.Size = new System.Drawing.Size(742, 106);
            this.tableLayoutPanel25.TabIndex = 0;
            // 
            // cbxMouseCoord
            // 
            this.cbxMouseCoord.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxMouseCoord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMouseCoord.FormattingEnabled = true;
            this.cbxMouseCoord.Items.AddRange(new object[] {
            "Absolute",
            "Relative"});
            this.cbxMouseCoord.Location = new System.Drawing.Point(102, 30);
            this.cbxMouseCoord.Name = "cbxMouseCoord";
            this.cbxMouseCoord.Size = new System.Drawing.Size(637, 21);
            this.cbxMouseCoord.TabIndex = 0;
            this.cbxMouseCoord.TabStop = false;
            // 
            // expMouseY
            // 
            this.expMouseY.AutocompleteAvailable = true;
            this.expMouseY.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expMouseY.AutoSize = true;
            this.expMouseY.Dock = System.Windows.Forms.DockStyle.Top;
            this.expMouseY.Expression = "";
            this.expMouseY.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expMouseY.IsPersistent = false;
            this.expMouseY.Location = new System.Drawing.Point(102, 83);
            this.expMouseY.Name = "expMouseY";
            this.expMouseY.ReadOnly = false;
            this.expMouseY.Size = new System.Drawing.Size(637, 20);
            this.expMouseY.TabIndex = 24;
            // 
            // lblMouseY
            // 
            this.lblMouseY.AutoSize = true;
            this.lblMouseY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMouseY.Location = new System.Drawing.Point(3, 80);
            this.lblMouseY.Name = "lblMouseY";
            this.lblMouseY.Size = new System.Drawing.Size(93, 26);
            this.lblMouseY.TabIndex = 25;
            this.lblMouseY.Text = "Y coordinate";
            this.lblMouseY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMouseX
            // 
            this.lblMouseX.AutoSize = true;
            this.lblMouseX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMouseX.Location = new System.Drawing.Point(3, 54);
            this.lblMouseX.Name = "lblMouseX";
            this.lblMouseX.Size = new System.Drawing.Size(93, 26);
            this.lblMouseX.TabIndex = 26;
            this.lblMouseX.Text = "X coordinate";
            this.lblMouseX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expMouseX
            // 
            this.expMouseX.AutocompleteAvailable = true;
            this.expMouseX.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expMouseX.AutoSize = true;
            this.expMouseX.Dock = System.Windows.Forms.DockStyle.Top;
            this.expMouseX.Expression = "";
            this.expMouseX.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expMouseX.IsPersistent = false;
            this.expMouseX.Location = new System.Drawing.Point(102, 57);
            this.expMouseX.Name = "expMouseX";
            this.expMouseX.ReadOnly = false;
            this.expMouseX.Size = new System.Drawing.Size(637, 20);
            this.expMouseX.TabIndex = 16;
            // 
            // lblMouseCoord
            // 
            this.lblMouseCoord.AutoSize = true;
            this.lblMouseCoord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMouseCoord.Location = new System.Drawing.Point(3, 27);
            this.lblMouseCoord.Name = "lblMouseCoord";
            this.lblMouseCoord.Size = new System.Drawing.Size(93, 27);
            this.lblMouseCoord.TabIndex = 27;
            this.lblMouseCoord.Text = "Coordinate system";
            this.lblMouseCoord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMouseOp
            // 
            this.lblMouseOp.AutoSize = true;
            this.lblMouseOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMouseOp.Location = new System.Drawing.Point(3, 0);
            this.lblMouseOp.Name = "lblMouseOp";
            this.lblMouseOp.Size = new System.Drawing.Size(93, 27);
            this.lblMouseOp.TabIndex = 28;
            this.lblMouseOp.Text = "Operation";
            this.lblMouseOp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxMouseOp
            // 
            this.cbxMouseOp.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxMouseOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMouseOp.FormattingEnabled = true;
            this.cbxMouseOp.Items.AddRange(new object[] {
            "Move mouse",
            "Left click",
            "Middle click",
            "Right click"});
            this.cbxMouseOp.Location = new System.Drawing.Point(102, 3);
            this.cbxMouseOp.Name = "cbxMouseOp";
            this.cbxMouseOp.Size = new System.Drawing.Size(637, 21);
            this.cbxMouseOp.TabIndex = 29;
            this.cbxMouseOp.TabStop = false;
            // 
            // tabKeypress
            // 
            this.tabKeypress.AutoScroll = true;
            this.tabKeypress.Controls.Add(this.tableLayoutPanel6);
            this.tabKeypress.Location = new System.Drawing.Point(4, 25);
            this.tabKeypress.Name = "tabKeypress";
            this.tabKeypress.Size = new System.Drawing.Size(742, 414);
            this.tabKeypress.TabIndex = 12;
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
            this.tableLayoutPanel6.Controls.Add(this.lblKeypressMethod, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.cbxKeypressMethod, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.lblKeypressProcId, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.expKeypressProcId, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.lblKeypresses, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.expKeypresses, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.btnSendKeysListen, 2, 2);
            this.tableLayoutPanel6.Controls.Add(this.lblKeypressWindow, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.expWindowTitle, 1, 3);
            this.tableLayoutPanel6.Controls.Add(this.lblKeypress, 0, 4);
            this.tableLayoutPanel6.Controls.Add(this.expKeypress, 1, 4);
            this.tableLayoutPanel6.Controls.Add(this.btnKeycodesListen, 2, 4);
            this.tableLayoutPanel6.Controls.Add(this.txtSendKeysLink, 1, 5);
            this.tableLayoutPanel6.Controls.Add(this.btnSendKeysLink, 2, 5);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 6;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(742, 157);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // lblKeypressMethod
            // 
            this.lblKeypressMethod.AutoSize = true;
            this.lblKeypressMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeypressMethod.Location = new System.Drawing.Point(3, 0);
            this.lblKeypressMethod.Name = "lblKeypressMethod";
            this.lblKeypressMethod.Size = new System.Drawing.Size(114, 27);
            this.lblKeypressMethod.TabIndex = 0;
            this.lblKeypressMethod.Text = "Keypress send method";
            this.lblKeypressMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxKeypressMethod
            // 
            this.tableLayoutPanel6.SetColumnSpan(this.cbxKeypressMethod, 2);
            this.cbxKeypressMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxKeypressMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKeypressMethod.FormattingEnabled = true;
            this.cbxKeypressMethod.Items.AddRange(new object[] {
            "SendKeys",
            "Window message",
            "Multiple window messages"});
            this.cbxKeypressMethod.Location = new System.Drawing.Point(123, 3);
            this.cbxKeypressMethod.Name = "cbxKeypressMethod";
            this.cbxKeypressMethod.Size = new System.Drawing.Size(616, 21);
            this.cbxKeypressMethod.TabIndex = 1;
            this.cbxKeypressMethod.TabStop = false;
            this.cbxKeypressMethod.SelectedIndexChanged += new System.EventHandler(this.cbxKeypressMethod_SelectedIndexChanged);
            // 
            // lblKeypressProcId
            // 
            this.lblKeypressProcId.AutoSize = true;
            this.lblKeypressProcId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeypressProcId.Location = new System.Drawing.Point(3, 27);
            this.lblKeypressProcId.Name = "lblKeypressProcId";
            this.lblKeypressProcId.Size = new System.Drawing.Size(114, 26);
            this.lblKeypressProcId.TabIndex = 2;
            this.lblKeypressProcId.Text = "Process ID";
            this.lblKeypressProcId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expKeypressProcId
            // 
            this.expKeypressProcId.AutocompleteAvailable = true;
            this.expKeypressProcId.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expKeypressProcId.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.expKeypressProcId, 2);
            this.expKeypressProcId.Dock = System.Windows.Forms.DockStyle.Top;
            this.expKeypressProcId.Expression = "";
            this.expKeypressProcId.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expKeypressProcId.IsPersistent = false;
            this.expKeypressProcId.Location = new System.Drawing.Point(123, 30);
            this.expKeypressProcId.Name = "expKeypressProcId";
            this.expKeypressProcId.ReadOnly = false;
            this.expKeypressProcId.Size = new System.Drawing.Size(616, 20);
            this.expKeypressProcId.TabIndex = 31;
            // 
            // lblKeypresses
            // 
            this.lblKeypresses.AutoSize = true;
            this.lblKeypresses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeypresses.Location = new System.Drawing.Point(3, 53);
            this.lblKeypresses.Name = "lblKeypresses";
            this.lblKeypresses.Size = new System.Drawing.Size(114, 26);
            this.lblKeypresses.TabIndex = 32;
            this.lblKeypresses.Text = "Keypresses to send";
            this.lblKeypresses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expKeypresses
            // 
            this.expKeypresses.AutocompleteAvailable = true;
            this.expKeypresses.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expKeypresses.AutoSize = true;
            this.expKeypresses.Dock = System.Windows.Forms.DockStyle.Top;
            this.expKeypresses.Expression = "";
            this.expKeypresses.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expKeypresses.IsPersistent = false;
            this.expKeypresses.Location = new System.Drawing.Point(123, 56);
            this.expKeypresses.Name = "expKeypresses";
            this.expKeypresses.ReadOnly = false;
            this.expKeypresses.Size = new System.Drawing.Size(576, 20);
            this.expKeypresses.TabIndex = 14;
            // 
            // btnSendKeysListen
            // 
            this.btnSendKeysListen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSendKeysListen.Image = ((System.Drawing.Image)(resources.GetObject("btnSendKeysListen.Image")));
            this.btnSendKeysListen.Location = new System.Drawing.Point(702, 53);
            this.btnSendKeysListen.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnSendKeysListen.Name = "btnSendKeysListen";
            this.btnSendKeysListen.Size = new System.Drawing.Size(37, 26);
            this.btnSendKeysListen.TabIndex = 33;
            this.btnSendKeysListen.TabStop = false;
            this.btnSendKeysListen.UseVisualStyleBackColor = true;
            this.btnSendKeysListen.Click += new System.EventHandler(this.btnSendKeysListen_Click);
            // 
            // lblKeypressWindow
            // 
            this.lblKeypressWindow.AutoSize = true;
            this.lblKeypressWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeypressWindow.Location = new System.Drawing.Point(3, 79);
            this.lblKeypressWindow.Name = "lblKeypressWindow";
            this.lblKeypressWindow.Size = new System.Drawing.Size(114, 26);
            this.lblKeypressWindow.TabIndex = 34;
            this.lblKeypressWindow.Text = "Window title";
            this.lblKeypressWindow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expWindowTitle
            // 
            this.expWindowTitle.AutocompleteAvailable = true;
            this.expWindowTitle.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expWindowTitle.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.expWindowTitle, 2);
            this.expWindowTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.expWindowTitle.Expression = "";
            this.expWindowTitle.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Regex;
            this.expWindowTitle.IsPersistent = false;
            this.expWindowTitle.Location = new System.Drawing.Point(123, 82);
            this.expWindowTitle.Name = "expWindowTitle";
            this.expWindowTitle.ReadOnly = false;
            this.expWindowTitle.Size = new System.Drawing.Size(616, 20);
            this.expWindowTitle.TabIndex = 25;
            // 
            // lblKeypress
            // 
            this.lblKeypress.AutoSize = true;
            this.lblKeypress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeypress.Location = new System.Drawing.Point(3, 105);
            this.lblKeypress.Name = "lblKeypress";
            this.lblKeypress.Size = new System.Drawing.Size(114, 26);
            this.lblKeypress.TabIndex = 35;
            this.lblKeypress.Text = "Keycode to send";
            this.lblKeypress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expKeypress
            // 
            this.expKeypress.AutocompleteAvailable = true;
            this.expKeypress.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expKeypress.AutoSize = true;
            this.expKeypress.Dock = System.Windows.Forms.DockStyle.Top;
            this.expKeypress.Expression = "";
            this.expKeypress.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expKeypress.IsPersistent = false;
            this.expKeypress.Location = new System.Drawing.Point(123, 108);
            this.expKeypress.Name = "expKeypress";
            this.expKeypress.ReadOnly = false;
            this.expKeypress.Size = new System.Drawing.Size(576, 20);
            this.expKeypress.TabIndex = 26;
            // 
            // btnKeycodesListen
            // 
            this.btnKeycodesListen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKeycodesListen.Image = ((System.Drawing.Image)(resources.GetObject("btnKeycodesListen.Image")));
            this.btnKeycodesListen.Location = new System.Drawing.Point(702, 105);
            this.btnKeycodesListen.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnKeycodesListen.Name = "btnKeycodesListen";
            this.btnKeycodesListen.Size = new System.Drawing.Size(37, 26);
            this.btnKeycodesListen.TabIndex = 36;
            this.btnKeycodesListen.TabStop = false;
            this.btnKeycodesListen.UseVisualStyleBackColor = true;
            this.btnKeycodesListen.Click += new System.EventHandler(this.btnKeycodesListen_Click);
            // 
            // txtSendKeysLink
            // 
            this.txtSendKeysLink.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSendKeysLink.Location = new System.Drawing.Point(123, 134);
            this.txtSendKeysLink.Name = "txtSendKeysLink";
            this.txtSendKeysLink.ReadOnly = true;
            this.txtSendKeysLink.Size = new System.Drawing.Size(576, 20);
            this.txtSendKeysLink.TabIndex = 37;
            this.txtSendKeysLink.TabStop = false;
            this.txtSendKeysLink.Text = "https://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.send.aspx";
            // 
            // btnSendKeysLink
            // 
            this.btnSendKeysLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSendKeysLink.Image = ((System.Drawing.Image)(resources.GetObject("btnSendKeysLink.Image")));
            this.btnSendKeysLink.Location = new System.Drawing.Point(702, 131);
            this.btnSendKeysLink.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnSendKeysLink.Name = "btnSendKeysLink";
            this.btnSendKeysLink.Size = new System.Drawing.Size(37, 26);
            this.btnSendKeysLink.TabIndex = 38;
            this.btnSendKeysLink.TabStop = false;
            this.btnSendKeysLink.UseVisualStyleBackColor = true;
            this.btnSendKeysLink.Click += new System.EventHandler(this.btnSendKeysLink_Click);
            // 
            // tabNamedCallback
            // 
            this.tabNamedCallback.Controls.Add(this.tableLayoutPanel24);
            this.tabNamedCallback.Location = new System.Drawing.Point(4, 25);
            this.tabNamedCallback.Name = "tabNamedCallback";
            this.tabNamedCallback.Size = new System.Drawing.Size(742, 414);
            this.tabNamedCallback.TabIndex = 13;
            this.tabNamedCallback.Text = "Callback";
            this.tabNamedCallback.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel24
            // 
            this.tableLayoutPanel24.AutoSize = true;
            this.tableLayoutPanel24.ColumnCount = 2;
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel24.Controls.Add(this.expCallbackParam, 1, 1);
            this.tableLayoutPanel24.Controls.Add(this.lblCallbackParam, 0, 1);
            this.tableLayoutPanel24.Controls.Add(this.lblCallbackName, 0, 0);
            this.tableLayoutPanel24.Controls.Add(this.expCallbackName, 1, 0);
            this.tableLayoutPanel24.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel24.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel24.Name = "tableLayoutPanel24";
            this.tableLayoutPanel24.RowCount = 2;
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel24.Size = new System.Drawing.Size(742, 52);
            this.tableLayoutPanel24.TabIndex = 0;
            // 
            // expCallbackParam
            // 
            this.expCallbackParam.AutocompleteAvailable = true;
            this.expCallbackParam.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expCallbackParam.AutoSize = true;
            this.expCallbackParam.Dock = System.Windows.Forms.DockStyle.Top;
            this.expCallbackParam.Expression = "";
            this.expCallbackParam.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expCallbackParam.IsPersistent = false;
            this.expCallbackParam.Location = new System.Drawing.Point(107, 29);
            this.expCallbackParam.Name = "expCallbackParam";
            this.expCallbackParam.ReadOnly = false;
            this.expCallbackParam.Size = new System.Drawing.Size(632, 20);
            this.expCallbackParam.TabIndex = 16;
            // 
            // lblCallbackParam
            // 
            this.lblCallbackParam.AutoSize = true;
            this.lblCallbackParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCallbackParam.Location = new System.Drawing.Point(3, 26);
            this.lblCallbackParam.Name = "lblCallbackParam";
            this.lblCallbackParam.Size = new System.Drawing.Size(98, 26);
            this.lblCallbackParam.TabIndex = 17;
            this.lblCallbackParam.Text = "Callback parameter";
            this.lblCallbackParam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCallbackName
            // 
            this.lblCallbackName.AutoSize = true;
            this.lblCallbackName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCallbackName.Location = new System.Drawing.Point(3, 0);
            this.lblCallbackName.Name = "lblCallbackName";
            this.lblCallbackName.Size = new System.Drawing.Size(98, 26);
            this.lblCallbackName.TabIndex = 18;
            this.lblCallbackName.Text = "Callback name";
            this.lblCallbackName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expCallbackName
            // 
            this.expCallbackName.AutocompleteAvailable = true;
            this.expCallbackName.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expCallbackName.AutoSize = true;
            this.expCallbackName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expCallbackName.Expression = "";
            this.expCallbackName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expCallbackName.IsPersistent = false;
            this.expCallbackName.Location = new System.Drawing.Point(107, 3);
            this.expCallbackName.Name = "expCallbackName";
            this.expCallbackName.ReadOnly = false;
            this.expCallbackName.Size = new System.Drawing.Size(632, 20);
            this.expCallbackName.TabIndex = 14;
            // 
            // tabWindowMessage
            // 
            this.tabWindowMessage.Controls.Add(this.tableLayoutPanel19);
            this.tabWindowMessage.Controls.Add(this.panel7);
            this.tabWindowMessage.Location = new System.Drawing.Point(4, 25);
            this.tabWindowMessage.Name = "tabWindowMessage";
            this.tabWindowMessage.Size = new System.Drawing.Size(742, 414);
            this.tabWindowMessage.TabIndex = 14;
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
            this.tableLayoutPanel19.Controls.Add(this.expWmsgProcid, 1, 0);
            this.tableLayoutPanel19.Controls.Add(this.lblWmsgProcid, 0, 0);
            this.tableLayoutPanel19.Controls.Add(this.expWmsgLparam, 1, 4);
            this.tableLayoutPanel19.Controls.Add(this.lblWmsgLparam, 0, 4);
            this.tableLayoutPanel19.Controls.Add(this.expWmsgWparam, 1, 3);
            this.tableLayoutPanel19.Controls.Add(this.lblWmsgWparam, 0, 3);
            this.tableLayoutPanel19.Controls.Add(this.expWmsgCode, 1, 2);
            this.tableLayoutPanel19.Controls.Add(this.expWmsgTitle, 1, 1);
            this.tableLayoutPanel19.Controls.Add(this.lblWmsgCode, 0, 2);
            this.tableLayoutPanel19.Controls.Add(this.lblWmsgTitle, 0, 1);
            this.tableLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel19.Location = new System.Drawing.Point(0, 51);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            this.tableLayoutPanel19.RowCount = 5;
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.Size = new System.Drawing.Size(742, 130);
            this.tableLayoutPanel19.TabIndex = 0;
            // 
            // expWmsgProcid
            // 
            this.expWmsgProcid.AutocompleteAvailable = true;
            this.expWmsgProcid.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expWmsgProcid.AutoSize = true;
            this.tableLayoutPanel19.SetColumnSpan(this.expWmsgProcid, 2);
            this.expWmsgProcid.Dock = System.Windows.Forms.DockStyle.Top;
            this.expWmsgProcid.Expression = "";
            this.expWmsgProcid.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expWmsgProcid.IsPersistent = false;
            this.expWmsgProcid.Location = new System.Drawing.Point(86, 3);
            this.expWmsgProcid.Name = "expWmsgProcid";
            this.expWmsgProcid.ReadOnly = false;
            this.expWmsgProcid.Size = new System.Drawing.Size(653, 20);
            this.expWmsgProcid.TabIndex = 32;
            // 
            // lblWmsgProcid
            // 
            this.lblWmsgProcid.AutoSize = true;
            this.lblWmsgProcid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWmsgProcid.Location = new System.Drawing.Point(3, 0);
            this.lblWmsgProcid.Name = "lblWmsgProcid";
            this.lblWmsgProcid.Size = new System.Drawing.Size(77, 26);
            this.lblWmsgProcid.TabIndex = 33;
            this.lblWmsgProcid.Text = "Process ID";
            this.lblWmsgProcid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expWmsgLparam
            // 
            this.expWmsgLparam.AutocompleteAvailable = true;
            this.expWmsgLparam.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expWmsgLparam.AutoSize = true;
            this.tableLayoutPanel19.SetColumnSpan(this.expWmsgLparam, 2);
            this.expWmsgLparam.Dock = System.Windows.Forms.DockStyle.Top;
            this.expWmsgLparam.Expression = "";
            this.expWmsgLparam.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expWmsgLparam.IsPersistent = false;
            this.expWmsgLparam.Location = new System.Drawing.Point(86, 107);
            this.expWmsgLparam.Name = "expWmsgLparam";
            this.expWmsgLparam.ReadOnly = false;
            this.expWmsgLparam.Size = new System.Drawing.Size(653, 20);
            this.expWmsgLparam.TabIndex = 30;
            // 
            // lblWmsgLparam
            // 
            this.lblWmsgLparam.AutoSize = true;
            this.lblWmsgLparam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWmsgLparam.Location = new System.Drawing.Point(3, 104);
            this.lblWmsgLparam.Name = "lblWmsgLparam";
            this.lblWmsgLparam.Size = new System.Drawing.Size(77, 26);
            this.lblWmsgLparam.TabIndex = 34;
            this.lblWmsgLparam.Text = "LParam";
            this.lblWmsgLparam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expWmsgWparam
            // 
            this.expWmsgWparam.AutocompleteAvailable = true;
            this.expWmsgWparam.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expWmsgWparam.AutoSize = true;
            this.tableLayoutPanel19.SetColumnSpan(this.expWmsgWparam, 2);
            this.expWmsgWparam.Dock = System.Windows.Forms.DockStyle.Top;
            this.expWmsgWparam.Expression = "";
            this.expWmsgWparam.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expWmsgWparam.IsPersistent = false;
            this.expWmsgWparam.Location = new System.Drawing.Point(86, 81);
            this.expWmsgWparam.Name = "expWmsgWparam";
            this.expWmsgWparam.ReadOnly = false;
            this.expWmsgWparam.Size = new System.Drawing.Size(653, 20);
            this.expWmsgWparam.TabIndex = 28;
            // 
            // lblWmsgWparam
            // 
            this.lblWmsgWparam.AutoSize = true;
            this.lblWmsgWparam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWmsgWparam.Location = new System.Drawing.Point(3, 78);
            this.lblWmsgWparam.Name = "lblWmsgWparam";
            this.lblWmsgWparam.Size = new System.Drawing.Size(77, 26);
            this.lblWmsgWparam.TabIndex = 35;
            this.lblWmsgWparam.Text = "WParam";
            this.lblWmsgWparam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expWmsgCode
            // 
            this.expWmsgCode.AutocompleteAvailable = true;
            this.expWmsgCode.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expWmsgCode.AutoSize = true;
            this.tableLayoutPanel19.SetColumnSpan(this.expWmsgCode, 2);
            this.expWmsgCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.expWmsgCode.Expression = "";
            this.expWmsgCode.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expWmsgCode.IsPersistent = false;
            this.expWmsgCode.Location = new System.Drawing.Point(86, 55);
            this.expWmsgCode.Name = "expWmsgCode";
            this.expWmsgCode.ReadOnly = false;
            this.expWmsgCode.Size = new System.Drawing.Size(653, 20);
            this.expWmsgCode.TabIndex = 26;
            // 
            // expWmsgTitle
            // 
            this.expWmsgTitle.AutocompleteAvailable = true;
            this.expWmsgTitle.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expWmsgTitle.AutoSize = true;
            this.tableLayoutPanel19.SetColumnSpan(this.expWmsgTitle, 2);
            this.expWmsgTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.expWmsgTitle.Expression = "";
            this.expWmsgTitle.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Regex;
            this.expWmsgTitle.IsPersistent = false;
            this.expWmsgTitle.Location = new System.Drawing.Point(86, 29);
            this.expWmsgTitle.Name = "expWmsgTitle";
            this.expWmsgTitle.ReadOnly = false;
            this.expWmsgTitle.Size = new System.Drawing.Size(653, 20);
            this.expWmsgTitle.TabIndex = 25;
            // 
            // lblWmsgCode
            // 
            this.lblWmsgCode.AutoSize = true;
            this.lblWmsgCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWmsgCode.Location = new System.Drawing.Point(3, 52);
            this.lblWmsgCode.Name = "lblWmsgCode";
            this.lblWmsgCode.Size = new System.Drawing.Size(77, 26);
            this.lblWmsgCode.TabIndex = 36;
            this.lblWmsgCode.Text = "Message code";
            this.lblWmsgCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWmsgTitle
            // 
            this.lblWmsgTitle.AutoSize = true;
            this.lblWmsgTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWmsgTitle.Location = new System.Drawing.Point(3, 26);
            this.lblWmsgTitle.Name = "lblWmsgTitle";
            this.lblWmsgTitle.Size = new System.Drawing.Size(77, 26);
            this.lblWmsgTitle.TabIndex = 37;
            this.lblWmsgTitle.Text = "Window title";
            this.lblWmsgTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.Controls.Add(this.lblWmsgWarning);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel7.Size = new System.Drawing.Size(742, 51);
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
            this.lblWmsgWarning.Size = new System.Drawing.Size(742, 41);
            this.lblWmsgWarning.TabIndex = 0;
            this.lblWmsgWarning.Text = "Actions of this type may be potentially dangerous and cause damage if, for exampl" +
    "e, the trigger is fired with parameters that fall outside of the expected values" +
    ". Please be aware of the risk.";
            this.lblWmsgWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabFile
            // 
            this.tabFile.Controls.Add(this.tableLayoutPanel20);
            this.tabFile.Controls.Add(this.panel9);
            this.tabFile.Location = new System.Drawing.Point(4, 25);
            this.tabFile.Name = "tabFile";
            this.tabFile.Size = new System.Drawing.Size(742, 414);
            this.tabFile.TabIndex = 15;
            this.tabFile.Text = "File";
            this.tabFile.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel20
            // 
            this.tableLayoutPanel20.AutoSize = true;
            this.tableLayoutPanel20.ColumnCount = 3;
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel20.Controls.Add(this.prsFileVariable, 2, 2);
            this.tableLayoutPanel20.Controls.Add(this.cbxFileOpCache, 0, 3);
            this.tableLayoutPanel20.Controls.Add(this.expFileOpVariable, 1, 2);
            this.tableLayoutPanel20.Controls.Add(this.lblFileOpVariable, 0, 2);
            this.tableLayoutPanel20.Controls.Add(this.cbxFileOpType, 1, 0);
            this.tableLayoutPanel20.Controls.Add(this.lblFileOpType, 0, 0);
            this.tableLayoutPanel20.Controls.Add(this.lblFileOpName, 0, 1);
            this.tableLayoutPanel20.Controls.Add(this.expFileOpName, 1, 1);
            this.tableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel20.Location = new System.Drawing.Point(0, 51);
            this.tableLayoutPanel20.Name = "tableLayoutPanel20";
            this.tableLayoutPanel20.RowCount = 4;
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel20.Size = new System.Drawing.Size(742, 106);
            this.tableLayoutPanel20.TabIndex = 0;
            // 
            // prsFileVariable
            // 
            this.prsFileVariable.AutoSize = true;
            this.prsFileVariable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prsFileVariable.BackgroundImage")));
            this.prsFileVariable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.prsFileVariable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prsFileVariable.IsPersistent = false;
            this.prsFileVariable.Location = new System.Drawing.Point(715, 56);
            this.prsFileVariable.Name = "prsFileVariable";
            this.prsFileVariable.RelatedTextbox = null;
            this.prsFileVariable.Size = new System.Drawing.Size(24, 20);
            this.prsFileVariable.TabIndex = 0;
            this.prsFileVariable.TabStop = false;
            this.prsFileVariable.Tag = ((object)(resources.GetObject("prsFileVariable.Tag")));
            // 
            // cbxFileOpCache
            // 
            this.cbxFileOpCache.AutoSize = true;
            this.cbxFileOpCache.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel20.SetColumnSpan(this.cbxFileOpCache, 3);
            this.cbxFileOpCache.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxFileOpCache.Location = new System.Drawing.Point(3, 84);
            this.cbxFileOpCache.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.cbxFileOpCache.Name = "cbxFileOpCache";
            this.cbxFileOpCache.Size = new System.Drawing.Size(737, 17);
            this.cbxFileOpCache.TabIndex = 1;
            this.cbxFileOpCache.TabStop = false;
            this.cbxFileOpCache.Text = "Cache file on disk";
            this.cbxFileOpCache.UseVisualStyleBackColor = true;
            // 
            // expFileOpVariable
            // 
            this.expFileOpVariable.AutocompleteAvailable = true;
            this.expFileOpVariable.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expFileOpVariable.AutoSize = true;
            this.expFileOpVariable.Dock = System.Windows.Forms.DockStyle.Top;
            this.expFileOpVariable.Expression = "";
            this.expFileOpVariable.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expFileOpVariable.IsPersistent = false;
            this.expFileOpVariable.Location = new System.Drawing.Point(85, 56);
            this.expFileOpVariable.Name = "expFileOpVariable";
            this.expFileOpVariable.ReadOnly = false;
            this.expFileOpVariable.Size = new System.Drawing.Size(624, 20);
            this.expFileOpVariable.TabIndex = 24;
            // 
            // lblFileOpVariable
            // 
            this.lblFileOpVariable.AutoSize = true;
            this.lblFileOpVariable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileOpVariable.Location = new System.Drawing.Point(3, 53);
            this.lblFileOpVariable.Name = "lblFileOpVariable";
            this.lblFileOpVariable.Size = new System.Drawing.Size(76, 26);
            this.lblFileOpVariable.TabIndex = 25;
            this.lblFileOpVariable.Text = "Variable name";
            this.lblFileOpVariable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxFileOpType
            // 
            this.tableLayoutPanel20.SetColumnSpan(this.cbxFileOpType, 2);
            this.cbxFileOpType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxFileOpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFileOpType.FormattingEnabled = true;
            this.cbxFileOpType.Items.AddRange(new object[] {
            "Read file into scalar variable",
            "Read file lines into list variable",
            "Read CSV file into table variable"});
            this.cbxFileOpType.Location = new System.Drawing.Point(85, 3);
            this.cbxFileOpType.Name = "cbxFileOpType";
            this.cbxFileOpType.Size = new System.Drawing.Size(654, 21);
            this.cbxFileOpType.TabIndex = 26;
            this.cbxFileOpType.TabStop = false;
            // 
            // lblFileOpType
            // 
            this.lblFileOpType.AutoSize = true;
            this.lblFileOpType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileOpType.Location = new System.Drawing.Point(3, 0);
            this.lblFileOpType.Name = "lblFileOpType";
            this.lblFileOpType.Size = new System.Drawing.Size(76, 27);
            this.lblFileOpType.TabIndex = 27;
            this.lblFileOpType.Text = "Operation type";
            this.lblFileOpType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFileOpName
            // 
            this.lblFileOpName.AutoSize = true;
            this.lblFileOpName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileOpName.Location = new System.Drawing.Point(3, 27);
            this.lblFileOpName.Name = "lblFileOpName";
            this.lblFileOpName.Size = new System.Drawing.Size(76, 26);
            this.lblFileOpName.TabIndex = 28;
            this.lblFileOpName.Text = "File name";
            this.lblFileOpName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expFileOpName
            // 
            this.expFileOpName.AutocompleteAvailable = true;
            this.expFileOpName.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expFileOpName.AutoSize = true;
            this.tableLayoutPanel20.SetColumnSpan(this.expFileOpName, 2);
            this.expFileOpName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expFileOpName.Expression = "";
            this.expFileOpName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expFileOpName.IsPersistent = false;
            this.expFileOpName.Location = new System.Drawing.Point(85, 30);
            this.expFileOpName.Name = "expFileOpName";
            this.expFileOpName.ReadOnly = false;
            this.expFileOpName.Size = new System.Drawing.Size(654, 20);
            this.expFileOpName.TabIndex = 14;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.Control;
            this.panel9.Controls.Add(this.lblFileWarning);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel9.Size = new System.Drawing.Size(742, 51);
            this.panel9.TabIndex = 6;
            // 
            // lblFileWarning
            // 
            this.lblFileWarning.AutoEllipsis = true;
            this.lblFileWarning.BackColor = System.Drawing.SystemColors.Info;
            this.lblFileWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFileWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileWarning.Location = new System.Drawing.Point(0, 0);
            this.lblFileWarning.Name = "lblFileWarning";
            this.lblFileWarning.Size = new System.Drawing.Size(742, 41);
            this.lblFileWarning.TabIndex = 0;
            this.lblFileWarning.Text = "Actions of this type may be potentially dangerous and cause damage if, for exampl" +
    "e, the trigger is fired with parameters that fall outside of the expected values" +
    ". Please be aware of the risk.";
            this.lblFileWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabLaunchProcess
            // 
            this.tabLaunchProcess.AutoScroll = true;
            this.tabLaunchProcess.Controls.Add(this.tableLayoutPanel5);
            this.tabLaunchProcess.Controls.Add(this.panel4);
            this.tabLaunchProcess.Location = new System.Drawing.Point(4, 25);
            this.tabLaunchProcess.Name = "tabLaunchProcess";
            this.tabLaunchProcess.Size = new System.Drawing.Size(742, 414);
            this.tabLaunchProcess.TabIndex = 16;
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
            this.tableLayoutPanel5.Size = new System.Drawing.Size(742, 105);
            this.tableLayoutPanel5.TabIndex = 0;
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
            this.cbxProcessWindowStyle.Size = new System.Drawing.Size(602, 21);
            this.cbxProcessWindowStyle.TabIndex = 0;
            this.cbxProcessWindowStyle.TabStop = false;
            // 
            // lblProcessWindowStyle
            // 
            this.lblProcessWindowStyle.AutoSize = true;
            this.lblProcessWindowStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProcessWindowStyle.Location = new System.Drawing.Point(3, 78);
            this.lblProcessWindowStyle.Name = "lblProcessWindowStyle";
            this.lblProcessWindowStyle.Size = new System.Drawing.Size(128, 27);
            this.lblProcessWindowStyle.TabIndex = 1;
            this.lblProcessWindowStyle.Text = "Process window";
            this.lblProcessWindowStyle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expProcessWorkingDir
            // 
            this.expProcessWorkingDir.AutocompleteAvailable = true;
            this.expProcessWorkingDir.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expProcessWorkingDir.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.expProcessWorkingDir, 2);
            this.expProcessWorkingDir.Dock = System.Windows.Forms.DockStyle.Top;
            this.expProcessWorkingDir.Expression = "";
            this.expProcessWorkingDir.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expProcessWorkingDir.IsPersistent = false;
            this.expProcessWorkingDir.Location = new System.Drawing.Point(137, 55);
            this.expProcessWorkingDir.Name = "expProcessWorkingDir";
            this.expProcessWorkingDir.ReadOnly = false;
            this.expProcessWorkingDir.Size = new System.Drawing.Size(602, 20);
            this.expProcessWorkingDir.TabIndex = 18;
            // 
            // lblProcessWorkingDir
            // 
            this.lblProcessWorkingDir.AutoSize = true;
            this.lblProcessWorkingDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProcessWorkingDir.Location = new System.Drawing.Point(3, 52);
            this.lblProcessWorkingDir.Name = "lblProcessWorkingDir";
            this.lblProcessWorkingDir.Size = new System.Drawing.Size(128, 26);
            this.lblProcessWorkingDir.TabIndex = 19;
            this.lblProcessWorkingDir.Text = "Working directory";
            this.lblProcessWorkingDir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expProcessParameters
            // 
            this.expProcessParameters.AutocompleteAvailable = true;
            this.expProcessParameters.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expProcessParameters.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.expProcessParameters, 2);
            this.expProcessParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.expProcessParameters.Expression = "";
            this.expProcessParameters.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expProcessParameters.IsPersistent = false;
            this.expProcessParameters.Location = new System.Drawing.Point(137, 29);
            this.expProcessParameters.Name = "expProcessParameters";
            this.expProcessParameters.ReadOnly = false;
            this.expProcessParameters.Size = new System.Drawing.Size(602, 20);
            this.expProcessParameters.TabIndex = 16;
            // 
            // lblProcessParameters
            // 
            this.lblProcessParameters.AutoSize = true;
            this.lblProcessParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProcessParameters.Location = new System.Drawing.Point(3, 26);
            this.lblProcessParameters.Name = "lblProcessParameters";
            this.lblProcessParameters.Size = new System.Drawing.Size(128, 26);
            this.lblProcessParameters.TabIndex = 20;
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
            this.lblProcessName.TabIndex = 21;
            this.lblProcessName.Text = "Process to launch";
            this.lblProcessName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(702, 0);
            this.button6.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(37, 26);
            this.button6.TabIndex = 22;
            this.button6.TabStop = false;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // expProcessName
            // 
            this.expProcessName.AutocompleteAvailable = true;
            this.expProcessName.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expProcessName.AutoSize = true;
            this.expProcessName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expProcessName.Expression = "";
            this.expProcessName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expProcessName.IsPersistent = false;
            this.expProcessName.Location = new System.Drawing.Point(137, 3);
            this.expProcessName.Name = "expProcessName";
            this.expProcessName.ReadOnly = false;
            this.expProcessName.Size = new System.Drawing.Size(562, 20);
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
            this.panel4.Size = new System.Drawing.Size(742, 51);
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
            this.lblProcessWarning.Size = new System.Drawing.Size(742, 41);
            this.lblProcessWarning.TabIndex = 0;
            this.lblProcessWarning.Text = "Actions of this type may be potentially dangerous and cause damage if, for exampl" +
    "e, the trigger is fired with parameters that fall outside of the expected values" +
    ". Please be aware of the risk.";
            this.lblProcessWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabScript
            // 
            this.tabScript.AutoScroll = true;
            this.tabScript.Controls.Add(this.tableLayoutPanel7);
            this.tabScript.Controls.Add(this.panel5);
            this.tabScript.Location = new System.Drawing.Point(4, 25);
            this.tabScript.Name = "tabScript";
            this.tabScript.Size = new System.Drawing.Size(742, 414);
            this.tabScript.TabIndex = 17;
            this.tabScript.Text = "Script";
            this.tabScript.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.lblScriptExtEditor, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.expExecScriptAssemblies, 1, 3);
            this.tableLayoutPanel7.Controls.Add(this.lblExecScriptAssemblies, 0, 3);
            this.tableLayoutPanel7.Controls.Add(this.expExecScriptCode, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.lblExecScriptCode, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.btnScriptExternalEditor, 1, 2);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 51);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 4;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(742, 125);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // lblScriptExtEditor
            // 
            this.lblScriptExtEditor.AutoEllipsis = true;
            this.lblScriptExtEditor.BackColor = System.Drawing.SystemColors.Info;
            this.lblScriptExtEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScriptExtEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScriptExtEditor.Location = new System.Drawing.Point(158, 26);
            this.lblScriptExtEditor.Name = "lblScriptExtEditor";
            this.lblScriptExtEditor.Size = new System.Drawing.Size(581, 41);
            this.lblScriptExtEditor.TabIndex = 0;
            this.lblScriptExtEditor.Text = "External editor has been launched - script contents will be read back from the di" +
    "sk and refreshed when you close the external editor.";
            this.lblScriptExtEditor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScriptExtEditor.Visible = false;
            // 
            // expExecScriptAssemblies
            // 
            this.expExecScriptAssemblies.AutocompleteAvailable = true;
            this.expExecScriptAssemblies.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expExecScriptAssemblies.AutoSize = true;
            this.expExecScriptAssemblies.Dock = System.Windows.Forms.DockStyle.Top;
            this.expExecScriptAssemblies.Expression = "";
            this.expExecScriptAssemblies.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expExecScriptAssemblies.IsPersistent = false;
            this.expExecScriptAssemblies.Location = new System.Drawing.Point(158, 102);
            this.expExecScriptAssemblies.Name = "expExecScriptAssemblies";
            this.expExecScriptAssemblies.ReadOnly = false;
            this.expExecScriptAssemblies.Size = new System.Drawing.Size(581, 20);
            this.expExecScriptAssemblies.TabIndex = 23;
            // 
            // lblExecScriptAssemblies
            // 
            this.lblExecScriptAssemblies.AutoSize = true;
            this.lblExecScriptAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExecScriptAssemblies.Location = new System.Drawing.Point(3, 99);
            this.lblExecScriptAssemblies.Name = "lblExecScriptAssemblies";
            this.lblExecScriptAssemblies.Size = new System.Drawing.Size(149, 26);
            this.lblExecScriptAssemblies.TabIndex = 24;
            this.lblExecScriptAssemblies.Text = "List of assemblies to reference";
            this.lblExecScriptAssemblies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expExecScriptCode
            // 
            this.expExecScriptCode.AutocompleteAvailable = false;
            this.expExecScriptCode.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expExecScriptCode.AutoSize = true;
            this.expExecScriptCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.expExecScriptCode.Expression = "";
            this.expExecScriptCode.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expExecScriptCode.IsPersistent = false;
            this.expExecScriptCode.Location = new System.Drawing.Point(158, 3);
            this.expExecScriptCode.Name = "expExecScriptCode";
            this.expExecScriptCode.ReadOnly = false;
            this.expExecScriptCode.Size = new System.Drawing.Size(581, 20);
            this.expExecScriptCode.TabIndex = 16;
            // 
            // lblExecScriptCode
            // 
            this.lblExecScriptCode.AutoSize = true;
            this.lblExecScriptCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExecScriptCode.Location = new System.Drawing.Point(3, 0);
            this.lblExecScriptCode.Name = "lblExecScriptCode";
            this.lblExecScriptCode.Size = new System.Drawing.Size(149, 26);
            this.lblExecScriptCode.TabIndex = 25;
            this.lblExecScriptCode.Text = "Script code";
            this.lblExecScriptCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnScriptExternalEditor
            // 
            this.btnScriptExternalEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnScriptExternalEditor.Location = new System.Drawing.Point(158, 70);
            this.btnScriptExternalEditor.Name = "btnScriptExternalEditor";
            this.btnScriptExternalEditor.Size = new System.Drawing.Size(581, 26);
            this.btnScriptExternalEditor.TabIndex = 26;
            this.btnScriptExternalEditor.TabStop = false;
            this.btnScriptExternalEditor.Text = "Open in external editor";
            this.btnScriptExternalEditor.UseVisualStyleBackColor = true;
            this.btnScriptExternalEditor.Click += new System.EventHandler(this.btnScriptExternalEditor_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.lblScriptWarning);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel5.Size = new System.Drawing.Size(742, 51);
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
            this.lblScriptWarning.Size = new System.Drawing.Size(742, 41);
            this.lblScriptWarning.TabIndex = 0;
            this.lblScriptWarning.Text = "Actions of this type may be potentially dangerous and cause damage if, for exampl" +
    "e, the trigger is fired with parameters that fall outside of the expected values" +
    ". Please be aware of the risk.";
            this.lblScriptWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabMutex
            // 
            this.tabMutex.Controls.Add(this.tableLayoutPanel22);
            this.tabMutex.Location = new System.Drawing.Point(4, 25);
            this.tabMutex.Name = "tabMutex";
            this.tabMutex.Size = new System.Drawing.Size(742, 414);
            this.tabMutex.TabIndex = 18;
            this.tabMutex.Text = "Mutex";
            this.tabMutex.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel22
            // 
            this.tableLayoutPanel22.AutoSize = true;
            this.tableLayoutPanel22.ColumnCount = 2;
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel22.Controls.Add(this.expMutexName, 1, 1);
            this.tableLayoutPanel22.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel22.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel22.Controls.Add(this.cbxMutexOp, 1, 0);
            this.tableLayoutPanel22.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel22.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel22.Name = "tableLayoutPanel22";
            this.tableLayoutPanel22.RowCount = 2;
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel22.Size = new System.Drawing.Size(742, 53);
            this.tableLayoutPanel22.TabIndex = 0;
            // 
            // expMutexName
            // 
            this.expMutexName.AutocompleteAvailable = true;
            this.expMutexName.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expMutexName.AutoSize = true;
            this.expMutexName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expMutexName.Expression = "";
            this.expMutexName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expMutexName.IsPersistent = false;
            this.expMutexName.Location = new System.Drawing.Point(85, 30);
            this.expMutexName.Name = "expMutexName";
            this.expMutexName.ReadOnly = false;
            this.expMutexName.Size = new System.Drawing.Size(654, 20);
            this.expMutexName.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 26);
            this.label2.TabIndex = 15;
            this.label2.Text = "Mutex name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 27);
            this.label3.TabIndex = 7;
            this.label3.Text = "Operation type";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxMutexOp
            // 
            this.cbxMutexOp.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxMutexOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMutexOp.FormattingEnabled = true;
            this.cbxMutexOp.Items.AddRange(new object[] {
            "Release mutex",
            "Acquire mutex"});
            this.cbxMutexOp.Location = new System.Drawing.Point(85, 3);
            this.cbxMutexOp.Name = "cbxMutexOp";
            this.cbxMutexOp.Size = new System.Drawing.Size(654, 21);
            this.cbxMutexOp.TabIndex = 17;
            this.cbxMutexOp.TabStop = false;
            // 
            // tabLoop
            // 
            this.tabLoop.AutoScroll = true;
            this.tabLoop.Controls.Add(this.actionViewer1);
            this.tabLoop.Controls.Add(this.tableLayoutPanel26);
            this.tabLoop.Location = new System.Drawing.Point(4, 25);
            this.tabLoop.Name = "tabLoop";
            this.tabLoop.Padding = new System.Windows.Forms.Padding(3);
            this.tabLoop.Size = new System.Drawing.Size(742, 414);
            this.tabLoop.TabIndex = 19;
            this.tabLoop.Text = "Loop";
            this.tabLoop.UseVisualStyleBackColor = true;
            // 
            // actionViewer1
            // 
            this.actionViewer1.AutoSize = true;
            this.actionViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionViewer1.Location = new System.Drawing.Point(3, 315);
            this.actionViewer1.MinimumSize = new System.Drawing.Size(0, 200);
            this.actionViewer1.Name = "actionViewer1";
            this.actionViewer1.Size = new System.Drawing.Size(736, 200);
            this.actionViewer1.TabIndex = 0;
            this.actionViewer1.TabStop = false;
            // 
            // tableLayoutPanel26
            // 
            this.tableLayoutPanel26.AutoSize = true;
            this.tableLayoutPanel26.ColumnCount = 4;
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel26.Controls.Add(this.expLoopIncr, 3, 0);
            this.tableLayoutPanel26.Controls.Add(this.expLoopInit, 1, 0);
            this.tableLayoutPanel26.Controls.Add(this.lblLoopIncr, 2, 0);
            this.tableLayoutPanel26.Controls.Add(this.lblLoopInit, 0, 0);
            this.tableLayoutPanel26.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel26.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel26.Controls.Add(this.expLoopIterationDelay, 1, 1);
            this.tableLayoutPanel26.Controls.Add(this.lblLoopDelay, 0, 1);
            this.tableLayoutPanel26.Controls.Add(this.cndLoopCondition, 0, 4);
            this.tableLayoutPanel26.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel26.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel26.Name = "tableLayoutPanel26";
            this.tableLayoutPanel26.RowCount = 7;
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel26.Size = new System.Drawing.Size(736, 312);
            this.tableLayoutPanel26.TabIndex = 1;
            // 
            // expLoopIncr
            // 
            this.expLoopIncr.AutocompleteAvailable = true;
            this.expLoopIncr.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expLoopIncr.AutoSize = true;
            this.expLoopIncr.Dock = System.Windows.Forms.DockStyle.Top;
            this.expLoopIncr.Expression = "";
            this.expLoopIncr.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expLoopIncr.IsPersistent = false;
            this.expLoopIncr.Location = new System.Drawing.Point(453, 3);
            this.expLoopIncr.Name = "expLoopIncr";
            this.expLoopIncr.ReadOnly = false;
            this.expLoopIncr.Size = new System.Drawing.Size(280, 20);
            this.expLoopIncr.TabIndex = 49;
            // 
            // expLoopInit
            // 
            this.expLoopInit.AutocompleteAvailable = true;
            this.expLoopInit.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expLoopInit.AutoSize = true;
            this.expLoopInit.Dock = System.Windows.Forms.DockStyle.Top;
            this.expLoopInit.Expression = "";
            this.expLoopInit.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expLoopInit.IsPersistent = false;
            this.expLoopInit.Location = new System.Drawing.Point(108, 3);
            this.expLoopInit.Name = "expLoopInit";
            this.expLoopInit.ReadOnly = false;
            this.expLoopInit.Size = new System.Drawing.Size(279, 20);
            this.expLoopInit.TabIndex = 48;
            // 
            // lblLoopIncr
            // 
            this.lblLoopIncr.AutoSize = true;
            this.lblLoopIncr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoopIncr.Location = new System.Drawing.Point(393, 0);
            this.lblLoopIncr.Name = "lblLoopIncr";
            this.lblLoopIncr.Size = new System.Drawing.Size(54, 26);
            this.lblLoopIncr.TabIndex = 50;
            this.lblLoopIncr.Text = "Increment";
            this.lblLoopIncr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLoopInit
            // 
            this.lblLoopInit.AutoSize = true;
            this.lblLoopInit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoopInit.Location = new System.Drawing.Point(3, 0);
            this.lblLoopInit.Name = "lblLoopInit";
            this.lblLoopInit.Size = new System.Drawing.Size(99, 26);
            this.lblLoopInit.TabIndex = 51;
            this.lblLoopInit.Text = "Initial iterator";
            this.lblLoopInit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Info;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel26.SetColumnSpan(this.label5, 4);
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(3, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(730, 20);
            this.label5.TabIndex = 52;
            this.label5.Text = "Loop actions";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel26.SetColumnSpan(this.label4, 4);
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(3, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(730, 20);
            this.label4.TabIndex = 53;
            this.label4.Text = "Loop condition (must be true to iterate)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // expLoopIterationDelay
            // 
            this.expLoopIterationDelay.AutocompleteAvailable = true;
            this.expLoopIterationDelay.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expLoopIterationDelay.AutoSize = true;
            this.tableLayoutPanel26.SetColumnSpan(this.expLoopIterationDelay, 3);
            this.expLoopIterationDelay.Dock = System.Windows.Forms.DockStyle.Top;
            this.expLoopIterationDelay.Expression = "";
            this.expLoopIterationDelay.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expLoopIterationDelay.IsPersistent = false;
            this.expLoopIterationDelay.Location = new System.Drawing.Point(108, 29);
            this.expLoopIterationDelay.Name = "expLoopIterationDelay";
            this.expLoopIterationDelay.ReadOnly = false;
            this.expLoopIterationDelay.Size = new System.Drawing.Size(625, 20);
            this.expLoopIterationDelay.TabIndex = 50;
            // 
            // lblLoopDelay
            // 
            this.lblLoopDelay.AutoSize = true;
            this.lblLoopDelay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoopDelay.Location = new System.Drawing.Point(3, 26);
            this.lblLoopDelay.Name = "lblLoopDelay";
            this.lblLoopDelay.Size = new System.Drawing.Size(99, 26);
            this.lblLoopDelay.TabIndex = 54;
            this.lblLoopDelay.Text = "Loop iteration delay";
            this.lblLoopDelay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cndLoopCondition
            // 
            this.tableLayoutPanel26.SetColumnSpan(this.cndLoopCondition, 4);
            this.cndLoopCondition.ConditionToEdit = null;
            this.cndLoopCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cndLoopCondition.Location = new System.Drawing.Point(3, 85);
            this.cndLoopCondition.Name = "cndLoopCondition";
            this.cndLoopCondition.Size = new System.Drawing.Size(730, 194);
            this.cndLoopCondition.TabIndex = 55;
            this.cndLoopCondition.TabStop = false;
            // 
            // tabGenericJson
            // 
            this.tabGenericJson.Controls.Add(this.jsonTableLayout);
            this.tabGenericJson.Location = new System.Drawing.Point(4, 25);
            this.tabGenericJson.Name = "tabGenericJson";
            this.tabGenericJson.Size = new System.Drawing.Size(742, 414);
            this.tabGenericJson.TabIndex = 20;
            this.tabGenericJson.Text = "JSON";
            this.tabGenericJson.UseVisualStyleBackColor = true;
            // 
            // jsonTableLayout
            // 
            this.jsonTableLayout.AutoSize = true;
            this.jsonTableLayout.ColumnCount = 3;
            this.jsonTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.jsonTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.jsonTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.jsonTableLayout.Controls.Add(this.prsJsonVariable, 2, 4);
            this.jsonTableLayout.Controls.Add(this.expJsonVariable, 1, 4);
            this.jsonTableLayout.Controls.Add(this.lblJsonVariable, 0, 4);
            this.jsonTableLayout.Controls.Add(this.expJsonHeaders, 1, 3);
            this.jsonTableLayout.Controls.Add(this.lblJsonHeaders, 0, 3);
            this.jsonTableLayout.Controls.Add(this.cbxJsonType, 1, 1);
            this.jsonTableLayout.Controls.Add(this.lblJsonType, 0, 1);
            this.jsonTableLayout.Controls.Add(this.cbxJsonCache, 0, 6);
            this.jsonTableLayout.Controls.Add(this.expJsonFiring, 1, 5);
            this.jsonTableLayout.Controls.Add(this.lblJsonFiring, 0, 5);
            this.jsonTableLayout.Controls.Add(this.expJsonPayload, 1, 2);
            this.jsonTableLayout.Controls.Add(this.lblJsonPayload, 0, 2);
            this.jsonTableLayout.Controls.Add(this.lblJsonEndpoint, 0, 0);
            this.jsonTableLayout.Controls.Add(this.expJsonEndpoint, 1, 0);
            this.jsonTableLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.jsonTableLayout.Location = new System.Drawing.Point(0, 0);
            this.jsonTableLayout.Name = "jsonTableLayout";
            this.jsonTableLayout.RowCount = 7;
            this.jsonTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.jsonTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.jsonTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.jsonTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.jsonTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.jsonTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.jsonTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.jsonTableLayout.Size = new System.Drawing.Size(742, 184);
            this.jsonTableLayout.TabIndex = 0;
            // 
            // prsJsonVariable
            // 
            this.prsJsonVariable.AutoSize = true;
            this.prsJsonVariable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prsJsonVariable.BackgroundImage")));
            this.prsJsonVariable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.prsJsonVariable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prsJsonVariable.IsPersistent = false;
            this.prsJsonVariable.Location = new System.Drawing.Point(715, 108);
            this.prsJsonVariable.Name = "prsJsonVariable";
            this.prsJsonVariable.RelatedTextbox = null;
            this.prsJsonVariable.Size = new System.Drawing.Size(24, 20);
            this.prsJsonVariable.TabIndex = 0;
            this.prsJsonVariable.TabStop = false;
            this.prsJsonVariable.Tag = ((object)(resources.GetObject("prsJsonVariable.Tag")));
            // 
            // expJsonVariable
            // 
            this.expJsonVariable.AutocompleteAvailable = true;
            this.expJsonVariable.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expJsonVariable.AutoSize = true;
            this.expJsonVariable.Dock = System.Windows.Forms.DockStyle.Top;
            this.expJsonVariable.Expression = "";
            this.expJsonVariable.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expJsonVariable.IsPersistent = false;
            this.expJsonVariable.Location = new System.Drawing.Point(150, 108);
            this.expJsonVariable.Name = "expJsonVariable";
            this.expJsonVariable.ReadOnly = false;
            this.expJsonVariable.Size = new System.Drawing.Size(559, 20);
            this.expJsonVariable.TabIndex = 28;
            // 
            // lblJsonVariable
            // 
            this.lblJsonVariable.AutoSize = true;
            this.lblJsonVariable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJsonVariable.Location = new System.Drawing.Point(3, 105);
            this.lblJsonVariable.Name = "lblJsonVariable";
            this.lblJsonVariable.Size = new System.Drawing.Size(141, 26);
            this.lblJsonVariable.TabIndex = 29;
            this.lblJsonVariable.Text = "Variable to store response to";
            this.lblJsonVariable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expJsonHeaders
            // 
            this.expJsonHeaders.AutocompleteAvailable = true;
            this.expJsonHeaders.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expJsonHeaders.AutoSize = true;
            this.jsonTableLayout.SetColumnSpan(this.expJsonHeaders, 2);
            this.expJsonHeaders.Dock = System.Windows.Forms.DockStyle.Top;
            this.expJsonHeaders.Expression = "";
            this.expJsonHeaders.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expJsonHeaders.IsPersistent = false;
            this.expJsonHeaders.Location = new System.Drawing.Point(150, 82);
            this.expJsonHeaders.Name = "expJsonHeaders";
            this.expJsonHeaders.ReadOnly = false;
            this.expJsonHeaders.Size = new System.Drawing.Size(589, 20);
            this.expJsonHeaders.TabIndex = 26;
            // 
            // lblJsonHeaders
            // 
            this.lblJsonHeaders.AutoSize = true;
            this.lblJsonHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJsonHeaders.Location = new System.Drawing.Point(3, 79);
            this.lblJsonHeaders.Name = "lblJsonHeaders";
            this.lblJsonHeaders.Size = new System.Drawing.Size(141, 26);
            this.lblJsonHeaders.TabIndex = 30;
            this.lblJsonHeaders.Text = "Headers to send";
            this.lblJsonHeaders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxJsonType
            // 
            this.jsonTableLayout.SetColumnSpan(this.cbxJsonType, 2);
            this.cbxJsonType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxJsonType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxJsonType.FormattingEnabled = true;
            this.cbxJsonType.Items.AddRange(new object[] {
            "POST",
            "GET"});
            this.cbxJsonType.Location = new System.Drawing.Point(150, 29);
            this.cbxJsonType.Name = "cbxJsonType";
            this.cbxJsonType.Size = new System.Drawing.Size(589, 21);
            this.cbxJsonType.TabIndex = 31;
            this.cbxJsonType.TabStop = false;
            this.cbxJsonType.SelectedIndexChanged += new System.EventHandler(this.cbxJsonType_SelectedIndexChanged);
            // 
            // lblJsonType
            // 
            this.lblJsonType.AutoSize = true;
            this.lblJsonType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJsonType.Location = new System.Drawing.Point(3, 26);
            this.lblJsonType.Name = "lblJsonType";
            this.lblJsonType.Size = new System.Drawing.Size(141, 27);
            this.lblJsonType.TabIndex = 32;
            this.lblJsonType.Text = "HTTP method";
            this.lblJsonType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxJsonCache
            // 
            this.cbxJsonCache.AutoSize = true;
            this.cbxJsonCache.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.jsonTableLayout.SetColumnSpan(this.cbxJsonCache, 3);
            this.cbxJsonCache.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxJsonCache.Location = new System.Drawing.Point(3, 162);
            this.cbxJsonCache.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.cbxJsonCache.Name = "cbxJsonCache";
            this.cbxJsonCache.Size = new System.Drawing.Size(737, 17);
            this.cbxJsonCache.TabIndex = 33;
            this.cbxJsonCache.TabStop = false;
            this.cbxJsonCache.Text = "Cache response on disk";
            this.cbxJsonCache.UseVisualStyleBackColor = true;
            // 
            // expJsonFiring
            // 
            this.expJsonFiring.AutocompleteAvailable = true;
            this.expJsonFiring.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expJsonFiring.AutoSize = true;
            this.jsonTableLayout.SetColumnSpan(this.expJsonFiring, 2);
            this.expJsonFiring.Dock = System.Windows.Forms.DockStyle.Top;
            this.expJsonFiring.Expression = "";
            this.expJsonFiring.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expJsonFiring.IsPersistent = false;
            this.expJsonFiring.Location = new System.Drawing.Point(150, 134);
            this.expJsonFiring.Name = "expJsonFiring";
            this.expJsonFiring.ReadOnly = false;
            this.expJsonFiring.Size = new System.Drawing.Size(589, 20);
            this.expJsonFiring.TabIndex = 29;
            // 
            // lblJsonFiring
            // 
            this.lblJsonFiring.AutoSize = true;
            this.lblJsonFiring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJsonFiring.Location = new System.Drawing.Point(3, 131);
            this.lblJsonFiring.Name = "lblJsonFiring";
            this.lblJsonFiring.Size = new System.Drawing.Size(141, 26);
            this.lblJsonFiring.TabIndex = 34;
            this.lblJsonFiring.Text = "Response firing expression";
            this.lblJsonFiring.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expJsonPayload
            // 
            this.expJsonPayload.AutocompleteAvailable = true;
            this.expJsonPayload.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expJsonPayload.AutoSize = true;
            this.jsonTableLayout.SetColumnSpan(this.expJsonPayload, 2);
            this.expJsonPayload.Dock = System.Windows.Forms.DockStyle.Top;
            this.expJsonPayload.Expression = "";
            this.expJsonPayload.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expJsonPayload.IsPersistent = false;
            this.expJsonPayload.Location = new System.Drawing.Point(150, 56);
            this.expJsonPayload.Name = "expJsonPayload";
            this.expJsonPayload.ReadOnly = false;
            this.expJsonPayload.Size = new System.Drawing.Size(589, 20);
            this.expJsonPayload.TabIndex = 16;
            // 
            // lblJsonPayload
            // 
            this.lblJsonPayload.AutoSize = true;
            this.lblJsonPayload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJsonPayload.Location = new System.Drawing.Point(3, 53);
            this.lblJsonPayload.Name = "lblJsonPayload";
            this.lblJsonPayload.Size = new System.Drawing.Size(141, 26);
            this.lblJsonPayload.TabIndex = 35;
            this.lblJsonPayload.Text = "Payload to send";
            this.lblJsonPayload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblJsonEndpoint
            // 
            this.lblJsonEndpoint.AutoSize = true;
            this.lblJsonEndpoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJsonEndpoint.Location = new System.Drawing.Point(3, 0);
            this.lblJsonEndpoint.Name = "lblJsonEndpoint";
            this.lblJsonEndpoint.Size = new System.Drawing.Size(141, 26);
            this.lblJsonEndpoint.TabIndex = 36;
            this.lblJsonEndpoint.Text = "Endpoint URL";
            this.lblJsonEndpoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expJsonEndpoint
            // 
            this.expJsonEndpoint.AutocompleteAvailable = true;
            this.expJsonEndpoint.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expJsonEndpoint.AutoSize = true;
            this.jsonTableLayout.SetColumnSpan(this.expJsonEndpoint, 2);
            this.expJsonEndpoint.Dock = System.Windows.Forms.DockStyle.Top;
            this.expJsonEndpoint.Expression = "";
            this.expJsonEndpoint.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expJsonEndpoint.IsPersistent = false;
            this.expJsonEndpoint.Location = new System.Drawing.Point(150, 3);
            this.expJsonEndpoint.Name = "expJsonEndpoint";
            this.expJsonEndpoint.ReadOnly = false;
            this.expJsonEndpoint.Size = new System.Drawing.Size(589, 20);
            this.expJsonEndpoint.TabIndex = 14;
            // 
            // tabDiscordWebhook
            // 
            this.tabDiscordWebhook.Controls.Add(this.discordTableLayout);
            this.tabDiscordWebhook.Location = new System.Drawing.Point(4, 25);
            this.tabDiscordWebhook.Name = "tabDiscordWebhook";
            this.tabDiscordWebhook.Size = new System.Drawing.Size(742, 414);
            this.tabDiscordWebhook.TabIndex = 21;
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
            this.discordTableLayout.Size = new System.Drawing.Size(742, 79);
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
            this.cbxDiscordTts.Size = new System.Drawing.Size(737, 17);
            this.cbxDiscordTts.TabIndex = 0;
            this.cbxDiscordTts.TabStop = false;
            this.cbxDiscordTts.Text = "Send as a text-to-speech message";
            this.cbxDiscordTts.UseVisualStyleBackColor = true;
            // 
            // expDiscordMessage
            // 
            this.expDiscordMessage.AutocompleteAvailable = true;
            this.expDiscordMessage.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expDiscordMessage.AutoSize = true;
            this.expDiscordMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.expDiscordMessage.Expression = "";
            this.expDiscordMessage.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expDiscordMessage.IsPersistent = false;
            this.expDiscordMessage.Location = new System.Drawing.Point(97, 29);
            this.expDiscordMessage.Name = "expDiscordMessage";
            this.expDiscordMessage.ReadOnly = false;
            this.expDiscordMessage.Size = new System.Drawing.Size(642, 20);
            this.expDiscordMessage.TabIndex = 16;
            // 
            // lblDiscordMessage
            // 
            this.lblDiscordMessage.AutoSize = true;
            this.lblDiscordMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiscordMessage.Location = new System.Drawing.Point(3, 26);
            this.lblDiscordMessage.Name = "lblDiscordMessage";
            this.lblDiscordMessage.Size = new System.Drawing.Size(88, 26);
            this.lblDiscordMessage.TabIndex = 17;
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
            this.lblDiscordUrl.TabIndex = 18;
            this.lblDiscordUrl.Text = "Webhook URL";
            this.lblDiscordUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expDiscordUrl
            // 
            this.expDiscordUrl.AutocompleteAvailable = true;
            this.expDiscordUrl.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expDiscordUrl.AutoSize = true;
            this.expDiscordUrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.expDiscordUrl.Expression = "";
            this.expDiscordUrl.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expDiscordUrl.IsPersistent = false;
            this.expDiscordUrl.Location = new System.Drawing.Point(97, 3);
            this.expDiscordUrl.Name = "expDiscordUrl";
            this.expDiscordUrl.ReadOnly = false;
            this.expDiscordUrl.Size = new System.Drawing.Size(642, 20);
            this.expDiscordUrl.TabIndex = 14;
            // 
            // tabLiveSplitControl
            // 
            this.tabLiveSplitControl.Controls.Add(this.tableLayoutPanelLs);
            this.tabLiveSplitControl.Location = new System.Drawing.Point(4, 25);
            this.tabLiveSplitControl.Name = "tabLiveSplitControl";
            this.tabLiveSplitControl.Size = new System.Drawing.Size(742, 414);
            this.tabLiveSplitControl.TabIndex = 22;
            this.tabLiveSplitControl.Text = "LiveSplit";
            this.tabLiveSplitControl.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelLs
            // 
            this.tableLayoutPanelLs.AutoSize = true;
            this.tableLayoutPanelLs.ColumnCount = 3;
            this.tableLayoutPanelLs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelLs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelLs.Controls.Add(this.lblLsCustPayload, 0, 3);
            this.tableLayoutPanelLs.Controls.Add(this.expLSCustPayload, 1, 3);
            this.tableLayoutPanelLs.Controls.Add(this.cbxLsOpType, 1, 0);
            this.tableLayoutPanelLs.Controls.Add(this.lblLsOpType, 0, 0);
            this.tableLayoutPanelLs.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelLs.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelLs.Name = "tableLayoutPanelLs";
            this.tableLayoutPanelLs.RowCount = 4;
            this.tableLayoutPanelLs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelLs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelLs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelLs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelLs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelLs.Size = new System.Drawing.Size(742, 53);
            this.tableLayoutPanelLs.TabIndex = 0;
            // 
            // lblLsCustPayload
            // 
            this.lblLsCustPayload.AutoSize = true;
            this.lblLsCustPayload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLsCustPayload.Location = new System.Drawing.Point(3, 27);
            this.lblLsCustPayload.Name = "lblLsCustPayload";
            this.lblLsCustPayload.Size = new System.Drawing.Size(82, 26);
            this.lblLsCustPayload.TabIndex = 0;
            this.lblLsCustPayload.Text = "Custom payload";
            this.lblLsCustPayload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expLSCustPayload
            // 
            this.expLSCustPayload.AutocompleteAvailable = true;
            this.expLSCustPayload.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expLSCustPayload.AutoSize = true;
            this.tableLayoutPanelLs.SetColumnSpan(this.expLSCustPayload, 2);
            this.expLSCustPayload.Dock = System.Windows.Forms.DockStyle.Top;
            this.expLSCustPayload.Expression = "";
            this.expLSCustPayload.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expLSCustPayload.IsPersistent = false;
            this.expLSCustPayload.Location = new System.Drawing.Point(91, 30);
            this.expLSCustPayload.Name = "expLSCustPayload";
            this.expLSCustPayload.ReadOnly = false;
            this.expLSCustPayload.Size = new System.Drawing.Size(648, 20);
            this.expLSCustPayload.TabIndex = 25;
            // 
            // cbxLsOpType
            // 
            this.tableLayoutPanelLs.SetColumnSpan(this.cbxLsOpType, 2);
            this.cbxLsOpType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxLsOpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLsOpType.FormattingEnabled = true;
            this.cbxLsOpType.Items.AddRange(new object[] {
            "Start run or split",
            "Start run",
            "Split",
            "Undo split",
            "Skip split",
            "Reset run",
            "Pause run",
            "Resume run",
            "Custom payload"});
            this.cbxLsOpType.Location = new System.Drawing.Point(91, 3);
            this.cbxLsOpType.Name = "cbxLsOpType";
            this.cbxLsOpType.Size = new System.Drawing.Size(648, 21);
            this.cbxLsOpType.TabIndex = 26;
            this.cbxLsOpType.TabStop = false;
            this.cbxLsOpType.SelectedIndexChanged += new System.EventHandler(this.cbxLsOpType_SelectedIndexChanged);
            // 
            // lblLsOpType
            // 
            this.lblLsOpType.AutoSize = true;
            this.lblLsOpType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLsOpType.Location = new System.Drawing.Point(3, 0);
            this.lblLsOpType.Name = "lblLsOpType";
            this.lblLsOpType.Size = new System.Drawing.Size(82, 27);
            this.lblLsOpType.TabIndex = 27;
            this.lblLsOpType.Text = "Operation type";
            this.lblLsOpType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabObsControl
            // 
            this.tabObsControl.Controls.Add(this.tableLayoutPanel18);
            this.tabObsControl.Location = new System.Drawing.Point(4, 25);
            this.tabObsControl.Name = "tabObsControl";
            this.tabObsControl.Size = new System.Drawing.Size(742, 414);
            this.tabObsControl.TabIndex = 23;
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
            this.tableLayoutPanel18.Controls.Add(this.expObsPassword, 1, 1);
            this.tableLayoutPanel18.Controls.Add(this.lblObsPassword, 0, 1);
            this.tableLayoutPanel18.Controls.Add(this.expObsEndpoint, 1, 0);
            this.tableLayoutPanel18.Controls.Add(this.lblObsEndpoint, 0, 0);
            this.tableLayoutPanel18.Controls.Add(this.lblObsJSONPayload, 0, 5);
            this.tableLayoutPanel18.Controls.Add(this.expObsJSONPayload, 1, 5);
            this.tableLayoutPanel18.Controls.Add(this.expObsSourceName, 1, 4);
            this.tableLayoutPanel18.Controls.Add(this.lblObsSourceName, 0, 4);
            this.tableLayoutPanel18.Controls.Add(this.cbxObsOpType, 1, 2);
            this.tableLayoutPanel18.Controls.Add(this.lblObsOpType, 0, 2);
            this.tableLayoutPanel18.Controls.Add(this.btnObsWebsocketLink, 2, 7);
            this.tableLayoutPanel18.Controls.Add(this.lblObsSceneName, 0, 3);
            this.tableLayoutPanel18.Controls.Add(this.expObsSceneName, 1, 3);
            this.tableLayoutPanel18.Controls.Add(this.lblObsWebsocketInfo, 1, 6);
            this.tableLayoutPanel18.Controls.Add(this.txtObsWebsocketLink, 1, 7);
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 8;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(742, 223);
            this.tableLayoutPanel18.TabIndex = 0;
            // 
            // expObsPassword
            // 
            this.expObsPassword.AutocompleteAvailable = true;
            this.expObsPassword.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expObsPassword.AutoSize = true;
            this.tableLayoutPanel18.SetColumnSpan(this.expObsPassword, 2);
            this.expObsPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.expObsPassword.Expression = "";
            this.expObsPassword.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expObsPassword.IsPersistent = false;
            this.expObsPassword.Location = new System.Drawing.Point(85, 29);
            this.expObsPassword.Name = "expObsPassword";
            this.expObsPassword.ReadOnly = false;
            this.expObsPassword.Size = new System.Drawing.Size(654, 20);
            this.expObsPassword.TabIndex = 30;
            // 
            // lblObsPassword
            // 
            this.lblObsPassword.AutoSize = true;
            this.lblObsPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblObsPassword.Location = new System.Drawing.Point(3, 26);
            this.lblObsPassword.Name = "lblObsPassword";
            this.lblObsPassword.Size = new System.Drawing.Size(76, 26);
            this.lblObsPassword.TabIndex = 31;
            this.lblObsPassword.Text = "Password";
            this.lblObsPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expObsEndpoint
            // 
            this.expObsEndpoint.AutocompleteAvailable = true;
            this.expObsEndpoint.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expObsEndpoint.AutoSize = true;
            this.tableLayoutPanel18.SetColumnSpan(this.expObsEndpoint, 2);
            this.expObsEndpoint.Dock = System.Windows.Forms.DockStyle.Top;
            this.expObsEndpoint.Expression = "";
            this.expObsEndpoint.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expObsEndpoint.IsPersistent = false;
            this.expObsEndpoint.Location = new System.Drawing.Point(85, 3);
            this.expObsEndpoint.Name = "expObsEndpoint";
            this.expObsEndpoint.ReadOnly = false;
            this.expObsEndpoint.Size = new System.Drawing.Size(654, 20);
            this.expObsEndpoint.TabIndex = 28;
            // 
            // lblObsEndpoint
            // 
            this.lblObsEndpoint.AutoSize = true;
            this.lblObsEndpoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblObsEndpoint.Location = new System.Drawing.Point(3, 0);
            this.lblObsEndpoint.Name = "lblObsEndpoint";
            this.lblObsEndpoint.Size = new System.Drawing.Size(76, 26);
            this.lblObsEndpoint.TabIndex = 32;
            this.lblObsEndpoint.Text = "Endpoint URL";
            this.lblObsEndpoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblObsJSONPayload
            // 
            this.lblObsJSONPayload.AutoSize = true;
            this.lblObsJSONPayload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblObsJSONPayload.Location = new System.Drawing.Point(3, 131);
            this.lblObsJSONPayload.Name = "lblObsJSONPayload";
            this.lblObsJSONPayload.Size = new System.Drawing.Size(76, 26);
            this.lblObsJSONPayload.TabIndex = 33;
            this.lblObsJSONPayload.Text = "JSON payload";
            this.lblObsJSONPayload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expObsJSONPayload
            // 
            this.expObsJSONPayload.AutocompleteAvailable = true;
            this.expObsJSONPayload.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expObsJSONPayload.AutoSize = true;
            this.tableLayoutPanel18.SetColumnSpan(this.expObsJSONPayload, 2);
            this.expObsJSONPayload.Dock = System.Windows.Forms.DockStyle.Top;
            this.expObsJSONPayload.Expression = "";
            this.expObsJSONPayload.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expObsJSONPayload.IsPersistent = false;
            this.expObsJSONPayload.Location = new System.Drawing.Point(85, 134);
            this.expObsJSONPayload.Name = "expObsJSONPayload";
            this.expObsJSONPayload.ReadOnly = false;
            this.expObsJSONPayload.Size = new System.Drawing.Size(654, 20);
            this.expObsJSONPayload.TabIndex = 25;
            this.expObsJSONPayload.EnabledChanged += new System.EventHandler(this.expObsJSONPayload_EnabledChanged);
            // 
            // expObsSourceName
            // 
            this.expObsSourceName.AutocompleteAvailable = true;
            this.expObsSourceName.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expObsSourceName.AutoSize = true;
            this.tableLayoutPanel18.SetColumnSpan(this.expObsSourceName, 2);
            this.expObsSourceName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expObsSourceName.Expression = "";
            this.expObsSourceName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expObsSourceName.IsPersistent = false;
            this.expObsSourceName.Location = new System.Drawing.Point(85, 108);
            this.expObsSourceName.Name = "expObsSourceName";
            this.expObsSourceName.ReadOnly = false;
            this.expObsSourceName.Size = new System.Drawing.Size(654, 20);
            this.expObsSourceName.TabIndex = 24;
            this.expObsSourceName.EnabledChanged += new System.EventHandler(this.expObsSourceName_EnabledChanged);
            // 
            // lblObsSourceName
            // 
            this.lblObsSourceName.AutoSize = true;
            this.lblObsSourceName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblObsSourceName.Location = new System.Drawing.Point(3, 105);
            this.lblObsSourceName.Name = "lblObsSourceName";
            this.lblObsSourceName.Size = new System.Drawing.Size(76, 26);
            this.lblObsSourceName.TabIndex = 34;
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
            "Stop then start recording",
            "Stop then start recording (if currently recording)",
            "Resume recording",
            "Pause recording",
            "Resume/pause recording (toggle)",
            "Start replay buffer",
            "Stop replay buffer",
            "Start/stop replay buffer (toggle)",
            "Save replay buffer",
            "Set scene",
            "Show source",
            "Hide source",
            "Custom JSON payload"});
            this.cbxObsOpType.Location = new System.Drawing.Point(85, 55);
            this.cbxObsOpType.Name = "cbxObsOpType";
            this.cbxObsOpType.Size = new System.Drawing.Size(654, 21);
            this.cbxObsOpType.TabIndex = 35;
            this.cbxObsOpType.TabStop = false;
            this.cbxObsOpType.SelectedIndexChanged += new System.EventHandler(this.cbxObsOpType_SelectedIndexChanged);
            // 
            // lblObsOpType
            // 
            this.lblObsOpType.AutoSize = true;
            this.lblObsOpType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblObsOpType.Location = new System.Drawing.Point(3, 52);
            this.lblObsOpType.Name = "lblObsOpType";
            this.lblObsOpType.Size = new System.Drawing.Size(76, 27);
            this.lblObsOpType.TabIndex = 36;
            this.lblObsOpType.Text = "Operation type";
            this.lblObsOpType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnObsWebsocketLink
            // 
            this.btnObsWebsocketLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnObsWebsocketLink.Image = ((System.Drawing.Image)(resources.GetObject("btnObsWebsocketLink.Image")));
            this.btnObsWebsocketLink.Location = new System.Drawing.Point(702, 203);
            this.btnObsWebsocketLink.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnObsWebsocketLink.Name = "btnObsWebsocketLink";
            this.btnObsWebsocketLink.Size = new System.Drawing.Size(37, 20);
            this.btnObsWebsocketLink.TabIndex = 37;
            this.btnObsWebsocketLink.TabStop = false;
            this.btnObsWebsocketLink.UseVisualStyleBackColor = true;
            this.btnObsWebsocketLink.Click += new System.EventHandler(this.button5_Click);
            // 
            // lblObsSceneName
            // 
            this.lblObsSceneName.AutoSize = true;
            this.lblObsSceneName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblObsSceneName.Location = new System.Drawing.Point(3, 79);
            this.lblObsSceneName.Name = "lblObsSceneName";
            this.lblObsSceneName.Size = new System.Drawing.Size(76, 26);
            this.lblObsSceneName.TabIndex = 38;
            this.lblObsSceneName.Text = "Scene name";
            this.lblObsSceneName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expObsSceneName
            // 
            this.expObsSceneName.AutocompleteAvailable = true;
            this.expObsSceneName.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expObsSceneName.AutoSize = true;
            this.tableLayoutPanel18.SetColumnSpan(this.expObsSceneName, 2);
            this.expObsSceneName.Dock = System.Windows.Forms.DockStyle.Top;
            this.expObsSceneName.Expression = "";
            this.expObsSceneName.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expObsSceneName.IsPersistent = false;
            this.expObsSceneName.Location = new System.Drawing.Point(85, 82);
            this.expObsSceneName.Name = "expObsSceneName";
            this.expObsSceneName.ReadOnly = false;
            this.expObsSceneName.Size = new System.Drawing.Size(654, 20);
            this.expObsSceneName.TabIndex = 14;
            this.expObsSceneName.EnabledChanged += new System.EventHandler(this.expObsSceneName_EnabledChanged);
            // 
            // lblObsWebsocketInfo
            // 
            this.lblObsWebsocketInfo.AutoSize = true;
            this.tableLayoutPanel18.SetColumnSpan(this.lblObsWebsocketInfo, 2);
            this.lblObsWebsocketInfo.Location = new System.Drawing.Point(85, 157);
            this.lblObsWebsocketInfo.Name = "lblObsWebsocketInfo";
            this.lblObsWebsocketInfo.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.lblObsWebsocketInfo.Size = new System.Drawing.Size(629, 46);
            this.lblObsWebsocketInfo.TabIndex = 39;
            this.lblObsWebsocketInfo.Text = "If you are using OBS v27 or older, you will have to install the OBS WebSocket plu" +
    "gin to use OBS remote control features. There is a simple installer available at" +
    ":";
            // 
            // txtObsWebsocketLink
            // 
            this.txtObsWebsocketLink.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtObsWebsocketLink.Location = new System.Drawing.Point(85, 206);
            this.txtObsWebsocketLink.Name = "txtObsWebsocketLink";
            this.txtObsWebsocketLink.ReadOnly = true;
            this.txtObsWebsocketLink.Size = new System.Drawing.Size(614, 20);
            this.txtObsWebsocketLink.TabIndex = 40;
            this.txtObsWebsocketLink.TabStop = false;
            this.txtObsWebsocketLink.Text = "https://obsproject.com/forum/resources/obs-websocket-remote-control-of-obs-studio" +
    "-made-easy.466/";
            // 
            // tabActInteraction
            // 
            this.tabActInteraction.Controls.Add(this.tableActInteraction);
            this.tabActInteraction.Location = new System.Drawing.Point(4, 25);
            this.tabActInteraction.Name = "tabActInteraction";
            this.tabActInteraction.Size = new System.Drawing.Size(742, 414);
            this.tabActInteraction.TabIndex = 24;
            this.tabActInteraction.Text = "Act";
            this.tabActInteraction.UseVisualStyleBackColor = true;
            // 
            // tableActInteraction
            // 
            this.tableActInteraction.AutoSize = true;
            this.tableActInteraction.ColumnCount = 2;
            this.tableActInteraction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableActInteraction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableActInteraction.Controls.Add(this.lblActOpType, 0, 0);
            this.tableActInteraction.Controls.Add(this.cbxActOpType, 1, 0);
            this.tableActInteraction.Controls.Add(this.lblActOpBoolParam, 0, 1);
            this.tableActInteraction.Controls.Add(this.cbxActOpBoolParam, 1, 1);
            this.tableActInteraction.Controls.Add(this.lblActOpStringParam, 0, 2);
            this.tableActInteraction.Controls.Add(this.expActOpStringParam, 1, 2);
            this.tableActInteraction.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableActInteraction.Location = new System.Drawing.Point(0, 0);
            this.tableActInteraction.Name = "tableActInteraction";
            this.tableActInteraction.RowCount = 3;
            this.tableActInteraction.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableActInteraction.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableActInteraction.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableActInteraction.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableActInteraction.Size = new System.Drawing.Size(742, 80);
            this.tableActInteraction.TabIndex = 0;
            // 
            // lblActOpType
            // 
            this.lblActOpType.AutoSize = true;
            this.lblActOpType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActOpType.Location = new System.Drawing.Point(3, 0);
            this.lblActOpType.Name = "lblActOpType";
            this.lblActOpType.Size = new System.Drawing.Size(67, 27);
            this.lblActOpType.TabIndex = 0;
            this.lblActOpType.Text = "Option";
            this.lblActOpType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxActOpType
            // 
            this.cbxActOpType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxActOpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxActOpType.FormattingEnabled = true;
            this.cbxActOpType.Items.AddRange(new object[] {
            "Set ACT combat state",
            "Log all network data",
            "Use Deucalion (injection)"});
            this.cbxActOpType.Location = new System.Drawing.Point(76, 3);
            this.cbxActOpType.Name = "cbxActOpType";
            this.cbxActOpType.Size = new System.Drawing.Size(663, 21);
            this.cbxActOpType.TabIndex = 1;
            this.cbxActOpType.TabStop = false;
            this.cbxActOpType.SelectedIndexChanged += new System.EventHandler(this.cbxActOpType_SelectedIndexChanged);
            // 
            // lblActOpBoolParam
            // 
            this.lblActOpBoolParam.AutoSize = true;
            this.lblActOpBoolParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActOpBoolParam.Location = new System.Drawing.Point(3, 27);
            this.lblActOpBoolParam.Name = "lblActOpBoolParam";
            this.lblActOpBoolParam.Size = new System.Drawing.Size(67, 27);
            this.lblActOpBoolParam.TabIndex = 2;
            this.lblActOpBoolParam.Text = "State";
            this.lblActOpBoolParam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxActOpBoolParam
            // 
            this.cbxActOpBoolParam.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxActOpBoolParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxActOpBoolParam.FormattingEnabled = true;
            this.cbxActOpBoolParam.Items.AddRange(new object[] {
            "End/Disable",
            "Start/Enable"});
            this.cbxActOpBoolParam.Location = new System.Drawing.Point(76, 30);
            this.cbxActOpBoolParam.Name = "cbxActOpBoolParam";
            this.cbxActOpBoolParam.Size = new System.Drawing.Size(663, 21);
            this.cbxActOpBoolParam.TabIndex = 3;
            this.cbxActOpBoolParam.TabStop = false;
            // 
            // lblActOpStringParam
            // 
            this.lblActOpStringParam.AutoSize = true;
            this.lblActOpStringParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActOpStringParam.Location = new System.Drawing.Point(3, 54);
            this.lblActOpStringParam.Name = "lblActOpStringParam";
            this.lblActOpStringParam.Size = new System.Drawing.Size(67, 26);
            this.lblActOpStringParam.TabIndex = 4;
            this.lblActOpStringParam.Text = "String Param";
            this.lblActOpStringParam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expActOpStringParam
            // 
            this.expActOpStringParam.AutocompleteAvailable = true;
            this.expActOpStringParam.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expActOpStringParam.AutoSize = true;
            this.expActOpStringParam.Dock = System.Windows.Forms.DockStyle.Top;
            this.expActOpStringParam.Expression = "";
            this.expActOpStringParam.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expActOpStringParam.IsPersistent = false;
            this.expActOpStringParam.Location = new System.Drawing.Point(76, 57);
            this.expActOpStringParam.Name = "expActOpStringParam";
            this.expActOpStringParam.ReadOnly = false;
            this.expActOpStringParam.Size = new System.Drawing.Size(663, 20);
            this.expActOpStringParam.TabIndex = 10;
            // 
            // tabTriggerOperation
            // 
            this.tabTriggerOperation.AutoScroll = true;
            this.tabTriggerOperation.Controls.Add(this.tableLayoutPanel10);
            this.tabTriggerOperation.Location = new System.Drawing.Point(4, 25);
            this.tabTriggerOperation.Name = "tabTriggerOperation";
            this.tabTriggerOperation.Size = new System.Drawing.Size(742, 414);
            this.tabTriggerOperation.TabIndex = 25;
            this.tabTriggerOperation.Text = "Trigger operation";
            this.tabTriggerOperation.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.AutoSize = true;
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.lblTriggerZoneType, 0, 2);
            this.tableLayoutPanel10.Controls.Add(this.cbxTriggerZoneType, 1, 2);
            this.tableLayoutPanel10.Controls.Add(this.lblFiringOptions, 0, 4);
            this.tableLayoutPanel10.Controls.Add(this.expTriggerZone, 1, 3);
            this.tableLayoutPanel10.Controls.Add(this.lblTriggerZone, 0, 3);
            this.tableLayoutPanel10.Controls.Add(this.lblTrigger, 0, 6);
            this.tableLayoutPanel10.Controls.Add(this.expTriggerText, 1, 1);
            this.tableLayoutPanel10.Controls.Add(this.lblTriggerText, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.lblTriggerOp, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.cbxTriggerOp, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.trvTrigger, 1, 6);
            this.tableLayoutPanel10.Controls.Add(this.cbxFiringOptions, 1, 4);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 8;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(742, 414);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // lblTriggerZoneType
            // 
            this.lblTriggerZoneType.AutoSize = true;
            this.lblTriggerZoneType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTriggerZoneType.Location = new System.Drawing.Point(3, 53);
            this.lblTriggerZoneType.Name = "lblTriggerZoneType";
            this.lblTriggerZoneType.Size = new System.Drawing.Size(95, 27);
            this.lblTriggerZoneType.TabIndex = 0;
            this.lblTriggerZoneType.Text = "Zone type";
            this.lblTriggerZoneType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxTriggerZoneType
            // 
            this.cbxTriggerZoneType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxTriggerZoneType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTriggerZoneType.FormattingEnabled = true;
            this.cbxTriggerZoneType.Items.AddRange(new object[] {
            "Zone name",
            "FFXIV zone ID"});
            this.cbxTriggerZoneType.Location = new System.Drawing.Point(104, 56);
            this.cbxTriggerZoneType.Name = "cbxTriggerZoneType";
            this.cbxTriggerZoneType.Size = new System.Drawing.Size(635, 21);
            this.cbxTriggerZoneType.TabIndex = 1;
            this.cbxTriggerZoneType.TabStop = false;
            this.cbxTriggerZoneType.SelectedIndexChanged += new System.EventHandler(this.cbxZoneType_SelectedIndexChanged);
            // 
            // lblFiringOptions
            // 
            this.lblFiringOptions.AutoSize = true;
            this.lblFiringOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFiringOptions.Location = new System.Drawing.Point(3, 109);
            this.lblFiringOptions.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblFiringOptions.Name = "lblFiringOptions";
            this.lblFiringOptions.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblFiringOptions.Size = new System.Drawing.Size(95, 17);
            this.lblFiringOptions.TabIndex = 2;
            this.lblFiringOptions.Text = "Firing options";
            this.lblFiringOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTriggerZone
            // 
            this.expTriggerZone.AutocompleteAvailable = true;
            this.expTriggerZone.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTriggerZone.AutoSize = true;
            this.expTriggerZone.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTriggerZone.Expression = "";
            this.expTriggerZone.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expTriggerZone.IsPersistent = false;
            this.expTriggerZone.Location = new System.Drawing.Point(104, 83);
            this.expTriggerZone.Name = "expTriggerZone";
            this.expTriggerZone.ReadOnly = false;
            this.expTriggerZone.Size = new System.Drawing.Size(635, 20);
            this.expTriggerZone.TabIndex = 25;
            this.expTriggerZone.EnabledChanged += new System.EventHandler(this.expTriggerZone_EnabledChanged);
            // 
            // lblTriggerZone
            // 
            this.lblTriggerZone.AutoSize = true;
            this.lblTriggerZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTriggerZone.Location = new System.Drawing.Point(3, 80);
            this.lblTriggerZone.Name = "lblTriggerZone";
            this.lblTriggerZone.Size = new System.Drawing.Size(95, 26);
            this.lblTriggerZone.TabIndex = 26;
            this.lblTriggerZone.Text = "Zone name";
            this.lblTriggerZone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTrigger
            // 
            this.lblTrigger.AutoSize = true;
            this.lblTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrigger.Location = new System.Drawing.Point(3, 164);
            this.lblTrigger.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblTrigger.Name = "lblTrigger";
            this.lblTrigger.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblTrigger.Size = new System.Drawing.Size(95, 17);
            this.lblTrigger.TabIndex = 27;
            this.lblTrigger.Text = "Trigger";
            this.lblTrigger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expTriggerText
            // 
            this.expTriggerText.AutocompleteAvailable = true;
            this.expTriggerText.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expTriggerText.AutoSize = true;
            this.expTriggerText.Dock = System.Windows.Forms.DockStyle.Top;
            this.expTriggerText.Expression = "";
            this.expTriggerText.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expTriggerText.IsPersistent = false;
            this.expTriggerText.Location = new System.Drawing.Point(104, 30);
            this.expTriggerText.Name = "expTriggerText";
            this.expTriggerText.ReadOnly = false;
            this.expTriggerText.Size = new System.Drawing.Size(635, 20);
            this.expTriggerText.TabIndex = 16;
            this.expTriggerText.EnabledChanged += new System.EventHandler(this.expTriggerText_EnabledChanged);
            // 
            // lblTriggerText
            // 
            this.lblTriggerText.AutoSize = true;
            this.lblTriggerText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTriggerText.Location = new System.Drawing.Point(3, 27);
            this.lblTriggerText.Name = "lblTriggerText";
            this.lblTriggerText.Size = new System.Drawing.Size(95, 26);
            this.lblTriggerText.TabIndex = 28;
            this.lblTriggerText.Text = "Event text for firing";
            this.lblTriggerText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTriggerOp
            // 
            this.lblTriggerOp.AutoSize = true;
            this.lblTriggerOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTriggerOp.Location = new System.Drawing.Point(3, 0);
            this.lblTriggerOp.Name = "lblTriggerOp";
            this.lblTriggerOp.Size = new System.Drawing.Size(95, 27);
            this.lblTriggerOp.TabIndex = 29;
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
            this.cbxTriggerOp.Location = new System.Drawing.Point(104, 3);
            this.cbxTriggerOp.Name = "cbxTriggerOp";
            this.cbxTriggerOp.Size = new System.Drawing.Size(635, 21);
            this.cbxTriggerOp.TabIndex = 30;
            this.cbxTriggerOp.TabStop = false;
            this.cbxTriggerOp.SelectedIndexChanged += new System.EventHandler(this.cbxTriggerOp_SelectedIndexChanged);
            // 
            // trvTrigger
            // 
            this.trvTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvTrigger.HideSelection = false;
            this.trvTrigger.Location = new System.Drawing.Point(104, 164);
            this.trvTrigger.MinimumSize = new System.Drawing.Size(4, 50);
            this.trvTrigger.Name = "trvTrigger";
            this.tableLayoutPanel10.SetRowSpan(this.trvTrigger, 2);
            this.trvTrigger.ShowNodeToolTips = true;
            this.trvTrigger.Size = new System.Drawing.Size(635, 247);
            this.trvTrigger.TabIndex = 31;
            this.trvTrigger.TabStop = false;
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
            this.cbxFiringOptions.Location = new System.Drawing.Point(104, 109);
            this.cbxFiringOptions.Name = "cbxFiringOptions";
            this.tableLayoutPanel10.SetRowSpan(this.cbxFiringOptions, 2);
            this.cbxFiringOptions.Size = new System.Drawing.Size(635, 49);
            this.cbxFiringOptions.TabIndex = 32;
            this.cbxFiringOptions.TabStop = false;
            this.cbxFiringOptions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cbxFiringOptions_ItemCheck);
            this.cbxFiringOptions.EnabledChanged += new System.EventHandler(this.cbxFiringOptions_EnabledChanged);
            // 
            // tabFolderOperation
            // 
            this.tabFolderOperation.Controls.Add(this.tableLayoutPanel12);
            this.tabFolderOperation.Location = new System.Drawing.Point(4, 25);
            this.tabFolderOperation.Name = "tabFolderOperation";
            this.tabFolderOperation.Size = new System.Drawing.Size(742, 414);
            this.tabFolderOperation.TabIndex = 26;
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
            this.tableLayoutPanel12.Size = new System.Drawing.Size(742, 414);
            this.tableLayoutPanel12.TabIndex = 0;
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
            this.lblFolder.TabIndex = 0;
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
            this.lblFolderOp.TabIndex = 1;
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
            "Disable the specified folder",
            "Cancel all actions in the specified folder"});
            this.cbxFolderOp.Location = new System.Drawing.Point(62, 3);
            this.cbxFolderOp.Name = "cbxFolderOp";
            this.cbxFolderOp.Size = new System.Drawing.Size(677, 21);
            this.cbxFolderOp.TabIndex = 2;
            this.cbxFolderOp.TabStop = false;
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
            this.trvFolder.Size = new System.Drawing.Size(677, 381);
            this.trvFolder.TabIndex = 22;
            this.trvFolder.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvFolder_BeforeCollapse);
            this.trvFolder.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvFolder_BeforeExpand);
            this.trvFolder.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvFolder_BeforeSelect);
            // 
            // tabRepo
            // 
            this.tabRepo.Controls.Add(this.tableLayoutPanel27);
            this.tabRepo.Location = new System.Drawing.Point(4, 25);
            this.tabRepo.Name = "tabRepo";
            this.tabRepo.Padding = new System.Windows.Forms.Padding(3);
            this.tabRepo.Size = new System.Drawing.Size(742, 414);
            this.tabRepo.TabIndex = 27;
            this.tabRepo.Text = "Repo";
            this.tabRepo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel27
            // 
            this.tableLayoutPanel27.AutoSize = true;
            this.tableLayoutPanel27.ColumnCount = 2;
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel27.Controls.Add(this.lblRepositoryLink, 0, 1);
            this.tableLayoutPanel27.Controls.Add(this.lblRepositoryOp, 0, 0);
            this.tableLayoutPanel27.Controls.Add(this.cbxRepositoryOp, 1, 0);
            this.tableLayoutPanel27.Controls.Add(this.trvRepositoryLink, 1, 1);
            this.tableLayoutPanel27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel27.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel27.Name = "tableLayoutPanel27";
            this.tableLayoutPanel27.RowCount = 3;
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel27.Size = new System.Drawing.Size(736, 408);
            this.tableLayoutPanel27.TabIndex = 0;
            // 
            // lblRepositoryLink
            // 
            this.lblRepositoryLink.AutoSize = true;
            this.lblRepositoryLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRepositoryLink.Location = new System.Drawing.Point(3, 30);
            this.lblRepositoryLink.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblRepositoryLink.Name = "lblRepositoryLink";
            this.lblRepositoryLink.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblRepositoryLink.Size = new System.Drawing.Size(57, 17);
            this.lblRepositoryLink.TabIndex = 0;
            this.lblRepositoryLink.Text = "Repository";
            this.lblRepositoryLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRepositoryOp
            // 
            this.lblRepositoryOp.AutoSize = true;
            this.lblRepositoryOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRepositoryOp.Location = new System.Drawing.Point(3, 0);
            this.lblRepositoryOp.Name = "lblRepositoryOp";
            this.lblRepositoryOp.Size = new System.Drawing.Size(57, 27);
            this.lblRepositoryOp.TabIndex = 1;
            this.lblRepositoryOp.Text = "Operation";
            this.lblRepositoryOp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxRepositoryOp
            // 
            this.cbxRepositoryOp.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxRepositoryOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRepositoryOp.FormattingEnabled = true;
            this.cbxRepositoryOp.Items.AddRange(new object[] {
            "Update containing repository",
            "Update selected repository",
            "Update all enabled repositories"});
            this.cbxRepositoryOp.Location = new System.Drawing.Point(66, 3);
            this.cbxRepositoryOp.Name = "cbxRepositoryOp";
            this.cbxRepositoryOp.Size = new System.Drawing.Size(667, 21);
            this.cbxRepositoryOp.TabIndex = 2;
            this.cbxRepositoryOp.TabStop = false;
            this.cbxRepositoryOp.SelectedIndexChanged += new System.EventHandler(this.cbxRepositoryOp_SelectedIndexChanged);
            // 
            // trvRepositoryLink
            // 
            this.trvRepositoryLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvRepositoryLink.HideSelection = false;
            this.trvRepositoryLink.Location = new System.Drawing.Point(66, 30);
            this.trvRepositoryLink.MinimumSize = new System.Drawing.Size(4, 50);
            this.trvRepositoryLink.Name = "trvRepositoryLink";
            this.tableLayoutPanel27.SetRowSpan(this.trvRepositoryLink, 2);
            this.trvRepositoryLink.ShowNodeToolTips = true;
            this.trvRepositoryLink.Size = new System.Drawing.Size(667, 375);
            this.trvRepositoryLink.TabIndex = 22;
            this.trvRepositoryLink.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvRepositoryLink_BeforeCollapse);
            this.trvRepositoryLink.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvRepositoryLink_BeforeExpand);
            this.trvRepositoryLink.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvRepositoryLink_BeforeSelect);
            this.trvRepositoryLink.EnabledChanged += new System.EventHandler(this.trvRepositoryLink_EnabledChanged);
            // 
            // tabPlaceholder
            // 
            this.tabPlaceholder.Controls.Add(this.lblPlaceholderNoParams);
            this.tabPlaceholder.Location = new System.Drawing.Point(4, 25);
            this.tabPlaceholder.Name = "tabPlaceholder";
            this.tabPlaceholder.Size = new System.Drawing.Size(742, 414);
            this.tabPlaceholder.TabIndex = 28;
            this.tabPlaceholder.Text = "Placeholder";
            this.tabPlaceholder.UseVisualStyleBackColor = true;
            // 
            // lblPlaceholderNoParams
            // 
            this.lblPlaceholderNoParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlaceholderNoParams.Location = new System.Drawing.Point(0, 0);
            this.lblPlaceholderNoParams.Name = "lblPlaceholderNoParams";
            this.lblPlaceholderNoParams.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.lblPlaceholderNoParams.Size = new System.Drawing.Size(742, 414);
            this.lblPlaceholderNoParams.TabIndex = 0;
            this.lblPlaceholderNoParams.Text = "This action has no configurable parameters.";
            this.lblPlaceholderNoParams.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(10, 606);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(764, 10);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnOk);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 616);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(764, 35);
            this.panel3.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnTest);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(150, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel6.Size = new System.Drawing.Size(464, 35);
            this.panel6.TabIndex = 2;
            // 
            // btnTest
            // 
            this.btnTest.AutoSize = true;
            this.btnTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTest.Location = new System.Drawing.Point(10, 0);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(444, 35);
            this.btnTest.TabIndex = 0;
            this.btnTest.TabStop = false;
            this.btnTest.Text = "Test action";
            this.btnTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(614, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
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
            this.btnOk.TabIndex = 4;
            this.btnOk.TabStop = false;
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
            this.tbcAction.Controls.Add(this.tabDescription);
            this.tbcAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcAction.Location = new System.Drawing.Point(10, 131);
            this.tbcAction.Name = "tbcAction";
            this.tbcAction.SelectedIndex = 0;
            this.tbcAction.Size = new System.Drawing.Size(764, 475);
            this.tbcAction.TabIndex = 0;
            this.tbcAction.TabStop = false;
            // 
            // tabActionSettings
            // 
            this.tabActionSettings.Controls.Add(this.tbcActionSettings);
            this.tabActionSettings.Controls.Add(this.stsMouseHelp);
            this.tabActionSettings.Location = new System.Drawing.Point(4, 22);
            this.tabActionSettings.Name = "tabActionSettings";
            this.tabActionSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabActionSettings.Size = new System.Drawing.Size(756, 449);
            this.tabActionSettings.TabIndex = 0;
            this.tabActionSettings.Text = "Action-specific settings";
            this.tabActionSettings.UseVisualStyleBackColor = true;
            // 
            // stsMouseHelp
            // 
            this.stsMouseHelp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsMouseLocation});
            this.stsMouseHelp.Location = new System.Drawing.Point(3, 324);
            this.stsMouseHelp.Name = "stsMouseHelp";
            this.stsMouseHelp.Size = new System.Drawing.Size(650, 22);
            this.stsMouseHelp.SizingGrip = false;
            this.stsMouseHelp.TabIndex = 1;
            this.stsMouseHelp.Visible = false;
            // 
            // tlsMouseLocation
            // 
            this.tlsMouseLocation.Image = ((System.Drawing.Image)(resources.GetObject("tlsMouseLocation.Image")));
            this.tlsMouseLocation.Name = "tlsMouseLocation";
            this.tlsMouseLocation.Size = new System.Drawing.Size(97, 17);
            this.tlsMouseLocation.Text = "X: 123, Y: 1234";
            // 
            // tabActionCondition
            // 
            this.tabActionCondition.Controls.Add(this.cndCondition);
            this.tabActionCondition.Location = new System.Drawing.Point(4, 22);
            this.tabActionCondition.Name = "tabActionCondition";
            this.tabActionCondition.Padding = new System.Windows.Forms.Padding(3);
            this.tabActionCondition.Size = new System.Drawing.Size(756, 449);
            this.tabActionCondition.TabIndex = 1;
            this.tabActionCondition.Text = "Action condition";
            this.tabActionCondition.UseVisualStyleBackColor = true;
            // 
            // cndCondition
            // 
            this.cndCondition.ConditionToEdit = null;
            this.cndCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cndCondition.Location = new System.Drawing.Point(3, 3);
            this.cndCondition.Name = "cndCondition";
            this.cndCondition.Size = new System.Drawing.Size(750, 443);
            this.cndCondition.TabIndex = 0;
            this.cndCondition.TabStop = false;
            // 
            // tabScheduling
            // 
            this.tabScheduling.Controls.Add(this.tableLayoutPanel15);
            this.tabScheduling.Location = new System.Drawing.Point(4, 22);
            this.tabScheduling.Name = "tabScheduling";
            this.tabScheduling.Padding = new System.Windows.Forms.Padding(7);
            this.tabScheduling.Size = new System.Drawing.Size(756, 449);
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
            this.tableLayoutPanel15.Size = new System.Drawing.Size(742, 107);
            this.tableLayoutPanel15.TabIndex = 0;
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
            this.chkExecuteAsync.Size = new System.Drawing.Size(737, 17);
            this.chkExecuteAsync.TabIndex = 0;
            this.chkExecuteAsync.TabStop = false;
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
            this.lblExecutionDelay.TabIndex = 1;
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
            this.cbxRefireOption2.Size = new System.Drawing.Size(467, 21);
            this.cbxRefireOption2.TabIndex = 2;
            this.cbxRefireOption2.TabStop = false;
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
            this.cbxRefireOption1.Size = new System.Drawing.Size(467, 21);
            this.cbxRefireOption1.TabIndex = 3;
            this.cbxRefireOption1.TabStop = false;
            // 
            // lblRefireOption1
            // 
            this.lblRefireOption1.AutoSize = true;
            this.lblRefireOption1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRefireOption1.Location = new System.Drawing.Point(3, 0);
            this.lblRefireOption1.Name = "lblRefireOption1";
            this.lblRefireOption1.Size = new System.Drawing.Size(263, 27);
            this.lblRefireOption1.TabIndex = 4;
            this.lblRefireOption1.Text = "If the trigger fires again while this action is still in queue";
            this.lblRefireOption1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expExecutionDelay
            // 
            this.expExecutionDelay.AutocompleteAvailable = true;
            this.expExecutionDelay.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expExecutionDelay.AutoSize = true;
            this.expExecutionDelay.Dock = System.Windows.Forms.DockStyle.Top;
            this.expExecutionDelay.Expression = "";
            this.expExecutionDelay.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            this.expExecutionDelay.IsPersistent = false;
            this.expExecutionDelay.Location = new System.Drawing.Point(272, 57);
            this.expExecutionDelay.Name = "expExecutionDelay";
            this.expExecutionDelay.ReadOnly = false;
            this.expExecutionDelay.Size = new System.Drawing.Size(467, 20);
            this.expExecutionDelay.TabIndex = 7;
            // 
            // tabDebugging
            // 
            this.tabDebugging.Controls.Add(this.tableLayoutPanel16);
            this.tabDebugging.Location = new System.Drawing.Point(4, 22);
            this.tabDebugging.Name = "tabDebugging";
            this.tabDebugging.Padding = new System.Windows.Forms.Padding(7);
            this.tabDebugging.Size = new System.Drawing.Size(756, 449);
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
            this.tableLayoutPanel16.Size = new System.Drawing.Size(742, 27);
            this.tableLayoutPanel16.TabIndex = 0;
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
            "Verbose debug",
            "(inherit from trigger)"});
            this.cbxLoggingLevel.Location = new System.Drawing.Point(115, 3);
            this.cbxLoggingLevel.Name = "cbxLoggingLevel";
            this.cbxLoggingLevel.Size = new System.Drawing.Size(624, 21);
            this.cbxLoggingLevel.TabIndex = 0;
            this.cbxLoggingLevel.TabStop = false;
            // 
            // lblLoggingLevel
            // 
            this.lblLoggingLevel.AutoSize = true;
            this.lblLoggingLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoggingLevel.Location = new System.Drawing.Point(3, 0);
            this.lblLoggingLevel.Name = "lblLoggingLevel";
            this.lblLoggingLevel.Size = new System.Drawing.Size(106, 27);
            this.lblLoggingLevel.TabIndex = 1;
            this.lblLoggingLevel.Text = "Logging filtering level";
            this.lblLoggingLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabDescription
            // 
            this.tabDescription.Controls.Add(this.tableLayoutPanel23);
            this.tabDescription.Location = new System.Drawing.Point(4, 22);
            this.tabDescription.Name = "tabDescription";
            this.tabDescription.Padding = new System.Windows.Forms.Padding(7);
            this.tabDescription.Size = new System.Drawing.Size(756, 449);
            this.tabDescription.TabIndex = 4;
            this.tabDescription.Text = "Description";
            this.tabDescription.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel23
            // 
            this.tableLayoutPanel23.AutoSize = true;
            this.tableLayoutPanel23.ColumnCount = 4;
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel23.Controls.Add(this.chkOverrideDesc, 0, 2);
            this.tableLayoutPanel23.Controls.Add(this.txtDescription, 0, 0);
            this.tableLayoutPanel23.Controls.Add(this.lblDescBgColor, 0, 1);
            this.tableLayoutPanel23.Controls.Add(this.expDescBgColor, 1, 1);
            this.tableLayoutPanel23.Controls.Add(this.lblDescTextColor, 2, 1);
            this.tableLayoutPanel23.Controls.Add(this.expDescTextColor, 3, 1);
            this.tableLayoutPanel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel23.Location = new System.Drawing.Point(7, 7);
            this.tableLayoutPanel23.Name = "tableLayoutPanel23";
            this.tableLayoutPanel23.RowCount = 3;
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel23.Size = new System.Drawing.Size(742, 435);
            this.tableLayoutPanel23.TabIndex = 0;
            // 
            // chkOverrideDesc
            // 
            this.chkOverrideDesc.AutoSize = true;
            this.chkOverrideDesc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel23.SetColumnSpan(this.chkOverrideDesc, 4);
            this.chkOverrideDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkOverrideDesc.Location = new System.Drawing.Point(3, 413);
            this.chkOverrideDesc.Margin = new System.Windows.Forms.Padding(3, 5, 2, 5);
            this.chkOverrideDesc.Name = "chkOverrideDesc";
            this.chkOverrideDesc.Size = new System.Drawing.Size(737, 17);
            this.chkOverrideDesc.TabIndex = 0;
            this.chkOverrideDesc.TabStop = false;
            this.chkOverrideDesc.Text = "Override autogenerated action description";
            this.chkOverrideDesc.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.AcceptsReturn = true;
            this.txtDescription.AcceptsTab = true;
            this.tableLayoutPanel23.SetColumnSpan(this.txtDescription, 4);
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(3, 3);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(736, 376);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.WordWrap = false;
            // 
            // lblDescBgColor
            // 
            this.lblDescBgColor.AutoSize = true;
            this.lblDescBgColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescBgColor.Location = new System.Drawing.Point(3, 382);
            this.lblDescBgColor.Name = "lblDescBgColor";
            this.lblDescBgColor.Size = new System.Drawing.Size(142, 26);
            this.lblDescBgColor.TabIndex = 2;
            this.lblDescBgColor.Text = "Background Color";
            this.lblDescBgColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expDescBgColor
            // 
            this.expDescBgColor.AutocompleteAvailable = true;
            this.expDescBgColor.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expDescBgColor.AutoSize = true;
            this.expDescBgColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.expDescBgColor.Expression = "";
            this.expDescBgColor.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Color;
            this.expDescBgColor.IsPersistent = false;
            this.expDescBgColor.Location = new System.Drawing.Point(151, 385);
            this.expDescBgColor.Name = "expDescBgColor";
            this.expDescBgColor.ReadOnly = false;
            this.expDescBgColor.Size = new System.Drawing.Size(216, 20);
            this.expDescBgColor.TabIndex = 4;
            // 
            // lblDescTextColor
            // 
            this.lblDescTextColor.AutoSize = true;
            this.lblDescTextColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescTextColor.Location = new System.Drawing.Point(373, 382);
            this.lblDescTextColor.Name = "lblDescTextColor";
            this.lblDescTextColor.Size = new System.Drawing.Size(142, 26);
            this.lblDescTextColor.TabIndex = 5;
            this.lblDescTextColor.Text = "Text Color";
            this.lblDescTextColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expDescTextColor
            // 
            this.expDescTextColor.AutocompleteAvailable = true;
            this.expDescTextColor.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expDescTextColor.AutoSize = true;
            this.expDescTextColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.expDescTextColor.Expression = "";
            this.expDescTextColor.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Color;
            this.expDescTextColor.IsPersistent = false;
            this.expDescTextColor.Location = new System.Drawing.Point(521, 385);
            this.expDescTextColor.Name = "expDescTextColor";
            this.expDescTextColor.ReadOnly = false;
            this.expDescTextColor.Size = new System.Drawing.Size(218, 20);
            this.expDescTextColor.TabIndex = 6;
            // 
            // fontDialog1
            // 
            this.fontDialog1.AllowScriptChange = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Control;
            this.panel8.Controls.Add(this.lblReadOnly);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(10, 80);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel8.Size = new System.Drawing.Size(764, 51);
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
            this.lblReadOnly.Size = new System.Drawing.Size(764, 41);
            this.lblReadOnly.TabIndex = 0;
            this.lblReadOnly.Text = "You are in read-only mode, as the configuration of remote triggers can\'t be edite" +
    "d locally. If you wish to edit the action, you will need to make a local copy of" +
    " the trigger.";
            this.lblReadOnly.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // expressionTextBox1
            // 
            this.expressionTextBox1.AutocompleteAvailable = true;
            this.expressionTextBox1.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expressionTextBox1.AutoSize = true;
            this.expressionTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.expressionTextBox1.Expression = "";
            this.expressionTextBox1.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expressionTextBox1.IsPersistent = false;
            this.expressionTextBox1.Location = new System.Drawing.Point(97, 3);
            this.expressionTextBox1.Name = "expressionTextBox1";
            this.expressionTextBox1.ReadOnly = false;
            this.expressionTextBox1.Size = new System.Drawing.Size(405, 20);
            this.expressionTextBox1.TabIndex = 14;
            // 
            // expressionTextBox2
            // 
            this.expressionTextBox2.AutocompleteAvailable = true;
            this.expressionTextBox2.AutofillType = Triggernometry.CustomControls.ExpressionTextBox.AutofillTypeEnum.None;
            this.expressionTextBox2.AutoSize = true;
            this.expressionTextBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.expressionTextBox2.Expression = "";
            this.expressionTextBox2.ExpressionType = Triggernometry.CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
            this.expressionTextBox2.IsPersistent = false;
            this.expressionTextBox2.Location = new System.Drawing.Point(68, 3);
            this.expressionTextBox2.Name = "expressionTextBox2";
            this.expressionTextBox2.ReadOnly = false;
            this.expressionTextBox2.Size = new System.Drawing.Size(474, 20);
            this.expressionTextBox2.TabIndex = 14;
            // 
            // ActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.tbcAction);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpGeneralSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(600, 600);
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
            this.tabVariable.ResumeLayout(false);
            this.tabVariable.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tabListVariable.ResumeLayout(false);
            this.tabListVariable.PerformLayout();
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            this.tabTableVariable.ResumeLayout(false);
            this.tabTableVariable.PerformLayout();
            this.tableLayoutPanel21.ResumeLayout(false);
            this.tableLayoutPanel21.PerformLayout();
            this.tabDictVariable.ResumeLayout(false);
            this.tabDictVariable.PerformLayout();
            this.tableLayoutPanelDict.ResumeLayout(false);
            this.tableLayoutPanelDict.PerformLayout();
            this.tabMessageBox.ResumeLayout(false);
            this.tabMessageBox.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tabLogMessage.ResumeLayout(false);
            this.tabLogMessage.PerformLayout();
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            this.tabTextAura.ResumeLayout(false);
            this.tabTextAura.PerformLayout();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.tableTextColor.ResumeLayout(false);
            this.tableTextColor.PerformLayout();
            this.tabImageAura.ResumeLayout(false);
            this.tabImageAura.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tabMouse.ResumeLayout(false);
            this.tabMouse.PerformLayout();
            this.tableLayoutPanel25.ResumeLayout(false);
            this.tableLayoutPanel25.PerformLayout();
            this.tabKeypress.ResumeLayout(false);
            this.tabKeypress.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tabNamedCallback.ResumeLayout(false);
            this.tabNamedCallback.PerformLayout();
            this.tableLayoutPanel24.ResumeLayout(false);
            this.tableLayoutPanel24.PerformLayout();
            this.tabWindowMessage.ResumeLayout(false);
            this.tabWindowMessage.PerformLayout();
            this.tableLayoutPanel19.ResumeLayout(false);
            this.tableLayoutPanel19.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.tabFile.ResumeLayout(false);
            this.tabFile.PerformLayout();
            this.tableLayoutPanel20.ResumeLayout(false);
            this.tableLayoutPanel20.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.tabLaunchProcess.ResumeLayout(false);
            this.tabLaunchProcess.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tabScript.ResumeLayout(false);
            this.tabScript.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.tabMutex.ResumeLayout(false);
            this.tabMutex.PerformLayout();
            this.tableLayoutPanel22.ResumeLayout(false);
            this.tableLayoutPanel22.PerformLayout();
            this.tabLoop.ResumeLayout(false);
            this.tabLoop.PerformLayout();
            this.tableLayoutPanel26.ResumeLayout(false);
            this.tableLayoutPanel26.PerformLayout();
            this.tabGenericJson.ResumeLayout(false);
            this.tabGenericJson.PerformLayout();
            this.jsonTableLayout.ResumeLayout(false);
            this.jsonTableLayout.PerformLayout();
            this.tabDiscordWebhook.ResumeLayout(false);
            this.tabDiscordWebhook.PerformLayout();
            this.discordTableLayout.ResumeLayout(false);
            this.discordTableLayout.PerformLayout();
            this.tabLiveSplitControl.ResumeLayout(false);
            this.tabLiveSplitControl.PerformLayout();
            this.tableLayoutPanelLs.ResumeLayout(false);
            this.tableLayoutPanelLs.PerformLayout();
            this.tabObsControl.ResumeLayout(false);
            this.tabObsControl.PerformLayout();
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel18.PerformLayout();
            this.tabActInteraction.ResumeLayout(false);
            this.tabActInteraction.PerformLayout();
            this.tableActInteraction.ResumeLayout(false);
            this.tableActInteraction.PerformLayout();
            this.tabTriggerOperation.ResumeLayout(false);
            this.tabTriggerOperation.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tabFolderOperation.ResumeLayout(false);
            this.tabFolderOperation.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.tabRepo.ResumeLayout(false);
            this.tabRepo.PerformLayout();
            this.tableLayoutPanel27.ResumeLayout(false);
            this.tableLayoutPanel27.PerformLayout();
            this.tabPlaceholder.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tbcAction.ResumeLayout(false);
            this.tabActionSettings.ResumeLayout(false);
            this.tabActionSettings.PerformLayout();
            this.stsMouseHelp.ResumeLayout(false);
            this.stsMouseHelp.PerformLayout();
            this.tabActionCondition.ResumeLayout(false);
            this.tabScheduling.ResumeLayout(false);
            this.tabScheduling.PerformLayout();
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.tabDebugging.ResumeLayout(false);
            this.tabDebugging.PerformLayout();
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            this.tabDescription.ResumeLayout(false);
            this.tabDescription.PerformLayout();
            this.tableLayoutPanel23.ResumeLayout(false);
            this.tableLayoutPanel23.PerformLayout();
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
        internal System.Windows.Forms.ComboBox cbxVariableOp;
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
        private System.Windows.Forms.TabPage tabActInteraction;
        private System.Windows.Forms.TableLayoutPanel tableActInteraction;
        private System.Windows.Forms.Label lblActOpType;
        private System.Windows.Forms.ComboBox cbxActOpType;
        private System.Windows.Forms.Label lblActOpBoolParam;
        private System.Windows.Forms.ComboBox cbxActOpBoolParam;
        private System.Windows.Forms.Label lblActOpStringParam;
        private Triggernometry.CustomControls.ExpressionTextBox expActOpStringParam;
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
        private System.Windows.Forms.Label lblTextColor;
        private System.Windows.Forms.TableLayoutPanel tableTextColor;
        private System.Windows.Forms.Label lblTextForeColor;
        private System.Windows.Forms.Label lblTextBackColor;
        private System.Windows.Forms.Label lblTextOutlineColor;
        private CustomControls.ExpressionTextBox expTextForeColor;
        private CustomControls.ExpressionTextBox expTextBackColor;
        private CustomControls.ExpressionTextBox expTextOutlineColor;
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
        internal System.Windows.Forms.ComboBox cbxLvarOperation;
        private System.Windows.Forms.TabPage tabObsControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.ComboBox cbxObsOpType;
        private System.Windows.Forms.Label lblObsOpType;
        private System.Windows.Forms.Button btnObsWebsocketLink;
        private System.Windows.Forms.Label lblObsSceneName;
        private CustomControls.ExpressionTextBox expObsSceneName;
        private System.Windows.Forms.Label lblObsWebsocketInfo;
        private System.Windows.Forms.TextBox txtObsWebsocketLink;
        private System.Windows.Forms.CheckBox chkProcessLog;
        private System.Windows.Forms.CheckBox chkProcessLogACT;
        private System.Windows.Forms.TabPage tabGenericJson;
        private System.Windows.Forms.TableLayoutPanel jsonTableLayout;
        private CustomControls.ExpressionTextBox expJsonFiring;
        private System.Windows.Forms.Label lblJsonFiring;
        private CustomControls.ExpressionTextBox expJsonPayload;
        private System.Windows.Forms.Label lblJsonPayload;
        private System.Windows.Forms.Label lblJsonEndpoint;
        private CustomControls.ExpressionTextBox expJsonEndpoint;
        private System.Windows.Forms.TabPage tabActionCondition;
        private CustomControls.ConditionViewer cndCondition;
        internal System.Windows.Forms.ComboBox cbxKeypressMethod;
        private System.Windows.Forms.Label lblKeypressMethod;
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
        private System.Windows.Forms.StatusStrip stsMouseHelp;
        private System.Windows.Forms.ToolStripStatusLabel tlsMouseLocation;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TabPage tabFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel20;
        private CustomControls.ExpressionTextBox expFileOpVariable;
        private System.Windows.Forms.Label lblFileOpVariable;
        private System.Windows.Forms.ComboBox cbxFileOpType;
        private System.Windows.Forms.Label lblFileOpType;
        private System.Windows.Forms.Label lblFileOpName;
        private CustomControls.ExpressionTextBox expFileOpName;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblFileWarning;
        private System.Windows.Forms.CheckBox cbxJsonCache;
        private System.Windows.Forms.TabPage tabTableVariable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel21;
        private System.Windows.Forms.ComboBox cbxTvarExpType;
        private System.Windows.Forms.Label lblTvarExpType;
        private CustomControls.ExpressionTextBox expTvarTarget;
        private System.Windows.Forms.Label lblTvarTarget;
        private CustomControls.ExpressionTextBox expTvarColumn;
        private System.Windows.Forms.Label lblTvarColumn;
        private CustomControls.ExpressionTextBox expTvarValue;
        private System.Windows.Forms.Label lblTvarValue;
        private CustomControls.ExpressionTextBox expTvarName;
        private System.Windows.Forms.Label lblTvarName;
        private System.Windows.Forms.Label lblTvarOpType;
        internal System.Windows.Forms.ComboBox cbxTvarOpType;
        private CustomControls.ExpressionTextBox expTvarRow;
        private System.Windows.Forms.Label lblTvarRow;
        private System.Windows.Forms.CheckBox cbxFileOpCache;
        private System.Windows.Forms.TabPage tabDictVariable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDict;
        private System.Windows.Forms.Label lblDictOpType;
        internal System.Windows.Forms.ComboBox cbxDictOpType;
        private System.Windows.Forms.Label lblDictName;
        private CustomControls.ExpressionTextBox expDictName;
        private CustomControls.PersistenceSwitch prsDictSource;
        private System.Windows.Forms.Label lblDictLength;
        private CustomControls.ExpressionTextBox expDictLength;
        private System.Windows.Forms.Label lblDictKeyType;
        private System.Windows.Forms.ComboBox cbxDictKeyType;
        private System.Windows.Forms.Label lblDictKey;
        private CustomControls.ExpressionTextBox expDictKey;
        private System.Windows.Forms.Label lblDictValueType;
        private System.Windows.Forms.ComboBox cbxDictValueType;
        private System.Windows.Forms.Label lblDictValue;
        private CustomControls.ExpressionTextBox expDictValue;
        private System.Windows.Forms.Label lblDictTarget;
        private CustomControls.ExpressionTextBox expDictTarget;
        private CustomControls.PersistenceSwitch prsDictTarget;
        private System.Windows.Forms.TabPage tabMutex;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel22;
        private CustomControls.ExpressionTextBox expMutexName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxMutexOp;
        private System.Windows.Forms.TabPage tabDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel23;
        private System.Windows.Forms.CheckBox chkOverrideDesc;
        private System.Windows.Forms.Label lblDescBgColor;
        private System.Windows.Forms.Label lblDescTextColor;
        private CustomControls.ExpressionTextBox expDescBgColor;
        private CustomControls.ExpressionTextBox expDescTextColor;
        private System.Windows.Forms.Label lblLogMessageLevel;
        private System.Windows.Forms.ComboBox cbxLogMessageLevel;
        private System.Windows.Forms.TabPage tabPlaceholder;
        private System.Windows.Forms.Label lblPlaceholderNoParams;
        private System.Windows.Forms.TabPage tabNamedCallback;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel24;
        private CustomControls.ExpressionTextBox expCallbackParam;
        private System.Windows.Forms.Label lblCallbackParam;
        private System.Windows.Forms.Label lblCallbackName;
        private CustomControls.ExpressionTextBox expCallbackName;
        private System.Windows.Forms.Label lblObsJSONPayload;
        private CustomControls.ExpressionTextBox expObsJSONPayload;
        private System.Windows.Forms.TabPage tabMouse;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel25;
        private System.Windows.Forms.ComboBox cbxMouseCoord;
        private CustomControls.ExpressionTextBox expMouseY;
        private System.Windows.Forms.Label lblMouseY;
        private System.Windows.Forms.Label lblMouseX;
        private CustomControls.ExpressionTextBox expMouseX;
        private System.Windows.Forms.Label lblMouseCoord;
        private System.Windows.Forms.Label lblMouseOp;
        private System.Windows.Forms.ComboBox cbxMouseOp;
        private System.Windows.Forms.ComboBox cbxJsonType;
        private System.Windows.Forms.Label lblJsonType;
        private CustomControls.PersistenceSwitch prsScalarName;
        private CustomControls.PersistenceSwitch prsListTarget;
        private CustomControls.PersistenceSwitch prsListSource;
        private CustomControls.PersistenceSwitch prsFileVariable;
        private CustomControls.PersistenceSwitch prsTableTarget;
        private CustomControls.PersistenceSwitch prsTableSource;
        private System.Windows.Forms.Label lblJsonHeaders;
        private CustomControls.ExpressionTextBox expJsonHeaders;
        private System.Windows.Forms.ComboBox cbxLogMessageTarget;
        private System.Windows.Forms.Label lblLogMessageTarget;
        private System.Windows.Forms.TabPage tabLoop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel26;
        private System.Windows.Forms.Label label4;
        private CustomControls.ExpressionTextBox expLoopIterationDelay;
        private System.Windows.Forms.Label lblLoopDelay;
        private CustomControls.ConditionViewer cndLoopCondition;
        private CustomControls.ActionViewer actionViewer1;
        private System.Windows.Forms.Button btnScriptExternalEditor;
        private System.Windows.Forms.Label lblScriptExtEditor;
        private System.Windows.Forms.Label lblObsEndpoint;
        private CustomControls.ExpressionTextBox expObsEndpoint;
        private CustomControls.ExpressionTextBox expObsPassword;
        private System.Windows.Forms.Label lblObsPassword;
        private System.Windows.Forms.TabPage tabRepo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel27;
        private System.Windows.Forms.Label lblRepositoryLink;
        private System.Windows.Forms.Label lblRepositoryOp;
        private System.Windows.Forms.ComboBox cbxRepositoryOp;
        internal System.Windows.Forms.TreeView trvRepositoryLink;
        private CustomControls.ExpressionTextBox expJsonVariable;
        private System.Windows.Forms.Label lblJsonVariable;
        private System.Windows.Forms.Label lblTriggerZoneType;
        internal System.Windows.Forms.ComboBox cbxTriggerZoneType;
        private CustomControls.PersistenceSwitch prsScalarTarget;
        private CustomControls.ExpressionTextBox expVariableTarget;
        private System.Windows.Forms.Label label6;
        private CustomControls.PersistenceSwitch prsJsonVariable;
        private CustomControls.ExpressionTextBox expWmsgProcid;
        private System.Windows.Forms.Label lblWmsgProcid;
        private CustomControls.ExpressionTextBox expKeypressProcId;
        private System.Windows.Forms.Label lblKeypressProcId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLoopInit;
        private CustomControls.ExpressionTextBox expLoopIncr;
        private CustomControls.ExpressionTextBox expLoopInit;
        private System.Windows.Forms.Label lblLoopIncr;
        private System.Windows.Forms.TabPage tabLiveSplitControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLs;
        private System.Windows.Forms.Label lblLsCustPayload;
        private CustomControls.ExpressionTextBox expLSCustPayload;
        private System.Windows.Forms.ComboBox cbxLsOpType;
        private System.Windows.Forms.Label lblLsOpType;
        private System.Windows.Forms.Button btnKeycodesListen;
        private System.Windows.Forms.Button btnSendKeysListen;
        private System.Windows.Forms.Label lblSpeechRouting;
        private System.Windows.Forms.ComboBox cbxSoundMethod;
        private System.Windows.Forms.Label lblSoundMethod;
        private System.Windows.Forms.ComboBox cbxTtsMethod;
    }
}
