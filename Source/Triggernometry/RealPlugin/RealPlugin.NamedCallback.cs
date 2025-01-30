using System;
using System.Collections.Generic;
using System.Linq;

namespace Triggernometry
{

    public partial class RealPlugin
    {
        public class NamedCallback
        {

            public int Id { get; set; }
            public string Name { get; set; }
            public Delegate Callback { get; set; }
            public object Obj { get; set; }
            public string Registrant { get; set; }
            public DateTime RegistrationTime { get; set; }
            public DateTime? LastInvoked { get; set; }

            public void Invoke(string val)
            {
                Callback.DynamicInvoke(new object[] { Obj, val });
                LastInvoked = DateTime.Now;
            }

        }

        internal Dictionary<int, NamedCallback> callbacksById = new Dictionary<int, NamedCallback>();
        internal Dictionary<string, List<NamedCallback>> callbacksByName = new Dictionary<string, List<NamedCallback>>();

        public void InvokeNamedCallback(string name, string val)
        {
            List<NamedCallback> cbs = new List<NamedCallback>();
            lock (callbacksByName)
            {
                if (callbacksByName.ContainsKey(name) == true)
                {
                    cbs.AddRange(callbacksByName[name]);
                }
            }
            foreach (NamedCallback nc in cbs)
            {
                try
                {
                    nc.Invoke(val);
                }
                catch (Exception ex)
                {
                    Exception inner = ex;
                    while (inner.InnerException != null)
                    {
                        inner = inner.InnerException;
                    }
                    FilteredAddToLog(DebugLevelEnum.Error, I18n.Translate("internal/NamedCallback/exception",
                        "Exception occurred when invoking named callback {0}:\n {1}", name, inner.ToString()));
                }
            }
        }

        public void RegisterNamedCallback(int id, string name, Delegate callback, object o, string registrant)
        {
            NamedCallback nc = new NamedCallback
            {
                Id = id,
                Callback = callback,
                Obj = o,
                Name = name,
                Registrant = registrant,
                RegistrationTime = DateTime.Now,
            };
            lock (callbacksById)
            {
                callbacksById[id] = nc;
                if (callbacksByName.ContainsKey(name) == false)
                {
                    callbacksByName[name] = new List<NamedCallback>();
                }
                callbacksByName[name].Add(nc);
            }
        }

        // used in scripts
        public int RegisterNamedCallback(string name, Delegate callback, object o, bool allowDuplicatedName = false, string registrant = "Triggernometry Script")
        {
            if (!allowDuplicatedName)
            {
                UnregisterNamedCallback(name);
            }

            int id;
            lock (callbacksById)
            {
                id = (callbacksById.Count == 0) ? 1 : callbacksById.Keys.Max() + 1;
            }

            RegisterNamedCallback(id, name, callback, o, registrant);
            return id;
        }

        public void UnregisterNamedCallback(int id)
        {
            lock (callbacksById)
            {
                NamedCallback nc = null;
                if (callbacksById.ContainsKey(id) == false)
                {
                    return;
                }
                nc = callbacksById[id];
                callbacksById.Remove(id);
                callbacksByName[nc.Name].Remove(nc);
                if (callbacksByName[nc.Name].Count == 0)
                {
                    callbacksByName.Remove(nc.Name);
                }
            }
        }

        public void UnregisterNamedCallback(string name)
        {   // unregister all callbacks with the given name
            lock (callbacksById)
            {
                if (!callbacksByName.ContainsKey(name))
                {
                    return;
                }
                foreach (NamedCallback nc in callbacksByName[name])
                {
                    callbacksById.Remove(nc.Id);
                }
                callbacksByName.Remove(name);
            }
        }

    }

}
