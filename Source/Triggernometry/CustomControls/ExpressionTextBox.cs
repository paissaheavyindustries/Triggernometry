using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triggernometry.CustomControls
{

    public partial class ExpressionTextBox : UserControl
    {

        public enum SupportedExpressionTypeEnum
        {
            String,
            Numeric
        }

        public bool ReadOnly
        {
            get
            {
                return textBox1.ReadOnly;
            }
            set
            {
                textBox1.ReadOnly = value;
            }
        }

        public string Expression
        {
            get
            {
                return textBox1.Text;
            }

            set
            {
                textBox1.Text = value;
            }
        }

        private SupportedExpressionTypeEnum _ExpressionType;
        public SupportedExpressionTypeEnum ExpressionType
        { 
            get
            {
                return _ExpressionType;
            }
            set
            {
                if (value != _ExpressionType)
                {
                    _ExpressionType = value;
                    ResetTooltip();
                }
            }
        }

        private void ResetTooltip()
        {
            switch (ExpressionType)
            {
                case SupportedExpressionTypeEnum.Numeric:
                    string temp = I18n.Translate("internal/ExpressionTextBox/numeric1", "This field supports numeric expressions; references to named regular expression groups will be expanded, after which the result will be evaluated as a mathematic expression.");
                    temp += Environment.NewLine;
                    temp += I18n.Translate("internal/ExpressionTextBox/numeric2", "The color of the field will also change depending on whether the numeric expression appears to be valid (green) or not (red).");
                    toolTip1.SetToolTip(panel1, temp);
                    break;
                case SupportedExpressionTypeEnum.String:
                    toolTip1.SetToolTip(panel1, I18n.Translate("internal/ExpressionTextBox/string", "This field supports string expressions; references to named regular expression groups will be expanded."));
                    break;
            }
            UpdateBackground();
        }

        private Context ctx;

        public ExpressionTextBox()
        {            
            InitializeComponent();
            ctx = new Context();
            ctx.testmode = true;
            ResetTooltip();
            textBox1.TextChanged += TextBox1_TextChanged;
        }

        private void UpdateBackground()
        {
            if (ExpressionType == SupportedExpressionTypeEnum.Numeric)
            {
                if (textBox1.Text.Length == 0)
                {
                    textBox1.BackColor = SystemColors.Window;
                    return;
                }
                try
                {
                    ctx.EvaluateNumericExpression(null, null, textBox1.Text);
                    textBox1.BackColor = Color.FromArgb(200, 255, 200);
                }
                catch (Exception)
                {
                    textBox1.BackColor = Color.FromArgb(255, 200, 200);
                }
            }
            else if (ExpressionType == SupportedExpressionTypeEnum.String)
            {
                if (textBox1.BackColor != SystemColors.Window)
                {
                    textBox1.BackColor = SystemColors.Window;
                }
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateBackground();
        }

    }

}
