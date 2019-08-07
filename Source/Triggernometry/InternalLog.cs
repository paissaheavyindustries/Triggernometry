using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggernometry
{

    public sealed class InternalLog
    {

        public DateTime Timestamp { get; set; }
        public Plugin.DebugLevelEnum Level { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return Plugin.FormatDateTime(Timestamp) + " - " + I18n.Translate("internal/Plugin/loglevel" + Level.ToString(), "{0}", Level.ToString()) + " - " + Message;
        }

    }

}
