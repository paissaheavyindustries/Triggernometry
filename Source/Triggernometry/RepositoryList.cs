using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Triggernometry
{

    public class RepositoryList
    {

        public class Category
        {

            [XmlAttribute]
            public string Name { get; set; } = "(not set)";
            [XmlAttribute]
            public string Description { get; set; } = "(not set)";

            public List<Category> Categories { get; set; } = new List<Category>();
            public List<Repository> Repositories { get; set; } = new List<Repository>();

        }

        public class Repository
        {

            [XmlAttribute]
            public string Name { get; set; } = "(not set)";
            [XmlAttribute]
            public string Address { get; set; } = "(not set)";
            [XmlAttribute]
            public string Description { get; set; } = "(not set)";

        }

        public List<Category> Categories { get; set; } = new List<Category>();

        public string Serialize()
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer xs = new XmlSerializer(typeof(RepositoryList));
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

        static public RepositoryList Unserialize(string src)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(RepositoryList));
                using (MemoryStream ms = new MemoryStream(UTF8Encoding.UTF8.GetBytes(src)))
                {
                    return (RepositoryList)xs.Deserialize(ms);
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

    }

}
