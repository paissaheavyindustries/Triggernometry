using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using Triggernometry.CustomControls;
using static Triggernometry.Action;

namespace Triggernometry.Forms
{

    public partial class ActionForm : MemoryForm<ActionForm>
    {

        private bool IsReadonly { get; set; } = false;
        private string EditorTempFn { get; set; }
        private Process ExtEditor { get; set; } = null;

        private RealPlugin _plug;
        internal RealPlugin plug
        {
            get
            {
                return _plug;
            }
            set
            {
                _plug = value;
                cndLoopCondition.plug = value;
                cndCondition.plug = value;
                actionViewer1.plug = value;
            }
        }

        private WMPLib.WindowsMediaPlayer _wmp;
        internal WMPLib.WindowsMediaPlayer wmp
        {
            get
            {
                return _wmp;
            }
            set
            {
                _wmp = value;
                actionViewer1.wmp = value;
            }
        }

        private SpeechSynthesizer _tts;
        internal SpeechSynthesizer tts
        {
            get
            {
                return _tts;
            }
            set
            {
                _tts = value;
                actionViewer1.tts = value;
            }
        }

        private ImageList _imgs;
        internal ImageList imgs
        {
            get
            {
                return _imgs;
            }
            set
            {
                _imgs = value;
                actionViewer1.imgs = value;
            }
        }

        private TreeView _trv;
        internal TreeView trv
        {
            get
            {
                return _trv;
            }
            set
            {
                _trv = value;
                actionViewer1.trv = value;
            }
        }

        private Context _fakectx;
        internal Context fakectx
        {
            get
            {
                return _fakectx;
            }
            set
            {
                _fakectx = value;
                actionViewer1.fakectx = value;
            }
        }

        //internal string Clipboard = "";

        internal static ImageConverter ic = new ImageConverter();

        public class FontInfoContainer
        {

            public string Name { get; set; }
            public float Size { get; set; }
            public Action.TextAuraEffectEnum Effect { get; set; }

        }

        public ActionForm()
        {
            InitializeComponent();
            // SetComboBoxItemHeight(this);   the drawing is too slow
            expAuraImage.textBox1.TextChanged += TextBox1_TextChanged;
            if (DesignMode == false)
            {
                tbcActionSettings.ItemSize = new Size(0, 1);
                tbcActionSettings.SizeMode = TabSizeMode.Fixed;
            }
            btnTest.Tag = I18n.DoNotTranslate;
            btnTest.Text = I18n.Translate("ActionForm/btnTest", "Test Action");
            btnTest.ContextMenuStrip = new ContextMenuStrip();
            ToolStripItem tsi = btnTest.ContextMenuStrip.Items.Add(I18n.Translate("internal/ActionForm/acttestplaceholder", "Test action with placeholder values"));
            tsi.Image = btnTest.Image;
            tsi.Click += Tsi_Click1;
            tsi = btnTest.ContextMenuStrip.Items.Add(I18n.Translate("internal/ActionForm/acttestlive", "Test action with live values"));
            tsi.Image = btnTest.Image;
            tsi.Click += Tsi_Click2;
            tsi = btnTest.ContextMenuStrip.Items.Add(I18n.Translate("internal/ActionForm/acttestliveignoreconditions", "Test action with live values (ignore conditions)"));
            tsi.Image = btnTest.Image;
            tsi.Click += Tsi_Click3;
            txtSendKeysLink.Tag = I18n.DoNotTranslate;
            txtObsWebsocketLink.Tag = I18n.DoNotTranslate;
            RestoredSavedDimensions();
            actionViewer1.plug = plug;
            actionViewer1.tts = tts;
            actionViewer1.wmp = wmp;
            actionViewer1.imgs = imgs;
            actionViewer1.trv = trv;
            actionViewer1.fakectx = fakectx;
            Disposed += ActionForm_Disposed;
            FormClosing += ActionForm_FormClosing;

            prsScalarTarget.RelatedTextbox = expVariableTarget;
            prsScalarName.RelatedTextbox = expVariableName;
            prsListTarget.RelatedTextbox = expLvarTarget;
            prsListSource.RelatedTextbox = expLvarName;
            prsJsonVariable.RelatedTextbox = expJsonVariable;
            prsFileVariable.RelatedTextbox = expFileOpVariable;
            prsTableTarget.RelatedTextbox = expTvarTarget;
            prsTableSource.RelatedTextbox = expTvarName;
            prsDictSource.RelatedTextbox = expDictName;
            prsDictTarget.RelatedTextbox = expDictTarget;
        }
        /*
        public void SetComboBoxItemHeight(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is ComboBox cbx)
                {
                    cbx.DrawMode = DrawMode.OwnerDrawFixed;
                    int fontHeight = cbx.Font.Height;
                    cbx.ItemHeight = (int)Math.Ceiling(fontHeight * 1.15);
                    cbx.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);
                }
                else
                {
                    SetComboBoxItemHeight(control);
                }
            }
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            ComboBox cbx = sender as ComboBox;
            using (Brush brush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(cbx.Items[e.Index].ToString(), e.Font, brush, e.Bounds);
            }
        }
        */

        private void ActionForm_Disposed(object sender, EventArgs e)
        {
            if (ExtEditor != null)
            {
                ExtEditor.Dispose();
                ExtEditor = null;
            }
        }

