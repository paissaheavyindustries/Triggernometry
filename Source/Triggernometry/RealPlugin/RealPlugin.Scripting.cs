using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Triggernometry
{

    public partial class RealPlugin
    {
        internal Interpreter scripting;
        internal bool scriptingInited = false;
        internal Dictionary<string, object> scriptingStorage = new Dictionary<string, object>();
        private List<Configuration.APIUsage> DefaultAPIUsages = Interpreter.SecurityAPIs.Select(name => new Configuration.APIUsage
        {
            Name = name,
            AllowLocal = false,
            AllowRemote = false,
            AllowAdmin = false
        }).ToList();

        private void InitScripting()
        {
            try
            {
                scripting = new Interpreter();
            }
            catch (Exception ex)
            {
                FilteredAddToLog(DebugLevelEnum.Error, I18n.Translate("internal/Plugin/iniscripterror", "Error when initializing scripting - try changing plugin load order: {0}", ex.Message));
            }
        }

        internal List<Configuration.APIUsage> GetDefaultAPIUsages()
        {
            List<Configuration.APIUsage> l = new List<Configuration.APIUsage>();
            foreach (Configuration.APIUsage a in DefaultAPIUsages)
            {
                l.Add(new Configuration.APIUsage() { Name = a.Name, AllowLocal = a.AllowLocal, AllowRemote = a.AllowRemote, AllowAdmin = a.AllowAdmin });
            }
            return l;
        }

        private void SetupDefaultSecurity()
        {
            MethodInfo setter = cfg.GetType().GetMethod("AddAPIUsage", BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (Configuration.APIUsage a in DefaultAPIUsages)
            {
                setter.Invoke(cfg, new object[] { a, false });
            }
        }

    }
}
