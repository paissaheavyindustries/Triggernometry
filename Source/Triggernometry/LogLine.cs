using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggernometry
{

    internal sealed class LogEvent
    {

        public enum SourceEnum
        {
            Log,
            NetworkFFXIV
        }

        public string Text { get; set; }
        public string Zone { get; set; }
        public SourceEnum Source { get; set; }
        public DateTime Timestamp { get; set; }

    }

}
