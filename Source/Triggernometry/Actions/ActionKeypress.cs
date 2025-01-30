using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using Triggernometry.Utilities;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Keypress operations
    /// </summary>
    [ActionCategory(ActionCategory.CategoryTypeEnum.Input)]
    [XmlRoot(ElementName = "Keypress")]
    internal class ActionKeypress : ActionBase
    {

        #region Properties

        /// <summary>
        /// Keypress operations
        /// </summary>
        private enum OperationEnum
        {
            /// <summary>
            /// Send by using the SendKeys API
            /// </summary>
            SendKeys,
            /// <summary>
            /// Send as a window message
            /// </summary>
            WindowMessage,
            /// <summary>
            /// Send as a series of window messages
            /// </summary>
            WindowMessageCombo
        }

        /// <summary>
        /// Type of the keypress operation
        /// </summary>
        [ActionAttribute(ordernum: 1)]
        private OperationEnum _Operation { get; set; } = OperationEnum.SendKeys;
        [XmlAttribute]
        public string Operation
        {
            get
            {
                if (_Operation != OperationEnum.SendKeys)
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
        /// Keypress expression (relevant only for SendKeys)
        /// </summary>
        [ActionAttribute(ordernum: 2, specialtype: ActionAttribute.SpecialTypeEnum.KeypressRecorder)]
        private string _Keypress { get; set; } = "";
        [XmlAttribute]
        public string Keypress
        {
            get
            {
                if (_Keypress == "")
                {
                    return null;
                }
                return _Keypress;
            }
            set
            {
                _Keypress = value;
            }
        }

        /// <summary>
        /// Keycode (relevant only for window message modes)
        /// </summary>
        [ActionAttribute(ordernum: 3, specialtype: ActionAttribute.SpecialTypeEnum.KeypressRecorder)]
        private string _Keycode { get; set; } = "";
        [XmlAttribute]
        public string Keycode
        {
            get
            {
                if (_Keycode == "")
                {
                    return null;
                }
                return _Keycode;
            }
            set
            {
                _Keycode = value;
            }
        }

        /// <summary>
        /// Window title to send keypress to (relevant only for window message modes)
        /// </summary>
        [ActionAttribute(ordernum: 4)]
        private string _WindowTitle { get; set; } = "";
        [XmlAttribute]
        public string WindowTitle
        {
            get
            {
                if (_WindowTitle == "")
                {
                    return null;
                }
                return _WindowTitle;
            }
            set
            {
                _WindowTitle = value;
            }
        }

        /// <summary>
        /// Process ID to send keypress to (relevant only for window message modes)
        /// </summary>
        [ActionAttribute(ordernum: 5, typehint: typeof(int))]
        private string _ProcessId { get; set; } = "";
        [XmlAttribute]
        public string ProcessId
        {
            get
            {
                if (_ProcessId == "")
                {
                    return null;
                }
                return _ProcessId;
            }
            set
            {
                _ProcessId = value;
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            switch (_Operation)
            {
                case OperationEnum.SendKeys:
                    return I18n.Translate("internal/Action/desckeypresses", "send keypresses ({0}) to the active window", _Keypress);                    
                case OperationEnum.WindowMessage:
                case OperationEnum.WindowMessageCombo:
                    string target;
                    _ProcessId = _ProcessId.Trim();
                    string title = string.IsNullOrWhiteSpace(_WindowTitle) ? ".*" : _WindowTitle;
                    int parsedProcId = 1;
                    try { parsedProcId = (int)MathParser.Parse(_ProcessId); }
                    catch { }
                    if (parsedProcId == 0)
                    {
                        target = I18n.Translate("internal/Action/descwindowtargetsingle", "the first window whose title match ({0})", title);
                    }
                    else if (parsedProcId < 0)
                    {
                        target = I18n.Translate("internal/Action/descwindowtargetall", "all windows whose titles match ({0})", title);
                    }
                    else
                    {
                        target = I18n.Translate("internal/Action/descwindowtargetid", "windows in the process with id ({0}) whose titles match ({1})", _ProcessId, title);
                    }
                    if (_Operation == OperationEnum.WindowMessage)
                    {
                        return I18n.Translate("internal/Action/desckeypress", "send keycode ({0}) to {1}", _Keycode, target);
                    }
                    return I18n.Translate("internal/Action/desckeypresscombo", "send keycodes ({0}) to {1}", _Keycode, target);
            }
            return "";
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            switch (_Operation)
            {
                case OperationEnum.SendKeys:
                    {
                        string ks = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Keypress);
                        SendKeys.SendWait(ks);
                    }
                    break;
                case OperationEnum.WindowMessage:
                    {
                        int procid = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _ProcessId);
                        string window = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _WindowTitle);
                        int keycode = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _Keycode);
                        WindowsUtils.SendKeycode(procid, window, keycode);
                    }
                    break;
                case OperationEnum.WindowMessageCombo:
                    {
                        int procid = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _ProcessId);
                        string window = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _WindowTitle);
                        int[] keycodes = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Keycode)
                            .Split(',').Select(kx => Convert.ToInt32(kx.Trim())).ToArray();
                        WindowsUtils.SendKeycodes(procid, window, keycodes);
                    }
                    break;
            }
        }

        #endregion

    }

}
