using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace Triggernometry
{

    public sealed class VariableClump
    {

        private Dictionary<string, Variable> Vars;

        public VariableClump()
        {
            Vars = new Dictionary<string, Variable>();
        }

        public string GetValue(string id)
        {
            if (Vars.ContainsKey(id) == true)
            {
                return Vars[id].Value;
            }
            return "";
        }

        public void SetValue(string id, int val)
        {
            SetValue(id, val.ToString());
        }

        public void SetValue(string id, float val)
        {
            SetValue(id, I18n.ThingToString(val));
        }

        public void SetValue(string id, double val)
        {
            SetValue(id, I18n.ThingToString(val));
        }

        public void SetValue(string id, string val)
        {
            Variable v;
            if (Vars.ContainsKey(id) == true)
            {
                v = Vars[id];
            }
            else
            {
                v = new Variable();
                Vars[id] = v;
            }
            v.Value = val;
            v.LastChanged = DateTime.Now;
            v.LastChanger = "VariableClump";            
        }

    }

}
