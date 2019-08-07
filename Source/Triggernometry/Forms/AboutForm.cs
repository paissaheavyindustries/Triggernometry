using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Triggernometry.Forms
{

    public partial class AboutForm : MemoryForm<AboutForm>
    {

        public AboutForm()
        {
            InitializeComponent();
            RestoredSavedDimensions();
        }

        private void AboutForm_Shown(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(53, 70, 92);
            txtGeneral.Text = txtGeneral.Text.Replace("[VERSIONNUMBER]", Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

    }

}
