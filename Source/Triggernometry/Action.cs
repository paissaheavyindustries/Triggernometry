using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using WMPLib;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using Triggernometry.Variables;
using CsvHelper;
using System.Globalization;
using Triggernometry.Utilities;
using static Triggernometry.RealPlugin;

namespace Triggernometry
{

    /*
	Confirm the triggers to import.
	
	At least one of triggers you are trying to import includes one of more actions that are set to launch an external process.
	These triggers may be dangerous and as such they are not included in the import by default.
	To import these triggers, you will have to confirm them manually one by one.
	
	*/
    public partial class Action
    {

        #region General properties

        public class ActionBundle
        {

            public List<Action> Actions { get; set; } = new List<Action>();

        }

        internal Action NextAction { get; set; } = null;
        internal Action LoopAction { get; set; } = null;
        internal Guid LoopContext { get; set; } = Guid.Empty;

        internal Guid Id { get; set; }

        internal bool _Enabled { get; set; } = true;
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

        [XmlIgnore]
        public Trigger ParentTrigger { get; set; } = null;

        internal ActionTypeEnum _ActionType = ActionTypeEnum.SystemBeep;

        [XmlAttribute]
        public string ActionType 
        {
            get => (_ActionType != ActionTypeEnum.SystemBeep) ? _ActionType.ToString() : null;
            set
            {
                if (Enum.TryParse(value, out _ActionType) || string.IsNullOrEmpty(value)) return;
                // convert old actions
                else if (value == "EndEncounter")
                {
                    _ActionType = ActionTypeEnum.ActInteraction;
                    _ActOpBoolParam = false;
                }
                else throw InvalidEnumException("ActionTypeEnum", value);
            }
        }

