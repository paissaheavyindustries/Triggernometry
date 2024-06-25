using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace Triggernometry
{

    public class TriggernometryExport
    {
        private Version _pluginVersion;
        [XmlAttribute]
        public string PluginVersion
        { 
            get => _pluginVersion?.ToString();
            set 
            {
                _pluginVersion = string.IsNullOrEmpty(value) ? null : new Version(value);
            }
        }

        public string PluginVersionDescription => _pluginVersion?.ToString() ?? "< 1.2.0.1";

        [XmlIgnore]
        public bool Corrupted = false;

        public Folder ExportedFolder;
        public Trigger ExportedTrigger;

        public TriggernometryExport()
        {
            _pluginVersion = null;
            ExportedFolder = null;
            ExportedTrigger = null;
        }

        public string Serialize()
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer xs = new XmlSerializer(typeof(TriggernometryExport));
            byte[] buf;
            using (MemoryStream ms = new MemoryStream())
            {
                xs.Serialize(ms, this, ns);
                ms.Seek(0, SeekOrigin.Begin);
                buf = new byte[ms.Length];
                ms.Read(buf, 0, (int)ms.Length);                
            }
            return UTF8Encoding.UTF8.GetString(buf);            
        }

        static public TriggernometryExport Unserialize(string src)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(TriggernometryExport));
                using (MemoryStream ms = new MemoryStream(UTF8Encoding.UTF8.GetBytes(src)))
                {
                    return (TriggernometryExport)xs.Deserialize(ms);
                }
            }
            catch (Exception)
            {
                Regex rexVersion = new Regex(@"TriggernometryExport[^>]+PluginVersion *= *(?<version>\d+.\d+.\d+.\d+)");
                string version = rexVersion.Match(src.Length > 100 ? src.Substring(0, 100) : src).Groups["version"].Value;
                return new TriggernometryExport() { PluginVersion = version, Corrupted = true };
            }
        }

    }

}
