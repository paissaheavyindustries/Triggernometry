using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Mutex operations
    /// </summary>
    [XmlRoot(ElementName = "Mutex")]
    internal class ActionMutex : ActionBase
    {

        #region Properties

        /// <summary>
        /// Mutex operations
        /// </summary>
        private enum OperationEnum
        {
            Release,
            Acquire
        }

        /// <summary>
        /// Type of the mutex operation
        /// </summary>
        [ActionAttribute(ordernum: 1)]
        private OperationEnum _Operation { get; set; } = OperationEnum.Release;
        [XmlAttribute]
        public string Operation
        {
            get
            {
                if (_Operation != OperationEnum.Release)
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
        /// Name of the mutex
        /// </summary>
        [ActionAttribute(ordernum: 2)]
        private string _Name { get; set; } = "";
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

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            switch (_Operation)
            {
                case OperationEnum.Release:
                    return I18n.Translate("internal/Action/mutexrelease", "release mutex ({0})", _Name);
                case OperationEnum.Acquire:
                    return I18n.Translate("internal/Action/mutexacquire", "acquire mutex ({0})", _Name);
            }
            return "";
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            string mn = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Name);
            switch (_Operation)
            {
                case OperationEnum.Acquire:
                    {
                        RealPlugin.MutexInformation mi = ctx.plug.GetMutex(mn);
                        mi.Acquire(ctx);
                    }
                    break;
                case OperationEnum.Release:
                    {
                        RealPlugin.MutexInformation mi = ctx.plug.GetMutex(mn);
                        mi.Release(ctx);
                    }
                    break;
            }
        }

        #endregion

    }

}
