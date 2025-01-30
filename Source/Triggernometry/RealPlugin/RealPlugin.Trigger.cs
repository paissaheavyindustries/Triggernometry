using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Triggernometry
{

    public partial class RealPlugin
    {

        internal List<Trigger> Triggers = new List<Trigger>();
        internal List<Trigger> ActiveTextTriggers = new List<Trigger>();
        internal List<Trigger> ActiveFFXIVNetworkTriggers = new List<Trigger>();
        internal List<Trigger> ActiveACTTriggers = new List<Trigger>();
        internal List<Trigger> ActiveEndpointTriggers = new List<Trigger>();

        internal void AddTrigger(Trigger t, bool parentenable)
        {
            lock (Triggers)
            {
                Triggers.Add(t);
                if (t.Enabled == true && parentenable == true)
                {
                    switch (t._Source)
                    {
                        case Trigger.TriggerSourceEnum.Log:
                            lock (ActiveTextTriggers)
                            {
                                ActiveTextTriggers.Add(t);
                            }
                            break;
                        case Trigger.TriggerSourceEnum.FFXIVNetwork:
                            lock (ActiveFFXIVNetworkTriggers)
                            {
                                ActiveFFXIVNetworkTriggers.Add(t);
                            }
                            break;
                        case Trigger.TriggerSourceEnum.ACT:
                            lock (ActiveACTTriggers)
                            {
                                ActiveACTTriggers.Add(t);
                            }
                            break;
                        case Trigger.TriggerSourceEnum.Endpoint:
                            lock (ActiveEndpointTriggers)
                            {
                                ActiveEndpointTriggers.Add(t);
                            }
                            break;
                        case Trigger.TriggerSourceEnum.None:
                            break;
                    }
                }
            }
        }

        internal void SourceChange(Trigger t, Trigger.TriggerSourceEnum oldSource, Trigger.TriggerSourceEnum newSource)
        {
            if (t.Enabled == true && t.Parent != null && t.Parent.ParentsEnabled() == true)
            {
                switch (oldSource)
                {
                    case Trigger.TriggerSourceEnum.Log:
                        lock (ActiveTextTriggers)
                        {
                            ActiveTextTriggers.Remove(t);
                        }
                        break;
                    case Trigger.TriggerSourceEnum.FFXIVNetwork:
                        lock (ActiveFFXIVNetworkTriggers)
                        {
                            ActiveFFXIVNetworkTriggers.Remove(t);
                        }
                        break;
                    case Trigger.TriggerSourceEnum.ACT:
                        lock (ActiveACTTriggers)
                        {
                            ActiveACTTriggers.Remove(t);
                        }
                        break;
                    case Trigger.TriggerSourceEnum.Endpoint:
                        lock (ActiveEndpointTriggers)
                        {
                            ActiveEndpointTriggers.Remove(t);
                        }
                        break;
                    case Trigger.TriggerSourceEnum.None:
                        break;
                }
                switch (newSource)
                {
                    case Trigger.TriggerSourceEnum.Log:
                        lock (ActiveTextTriggers)
                        {
                            ActiveTextTriggers.Add(t);
                        }
                        break;
                    case Trigger.TriggerSourceEnum.FFXIVNetwork:
                        lock (ActiveFFXIVNetworkTriggers)
                        {
                            ActiveFFXIVNetworkTriggers.Add(t);
                        }
                        break;
                    case Trigger.TriggerSourceEnum.ACT:
                        lock (ActiveACTTriggers)
                        {
                            ActiveACTTriggers.Add(t);
                        }
                        break;
                    case Trigger.TriggerSourceEnum.Endpoint:
                        lock (ActiveEndpointTriggers)
                        {
                            ActiveEndpointTriggers.Add(t);
                        }
                        break;
                    case Trigger.TriggerSourceEnum.None:
                        break;
                }
            }
        }

        internal void RemoveTrigger(Trigger t)
        {
            lock (Triggers)
            {
                switch (t._Source)
                {
                    case Trigger.TriggerSourceEnum.Log:
                        lock (ActiveTextTriggers)
                        {
                            if (ActiveTextTriggers.Contains(t) == true)
                            {
                                ActiveTextTriggers.Remove(t);
                            }
                        }
                        break;
                    case Trigger.TriggerSourceEnum.FFXIVNetwork:
                        lock (ActiveFFXIVNetworkTriggers)
                        {
                            if (ActiveFFXIVNetworkTriggers.Contains(t) == true)
                            {
                                ActiveFFXIVNetworkTriggers.Remove(t);
                            }
                        }
                        break;
                    case Trigger.TriggerSourceEnum.ACT:
                        lock (ActiveACTTriggers)
                        {
                            if (ActiveACTTriggers.Contains(t) == true)
                            {
                                ActiveACTTriggers.Remove(t);
                            }
                        }
                        break;
                    case Trigger.TriggerSourceEnum.Endpoint:
                        lock (ActiveEndpointTriggers)
                        {
                            if (ActiveEndpointTriggers.Contains(t) == true)
                            {
                                ActiveEndpointTriggers.Remove(t);
                            }
                        }
                        break;
                    case Trigger.TriggerSourceEnum.None:
                        break;
                }
                Triggers.Remove(t);
            }
        }

        internal void TriggerEnabled(Trigger t)
        {
            switch (t._Source)
            {
                case Trigger.TriggerSourceEnum.Log:
                    lock (ActiveTextTriggers)
                    {
                        if (ActiveTextTriggers.Contains(t) == false)
                        {
                            FilteredAddToLog(DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/trigaddbook", "Trigger '{0}' added to bookkeeping", t.LogName));
                            ActiveTextTriggers.Add(t);
                            return;
                        }
                    }
                    break;
                case Trigger.TriggerSourceEnum.FFXIVNetwork:
                    lock (ActiveFFXIVNetworkTriggers)
                    {
                        if (ActiveFFXIVNetworkTriggers.Contains(t) == false)
                        {
                            FilteredAddToLog(DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/trigaddbook", "Trigger '{0}' added to bookkeeping", t.LogName));
                            ActiveFFXIVNetworkTriggers.Add(t);
                            return;
                        }
                    }
                    break;
                case Trigger.TriggerSourceEnum.ACT:
                    lock (ActiveACTTriggers)
                    {
                        if (ActiveACTTriggers.Contains(t) == false)
                        {
                            FilteredAddToLog(DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/trigaddbook", "Trigger '{0}' added to bookkeeping", t.LogName));
                            ActiveACTTriggers.Add(t);
                            return;
                        }
                    }
                    break;
                case Trigger.TriggerSourceEnum.Endpoint:
                    lock (ActiveEndpointTriggers)
                    {
                        if (ActiveEndpointTriggers.Contains(t) == false)
                        {
                            FilteredAddToLog(DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/trigaddbook", "Trigger '{0}' added to bookkeeping", t.LogName));
                            ActiveEndpointTriggers.Add(t);
                            return;
                        }
                    }
                    break;
                case Trigger.TriggerSourceEnum.None:
                    break;
            }
        }

        internal void TriggerDisabled(Trigger t)
        {
            switch (t._Source)
            {
                case Trigger.TriggerSourceEnum.Log:
                    lock (ActiveTextTriggers)
                    {
                        if (ActiveTextTriggers.Contains(t) == true)
                        {
                            FilteredAddToLog(DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/trigrembook", "Trigger '{0}' removed from bookkeeping", t.LogName));
                            RemoveAurasFromTrigger(t);
                            ActiveTextTriggers.Remove(t);
                            return;
                        }
                    }
                    break;
                case Trigger.TriggerSourceEnum.FFXIVNetwork:
                    lock (ActiveFFXIVNetworkTriggers)
                    {
                        if (ActiveFFXIVNetworkTriggers.Contains(t) == true)
                        {
                            FilteredAddToLog(DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/trigrembook", "Trigger '{0}' removed from bookkeeping", t.LogName));
                            RemoveAurasFromTrigger(t);
                            ActiveFFXIVNetworkTriggers.Remove(t);
                            return;
                        }
                    }
                    break;
                case Trigger.TriggerSourceEnum.ACT:
                    lock (ActiveACTTriggers)
                    {
                        if (ActiveACTTriggers.Contains(t) == true)
                        {
                            FilteredAddToLog(DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/trigrembook", "Trigger '{0}' removed from bookkeeping", t.LogName));
                            RemoveAurasFromTrigger(t);
                            ActiveACTTriggers.Remove(t);
                            return;
                        }
                    }
                    break;
                case Trigger.TriggerSourceEnum.Endpoint:
                    lock (ActiveEndpointTriggers)
                    {
                        if (ActiveEndpointTriggers.Contains(t) == true)
                        {
                            FilteredAddToLog(DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/trigrembook", "Trigger '{0}' removed from bookkeeping", t.LogName));
                            RemoveAurasFromTrigger(t);
                            ActiveEndpointTriggers.Remove(t);
                            return;
                        }
                    }
                    break;
                case Trigger.TriggerSourceEnum.None:
                    RemoveAurasFromTrigger(t);
                    break;
            }
        }

        internal void TestTrigger(Trigger t, LogEvent le, Action.TriggerForceTypeEnum force)
        {
            lock (t)
            {
                Match m = null;
                if ((force & Action.TriggerForceTypeEnum.SkipRegexp) == 0)
                {
                    m = t.CheckMatch(le.Text);
                    if (m == null)
                    {
                        return;
                    }
                    else
                    {
                        t.AddToLog(this, DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/trigmatches", "Trigger '{0}' matches log line '{1}'", t.LogName, le.Text));
                    }
                }
                if ((force & Action.TriggerForceTypeEnum.SkipActive) == 0)
                {
                    if (t.Enabled == false)
                    {
                        t.AddToLog(this, DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/trignotactive", "Trigger '{0}' is not active for firing", t.LogName));
                        return;
                    }
                }
                if ((force & Action.TriggerForceTypeEnum.SkipParent) == 0)
                {
                    Folder.FilterFailReason reason = t.Parent.PassesFilter(le);
                    if (reason != Folder.FilterFailReason.Passed)
                    {
                        if (reason != Folder.FilterFailReason.NotEnabled)
                        {
                            t.AddToLog(this, DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/trigparentfail", "Trigger '{0}' doesn't pass parent folder '{1}' filter(s): {2}", t.LogName, t.Parent.Name, reason.ToString()));
                        }
                        return;
                    }
                }
                if ((force & Action.TriggerForceTypeEnum.SkipRefire) == 0)
                {
                    if (t._PeriodRefire == Trigger.RefireEnum.Deny && DateTime.Now < t.RefireDelayedUntil)
                    {
                        t.AddToLog(this, DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/trigrefirefail", "Trigger '{0}' refire delayed until {1}", t.LogName, FormatDateTime(t.RefireDelayedUntil)));
                        return;
                    }
                }
                t.AddToLog(this, DebugLevelEnum.Info, I18n.Translate("internal/Plugin/trigfiring", "Firing trigger '{0}'", t.LogName));
                Context ctx = new Context();
                ctx.plug = this;
                ctx.trig = t;
                ctx.soundhook = SoundPlaybackSmart;
                ctx.ttshook = TtsPlaybackSmart;
                if ((force & Action.TriggerForceTypeEnum.SkipRegexp) == 0)
                {
                    foreach (int idx in t.rex.GetGroupNumbers())
                    {
                        ctx.numgroups.Add(m.Groups[idx].Value);
                        t.AddToLog(this, DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/debugnumgroup", "Trigger '{0}' numbered group {1}: {2}", t.LogName, idx, m.Groups[idx].Value));
                    }
                    foreach (string sdx in t.rex.GetGroupNames())
                    {
                        ctx.namedgroups[sdx] = m.Groups[sdx].Value;
                        t.AddToLog(this, DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/debugnamedgroup", "Trigger '{0}' named group '{1}': {2}", t.LogName, sdx, m.Groups[sdx].Value));
                    }
                }
                ctx.namedgroups["_zone"] = le.ZoneName;
                ctx.namedgroups["_event"] = le.Text;
                if (le.TestMode == true && le.ZoneId != "")
                {
                    ctx.zoneIdOverride = le.ZoneId;
                }
                ctx.triggered = DateTime.UtcNow;
                ctx.namedgroups["_timestamp"] = "" + (long)(ctx.triggered - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
                ctx.namedgroups["_timestampms"] = "" + (long)(ctx.triggered - new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds;
                ctx.force = force;
                t.Fire(this, ctx, null);
            }
        }

    }
}
