using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using WMPLib;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Net;
using System.IO;
using Microsoft.CSharp;
using Microsoft.VisualBasic;

namespace Triggernometry
{

    /*
	Confirm the triggers to import.
	
	At least one of triggers you are trying to import includes one of more actions that are set to launch an external process.
	These triggers may be dangerous and as such they are not included in the import by default.
	To import these triggers, you will have to confirm them manually one by one.
	
	*/
    public class Action
    {

        public enum ActionTypeEnum
        {
            SystemBeep,
            PlaySound,
            UseTTS,
            LaunchProcess,
            Trigger,
            KeyPress,
            ExecuteScript,
            MessageBox,
            Variable,
            Aura,
            Folder,
            EndEncounter,
            DiscordWebhook,
            TextAura,
            LogMessage,
            ListVariable,
            ObsControl,
            GenericJson,
            WindowMessage
        }

        public enum VariableOpEnum
        {
            Unset,
            SetString,
            SetNumeric,
            UnsetAll
        }

        public enum ScriptTypeEnum
        {
            CSharp,
            VBScript
        }

        public enum TriggerOpEnum
        {
            FireTrigger,
            CancelTrigger,
            EnableTrigger,
            DisableTrigger,
            CancelAllTrigger
        }

        public enum FolderOpEnum
        {
            EnableFolder,
            DisableFolder
        }

        public enum AuraOpEnum
        {
            ActivateAura,
            DeactivateAura,
            DeactivateAllAura
        }

        public enum MessageBoxIconTypeEnum
        {
            None = 0,
            Error = 16,
            Question = 32,
            Warning = 48,
            Information = 64
        }

        public enum TextAuraAlignmentEnum
        {
            TopLeft,
            TopCenter,
            TopRight,
            MiddleLeft,
            MiddleCenter,
            MiddleRight,
            BottomLeft,
            BottomCenter,
            BottomRight
        }

        public enum ListVariableOpEnum
        {
            Unset,
            Push,
            Insert,
            Set,
            Remove,
            PopLast,
            PopFirst,
            SortAlphaAsc,
            SortAlphaDesc,
            SortFfxivPartyAsc,
            SortFfxivPartyDesc,
            Copy,
            InsertList,
            Join,
            Split,
            UnsetAll
        }

        public enum ListVariableExpTypeEnum
        {
            String,
            Numeric
        }

        public enum ObsControlTypeEnum
        {
            StartStreaming,
            StopStreaming,
            ToggleStreaming,
            StartRecording,
            StopRecording,
            ToggleRecording,
            StartReplayBuffer,
            StopReplayBuffer,
            ToggleReplayBuffer,
            SaveReplayBuffer,
            SetScene,
            ShowSource,
            HideSource
        }

        public enum KeypressTypeEnum
        {
            SendKeys,
            WindowMessage
        }

        internal Guid Id { get; set; }

        internal bool _Enabled { get; set; }
        [XmlAttribute]
        public string Enabled
        {
            get
            {
                if (_Enabled == true)
                {
                    return null;
                }
                return _Enabled.ToString();
            }
            set
            {
                _Enabled = Boolean.Parse(value);
            }
        }

        [XmlAttribute]
        public ActionTypeEnum ActionType { get; set; }
        [XmlAttribute]
        public string ExecutionDelayExpression { get; set; }

        internal bool _Asynchronous { get; set; }
        [XmlAttribute]
        public string Asynchronous
        {
            get
            {
                if (_Asynchronous == true)
                {
                    return null;
                }
                return _Asynchronous.ToString();
            }
            set
            {
                _Asynchronous = Boolean.Parse(value);
            }
        }


        [XmlAttribute]
        public Plugin.DebugLevelEnum DebugLevel { get; set; } = Plugin.DebugLevelEnum.Inherit;

        internal bool _RefireInterrupt { get; set; }
        [XmlAttribute]
        public string RefireInterrupt
        {
            get
            {
                if (_RefireInterrupt == false)
                {
                    return null;
                }
                return _RefireInterrupt.ToString();
            }
            set
            {
                _RefireInterrupt = Boolean.Parse(value);
            }
        }

        internal bool _RefireRequeue { get; set; }
        [XmlAttribute]
        public string RefireRequeue
        {
            get
            {
                if (_RefireRequeue == true)
                {
                    return null;
                }
                return _RefireRequeue.ToString();
            }
            set
            {
                _RefireRequeue = Boolean.Parse(value);
            }
        }

        [XmlAttribute]
        public string SystemBeepFreqExpression
        {
            get
            {
                if (_SystemBeepFreqExpression == "")
                {
                    return null;
                }
                return _SystemBeepFreqExpression;
            }
            set
            {
                _SystemBeepFreqExpression = value;
            }
        }
        private string _SystemBeepFreqExpression;
        [XmlAttribute]
        public string SystemBeepLengthExpression
        {
            get
            {
                if (_SystemBeepLengthExpression == "")
                {
                    return null;
                }
                return _SystemBeepLengthExpression;
            }
            set
            {
                _SystemBeepLengthExpression = value;
            }
        }
        private string _SystemBeepLengthExpression;

        [XmlAttribute]
        public string PlaySoundFileExpression
        {
            get
            {
                if (_PlaySoundFileExpression == "")
                {
                    return null;
                }
                return _PlaySoundFileExpression;
            }
            set
            {
                _PlaySoundFileExpression = value;
            }
        }
        private string _PlaySoundFileExpression;
        [XmlAttribute]
        public string PlaySoundVolumeExpression
        {
            get
            {
                if (_PlaySoundVolumeExpression == "")
                {
                    return null;
                }
                return _PlaySoundVolumeExpression;
            }
            set
            {
                _PlaySoundVolumeExpression = value;
            }
        }
        private string _PlaySoundVolumeExpression;

        internal bool _PlaySoundExclusive { get; set; }
        [XmlAttribute]
        public string PlaySoundExclusive
        {
            get
            {
                if (_PlaySoundExclusive == true)
                {
                    return null;
                }
                return _PlaySoundExclusive.ToString();
            }
            set
            {
                _PlaySoundExclusive = Boolean.Parse(value);
            }
        }

        internal bool _PlaySoundMyself { get; set; }
        [XmlAttribute]
        public string PlaySoundMyself
        {
            get
            {
                if (_PlaySoundMyself == false)
                {
                    return null;
                }
                return _PlaySoundMyself.ToString();
            }
            set
            {
                _PlaySoundMyself = Boolean.Parse(value);
            }
        }

        internal bool _PlaySpeechMyself { get; set; }
        [XmlAttribute]
        public string PlaySpeechMyself
        {
            get
            {
                if (_PlaySpeechMyself == false)
                {
                    return null;
                }
                return _PlaySpeechMyself.ToString();
            }
            set
            {
                _PlaySpeechMyself = Boolean.Parse(value);
            }
        }

        [XmlAttribute]
        public string UseTTSTextExpression
        {
            get
            {
                if (_UseTTSTextExpression == "")
                {
                    return null;
                }
                return _UseTTSTextExpression;
            }
            set
            {
                _UseTTSTextExpression = value;
            }
        }
        private string _UseTTSTextExpression;
        [XmlAttribute]
        public string UseTTSVolumeExpression
        {
            get
            {
                if (_UseTTSVolumeExpression == "")
                {
                    return null;
                }
                return _UseTTSVolumeExpression;
            }
            set
            {
                _UseTTSVolumeExpression = value;
            }
        }
        private string _UseTTSVolumeExpression;
        [XmlAttribute]
        public string UseTTSRateExpression
        {
            get
            {
                if (_UseTTSRateExpression == "")
                {
                    return null;
                }
                return _UseTTSRateExpression;
            }
            set
            {
                _UseTTSRateExpression = value;
            }
        }
        private string _UseTTSRateExpression;

        internal bool _UseTTSExclusive { get; set; }
        [XmlAttribute]
        public string UseTTSExclusive
        {
            get
            {
                if (_UseTTSExclusive == true)
                {
                    return null;
                }
                return _UseTTSExclusive.ToString();
            }
            set
            {
                _UseTTSExclusive = Boolean.Parse(value);
            }
        }

        [XmlAttribute]
        public string LaunchProcessPathExpression
        {
            get
            {
                if (_LaunchProcessPathExpression == "")
                {
                    return null;
                }
                return _LaunchProcessPathExpression;
            }
            set
            {
                _LaunchProcessPathExpression = value;
            }
        }
        private string _LaunchProcessPathExpression;
        [XmlAttribute]
        public string LaunchProcessCmdlineExpression
        {
            get
            {
                if (_LaunchProcessCmdlineExpression == "")
                {
                    return null;
                }
                return _LaunchProcessCmdlineExpression;
            }
            set
            {
                _LaunchProcessCmdlineExpression = value;
            }
        }
        private string _LaunchProcessCmdlineExpression;
        [XmlAttribute]
        public string LaunchProcessWorkingDirExpression
        {
            get
            {
                if (_LaunchProcessWorkingDirExpression == "")
                {
                    return null;
                }
                return _LaunchProcessWorkingDirExpression;
            }
            set
            {
                _LaunchProcessWorkingDirExpression = value;
            }
        }
        private string _LaunchProcessWorkingDirExpression;
        [XmlAttribute]
        public System.Diagnostics.ProcessWindowStyle LaunchProcessWindowStyle { get; set; }

        [XmlAttribute]
        public ScriptTypeEnum ExecScriptType { get; set; }
        [XmlAttribute]
        public string ExecScriptAssembliesExpression
        {
            get
            {
                if (_ExecScriptAssembliesExpression == "")
                {
                    return null;
                }
                return _ExecScriptAssembliesExpression;
            }
            set
            {
                _ExecScriptAssembliesExpression = value;
            }
        }
        private string _ExecScriptAssembliesExpression;
        [XmlAttribute]
        public string ExecScriptExpression
        {
            get
            {
                if (_ExecScriptExpression == "")
                {
                    return null;
                }
                return _ExecScriptExpression;
            }
            set
            {
                _ExecScriptExpression = value;
            }
        }
        private string _ExecScriptExpression;

        [XmlAttribute]
        public MessageBoxIconTypeEnum MessageBoxIconType { get; set; }
        [XmlAttribute]
        public string MessageBoxText
        {
            get
            {
                if (_MessageBoxText == "")
                {
                    return null;
                }
                return _MessageBoxText;
            }
            set
            {
                _MessageBoxText = value;
            }
        }
        private string _MessageBoxText;

        [XmlAttribute]
        public VariableOpEnum VariableOp { get; set; }
        [XmlAttribute]
        public string VariableName
        {
            get
            {
                if (_VariableName == "")
                {
                    return null;
                }
                return _VariableName;
            }
            set
            {
                _VariableName = value;
            }
        }
        private string _VariableName;
        [XmlAttribute]
        public string VariableExpression
        {
            get
            {
                if (_VariableExpression == "")
                {
                    return null;
                }
                return _VariableExpression;
            }
            set
            {
                _VariableExpression = value;
            }
        }
        private string _VariableExpression;

        [XmlAttribute]
        public ListVariableOpEnum ListVariableOp { get; set; }
        [XmlAttribute]
        public string ListVariableName
        {
            get
            {
                if (_ListVariableName == "")
                {
                    return null;
                }
                return _ListVariableName;
            }
            set
            {
                _ListVariableName = value;
            }
        }
        private string _ListVariableName;
        [XmlAttribute]
        public string ListVariableExpression
        {
            get
            {
                if (_ListVariableExpression == "")
                {
                    return null;
                }
                return _ListVariableExpression;
            }
            set
            {
                _ListVariableExpression = value;
            }
        }
        private string _ListVariableExpression;
        [XmlAttribute]
        public ListVariableExpTypeEnum ListVariableExpressionType { get; set; }
        [XmlAttribute]
        public string ListVariableIndex
        {
            get
            {
                if (_ListVariableIndex == "")
                {
                    return null;
                }
                return _ListVariableIndex;
            }
            set
            {
                _ListVariableIndex = value;
            }
        }
        private string _ListVariableIndex;
        [XmlAttribute]
        public string ListVariableTarget
        {
            get
            {
                if (_ListVariableTarget == "")
                {
                    return null;
                }
                return _ListVariableTarget;
            }
            set
            {
                _ListVariableTarget = value;
            }
        }
        private string _ListVariableTarget;

