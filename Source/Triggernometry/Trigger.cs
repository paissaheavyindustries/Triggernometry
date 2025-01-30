using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

namespace Triggernometry
{

    public class Trigger
    {

        public enum PrevActionsEnum
        {
            Keep,
            Interrupt
        }

        public enum RefireEnum
        {
            Allow,
            Deny
        }

        public enum SchedulingEnum
        {
            FromFire,
            FromLastAction,
            FromRefirePeriod
        }

        internal Folder Parent { get; set; }

        internal bool ZoneBlocked { get; set; } = false;

        [XmlAttribute]
        public bool Enabled { get; set; }		
        public List<Action> Actions { get; set; }

        public enum TriggerSourceEnum
        {
            Log,
            FFXIVNetwork,
            None,
            ACT,
            Endpoint
        }

        internal TriggerSourceEnum _Source { get; set; } = TriggerSourceEnum.Log;
        [XmlAttribute]
        public string Source
        {
            get
            {
                if (_Source != TriggerSourceEnum.Log)
                {
                    return _Source.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _Source = (TriggerSourceEnum)Enum.Parse(typeof(TriggerSourceEnum), value);
            }
        }

        internal ConditionGroup _Condition = new ConditionGroup { Enabled = false };
        public ConditionGroup Condition
        {
            get => _Condition.Children.Count == 0 && !_Condition.Enabled ? null : _Condition;
            set => _Condition = value;
        }

        internal bool _Sequential { get; set; } = false;
        [XmlAttribute]
        public string Sequential
        {
            get
            {
                if (_Sequential == false)
                {
                    return null;
                }
                return _Sequential.ToString();
            }
            set
            {
                _Sequential = Boolean.Parse(value);
            }
        }

        internal bool _IsReadme { get; set; } = false;
        [XmlAttribute]
        public string IsReadme
        {
            get
            {
                if (_IsReadme == false)
                {
                    return null;
                }
                return _IsReadme.ToString();
            }
            set
            {
                _IsReadme = Boolean.Parse(value);
            }
        }

        [XmlAttribute]
        public string Name { get; set; } = "";

        internal string LogName
        {
            get
            {
                return Name + " (" + (Repo != null ? "@" : "") + Id + ")";
            }
        }

        [XmlAttribute]
        public Guid Id { get; set; }

        internal Repository Repo { get; set; } = null;

        internal Regex rex;

        private string _RegularExpression;
        [XmlAttribute]
        public string RegularExpression
        {
            get
            {
                return _RegularExpression;
            }
            set
            {
                string temp = RealPlugin.UnserializeInvalidXmlCharacters(value);
                if (_RegularExpression != temp)
                {
                    _RegularExpression = temp;
                    if (value.Trim().Length == 0)
                    {
                        rex = null;
                        return;
                    }
                    try
                    {
                        rex = new Regex(_RegularExpression);
                    }
                    catch (Exception)
                    {
                        rex = null;
                    }
                }
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

        internal PrevActionsEnum _PrevActions { get; set; } = PrevActionsEnum.Keep;
        [XmlAttribute]
        public string PrevActions
        {
            get
            {
                if (_PrevActions != PrevActionsEnum.Keep)
                {
                    return _PrevActions.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _PrevActions = (PrevActionsEnum)Enum.Parse(typeof(PrevActionsEnum), value);
            }
        }

        internal RefireEnum _PrevActionsRefire { get; set; } = RefireEnum.Allow;
        [XmlAttribute]
        public string PrevActionsRefire
        {
            get
            {
                if (_PrevActionsRefire != RefireEnum.Allow)
                {
                    return _PrevActionsRefire.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _PrevActionsRefire = (RefireEnum)Enum.Parse(typeof(RefireEnum), value);
            }
        }

        internal SchedulingEnum _Scheduling { get; set; } = SchedulingEnum.FromFire;
        [XmlAttribute]
        public string Scheduling
        {
            get
            {
                if (_Scheduling != SchedulingEnum.FromFire)
                {
                    return _Scheduling.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _Scheduling = (SchedulingEnum)Enum.Parse(typeof(SchedulingEnum), value);
            }
        }

        internal RefireEnum _PeriodRefire { get; set; } = RefireEnum.Allow;
        [XmlAttribute]
        public string PeriodRefire
        {
            get
            {
                if (_PeriodRefire != RefireEnum.Allow)
                {
                    return _PeriodRefire.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _PeriodRefire = (RefireEnum)Enum.Parse(typeof(RefireEnum), value);
            }
        }

        internal string _RefirePeriodExpression { get; set; } = "0";
        [XmlAttribute]
        public string RefirePeriodExpression
        {
            get
            {
                if (_RefirePeriodExpression == "0" || _RefirePeriodExpression == "")
                {
                    return null;
                }
                return _RefirePeriodExpression;
            }
            set
            {
                _RefirePeriodExpression = value;
            }
        }

        internal string _MutexToCapture { get; set; } = "";
        [XmlAttribute]
        public string MutexToCapture
        {
            get
            {
                if (_MutexToCapture == "")
                {
                    return null;
                }
                return _MutexToCapture;
            }
            set
            {
                _MutexToCapture = value;
            }
        }

        internal bool _EditAutofire { get; set; } = false;
        [XmlAttribute]
        public string EditAutofire
        {
            get
            {
                if (_EditAutofire == false)
                {
                    return null;
                }
                return _EditAutofire.ToString();
            }
            set
            {
                _EditAutofire = Boolean.Parse(value);
            }
        }
        internal bool _EditAutofireAllowCondition { get; set; } = false;
        [XmlAttribute]
        public string EditAutofireAllowCondition
        {
            get
            {
                if (_EditAutofireAllowCondition == false)
                {
                    return null;
                }
                return _EditAutofireAllowCondition.ToString();
            }
            set
            {
                _EditAutofireAllowCondition = Boolean.Parse(value);
            }
        }

        internal string _TestInput;
        [XmlAttribute]
        public string TestInput
        {
            get
            {
                if (_TestInput == "")
                {
                    return null;
                }
                return _TestInput;
            }
            set
            {
                _TestInput = value;
            }
        }

        internal string _Description;
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

        private DateTime LastFired { get; set; }
        internal DateTime RefireDelayedUntil { get; set; }

        internal string FullPath
        {
            get
            {
                string name = Name;
                Folder f = Parent;
                while (f != null)
                {
                    if (f.Parent != null)
                    {
                        name = f.Name + @"\" + name;
                    }
                    f = f.Parent;
                }
                return name;
            }
        }

        #region Old condition to new condition converter
        private EventList<Condition> _Conditions;
        public EventList<Condition> Conditions
        {
            get
            {
                return (_Conditions?.Count ?? 0) == 0 ? null : _Conditions;
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


        #region Old property conversions
        [XmlAttribute]
        public string AllowRefire
        {
            get
            {
                return null;
            }
            set
            {
                if (value == "true")
                {
                    _PrevActionsRefire = RefireEnum.Allow;
                }
                else
                {
                    _PrevActionsRefire = RefireEnum.Deny;
                }
            }
        }

        [XmlAttribute]
        public string RefireDelayed
        {
            get
            {
                return null;
            }
            set
            {
                if (value == "true")
                {
                    _PeriodRefire = RefireEnum.Deny;
                }
                else
                {
                    _PeriodRefire = RefireEnum.Allow;
                }
            }
        }

        [XmlAttribute]
        public string RefireDelayExpression
        {
            get
            {
                return null;
            }
            set
            {
                _RefirePeriodExpression = value;
            }
        }
        #endregion

        public Trigger()
        {
            Actions = new List<Action>();
            Conditions = new EventList<Triggernometry.Condition>();
            Id = Guid.NewGuid();
        }

        internal Match CheckMatch(string input)
        {
			if (rex == null)
			{
				return null;
			}		
            try
            {
                Match m = rex.Match(input);
                if (m.Success == true)
                {
                    return m;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        internal RealPlugin.DebugLevelEnum GetDebugLevel(RealPlugin p)
        {
            if (_DebugLevel == RealPlugin.DebugLevelEnum.Inherit)
            {
                if (p.cfg != null)
                {
                    return p.cfg.DebugLevel;
                }
                else
                {
                    return RealPlugin.DebugLevelEnum.Verbose;
                }
            }
            return _DebugLevel;
        }

        internal void AddToLog(RealPlugin p, RealPlugin.DebugLevelEnum level, string message)
        {
            RealPlugin.DebugLevelEnum dx = GetDebugLevel(p);
            if (level > dx)
            {
                return;
            }
            p.UnfilteredAddToLog(level, message);
        }

        internal void DeferredFire(RealPlugin p, Context ctx, RealPlugin.MutexInformation mi, RealPlugin.MutexTicket m)
        {
            using (m)
            {
                mi.Acquire(ctx, m);
                if (Fire(p, ctx, mi) == false)
                {
                    mi.Release(ctx);
                }
            }
        }

        internal bool PassesZoneRestriction(string zone)
        {
            return Parent.PassesZoneRestriction(zone);
        }

        internal void QueueActions(Context ctx, DateTime curtime, RealPlugin.MutexInformation mtx)
        {
            //System.Diagnostics.Debug.WriteLine("### queuing actions for " + ctx.ToString());
            RealPlugin.plug.QueueActions(ctx, curtime, Actions, _Sequential, mtx, TriggerContextLogger);
        }

        internal bool Fire(RealPlugin p, Context ctx, RealPlugin.MutexInformation mtx)
		{
            try
            {
                if (mtx == null && _MutexToCapture != "")
                {
                    string mn = ctx.EvaluateStringExpression(TriggerContextLogger, p, _MutexToCapture);
                    RealPlugin.MutexInformation mi = ctx.plug.GetMutex(mn);
                    RealPlugin.MutexTicket m = mi.QueueForAcquisition(ctx);
                    Task t = new Task(() => {
                        using (m)
                        {                            
                            DeferredFire(ctx.plug, ctx, mi, m);                            
                        }
                    });
                    t.Start();
                    return true;
                }
                if ((ctx.force & Action.TriggerForceTypeEnum.SkipConditions) == 0)
                {
                    if (_Condition != null && _Condition.Enabled == true)
                    {
                        if (_Condition.CheckCondition(ctx, TriggerContextLogger, ctx.plug) == false)
                        {
                            AddToLog(p, RealPlugin.DebugLevelEnum.Info, I18n.Translate("internal/Trigger/trignotfired", "Trigger '{0}' not fired, condition not met", LogName));
                            return false;
                        }
                    }
                }
                DateTime prevLastFired = LastFired;
                LastFired = DateTime.Now;
                if (_PeriodRefire == RefireEnum.Deny)
                {
                    RefireDelayedUntil = LastFired.AddMilliseconds(ctx.EvaluateNumericExpression(TriggerContextLogger, p, _RefirePeriodExpression));
                    AddToLog(p, RealPlugin.DebugLevelEnum.Info, I18n.Translate("internal/Trigger/delayingrefire", "Delaying trigger '{0}' refire to {1}", LogName, RefireDelayedUntil));
                }
                else
                {
                    RefireDelayedUntil = DateTime.MinValue;
                }
                DateTime curtime = DateTime.Now;
                if (_Scheduling == SchedulingEnum.FromLastAction)
                {
                    // get the last queued action as curTime
                    lock (ctx.plug.ActionQueue)
                    {
                        var ixy = from ax in ctx.plug.ActionQueue
                                  where ax.ctx.trig.Id == Id
                                  orderby ax.when descending
                                  select ax;
                        if (ixy.Count() > 0)
                        {
                            curtime = ixy.ElementAt(0).when;
                            AddToLog(p, RealPlugin.DebugLevelEnum.Info, I18n.Translate("internal/Trigger/lastactionfound", "Last action for trigger '{0}' found at {1}", LogName, curtime));
                        }
                    }
                }
                else if (_Scheduling == SchedulingEnum.FromRefirePeriod)
                {
                    curtime = prevLastFired.AddMilliseconds(ctx.EvaluateNumericExpression(TriggerContextLogger, p, _RefirePeriodExpression));
                    if (curtime < LastFired)
                    {
                        curtime = LastFired;
                        AddToLog(p, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Trigger/beforelastfired", "Current time is before last fired for trigger '{0}'", LogName));
                    }
                }
                if (_PrevActions == PrevActionsEnum.Interrupt)
                {
                    int exx = 0;
                    lock (ctx.plug.ActionQueue)
                    {
                        var ixy = from ax in ctx.plug.ActionQueue
                                  where ax.ctx.trig.Id == Id
                                  select ax;
                        if (ixy.Count() > 0)
                        {
                            List<RealPlugin.QueuedAction> rems = new List<RealPlugin.QueuedAction>();
                            rems.AddRange(ixy);
                            foreach (RealPlugin.QueuedAction qa in rems)
                            {
                                ctx.plug.ActionQueue.Remove(qa);
                                exx++;
                            }
                        }
                    }
                    if (exx > 0)
                    {
                        if (_PrevActionsRefire == RefireEnum.Deny)
                        {
                            AddToLog(p, RealPlugin.DebugLevelEnum.Info, I18n.Translate("internal/Trigger/removefromqueuenorefire", "Removed {0} instance(s) of trigger '{1}' actions from queue, refire denied", exx, LogName));
                            return false;
                        }
                        else
                        {
                            AddToLog(p, RealPlugin.DebugLevelEnum.Info, I18n.Translate("internal/Trigger/removefromqueue", "Removed {0} instance(s) of trigger '{1}' actions from queue", exx, LogName));
                        }
                    }
                }
                else if (_PrevActionsRefire == RefireEnum.Deny)
                {
                    int exx = 0;
                    lock (ctx.plug.ActionQueue)
                    {
                        var ixy = from ax in ctx.plug.ActionQueue
                                  where ax.ctx.trig.Id == Id
                                  select ax;
                        exx = ixy.Count();
                    }
                    if (exx > 0)
                    {
                        AddToLog(p, RealPlugin.DebugLevelEnum.Info, I18n.Translate("internal/Trigger/refiredenied", "{0} instance(s) of trigger '{1}' actions in queue, refire denied", exx, LogName));
                        return false;
                    }
                }
                QueueActions(ctx, curtime, mtx);
                return true;
            }
            catch (Exception ex)
            {
                AddToLog(p, RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/Trigger/firingexception", "Trigger '{0}' didn't fire due to exception: {1}", LogName, ex.ToString()));
            }
            return false;
        }

        public void TriggerContextLogger(object o, string msg)
        {
            AddToLog((RealPlugin)o, RealPlugin.DebugLevelEnum.Verbose, msg);
        }

        internal void CopySettingsTo(Trigger t)
        {
            t._Source = _Source;
            t._Sequential = _Sequential;
            t.Enabled = Enabled;
            t.Actions.Clear();
            var ix = from tx in Actions
                     orderby tx.OrderNumber ascending
                     select tx;
            foreach (Action a in ix)
            {
                Action b = new Action();
                a.CopySettingsTo(b);
                t.Actions.Add(b);
            }
            t._Condition = (ConditionGroup)_Condition.Duplicate();
            t._IsReadme = _IsReadme;
            t.Name = Name;
            t.Id = Id;
            t._RegularExpression = _RegularExpression;
            t._DebugLevel = _DebugLevel;
            t._PrevActions = _PrevActions;
            t._PrevActionsRefire = _PrevActionsRefire;
            t._Scheduling = _Scheduling;
            t._PeriodRefire = _PeriodRefire;
            t._RefirePeriodExpression = _RefirePeriodExpression;
            t._MutexToCapture = _MutexToCapture;
            t._EditAutofire = _EditAutofire;
            t._EditAutofireAllowCondition = _EditAutofireAllowCondition;
            t._Description = _Description;
            t._TestInput = _TestInput;
        }

    }

}
