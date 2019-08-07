using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Triggernometry
{

    public sealed class ConditionGroup : ConditionComponent
    {

        public enum CndGroupingEnum
        {
            And = 1,
            Or = 2,
            Xor = 3,
            Not = 4
        }

        private CndGroupingEnum _Grouping = CndGroupingEnum.Or;
        [XmlAttribute]
        public CndGroupingEnum Grouping
        {
            get
            {
                return _Grouping;
            }
            set
            {
                if (value != _Grouping)
                {
                    _Grouping = value;
                    TriggerOnPropertyChange();
                }
            }
        }

        [XmlElement(typeof(ConditionGroup))]
        [XmlElement(typeof(ConditionSingle))]
        public List<ConditionComponent> Children { get; set; } = new List<ConditionComponent>();

        public void AddChild(ConditionComponent re)
        {
            re.Parent = this;
            Children.Add(re);
        }

        public void RemoveChild(ConditionComponent re)
        {
            Children.Remove(re);
            re.Parent = null;
        }

        public override string ToString()
        {
            switch (Grouping)
            {
                case CndGroupingEnum.And:
                    return I18n.Translate("internal/ConditionGroup/and", "All conditions must be true");
                case CndGroupingEnum.Or:
                    return I18n.Translate("internal/ConditionGroup/or", "At least one condition must be true");
                case CndGroupingEnum.Xor:
                    return I18n.Translate("internal/ConditionGroup/xor", "Only one condition must be true");
                case CndGroupingEnum.Not:
                    return I18n.Translate("internal/ConditionGroup/not", "None of the conditions may be true");
            }
            return I18n.Translate("internal/ConditionGroup/unknown", "Unknown grouping value '{0}'", Grouping);
        }

        internal override ConditionComponent Duplicate()
        {
            ConditionGroup cg = new ConditionGroup();
            cg.Enabled = Enabled;
            cg.Grouping = Grouping;
            foreach (ConditionComponent cc in Children)
            {
                cg.AddChild(cc.Duplicate());
            }
            return cg;
        }

        internal static void RebuildParentage(ConditionGroup cg)
        {
            foreach (ConditionComponent cc in cg.Children)
            {
                cc.Parent = cg;
                if (cc is ConditionGroup)
                {
                    RebuildParentage((ConditionGroup)cc);
                }
            }
        }

        internal override bool CheckCondition(Context ctx, Context.LoggerDelegate logger, object o)
        {
            if (Children.Count == 0 && Parent == null)
            {
                return true;
            }
            switch (Grouping)
            {
                case CndGroupingEnum.And:
                    {
                        bool actives = false;
                        foreach (ConditionComponent cc in Children)
                        {
                            if (cc.Enabled == false)
                            {
                                if (System.Diagnostics.Debugger.IsAttached == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("AND: Condition '" + cc.ToString() + "' not enabled");
                                }
                                continue;
                            }
                            actives = true;
                            if (cc.CheckCondition(ctx, logger, o) == false)
                            {
                                if (System.Diagnostics.Debugger.IsAttached == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("AND: Condition '" + cc.ToString() + "' was false");
                                }
                                return false;
                            }
                        }
                        if (actives == false)
                        {
                            if (System.Diagnostics.Debugger.IsAttached == true)
                            {
                                System.Diagnostics.Debug.WriteLine("AND: No actives found");
                            }
                            return false;
                        }
                    }
                    break;
                case CndGroupingEnum.Or:
                    {
                        foreach (ConditionComponent cc in Children)
                        {
                            if (cc.Enabled == false)
                            {
                                if (System.Diagnostics.Debugger.IsAttached == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("OR: Condition '" + cc.ToString() + "' not enabled");
                                }
                                continue;
                            }
                            if (cc.CheckCondition(ctx, logger, o) == true)
                            {
                                if (System.Diagnostics.Debugger.IsAttached == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("OR: Condition '" + cc.ToString() + "' was true");
                                }
                                return true;
                            }
                        }
                    }
                    break;
                case CndGroupingEnum.Xor:
                    {
                        bool truefound = false;
                        foreach (ConditionComponent cc in Children)
                        {
                            if (cc.Enabled == false)
                            {
                                if (System.Diagnostics.Debugger.IsAttached == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("XOR: Condition '" + cc.ToString() + "' not enabled");
                                }
                                continue;
                            }
                            if (cc.CheckCondition(ctx, logger, o) == true)
                            {
                                if (truefound == true)
                                {
                                    if (System.Diagnostics.Debugger.IsAttached == true)
                                    {
                                        System.Diagnostics.Debug.WriteLine("XOR: Condition '" + cc.ToString() + "' was true as well");
                                    }
                                    return false;
                                }
                                if (System.Diagnostics.Debugger.IsAttached == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("XOR: Condition '" + cc.ToString() + "' was true");
                                }
                                truefound = true;
                            }
                        }
                        if (System.Diagnostics.Debugger.IsAttached == true)
                        {
                            System.Diagnostics.Debug.WriteLine("XOR: Condition on '" + this.ToString() + "' " + ((truefound == true) ? "passed" : "did not pass"));
                        }
                        return truefound;
                    }
                case CndGroupingEnum.Not:
                    {
                        foreach (ConditionComponent cc in Children)
                        {
                            if (cc.Enabled == false)
                            {
                                if (System.Diagnostics.Debugger.IsAttached == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("NOT: Condition '" + cc.ToString() + "' not enabled");
                                }
                                continue;
                            }
                            if (cc.CheckCondition(ctx, logger, o) == true)
                            {
                                if (System.Diagnostics.Debugger.IsAttached == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("NOT: Condition '" + cc.ToString() + "' was true");
                                }
                                return false;
                            }
                        }
                        if (System.Diagnostics.Debugger.IsAttached == true)
                        {
                            System.Diagnostics.Debug.WriteLine("NOT: Condition on '" + this.ToString() + "' passed");
                        }
                        return true;
                    }
            }
            if (System.Diagnostics.Debugger.IsAttached == true)
            {
                System.Diagnostics.Debug.WriteLine("GENERAL: Condition on '" + this.ToString() + "' " + ((Children.Count > 0 && Grouping == CndGroupingEnum.And) ? "passed" : "did not pass"));
            }
            return (Children.Count > 0 && Grouping == CndGroupingEnum.And); 
        }

    }

}
