using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggernometry
{

    public class Variable
    {

        public string Value { get; set; }
        public string LastChanger { get; set; }
        public DateTime LastChanged { get; set; }

        public Variable()
        {
            Value = "";
            LastChanged = DateTime.Now;
            LastChanger = "N/A";
        }

    }

}
