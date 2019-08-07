using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Triggernometry
{

    public class RepositoryFolder
    {

        public List<Repository> Repositories { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public bool Enabled { get; set; }

        public RepositoryFolder()
        {
            Repositories = new List<Repository>();
            Enabled = true;
        }

        public Folder ConvertToFolder()
        {
            Folder f = new Folder();
            f.Enabled = Enabled;
            f.Name = Name;
            foreach (Repository r in Repositories)
            {
                Folder fx = r.Root;
                fx.Parent = f;
                f.Folders.Add(fx);
            }
            return f;
        }

    }

}
