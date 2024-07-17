using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry.Actions
{

    /// <summary>
    /// LiveSplit remote control operations
    /// </summary>
    [XmlRoot(ElementName = "LiveSplitControl")]
    internal class ActionLiveSplitControl : ActionBase
    {

        #region Properties

        /// <summary>
        /// LiveSplit remote control operations
        /// </summary>
        private enum OperationEnum
        {
            StartOrSplit,
            Start,
            Split,
            UndoSplit,
            SkipSplit,
            Reset,
            Pause,
            Resume,
            CustomPayload
        }

        /// <summary>
        /// Type of the LiveSplit control operation
        /// </summary>
        [ActionAttribute(ordernum: 1)]
        private OperationEnum _Operation { get; set; } = OperationEnum.StartOrSplit;
        [XmlAttribute]
        public string Operation
        {
            get
            {
                if (_Operation != OperationEnum.StartOrSplit)
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
        /// Custom payload to send to LiveSplit
        /// </summary>
        [ActionAttribute(ordernum: 2)]
        private string _CustomPayload { get; set; } = "";
        [XmlAttribute]
        public string CustomPayload
        {
            get
            {
                if (_Operation != OperationEnum.CustomPayload)
                {
                    return null;
                }
                return _CustomPayload;
            }
            set
            {
                _CustomPayload = value;
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            switch (_Operation)
            {
                case OperationEnum.StartOrSplit:
                    return I18n.Translate("internal/Action/desclsstartorsplit", "Start run or split on LiveSplit");
                case OperationEnum.Start:
                    return I18n.Translate("internal/Action/desclsstart", "Start run on LiveSplit");
                case OperationEnum.Split:
                    return I18n.Translate("internal/Action/desclssplit", "Split on LiveSplit");
                case OperationEnum.UndoSplit:
                    return I18n.Translate("internal/Action/desclsundosplit", "Undo split on LiveSplit");
                case OperationEnum.SkipSplit:
                    return I18n.Translate("internal/Action/desclsskipsplit", "Skip split on LiveSplit");
                case OperationEnum.Reset:
                    return I18n.Translate("internal/Action/desclsreset", "Reset run on LiveSplit");
                case OperationEnum.Pause:
                    return I18n.Translate("internal/Action/desclspause", "Pause run on LiveSplit");
                case OperationEnum.Resume:
                    return I18n.Translate("internal/Action/desclsresume", "Resume run on LiveSplit");
                case OperationEnum.CustomPayload:
                    return I18n.Translate("internal/Action/desclscustompayload", "Send custom payload to LiveSplit");
            }
            return "";
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            LiveSplitController livesplitController = ctx.plug._livesplit;
            if (livesplitController != null)
            {
                lock (livesplitController)
                {
                    if (LiveSplitConnector(ctx) == true)
                    {
                        try
                        {
                            switch (_Operation)
                            {
                                case OperationEnum.StartOrSplit:
                                    livesplitController.StartOrSplit();
                                    break;
                                case OperationEnum.Start:
                                    livesplitController.Start();
                                    break;
                                case OperationEnum.Split:
                                    livesplitController.Split();
                                    break;
                                case OperationEnum.UndoSplit:
                                    livesplitController.UndoSplit();
                                    break;
                                case OperationEnum.SkipSplit:
                                    livesplitController.SkipSplit();
                                    break;
                                case OperationEnum.Reset:
                                    livesplitController.Reset();
                                    break;
                                case OperationEnum.Pause:
                                    livesplitController.Pause();
                                    break;
                                case OperationEnum.Resume:
                                    livesplitController.Resume();
                                    break;
                                case OperationEnum.CustomPayload:
                                    string lscommand = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _CustomPayload);
                                    livesplitController.SendCommand(lscommand);
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/Action/lscontrolexception", "Can't execute LiveSplit control action due to exception: " + ex.Message));
                        }
                    }
                    else
                    {
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/lscontrolerror", "Can't execute LiveSplit control action due to error"));
                    }
                }
            }
        }

        #endregion

    }

}
