using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using Triggernometry.Utilities;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Send window message
    /// </summary>
    [ActionCategory(ActionCategory.CategoryTypeEnum.RemoteControl)]
    [XmlRoot(ElementName = "WindowMessage")]
    public class ActionWindowMessage : ActionBase
    {

        #region Properties

        /// <summary>
        /// Process ID to send window message to.
        /// If -1, message is sent to all windows in all windows with a matching title in all processes.
        /// If 0, message is sent to first window with a matching title in all processes.
        /// If >0, message is sent to all windows in all processes with matching title in the given process.
        /// </summary>
        [ActionAttribute(ordernum: 1, typehint: typeof(uint))]
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

        /// <summary>
        /// Window title to send window message to
        /// </summary>
        [ActionAttribute(ordernum: 2)]
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
        /// Id of the window message
        /// </summary>
        [ActionAttribute(ordernum: 3, typehint: typeof(uint))]
        private string _MessageId { get; set; } = "";
        [XmlAttribute]
        public string MessageId
        {
            get
            {
                if (_MessageId == "")
                {
                    return null;
                }
                return _MessageId;
            }
            set
            {
                _MessageId = value;
            }
        }

        /// <summary>
        /// Wparam of the window message
        /// </summary>
        [ActionAttribute(ordernum: 4, typehint: typeof(int))]
        private string _Wparam { get; set; } = "";
        [XmlAttribute]
        public string Wparam
        {
            get
            {
                if (_Wparam == "")
                {
                    return null;
                }
                return _Wparam;
            }
            set
            {
                _Wparam = value;
            }
        }

        /// <summary>
        /// Lparam of the window message
        /// </summary>
        [ActionAttribute(ordernum: 5, typehint: typeof(int))]
        private string _Lparam { get; set; } = "";
        [XmlAttribute]
        public string Lparam
        {
            get
            {
                if (_Lparam == "")
                {
                    return null;
                }
                return _Lparam;
            }
            set
            {
                _Lparam = value;
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            string target;
            _ProcessId = _ProcessId.Trim();
            if (_WindowTitle.Trim().Length == 0)
            {
                // the same condition check as in WindowsUtils.FindWindowsByTitleRegex
                target = I18n.Translate("internal/Action/descwindowtargetnone", "(unspecified window name)");
            }
            if (_ProcessId == "" || _ProcessId == "0")
            {
                target = I18n.Translate("internal/Action/descwindowtargetsingle", "the first window whose title match ({0})", _WindowTitle);
            }
            else if (_ProcessId == "-1")
            {
                target = I18n.Translate("internal/Action/descwindowtargetall", "all windows whose titles match ({0})", _WindowTitle);
            }
            else
            {
                target = I18n.Translate("internal/Action/descwindowtargetid", "windows in the process id ({0}) whose titles match ({1})", _ProcessId, _WindowTitle);
            }
            return I18n.Translate("internal/Action/descwmsg", "Send message ({0}) wparam ({1}) lparam ({2}) to {3}", _MessageId, _Wparam, _Lparam, target);
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            int procid = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _ProcessId);
            string window = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _WindowTitle);
            int code = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _MessageId);
            IntPtr wparam = (IntPtr)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _Wparam);
            IntPtr lparam = (IntPtr)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _Lparam);
            WindowsUtils.SendMessageToWindow(procid, window, (ushort)code, wparam, lparam);
        }

        #endregion

    }

}