        [XmlAttribute]
        public string DiscordWebhookURL
        {
            get
            {
                if (_DiscordWebhookURL == "")
                {
                    return null;
                }
                return _DiscordWebhookURL;
            }
            set
            {
                _DiscordWebhookURL = value;
            }
        }
        private string _DiscordWebhookURL;
        [XmlAttribute]
        public string DiscordWebhookMessage
        {
            get
            {
                if (_DiscordWebhookMessage == "")
                {
                    return null;
                }
                return _DiscordWebhookMessage;
            }
            set
            {
                _DiscordWebhookMessage = value;
            }
        }
        private string _DiscordWebhookMessage;

        internal bool _DiscordTts { get; set; }
        [XmlAttribute]
        public string DiscordTts
        {
            get
            {
                if (_DiscordTts == false)
                {
                    return null;
                }
                return _DiscordTts.ToString();
            }
            set
            {
                _DiscordTts = Boolean.Parse(value);
            }
        }

        [XmlAttribute]
        public string LogMessageText
        {
            get
            {
                if (_LogMessageText == "")
                {
                    return null;
                }
                return _LogMessageText;
            }
            set
            {
                _LogMessageText = value;
            }
        }
        private string _LogMessageText;

        [XmlAttribute]
        public TriggerOpEnum TriggerOp { get; set; }
        [XmlAttribute]
        public string TriggerText
        {
            get
            {
                if (_TriggerText == "")
                {
                    return null;
                }
                return _TriggerText;
            }
            set
            {
                _TriggerText = value;
            }
        }
        private string _TriggerText;
        [XmlAttribute]
        public string TriggerZone
        {
            get
            {
                if (_TriggerZone == "")
                {
                    return null;
                }
                return _TriggerZone;
            }
            set
            {
                _TriggerZone = value;
            }
        }
        private string _TriggerZone;
        [XmlAttribute]
        public string TriggerForce
        {
            get
            {
                List<string> ex = new List<string>();
                if (TriggerForceType == TriggerForceTypeEnum.SkipAll)
                {
                    ex.Add("true");
                }
                else
                {
                    if ((TriggerForceType & TriggerForceTypeEnum.SkipRegexp) != 0)
                    {
                        ex.Add("regexp");
                    }
                    if ((TriggerForceType & TriggerForceTypeEnum.SkipConditions) != 0)
                    {
                        ex.Add("conditions");
                    }
                    if ((TriggerForceType & TriggerForceTypeEnum.SkipRefire) != 0)
                    {
                        ex.Add("refire");
                    }
                    if ((TriggerForceType & TriggerForceTypeEnum.SkipParent) != 0)
                    {
                        ex.Add("parent");
                    }
                    if ((TriggerForceType & TriggerForceTypeEnum.SkipActive) != 0)
                    {
                        ex.Add("active");
                    }
                }
                return String.Join(",", ex.ToArray());
            }
            set
            {
                string[] exx = value.Split(",".ToCharArray());
                TriggerForceTypeEnum newval = TriggerForceTypeEnum.NoSkip;
                foreach (string ex in exx)
                {
                    if (string.Compare(ex, "true", true) == 0)
                    {
                        newval = TriggerForceTypeEnum.SkipAll;
                        break;
                    }
                    else if (string.Compare(ex, "false", true) == 0)
                    {
                        newval = TriggerForceTypeEnum.NoSkip;
                        break;
                    }
                    if (string.Compare(ex, "regexp", true) == 0)
                    {
                        newval |= TriggerForceTypeEnum.SkipRegexp;
                    }
                    if (string.Compare(ex, "conditions", true) == 0)
                    {
                        newval |= TriggerForceTypeEnum.SkipConditions;
                    }
                    if (string.Compare(ex, "refire", true) == 0)
                    {
                        newval |= TriggerForceTypeEnum.SkipRefire;
                    }
                    if (string.Compare(ex, "parent", true) == 0)
                    {
                        newval |= TriggerForceTypeEnum.SkipParent;
                    }
                    if (string.Compare(ex, "active", true) == 0)
                    {
                        newval |= TriggerForceTypeEnum.SkipActive;
                    }
                }
                TriggerForceType = newval;
            }
        }
        [XmlAttribute]
        public Guid TriggerId { get; set; }

        [XmlIgnore]
        internal TriggerForceTypeEnum TriggerForceType { get; set; }

        [Flags]
        public enum TriggerForceTypeEnum
        {
            NoSkip = 0,
            SkipRegexp = 1,
            SkipConditions = 2,
            SkipRefire = 4,
            SkipParent = 8,
            SkipActive = 16,
            SkipAll = SkipRegexp | SkipConditions | SkipRefire | SkipParent | SkipActive
        }

        [Flags]
        public enum TextAuraEffectEnum
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4,
            Strikeout = 8,
            Outline = 16
        }

        [XmlAttribute]
        public FolderOpEnum FolderOp { get; set; }
        [XmlAttribute]
        public Guid FolderId { get; set; }

        [XmlAttribute]
        public int OrderNumber;

        [XmlAttribute]
        public AuraOpEnum AuraOp { get; set; }
        [XmlAttribute]
        public string AuraName
        {
            get
            {
                if (_AuraName == "")
                {
                    return null;
                }
                return _AuraName;
            }
            set
            {
                _AuraName = value;
            }
        }
        private string _AuraName;
        [XmlAttribute]
        public string AuraImage
        {
            get
            {
                if (_AuraImage == "")
                {
                    return null;
                }
                return _AuraImage;
            }
            set
            {
                _AuraImage = value;
            }
        }
        private string _AuraImage;
        [XmlAttribute]
        public PictureBoxSizeMode AuraImageMode;

        // ------------------------------------------------------------------------------------
        [XmlAttribute]
        public string AuraXIniExpression
        {
            get
            {
                if (_AuraXIniExpression == "")
                {
                    return null;
                }
                return _AuraXIniExpression;
            }
            set
            {
                _AuraXIniExpression = value;
            }
        }
        private string _AuraXIniExpression;
        [XmlAttribute]
        public string AuraYIniExpression
        {
            get
            {
                if (_AuraYIniExpression == "")
                {
                    return null;
                }
                return _AuraYIniExpression;
            }
            set
            {
                _AuraYIniExpression = value;
            }
        }
        private string _AuraYIniExpression;
        [XmlAttribute]
        public string AuraWIniExpression
        {
            get
            {
                if (_AuraWIniExpression == "")
                {
                    return null;
                }
                return _AuraWIniExpression;
            }
            set
            {
                _AuraWIniExpression = value;
            }
        }
        private string _AuraWIniExpression;
        [XmlAttribute]
        public string AuraHIniExpression
        {
            get
            {
                if (_AuraHIniExpression == "")
                {
                    return null;
                }
                return _AuraHIniExpression;
            }
            set
            {
                _AuraHIniExpression = value;
            }
        }
        private string _AuraHIniExpression;
        [XmlAttribute]
        public string AuraOIniExpression
        {
            get
            {
                if (_AuraOIniExpression == "")
                {
                    return null;
                }
                return _AuraOIniExpression;
            }
            set
            {
                _AuraOIniExpression = value;
            }
        }
        private string _AuraOIniExpression;
        // ------------------------------------------------------------------------------------

        [XmlAttribute]
        public string AuraXTickExpression
        {
            get
            {
                if (_AuraXTickExpression == "")
                {
                    return null;
                }
                return _AuraXTickExpression;
            }
            set
            {
                _AuraXTickExpression = value;
            }
        }
        private string _AuraXTickExpression;
        [XmlAttribute]
        public string AuraYTickExpression
        {
            get
            {
                if (_AuraYTickExpression == "")
                {
                    return null;
                }
                return _AuraYTickExpression;
            }
            set
            {
                _AuraYTickExpression = value;
            }
        }
        private string _AuraYTickExpression;
        [XmlAttribute]
        public string AuraWTickExpression
        {
            get
            {
                if (_AuraWTickExpression == "")
                {
                    return null;
                }
                return _AuraWTickExpression;
            }
            set
            {
                _AuraWTickExpression = value;
            }
        }
        private string _AuraWTickExpression;
        [XmlAttribute]
        public string AuraHTickExpression
        {
            get
            {
                if (_AuraHTickExpression == "")
                {
                    return null;
                }
                return _AuraHTickExpression;
            }
            set
            {
                _AuraHTickExpression = value;
            }
        }
        private string _AuraHTickExpression;
        [XmlAttribute]
        public string AuraOTickExpression
        {
            get
            {
                if (_AuraOTickExpression == "")
                {
                    return null;
                }
                return _AuraOTickExpression;
            }
            set
            {
                _AuraOTickExpression = value;
            }
        }
        private string _AuraOTickExpression;
        [XmlAttribute]
        public string AuraTTLTickExpression
        {
            get
            {
                if (_AuraTTLTickExpression == "")
                {
                    return null;
                }
                return _AuraTTLTickExpression;
            }
            set
            {
                _AuraTTLTickExpression = value;
            }
        }
        private string _AuraTTLTickExpression;

        // ------------------------------------------------------------------------------------

        [XmlAttribute]
        public AuraOpEnum TextAuraOp { get; set; }
        [XmlAttribute]
        public string TextAuraName
        {
            get
            {
                if (_TextAuraName == "")
                {
                    return null;
                }
                return _TextAuraName;
            }
            set
            {
                _TextAuraName = value;
            }
        }
        private string _TextAuraName;
        [XmlAttribute]
        public string TextAuraExpression
        {
            get
            {
                if (_TextAuraExpression == "")
                {
                    return null;
                }
                return _TextAuraExpression;
            }
            set
            {
                _TextAuraExpression = value;
            }
        }
        private string _TextAuraExpression;
        [XmlAttribute]
        public TextAuraAlignmentEnum TextAuraAlignment;

        // ------------------------------------------------------------------------------------
        [XmlAttribute]
        public string TextAuraXIniExpression
        {
            get
            {
                if (_TextAuraXIniExpression == "")
                {
                    return null;
                }
                return _TextAuraXIniExpression;
            }
            set
            {
                _TextAuraXIniExpression = value;
            }
        }
        private string _TextAuraXIniExpression;
        [XmlAttribute]
        public string TextAuraYIniExpression
        {
            get
            {
                if (_TextAuraYIniExpression == "")
                {
                    return null;
                }
                return _TextAuraYIniExpression;
            }
            set
            {
                _TextAuraYIniExpression = value;
            }
        }
        private string _TextAuraYIniExpression;
        [XmlAttribute]
        public string TextAuraWIniExpression
        {
            get
            {
                if (_TextAuraWIniExpression == "")
                {
                    return null;
                }
                return _TextAuraWIniExpression;
            }
            set
            {
                _TextAuraWIniExpression = value;
            }
        }
        private string _TextAuraWIniExpression;
        [XmlAttribute]
        public string TextAuraHIniExpression
        {
            get
            {
                if (_TextAuraHIniExpression == "")
                {
                    return null;
                }
                return _TextAuraHIniExpression;
            }
            set
            {
                _TextAuraHIniExpression = value;
            }
        }
        private string _TextAuraHIniExpression;
        [XmlAttribute]
        public string TextAuraOIniExpression
        {
            get
            {
                if (_TextAuraOIniExpression == "")
                {
                    return null;
                }
                return _TextAuraOIniExpression;
            }
            set
            {
                _TextAuraOIniExpression = value;
            }
        }
        private string _TextAuraOIniExpression;
        // ------------------------------------------------------------------------------------
        [XmlAttribute]
        public string TextAuraXTickExpression
        {
            get
            {
                if (_TextAuraXTickExpression == "")
                {
                    return null;
                }
                return _TextAuraXTickExpression;
            }
            set
            {
                _TextAuraXTickExpression = value;
            }
        }
        private string _TextAuraXTickExpression;
        [XmlAttribute]
        public string TextAuraYTickExpression
        {
            get
            {
                if (_TextAuraYTickExpression == "")
                {
                    return null;
                }
                return _TextAuraYTickExpression;
            }
            set
            {
                _TextAuraYTickExpression = value;
            }
        }
        private string _TextAuraYTickExpression;
        [XmlAttribute]
        public string TextAuraWTickExpression
        {
            get
            {
                if (_TextAuraWTickExpression == "")
                {
                    return null;
                }
                return _TextAuraWTickExpression;
            }
            set
            {
                _TextAuraWTickExpression = value;
            }
        }
        private string _TextAuraWTickExpression;
        [XmlAttribute]
        public string TextAuraHTickExpression
        {
            get
            {
                if (_TextAuraHTickExpression == "")
                {
                    return null;
                }
                return _TextAuraHTickExpression;
            }
            set
            {
                _TextAuraHTickExpression = value;
            }
        }
        private string _TextAuraHTickExpression;
        [XmlAttribute]
        public string TextAuraOTickExpression
        {
            get
            {
                if (_TextAuraOTickExpression == "")
                {
                    return null;
                }
                return _TextAuraOTickExpression;
            }
            set
            {
                _TextAuraOTickExpression = value;
            }
        }
        private string _TextAuraOTickExpression;
        [XmlAttribute]
        public string TextAuraTTLTickExpression
        {
            get
            {
                if (_TextAuraTTLTickExpression == "")
                {
                    return null;
                }
                return _TextAuraTTLTickExpression;
            }
            set
            {
                _TextAuraTTLTickExpression = value;
            }
        }
        private string _TextAuraTTLTickExpression;
        // ------------------------------------------------------------------------------------

