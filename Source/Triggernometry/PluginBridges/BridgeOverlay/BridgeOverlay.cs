using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Triggernometry;
using Triggernometry.Utilities;

namespace Triggernometry.PluginBridges
{
    public static class BridgeOverlay
    {
        public const string PluginName = "OverlayPlugin.dll";
        public const string PluginType = "RainbowMage.OverlayPlugin.PluginLoader";

        public static bool Ready;
        public static RealPlugin.PluginWrapper WrappedPlugin;
        public static object Container;
        private static MethodInfo _resolveMethodGeneric;

        static BridgeOverlay()
        {
            Initialize();
        }

        static void Initialize()
        {
            WrappedPlugin = RealPlugin.InstanceHook(PluginName, PluginType);
            object op = WrappedPlugin?.pluginObj;
            if (op == null)
            { 
                RealPlugin.plug.UnfilteredAddToLog(RealPlugin.DebugLevelEnum.Warning, "OverlayPlugin not found");
                Ready = false;
                return;
            }

            // get the container and resolve method
            try
            {
                Container = op.GetType().GetProperty("Container", BindingFlags.Public | BindingFlags.Instance)?.GetValue(op)
                    ?? throw new ReflectionNotFoundException("Container");
                _resolveMethodGeneric = Container.GetType().GetMethod("Resolve", BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null)
                    ?? throw new ReflectionNotFoundException("ResolveMethodGeneric");
                Ready = true;
            }
            catch (Exception ex)
            {
                RealPlugin.plug.UnfilteredAddToLog(RealPlugin.DebugLevelEnum.Error, 
                    I18n.Translate("internal/BridgeOverlay/failInit", 
                    "OverlayPlugin-related initialization failed due to: {0}", ex.ToString())
                );
                Ready = false;
                return;
            }
        }

        public static object Resolve(this object container, string typeName)
        {
            Type type = Type.GetType(typeName)
                ?? throw new ReflectionNotFoundException($"{typeName} type");
            MethodInfo resolveMethodSpecific = _resolveMethodGeneric.MakeGenericMethod(type);
            object resolvedInstance = resolveMethodSpecific.Invoke(container, null) 
                ?? throw new ReflectionNotFoundException($"{typeName} instance");
            return resolvedInstance;
        }

    }

    public class ReflectionNotFoundException : Exception
    {
        public ReflectionNotFoundException(string objectName) : base(I18n.Translate(
            "internal/BridgeOverlay/reflectionNotFound",
            "Failed to find reflection object ({0}) during initializing OverlayPlugin-related modules.", 
            objectName))
        {
        }
    }
}

[AttributeUsage(AttributeTargets.Class)]
public class OverlayModuleAttribute : Attribute { }