using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Named callback invocation
    /// </summary>
    [XmlRoot(ElementName = "NamedCallback")]
    internal class ActionNamedCallback : ActionBase
    {

        #region Properties

        /// <summary>
        /// Name of the callback to invoke
        /// </summary>
        private string _Name = "";
        [XmlAttribute]
        public string Name
        {
            get
            {
                if (_Name == "")
                {
                    return null;
                }
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        /// <summary>
        /// Parameter value to pass to the callback
        /// </summary>
        private string _Parameter = "";
        [XmlAttribute]
        public string Parameter
        {
            get
            {
                if (_Parameter == "")
                {
                    return null;
                }
                return _Parameter;
            }
            set
            {
                _Parameter = value;
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            return I18n.Translate("internal/Action/descnamedcallback", "Invoke named callback ({0}) with parameter ({1})", _Name, _Parameter);
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            string cbname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Name);
            string cbparm = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Parameter);
            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/callbackinvoke", "Invoking named callback ({0}) with parameter ({1})", cbname, cbparm));
            ctx.plug.InvokeNamedCallback(cbname, cbparm);
        }

        internal override Control GetPropertyEditor()
        {
            return null; // todo
        }

        #endregion

    }

}
