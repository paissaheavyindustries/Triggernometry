using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triggernometry.Aura
{

    internal sealed class AuraImage : Aura
    {

        internal string ImageFilenameExpression { get; set; }

        private string _ImageFileName;
        internal string ImageFileName
        {
            get
            {
                return _ImageFileName;
            }
            set
            {
                if (value != _ImageFileName)
                {
                    Changed = true;
                    _ImageFileName = value;
                }
            }
        }

        private PictureBoxSizeMode _Display;
        internal PictureBoxSizeMode Display
        {
            get
            {
                return _Display;
            }
            set
            {
                if (value != _Display)
                {
                    Changed = true;
                    _Display = value;
                }
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        internal static string GetImageFilename(Triggernometry.RealPlugin plug, string ifn)
        {
            Uri u = new Uri(ifn);
            if (u.IsFile == true)
            {
                return ifn;
            }
            else
            {
                string fn = Path.Combine(plug.path, "TriggernometryRemoteImages");
                if (Directory.Exists(fn) == false)
                {
                    Directory.CreateDirectory(fn);
                }
                string ext = Path.GetExtension(u.LocalPath);
                fn = Path.Combine(fn, plug.GenerateHash(u.AbsoluteUri) + Path.GetExtension(u.LocalPath));
                if (File.Exists(fn) == true)
                {
                    FileInfo fi = new FileInfo(fn);
                    DateTime dt = DateTime.Now.AddMinutes(0 - plug.cfg.CacheImageExpiry);
                    if (fi.LastWriteTime > dt)
                    {
                        return fn;
                    }
                }
                using (WebClient wc = new WebClient())
                {
                    wc.Headers["User-Agent"] = "Triggernometry Image Retriever";
                    byte[] data = wc.DownloadData(u.AbsoluteUri);
                    File.WriteAllBytes(fn, data);
                    return fn;
                }
            }
        }

    }

}
