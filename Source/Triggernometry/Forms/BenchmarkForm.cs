using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Triggernometry.Forms
{

    public partial class BenchmarkForm : MemoryForm<BenchmarkForm>
    {

        public RealPlugin plug { get; set; }
        public List<BenchmarkItem> temp;
        public BenchmarkProgressForm bpf;

        public class BenchmarkItem
        {

            public Trigger trig;
            public long TimeOnMatch;
            public long TimeOnParent;
            public long TimeOnConditions;

            public long TimeTotal
            {
                get
                {
                    return TimeOnMatch + TimeOnParent + TimeOnConditions;
                }
            }

            public BenchmarkItem()
            {
                TimeOnMatch = 0;
                TimeOnParent = 0;
                TimeOnConditions = 0;
            }

        }

        public BenchmarkForm()
        {
            InitializeComponent();
            temp = new List<BenchmarkItem>();
            backgroundWorker1.ProgressChanged += BackgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
            Disposed += BenchmarkForm_Disposed;
            RestoredSavedDimensions();
        }

        private void BenchmarkForm_Disposed(object sender, EventArgs e)
        {
            if (bpf != null)
            {
                bpf.Close();
                bpf.Dispose();
                bpf = null;
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bpf.DialogResult = DialogResult.OK;
            bpf.Close();
            bpf.Dispose();          
            bpf = null;
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            bpf.progressBar1.Value = e.ProgressPercentage;
        }

        internal void RunBenchmark()
        {
            temp.Clear();
            dgvResults.Rows.Clear();            
            backgroundWorker1.RunWorkerAsync();
        }

        internal string TimeFormat(double x)
        {
            int step = 0;
            string name = "s";
            while (x < 0.1)
            {
                x *= 1000.0;
                step++;
                switch (step)
                {
                    case 1:
                        name = I18n.Translate("internal/BenchmarkForm/millisecond", "ms");
                        break;
                    case 2:
                        name = I18n.Translate("internal/BenchmarkForm/microsecond", "µs");
                        break;
                    case 3:
                        name = I18n.Translate("internal/BenchmarkForm/nanosecond", "ns");
                        break;
                }
            }
            return Math.Round(x, 3) + " " + name;
        }

        internal void ShowResults()
        {
            try
            {
                long totaltime = 0;
                foreach (BenchmarkItem bi in temp)
                {
                    totaltime += bi.TimeTotal;
                }                
                temp.Sort((a, b) => b.TimeTotal.CompareTo(a.TimeTotal));
                double dx = (double)(totaltime / 10000.0) / (double)Stopwatch.Frequency;
                dgvResults.Rows.Add(new object[] { I18n.Translate("internal/BenchmarkForm/esttotal", "(Estimated total evaluation time per event)"), null, TimeFormat(dx), null, null, null });
                dgvResults.Rows.Add(new object[] { I18n.Translate("internal/BenchmarkForm/estmaximum", "(Estimated maximum sustainable event load per second)"), null, Math.Round(1.0 / dx, 2), null, null });
                foreach (BenchmarkItem bi in temp)
                {                    
                    dgvResults.Rows.Add(new object[] {
                        bi.trig.FullPath, // name
                        Math.Round((double)bi.TimeTotal / (double)totaltime * 100.0, 2) + " %", // relative exec time
                        TimeFormat((double)(bi.TimeTotal / 10000.0) / (double)Stopwatch.Frequency), // average exec time
                        Math.Round((double)bi.TimeOnMatch / (double)bi.TimeTotal * 100.0, 2) + " %", // % on regexp
                        Math.Round((double)bi.TimeOnParent / (double)bi.TimeTotal * 100.0, 2) + " %", // % on folder
                        Math.Round((double)bi.TimeOnConditions / (double)bi.TimeTotal * 100.0, 2) + " %", // % on conditions
                    });
                }
                dgvResults.Invalidate();
            }
            catch (Exception)
            {
                plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/BenchmarkForm/resultexception", "An exception occurred during compiling benchmark results"));
            }
        }

        internal BenchmarkItem BenchmarkTrigger(Trigger t)
        {
            int i = 0;
            BenchmarkItem bi = new BenchmarkItem();
            bi.trig = t;
            string temp = "this is just a benchmark test string that has no bearing on anything important";
            Context ctx = new Context();
            ctx.plug = plug;
            Stopwatch st = Stopwatch.StartNew();
            while (i < 10000)
            {
                long stTime = st.ElapsedTicks;
                if (backgroundWorker1.CancellationPending == true)
                {
                    return null;
                }                
                t.CheckMatch(temp);
                bi.TimeOnMatch += st.ElapsedTicks - stTime;
                stTime = st.ElapsedTicks;
                LogEvent le = new LogEvent() { ZoneId = temp, ZoneName = temp, Text = temp };
                t.Parent.PassesFilter(le);
                bi.TimeOnParent += st.ElapsedTicks - stTime;
                stTime = st.ElapsedTicks;
                if (t._Condition != null && t._Condition.Enabled == true)
                {
                    t._Condition.CheckCondition(ctx, t.TriggerContextLogger, plug);
                }
                bi.TimeOnConditions += st.ElapsedTicks - stTime;
                i++;
            }            
            st.Stop();
            return bi;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            btnCopyToClipboard.Enabled = false;
            using (bpf = new BenchmarkProgressForm())
            {
                bpf.bf = this;                
                switch (bpf.ShowDialog())
                {
                    case DialogResult.OK:
                        ShowResults();
                        btnCopyToClipboard.Enabled = (dgvResults.RowCount > 0);
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }            
        }

        private bool FoldersEnabled(Folder f)
        {
            if (f.Enabled == false)
            {
                return false;
            }
            if (f.Parent != null)
            {
                if (FoldersEnabled(f.Parent) == false)
                {
                    return false;
                }
            }
            return f.Enabled;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                plug.DisableLogging = true;
                List<Trigger> trigs = new List<Trigger>();
                lock (plug.Triggers)
                {
                    trigs.AddRange(plug.Triggers);
                }
                int i = 0;
                int j = trigs.Count;
                foreach (Trigger t in trigs)
                {
                    if (backgroundWorker1.CancellationPending == true)
                    {
                        return;
                    }
                    if (t.Enabled == false)
                    {
                        continue;
                    }
                    if (FoldersEnabled(t.Parent) == false)
                    {
                        continue;
                    }
                    temp.Add(BenchmarkTrigger(t));
                    i++;
                    backgroundWorker1.ReportProgress((int)Math.Ceiling(100.0f * (float)i / (float)j));
                }
            }
            catch (Exception)
            {
                plug.DisableLogging = false;
                plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/BenchmarkForm/exception", "An exception occurred during benchmark"));
            }
            plug.DisableLogging = false;
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (DataGridViewRow r in dgvResults.Rows)
                {
                    List<string> wot = new List<string>();
                    foreach (DataGridViewCell c in r.Cells)
                    {                        
                        wot.Add(c.Value != null ? "\"" + c.Value.ToString() + "\"" : "");
                    }
                    sb.AppendLine(String.Join(",", wot));
                }
                Clipboard.SetText(sb.ToString());
            }
            catch (Exception)
            {
            }
        }

    }

}
