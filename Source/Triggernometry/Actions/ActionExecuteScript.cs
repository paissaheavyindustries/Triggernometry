using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Script execution
    /// </summary>
    [ActionCategory(ActionCategory.CategoryTypeEnum.Programming)]
    [XmlRoot(ElementName = "ExecuteScript")]
    internal class ActionExecuteScript : ActionBase
    {

        #region Properties

        /// <summary>
        /// Comma-separated list of referenced assemblies
        /// </summary>
        [ActionAttribute(ordernum: 1)]
        private string _Assemblies { get; set; } = "";
        [XmlAttribute]
        public string Assemblies
        {
            get
            {
                if (_Assemblies == "")
                {
                    return null;
                }
                return _Assemblies;
            }
            set
            {
                _Assemblies = value;
            }
        }

        /// <summary>
        /// Script code expression
        /// </summary>
        [ActionAttribute(ordernum: 2)]
        private string _Script { get; set; } = "";
        [XmlAttribute]
        public string Script
        {
            get
            {
                if (_Script == "")
                {
                    return null;
                }
                return _Script;
            }
            set
            {
                _Script = value;
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            return I18n.Translate("internal/Action/descexecscript", "execute C# script");
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            string scp = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Script);
            string assy = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Assemblies);
            while (ctx.plug.scriptingInited == false)
            {
                Thread.Sleep(10);
            }
            if (ctx.plug.scripting != null && ctx.plug.scripting.Ready)
            {
                ctx.plug.scripting.Evaluate(scp, assy, ctx);
            }
            else
            {
                AddToLog(ctx, RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/scriptinifailed", "Action #{0} on trigger '{1}' not fired, scripting not available", OrderNumber, ctx.trig?.LogName ?? "(null)"));
            }
        }

        #endregion

    }

}