        [XmlAttribute]
        public string TextAuraFontName
        {
            get
            {
                if (_TextAuraFontName == "")
                {
                    return null;
                }
                return _TextAuraFontName;
            }
            set
            {
                _TextAuraFontName = value;
            }
        }
        private string _TextAuraFontName;
        [XmlAttribute]
        public float TextAuraFontSize;
        [XmlAttribute]
        public TextAuraEffectEnum TextAuraEffect;

        internal bool _TextAuraUseOutline { get; set; }
        [XmlAttribute]
        public string TextAuraUseOutline
        {
            get
            {
                if (_TextAuraUseOutline == false)
                {
                    return null;
                }
                return _TextAuraUseOutline.ToString();
            }
            set
            {
                _TextAuraUseOutline = Boolean.Parse(value);
            }
        }

        [XmlAttribute]
        public string TextAuraForeground
        {
            get
            {                
                return System.Drawing.ColorTranslator.ToHtml(TextAuraForegroundClInt);
            }
            set
            {
                TextAuraForegroundClInt = System.Drawing.ColorTranslator.FromHtml(value);
            }
        }
        [XmlAttribute]
        public string TextAuraBackground
        {
            get
            {
                return System.Drawing.ColorTranslator.ToHtml(TextAuraBackgroundClInt);
            }
            set
            {
                TextAuraBackgroundClInt = System.Drawing.ColorTranslator.FromHtml(value);
            }
        }

        [XmlAttribute]
        public string TextAuraOutline
        {
            get
            {
                return System.Drawing.ColorTranslator.ToHtml(TextAuraOutlineClInt);
            }
            set
            {
                TextAuraOutlineClInt = System.Drawing.ColorTranslator.FromHtml(value);
            }
        }

        [XmlAttribute]
        public ObsControlTypeEnum OBSControlType { get; set; }

        internal bool _LogProcess { get; set; }
        [XmlAttribute]
        public string LogProcess
        {
            get
            {
                if (_LogProcess == false)
                {
                    return null;
                }
                return _LogProcess.ToString();
            }
            set
            {
                _LogProcess = Boolean.Parse(value);
            }
        }

        private string _OBSSceneName;
        [XmlAttribute]
        public string OBSSceneName
        {
            get
            {
                if (_OBSSceneName == "")
                {
                    return null;
                }
                return _OBSSceneName;
            }
            set
            {
                _OBSSceneName = value;
            }
        }

        private string _OBSSourceName;
        [XmlAttribute]
        public string OBSSourceName
        {
            get
            {
                if (_OBSSourceName == "")
                {
                    return null;
                }
                return _OBSSourceName;
            }
            set
            {
                _OBSSourceName = value;
            }
        }

        private string _JsonEndpointExpression;
        [XmlAttribute]
        public string JsonEndpointExpression
        {
            get
            {
                if (_JsonEndpointExpression == "")
                {
                    return null;
                }
                return _JsonEndpointExpression;
            }
            set
            {
                _JsonEndpointExpression = value;
            }
        }

        private string _JsonPayloadExpression;
        [XmlAttribute]
        public string JsonPayloadExpression
        {
            get
            {
                if (_JsonPayloadExpression == "")
                {
                    return null;
                }
                return _JsonPayloadExpression;
            }
            set
            {
                _JsonPayloadExpression = value;
            }
        }

        private string _JsonFiringExpression;
        [XmlAttribute]
        public string JsonFiringExpression
        {
            get
            {
                if (_JsonFiringExpression == "")
                {
                    return null;
                }
                return _JsonFiringExpression;
            }
            set
            {
                _JsonFiringExpression = value;
            }
        }

        [XmlAttribute]
        public KeypressTypeEnum KeypressType { get; set; }

        [XmlAttribute]
        public string WmsgTitle
        {
            get
            {
                if (_WmsgTitle == "")
                {
                    return null;
                }
                return _WmsgTitle;
            }
            set
            {
                _WmsgTitle = value;
            }
        }
        private string _WmsgTitle;

        [XmlAttribute]
        public string WmsgCode
        {
            get
            {
                if (_WmsgCode == "")
                {
                    return null;
                }
                return _WmsgCode;
            }
            set
            {
                _WmsgCode = value;
            }
        }
        private string _WmsgCode;

        [XmlAttribute]
        public string WmsgWparam
        {
            get
            {
                if (_WmsgWparam == "")
                {
                    return null;
                }
                return _WmsgWparam;
            }
            set
            {
                _WmsgWparam = value;
            }
        }
        private string _WmsgWparam;

        [XmlAttribute]
        public string WmsgLparam
        {
            get
            {
                if (_WmsgLparam == "")
                {
                    return null;
                }
                return _WmsgLparam;
            }
            set
            {
                _WmsgLparam = value;
            }
        }
        private string _WmsgLparam;

        internal Color TextAuraForegroundClInt;
        internal Color TextAuraBackgroundClInt;
        internal Color TextAuraOutlineClInt;

        public ConditionGroup Condition { get; set; }

        private EventList<Condition> _Conditions;
        public EventList<Condition> Conditions
        {
            get
            {
                return _Conditions;
            }
            set
            {
                _Conditions = value;
                if (_Conditions != null)
                {
                    _Conditions.ItemAdded += _Conditions_ItemAdded;
                }
            }
        }

        private void _Conditions_ItemAdded(object sender, EventListArgs<Condition> e)
        {
            if (Condition == null)
            {
                Condition = new ConditionGroup();
                Condition.Grouping = ConditionGroup.CndGroupingEnum.And;
                Condition.Enabled = true;
            }
            Condition cx = e.Item;
            Condition.AddChild(cx.ConvertToConditionSingle());
            _Conditions.Remove(e.Item);
        }

        public class EventListArgs<T> : EventArgs
        {
            public EventListArgs(T item, int index)
            {
                Item = item;
                Index = index;
            }

            public T Item { get; }
            public int Index { get; }
        }

        public class EventList<T> : IList<T>
        {
            private readonly List<T> _list;

            public EventList()
            {
                _list = new List<T>();
            }

            public EventList(IEnumerable<T> collection)
            {
                _list = new List<T>(collection);
            }

            public EventList(int capacity)
            {
                _list = new List<T>(capacity);
            }

            public event EventHandler<EventListArgs<T>> ItemAdded;
            public event EventHandler<EventListArgs<T>> ItemRemoved;

            private void RaiseEvent(EventHandler<EventListArgs<T>> eventHandler, T item, int index)
            {
                var eh = eventHandler;
                eh?.Invoke(this, new EventListArgs<T>(item, index));
            }

            public IEnumerator<T> GetEnumerator()
            {
                return _list.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public void Add(T item)
            {
                var index = _list.Count;
                _list.Add(item);
                RaiseEvent(ItemAdded, item, index);
            }

            public void Clear()
            {
                for (var index = 0; index < _list.Count; index++)
                {
                    var item = _list[index];
                    RaiseEvent(ItemRemoved, item, index);
                }

                _list.Clear();
            }

            public bool Contains(T item)
            {
                return _list.Contains(item);
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                _list.CopyTo(array, arrayIndex);
            }

            public bool Remove(T item)
            {
                var index = _list.IndexOf(item);

                if (_list.Remove(item))
                {
                    RaiseEvent(ItemRemoved, item, index);
                    return true;
                }

                return false;
            }

            public int Count => _list.Count;
            public bool IsReadOnly => false;

            public int IndexOf(T item)
            {
                return _list.IndexOf(item);
            }

            public void Insert(int index, T item)
            {
                _list.Insert(index, item);
                RaiseEvent(ItemRemoved, item, index);
            }

            public void RemoveAt(int index)
            {
                var item = _list[index];
                _list.RemoveAt(index);
                RaiseEvent(ItemRemoved, item, index);
            }

            public T this[int index]
            {
                get { return _list[index]; }
                set { _list[index] = value; }
            }
        }

        public void ActionContextLogger(object o, string msg)
        {
            AddToLog((Context)o, Plugin.DebugLevelEnum.Verbose, msg);
        }

        private string Capitalize(string str)
        {
            if (str == null)
            {
                return null;
            }
            if (str.Length > 1)
            {
                return char.ToUpper(str[0]) + str.Substring(1);
            }
            return str.ToUpper();
        }

