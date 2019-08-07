using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Triggernometry
{

    public class TriggernometryExport
    {

        [XmlAttribute]
        public int Version { get; set; }

        public Folder ExportedFolder;
        public Trigger ExportedTrigger;        

        public TriggernometryExport()
        {
            Version = 1;
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
            }
            return null;
        }

    }

}
