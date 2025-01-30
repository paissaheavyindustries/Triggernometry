using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Trigger operations
    /// </summary>
    [ActionCategory(ActionCategory.CategoryTypeEnum.Programming)]
    [XmlRoot(ElementName = "TriggerOperation")]
    public class ActionTriggerOperation : ActionBase
    {

        #region Properties

        /// <summary>
        /// Trigger operations
        /// </summary>
        private enum OperationEnum
        {
            /// <summary>
            /// Fire trigger
            /// </summary>
            FireTrigger,
            /// <summary>
            /// Cancel all queued actions from trigger
            /// </summary>
            CancelTrigger,
            /// <summary>
            /// Enable trigger
            /// </summary>
            EnableTrigger,
            /// <summary>
            /// Disable trigger
            /// </summary>
            DisableTrigger,
            /// <summary>
            /// Cancel all queued actions from all triggers
            /// </summary>
            CancelAllTrigger
        }

        /// <summary>
        /// Trigger force firing flags
        /// </summary>
        [Flags]
        private enum ForceEnum
        {
            /// <summary>
            /// Don't skip anything, all restrictions in effect
            /// </summary>
            NoSkip = 0,
            /// <summary>
            /// Skip checking regexp
            /// </summary>
            SkipRegexp = 1,
            /// <summary>
            /// Skip checking conditions
            /// </summary>
            SkipConditions = 2,
            /// <summary>
            /// Skip checking refire restrictions
            /// </summary>
            SkipRefire = 4,
            /// <summary>
            /// Skip any checks from parent folder(s)
            /// </summary>
            SkipParent = 8,
            /// <summary>
            /// Skip checking whether trigger is active or not
            /// </summary>
            SkipActive = 16,
            /// <summary>
            /// Skip all checks except condition checks
            /// </summary>
            SkipExceptConditions = SkipRegexp | SkipRefire | SkipParent | SkipActive,
            /// <summary>
            /// Skip all checks
            /// </summary>
            SkipAll = SkipRegexp | SkipConditions | SkipRefire | SkipParent | SkipActive
        }

        /// <summary>
        /// Type of the zone information
        /// </summary>
        private enum ZoneTypeEnum
        {
            /// <summary>
            /// Zone information is a zone name
            /// </summary>
            ZoneName,
            /// <summary>
            /// Zone information is a FFXIV zone ID
            /// </summary>
            ZoneIdFFXIV
        }

        /// <summary>
        /// Type of the zone information provided
        /// </summary>
        [ActionAttribute(ordernum: 1)]
        private ZoneTypeEnum _ZoneType { get; set; } = ZoneTypeEnum.ZoneName;
        [XmlAttribute]
        public string ZoneType
        {
            get
            {
                if (_ZoneType != ZoneTypeEnum.ZoneName)
                {
                    return _ZoneType.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _ZoneType = (ZoneTypeEnum)Enum.Parse(typeof(ZoneTypeEnum), value);
            }
        }

        /// <summary>
        /// Type of the trigger operation
        /// </summary>
        [ActionAttribute(ordernum: 2)]
        private OperationEnum _Operation { get; set; } = OperationEnum.FireTrigger;
        [XmlAttribute]
        public string Operation
        {
            get
            {
                if (_Operation != OperationEnum.FireTrigger)
                {
                    return _Operation.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _Operation = (OperationEnum)Enum.Parse(typeof(OperationEnum), value);
            }
        }

        /// <summary>
        /// Reference to the trigger
        /// </summary>
        [ActionAttribute(ordernum: 3, specialtype: ActionAttribute.SpecialTypeEnum.TriggerReference)]
        private Guid _TriggerId { get; set; } = Guid.Empty;
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

        /// <summary>
        /// Event text the trigger is fired with
        /// </summary>
        [ActionAttribute(ordernum: 4)]
        private string _Text { get; set; } = "";
        [XmlAttribute]
        public string Text
        {
            get
            {
                if (_Text == "")
                {
                    return null;
                }
                return _Text;
            }
            set
            {
                _Text = value;
            }
        }

        /// <summary>
        /// Zone information the trigger is fired with
        /// </summary>
        [ActionAttribute(ordernum: 5)]
        private string _Zone { get; set; } = "";
        [XmlAttribute]
        public string Zone
        {
            get
            {
                if (_Zone == "")
                {
                    return null;
                }
                return _Zone;
            }
            set
            {
                _Zone = value;
            }
        }

        /// <summary>
        /// Trigger force firing flags
        /// </summary>
        [ActionAttribute(ordernum: 6)]
        private ForceEnum _Force { get; set; } = ForceEnum.NoSkip;
        [XmlAttribute]
        public string Force
        {
            get
            {
                List<string> ex = new List<string>();
                if (_Force == ForceEnum.SkipAll)
                {
                    ex.Add("true");
                }
                else
                {
                    if ((_Force & ForceEnum.SkipRegexp) != 0)
                    {
                        ex.Add("regexp");
                    }
                    if ((_Force & ForceEnum.SkipConditions) != 0)
                    {
                        ex.Add("conditions");
                    }
                    if ((_Force & ForceEnum.SkipRefire) != 0)
                    {
                        ex.Add("refire");
                    }
                    if ((_Force & ForceEnum.SkipParent) != 0)
                    {
                        ex.Add("parent");
                    }
                    if ((_Force & ForceEnum.SkipActive) != 0)
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
                ForceEnum newval = ForceEnum.NoSkip;
                foreach (string ex in exx)
                {
                    if (string.Compare(ex, "true", true) == 0)
                    {
                        newval = ForceEnum.SkipAll;
                        break;
                    }
                    else if (string.Compare(ex, "false", true) == 0)
                    {
                        newval = ForceEnum.NoSkip;
                        break;
                    }
                    if (string.Compare(ex, "regexp", true) == 0)
                    {
                        newval |= ForceEnum.SkipRegexp;
                    }
                    if (string.Compare(ex, "conditions", true) == 0)
                    {
                        newval |= ForceEnum.SkipConditions;
                    }
                    if (string.Compare(ex, "refire", true) == 0)
                    {
                        newval |= ForceEnum.SkipRefire;
                    }
                    if (string.Compare(ex, "parent", true) == 0)
                    {
                        newval |= ForceEnum.SkipParent;
                    }
                    if (string.Compare(ex, "active", true) == 0)
                    {
                        newval |= ForceEnum.SkipActive;
                    }
                }
                _Force = newval;
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            Trigger t = ctx.plug.GetTriggerById(_TriggerId, ctx.trig?.Repo);
            if (t != null)
            {
                switch (_Operation)
                {
                    case OperationEnum.CancelTrigger:
                        return I18n.Translate("internal/Action/desctrigcancel", "cancel all actions queued from trigger ({0})", t.Name);                        
                    case OperationEnum.CancelAllTrigger:
                        return I18n.Translate("internal/Action/desctrigcancelall", "cancel all actions queued from all triggers");                        
                    case OperationEnum.FireTrigger:
                        string temp = I18n.Translate("internal/Action/desctrigfire", "fire trigger ({0})", t.Name);
                        List<string> ex = new List<string>();
                        if (_Force == ForceEnum.SkipAll)
                        {
                            ex.Add(I18n.Translate("internal/Action/desctrigignoreall", "all restrictions"));
                        }
                        else
                        {
                            if ((_Force & ForceEnum.SkipRegexp) != 0)
                            {
                                ex.Add(I18n.Translate("internal/Action/desctrigignoreregex", "regular expression"));
                            }
                            else
                            {
                                temp += " " + I18n.Translate("internal/Action/desctrigfireusing", "with event text ({0}) and zone ({1})", _Text, _Zone);
                            }
                            if ((_Force & ForceEnum.SkipConditions) != 0)
                            {
                                ex.Add(I18n.Translate("internal/Action/desctrigignoreconditions", "conditions"));
                            }
                            if ((_Force & ForceEnum.SkipRefire) != 0)
                            {
                                ex.Add(I18n.Translate("internal/Action/desctrigignorerefire", "refire delay"));
                            }
                            if ((_Force & ForceEnum.SkipParent) != 0)
                            {
                                ex.Add(I18n.Translate("internal/Action/desctrigignoreparent", "parent folder settings"));
                            }
                            if ((_Force & ForceEnum.SkipActive) != 0)
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
                    case OperationEnum.DisableTrigger:
                        return I18n.Translate("internal/Action/desctrigdisable", "disable trigger ({0})", t.Name);
                    case OperationEnum.EnableTrigger:
                        return I18n.Translate("internal/Action/desctrigenable", "enable trigger ({0})", t.Name);                        
                }
            }
            if (_Operation == OperationEnum.CancelAllTrigger)
            {
                return I18n.Translate("internal/Action/desctrigcancelall", "cancel all actions queued from all triggers");
            }
            return I18n.Translate("internal/Action/desctriginvalidref", "trigger action with an invalid trigger reference ({0})", _TriggerId);
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            Trigger t = ctx.plug.GetTriggerById(_TriggerId, ctx.trig?.Repo);
            if (t != null)
            {
                switch (_Operation)
                {
                    case OperationEnum.CancelAllTrigger:
                        ctx.plug.ClearActionQueue();
                        break;
                    case OperationEnum.CancelTrigger:
                        ctx.plug.CancelAllQueuedActionsFromTrigger(t);
                        break;
                    case OperationEnum.FireTrigger:
                        {
                            LogEvent le = new LogEvent();
                            le.Text = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Text);
                            le.ZoneName = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Zone);
                            if (_ZoneType == ZoneTypeEnum.ZoneIdFFXIV && le.ZoneName.Trim().Length > 0)
                            {
                                le.ZoneId = le.ZoneName;
                            }
                            le.Timestamp = DateTime.Now;
                            if (ctx.zoneIdOverride != null)
                            {
                                le.TestMode = true;
                                le.ZoneId = ctx.zoneIdOverride;
                            }
                            //ctx.plug.TestTrigger(t, le, _Force); todo
                        }
                        break;
                    case OperationEnum.EnableTrigger:
                        {
                            t.Enabled = true;
                            ctx.plug.ui.Invoke((System.Action)(() =>
                            {
                                bool isLocal = ctx.trig == null || ctx.trig.Repo == null;
                                TreeNode tn = ctx.plug.LocateNodeHostingTrigger(ctx.plug.ui.treeView1.Nodes[isLocal ? 0 : 1], t);

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
                    case OperationEnum.DisableTrigger:
                        {
                            t.Enabled = false;
                            ctx.plug.ui.Invoke((System.Action)(() =>
                            {
                                bool isLocal = ctx.trig == null || ctx.trig.Repo == null;
                                TreeNode tn = ctx.plug.LocateNodeHostingTrigger(ctx.plug.ui.treeView1.Nodes[isLocal ? 0 : 1], t);

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
                if (_Operation == OperationEnum.CancelAllTrigger)
                {
                    ctx.plug.ClearActionQueue();
                }
                else
                {
                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/notriggerwithid",
                        "Trigger operation failed: In trigger ({1}), the specified trigger id ({0}) does not exist.", _TriggerId, ParentTrigger?.FullPath ?? "null"));
                }
            }
        }

        #endregion

    }

}
