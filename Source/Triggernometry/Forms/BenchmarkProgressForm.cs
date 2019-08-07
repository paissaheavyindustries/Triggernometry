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
    public partial class BenchmarkProgressForm : MemoryForm<BenchmarkProgressForm>
    {

        public BenchmarkForm bf { get; set; }

        public BenchmarkProgressForm()
        {
            InitializeComponent();
            Shown += BenchmarkProgressForm_Shown;
            RestoredSavedDimensions();
        }

        private void BenchmarkProgressForm_Shown(object sender, EventArgs e)
        {
            bf.RunBenchmark();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bf.backgroundWorker1.CancelAsync();
            DialogResult = DialogResult.Cancel;
        }
    }
}
