using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Triggernometry.CustomControls;
using Triggernometry.Utilities;
using Triggernometry.Variables;

namespace Triggernometry
{

    public partial class RealPlugin
    {

        internal Thread ActionQueueThread = null;
        internal List<QueuedAction> ActionQueue = new List<QueuedAction>();
        internal AutoResetEvent ActionUpdateEvent = null;
        private Int64 curOrdinal = 0;
        internal object QueueProcessingLock = new object();
        internal bool QueueProcessing = true;

        internal delegate void ActionExecutionHook(Context ctx, Action a);

        private void InitActionQueue()
        {
            ActionQueueThread = new Thread(new ThreadStart(ActionThreadProc));
            ActionQueueThread.Name = "ActionQueueThread";
            ActionQueueThread.Start();
        }

        private void DeinitActionQueue()
        {
            if (ActionQueueThread != null)
            {
                if (ActionQueueThread.Join(5000) == false)
                {
                    ActionQueueThread.Abort();
                }
                ActionQueueThread = null;
            }
            ActionUpdateEvent?.Dispose();
            ActionUpdateEvent = null;
        }

        internal class QueuedAction : IComparable
        {

            internal DateTime when { get; set; }
            internal Int64 ordinal { get; set; }
            internal MutexInformation mutex { get; set; }
            internal Action act { get; set; }
            internal Context ctx { get; set; }
            internal bool releaseMutex { get; set; } = false;

            public QueuedAction(DateTime when, Int64 ordinal, MutexInformation mtx, Action act, Context ctx, bool releaseMutex)
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
                QueuedAction b = (QueuedAction)o;
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

        internal void ClearActionQueue()
        {
            lock (ActionQueue) // verified
            {
                ActionQueue.Clear();
            }
        }

        internal void CancelAllQueuedActionsFromTrigger(Trigger t)
        {
            int remd = 0;
            lock (ActionQueue)
            {
                var ix = from ax in ActionQueue
                         where ax.ctx.trig == t
                         select ax;
                if (ix.Count() > 0)
                {
                    List<QueuedAction> rems = new List<QueuedAction>();
                    rems.AddRange(ix);
                    foreach (QueuedAction qa in rems)
                    {
                        ActionQueue.Remove(qa);
                        remd++;
                    }
                    ActionQueue.Sort();
                    ActionUpdateEvent.Set();
                }
            }
            t.AddToLog(this, DebugLevelEnum.Info, I18n.Translate("internal/Plugin/queuedactscancelled", "{0} queued action(s) from trigger '{1}' cancelled", remd, t.LogName));
        }

        internal Action QueueActions(Context ctx, DateTime startingFrom, IEnumerable<Action> actions, bool sequential, RealPlugin.MutexInformation mtx, Context.LoggerDelegate logger)
        {
            Action lastAction = null;
            var sortedActions = actions.OrderBy(a => a.OrderNumber);
            var finalAction = sortedActions.LastOrDefault();
            if (sequential == false)
            {
                foreach (Action action in sortedActions)
                {
                    if (action._Enabled == true)
                    {
                        startingFrom = startingFrom.AddMilliseconds(ctx.EvaluateNumericExpression(logger, this, action._ExecutionDelayExpression));
                        QueueAction(ctx, ctx.trig, mtx, action, startingFrom, finalAction == action);
                        lastAction = action;
                    }
                }
            }
            else
            {
                Action prev = null;
                Action first = null;
                foreach (Action action in sortedActions)
                {
                    if (action._Enabled == false)
                    {
                        continue;
                    }
                    lastAction = action;
                    if (prev != null)
                    {
                        prev.NextAction = action;
                    }
                    else
                    {
                        first = action;
                        startingFrom = startingFrom.AddMilliseconds(ctx.EvaluateNumericExpression(logger, this, action._ExecutionDelayExpression));
                    }
                    prev = action;
                }
                if (first != null)
                {
                    QueueAction(ctx, ctx.trig, mtx, first, startingFrom, false);
                }
            }
            return lastAction;
        }

