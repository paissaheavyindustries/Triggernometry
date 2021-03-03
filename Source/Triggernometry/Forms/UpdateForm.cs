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

    public partial class UpdateForm : MemoryForm<UpdateForm>
    {

        private delegate void ProgressDelegate(int progress, string state);
        internal RealPlugin plug { get; set; }

        public UpdateForm()
        {
            InitializeComponent();
            RestoredSavedDimensions();
            Shown += UpdateForm_Shown;
        }

        internal void ShowProgress(int progress, string state)
        {
            if (statusStrip1.InvokeRequired == true)
            {
                statusStrip1.Invoke(new ProgressDelegate(ShowProgress), progress, state);
                return;
            }
            if (progress == 0 && state == "" && statusStrip1.Visible == true)
            {
                statusStrip1.Visible = false;
                return;
            }
            if (progress == -1)
            {
                prgProgress.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                prgProgress.Style = ProgressBarStyle.Continuous;
                if (progress < prgProgress.Minimum)
                {
                    progress = prgProgress.Minimum;
                }
                if (progress > prgProgress.Maximum)
                {
                    progress = prgProgress.Maximum;
                }
                prgProgress.Value = progress;
            }
            lblStatus.Text = state;
            if (progress != 0 && statusStrip1.Visible == false)
            {
                statusStrip1.Visible = true;
            }
        }

        private void UpdateForm_Shown(object sender, EventArgs e)
        {
            string trans = I18n.Translate("UpdateForm/statuschecking", "Checking for latest version...");
            ShowProgress(-1, trans);
            plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Info, trans);
            Task tx = new Task(() =>
            {
                //RepositoryListDownload();
            });
            tx.Start();
        }

    }

}
