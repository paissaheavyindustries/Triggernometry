using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Triggernometry.Variables
{

    [XmlRoot(ElementName = "VariableList")]
    public class VariableList : Variable
    {

        [XmlArrayItem(ElementName = "VariableScalar", Type = typeof(VariableScalar))]
        [XmlArrayItem(ElementName = "VariableList", Type = typeof(VariableList))]
        [XmlArrayItem(ElementName = "VariableTable", Type = typeof(VariableTable))]
        public List<Variable> Values { get; set; } = new List<Variable>();

        public VariableList()
        {
        }

        public VariableList(IEnumerable<object> objs)
        {
            foreach (object obj in objs)
            {
                Values.Add(new VariableScalar() { Value = obj.ToString() });
            }
        }

        public override string ToString()
        {
            return String.Join(",", Values);
        }

        public override int CompareTo(object o)
        {
            if ((o is Variable) == false)
            {
                throw new InvalidOperationException();
            }
            if (o is VariableScalar)
            {
                return 1;
            }
            if (o is VariableList)
            {
                VariableList v = (VariableList)o;
                if (v.Values.Count > Values.Count)
                {
                    return -1;
                }
                if (v.Values.Count < Values.Count)
                {
                    return 1;
                }
                for (int i = 0; i < Values.Count; i++)
                {
                    int res = Values[i].CompareTo(v.Values[i]);
                    if (res != 0)
                    {
                        return res;
                    }
                }
                return 0;
            }
            return -1;
        }

        public override Variable Duplicate()
        {
            VariableList v = new VariableList();
            foreach (Variable vx in Values)
            {
                v.Push(vx.Duplicate(), "");
            }
            v.LastChanger = LastChanger;
            v.LastChanged = LastChanged;
            return v;
        }

        public void Push(Variable value, string changer)
        {
            Values.Add(value);
            LastChanged = DateTime.Now;
            LastChanger = changer;
        }

        public Variable QueuePop(string changer)
        {
            if (Values.Count > 0)
            {
                Variable x = Values[0];
                Values.RemoveAt(0);
                LastChanged = DateTime.Now;
                LastChanger = changer;
                return x;
            }
            return null;
        }

        public Variable StackPop(string changer)
        {
            if (Values.Count > 0)
            {
                int idx = Values.Count - 1;
                Variable x = Values[idx];
                Values.RemoveAt(idx);
                LastChanged = DateTime.Now;
                LastChanger = changer;
                return x;
            }
            return null;
        }

        public void Insert(int index, Variable value, string changer)
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
                    Push(null, changer);
                    needcre--;
                }                
            }
            Values.Insert(idx, value);
            LastChanged = DateTime.Now;
            LastChanger = changer;
        }

        public void Insert(int index, string value, string changer)
        {
            Insert(index, new VariableScalar() { Value = value }, changer);
        }

        public void Set(int index, Variable value, string changer)
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
                    Push(new VariableScalar() { Value = "" }, changer);
                    needcre--;
                }
            }
            Values[idx] = value;
            LastChanged = DateTime.Now;
            LastChanger = changer;
        }

        public void Set(int index, string value, string changer)
        {
            Set(index, new VariableScalar() { Value = value }, changer);
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

        public Variable Peek(int index)
        {
            int idx = index - 1;
            if (idx >= 0 && idx < Values.Count)
            {
                return Values[index - 1];
            }
            return new VariableScalar();
        }

        public void RemoveAll(string changer)
        {
            Values.Clear();
            LastChanged = DateTime.Now;
            LastChanger = changer;
        }

        public int IndexOf(Variable value)
        {
            for (int i = 0; i < Values.Count; i++)
            {
                if (Values[i].CompareTo(value) == 0)
                {
                    return i + 1;
                }
            }
            return 0;
        }

        public int IndexOf(string value)
        {
            return IndexOf(new VariableScalar() { Value = value });
        }

        public int LastIndexOf(Variable value)
        {
            for (int i = Values.Count - 1; i >= 0; i--)
            {
                if (Values[i].CompareTo(value) == 0)
                {
                    return i + 1;
                }
            }
            return 0;
        }

        public int LastIndexOf(string value)
        {
            return LastIndexOf(new VariableScalar() { Value = value });
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
                VariableDictionary pa = PluginBridges.BridgeFFXIV.GetNamedPartyMember(a.ToString());
                VariableDictionary pb = PluginBridges.BridgeFFXIV.GetNamedPartyMember(b.ToString());
                if (cfg.FfxivPartyOrdering == Configuration.FfxivPartyOrderingEnum.CustomSelfFirst)
                {
                    VariableDictionary se = PluginBridges.BridgeFFXIV.GetMyself();
                    if (se == pa)
                    {
                        return -1;
                    }
                    if (se == pb)
                    {
                        return 1;
                    }
                }
                int vla = cfg.GetPartyOrderValue(pa.GetValue("jobid").ToString());
                int vlb = cfg.GetPartyOrderValue(pb.GetValue("jobid").ToString());
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
                VariableDictionary pa = PluginBridges.BridgeFFXIV.GetNamedPartyMember(a.ToString());
                VariableDictionary pb = PluginBridges.BridgeFFXIV.GetNamedPartyMember(b.ToString());
                if (cfg.FfxivPartyOrdering == Configuration.FfxivPartyOrderingEnum.CustomSelfFirst)
                {
                    VariableDictionary se = PluginBridges.BridgeFFXIV.GetMyself();
                    if (se == pa)
                    {
                        return 1;
                    }
                    if (se == pb)
                    {
                        return -1;
                    }
                }
                int vla = cfg.GetPartyOrderValue(pa.GetValue("jobid").ToString());
                int vlb = cfg.GetPartyOrderValue(pb.GetValue("jobid").ToString());
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
