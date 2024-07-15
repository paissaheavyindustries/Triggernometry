using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static Triggernometry.RealPlugin;

namespace Triggernometry
{

    [XmlInclude(typeof(Actions.ActionActInteraction))]
    [XmlInclude(typeof(Actions.ActionBeep))]
    [XmlInclude(typeof(Actions.ActionDiscordWebhook))]
    [XmlInclude(typeof(Actions.ActionDiskOperation))]
    [XmlInclude(typeof(Actions.ActionExecuteScript))]
    [XmlInclude(typeof(Actions.ActionFolderOperation))]
    [XmlInclude(typeof(Actions.ActionJsonRequest))]
    [XmlInclude(typeof(Actions.ActionKeypress))]
    [XmlInclude(typeof(Actions.ActionLaunchProcess))]
    [XmlInclude(typeof(Actions.ActionLiveSplitControl))]
    [XmlInclude(typeof(Actions.ActionLogMessage))]
    [XmlInclude(typeof(Actions.ActionLoop))]
    [XmlInclude(typeof(Actions.ActionMessageBox))]
    [XmlInclude(typeof(Actions.ActionMouse))]
    [XmlInclude(typeof(Actions.ActionMutex))]
    [XmlInclude(typeof(Actions.ActionNamedCallback))]
    [XmlInclude(typeof(Actions.ActionObsControl))]
    [XmlInclude(typeof(Actions.ActionOverlayImage))]
    [XmlInclude(typeof(Actions.ActionOverlayText))]
    [XmlInclude(typeof(Actions.ActionPlaceholder))]
    [XmlInclude(typeof(Actions.ActionPlaySound))]
    [XmlInclude(typeof(Actions.ActionPlaySpeech))]
    [XmlInclude(typeof(Actions.ActionRepository))]
    [XmlInclude(typeof(Actions.ActionTriggerOperation))]
    [XmlInclude(typeof(Actions.ActionVariableDict))]
    [XmlInclude(typeof(Actions.ActionVariableList))]
    [XmlInclude(typeof(Actions.ActionVariableScalar))]
    [XmlInclude(typeof(Actions.ActionVariableTable))]
    [XmlInclude(typeof(Actions.ActionWindowMessage))]
    public abstract class ActionBase
    {

        internal Guid Id { get; set; } = Guid.NewGuid();
        internal Trigger ParentTrigger { get; set; } = null;

        [XmlAttribute]
        public int OrderNumber { get; set; } = 1;

        #region Action instance

        /// <summary>
        /// When an action is queued for execution, it's wrapped in an ActionInstance that carries all the relevant data for execution.
        /// </summary>
        internal class ActionInstance : IComparable
        {

            internal DateTime when { get; set; }
            internal Int64 ordinal { get; set; }
            internal MutexInformation mutex { get; set; }
            internal Action act { get; set; }
            internal Context ctx { get; set; }
            internal bool releaseMutex { get; set; } = false;

            public ActionInstance(DateTime when, Int64 ordinal, MutexInformation mtx, Action act, Context ctx, bool releaseMutex)
            {
                this.when = when;
                this.ordinal = ordinal;
                this.mutex = mtx;
                this.act = act;
                this.ctx = ctx;
                this.releaseMutex = releaseMutex;
            }

            public int CompareTo(object o)
            {
                ActionInstance b = (ActionInstance)o;
                int ex = when.CompareTo(b.when);
                if (ex != 0)
                {
                    return ex;
                }
                return ordinal.CompareTo(b.ordinal);
            }

            public void ActionFinished()
            {
                if (mutex != null && releaseMutex == true)
                {
                    mutex.Release(ctx);
                }
            }

        }

        #endregion

        #region Description and information

        private bool _DescriptionOverride { get; set; } = false;
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

