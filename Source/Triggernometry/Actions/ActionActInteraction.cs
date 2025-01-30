using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry.Actions
{

    /// <summary>
    /// ACT interaction operations
    /// </summary>
    [ActionCategory(ActionCategory.CategoryTypeEnum.RemoteControl)]
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
        [ActionAttribute(ordernum: 1)]
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
        [ActionAttribute(ordernum: 2)]
        private string _Value { get; set; } = "";
        [XmlAttribute]
        public string Value
        {
            get => _Value != "" ? _Value : null;
            set
            {
                _Value = value;
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            switch (_Operation)
            {
                case OperationEnum.SetCombatState:
                    return bool.Parse(_Value) == false ? 
                        I18n.Translate("internal/Action/descactcombatend", "end ACT encounter")
                        :
                        I18n.Translate("internal/Action/descactcombatstart", "start ACT encounter");                    
                case OperationEnum.LogAllNetwork:
                    return I18n.Translate("internal/Action/descactlogallnetwork", "{0} option: Log all network data", I18n.TranslateEnable(bool.Parse(_Value)));
                case OperationEnum.UseDeucalion:
                    return I18n.Translate("internal/Action/descactusedeucalion", "{0} option: Use Deucalion (injection)", I18n.TranslateEnable(bool.Parse(_Value)));
            }
            return "";
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            RealPlugin plug = ai.ctx.plug;
            switch (_Operation)
            {
                case OperationEnum.SetCombatState:
                    plug.SetCombatStateHook(bool.Parse(_Value));
                    break;
                case OperationEnum.LogAllNetwork:
                    PluginBridges.BridgeFFXIV.LogAllNetwork(bool.Parse(_Value));
                    break;
                case OperationEnum.UseDeucalion:
                    PluginBridges.BridgeFFXIV.UseDeucalion(bool.Parse(_Value));
                    break;
            }
        }

        #endregion

    }

}
