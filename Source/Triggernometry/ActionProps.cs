using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry
{

    public partial class Action
    {

        #region Enums

        public enum ActionTypeEnum
        {
            SystemBeep,
            PlaySound,
            UseTTS,
            Variable,
            ListVariable,
            TableVariable,
            DictVariable,
            MessageBox,
            LogMessage,
            TextAura,
            Aura,
            Mouse,
            KeyPress,
            NamedCallback,
            WindowMessage,
            DiskFile,
            LaunchProcess,
            ExecuteScript,
            Mutex,
            Loop,
            GenericJson,
            DiscordWebhook,
            LiveSplitControl,
            ObsControl,
            ActInteraction,
            Trigger,
            Folder,
            Repository,
            Placeholder,
            // Old actions:
            // EndEncounter => ActInteraction
        }

        public enum VariableOpEnum
        {
            Unset,
            SetString,
            SetNumeric,
            Increment,
            Clipboard,
            UnsetAll,
            UnsetRegex,
            UnsetRegexUniversal,
            QueryJsonPath,
            QueryJsonPathList
        }

        public enum TableVariableOpEnum
        {
            Unset,
            Set,
            SetAll,
            SlicesSetAll,
            Resize,
            Build,
            SetLine,
            InsertLine,
            RemoveLine,
            Filter,
            FilterLine,
            Copy,
            Append,
            AppendH,
            SortLine,
            GetAllEntities,
            UnsetAll,
            UnsetRegex,
        }

        public enum TableVariableExpTypeEnum
        {
            String,
            Numeric
        }

        public enum DictVariableOpEnum
        {
            Unset,
            Set,
            Remove,
            SetAll,
            Build,
            Filter,
            Merge,
            MergeHard,
            GetEntity,
            UnsetAll,
            UnsetRegex,
            [Obsolete] GetEntityByName, // => GetEntity
            [Obsolete] GetEntityById, // => GetEntity
        }

        public enum DictVariableExpTypeEnum
        {
            String,
            Numeric
        }

        public enum DiskFileOpEnum
        {
            ReadIntoVariable,
            ReadIntoListVariable,
            ReadCSVIntoTableVariable
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
            DisableFolder,
            CancelFolder,
        }

        public enum AuraOpEnum
        {
            ActivateAura,
            DeactivateAura,
            DeactivateAllAura,
            DeactivateAuraRegex,
            DeactivateAuraTrigger
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
            SetAll,
            Remove,
            PopFirst,
            PopToListInsert,
            PopToListSet,
            Build,
            Filter,
            Join,
            Split,
            Copy,
            InsertList,
            SortNumericAsc,
            SortNumericDesc,
            SortAlphaAsc,
            SortAlphaDesc,
            SortFfxivPartyAsc,
            SortFfxivPartyDesc,
            SortByKeys,
            UnsetAll,
            UnsetRegex,
            // Old
            // PopLast => PopFirst
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
            RestartRecording,
            RestartRecordingIfActive,
            ResumeRecording,
            PauseRecording,
            ToggleRecordPause,
            StartReplayBuffer,
            StopReplayBuffer,
            ToggleReplayBuffer,
            SaveReplayBuffer,
            SetScene,
            ShowSource,
            HideSource,
            JSONPayload
        }

        public enum LiveSplitControlTypeEnum
        {
            StartOrSplit,
            Start,
            Split,
            UndoSplit,
            SkipSplit,
            Reset,
            Pause,
            Resume,
            CustomPayload
        }

        public enum KeypressTypeEnum
        {
            SendKeys,
            WindowMessage,
            WindowMessageCombo
        }

        public enum MutexOpEnum
        {
            Release,
            Acquire
        }

        public enum LogMessageEnum
        {
            Error,
            Warning,
            Custom,
            Custom2,
            Info,
            Verbose,
        }

        [Flags]
        public enum TriggerForceTypeEnum
        {
            NoSkip = 0,
            SkipRegexp = 1,
            SkipConditions = 2,
            SkipRefire = 4,
            SkipParent = 8,
            SkipActive = 16,
            SkipExceptConditions = SkipRegexp | SkipRefire | SkipParent | SkipActive,
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

        public enum MouseOpEnum
        {
            Move,
            LeftClick,
            MiddleClick,
            RightClick
        }

        public enum MouseCoordEnum
        {
            Absolute,
            Relative
        }

        public enum HTTPMethodEnum
        {
            POST,
            GET
        }

        public enum RepositoryOpEnum
        {
            UpdateSelf,
            UpdateRepo,
            UpdateAll
        }

        public enum TriggerZoneTypeEnum
        {
            ZoneName,
            ZoneIdFFXIV
        }

        public enum ActInteractionTypeEnum
        {
            SetCombatState,
            LogAllNetwork,
            UseDeucalion,
        }

        #endregion

        #region Action specific properties - ACT Interaction operation

        internal ActInteractionTypeEnum _ActOpType { get; set; } = ActInteractionTypeEnum.SetCombatState;
        [XmlAttribute]
        public string ActOpType
        {
            get => _ActOpType != ActInteractionTypeEnum.SetCombatState ? _ActOpType.ToString() : null;
            set
            {
                _ActOpType = (ActInteractionTypeEnum)Enum.Parse(typeof(ActInteractionTypeEnum), value);
            }
        }

        internal bool _ActOpBoolParam { get; set; } = false;
        [XmlAttribute]
        public string ActOpBoolParam
        {
            get => _ActOpBoolParam ? _ActOpBoolParam.ToString() : null;
            set
            {
                _ActOpBoolParam = bool.Parse(value);
            }
        }

        internal string _ActOpStringParam = "";
        [XmlAttribute]
        public string ActOpStringParam
        {
            get => _ActOpStringParam != "" ? _ActOpStringParam : null;
            set
            {
                _ActOpStringParam = value;
            }
        }

        #endregion
        #region Action specific properties - Beep

        internal string _SystemBeepFreqExpression = "1046.5"; // freq(C6)
        [XmlAttribute]
        public string SystemBeepFreqExpression
        {
            get
            {
                if (_SystemBeepFreqExpression == "1046.5")
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

        internal string _SystemBeepLengthExpression = "100";
        [XmlAttribute]
        public string SystemBeepLengthExpression
        {
            get
            {
                if (_SystemBeepLengthExpression == "100")
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

        #endregion
        #region Action specific properties - Dict variable

        internal DictVariableOpEnum _DictVariableOp { get; set; } = DictVariableOpEnum.Unset;
        [XmlAttribute]
        public string DictVariableOp
        {
            get
            {
                if (_DictVariableOp != DictVariableOpEnum.Unset)
                {
                    return _DictVariableOp.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _DictVariableOp = (DictVariableOpEnum)Enum.Parse(typeof(DictVariableOpEnum), value);
#pragma warning disable CS0612 // obsolete
                if (_DictVariableOp == DictVariableOpEnum.GetEntityByName || 
                    _DictVariableOp == DictVariableOpEnum.GetEntityById)
#pragma warning restore CS0612
                {
                    _DictVariableOp = DictVariableOpEnum.GetEntity;
                }
            }
        }

        internal DictVariableExpTypeEnum _DictVariableKeyType { get; set; } = DictVariableExpTypeEnum.String;
        [XmlAttribute]
        public string DictVariableKeyType
        {
            get
            {
                return (_DictVariableKeyType != DictVariableExpTypeEnum.String) ? _DictVariableKeyType.ToString() : null;
            }
            set
            {
                _DictVariableKeyType = (DictVariableExpTypeEnum)Enum.Parse(typeof(DictVariableExpTypeEnum), value);
            }
        }

        internal DictVariableExpTypeEnum _DictVariableValueType { get; set; } = DictVariableExpTypeEnum.String;
        [XmlAttribute]
        public string DictVariableValueType
        {
            get
            {
                return (_DictVariableValueType != DictVariableExpTypeEnum.String) ? _DictVariableValueType.ToString() : null;
            }
            set
            {
                _DictVariableValueType = (DictVariableExpTypeEnum)Enum.Parse(typeof(DictVariableExpTypeEnum), value);
            }
        }

        internal string _DictVariableName = "";
        [XmlAttribute]
        public string DictVariableName
        {
            get
            {
                return (_DictVariableName == "") ? null : _DictVariableName;
            }
            set
            {
                _DictVariableName = value;
            }
        }

        internal string _DictVariableTarget = "";
        [XmlAttribute]
        public string DictVariableTarget
        {
            get
            {
                return (_DictVariableTarget == "") ? null : _DictVariableTarget;
            }
            set
            {
                _DictVariableTarget = value;
            }
        }

        internal string _DictVariableLength = "";
        [XmlAttribute]
        public string DictVariableLength
        {
            get
            {
                return (_DictVariableLength == "") ? null : _DictVariableLength;
            }
            set
            {
                _DictVariableLength = value;
            }
        }

        internal string _DictVariableKey = "";
        [XmlAttribute]
        public string DictVariableKey
        {
            get
            {
                return (_DictVariableKey == "") ? null : _DictVariableKey;
            }
            set
            {
                _DictVariableKey = value;
            }
        }

        internal string _DictVariableValue = "";
        [XmlAttribute]
        public string DictVariableValue
        {
            get
            {
                return (_DictVariableValue == "") ? null : _DictVariableValue;
            }
            set
            {
                _DictVariableValue = value;
            }
        }

        internal bool _DictSourcePersist { get; set; } = false;
        [XmlAttribute]
        public string DictSourcePersist
        {
            get
            {
                return (_DictSourcePersist) ? _DictSourcePersist.ToString() : null;
            }
            set
            {
                _DictSourcePersist = Boolean.Parse(value);
            }
        }

        internal bool _DictTargetPersist { get; set; } = false;
        [XmlAttribute]
        public string DictTargetPersist
        {
            get
            {
                return (_DictTargetPersist) ? _DictTargetPersist.ToString() : null;
            }
            set
            {
                _DictTargetPersist = Boolean.Parse(value);
            }
        }

        #endregion
        #region Action specific properties - Discord webhook

        internal string _DiscordWebhookURL = "";
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

        internal string _DiscordWebhookMessage = "";
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

        internal bool _DiscordTts { get; set; } = false;
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

        #endregion
        #region Action specific properties - Disk operation

        internal DiskFileOpEnum _DiskFileOp { get; set; } = DiskFileOpEnum.ReadIntoVariable;
        [XmlAttribute]
        public string DiskFileOp
        {
            get
            {
                if (_DiskFileOp != DiskFileOpEnum.ReadIntoVariable)
                {
                    return _DiskFileOp.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _DiskFileOp = (DiskFileOpEnum)Enum.Parse(typeof(DiskFileOpEnum), value);
            }
        }

        internal string _DiskFileOpName;
        [XmlAttribute]
        public string DiskFileOpName
        {
            get
            {
                if (_DiskFileOpName == "")
                {
                    return null;
                }
                return _DiskFileOpName;
            }
            set
            {
                _DiskFileOpName = value;
            }
        }
        internal string _DiskFileOpVar;
        [XmlAttribute]
        public string DiskFileOpVar
        {
            get
            {
                if (_DiskFileOpVar == "")
                {
                    return null;
                }
                return _DiskFileOpVar;
            }
            set
            {
                _DiskFileOpVar = value;
            }
        }

        internal bool _DiskFileCache { get; set; } = false;
        [XmlAttribute]
        public string DiskFileCache
        {
            get
            {
                if (_DiskFileCache == false)
                {
                    return null;
                }
                return _DiskFileCache.ToString();
            }
            set
            {
                _DiskFileCache = Boolean.Parse(value);
            }
        }

        internal bool _DiskPersist { get; set; } = false;
        [XmlAttribute]
        public string DiskPersist
        {
            get
            {
                if (_DiskPersist == false)
                {
                    return null;
                }
                return _DiskPersist.ToString();
            }
            set
            {
                _DiskPersist = Boolean.Parse(value);
            }
        }

        #endregion
        #region Action specific properties - Execute script

        internal string _ExecScriptAssembliesExpression = "";
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

        internal string _ExecScriptExpression = "";
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

        #endregion
        #region Action specific properties - Folder operation

        internal FolderOpEnum _FolderOp { get; set; } = FolderOpEnum.EnableFolder;
        [XmlAttribute]
        public string FolderOp
        {
            get
            {
                if (_FolderOp != FolderOpEnum.EnableFolder)
                {
                    return _FolderOp.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _FolderOp = (FolderOpEnum)Enum.Parse(typeof(FolderOpEnum), value);
            }
        }

        internal Guid _FolderId { get; set; } = Guid.Empty;
        [XmlAttribute]
        public string FolderId
        {
            get
            {
                if (_FolderId != Guid.Empty)
                {
                    return _FolderId.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _FolderId = Guid.Parse(value);
            }
        }

        #endregion
        #region Action specific properties - Image aura

        internal AuraOpEnum _AuraOp { get; set; } = AuraOpEnum.ActivateAura;
        [XmlAttribute]
        public string AuraOp
        {
            get
            {
                if (_AuraOp != AuraOpEnum.ActivateAura)
                {
                    return _AuraOp.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _AuraOp = (AuraOpEnum)Enum.Parse(typeof(AuraOpEnum), value);
            }
        }

        internal PictureBoxSizeMode _AuraImageMode { get; set; } = PictureBoxSizeMode.Normal;
        [XmlAttribute]
        public string AuraImageMode
        {
            get
            {
                if (_AuraImageMode != PictureBoxSizeMode.Normal)
                {
                    return _AuraImageMode.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _AuraImageMode = (PictureBoxSizeMode)Enum.Parse(typeof(PictureBoxSizeMode), value);
            }
        }

        internal string _AuraName = "";
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

        internal string _AuraImage = "";
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

        internal string _AuraXIniExpression = "";
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

        internal string _AuraYIniExpression = "";
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

        internal string _AuraWIniExpression = "";
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

        internal string _AuraHIniExpression = "";
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

        internal string _AuraOIniExpression = "";
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

        internal string _AuraXTickExpression = "";
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

        internal string _AuraYTickExpression = "";
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

        internal string _AuraWTickExpression = "";
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

        internal string _AuraHTickExpression = "";
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

        internal string _AuraOTickExpression = "";
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

        internal string _AuraTTLTickExpression = "";
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

        #endregion
        #region Action specific properties - JSON

        internal HTTPMethodEnum _JsonOperationType { get; set; } = HTTPMethodEnum.POST;
        [XmlAttribute]
        public string JsonOperationType
        {
            get
            {
                if (_JsonOperationType == HTTPMethodEnum.POST)
                {
                    return null;
                }
                return _JsonOperationType.ToString();
            }
            set
            {
                _JsonOperationType = (HTTPMethodEnum)Enum.Parse(typeof(HTTPMethodEnum), value);
            }
        }

        internal bool _JsonCacheRequest { get; set; } = false;
        [XmlAttribute]
        public string JsonCacheRequest
        {
            get
            {
                if (_JsonCacheRequest == false)
                {
                    return null;
                }
                return _JsonCacheRequest.ToString();
            }
            set
            {
                _JsonCacheRequest = Boolean.Parse(value);
            }
        }

        internal string _JsonResultVariable = "";
        [XmlAttribute]
        public string JsonResultVariable
        {
            get
            {
                if (_JsonResultVariable == "")
                {
                    return null;
                }
                return _JsonResultVariable;
            }
            set
            {
                _JsonResultVariable = value;
            }
        }

        internal string _JsonEndpointExpression = "";
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

        internal string _JsonPayloadExpression = "";
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

        internal string _JsonHeaderExpression = "";
        [XmlAttribute]
        public string JsonHeaderExpression
        {
            get
            {
                if (_JsonHeaderExpression == "")
                {
                    return null;
                }
                return _JsonHeaderExpression;
            }
            set
            {
                _JsonHeaderExpression = value;
            }
        }

        internal string _JsonFiringExpression = "";
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

        internal bool _JsonResultVariablePersist { get; set; } = false;
        [XmlAttribute]
        public string JsonResultVariablePersist
        {
            get
            {
                if (_JsonResultVariablePersist == false)
                {
                    return null;
                }
                return _JsonResultVariablePersist.ToString();
            }
            set
            {
                _JsonResultVariablePersist = Boolean.Parse(value);
            }
        }

        #endregion
        #region Action specific properties - Keypress

        internal KeypressTypeEnum _KeypressType { get; set; } = KeypressTypeEnum.SendKeys;
        [XmlAttribute]
        public string KeypressType
        {
            get
            {
                if (_KeypressType != KeypressTypeEnum.SendKeys)
                {
                    return _KeypressType.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _KeypressType = (KeypressTypeEnum)Enum.Parse(typeof(KeypressTypeEnum), value);
            }
        }

        internal string _KeyPressExpression = "";
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

        internal string _KeyPressCode = "";
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

        internal string _KeyPressWindow = "";
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

        internal string _KeyPressProcId = "";
        [XmlAttribute]
        public string KeyPressProcId
        {
            get
            {
                if (_KeyPressProcId == "")
                {
                    return null;
                }
                return _KeyPressProcId;
            }
            set
            {
                _KeyPressProcId = value;
            }
        }

        #endregion
        #region Action specific properties - Launch process

        internal System.Diagnostics.ProcessWindowStyle _LaunchProcessWindowStyle { get; set; } = System.Diagnostics.ProcessWindowStyle.Normal;
        [XmlAttribute]
        public string LaunchProcessWindowStyle
        {
            get
            {
                if (_LaunchProcessWindowStyle != System.Diagnostics.ProcessWindowStyle.Normal)
                {
                    return _LaunchProcessWindowStyle.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _LaunchProcessWindowStyle = (System.Diagnostics.ProcessWindowStyle)Enum.Parse(typeof(System.Diagnostics.ProcessWindowStyle), value);
            }
        }

        internal string _LaunchProcessPathExpression = "";
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

        internal string _LaunchProcessCmdlineExpression = "";
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

        internal string _LaunchProcessWorkingDirExpression = "";
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

        #endregion
        #region Action specific properties - List variable

        internal ListVariableOpEnum _ListVariableOp { get; set; } = ListVariableOpEnum.Unset;
        [XmlAttribute]
        public string ListVariableOp
        {
            get => _ListVariableOp != ListVariableOpEnum.Unset ? _ListVariableOp.ToString() : null;
            set
            {
                if (Enum.TryParse(value, out ListVariableOpEnum type) || string.IsNullOrEmpty(value))
                {
                    _ListVariableOp = type;
                }
                // convert old actions
                else if (value == "PopLast")
                {
                    _ListVariableOp = ListVariableOpEnum.PopFirst;
                    _ListVariableIndex = "-1";
                }
                else throw InvalidEnumException("ListVariableOpEnum", value);
            }
        }

        internal ListVariableExpTypeEnum _ListVariableExpressionType { get; set; } = ListVariableExpTypeEnum.String;
        [XmlAttribute]
        public string ListVariableExpressionType
        {
            get
            {
                if (_ListVariableExpressionType != ListVariableExpTypeEnum.String)
                {
                    return _ListVariableExpressionType.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _ListVariableExpressionType = (ListVariableExpTypeEnum)Enum.Parse(typeof(ListVariableExpTypeEnum), value);
            }
        }

        internal string _ListVariableName = "";
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

        internal string _ListVariableExpression = "";
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

        internal string _ListVariableIndex = "";
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

        internal string _ListVariableTarget = "";
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

        internal bool _ListSourcePersist { get; set; } = false;
        [XmlAttribute]
        public string ListSourcePersist
        {
            get
            {
                if (_ListSourcePersist == false)
                {
                    return null;
                }
                return _ListSourcePersist.ToString();
            }
            set
            {
                _ListSourcePersist = Boolean.Parse(value);
            }
        }

        internal bool _ListTargetPersist { get; set; } = false;
        [XmlAttribute]
        public string ListTargetPersist
        {
            get
            {
                if (_ListTargetPersist == false)
                {
                    return null;
                }
                return _ListTargetPersist.ToString();
            }
            set
            {
                _ListTargetPersist = Boolean.Parse(value);
            }
        }

        #endregion
        #region Action specific properties - Log message

        internal LogEvent.SourceEnum _LogMessageTarget { get; set; } = LogEvent.SourceEnum.Log;
        [XmlAttribute]
        public string LogMessageTarget
        {
            get
            {
                if (_LogMessageTarget != LogEvent.SourceEnum.Log)
                {
                    return _LogMessageTarget.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _LogMessageTarget = (LogEvent.SourceEnum)Enum.Parse(typeof(LogEvent.SourceEnum), value);
            }
        }

        internal string _LogMessageText = "";
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

        internal bool _LogProcess { get; set; } = false;
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

        internal bool _LogProcessACT { get; set; } = false;
        [XmlAttribute]
        public string LogProcessACT
        {
            get
            {
                if (_LogProcessACT == false)
                {
                    return null;
                }
                return _LogProcessACT.ToString();
            }
            set
            {
                _LogProcessACT = Boolean.Parse(value);
            }
        }

        internal LogMessageEnum _LogLevel { get; set; } = LogMessageEnum.Error;
        [XmlAttribute]
        public string LogLevel
        {
            get
            {
                if (_LogLevel != LogMessageEnum.Error)
                {
                    return _LogLevel.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _LogLevel = (LogMessageEnum)Enum.Parse(typeof(LogMessageEnum), value);
                if ((int)_LogLevel == -1)
                {
                    _LogLevel = LogMessageEnum.Error;
                }
            }
        }

        #endregion
        #region Action specific properties - Loop

        public bool ShouldSerializeLoopCondition()
        {
            return (LoopCondition.Children.Count > 0);
        }

        public ConditionGroup LoopCondition = new ConditionGroup();

        public bool ShouldSerializeLoopActions()
        {
            return (LoopActions.Count > 0);
        }

        public List<Action> LoopActions = new List<Action>();

        internal string _LoopDelayExpression = "";
        [XmlAttribute]
        public string LoopDelayExpression
        {
            get
            {
                if (_LoopDelayExpression == "")
                {
                    return null;
                }
                return _LoopDelayExpression;
            }
            set
            {
                _LoopDelayExpression = value;
            }
        }

        internal string _LoopInitExpression = "0";
        [XmlAttribute]
        public string LoopInitExpression
        {
            get
            {
                if (_LoopInitExpression == "0")
                {
                    return null;
                }
                return _LoopInitExpression;
            }
            set
            {
                _LoopInitExpression = value;
            }
        }

        internal string _LoopIncrExpression = "1";
        [XmlAttribute]
        public string LoopIncrExpression
        {
            get
            {
                if (_LoopIncrExpression == "1")
                {
                    return null;
                }
                return _LoopIncrExpression;
            }
            set
            {
                _LoopIncrExpression = value;
            }
        }

        #endregion
        #region Action specific properties - Message box

        internal MessageBoxIconTypeEnum _MessageBoxIconType { get; set; } = MessageBoxIconTypeEnum.None;
        [XmlAttribute]
        public string MessageBoxIconType
        {
            get
            {
                if (_MessageBoxIconType != MessageBoxIconTypeEnum.None)
                {
                    return _MessageBoxIconType.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _MessageBoxIconType = (MessageBoxIconTypeEnum)Enum.Parse(typeof(MessageBoxIconTypeEnum), value);
            }
        }

        internal string _MessageBoxText = "";
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

        #endregion
        #region Action specific properties - Mouse

        internal MouseOpEnum _MouseOpType { get; set; } = MouseOpEnum.Move;
        [XmlAttribute]
        public string MouseOpType
        {
            get
            {
                if (_MouseOpType != MouseOpEnum.Move)
                {
                    return _MouseOpType.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _MouseOpType = (MouseOpEnum)Enum.Parse(typeof(MouseOpEnum), value);
            }
        }

        internal MouseCoordEnum _MouseCoordType { get; set; } = MouseCoordEnum.Absolute;
        [XmlAttribute]
        public string MouseCoordType
        {
            get
            {
                if (_MouseCoordType != MouseCoordEnum.Absolute)
                {
                    return _MouseCoordType.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _MouseCoordType = (MouseCoordEnum)Enum.Parse(typeof(MouseCoordEnum), value);
            }
        }

        internal string _MouseX = "0";
        [XmlAttribute]
        public string MouseX
        {
            get
            {
                if (_MouseX == "0" || _MouseX == "")
                {
                    return null;
                }
                return _MouseX.ToString();
            }
            set
            {
                _MouseX = value;
            }
        }

        internal string _MouseY = "0";
        [XmlAttribute]
        public string MouseY
        {
            get
            {
                if (_MouseY == "0" || _MouseY == "")
                {
                    return null;
                }
                return _MouseY.ToString();
            }
            set
            {
                _MouseY = value;
            }
        }

        #endregion
        #region Action specific properties - Mutex

        internal MutexOpEnum _MutexOpType { get; set; } = MutexOpEnum.Release;
        [XmlAttribute]
        public string MutexOpType
        {
            get
            {
                if (_MutexOpType != MutexOpEnum.Release)
                {
                    return _MutexOpType.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _MutexOpType = (MutexOpEnum)Enum.Parse(typeof(MutexOpEnum), value);
            }
        }

        internal string _MutexName = "";
        [XmlAttribute]
        public string MutexName
        {
            get
            {
                if (_MutexName == "")
                {
                    return null;
                }
                return _MutexName;
            }
            set
            {
                _MutexName = value;
            }
        }

        #endregion
        #region Action specific properties - Named callback

        internal string _NamedCallbackName = "";
        [XmlAttribute]
        public string NamedCallbackName
        {
            get
            {
                if (_NamedCallbackName == "")
                {
                    return null;
                }
                return _NamedCallbackName;
            }
            set
            {
                _NamedCallbackName = value;
            }
        }

        internal string _NamedCallbackParam = "";
        [XmlAttribute]
        public string NamedCallbackParam
        {
            get
            {
                if (_NamedCallbackParam == "")
                {
                    return null;
                }
                return _NamedCallbackParam;
            }
            set
            {
                _NamedCallbackParam = value;
            }
        }

        #endregion
        #region Action specific properties - OBS

        internal ObsControlTypeEnum _OBSControlType { get; set; } = ObsControlTypeEnum.StartStreaming;
        [XmlAttribute]
        public string OBSControlType
        {
            get
            {
                if (_OBSControlType != ObsControlTypeEnum.StartStreaming)
                {
                    return _OBSControlType.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _OBSControlType = (ObsControlTypeEnum)Enum.Parse(typeof(ObsControlTypeEnum), value);
            }
        }

        internal string _OBSEndPoint = @"ws://${_const[OBSWebsocketEndpoint]}:${_const[OBSWebsocketPort]}";
        [XmlAttribute]
        public string OBSEndPoint
        {
            get
            {
                if (_OBSEndPoint == @"ws://${_const[OBSWebsocketEndpoint]}:${_const[OBSWebsocketPort]}")
                {
                    return null;
                }
                return _OBSEndPoint;
            }
            set
            {
                _OBSEndPoint = value;
            }
        }

        internal string _OBSPassword = @"${_const[OBSWebsocketPassword]}";
        [XmlAttribute]
        public string OBSPassword
        {
            get
            {
                if (_OBSPassword == @"${_const[OBSWebsocketPassword]}")
                {
                    return null;
                }
                return _OBSPassword;
            }
            set
            {
                _OBSPassword = value;
            }
        }

        internal string _OBSSceneName = "";
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

        internal string _OBSSourceName = "";
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

        internal string _OBSJSONPayload = "";
        [XmlAttribute]
        public string OBSJSONPayload
        {
            get
            {
                if (_OBSJSONPayload == "")
                {
                    return null;
                }
                return _OBSJSONPayload;
            }
            set
            {
                _OBSJSONPayload = value;
            }
        }

        #endregion
        #region Action specific properties - LiveSplit
        internal LiveSplitControlTypeEnum _LSControlType { get; set; } = LiveSplitControlTypeEnum.StartOrSplit;
        [XmlAttribute]
        public string LiveSplitControlType
        {
            get
            {
                if (_LSControlType != LiveSplitControlTypeEnum.StartOrSplit)
                {
                    return _LSControlType.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _LSControlType = (LiveSplitControlTypeEnum)Enum.Parse(typeof(LiveSplitControlTypeEnum), value);
            }
        }
        internal string _LSCustomPayload = "";
        [XmlAttribute]
        public string LiveSplitCustomPayload
        {
            get
            {
                if (_LSControlType != LiveSplitControlTypeEnum.CustomPayload)
                {
                    return null;
                }
                return _LSCustomPayload;
            }
            set
            {
                _LSCustomPayload = value;
            }
        }
        #endregion
        #region Action specific properties - Placeholder
        #endregion
        #region Action specific properties - Play sound

        internal string _PlaySoundFileExpression = "";
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

        internal string _PlaySoundVolumeExpression = "100";
        [XmlAttribute]
        public string PlaySoundVolumeExpression
        {
            get
            {
                if (_PlaySoundVolumeExpression == "100")
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

        internal bool _PlaySoundExclusive { get; set; } = true;
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

        internal Configuration.AudioRoutingMethodEnum _SoundRouting = Configuration.AudioRoutingMethodEnum.None;
        [XmlAttribute]
        public string SoundRouting
        {
            get => _SoundRouting != Configuration.AudioRoutingMethodEnum.None ? _SoundRouting.ToString() : null;
            set => _SoundRouting = (Configuration.AudioRoutingMethodEnum)Enum.Parse(typeof(Configuration.AudioRoutingMethodEnum), value);
        }

        [XmlAttribute]
        public string PlaySoundMyself // old version compatibility
        {
            get
            {
                return null;
            }
            set
            {
                if (Boolean.Parse(value))
                {
                    _SoundRouting = Configuration.AudioRoutingMethodEnum.Triggernometry;
                }
            }
        }

        #endregion
        #region Action specific properties - Play speech
        
        internal Configuration.AudioRoutingMethodEnum _TTSRouting = Configuration.AudioRoutingMethodEnum.None;
        [XmlAttribute]
        public string TTSRouting
        {
            get => _TTSRouting != Configuration.AudioRoutingMethodEnum.None ? _TTSRouting.ToString() : null;
            set => _TTSRouting = (Configuration.AudioRoutingMethodEnum)Enum.Parse(typeof(Configuration.AudioRoutingMethodEnum), value);
        }

        [XmlAttribute]
        public string PlaySpeechMyself // old version compatibility
        {
            get
            {
                return null;
            }
            set
            {
                if (Boolean.Parse(value))
                {
                    _TTSRouting = Configuration.AudioRoutingMethodEnum.Triggernometry;
                }
            }
        }

        internal string _UseTTSTextExpression = "";
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

        internal string _UseTTSVolumeExpression = "100";
        [XmlAttribute]
        public string UseTTSVolumeExpression
        {
            get
            {
                if (_UseTTSVolumeExpression == "100")
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

        internal string _UseTTSRateExpression = "0";
        [XmlAttribute]
        public string UseTTSRateExpression
        {
            get
            {
                if (_UseTTSRateExpression == "0")
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

        internal bool _UseTTSExclusive { get; set; } = true;
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

        #endregion
        #region Action specific properties - Repository

        internal RepositoryOpEnum _RepositoryOp { get; set; } = RepositoryOpEnum.UpdateSelf;
        [XmlAttribute]
        public string RepositoryOp
        {
            get
            {
                if (_RepositoryOp != RepositoryOpEnum.UpdateSelf)
                {
                    return _RepositoryOp.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _RepositoryOp = (RepositoryOpEnum)Enum.Parse(typeof(RepositoryOpEnum), value);
            }
        }

        internal Guid _RepositoryId { get; set; } = Guid.Empty;
        [XmlAttribute]
        public string RepositoryId
        {
            get
            {
                if (_RepositoryId != Guid.Empty)
                {
                    return _RepositoryId.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _RepositoryId = Guid.Parse(value);
            }
        }

        #endregion
        #region Action specific properties - Scalar variable

        internal VariableOpEnum _VariableOp { get; set; } = VariableOpEnum.Unset;
        [XmlAttribute]
        public string VariableOp
        {
            get
            {
                if (_VariableOp != VariableOpEnum.Unset)
                {
                    return _VariableOp.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _VariableOp = (VariableOpEnum)Enum.Parse(typeof(VariableOpEnum), value);
            }
        }

        internal string _VariableName = "";
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

        internal string _VariableJsonTarget = "";
        [XmlAttribute]
        public string VariableJsonTarget
        {
            get
            {
                if (_VariableJsonTarget == "")
                {
                    return null;
                }
                return _VariableJsonTarget;
            }
            set
            {
                _VariableJsonTarget = value;
            }
        }

        internal string _VariableExpression = "";
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

        internal bool _VariableTargetPersist { get; set; } = false;
        [XmlAttribute]
        public string VariableTargetPersist
        {
            get
            {
                if (_VariableTargetPersist == false)
                {
                    return null;
                }
                return _VariableTargetPersist.ToString();
            }
            set
            {
                _VariableTargetPersist = Boolean.Parse(value);
            }
        }

        internal bool _VariablePersist { get; set; } = false;
        [XmlAttribute]
        public string VariablePersist
        {
            get
            {
                if (_VariablePersist == false)
                {
                    return null;
                }
                return _VariablePersist.ToString();
            }
            set
            {
                _VariablePersist = Boolean.Parse(value);
            }
        }

        #endregion
        #region Action specific properties - Table variable

        internal TableVariableOpEnum _TableVariableOp { get; set; } = TableVariableOpEnum.Unset;
        [XmlAttribute]
        public string TableVariableOp
        {
            get
            {
                if (_TableVariableOp != TableVariableOpEnum.Unset)
                {
                    return _TableVariableOp.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _TableVariableOp = (TableVariableOpEnum)Enum.Parse(typeof(TableVariableOpEnum), value);
            }
        }

        internal TableVariableExpTypeEnum _TableVariableExpressionType { get; set; } = TableVariableExpTypeEnum.String;
        [XmlAttribute]
        public string TableVariableExpressionType
        {
            get
            {
                if (_TableVariableExpressionType != TableVariableExpTypeEnum.String)
                {
                    return _TableVariableExpressionType.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _TableVariableExpressionType = (TableVariableExpTypeEnum)Enum.Parse(typeof(TableVariableExpTypeEnum), value);
            }
        }

        internal string _TableVariableName = "";
        [XmlAttribute]
        public string TableVariableName
        {
            get
            {
                if (_TableVariableName == "")
                {
                    return null;
                }
                return _TableVariableName;
            }
            set
            {
                _TableVariableName = value;
            }
        }

        internal string _TableVariableTarget = "";
        [XmlAttribute]
        public string TableVariableTarget
        {
            get
            {
                if (_TableVariableTarget == "")
                {
                    return null;
                }
                return _TableVariableTarget;
            }
            set
            {
                _TableVariableTarget = value;
            }
        }

        internal string _TableVariableExpression = "";
        [XmlAttribute]
        public string TableVariableExpression
        {
            get
            {
                if (_TableVariableExpression == "")
                {
                    return null;
                }
                return _TableVariableExpression;
            }
            set
            {
                _TableVariableExpression = value;
            }
        }

        internal string _TableVariableX = "";
        [XmlAttribute]
        public string TableVariableX
        {
            get
            {
                if (_TableVariableX == "")
                {
                    return null;
                }
                return _TableVariableX;
            }
            set
            {
                _TableVariableX = value;
            }
        }

        internal string _TableVariableY = "";
        [XmlAttribute]
        public string TableVariableY
        {
            get
            {
                if (_TableVariableY == "")
                {
                    return null;
                }
                return _TableVariableY;
            }
            set
            {
                _TableVariableY = value;
            }
        }

        internal bool _TableSourcePersist { get; set; } = false;
        [XmlAttribute]
        public string TableSourcePersist
        {
            get
            {
                if (_TableSourcePersist == false)
                {
                    return null;
                }
                return _TableSourcePersist.ToString();
            }
            set
            {
                _TableSourcePersist = Boolean.Parse(value);
            }
        }

        internal bool _TableTargetPersist { get; set; } = false;
        [XmlAttribute]
        public string TableTargetPersist
        {
            get
            {
                if (_TableTargetPersist == false)
                {
                    return null;
                }
                return _TableTargetPersist.ToString();
            }
            set
            {
                _TableTargetPersist = Boolean.Parse(value);
            }
        }

        #endregion
        #region Action specific properties - Text aura

        internal AuraOpEnum _TextAuraOp { get; set; } = AuraOpEnum.ActivateAura;
        [XmlAttribute]
        public string TextAuraOp
        {
            get
            {
                if (_TextAuraOp != AuraOpEnum.ActivateAura)
                {
                    return _TextAuraOp.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _TextAuraOp = (AuraOpEnum)Enum.Parse(typeof(AuraOpEnum), value);
            }
        }

        internal TextAuraAlignmentEnum _TextAuraAlignment { get; set; } = TextAuraAlignmentEnum.MiddleCenter;
        [XmlAttribute]
        public string TextAuraAlignment
        {
            get
            {
                if (_TextAuraAlignment != TextAuraAlignmentEnum.MiddleCenter)
                {
                    return _TextAuraAlignment.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _TextAuraAlignment = (TextAuraAlignmentEnum)Enum.Parse(typeof(TextAuraAlignmentEnum), value);
            }
        }

        internal TextAuraEffectEnum _TextAuraEffect { get; set; } = TextAuraEffectEnum.None;
        [XmlAttribute]
        public string TextAuraEffect
        {
            get
            {
                if (_TextAuraEffect != TextAuraEffectEnum.None)
                {
                    return _TextAuraEffect.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                TextAuraEffectEnum tea = (TextAuraEffectEnum)0;
                string[] ex = value.Split(' ');
                foreach (string exx in ex)
                {
                    tea |= (TextAuraEffectEnum)Enum.Parse(typeof(TextAuraEffectEnum), exx.Replace(",", ""));
                }
                _TextAuraEffect = tea;
            }
        }

        internal float _TextAuraFontSize { get; set; } = 10.0f;
        [XmlAttribute]
        public string TextAuraFontSize
        {
            get
            {
                if (_ActionType != ActionTypeEnum.TextAura)
                {
                    return null;
                }
                else
                {
                    return I18n.ThingToString(_TextAuraFontSize);
                }
            }
            set
            {
                _TextAuraFontSize = float.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        internal string _TextAuraForegroundClInt = "";
        [XmlAttribute]
        public string TextAuraForeground
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_TextAuraForegroundClInt))
                {
                    return _TextAuraForegroundClInt;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _TextAuraForegroundClInt = value;
            }
        }

        internal string _TextAuraBackgroundClInt = "";
        [XmlAttribute]
        public string TextAuraBackground
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_TextAuraBackgroundClInt))
                {
                    return _TextAuraBackgroundClInt;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _TextAuraBackgroundClInt = value;
            }
        }

        internal string _TextAuraOutlineClInt = "";
        [XmlAttribute]
        public string TextAuraOutline
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_TextAuraOutlineClInt))
                {
                    return _TextAuraOutlineClInt;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _TextAuraOutlineClInt = value;
            }
        }

        internal string _TextAuraName = "";
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

        internal string _TextAuraExpression = "";
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

        internal string _TextAuraXIniExpression = "";
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

        internal string _TextAuraYIniExpression = "";
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

        internal string _TextAuraWIniExpression = "";
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

        internal string _TextAuraHIniExpression = "";
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

        internal string _TextAuraOIniExpression = "";
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

        internal string _TextAuraXTickExpression = "";
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

        internal string _TextAuraYTickExpression = "";
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

        internal string _TextAuraWTickExpression = "";
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

        internal string _TextAuraHTickExpression = "";
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

        internal string _TextAuraOTickExpression = "";
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

        internal string _TextAuraTTLTickExpression = "";
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

        internal string _TextAuraFontName = "";
        [XmlAttribute]
        public string TextAuraFontName
        {
            get
            {
                if (_TextAuraFontName == "" || _ActionType != ActionTypeEnum.TextAura)
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

        #endregion
        #region Action specific properties - Trigger operation

        internal TriggerZoneTypeEnum _TriggerZoneType { get; set; } = TriggerZoneTypeEnum.ZoneName;
        [XmlAttribute]
        public string TriggerZoneType
        {
            get
            {
                if (_TriggerZoneType != TriggerZoneTypeEnum.ZoneName)
                {
                    return _TriggerZoneType.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _TriggerZoneType = (TriggerZoneTypeEnum)Enum.Parse(typeof(TriggerZoneTypeEnum), value);
            }
        }

        internal TriggerOpEnum _TriggerOp { get; set; } = TriggerOpEnum.FireTrigger;
        [XmlAttribute]
        public string TriggerOp
        {
            get
            {
                if (_TriggerOp != TriggerOpEnum.FireTrigger)
                {
                    return _TriggerOp.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _TriggerOp = (TriggerOpEnum)Enum.Parse(typeof(TriggerOpEnum), value);
            }
        }

        internal Guid _TriggerId { get; set; } = Guid.Empty;
        [XmlAttribute]
        public string TriggerId
        {
            get
            {
                if (_TriggerId != Guid.Empty)
                {
                    return _TriggerId.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _TriggerId = Guid.Parse(value);
            }
        }

        internal string _TriggerText = "";
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

        internal string _TriggerZone = "";
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

        [XmlIgnore]
        internal TriggerForceTypeEnum _TriggerForceType { get; set; } = TriggerForceTypeEnum.NoSkip;
        [XmlAttribute]
        public string TriggerForce
        {
            get
            {
                List<string> ex = new List<string>();
                if (_TriggerForceType == TriggerForceTypeEnum.SkipAll)
                {
                    ex.Add("true");
                }
                else
                {
                    if ((_TriggerForceType & TriggerForceTypeEnum.SkipRegexp) != 0)
                    {
                        ex.Add("regexp");
                    }
                    if ((_TriggerForceType & TriggerForceTypeEnum.SkipConditions) != 0)
                    {
                        ex.Add("conditions");
                    }
                    if ((_TriggerForceType & TriggerForceTypeEnum.SkipRefire) != 0)
                    {
                        ex.Add("refire");
                    }
                    if ((_TriggerForceType & TriggerForceTypeEnum.SkipParent) != 0)
                    {
                        ex.Add("parent");
                    }
                    if ((_TriggerForceType & TriggerForceTypeEnum.SkipActive) != 0)
                    {
                        ex.Add("active");
                    }
                }
                string temp = String.Join(",", ex.ToArray());
                if (temp.Length > 0)
                {
                    return temp;
                }
                return null;
            }
            set
            {
                string[] exx = value != null ? value.Split(",".ToCharArray()) : new string[] { "" };
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
                _TriggerForceType = newval;
            }
        }

        #endregion
        #region Action specific properties - Window message

        internal string _WmsgProcId = "";
        [XmlAttribute]
        public string WmsgProcId
        {
            get
            {
                if (_WmsgProcId == "")
                {
                    return null;
                }
                return _WmsgProcId;
            }
            set
            {
                _WmsgProcId = value;
            }
        }

        internal string _WmsgTitle = "";
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

        internal string _WmsgCode = "";
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

        internal string _WmsgWparam = "";
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

        internal string _WmsgLparam = "";
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

        #endregion

    }

}
