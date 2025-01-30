using System;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace Triggernometry
{

    public partial class RealPlugin
    {

        internal static string FormatDateTime(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        internal string GenerateHash(string addy)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(addy);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
        }

        public bool CheckIfAdministrator(bool warnIfNotAdmin)
        {
            bool ret;
            using (var identity = WindowsIdentity.GetCurrent())
            {
                var principal = new WindowsPrincipal(identity);
                ret = principal.IsInRole(WindowsBuiltInRole.Administrator);
                if (ret == false && warnIfNotAdmin == true)
                {
                    CustomControls.Toast t = new CustomControls.Toast();
                    t.ToastText = I18n.Translate("internal/Plugin/notadministrator", "You are not running ACT as an administrator - this might prevent some triggers from working.");
                    t.ToastType = CustomControls.Toast.ToastTypeEnum.OK;
                    ui.QueueToast(t);
                }
            }
            return ret;
        }

        internal static string SerializeInvalidXmlCharacters(string ex)
        {
            ex = ex.Replace("&#x0;", "␀");
            ex = ex.Replace("&#x1;", "␁");
            ex = ex.Replace("&#x2;", "␂");
            ex = ex.Replace("&#x3;", "␃");
            ex = ex.Replace("&#x4;", "␄");
            ex = ex.Replace("&#x5;", "␅");
            ex = ex.Replace("&#x6;", "␆");
            ex = ex.Replace("&#x7;", "␇");
            ex = ex.Replace("&#x8;", "␈");
            ex = ex.Replace("&#x9;", "␉");
            ex = ex.Replace("&#xa;", "␊");
            ex = ex.Replace("&#xb;", "␋");
            ex = ex.Replace("&#xc;", "␌");
            ex = ex.Replace("&#xd;", "␍");
            ex = ex.Replace("&#xe;", "␎");
            ex = ex.Replace("&#xf;", "␏");
            ex = ex.Replace("&#x10;", "␐");
            ex = ex.Replace("&#x11;", "␑");
            ex = ex.Replace("&#x12;", "␒");
            ex = ex.Replace("&#x13;", "␓");
            ex = ex.Replace("&#x14;", "␔");
            ex = ex.Replace("&#x15;", "␕");
            ex = ex.Replace("&#x16;", "␖");
            ex = ex.Replace("&#x17;", "␗");
            ex = ex.Replace("&#x18;", "␘");
            ex = ex.Replace("&#x19;", "␙");
            ex = ex.Replace("&#x1a;", "␚");
            ex = ex.Replace("&#x1b;", "␛");
            ex = ex.Replace("&#x1c;", "␜");
            ex = ex.Replace("&#x1d;", "␝");
            ex = ex.Replace("&#x1e;", "␞");
            ex = ex.Replace("&#x1f;", "␟");
            ex = ex.Replace("&#x7f;", "␡");
            return ex;
        }

        internal static string UnserializeInvalidXmlCharacters(string ex)
        {
            char exx = '\x01';
            string hex = ex;
            ex = ex.Replace("␀", "\x00");
            ex = ex.Replace("␁", "" + exx);
            ex = ex.Replace("␂", "\x02");
            ex = ex.Replace("␃", "\x03");
            ex = ex.Replace("␄", "\x04");
            ex = ex.Replace("␅", "\x05");
            ex = ex.Replace("␆", "\x06");
            ex = ex.Replace("␇", "\x07");
            ex = ex.Replace("␈", "\x08");
            ex = ex.Replace("␉", "\x09");
            ex = ex.Replace("␊", "\x0a");
            ex = ex.Replace("␋", "\x0b");
            ex = ex.Replace("␌", "\x0c");
            ex = ex.Replace("␍", "\x0d");
            ex = ex.Replace("␎", "\x0e");
            ex = ex.Replace("␏", "\x0f");
            ex = ex.Replace("␐", "\x10");
            ex = ex.Replace("␑", "\x11");
            ex = ex.Replace("␒", "\x12");
            ex = ex.Replace("␓", "\x13");
            ex = ex.Replace("␔", "\x14");
            ex = ex.Replace("␕", "\x15");
            ex = ex.Replace("␖", "\x16");
            ex = ex.Replace("␗", "\x17");
            ex = ex.Replace("␘", "\x18");
            ex = ex.Replace("␙", "\x19");
            ex = ex.Replace("␚", "\x1a");
            ex = ex.Replace("␛", "\x1b");
            ex = ex.Replace("␜", "\x1c");
            ex = ex.Replace("␝", "\x1d");
            ex = ex.Replace("␞", "\x1e");
            ex = ex.Replace("␟", "\x1f");
            ex = ex.Replace("␡", "\x7f");
            return ex;
        }

        internal Repository GetRepositoryById(Guid id)
        {
            return (from ix in cfg.RepositoryRoot.Repositories where ix.Id == id select ix).FirstOrDefault();
        }

        internal Trigger GetTriggerById(Guid id, Repository repo)
        {
            lock (Triggers)
            {
                var ix = from ax in Triggers
                         where ax.Id == id && ax.Repo == repo
                         select ax;
                return ix.FirstOrDefault();
            }
        }

        internal Folder GetFolderById(Guid id, Repository repo)
        {
            if (repo != null)
            {
                return RecursiveFolderSearch(repo.Root, id, repo);
            }
            else
            {
                return RecursiveFolderSearch(cfg.Root, id, repo);
            }
        }

        internal Folder RecursiveFolderSearch(Folder f, Guid id, Repository repo)
        {
            if (f.Id == id && f.Repo == repo)
            {
                return f;
            }
            foreach (Folder c in f.Folders)
            {
                Folder ex = RecursiveFolderSearch(c, id, repo);
                if (ex != null)
                {
                    return ex;
                }
            }
            return null;
        }

        internal TreeNode LocateNodeHostingTrigger(TreeNode tn, Trigger t)
        {
            if (tn.Tag == t)
            {
                return tn;
            }
            foreach (TreeNode tc in tn.Nodes)
            {
                TreeNode tp = LocateNodeHostingTrigger(tc, t);
                if (tp != null)
                {
                    return tp;
                }
            }
            return null;
        }

        internal TreeNode LocateNodeHostingRepository(TreeNode tn, Repository r)
        {
            foreach (TreeNode tc in tn.Nodes)
            {
                if (tc.Tag == r)
                {
                    return tc;
                }
            }
            return null;
        }

        internal TreeNode LocateNodeHostingFolder(TreeNode tn, Folder f)
        {
            if (tn.Tag == f)
            {
                return tn;
            }
            foreach (TreeNode tc in tn.Nodes)
            {
                TreeNode tp = LocateNodeHostingFolder(tc, f);
                if (tp != null)
                {
                    return tp;
                }
            }
            return null;
        }

        internal TreeNode LocateNodeHostingTriggerId(TreeNode tn, Guid id, Repository repo)
        {
            Trigger t = GetTriggerById(id, repo);
            if (t == null)
            {
                return null;
            }
            return LocateNodeHostingTrigger(tn, t);
        }

        internal TreeNode LocateNodeHostingRepositoryId(TreeNode tn, Guid id)
        {
            Repository r = GetRepositoryById(id);
            if (r == null)
            {
                return null;
            }
            return LocateNodeHostingRepository(tn, r);
        }

        internal TreeNode LocateNodeHostingFolderId(TreeNode tn, Guid id, Repository repo)
        {
            Folder f = GetFolderById(id, repo);
            if (f == null)
            {
                return null;
            }
            return LocateNodeHostingFolder(tn, f);
        }

    }
}
