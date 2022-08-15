﻿using System;
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
            NetworkFFXIV,
            ACT
        }

        public string Text { get; set; }
        public string ZoneName { get; set; }
        public SourceEnum Source { get; set; }
        public DateTime Timestamp { get; set; }
        public bool TestMode { get; set; } = false;
        public string ZoneId { get; set; }

    }

}