        internal string _ExecutionDelayExpression { get; set; } = "0";
        [XmlAttribute]
        public string ExecutionDelayExpression
        {
            get
            {
                if (_ExecutionDelayExpression != "0" && _ExecutionDelayExpression != "")
                {
                    return _ExecutionDelayExpression;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _ExecutionDelayExpression = value;
            }
        }

        internal bool _Asynchronous { get; set; } = true;
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

        internal RealPlugin.DebugLevelEnum _DebugLevel { get; set; } = RealPlugin.DebugLevelEnum.Inherit;
        [XmlAttribute]
        public string DebugLevel
        {
            get
            {
                if (_DebugLevel != RealPlugin.DebugLevelEnum.Inherit)
                {
                    return _DebugLevel.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _DebugLevel = (RealPlugin.DebugLevelEnum)Enum.Parse(typeof(RealPlugin.DebugLevelEnum), value);
            }
        }

        internal bool _RefireInterrupt { get; set; } = false;
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

        internal bool _RefireRequeue { get; set; } = true;
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
        public int OrderNumber;

        internal string _Description { get; set; } = "";
        [XmlAttribute]
        public string Description
        {
            get
            {
                if (_Description == "")
                {
                    return null;
                }
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        internal string _DescBgColor { get; set; } = "";
        [XmlAttribute]
        public string DescBgColor
        {
            get
            {
                if (_DescBgColor != "0" & !string.IsNullOrWhiteSpace(_DescBgColor))
                {
                    return _DescBgColor;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _DescBgColor = value;
            }
        }

        internal string _DescTextColor { get; set; } = "";
        [XmlAttribute]
        public string DescTextColor
        {
            get
            {
                if (_DescTextColor != "0" && !string.IsNullOrWhiteSpace(_DescTextColor))
                {
                    return _DescTextColor;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _DescTextColor = value;
            }
        }

        internal bool _DescriptionOverride { get; set; } = false;
        [XmlAttribute]
        public string DescriptionOverride
        {
            get
            {
                if (_DescriptionOverride == false)
                {
                    return null;
                }
                return _DescriptionOverride.ToString();
            }
            set
            {
                _DescriptionOverride = Boolean.Parse(value);
            }
        }

        internal ConditionGroup _Condition = new ConditionGroup { Enabled = false };
        public ConditionGroup Condition
        {
            get => _Condition.Children.Count == 0 && !_Condition.Enabled ? null : _Condition;
            set => _Condition = value;
        }

        #endregion

        #region Old condition to new condition converter
        public bool ShouldSerializeConditions()
        {
            return false;
        }

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
            if (_Condition == null)
            {
                _Condition = new ConditionGroup();
                _Condition.Grouping = ConditionGroup.CndGroupingEnum.And;
                _Condition.Enabled = true;
            }
            Condition cx = e.Item;
            _Condition.AddChild(cx.ConvertToConditionSingle());
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
        #endregion

        public void ActionContextLogger(object o, string msg)
        {
            AddToLog((Context)o, RealPlugin.DebugLevelEnum.Verbose, msg);
        }

        private static readonly CultureInfo InvClt = CultureInfo.InvariantCulture;
        private static readonly NumberStyles NSFloat = NumberStyles.Float;

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

        private void CancelAllTriggersInFolder(Folder folder, Context ctx)
        {
            foreach (var trigger in folder.Triggers)
            {
                plug.CancelAllQueuedActionsFromTrigger(trigger);
            }

            foreach (var subFolder in folder.Folders)
            {
                CancelAllTriggersInFolder(subFolder, ctx);
            }
        }

        /// <returns>
        /// <c>true</c> : connected <br /> 
        /// <c>false</c>: failed <br /> 
        /// <c>null</c> : not running
        /// </returns>
        internal bool? ObsConnector(Context ctx, string endpoint, string password)
        {
            lock (plug._obs)
            {
                if (plug._obs.IsConnected == true)
                {
                    return true;
                }
                switch (plug._obs.CheckRunningState())
                {
                    case ObsController.ObsRunningState.NotRunningFirstlyFound:
                        AddToLog(ctx, DebugLevelEnum.Warning, I18n.Translate("internal/Action/obsnotrunning",
                            "OBS is not running and the OBS action cannot be performed."));
                        return null;
                    case ObsController.ObsRunningState.NotRunning:
                        return null;
                    case ObsController.ObsRunningState.Running:
                        break;
                }
                try
                {
                    plug._obs.Connect(endpoint, password);
                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Info, I18n.Translate("internal/Action/obsconnectok", 
                        "OBS WebSocket connected successfully"));
                    return true;
                }
                catch (Exception ex)
                {
                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/obsconnecterror", 
                        "Error connecting to OBS WebSocket: {0}", ex.Message));
                }
            }
            return false;
        }

        internal bool LiveSplitConnector(Context ctx)
        {
            lock (plug._livesplit)
            {
                if (plug._livesplit.IsConnected == true)
                {
                    return true;
                }
                try
                {
                    plug._livesplit.Connect();
                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Info, I18n.Translate("internal/Action/lsconnectok", "LiveSplit connected successfully"));
                    return true;
                }
                catch (Exception ex)
                {
                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/lsconnecterror", "Error connecting to LiveSplit: {0}", ex.Message));
                }
            }
            return false;
        }

        private string GetTargetWindowsDescription(string procid, string titleRegex)
        {
            procid = procid.Trim();
            if (string.IsNullOrWhiteSpace(titleRegex))
            {
                titleRegex = ".*";
            }
            int parsedProcId = 1;
            try { parsedProcId = (int)MathParser.Parse(procid); } 
            catch { }
            if (parsedProcId == 0)
            {
                return I18n.Translate("internal/Action/descwindowtargetsingle", "the first window whose title match ({0})", titleRegex);
            }
            else if (parsedProcId < 0)
            {
                return I18n.Translate("internal/Action/descwindowtargetall", "all windows whose titles match ({0})", titleRegex);
            }
            else
            {
                return I18n.Translate("internal/Action/descwindowtargetid", "windows in the process with id ({0}) whose titles match ({1})", procid, titleRegex);
            }
        }

        internal string GetDescription(Context ctx)
        {
            string temp = "";
            if (_DescriptionOverride == true)
            {
                return _Description;
            }
            temp += I18n.TrlAsync(_Asynchronous);
            if (!string.IsNullOrWhiteSpace(_ExecutionDelayExpression) && _ExecutionDelayExpression.Trim() != "0")
            {
                string delay = double.TryParse(_ExecutionDelayExpression.Trim(), NSFloat, InvClt, out _)
                    ? _ExecutionDelayExpression : $"({_ExecutionDelayExpression})";
                temp += I18n.Translate("internal/Action/descafterdelay", "after {0} ms, ", delay);  // included comma in translations (comma symbols are language-dependent)
            }
            if (_Condition != null && _Condition.Enabled == true)
            {
                temp += I18n.Translate("internal/Action/descassumingcondition", "assuming condition is met, ");
            }
            switch (_ActionType)
            {
                case ActionTypeEnum.ActInteraction:
                    {
                        switch (_ActOpType)
                        {
                            case ActInteractionTypeEnum.SetCombatState:
                                temp += !_ActOpBoolParam ? I18n.Translate("internal/Action/descactcombatend", "End ACT encounter")
                                                         : I18n.Translate("internal/Action/descactcombatstart", "Start ACT encounter");
                                break;
                            case ActInteractionTypeEnum.LogAllNetwork:
                                temp += I18n.Translate("internal/Action/descactlogallnetwork", "{0} option: Log all network data", I18n.TranslateEnable(_ActOpBoolParam));
                                break;
                            case ActInteractionTypeEnum.UseDeucalion:
                                temp += I18n.Translate("internal/Action/descactusedeucalion", "{0} option: Use Deucalion (injection)", I18n.TranslateEnable(_ActOpBoolParam));
                                break;
                        }
                    }
                    break;
                case ActionTypeEnum.Trigger:
                    {
                        Trigger t = plug.GetTriggerById(_TriggerId, ctx.trig?.Repo);
                        if (t != null)
                        {
                            switch (_TriggerOp)
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
                                    if (_TriggerForceType == TriggerForceTypeEnum.SkipAll)
                                    {
                                        ex.Add(I18n.Translate("internal/Action/desctrigignoreall", "all restrictions"));
                                    }
                                    else
                                    {
                                        if ((_TriggerForceType & TriggerForceTypeEnum.SkipRegexp) != 0)
                                        {
                                            ex.Add(I18n.Translate("internal/Action/desctrigignoreregex", "regular expression"));
                                        }
                                        else
                                        {
                                            temp += " " + I18n.Translate("internal/Action/desctrigfireusing", "with event text ({0}) and zone ({1})", _TriggerText, _TriggerZone);
                                        }
                                        if ((_TriggerForceType & TriggerForceTypeEnum.SkipConditions) != 0)
                                        {
                                            ex.Add(I18n.Translate("internal/Action/desctrigignoreconditions", "conditions"));
                                        }
                                        if ((_TriggerForceType & TriggerForceTypeEnum.SkipRefire) != 0)
                                        {
                                            ex.Add(I18n.Translate("internal/Action/desctrigignorerefire", "refire delay"));
                                        }
                                        if ((_TriggerForceType & TriggerForceTypeEnum.SkipParent) != 0)
                                        {
                                            ex.Add(I18n.Translate("internal/Action/desctrigignoreparent", "parent folder settings"));
                                        }
                                        if ((_TriggerForceType & TriggerForceTypeEnum.SkipActive) != 0)
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
                            if (_TriggerOp == TriggerOpEnum.CancelAllTrigger)
                            {
                                temp += I18n.Translate("internal/Action/desctrigcancelall", "cancel all actions queued from all triggers");
                            }
                            else
                            {
                                temp += I18n.Translate("internal/Action/desctriginvalidref", "trigger action with an invalid trigger reference ({0})", _TriggerId);
                            }
                        }
                    }
                    break;
                case ActionTypeEnum.Folder:
                    {
                        Folder f = plug.GetFolderById(_FolderId, ctx.trig?.Repo);
                        if (f != null)
                        {
                            switch (_FolderOp)
                            {
                                case FolderOpEnum.DisableFolder:
                                    temp += I18n.Translate("internal/Action/descdisablefolder", "disable folder ({0})", f.Name);
                                    break;
                                case FolderOpEnum.EnableFolder:
                                    temp += I18n.Translate("internal/Action/descenablefolder", "enable folder ({0})", f.Name);
                                    break;
                                case FolderOpEnum.CancelFolder:
                                    temp += I18n.Translate("internal/Action/desccancelfolder", "cancel all actions from folder ({0})", f.Name);
                                    break;
                            }
                        }
                        else
                        {
                            temp += I18n.Translate("internal/Action/descinvalidfolderref", "folder action with an invalid folder reference ({0})", _FolderId);
                        }
                    }
                    break;
                case ActionTypeEnum.KeyPress:
                    switch (_KeypressType)
                    {
                        case KeypressTypeEnum.SendKeys:
                            temp += I18n.Translate("internal/Action/desckeypresses", "send keypresses ({0}) to the active window", _KeyPressExpression);
                            break;
                        case KeypressTypeEnum.WindowMessage:
                        case KeypressTypeEnum.WindowMessageCombo:
                            string target = GetTargetWindowsDescription(_KeyPressProcId, _KeyPressWindow);

                            if (_KeypressType == KeypressTypeEnum.WindowMessage)
                            {
                                temp += I18n.Translate("internal/Action/desckeypress", "send keycode ({0}) to {1}", _KeyPressCode, target);
                            }
                            else
                            {
                                temp += I18n.Translate("internal/Action/desckeypresscombo", "send keycodes ({0}) to {1}", _KeyPressCode, target);
                            }
                            break;
                    }
                    break;
                case ActionTypeEnum.LaunchProcess:
                    {
                        string tempt = "";
                        switch (_LaunchProcessWindowStyle)
                        {
                            case System.Diagnostics.ProcessWindowStyle.Hidden:
                                tempt = I18n.Lookup("ActionForm/cbxProcessWindowStyle[Hidden from view]", _LaunchProcessWindowStyle.ToString());
                                break;
                            case System.Diagnostics.ProcessWindowStyle.Maximized:
                                tempt = I18n.Lookup("ActionForm/cbxProcessWindowStyle[Maximized to fullscreen]", _LaunchProcessWindowStyle.ToString());
                                break;
                            case System.Diagnostics.ProcessWindowStyle.Minimized:
                                tempt = I18n.Lookup("ActionForm/cbxProcessWindowStyle[Minimized to taskbar]", _LaunchProcessWindowStyle.ToString());
                                break;
                            case System.Diagnostics.ProcessWindowStyle.Normal:
                                tempt = I18n.Lookup("ActionForm/cbxProcessWindowStyle[Normal]", _LaunchProcessWindowStyle.ToString());
                                break;
                            default:
                                tempt = _LaunchProcessWindowStyle.ToString();
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
                    temp += I18n.Translate("internal/Action/descplaysound", "play sound file ({0}) at volume ({1}) %", _PlaySoundFileExpression, _PlaySoundVolumeExpression);
                    break;
                case ActionTypeEnum.SystemBeep:
                    temp += I18n.Translate("internal/Action/descbeep", "beep at ({0}) hz for ({1}) ms", _SystemBeepFreqExpression, _SystemBeepLengthExpression);
                    break;
                case ActionTypeEnum.UseTTS:
                    temp += I18n.Translate("internal/Action/desctts", "say ({0}) at volume ({1}) %, using speed ({2})", _UseTTSTextExpression, _UseTTSVolumeExpression, _UseTTSRateExpression);
                    break;
                case ActionTypeEnum.ExecuteScript:
                    temp += I18n.Translate("internal/Action/descexecscript", "execute C# script");
                    break;
                case ActionTypeEnum.MessageBox:
                    temp += I18n.Translate($"internal/Action/descmsgbox{_MessageBoxIconType}", "show a message box saying ({0}) with icon (" + _MessageBoxIconType.ToString() + ")", _MessageBoxText);
                    break;
                case ActionTypeEnum.Mutex:
                    switch (_MutexOpType)
                    {
                        case MutexOpEnum.Release:
                            temp += I18n.Translate("internal/Action/mutexrelease", "release mutex ({0})", _MutexName);
                            break;
                        case MutexOpEnum.Acquire:
                            temp += I18n.Translate("internal/Action/mutexacquire", "acquire mutex ({0})", _MutexName);
                            break;
                    }
                    break;
                case ActionTypeEnum.ListVariable:
                    string sPersistL = I18n.TrlVarPersist(_ListSourcePersist);
                    string tPersistL = I18n.TrlVarPersist(_ListTargetPersist);
                    string exprTypeL = I18n.TrlExprType(_ListVariableExpressionType == ListVariableExpTypeEnum.String);
                    switch (_ListVariableOp)
                    {
                        case ListVariableOpEnum.Unset:
                            temp += I18n.Translate("internal/Action/desclistunset",
                                    "unset {1}list variable ({0})", _ListVariableName, sPersistL);
                            break;
                        case ListVariableOpEnum.Push:
                            temp += I18n.Translate("internal/Action/desclistpush",
                                    "push the value from {3} expression ({2}) to the end of {1}list variable ({0})",
                                    _ListVariableName, sPersistL, _ListVariableExpression, exprTypeL);
                            break;
                        case ListVariableOpEnum.Insert:
                            temp += I18n.Translate("internal/Action/desclistinsert",
                                    "insert the value from {3} expression ({2}) to index ({4}) on {1}list variable ({0})",
                                    _ListVariableName, sPersistL, _ListVariableExpression, exprTypeL, _ListVariableIndex);
                            break;
                        case ListVariableOpEnum.Set:
                            temp += I18n.Translate("internal/Action/desclistset",
                                    "set the value from {3} expression ({2}) to index ({4}) on {1}list variable ({0})",
                                    _ListVariableName, sPersistL, _ListVariableExpression, exprTypeL, _ListVariableIndex);
                            break;
                        case ListVariableOpEnum.SetAll:
                            if (string.IsNullOrWhiteSpace(_ListVariableIndex))
                                temp += I18n.Translate("internal/Action/desclistsetall",
                                        "set all values on {1}list ({0}) to {3} expr ({2})",
                                        _ListVariableName, sPersistL, _ListVariableExpression, exprTypeL);
                            else
                                temp += I18n.Translate("internal/Action/desclistsetallresize",
                                        "set all values on {1}list ({0}) to {3} expr ({2}) (resized to length ({4}))",
                                        _ListVariableName, sPersistL, _ListVariableExpression, exprTypeL, _ListVariableIndex);
                            break;
                        case ListVariableOpEnum.Remove:
                            temp += I18n.Translate("internal/Action/desclistremove",
                                    "remove the value at index ({0}) on {2}list variable ({1})",
                                    _ListVariableIndex, _ListVariableName, sPersistL);
                            break;
                        case ListVariableOpEnum.PopFirst: // the action was updated to "Pop" but the name was unchanged
                            string index = (String.IsNullOrWhiteSpace(_ListVariableIndex)) ? "1" : _ListVariableIndex;
                            temp += I18n.Translate("internal/Action/desclistpop",
                                    "pop index ({4}) of {1}list variable ({0}) into {3}scalar variable ({2})",
                                    _ListVariableName, sPersistL, _ListVariableTarget, tPersistL, index);
                            break;
                        case ListVariableOpEnum.PopToListInsert:
                            if (String.IsNullOrWhiteSpace(_ListVariableExpression))
                                temp += I18n.Translate("internal/Action/desclistpoptolist",
                                        "pop index ({2}) of {1}list variable ({0}) to the end of {5}list variable ({4})",
                                        _ListVariableName, sPersistL, _ListVariableIndex, _ListVariableTarget, tPersistL);
                            else
                                temp += I18n.Translate("internal/Action/desclistpoptolistinsert",
                                        "pop index ({2}) of {1}list variable ({0}) and insert to index ({5}) of {4}list variable ({3})",
                                        _ListVariableName, sPersistL, _ListVariableIndex,
                                        _ListVariableTarget, tPersistL, _ListVariableExpression);
                            break;
                        case ListVariableOpEnum.PopToListSet:
                            temp += I18n.Translate("internal/Action/desclistpoptolistset",
                                    "pop index ({2}) of {1}list variable ({0}) and set to index ({5}) of {4}list variable ({3})",
                                    _ListVariableName, sPersistL, _ListVariableIndex,
                                    _ListVariableTarget, tPersistL, _ListVariableExpression);
                            break;
                        case ListVariableOpEnum.SortAlphaAsc:
                        case ListVariableOpEnum.SortAlphaDesc:
                            string strOrder = I18n.TrlSortAscOrDesc(_ListVariableOp == ListVariableOpEnum.SortAlphaAsc);
                            temp += I18n.Translate("internal/Action/desclistsortstring",
                                    "sort {1}list variable ({0}) in an alphabetically {2} order",
                                    _ListVariableName, sPersistL, strOrder);
                            break;
                        case ListVariableOpEnum.SortNumericAsc:
                        case ListVariableOpEnum.SortNumericDesc:
                            string numOrder = I18n.TrlSortAscOrDesc(_ListVariableOp == ListVariableOpEnum.SortNumericAsc);
                            temp += I18n.Translate("internal/Action/desclistsortnum",
                                    "sort {1}list variable ({0}) in a numerically {2} order",
                                    _ListVariableName, sPersistL, numOrder);
                            break;
                        case ListVariableOpEnum.SortFfxivPartyAsc:
                        case ListVariableOpEnum.SortFfxivPartyDesc:
                            string jobOrder = I18n.TrlSortAscOrDesc(_ListVariableOp == ListVariableOpEnum.SortFfxivPartyAsc);
                            temp += I18n.Translate("internal/Action/desclistsortffxiv",
                                    "sort {1}list variable ({0}) in an FFXIV party job {2} order",
                                    _ListVariableName, sPersistL, jobOrder);
                            break;
                        case ListVariableOpEnum.SortByKeys:
                            temp += I18n.Translate("internal/Action/desclistsortbykeys",
                                    "sort {1}list variable ({0}) by keys ({2})",
                                    _ListVariableName, sPersistL, _ListVariableExpression);
                            break;
                        case ListVariableOpEnum.Copy:
                            temp += I18n.Translate("internal/Action/desclistcopy",
                                    "copy {2}list variable ({0}) to {3}list variable ({1})",
                                    _ListVariableName, _ListVariableTarget, sPersistL, tPersistL);
                            break;
                        case ListVariableOpEnum.InsertList:
                            temp += I18n.Translate("internal/Action/desclistinsertlist",
                                    "insert {3}list variable ({0}) into {4}list variable ({1}) at index ({2})",
                                    _ListVariableName, _ListVariableTarget, _ListVariableIndex, sPersistL, tPersistL);
                            break;
                        case ListVariableOpEnum.Join:
                            temp += I18n.Translate("internal/Action/desclistjoin",
                                    "join all values in {3}list variable ({0}) to {4}scalar variable ({1}) using {5} expression ({2}) as separator",
                                    _ListVariableName, _ListVariableTarget, _ListVariableExpression, sPersistL, tPersistL, exprTypeL);
                            break;
                        case ListVariableOpEnum.Split:
                            temp += I18n.Translate("internal/Action/desclistsplit",
                                    "split {3}scalar variable ({0}) into {4}list variable ({1}) using {5} expression ({2}) as separator",
                                    _ListVariableName, _ListVariableTarget, _ListVariableExpression, sPersistL, tPersistL, exprTypeL);
                            break;
                        case ListVariableOpEnum.Build:
                            if (_ListVariableExpressionType == ListVariableExpTypeEnum.String
                                && !_ListVariableExpression.StartsWith("$") && !_ListVariableExpression.StartsWith("ก่{"))
                                temp += I18n.Translate("internal/Action/desclistbuild",
                                        "build {1}list variable ({0}) from string ({2}) separated by ({3})",
                                        _ListVariableTarget, tPersistL,
                                        (_ListVariableExpression.Length == 0) ? "" : _ListVariableExpression.Substring(1),
                                        (_ListVariableExpression.Length == 0) ? "" : _ListVariableExpression.Substring(0, 1));
                            else
                                temp += I18n.Translate("internal/Action/desclistbuildraw",
                                        "build {1}list variable ({0}) from {3} expression ({2}) separated by its first character",
                                        _ListVariableTarget, tPersistL, _ListVariableExpression, exprTypeL);
                            break;
                        case ListVariableOpEnum.Filter:
                            temp += I18n.Translate("internal/Action/desclistfilter",
                                    "Use expression ({4}) to filter {1}list ({0}) into {3}list ({2})",
                                    _ListVariableName, sPersistL, _ListVariableTarget, tPersistL, _ListVariableExpression);
                            break;
                        case ListVariableOpEnum.UnsetAll:
                            temp += I18n.Translate("internal/Action/desclistunsetall",
                                    "unset all {0}list variables", sPersistL);
                            break;
                        case ListVariableOpEnum.UnsetRegex:
                            temp += I18n.Translate("internal/Action/desclistunsetregex",
                                    "unset {1}list variables matching regular expression ({0})", _ListVariableName, sPersistL);
                            break;
                    }
                    break;
                case ActionTypeEnum.GenericJson:
                    {
                        string cache = I18n.TrlCacheFile(_JsonCacheRequest);
                        if (_JsonFiringExpression != null && _JsonFiringExpression.Trim().Length > 0)
                        {
                            temp += I18n.Translate("internal/Action/descjsonsendrelay",
                                "send JSON payload to endpoint ({0}){1}, and relaying response for further processing", _JsonEndpointExpression, cache);
                        }
                        else
                        {
                            temp += I18n.Translate("internal/Action/descjsonsend",
                                "send JSON payload to endpoint ({0}){1} and cache the response", _JsonEndpointExpression, cache);
                        }
                        break;
                    }
                case ActionTypeEnum.ObsControl:
                    switch (_OBSControlType)
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
                        case ObsControlTypeEnum.RestartRecording:
                            temp += I18n.Translate("internal/Action/descobsrestartrecord", "stop then start recording on OBS");
                            break;
                        case ObsControlTypeEnum.RestartRecordingIfActive:
                            temp += I18n.Translate("internal/Action/descobsrestartrecordifactive", "stop then start recording on OBS (if currently recording)");
                            break;
                        case ObsControlTypeEnum.ResumeRecording:
                            temp += I18n.Translate("internal/Action/descobsresumerecord", "resume recording on OBS");
                            break;
                        case ObsControlTypeEnum.PauseRecording:
                            temp += I18n.Translate("internal/Action/descobspauserecord", "pause recording on OBS");
                            break;
                        case ObsControlTypeEnum.ToggleRecordPause:
                            temp += I18n.Translate("internal/Action/descobstogglerecordpause", "resume/pause recording on OBS (toggle)");
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
                            temp += I18n.Translate("internal/Action/descobssetscene", "set current OBS scene to ({0})", _OBSSceneName);
                            break;
                        case ObsControlTypeEnum.ShowSource:
                            temp += I18n.Translate("internal/Action/descobsshowsource", "show source ({0}) on OBS scene ({1})", _OBSSourceName, _OBSSceneName);
                            break;
                        case ObsControlTypeEnum.HideSource:
                            temp += I18n.Translate("internal/Action/descobshidesource", "hide source ({0}) on OBS scene ({1})", _OBSSourceName, _OBSSceneName);
                            break;
                        case ObsControlTypeEnum.JSONPayload:
                            temp += I18n.Translate("internal/Action/descobsjsonpayload", "Send custom JSON payload to OBS");
                            break;
                    }
                    break;
                case ActionTypeEnum.LiveSplitControl:
                    switch (_LSControlType)
                    {
                        case LiveSplitControlTypeEnum.StartOrSplit:
                            temp += I18n.Translate("internal/Action/desclsstartorsplit", "Start run or split on LiveSplit");
                            break;
                        case LiveSplitControlTypeEnum.Start:
                            temp += I18n.Translate("internal/Action/desclsstart", "Start run on LiveSplit");
                            break;
                        case LiveSplitControlTypeEnum.Split:
                            temp += I18n.Translate("internal/Action/desclssplit", "Split on LiveSplit");
                            break;
                        case LiveSplitControlTypeEnum.UndoSplit:
                            temp += I18n.Translate("internal/Action/desclsundosplit", "Undo split on LiveSplit");
                            break;
                        case LiveSplitControlTypeEnum.SkipSplit:
                            temp += I18n.Translate("internal/Action/desclsskipsplit", "Skip split on LiveSplit");
                            break;
                        case LiveSplitControlTypeEnum.Reset:
                            temp += I18n.Translate("internal/Action/desclsreset", "Reset run on LiveSplit");
                            break;
                        case LiveSplitControlTypeEnum.Pause:
                            temp += I18n.Translate("internal/Action/desclspause", "Pause run on LiveSplit");
                            break;
                        case LiveSplitControlTypeEnum.Resume:
                            temp += I18n.Translate("internal/Action/desclsresume", "Resume run on LiveSplit");
                            break;
                        case LiveSplitControlTypeEnum.CustomPayload:
                            temp += I18n.Translate("internal/Action/desclscustompayload", "Send custom payload to LiveSplit");
                            break;
                    }
                    break;
                case ActionTypeEnum.Variable:
                    string sPersist = I18n.TrlVarPersist(_VariablePersist);
                    string tPersist = I18n.TrlVarPersist(_VariableTargetPersist);
                    switch (_VariableOp)
                    {
                        case VariableOpEnum.SetNumeric:
                        case VariableOpEnum.SetString:
                            string exprType = I18n.TrlExprType(_VariableOp == VariableOpEnum.SetString);
                            temp += I18n.Translate("internal/Action/descscalarset",
                                "set {1}scalar variable ({0}) value with {3} expression ({2})",
                                _VariableName, sPersist, _VariableExpression, exprType);
                            break;
                        case VariableOpEnum.Increment:
                            string value = string.IsNullOrWhiteSpace(_VariableExpression) ? "1" : _VariableExpression;
                            temp += I18n.Translate("internal/Action/descscalarincrement",
                                "increment the value of {1}scalar variable ({0}) by ({2})",
                                _VariableName, sPersist, value);
                            break;
                        case VariableOpEnum.Clipboard:
                            bool isName = !string.IsNullOrWhiteSpace(_VariableName);
                            if (isName)
                                temp += I18n.Translate("internal/Action/descscalarclipboardvar",
                                    "Copy {1}scalar variable ({0}) value to clipboard", _VariableName, sPersist);
                            else
                                temp += I18n.Translate("internal/Action/descscalarclipboardexpr",
                                    "Copy string expression ({0}) to clipboard", _VariableExpression);
                            break;
                        case VariableOpEnum.Unset:
                            temp += I18n.Translate("internal/Action/descscalarunset",
                                "unset {1}scalar variable ({0})", _VariableName, sPersist);
                            break;
                        case VariableOpEnum.UnsetAll:
                            temp += I18n.Translate("internal/Action/descscalarunsetall",
                                "unset all {0}scalar variables", sPersist);
                            break;
                        case VariableOpEnum.UnsetRegex:
                            temp += I18n.Translate("internal/Action/descscalarunsetregex",
                                "unset {1}scalar variables matching regular expression ({0})",
                                _VariableName, sPersist);
                            break;
                        case VariableOpEnum.UnsetRegexUniversal:
                            temp += I18n.Translate("internal/Action/descscalarunsetregexuniversal",
                                "unset all types of {1}variables matching regular expression ({0})",
                                _VariableName, sPersist);
                            break;
                        case VariableOpEnum.QueryJsonPath:
                            temp += I18n.Translate("internal/Action/descscalarqueryjson",
                                "query {1} variable ({0}) with JSON path ({2}) and store result to {4}scalar variable ({3})",
                                _VariableName, sPersist, _VariableExpression, _VariableJsonTarget, tPersist);
                            break;
                        case VariableOpEnum.QueryJsonPathList:
                            temp += I18n.Translate("internal/Action/descscalarqueryjsonlist",
                                "query {1} variable ({0}) with JSON path ({2}) and store result to {4}list variable ({3})",
                                _VariableName, sPersist, _VariableExpression, _VariableJsonTarget, tPersist);
                            break;
                    }
                    break;
                case ActionTypeEnum.TableVariable:
                    string sPersistT = I18n.TrlVarPersist(_TableSourcePersist);
                    string tPersistT = I18n.TrlVarPersist(_TableTargetPersist);
                    string exprTypeT = I18n.TrlExprType(_TableVariableExpressionType == TableVariableExpTypeEnum.String);
                    switch (_TableVariableOp)
                    {
                        case TableVariableOpEnum.Set:
                            temp += I18n.Translate("internal/Action/desctableset",
                                    "set {1}table variable ({0}) value at ({2},{3}) with {5} expression ({4})",
                                    _TableVariableName, sPersistT, _TableVariableX, _TableVariableY, _TableVariableExpression, exprTypeT);
                            break;
                        case TableVariableOpEnum.SetAll:
                            {
                                temp += I18n.Translate("internal/Action/desctablesetall",
                                        "set all values in {1}table ({0}) to {3} expr ({2})",
                                        _TableVariableName, sPersistT, _TableVariableExpression, exprTypeT);
                                bool givenX = !string.IsNullOrWhiteSpace(_TableVariableX);
                                bool givenY = !string.IsNullOrWhiteSpace(_TableVariableY);
                                if (givenX && givenY)
                                {
                                    temp += I18n.Translate("internal/Action/desctablesetallresizeXY",
                                            " (resized to width ({0}) height ({1}))", _TableVariableX, _TableVariableY);
                                }
                                else if (givenX && !givenY)
                                {
                                    temp += I18n.Translate("internal/Action/desctablesetallresizeX",
                                            " (resized to width ({0}))", _TableVariableX);
                                }
                                else if (!givenX && givenY)
                                {
                                    temp += I18n.Translate("internal/Action/desctablesetallresizeY",
                                            " (resized to height ({0}))", _TableVariableY);
                                }
                            }
                            break;
                        case TableVariableOpEnum.SlicesSetAll:
                            {
                                temp += I18n.Translate("internal/Action/desctableslicessetall",
                                        "set all values in column(s) ({4}) and row(s) ({5}) of {1}table ({0}) to {3} expr ({2})",
                                        _TableVariableName, sPersistT, _TableVariableExpression, exprTypeT,
                                        _TableVariableX, _TableVariableY);
                            }
                            break;
                        case TableVariableOpEnum.Resize:
                            {
                                temp += I18n.Translate("internal/Action/desctableresizeprefix",
                                        "resize {1}table variable ({0}) to", _TableVariableName, sPersistT);
                                bool givenCol = !string.IsNullOrWhiteSpace(_TableVariableX);
                                bool givenRow = !string.IsNullOrWhiteSpace(_TableVariableY);
                                if (!givenCol && !givenRow)
                                {
                                    temp += I18n.Translate("internal/Action/desctableresizeunchanged", " (unchanged)");
                                }
                                if (givenCol)
                                {
                                    temp += I18n.Translate("internal/Action/desctableresizecol", " width ({0})", _TableVariableX);
                                }
                                if (givenRow)
                                {
                                    temp += I18n.Translate("internal/Action/desctableresizerow", " height ({0})", _TableVariableY);
                                }
                            }
                            break;
                        case TableVariableOpEnum.Unset:
                            temp += I18n.Translate("internal/Action/desctableunset",
                                "unset {1}table variable ({0})", _TableVariableName, sPersistT);
                            break;
                        case TableVariableOpEnum.UnsetAll:
                            temp += I18n.Translate("internal/Action/desctableunsetall",
                                "unset {0}all table variables", sPersistT);
                            break;
                        case TableVariableOpEnum.UnsetRegex:
                            temp += I18n.Translate("internal/Action/desctableunsetregex",
                                "unset {1}table variables matching regular expression ({0})", _TableVariableName, sPersistT);
                            break;
                        case TableVariableOpEnum.Copy:
                            temp += I18n.Translate("internal/Action/desctablecopy",
                                "copy {2}table variable ({0}) to {3}table variable ({1})",
                                _TableVariableName, _TableVariableTarget, sPersistT, tPersistT);
                            break;
                        case TableVariableOpEnum.Append:
                            temp += I18n.Translate("internal/Action/desctableappend",
                                "vertically append {2}table variable ({0}) to {3}table variable ({1})",
                                _TableVariableName, _TableVariableTarget, sPersistT, tPersistT);
                            break;
                        case TableVariableOpEnum.AppendH:
                            temp += I18n.Translate("internal/Action/desctableappendh",
                                "horizontally append {2}table variable ({0}) to {3}table variable ({1})",
                                _TableVariableName, _TableVariableTarget, sPersistT, tPersistT);
                            break;
                        case TableVariableOpEnum.Build:
                            int dollarIndex = _TableVariableExpression.IndexOf("$");
                            int crcIndex = _TableVariableExpression.IndexOf("ก่{");
                            if (_TableVariableExpressionType == TableVariableExpTypeEnum.String
                                && dollarIndex != 0 && dollarIndex != 1 && crcIndex != 0 && crcIndex != 1)
                                temp += I18n.Translate("internal/Action/desctablebuild",
                                    "build {1}table variable ({0}) from string ({2}) separated by ({3}) ({4})",
                                    _TableVariableTarget, tPersistT,
                                    (_TableVariableExpression.Length < 2) ? "" : _TableVariableExpression.Substring(2),
                                    (_TableVariableExpression.Length < 1) ? "" : _TableVariableExpression.Substring(0, 1),
                                    (_TableVariableExpression.Length < 2) ? "" : _TableVariableExpression.Substring(1, 1));
                            else
                                temp += I18n.Translate("internal/Action/desctablebuildraw",
                                    "build {1}table variable ({0}) from {3} expression ({2}) separated by its first 2 characters",
                                    _TableVariableTarget, tPersistT, _TableVariableExpression, exprTypeT);
                            break;
                        case TableVariableOpEnum.Filter:
                            {
                                temp += I18n.Translate("internal/Action/desctablefilter",
                                    "Use expression ({4}) to filter {1}table ({0}) into {3}list ({2})",
                                    _TableVariableName, sPersistT, _TableVariableTarget, tPersistT, _TableVariableExpression);
                            }
                            break;
                        case TableVariableOpEnum.FilterLine:
                            {
                                bool isCol = !string.IsNullOrWhiteSpace(_TableVariableX);
                                string lineType = I18n.TrlTableColOrRow(isCol);
                                temp += I18n.Translate("internal/Action/desctablefilterline",
                                    "Use expression ({4}) to filter the {5}s in {1}table ({0}) into {3}table ({2})",
                                    _TableVariableName, sPersistT, _TableVariableTarget, tPersistT,
                                    isCol ? _TableVariableX : _TableVariableY, lineType);
                            }
                            break;
                        case TableVariableOpEnum.SetLine:
                            {
                                string lineType = I18n.TrlTableColOrRow(!string.IsNullOrWhiteSpace(_TableVariableX));
                                string index = (!string.IsNullOrWhiteSpace(_TableVariableX)) ? _TableVariableX : _TableVariableY;
                                if (_TableVariableExpressionType == TableVariableExpTypeEnum.String
                                    && !_TableVariableExpression.StartsWith("$") && !_TableVariableExpression.StartsWith("ก่{"))
                                    temp += I18n.Translate("internal/Action/desctablesetline",
                                        "set {1}table ({0}) {2} #({3}) values from string ({4}) separated by ({5})",
                                        _TableVariableName, sPersistT, lineType, index,
                                        (_TableVariableExpression.Length < 1) ? "" : _TableVariableExpression.Substring(1),
                                        (_TableVariableExpression.Length < 1) ? "" : _TableVariableExpression.Substring(0, 1));
                                else
                                    temp += I18n.Translate("internal/Action/desctablesetlineraw",
                                        "set {1}table ({0}) {2} #({3}) values from {5} expression ({4}) separated by its first character",
                                        _TableVariableName, sPersistT, lineType, index, _TableVariableExpression, exprTypeT);
                            }
                            break;
                        case TableVariableOpEnum.InsertLine:
                            {
                                string lineType = I18n.TrlTableColOrRow(!string.IsNullOrWhiteSpace(_TableVariableX));
                                string index = (!string.IsNullOrWhiteSpace(_TableVariableX)) ? _TableVariableX : _TableVariableY;
                                if (_TableVariableExpressionType == TableVariableExpTypeEnum.String
                                    && !_TableVariableExpression.StartsWith("$") && !_TableVariableExpression.StartsWith("ก่{"))
                                    temp += I18n.Translate("internal/Action/desctableinsertline",
                                        "at {1}table ({0}) {3} #({2}), insert values from string ({4}) separated by ({5})",
                                        _TableVariableName, sPersistT, lineType, index,
                                        (_TableVariableExpression.Length < 1) ? "" : _TableVariableExpression.Substring(1),
                                        (_TableVariableExpression.Length < 1) ? "" : _TableVariableExpression.Substring(0, 1));
                                else
                                    temp += I18n.Translate("internal/Action/desctableinsertlineraw",
                                        "at {1}table ({0}) {3} #({2}), insert values from {5} expression ({4}) separated by its first character",
                                        _TableVariableName, sPersistT, lineType, index, _TableVariableExpression, exprTypeT);
                            }
                            break;
                        case TableVariableOpEnum.RemoveLine:
                            {
                                string lineType = I18n.TrlTableColOrRow(!string.IsNullOrWhiteSpace(_TableVariableX));
                                string index = (!string.IsNullOrWhiteSpace(_TableVariableX)) ? _TableVariableX : _TableVariableY;
                                temp += I18n.Translate("internal/Action/desctableremoveline",
                                        "removed {2} #({3}) from {1}table ({0})",
                                        _TableVariableName, sPersistT, lineType, index);
                            }
                            break;
                        case TableVariableOpEnum.SortLine:
                            {
                                bool isCol = !string.IsNullOrWhiteSpace(_TableVariableX);
                                string lineType = I18n.TrlTableColOrRow(isCol);
                                temp += I18n.Translate("internal/Action/desctablesortline",
                                    "sort the {2}s of {1}table variable ({0}) by keys ({3})",
                                    _TableVariableName, sPersistT, lineType, isCol ? _TableVariableX : _TableVariableY);
                            }
                            break;
                        case TableVariableOpEnum.GetAllEntities:
                            {
                                bool hasFilter = string.IsNullOrWhiteSpace(_TableVariableY);
                                bool hasSpecifiedProps = !string.IsNullOrWhiteSpace(_TableVariableX);
                                string keySuffix = (hasFilter ? "1" : "0") + (hasSpecifiedProps ? "1" : "0");
                                string key = $"internal/Action/desctablegetallentities{keySuffix}"; //...00, ...01, ...10, ...11
                                string trl = "";
                                switch (keySuffix)
                                {
                                    case "11": trl = "Store ({3}) properties of FFXIV entities matching ({2}) in {1}table ({0})"; break;
                                    case "10": trl = "Store all properties of FFXIV entities matching ({2}) in {1}table ({0})"; break;
                                    case "01": trl = "Store ({3}) properties of all FFXIV entities in {1}table ({0})"; break;
                                    case "00": trl = "Store all properties of all FFXIV entities in {1}table ({0})"; break;
                                }
                                temp += I18n.Translate(key, trl, _TableVariableName, sPersistT, _TableVariableY, _TableVariableX);
                            }
                            break;
                    }
                    break;
                case ActionTypeEnum.DictVariable:
                    string sPersistD = I18n.TrlVarPersist(_DictSourcePersist);
                    string tPersistD = I18n.TrlVarPersist(_DictTargetPersist);
                    string keyType = I18n.TrlExprType(_DictVariableKeyType == DictVariableExpTypeEnum.String);
                    string valueType = I18n.TrlExprType(_DictVariableValueType == DictVariableExpTypeEnum.String);
                    switch (_DictVariableOp)
                    {
                        case DictVariableOpEnum.Unset:
                            temp += I18n.Translate("internal/Action/descdictunset",
                                "unset {1}dict variable ({0})",
                                _DictVariableName, sPersistD);
                            break;
                        case DictVariableOpEnum.Set:
                            temp += I18n.Translate("internal/Action/descdictset",
                                "set the value of {3} key ({2}) in the {1}dict variable ({0}) to {5} expression ({4})",
                                _DictVariableName, sPersistD, _DictVariableKey, keyType, _DictVariableValue, valueType);
                            break;
                        case DictVariableOpEnum.Remove:
                            temp += I18n.Translate("internal/Action/descdictremove",
                                "remove the {3} key ({2}) in the {1}dict variable ({0})",
                                _DictVariableName, sPersistD, _DictVariableKey, keyType);
                            break;
                        case DictVariableOpEnum.Build:
                            int dollarIndex = _DictVariableValue.IndexOf("$");
                            int crcIndex = _DictVariableValue.IndexOf("ก่{");
                            if (_DictVariableValueType == DictVariableExpTypeEnum.String
                                && dollarIndex != 0 && dollarIndex != 1 && crcIndex != 0 && crcIndex != 1)
                                temp += I18n.Translate("internal/Action/descdictbuild",
                                    "build {1}dict variable ({0}) from string ({2}) separated by ({3}) ({4})",
                                    _DictVariableTarget, tPersistD,
                                    (_DictVariableValue.Length < 2) ? "" : _DictVariableValue.Substring(2),
                                    (_DictVariableValue.Length < 1) ? "" : _DictVariableValue.Substring(0, 1),
                                    (_DictVariableValue.Length < 2) ? "" : _DictVariableValue.Substring(1, 1));
                            else
                                temp += I18n.Translate("internal/Action/descdictbuildraw",
                                    "build {1}dict variable ({0}) from {3} expression ({2}) separated by its first 2 characters",
                                    _DictVariableTarget, tPersistD, _DictVariableValue, valueType);
                            break;
                        case DictVariableOpEnum.Filter:
                            temp += I18n.Translate("internal/Action/descdictfilter",
                                    "Use expression ({4}) to filter {1}dict ({0}) into {3}dict ({2})",
                                    _DictVariableName, sPersistD, _DictVariableTarget, tPersistD, _DictVariableValue);
                            break;
                        case DictVariableOpEnum.SetAll:
                            if (string.IsNullOrWhiteSpace(_DictVariableLength))
                                temp += I18n.Translate("internal/Action/descdictsetall",
                                    "rewrite all key value pairs in {1}dict ({0}) to {3} expr ({2}) : {5} expr ({4})",
                                    _DictVariableName, sPersistD, _DictVariableKey, keyType, _DictVariableValue, valueType);
                            else
                                temp += I18n.Translate("internal/Action/descdictsetallbyindex",
                                    "set {6} key value pairs in {1}dict ({0}) to {3} expr ({2}) : {5} expr ({4})",
                                    _DictVariableName, sPersistD, _DictVariableKey, keyType, _DictVariableValue, valueType, _DictVariableLength);
                            break;
                        case DictVariableOpEnum.Merge:
                            temp += I18n.Translate("internal/Action/descdictmerge",
                                "merge {1}dict variable ({0}) into {3}dict variable ({2}), and keep the values of repeated keys",
                                _DictVariableName, sPersistD, _DictVariableTarget, tPersistD);
                            break;
                        case DictVariableOpEnum.MergeHard:
                            temp += I18n.Translate("internal/Action/descdictmergehard",
                                "merge {1}dict variable ({0}) into {3}dict variable ({2}), and overwrite the values of repeated keys",
                                _DictVariableName, sPersistD, _DictVariableTarget, tPersistD);
                            break;
                        case DictVariableOpEnum.GetEntity:
                            {
                                bool hasSpecifiedProps = !string.IsNullOrWhiteSpace(_DictVariableKey);
                                string key = hasSpecifiedProps ? "internal/Action/descdictgetentitygivenprops"
                                                               : "internal/Action/descdictgetentity";
                                string trl = hasSpecifiedProps ? "Store ({3}) properties of the entity ({2}) in {1}dictionary ({0})"
                                                               : "Store all properties of the entity ({2}) in {1}dictionary ({0})";
                                temp += I18n.Translate(key, trl, _DictVariableName, sPersistD, _DictVariableValue, _DictVariableKey);
                            }
                            break;
                        case DictVariableOpEnum.UnsetAll:
                            temp += I18n.Translate("internal/Action/descdictunsetall",
                                "unset all {0}dict variables",
                                sPersistD);
                            break;
                        case DictVariableOpEnum.UnsetRegex:
                            temp += I18n.Translate("internal/Action/descdictunsetregex",
                                "unset all {0}dict variables matching regular expression ({1})",
                                sPersistD, _DictVariableName);
                            break;
                    }
                    break;
                case ActionTypeEnum.Aura:
                    switch (_AuraOp)
                    {
                        case AuraOpEnum.ActivateAura:
                            temp += I18n.Translate("internal/Action/descimgauraact", "activate image aura ({0}) with image ({1})", _AuraName, _AuraImage);
                            break;
                        case AuraOpEnum.DeactivateAura:
                            temp += I18n.Translate("internal/Action/descimgauradeact", "deactivate image aura ({0})", _AuraName);
                            break;
                        case AuraOpEnum.DeactivateAllAura:
                            temp += I18n.Translate("internal/Action/descimgauradeactall", "deactivate all image auras");
                            break;
                        case AuraOpEnum.DeactivateAuraRegex:
                            temp += I18n.Translate("internal/Action/descimgauradeactrex", "deactivate image auras matching regular expression ({0})", _AuraName);
                            break;
                    }
                    break;
                case ActionTypeEnum.TextAura:
                    switch (_TextAuraOp)
                    {
                        case AuraOpEnum.ActivateAura:
                            temp += I18n.Translate("internal/Action/desctextauraact", "activate text aura ({0}) with expression ({1})", _TextAuraName, _TextAuraExpression);
                            break;
                        case AuraOpEnum.DeactivateAura:
                            temp += I18n.Translate("internal/Action/desctextauradeact", "deactivate text aura ({0})", _TextAuraName);
                            break;
                        case AuraOpEnum.DeactivateAllAura:
                            temp += I18n.Translate("internal/Action/desctextauradeactall", "deactivate all text auras");
                            break;
                        case AuraOpEnum.DeactivateAuraRegex:
                            temp += I18n.Translate("internal/Action/desctextauradeactrex", "deactivate text auras matching regular expression ({0})", _TextAuraName);
                            break;
                    }
                    break;
                case ActionTypeEnum.DiscordWebhook:
                    {
                        if (_DiscordTts == true)
                        {
                            temp += I18n.Translate("internal/Action/descdiscordttsmsg", "send TTS message ({0}) to Discord webhook ({1})", _DiscordWebhookMessage, _DiscordWebhookURL);
                        }
                        else
                        {
                            temp += I18n.Translate("internal/Action/descdiscordmsg", "send message ({0}) to Discord webhook ({1})", _DiscordWebhookMessage, _DiscordWebhookURL);
                        }
                    }
                    break;
                case ActionTypeEnum.LogMessage:
                    {
                        if (_LogProcess == true)
                        {
                            string srcType = "";
                            switch (_LogMessageTarget)
                            {
                                case LogEvent.SourceEnum.ACT: srcType = "ACT event"; break;
                                case LogEvent.SourceEnum.NetworkFFXIV: srcType = "FFXIV network event"; break;
                                case LogEvent.SourceEnum.Log: srcType = "Normal log line"; break;
                            }
                            srcType = I18n.Translate($"ActionForm/cbxLogMessageTarget[{srcType}]", srcType);
                            temp += I18n.Translate("internal/Action/descprocessmessage",
                                "process message ({0}) as {1}", _LogMessageText, srcType);
                        }
                        else
                        {
                            string level = "";
                            switch (_LogLevel)
                            {
                                case LogMessageEnum.Error: level = "Error"; break;
                                case LogMessageEnum.Info: level = "Info"; break;
                                case LogMessageEnum.Verbose: level = "Verbose"; break;
                                case LogMessageEnum.Warning: level = "Warning"; break;
                                case LogMessageEnum.Custom: level = "Custom"; break;
                                case LogMessageEnum.Custom2: level = "Custom 2"; break;
                            }
                            level = I18n.Translate($"ActionForm/cbxLogMessageLevel[{level}]", level);
                            temp += I18n.Translate("internal/Action/desclogmessage",
                                "log message ({0}) with {1} level", _LogMessageText, level);
                        }
                    }
                    break;
                case ActionTypeEnum.WindowMessage:
                    {
                        string target = GetTargetWindowsDescription(_WmsgProcId, _WmsgTitle);
                        temp += I18n.Translate("internal/Action/descwmsg", "send message ({0}) wparam ({1}) lparam ({2}) to {3}", _WmsgCode, _WmsgWparam, _WmsgLparam, target);
                        break;
                    }
                case ActionTypeEnum.DiskFile:
                    {
                        string persist = I18n.TrlVarPersist(_DiskPersist);
                        string cache = I18n.TrlCacheFile(_DiskFileCache);
                        switch (_DiskFileOp)
                        {
                            case DiskFileOpEnum.ReadIntoListVariable:
                                temp += I18n.Translate("internal/Action/descfilereadlistvar",
                                    "read file ({0}) lines into {2}list variable ({1}){3}",
                                    _DiskFileOpName, _DiskFileOpVar, persist, cache);
                                break;
                            case DiskFileOpEnum.ReadIntoVariable:
                                temp += I18n.Translate("internal/Action/descfilereadvar",
                                    "read file ({0}) lines into {2}scalar variable ({1}){3}",
                                    _DiskFileOpName, _DiskFileOpVar, persist, cache);
                                break;
                            case DiskFileOpEnum.ReadCSVIntoTableVariable:
                                temp += I18n.Translate("internal/Action/descfilereadcsvtable",
                                    "read csv file ({0}) into {2}table variable ({1}){3}",
                                    _DiskFileOpName, _DiskFileOpVar, persist, cache);
                                break;
                        }
                    }
                    break;
                case ActionTypeEnum.Placeholder:
                    temp += I18n.Translate("internal/Action/descplaceholder", "Placeholder");
                    break;
                case ActionTypeEnum.NamedCallback:
                    temp += I18n.Translate("internal/Action/descnamedcallback", "Invoke named callback ({0}) with parameter ({1})", _NamedCallbackName, _NamedCallbackParam);
                    break;
                case ActionTypeEnum.Mouse:
                    {
                        string coorddesc = "";
                        switch (_MouseCoordType)
                        {
                            case MouseCoordEnum.Absolute:
                                coorddesc = I18n.Translate("internal/Action/descmousecoordabsolute", "to absolute coordinates");
                                break;
                            case MouseCoordEnum.Relative:
                                coorddesc = I18n.Translate("internal/Action/descmousecoordrelative", "by relative coordinates");
                                break;
                        }
                        switch (_MouseOpType)
                        {
                            case MouseOpEnum.Move:
                                temp += I18n.Translate("internal/Action/descmousemove", "Move mouse {0} X: {1} Y: {2}", coorddesc, _MouseX, _MouseY);
                                break;
                            case MouseOpEnum.LeftClick:
                                temp += I18n.Translate("internal/Action/descmouselmb", "Move mouse {0} X: {1} Y: {2} and left click", coorddesc, _MouseX, _MouseY);
                                break;
                            case MouseOpEnum.MiddleClick:
                                temp += I18n.Translate("internal/Action/descmousemmb", "Move mouse {0} X: {1} Y: {2} and middle click", coorddesc, _MouseX, _MouseY);
                                break;
                            case MouseOpEnum.RightClick:
                                temp += I18n.Translate("internal/Action/descmousermb", "Move mouse {0} X: {1} Y: {2} and right click", coorddesc, _MouseX, _MouseY);
                                break;
                        }
                    }
                    break;
                case ActionTypeEnum.Loop:
                    temp += I18n.Translate("internal/Action/descloop", "Loop with {0} actions at ({1}) ms intervals",
                        LoopActions?.Count(action => action._Enabled) ?? 0,
                        string.IsNullOrWhiteSpace(_LoopDelayExpression) ? "0" : _LoopDelayExpression);
                    break;
                case ActionTypeEnum.Repository:
                    {
                        switch (_RepositoryOp)
                        {
                            case RepositoryOpEnum.UpdateSelf:
                                temp += I18n.Translate("internal/Action/repoupdateself", "Update containing repository");
                                break;
                            case RepositoryOpEnum.UpdateRepo:
                                {
                                    Repository r = plug.GetRepositoryById(_RepositoryId);
                                    if (r != null)
                                    {
                                        temp += I18n.Translate("internal/Action/repoupdatespecific", "Update repository ({0})", r.Name);
                                    }
                                    else
                                    {
                                        temp += I18n.Translate("internal/Action/descrepoinvalidref", "repository action with an invalid repository reference ({0})", _RepositoryId);
                                    }
                                }
                                break;
                            case RepositoryOpEnum.UpdateAll:
                                temp += I18n.Translate("internal/Action/repoupdateall", "Update all repositories");
                                break;
                        }
                    }
                    break;
                default:
                    temp += I18n.Translate("internal/Action/descunknown", "unknown action type");
                    break;
            }
            return Capitalize(temp);
        }

        internal List<WindowsMediaPlayer> players;

        public Action()
        {
            Id = Guid.NewGuid();
            Conditions = new EventList<Condition>();
            players = new List<WindowsMediaPlayer>();
        }

        private RealPlugin.DebugLevelEnum GetDebugLevel(Context ctx)
        {
            if (_DebugLevel == RealPlugin.DebugLevelEnum.Inherit)
            {
                return ctx.trig?.GetDebugLevel(plug) ?? DebugLevelEnum.Verbose;
            }
            else
            {
                return _DebugLevel;
            }
        }

        internal void AddToLog(Context ctx, RealPlugin.DebugLevelEnum level, string message)
        {
            RealPlugin.DebugLevelEnum dx = GetDebugLevel(ctx);
            if (level > dx)
            {
                return;
            }
            plug.UnfilteredAddToLog(level, message);
        }

        private VariableList GetListVariable(VariableStore vs, string varname, bool createNew)
        {
            if (vs.List.ContainsKey(varname) == true)
            {
                return vs.List[varname];
            }
            VariableList vl = new VariableList();
            if (createNew == true)
            {
                vs.List[varname] = vl;
            }
            return vl;
        }

        private VariableTable GetTableVariable(VariableStore vs, string varname, bool createNew)
        {
            if (vs.Table.ContainsKey(varname) == true)
            {
                return vs.Table[varname];
            }
            VariableTable vt = new VariableTable();
            if (createNew == true)
            {
                vs.Table[varname] = vt;
            }
            return vt;
        }

        private VariableDictionary GetDictVariable(VariableStore vs, string varname, bool createNew)
        {
            if (vs.Dict.ContainsKey(varname) == true)
            {
                return vs.Dict[varname];
            }
            VariableDictionary vd = new VariableDictionary();
            if (createNew == true)
            {
                vs.Dict[varname] = vd;
            }
            return vd;
        }

        private void VariablesUnsetRegex<TValue>(Dictionary<string, TValue> variables, Regex rx)
        {
            lock (variables)
            {
                List<string> keysToRemove = variables.Keys.Where(key => rx.IsMatch(key)).ToList();
                foreach (string key in keysToRemove)
                {
                    variables.Remove(key);
                }
            }
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

        internal static void CheckInvalidDymanicExpr(string expr, string[] invalidExprs)
        {
            foreach (string word in invalidExprs)
            {
                if (expr.Contains(word))
                    throw new ArgumentException(I18n.Translate("internal/Action/dynamicexprerror",
                        "The dynamic expression ({0}) is invalid in the current action. Expression: ({1})",
                        word, expr));
            }
        }

        private void ParseSortKeyFunctions(string rawExpr,
            out List<bool> isNumeric, out List<bool> isAscending,
            out List<string> keysExpr, out List<List<string>> values)
        {   // parsing expressions like "n+:key1, s-:key2, s+:key3, ..."
            string[] rawKeys = Context.SplitArguments(rawExpr, allowEmptyList: true);

            isNumeric = new List<bool>();       // numeric / string options
            isAscending = new List<bool>();     // ascending / descending options
            keysExpr = new List<string>();      // expression of the keys
            values = new List<List<string>>();  // each sublist contains the evaluated results of one key

            Regex regexSortKeyExpr = new Regex("^ *(?<type>[NnSs]) *(?<order>[-+]?) *:(?<key>.+)$");
            foreach (string rawKey in rawKeys)
            {
                Match keyMatch = regexSortKeyExpr.Match(rawKey);
                if (keyMatch.Success)
                {
                    isNumeric.Add(keyMatch.Groups["type"].Value.ToLower() == "n");
                    isAscending.Add(keyMatch.Groups["order"].Value != "-");
                    keysExpr.Add(keyMatch.Groups["key"].Value);
                    values.Add(new List<string>());
                }
                else
                {
                    throw new ArgumentException(I18n.Translate("internal/Action/sortkeyexprerror",
                        "The sorting key functions ({0}) could not be parsed.", rawKey));
                }
            }
        }

        private IOrderedEnumerable<int> ApplySorting(int elementCount,
            List<bool> isNumeric, List<bool> isAscending, List<List<string>> values)
        {
            // Create an enumeration of indices representing the initial order
            IEnumerable<int> indices = Enumerable.Range(0, elementCount);
            IOrderedEnumerable<int> sortedIndices = null;

            // Iterate through the sorting key functions
            for (int keyIndex = 0; keyIndex < values.Count; keyIndex++)
            {
                int k = keyIndex; // local variable for lambda expression
                // 4 sorting rules: numeric/string กม ascending/descending
                if (keyIndex == 0)
                {
                    if (isNumeric[k])
                    {
                        sortedIndices = isAscending[k]
                            ? indices.OrderBy(i => Convert.ToDouble(values[k][i]))
                            : indices.OrderByDescending(i => Convert.ToDouble(values[k][i]));
                    }
                    else
                    {
                        sortedIndices = isAscending[k]
                            ? indices.OrderBy(i => values[k][i])
                            : indices.OrderByDescending(i => values[k][i]);
                    }
                }
                else
                {
                    if (isNumeric[k])
                    {
                        sortedIndices = isAscending[k]
                            ? sortedIndices.ThenBy(i => Convert.ToDouble(values[k][i]))
                            : sortedIndices.ThenByDescending(i => Convert.ToDouble(values[k][i]));
                    }
                    else
                    {
                        sortedIndices = isAscending[k]
                            ? sortedIndices.ThenBy(i => values[k][i])
                            : sortedIndices.ThenByDescending(i => values[k][i]);
                    }
                }
            }
            return sortedIndices;
        }

        private void ExecutionImplementation(RealPlugin.QueuedAction qa, Context ctx)
        {
            try
            {
                if ((ctx.force & Action.TriggerForceTypeEnum.SkipConditions) == 0 && ctx.testByPlaceholder == false)
                {
                    if (_Condition != null && _Condition.Enabled == true)
                    {
                        if (_Condition.CheckCondition(ctx, ActionContextLogger, ctx) == false)
                        {
                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/actionnotfired", "Action #{0} on trigger '{1}' not fired, condition not met", OrderNumber, ctx.trig?.LogName ?? "(null)"));
                            ctx.PushActionResult(0);
                            goto ContinueChain;
                        }
                    }
                }
                ctx.PushActionResult(1);
                AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/executingaction", "Executing action '{0}' in thread {1}", GetDescription(ctx), System.Threading.Thread.CurrentThread.ManagedThreadId));

                switch (_ActionType)
                {
                    #region Implementation - ACT Interaction
                    case ActionTypeEnum.ActInteraction:
                        {
                            switch (_ActOpType)
                            {
                                case ActInteractionTypeEnum.SetCombatState:
                                    plug.SetCombatStateHook(_ActOpBoolParam);
                                    break;
                                case ActInteractionTypeEnum.LogAllNetwork:
                                    PluginBridges.BridgeFFXIV.LogAllNetwork(_ActOpBoolParam);
                                    break;
                                case ActInteractionTypeEnum.UseDeucalion:
                                    PluginBridges.BridgeFFXIV.UseDeucalion(_ActOpBoolParam);
                                    break;
                            }
                        }
                        break;
                    #endregion
                    #region Implementation - Beep
                    case ActionTypeEnum.SystemBeep:
                        {
                            double freq = ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _SystemBeepFreqExpression);
                            if (freq < 37.0)
                            {
                                freq = 37.0;
                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/beepfreqlo", "Beep frequency below limit, capping to {0}", freq));
                            }
                            if (freq > 32767.0)
                            {
                                freq = 32767.0;
                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/beepfreqhi", "Beep frequency above limit, capping to {0} ", freq));
                            }
                            double len = ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _SystemBeepLengthExpression);
                            if (len < 0.0)
                            {
                                len = 0.0;
                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/beeplengthlo", "Beep length below limit, capping to {0}", len));
                            }
                            Console.Beep((int)Math.Ceiling(freq), (int)Math.Ceiling(len));
                        }
                        break;
                    #endregion
                    #region Implementation - Dict variable
                    case ActionTypeEnum.DictVariable:
                        {
                            string sourcename = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _DictVariableName);
                            string targetname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _DictVariableTarget);
                            VariableStore svs = (_DictSourcePersist) ? plug.cfg.PersistentVariables : plug.sessionvars;
                            VariableStore tvs = (_DictTargetPersist) ? plug.cfg.PersistentVariables : plug.sessionvars;
                            string sPersist = I18n.TrlVarPersist(_DictSourcePersist);
                            string tPersist = I18n.TrlVarPersist(_DictTargetPersist);

                            string ParseKey()
                            {
                                if (_DictVariableKeyType == DictVariableExpTypeEnum.String)
                                    return ctx.EvaluateStringExpression(ActionContextLogger, ctx, _DictVariableKey);
                                else
                                    return I18n.ThingToString(ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _DictVariableKey));

                            }
                            string ParseValue()
                            {
                                if (_DictVariableValueType == DictVariableExpTypeEnum.String)
                                    return ctx.EvaluateStringExpression(ActionContextLogger, ctx, _DictVariableValue);
                                else
                                    return I18n.ThingToString(ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _DictVariableValue));
                            }

                            string vdchanger;
                            if (ctx.trig != null)
                                vdchanger = I18n.Translate("internal/Action/changetagtrigaction", "Trigger '{0}' action '{1}'", ctx.trig.LogName, GetDescription(ctx));
                            else
                                vdchanger = I18n.Translate("internal/Action/changetagtestmode", "Action '{0}' test mode", GetDescription(ctx));

                            switch (_DictVariableOp)
                            {
                                case DictVariableOpEnum.UnsetAll:
                                    lock (svs.Dict)
                                    {
                                        svs.Dict.Clear();
                                    }
                                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictunsetall",
                                        "All {0}dict variables unset", sPersist));
                                    break;
                                case DictVariableOpEnum.UnsetRegex:
                                    Regex rx = new Regex(_DictVariableName);
                                    VariablesUnsetRegex(svs.Dict, rx);
                                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictunsetregex",
                                        "All {0}dict variables matching ({1}) unset", sPersist, _DictVariableName));
                                    break;
                                case DictVariableOpEnum.Unset:
                                    lock (svs.Dict)
                                    {
                                        svs.Dict.Remove(sourcename);
                                    }
                                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictunset",
                                        "Unset {1}dict variable ({0})", sourcename, sPersist));
                                    break;
                                case DictVariableOpEnum.Set:
                                    {
                                        string[] invalidExprs = new[] { "${_row", "${_col", "${_this}", "${_idx}", "${_key}" };
                                        CheckInvalidDymanicExpr(_DictVariableValue, invalidExprs);

                                        string key = ParseKey();
                                        string value;
                                        lock (svs.Dict)
                                        {
                                            VariableDictionary vd = GetDictVariable(svs, sourcename, true);
                                            ctx.dictValue = vd.GetValue(key).ToString(); // for ${_val}
                                            value = ParseValue();
                                            vd.SetValue(key, value, vdchanger);
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictset",
                                            "Value of key ({2}) in {1}dict variable ({0}) set to ({3})", sourcename, sPersist, key, value));
                                    }
                                    break;
                                case DictVariableOpEnum.Remove:
                                    {
                                        string key = ParseKey();
                                        lock (svs.Dict)
                                        {
                                            VariableDictionary vd = GetDictVariable(svs, sourcename, true);
                                            vd.RemoveKey(key, vdchanger);
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictremove",
                                            "Removed key ({2}) from {1}dict variable ({0})", sourcename, sPersist, key));
                                    }
                                    break;
                                case DictVariableOpEnum.Merge:
                                case DictVariableOpEnum.MergeHard:
                                    {
                                        bool shouldOverwrite = (_DictVariableOp == DictVariableOpEnum.MergeHard);
                                        VariableDictionary svdCopy;
                                        lock (svs.Dict)
                                        {
                                            svdCopy = (VariableDictionary)GetDictVariable(svs, sourcename, false).Duplicate();
                                        }
                                        lock (tvs.Dict)
                                        {
                                            VariableDictionary tvd = GetDictVariable(tvs, targetname, true);
                                            tvd.Merge(svdCopy, overwriteExistingKeys: shouldOverwrite);
                                        }
                                        if (shouldOverwrite)
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictmergehard",
                                                "Merged {1}dict variable ({0}) into {3}dict variable ({2}) (overwrite repeated keys)",
                                                sourcename, sPersist, targetname, tPersist));
                                        else
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictmerge",
                                                "Merged {1}dict variable ({0}) into {3}dict variable ({2}) (keep repeated keys)",
                                                sourcename, sPersist, targetname, tPersist));
                                    }
                                    break;
                                case DictVariableOpEnum.GetEntity:
                                    {
                                        string value = ParseValue();

                                        var entity = FFXIV.Entity.GetFilteredEntities(value).FirstOrDefault();
                                        entity = entity ?? FFXIV.Entity.NullEntity();

                                        var propNames = string.IsNullOrWhiteSpace(_DictVariableKey)
                                            ? FFXIV.Entity.RecommendedEntityPropNames.Concat(FFXIV.Job.LegalJobPropNames)
                                            : Context.SplitArguments(ParseKey(), false);

                                        var vd = new VariableDictionary(propNames.ToDictionary(
                                            propName => propName,
                                            propName => entity.QueryProperty(propName)
                                        ));
                                        lock (svs.Dict)
                                        {
                                            svs.Dict[sourcename] = vd;
                                        }
                                        if (entity.Exist)
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictgetentity",
                                                "Saved the data of entity ({2}) into {1}dict variable ({0})",
                                                sourcename, sPersist, value));
                                        else
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/dictgetentityfail",
                                                "Entity ({2}) not found when trying to save into {1}dict variable ({0})",
                                                sourcename, sPersist, value));
                                    }
                                    break;
                                case DictVariableOpEnum.Build:
                                    {   // Using the first 2 characters in the expression as the separator to split the remaining part into a new dict
                                        // e.g. expr = ":,aaa:1,bbb:2,ccc:3"
                                        VariableDictionary vt = new VariableDictionary();
                                        string expr = ParseValue();
                                        if (expr.Length > 1)
                                        {
                                            if (expr[1] == '\n' || expr.Substring(1).StartsWith("\r\n"))
                                                expr = Context.ReplaceLineBreak(expr);
                                            char kvSeparator = expr[0];
                                            char pairSeparator = expr[1];
                                            string splitval = expr.Substring(2);
                                            vt = VariableDictionary.Build(splitval, kvSeparator, pairSeparator, vdchanger);
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictbuild",
                                                "{1}Dictionary ({0}) built from expression ({2}) splitted by ({3}) ({4})",
                                                targetname, tPersist, splitval, kvSeparator, pairSeparator));
                                        }
                                        else
                                        {
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/dictbuildfail",
                                                "{1}Dictionary ({0}) cannot be built since expression ({2}) length < 2",
                                                targetname, tPersist, expr));
                                        }
                                        lock (tvs.Dict)
                                        {
                                            tvs.Dict[targetname] = vt;
                                        }
                                    }
                                    break;
                                case DictVariableOpEnum.Filter:
                                    {
                                        string[] invalidExprs = new[] { "${_row", "${_col", "${_this}", "${_idx}" };
                                        CheckInvalidDymanicExpr(_DictVariableValue, invalidExprs);
                                        VariableDictionary vdResult = new VariableDictionary();
                                        lock (svs.Dict)
                                        {
                                            VariableDictionary vd = GetDictVariable(svs, sourcename, false);
                                            foreach (var pair in vd.Values)
                                            {
                                                ctx.dictKey = pair.Key;                 // for ${_key}
                                                ctx.dictValue = pair.Value.ToString();  // for ${_val}
                                                double result = ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _DictVariableValue);
                                                if (!MathParser.IsZero(result))
                                                {
                                                    vdResult.Values[pair.Key] = pair.Value.Duplicate();
                                                }
                                            }
                                        }
                                        vdResult.LastChanger = vdchanger;
                                        vdResult.LastChanged = DateTime.Now;
                                        lock (tvs.Dict)
                                        {
                                            tvs.Dict[targetname] = vdResult;
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictfilter",
                                                "Filtered {4} key-value pairs from {1}dict ({0}) into {3}dict ({2})",
                                                sourcename, sPersist, targetname, tPersist, vdResult.Size));
                                        }
                                    }
                                    break;
                                case DictVariableOpEnum.SetAll:
                                    {
                                        bool isLengthMode = !string.IsNullOrWhiteSpace(_DictVariableLength);
                                        int length = isLengthMode ? (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _DictVariableLength) : 0;
                                        string[] invalidExprs = new[] { "${_row", "${_col", "${_this}" };
                                        CheckInvalidDymanicExpr(_DictVariableKey, invalidExprs);
                                        CheckInvalidDymanicExpr(_DictVariableValue, invalidExprs);
                                        VariableDictionary vdNew = new VariableDictionary();
                                        lock (svs.Dict)
                                        {
                                            VariableDictionary vd = GetDictVariable(svs, sourcename, false);
                                            ctx.varName = (_DictSourcePersist ? "pdvar:" : "dvar:") + sourcename;

                                            if (isLengthMode)
                                            {   // should only use ${_idx} to generate each key/value
                                                for (int i = 0; i < length; i++)
                                                {
                                                    ctx.listIndex = i + 1;
                                                    ctx.dictKey = (i < vd.Size) ? vd.Values.ElementAt(i).Key : "";
                                                    ctx.dictValue = (i < vd.Size) ? vd.Values.ElementAt(i).Value.ToString() : "";
                                                    string k = ParseKey();
                                                    string v = ParseValue();
                                                    vdNew.SetValue(k, v, vdchanger);
                                                }
                                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictsetallbyindex",
                                                    "{4} key value pairs in {1}dictionary ({0}) set to ({2}): ({3})",
                                                    sourcename, sPersist, _DictVariableKey, _DictVariableValue, length));
                                            }
                                            else
                                            {   // should only use ${_key} and ${_val} to rewrite the list
                                                foreach (var pair in vd.Values)
                                                {
                                                    ctx.dictKey = pair.Key;
                                                    ctx.dictValue = pair.Value.ToString();
                                                    string k = ParseKey();
                                                    string v = ParseValue();
                                                    vdNew.SetValue(k, v, vdchanger);
                                                }
                                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictsetall",
                                                    "All key value pairs in {1}dictionary ({0}) set to ({2}): ({3})",
                                                    sourcename, sPersist, _DictVariableKey, _DictVariableValue));
                                            }
                                            svs.Dict[sourcename] = vdNew;
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    #endregion
                    #region Implementation - Discord webhook
                    case ActionTypeEnum.DiscordWebhook:
                        {
                            string msg = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _DiscordWebhookMessage);
                            string url = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _DiscordWebhookURL);
                            if (_DiscordTts == true)
                            {
                                if (msg.Length > 1970)
                                {
                                    msg = msg.Substring(0, 1970);
                                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/warndiscordtrunc", "Discord message too long, capping to {0}", msg.Length));
                                }
                                var wh = new JavaScriptSerializer().Serialize(new { content = msg, tts = true });
                                SendJson(ctx, HTTPMethodEnum.POST, url, wh, null, true);
                            }
                            else
                            {
                                if (msg.Length > 1980)
                                {
                                    msg = msg.Substring(0, 1980);
                                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/warndiscordtrunc", "Discord message too long, capping to {0}", msg.Length));
                                }
                                var wh = new JavaScriptSerializer().Serialize(new { content = msg });
                                SendJson(ctx, HTTPMethodEnum.POST, url, wh, null, true);
                            }
                        }
                        break;
                    #endregion
                    #region Implementation - Disk operation
                    case ActionTypeEnum.DiskFile:
                        {
                            string filename = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _DiskFileOpName);
                            string varname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _DiskFileOpVar);
                            string persist = I18n.TrlVarPersist(_DiskPersist);
                            string cache = I18n.TrlCacheFile(_DiskFileCache);
                            VariableStore vs = (_DiskPersist == false) ? plug.sessionvars : plug.cfg.PersistentVariables;
                            if (_DiskFileOp == DiskFileOpEnum.ReadCSVIntoTableVariable || _DiskFileOp == DiskFileOpEnum.ReadIntoListVariable || _DiskFileOp == DiskFileOpEnum.ReadIntoVariable)
                            {
                                Uri u = new Uri(filename);
                                if (u.IsFile == false)
                                {
                                    string fn = Path.Combine(plug.path, "TriggernometryFileCache");
                                    if (Directory.Exists(fn) == false)
                                    {
                                        Directory.CreateDirectory(fn);
                                    }
                                    string ext = Path.GetExtension(u.LocalPath);
                                    fn = Path.Combine(fn, plug.GenerateHash(u.AbsoluteUri) + Path.GetExtension(u.LocalPath));
                                    bool fromcache = false;
                                    if (File.Exists(fn) == true && _DiskFileCache == true)
                                    {
                                        FileInfo fi = new FileInfo(fn);
                                        DateTime dt = DateTime.Now.AddMinutes(0 - plug.cfg.CacheFileExpiry);
                                        if (fi.LastWriteTime > dt)
                                        {
                                            filename = fn;
                                            fromcache = true;
                                        }
                                    }
                                    if (fromcache == false)
                                    {
                                        using (WebClient wc = new WebClient())
                                        {
                                            wc.Headers["User-Agent"] = "Triggernometry File Retriever";
                                            byte[] data = wc.DownloadData(u.AbsoluteUri);
                                            File.WriteAllBytes(fn, data);
                                            filename = fn;
                                        }
                                    }
                                }
                            }
                            switch (_DiskFileOp)
                            {
                                case DiskFileOpEnum.ReadCSVIntoTableVariable:
                                    {
                                        List<string[]> data = new List<string[]>();
                                        int datawidth = 0;
                                        using (StreamReader sr = new StreamReader(filename))
                                        {
                                            using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
                                            {
                                                while (csv.Parser.Read() == true)
                                                {
                                                    string[] x = csv.Parser.Record;
                                                    if (x.Length > datawidth)
                                                    {
                                                        datawidth = x.Length;
                                                    }
                                                    data.Add(x);
                                                }
                                            }
                                        }
                                        VariableTable vt = GetTableVariable(vs, varname, true);
                                        if (data.Count > 0 && datawidth > 0)
                                        {
                                            string vtchanger;
                                            if (ctx.trig != null)
                                            {
                                                vtchanger = I18n.Translate("internal/Action/changetagtrigaction", "Trigger '{0}' action '{1}'", ctx.trig.LogName, GetDescription(ctx));
                                            }
                                            else
                                            {
                                                vtchanger = I18n.Translate("internal/Action/changetagtestmode", "Action '{0}' test mode", GetDescription(ctx));
                                            }
                                            vt.Resize(datawidth, data.Count);
                                            int y = 1;
                                            foreach (string[] row in data)
                                            {
                                                for (int x = 0; x < row.Length; x++)
                                                {
                                                    vt.Set(x + 1, y, row[x], vtchanger);
                                                }
                                                y++;
                                            }
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/filetableset",
                                            "{2}Table variable ({0}) value read from CSV file ({1})", varname, filename, persist));
                                    }
                                    break;
                                case DiskFileOpEnum.ReadIntoListVariable:
                                    {
                                        string[] data = File.ReadAllLines(filename);
                                        lock (vs.List) // verified
                                        {
                                            if (vs.List.ContainsKey(varname) == false)
                                            {
                                                vs.List[varname] = new VariableList();
                                            }
                                            VariableList x = vs.List[varname];
                                            foreach (string dat in data)
                                            {
                                                x.Push(new VariableScalar() { Value = dat }, "");
                                            }
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
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/filelistset",
                                            "{2}List variable ({0}) value read from file ({1})", varname, filename, persist));
                                    }
                                    break;
                                case DiskFileOpEnum.ReadIntoVariable:
                                    {
                                        string data = File.ReadAllText(filename);
                                        lock (vs.Scalar) // verified
                                        {
                                            if (vs.Scalar.ContainsKey(varname) == false)
                                            {
                                                vs.Scalar[varname] = new VariableScalar();
                                            }
                                            VariableScalar x = vs.Scalar[varname];
                                            x.Value = data;
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
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/filescalarset",
                                            "{2}Scalar variable ({0}) value read from file ({1})",
                                            varname, filename, persist));
                                    }
                                    break;
                            }
                        }
                        break;
                    #endregion
                    #region Implementation - Execute script
                    case ActionTypeEnum.ExecuteScript:
                        {
                            string scp = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _ExecScriptExpression);
                            string assy = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _ExecScriptAssembliesExpression);
                            while (plug.scriptingInited == false)
                            {
                                Thread.Sleep(10);
                            }
                            if (plug.scripting != null && plug.scripting.Ready)
                            {
                                plug.scripting.Evaluate(scp, assy, ctx);
                            }
                            else
                            {
                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/scriptinifailed", "Action #{0} on trigger '{1}' not fired, scripting not available", OrderNumber, ctx.trig?.LogName ?? "(null)"));
                            }
                        }
                        break;
                    #endregion
                    #region Implementation - Folder operation
                    case ActionTypeEnum.Folder:
                        {
                            Folder f = plug.GetFolderById(_FolderId, ctx.trig?.Repo);
                            if (f != null)
                            {
                                switch (_FolderOp)
                                {
                                    case FolderOpEnum.DisableFolder:
                                        {
                                            f.Enabled = false;

                                            plug.ui.Invoke((System.Action)(() =>
                                            {
                                                bool isLocal = ctx.trig?.Repo == null;
                                                TreeNode tn = plug.LocateNodeHostingFolder(plug.ui.treeView1.Nodes[isLocal ? 0 : 1], f);

                                                if (tn != null)
                                                {
                                                    tn.Checked = false;
                                                }
                                                else
                                                {
                                                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/notreenodefolderwithid", "Didn't find a tree node for folder ({0}) with id ({1})", f.Name, f.Id));
                                                }
                                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/disabledfolderwithid", "Disabled folder ({0}) with id ({1})", f.Name, f.Id));
                                            }));
                                        }
                                        break;
                                    case FolderOpEnum.EnableFolder:
                                        {
                                            f.Enabled = true;

                                            plug.ui.Invoke((System.Action)(() =>
                                            {
                                                bool isLocal = ctx.trig?.Repo == null;
                                                TreeNode tn = plug.LocateNodeHostingFolder(plug.ui.treeView1.Nodes[isLocal ? 0 : 1], f);

                                                if (tn != null)
                                                {
                                                    tn.Checked = true;
                                                }
                                                else
                                                {
                                                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/notreenodefolderwithid", "Didn't find a tree node for folder ({0}) with id ({1})", f.Name, f.Id));
                                                }
                                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/enabledfolderwithid", "Enabled folder ({0}) with id ({1})", f.Name, f.Id));
                                            }));
                                        }
                                        break;
                                    case FolderOpEnum.CancelFolder:
                                        {
                                            CancelAllTriggersInFolder(f, ctx);
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/cancelfolder", "Cancelled all triggers in folder ({0})", f.Name));
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/nofolderwithid",
                                    "Folder operation failed: In trigger ({1}), the specified folder id ({0}) does not exist.", _FolderId, ParentTrigger?.FullPath ?? "null"));
                            }
                        }
                        break;
                    #endregion
                    #region Implementation - Image aura
                    case ActionTypeEnum.Aura:
                        {
                            plug.ImageAuraManagement(ctx, this);
                        }
                        break;
                    #endregion
                    #region Implementation - JSON
                    case ActionTypeEnum.GenericJson:
                        {
                            string response = "";
                            int responseCode = 0;
                            string endpoint = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _JsonEndpointExpression);
                            string payload = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _JsonPayloadExpression);
                            string headers = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _JsonHeaderExpression).Trim();
                            string varname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _JsonResultVariable);
                            string persist = I18n.TrlVarPersist(_JsonResultVariablePersist);
                            List<string> headerslist = new List<string>();
                            if (headers.Length > 0)
                            {
                                headerslist.AddRange(headers.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                            }
                            if (_JsonCacheRequest == true)
                            {
                                string endpointh = plug.GenerateHash(endpoint);
                                string payloadh = plug.GenerateHash(payload);
                                string headersh = plug.GenerateHash(headers);
                                string fh = plug.GenerateHash(endpointh + payloadh + headers);
                                string fn = Path.Combine(plug.path, "TriggernometryJsonCache");
                                if (Directory.Exists(fn) == false)
                                {
                                    Directory.CreateDirectory(fn);
                                }
                                fn = Path.Combine(fn, fh + ".json");
                                bool fromcache = false;
                                if (File.Exists(fn) == true)
                                {
                                    FileInfo fi = new FileInfo(fn);
                                    DateTime dt = DateTime.Now.AddMinutes(0 - plug.cfg.CacheJsonExpiry);
                                    if (fi.LastWriteTime > dt)
                                    {
                                        responseCode = (int)HttpStatusCode.OK;
                                        response = File.ReadAllText(fn);
                                        fromcache = true;
                                    }
                                }
                                if (fromcache == false)
                                {
                                    Tuple<int, string> resp = SendJson(ctx, _JsonOperationType, endpoint, payload, headerslist, false);
                                    responseCode = resp.Item1;
                                    response = resp.Item2;
                                    File.WriteAllText(fn, response);
                                }
                            }
                            else
                            {
                                Tuple<int, string> resp = SendJson(ctx, _JsonOperationType, endpoint, payload, headerslist, false);
                                responseCode = resp.Item1;
                                response = resp.Item2;
                            }
                            if (varname != "")
                            {
                                VariableStore vs = (_JsonResultVariablePersist == false) ? plug.sessionvars : plug.cfg.PersistentVariables;
                                lock (vs.Scalar) // verified
                                {
                                    if (vs.Scalar.ContainsKey(varname) == false)
                                    {
                                        vs.Scalar[varname] = new VariableScalar();
                                    }
                                    VariableScalar x = vs.Scalar[varname];
                                    x.Value = response;
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
                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarsetjson",
                                    "{1}Scalar variable ({0}) value set to JSON response", varname, persist));
                            }
                            ctx.contextResponse = response;
                            ctx.contextResponseCode = responseCode;
                            if (_JsonFiringExpression != null && _JsonFiringExpression.Trim().Length > 0)
                            {
                                string firing = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _JsonFiringExpression);
                                if (firing.Length > 0)
                                {
                                    plug.LogLineQueuer(firing, "", LogEvent.SourceEnum.Log);
                                }
                            }
                        }
                        break;
                    #endregion
                    #region Implementation - Keypress
                    case ActionTypeEnum.KeyPress:
                        {
                            switch (_KeypressType)
                            {
                                case KeypressTypeEnum.SendKeys:
                                    {
                                        string ks = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _KeyPressExpression);
                                        SendKeys.SendWait(ks);
                                    }
                                    break;
                                case KeypressTypeEnum.WindowMessage:
                                    {
                                        int procid = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _KeyPressProcId);
                                        string window = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _KeyPressWindow);
                                        int keycode = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _KeyPressCode);
                                        WindowsUtils.SendKeycode(procid, window, keycode);
                                    }
                                    break;
                                case KeypressTypeEnum.WindowMessageCombo:
                                    {
                                        int procid = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _KeyPressProcId);
                                        string window = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _KeyPressWindow);
                                        int[] keycodes = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _KeyPressCode)
                                            .Split(',').Select(kx => Convert.ToInt32(kx.Trim())).ToArray();
                                        WindowsUtils.SendKeycodes(procid, window, keycodes);
                                    }
                                    break;
                            }
                        }
                        break;
                    #endregion
                    #region Implementation - Launch process
                    case ActionTypeEnum.LaunchProcess:
                        {
                            System.Diagnostics.Process p = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
                            psi.Arguments = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _LaunchProcessCmdlineExpression);
                            psi.WindowStyle = _LaunchProcessWindowStyle;
                            psi.WorkingDirectory = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _LaunchProcessWorkingDirExpression);
                            psi.FileName = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _LaunchProcessPathExpression);
                            p.StartInfo = psi;
                            p.Start();
                            if (_Asynchronous == false)
                            {
                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/waitingprocexit", "Waiting for process to exit"));
                                p.WaitForExit();
                            }
                        }
                        break;
                    #endregion
                    #region Implementation - List variable
                    case ActionTypeEnum.ListVariable:
                        {
                            string sourcename = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _ListVariableName);
                            VariableStore svs = (_ListSourcePersist) ? plug.cfg.PersistentVariables : plug.sessionvars;
                            VariableStore tvs = (_ListTargetPersist) ? plug.cfg.PersistentVariables : plug.sessionvars;
                            string sPersist = I18n.TrlVarPersist(_ListSourcePersist);
                            string tPersist = I18n.TrlVarPersist(_ListTargetPersist);
                            string changer;
                            if (ctx.trig != null)
                            {
                                changer = I18n.Translate("internal/Action/changetagtrigaction", "Trigger '{0}' action '{1}'", ctx.trig.LogName, GetDescription(ctx));
                            }
                            else
                            {
                                changer = I18n.Translate("internal/Action/changetagtestmode", "Action '{0}' test mode", GetDescription(ctx));
                            }
                            switch (_ListVariableOp)
                            {
                                case ListVariableOpEnum.Unset:
                                    {
                                        lock (svs.List) // verified
                                        {
                                            svs.List.Remove(sourcename);
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listunset",
                                            "{1}List variable ({0}) unset", sourcename, sPersist));
                                    }
                                    break;
                                case ListVariableOpEnum.Push:
                                    {
                                        string value = GetListExpressionValue(ctx, _ListVariableExpressionType, _ListVariableExpression);
                                        lock (svs.List)
                                        {
                                            VariableList vl = GetListVariable(svs, sourcename, true);
                                            vl.Push(new VariableScalar() { Value = value }, changer);
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listpush",
                                            "Value ({0}) pushed to the end of {2}list variable ({1})",
                                            value, sourcename, sPersist));
                                    }
                                    break;
                                case ListVariableOpEnum.Insert:
                                    {
                                        string value = GetListExpressionValue(ctx, _ListVariableExpressionType, _ListVariableExpression);
                                        int index = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _ListVariableIndex);
                                        lock (svs.List)
                                        {
                                            VariableList vl = GetListVariable(svs, sourcename, true);
                                            vl.Insert(index, value, changer);
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listindexinsert",
                                            "Value ({0}) inserted to index ({1}) of {3}list variable ({2})",
                                            value, index, sourcename, sPersist));
                                    }
                                    break;
                                case ListVariableOpEnum.Set:
                                    {
                                        string[] invalidExprs = new[] { "${_row", "${_col", "${_key}", "${_val}" };
                                        CheckInvalidDymanicExpr(_TableVariableExpression, invalidExprs);

                                        string value = GetListExpressionValue(ctx, _ListVariableExpressionType, _ListVariableExpression);
                                        int index = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _ListVariableIndex);
                                        lock (svs.List)
                                        {
                                            VariableList vl = GetListVariable(svs, sourcename, true);
                                            ctx.varName = (_ListSourcePersist ? "plvar:" : "lvar:") + sourcename;   // ${_this}
                                            ctx.listIndex = index;  // ${_idx}
                                            vl.Set(index, value, changer);
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listindexset",
                                            "Value ({0}) set to index ({1}) of {3}list variable ({2})",
                                            value, index, sourcename, sPersist));
                                    }
                                    break;
                                case ListVariableOpEnum.SetAll:
                                    {
                                        string[] invalidExprs = new[] { "${_row", "${_col", "${_key}", "${_val}" };
                                        CheckInvalidDymanicExpr(_ListVariableExpression, invalidExprs);
                                        int newLength = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _ListVariableIndex);
                                        // create a new list to avoid setting values base on previously edited ones
                                        VariableList vlNew = new VariableList();
                                        lock (svs.List)
                                        {
                                            VariableList vl = GetListVariable(svs, sourcename, false);
                                            newLength = (newLength <= 0) ? vl.Size : newLength;
                                            ctx.varName = (_ListSourcePersist ? "plvar:" : "lvar:") + sourcename;   // ${_this}
                                            for (int i = 1; i <= newLength; i++)   // index starts from 1
                                            {
                                                ctx.listIndex = i;  // ${_idx}
                                                string expr = GetListExpressionValue(ctx, _ListVariableExpressionType, _ListVariableExpression);
                                                vlNew.Push(new VariableScalar() { Value = expr }, changer);
                                            }
                                            svs.List[sourcename] = vlNew;
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listsetall",
                                            "All values in {1}list variable ({0}) set to ({2})",
                                            sourcename, sPersist, _ListVariableExpression));
                                    }
                                    break;
                                case ListVariableOpEnum.Remove:
                                    {
                                        int index = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _ListVariableIndex);
                                        lock (svs.List)
                                        {
                                            VariableList vl = GetListVariable(svs, sourcename, false);
                                            vl.Remove(index, changer);
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listindexunset",
                                            "Value removed from index ({0}) of {2}list variable ({1})",
                                            index, sourcename, sPersist));
                                    }
                                    break;
                                case ListVariableOpEnum.PopFirst:
                                    {
                                        string targetname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _ListVariableTarget);
                                        int rawIndex = (string.IsNullOrWhiteSpace(_ListVariableIndex)) ? 1 : (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _ListVariableIndex);

                                        string newval = "";
                                        lock (svs.List)
                                        {
                                            VariableList vl = GetListVariable(svs, sourcename, false);
                                            newval = vl.Pop(rawIndex, changer).ToString();
                                        }
                                        VariableScalar x = new VariableScalar();
                                        x.Value = newval;
                                        x.LastChanger = changer;
                                        x.LastChanged = DateTime.Now;
                                        lock (tvs.Scalar) // verified
                                        {
                                            tvs.Scalar[targetname] = x;
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listpop",
                                            "Value ({4}) popped from index ({5}) of {1}list ({0}) into {3}scalar variable ({2})",
                                            sourcename, sPersist, targetname, tPersist, newval, rawIndex));
                                    }
                                    break;
                                case ListVariableOpEnum.PopToListInsert:
                                case ListVariableOpEnum.PopToListSet:
                                    {
                                        string targetname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _ListVariableTarget);
                                        bool isInsert = (_ListVariableOp == ListVariableOpEnum.PopToListInsert);
                                        bool popToEnd = isInsert && string.IsNullOrWhiteSpace(_ListVariableExpression);

                                        int rawSourceIndex = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _ListVariableIndex);
                                        int rawTargetIndex = 0;
                                        if (!popToEnd)
                                        {
                                            rawTargetIndex = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _ListVariableExpression);
                                        }

                                        VariableScalar popped;
                                        lock (svs.List)
                                        {
                                            VariableList svl = GetListVariable(svs, sourcename, false);
                                            popped = (VariableScalar)svl.Pop(rawSourceIndex, changer);
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listpoptolist",
                                                "pop value ({3}) from {1}list variable ({0}) index ({2})",
                                                sourcename, sPersist, rawSourceIndex, targetname, tPersist));
                                        }
                                        lock (tvs.List)
                                        {
                                            VariableList tvl = GetListVariable(tvs, targetname, true);
                                            if (popToEnd)
                                            {
                                                tvl.Values.Add(popped);
                                                tvl.LastChanged = DateTime.Now;
                                                tvl.LastChanger = changer;
                                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listindexset",
                                                    "Value ({0}) set to index ({1}) of {3}list variable ({2})",
                                                    popped.Value, tvl.Size, targetname, tPersist));
                                            }
                                            else if (isInsert)
                                            {
                                                tvl.Insert(rawTargetIndex, popped, changer);
                                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listindexinsert",
                                                    "Value ({0}) inserted to index ({1}) of {3}list variable ({2})",
                                                    popped.Value, rawTargetIndex, targetname, tPersist));
                                            }
                                            else
                                            {
                                                tvl.Set(rawTargetIndex, popped, changer);
                                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listindexset",
                                                    "Value ({0}) set to index ({1}) of {3}list variable ({2})",
                                                    popped.Value, rawTargetIndex, targetname, tPersist));
                                            }
                                        }
                                    }
                                    break;
                                case ListVariableOpEnum.SortAlphaAsc:
                                    {
                                        string order = I18n.TrlSortAscOrDesc(true);
                                        lock (svs.List)
                                        {
                                            VariableList vl = GetListVariable(svs, sourcename, false);
                                            vl.SortAlphaAsc(changer);
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listsortstr",
                                            "{1}List variable ({0}) sorted in alphabetically {2} order", sourcename, sPersist, order));
                                    }
                                    break;
                                case ListVariableOpEnum.SortAlphaDesc:
                                    {
                                        string order = I18n.TrlSortAscOrDesc(false);
                                        lock (svs.List)
                                        {
                                            VariableList vl = GetListVariable(svs, sourcename, false);
                                            vl.SortAlphaDesc(changer);
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listsortstr",
                                            "{1}List variable ({0}) sorted in alphabetically {2} order", sourcename, sPersist, order));
                                    }
                                    break;
                                case ListVariableOpEnum.SortNumericAsc:
                                    {
                                        string order = I18n.TrlSortAscOrDesc(true);
                                        lock (svs.List)
                                        {
                                            VariableList vl = GetListVariable(svs, sourcename, false);
                                            vl.SortNumericAsc(changer);
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listsortnum",
                                            "{1}List variable ({0}) sorted in numerically {2} order", sourcename, sPersist, order));
                                    }
                                    break;
                                case ListVariableOpEnum.SortNumericDesc:
                                    {
                                        string order = I18n.TrlSortAscOrDesc(false);
                                        lock (svs.List)
                                        {
                                            VariableList vl = GetListVariable(svs, sourcename, false);
                                            vl.SortNumericDesc(changer);
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listsortnum",
                                            "{1}List variable ({0}) sorted in numerically {2} order", sourcename, sPersist, order));
                                    }
                                    break;
                                case ListVariableOpEnum.SortFfxivPartyAsc:
                                    {
                                        string order = I18n.TrlSortAscOrDesc(true);
                                        lock (svs.List)
                                        {
                                            VariableList vl = GetListVariable(svs, sourcename, false);
                                            vl.SortFfxivPartyAsc(plug.cfg, changer);
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listsortffxiv",
                                            "{1}List variable ({0}) sorted in FFXIV party {2} order", sourcename, sPersist, order));
                                    }
                                    break;
                                case ListVariableOpEnum.SortFfxivPartyDesc:
                                    {
                                        string order = I18n.TrlSortAscOrDesc(false);
                                        lock (svs.List)
                                        {
                                            VariableList vl = GetListVariable(svs, sourcename, false);
                                            vl.SortFfxivPartyDesc(plug.cfg, changer);
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listsortffxiv",
                                            "{1}List variable ({0}) sorted in FFXIV party {2} order", sourcename, sPersist, order));
                                    }
                                    break;
                                case ListVariableOpEnum.SortByKeys:
                                    {
                                        string[] invalidExprs = new[] { "${_row", "${_col", "${_key}", "${_val}" };
                                        CheckInvalidDymanicExpr(_ListVariableExpression, invalidExprs);

                                        // parsing expressions like "n+:key1, s-:key2, s+:key3, ..."
                                        ParseSortKeyFunctions(_ListVariableExpression,
                                            out List<bool> isNumeric, out List<bool> isAscending,
                                            out List<string> keysExpr, out List<List<string>> values);
                                        int keysCount = keysExpr.Count;

                                        lock (svs.List)
                                        {
                                            VariableList vl = GetListVariable(svs, sourcename, false);
                                            ctx.varName = (_ListSourcePersist ? "plvar:" : "lvar:") + _ListVariableName;    // for ${_this}
                                            // Iterate through the list and evaluate the key expression in the current context
                                            for (int listIndex = 0; listIndex < vl.Size; listIndex++)
                                            {
                                                ctx.listIndex = listIndex + 1;  // for ${_idx}
                                                for (int keyIndex = 0; keyIndex < keysCount; keyIndex++)
                                                {
                                                    string keyValue = isNumeric[keyIndex]
                                                        ? I18n.ThingToString(ctx.EvaluateNumericExpression(ActionContextLogger, ctx, keysExpr[keyIndex]))
                                                        : ctx.EvaluateStringExpression(ActionContextLogger, ctx, keysExpr[keyIndex]);
                                                    values[keyIndex].Add(keyValue);
                                                }
                                            }
                                            IOrderedEnumerable<int> sortedIndices = ApplySorting(vl.Size, isNumeric, isAscending, values);
                                            var sortedList = sortedIndices.Select(i => vl.Values[i]).ToList();
                                            vl.Values = sortedList;
                                            vl.LastChanger = changer;
                                            vl.LastChanged = DateTime.Now;
                                        }

                                        for (int i = 0; i < keysCount; i++)
                                        {   // logging each sorting keys
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listsortbykeys",
                                                "Sorting {1}list ({0}): function ({2}/{3}, {5}) = ({4}). Keys: ({6})",
                                                sourcename, sPersist, i + 1, keysCount, keysExpr[i],
                                                (isNumeric[i] ? "n" : "s") + (isAscending[i] ? "+" : "-"),
                                                String.Join(", ", values[i])));
                                        }
                                    }
                                    break;
                                case ListVariableOpEnum.Copy:
                                    {
                                        string targetname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _ListVariableTarget);
                                        VariableList vl = null;
                                        lock (svs.List)
                                        {
                                            vl = GetListVariable(svs, sourcename, false);
                                        }
                                        lock (tvs.List)
                                        {
                                            VariableList newvl = new VariableList();
                                            foreach (Variable x in vl.Values)
                                            {
                                                newvl.Push(x.Duplicate(), changer);
                                            }
                                            tvs.List[targetname] = newvl;
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listcopy",
                                            "{2}List variable ({0}) copied to {3}list variable ({1})",
                                            sourcename, targetname, sPersist, tPersist));
                                    }
                                    break;
                                case ListVariableOpEnum.InsertList:
                                    {
                                        string targetname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _ListVariableTarget);
                                        int rawIndex = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _ListVariableIndex);
                                        VariableList vl = null;
                                        VariableList vlcopy = null;
                                        lock (svs.List)
                                        {
                                            vl = GetListVariable(svs, sourcename, false);
                                            if (svs == tvs)
                                            {
                                                VariableList newvl = GetListVariable(tvs, targetname, true);
                                                newvl.InsertList(rawIndex, vl, changer);
                                            }
                                            else
                                            {
                                                vlcopy = (VariableList)vl.Duplicate();
                                            }
                                        }
                                        if (svs != tvs)
                                        {
                                            lock (tvs.List)
                                            {
                                                VariableList newvl = GetListVariable(tvs, targetname, true);
                                                newvl.InsertList(rawIndex, vlcopy, changer);
                                            }
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listinsertlist",
                                            "{3}List variable ({0}) inserted to {4}list variable ({1}) at index ({2})",
                                            sourcename, targetname, rawIndex, sPersist, tPersist));
                                    }
                                    break;
                                case ListVariableOpEnum.Filter:
                                    {
                                        string[] invalidExprs = new[] { "${_row", "${_col", "${_key}", "${_val}" };
                                        CheckInvalidDymanicExpr(_ListVariableExpression, invalidExprs);
                                        string targetname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _ListVariableTarget);
                                        VariableList vlResult = new VariableList();
                                        lock (svs.List)
                                        {
                                            VariableList vl = GetListVariable(svs, sourcename, false);
                                            ctx.varName = (_ListSourcePersist ? "plvar:" : "lvar:") + _ListVariableName;    // for ${_this}
                                            for (int i = 0; i < vl.Size; i++)
                                            {
                                                ctx.listIndex = i + 1;  // for ${_idx}
                                                double result = ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _ListVariableExpression);
                                                if (!MathParser.IsZero(result))
                                                {
                                                    vlResult.Values.Add(vl.Values[i].Duplicate());
                                                }
                                            }
                                        }
                                        vlResult.LastChanger = changer;
                                        vlResult.LastChanged = DateTime.Now;
                                        lock (tvs.List)
                                        {
                                            tvs.List[targetname] = vlResult;
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listfilter",
                                                "Filtered {4} elements from {1}list ({0}) into {3}list ({2})",
                                                sourcename, sPersist, targetname, tPersist, vlResult.Size));
                                        }
                                    }
                                    break;
                                case ListVariableOpEnum.Join:
                                    {
                                        string separator = GetListExpressionValue(ctx, _ListVariableExpressionType, _ListVariableExpression);
                                        string targetname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _ListVariableTarget);
                                        string newval = "";
                                        lock (svs.List)
                                        {
                                            VariableList vl = GetListVariable(svs, sourcename, false);
                                            newval = vl.Join(separator);
                                        }
                                        VariableScalar x = new VariableScalar
                                        {
                                            Value = newval,
                                            LastChanger = changer,
                                            LastChanged = DateTime.Now
                                        };
                                        lock (tvs.Scalar) // verified
                                        {
                                            tvs.Scalar[targetname] = x;
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listscalarjoin",
                                            "{3}List variable ({0}) joined to {4}scalar variable ({1}) with separator ({2})",
                                            sourcename, targetname, separator, sPersist, tPersist));
                                    }
                                    break;
                                case ListVariableOpEnum.Split:
                                    {
                                        string separator = GetListExpressionValue(ctx, _ListVariableExpressionType, _ListVariableExpression);
                                        string targetname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _ListVariableTarget);
                                        string splitval = "";
                                        lock (svs.Scalar) // verified
                                        {
                                            if (svs.Scalar.ContainsKey(sourcename))
                                            {
                                                splitval = svs.Scalar[sourcename].Value;
                                            }
                                        }
                                        string[] vals = splitval.Split(new string[] { separator }, StringSplitOptions.None);

                                        VariableList vl = new VariableList();
                                        foreach (string x in vals)
                                        {
                                            vl.Push(new VariableScalar() { Value = x }, changer);
                                        }
                                        lock (tvs.List)
                                        {
                                            tvs.List[targetname] = vl;
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listsplit",
                                            "{3}Scalar variable ({0}) split into {4}list variable ({1}) with separator ({2})",
                                            sourcename, targetname, separator, sPersist, tPersist));
                                    }
                                    break;
                                case ListVariableOpEnum.Build:
                                    {   // Using the first character in the expression to split the remaining part into a new list
                                        // e.g. expr = ",1,2,3,4,5,6,7,8"
                                        string expr = GetListExpressionValue(ctx, _ListVariableExpressionType, _ListVariableExpression);
                                        string targetname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _ListVariableTarget);
                                        VariableList vl = new VariableList();
                                        if (expr.Length > 0)
                                        {
                                            if (expr[0] == '\n' || expr.StartsWith("\r\n"))
                                                expr = Context.ReplaceLineBreak(expr);
                                            char separator = expr[0];
                                            string splitval = expr.Substring(1);
                                            vl = VariableList.Build(splitval, separator, changer);
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listbuild",
                                                "{1}List variable ({0}) built from expression ({2}) splitted by ({3})",
                                                targetname, tPersist, splitval, separator));
                                        }
                                        else
                                        {
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/listbuildfail",
                                                "{1}List variable ({0}) cannot be built because expression ({2}) length < 1",
                                                targetname, tPersist, expr));
                                        }

                                        lock (tvs.List)
                                        {
                                            tvs.List[targetname] = vl;
                                        }
                                    }
                                    break;
                                case ListVariableOpEnum.UnsetAll:
                                    {
                                        lock (svs.List) // verified
                                        {
                                            svs.List.Clear();
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listunsetall",
                                            "All {0}list variables unset", sPersist));
                                    }
                                    break;
                                case ListVariableOpEnum.UnsetRegex:
                                    {
                                        Regex rx = new Regex(_ListVariableName);
                                        VariablesUnsetRegex(svs.List, rx);
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listunsetregex",
                                            "All {1}list variables matching ({0}) unset", _ListVariableName, sPersist));
                                        break;
                                    }
                            }
                        }
                        break;
                    #endregion
                    #region Implementation - Log message
                    case ActionTypeEnum.LogMessage:
                        {
                            string message = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _LogMessageText);

                            if (_LogProcess)
                            {
                                string zone = ctx.EvaluateStringExpression(ActionContextLogger, ctx, plug.currentZone);
                                plug.LogLineQueuer(message, zone, _LogMessageTarget);
                            }
                            else
                            {
                                RealPlugin.DebugLevelEnum debugLevel = RealPlugin.DebugLevelEnum.Error;
                                switch (_LogLevel)
                                {
                                    case LogMessageEnum.Custom: debugLevel = RealPlugin.DebugLevelEnum.Custom; break;
                                    case LogMessageEnum.Custom2: debugLevel = RealPlugin.DebugLevelEnum.Custom2; break;
                                    case LogMessageEnum.Error: debugLevel = RealPlugin.DebugLevelEnum.Error; break;
                                    case LogMessageEnum.Info: debugLevel = RealPlugin.DebugLevelEnum.Info; break;
                                    case LogMessageEnum.Verbose: debugLevel = RealPlugin.DebugLevelEnum.Verbose; break;
                                    case LogMessageEnum.Warning: debugLevel = RealPlugin.DebugLevelEnum.Warning; break;
                                }
                                AddToLog(ctx, debugLevel, message);
                            }
                            if (_LogProcessACT)
                            {
                                plug.ACTEncounterLogHook(message);
                            }
                        }
                        break;
                    #endregion
                    #region Implementation - Message box
                    case ActionTypeEnum.MessageBox:
                        {
                            Form activeForm = Form.ActiveForm;
                            if (activeForm != null)
                            {
                                MessageBox.Show(activeForm, ctx.EvaluateStringExpression(ActionContextLogger, ctx, _MessageBoxText), "", MessageBoxButtons.OK, (System.Windows.Forms.MessageBoxIcon)_MessageBoxIconType);
                            }
                            else
                            {
                                MessageBox.Show(ctx.EvaluateStringExpression(ActionContextLogger, ctx, _MessageBoxText), "", MessageBoxButtons.OK, (System.Windows.Forms.MessageBoxIcon)_MessageBoxIconType);
                            }
                        }
                        break;
                    #endregion
                    #region Implementation - Mutex
                    case ActionTypeEnum.Mutex:
                        {
                            string mn = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _MutexName);
                            switch (_MutexOpType)
                            {
                                case MutexOpEnum.Acquire:
                                    {
                                        RealPlugin.MutexInformation mi = plug.GetMutex(mn);
                                        mi.Acquire(ctx);
                                    }
                                    break;
                                case MutexOpEnum.Release:
                                    {
                                        RealPlugin.MutexInformation mi = plug.GetMutex(mn);
                                        mi.Release(ctx);
                                    }
                                    break;
                            }
                        }
                        break;
                    #endregion
                    #region Implementation - OBS
                    case ActionTypeEnum.ObsControl:
                        ObsController obsController = plug._obs;
                        if (obsController != null)
                        {
                            string endpoint = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _OBSEndPoint);
                            string password = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _OBSPassword);
                            lock (obsController)
                            {
                                if (ObsConnector(ctx, endpoint, password) != true)
                                    return; // already complaint about errors
                                try
                                {
                                    switch (_OBSControlType)
                                    {
                                        case ObsControlTypeEnum.StartStreaming:
                                            obsController.StartStreaming();
                                            break;
                                        case ObsControlTypeEnum.StopStreaming:
                                            obsController.StopStreaming();
                                            break;
                                        case ObsControlTypeEnum.ToggleStreaming:
                                            obsController.ToggleStreaming();
                                            break;
                                        case ObsControlTypeEnum.StartRecording:
                                            obsController.StartRecording();
                                            break;
                                        case ObsControlTypeEnum.StopRecording:
                                            obsController.StopRecording();
                                            break;
                                        case ObsControlTypeEnum.ToggleRecording:
                                            obsController.ToggleRecording();
                                            break;
                                        case ObsControlTypeEnum.RestartRecording:
                                            obsController.RestartRecording();
                                            break;
                                        case ObsControlTypeEnum.RestartRecordingIfActive:
                                            obsController.RestartRecordingIfActive();
                                            break;
                                        case ObsControlTypeEnum.ResumeRecording:
                                            obsController.ResumeRecording();
                                            break;
                                        case ObsControlTypeEnum.PauseRecording:
                                            obsController.PauseRecording();
                                            break;
                                        case ObsControlTypeEnum.ToggleRecordPause:
                                            obsController.ToggleRecordPause();
                                            break;
                                        case ObsControlTypeEnum.StartReplayBuffer:
                                            obsController.StartReplayBuffer();
                                            break;
                                        case ObsControlTypeEnum.StopReplayBuffer:
                                            obsController.StopReplayBuffer();
                                            break;
                                        case ObsControlTypeEnum.ToggleReplayBuffer:
                                            obsController.ToggleReplayBuffer();
                                            break;
                                        case ObsControlTypeEnum.SaveReplayBuffer:
                                            obsController.SaveReplayBuffer();
                                            break;
                                        case ObsControlTypeEnum.SetScene:
                                            {
                                                string scn = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _OBSSceneName);
                                                obsController.SetCurrentScene(scn);
                                            }
                                            break;
                                        case ObsControlTypeEnum.ShowSource:
                                            {
                                                string scn = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _OBSSceneName);
                                                string src = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _OBSSourceName);
                                                obsController.ShowHideSource(scn, src, true);
                                            }
                                            break;
                                        case ObsControlTypeEnum.HideSource:
                                            {
                                                string scn = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _OBSSceneName);
                                                string src = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _OBSSourceName);
                                                obsController.ShowHideSource(scn, src, false);
                                            }
                                            break;
                                        case ObsControlTypeEnum.JSONPayload:
                                            {
                                                string json = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _OBSJSONPayload);
                                                obsController.JSONPayload(json);
                                            }
                                            break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/obscontrolexception", "Can't execute OBS control action due to exception: {0}" + ex.Message));
                                }
                            }
                        }
                        break;
                    #endregion
                    #region Implementation - LiveSplit
                    case ActionTypeEnum.LiveSplitControl:
                        LiveSplitController livesplitController = plug._livesplit;
                        if (livesplitController != null)
                        {
                            lock (livesplitController)
                            {
                                if (LiveSplitConnector(ctx) == true)
                                {
                                    try
                                    {
                                        switch (_LSControlType)
                                        {
                                            case LiveSplitControlTypeEnum.StartOrSplit:
                                                livesplitController.StartOrSplit();
                                                break;
                                            case LiveSplitControlTypeEnum.Start:
                                                livesplitController.Start();
                                                break;
                                            case LiveSplitControlTypeEnum.Split:
                                                livesplitController.Split();
                                                break;
                                            case LiveSplitControlTypeEnum.UndoSplit:
                                                livesplitController.UndoSplit();
                                                break;
                                            case LiveSplitControlTypeEnum.SkipSplit:
                                                livesplitController.SkipSplit();
                                                break;
                                            case LiveSplitControlTypeEnum.Reset:
                                                livesplitController.Reset();
                                                break;
                                            case LiveSplitControlTypeEnum.Pause:
                                                livesplitController.Pause();
                                                break;
                                            case LiveSplitControlTypeEnum.Resume:
                                                livesplitController.Resume();
                                                break;
                                            case LiveSplitControlTypeEnum.CustomPayload:
                                                string lscommand = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _LSCustomPayload);
                                                livesplitController.SendCommand(lscommand);
                                                break;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/lscontrolexception", "Can't execute LiveSplit control action due to exception: " + ex.Message));
                                    }
                                }
                                else
                                {
                                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/lscontrolerror", "Can't execute LiveSplit control action due to error"));
                                }
                            }
                        }
                        break;
                    #endregion
                    #region Implementation - Play sound
                    case ActionTypeEnum.PlaySound:
                        {
                            ctx.soundhook(ctx, this);
                        }
                        break;
                    #endregion
                    #region Implementation - Placeholder
                    case ActionTypeEnum.Placeholder:
                        break;
                    #endregion
                    #region Implementation - Play speech
                    case ActionTypeEnum.UseTTS:
                        {
                            ctx.ttshook(ctx, this);
                        }
                        break;
                    #endregion
                    #region Implementation - Repository
                    case ActionTypeEnum.Repository:
                        {
                            Repository r = null;
                            switch (_RepositoryOp)
                            {
                                case RepositoryOpEnum.UpdateSelf:
                                    r = ctx.trig?.Repo;
                                    break;
                                case RepositoryOpEnum.UpdateRepo:
                                    r = plug.GetRepositoryById(_RepositoryId);
                                    break;
                                case RepositoryOpEnum.UpdateAll:
                                    plug.AllRepositoryUpdates(false);
                                    break;
                            }
                            if (r != null)
                            {
                                plug.RepositoryUpdate(r, true, false);
                            }
                        }
                        break;
                    #endregion
                    #region Implementation - Scalar variable
                    case ActionTypeEnum.Variable:
                        {
                            string varname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _VariableName);
                            string sPersist = I18n.TrlVarPersist(_VariablePersist);
                            string tPersist = I18n.TrlVarPersist(_VariableTargetPersist);
                            string changer;
                            if (ctx.trig != null)
                            {
                                changer = I18n.Translate("internal/Action/changetagtrigaction", "Trigger '{0}' action '{1}'", ctx.trig.LogName, GetDescription(ctx));
                            }
                            else
                            {
                                changer = I18n.Translate("internal/Action/changetagtestmode", "Action '{0}' test mode", GetDescription(ctx));
                            }
                            string newval;
                            VariableStore vs = (_VariablePersist == false) ? plug.sessionvars : plug.cfg.PersistentVariables;
                            switch (_VariableOp)
                            {
                                case VariableOpEnum.UnsetAll:
                                    {
                                        lock (vs.Scalar) // verified
                                        {
                                            vs.Scalar.Clear();
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarunsetall",
                                            "All {0}scalar variables unset", sPersist));
                                        break;
                                    }
                                case VariableOpEnum.UnsetRegex:
                                    {
                                        Regex rx = new Regex(_VariableName);
                                        VariablesUnsetRegex(vs.Scalar, rx);
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarunsetregex",
                                            "All {1}scalar variables matching ({0}) unset", _VariableName, sPersist));
                                        break;
                                    }
                                case VariableOpEnum.UnsetRegexUniversal:
                                    {
                                        Regex rx = new Regex(_VariableName);
                                        VariablesUnsetRegex(vs.Scalar, rx);
                                        VariablesUnsetRegex(vs.List, rx);
                                        VariablesUnsetRegex(vs.Table, rx);
                                        VariablesUnsetRegex(vs.Dict, rx);
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarunsetregexuniversal",
                                            "All {1}variables matching ({0}) unset", _VariableName, sPersist));
                                        break;
                                    }
                                case VariableOpEnum.Unset:
                                    {
                                        lock (vs.Scalar) // verified
                                        {
                                            vs.Scalar.Remove(varname);
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarunset",
                                            "{1}Scalar variable ({0}) unset", varname, sPersist));
                                        break;
                                    }
                                case VariableOpEnum.SetString:
                                case VariableOpEnum.SetNumeric:
                                    {
                                        if (_VariableOp == VariableOpEnum.SetString)
                                        {
                                            newval = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _VariableExpression);
                                        }
                                        else
                                        {
                                            newval = I18n.ThingToString(ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _VariableExpression));
                                        }

                                        VariableScalar x = new VariableScalar();
                                        x.Value = newval;
                                        x.LastChanger = changer;
                                        x.LastChanged = DateTime.Now;
                                        lock (vs.Scalar) // verified
                                        {
                                            vs.Scalar[varname] = x;
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarset",
                                            "{2}Scalar variable ({0}) value set to ({1})", varname, newval, sPersist));
                                        break;
                                    }
                                case VariableOpEnum.Increment:
                                    {
                                        double original = 0;
                                        double increment = string.IsNullOrWhiteSpace(_VariableExpression)
                                            ? 1 : ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _VariableExpression);
                                        VariableScalar x = new VariableScalar { LastChanger = changer, LastChanged = DateTime.Now };
                                        lock (vs.Scalar)
                                        {
                                            if (vs.Scalar.TryGetValue(varname, out VariableScalar originalVar))
                                            {
                                                if (!string.IsNullOrWhiteSpace(originalVar.Value))
                                                {
                                                    original = ctx.EvaluateNumericExpression(ActionContextLogger, ctx, originalVar.Value);
                                                }
                                            }
                                            x.Value = I18n.ThingToString(original + increment);
                                            vs.Scalar[varname] = x;
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarset",
                                                "{2}Scalar variable ({0}) value set to ({1})", varname, x.Value, sPersist));
                                        }
                                        break;
                                    }
                                case VariableOpEnum.Clipboard:
                                    {
                                        bool isName = !string.IsNullOrWhiteSpace(_VariableName);
                                        string text = "";
                                        if (isName)
                                            lock (vs.Scalar)
                                            {
                                                text = vs.Scalar[varname].Value;
                                            }
                                        else
                                        {
                                            text = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _VariableExpression);
                                        }
                                        ClipboardSetText(text);
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarclipboard",
                                            "Set text ({0}) to clipboard", text));
                                        break;
                                    }
                                case VariableOpEnum.QueryJsonPath:
                                    {
                                        newval = "";
                                        lock (vs.Scalar) // verified
                                        {
                                            if (vs.Scalar.ContainsKey(varname) == true)
                                            {
                                                newval = vs.Scalar[varname].Value;
                                            }
                                        }
                                        string tgtname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _VariableJsonTarget);
                                        VariableStore vs2 = (_VariableTargetPersist == false) ? plug.sessionvars : plug.cfg.PersistentVariables;
                                        string query = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _VariableExpression);
                                        JsonPath.JsonPathContext pc = new JsonPath.JsonPathContext();
                                        Dictionary<string, object> p = new Parser().Parse(newval);
                                        IEnumerable<object> result = pc.Select(p, query);

                                        VariableScalar x = new VariableScalar();
                                        switch (result.Count())
                                        {
                                            case 0: x.Value = ""; break;
                                            case 1: x.Value = result.First().ToString(); break;
                                            default: x.Value = JsonSerializer.Serialize<object[]>(result.ToArray()); break;
                                        }
                                        x.LastChanger = changer;
                                        x.LastChanged = DateTime.Now;

                                        lock (vs2.Scalar) // verified
                                        {
                                            vs2.Scalar[tgtname] = x;
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarset",
                                            "{2}Scalar variable ({0}) value set to ({1})", tgtname, newval, tPersist));
                                    }
                                    break;
                                case VariableOpEnum.QueryJsonPathList:
                                    {
                                        newval = "";
                                        lock (vs.Scalar) // verified
                                        {
                                            if (vs.Scalar.ContainsKey(varname) == true)
                                            {
                                                newval = vs.Scalar[varname].Value;
                                            }
                                        }
                                        string tgtname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _VariableJsonTarget);
                                        VariableStore vs2 = (_VariableTargetPersist == false) ? plug.sessionvars : plug.cfg.PersistentVariables;
                                        string query = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _VariableExpression);
                                        JsonPath.JsonPathContext pc = new JsonPath.JsonPathContext();
                                        Dictionary<string, object> p = new Parser().Parse(newval);
                                        IEnumerable<object> result = pc.Select(p, query);

                                        VariableList x = new VariableList();
                                        x.LastChanger = changer;
                                        x.LastChanged = DateTime.Now;
                                        switch (result.Count())
                                        {
                                            case 0: break;
                                            case 1: x.Push(new VariableScalar() { Value = result.First().ToString(), LastChanged = x.LastChanged, LastChanger = changer }, changer); break;
                                            default:
                                                foreach (object o in result)
                                                {
                                                    if (o is object[])
                                                    {
                                                        x.Push(new VariableScalar() { Value = JsonSerializer.Serialize<object[]>((object[])o), LastChanged = x.LastChanged, LastChanger = changer }, changer);
                                                    }
                                                    else if (o is Dictionary<string, object>)
                                                    {
                                                        x.Push(new VariableScalar() { Value = JsonSerializer.Serialize<Dictionary<string, object>>((Dictionary<string, object>)o), LastChanged = x.LastChanged, LastChanger = changer }, changer);
                                                    }
                                                    else
                                                    {
                                                        x.Push(new VariableScalar() { Value = o.ToString(), LastChanged = x.LastChanged, LastChanger = changer }, changer);
                                                    }
                                                }
                                                break;
                                        }
                                        lock (vs2.List) // verified
                                        {
                                            vs2.List[tgtname] = x;
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listset",
                                            "{2}List variable ({0}) value set to ({1})", tgtname, newval, tPersist));
                                    }
                                    break;
                            }
                        }
                        break;
                    #endregion
                    #region Implementation - Table variable
                    case ActionTypeEnum.TableVariable:
                        {
                            string sourcename = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _TableVariableName);
                            string targetname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _TableVariableTarget);
                            VariableStore svs = (_TableSourcePersist == false) ? plug.sessionvars : plug.cfg.PersistentVariables;
                            VariableStore tvs = (_TableTargetPersist == false) ? plug.sessionvars : plug.cfg.PersistentVariables;
                            string sPersist = I18n.TrlVarPersist(_TableSourcePersist);
                            string tPersist = I18n.TrlVarPersist(_TableTargetPersist);
                            string expr;
                            string ParseExpr()
                            {
                                if (_TableVariableExpressionType == TableVariableExpTypeEnum.String)
                                    return ctx.EvaluateStringExpression(ActionContextLogger, ctx, _TableVariableExpression);
                                else
                                    return I18n.ThingToString(ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _TableVariableExpression));
                            }

                            string vtchanger;
                            if (ctx.trig != null)
                            {
                                vtchanger = I18n.Translate("internal/Action/changetagtrigaction", "Trigger '{0}' action '{1}'", ctx.trig.LogName, GetDescription(ctx));
                            }
                            else
                            {
                                vtchanger = I18n.Translate("internal/Action/changetagtestmode", "Action '{0}' test mode", GetDescription(ctx));
                            }

                            switch (_TableVariableOp)
                            {
                                case TableVariableOpEnum.UnsetAll:
                                    {
                                        lock (svs.Table) // verified
                                        {
                                            svs.Table.Clear();
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tableunsetall",
                                            "All {0}table variables unset", sPersist));
                                        break;
                                    }
                                case TableVariableOpEnum.UnsetRegex:
                                    {
                                        Regex rx = new Regex(_TableVariableName);
                                        VariablesUnsetRegex(svs.Table, rx);
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tableunsetregex",
                                            "All {1}table variables matching ({0}) unset", _TableVariableName, sPersist));
                                        break;
                                    }
                                case TableVariableOpEnum.Resize:
                                    {
                                        int w = string.IsNullOrWhiteSpace(_TableVariableX) ? int.MinValue : (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _TableVariableX);
                                        int h = string.IsNullOrWhiteSpace(_TableVariableY) ? int.MinValue : (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _TableVariableY);
                                        lock (svs.Table) // verified
                                        {
                                            VariableTable vt = GetTableVariable(svs, sourcename, createNew: true);
                                            w = (w == int.MinValue) ? vt.Width : w;
                                            h = (h == int.MinValue) ? vt.Height : h;
                                            vt.Resize(w, h, vtchanger);
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tableresize",
                                            "{3}Table variable ({0}) resized to ({1},{2})", sourcename, w, h, sPersist));
                                        break;
                                    }
                                case TableVariableOpEnum.Unset:
                                    {
                                        lock (svs.Table) // verified
                                        {
                                            svs.Table.Remove(sourcename);
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tableunset",
                                            "{1}Table variable ({0}) unset", sourcename, sPersist));
                                        break;
                                    }
                                case TableVariableOpEnum.Copy:
                                    {
                                        VariableTable vt = null;
                                        lock (svs.Table) // verified
                                        {
                                            if (svs.Table.ContainsKey(sourcename) == true)
                                            {
                                                vt = (VariableTable)svs.Table[sourcename].Duplicate();
                                                vt.LastChanged = DateTime.Now;
                                                vt.LastChanger = vtchanger;
                                            }
                                        }
                                        if (vt != null)
                                        {
                                            lock (tvs.Table)
                                            {
                                                tvs.Table[targetname] = vt;
                                            }
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tablecopy",
                                                "{2}Table ({0}) copied to {3}table ({1})",
                                                sourcename, targetname, sPersist, tPersist));
                                        }
                                        else
                                        {
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/tablecopynotexist",
                                                "{2}Table variable ({0}) couldn't be copied to {3}table ({1}) since it doesn't exist",
                                                sourcename, targetname, sPersist, tPersist));
                                        }
                                        break;
                                    }
                                case TableVariableOpEnum.Append:
                                case TableVariableOpEnum.AppendH:
                                    {
                                        VariableTable tableToAppend;
                                        lock (svs.Table) // verified
                                        {
                                            tableToAppend = svs.Table.TryGetValue(sourcename, out VariableTable svt)
                                                ? (VariableTable)svt.Duplicate()
                                                : new VariableTable();
                                        }
                                        lock (tvs.Table)
                                        {
                                            if (!tvs.Table.ContainsKey(targetname))
                                            {
                                                tvs.Table.Add(targetname, new VariableTable());
                                            }
                                            VariableTable tvt = tvs.Table[targetname];
                                            if (_TableVariableOp == TableVariableOpEnum.Append)
                                            {
                                                tvt.AppendVertical(tableToAppend, vtchanger);
                                            }
                                            else
                                            {
                                                tvt.AppendHorizontal(tableToAppend, vtchanger);
                                            }
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tableappend",
                                            "{2}Table variable ({0}) appended to {3} table ({1})",
                                            sourcename, targetname, sPersist, tPersist));
                                        break;
                                    }
                                case TableVariableOpEnum.Set:
                                    {
                                        string[] invalidExprs = new[] { "${_idx}", "${_key}", "${_val}" };
                                        CheckInvalidDymanicExpr(_TableVariableExpression, invalidExprs);

                                        int x = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _TableVariableX);
                                        int y = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _TableVariableY);

                                        lock (svs.Table) // verified
                                        {
                                            VariableTable vt = GetTableVariable(svs, sourcename, true);
                                            int mx = Math.Max(x, vt.Width);
                                            int my = Math.Max(y, vt.Height);
                                            if (mx != vt.Width || my != vt.Height)
                                            {
                                                vt.Resize(mx, my);
                                            }
                                            ctx.varName = (_TableSourcePersist ? "ptvar:" : "tvar:") + _TableVariableName;
                                            ctx.tableColIndex = x;          // for ${_row}
                                            ctx.tableRowIndex = y;          // for ${_col}
                                            expr = ParseExpr();
                                            vt.Set(x, y, expr, vtchanger);
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tableset",
                                            "{4}Table variable ({0}) column ({1}) row ({2}) set to ({3})",
                                            sourcename, x, y, expr, sPersist));
                                        break;
                                    }
                                case TableVariableOpEnum.SetAll:
                                    {
                                        string[] invalidExprs = new[] { "${_idx}", "${_key}", "${_val}" };
                                        CheckInvalidDymanicExpr(_TableVariableExpression, invalidExprs);
                                        int newWidth = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _TableVariableX);
                                        int newHeight = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _TableVariableY);
                                        VariableTable vtNew = new VariableTable { LastChanger = vtchanger, LastChanged = DateTime.Now };
                                        lock (svs.Table)
                                        {
                                            VariableTable vt = GetTableVariable(svs, sourcename, false);
                                            newWidth = (newWidth <= 0) ? vt.Width : newWidth;
                                            newHeight = (newHeight <= 0) ? vt.Height : newHeight;
                                            ctx.varName = (_TableSourcePersist ? "ptvar:" : "tvar:") + _TableVariableName;
                                            for (int y = 1; y <= newHeight; y++)     // x/y index starts from 1
                                            {
                                                ctx.tableRowIndex = y;          // for ${_row}
                                                vtNew.Rows.Add(new VariableTable.VariableTableRow());
                                                for (int x = 1; x <= newWidth; x++)
                                                {
                                                    ctx.tableColIndex = x;      // for ${_col}
                                                    expr = ParseExpr();         // evaluate the expression for every grid
                                                    vtNew.Rows[y - 1].Values.Add(new VariableScalar() { Value = expr, LastChanger = vtchanger, LastChanged = DateTime.Now });
                                                }
                                            }
                                            svs.Table[sourcename] = vtNew;
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tablesetall",
                                            "All values in {1}table variable ({0}) set to ({2})",
                                            sourcename, sPersist, _TableVariableExpression));
                                    }
                                    break;
                                case TableVariableOpEnum.SlicesSetAll:
                                    {
                                        string[] invalidExprs = new[] { "${_idx}", "${_key}", "${_val}" };
                                        CheckInvalidDymanicExpr(_TableVariableExpression, invalidExprs);
                                        string colSlicesStr = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _TableVariableX);
                                        string rowSlicesStr = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _TableVariableY);
                                        VariableTable vtNew;
                                        lock (svs.Table)
                                        {
                                            VariableTable vt = GetTableVariable(svs, sourcename, false);
                                            vtNew = (VariableTable)vt.Duplicate();
                                            // index starts from 0
                                            List<int> colIndices = Context.GetSliceIndices(colSlicesStr, vt.Width, _TableVariableX, startIndex: 1);
                                            List<int> rowIndices = Context.GetSliceIndices(rowSlicesStr, vt.Height, _TableVariableY, startIndex: 1);
                                            ctx.varName = (_TableSourcePersist ? "ptvar:" : "tvar:") + _TableVariableName;
                                            foreach (int rowIndex in rowIndices)
                                            {
                                                ctx.tableRowIndex = rowIndex + 1;       // for ${_row}
                                                foreach (int colIndex in colIndices)
                                                {
                                                    ctx.tableColIndex = colIndex + 1;   // for ${_col}
                                                    expr = ParseExpr();                 // evaluate the expression for every grid
                                                    vtNew.Rows[rowIndex].Values[colIndex] = new VariableScalar() { Value = expr, LastChanger = vtchanger, LastChanged = DateTime.Now };
                                                }
                                            }
                                            svs.Table[sourcename] = vtNew;
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tableslicessetall",
                                            "All values in column ({3}) row ({4}) of {1}table variable ({0}) set to ({2})",
                                            sourcename, sPersist, _TableVariableExpression, colSlicesStr, rowSlicesStr));
                                    }
                                    break;
                                case TableVariableOpEnum.Build:
                                    {   // Using the first 2 characters in the expression as the separator to split the remaining part into a new table
                                        // e.g. expr = ",|1,2,3|4,5,6|7,8,9"
                                        VariableTable vt = new VariableTable();
                                        expr = ParseExpr();
                                        if (expr.Length > 1)
                                        {
                                            if (expr[1] == '\n' || expr.Substring(1).StartsWith("\r\n"))
                                                expr = Context.ReplaceLineBreak(expr);
                                            char colSeparator = expr[0];
                                            char rowSeparator = expr[1];
                                            string splitval = expr.Substring(2);
                                            vt = VariableTable.Build(splitval, colSeparator, rowSeparator, vtchanger);
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tablebuild",
                                                "{1}Table variable ({0}) built from expression ({2}) splitted by ({3}) ({4})",
                                                targetname, tPersist, splitval, colSeparator, rowSeparator));
                                        }
                                        else
                                        {
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/tablebuildfail",
                                                "{1}Table variable ({0}) cannot be built since expression ({2}) length < 2",
                                                targetname, tPersist, expr));
                                        }

                                        lock (tvs.Table)
                                        {
                                            tvs.Table[targetname] = vt;
                                        }
                                    }
                                    break;
                                case TableVariableOpEnum.Filter:
                                    {
                                        VariableList vlResult = new VariableList();
                                        string[] invalidExprs = new[] { "${_idx}", "${_key}", "${_val}" };
                                        CheckInvalidDymanicExpr(_TableVariableExpression, invalidExprs);
                                        lock (svs.Table)
                                        {
                                            VariableTable vt = GetTableVariable(svs, sourcename, false);
                                            ctx.varName = (_TableSourcePersist ? "ptvar:" : "tvar:") + _TableVariableName;  // for ${_this}

                                            for (int rowIndex = 0; rowIndex < vt.Height; rowIndex++)
                                            {
                                                ctx.tableRowIndex = rowIndex + 1;       // for ${_row}
                                                for (int colIndex = 0; colIndex < vt.Width; colIndex++)
                                                {
                                                    ctx.tableColIndex = colIndex + 1;   // for ${_col}
                                                    double result = ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _TableVariableExpression);
                                                    if (!MathParser.IsZero(result))
                                                    {
                                                        vlResult.Values.Add(vt.Rows[rowIndex].Values[colIndex].Duplicate());
                                                    }
                                                }
                                            }
                                        }
                                        vlResult.LastChanger = vtchanger;
                                        vlResult.LastChanged = DateTime.Now;
                                        lock (tvs.List)
                                        {
                                            tvs.List[targetname] = vlResult;
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tablefilter",
                                                "Filtered {4} elements from {1}table ({0}) into {3}list ({2})",
                                                sourcename, sPersist, targetname, tPersist, vlResult.Size));
                                        }
                                    }
                                    break;
                                case TableVariableOpEnum.FilterLine:
                                    {
                                        bool isCol = !string.IsNullOrWhiteSpace(_TableVariableX);
                                        string rawExpr = isCol ? _TableVariableX : _TableVariableY;
                                        string[] invalidExprs = isCol
                                            ? new[] { "${_this}", "${_row", "${_idx}", "${_key}", "${_val}" }
                                            : new[] { "${_this}", "${_col", "${_idx}", "${_key}", "${_val}" };
                                        CheckInvalidDymanicExpr(rawExpr, invalidExprs);
                                        VariableTable vtResult = new VariableTable();
                                        lock (svs.Table)
                                        {
                                            VariableTable vt = GetTableVariable(svs, sourcename, false);
                                            ctx.varName = (_TableSourcePersist ? "ptvar:" : "tvar:") + _TableVariableName;  // for ${_this}
                                            if (isCol)
                                            {
                                                for (int rowIndex = 0; rowIndex < vt.Height; rowIndex++)
                                                {
                                                    vtResult.Rows.Add(new VariableTable.VariableTableRow());
                                                }
                                                for (int colIndex = 0; colIndex < vt.Width; colIndex++)
                                                {
                                                    ctx.tableColIndex = colIndex + 1;          // for ${_col}
                                                    double result = ctx.EvaluateNumericExpression(ActionContextLogger, ctx, rawExpr);
                                                    if (!MathParser.IsZero(result))
                                                    {
                                                        for (int rowIndex = 0; rowIndex < vt.Height; rowIndex++)
                                                        {
                                                            vtResult.Rows[rowIndex].Values.Add(vt.Rows[rowIndex].Values[colIndex].Duplicate());
                                                        }
                                                    }
                                                }
                                                if (vtResult.Width == 0) { vtResult.Rows.Clear(); }
                                            }
                                            else // is row
                                            {
                                                for (int rowIndex = 0; rowIndex < vt.Height; rowIndex++)
                                                {
                                                    ctx.tableRowIndex = rowIndex + 1;      // for ${_row}
                                                    double result = ctx.EvaluateNumericExpression(ActionContextLogger, ctx, rawExpr);
                                                    if (!MathParser.IsZero(result))
                                                    {
                                                        var newRow = new VariableTable.VariableTableRow();
                                                        for (int colIndex = 0; colIndex < vt.Width; colIndex++)
                                                        {
                                                            newRow.Values.Add(vt.Rows[rowIndex].Values[colIndex].Duplicate());
                                                        }
                                                        vtResult.Rows.Add(newRow);
                                                    }
                                                }
                                            }
                                        }
                                        vtResult.LastChanger = vtchanger;
                                        vtResult.LastChanged = DateTime.Now;
                                        lock (tvs.Table)
                                        {
                                            tvs.Table[targetname] = vtResult;
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tablefilterline",
                                                "Filtered {4} {5}s from {1}table ({0}) into {3}table ({2})",
                                                sourcename, sPersist, targetname, tPersist,
                                                (isCol ? vtResult.Width : vtResult.Height), I18n.TrlTableColOrRow(isCol)));
                                        }
                                    }
                                    break;
                                case TableVariableOpEnum.SetLine:
                                case TableVariableOpEnum.InsertLine:
                                    {
                                        expr = ParseExpr();
                                        string separator = (expr.Length > 0) ? expr.Substring(0, 1) : "";
                                        string splitval = (expr.Length > 0) ? expr.Substring(1) : "";
                                        string[] newValues = (separator.Length > 0) ? splitval.Split(separator[0]) : new string[0];
                                        bool isRow = string.IsNullOrWhiteSpace(_TableVariableX);
                                        string lineType = I18n.TrlTableColOrRow(!isRow);
                                        int rawIndex = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, (isRow) ? _TableVariableY : _TableVariableX);

                                        lock (svs.Table) // verified
                                        {
                                            VariableTable vt = GetTableVariable(svs, sourcename, true);
                                            int tableLength = (isRow) ? vt.Height : vt.Width;

                                            // index start from 0
                                            int index = (rawIndex < 0) ? (rawIndex + tableLength) : (rawIndex - 1);
                                            if (index < 0)
                                                break;

                                            if (_TableVariableOp == TableVariableOpEnum.SetLine)
                                            {
                                                if (isRow)
                                                    vt.SetRow(index, newValues, vtchanger);
                                                else
                                                    vt.SetColumn(index, newValues, vtchanger);

                                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tablesetline",
                                                    "{1}Table ({0}) {3} #({2}) set to ({4})",
                                                    sourcename, sPersist, index, lineType, splitval));
                                            }
                                            else // InsertLine
                                            {
                                                if (isRow)
                                                    vt.InsertRow(index, newValues, vtchanger);
                                                else
                                                    vt.InsertColumn(index, newValues, vtchanger);

                                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tableinsertline",
                                                    "Inserted ({4}) to {1}Table ({0}) {3} #({2})",
                                                    sourcename, sPersist, index, lineType, splitval));
                                            }
                                        }
                                    }
                                    break;
                                case TableVariableOpEnum.RemoveLine:
                                    {
                                        bool isRow = string.IsNullOrWhiteSpace(_TableVariableX);
                                        string lineType = I18n.TrlTableColOrRow(!isRow);

                                        lock (svs.Table) // verified
                                        {
                                            VariableTable vt = GetTableVariable(svs, sourcename, true);
                                            int tableLength = (isRow) ? vt.Height : vt.Width;
                                            int rawIndex = (isRow) ? (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _TableVariableY)
                                                                   : (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _TableVariableX);
                                            // index start from 0
                                            int index = (rawIndex < 0) ? (rawIndex + tableLength) : (rawIndex - 1);

                                            if (isRow) { vt.RemoveRow(index, vtchanger); }
                                            else { vt.RemoveColumn(index, vtchanger); }

                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tableremoveline",
                                                "Removed {3} #({2}) from {1}table ({0})",
                                                sourcename, sPersist, index, lineType));
                                        }
                                    }
                                    break;
                                case TableVariableOpEnum.SortLine:
                                    {
                                        bool isCol = !string.IsNullOrWhiteSpace(_TableVariableX);
                                        string lineType = I18n.TrlTableColOrRow(isCol);
                                        string rawExpr = isCol ? _TableVariableX : _TableVariableY;
                                        string[] invalidExprs = isCol
                                            ? new[] { "${_this}", "${_row", "${_idx}", "${_key}", "${_val}" }
                                            : new[] { "${_this}", "${_col", "${_idx}", "${_key}", "${_val}" };
                                        CheckInvalidDymanicExpr(rawExpr, invalidExprs);

                                        // parsing expressions like "n+:key1, s-:key2, s+:key3, ..."
                                        ParseSortKeyFunctions(rawExpr, out List<bool> isNumeric, out List<bool> isAscending,
                                            out List<string> keysExpr, out List<List<string>> values);
                                        int keysCount = keysExpr.Count;

                                        lock (svs.Table)
                                        {
                                            VariableTable vt = GetTableVariable(svs, sourcename, false);
                                            ctx.varName = (_TableSourcePersist ? "ptvar:" : "tvar:") + _TableVariableName; // for ${_row[i]}
                                            if (isCol)
                                            {
                                                // Iterate through the columns and evaluate the key expression in the current context
                                                for (int colIndex = 0; colIndex < vt.Width; colIndex++)
                                                {
                                                    ctx.tableColIndex = colIndex + 1;  // for ${_col}
                                                    for (int keyIndex = 0; keyIndex < keysCount; keyIndex++)
                                                    {
                                                        string keyValue = isNumeric[keyIndex]
                                                            ? I18n.ThingToString(ctx.EvaluateNumericExpression(ActionContextLogger, ctx, keysExpr[keyIndex]))
                                                            : ctx.EvaluateStringExpression(ActionContextLogger, ctx, keysExpr[keyIndex]);
                                                        values[keyIndex].Add(keyValue);
                                                    }
                                                }

                                                IOrderedEnumerable<int> sortedIndices = ApplySorting(vt.Width, isNumeric, isAscending, values);
                                                foreach (var row in vt.Rows)
                                                {
                                                    var sortedValue = sortedIndices.Select(i => row.Values[i]).ToList();
                                                    row.Values = sortedValue;
                                                }
                                            }
                                            else // is row
                                            {
                                                // Iterate through the rows and evaluate the key expression in the current context
                                                for (int rowIndex = 0; rowIndex < vt.Height; rowIndex++)
                                                {
                                                    ctx.tableRowIndex = rowIndex + 1;  // for ${_row}
                                                    for (int keyIndex = 0; keyIndex < keysCount; keyIndex++)
                                                    {
                                                        string keyValue = isNumeric[keyIndex]
                                                            ? I18n.ThingToString(ctx.EvaluateNumericExpression(ActionContextLogger, ctx, keysExpr[keyIndex]))
                                                            : ctx.EvaluateStringExpression(ActionContextLogger, ctx, keysExpr[keyIndex]);
                                                        values[keyIndex].Add(keyValue);
                                                    }
                                                }

                                                IOrderedEnumerable<int> sortedIndices = ApplySorting(vt.Height, isNumeric, isAscending, values);
                                                var sortedRows = sortedIndices.Select(i => vt.Rows[i]).ToList();
                                                vt.Rows = sortedRows;
                                            }

                                            vt.LastChanger = vtchanger;
                                            vt.LastChanged = DateTime.Now;
                                        }

                                        for (int i = 0; i < keysCount; i++)
                                        {   // logging each sorting keys
                                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tablesortline",
                                                "Sorting {2}s of {1}table ({0}): function ({3}/{4}, {6}) = ({5}). Keys: ({7})",
                                                sourcename, sPersist, lineType, i + 1, keysCount, keysExpr[i],
                                                (isNumeric[i] ? "n" : "s") + (isAscending[i] ? "+" : "-"),
                                                String.Join(", ", values[i])));
                                        }
                                    }
                                    break;
                                case TableVariableOpEnum.GetAllEntities:
                                    {
                                        var entities = string.IsNullOrWhiteSpace(_TableVariableY)
                                            ? FFXIV.Entity.GetEntities()
                                            : FFXIV.Entity.GetFilteredEntities(ctx.EvaluateStringExpression(ActionContextLogger, ctx, _TableVariableY));

                                        var propNames = string.IsNullOrWhiteSpace(_TableVariableX)
                                            ? FFXIV.Entity.RecommendedEntityPropNames.Select(x => x.ToLower()).Concat(FFXIV.Job.LegalJobPropNames).OrderBy(s => s)
                                            : (IEnumerable<string>)Context.SplitArguments(ctx.EvaluateStringExpression(ActionContextLogger, ctx, _TableVariableX), false);
                                        if (string.IsNullOrWhiteSpace(_TableVariableX))
                                        {
                                            var specialKeys = new List<string> { "id", "name", "x", "y", "z", "h", "bnpcid" };
                                            propNames = specialKeys.Concat(propNames.Except(specialKeys));
                                        }

                                        VariableTable vt = new VariableTable { LastChanger = vtchanger, LastChanged = DateTime.Now };
                                        var headerRow = new VariableTable.VariableTableRow
                                        {
                                            Values = propNames.Select(prop => (Variable)new VariableScalar(prop)).ToList()
                                        };
                                        vt.Rows.Add(headerRow);

                                        foreach (var entity in entities)
                                        {
                                            if (entity.ID == 0) continue; 
                                            var row = new VariableTable.VariableTableRow
                                            {
                                                Values = propNames.Select(prop => (Variable)new VariableScalar(entity.QueryProperty(prop))).ToList()
                                            };
                                            vt.Rows.Add(row);
                                        }
                                        lock (svs.Table)
                                        {
                                            svs.Table[sourcename] = vt;
                                        }
                                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tablegetallentities",
                                            "Saved {2} entities into {1}table variable ({0})",
                                            sourcename, sPersist, vt.Rows.Count - 1));
                                    }
                                    break;
                            }
                        }
                        break;
                    #endregion  
                    #region Implementation - Text aura
                    case ActionTypeEnum.TextAura:
                        {
                            plug.TextAuraManagement(ctx, this);
                        }
                        break;
                    #endregion
                    #region Implementation - Trigger operation
                    case ActionTypeEnum.Trigger:
                        {
                            Trigger t = plug.GetTriggerById(_TriggerId, ctx.trig?.Repo);
                            if (t != null)
                            {
                                switch (_TriggerOp)
                                {
                                    case TriggerOpEnum.CancelAllTrigger:
                                        plug.ClearActionQueue();
                                        break;
                                    case TriggerOpEnum.CancelTrigger:
                                        plug.CancelAllQueuedActionsFromTrigger(t);
                                        break;
                                    case TriggerOpEnum.FireTrigger:
                                        {
                                            LogEvent le = new LogEvent();
                                            le.Text = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _TriggerText);
                                            le.ZoneName = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _TriggerZone);
                                            if (_TriggerZoneType == TriggerZoneTypeEnum.ZoneIdFFXIV && le.ZoneName.Trim().Length > 0)
                                            {
                                                le.ZoneId = le.ZoneName;
                                            }
                                            le.Timestamp = DateTime.Now;
                                            if (ctx.zoneIdOverride != null)
                                            {
                                                le.TestMode = true;
                                                le.ZoneId = ctx.zoneIdOverride;
                                            }
                                            plug.TestTrigger(t, le, _TriggerForceType);
                                        }
                                        break;
                                    case TriggerOpEnum.EnableTrigger:
                                        {
                                            t.Enabled = true;

                                            plug.ui.Invoke((System.Action)(() =>
                                            {
                                                bool isLocal = ctx.trig == null || ctx.trig.Repo == null;
                                                TreeNode tn = plug.LocateNodeHostingTrigger(plug.ui.treeView1.Nodes[isLocal ? 0 : 1], t);

                                                if (tn != null)
                                                {
                                                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/trigenable", "Trigger '{0}' enabled", t.LogName));
                                                    tn.Checked = true;
                                                }
                                                else
                                                {
                                                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/notreenodetrigenable", "Could not find tree node to modify for enabling trigger {0}", t.LogName));
                                                }
                                            }));
                                        }
                                        break;
                                    case TriggerOpEnum.DisableTrigger:
                                        {
                                            t.Enabled = false;

                                            plug.ui.Invoke((System.Action)(() =>
                                            {
                                                bool isLocal = ctx.trig == null || ctx.trig.Repo == null;
                                                TreeNode tn = plug.LocateNodeHostingTrigger(plug.ui.treeView1.Nodes[isLocal ? 0 : 1], t);

                                                if (tn != null)
                                                {
                                                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/trigdisable", "Trigger '{0}' disabled", t.LogName));
                                                    tn.Checked = false;
                                                }
                                                else
                                                {
                                                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/notreenodetrigdisable", "Could not find tree node to modify for disabling trigger {0}", t.LogName));
                                                }
                                            }));
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                if (_TriggerOp == TriggerOpEnum.CancelAllTrigger)
                                {
                                    plug.ClearActionQueue();
                                }
                                else
                                {
                                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/notriggerwithid", 
                                        "Trigger operation failed: In trigger ({1}), the specified trigger id ({0}) does not exist.", _TriggerId, ParentTrigger?.FullPath ?? "null"));
                                }
                            }
                        }
                        break;
                    #endregion
                    #region Implementation - Window message
                    case ActionTypeEnum.WindowMessage:
                        {
                            int procid = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _WmsgProcId);
                            string window = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _WmsgTitle);
                            int code = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _WmsgCode);
                            IntPtr wparam = (IntPtr)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _WmsgWparam);
                            IntPtr lparam = (IntPtr)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _WmsgLparam);
                            WindowsUtils.SendMessageToWindow(procid, window, (ushort)code, wparam, lparam);
                        }
                        break;
                    #endregion
                    #region Implementation - Mouse
                    case ActionTypeEnum.Mouse:
                        {
                            int mousex = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _MouseX);
                            int mousey = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _MouseY);
                            WindowsUtils.MouseEventFlags flags = 0;
                            switch (_MouseCoordType)
                            {
                                case MouseCoordEnum.Absolute:
                                    flags |= WindowsUtils.MouseEventFlags.ABSOLUTE;
                                    break;
                                case MouseCoordEnum.Relative:
                                    break;
                            }
                            switch (_MouseOpType)
                            {
                                case MouseOpEnum.Move:
                                    WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.MOVE, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                                    break;
                                case MouseOpEnum.LeftClick:
                                    Task.Run(() =>
                                    {
                                        WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.MOVE, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                                        Thread.Sleep(10);
                                        WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.LEFTDOWN, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                                        Thread.Sleep(10);
                                        WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.LEFTUP, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                                    });
                                    break;
                                case MouseOpEnum.MiddleClick:
                                    Task.Run(() =>
                                    {
                                        WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.MOVE, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                                        Thread.Sleep(10);
                                        WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.MIDDLEDOWN, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                                        Thread.Sleep(10);
                                        WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.MIDDLEUP, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                                    });
                                    break;
                                case MouseOpEnum.RightClick:
                                    Task.Run(() =>
                                    {
                                        WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.MOVE, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                                        Thread.Sleep(10);
                                        WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.RIGHTDOWN, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                                        Thread.Sleep(10);
                                        WindowsUtils.SendMouse(flags | WindowsUtils.MouseEventFlags.RIGHTUP, WindowsUtils.MouseEventDataXButtons.NONE, mousex, mousey);
                                    });
                                    break;
                            }
                        }
                        break;
                    #endregion
                    #region Implementation - Named callback
                    case ActionTypeEnum.NamedCallback:
                        {
                            string cbname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _NamedCallbackName);
                            string cbparm = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _NamedCallbackParam);
                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/callbackinvoke", "Invoking named callback ({0}) with parameter ({1})", cbname, cbparm));
                            plug.InvokeNamedCallback(cbname, cbparm);
                        }
                        break;
                    #endregion
                    #region Implementation - Loop
                    case ActionTypeEnum.Loop:
                        {
                            if (ctx.loopcontext == Id)
                            {
                                ctx.loopiterator += (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _LoopIncrExpression);
                            }
                            if (LoopCondition.Enabled == true && LoopCondition.CheckCondition(ctx, ActionContextLogger, ctx) == true)
                            {
                                bool continuing = false;
                                if (ctx.loopcontext != Id)
                                {
                                    continuing = (ctx.loopcontext == Guid.Empty);
                                    ctx = ctx.Duplicate();
                                    if (ctx.loopcontext != Guid.Empty && ctx.loopcontext != Id)
                                    {
                                        ctx.id = Guid.NewGuid();
                                    }
                                    ctx.loopcontext = Id;
                                    ctx.loopiterator = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _LoopInitExpression);
                                }
                                else
                                {
                                    continuing = true;
                                }
                                DateTime curTime = DateTime.Now;
                                Action lastAction = plug.QueueActions(ctx, curTime, LoopActions, ctx.trig._Sequential, qa?.mutex, ActionContextLogger);
                                lastAction.LoopAction = this;
                                if (continuing == true)
                                {
                                    return;
                                }
                            }
                        }
                        break;
                        #endregion
                }
            ContinueChain:
                if (LoopAction != null)
                {
                    DateTime dt = DateTime.Now.AddMilliseconds(ctx.EvaluateNumericExpression(ActionContextLogger, ctx, LoopAction._LoopDelayExpression));
                    plug.QueueAction(ctx, ctx.trig, qa?.mutex, LoopAction, dt, false);
                }
                else if (NextAction != null)
                {
                    DateTime dt = DateTime.Now.AddMilliseconds(ctx.EvaluateNumericExpression(ActionContextLogger, ctx, NextAction._ExecutionDelayExpression));
                    plug.QueueAction(ctx, ctx.trig, qa?.mutex, NextAction, dt, false);
                }
                else if (qa?.mutex != null)
                {
                    qa.mutex.Release(ctx);
                    qa.mutex = null;
                }
            }
            catch (Exception ex)
            {
                string triggerPath = qa?.ctx?.trig?.FullPath ?? "(null)";
                string actionDesc = "";
                try { actionDesc = GetDescription(ctx); } catch { }
                actionDesc = (actionDesc.Length > 300) ? (actionDesc.Substring(0, 297) + "...") : actionDesc;
                bool showDetail = _ActionType == ActionTypeEnum.ExecuteScript || _ActionType == ActionTypeEnum.NamedCallback || plug.cfg.DeveloperMode;
                string exDesc1 = ex.Message; // type and message
                string exDesc2 = ""; // inner and stack
                if (showDetail)
                {
                    exDesc1 = ex.GetType().FullName + ": " + exDesc1;
                    exDesc2 = Environment.NewLine;
                    if (ex.InnerException != null)
                    {
                        exDesc2 += Environment.NewLine + " ---> " + ex.InnerException.ToString();
                    }
                    if (ex.StackTrace != null)
                    {
                        exDesc2 += Environment.NewLine + ex.StackTrace;
                    }
                }
                AddToLog(ctx, RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/exception",
                    "Action exception: {0}  \nIn action: {1}  \nIn trigger: {2}{3}",
                    exDesc1, actionDesc, triggerPath, exDesc2));
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

        internal void Execute(RealPlugin.QueuedAction qa, Context ctx)
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
                        ExecutionImplementation(qa, ctx);
                        qa?.ActionFinished();
                    });
                }
                else
                {
                    t = new Task(() =>
                    {
                        ExecutionImplementation(qa, ctx);
                        qa?.ActionFinished();
                    });
                }
                t.Start();
            }
            else
            {
                ExecutionImplementation(qa, ctx);
                qa?.ActionFinished();
            }
        }

        public void CopySettingsTo(Action a)
        {
            a.ParentTrigger = ParentTrigger;
            a.Id = Id;
            a._ActionType = _ActionType;
            a.OrderNumber = OrderNumber;
            a._Asynchronous = _Asynchronous;
            a._Enabled = _Enabled;
            a._ExecutionDelayExpression = _ExecutionDelayExpression;
            a._LaunchProcessCmdlineExpression = _LaunchProcessCmdlineExpression;
            a._LaunchProcessPathExpression = _LaunchProcessPathExpression;
            a._LaunchProcessWindowStyle = _LaunchProcessWindowStyle;
            a._LaunchProcessWorkingDirExpression = _LaunchProcessWorkingDirExpression;
            a._PlaySoundExclusive = _PlaySoundExclusive;
            a._PlaySoundFileExpression = _PlaySoundFileExpression;
            a._PlaySoundVolumeExpression = _PlaySoundVolumeExpression;
            a._RefireInterrupt = _RefireInterrupt;
            a._RefireRequeue = _RefireRequeue;
            a._SystemBeepFreqExpression = _SystemBeepFreqExpression;
            a._SystemBeepLengthExpression = _SystemBeepLengthExpression;
            a._UseTTSExclusive = _UseTTSExclusive;
            a._UseTTSRateExpression = _UseTTSRateExpression;
            a._UseTTSTextExpression = _UseTTSTextExpression;
            a._UseTTSVolumeExpression = _UseTTSVolumeExpression;
            a._ExecScriptAssembliesExpression = _ExecScriptAssembliesExpression;
            a._ExecScriptExpression = _ExecScriptExpression;
            a._MessageBoxIconType = _MessageBoxIconType;
            a._MessageBoxText = _MessageBoxText;
            a._VariableOp = _VariableOp;
            a._VariableName = _VariableName;
            a._VariableJsonTarget = _VariableJsonTarget;
            a._DebugLevel = _DebugLevel;
            a._VariableExpression = _VariableExpression;
            a._TriggerId = _TriggerId;
            a._TriggerOp = _TriggerOp;
            a._TriggerText = _TriggerText;
            a._TriggerZone = _TriggerZone;
            a._TriggerForceType = _TriggerForceType;
            a._AuraOp = _AuraOp;
            a._AuraName = _AuraName;
            a._AuraImage = _AuraImage;
            a._AuraImageMode = _AuraImageMode;
            a._AuraXIniExpression = _AuraXIniExpression;
            a._AuraYIniExpression = _AuraYIniExpression;
            a._AuraWIniExpression = _AuraWIniExpression;
            a._AuraHIniExpression = _AuraHIniExpression;
            a._AuraOIniExpression = _AuraOIniExpression;
            a._AuraXTickExpression = _AuraXTickExpression;
            a._AuraYTickExpression = _AuraYTickExpression;
            a._AuraWTickExpression = _AuraWTickExpression;
            a._AuraHTickExpression = _AuraHTickExpression;
            a._AuraOTickExpression = _AuraOTickExpression;
            a._AuraTTLTickExpression = _AuraTTLTickExpression;
            a._FolderOp = _FolderOp;
            a._FolderId = _FolderId;
            a._DiscordWebhookMessage = _DiscordWebhookMessage;
            a._DiscordWebhookURL = _DiscordWebhookURL;
            a._TextAuraOp = _TextAuraOp;
            a._TextAuraName = _TextAuraName;
            a._TextAuraExpression = _TextAuraExpression;
            a._TextAuraAlignment = _TextAuraAlignment;
            a._TextAuraXIniExpression = _TextAuraXIniExpression;
            a._TextAuraYIniExpression = _TextAuraYIniExpression;
            a._TextAuraWIniExpression = _TextAuraWIniExpression;
            a._TextAuraHIniExpression = _TextAuraHIniExpression;
            a._TextAuraOIniExpression = _TextAuraOIniExpression;
            a._TextAuraXTickExpression = _TextAuraXTickExpression;
            a._TextAuraYTickExpression = _TextAuraYTickExpression;
            a._TextAuraWTickExpression = _TextAuraWTickExpression;
            a._TextAuraHTickExpression = _TextAuraHTickExpression;
            a._TextAuraOTickExpression = _TextAuraOTickExpression;
            a._TextAuraTTLTickExpression = _TextAuraTTLTickExpression;
            a._TextAuraFontName = _TextAuraFontName;
            a._TextAuraFontSize = _TextAuraFontSize;
            a._TextAuraEffect = _TextAuraEffect;
            a._TextAuraOutlineClInt = _TextAuraOutlineClInt;
            a._TextAuraForegroundClInt = _TextAuraForegroundClInt;
            a._TextAuraBackgroundClInt = _TextAuraBackgroundClInt;
            a._LogMessageText = _LogMessageText;
            a._LogLevel = _LogLevel;
            a._DiscordTts = _DiscordTts;
            a._ListVariableExpression = _ListVariableExpression;
            a._ListVariableExpressionType = _ListVariableExpressionType;
            a._ListVariableIndex = _ListVariableIndex;
            a._ListVariableName = _ListVariableName;
            a._ListVariableOp = _ListVariableOp;
            a._ListVariableTarget = _ListVariableTarget;
            a._OBSControlType = _OBSControlType;
            a._OBSEndPoint = _OBSEndPoint;
            a._OBSPassword = _OBSPassword;
            a._OBSSceneName = _OBSSceneName;
            a._OBSSourceName = _OBSSourceName;
            a._OBSJSONPayload = _OBSJSONPayload;
            a._LSControlType = _LSControlType;
            a._LSCustomPayload = _LSCustomPayload;
            a._LogProcess = _LogProcess;
            a._LogProcessACT = _LogProcessACT;
            a._LogMessageTarget = _LogMessageTarget;
            a._JsonOperationType = _JsonOperationType;
            a._JsonCacheRequest = _JsonCacheRequest;
            a._JsonEndpointExpression = _JsonEndpointExpression;
            a._JsonHeaderExpression = _JsonHeaderExpression;
            a._JsonFiringExpression = _JsonFiringExpression;
            a._JsonPayloadExpression = _JsonPayloadExpression;
            a._Condition = (ConditionGroup)(_Condition != null ? ((ConditionGroup)_Condition).Duplicate() : null);
            a._KeyPressExpression = _KeyPressExpression;
            a._KeypressType = _KeypressType;
            a._KeyPressCode = _KeyPressCode;
            a._KeyPressWindow = _KeyPressWindow;
            a._KeyPressProcId = _KeyPressProcId;
            a._WmsgProcId = _WmsgProcId;
            a._WmsgCode = _WmsgCode;
            a._WmsgTitle = _WmsgTitle;
            a._WmsgLparam = _WmsgLparam;
            a._WmsgWparam = _WmsgWparam;
            a._DiskFileOp = _DiskFileOp;
            a._DiskFileOpVar = _DiskFileOpVar;
            a._DiskFileOpName = _DiskFileOpName;
            a._TableVariableExpression = _TableVariableExpression;
            a._TableVariableExpressionType = _TableVariableExpressionType;
            a._TableVariableName = _TableVariableName;
            a._TableVariableOp = _TableVariableOp;
            a._TableVariableTarget = _TableVariableTarget;
            a._TableVariableX = _TableVariableX;
            a._TableVariableY = _TableVariableY;
            a._DictVariableName = _DictVariableName;
            a._DictVariableTarget = _DictVariableTarget;
            a._DictSourcePersist = _DictSourcePersist;
            a._DictTargetPersist = _DictTargetPersist;
            a._DictVariableKey = _DictVariableKey;
            a._DictVariableValue = _DictVariableValue;
            a._DictVariableKeyType = _DictVariableKeyType;
            a._DictVariableValueType = _DictVariableValueType;
            a._DictVariableOp = _DictVariableOp;
            a._DictVariableLength = _DictVariableLength;
            a._MutexOpType = _MutexOpType;
            a._MutexName = _MutexName;
            a._Description = _Description;
            a._DescriptionOverride = _DescriptionOverride;
            a._DescBgColor = _DescBgColor;
            a._DescTextColor = _DescTextColor;
            a._NamedCallbackParam = _NamedCallbackParam;
            a._NamedCallbackName = _NamedCallbackName;
            a._MouseOpType = _MouseOpType;
            a._MouseCoordType = _MouseCoordType;
            a._MouseX = _MouseX;
            a._MouseY = _MouseY;
            a._ListSourcePersist = _ListSourcePersist;
            a._ListTargetPersist = _ListTargetPersist;
            a._TableSourcePersist = _TableSourcePersist;
            a._TableTargetPersist = _TableTargetPersist;
            a._DiskPersist = _DiskPersist;
            a._VariablePersist = _VariablePersist;
            a._VariableTargetPersist = _VariableTargetPersist;
            a.LoopCondition = (ConditionGroup)(LoopCondition != null ? ((ConditionGroup)LoopCondition).Duplicate() : null);
            a.LoopActions.Clear();
            if (LoopActions != null)
            {
                var ix = from tx in LoopActions
                         orderby tx.OrderNumber ascending
                         select tx;
                foreach (Action ax in ix)
                {
                    Action b = new Action();
                    ax.CopySettingsTo(b);
                    a.LoopActions.Add(b);
                }
            }
            a._LoopDelayExpression = _LoopDelayExpression;
            a._LoopIncrExpression = _LoopIncrExpression;
            a._LoopInitExpression = _LoopInitExpression;
            a._ActOpBoolParam = _ActOpBoolParam;
            a._ActOpStringParam = _ActOpStringParam;
            a._ActOpType = _ActOpType;
            a._RepositoryId = _RepositoryId;
            a._RepositoryOp = _RepositoryOp;
            a._JsonResultVariable = _JsonResultVariable;
            a._JsonResultVariablePersist = _JsonResultVariablePersist;
            a._TriggerZoneType = _TriggerZoneType;
            a._SoundRouting = _SoundRouting;
            a._TTSRouting = _TTSRouting;
        }

        private Tuple<int, string> SendJson(Context ctx, Action.HTTPMethodEnum method, string url, string json, IEnumerable<string> headers, bool expectNoContent)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                if (headers != null && headers.Count() > 0)
                {
                    foreach (string hdr in headers)
                    {
                        httpWebRequest.Headers.Add(hdr);
                    }
                }
                switch (method)
                {
                    case HTTPMethodEnum.POST:
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";
                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            streamWriter.Write(json);
                            streamWriter.Flush();
                            streamWriter.Close();
                        }
                        break;
                    case HTTPMethodEnum.GET:
                        httpWebRequest.Method = "GET";
                        break;
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode != HttpStatusCode.NoContent && expectNoContent == true)
                {
                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/jsonpostunexpectedresponse", "Unexpected response code: {0}", httpResponse.StatusCode));
                }
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    return new Tuple<int, string>((int)httpResponse.StatusCode, streamReader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                AddToLog(ctx, RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/jsonpostexception", "Couldn't send message due to exception: {0}", ex.Message));
                return new Tuple<int, string>(-1, "");
            }
        }

        /// <summary> Set text to the clipboard using the UI thread. If text is empty, clear the clipboard. </summary>
        public static void ClipboardSetText(string text)
        {
            plug.ui.Invoke(new System.Action(() =>
            {
                if (string.IsNullOrEmpty(text))
                    Clipboard.Clear();
                else
                    Clipboard.SetText(text);
            }));
        }

        /// <summary> Get the clipboard text using the UI thread. </summary>
        public static string ClipboardGetText()
            => (string)plug.ui.Invoke(new Func<string>(Clipboard.GetText));

        public static ArgumentException InvalidEnumException(string enumName, string enumValue)
        { 
            return new ArgumentException(
                I18n.Translate(
                    "internal/Action/invalidEnumType",
                    "{0} = {1} is not a known enum type.\n\n" +
                    "This may be because your Triggernometry plugin is not up to date, or the data you are trying to import is corrupted.",
                    enumName, enumValue)
                );
        }

    }

}
