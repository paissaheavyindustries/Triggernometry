using System.Collections.Generic;
using Triggernometry.VariableTypes;

namespace Triggernometry.Scripting
{

    public class VariablePool
    {

        internal Dictionary<string, VariableScalar> scalarvariables = new Dictionary<string, VariableScalar>();
        internal Dictionary<string, VariableList> listvariables = new Dictionary<string, VariableList>();
        internal Dictionary<string, VariableTable> tablevariables = new Dictionary<string, VariableTable>();

        public void ClearScalarVariables()
        {
            lock (scalarvariables)
            {
                scalarvariables.Clear();
            }
        }

        public void ClearListVariables()
        {
            lock (listvariables)
            {
                listvariables.Clear();
            }
        }

        public void ClearTableVariables()
        {
            lock (tablevariables)
            {
                tablevariables.Clear();
            }
        }

        public bool ScalarVariableExists(string name)
        {
            lock (scalarvariables)
            {
                return scalarvariables.ContainsKey(name);
            }
        }

        public bool ListVariableExists(string name)
        {
            lock (listvariables)
            {
                return listvariables.ContainsKey(name);
            }
        }

        public bool TableVariableExists(string name)
        {
            lock (tablevariables)
            {
                return tablevariables.ContainsKey(name);
            }
        }

        public VariableScalar GetScalarVariable(string name, bool createNew = false)
        {
            lock (scalarvariables)
            {
                if (scalarvariables.ContainsKey(name) == true)
                {
                    return scalarvariables[name];
                }
                if (createNew == false)
                {
                    return null;
                }
                VariableScalar v = new VariableScalar();
                scalarvariables[name] = v;
                return v;
            }
        }

        public VariableList GetListVariable(string name, bool createNew = false)
        {
            lock (listvariables)
            {
                if (listvariables.ContainsKey(name) == true)
                {
                    return listvariables[name];
                }
                if (createNew == false)
                {
                    return null;
                }
                VariableList v = new VariableList();
                listvariables[name] = v;
                return v;
            }
        }

        public VariableTable GetTableVariable(string name, bool createNew = false)
        {
            lock (tablevariables)
            {
                if (tablevariables.ContainsKey(name) == true)
                {
                    return tablevariables[name];
                }
                if (createNew == false)
                {
                    return null;
                }
                VariableTable v = new VariableTable();
                tablevariables[name] = v;
                return v;
            }
        }

        public void SetScalarVariable(string name, VariableScalar val)
        {
            if (val == null)
            {
                return;
            }
            lock (scalarvariables)
            {
                scalarvariables[name] = val;
            }
        }

        public void SetListVariable(string name, VariableList val)
        {
            if (val == null)
            {
                return;
            }
            lock (listvariables)
            {
                listvariables[name] = val;
            }
        }

        public void SetTableVariable(string name, VariableTable val)
        {
            if (val == null)
            {
                return;
            }
            lock (tablevariables)
            {
                tablevariables[name] = val;
            }
        }

        public void UnsetScalarVariable(string name)
        {
            lock (scalarvariables)
            {
                if (scalarvariables.ContainsKey(name) == true)
                {
                    scalarvariables.Remove(name);
                }
            }
        }

        public void UnsetListVariable(string name)
        {
            lock (listvariables)
            {
                if (listvariables.ContainsKey(name) == true)
                {
                    listvariables.Remove(name);
                }
            }
        }

        public void UnsetTableVariable(string name)
        {
            lock (tablevariables)
            {
                if (tablevariables.ContainsKey(name) == true)
                {
                    tablevariables.Remove(name);
                }
            }
        }

    }

}
