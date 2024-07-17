using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Message box
    /// </summary>
    [XmlRoot(ElementName = "MessageBox")]
    internal class ActionMessageBox : ActionBase
    {

        #region Properties

        /// <summary>
        /// Message box icon types
        /// </summary>
        private enum MessageBoxIconEnum
        {
            None = 0,
            Error = 16,
            Question = 32,
            Warning = 48,
            Information = 64
        }

        /// <summary>
        /// Icon to display on message box
        /// </summary>
        [ActionAttribute(ordernum: 1)]
        private MessageBoxIconEnum _Icon { get; set; } = MessageBoxIconEnum.None;
        [XmlAttribute]
        public string Icon
        {
            get
            {
                if (_Icon != MessageBoxIconEnum.None)
                {
                    return _Icon.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _Icon = (MessageBoxIconEnum)Enum.Parse(typeof(MessageBoxIconEnum), value);
            }
        }

        /// <summary>
        /// Text to display on message box
        /// </summary>
        [ActionAttribute(ordernum: 2)]
        private string _Text { get; set; } = "";
        [XmlAttribute]
        public string Text
        {
            get
            {
                if (_Text == "")
                {
                    return null;
                }
                return _Text;
            }
            set
            {
                _Text = value;
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            return I18n.Translate($"internal/Action/descmsgbox{_Icon}", "show a message box saying ({0}) with icon (" + _Icon.ToString() + ")", _Text);
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            Form activeForm = Form.ActiveForm;
            if (activeForm != null)
            {
                MessageBox.Show(activeForm, ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Text), "", MessageBoxButtons.OK, (System.Windows.Forms.MessageBoxIcon)_Icon);
            }
            else
            {
                MessageBox.Show(ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Text), "", MessageBoxButtons.OK, (System.Windows.Forms.MessageBoxIcon)_Icon);
            }
        }

        #endregion

    }

}
