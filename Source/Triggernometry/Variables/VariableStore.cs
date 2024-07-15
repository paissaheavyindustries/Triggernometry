using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Triggernometry.Variables
{

    public class VariableStore
    {
       
        public SerializableDictionary<string, VariableScalar> Scalar { get; set; } = new SerializableDictionary<string, VariableScalar>();

        public SerializableDictionary<string, VariableList> List { get; set; } = new SerializableDictionary<string, VariableList>();

        public SerializableDictionary<string, VariableTable> Table { get; set; } = new SerializableDictionary<string, VariableTable>();

        public SerializableDictionary<string, VariableDictionary> Dict { get; set; } = new SerializableDictionary<string, VariableDictionary>();

        public TValue GetVariable<TValue>(Dictionary<string, TValue> variables, string name, bool createNew) where TValue : new()
        {
            lock (variables)
            {
                if (variables.ContainsKey(name) == true)
                {
                    return variables[name];
                }
                TValue vl = new TValue();
                if (createNew == true)
                {
                    variables[name] = vl;
                }
                return vl;
            }
        }

        public VariableScalar GetScalarVariable(string name, bool createNew)
        {
            return GetVariable(Scalar, name, createNew);
        }

        public VariableList GetListVariable(string name, bool createNew)
        {
            return GetVariable(List, name, createNew);
        }

        public VariableTable GetTableVariable(string name, bool createNew)
        {
            return GetVariable(Table, name, createNew);
        }

        public VariableDictionary GetDictVariable(string name, bool createNew)
        {
            return GetVariable(Dict, name, createNew);
        }

        public void UnsetAllVariables<TValue>(Dictionary<string, TValue> variables)
        {
            lock (variables)
            {
                variables.Clear();
            }
        }

        public void UnsetVariable<TValue>(Dictionary<string, TValue> variables, string name)
        {
            lock (variables)
            {
                if (variables.ContainsKey(name) == true)
                {
                    variables.Remove(name);
                }
            }
        }

        public void UnsetVariableRegex<TValue>(Dictionary<string, TValue> variables, Regex rex)
        {            
            lock (variables)
            {
                List<string> keysToRemove = variables.Keys.Where(key => rex.IsMatch(key)).ToList();
                foreach (string key in keysToRemove)
                {
                    variables.Remove(key);
                }
            }
        }

        public void UnsetVariableRegex<TValue>(Dictionary<string, TValue> variables, string rex)
        {
            UnsetVariableRegex<TValue>(variables, new Regex(rex));
        }

    }

}