        private string _Description { get; set; } = null;
        [XmlAttribute]
        public string Description
        {
            get
            {
                if (_Description == null || _Description == "")
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

        internal abstract string DescribeImplementation(Context ctx);
        internal string Describe(Context ctx)
        {
            if (_DescriptionOverride == true)
            {
                return _Description ?? "";
            }
            string temp = I18n.TrlAsync(_Asynchronous);
            if (!string.IsNullOrWhiteSpace(_ExecutionDelayExpression) && _ExecutionDelayExpression.Trim() != "0")
            {
                string delay = double.TryParse(_ExecutionDelayExpression.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out _) ? _ExecutionDelayExpression : $"({_ExecutionDelayExpression})";
                temp += I18n.Translate("internal/Action/descafterdelay", "after {0} ms, ", delay);  // included comma in translations (comma symbols are language-dependent)
            }
            if (Condition != null && Condition.Enabled == true)
            {
                temp += I18n.Translate("internal/Action/descassumingcondition", "assuming condition is met, ");
            }
            temp += DescribeImplementation(ctx);
            if (temp.Length > 1)
            {
                return char.ToUpper(temp[0]) + temp.Substring(1);
            }
            return temp.ToUpper();
        }

        #endregion

        #region Scheduling and execution

        /// <summary>
        /// True = action was executed (enabled & conditions met), false = action was not executed (disabled or conditions not met)
        /// </summary>
        internal bool LastExecutionResult
        {
            get
            {
                return _LastExecutionResult;
            }
            set
            {
                _LastExecutionResult = value;
                LastExecutionTime = DateTime.Now;
                ExecutionCount++;
            }
        }
        private bool _LastExecutionResult { get; set; } = false;
        internal DateTime LastExecutionTime { get; set; } = DateTime.MinValue;
        internal int ExecutionCount { get; set; } = 0;

        public ConditionGroup Condition { get; set; } = null;

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
                return null;
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
                return null;
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

        internal abstract void ExecuteImplementation(ActionInstance ai);
        internal void Execute(ActionInstance ai)
        {            
            if (_Enabled == false)
            {
                LastExecutionResult = false;
                return;
            }
            Context ctx = ai.ctx;
            if ((ctx.force & Action.TriggerForceTypeEnum.SkipConditions) == 0 && ctx.testByPlaceholder == false)
            {
                if (Condition != null && Condition.Enabled == true)
                {
                    if (Condition.CheckCondition(ctx, ActionContextLogger, ctx) == false)
                    {
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/actionnotfired", "Action #{0} on trigger '{1}' not fired, condition not met", OrderNumber, ctx.trig?.LogName ?? "(null)"));
                        LastExecutionResult = false;
                        return;
                    }
                }
            }
            if (_Asynchronous == true)
            {
                Task t;
                if (ctx.plug != null)
                {
                    CancellationToken ct = ctx.plug.GetCancellationToken();
                    t = new Task(() =>
                    {
                        ct.ThrowIfCancellationRequested();
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/executingaction", "Executing action '{0}' in thread {1}", Describe(ctx), System.Threading.Thread.CurrentThread.ManagedThreadId));
                        ExecuteImplementation(ai);
                        ai?.ActionFinished();
                    });
                }
                else
                {
                    t = new Task(() =>
                    {                        
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/executingaction", "Executing action '{0}' in thread {1}", Describe(ctx), System.Threading.Thread.CurrentThread.ManagedThreadId));
                        ExecuteImplementation(ai);
                        ai?.ActionFinished();
                    });
                }
                t.Start();
            }
            else
            {                
                AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/executingaction", "Executing action '{0}' in thread {1}", Describe(ctx), System.Threading.Thread.CurrentThread.ManagedThreadId));
                ExecuteImplementation(ai);
                ai?.ActionFinished();
            }
            LastExecutionResult = true;
        }

        internal RealPlugin.DebugLevelEnum GetDebugLevel(Context ctx)
        {
            if (_DebugLevel == RealPlugin.DebugLevelEnum.Inherit)
            {
                return ctx.trig?.GetDebugLevel(plug) ?? DebugLevelEnum.Verbose;
            }
            return _DebugLevel;
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

        // todo should get rid of this maybe

        #endregion

        #region Obsoletes, under construction, etc

        public void ActionContextLogger(object o, string msg)
        {            
        }

        public IOrderedEnumerable<int> ApplySorting(int elementCount, List<bool> isNumeric, List<bool> isAscending, List<List<string>> values)
        {
            return null;
        }

        public static void CheckInvalidDymanicExpr(string expr, string[] invalidExprs)
        {
        }

        public void ParseSortKeyFunctions(string rawExpr,
            out List<bool> isNumeric, out List<bool> isAscending,
            out List<string> keysExpr, out List<List<string>> values)
        {
            isNumeric = new List<bool>();
            isAscending = new List<bool>();
            keysExpr = new List<string>();
            values = new List<List<string>>();
        }

        public void CancelAllTriggersInFolder(Folder folder, Context ctx)
        {
        }

        public bool ObsConnector(Context ctx, string endpoint, string password)
        {
            return false;
        }

        public bool LiveSplitConnector(Context ctx)
        {
            return false;
        }

        public Tuple<int, string> SendJson(Context ctx, object method, string url, string json, IEnumerable<string> headers, bool expectNoContent)
        {
            return new Tuple<int, string>(-1, "");
        }

        public static ArgumentException InvalidEnumException(string enumName, string enumValue)
        {
            return new ArgumentException();
        }

        #endregion

        #region Action-specific properties

        internal abstract Control GetPropertyEditor();

        #endregion

    }

}
