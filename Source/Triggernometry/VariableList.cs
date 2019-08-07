using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggernometry
{

    public class VariableList
    {

        public List<string> Values { get; set; }
        public string LastChanger { get; set; }
        public DateTime LastChanged { get; set; }

        public VariableList()
        {
            Values = new List<string>();
            LastChanged = DateTime.Now;
            LastChanger = "N/A";
        }

        public void Push(string value, string changer)
        {
            Values.Add(value);
            LastChanged = DateTime.Now;
            LastChanger = changer;
        }

        public string QueuePop(string changer)
        {
            if (Values.Count > 0)
            {
                string x = Values[0];
                Values.RemoveAt(0);
                LastChanged = DateTime.Now;
                LastChanger = changer;
                return x;
            }
            return "";
        }

        public string StackPop(string changer)
        {
            if (Values.Count > 0)
            {
                int idx = Values.Count - 1;
                string x = Values[idx];
                Values.RemoveAt(idx);
                LastChanged = DateTime.Now;
                LastChanger = changer;
                return x;
            }
            return "";
        }

        public void Insert(int index, string value, string changer)
        {
            int idx = index - 1;
            if (idx < 0)
            {
                idx = 0;
            }
            if (idx >= Values.Count)
            {
                int needcre = idx - Values.Count;
                while (needcre > 0)
                {
                    Push("", changer);
                    needcre--;
                }                
            }
            Values.Insert(idx, value);
            LastChanged = DateTime.Now;
            LastChanger = changer;
        }

        public void Set(int index, string value, string changer)
        {
            int idx = index - 1;
            if (idx < 0)
            {
                idx = 0;
            }
            if (idx >= Values.Count)
            {
                int needcre = idx - Values.Count;
                while (needcre > 0)
                {
                    Push("", changer);
                    needcre--;
                }
            }
            Values[idx] = value;
            LastChanged = DateTime.Now;
            LastChanger = changer;
        }

        public void Remove(int index, string changer)
        {
            int idx = index - 1;
            if (idx >= 0 && idx < Values.Count)
            {
                Values.RemoveAt(index - 1);
                LastChanged = DateTime.Now;
                LastChanger = changer;
            }
        }

        public string Peek(int index)
        {
            int idx = index - 1;
            if (idx >= 0 && idx < Values.Count)
            {
                return Values[index - 1];
            }
            return "";
        }

        public void RemoveAll(string changer)
        {
            Values.Clear();
            LastChanged = DateTime.Now;
            LastChanger = changer;
        }

        public int IndexOf(string value)
        {
            int i = 1;
            foreach (string x in Values)
            {
                if (x == value)
                {
                    return i;
                }
                i++;
            }
            return 0;
        }

        public int Size()
        {
            return Values.Count;
        }

        public string Join(string joiner)
        {
            return String.Join(joiner, Values);
        }

        public void SortAlphaAsc(string changer)
        {
            Values.Sort((a, b) => a.CompareTo(b));
            LastChanged = DateTime.Now;
            LastChanger = changer;
        }

        public void SortAlphaDesc(string changer)
        {
            Values.Sort((a, b) => a.CompareTo(b) * -1);
            LastChanged = DateTime.Now;
            LastChanger = changer;
        }

        public void SortFfxivPartyAsc(Configuration cfg, string changer)
        {
            Values.Sort((a, b) =>
            {
                VariableClump pa = PluginBridges.BridgeFFXIV.GetNamedPartyMember(a);
                VariableClump pb = PluginBridges.BridgeFFXIV.GetNamedPartyMember(b);
                if (cfg.FfxivPartyOrdering == Configuration.FfxivPartyOrderingEnum.CustomSelfFirst)
                {
                    VariableClump se = PluginBridges.BridgeFFXIV.GetMyself();
                    if (se == pa)
                    {
                        return -1;
                    }
                    if (se == pb)
                    {
                        return 1;
                    }
                }
                int vla = cfg.GetPartyOrderValue(pa.GetValue("jobid"));
                int vlb = cfg.GetPartyOrderValue(pb.GetValue("jobid"));
                if (vla < vlb)
                {
                    return -1;
                }
                if (vla > vlb)
                {
                    return 1;
                }
                return pa.GetValue("name").CompareTo(pb.GetValue("name"));
            });
        }

        public void SortFfxivPartyDesc(Configuration cfg, string changer)
        {
            Values.Sort((a, b) =>
            {
                VariableClump pa = PluginBridges.BridgeFFXIV.GetNamedPartyMember(a);
                VariableClump pb = PluginBridges.BridgeFFXIV.GetNamedPartyMember(b);
                if (cfg.FfxivPartyOrdering == Configuration.FfxivPartyOrderingEnum.CustomSelfFirst)
                {
                    VariableClump se = PluginBridges.BridgeFFXIV.GetMyself();
                    if (se == pa)
                    {
                        return 1;
                    }
                    if (se == pb)
                    {
                        return -1;
                    }
                }
                int vla = cfg.GetPartyOrderValue(pa.GetValue("jobid"));
                int vlb = cfg.GetPartyOrderValue(pb.GetValue("jobid"));
                if (vla < vlb)
                {
                    return 1;
                }
                if (vla > vlb)
                {
                    return -1;
                }
                return pa.GetValue("name").CompareTo(pb.GetValue("name")) * -1;
            });
        }

    }

}
