using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggernometry.FFXIV
{
    public class Status
    {
        public virtual PluginSource PluginSource { get; set; } = PluginSource.None;
        public virtual ushort StatusID { get; set; }
        public virtual ushort Stack { get; set; }
        public virtual float Timer { get; set; }
        public virtual uint SourceID { get; set; }
        public virtual Entity Target { get; set; } = Entity.NullEntity();
        public string SourceHexID => SourceID.ToString("X");
        public string StatusHexID => StatusID.ToString("X");
        public virtual Status Snapshot() => new Status
        {
            PluginSource = PluginSource.None,
            StatusID = StatusID,
            Stack = Stack,
            Timer = Timer,
            SourceID = SourceID,
            Target = Target,
        };
    }

}
