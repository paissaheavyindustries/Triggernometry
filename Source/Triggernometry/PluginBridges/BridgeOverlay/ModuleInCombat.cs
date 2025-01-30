using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Triggernometry.PluginBridges
{
    [OverlayModule]
    internal static class ModuleInCombat
    {
        public static bool Ready;
        private static object _inCombatMemoryManager;
        private static MethodInfo _getInCombatMethod;

        static ModuleInCombat()
        {
            try
            {
                _inCombatMemoryManager = BridgeOverlay.Container.Resolve($"RainbowMage.OverlayPlugin.MemoryProcessors.InCombat.IInCombatMemory, OverlayPlugin.Core");
                _getInCombatMethod = _inCombatMemoryManager.GetType().GetMethod("GetInCombat", BindingFlags.Public | BindingFlags.Instance)
                    ?? throw new ReflectionNotFoundException("GetInCombatMethod");
                Ready = true;
            }
            catch (Exception ex)
            {
                RealPlugin.plug.UnfilteredAddToLog(RealPlugin.DebugLevelEnum.Error, 
                    I18n.Translate("internal/BridgeOverlay/failInitModule", 
                    "OverlayPlugin {1} module initialization failed due to: {0}", 
                    ex.ToString(), "InCombat")
                );
                Ready = false;
            }
        }

        public static bool GetInCombat()
        {
            if (!Ready) return false;
            return (bool)_getInCombatMethod.Invoke(_inCombatMemoryManager, null);
        }
    }
}