        internal bool ObsConnector(Context ctx)
        {
            Plugin p = ctx.plug;
            lock (p._obs)
            {
                if (p._obs.IsConnected == true)
                {
                    return true;
                }
                try
                {
                    p._obs.Connect();
                    AddToLog(ctx, Plugin.DebugLevelEnum.Info, I18n.Translate("internal/Action/obsconnectok", "OBS WebSocket connected successfully"));
                    return true;
                }
                catch (Exception ex)
                {
                    AddToLog(ctx, Plugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/obsconnecterror", "Error connecting to OBS WebSocket: {0}", ex.Message));
                }
            }
            return false;
        }

        internal string GetDescription(Context ctx)
        {
            string temp = "";
            if (ExecutionDelayExpression.Length > 0 && ExecutionDelayExpression != "0")
            {
                temp = I18n.Translate("internal/Action/descafterdelay", "after ({0}) ms", ExecutionDelayExpression);
                temp += ", ";
            }
            if (Condition != null && Condition.Enabled == true)
            {
                temp = I18n.Translate("internal/Action/descassumingcondition", "assuming condition is met");
                temp += ", ";
            }
            switch (ActionType)
            { 
                case ActionTypeEnum.Trigger:
                    {
                        Trigger t = ctx.plug.GetTriggerById(TriggerId, ctx.trig != null ? ctx.trig.Repo : null);
                        if (t != null)
                        {
                            switch (TriggerOp)
                            {
                                case TriggerOpEnum.CancelTrigger:
                                    temp += I18n.Translate("internal/Action/desctrigcancel", "cancel all actions queued from trigger ({0})", t.Name);
                                    break;
                                case TriggerOpEnum.CancelAllTrigger:
                                    temp += I18n.Translate("internal/Action/desctrigcancelall", "cancel all actions queued from all triggers");
                                    break;
                                case TriggerOpEnum.FireTrigger:
                                    
                                    temp += I18n.Translate("internal/Action/desctrigfire", "fire trigger ({0})", t.Name);
                                    List<string> ex = new List<string>();
                                    if (TriggerForceType == TriggerForceTypeEnum.SkipAll)
                                    {
                                        ex.Add(I18n.Translate("internal/Action/desctrigignoreall", "all restrictions"));
                                    }
                                    else
                                    {
                                        if ((TriggerForceType & TriggerForceTypeEnum.SkipRegexp) != 0)
                                        {
                                            ex.Add(I18n.Translate("internal/Action/desctrigignoreregex", "regular expression"));
                                        }
                                        else
                                        {
                                            temp += " " + I18n.Translate("internal/Action/desctrigfireusing", "with event text ({0}) and zone ({1})", TriggerText, TriggerZone);
                                        }
                                        if ((TriggerForceType & TriggerForceTypeEnum.SkipConditions) != 0)
                                        {
                                            ex.Add(I18n.Translate("internal/Action/desctrigignoreconditions", "conditions"));
                                        }
                                        if ((TriggerForceType & TriggerForceTypeEnum.SkipRefire) != 0)
                                        {
                                            ex.Add(I18n.Translate("internal/Action/desctrigignorerefire", "refire delay"));
                                        }
                                        if ((TriggerForceType & TriggerForceTypeEnum.SkipParent) != 0)
                                        {
                                            ex.Add(I18n.Translate("internal/Action/desctrigignoreparent", "parent folder settings"));
                                        }
                                        if ((TriggerForceType & TriggerForceTypeEnum.SkipActive) != 0)
                                        {
                                            ex.Add(I18n.Translate("internal/Action/desctrigignorestate", "enabled/disabled status"));
                                        }
                                    }
                                    if (ex.Count > 1)
                                    {
                                        ex[ex.Count - 1] = I18n.Translate("internal/Action/desctrigignoreand", "and") + " " + ex[ex.Count - 1];
                                    }
                                    if (ex.Count > 0)
                                    {
                                        temp += ", " + I18n.Translate("internal/Action/desctrigignoring", "ignoring") + " " + String.Join(", ", ex);
                                    }
                                    break;
                                case TriggerOpEnum.DisableTrigger:
                                    temp += I18n.Translate("internal/Action/desctrigdisable", "disable trigger ({0})", t.Name);
                                    break;
                                case TriggerOpEnum.EnableTrigger:
                                    temp += I18n.Translate("internal/Action/desctrigenable", "enable trigger ({0})", t.Name);
                                    break;
                            }
                        }
                        else
                        {
                            if (TriggerOp == TriggerOpEnum.CancelAllTrigger)
                            {
                                temp += I18n.Translate("internal/Action/desctrigcancelall", "cancel all actions queued from all triggers");
                            }
                            else
                            {
                                temp += I18n.Translate("internal/Action/desctriginvalidref", "trigger action with an invalid trigger reference ({0})", TriggerId);
                            }
                        }
                    }
                    break;
                case ActionTypeEnum.Folder:
                    {
                        Folder f = ctx.plug.GetFolderById(FolderId, ctx.trig != null ? ctx.trig.Repo : null);
                        if (f != null)
                        {
                            switch (FolderOp)
                            {
                                case FolderOpEnum.DisableFolder:
                                    temp += I18n.Translate("internal/Action/descdisablefolder", "disable folder ({0})", f.Name);
                                    break;
                                case FolderOpEnum.EnableFolder:
                                    temp += I18n.Translate("internal/Action/descenablefolder", "enable folder ({0})", f.Name);
                                    break;
                            }
                        }
                        else
                        {
                            temp += I18n.Translate("internal/Action/descinvalidfolderref", "folder action with an invalid folder reference ({0})", FolderId);
                        }
                    }
                    break;
                case ActionTypeEnum.KeyPress:
                    if (KeypressType == KeypressTypeEnum.SendKeys)
                    {
                        temp += I18n.Translate("internal/Action/desckeypresses", "send keypresses ({0}) to the active window", KeyPressExpression);
                    }
                    else
                    {
                        temp += I18n.Translate("internal/Action/desckeypress", "send keycode ({0}) to window ({1})", KeyPressCode, KeyPressWindow);
                    }
                    break;
                case ActionTypeEnum.LaunchProcess:
                    {
                        string tempt = "";
                        switch (LaunchProcessWindowStyle)
                        {
                            case System.Diagnostics.ProcessWindowStyle.Hidden:
                                tempt = I18n.Lookup("ActionForm/cbxProcessWindowStyle[Hidden from view]", LaunchProcessWindowStyle.ToString());
                                break;
                            case System.Diagnostics.ProcessWindowStyle.Maximized:
                                tempt = I18n.Lookup("ActionForm/cbxProcessWindowStyle[Maximized to fullscreen]", LaunchProcessWindowStyle.ToString());
                                break;
                            case System.Diagnostics.ProcessWindowStyle.Minimized:
                                tempt = I18n.Lookup("ActionForm/cbxProcessWindowStyle[Minimized to taskbar]", LaunchProcessWindowStyle.ToString());
                                break;
                            case System.Diagnostics.ProcessWindowStyle.Normal:
                                tempt = I18n.Lookup("ActionForm/cbxProcessWindowStyle[Normal]", LaunchProcessWindowStyle.ToString());
                                break;
                            default:
                                tempt = LaunchProcessWindowStyle.ToString();
                                break;
                        }
                        temp += I18n.Translate("internal/Action/desclaunchprocess", "launch process ({0}) as ({1}) using command line parameters ({2})",
                            LaunchProcessPathExpression,
                            tempt,
                            LaunchProcessCmdlineExpression
                        );
                    }
                    break;
                case ActionTypeEnum.PlaySound:
                    temp += I18n.Translate("internal/Action/descplaysound", "play sound file ({0}) at volume ({1}) %", PlaySoundFileExpression, PlaySoundVolumeExpression);
                    break;
                case ActionTypeEnum.SystemBeep:
                    temp += I18n.Translate("internal/Action/descbeep", "beep at ({0}) hz for ({1}) ms", SystemBeepFreqExpression, SystemBeepLengthExpression);
                    break;
                case ActionTypeEnum.UseTTS:
                    temp += I18n.Translate("internal/Action/desctts", "say ({0}) at volume ({1}) %, using speed ({2})", UseTTSTextExpression, UseTTSVolumeExpression, UseTTSRateExpression);
                    break;
                case ActionTypeEnum.ExecuteScript:
                    temp += I18n.Translate("internal/Action/descexecscript", "execute ({0}) script", ExecScriptType.ToString());
                    break;
                case ActionTypeEnum.MessageBox:
                    temp += I18n.Translate("internal/Action/descmsgbox", "show a message box saying ({0}) with icon ({1})", MessageBoxText, MessageBoxIconType.ToString());
                    break;
                case ActionTypeEnum.ListVariable:
                    switch (ListVariableOp)
                    {
                        case ListVariableOpEnum.Unset:
                            temp += I18n.Translate("internal/Action/desclistunset", "unset list variable ({0})", ListVariableName);
                            break;
                        case ListVariableOpEnum.Push:
                            switch (ListVariableExpressionType)
                            {
                                case ListVariableExpTypeEnum.Numeric:
                                    temp += I18n.Translate("internal/Action/desclistpushnumeric", "push the value from numeric expression ({0}) to the end of list variable ({1})", ListVariableExpression, ListVariableName);
                                    break;
                                case ListVariableExpTypeEnum.String:
                                    temp += I18n.Translate("internal/Action/desclistpushstring", "push the value from string expression ({0}) to the end of list variable ({1})", ListVariableExpression, ListVariableName);
                                    break;
                            }
                            break;
                        case ListVariableOpEnum.Insert:
                            switch (ListVariableExpressionType)
                            {
                                case ListVariableExpTypeEnum.Numeric:
                                    temp += I18n.Translate("internal/Action/desclistinsertnumeric", "insert the value from numeric expression ({0}) to index ({1}) on list variable ({2})", ListVariableExpression, ListVariableIndex, ListVariableName);
                                    break;
                                case ListVariableExpTypeEnum.String:
                                    temp += I18n.Translate("internal/Action/desclistinsertstring", "insert the value from string expression ({0}) to index ({1}) on list variable ({2})", ListVariableExpression, ListVariableIndex, ListVariableName);
                                    break;
                            }
                            break;
                        case ListVariableOpEnum.Set:
                            switch (ListVariableExpressionType)
                            {
                                case ListVariableExpTypeEnum.Numeric:
                                    temp += I18n.Translate("internal/Action/desclistsetnumeric", "set the value from numeric expression ({0}) to index ({1}) on list variable ({2})", ListVariableExpression, ListVariableIndex, ListVariableName);
                                    break;
                                case ListVariableExpTypeEnum.String:
                                    temp += I18n.Translate("internal/Action/desclistsetstring", "set the value from string expression ({0}) to index ({1}) on list variable ({2})", ListVariableExpression, ListVariableIndex, ListVariableName);
                                    break;
                            }
                            break;
                        case ListVariableOpEnum.Remove:
                            temp += I18n.Translate("internal/Action/desclistremoveindex", "remove the value at index ({0}) on list variable ({1})", ListVariableIndex, ListVariableName);
                            break;
                        case ListVariableOpEnum.PopLast:
                            temp += I18n.Translate("internal/Action/desclistpoplast", "pop the last value in list variable ({0}) into scalar variable ({1})", ListVariableName, ListVariableTarget);
                            break;
                        case ListVariableOpEnum.PopFirst:
                            temp += I18n.Translate("internal/Action/desclistpopfirst", "pop the first value in list variable ({0}) into scalar variable ({1})", ListVariableName, ListVariableTarget);
                            break;
                        case ListVariableOpEnum.SortAlphaAsc:
                            temp += I18n.Translate("internal/Action/desclistsortasc", "sort list variable ({0}) in an alphabetically ascending order", ListVariableName);
                            break;
                        case ListVariableOpEnum.SortAlphaDesc:
                            temp += I18n.Translate("internal/Action/desclistsortdesc", "sort list variable ({0}) in an alphabetically descending order", ListVariableName);
                            break;
                        case ListVariableOpEnum.SortFfxivPartyAsc:
                            temp += I18n.Translate("internal/Action/desclistsortffxivasc", "sort list variable ({0}) in ascending order according to FFXIV party job order", ListVariableName);
                            break;
                        case ListVariableOpEnum.SortFfxivPartyDesc:
                            temp += I18n.Translate("internal/Action/desclistsortffxivdesc", "sort list variable ({0}) in descending order according to FFXIV party job order", ListVariableName);
                            break;
                        case ListVariableOpEnum.Copy:
                            temp += I18n.Translate("internal/Action/desclistcopy", "copy list variable ({0}) to list variable ({1})", ListVariableName, ListVariableTarget);
                            break;
                        case ListVariableOpEnum.InsertList:
                            temp += I18n.Translate("internal/Action/desclistinsertlist", "insert list variable ({0}) into list variable ({1}) at index ({2})", ListVariableName, ListVariableTarget, ListVariableIndex);
                            break;
                        case ListVariableOpEnum.Join:
                            temp += I18n.Translate("internal/Action/desclistjoin", "join all values in list variable ({0}) to scalar variable ({1}) using ({2}) as separator", ListVariableName, ListVariableTarget, ListVariableExpression);
                            break;
                        case ListVariableOpEnum.Split:
                            temp += I18n.Translate("internal/Action/desclistsplit", "split scalar variable ({0}) into list variable ({1}) using ({2}) as separator", ListVariableName, ListVariableTarget, ListVariableExpression);
                            break;
                        case ListVariableOpEnum.UnsetAll:
                            temp += I18n.Translate("internal/Action/desclistunsetall", "unset all list variables");
                            break;
                    }
                    break;
                case ActionTypeEnum.GenericJson:
                    if (JsonFiringExpression != null && JsonFiringExpression.Trim().Length > 0)
                    {
                        temp += I18n.Translate("internal/Action/descjsonsendrelay", "send JSON payload to endpoint ({0}), relaying response for further processing", JsonEndpointExpression);
                    }
                    else
                    {
                        temp += I18n.Translate("internal/Action/descjsonsend", "send JSON payload to endpoint ({0})", JsonEndpointExpression);
                    }
                    break;
                case ActionTypeEnum.ObsControl:
                    switch (OBSControlType)
                    {
                        case ObsControlTypeEnum.StartStreaming:
                            temp += I18n.Translate("internal/Action/descobsstartstream", "start streaming on OBS");
                            break;
                        case ObsControlTypeEnum.StopStreaming:
                            temp += I18n.Translate("internal/Action/descobsstopstream", "stop streaming on OBS");
                            break;
                        case ObsControlTypeEnum.ToggleStreaming:
                            temp += I18n.Translate("internal/Action/descobstogglestream", "start/stop streaming on OBS (toggle)");
                            break;
                        case ObsControlTypeEnum.StartRecording:
                            temp += I18n.Translate("internal/Action/descobsstartrecord", "start recording on OBS");
                            break;
                        case ObsControlTypeEnum.StopRecording:
                            temp += I18n.Translate("internal/Action/descobsstoprecord", "stop recording on OBS");
                            break;
                        case ObsControlTypeEnum.ToggleRecording:
                            temp += I18n.Translate("internal/Action/descobstogglerecord", "start/stop recording on OBS (toggle)");
                            break;
                        case ObsControlTypeEnum.StartReplayBuffer:
                            temp += I18n.Translate("internal/Action/descobsstartreplay", "start OBS replay buffer");
                            break;
                        case ObsControlTypeEnum.StopReplayBuffer:
                            temp += I18n.Translate("internal/Action/descobsstopreplay", "stop OBS replay buffer");
                            break;
                        case ObsControlTypeEnum.ToggleReplayBuffer:
                            temp += I18n.Translate("internal/Action/descobstogglereplay", "start/stop OBS replay buffer (toggle)");
                            break;
                        case ObsControlTypeEnum.SaveReplayBuffer:
                            temp += I18n.Translate("internal/Action/descobssavereplay", "save OBS replay buffer");
                            break;
                        case ObsControlTypeEnum.SetScene:
                            temp += I18n.Translate("internal/Action/descobssetscene", "set current OBS scene to ({0})", OBSSceneName);
                            break;
                        case ObsControlTypeEnum.ShowSource:
                            if (OBSSceneName != null && OBSSceneName != "")
                            {
                                temp += I18n.Translate("internal/Action/descobsshowsource", "show source ({0}) on OBS scene ({1})", OBSSourceName, OBSSceneName);
                            }
                            else
                            {
                                temp += I18n.Translate("internal/Action/descobsshowsourcecurrent", "show source ({0}) on current OBS scene", OBSSourceName);
                            }
                            break;
                        case ObsControlTypeEnum.HideSource:
                            if (OBSSceneName != null && OBSSceneName != "")
                            {
                                temp += I18n.Translate("internal/Action/descobshidesource", "hide source ({0}) on OBS scene ({1})", OBSSourceName, OBSSceneName);
                            }
                            else
                            {
                                temp += I18n.Translate("internal/Action/descobshidesourcecurrent", "hide source ({0}) on current OBS scene", OBSSourceName);
                            }
                            break;
                    }
                    break; 
                case ActionTypeEnum.Variable:
                    switch (VariableOp)
                    {
                        case VariableOpEnum.SetNumeric:
                            temp += I18n.Translate("internal/Action/descscalarnumeric", "set scalar variable ({0}) value with numeric expression ({1})", VariableName, VariableExpression);
                            break;
                        case VariableOpEnum.SetString:
                            temp += I18n.Translate("internal/Action/descscalarstring", "set scalar variable ({0}) value with string expression ({1})", VariableName, VariableExpression);
                            break;
                        case VariableOpEnum.Unset:
                            temp += I18n.Translate("internal/Action/descscalarunset", "unset scalar variable ({0})", VariableName);
                            break;
                        case VariableOpEnum.UnsetAll:
                            temp += I18n.Translate("internal/Action/descscalarunsetall", "unset all scalar variables");
                            break;
                    }
                    break;
                case ActionTypeEnum.Aura:
                    switch (AuraOp)
                    {
                        case AuraOpEnum.ActivateAura:
                            temp += I18n.Translate("internal/Action/descimgauraact", "activate image aura ({0}) with image ({1})", AuraName, AuraImage);
                            break;
                        case AuraOpEnum.DeactivateAura:
                            temp += I18n.Translate("internal/Action/descimgauradeact", "deactivate image aura ({0})", AuraName);
                            break;
                        case AuraOpEnum.DeactivateAllAura:
                            temp += I18n.Translate("internal/Action/descimgauradeactall", "deactivate all image auras");
                            break;
                    }
                    break;
                case ActionTypeEnum.TextAura:
                    switch (TextAuraOp)
                    {
                        case AuraOpEnum.ActivateAura:
                            temp += I18n.Translate("internal/Action/desctextauraact", "activate text aura ({0}) with expression ({1})", TextAuraName, TextAuraExpression);
                            break;
                        case AuraOpEnum.DeactivateAura:
                            temp += I18n.Translate("internal/Action/desctextauradeact", "deactivate text aura ({0})", TextAuraName);
                            break;
                        case AuraOpEnum.DeactivateAllAura:
                            temp += I18n.Translate("internal/Action/desctextauradeactall", "deactivate all text auras");
                            break;
                    }
                    break;
                case ActionTypeEnum.DiscordWebhook:
                    {
                        if (_DiscordTts == true)
                        {
                            temp += I18n.Translate("internal/Action/descdiscordttsmsg", "send TTS message ({0}) to Discord webhook ({1})", DiscordWebhookMessage, DiscordWebhookURL);
                        }
                        else
                        {
                            temp += I18n.Translate("internal/Action/descdiscordmsg", "send message ({0}) to Discord webhook ({1})", DiscordWebhookMessage, DiscordWebhookURL);
                        }
                    }
                    break;
                case ActionTypeEnum.EndEncounter:
                    {
                        temp += I18n.Translate("internal/Action/descendencounter", "end encounter");
                    }
                    break;
                case ActionTypeEnum.LogMessage:
                    {
                        if (_LogProcess == true)
                        {
                            temp += I18n.Translate("internal/Action/descprocessmessage", "process message ({0}) as log line", LogMessageText);
                        }
                        else
                        {
                            temp += I18n.Translate("internal/Action/desclogmessage", "log message ({0})", LogMessageText);
                        }                        
                    }
                    break;
                case ActionTypeEnum.WindowMessage:
                    temp += I18n.Translate("internal/Action/descwmsg", "send message ({0}) wparam ({1}) lparam ({2}) to window ({3})", WmsgCode, WmsgWparam, WmsgLparam, WmsgTitle);
                    break;
                default:
                    temp += I18n.Translate("internal/Action/descunknown", "unknown action type");
                    break;
            }
            return Capitalize(temp);
        }

        [XmlAttribute]
        public string KeyPressExpression
        {
            get
            {
                if (_KeyPressExpression == "")
                {
                    return null;
                }
                return _KeyPressExpression;
            }
            set
            {
                _KeyPressExpression = value;
            }
        }
        private string _KeyPressExpression;

        [XmlAttribute]
        public string KeyPressCode
        {
            get
            {
                if (_KeyPressCode == "")
                {
                    return null;
                }
                return _KeyPressCode;
            }
            set
            {
                _KeyPressCode = value;
            }
        }
        private string _KeyPressCode;

        [XmlAttribute]
        public string KeyPressWindow
        {
            get
            {
                if (_KeyPressWindow == "")
                {
                    return null;
                }
                return _KeyPressWindow;
            }
            set
            {
                _KeyPressWindow = value;
            }
        }
        private string _KeyPressWindow;

        internal List<WindowsMediaPlayer> players;

        public Action()
        {
            Id = Guid.NewGuid();
            Conditions = new EventList<Condition>();
            players = new List<WindowsMediaPlayer>();
            DefaultSettings();
        }

        public void DefaultSettings()
        {
            _Enabled = true;
            ActionType = ActionTypeEnum.SystemBeep;
            _Asynchronous = true;
            _RefireInterrupt = false;
            DebugLevel = Plugin.DebugLevelEnum.Inherit;
            _RefireRequeue = true;
            ExecutionDelayExpression = "0";
            SystemBeepFreqExpression = "1000";
            SystemBeepLengthExpression = "100";
            PlaySoundFileExpression = "";
            PlaySoundVolumeExpression = "100";
            _PlaySoundExclusive = true;
            _PlaySoundMyself = false;
            UseTTSTextExpression = "";
            UseTTSVolumeExpression = "100";
            UseTTSRateExpression = "0";
            _UseTTSExclusive = true;
            _PlaySpeechMyself = false;
            _LogProcess = false;
            LaunchProcessCmdlineExpression = "";
            LaunchProcessPathExpression = "";
            LaunchProcessWindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            LaunchProcessWorkingDirExpression = "";
            KeyPressExpression = "";
            ExecScriptAssembliesExpression = "";
            ExecScriptExpression = "";
            ExecScriptType = ScriptTypeEnum.CSharp;
            MessageBoxIconType = MessageBoxIconTypeEnum.None;
            MessageBoxText = "";
            VariableName = "";
            VariableExpression = "";
            VariableOp = VariableOpEnum.Unset;
            ListVariableName = "";
            ListVariableExpression = "";
            ListVariableExpressionType = ListVariableExpTypeEnum.String;
            ListVariableIndex = "";
            ListVariableOp = ListVariableOpEnum.Unset;
            ListVariableTarget = "";
            TriggerId = Guid.Empty;
            TriggerOp = TriggerOpEnum.FireTrigger;
            TriggerText = "";
            TriggerZone = "";
            TriggerForceType = TriggerForceTypeEnum.NoSkip;
            FolderOp = FolderOpEnum.EnableFolder;
            FolderId = Guid.Empty;
            AuraOp = AuraOpEnum.ActivateAura;
            AuraName = "";
            AuraImage = "";
            AuraImageMode = PictureBoxSizeMode.Normal;
            AuraXIniExpression = "";
            AuraYIniExpression = "";
            AuraWIniExpression = "";
            AuraHIniExpression = "";
            AuraOIniExpression = "";
            AuraXTickExpression = "";
            AuraYTickExpression = "";
            AuraWTickExpression = "";
            AuraHTickExpression = "";
            AuraOTickExpression = "";
            AuraTTLTickExpression = "";
            DiscordWebhookURL = "";
            DiscordWebhookMessage = "";
            _DiscordTts = false;
            TextAuraOp = AuraOpEnum.ActivateAura;
            TextAuraName = "";
            TextAuraExpression = "";
            TextAuraAlignment = TextAuraAlignmentEnum.MiddleCenter;
            TextAuraXIniExpression = "";
            TextAuraYIniExpression = "";
            TextAuraWIniExpression = "";
            TextAuraHIniExpression = "";
            TextAuraOIniExpression = "";
            TextAuraXTickExpression = "";
            TextAuraYTickExpression = "";
            TextAuraWTickExpression = "";
            TextAuraHTickExpression = "";
            TextAuraOTickExpression = "";
            TextAuraTTLTickExpression = "";
            TextAuraForeground = System.Drawing.ColorTranslator.ToHtml(Color.Black);
            TextAuraBackground = System.Drawing.ColorTranslator.ToHtml(Color.Transparent);
            TextAuraOutline = System.Drawing.ColorTranslator.ToHtml(Color.White);
            _TextAuraUseOutline = false;
            LogMessageText = "";
            OBSControlType = ObsControlTypeEnum.StartStreaming;
            OBSSceneName = "";
            OBSSourceName = "";
            JsonEndpointExpression = "";
            JsonPayloadExpression = "";
            JsonFiringExpression = "";
            KeypressType = KeypressTypeEnum.SendKeys;
            KeyPressCode = "";
            KeyPressWindow = "";
            WmsgTitle = "";
            WmsgCode = "";
            WmsgWparam = "";
            WmsgLparam = "";
        }

        private Plugin.DebugLevelEnum GetDebugLevel(Context ctx)
        {
            if (DebugLevel == Plugin.DebugLevelEnum.Inherit)
            {
                if (ctx.trig != null)
                {
                    return ctx.trig.GetDebugLevel(ctx.plug);
                }
                else
                {
                    return Plugin.DebugLevelEnum.Verbose;
                }
            }
            else
            {
                return DebugLevel;
            }
        }

        internal void AddToLog(Context ctx, Plugin.DebugLevelEnum level, string message)
        {
            Plugin.DebugLevelEnum dx = GetDebugLevel(ctx);
            if (level > dx)
            {
                return;
            }
            ctx.plug.UnfilteredAddToLog(level, message);
        }

        private VariableList GetListVariable(Plugin p, string varname, bool createNew)
        {
            if (p.listvariables.ContainsKey(varname) == true)
            {
                return p.listvariables[varname];
            }
            VariableList vl = new VariableList();
            if (createNew == true)
            {
                p.listvariables[varname] = vl;
            }
            return vl;
        }

        private string GetListExpressionValue(Context ctx, ListVariableExpTypeEnum typ, string expr)
        {
            switch (typ)
            {
                case ListVariableExpTypeEnum.Numeric:
                    return I18n.ThingToString(ctx.EvaluateNumericExpression(ActionContextLogger, ctx, expr));
                case ListVariableExpTypeEnum.String:
                    return ctx.EvaluateStringExpression(ActionContextLogger, ctx, expr);
            }
            return "";
        }

        private void ExecutionImplementation(Context ctx)
		{
			try
			{
                if ((ctx.force & Action.TriggerForceTypeEnum.SkipConditions) == 0 && ctx.testmode == false)
                {
                    if (Condition != null && Condition.Enabled == true)
                    {
                        if (Condition.CheckCondition(ctx, ActionContextLogger, ctx) == false)
                        {
                            AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/actionnotfired", "Action #{0} on trigger '{1}' not fired, condition not met", OrderNumber, (ctx.trig != null ? ctx.trig.LogName : "(null)")));
                            return;
                        }
                    }
                }
                AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/executingaction", "Executing action '{0}' in thread {1}", GetDescription(ctx), System.Threading.Thread.CurrentThread.ManagedThreadId));
				switch (ActionType)
				{
					case ActionTypeEnum.SystemBeep:
						{
							double freq = ctx.EvaluateNumericExpression(ActionContextLogger, ctx, SystemBeepFreqExpression);
                            if (freq < 37.0)
                            {                                
                                freq = 37.0;
                                AddToLog(ctx, Plugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/beepfreqlo", "Beep frequency below limit, capping to {0}", freq));
                            }
                            if (freq > 32767.0)
                            {
                                freq = 32767.0;
                                AddToLog(ctx, Plugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/beepfreqhi", "Beep frequency above limit, capping to {0} ", freq));
                            }
                            double len = ctx.EvaluateNumericExpression(ActionContextLogger, ctx, SystemBeepLengthExpression);
                            if (len < 0.0)
                            {
                                len = 0.0;
                                AddToLog(ctx, Plugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/beeplengthlo", "Beep length below limit, capping to {0}", len));
                            }
                            Console.Beep((int)Math.Ceiling(freq), (int)Math.Ceiling(len));
						}
						break;
					case ActionTypeEnum.PlaySound:
						{
                            ctx.soundhook(ctx, this);
                        }
                        break;
					case ActionTypeEnum.UseTTS:
						{
                            ctx.ttshook(ctx, this);
						}
						break;
					case ActionTypeEnum.LaunchProcess:
						{
							System.Diagnostics.Process p = new System.Diagnostics.Process();
							System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
							psi.Arguments = ctx.EvaluateStringExpression(ActionContextLogger, ctx, LaunchProcessCmdlineExpression);
							psi.WindowStyle = LaunchProcessWindowStyle;
							psi.WorkingDirectory = ctx.EvaluateStringExpression(ActionContextLogger, ctx, LaunchProcessWorkingDirExpression);
							psi.FileName = ctx.EvaluateStringExpression(ActionContextLogger, ctx, LaunchProcessPathExpression);
							p.StartInfo = psi;
							p.Start();
							if (_Asynchronous == false)
							{
                                AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/waitingprocexit", "Waiting for process to exit"));
                                p.WaitForExit();                                
							}
						}
						break;
					case ActionTypeEnum.Trigger:
						{
                            Trigger t = ctx.plug.GetTriggerById(TriggerId, ctx.trig != null ? ctx.trig.Repo : null);
                            if (t != null)
                            {
                                switch (TriggerOp)
                                {
                                    case TriggerOpEnum.CancelAllTrigger:
                                        ctx.plug.ClearActionQueue();
                                        break;
                                    case TriggerOpEnum.CancelTrigger:
                                        ctx.plug.CancelAllQueuedActionsFromTrigger(t);
                                        break;
                                    case TriggerOpEnum.FireTrigger:
                                        {
                                            LogEvent le = new LogEvent();
                                            le.Text = ctx.EvaluateStringExpression(ActionContextLogger, ctx, TriggerText);
                                            le.Zone = ctx.EvaluateStringExpression(ActionContextLogger, ctx, TriggerZone);
                                            le.Timestamp = DateTime.Now;
                                            ctx.plug.TestTrigger(t, le, TriggerForceType);
                                        }
                                        break;
                                    case TriggerOpEnum.EnableTrigger:
                                        {
                                            t.Enabled = true;
                                            TreeNode tn;
                                            if (ctx.trig.Repo == null)
                                            {
                                                tn = ctx.plug.LocateNodeHostingTrigger(ctx.plug.ui.treeView1.Nodes[0], t);
                                            }
                                            else
                                            {
                                                tn = ctx.plug.LocateNodeHostingTrigger(ctx.plug.ui.treeView1.Nodes[1], t);
                                            }
                                            if (tn != null)
                                            {
                                                AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/trigenable", "Trigger '{0}' enabled", t.LogName));
                                                tn.Checked = true;
                                            }
                                            else
                                            {
                                                AddToLog(ctx, Plugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/notreenodetrigenable", "Could not find tree node to modify for enabling trigger {0}", t.LogName));
                                            }
                                        }
                                        break;
                                    case TriggerOpEnum.DisableTrigger:
                                        {
                                            t.Enabled = false;
                                            TreeNode tn;
                                            if (ctx.trig.Repo == null)
                                            {
                                                tn = ctx.plug.LocateNodeHostingTrigger(ctx.plug.ui.treeView1.Nodes[0], t);
                                            }
                                            else
                                            {
                                                tn = ctx.plug.LocateNodeHostingTrigger(ctx.plug.ui.treeView1.Nodes[1], t);
                                            }
                                            if (tn != null)
                                            {
                                                AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/trigdisable", "Trigger '{0}' disabled", t.LogName));
                                                tn.Checked = false;
                                            }
                                            else
                                            {
                                                AddToLog(ctx, Plugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/notreenodetrigdisable", "Could not find tree node to modify for disabling trigger {0}", t.LogName));
                                            }
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                if (TriggerOp == TriggerOpEnum.CancelAllTrigger)
                                {
                                    ctx.plug.ClearActionQueue();
                                }
                                else
                                {
                                    AddToLog(ctx, Plugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/notrigiderror", "No trigger id, and op is not cancel all actions, unexpected"));
                                }
                            }
						}
                        break;
                    case ActionTypeEnum.KeyPress:
                        {
                            if (KeypressType == KeypressTypeEnum.SendKeys)
                            {
                                if (ctx.testmode == true)
                                {
                                    Thread.Sleep(2000);
                                }
                                string ks = ctx.EvaluateStringExpression(ActionContextLogger, ctx, KeyPressExpression);
                                SendKeys.SendWait(ks);
                            }
                            else
                            {
                                string window = ctx.EvaluateStringExpression(ActionContextLogger, ctx, KeyPressWindow);
                                int keycode = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, KeyPressCode);
                                Plugin.WindowsUtils.SendKeycode(window, (ushort)keycode);
                            }
                        }
						break;
                    case ActionTypeEnum.ExecuteScript:
                        {
                            CodeDomProvider pr = null;
                            switch (ExecScriptType)
                            {
                                case ScriptTypeEnum.CSharp:
                                    pr = CodeDomProvider.CreateProvider("CSharp");
                                    break;
                                case ScriptTypeEnum.VBScript:
                                    pr = CodeDomProvider.CreateProvider("VisualBasic");
                                    break;
                            }
                            using (pr)
                            {                                
                                CompilerParameters cp = new CompilerParameters();
                                cp.GenerateExecutable = true;
                                cp.GenerateInMemory = true;
                                cp.TreatWarningsAsErrors = false;                                                                
                                string assy = ctx.EvaluateStringExpression(ActionContextLogger, ctx, ExecScriptAssembliesExpression);
                                foreach (string sass in assy.Split(",".ToArray()))
                                {
                                    string saf = sass.Trim();
                                    AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/addingassembly", "Adding assembly {0}", saf));
                                    cp.ReferencedAssemblies.Add(saf);
                                }
                                List<string> temp = new List<string>();
                                temp.Add(ctx.EvaluateStringExpression(ActionContextLogger, ctx, ExecScriptExpression));
                                CompilerResults cr = pr.CompileAssemblyFromSource(cp, temp.ToArray());
                                if (cr.Errors.Count > 0)
                                {
                                    if (ctx.testmode == true)
                                    {
                                        string erm = "";
                                        if (cr.Errors.Count > 1)
                                        {
                                            erm = I18n.Translate("internal/Action/scripterrorplural", "{0} errors occurred while compiling the script.", cr.Errors.Count);
                                        }
                                        else
                                        {
                                            erm = I18n.Translate("internal/Action/scripterrorsingular", "An error occurred while compiling the script.");
                                        }
                                        erm += " ";
                                        if (cr.Errors.Count > 5)
                                        {
                                            erm += I18n.Translate("internal/Action/fivescripterrorsare", "The first five errors are:");
                                        }
                                        else
                                        {
                                            if (cr.Errors.Count == 1)
                                            {
                                                erm += I18n.Translate("internal/Action/scripterroris", "The error is:");
                                            }
                                            else
                                            { 
                                                erm += I18n.Translate("internal/Action/scripterrorsare", "The errors are:");
                                            }
                                        }
                                        int num = 0;                                        
                                        foreach (CompilerError ce in cr.Errors)
                                        {
                                            AddToLog(ctx, Plugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/scripterror", "Script error: {0} @ line {1}", ce.ErrorText, ce.Line));
                                            erm += Environment.NewLine + Environment.NewLine + I18n.Translate("internal/Action/shortscripterror", "{0} @ line {1}", ce.ErrorText, ce.Line);
                                            num++;
                                            if (num >= 5)
                                            {
                                                break;
                                            }
                                        }
                                        MessageBox.Show(erm, I18n.Translate("internal/Action/scriptexecerror", "Script execution error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        int num = 0;
                                        foreach (CompilerError ce in cr.Errors)
                                        {
                                            AddToLog(ctx, Plugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/scripterror", "Script error: {0} @ line {1}", ce.ErrorText, ce.Line));
                                            num++;
                                            if (num >= 5)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                }
                                cr.CompiledAssembly.EntryPoint.Invoke(null, null);
                            }
                        }
                        break;
                    case ActionTypeEnum.MessageBox:
                        {
                            MessageBox.Show(ctx.EvaluateStringExpression(ActionContextLogger, ctx, MessageBoxText), "", MessageBoxButtons.OK, (System.Windows.Forms.MessageBoxIcon)MessageBoxIconType);
                        }
                        break;
                    case ActionTypeEnum.ListVariable:
                        {
                            string varname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, ListVariableName);
                            string changer;
                            if (ctx.trig != null)
                            {
                                changer = I18n.Translate("internal/Action/changetagtrigaction", "Trigger '{0}' action '{1}'", ctx.trig.LogName, GetDescription(ctx));
                            }
                            else
                            {
                                changer = I18n.Translate("internal/Action/changetagtestmode", "Action '{0}' test mode", GetDescription(ctx));
                            }
                            switch (ListVariableOp)
                            {
                                case ListVariableOpEnum.Unset:
                                    lock (ctx.plug.listvariables) // verified
                                    {
                                        if (ctx.plug.listvariables.ContainsKey(varname) == true)
                                        {
                                            ctx.plug.listvariables.Remove(varname);
                                        }
                                    }
                                    AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listunset", "List variable ({0}) unset", varname));
                                    break;
                                case ListVariableOpEnum.Push:
                                    {
                                        string value = GetListExpressionValue(ctx, ListVariableExpressionType, ListVariableExpression);
                                        lock (ctx.plug.listvariables)
                                        {
                                            VariableList vl = GetListVariable(ctx.plug, varname, true);
                                            vl.Push(value, changer);
                                        }
                                        AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listpush", "Value ({0}) pushed to the end of list variable ({1})", value, varname));
                                    }
                                    break;
                                case ListVariableOpEnum.Insert:
                                    {
                                        string value = GetListExpressionValue(ctx, ListVariableExpressionType, ListVariableExpression);
                                        int index = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, ListVariableIndex);
                                        lock (ctx.plug.listvariables)
                                        {
                                            VariableList vl = GetListVariable(ctx.plug, varname, true);
                                            vl.Insert(index, value, changer);
                                        }
                                        AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listindexinsert", "Value ({0}) inserted to index ({1}) of list variable ({2})", value, index, varname));
                                    }
                                    break;
                                case ListVariableOpEnum.Set:
                                    {
                                        string value = GetListExpressionValue(ctx, ListVariableExpressionType, ListVariableExpression);
                                        int index = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, ListVariableIndex);
                                        lock (ctx.plug.listvariables)
                                        {
                                            VariableList vl = GetListVariable(ctx.plug, varname, true);
                                            vl.Set(index, value, changer);
                                        }
                                        AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listindexset", "Value ({0}) set to index ({1}) of list variable ({2})", value, index, varname));
                                    }
                                    break;
                                case ListVariableOpEnum.Remove:
                                    {
                                        int index = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, ListVariableIndex);
                                        lock (ctx.plug.listvariables)
                                        {
                                            VariableList vl = GetListVariable(ctx.plug, varname, false);
                                            vl.Remove(index, changer);
                                        }
                                        AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listindexunset", "Value removed from index ({0}) of list variable ({1})", index, varname));
                                    }
                                    break;
                                case ListVariableOpEnum.PopLast:
                                    {
                                        string newname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, ListVariableTarget);
                                        string newval = "";
                                        lock (ctx.plug.listvariables)
                                        {
                                            VariableList vl = GetListVariable(ctx.plug, varname, false);
                                            newval = vl.StackPop(changer);
                                        }
                                        lock (ctx.plug.simplevariables) // verified
                                        {
                                            if (ctx.plug.simplevariables.ContainsKey(newname) == false)
                                            {
                                                ctx.plug.simplevariables[newname] = new Variable();
                                            }
                                            Variable x = ctx.plug.simplevariables[newname];
                                            x.Value = newval;
                                            x.LastChanger = changer;
                                            x.LastChanged = DateTime.Now;
                                        }
                                        AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listpopend", "Value ({0}) popped from the end of list variable ({1}) into scalar variable ({2})", newval, varname, newname));
                                    }
                                    break;
                                case ListVariableOpEnum.PopFirst:
                                    {
                                        string newname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, ListVariableTarget);
                                        string newval = "";
                                        lock (ctx.plug.listvariables)
                                        {
                                            VariableList vl = GetListVariable(ctx.plug, varname, false);
                                            newval = vl.QueuePop(changer);
                                        }
                                        lock (ctx.plug.simplevariables) // verified
                                        {
                                            if (ctx.plug.simplevariables.ContainsKey(newname) == false)
                                            {
                                                ctx.plug.simplevariables[newname] = new Variable();
                                            }
                                            Variable x = ctx.plug.simplevariables[newname];
                                            x.Value = newval;
                                            x.LastChanger = changer;
                                            x.LastChanged = DateTime.Now;
                                        }
                                        AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listpopbegin", "Value ({0}) popped from the beginning of list variable ({1}) into scalar variable ({2})", newval, varname, newname));
                                    }
                                    break;
                                case ListVariableOpEnum.SortAlphaAsc:
                                    {
                                        lock (ctx.plug.listvariables)
                                        {
                                            VariableList vl = GetListVariable(ctx.plug, varname, false);
                                            vl.SortAlphaAsc(changer);
                                        }
                                        AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listsortasc", "List variable ({0}) sorted in ascending order", varname));
                                    }
                                    break;
                                case ListVariableOpEnum.SortAlphaDesc:
                                    {
                                        lock (ctx.plug.listvariables)
                                        {
                                            VariableList vl = GetListVariable(ctx.plug, varname, false);
                                            vl.SortAlphaDesc(changer);
                                        }
                                        AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listsortdesc", "List variable ({0}) sorted in descending order", varname));
                                    }
                                    break;
                                case ListVariableOpEnum.SortFfxivPartyAsc:
                                    {
                                        lock (ctx.plug.listvariables)
                                        {
                                            VariableList vl = GetListVariable(ctx.plug, varname, false);
                                            vl.SortFfxivPartyAsc(ctx.plug.cfg, changer);
                                        }
                                        AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listsortffxivasc", "List variable ({0}) sorted in FFXIV party ascending order", varname));
                                    }
                                    break;
                                case ListVariableOpEnum.SortFfxivPartyDesc:
                                    {
                                        lock (ctx.plug.listvariables)
                                        {
                                            VariableList vl = GetListVariable(ctx.plug, varname, false);
                                            vl.SortFfxivPartyDesc(ctx.plug.cfg, changer);
                                        }
                                        AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listsortffxivdesc", "List variable ({0}) sorted in FFXIV party descending order", varname));
                                    }
                                    break;
                                case ListVariableOpEnum.Copy:
                                    {
                                        string newname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, ListVariableTarget);
                                        lock (ctx.plug.listvariables)
                                        {
                                            VariableList vl = GetListVariable(ctx.plug, varname, false);
                                            VariableList newvl = new VariableList();
                                            foreach (string x in vl.Values)
                                            {
                                                newvl.Push(x, changer);
                                            }
                                            ctx.plug.listvariables[newname] = newvl;
                                        }
                                        AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listcopy", "List variable ({0}) copied to list variable ({1})", varname, newname));
                                    }
                                    break;
                                case ListVariableOpEnum.InsertList:
                                    {
                                        string newname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, ListVariableTarget);
                                        int index = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, ListVariableIndex);
                                        int rindex = index;                                        
                                        lock (ctx.plug.listvariables)
                                        {
                                            VariableList vl = GetListVariable(ctx.plug, varname, false);
                                            VariableList newvl = GetListVariable(ctx.plug, newname, true);
                                            foreach (string x in vl.Values)
                                            {
                                                newvl.Insert(rindex, x, changer);
                                                rindex++;
                                            }                                            
                                        }
                                        AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listinsertlist", "List variable ({0}) inserted to list variable ({1}) at index ({2})", varname, newname, index));
                                    }
                                    break;
                                case ListVariableOpEnum.Join:
                                    {
                                        string separator = GetListExpressionValue(ctx, ListVariableExpressionType, ListVariableExpression);
                                        string newname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, ListVariableTarget);
                                        string newval = "";
                                        lock (ctx.plug.listvariables)
                                        {
                                            VariableList vl = GetListVariable(ctx.plug, varname, false);
                                            newval = vl.Join(separator);
                                        }
                                        lock (ctx.plug.simplevariables) // verified
                                        {
                                            if (ctx.plug.simplevariables.ContainsKey(newname) == false)
                                            {
                                                ctx.plug.simplevariables[newname] = new Variable();
                                            }
                                            Variable x = ctx.plug.simplevariables[newname];
                                            x.Value = newval;
                                            x.LastChanger = changer;
                                            x.LastChanged = DateTime.Now;
                                        }
                                        AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listscalarjoin", "List variable ({0}) joined to scalar variable ({1}) with separator ({2})", varname, newname, separator));
                                    }
                                    break;
                                case ListVariableOpEnum.Split:
                                    {
                                        string separator = GetListExpressionValue(ctx, ListVariableExpressionType, ListVariableExpression);
                                        string newname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, ListVariableTarget);
                                        string splitval = "";
                                        lock (ctx.plug.simplevariables) // verified
                                        {
                                            if (ctx.plug.simplevariables.ContainsKey(varname) == true)
                                            {
                                                splitval = ctx.plug.simplevariables[varname].Value;
                                            }
                                        }
                                        string[] vals = splitval.Split(new string[] { separator }, StringSplitOptions.None);
                                        lock (ctx.plug.listvariables)
                                        {
                                            VariableList newvl = new VariableList();
                                            foreach (string x in vals)
                                            {
                                                newvl.Push(x, changer);
                                            }
                                            ctx.plug.listvariables[newname] = newvl;
                                        }
                                        AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarlistsplit", "Scalar variable ({0}) split into list variable ({1}) with separator ({2})", varname, newname, separator));
                                    }
                                    break;
                                case ListVariableOpEnum.UnsetAll:
                                    lock (ctx.plug.listvariables) // verified
                                    {
                                        ctx.plug.listvariables.Clear();
                                    }
                                    AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/alllistunset", "All list variables unset"));
                                    break;
                            }
                        }
                        break;
                    case ActionTypeEnum.ObsControl:
                        if (ctx.plug._obs != null) {
                            lock (ctx.plug._obs)
                            {
                                if (ObsConnector(ctx) == true)
                                {
                                    try
                                    {
                                        switch (OBSControlType)
                                        {
                                            case ObsControlTypeEnum.StartStreaming:
                                                ctx.plug._obs.StartStreaming();
                                                break;
                                            case ObsControlTypeEnum.StopStreaming:
                                                ctx.plug._obs.StopStreaming();
                                                break;
                                            case ObsControlTypeEnum.ToggleStreaming:
                                                ctx.plug._obs.ToggleStreaming();
                                                break;
                                            case ObsControlTypeEnum.StartRecording:
                                                ctx.plug._obs.StartRecording();
                                                break;
                                            case ObsControlTypeEnum.StopRecording:
                                                ctx.plug._obs.StopRecording();
                                                break;
                                            case ObsControlTypeEnum.ToggleRecording:
                                                ctx.plug._obs.ToggleRecording();
                                                break;
                                            case ObsControlTypeEnum.StartReplayBuffer:
                                                ctx.plug._obs.StartReplayBuffer();
                                                break;
                                            case ObsControlTypeEnum.StopReplayBuffer:
                                                ctx.plug._obs.StopReplayBuffer();
                                                break;
                                            case ObsControlTypeEnum.ToggleReplayBuffer:
                                                ctx.plug._obs.ToggleReplayBuffer();
                                                break;
                                            case ObsControlTypeEnum.SaveReplayBuffer:
                                                ctx.plug._obs.SaveReplayBuffer();
                                                break;
                                            case ObsControlTypeEnum.SetScene:
                                                {
                                                    string scn = ctx.EvaluateStringExpression(ActionContextLogger, ctx, OBSSceneName);
                                                    ctx.plug._obs.SetCurrentScene(scn);
                                                }
                                                break;
                                            case ObsControlTypeEnum.ShowSource:
                                                {
                                                    string scn = ctx.EvaluateStringExpression(ActionContextLogger, ctx, OBSSceneName);
                                                    string src = ctx.EvaluateStringExpression(ActionContextLogger, ctx, OBSSourceName);
                                                    ctx.plug._obs.ShowSource(scn, src);
                                                }
                                                break;
                                            case ObsControlTypeEnum.HideSource:
                                                {
                                                    string scn = ctx.EvaluateStringExpression(ActionContextLogger, ctx, OBSSceneName);
                                                    string src = ctx.EvaluateStringExpression(ActionContextLogger, ctx, OBSSourceName);
                                                    ctx.plug._obs.HideSource(scn, src);
                                                }
                                                break;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        AddToLog(ctx, Plugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/obscontrolexception", "Can't execute OBS control action due to exception: " + ex.Message));
                                    }
                                }
                                else
                                {
                                    AddToLog(ctx, Plugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/obscontrolerror", "Can't execute OBS control action due to error"));
                                }
                            }
                        }
                        break;
                    case ActionTypeEnum.Variable:
                        {
                            string varname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, VariableName);
                            string newval;
                            switch (VariableOp)
                            {
                                case VariableOpEnum.UnsetAll:
                                    {                                        
                                        lock (ctx.plug.simplevariables) // verified
                                        {
                                            ctx.plug.simplevariables.Clear();
                                        }
                                        AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/allscalarunset", "All scalar variables unset"));
                                        break;
                                    }
                                case VariableOpEnum.Unset:
                                    {
                                        lock (ctx.plug.simplevariables) // verified
                                        {
                                            if (ctx.plug.simplevariables.ContainsKey(varname) == true)
                                            {
                                                ctx.plug.simplevariables.Remove(varname);
                                            }
                                        }
                                        AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarunset", "Scalar variable ({0}) unset", varname));
                                        break;
                                    }
                                case VariableOpEnum.SetString:
                                case VariableOpEnum.SetNumeric:
                                    {
                                        if (VariableOp == VariableOpEnum.SetString)
                                        {
                                            newval = ctx.EvaluateStringExpression(ActionContextLogger, ctx, VariableExpression);
                                        }
                                        else
                                        {
                                            newval = I18n.ThingToString(ctx.EvaluateNumericExpression(ActionContextLogger, ctx, VariableExpression));
                                        }
                                        lock (ctx.plug.simplevariables) // verified
                                        {
                                            if (ctx.plug.simplevariables.ContainsKey(varname) == false)
                                            {
                                                ctx.plug.simplevariables[varname] = new Variable();
                                            }
                                            Variable x = ctx.plug.simplevariables[varname];
                                            x.Value = newval;
                                            if (ctx.trig != null)
                                            {
                                                x.LastChanger = I18n.Translate("internal/Action/changetagtrigaction", "Trigger '{0}' action '{1}'", ctx.trig.LogName, GetDescription(ctx));
                                            }
                                            else
                                            {
                                                x.LastChanger = I18n.Translate("internal/Action/changetagtestmode", "Action '{0}' test mode", GetDescription(ctx));
                                            }                                            
                                            x.LastChanged = DateTime.Now;
                                        }
                                        AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarset", "Scalar variable ({0}) value set to ({1})", varname, newval));
                                        break;
                                    }
                            }
                        }
                        break;
                    case ActionTypeEnum.Aura:
                        {
                            ctx.plug.ImageAuraManagement(ctx, this);
                        }
                        break;
                    case ActionTypeEnum.TextAura:
                        {
                            ctx.plug.TextAuraManagement(ctx, this);
                        }
                        break;
                    case ActionTypeEnum.Folder:
                        {
                            Folder f = ctx.plug.GetFolderById(FolderId, ctx.trig != null ? ctx.trig.Repo : null);
                            if (f != null)
                            {
                                switch (FolderOp)
                                {
                                    case FolderOpEnum.DisableFolder:
                                        {
                                            f.Enabled = false;
                                            TreeNode tn;
                                            if (ctx.trig.Repo == null)
                                            {
                                                tn = ctx.plug.LocateNodeHostingFolder(ctx.plug.ui.treeView1.Nodes[0], f);
                                            }
                                            else
                                            {
                                                tn = ctx.plug.LocateNodeHostingFolder(ctx.plug.ui.treeView1.Nodes[1], f);
                                            }
                                            if (tn != null)
                                            {
                                                tn.Checked = false;
                                            }
                                            else
                                            {
                                                AddToLog(ctx, Plugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/notreenodefolderwithid", "Didn't find a tree node for folder ({0}) with id ({1})", f.Name, f.Id));
                                            }
                                            AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/disabledfolderwithid", "Disabled folder ({0}) with id ({1})", f.Name, f.Id));
                                        }
                                        break;
                                    case FolderOpEnum.EnableFolder:
                                        {
                                            f.Enabled = true;
                                            TreeNode tn;
                                            if (ctx.trig.Repo == null)
                                            {
                                                tn = ctx.plug.LocateNodeHostingFolder(ctx.plug.ui.treeView1.Nodes[0], f);
                                            }
                                            else
                                            {
                                                tn = ctx.plug.LocateNodeHostingFolder(ctx.plug.ui.treeView1.Nodes[1], f);
                                            }
                                            if (tn != null)
                                            {
                                                tn.Checked = true;
                                            }
                                            else
                                            {
                                                AddToLog(ctx, Plugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/notreenodefolderwithid", "Didn't find a tree node for folder ({0}) with id ({1})", f.Name, f.Id));
                                            }
                                            AddToLog(ctx, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/enabledfolderwithid", "Enabled folder ({0}) with id ({1})", f.Name, f.Id));
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                AddToLog(ctx, Plugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/nofolderwithid", "Didn't find a folder with id ({0})", FolderId));
                            }
                        }
                        break;
                    case ActionTypeEnum.GenericJson:
                        {
                            string endpoint = ctx.EvaluateStringExpression(ActionContextLogger, ctx, JsonEndpointExpression);
                            string payload = ctx.EvaluateStringExpression(ActionContextLogger, ctx, JsonPayloadExpression);
                            string response = PostJson(ctx, endpoint, payload, false);
                            if (JsonFiringExpression != null && JsonFiringExpression.Trim().Length > 0)
                            {
                                string firing = "";
                                lock (ctx.contextResponse)
                                {
                                    ctx.contextResponse = response;
                                    firing = ctx.EvaluateStringExpression(ActionContextLogger, ctx, JsonFiringExpression);
                                }
                                if (firing.Length > 0)
                                {
                                    ctx.plug.LogLineQueuer(firing, "", LogEvent.SourceEnum.Log);
                                }
                            }
                        }
                        break;
                    case ActionTypeEnum.DiscordWebhook:
                        {
                            string msg = ctx.EvaluateStringExpression(ActionContextLogger, ctx, DiscordWebhookMessage);
                            string url = ctx.EvaluateStringExpression(ActionContextLogger, ctx, DiscordWebhookURL);
                            if (_DiscordTts == true)
                            {
                                if (msg.Length > 1970)
                                {
                                    msg = msg.Substring(0, 1970);
                                    AddToLog(ctx, Plugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/warndiscordtrunc", "Discord message too long, capping to {0}", msg.Length));
                                }
                                var wh = new JavaScriptSerializer().Serialize(new { content = msg, tts = true });
                                PostJson(ctx, url, wh, true);
                            }
                            else
                            {
                                if (msg.Length > 1980)
                                {
                                    msg = msg.Substring(0, 1980);
                                    AddToLog(ctx, Plugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/warndiscordtrunc", "Discord message too long, capping to {0}", msg.Length));
                                }
                                var wh = new JavaScriptSerializer().Serialize(new { content = msg });
                                PostJson(ctx, url, wh, true);
                            }
                        }
                        break;
                    case ActionTypeEnum.EndEncounter:
                        {
                            ctx.plug.EndEncounter();
                        }
                        break;
                    case ActionTypeEnum.LogMessage:
                        {
                            if (_LogProcess == true)
                            {
                                ctx.plug.LogLineQueuer(ctx.EvaluateStringExpression(ActionContextLogger, ctx, LogMessageText), "", LogEvent.SourceEnum.Log);
                            }
                            else
                            {
                                AddToLog(ctx, Plugin.DebugLevelEnum.Error, ctx.EvaluateStringExpression(ActionContextLogger, ctx, LogMessageText));
                            }
                        }
                        break;
                    case ActionTypeEnum.WindowMessage:
                        {
                            string window = ctx.EvaluateStringExpression(ActionContextLogger, ctx, WmsgTitle);
                            int code = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, WmsgCode);
                            int wparam = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, WmsgWparam);
                            int lparam = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, WmsgLparam);
                            Plugin.WindowsUtils.SendMessageToWindow(window, (ushort)code, wparam, lparam);
                        }
                        break;
                }
            }
			catch (Exception ex)
			{
                AddToLog(ctx, Plugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/exception", "Exception: {0}", ex.Message));
            }
		}

        internal void Mywmp_PlayStateChange(int NewState)
        {
            if ((WMPLib.WMPPlayState)NewState != WMPLib.WMPPlayState.wmppsStopped)
            {
                return;
            }
            WindowsMediaPlayer wmp = null;
            lock (players) // verified
            {
                do
                {
                    wmp = null;
                    foreach (WindowsMediaPlayer x in players)
                    {                        
                        if (x.playState == WMPPlayState.wmppsStopped)
                        {
                            wmp = x;
                            break;
                        }
                    }
                    if (wmp != null)
                    {
                        players.Remove(wmp);
                    }
                } while (wmp != null);
            }
        }

        internal void Mywmp_MediaError(object pMediaObject)
        {
            WindowsMediaPlayer wmp = (WindowsMediaPlayer)pMediaObject;
            lock (players) // verified
            {
                players.Remove(wmp);                
            }
        }

        internal void Execute(Context ctx)
        {
            if (_Asynchronous == true)
            {
                Task t;
                if (ctx.plug != null)
                {
                    CancellationToken ct = ctx.plug.GetCancellationToken();
                    t = new Task(() =>
                    {
                        ct.ThrowIfCancellationRequested();
                        ExecutionImplementation(ctx);
                    });
                }
                else
                {
                    t = new Task(() =>
                    {
                        ExecutionImplementation(ctx);
                    });
                }
                t.Start();
            }
            else
            {
                ExecutionImplementation(ctx);
            }
        }

        internal void CopySettingsTo(Action a)
        {
            a.Id = Id;
            a.ActionType = ActionType;
            a.OrderNumber = OrderNumber;
            a._Asynchronous = _Asynchronous;
            a._Enabled = _Enabled;
            a.ExecutionDelayExpression = ExecutionDelayExpression;
            a.KeyPressExpression = KeyPressExpression;
            a.LaunchProcessCmdlineExpression = LaunchProcessCmdlineExpression;
            a.LaunchProcessPathExpression = LaunchProcessPathExpression;
            a.LaunchProcessWindowStyle = LaunchProcessWindowStyle;
            a.LaunchProcessWorkingDirExpression = LaunchProcessWorkingDirExpression;
            a._PlaySoundExclusive = _PlaySoundExclusive;
            a._PlaySoundMyself = _PlaySoundMyself;
            a.PlaySoundFileExpression = PlaySoundFileExpression;
            a.PlaySoundVolumeExpression = PlaySoundVolumeExpression;
            a._RefireInterrupt = _RefireInterrupt;
            a._RefireRequeue = _RefireRequeue;
            a.SystemBeepFreqExpression = SystemBeepFreqExpression;
            a.SystemBeepLengthExpression = SystemBeepLengthExpression;
            a._UseTTSExclusive = _UseTTSExclusive;
            a.UseTTSRateExpression = UseTTSRateExpression;
            a.UseTTSTextExpression = UseTTSTextExpression;
            a.UseTTSVolumeExpression = UseTTSVolumeExpression;
            a._PlaySpeechMyself = _PlaySpeechMyself;
            a.ExecScriptAssembliesExpression = ExecScriptAssembliesExpression;
            a.ExecScriptExpression = ExecScriptExpression;
            a.MessageBoxIconType = MessageBoxIconType;
            a.MessageBoxText = MessageBoxText;
            a.VariableOp = VariableOp;
            a.VariableName = VariableName;
            a.DebugLevel = DebugLevel;
            a.VariableExpression = VariableExpression;
            a.TriggerId = TriggerId;
            a.TriggerOp = TriggerOp;
            a.TriggerText = TriggerText;
            a.TriggerZone = TriggerZone;
            a.TriggerForce = TriggerForce;
            a.TriggerForceType = TriggerForceType;
            a.AuraOp = AuraOp;
            a.AuraName = AuraName;
            a.AuraImage = AuraImage;
            a.AuraImageMode = AuraImageMode;
            a.AuraXIniExpression = AuraXIniExpression;
            a.AuraYIniExpression = AuraYIniExpression;
            a.AuraWIniExpression = AuraWIniExpression;
            a.AuraHIniExpression = AuraHIniExpression;
            a.AuraOIniExpression = AuraOIniExpression;
            a.AuraXTickExpression = AuraXTickExpression;
            a.AuraYTickExpression = AuraYTickExpression;
            a.AuraWTickExpression = AuraWTickExpression;
            a.AuraHTickExpression = AuraHTickExpression;
            a.AuraOTickExpression = AuraOTickExpression;
            a.AuraTTLTickExpression = AuraTTLTickExpression;
            a.FolderOp = FolderOp;
            a.FolderId = FolderId;
            a.DiscordWebhookMessage = DiscordWebhookMessage;
            a.DiscordWebhookURL = DiscordWebhookURL;
            a.TextAuraOp = TextAuraOp;
            a.TextAuraName = TextAuraName;
            a.TextAuraExpression = TextAuraExpression;
            a.TextAuraAlignment = TextAuraAlignment;
            a.TextAuraXIniExpression = TextAuraXIniExpression;
            a.TextAuraYIniExpression = TextAuraYIniExpression;
            a.TextAuraWIniExpression = TextAuraWIniExpression;
            a.TextAuraHIniExpression = TextAuraHIniExpression;
            a.TextAuraOIniExpression = TextAuraOIniExpression;
            a.TextAuraXTickExpression = TextAuraXTickExpression;
            a.TextAuraYTickExpression = TextAuraYTickExpression;
            a.TextAuraWTickExpression = TextAuraWTickExpression;
            a.TextAuraHTickExpression = TextAuraHTickExpression;
            a.TextAuraOTickExpression = TextAuraOTickExpression;
            a.TextAuraTTLTickExpression = TextAuraTTLTickExpression;
            a.TextAuraFontName = TextAuraFontName;
            a.TextAuraFontSize = TextAuraFontSize;
            a.TextAuraEffect = TextAuraEffect;
            a.TextAuraOutline = TextAuraOutline;
            a.TextAuraForeground = TextAuraForeground;
            a.TextAuraBackground = TextAuraBackground;
            a._TextAuraUseOutline = _TextAuraUseOutline;
            a.LogMessageText = LogMessageText;
            a._DiscordTts = _DiscordTts;
            a.ListVariableExpression = ListVariableExpression;
            a.ListVariableExpressionType = ListVariableExpressionType;
            a.ListVariableIndex = ListVariableIndex;
            a.ListVariableName = ListVariableName;
            a.ListVariableOp = ListVariableOp;
            a.ListVariableTarget = ListVariableTarget;
            a.OBSControlType = OBSControlType;
            a.OBSSceneName = OBSSceneName;
            a.OBSSourceName = OBSSourceName;
            a._LogProcess = _LogProcess;
            a.JsonEndpointExpression = _JsonEndpointExpression;
            a.JsonFiringExpression = _JsonFiringExpression;
            a.JsonPayloadExpression = _JsonPayloadExpression;
            a.Condition = (ConditionGroup)(Condition != null ? ((ConditionGroup)Condition).Duplicate() : null);
            a.KeypressType = KeypressType;
            a._KeyPressCode = _KeyPressCode;
            a._KeyPressWindow = _KeyPressWindow;
            a._WmsgCode = _WmsgCode;
            a._WmsgTitle = _WmsgTitle;
            a._WmsgLparam = _WmsgLparam;
            a._WmsgWparam = _WmsgWparam;
        }

        private string PostJson(Context ctx, string url, string json, bool expectNoContent)
        {
            try
            {                
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode != HttpStatusCode.NoContent && expectNoContent == true)
                {
                    AddToLog(ctx, Plugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/jsonpostunexpectedresponse", "Unexpected response code: {0}", httpResponse.StatusCode));
                }
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                AddToLog(ctx, Plugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/jsonpostexception", "Couldn't send message due to exception: {0}", ex.Message));
                return "";
            }
        }

    }

}