        private void ActionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ExtEditor != null)
            {
                switch (MessageBox.Show(
                    this,
                    I18n.Translate("internal/ActionForm/exteditorstillup", "External script editor is still running, and any changes made have not yet been reflected to the script code. Ignore changes and close the action editor anyway?"),
                    I18n.Translate("internal/ConfigurationForm/warning", "Warning"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                ))
                {
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void Tsi_Click3(object sender, EventArgs e)
        {
            TestActionPrepare(liveValues: true, ignoreConditions: true);
        }

        private void Tsi_Click2(object sender, EventArgs e)
        {
            TestActionPrepare(liveValues: true, ignoreConditions: false);
        }

        private void Tsi_Click1(object sender, EventArgs e)
        {
            TestActionPrepare(liveValues: false, ignoreConditions: false);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            btnAuraGuide.Enabled = (expAuraImage.textBox1.Text.Length > 0);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int oldsel = tbcActionSettings.SelectedIndex;
            tbcActionSettings.SelectedIndex = cbxActionType.SelectedIndex;
            if (cbxActionType.SelectedIndex == (int)ActionTypeEnum.Aura
                || cbxActionType.SelectedIndex == (int)ActionTypeEnum.TextAura
                || cbxActionType.SelectedIndex == (int)ActionTypeEnum.NamedCallback)
            {
                timer2.Enabled = true;
                stsMouseHelp.Visible = true;
            }
            else if (oldsel == (int)ActionTypeEnum.Aura
                || oldsel == (int)ActionTypeEnum.TextAura
                || oldsel == (int)ActionTypeEnum.NamedCallback)
            {
                stsMouseHelp.Visible = false;
                timer2.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                expSoundFile.Expression = openFileDialog1.FileName;
            }
        }

        internal void SetReadOnlyRecursive(Control c)
        {
            if (c is CustomControls.ExpressionTextBox)
            {
                ((CustomControls.ExpressionTextBox)c).ReadOnly = true;
                return;
            }
            if (c is TextBox)
            {
                ((TextBox)c).ReadOnly = true;
                return;
            }
            foreach (Control cc in c.Controls)
            {
                SetReadOnlyRecursive(cc);
            }
            if (c is Panel || c is TabPage)
            {
                return;
            }
            c.Enabled = false;
        }

        internal void SetReadOnly(TabPage tp)
        {
            foreach (Control c in tp.Controls)
            {
                SetReadOnlyRecursive(c);
            }
        }

        internal void SetReadOnly()
        {
            IsReadonly = true;
            btnTest.Visible = false;
            btnOk.Enabled = false;
            btnOk.Visible = false;
            btnCancel.Dock = DockStyle.Fill;
            cbxActionType.Enabled = false;
            foreach (TabPage tp in tbcActionSettings.TabPages)
            {
                SetReadOnly(tp);
            }
            SetReadOnly(tabActionCondition);
            SetReadOnly(tabScheduling);
            SetReadOnly(tabDebugging);
            SetReadOnly(tabDescription);
            panel6.Visible = false;
            panel8.Visible = true;
        }

        private void UpdateFontDescription()
        {
            FontInfoContainer fic = (FontInfoContainer)txtTextAuraFont.Tag;
            string desc = fic.Name + ", " + fic.Size + I18n.Translate("internal/ActionForm/textptunit", "pt");
            List<string> ex = new List<string>();
            if ((fic.Effect & Action.TextAuraEffectEnum.Bold) != 0)
            {
                ex.Add(I18n.Translate("internal/ActionForm/textbold", "bold"));
            }
            if ((fic.Effect & Action.TextAuraEffectEnum.Italic) != 0)
            {
                ex.Add(I18n.Translate("internal/ActionForm/textitalic", "italic"));
            }
            if ((fic.Effect & Action.TextAuraEffectEnum.Underline) != 0)
            {
                ex.Add(I18n.Translate("internal/ActionForm/textunderline", "underline"));
            }
            if ((fic.Effect & Action.TextAuraEffectEnum.Strikeout) != 0)
            {
                ex.Add(I18n.Translate("internal/ActionForm/textstrikeout", "strikeout"));
            }
            if (ex.Count > 0)
            {
                desc += " (" + String.Join(", ", ex) + ")";
            }
            txtTextAuraFont.Text = desc;
        }

        internal void SettingsFromAction(Action a)
        {
            if (a == null)
            {
                cbxKeypressMethod.SelectedIndex = 0;
                expWindowTitle.Expression = "";
                expKeypress.Expression = "";
                cbxActionType.SelectedIndex = 0;
                cbxRefireOption1.SelectedIndex = 1;
                cbxRefireOption2.SelectedIndex = 1;
                expExecutionDelay.Expression = "0";
                chkExecuteAsync.Checked = plug.cfg.ActionAsyncByDefault;
                expBeepFrequency.Expression = "1046.5"; // C6
                expBeepLength.Expression = "100";
                expSoundFile.Expression = "";
                expSoundVolume.Expression = "100";
                chkSoundExclusive.Checked = true;
                chkSoundMyOutput.Checked = false;
                expTextToSay.Expression = "";
                expSpeechVolume.Expression = "100";
                expSpeechRate.Expression = "0";
                chkSpeechExclusive.Checked = true;
                chkSpeechMyOutput.Checked = false;
                expProcessName.Expression = "";
                expProcessParameters.Expression = "";
                expProcessWorkingDir.Expression = "";
                cbxProcessWindowStyle.SelectedIndex = 0;
                expKeypresses.Expression = "";
                expExecScriptCode.Expression = "";
                expExecScriptAssemblies.Expression = "";
                cbxMessageBoxIcon.SelectedIndex = 0;
                expMessageBoxText.Expression = "";
                expVariableExpression.Expression = "";
                expVariableName.Expression = "";
                expVariableTarget.Expression = "";
                cbxVariableOp.SelectedIndex = 0;
                expLvarIndex.Expression = "";
                expLvarName.Expression = "";
                expLvarTarget.Expression = "";
                expLvarValue.Expression = "";
                cbxLvarExpType.SelectedIndex = 0;
                cbxLvarOperation.SelectedIndex = 0;
                cbxTriggerOp.SelectedIndex = 0;
                expTriggerText.Expression = "";
                expTriggerZone.Expression = "";
                cbxAuraOp.SelectedIndex = 0;
                cbxAuraDisplay.SelectedIndex = 0;
                expAuraName.Expression = "";
                expAuraImage.Expression = "";
                expAuraXIni.Expression = "";
                expAuraYIni.Expression = "";
                expAuraWIni.Expression = "";
                expAuraHIni.Expression = "";
                expAuraOIni.Expression = "";
                expAuraXTick.Expression = "";
                expAuraYTick.Expression = "";
                cbxLoggingLevel.SelectedIndex = (int)RealPlugin.DebugLevelEnum.Inherit;
                expAuraWTick.Expression = "";
                expAuraHTick.Expression = "";
                expAuraOTick.Expression = "";
                expAuraTTLTick.Expression = "";
                cbxFolderOp.SelectedIndex = 0;
                expDiscordMessage.Expression = "";
                expDiscordUrl.Expression = "";
                cbxDiscordTts.Checked = false;
                cbxObsOpType.SelectedIndex = 0;
                expObsEndpoint.Expression = "ws://${_const[OBSWebsocketEndpoint]}:${_const[OBSWebsocketPort]}";
                expObsPassword.Expression = "${_const[OBSWebsocketPassword]}";
                expObsSceneName.Expression = "";
                expObsSourceName.Expression = "";
                expObsJSONPayload.Expression = "";
                cbxLsOpType.SelectedIndex = 0;
                expLSCustPayload.Expression = "";
                cbxTextAuraOp.SelectedIndex = 0;
                cbxTextAuraAlignment.SelectedIndex = 4;
                expTextAuraName.Expression = "";
                expTextAuraText.Expression = "";
                expTextAuraXIni.Expression = "";
                expTextAuraYIni.Expression = "";
                cbxProcessLog.Checked = false;
                cbxLogMessageTarget.SelectedIndex = 0;
                expTextAuraWIni.Expression = "";
                expTextAuraHIni.Expression = "";
                expTextAuraOIni.Expression = "";
                expLogMessageText.Expression = "";
                cbxLogMessageLevel.SelectedIndex = 0;
                expTextAuraXTick.Expression = "";
                expTextAuraYTick.Expression = "";
                expTextAuraWTick.Expression = "";
                expTextAuraHTick.Expression = "";
                expTextAuraOTick.Expression = "";
                expTextAuraTTLTick.Expression = "";
                cbxJsonType.SelectedIndex = 0;
                expJsonEndpoint.Expression = "";
                expJsonFiring.Expression = "";
                expJsonPayload.Expression = "";
                cbxJsonCache.Checked = false;
                expWmsgTitle.Expression = "";
                expWmsgCode.Expression = "";
                expWmsgWparam.Expression = "";
                expWmsgLparam.Expression = "";
                FontInfoContainer fic = new FontInfoContainer();
                fic.Name = Font.Name;
                fic.Size = Font.SizeInPoints;
                if (Font.Bold == true)
                {
                    fic.Effect |= Action.TextAuraEffectEnum.Bold;
                }
                if (Font.Italic == true)
                {
                    fic.Effect |= Action.TextAuraEffectEnum.Italic;
                }
                if (Font.Underline == true)
                {
                    fic.Effect |= Action.TextAuraEffectEnum.Underline;
                }
                if (Font.Strikeout == true)
                {
                    fic.Effect |= Action.TextAuraEffectEnum.Strikeout;
                }
                txtTextAuraFont.Tag = fic;
                colorSelector1.TextColor = Color.Black;
                colorSelector1.TextOutlineColor = Color.White;
                colorSelector1.BackgroundColor = Color.Transparent;
                cbxTextAuraOutline.Checked = false;
                UpdateFontDescription();
                cndCondition.ConditionToEdit = new ConditionGroup() { Enabled = false };
                expFileOpName.Expression = "";
                expFileOpVariable.Expression = "";
                cbxFileOpType.SelectedIndex = 0;
                cbxFileOpCache.Checked = false;
                cbxTvarOpType.SelectedIndex = 0;
                cbxTvarExpType.SelectedIndex = 0;
                expTvarColumn.Expression = "";
                expTvarName.Expression = "";
                expTvarRow.Expression = "";
                expTvarTarget.Expression = "";
                expTvarValue.Expression = "";
                cbxDictOpType.SelectedIndex = 0;
                cbxDictKeyType.SelectedIndex = 0;
                cbxDictValueType.SelectedIndex = 0;
                expDictLength.Expression = "";
                expDictKey.Expression = "";
                expDictValue.Expression = "";
                expDictName.Expression = "";
                expDictTarget.Expression = "";
                prsDictSource.IsPersistent = false;
                prsDictTarget.IsPersistent = false;
                cbxMutexOp.SelectedIndex = 0;
                expMutexName.Expression = "";
                txtDescription.Text = "";
                chkOverrideDesc.Checked = false;
                expDescBgColor.Expression = "";
                expDescTextColor.Expression = "";
                expCallbackName.Expression = "";
                expCallbackParam.Expression = "";
                cbxMouseOp.SelectedIndex = 0;
                cbxMouseCoord.SelectedIndex = 0;
                expMouseX.Expression = "";
                expMouseY.Expression = "";
                prsFileVariable.IsPersistent = false;
                prsListSource.IsPersistent = false;
                prsListTarget.IsPersistent = false;
                prsScalarName.IsPersistent = false;
                prsJsonVariable.IsPersistent = false;
                prsScalarTarget.IsPersistent = false;
                prsTableSource.IsPersistent = false;
                prsTableTarget.IsPersistent = false;
                cndLoopCondition.ConditionToEdit = new ConditionGroup() { Enabled = false };
                actionViewer1.Actions = new List<Action>();
                expLoopIterationDelay.Expression = "";
                expLoopInit.Expression = "0";
                expLoopIncr.Expression = "1";
                cbxRepositoryOp.SelectedIndex = 0;
                cbxTriggerZoneType.SelectedIndex = 0;
                expJsonVariable.Expression = "";
            }
            else
            {
                cbxActionType.SelectedIndex = (int)a.ActionType;
                cbxRefireOption1.SelectedIndex = (a._RefireInterrupt == true ? 0 : 1);
                cbxRefireOption2.SelectedIndex = (a._RefireRequeue == true ? 1 : 0);
                expExecutionDelay.Expression = a._ExecutionDelayExpression;
                chkExecuteAsync.Checked = a._Asynchronous;
                expBeepFrequency.Expression = a._SystemBeepFreqExpression;
                expBeepLength.Expression = a._SystemBeepLengthExpression;
                expSoundFile.Expression = a._PlaySoundFileExpression;
                expSoundVolume.Expression = a._PlaySoundVolumeExpression;
                chkSoundExclusive.Checked = a._PlaySoundExclusive;
                chkSoundMyOutput.Checked = a._PlaySoundMyself;
                expTextToSay.Expression = a._UseTTSTextExpression;
                expSpeechVolume.Expression = a._UseTTSVolumeExpression;
                expSpeechRate.Expression = a._UseTTSRateExpression;
                chkSpeechExclusive.Checked = a._UseTTSExclusive;
                chkSpeechMyOutput.Checked = a._PlaySpeechMyself;
                expProcessName.Expression = a._LaunchProcessPathExpression;
                expProcessParameters.Expression = a._LaunchProcessCmdlineExpression;
                expProcessWorkingDir.Expression = a._LaunchProcessWorkingDirExpression;
                cbxProcessWindowStyle.SelectedIndex = (int)a._LaunchProcessWindowStyle;
                expKeypresses.Expression = a._KeyPressExpression;
                expExecScriptCode.Expression = a._ExecScriptExpression;
                cbxLoggingLevel.SelectedIndex = (int)a._DebugLevel;
                expExecScriptAssemblies.Expression = a._ExecScriptAssembliesExpression;
                cbxMessageBoxIcon.SelectedIndex = ((int)a._MessageBoxIconType) / 16;
                expMessageBoxText.Expression = a._MessageBoxText;
                expVariableExpression.Expression = a._VariableExpression;
                expVariableName.Expression = a._VariableName;
                expVariableTarget.Expression = a._VariableJsonTarget;
                cbxVariableOp.SelectedIndex = (int)a._VariableOp;
                expLvarIndex.Expression = a._ListVariableIndex;
                expLvarName.Expression = a._ListVariableName;
                expLvarTarget.Expression = a._ListVariableTarget;
                expLvarValue.Expression = a._ListVariableExpression;
                cbxLvarExpType.SelectedIndex = (int)a._ListVariableExpressionType;
                cbxLvarOperation.SelectedIndex = (int)a._ListVariableOp;
                if ((a._TriggerForceType & Action.TriggerForceTypeEnum.SkipRegexp) != 0)
                {
                    cbxFiringOptions.SetItemChecked(0, true);
                }
                if ((a._TriggerForceType & Action.TriggerForceTypeEnum.SkipConditions) != 0)
                {
                    cbxFiringOptions.SetItemChecked(1, true);
                }
                if ((a._TriggerForceType & Action.TriggerForceTypeEnum.SkipRefire) != 0)
                {
                    cbxFiringOptions.SetItemChecked(2, true);
                }
                if ((a._TriggerForceType & Action.TriggerForceTypeEnum.SkipParent) != 0)
                {
                    cbxFiringOptions.SetItemChecked(3, true);
                }
                if ((a._TriggerForceType & Action.TriggerForceTypeEnum.SkipActive) != 0)
                {
                    cbxFiringOptions.SetItemChecked(4, true);
                }
                TreeNode tn = plug.LocateNodeHostingTriggerId(trvTrigger.Nodes[0], a._TriggerId, null);
                if (tn != null)
                {
                    tn.EnsureVisible();
                    trvTrigger.SelectedNode = tn;
                    trvTrigger.Update();
                }
                cbxTriggerOp.SelectedIndex = (int)a._TriggerOp;
                tn = plug.LocateNodeHostingFolderId(trvFolder.Nodes[0], a._FolderId, null);
                if (tn != null)
                {
                    tn.EnsureVisible();
                    trvFolder.SelectedNode = tn;
                    trvFolder.Update();
                }
                cbxFolderOp.SelectedIndex = (int)a._FolderOp;
                expTriggerZone.Expression = a._TriggerZone;
                expTriggerText.Expression = a._TriggerText;
                cbxAuraOp.SelectedIndex = (int)a._AuraOp;
                switch (a._AuraImageMode)
                {
                    case PictureBoxSizeMode.Normal:
                        cbxAuraDisplay.SelectedIndex = 0;
                        break;
                    case PictureBoxSizeMode.StretchImage:
                        cbxAuraDisplay.SelectedIndex = 1;
                        break;
                    case PictureBoxSizeMode.CenterImage:
                        cbxAuraDisplay.SelectedIndex = 2;
                        break;
                    case PictureBoxSizeMode.Zoom:
                        cbxAuraDisplay.SelectedIndex = 3;
                        break;
                }
                expAuraName.Expression = a._AuraName;
                expAuraImage.Expression = a._AuraImage;
                expAuraXIni.Expression = a._AuraXIniExpression;
                expAuraYIni.Expression = a._AuraYIniExpression;
                expAuraWIni.Expression = a._AuraWIniExpression;
                expAuraHIni.Expression = a._AuraHIniExpression;
                expAuraOIni.Expression = a._AuraOIniExpression;
                expAuraXTick.Expression = a._AuraXTickExpression;
                expAuraYTick.Expression = a._AuraYTickExpression;
                expAuraWTick.Expression = a._AuraWTickExpression;
                expAuraHTick.Expression = a._AuraHTickExpression;
                expAuraOTick.Expression = a._AuraOTickExpression;
                expAuraTTLTick.Expression = a._AuraTTLTickExpression;
                expDiscordUrl.Expression = a._DiscordWebhookURL;
                expDiscordMessage.Expression = a._DiscordWebhookMessage;
                cbxDiscordTts.Checked = a._DiscordTts;
                cbxObsOpType.SelectedIndex = (int)a._OBSControlType;
                expObsEndpoint.Expression = a._OBSEndPoint;
                expObsPassword.Expression = a._OBSPassword;
                expObsSceneName.Expression = a._OBSSceneName;
                expObsSourceName.Expression = a._OBSSourceName;
                expObsJSONPayload.Expression = a._OBSJSONPayload;
                cbxLsOpType.SelectedIndex = (int)a._LSControlType;
                expLSCustPayload.Expression = a._LSCustomPayload;
                cbxTextAuraOp.SelectedIndex = (int)a._TextAuraOp;
                cbxJsonType.SelectedIndex = (int)a._JsonOperationType;
                expJsonEndpoint.Expression = a._JsonEndpointExpression;
                expJsonFiring.Expression = a._JsonFiringExpression;
                expJsonPayload.Expression = a._JsonPayloadExpression;
                expJsonHeaders.Expression = a._JsonHeaderExpression;
                cbxJsonCache.Checked = a._JsonCacheRequest;
                expWmsgProcid.Expression = a._WmsgProcId;
                expWmsgTitle.Expression = a._WmsgTitle;
                expWmsgCode.Expression = a._WmsgCode;
                expWmsgWparam.Expression = a._WmsgWparam;
                expWmsgLparam.Expression = a._WmsgLparam;
                switch (a._TextAuraAlignment)
                {
                    case Action.TextAuraAlignmentEnum.TopLeft:
                        cbxTextAuraAlignment.SelectedIndex = 0;
                        break;
                    case Action.TextAuraAlignmentEnum.TopCenter:
                        cbxTextAuraAlignment.SelectedIndex = 1;
                        break;
                    case Action.TextAuraAlignmentEnum.TopRight:
                        cbxTextAuraAlignment.SelectedIndex = 2;
                        break;
                    case Action.TextAuraAlignmentEnum.MiddleLeft:
                        cbxTextAuraAlignment.SelectedIndex = 3;
                        break;
                    case Action.TextAuraAlignmentEnum.MiddleCenter:
                        cbxTextAuraAlignment.SelectedIndex = 4;
                        break;
                    case Action.TextAuraAlignmentEnum.MiddleRight:
                        cbxTextAuraAlignment.SelectedIndex = 5;
                        break;
                    case Action.TextAuraAlignmentEnum.BottomLeft:
                        cbxTextAuraAlignment.SelectedIndex = 6;
                        break;
                    case Action.TextAuraAlignmentEnum.BottomCenter:
                        cbxTextAuraAlignment.SelectedIndex = 7;
                        break;
                    case Action.TextAuraAlignmentEnum.BottomRight:
                        cbxTextAuraAlignment.SelectedIndex = 8;
                        break;
                }
                expTextAuraName.Expression = a._TextAuraName;
                expTextAuraText.Expression = a._TextAuraExpression;
                expTextAuraXIni.Expression = a._TextAuraXIniExpression;
                expTextAuraYIni.Expression = a._TextAuraYIniExpression;
                expTextAuraWIni.Expression = a._TextAuraWIniExpression;
                expTextAuraHIni.Expression = a._TextAuraHIniExpression;
                expTextAuraOIni.Expression = a._TextAuraOIniExpression;
                expTextAuraXTick.Expression = a._TextAuraXTickExpression;
                expTextAuraYTick.Expression = a._TextAuraYTickExpression;
                expTextAuraWTick.Expression = a._TextAuraWTickExpression;
                expTextAuraHTick.Expression = a._TextAuraHTickExpression;
                expTextAuraOTick.Expression = a._TextAuraOTickExpression;
                cbxProcessLog.Checked = a._LogProcess;
                cbxLogMessageTarget.SelectedIndex = (int)a._LogMessageTarget;
                expTextAuraTTLTick.Expression = a._TextAuraTTLTickExpression;
                expLogMessageText.Expression = a._LogMessageText;
                cbxLogMessageLevel.SelectedIndex = (int)a._LogLevel;
                FontInfoContainer fic = new FontInfoContainer();
                fic.Name = a._TextAuraFontName;
                fic.Size = a._TextAuraFontSize;
                fic.Effect = a._TextAuraEffect;
                txtTextAuraFont.Tag = fic;
                colorSelector1.TextColor = a._TextAuraForegroundClInt;
                colorSelector1.TextOutlineColor = a._TextAuraOutlineClInt;
                colorSelector1.BackgroundColor = a._TextAuraBackgroundClInt;
                colorSelector1.BackColor = a._TextAuraBackgroundClInt;
                cbxTextAuraOutline.Checked = a._TextAuraUseOutline;
                UpdateFontDescription();
                ConditionGroup cx;
                if (a.Condition != null)
                {
                    cx = (ConditionGroup)a.Condition.Duplicate();
                }
                else
                {
                    cx = new ConditionGroup();
                    cx.Grouping = ConditionGroup.CndGroupingEnum.Or;
                    cx.Enabled = false;
                }
                cndCondition.ConditionToEdit = cx;
                switch (a._KeypressType)
                {
                    case Action.KeypressTypeEnum.SendKeys:
                        cbxKeypressMethod.SelectedIndex = 0;
                        break;
                    case Action.KeypressTypeEnum.WindowMessage:
                        cbxKeypressMethod.SelectedIndex = 1;
                        break;
                    case Action.KeypressTypeEnum.WindowMessageCombo:
                        cbxKeypressMethod.SelectedIndex = 2;
                        break;
                }
                expKeypress.Expression = a._KeyPressCode;
                expWindowTitle.Expression = a._KeyPressWindow;
                expKeypressProcId.Expression = a._KeyPressProcId;
                expFileOpName.Expression = a._DiskFileOpName;
                expFileOpVariable.Expression = a._DiskFileOpVar;
                cbxFileOpType.SelectedIndex = (int)a._DiskFileOp;
                cbxTvarOpType.SelectedIndex = (int)a._TableVariableOp;
                cbxTvarExpType.SelectedIndex = (int)a._TableVariableExpressionType;
                expTvarColumn.Expression = a._TableVariableX;
                expTvarName.Expression = a._TableVariableName;
                expTvarRow.Expression = a._TableVariableY;
                expTvarTarget.Expression = a._TableVariableTarget;
                expTvarValue.Expression = a._TableVariableExpression;
                cbxDictOpType.SelectedIndex = (int)a._DictVariableOp;
                cbxDictKeyType.SelectedIndex = (int)a._DictVariableKeyType;
                cbxDictValueType.SelectedIndex = (int)a._DictVariableValueType;
                expDictLength.Expression = a._DictVariableLength;
                expDictKey.Expression = a._DictVariableKey;
                expDictValue.Expression = a._DictVariableValue;
                expDictName.Expression = a._DictVariableName;
                expDictTarget.Expression = a._DictVariableTarget;
                prsDictSource.IsPersistent = a._DictSourcePersist;
                prsDictTarget.IsPersistent = a._DictTargetPersist;
                cbxFileOpCache.Checked = a._DiskFileCache;
                cbxMutexOp.SelectedIndex = (int)a._MutexOpType;
                expMutexName.Expression = a._MutexName;
                txtDescription.Text = a._Description;
                chkOverrideDesc.Checked = a._DescriptionOverride;
                expDescBgColor.Expression = a._DescBgColor;
                expDescTextColor.Expression = a._DescTextColor;
                expCallbackName.Expression = a._NamedCallbackName;
                expCallbackParam.Expression = a._NamedCallbackParam;
                cbxMouseOp.SelectedIndex = (int)a._MouseOpType;
                cbxMouseCoord.SelectedIndex = (int)a._MouseCoordType;
                expMouseX.Expression = a._MouseX;
                expMouseY.Expression = a._MouseY;
                prsFileVariable.IsPersistent = a._DiskPersist;
                prsListSource.IsPersistent = a._ListSourcePersist;
                prsListTarget.IsPersistent = a._ListTargetPersist;
                prsScalarName.IsPersistent = a._VariablePersist;
                prsScalarTarget.IsPersistent = a._VariableTargetPersist;
                prsJsonVariable.IsPersistent = a._JsonResultVariablePersist;
                prsTableSource.IsPersistent = a._TableSourcePersist;
                prsTableTarget.IsPersistent = a._TableTargetPersist;
                if (a.LoopCondition != null)
                {
                    cx = (ConditionGroup)a.LoopCondition.Duplicate();
                }
                else
                {
                    cx = new ConditionGroup();
                    cx.Grouping = ConditionGroup.CndGroupingEnum.Or;
                    cx.Enabled = false;
                }
                cndLoopCondition.ConditionToEdit = cx;
                actionViewer1.Actions = new List<Action>();
                var ix = from tx in a.LoopActions
                         orderby tx.OrderNumber ascending
                         select tx;
                foreach (Action ax in ix)
                {
                    Action b = new Action();
                    ax.CopySettingsTo(b);
                    actionViewer1.Actions.Add(b);
                }
                actionViewer1.RefreshDgv();
                expLoopIterationDelay.Expression = a._LoopDelayExpression;
                expLoopIncr.Expression = a._LoopIncrExpression;
                expLoopInit.Expression = a._LoopInitExpression;
                tn = plug.LocateNodeHostingRepositoryId(trvRepositoryLink.Nodes[0], a._RepositoryId);
                if (tn != null)
                {
                    tn.EnsureVisible();
                    trvRepositoryLink.SelectedNode = tn;
                    trvRepositoryLink.Update();
                }
                cbxRepositoryOp.SelectedIndex = (int)a._RepositoryOp;
                cbxTriggerZoneType.SelectedIndex = (int)a._TriggerZoneType;
                expJsonVariable.Expression = a._JsonResultVariable;
            }
            cbxProcessLog_CheckedChanged(null, null);
        }

        internal void SettingsToAction(Action a)
        {
            a.ActionType = (Action.ActionTypeEnum)cbxActionType.SelectedIndex;
            a._RefireInterrupt = (cbxRefireOption1.SelectedIndex == 0);
            a._RefireRequeue = (cbxRefireOption2.SelectedIndex == 1);
            a._ExecutionDelayExpression = expExecutionDelay.Expression;
            a._Asynchronous = chkExecuteAsync.Checked;
            a._SystemBeepFreqExpression = expBeepFrequency.Expression;
            a._SystemBeepLengthExpression = expBeepLength.Expression;
            a._PlaySoundFileExpression = expSoundFile.Expression;
            a._PlaySoundVolumeExpression = expSoundVolume.Expression;
            a._PlaySoundExclusive = chkSoundExclusive.Checked;
            a._PlaySoundMyself = chkSoundMyOutput.Checked;
            a._UseTTSTextExpression = expTextToSay.Expression;
            a._LogProcess = cbxProcessLog.Checked;
            a._LogMessageTarget = (LogEvent.SourceEnum)cbxLogMessageTarget.SelectedIndex;
            a._UseTTSVolumeExpression = expSpeechVolume.Expression;
            a._UseTTSRateExpression = expSpeechRate.Expression;
            a._UseTTSExclusive = chkSpeechExclusive.Checked;
            a._PlaySpeechMyself = chkSpeechMyOutput.Checked;
            a._LaunchProcessPathExpression = expProcessName.Expression;
            a._LaunchProcessCmdlineExpression = expProcessParameters.Expression;
            a._LaunchProcessWorkingDirExpression = expProcessWorkingDir.Expression;
            a._DebugLevel = (RealPlugin.DebugLevelEnum)cbxLoggingLevel.SelectedIndex;
            a._LaunchProcessWindowStyle = (System.Diagnostics.ProcessWindowStyle)cbxProcessWindowStyle.SelectedIndex;
            a._KeyPressExpression = expKeypresses.Expression;
            a._ExecScriptExpression = expExecScriptCode.Expression;
            a._ExecScriptAssembliesExpression = expExecScriptAssemblies.Expression;
            a._MessageBoxIconType = (Action.MessageBoxIconTypeEnum)(cbxMessageBoxIcon.SelectedIndex * 16);
            a._MessageBoxText = expMessageBoxText.Expression;
            a._VariableExpression = expVariableExpression.Expression;
            a._VariableName = expVariableName.Expression;
            a._VariableJsonTarget = expVariableTarget.Expression;
            a._VariableOp = (Action.VariableOpEnum)cbxVariableOp.SelectedIndex;
            a._ListVariableExpression = expLvarValue.Expression;
            a._ListVariableExpressionType = (Action.ListVariableExpTypeEnum)cbxLvarExpType.SelectedIndex;
            a._ListVariableIndex = expLvarIndex.Expression;
            a._ListVariableName = expLvarName.Expression;
            a._ListVariableOp = (Action.ListVariableOpEnum)cbxLvarOperation.SelectedIndex;
            a._ListVariableTarget = expLvarTarget.Expression;
            TreeNode tn = trvTrigger.SelectedNode;
            if (tn != null)
            {
                a._TriggerId = ((Trigger)tn.Tag).Id;
            }
            else
            {
                a._TriggerId = Guid.Empty;
            }
            a._TriggerOp = (Action.TriggerOpEnum)cbxTriggerOp.SelectedIndex;
            tn = trvFolder.SelectedNode;
            if (tn != null)
            {
                a._FolderId = ((Folder)tn.Tag).Id;
            }
            else
            {
                a._FolderId = Guid.Empty;
            }
            a._FolderOp = (Action.FolderOpEnum)cbxFolderOp.SelectedIndex;
            Action.TriggerForceTypeEnum newval = Action.TriggerForceTypeEnum.NoSkip;
            if (cbxFiringOptions.CheckedIndices.Contains(0) == true)
            {
                newval |= Action.TriggerForceTypeEnum.SkipRegexp;
            }
            if (cbxFiringOptions.CheckedIndices.Contains(1) == true)
            {
                newval |= Action.TriggerForceTypeEnum.SkipConditions;
            }
            if (cbxFiringOptions.CheckedIndices.Contains(2) == true)
            {
                newval |= Action.TriggerForceTypeEnum.SkipRefire;
            }
            if (cbxFiringOptions.CheckedIndices.Contains(3) == true)
            {
                newval |= Action.TriggerForceTypeEnum.SkipParent;
            }
            if (cbxFiringOptions.CheckedIndices.Contains(4) == true)
            {
                newval |= Action.TriggerForceTypeEnum.SkipActive;
            }
            a._TriggerForceType = newval;
            a._TriggerText = expTriggerText.Expression;
            a._TriggerZone = expTriggerZone.Expression;
            a._AuraOp = (Action.AuraOpEnum)cbxAuraOp.SelectedIndex;
            switch (cbxAuraDisplay.SelectedIndex)
            {
                case 0:
                    a._AuraImageMode = PictureBoxSizeMode.Normal;
                    break;
                case 1:
                    a._AuraImageMode = PictureBoxSizeMode.StretchImage;
                    break;
                case 2:
                    a._AuraImageMode = PictureBoxSizeMode.CenterImage;
                    break;
                case 3:
                    a._AuraImageMode = PictureBoxSizeMode.Zoom;
                    break;
            }
            a._AuraName = expAuraName.Expression;
            a._AuraImage = expAuraImage.Expression;
            a._AuraXIniExpression = expAuraXIni.Expression;
            a._AuraYIniExpression = expAuraYIni.Expression;
            a._AuraWIniExpression = expAuraWIni.Expression;
            a._AuraHIniExpression = expAuraHIni.Expression;
            a._AuraOIniExpression = expAuraOIni.Expression;
            a._AuraXTickExpression = expAuraXTick.Expression;
            a._AuraYTickExpression = expAuraYTick.Expression;
            a._AuraWTickExpression = expAuraWTick.Expression;
            a._AuraHTickExpression = expAuraHTick.Expression;
            a._AuraOTickExpression = expAuraOTick.Expression;
            a._AuraTTLTickExpression = expAuraTTLTick.Expression;
            a._DiscordWebhookMessage = expDiscordMessage.Expression;
            a._DiscordWebhookURL = expDiscordUrl.Expression;
            a._DiscordTts = cbxDiscordTts.Checked;
            a._OBSControlType = (Action.ObsControlTypeEnum)cbxObsOpType.SelectedIndex;
            a._OBSEndPoint = expObsEndpoint.Expression;
            a._OBSPassword = expObsPassword.Expression;
            a._OBSSceneName = expObsSceneName.Expression;
            a._OBSSourceName = expObsSourceName.Expression;
            a._OBSJSONPayload = expObsJSONPayload.Expression;
            a._LSControlType = (Action.LiveSplitControlTypeEnum)cbxLsOpType.SelectedIndex;
            a._LSCustomPayload = expLSCustPayload.Expression;
            a._JsonOperationType = (Action.HTTPMethodEnum)cbxJsonType.SelectedIndex;
            a._JsonEndpointExpression = expJsonEndpoint.Expression;
            a._JsonFiringExpression = expJsonFiring.Expression;
            a._JsonHeaderExpression = expJsonHeaders.Expression;
            a._JsonPayloadExpression = expJsonPayload.Expression;
            a._JsonCacheRequest = cbxJsonCache.Checked;
            a._TextAuraOp = (Action.AuraOpEnum)cbxTextAuraOp.SelectedIndex;
            a._WmsgProcId = expWmsgProcid.Expression;
            a._WmsgTitle = expWmsgTitle.Expression;
            a._WmsgCode = expWmsgCode.Expression;
            a._WmsgWparam = expWmsgWparam.Expression;
            a._WmsgLparam = expWmsgLparam.Expression;
            switch (cbxTextAuraAlignment.SelectedIndex)
            {
                case 0:
                    a._TextAuraAlignment = Action.TextAuraAlignmentEnum.TopLeft;
                    break;
                case 1:
                    a._TextAuraAlignment = Action.TextAuraAlignmentEnum.TopCenter;
                    break;
                case 2:
                    a._TextAuraAlignment = Action.TextAuraAlignmentEnum.TopRight;
                    break;
                case 3:
                    a._TextAuraAlignment = Action.TextAuraAlignmentEnum.MiddleLeft;
                    break;
                case 4:
                    a._TextAuraAlignment = Action.TextAuraAlignmentEnum.MiddleCenter;
                    break;
                case 5:
                    a._TextAuraAlignment = Action.TextAuraAlignmentEnum.MiddleRight;
                    break;
                case 6:
                    a._TextAuraAlignment = Action.TextAuraAlignmentEnum.BottomLeft;
                    break;
                case 7:
                    a._TextAuraAlignment = Action.TextAuraAlignmentEnum.BottomCenter;
                    break;
                case 8:
                    a._TextAuraAlignment = Action.TextAuraAlignmentEnum.BottomRight;
                    break;
            }
            a._TextAuraName = expTextAuraName.Expression;
            a._TextAuraExpression = expTextAuraText.Expression;
            a._TextAuraXIniExpression = expTextAuraXIni.Expression;
            a._TextAuraYIniExpression = expTextAuraYIni.Expression;
            a._TextAuraWIniExpression = expTextAuraWIni.Expression;
            a._TextAuraHIniExpression = expTextAuraHIni.Expression;
            a._TextAuraOIniExpression = expTextAuraOIni.Expression;
            a._TextAuraXTickExpression = expTextAuraXTick.Expression;
            a._TextAuraYTickExpression = expTextAuraYTick.Expression;
            a._TextAuraWTickExpression = expTextAuraWTick.Expression;
            a._TextAuraHTickExpression = expTextAuraHTick.Expression;
            a._TextAuraOTickExpression = expTextAuraOTick.Expression;
            a._TextAuraTTLTickExpression = expTextAuraTTLTick.Expression;
            a._LogMessageText = expLogMessageText.Expression;
            a._LogLevel = (Action.LogMessageEnum)cbxLogMessageLevel.SelectedIndex;
            FontInfoContainer fic = (FontInfoContainer)txtTextAuraFont.Tag;
            a._TextAuraFontName = fic.Name;
            a._TextAuraFontSize = fic.Size;
            a._TextAuraEffect = fic.Effect;
            a._TextAuraForegroundClInt = colorSelector1.TextColor;
            a._TextAuraBackgroundClInt = colorSelector1.BackgroundColor;
            a._TextAuraOutlineClInt = colorSelector1.TextOutlineColor;
            a._TextAuraUseOutline = cbxTextAuraOutline.Checked;
            a.Condition = cndCondition.ConditionToEdit;
            a._KeypressType = (Action.KeypressTypeEnum)cbxKeypressMethod.SelectedIndex;
            a._KeyPressCode = expKeypress.Expression;
            a._KeyPressProcId = expKeypressProcId.Expression;
            a._KeyPressWindow = expWindowTitle.Expression;
            a._DiskFileOp = (Action.DiskFileOpEnum)cbxFileOpType.SelectedIndex;
            a._DiskFileOpName = expFileOpName.Expression;
            a._DiskFileOpVar = expFileOpVariable.Expression;
            a._DiskFileCache = cbxFileOpCache.Checked;
            a._TableVariableOp = (Action.TableVariableOpEnum)cbxTvarOpType.SelectedIndex;
            a._TableVariableExpressionType = (Action.TableVariableExpTypeEnum)cbxTvarExpType.SelectedIndex;
            a._TableVariableX = expTvarColumn.Expression;
            a._TableVariableName = expTvarName.Expression;
            a._TableVariableY = expTvarRow.Expression;
            a._TableVariableTarget = expTvarTarget.Expression;
            a._TableVariableExpression = expTvarValue.Expression;
            a._DictVariableOp = (Action.DictVariableOpEnum)cbxDictOpType.SelectedIndex;
            a._DictVariableKeyType = (Action.DictVariableExpTypeEnum)cbxDictKeyType.SelectedIndex;
            a._DictVariableValueType = (Action.DictVariableExpTypeEnum)cbxDictValueType.SelectedIndex;
            a._DictVariableLength = expDictLength.Expression;
            a._DictVariableKey = expDictKey.Expression;
            a._DictVariableValue = expDictValue.Expression;
            a._DictVariableName = expDictName.Expression;
            a._DictVariableTarget = expDictTarget.Expression;
            a._DictSourcePersist = prsDictSource.IsPersistent;
            a._DictTargetPersist = prsDictTarget.IsPersistent;
            a._MutexOpType = (Action.MutexOpEnum)cbxMutexOp.SelectedIndex;
            a._MutexName = expMutexName.Expression;
            a._Description = txtDescription.Text;
            a._DescriptionOverride = chkOverrideDesc.Checked;
            a._DescBgColor = expDescBgColor.Expression;
            a._DescTextColor = expDescTextColor.Expression;
            a._NamedCallbackName = expCallbackName.Expression;
            a._NamedCallbackParam = expCallbackParam.Expression;
            a._MouseOpType = (Action.MouseOpEnum)cbxMouseOp.SelectedIndex;
            a._MouseCoordType = (Action.MouseCoordEnum)cbxMouseCoord.SelectedIndex;
            a._MouseX = expMouseX.Expression;
            a._MouseY = expMouseY.Expression;
            a._DiskPersist = prsFileVariable.IsPersistent;
            a._ListSourcePersist = prsListSource.IsPersistent;
            a._ListTargetPersist = prsListTarget.IsPersistent;
            a._VariablePersist = prsScalarName.IsPersistent;
            a._JsonResultVariablePersist = prsJsonVariable.IsPersistent;
            a._VariableTargetPersist = prsScalarTarget.IsPersistent;
            a._TableSourcePersist = prsTableSource.IsPersistent;
            a._TableTargetPersist = prsTableTarget.IsPersistent;
            a.LoopCondition = cndLoopCondition.ConditionToEdit;
            a.LoopActions = new List<Action>();
            var ix = from tx in actionViewer1.Actions
                     orderby tx.OrderNumber ascending
                     select tx;
            a.LoopActions.AddRange(ix);
            a.LoopDelayExpression = expLoopIterationDelay.Expression;
            a.LoopIncrExpression = expLoopIncr.Expression;
            a.LoopInitExpression = expLoopInit.Expression;
            tn = trvRepositoryLink.SelectedNode;
            if (tn != null)
            {
                a._RepositoryId = ((Repository)tn.Tag).Id;
            }
            else
            {
                a._RepositoryId = Guid.Empty;
            }
            a._RepositoryOp = (Action.RepositoryOpEnum)cbxRepositoryOp.SelectedIndex;
            a._TriggerZoneType = (Action.TriggerZoneTypeEnum)cbxTriggerZoneType.SelectedIndex;
            a._JsonResultVariable = expJsonVariable.Expression;
        }

        private void TestAction(bool liveValues, bool ignoreConditions = false)
        {
            Action a = new Action();
            Context ctx = new Context();
            ctx.plug = plug;
            ctx.testmode = (liveValues == false);
            ctx.trig = null;
            ctx.soundhook = plug.SoundPlaybackSmart;
            ctx.ttshook = plug.TtsPlaybackSmart;
            SettingsToAction(a);
            if (ignoreConditions) { a.Condition = new ConditionGroup(); }
            ctx.triggered = DateTime.UtcNow;
            a.Execute(null, ctx);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                expProcessName.Expression = openFileDialog2.FileName;
            }
        }

        private void cbxVariableOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxVariableOp.SelectedIndex)
            {
                case (int)VariableOpEnum.Unset:
                    expVariableExpression.Enabled = false;
                    expVariableName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    break;
                case (int)VariableOpEnum.SetString:
                    expVariableExpression.Enabled = true;
                    expVariableName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    break;
                case (int)VariableOpEnum.SetNumeric:
                    expVariableExpression.Enabled = true;
                    expVariableName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    break;
                case (int)VariableOpEnum.Clipboard:
                    expVariableExpression.Enabled = true;
                    expVariableName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    break;
                case (int)VariableOpEnum.UnsetAll:
                    expVariableExpression.Enabled = false;
                    expVariableName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    break;
                case (int)VariableOpEnum.UnsetRegex:
                    expVariableExpression.Enabled = false;
                    expVariableName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.Regex;
                    break;
                case (int)VariableOpEnum.UnsetRegexUniversal:
                    expVariableExpression.Enabled = false;
                    expVariableName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.Regex;
                    break;
                case (int)VariableOpEnum.QueryJsonPath:
                    expVariableExpression.Enabled = true;
                    expVariableName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    break;
                case (int)VariableOpEnum.QueryJsonPathList:
                    expVariableExpression.Enabled = true;
                    expVariableName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    break;
            }
            expVariableName.Enabled = (cbxVariableOp.SelectedIndex != (int)VariableOpEnum.UnsetAll);
            prsScalarName.Enabled = (cbxVariableOp.SelectedIndex == (int)VariableOpEnum.UnsetAll)
                                  ? true : expVariableName.Enabled;
            expVariableTarget.Enabled = (cbxVariableOp.SelectedIndex == (int)VariableOpEnum.QueryJsonPath
                                      || cbxVariableOp.SelectedIndex == (int)VariableOpEnum.QueryJsonPathList);
            prsScalarTarget.Enabled = expVariableTarget.Enabled;

            expVariableExpression.ExpressionType = (cbxVariableOp.SelectedIndex == (int)VariableOpEnum.SetNumeric)
                                     ? ExpressionTextBox.SupportedExpressionTypeEnum.Numeric
                                     : ExpressionTextBox.SupportedExpressionTypeEnum.String;
            SetScalarHelperText(cbxVariableOp.SelectedIndex);
        }

