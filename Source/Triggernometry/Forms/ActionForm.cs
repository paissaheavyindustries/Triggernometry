using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Xml.Serialization;
using System.IO;

namespace Triggernometry.Forms
{

    public partial class ActionForm : MemoryForm<ActionForm>
    {

        private bool IsReadonly { get; set; } = false;

        internal WMPLib.WindowsMediaPlayer wmp;
        internal SpeechSynthesizer tts;
        private Plugin _plug;
        internal Plugin plug
        {
            get
            {
                return _plug;
            }
            set
            {
                _plug = value;
                cndCondition.plug = value;
            }
        }

        internal string Clipboard = "";

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
            expAuraImage.textBox1.TextChanged += TextBox1_TextChanged;
            if (DesignMode == false)
            {
                tbcActionSettings.ItemSize = new Size(0, 1);
                tbcActionSettings.SizeMode = TabSizeMode.Fixed;
            }
            btnTest.Tag = I18n.DoNotTranslate;
            btnTest.ContextMenuStrip = new ContextMenuStrip();
            ToolStripItem tsi = btnTest.ContextMenuStrip.Items.Add(I18n.Translate("internal/ActionForm/acttestplaceholder", "Test action with placeholder values"));
            tsi.Image = btnTest.Image;
            tsi.Click += Tsi_Click1;            
            tsi = btnTest.ContextMenuStrip.Items.Add(I18n.Translate("internal/ActionForm/acttestlive", "Test action with live values"));
            tsi.Image = btnTest.Image;
            tsi.Click += Tsi_Click2;
            txtSendKeysLink.Tag = I18n.DoNotTranslate;
            txtObsWebsocketLink.Tag = I18n.DoNotTranslate;
            RestoredSavedDimensions();
        }

        private void Tsi_Click2(object sender, EventArgs e)
        {
            TestActionPrepare(true);
        }

        private void Tsi_Click1(object sender, EventArgs e)
        {
            TestActionPrepare(false);
        }

