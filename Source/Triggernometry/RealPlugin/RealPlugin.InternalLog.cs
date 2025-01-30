using System;
using System.Collections.Generic;
using System.Linq;

namespace Triggernometry
{

    public partial class RealPlugin
    {

        internal bool DisableLogging = false;

        internal Dictionary<DebugLevelEnum, Queue<InternalLog>> log = Enum.GetValues(typeof(DebugLevelEnum))
            .Cast<DebugLevelEnum>()
            .ToDictionary(level => level, level => new Queue<InternalLog>());

        public enum DebugLevelEnum
        {
            None,
            Error,
            Warning,
            Custom,
            Custom2,
            Info,
            Verbose,
            Inherit
        }

        internal void ClearLog()
        {
            lock (log)
            {
                foreach (var pair in plug.log)
                {
                    pair.Value.Clear();
                }
            }
            ui?.ClearErrorCount();
        }

        internal void UnfilteredAddToLog(DebugLevelEnum level, string msg)
        {
            InternalLog il = new InternalLog() { Timestamp = DateTime.Now, Level = level, Message = msg };
            if (DisableLogging == false && System.Diagnostics.Debugger.IsAttached == true)
            {
                System.Diagnostics.Debug.WriteLine(il.ToString());
            }
            if (level == DebugLevelEnum.Error)
            {
                ui?.IncrementErrorCount();
            }
            var queue = log[level];
            lock (queue)
            {
                queue.Enqueue(il);
                if (queue.Count > 30000)
                {
                    queue.Dequeue();
                }
            }
        }

        public void FilteredAddToLog(DebugLevelEnum level, string msg)
        {
            if (cfg != null && level > cfg.DebugLevel)
            {
                return;
            }
            UnfilteredAddToLog(level, msg);
        }

    }
}