        private void cbxTriggerOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            expTriggerText.Enabled = (cbxTriggerOp.SelectedIndex == 0 && cbxFiringOptions.CheckedIndices.Contains(0) == false);
            expTriggerZone.Enabled = (cbxTriggerOp.SelectedIndex == 0 && cbxFiringOptions.CheckedIndices.Contains(0) == false);
            cbxFiringOptions.Enabled = (cbxTriggerOp.SelectedIndex == 0);
            trvTrigger.Enabled = (cbxTriggerOp.SelectedIndex != 4);
        }

        private void cbxFiringOptions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            bool nv = cbxFiringOptions.CheckedIndices.Contains(0);
            if (e.Index == 0)
            {
                nv = e.NewValue == CheckState.Checked ? true : false;
            }
            expTriggerText.Enabled = (cbxTriggerOp.SelectedIndex == 0 && nv == false);
            expTriggerZone.Enabled = (cbxTriggerOp.SelectedIndex == 0 && nv == false);
        }

        private void trvTrigger_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag is Folder)
            {
                e.Cancel = true;
            }
        }

        private void trvTrigger_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag is Folder)
            {
                e.Node.ImageIndex = (int)CustomControls.UserInterface.GetImageIndexForClosedFolder((Folder)e.Node.Tag);
                e.Node.SelectedImageIndex = e.Node.ImageIndex;
            }
        }

        private void trvTrigger_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag is Folder)
            {
                e.Node.ImageIndex = (int)CustomControls.UserInterface.GetImageIndexForOpenFolder((Folder)e.Node.Tag);
                e.Node.SelectedImageIndex = e.Node.ImageIndex;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            TestActionPrepare(plug.cfg.TestLiveByDefault, plug.cfg.TestIgnoreConditionsByDefault);
        }

        private void TestActionPrepare(bool liveValues, bool ignoreConditions)
        {
            if (cbxActionType.SelectedIndex == (int)ActionTypeEnum.KeyPress && cbxKeypressMethod.SelectedIndex == 0)
            {
                MessageBox.Show(this, I18n.Translate("internal/ActionForm/confirmkeypress", "The keypresses you defined will be sent in two seconds after you hit OK, to allow you to change to the window you want to send the keypresses to."), I18n.Translate("internal/ActionForm/confirmkeypressdelay", "Confirm"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cbxActionType.SelectedIndex == (int)ActionTypeEnum.Aura)
            {
                if (cbxAuraOp.SelectedIndex == (int)AuraOpEnum.ActivateAura)
                {
                    timer1.Stop();
                    timer1.Tag = 0;
                    timer1.Start();
                }
            }
            TestAction(liveValues, ignoreConditions);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txtSendKeysLink.Text.ToString());
        }

        private void cbxAuraOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxAuraOp.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                    expAuraName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    break;
                case 3:
                    expAuraName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.Regex;
                    break;
            }
            btnBrowseAura.Enabled = (cbxAuraOp.SelectedIndex == 0);
            cbxAuraDisplay.Enabled = (cbxAuraOp.SelectedIndex == 0);
            expAuraImage.Enabled = (cbxAuraOp.SelectedIndex == 0);
            expAuraXIni.Enabled = (cbxAuraOp.SelectedIndex == 0);
            expAuraYIni.Enabled = (cbxAuraOp.SelectedIndex == 0);
            expAuraWIni.Enabled = (cbxAuraOp.SelectedIndex == 0);
            expAuraHIni.Enabled = (cbxAuraOp.SelectedIndex == 0);
            expAuraOIni.Enabled = (cbxAuraOp.SelectedIndex == 0);
            expAuraXTick.Enabled = (cbxAuraOp.SelectedIndex == 0);
            expAuraYTick.Enabled = (cbxAuraOp.SelectedIndex == 0);
            expAuraWTick.Enabled = (cbxAuraOp.SelectedIndex == 0);
            expAuraHTick.Enabled = (cbxAuraOp.SelectedIndex == 0);
            expAuraOTick.Enabled = (cbxAuraOp.SelectedIndex == 0);
            expAuraTTLTick.Enabled = (cbxAuraOp.SelectedIndex == 0);
            btnAuraGuide.Enabled = (cbxAuraOp.SelectedIndex == 0);
            expAuraName.Enabled = (cbxAuraOp.SelectedIndex != 2);
            btnHide.Enabled = (cbxAuraOp.SelectedIndex != 2);
        }

        private void expExecutionDelay_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                expAuraImage.Expression = openFileDialog3.FileName;
            }
        }

        private System.Drawing.Bitmap LoadImage(string fn)
        {
            byte[] buf = File.ReadAllBytes(fn);
            Bitmap bm = (Bitmap)ic.ConvertFrom(buf);
            if (bm != null && (bm.HorizontalResolution != (int)bm.HorizontalResolution || bm.VerticalResolution != (int)bm.VerticalResolution))
            {
                // Correct a strange glitch that has been observed in the test program when converting 
                //  from a PNG file image created by CopyImageToByteArray() - the dpi value "drifts" 
                //  slightly away from the nominal integer value
                bm.SetResolution((int)(bm.HorizontalResolution + 0.5f), (int)(bm.VerticalResolution + 0.5f));
            }
            return bm;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Context ctx = new Context();
            ctx.plug = plug;
            ctx.testmode = false;
            ctx.trig = null;
            ctx.triggered = DateTime.UtcNow;
            string fn = ctx.EvaluateStringExpression(null, null, expAuraImage.Expression);
            Bitmap ix;
            try
            {
                Image iix = AuraContainerForm.LoadImageData(plug, fn);
                ix = (Bitmap)iix;
            }
            catch (Exception)
            {
                MessageBox.Show(this, I18n.Translate("internal/ActionForm/imageloaderror", "The specific image file could not be loaded, please verify the path and filename."), I18n.Translate("internal/ActionForm/error", "Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (AuraDesignForm adf = new AuraDesignForm(AuraContainerForm.AuraTypeEnum.Image))
            {
                I18n.TranslateForm(adf);
                adf.SetImage(ix);
                switch (cbxAuraDisplay.SelectedIndex)
                {
                    case 0:
                        adf.SetImageMode(PictureBoxSizeMode.Normal);
                        break;
                    case 1:
                        adf.SetImageMode(PictureBoxSizeMode.StretchImage);
                        break;
                    case 2:
                        adf.SetImageMode(PictureBoxSizeMode.CenterImage);
                        break;
                    case 3:
                        adf.SetImageMode(PictureBoxSizeMode.Zoom);
                        break;
                }
                if (
                    (expAuraXIni.Expression.Length == 0)
                    ||
                    (expAuraYIni.Expression.Length == 0)
                    ||
                    (expAuraWIni.Expression.Length == 0)
                    ||
                    (expAuraHIni.Expression.Length == 0)
                )
                {
                    adf.StartPosition = FormStartPosition.CenterParent;
                }
                else
                {
                    adf.StartPosition = FormStartPosition.Manual;
                }
                int i = (int)Math.Round(ctx.EvaluateNumericExpression(null, null, expAuraXIni.Expression));
                adf.Left = i;
                i = (int)Math.Round(ctx.EvaluateNumericExpression(null, null, expAuraYIni.Expression));
                adf.Top = i;
                i = (int)Math.Round(ctx.EvaluateNumericExpression(null, null, expAuraWIni.Expression));
                adf.Width = i;
                i = (int)Math.Round(ctx.EvaluateNumericExpression(null, null, expAuraHIni.Expression));
                adf.Height = i;
                switch (adf.ShowDialog())
                {
                    case DialogResult.OK:
                        expAuraXIni.Expression = adf.Left.ToString();
                        expAuraYIni.Expression = adf.Top.ToString();
                        expAuraWIni.Expression = adf.Width.ToString();
                        expAuraHIni.Expression = adf.Height.ToString();
                        if (expAuraOIni.Expression.Length == 0)
                        {
                            expAuraOIni.Expression = "100";
                        }
                        switch (adf.GetImageDisplay())
                        {
                            case PictureBoxSizeMode.Normal:
                                cbxAuraDisplay.SelectedIndex = 0;
                                break;
                            case PictureBoxSizeMode.StretchImage:
                                cbxAuraDisplay.SelectedIndex = 1;
                                break;
                            case PictureBoxSizeMode.CenterImage:
                                cbxAuraDisplay.SelectedIndex = 2;
                                break;
                            case PictureBoxSizeMode.Zoom:
                                cbxAuraDisplay.SelectedIndex = 3;
                                break;
                        }
                        break;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Context ctx = new Context();
            ctx.plug = plug;
            ctx.testmode = true;
            ctx.trig = null;
            ctx.triggered = DateTime.UtcNow;
            using (AuraDesignForm adf = new AuraDesignForm(AuraContainerForm.AuraTypeEnum.Text))
            {
                I18n.TranslateForm(adf);
                adf.TextColor = colorSelector1.TextColor;
                adf.OutlineColor = colorSelector1.TextOutlineColor;
                adf.UseOutline = cbxTextAuraOutline.Checked;
                FontInfoContainer fic = (FontInfoContainer)txtTextAuraFont.Tag;
                FontStyle fs = FontStyle.Regular;
                if ((fic.Effect & Action.TextAuraEffectEnum.Bold) != 0)
                {
                    fs |= FontStyle.Bold;
                }
                if ((fic.Effect & Action.TextAuraEffectEnum.Italic) != 0)
                {
                    fs |= FontStyle.Italic;
                }
                if ((fic.Effect & Action.TextAuraEffectEnum.Underline) != 0)
                {
                    fs |= FontStyle.Underline;
                }
                if ((fic.Effect & Action.TextAuraEffectEnum.Strikeout) != 0)
                {
                    fs |= FontStyle.Strikeout;
                }
                using (Font fx = new Font(fic.Name, fic.Size, fs, GraphicsUnit.Point))
                {
                    adf.AuraFont = fx;
                    switch (cbxTextAuraAlignment.SelectedIndex)
                    {
                        case 0:
                            adf.TextAlignment = Action.TextAuraAlignmentEnum.TopLeft;
                            break;
                        case 1:
                            adf.TextAlignment = Action.TextAuraAlignmentEnum.TopCenter;
                            break;
                        case 2:
                            adf.TextAlignment = Action.TextAuraAlignmentEnum.TopRight;
                            break;
                        case 3:
                            adf.TextAlignment = Action.TextAuraAlignmentEnum.MiddleLeft;
                            break;
                        case 4:
                            adf.TextAlignment = Action.TextAuraAlignmentEnum.MiddleCenter;
                            break;
                        case 5:
                            adf.TextAlignment = Action.TextAuraAlignmentEnum.MiddleRight;
                            break;
                        case 6:
                            adf.TextAlignment = Action.TextAuraAlignmentEnum.BottomLeft;
                            break;
                        case 7:
                            adf.TextAlignment = Action.TextAuraAlignmentEnum.BottomCenter;
                            break;
                        case 8:
                            adf.TextAlignment = Action.TextAuraAlignmentEnum.BottomRight;
                            break;
                    }
                    if (
                        (expTextAuraXIni.Expression.Length == 0)
                        ||
                        (expTextAuraYIni.Expression.Length == 0)
                        ||
                        (expTextAuraWIni.Expression.Length == 0)
                        ||
                        (expTextAuraHIni.Expression.Length == 0)
                    )
                    {
                        adf.StartPosition = FormStartPosition.CenterParent;
                    }
                    else
                    {
                        adf.StartPosition = FormStartPosition.Manual;
                    }
                    int i = (int)Math.Round(ctx.EvaluateNumericExpression(null, null, expTextAuraXIni.Expression));
                    adf.Left = i;
                    i = (int)Math.Round(ctx.EvaluateNumericExpression(null, null, expTextAuraYIni.Expression));
                    adf.Top = i;
                    i = (int)Math.Round(ctx.EvaluateNumericExpression(null, null, expTextAuraWIni.Expression));
                    adf.Width = i;
                    i = (int)Math.Round(ctx.EvaluateNumericExpression(null, null, expTextAuraHIni.Expression));
                    adf.Height = i;
                    switch (adf.ShowDialog())
                    {
                        case DialogResult.OK:
                            expTextAuraXIni.Expression = adf.Left.ToString();
                            expTextAuraYIni.Expression = adf.Top.ToString();
                            expTextAuraWIni.Expression = adf.Width.ToString();
                            expTextAuraHIni.Expression = adf.Height.ToString();
                            if (expTextAuraOIni.Expression.Length == 0)
                            {
                                expTextAuraOIni.Expression = "100";
                            }
                            switch (adf.TextAlignment)
                            {
                                case Action.TextAuraAlignmentEnum.TopLeft:
                                    cbxTextAuraAlignment.SelectedIndex = 0;
                                    break;
                                case Action.TextAuraAlignmentEnum.TopCenter:
                                    cbxTextAuraAlignment.SelectedIndex = 1;
                                    break;
                                case Action.TextAuraAlignmentEnum.TopRight:
                                    cbxTextAuraAlignment.SelectedIndex = 2;
                                    break;
                                case Action.TextAuraAlignmentEnum.MiddleLeft:
                                    cbxTextAuraAlignment.SelectedIndex = 3;
                                    break;
                                case Action.TextAuraAlignmentEnum.MiddleCenter:
                                    cbxTextAuraAlignment.SelectedIndex = 4;
                                    break;
                                case Action.TextAuraAlignmentEnum.MiddleRight:
                                    cbxTextAuraAlignment.SelectedIndex = 5;
                                    break;
                                case Action.TextAuraAlignmentEnum.BottomLeft:
                                    cbxTextAuraAlignment.SelectedIndex = 6;
                                    break;
                                case Action.TextAuraAlignmentEnum.BottomCenter:
                                    cbxTextAuraAlignment.SelectedIndex = 7;
                                    break;
                                case Action.TextAuraAlignmentEnum.BottomRight:
                                    cbxTextAuraAlignment.SelectedIndex = 8;
                                    break;
                            }
                            break;
                    }
                }
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            Action a = new Action();
            Context ctx = new Context();
            ctx.plug = plug;
            ctx.testmode = true;
            ctx.trig = null;
            SettingsToAction(a);
            a.ActionType = Action.ActionTypeEnum.Aura;
            a._AuraOp = Action.AuraOpEnum.DeactivateAura;
            ctx.triggered = DateTime.UtcNow;
            a.Execute(null, ctx);
        }

        private void btnTextAuraHide_Click(object sender, EventArgs e)
        {
            Action a = new Action();
            Context ctx = new Context();
            ctx.plug = plug;
            ctx.testmode = true;
            ctx.trig = null;
            SettingsToAction(a);
            a.ActionType = Action.ActionTypeEnum.TextAura;
            a._AuraOp = Action.AuraOpEnum.DeactivateAura;
            ctx.triggered = DateTime.UtcNow;
            a.Execute(null, ctx);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int ex = (int)timer1.Tag;
            ex++;
            if ((ex >= 0 && ex < 10) || (ex >= 15 && ex < 25))
            {
                if ((ex % 2) == 0)
                {
                    btnHide.BackColor = SystemColors.Info;
                }
                else
                {
                    btnHide.BackColor = SystemColors.Control;
                }
            }
            if (ex >= 25)
            {
                btnHide.BackColor = SystemColors.Control;
                timer1.Stop();
            }
            timer1.Tag = ex;
        }

        private void trvFolder_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag is Folder)
            {
                e.Node.ImageIndex = (int)CustomControls.UserInterface.GetImageIndexForClosedFolder((Folder)e.Node.Tag);
                e.Node.SelectedImageIndex = e.Node.ImageIndex;
            }
        }

        private void trvFolder_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag is Folder)
            {
                e.Node.ImageIndex = (int)CustomControls.UserInterface.GetImageIndexForOpenFolder((Folder)e.Node.Tag);
                e.Node.SelectedImageIndex = e.Node.ImageIndex;
            }
        }

        private void trvFolder_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if ((e.Node.Tag is Folder) == false)
            {
                e.Cancel = true;
                return;
            }
            Folder f = (Folder)e.Node.Tag;
            if (f.Parent == null)
            {
                e.Cancel = true;
                return;
            }
            //plug.AddToLog(true, "Selected folder (" + f.Name + ") with id (" + f.Id + ")");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void cbxTextAuraOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxTextAuraOp.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                    expTextAuraName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    break;
                case 3:
                    expTextAuraName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.Regex;
                    break;
            }
            cbxTextAuraAlignment.Enabled = (cbxTextAuraOp.SelectedIndex == 0);
            expTextAuraText.Enabled = (cbxTextAuraOp.SelectedIndex == 0);
            expTextAuraXIni.Enabled = (cbxTextAuraOp.SelectedIndex == 0);
            expTextAuraYIni.Enabled = (cbxTextAuraOp.SelectedIndex == 0);
            expTextAuraWIni.Enabled = (cbxTextAuraOp.SelectedIndex == 0);
            expTextAuraHIni.Enabled = (cbxTextAuraOp.SelectedIndex == 0);
            expTextAuraOIni.Enabled = (cbxTextAuraOp.SelectedIndex == 0);
            btnTextAuraFont.Enabled = (cbxTextAuraOp.SelectedIndex == 0);
            expTextAuraXTick.Enabled = (cbxTextAuraOp.SelectedIndex == 0);
            expTextAuraYTick.Enabled = (cbxTextAuraOp.SelectedIndex == 0);
            expTextAuraWTick.Enabled = (cbxTextAuraOp.SelectedIndex == 0);
            expTextAuraHTick.Enabled = (cbxTextAuraOp.SelectedIndex == 0);
            expTextAuraOTick.Enabled = (cbxTextAuraOp.SelectedIndex == 0);
            expTextAuraTTLTick.Enabled = (cbxTextAuraOp.SelectedIndex == 0);
            colorSelector1.Enabled = (cbxTextAuraOp.SelectedIndex == 0);
            txtTextAuraFont.Enabled = (cbxTextAuraOp.SelectedIndex == 0);
            btnTextAuraGuide.Enabled = (cbxTextAuraOp.SelectedIndex == 0);
            cbxTextAuraOutline.Enabled = (cbxTextAuraOp.SelectedIndex == 0);
            expTextAuraName.Enabled = (cbxTextAuraOp.SelectedIndex != 2);
            btnTextAuraHide.Enabled = (cbxTextAuraOp.SelectedIndex != 2);
        }

        private void btnTextAuraFont_Click(object sender, EventArgs e)
        {
            FontInfoContainer fic = (FontInfoContainer)txtTextAuraFont.Tag;
            FontStyle fs = FontStyle.Regular;
            if ((fic.Effect & Action.TextAuraEffectEnum.Bold) != 0)
            {
                fs |= FontStyle.Bold;
            }
            if ((fic.Effect & Action.TextAuraEffectEnum.Italic) != 0)
            {
                fs |= FontStyle.Italic;
            }
            if ((fic.Effect & Action.TextAuraEffectEnum.Underline) != 0)
            {
                fs |= FontStyle.Underline;
            }
            if ((fic.Effect & Action.TextAuraEffectEnum.Strikeout) != 0)
            {
                fs |= FontStyle.Strikeout;
            }
            if (fic.Size < 1)
            {
                fic.Size = 1;
            }
            using (Font fx = new Font(fic.Name, fic.Size, fs, GraphicsUnit.Point))
            {
                fontDialog1.Font = fx;
                switch (fontDialog1.ShowDialog())
                {
                    case DialogResult.OK:
                        {
                            fic.Name = fontDialog1.Font.Name;
                            fic.Size = fontDialog1.Font.SizeInPoints;
                            Action.TextAuraEffectEnum ef = Action.TextAuraEffectEnum.None;
                            if (fontDialog1.Font.Bold == true)
                            {
                                ef |= Action.TextAuraEffectEnum.Bold;
                            }
                            if (fontDialog1.Font.Italic == true)
                            {
                                ef |= Action.TextAuraEffectEnum.Italic;
                            }
                            if (fontDialog1.Font.Strikeout == true)
                            {
                                ef |= Action.TextAuraEffectEnum.Strikeout;
                            }
                            if (fontDialog1.Font.Underline == true)
                            {
                                ef |= Action.TextAuraEffectEnum.Underline;
                            }
                            fic.Effect = ef;
                            UpdateFontDescription();
                        }
                        break;
                }
            }
        }

        private void cbxLvarExpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxLvarExpType.SelectedIndex)
            {
                case 0:
                    expLvarValue.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    break;
                case 1:
                    expLvarValue.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
                    break;
            }
        }

        private void cbxLvarOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxLvarOperation.SelectedIndex)
            {
                case (int)ListVariableOpEnum.Unset:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = false;
                    break;
                case (int)ListVariableOpEnum.Push:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = true;
                    cbxLvarExpType.Enabled = true;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = false;
                    break;
                case (int)ListVariableOpEnum.Insert:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = true;
                    cbxLvarExpType.Enabled = true;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = true;
                    break;
                case (int)ListVariableOpEnum.Set:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = true;
                    cbxLvarExpType.Enabled = true;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = true;
                    break;
                case (int)ListVariableOpEnum.SetAll:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = true;
                    cbxLvarExpType.Enabled = true;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = true;
                    break;
                case (int)ListVariableOpEnum.Remove:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = true;
                    break;
                case (int)ListVariableOpEnum.PopFirst:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = true;
                    expLvarIndex.Enabled = true;
                    break;
                case (int)ListVariableOpEnum.PopToListInsert:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = true;
                    cbxLvarExpType.SelectedIndex = 1; // numeric
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = true;
                    expLvarIndex.Enabled = true;
                    break;
                case (int)ListVariableOpEnum.PopToListSet:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = true;
                    cbxLvarExpType.SelectedIndex = 1; // numeric
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = true;
                    expLvarIndex.Enabled = true;
                    break;
                case (int)ListVariableOpEnum.PopLast:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = true;
                    expLvarIndex.Enabled = false;
                    break;
                case (int)ListVariableOpEnum.Build:
                    expLvarName.Enabled = false;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = true;
                    cbxLvarExpType.Enabled = true;
                    expLvarTarget.Enabled = true;
                    expLvarIndex.Enabled = false;
                    break;
                case (int)ListVariableOpEnum.Filter:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = true;
                    cbxLvarExpType.Enabled = false;
                    cbxLvarExpType.SelectedIndex = 1; // numeric
                    expLvarTarget.Enabled = true;
                    expLvarIndex.Enabled = false;
                    break;
                case (int)ListVariableOpEnum.Join:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = true;
                    cbxLvarExpType.Enabled = true;
                    expLvarTarget.Enabled = true;
                    expLvarIndex.Enabled = false;
                    break;
                case (int)ListVariableOpEnum.Split:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = true;
                    cbxLvarExpType.Enabled = true;
                    expLvarTarget.Enabled = true;
                    expLvarIndex.Enabled = false;
                    break;
                case (int)ListVariableOpEnum.Copy:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = true;
                    expLvarIndex.Enabled = false;
                    break;
                case (int)ListVariableOpEnum.InsertList:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = true;
                    expLvarIndex.Enabled = true;
                    break;
                case (int)ListVariableOpEnum.SortNumericAsc:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = false;
                    break;
                case (int)ListVariableOpEnum.SortNumericDesc:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = false;
                    break;
                case (int)ListVariableOpEnum.SortAlphaAsc:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = false;
                    break;
                case (int)ListVariableOpEnum.SortAlphaDesc:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = false;
                    break;
                case (int)ListVariableOpEnum.SortFfxivPartyAsc:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = false;
                    break;
                case (int)ListVariableOpEnum.SortFfxivPartyDesc:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = false;
                    break;
                case (int)ListVariableOpEnum.SortByKeys:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = true;
                    cbxLvarExpType.Enabled = false;
                    cbxLvarExpType.SelectedIndex = 0; // string
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = false;
                    break;
                case (int)ListVariableOpEnum.UnsetAll:
                    expLvarName.Enabled = false;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = false;
                    break;
                case (int)ListVariableOpEnum.UnsetRegex:
                    expLvarName.Enabled = true;
                    expLvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.Regex;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = false;
                    break;
            }
            prsListSource.Enabled = (cbxLvarOperation.SelectedIndex == (int)ListVariableOpEnum.UnsetAll)
                                  ? true : expLvarName.Enabled;
            prsListTarget.Enabled = expLvarTarget.Enabled;
            lblLvarValue.Text = (cbxLvarOperation.SelectedIndex != (int)ListVariableOpEnum.PopToListInsert
                              && cbxLvarOperation.SelectedIndex != (int)ListVariableOpEnum.PopToListSet)
                              ? I18n.Translate("ActionForm/lblLvarValue", "Expression")
                              : I18n.Translate("ActionForm/lblLvarValueTgtIndex", "Target Index");
            SetListHelperText(cbxLvarOperation.SelectedIndex);
        }

        private void expVariableName_EnabledChanged(object sender, EventArgs e)
        {
            lblVariableName.Enabled = expVariableName.Enabled;
        }

        private void expVariableExpression_EnabledChanged(object sender, EventArgs e)
        {
            lblVariableExpression.Enabled = expVariableExpression.Enabled;
        }

        private void expTriggerText_EnabledChanged(object sender, EventArgs e)
        {
            lblTriggerText.Enabled = expTriggerText.Enabled;
        }

        private void expTriggerZone_EnabledChanged(object sender, EventArgs e)
        {
            lblTriggerZone.Enabled = expTriggerZone.Enabled;
        }

        private void cbxFiringOptions_EnabledChanged(object sender, EventArgs e)
        {
            lblFiringOptions.Enabled = cbxFiringOptions.Enabled;
        }

        private void trvTrigger_EnabledChanged(object sender, EventArgs e)
        {
            lblTrigger.Enabled = trvTrigger.Enabled;
        }

        private void cbxFolderOp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void expLvarName_EnabledChanged(object sender, EventArgs e)
        {
            lblLvarName.Enabled = expLvarName.Enabled;
        }

        private void cbxLvarExpType_EnabledChanged(object sender, EventArgs e)
        {
            lblLvarExpType.Enabled = cbxLvarExpType.Enabled;
        }

        private void expLvarValue_EnabledChanged(object sender, EventArgs e)
        {
            lblLvarValue.Enabled = expLvarValue.Enabled;
        }

        private void expLvarIndex_EnabledChanged(object sender, EventArgs e)
        {
            lblLvarIndex.Enabled = expLvarIndex.Enabled;
        }

        private void expLvarTarget_EnabledChanged(object sender, EventArgs e)
        {
            lblLvarTarget.Enabled = expLvarTarget.Enabled;
        }

        private void expTextAuraName_EnabledChanged(object sender, EventArgs e)
        {
            lblTextAuraName.Enabled = expTextAuraName.Enabled;
        }

        private void expTextAuraText_EnabledChanged(object sender, EventArgs e)
        {
            lblTextAuraText.Enabled = expTextAuraText.Enabled;
        }

        private void colorSelector1_EnabledChanged(object sender, EventArgs e)
        {
            lblTextAuraFont.Enabled = colorSelector1.Enabled;
        }

        private void cbxTextAuraAlignment_EnabledChanged(object sender, EventArgs e)
        {
            lblTextAuraAlignment.Enabled = cbxTextAuraAlignment.Enabled;
        }

        private void cbxTextAuraOutline_EnabledChanged(object sender, EventArgs e)
        {
            lblTextAuraOutline.Enabled = cbxTextAuraOutline.Enabled;
        }

        private void expTextAuraXTick_EnabledChanged(object sender, EventArgs e)
        {
            lblTextAuraX.Enabled = expTextAuraXTick.Enabled;
        }

        private void expTextAuraYTick_EnabledChanged(object sender, EventArgs e)
        {
            lblTextAuraY.Enabled = expTextAuraYTick.Enabled;
        }

        private void expTextAuraWTick_EnabledChanged(object sender, EventArgs e)
        {
            lblTextAuraWidth.Enabled = expTextAuraWTick.Enabled;
        }

        private void expTextAuraHTick_EnabledChanged(object sender, EventArgs e)
        {
            lblTextAuraHeight.Enabled = expTextAuraHTick.Enabled;
        }

        private void expTextAuraOTick_EnabledChanged(object sender, EventArgs e)
        {
            lblTextAuraOpacity.Enabled = expTextAuraOTick.Enabled;
        }

        private void expTextAuraTTLTick_EnabledChanged(object sender, EventArgs e)
        {
            lblTextAuraTtlExp.Enabled = expTextAuraTTLTick.Enabled;
        }

        private void expAuraName_EnabledChanged(object sender, EventArgs e)
        {
            lblAuraName.Enabled = expAuraName.Enabled;
        }

        private void expAuraImage_EnabledChanged(object sender, EventArgs e)
        {
            lblAuraImage.Enabled = expAuraImage.Enabled;
        }

        private void cbxAuraDisplay_EnabledChanged(object sender, EventArgs e)
        {
            lblAuraDisplay.Enabled = cbxAuraDisplay.Enabled;
        }

        private void expAuraXTick_EnabledChanged(object sender, EventArgs e)
        {
            lblAuraX.Enabled = expAuraXTick.Enabled;
        }

        private void expAuraYTick_EnabledChanged(object sender, EventArgs e)
        {
            lblAuraY.Enabled = expAuraYTick.Enabled;
        }

        private void expAuraWTick_EnabledChanged(object sender, EventArgs e)
        {
            lblAuraWidth.Enabled = expAuraWTick.Enabled;
        }

        private void expAuraHTick_EnabledChanged(object sender, EventArgs e)
        {
            lblAuraHeight.Enabled = expAuraHTick.Enabled;
        }

        private void expAuraOTick_EnabledChanged(object sender, EventArgs e)
        {
            lblAuraOpacity.Enabled = expAuraOTick.Enabled;
        }

        private void expAuraTTLTick_EnabledChanged(object sender, EventArgs e)
        {
            lblAuraTtl.Enabled = expAuraTTLTick.Enabled;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txtObsWebsocketLink.Text.ToString());
        }

        private void cbxObsOpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            expObsSceneName.Enabled = (cbxObsOpType.SelectedIndex >= 15 && cbxObsOpType.SelectedIndex <= 17);
            expObsSourceName.Enabled = (cbxObsOpType.SelectedIndex >= 16 && cbxObsOpType.SelectedIndex <= 17);
            expObsJSONPayload.Enabled = (cbxObsOpType.SelectedIndex >= 18);
        }

        private void cbxLsOpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            expLSCustPayload.Enabled = (cbxLsOpType.SelectedIndex == cbxLsOpType.Items.Count - 1);
            lblLsCustPayload.Enabled = expLSCustPayload.Enabled;
        }

        private void cbxKeypressMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblKeypresses.Enabled = (cbxKeypressMethod.SelectedIndex == 0);
            expKeypresses.Enabled = (cbxKeypressMethod.SelectedIndex == 0);
            lblKeypressesInfo.Enabled = (cbxKeypressMethod.SelectedIndex == 0);
            txtSendKeysLink.Enabled = (cbxKeypressMethod.SelectedIndex == 0);
            btnSendKeysLink.Enabled = (cbxKeypressMethod.SelectedIndex == 0);
            btnSendKeysListen.Enabled = (cbxKeypressMethod.SelectedIndex == 0);
            lblKeypressWindow.Enabled = (cbxKeypressMethod.SelectedIndex >= 1);
            expWindowTitle.Enabled = (cbxKeypressMethod.SelectedIndex >= 1);
            lblKeypress.Enabled = (cbxKeypressMethod.SelectedIndex >= 1);
            expKeypress.Enabled = (cbxKeypressMethod.SelectedIndex >= 1);
            lblKeypressInfo.Enabled = (cbxKeypressMethod.SelectedIndex >= 1);
            txtKeyCodesLink.Enabled = (cbxKeypressMethod.SelectedIndex >= 1);
            btnKeycodesLink.Enabled = (cbxKeypressMethod.SelectedIndex >= 1);
            btnKeycodesListen.Enabled = (cbxKeypressMethod.SelectedIndex >= 1);
            lblKeypressProcId.Enabled = (cbxKeypressMethod.SelectedIndex >= 1);
            expKeypressProcId.Enabled = (cbxKeypressMethod.SelectedIndex >= 1);
            lblKeypressProcInfo.Enabled = (cbxKeypressMethod.SelectedIndex >= 1);
            switch (cbxKeypressMethod.SelectedIndex)
            {
                case 0:
                    expKeypress.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
                    break;
                case 1:
                    expKeypress.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
                    break;
                case 2:
                    expKeypress.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    break;
            }
        }

        private void btnKeycodesLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txtKeyCodesLink.Text.ToString());
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            tlsMouseLocation.Text = String.Format("X: {0}, Y: {1}",
                Cursor.Position.X.ToString(CultureInfo.InvariantCulture),
                Cursor.Position.Y.ToString(CultureInfo.InvariantCulture)
            );
        }

        private void cbxTvarExpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxTvarExpType.SelectedIndex)
            {
                case 0:
                    expTvarValue.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    break;
                case 1:
                    expTvarValue.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
                    break;
            }
        }

        private void expObsSceneName_EnabledChanged(object sender, EventArgs e)
        {
            lblObsSceneName.Enabled = expObsSceneName.Enabled;
        }

        private void expObsSourceName_EnabledChanged(object sender, EventArgs e)
        {
            lblObsSourceName.Enabled = expObsSourceName.Enabled;
        }

        private void expObsJSONPayload_EnabledChanged(object sender, EventArgs e)
        {
            lblObsJSONPayload.Enabled = expObsJSONPayload.Enabled;
        }

        private void cbxTvarOpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxTvarOpType.SelectedIndex)
            {
                case (int)TableVariableOpEnum.Unset:
                    expTvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expTvarName.Enabled = true;
                    cbxTvarExpType.Enabled = false;
                    expTvarValue.Enabled = false;
                    expTvarColumn.Enabled = false;
                    expTvarRow.Enabled = false;
                    expTvarTarget.Enabled = false;
                    break;
                case (int)TableVariableOpEnum.Set:
                    expTvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expTvarName.Enabled = true;
                    cbxTvarExpType.Enabled = true;
                    expTvarValue.Enabled = true;
                    expTvarColumn.Enabled = true;
                    expTvarRow.Enabled = true;
                    expTvarTarget.Enabled = false;
                    break;
                case (int)TableVariableOpEnum.SetAll:
                    expTvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expTvarName.Enabled = true;
                    cbxTvarExpType.Enabled = true;
                    expTvarValue.Enabled = true;
                    expTvarColumn.Enabled = true;
                    expTvarRow.Enabled = true;
                    expTvarTarget.Enabled = false;
                    break;
                case (int)TableVariableOpEnum.SlicesSetAll:
                    expTvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expTvarName.Enabled = true;
                    cbxTvarExpType.Enabled = true;
                    expTvarValue.Enabled = true;
                    expTvarColumn.Enabled = true;
                    expTvarRow.Enabled = true;
                    expTvarTarget.Enabled = false;
                    break;
                case (int)TableVariableOpEnum.Resize:
                    expTvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expTvarName.Enabled = true;
                    cbxTvarExpType.Enabled = false;
                    expTvarValue.Enabled = false;
                    expTvarColumn.Enabled = true;
                    expTvarRow.Enabled = true;
                    expTvarTarget.Enabled = false;
                    break;
                case (int)TableVariableOpEnum.Build:
                    expTvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expTvarName.Enabled = false;
                    cbxTvarExpType.Enabled = true;
                    expTvarValue.Enabled = true;
                    expTvarColumn.Enabled = false;
                    expTvarRow.Enabled = false;
                    expTvarTarget.Enabled = true;
                    break;
                case (int)TableVariableOpEnum.SetLine:
                    expTvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expTvarName.Enabled = true;
                    cbxTvarExpType.Enabled = true;
                    expTvarValue.Enabled = true;
                    expTvarColumn.Enabled = true;
                    expTvarRow.Enabled = true;
                    expTvarTarget.Enabled = false;
                    break;
                case (int)TableVariableOpEnum.InsertLine:
                    expTvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expTvarName.Enabled = true;
                    cbxTvarExpType.Enabled = true;
                    expTvarValue.Enabled = true;
                    expTvarColumn.Enabled = true;
                    expTvarRow.Enabled = true;
                    expTvarTarget.Enabled = false;
                    break;
                case (int)TableVariableOpEnum.RemoveLine:
                    expTvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expTvarName.Enabled = true;
                    cbxTvarExpType.Enabled = false;
                    expTvarValue.Enabled = false;
                    expTvarColumn.Enabled = true;
                    expTvarRow.Enabled = true;
                    expTvarTarget.Enabled = false;
                    break;
                case (int)TableVariableOpEnum.Filter:
                    expTvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expTvarName.Enabled = true;
                    cbxTvarExpType.Enabled = false;
                    cbxTvarExpType.SelectedIndex = 1; // numeric
                    expTvarValue.Enabled = true;
                    expTvarColumn.Enabled = false;
                    expTvarRow.Enabled = false;
                    expTvarTarget.Enabled = true;
                    break;
                case (int)TableVariableOpEnum.FilterLine:
                    expTvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expTvarName.Enabled = true;
                    cbxTvarExpType.Enabled = false;
                    expTvarValue.Enabled = false;
                    expTvarColumn.Enabled = true;
                    expTvarRow.Enabled = true;
                    expTvarTarget.Enabled = true;
                    break;
                case (int)TableVariableOpEnum.Copy:
                    expTvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expTvarName.Enabled = true;
                    cbxTvarExpType.Enabled = false;
                    expTvarValue.Enabled = false;
                    expTvarColumn.Enabled = false;
                    expTvarRow.Enabled = false;
                    expTvarTarget.Enabled = true;
                    break;
                case (int)TableVariableOpEnum.Append:
                    expTvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expTvarName.Enabled = true;
                    cbxTvarExpType.Enabled = false;
                    expTvarValue.Enabled = false;
                    expTvarColumn.Enabled = false;
                    expTvarRow.Enabled = false;
                    expTvarTarget.Enabled = true;
                    break;
                case (int)TableVariableOpEnum.SortLine:
                    expTvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expTvarName.Enabled = true;
                    cbxTvarExpType.Enabled = false;
                    expTvarValue.Enabled = false;
                    expTvarColumn.Enabled = true;   // set to numeric after switch-case
                    expTvarRow.Enabled = true;      // set to numeric after switch-case
                    expTvarTarget.Enabled = false;
                    break;
                case (int)TableVariableOpEnum.UnsetAll:
                    expTvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expTvarName.Enabled = false;
                    cbxTvarExpType.Enabled = false;
                    expTvarValue.Enabled = false;
                    expTvarColumn.Enabled = false;
                    expTvarRow.Enabled = false;
                    expTvarTarget.Enabled = false;
                    break;
                case (int)TableVariableOpEnum.UnsetRegex:
                    expTvarName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.Regex;
                    expTvarName.Enabled = true;
                    cbxTvarExpType.Enabled = false;
                    expTvarValue.Enabled = false;
                    expTvarColumn.Enabled = false;
                    expTvarRow.Enabled = false;
                    expTvarTarget.Enabled = false;
                    break;
            }
            expTvarColumn.ExpressionType = (cbxTvarOpType.SelectedIndex == (int)TableVariableOpEnum.SortLine
                                         || cbxTvarOpType.SelectedIndex == (int)TableVariableOpEnum.SlicesSetAll)
                                         ? ExpressionTextBox.SupportedExpressionTypeEnum.String
                                         : ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
            expTvarRow.ExpressionType = expTvarColumn.ExpressionType;
            prsTableSource.Enabled = (cbxTvarOpType.SelectedIndex == (int)TableVariableOpEnum.UnsetAll)
                                   ? true : expTvarName.Enabled;
            prsTableTarget.Enabled = expTvarTarget.Enabled;
            SetTableHelperText(cbxTvarOpType.SelectedIndex);
        }

        private void expTvarName_EnabledChanged(object sender, EventArgs e)
        {
            lblTvarName.Enabled = expTvarName.Enabled;
        }

        private void cbxTvarExpType_EnabledChanged(object sender, EventArgs e)
        {
            lblTvarExpType.Enabled = cbxTvarExpType.Enabled;
        }

        private void expTvarValue_EnabledChanged(object sender, EventArgs e)
        {
            lblTvarValue.Enabled = expTvarValue.Enabled;
        }

        private void expTvarColumn_EnabledChanged(object sender, EventArgs e)
        {
            lblTvarColumn.Enabled = expTvarColumn.Enabled;
        }

        private void expTvarRow_EnabledChanged(object sender, EventArgs e)
        {
            lblTvarRow.Enabled = expTvarRow.Enabled;
        }

        private void expTvarTarget_EnabledChanged(object sender, EventArgs e)
        {
            lblTvarTarget.Enabled = expTvarTarget.Enabled;
        }

        private void cbxDictKeyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxDictKeyType.SelectedIndex)
            {
                case 0:
                    expDictKey.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    break;
                case 1:
                    expDictKey.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
                    break;
            }
        }

        private void cbxDictValueType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxDictValueType.SelectedIndex)
            {
                case 0:
                    expDictValue.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    break;
                case 1:
                    expDictValue.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
                    break;
            }
        }

        private void cbxDictOpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxDictOpType.SelectedIndex)
            {
                case (int)DictVariableOpEnum.Unset:
                    expDictName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expDictName.Enabled = true;
                    expDictLength.Enabled = false;
                    cbxDictKeyType.Enabled = false;
                    expDictKey.Enabled = false;
                    cbxDictValueType.Enabled = false;
                    expDictValue.Enabled = false;
                    expDictTarget.Enabled = false;
                    break;
                case (int)DictVariableOpEnum.Set:
                    expDictName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expDictName.Enabled = true;
                    expDictLength.Enabled = false;
                    cbxDictKeyType.Enabled = true;
                    expDictKey.Enabled = true;
                    cbxDictValueType.Enabled = true;
                    expDictValue.Enabled = true;
                    expDictTarget.Enabled = false;
                    break;
                case (int)DictVariableOpEnum.Remove:
                    expDictName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expDictName.Enabled = true;
                    expDictLength.Enabled = false;
                    cbxDictKeyType.Enabled = true;
                    expDictKey.Enabled = true;
                    cbxDictValueType.Enabled = false;
                    expDictValue.Enabled = false;
                    expDictTarget.Enabled = false;
                    break;
                case (int)DictVariableOpEnum.SetAll:
                    expDictName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expDictName.Enabled = true;
                    expDictLength.Enabled = true;
                    cbxDictKeyType.Enabled = true;
                    expDictKey.Enabled = true;
                    cbxDictValueType.Enabled = true;
                    expDictValue.Enabled = true;
                    expDictTarget.Enabled = false;
                    break;
                case (int)DictVariableOpEnum.Build:
                    expDictName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expDictName.Enabled = false;
                    expDictLength.Enabled = false;
                    cbxDictKeyType.Enabled = false;
                    expDictKey.Enabled = false;
                    cbxDictValueType.Enabled = true;
                    expDictValue.Enabled = true;
                    expDictTarget.Enabled = true;
                    break;
                case (int)DictVariableOpEnum.Filter:
                    expDictName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expDictName.Enabled = true;
                    expDictLength.Enabled = false;
                    cbxDictKeyType.Enabled = false;
                    expDictKey.Enabled = false;
                    cbxDictValueType.Enabled = false;
                    cbxDictValueType.SelectedIndex = 1; // numeric
                    expDictValue.Enabled = true;
                    expDictTarget.Enabled = true;
                    break;
                case (int)DictVariableOpEnum.Merge:
                    expDictName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expDictName.Enabled = true;
                    expDictLength.Enabled = false;
                    cbxDictKeyType.Enabled = false;
                    expDictKey.Enabled = false;
                    cbxDictValueType.Enabled = false;
                    expDictValue.Enabled = false;
                    expDictTarget.Enabled = true;
                    break;
                case (int)DictVariableOpEnum.MergeHard:
                    expDictName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expDictName.Enabled = true;
                    expDictLength.Enabled = false;
                    cbxDictKeyType.Enabled = false;
                    expDictKey.Enabled = false;
                    cbxDictValueType.Enabled = false;
                    expDictValue.Enabled = false;
                    expDictTarget.Enabled = true;
                    break;
                case (int)DictVariableOpEnum.UnsetAll:
                    expDictName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    expDictName.Enabled = false;
                    expDictLength.Enabled = false;
                    cbxDictKeyType.Enabled = false;
                    expDictKey.Enabled = false;
                    cbxDictValueType.Enabled = false;
                    expDictValue.Enabled = false;
                    expDictTarget.Enabled = false;
                    break;
                case (int)DictVariableOpEnum.UnsetRegex:
                    expDictName.ExpressionType = ExpressionTextBox.SupportedExpressionTypeEnum.Regex;
                    expDictName.Enabled = true;
                    expDictLength.Enabled = false;
                    cbxDictKeyType.Enabled = false;
                    expDictKey.Enabled = false;
                    cbxDictValueType.Enabled = false;
                    expDictValue.Enabled = false;
                    expDictTarget.Enabled = false;
                    break;
            }
            prsDictSource.Enabled = (cbxDictOpType.SelectedIndex == (int)DictVariableOpEnum.UnsetAll)
                                  ? true : expDictName.Enabled;
            expDictName.IsPersistent = prsDictSource.IsPersistent;
            prsDictTarget.Enabled = expDictTarget.Enabled;
            SetDictHelperText(cbxDictOpType.SelectedIndex);
        }

        private void expDictName_EnabledChanged(object sender, EventArgs e)
        {
            lblDictName.Enabled = expDictName.Enabled;
        }

        private void expDictLength_EnabledChanged(object sender, EventArgs e)
        {
            lblDictLength.Enabled = expDictLength.Enabled;
        }

        private void cbxDictKeyType_EnabledChanged(object sender, EventArgs e)
        {
            lblDictKeyType.Enabled = cbxDictKeyType.Enabled;
        }

        private void expDictKey_EnabledChanged(object sender, EventArgs e)
        {
            lblDictKey.Enabled = expDictKey.Enabled;
        }

        private void cbxDictValueType_EnabledChanged(object sender, EventArgs e)
        {
            lblDictValueType.Enabled = cbxDictValueType.Enabled;
        }

        private void expDictValue_EnabledChanged(object sender, EventArgs e)
        {
            lblDictValue.Enabled = expDictValue.Enabled;
        }

        private void expDictTarget_EnabledChanged(object sender, EventArgs e)
        {
            lblDictTarget.Enabled = expDictTarget.Enabled;
        }


        private void cbxJsonType_SelectedIndexChanged(object sender, EventArgs e)
        {
            expJsonPayload.Enabled = (cbxJsonType.SelectedIndex == 0);
        }

        private void cbxProcessLog_CheckedChanged(object sender, EventArgs e)
        {
            cbxLogMessageTarget.Enabled = cbxProcessLog.Checked;
            lblLogMessageTarget.Enabled = cbxLogMessageTarget.Enabled;
            cbxLogMessageLevel.Enabled = (cbxLogMessageTarget.Enabled == false);
            lblLogMessageLevel.Enabled = cbxLogMessageLevel.Enabled;
        }

        private void btnScriptExternalEditor_Click(object sender, EventArgs e)
        {
            try
            {
                string code = expExecScriptCode.Expression;
                EditorTempFn = Path.GetTempFileName() + ".cs";
                File.WriteAllText(EditorTempFn, code);
                ExtEditor = new Process();
                ExtEditor.StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    FileName = EditorTempFn
                };
                ExtEditor.EnableRaisingEvents = true;
                ExtEditor.Exited += P_Exited;
                ExtEditor.Start();
                btnScriptExternalEditor.Enabled = false;
                expExecScriptCode.Enabled = false;
                lblScriptExtEditor.Visible = true;
            }
            catch (Exception ex)
            {
                plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/ActionForm/exteditorfailed", "Couldn't launch external editor due to exception: {0}", ex.Message));
            }
        }

        private void P_Exited(object sender, EventArgs e)
        {
            try
            {
                expExecScriptCode.Expression = File.ReadAllText(EditorTempFn);
                File.Delete(EditorTempFn);
            }
            catch (Exception ex)
            {
                plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/ActionForm/tempfiledeletefailed", "Couldn't process temporary file {0} due to exception: {1}", EditorTempFn, ex.Message));
            }
            btnScriptExternalEditor.Enabled = true;
            expExecScriptCode.Enabled = true;
            lblScriptExtEditor.Visible = false;
            ExtEditor.Dispose();
            ExtEditor = null;
        }

        private void cbxRepositoryOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            trvRepositoryLink.Enabled = (cbxRepositoryOp.SelectedIndex == 1);
        }

        private void trvRepositoryLink_EnabledChanged(object sender, EventArgs e)
        {
            lblRepositoryLink.Enabled = trvRepositoryLink.Enabled;
        }

        private void trvRepositoryLink_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if ((e.Node.Tag is Repository) == false)
            {
                e.Cancel = true;
            }
        }

        private void trvRepositoryLink_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag is Folder)
            {
                e.Node.ImageIndex = (int)CustomControls.UserInterface.GetImageIndexForClosedFolder((Folder)e.Node.Tag);
                e.Node.SelectedImageIndex = e.Node.ImageIndex;
            }
        }

        private void trvRepositoryLink_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag is Folder)
            {
                e.Node.ImageIndex = (int)CustomControls.UserInterface.GetImageIndexForOpenFolder((Folder)e.Node.Tag);
                e.Node.SelectedImageIndex = e.Node.ImageIndex;
            }
        }

        private void cbxZoneType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTriggerZoneType.SelectedIndex == 0)
            {
                lblTriggerZone.Text = I18n.Translate("TestInputForm/lblZoneName", "Zone name");
            }
            else
            {
                lblTriggerZone.Text = I18n.Translate("TestInputForm/ffxivzoneid", "Zone ID");
            }
        }

        private void btnSendKeysListen_Click(object sender, EventArgs e)
        {
            ListenToKeypresses(true);
        }

        private void btnKeycodesListen_Click(object sender, EventArgs e)
        {
            ListenToKeypresses(false);
        }

        private void ListenToKeypresses(bool isSendKeys)
        {
            Keys keyData = Keys.None;
            string keyRep = "";
            using (KeyListenForm klf = new KeyListenForm())
            {
                if (klf.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                keyData = klf.CurrentKey;
            }
            if (keyData != Keys.None)
            {
                if (isSendKeys == false)
                {
                    keyRep = ((int)keyData).ToString();
                }
                else
                {
                    if ((keyData & Keys.Control) != Keys.None)
                    {
                        keyRep += "^";
                    }
                    if ((keyData & Keys.Shift) != Keys.None)
                    {
                        keyRep += "+";
                    }
                    if ((keyData & Keys.Alt) != Keys.None)
                    {
                        keyRep += "%";
                    }
                    Keys keyCode = keyData & Keys.KeyCode;
                    switch (keyCode)
                    {
                        case Keys.Back: keyRep += "{BS}"; break;
                        case Keys.CapsLock: keyRep += "{CAPSLOCK}"; break;
                        case Keys.Delete: keyRep += "{DEL}"; break;
                        case Keys.Down: keyRep += "{DOWN}"; break;
                        case Keys.End: keyRep += "{END}"; break;
                        case Keys.Enter: keyRep += "{ENTER}"; break;
                        case Keys.Escape: keyRep += "{ESC}"; break;
                        case Keys.Help: keyRep += "{HELP}"; break;
                        case Keys.Home: keyRep += "{HOME}"; break;
                        case Keys.Insert: keyRep += "{INS}"; break;
                        case Keys.Left: keyRep += "{LEFT}"; break;
                        case Keys.NumLock: keyRep += "{NUMLOCK}"; break;
                        case Keys.PageDown: keyRep += "{PGDN}"; break;
                        case Keys.PageUp: keyRep += "{PGUP}"; break;
                        case Keys.PrintScreen: keyRep += "{PRTSC}"; break;
                        case Keys.Right: keyRep += "{RIGHT}"; break;
                        case Keys.Scroll: keyRep += "{SCROLLLOCK}"; break;
                        case Keys.Tab: keyRep += "{TAB}"; break;
                        case Keys.Up: keyRep += "{UP}"; break;
                        case Keys.F1: keyRep += "{F1}"; break;
                        case Keys.F2: keyRep += "{F2}"; break;
                        case Keys.F3: keyRep += "{F3}"; break;
                        case Keys.F4: keyRep += "{F4}"; break;
                        case Keys.F5: keyRep += "{F5}"; break;
                        case Keys.F6: keyRep += "{F6}"; break;
                        case Keys.F7: keyRep += "{F7}"; break;
                        case Keys.F8: keyRep += "{F8}"; break;
                        case Keys.F9: keyRep += "{F9}"; break;
                        case Keys.F10: keyRep += "{F10}"; break;
                        case Keys.F11: keyRep += "{F11}"; break;
                        case Keys.F12: keyRep += "{F12}"; break;
                        case Keys.F13: keyRep += "{F13}"; break;
                        case Keys.F14: keyRep += "{F14}"; break;
                        case Keys.F15: keyRep += "{F15}"; break;
                        case Keys.F16: keyRep += "{F16}"; break;
                        case Keys.Add: keyRep += "{ADD}"; break;
                        case Keys.Subtract: keyRep += "{SUBTRACT}"; break;
                        case Keys.Multiply: keyRep += "{MULTIPLY}"; break;
                        case Keys.Divide: keyRep += "{DIVIDE}"; break;
                        default: keyRep += keyCode != Keys.None ? keyCode.ToString() : ""; break;
                    }
                }
            }
            if (isSendKeys == true)
            {
                expKeypresses.Expression = keyRep;
            }
            else
            {
                expKeypress.Expression = keyRep;
            }
        }


        #region Helper Text

        private void SetScalarHelperText(int cbxOpIndex)
        {
            string enumName = Enum.GetName(typeof(VariableOpEnum), cbxOpIndex);
            if (enumName != null)
            {
                string key = "ActionForm/helpVar" + enumName;
                string textEN = "";
                switch (cbxOpIndex)
                {
                    case (int)VariableOpEnum.Unset: textEN = ""; break;
                    case (int)VariableOpEnum.SetString: textEN = ""; break;
                    case (int)VariableOpEnum.SetNumeric: textEN = ""; break;
                    case (int)VariableOpEnum.Clipboard: textEN = ""; break;
                    case (int)VariableOpEnum.UnsetAll: textEN = ""; break;
                    case (int)VariableOpEnum.UnsetRegex: textEN = ""; break;
                    case (int)VariableOpEnum.UnsetRegexUniversal: textEN = ""; break;
                    case (int)VariableOpEnum.QueryJsonPath: textEN = ""; break;
                    case (int)VariableOpEnum.QueryJsonPathList: textEN = ""; break;
                }
                lblVariableHelper.Text = I18n.Translate(key, textEN);
            }
        }

        private void SetListHelperText(int cbxOpIndex)
        {
            string enumName = Enum.GetName(typeof(ListVariableOpEnum), cbxOpIndex);
            if (enumName != null)
            {
                string key = "ActionForm/helpLvar" + enumName;
                string textEN = "";
                switch (cbxOpIndex)
                {
                    case (int)ListVariableOpEnum.Unset: textEN = ""; break;
                    case (int)ListVariableOpEnum.Push: textEN = ""; break;
                    case (int)ListVariableOpEnum.Insert: textEN = ""; break;
                    case (int)ListVariableOpEnum.Set: textEN = ""; break;
                    case (int)ListVariableOpEnum.SetAll: textEN = ""; break;
                    case (int)ListVariableOpEnum.Remove: textEN = ""; break;
                    case (int)ListVariableOpEnum.PopFirst: textEN = ""; break;
                    case (int)ListVariableOpEnum.PopToListInsert: textEN = "";  break;
                    case (int)ListVariableOpEnum.PopToListSet: textEN = ""; break;
                    case (int)ListVariableOpEnum.PopLast: textEN = ""; break;
                    case (int)ListVariableOpEnum.Build: textEN = ""; break;
                    case (int)ListVariableOpEnum.Filter: textEN = ""; break;
                    case (int)ListVariableOpEnum.Join: textEN = ""; break;
                    case (int)ListVariableOpEnum.Split: textEN = ""; break;
                    case (int)ListVariableOpEnum.Copy: textEN = ""; break;
                    case (int)ListVariableOpEnum.InsertList: textEN = ""; break;
                    case (int)ListVariableOpEnum.SortNumericAsc: textEN = ""; break;
                    case (int)ListVariableOpEnum.SortNumericDesc: textEN = ""; break;
                    case (int)ListVariableOpEnum.SortAlphaAsc: textEN = ""; break;
                    case (int)ListVariableOpEnum.SortAlphaDesc: textEN = ""; break;
                    case (int)ListVariableOpEnum.SortFfxivPartyAsc: textEN = ""; break;
                    case (int)ListVariableOpEnum.SortFfxivPartyDesc: textEN = ""; break;
                    case (int)ListVariableOpEnum.SortByKeys: textEN = ""; break;
                    case (int)ListVariableOpEnum.UnsetAll: textEN = ""; break;
                    case (int)ListVariableOpEnum.UnsetRegex: textEN = ""; break;
                }
                lblLvarHelper.Text = I18n.Translate(key, textEN);
            }
        }

        private void SetTableHelperText(int cbxOpIndex)
        {
            string enumName = Enum.GetName(typeof(TableVariableOpEnum), cbxOpIndex);
            if (enumName != null)
            {
                string key = "ActionForm/helpTvar" + enumName;
                string textEN = "";
                switch (cbxOpIndex)
                {
                    case (int)TableVariableOpEnum.Unset: textEN = ""; break;
                    case (int)TableVariableOpEnum.Set: textEN = ""; break;
                    case (int)TableVariableOpEnum.SetAll: textEN = ""; break;
                    case (int)TableVariableOpEnum.SlicesSetAll: textEN = ""; break;
                    case (int)TableVariableOpEnum.Resize: textEN = ""; break;
                    case (int)TableVariableOpEnum.Build: textEN = ""; break;
                    case (int)TableVariableOpEnum.SetLine: textEN = ""; break;
                    case (int)TableVariableOpEnum.InsertLine: textEN = ""; break;
                    case (int)TableVariableOpEnum.RemoveLine: textEN = ""; break;
                    case (int)TableVariableOpEnum.Filter: textEN = ""; break;
                    case (int)TableVariableOpEnum.FilterLine: textEN = ""; break;
                    case (int)TableVariableOpEnum.Copy: textEN = ""; break;
                    case (int)TableVariableOpEnum.Append: textEN = ""; break;
                    case (int)TableVariableOpEnum.SortLine: textEN = ""; break;
                    case (int)TableVariableOpEnum.UnsetAll: textEN = ""; break;
                    case (int)TableVariableOpEnum.UnsetRegex: textEN = ""; break;
                }
                lblTvarHelper.Text = I18n.Translate(key, textEN);
            }
        }

        private void SetDictHelperText(int cbxOpIndex)
        {
            string enumName = Enum.GetName(typeof(DictVariableOpEnum), cbxOpIndex);
            if (enumName != null)
            {
                string key = "ActionForm/helpDict" + enumName;
                string textEN = "";
                switch (cbxOpIndex)
                {
                    case (int)DictVariableOpEnum.Unset: textEN = ""; break;
                    case (int)DictVariableOpEnum.Set: textEN = ""; break;
                    case (int)DictVariableOpEnum.Remove: textEN = ""; break;
                    case (int)DictVariableOpEnum.SetAll: textEN = ""; break;
                    case (int)DictVariableOpEnum.Build: textEN = ""; break;
                    case (int)DictVariableOpEnum.Filter: textEN = ""; break;
                    case (int)DictVariableOpEnum.Merge: textEN = ""; break;
                    case (int)DictVariableOpEnum.MergeHard: textEN = ""; break;
                    case (int)DictVariableOpEnum.UnsetAll: textEN = ""; break;
                    case (int)DictVariableOpEnum.UnsetRegex: textEN = ""; break;
                }
                lblDictHelper.Text = I18n.Translate(key, textEN);
            }
        }

        #endregion
    }

}
