using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Triggernometry.CustomControls
{

    public partial class RegexTextBox : UserControl
    {

        public override string Text
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

        public RegexTextBox()
        {
            InitializeComponent();
            toolTip1.SetToolTip(panel1, I18n.Translate("internal/RegexTextBox", "This field supports regular expressions; the color of the field will change depending on whether the regular expression is valid (green) or not (red)."));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.BackColor = SystemColors.Window;
                return;
            }
            try
            {
                Regex rex = new Regex(textBox1.Text);
                textBox1.BackColor = Color.FromArgb(200, 255, 200);
            }
            catch (Exception)
            {
                textBox1.BackColor = Color.FromArgb(255, 200, 200);
            }
        }

    }

}
