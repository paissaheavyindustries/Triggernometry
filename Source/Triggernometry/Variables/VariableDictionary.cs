using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Serialization;

namespace Triggernometry.Variables
{
    [XmlRoot(ElementName = "VariableDictionary")]
    public sealed class VariableDictionary : Variable
    {
        private Dictionary<string, Variable> _values = new Dictionary<string, Variable>(StringComparer.OrdinalIgnoreCase);

        [XmlIgnore]
        public Dictionary<string, Variable> Values
        { 
            get => _values;
            set
            {
                _values = value?.ToDictionary(pair => pair.Key, pair => pair.Value, StringComparer.OrdinalIgnoreCase) 
                    ?? new Dictionary<string, Variable>(StringComparer.OrdinalIgnoreCase);
            }
        }

        [XmlArray("Items")]
        [XmlArrayItem("Item")]
        public KeyValue[] KeyValuePairs
        {
            get
            {
                List<KeyValue> list = new List<KeyValue>();
                foreach (KeyValuePair<string, Variable> pair in Values)
                {
                    list.Add(new KeyValue() { Key = pair.Key, Value = pair.Value });
                }
                return list.ToArray();
            }
            set
            {
                Values.Clear();
                foreach (KeyValue kv in value)
                {
                    Values[kv.Key] = kv.Value;
                }
            }
        }

        public class KeyValue
        {
            [XmlElement("Key")]
            public string Key { get; set; }

            [XmlElement("Value")]
            public Variable Value { get; set; }
        }

        public VariableDictionary() { }
        public VariableDictionary(Dictionary<string, string> dict)
        {
            Values = dict.ToDictionary(
                p => p.Key,
                p => (Variable)new VariableScalar(p.Value)
            );
        }

        public int Size
        {
            get { return Values.Count; }
        }

        private const string DEFAULTCHANGER = "VariableDictionary";

        public override string ToString()
        {
            return String.Join(",", Values.Select(pair => $"{pair.Key}={pair.Value}"));
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
                return 1;
            }
            if (o is VariableDictionary)
            {
                VariableDictionary v = (VariableDictionary)o;
                if (v.Values.Keys.Count > Values.Keys.Count)
                {
                    return -1;
                }
                if (v.Values.Keys.Count < Values.Keys.Count)
                {
                    return 1;
                }
                List<string> a = new List<string>(Values.Keys);
                List<string> b = new List<string>(v.Values.Keys);
                a.Sort();
                b.Sort();
                for (int i = 0; i < a.Count; i++)
                {
                    int res = a[i].CompareTo(b[i]);
                    if (res != 0)
                    {
                        return res;
                    }
                    res = Values[a[i]].CompareTo(v.Values[a[i]]);
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
            VariableDictionary v = new VariableDictionary();
            foreach (KeyValuePair<string, Variable> kp in Values)
            {
                v.SetValue(kp.Key, kp.Value.Duplicate());
            }
            v.LastChanger = LastChanger;
            v.LastChanged = LastChanged;
            return v;
        }

        public Variable GetValue(string id)
            => Values.TryGetValue(id, out var result) ? result : new VariableScalar();

        public string GetStringValue(string id)
            => Values.TryGetValue(id, out var result) ? result.ToString() : "";

        public void SetValue(string id, int val, string changer = DEFAULTCHANGER)
        {
            InternalSetValue(id, new VariableScalar() { Value = I18n.ThingToString(val) }, changer);
        }

        public void SetValue(string id, float val, string changer = DEFAULTCHANGER)
        {
            InternalSetValue(id, new VariableScalar() { Value = I18n.ThingToString(val) }, changer);
        }

        public void SetValue(string id, double val, string changer = DEFAULTCHANGER)
        {
            InternalSetValue(id, new VariableScalar() { Value = I18n.ThingToString(val) }, changer);
        }

        public void SetValue(string id, string val, string changer = DEFAULTCHANGER)
        {
            InternalSetValue(id, new VariableScalar() { Value = val }, changer);
        }

        public void SetValue(string id, Variable val, string changer = DEFAULTCHANGER)
        {
            InternalSetValue(id, val.Duplicate(), changer);
        }

        private void InternalSetValue(string id, Variable val, string changer)
        {
            Values[id] = val;
            LastChanged = DateTime.Now;
            LastChanger = changer;
        }

        public void RemoveKey(string key, string changer)
        {
            if (Values.ContainsKey(key))
            {
                Values.Remove(key);
                LastChanged = DateTime.Now;
                LastChanger = changer;
            }
        }

        public bool ContainsKey(string key)
        {
            return Values.ContainsKey(key);
        }

        public bool ContainsValue(string value)
        {
            return Values.Values.Any(var => var.ToString() == value);
        }

        public int Count(string str)
        {
            return Values.Count(pair => pair.Value.ToString() == str);
        }

        public double Sum()
        {
            double sum = 0;
            foreach (Variable varValue in Values.Values)
            {
                if (double.TryParse(varValue.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                    sum += value;
            }
            return sum;
        }

        public double SumKeys()
        {
            double sum = 0;
            foreach (string key in Values.Keys)
            {
                if (double.TryParse(key, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                    sum += value;
            }
            return sum;
        }

        public double Min(double initValue)
        {
            double min = initValue;
            foreach (var item in Values.Values)
            {
                if (double.TryParse(item.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out double num))
                {
                    if (num < min) { min = num; }
                }
            }
            return min;
        }

        public string KeyOf(string value)
        {
            var keys = Values.Where(pair => pair.Value.ToString() == value)
                             .Select(pair => pair.Key);
            return keys.FirstOrDefault() ?? "";
        }

        public string KeysOf(string value, string joiner)
        {
            var keys = Values.Where(pair => pair.Value.ToString() == value)
                             .Select(pair => pair.Key);
            return String.Join(joiner, keys);
        }

        public string JoinKeys(string joiner)
        {
            return String.Join(joiner, Values.Keys);
        }

        public string JoinValues(string joiner)
        {
            return String.Join(joiner, Values.Values.Select(v => v.ToString()));
        }

        public string JoinAll(string kvJoiner, string pairJoiner)
        {
            return String.Join(pairJoiner, Values.Select(pair => pair.Key + kvJoiner + pair.Value.ToString()));
        }

        public void Merge(VariableDictionary sourceDict, bool overwriteExistingKeys = true)
        {
            foreach (var pair in sourceDict.Values)
            {
                if (overwriteExistingKeys || !Values.ContainsKey(pair.Key))
                {
                    Values[pair.Key] = pair.Value;
                }
            }
        }

        public static VariableDictionary Build(string expression, char kvSeparator, char pairSeparator, string changer)
        {   // in actions
            string[] pairs = expression.Split(pairSeparator);
            VariableDictionary vd = new VariableDictionary();
            foreach (string pair in pairs)
            {
                int sepIndex = pair.IndexOf(kvSeparator);
                bool sep = (sepIndex >= 0);
                string k = sep ? pair.Substring(0, sepIndex) : pair;
                string v = sep ? pair.Substring(sepIndex + 1) : "";
                vd.SetValue(k, v, changer);
            }
            return vd;
        }

        public static VariableDictionary BuildTemp(string expression)
        {   // in expressions: ${?d: a:1, b:2, c:3 [xxx][xxx]}
            string[] pairs = Context.SplitArguments(expression);
            VariableDictionary vd = new VariableDictionary();
            foreach (string pair in pairs)
            {
                string[] kv = Context.SplitArguments(pair + "=", separator: "="); // in case only a key was given
                vd.Values[kv[0]] = new VariableScalar() { Value = kv[1] };
            }
            return vd;
        }
    }

}