        private void Tsi_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            btnAuraGuide.Enabled = (expAuraImage.textBox1.Text.Length > 0);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbcActionSettings.SelectedIndex = cbxActionType.SelectedIndex;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                expSoundFile.Expression = openFileDialog1.FileName;
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
            foreach (TabPage tp in tbcAction.TabPages)
            {
                foreach (Control c in tp.Controls)
                {
                    c.Enabled = false;
                }
            }
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
                chkExecuteAsync.Checked = true;
                expBeepFrequency.Expression = "1000";
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
                cbxExecScriptLang.SelectedIndex = 0;
                expExecScriptCode.Expression = "";
                expExecScriptAssemblies.Expression = "";
                cbxMessageBoxIcon.SelectedIndex = 0;
                expMessageBoxText.Expression = "";
                expVariableExpression.Expression = "";
                expVariableName.Expression = "";
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
                cbxLoggingLevel.SelectedIndex = 5;
                expAuraWTick.Expression = "";
                expAuraHTick.Expression = "";
                expAuraOTick.Expression = "";
                expAuraTTLTick.Expression = "";
                cbxFolderOp.SelectedIndex = 0;
                expDiscordMessage.Expression = "";
                expDiscordUrl.Expression = "";
                cbxDiscordTts.Checked = false;
                cbxObsOpType.SelectedIndex = 0;
                expObsSceneName.Expression = "";
                expObsSourceName.Expression = "";
                cbxTextAuraOp.SelectedIndex = 0;
                cbxTextAuraAlignment.SelectedIndex = 4;
                expTextAuraName.Expression = "";
                expTextAuraText.Expression = "";
                expTextAuraXIni.Expression = "";
                expTextAuraYIni.Expression = "";
                cbxProcessLog.Checked = false;
                expTextAuraWIni.Expression = "";
                expTextAuraHIni.Expression = "";
                expTextAuraOIni.Expression = "";
                expLogMessageText.Expression = "";
                expTextAuraXTick.Expression = "";
                expTextAuraYTick.Expression = "";
                expTextAuraWTick.Expression = "";
                expTextAuraHTick.Expression = "";
                expTextAuraOTick.Expression = "";
                expTextAuraTTLTick.Expression = "";
                expJsonEndpoint.Expression = "";
                expJsonFiring.Expression = "";
                expJsonPayload.Expression = "";
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
            }
            else
            {
                cbxActionType.SelectedIndex = (int)a.ActionType;
                cbxRefireOption1.SelectedIndex = (a._RefireInterrupt == true ? 0 : 1);
                cbxRefireOption2.SelectedIndex = (a._RefireRequeue == true ? 1 : 0);
                expExecutionDelay.Expression = a.ExecutionDelayExpression;
                chkExecuteAsync.Checked = a._Asynchronous;
                expBeepFrequency.Expression = a.SystemBeepFreqExpression;
                expBeepLength.Expression = a.SystemBeepLengthExpression;
                expSoundFile.Expression = a.PlaySoundFileExpression;
                expSoundVolume.Expression = a.PlaySoundVolumeExpression;
                chkSoundExclusive.Checked = a._PlaySoundExclusive;
                chkSoundMyOutput.Checked = a._PlaySoundMyself;
                expTextToSay.Expression = a.UseTTSTextExpression;
                expSpeechVolume.Expression = a.UseTTSVolumeExpression;
                expSpeechRate.Expression = a.UseTTSRateExpression;
                chkSpeechExclusive.Checked = a._UseTTSExclusive;
                chkSpeechMyOutput.Checked = a._PlaySpeechMyself;
                expProcessName.Expression = a.LaunchProcessPathExpression;
                expProcessParameters.Expression = a.LaunchProcessCmdlineExpression;
				expProcessWorkingDir.Expression = a.LaunchProcessWorkingDirExpression;
				cbxProcessWindowStyle.SelectedIndex = (int)a.LaunchProcessWindowStyle;
                expKeypresses.Expression = a.KeyPressExpression;
                cbxExecScriptLang.SelectedIndex = (int)a.ExecScriptType;
                expExecScriptCode.Expression = a.ExecScriptExpression;
                cbxLoggingLevel.SelectedIndex = (int)a.DebugLevel;
                expExecScriptAssemblies.Expression = a.ExecScriptAssembliesExpression;
                cbxMessageBoxIcon.SelectedIndex = ((int)a.MessageBoxIconType) / 16;
                expMessageBoxText.Expression = a.MessageBoxText;
                expVariableExpression.Expression = a.VariableExpression;
                expVariableName.Expression = a.VariableName;
                cbxVariableOp.SelectedIndex = (int)a.VariableOp;
                expLvarIndex.Expression = a.ListVariableIndex;
                expLvarName.Expression = a.ListVariableName;
                expLvarTarget.Expression = a.ListVariableTarget;
                expLvarValue.Expression = a.ListVariableExpression;
                cbxLvarExpType.SelectedIndex = (int)a.ListVariableExpressionType;
                cbxLvarOperation.SelectedIndex = (int)a.ListVariableOp;
                if ((a.TriggerForceType & Action.TriggerForceTypeEnum.SkipRegexp) != 0)
                {
                    cbxFiringOptions.SetItemChecked(0, true);
                }
                if ((a.TriggerForceType & Action.TriggerForceTypeEnum.SkipConditions) != 0)
                {
                    cbxFiringOptions.SetItemChecked(1, true);
                }
                if ((a.TriggerForceType & Action.TriggerForceTypeEnum.SkipRefire) != 0)
                {
                    cbxFiringOptions.SetItemChecked(2, true);
                }
                if ((a.TriggerForceType & Action.TriggerForceTypeEnum.SkipParent) != 0)
                {
                    cbxFiringOptions.SetItemChecked(3, true);
                }
                if ((a.TriggerForceType & Action.TriggerForceTypeEnum.SkipActive) != 0)
                {
                    cbxFiringOptions.SetItemChecked(4, true);
                }
                TreeNode tn = plug.LocateNodeHostingTriggerId(trvTrigger.Nodes[0], a.TriggerId, null);
                if (tn != null)
                {
                    tn.EnsureVisible();
                    trvTrigger.SelectedNode = tn;
                    trvTrigger.Update();
                }
                cbxTriggerOp.SelectedIndex = (int)a.TriggerOp;
                tn = plug.LocateNodeHostingFolderId(trvFolder.Nodes[0], a.FolderId, null);
                if (tn != null)
                {
                    tn.EnsureVisible();
                    trvFolder.SelectedNode = tn;
                    trvFolder.Update();
                }
                cbxFolderOp.SelectedIndex = (int)a.FolderOp;
                expTriggerZone.Expression = a.TriggerZone;
                expTriggerText.Expression = a.TriggerText;
                cbxAuraOp.SelectedIndex = (int)a.AuraOp;
                switch (a.AuraImageMode)
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
                expAuraName.Expression = a.AuraName;
                expAuraImage.Expression = a.AuraImage;
                expAuraXIni.Expression = a.AuraXIniExpression;
                expAuraYIni.Expression = a.AuraYIniExpression;
                expAuraWIni.Expression = a.AuraWIniExpression;
                expAuraHIni.Expression = a.AuraHIniExpression;
                expAuraOIni.Expression = a.AuraOIniExpression;
                expAuraXTick.Expression = a.AuraXTickExpression;
                expAuraYTick.Expression = a.AuraYTickExpression;
                expAuraWTick.Expression = a.AuraWTickExpression;
                expAuraHTick.Expression = a.AuraHTickExpression;
                expAuraOTick.Expression = a.AuraOTickExpression;
                expAuraTTLTick.Expression = a.AuraTTLTickExpression;
                expDiscordUrl.Expression = a.DiscordWebhookURL;
                expDiscordMessage.Expression = a.DiscordWebhookMessage;
                cbxDiscordTts.Checked = a._DiscordTts;
                cbxObsOpType.SelectedIndex = (int)a.OBSControlType;
                expObsSceneName.Expression = a.OBSSceneName;
                expObsSourceName.Expression = a.OBSSourceName;
                cbxTextAuraOp.SelectedIndex = (int)a.TextAuraOp;
                expJsonEndpoint.Expression = a.JsonEndpointExpression;
                expJsonFiring.Expression = a.JsonFiringExpression;
                expJsonPayload.Expression = a.JsonPayloadExpression;
                expWmsgTitle.Expression = a.WmsgTitle;
                expWmsgCode.Expression = a.WmsgCode;
                expWmsgWparam.Expression = a.WmsgWparam;
                expWmsgLparam.Expression = a.WmsgLparam;
                switch (a.TextAuraAlignment)
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
                expTextAuraName.Expression = a.TextAuraName;
                expTextAuraText.Expression = a.TextAuraExpression;
                expTextAuraXIni.Expression = a.TextAuraXIniExpression;
                expTextAuraYIni.Expression = a.TextAuraYIniExpression;
                expTextAuraWIni.Expression = a.TextAuraWIniExpression;
                expTextAuraHIni.Expression = a.TextAuraHIniExpression;
                expTextAuraOIni.Expression = a.TextAuraOIniExpression;
                expTextAuraXTick.Expression = a.TextAuraXTickExpression;
                expTextAuraYTick.Expression = a.TextAuraYTickExpression;
                expTextAuraWTick.Expression = a.TextAuraWTickExpression;
                expTextAuraHTick.Expression = a.TextAuraHTickExpression;
                expTextAuraOTick.Expression = a.TextAuraOTickExpression;
                cbxProcessLog.Checked = a._LogProcess;
                expTextAuraTTLTick.Expression = a.TextAuraTTLTickExpression;
                expLogMessageText.Expression = a.LogMessageText;
                FontInfoContainer fic = new FontInfoContainer();
                fic.Name = a.TextAuraFontName;
                fic.Size = a.TextAuraFontSize;
                fic.Effect = a.TextAuraEffect;
                txtTextAuraFont.Tag = fic;
                colorSelector1.TextColor = a.TextAuraForegroundClInt;
                colorSelector1.TextOutlineColor = a.TextAuraOutlineClInt;
                colorSelector1.BackgroundColor = a.TextAuraBackgroundClInt;
                colorSelector1.BackColor = a.TextAuraBackgroundClInt;
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
                switch (a.KeypressType)
                {
                    case Action.KeypressTypeEnum.SendKeys:
                        cbxKeypressMethod.SelectedIndex = 0;
                        break;
                    case Action.KeypressTypeEnum.WindowMessage:
                        cbxKeypressMethod.SelectedIndex = 1;
                        break;
                }
                expKeypress.Expression = a.KeyPressCode;
                expWindowTitle.Expression = a.KeyPressWindow;
            }
        }

        internal void SettingsToAction(Action a)
        {
            a.ActionType = (Action.ActionTypeEnum)cbxActionType.SelectedIndex;
            a._RefireInterrupt = (cbxRefireOption1.SelectedIndex == 0);
            a._RefireRequeue = (cbxRefireOption2.SelectedIndex == 1);
            a.ExecutionDelayExpression = expExecutionDelay.Expression;
            a._Asynchronous = chkExecuteAsync.Checked;
            a.SystemBeepFreqExpression = expBeepFrequency.Expression;
            a.SystemBeepLengthExpression = expBeepLength.Expression;
            a.PlaySoundFileExpression = expSoundFile.Expression;
            a.PlaySoundVolumeExpression = expSoundVolume.Expression;
            a._PlaySoundExclusive = chkSoundExclusive.Checked;
            a._PlaySoundMyself = chkSoundMyOutput.Checked;
            a.UseTTSTextExpression = expTextToSay.Expression;
            a._LogProcess = cbxProcessLog.Checked;
            a.UseTTSVolumeExpression = expSpeechVolume.Expression;
            a.UseTTSRateExpression = expSpeechRate.Expression;
            a._UseTTSExclusive = chkSpeechExclusive.Checked;
            a._PlaySpeechMyself = chkSpeechMyOutput.Checked;
            a.LaunchProcessPathExpression = expProcessName.Expression;
            a.LaunchProcessCmdlineExpression = expProcessParameters.Expression;
			a.LaunchProcessWorkingDirExpression = expProcessWorkingDir.Expression;
            a.DebugLevel = (Plugin.DebugLevelEnum)cbxLoggingLevel.SelectedIndex;
			a.LaunchProcessWindowStyle = (System.Diagnostics.ProcessWindowStyle)cbxProcessWindowStyle.SelectedIndex;
            a.KeyPressExpression = expKeypresses.Expression;
            a.ExecScriptType = (Action.ScriptTypeEnum)cbxExecScriptLang.SelectedIndex;
            a.ExecScriptExpression = expExecScriptCode.Expression;
            a.ExecScriptAssembliesExpression = expExecScriptAssemblies.Expression;
            a.MessageBoxIconType = (Action.MessageBoxIconTypeEnum)(cbxMessageBoxIcon.SelectedIndex * 16);
            a.MessageBoxText = expMessageBoxText.Expression;
            a.VariableExpression = expVariableExpression.Expression;
            a.VariableName = expVariableName.Expression;
            a.VariableOp = (Action.VariableOpEnum)cbxVariableOp.SelectedIndex;
            a.ListVariableExpression = expLvarValue.Expression;
            a.ListVariableExpressionType = (Action.ListVariableExpTypeEnum)cbxLvarExpType.SelectedIndex;
            a.ListVariableIndex = expLvarIndex.Expression;
            a.ListVariableName = expLvarName.Expression;
            a.ListVariableOp = (Action.ListVariableOpEnum)cbxLvarOperation.SelectedIndex;
            a.ListVariableTarget = expLvarTarget.Expression;
            TreeNode tn = trvTrigger.SelectedNode;
            if (tn != null)
            {
                a.TriggerId = ((Trigger)tn.Tag).Id;
            }
            else
            { 
                a.TriggerId = Guid.Empty;
            }
            a.TriggerOp = (Action.TriggerOpEnum)cbxTriggerOp.SelectedIndex;
            tn = trvFolder.SelectedNode;
            if (tn != null)
            {
                a.FolderId = ((Folder)tn.Tag).Id;
            }
            else
            {
                a.FolderId = Guid.Empty;
            }
            a.FolderOp = (Action.FolderOpEnum)cbxFolderOp.SelectedIndex;
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
            a.TriggerForceType = newval;
            a.TriggerText = expTriggerText.Expression;
            a.TriggerZone = expTriggerZone.Expression;
            a.AuraOp = (Action.AuraOpEnum)cbxAuraOp.SelectedIndex;
            switch (cbxAuraDisplay.SelectedIndex)
            {
                case 0:
                    a.AuraImageMode = PictureBoxSizeMode.Normal;
                    break;
                case 1:
                    a.AuraImageMode = PictureBoxSizeMode.StretchImage;
                    break;
                case 2:
                    a.AuraImageMode = PictureBoxSizeMode.CenterImage;
                    break;
                case 3:
                    a.AuraImageMode = PictureBoxSizeMode.Zoom;
                    break;
            }
            a.AuraName = expAuraName.Expression;
            a.AuraImage = expAuraImage.Expression;
            a.AuraXIniExpression = expAuraXIni.Expression;
            a.AuraYIniExpression = expAuraYIni.Expression;
            a.AuraWIniExpression = expAuraWIni.Expression;
            a.AuraHIniExpression = expAuraHIni.Expression;
            a.AuraOIniExpression = expAuraOIni.Expression;
            a.AuraXTickExpression = expAuraXTick.Expression;
            a.AuraYTickExpression = expAuraYTick.Expression;
            a.AuraWTickExpression = expAuraWTick.Expression;
            a.AuraHTickExpression = expAuraHTick.Expression;
            a.AuraOTickExpression = expAuraOTick.Expression;
            a.AuraTTLTickExpression = expAuraTTLTick.Expression;
            a.DiscordWebhookMessage = expDiscordMessage.Expression;
            a.DiscordWebhookURL = expDiscordUrl.Expression;
            a._DiscordTts = cbxDiscordTts.Checked;
            a.OBSControlType = (Action.ObsControlTypeEnum)cbxObsOpType.SelectedIndex;
            a.OBSSceneName = expObsSceneName.Expression;
            a.OBSSourceName = expObsSourceName.Expression;
            a.JsonEndpointExpression = expJsonEndpoint.Expression;
            a.JsonFiringExpression = expJsonFiring.Expression;
            a.JsonPayloadExpression = expJsonPayload.Expression;
            a.TextAuraOp = (Action.AuraOpEnum)cbxTextAuraOp.SelectedIndex;
            a.WmsgTitle = expWmsgTitle.Expression;
            a.WmsgCode = expWmsgCode.Expression;
            a.WmsgWparam = expWmsgWparam.Expression;
            a.WmsgLparam = expWmsgLparam.Expression;
            switch (cbxTextAuraAlignment.SelectedIndex)
            {
                case 0:
                    a.TextAuraAlignment = Action.TextAuraAlignmentEnum.TopLeft;
                    break;
                case 1:
                    a.TextAuraAlignment = Action.TextAuraAlignmentEnum.TopCenter;
                    break;
                case 2:
                    a.TextAuraAlignment = Action.TextAuraAlignmentEnum.TopRight;
                    break;
                case 3:
                    a.TextAuraAlignment = Action.TextAuraAlignmentEnum.MiddleLeft;
                    break;
                case 4:
                    a.TextAuraAlignment = Action.TextAuraAlignmentEnum.MiddleCenter;
                    break;
                case 5:
                    a.TextAuraAlignment = Action.TextAuraAlignmentEnum.MiddleRight;
                    break;
                case 6:
                    a.TextAuraAlignment = Action.TextAuraAlignmentEnum.BottomLeft;
                    break;
                case 7:
                    a.TextAuraAlignment = Action.TextAuraAlignmentEnum.BottomCenter;
                    break;
                case 8:
                    a.TextAuraAlignment = Action.TextAuraAlignmentEnum.BottomRight;
                    break;
            }
            a.TextAuraName = expTextAuraName.Expression;
            a.TextAuraExpression = expTextAuraText.Expression;
            a.TextAuraXIniExpression = expTextAuraXIni.Expression;
            a.TextAuraYIniExpression = expTextAuraYIni.Expression;
            a.TextAuraWIniExpression = expTextAuraWIni.Expression;
            a.TextAuraHIniExpression = expTextAuraHIni.Expression;
            a.TextAuraOIniExpression = expTextAuraOIni.Expression;
            a.TextAuraXTickExpression = expTextAuraXTick.Expression;
            a.TextAuraYTickExpression = expTextAuraYTick.Expression;
            a.TextAuraWTickExpression = expTextAuraWTick.Expression;
            a.TextAuraHTickExpression = expTextAuraHTick.Expression;
            a.TextAuraOTickExpression = expTextAuraOTick.Expression;
            a.TextAuraTTLTickExpression = expTextAuraTTLTick.Expression;
            a.LogMessageText = expLogMessageText.Expression;
            FontInfoContainer fic = (FontInfoContainer)txtTextAuraFont.Tag;
            a.TextAuraFontName = fic.Name;
            a.TextAuraFontSize = fic.Size;
            a.TextAuraEffect = fic.Effect;
            a.TextAuraForegroundClInt = colorSelector1.TextColor;
            a.TextAuraBackgroundClInt = colorSelector1.BackgroundColor;
            a.TextAuraOutlineClInt = colorSelector1.TextOutlineColor;
            a._TextAuraUseOutline = cbxTextAuraOutline.Checked;
            a.Condition = cndCondition.ConditionToEdit;
            a.KeypressType = (Action.KeypressTypeEnum)cbxKeypressMethod.SelectedIndex;
            a.KeyPressCode = expKeypress.Expression;
            a.KeyPressWindow = expWindowTitle.Expression;
        }

        private void TestAction(bool liveValues)
		{
			Action a = new Action();
			Context ctx = new Context();
            ctx.plug = plug;
			ctx.testmode = (liveValues == false);
            ctx.trig = null;
            ctx.soundhook = plug.SoundPlaybackSmart;
            ctx.ttshook = plug.TtsPlaybackSmart;
            SettingsToAction(a);
            ctx.triggered = DateTime.UtcNow;
            a.Execute(ctx);		
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
                case 1:
                    expVariableExpression.ExpressionType = CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    break;
                case 2:
                    expVariableExpression.ExpressionType = CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
                    break;
            }
            expVariableName.Enabled = (cbxVariableOp.SelectedIndex != 3);
            expVariableExpression.Enabled = (cbxVariableOp.SelectedIndex == 1 || cbxVariableOp.SelectedIndex == 2);            
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
            e.Node.ImageIndex = 0;
            e.Node.SelectedImageIndex = 0;
        }

        private void trvTrigger_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ImageIndex = 1;
            e.Node.SelectedImageIndex = 1;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            TestActionPrepare(plug.cfg.TestLiveByDefault);
        }

        private void TestActionPrepare(bool liveValues)
        {
            if (cbxActionType.SelectedIndex == (int)Action.ActionTypeEnum.KeyPress && cbxKeypressMethod.SelectedIndex == 0)
            {
                MessageBox.Show(this, I18n.Translate("internal/ActionForm/confirmkeypress", "The keypresses you defined will be sent in two seconds after you hit OK, to allow you to change to the window you want to send the keypresses to."), I18n.Translate("internal/ActionForm/confirmkeypressdelay", "Confirm"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (cbxActionType.SelectedIndex == (int)Action.ActionTypeEnum.Aura)
            {
                if (cbxAuraOp.SelectedIndex == (int)Action.AuraOpEnum.ActivateAura)
                {
                    timer1.Stop();
                    timer1.Tag = 0;
                    timer1.Start();
                }
            }
            TestAction(liveValues);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txtSendKeysLink.Text.ToString());
        }

        private void cbxAuraOp_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private Bitmap LoadImage(string fn)
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
            a.AuraOp = Action.AuraOpEnum.DeactivateAura;
            ctx.triggered = DateTime.UtcNow;
            a.Execute(ctx);
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
            a.AuraOp = Action.AuraOpEnum.DeactivateAura;
            ctx.triggered = DateTime.UtcNow;
            a.Execute(ctx);
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
            e.Node.ImageIndex = 0;
            e.Node.SelectedImageIndex = 0;
        }

        private void trvFolder_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ImageIndex = 1;
            e.Node.SelectedImageIndex = 1;
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
                    expLvarValue.ExpressionType = CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.String;
                    break;
                case 1:
                    expLvarValue.ExpressionType = CustomControls.ExpressionTextBox.SupportedExpressionTypeEnum.Numeric;
                    break;
            }
        }

        private void cbxLvarOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxLvarOperation.SelectedIndex)
            {
                case 0: // Unset list variable
                    expLvarName.Enabled = true;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = false;
                    break;
                case 1: // Push value to the end of the list variable
                    expLvarName.Enabled = true;
                    expLvarValue.Enabled = true;
                    cbxLvarExpType.Enabled = true;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = false;
                    break;
                case 2: // Insert value to the given index of the list variable
                    expLvarName.Enabled = true;
                    expLvarValue.Enabled = true;
                    cbxLvarExpType.Enabled = true;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = true;
                    break;
                case 3: // Set value at the given index of the list variable
                    expLvarName.Enabled = true;
                    expLvarValue.Enabled = true;
                    cbxLvarExpType.Enabled = true;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = true;
                    break;
                case 4: // Remove value at the given index of the list variable
                    expLvarName.Enabled = true;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = true;
                    break;
                case 5: // Pop last value from list variable into a simple variable (stack)
                    expLvarName.Enabled = true;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = true;
                    expLvarIndex.Enabled = false;
                    break;
                case 6: // Pop first value from list variable into a simple variable (queue)
                    expLvarName.Enabled = true;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = true;
                    expLvarIndex.Enabled = false;
                    break;
                case 7: // Sort list in an alphabetically ascending order
                    expLvarName.Enabled = true;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = false;
                    break;
                case 8: // Sort list in an alphabetically descending order
                    expLvarName.Enabled = true;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = false;
                    break;
                case 9: // Sort list in ffxiv party ascending order
                    expLvarName.Enabled = true;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = false;
                    break;
                case 10: // Sort list in ffxiv party descending order
                    expLvarName.Enabled = true;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = false;
                    break;
                case 11: // Copy whole list variable to another list variable
                    expLvarName.Enabled = true;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = true;
                    expLvarIndex.Enabled = false;
                    break;
                case 12: // Insert list variable into another list variable
                    expLvarName.Enabled = true;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = true;
                    expLvarIndex.Enabled = true;
                    break;
                case 13: // Join all values in the list variable into a single string (separator in expression)
                    expLvarName.Enabled = true;
                    expLvarValue.Enabled = true;
                    cbxLvarExpType.Enabled = true;
                    expLvarTarget.Enabled = true;
                    expLvarIndex.Enabled = false;
                    break;
                case 14: // Split a scalar variable into a list variable (separator in expression)
                    expLvarName.Enabled = true;
                    expLvarValue.Enabled = true;
                    cbxLvarExpType.Enabled = true;
                    expLvarTarget.Enabled = true;
                    expLvarIndex.Enabled = false;
                    break;
                case 15: // Unset all list variables
                    expLvarName.Enabled = false;
                    expLvarValue.Enabled = false;
                    cbxLvarExpType.Enabled = false;
                    expLvarTarget.Enabled = false;
                    expLvarIndex.Enabled = false;
                    break;
            }
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
            expObsSceneName.Enabled = (cbxObsOpType.SelectedIndex >= 10);
            expObsSourceName.Enabled = (cbxObsOpType.SelectedIndex >= 11);
        }

        private void cbxKeypressMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblKeypresses.Enabled = (cbxKeypressMethod.SelectedIndex == 0);
            expKeypresses.Enabled = (cbxKeypressMethod.SelectedIndex == 0);
            lblKeypressesInfo.Enabled = (cbxKeypressMethod.SelectedIndex == 0);
            txtSendKeysLink.Enabled = (cbxKeypressMethod.SelectedIndex == 0);
            btnSendKeysLink.Enabled = (cbxKeypressMethod.SelectedIndex == 0);
            lblKeypressWindow.Enabled = (cbxKeypressMethod.SelectedIndex == 1);
            expWindowTitle.Enabled = (cbxKeypressMethod.SelectedIndex == 1);
            lblKeypress.Enabled = (cbxKeypressMethod.SelectedIndex == 1);
            expKeypress.Enabled = (cbxKeypressMethod.SelectedIndex == 1);
            lblKeypressInfo.Enabled = (cbxKeypressMethod.SelectedIndex == 1);
            txtKeyCodesLink.Enabled = (cbxKeypressMethod.SelectedIndex == 1);
            btnKeycodesLink.Enabled = (cbxKeypressMethod.SelectedIndex == 1);            
        }

        private void btnKeycodesLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txtKeyCodesLink.Text.ToString());
        }

    }

}
