using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry.Actions
{

    /// <summary>
    /// ACT interaction operations
    /// </summary>
    [XmlRoot(ElementName = "ActInteraction")]
    public class ActionActInteraction : ActionBase
    {

        #region Properties

        /// <summary>
        /// ACT interaction operations
        /// </summary>
        private enum OperationEnum
        {
            /// <summary>
            /// Set ACT combat state
            /// </summary>
            SetCombatState,
            /// <summary>
            /// Toggle all network logging
            /// </summary>
            LogAllNetwork,
            /// <summary>
            /// Toggle Deucalion usage
            /// </summary>
            UseDeucalion,
        }

        /// <summary>
        /// Type of ACT interaction
        /// </summary>
        private OperationEnum _Operation { get; set; } = OperationEnum.SetCombatState;
        [XmlAttribute]
        public string Operation
        {
            get => _Operation != OperationEnum.SetCombatState ? _Operation.ToString() : null;
            set
            {
                _Operation = (OperationEnum)Enum.Parse(typeof(OperationEnum), value);
            }
        }

        /// <summary>
        /// Value to set
        /// </summary>
        private bool _Value { get; set; } = false;
        [XmlAttribute]
        public string Value
        {
            get => _Value ? _Value.ToString() : null;
            set
            {
                _Value = bool.Parse(value);
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            switch (_Operation)
            {
                case OperationEnum.SetCombatState:
                    return _Value == false ? 
                        I18n.Translate("internal/Action/descactcombatend", "end ACT encounter")
                        :
                        I18n.Translate("internal/Action/descactcombatstart", "start ACT encounter");                    
                case OperationEnum.LogAllNetwork:
                    return I18n.Translate("internal/Action/descactlogallnetwork", "{0} option: Log all network data", I18n.TranslateEnable(_Value));
                case OperationEnum.UseDeucalion:
                    return I18n.Translate("internal/Action/descactusedeucalion", "{0} option: Use Deucalion (injection)", I18n.TranslateEnable(_Value));
            }
            return "";
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            RealPlugin plug = ai.ctx.plug;
            switch (_Operation)
            {
                case OperationEnum.SetCombatState:
                    plug.SetCombatStateHook(_Value);
                    break;
                case OperationEnum.LogAllNetwork:
                    plug.LogAllNetworkHook(_Value);
                    break;
                case OperationEnum.UseDeucalion:
                    plug.UseDeucalionHook(_Value);
                    break;
            }
        }

        internal override Control GetPropertyEditor()
        {            
            return null; // todo
        }

        #endregion

    }

}
