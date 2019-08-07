using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advanced_Combat_Tracker;

namespace Triggernometry.Forms
{

    public partial class TestInputForm : MemoryForm<TestInputForm>
    {

        public TestInputForm()
        {
            InitializeComponent();
            Shown += TestInputForm_Shown;
            RestoredSavedDimensions();
        }

        private void TestInputForm_Shown(object sender, EventArgs e)
        {
            txtEvent.Focus();
        }

        private void btnGetCurZone_Click(object sender, EventArgs e)
        {
            txtZoneName.Text = ActGlobals.oFormActMain.CurrentZone;
        }

        private void txtEvent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                txtEvent.SelectAll();
            }
        }
    }

}