        public void QueueAction(Context ctx, Trigger t, MutexInformation m, Action a, DateTime when, bool releaseMutex)
        {
            lock (ActionQueue) // verified
            {
                if (a._RefireRequeue == false || a._RefireInterrupt == true)
                {
                    var ix = from ax in ActionQueue
                             where ax.act.Id == a.Id
                             select ax;
                    if (ix.Count() > 0)
                    {
                        if (a._RefireInterrupt == true)
                        {
                            List<QueuedAction> rems = new List<QueuedAction>();
                            rems.AddRange(ix);
                            int exx = 0;
                            foreach (QueuedAction qa in rems)
                            {
                                ActionQueue.Remove(qa);
                                exx++;
                            }
                            if (exx > 0)
                            {
                                a.AddToLog(ctx, DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/actionqueuerem", "Removed {0} instance(s) of trigger '{1}' action '{2}' from queue", exx, t.LogName, a.GetDescription(ctx)));
                            }
                        }
                        if (a._RefireRequeue == false)
                        {
                            a.AddToLog(ctx, DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/actionqueuefail", "Trigger '{0}' action '{1}' not queued, refire requeue disabled", t.LogName, a.GetDescription(ctx)));
                            if (releaseMutex == true && m != null)
                            {
                                m.Release(ctx);
                            }
                            return;
                        }
                    }
                }
                Int64 newOrdinal;
                lock (this)
                {
                    newOrdinal = curOrdinal;
                    curOrdinal++;
                }
                a.AddToLog(ctx, DebugLevelEnum.Info, I18n.Translate("internal/Plugin/actionqueued", "Queuing trigger '{0}' action '{1}' to {2} slot {3}", t.LogName, a.GetDescription(ctx), FormatDateTime(when), newOrdinal));
                ActionQueue.Add(new QueuedAction(when, newOrdinal, m, a, ctx, releaseMutex));
                ActionQueue.Sort();
                ActionUpdateEvent.Set();
            }
        }

        internal bool ReadyForOperation()
        {
            return mainform?.IsHandleCreated == true && ActInitedHook?.Invoke() == true;
        }

        internal void ActionThreadProc()
        {
            int timeout = Timeout.Infinite;
            WaitHandle[] wh = new WaitHandle[2];
            wh[0] = ExitEvent;
            wh[1] = ActionUpdateEvent;
            if (ReadyForOperation() == false)
            {
                //FilteredAddToLog(DebugLevelEnum.Warning, I18n.Translate("internal/Plugin/invalidwindowhandle", "No valid window handle yet, waiting for it to be created"));
                do
                {
                    Thread.Sleep(100);
                } while (ReadyForOperation() == false);
            }
            if (cfg.StartupTriggerId != Guid.Empty)
            {
                if (cfg.StartupTriggerType == Configuration.StartupTriggerTypeEnum.Trigger)
                {
                    Trigger t = GetTriggerById(cfg.StartupTriggerId, null);
                    if (t != null)
                    {
                        LogEvent le = new LogEvent();
                        le.Text = "";
                        le.ZoneName = "";
                        le.Timestamp = DateTime.Now;
                        TestTrigger(t, le, Action.TriggerForceTypeEnum.SkipAll);
                    }
                }
                if (cfg.StartupTriggerType == Configuration.StartupTriggerTypeEnum.Folder)
                {
                    Folder f = GetFolderById(cfg.StartupTriggerId, null);
                    if (f != null)
                    {
                        LogEvent le = new LogEvent();
                        le.Text = "";
                        le.ZoneName = "";
                        le.Timestamp = DateTime.Now;
                        foreach (Trigger tx in f.Triggers)
                        {
                            TestTrigger(tx, le, Action.TriggerForceTypeEnum.SkipAll);
                        }
                    }
                }
            }
            while (true)
            {
                switch (WaitHandle.WaitAny(wh, timeout))
                {
                    case WaitHandle.WaitTimeout:
                        {
                            QueuedAction tp = null;
                            lock (ActionQueue) // verified
                            {
                                if (ActionQueue.Count > 0)
                                {
                                    tp = ActionQueue[0];
                                    ActionQueue.RemoveAt(0);
                                }
                            }
                            if (tp != null)
                            {
                                tp.act.Execute(tp, tp.ctx);
                                goto case 1;
                            }
                            else
                            {
                                timeout = Timeout.Infinite;
                                continue;
                            }
                        }
                    case 0:
                        {
                            return;
                        }
                    case 1:
                        {
                            lock (ActionQueue) // verified
                            {
                                lock (QueueProcessingLock) // verified
                                {
                                    if (QueueProcessing == false)
                                    {
                                        timeout = Timeout.Infinite;
                                        break;
                                    }
                                }
                                if (ActionQueue.Count > 0)
                                {
                                    timeout = (int)Math.Ceiling((ActionQueue[0].when - DateTime.Now).TotalMilliseconds);
                                    if (timeout < 0)
                                    {
                                        timeout = 0;
                                    }
                                }
                                else
                                {
                                    timeout = Timeout.Infinite;
                                }
                            }
                        }
                        break;
                }
            }
        }


        #region Mutex

        internal Dictionary<string, MutexInformation> mutexes = new Dictionary<string, MutexInformation>();

        internal class MutexTicket : IDisposable
        {

            internal Context ctx { get; set; }
            internal ManualResetEvent ev { get; set; }

            internal MutexTicket(Context c)
            {
                ctx = c;
                ev = new ManualResetEvent(false);
            }

            public void Dispose()
            {
                if (ev != null)
                {
                    ev.Dispose();
                    ev = null;
                }
            }

        }

        public class MutexInformation
        {

            private string name { get; set; }
            internal int refCount { get; set; }
            internal Context heldBy { get; set; }
            internal List<MutexTicket> acquireQueue { get; set; }

            internal MutexInformation(string name)
            {
                this.name = name;
                refCount = 0;
                heldBy = null;
                acquireQueue = new List<MutexTicket>();
            }

            internal MutexTicket QueueForAcquisition(Context ctx)
            {
                System.Diagnostics.Debug.WriteLine("### {0} - Queuing acquisition for context: {1}", this.name, ctx.ToString());
                MutexTicket m = new MutexTicket(ctx);
                lock (this)
                {
                    acquireQueue.Add(m);
                }
                System.Diagnostics.Debug.WriteLine("### {0} - Queued acquisition {1} for context: {2}", this.name, m.GetHashCode(), ctx.ToString());
                return m;
            }

            internal void Acquire(Context ctx)
            {
                System.Diagnostics.Debug.WriteLine("### {0} - Acquiring for context: {1}", this.name, ctx.ToString());
                using (MutexTicket m = QueueForAcquisition(ctx))
                {
                    Acquire(ctx, m);
                    System.Diagnostics.Debug.WriteLine("### {0} - Acquired {1} for context: {2}", this.name, m.GetHashCode(), ctx.ToString());
                }
            }

            internal void Acquire(Context ctx, MutexTicket m)
            {
                DateTime start = DateTime.Now;
                string ownername = "";
                bool autoget = false;
                System.Diagnostics.Debug.WriteLine("### {0} - Acquisition {1} pending stage 1 for context: {2}", this.name, m.GetHashCode(), ctx.ToString());
                lock (this)
                {
                    if (heldBy == null)
                    {
                        MutexTicket first = acquireQueue.ElementAt(0);
                        if (first == m)
                        {
                            m.ev.Set();
                            refCount++;
                            heldBy = ctx;
                            autoget = true;
                        }
                    }
                    else if (heldBy.id == ctx.id)
                    {
                        m.ev.Set();
                        refCount++;
                        autoget = true;
                    }
                    else
                    {
                    }
                    if (autoget == false)
                    {
                        ownername = heldBy != null ? heldBy.ToString() : null;
                    }
                }
                while (m.ev.WaitOne(5000) == false)
                {
                    if (ctx.plug != null)
                    {
                        ctx.plug.FilteredAddToLog(DebugLevelEnum.Warning, I18n.Translate("internal/Plugin/mutexdelayed", "Context '{0}' has been waiting for mutex '{1}' on {2} for {3} ms, current owner is '{4}'", ctx.ToString(), name, m.GetHashCode(), (DateTime.Now - start).TotalMilliseconds, ownername));
                    }
                }
                System.Diagnostics.Debug.WriteLine("### {0} - Acquisition {1} pending stage 2 for context: {2}", this.name, m.GetHashCode(), ctx.ToString());
                lock (this)
                {
                    System.Diagnostics.Debug.WriteLine("### {0} - Acquisition {1} pending stage 3 for context: {2}", this.name, m.GetHashCode(), ctx.ToString());
                    acquireQueue.Remove(m);
                    if (autoget == false)
                    {
                        if (heldBy != null)
                        {
                            throw new InvalidOperationException(I18n.Translate("internal/Plugin/invalidacquiremutex", "Tried to acquire mutex '{0}' belonging to context '{1}' on context '{2}'", name, heldBy.ToString(), ctx.ToString()));
                        }
                        heldBy = ctx;
                        refCount++;
                        System.Diagnostics.Debug.WriteLine("### {0} - New acquisition {1} for context: {2}", this.name, m.GetHashCode(), ctx.ToString());
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("### {0} - Autoget acquisition {1} for context: {2}", this.name, m.GetHashCode(), ctx.ToString());
                    }
                }
                System.Diagnostics.Debug.WriteLine("### {0} - Acquisition {1} pending stage 4 for context: {2}", this.name, m.GetHashCode(), ctx.ToString());
            }

            internal void Release(Context ctx)
            {
                System.Diagnostics.Debug.WriteLine("### {0} - Releasing for context: {1}", this.name, ctx.ToString());
                lock (this)
                {
                    if (heldBy == null || heldBy.id != ctx.id)
                    {
                        throw new InvalidOperationException(I18n.Translate("internal/Plugin/releaseunownedmutex", "Tried to release unowned mutex '{0}' from context '{1}'", name, ctx.ToString()));
                    }
                    refCount--;
                    if (refCount == 0)
                    {
                        System.Diagnostics.Debug.WriteLine("### {0} - Fully released by context: {1}", this.name, ctx.ToString());
                        heldBy = null;
                        WakeupNext();
                    }
                }
                System.Diagnostics.Debug.WriteLine("### {0} - Released for context: {1}", this.name, ctx.ToString());
            }

            internal void ForceRelease()
            {
                System.Diagnostics.Debug.WriteLine("### {0} - Releasing by force", this.name);
                lock (this)
                {
                    refCount = 0;
                    heldBy = null;
                    WakeupNext();
                }
                System.Diagnostics.Debug.WriteLine("### {0} - Released by force", this.name);
            }

            private void WakeupNext()
            {
                if (acquireQueue.Count > 0)
                {
                    MutexTicket m = acquireQueue.ElementAt(0);
                    System.Diagnostics.Debug.WriteLine("### {0} - Waking up next context in queue : {1}", this.name, m.ctx.ToString());
                    m.ev.Set();
                }
            }

        }

        internal MutexInformation GetMutex(string name)
        {
            MutexInformation mi = null;
            lock (mutexes)
            {
                if (mutexes.ContainsKey(name) == false)
                {
                    mutexes[name] = new MutexInformation(name);
                }
                mi = mutexes[name];
            }
            return mi;
        }

        #endregion
    }
}
