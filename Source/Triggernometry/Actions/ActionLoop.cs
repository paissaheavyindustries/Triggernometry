using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Loop
    /// </summary>
    [ActionCategory(ActionCategory.CategoryTypeEnum.Programming)]
    [XmlRoot(ElementName = "Loop")]
    internal class ActionLoop : ActionBase
    {

        #region Properties

        // todo probably needs a custom property editor

        private bool ShouldSerializeLoopCondition()
        {
            return (LoopCondition.Children.Count > 0);
        }

        private bool ShouldSerializeLoopActions()
        {
            return (Actions.Count > 0);
        }

        /// <summary>
        /// Condition that is checked before every iterator whether loop should continue or not
        /// </summary>
        public ConditionGroup LoopCondition = new ConditionGroup();

        /// <summary>
        /// Actions within the loop
        /// </summary>
        public List<ActionBase> Actions = new List<ActionBase>();

        /// <summary>
        /// Delay between every loop iteration
        /// </summary>        
        private string _DelayExpression = "";
        [XmlAttribute]
        public string DelayExpression
        {
            get
            {
                if (_DelayExpression == "")
                {
                    return null;
                }
                return _DelayExpression;
            }
            set
            {
                _DelayExpression = value;
            }
        }

        /// <summary>
        /// Expression for the initial value of the loop iterator
        /// </summary>
        private string _InitExpression = "0";
        [XmlAttribute]
        public string InitExpression
        {
            get
            {
                if (_InitExpression == "0")
                {
                    return null;
                }
                return _InitExpression;
            }
            set
            {
                _InitExpression = value;
            }
        }

        /// <summary>
        /// Expression for the addition to the loop iterator after every iteration
        /// </summary>
        private string _IncrExpression = "1";
        [XmlAttribute]
        public string IncrExpression
        {
            get
            {
                if (_IncrExpression == "1")
                {
                    return null;
                }
                return _IncrExpression;
            }
            set
            {
                _IncrExpression = value;
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            return I18n.Translate(
                "internal/Action/descloop", "Loop with {0} actions at ({1}) ms intervals",
                Actions?.Count(action => action._Enabled) ?? 0,
                string.IsNullOrWhiteSpace(_DelayExpression) ? "0" : _DelayExpression
            );
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            if (ctx.loopcontext == Id)
            {
                ctx.loopiterator += (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _IncrExpression);
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
                    ctx.loopiterator = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _InitExpression);
                }
                else
                {
                    continuing = true;
                }
                DateTime curTime = DateTime.Now;
                Action lastAction = ctx.plug.QueueActions(ctx, curTime, null /* todo Actions proper type */, ctx.trig._Sequential, ai?.mutex, ActionContextLogger);
                lastAction.LoopAction = null; // todo supposed to be a reference to this action
                if (continuing == true)
                {
                    return;
                }
            }
        }

        #endregion

    }

}
