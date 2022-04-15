using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triggernometry.Forms
{

    public partial class TestInputForm : MemoryForm<TestInputForm>
    {

        public RealPlugin plug;

        public TestInputForm()
        {
            InitializeComponent();
            Shown += TestInputForm_Shown;
            cbxEventDestination.SelectedIndex = 0;
            cbxZoneType.SelectedIndex = 0;
            RestoredSavedDimensions();
        }

        private void TestInputForm_Shown(object sender, EventArgs e)
        {
            txtEvent.Focus();
        }

        private void btnGetCurZone_Click(object sender, EventArgs e)
        {
            if (cbxZoneType.SelectedIndex == 0) 
            {
                txtZoneName.Text = plug.CurrentZoneHook();
            }
            else 
            {
                txtZoneName.Text = PluginBridges.BridgeFFXIV.ZoneID.ToString();
            }
        }

        private void txtEvent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                txtEvent.SelectAll();
            }
        }

        private void cbxZoneType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxZoneType.SelectedIndex == 0) 
            {
                lblZoneName.Text = I18n.Translate("TestInputForm/lblZoneName", "Zone name");
            }
            else 
            {
                lblZoneName.Text = I18n.Translate("TestInputForm/ffxivzoneid", "Zone ID");
            }
        }

    }

}
