using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Triggernometry.Forms
{

    public partial class RepositoryListForm : MemoryForm<RepositoryListForm>
    {

        private delegate void ProgressDelegate(int progress, string state);
        internal Plugin plug { get; set; }

        internal List<RepositoryList.Repository> ReposToAdd { get; set; } = new List<RepositoryList.Repository>();

        public RepositoryListForm()
        {
            InitializeComponent();
            RestoredSavedDimensions();
            Shown += RepositoryListForm_Shown;
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

        private void RepositoryListForm_Shown(object sender, EventArgs e)
        {
            string trans = I18n.Translate("RepositoryListForm/statusdownloading", "Downloading master repository list...");
            ShowProgress(-1, trans);
            plug.FilteredAddToLog(Plugin.DebugLevelEnum.Info, trans);
            Task tx = new Task(() =>
            {
                RepositoryListDownload();
            });
            tx.Start();
        }

        private void RepositoryListDownload()
        {
            string trans;
            try
            {
                string data;
                using (WebClient wc = new WebClient())
                {
                    wc.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                    wc.Headers["User-Agent"] = "Triggernometry Repository List Downloader";
                    byte[] rawdata = wc.DownloadData(@"https://raw.githubusercontent.com/paissaheavyindustries/Triggernometry/master/Repositories/manifest.xml?temp=" + DateTime.Now.Ticks);
                    data = Encoding.UTF8.GetString(rawdata);
                }
                RepositoryList rl = RepositoryList.Unserialize(data);
                if (rl == null)
                {
                    throw new InvalidOperationException(I18n.Translate("RepositoryListForm/masterlistproblem", "Data from master repository list could not be unserialized"));
                }
                ParseRepositoryList(rl);
                trans = I18n.Translate("RepositoryListForm/downloadcomplete", "Download complete");
                plug.FilteredAddToLog(Plugin.DebugLevelEnum.Info, trans);
                ShowProgress(100, trans);
                System.Threading.Thread.Sleep(2000);
                ShowProgress(0, "");
            }
            catch (Exception ex)
            {
                trans = I18n.Translate("RepositoryListForm/exception", "Download failed due to exception: {0}", ex.Message);
                plug.FilteredAddToLog(Plugin.DebugLevelEnum.Error, trans);
                ShowProgress(100, trans);
            }
        }

        private void ParseRepositoryList(RepositoryList rl)
        {
            List<TreeNode> tns = new List<TreeNode>();
            foreach (RepositoryList.Category c in rl.Categories)
            {
                TreeNode tn = HandleRepoCategory(null, c);
                tns.Add(tn);
            }
            AddToTree(tns);
        }

        private delegate void TreeDelegate(IEnumerable<TreeNode> tns);

        private void AddToTree(IEnumerable<TreeNode> tns)
        {
            if (trvRepositories.InvokeRequired == true)
            {
                trvRepositories.Invoke(new TreeDelegate(AddToTree), tns);
                return;
            }
            trvRepositories.Nodes.AddRange(tns.ToArray());
            if (tns.Count() != 0)
            {
                trvRepositories.Enabled = true;
            }
            trvRepositories.ExpandAll();
            if (trvRepositories.Nodes.Count > 0)
            {
                trvRepositories.Nodes[0].EnsureVisible();
            }
        }

        private TreeNode HandleRepoCategory(TreeNode parent, RepositoryList.Category c)
        {
            TreeNode tn = new TreeNode();
            tn.Text = c.Name;
            tn.Tag = c;
            if (parent != null)
            {
                parent.Nodes.Add(tn);
            }
            foreach (RepositoryList.Category subc in c.Categories)
            {
                HandleRepoCategory(tn, subc);                
            }
            foreach (RepositoryList.Repository subr in c.Repositories)
            {
                HandleRepo(tn, subr);
            }
            return tn;
        }

        private void HandleRepo(TreeNode parent, RepositoryList.Repository r)
        {
            TreeNode tn = new TreeNode();
            tn.Text = r.Name;
            tn.Tag = r;
            if (parent != null)
            {
                parent.Nodes.Add(tn);
            }
        }

        private void trvRepositories_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node == null)
            {
                txtRepoDetails.Text = "";
                return;
            }
            if (e.Node.Tag is RepositoryList.Category)
            {
                RepositoryList.Category c = (RepositoryList.Category)e.Node.Tag;
                txtRepoDetails.Text = c.Description;
            }
            if (e.Node.Tag is RepositoryList.Repository)
            {
                RepositoryList.Repository r = (RepositoryList.Repository)e.Node.Tag;
                txtRepoDetails.Text = r.Description;
            }
        }

        private void trvRepositories_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is RepositoryList.Repository)
            {
                RepositoryList.Repository r = (RepositoryList.Repository)e.Node.Tag;
                if (e.Node.Checked == true)
                {
                    if (ReposToAdd.Contains(r) == false)
                    {
                        ReposToAdd.Add(r);
                    }
                }
                else
                {
                    if (ReposToAdd.Contains(r) == true)
                    {
                        ReposToAdd.Remove(r);
                    }
                }
            }
            if (e.Node.Tag is RepositoryList.Category)
            {
                foreach (TreeNode tn in e.Node.Nodes)
                {
                    tn.Checked = e.Node.Checked;
                }
            }
            btnOk.Enabled = (ReposToAdd.Count > 0);
        }

    }

}
