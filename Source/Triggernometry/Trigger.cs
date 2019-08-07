using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace Triggernometry
{

    public class Trigger
    {

		internal Folder Parent { get; set; }

        [XmlAttribute]
        public bool Enabled { get; set; }		
        public List<Action> Actions { get; set; }

        public enum TriggerSourceEnum
        {
            Log,
            FFXIVNetwork
        }

        [XmlAttribute]
        public TriggerSourceEnum Source { get; set; }

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

        [XmlAttribute]
        public string Name { get; set; }

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
                string temp = Plugin.UnserializeInvalidXmlCharacters(value);
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
						rex = new Regex(RegularExpression);
					}
					catch (Exception)
					{
						rex = null;
					}
				}
			}
		}

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

        [XmlAttribute]
        public Plugin.DebugLevelEnum DebugLevel { get; set; } = Plugin.DebugLevelEnum.Inherit;

        [XmlAttribute]
        public PrevActionsEnum PrevActions { get; set; } // option1a
        [XmlAttribute]
        public RefireEnum PrevActionsRefire { get; set; } // option1b
        [XmlAttribute]
        public SchedulingEnum Scheduling { get; set; } // option2
        [XmlAttribute]
        public RefireEnum PeriodRefire { get; set; } // option3
        [XmlAttribute]
        public string RefirePeriodExpression { get; set; }

        private string _Description;
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
                    PrevActionsRefire = RefireEnum.Allow;
                }
                else
                {
                    PrevActionsRefire = RefireEnum.Deny;
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
                    PeriodRefire = RefireEnum.Deny;
                }
                else
                {
                    PeriodRefire = RefireEnum.Allow;
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
                RefirePeriodExpression = value;
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

        public Trigger()
        {
            Actions = new List<Action>();
            Conditions = new EventList<Triggernometry.Condition>();
            Id = Guid.NewGuid();
            Source = TriggerSourceEnum.Log;
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

        internal Plugin.DebugLevelEnum GetDebugLevel(Plugin p)
        {
            if (DebugLevel == Plugin.DebugLevelEnum.Inherit)
            {
                if (p.cfg != null)
                {
                    return p.cfg.DebugLevel;
                }
                else
                {
                    return Plugin.DebugLevelEnum.Verbose;
                }
            }
            return DebugLevel;
        }

        internal void AddToLog(Plugin p, Plugin.DebugLevelEnum level, string message)
        {
            Plugin.DebugLevelEnum dx = GetDebugLevel(p);
            if (level > dx)
            {
                return;
            }
            p.UnfilteredAddToLog(level, message);
        }

        internal void Fire(Plugin p, Context ctx)
		{
            if ((ctx.force & Action.TriggerForceTypeEnum.SkipConditions) == 0)
            {
                if (Condition != null && Condition.Enabled == true)
                {
                    if (Condition.CheckCondition(ctx, TriggerContextLogger, ctx.plug) == false)
                    {
                        AddToLog(p, Plugin.DebugLevelEnum.Info, I18n.Translate("internal/Trigger/trignotfired", "Trigger '{0}' not fired, condition not met", Name));
                        return;
                    }
                }
            }
            DateTime prevLastFired = LastFired;
            LastFired = DateTime.Now;
            if (PeriodRefire == RefireEnum.Deny)
            {
                RefireDelayedUntil = LastFired.AddMilliseconds(ctx.EvaluateNumericExpression(TriggerContextLogger, p, RefirePeriodExpression));
                AddToLog(p, Plugin.DebugLevelEnum.Info, I18n.Translate("internal/Trigger/delayingrefire", "Delaying trigger '{0}' refire to {1}", Name, RefireDelayedUntil));
            }
            else
            {
                RefireDelayedUntil = DateTime.MinValue;
            }
            DateTime curtime = DateTime.Now;
            if (Scheduling == SchedulingEnum.FromLastAction)
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
                        AddToLog(p, Plugin.DebugLevelEnum.Info, I18n.Translate("internal/Trigger/lastactionfound", "Last action for trigger '{0}' found at {1}", Name, curtime));
                    }
                }
            }
            else if (Scheduling == SchedulingEnum.FromRefirePeriod)
            {
                curtime = prevLastFired.AddMilliseconds(ctx.EvaluateNumericExpression(TriggerContextLogger, p, RefirePeriodExpression));
                if (curtime < LastFired)
                {
                    curtime = LastFired;
                    AddToLog(p, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Trigger/beforelastfired", "Current time is before last fired for trigger '{0}'", Name));
                }
            }
            if (PrevActions == PrevActionsEnum.Interrupt)
            {
                int exx = 0;
                lock (ctx.plug.ActionQueue)
                {
                    var ixy = from ax in ctx.plug.ActionQueue
                                where ax.ctx.trig.Id == Id
                                select ax;
                    if (ixy.Count() > 0)
                    {
                        List<Plugin.QueuedAction> rems = new List<Plugin.QueuedAction>();
                        rems.AddRange(ixy);
                        foreach (Plugin.QueuedAction qa in rems)
                        {
                            ctx.plug.ActionQueue.Remove(qa);
                            exx++;
                        }
                    }
                }
                if (exx > 0)
                {
                    if (PrevActionsRefire == RefireEnum.Deny)
                    {
                        AddToLog(p, Plugin.DebugLevelEnum.Info, I18n.Translate("internal/Trigger/removefromqueuenorefire", "Removed {0} instance(s) of trigger '{1}' actions from queue, refire denied", exx, Name));
                        return;
                    }
                    else
                    {
                        AddToLog(p, Plugin.DebugLevelEnum.Info, I18n.Translate("internal/Trigger/removefromqueue", "Removed {0} instance(s) of trigger '{1}' actions from queue", exx, Name));
                    }                    
                }
            }
            else if (PrevActionsRefire == RefireEnum.Deny)
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
                    AddToLog(p, Plugin.DebugLevelEnum.Info, I18n.Translate("internal/Trigger/refiredenied", "{0} instance(s) of trigger '{1}' actions in queue, refire denied", exx, Name));
                    return;
                }
            }
            var ix = from tx in Actions
                     orderby tx.OrderNumber ascending
                     select tx;
            foreach (Action a in ix)
			{
                curtime = curtime.AddMilliseconds(ctx.EvaluateNumericExpression(TriggerContextLogger, p, a.ExecutionDelayExpression));
				if (a._Enabled == true)
				{
					p.QueueAction(ctx, this, a, curtime);
				}
			}			
		}

        public void TriggerContextLogger(object o, string msg)
        {
            AddToLog((Plugin)o, Plugin.DebugLevelEnum.Verbose, msg);
        }

    }

}
