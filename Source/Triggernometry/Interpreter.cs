using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Triggernometry.Variables;

namespace Triggernometry
{

    public class Interpreter
    {

        internal readonly static List<string> SecurityAPIs = new List<string>
        {
            "Microsoft.CodeAnalysis",
            "Microsoft.Win32",
            "System.CodeDom.Compiler",
            "System.Diagnostics",
            "System.IO",
            "System.Net",
            "System.Reflection",
            "System.Runtime",
            "System.Security",
            "System.Web",
            "Triggernometry.Utilities"
        };

        private class Validator
        {

            private static bool IsBadApi(string assy, params string[] badApis)
            {
                return assy != null && badApis.Any(x => assy.Contains(x) == true);
            }

            public static bool Validate(Script script, out string badApi, params string[] badApis)
            {                
                Compilation comp = script.GetCompilation();
                SyntaxTree st = comp.SyntaxTrees.First();
                CompilationUnitSyntax srn = st.GetRoot() as CompilationUnitSyntax;
                SemanticModel model = comp.GetSemanticModel(comp.SyntaxTrees.First());
                badApi = "";
                foreach (UsingDirectiveSyntax usingdir in srn.Usings)
                {
                    ISymbol symbol = model.GetSymbolInfo(usingdir.Name).Symbol;
                    string name = symbol?.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                    if (IsBadApi(name, badApis))
                    {
                        badApi = name;
                        return false;
                    }
                }
                var variables = srn.DescendantNodes().OfType<VariableDeclaratorSyntax>();
                foreach (var variable in variables)
                {
                    ISymbol symbol = model.GetDeclaredSymbol(variable);
                    ITypeSymbol type;
                    switch (symbol.Kind)
                    {
                        case SymbolKind.Field:
                            var fieldSymbol = ((IFieldSymbol)symbol);
                            type = fieldSymbol.Type;
                            break;
                        case SymbolKind.Local:
                            var localSymbol = ((ILocalSymbol)symbol);
                            type = localSymbol.Type;
                            break;
                        default:
                            continue;
                    }
                    string name = type.ContainingNamespace?.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                    if (IsBadApi(name, badApis))
                    {
                        badApi = name;
                        return false;
                    }
                }
                var invocs = srn.DescendantNodes().OfType<InvocationExpressionSyntax>();
                foreach (var invoc in invocs)
                {
                    ISymbol symbol = model.GetSymbolInfo(invoc).Symbol;
                    string name = symbol?.ContainingNamespace?.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                    if (IsBadApi(name, badApis))
                    {
                        badApi = name;
                        return false;
                    }
                }
                var methods = srn.DescendantNodes().OfType<MethodDeclarationSyntax>();
                foreach (var method in methods)
                {
                    IMethodSymbol symbol = model.GetDeclaredSymbol(method) as IMethodSymbol;
                    string name = symbol?.ContainingAssembly?.Name;
                    if (IsBadApi(name, badApis))
                    {
                        badApi = name;
                        return false;
                    }
                }
                var props = srn.DescendantNodes().OfType<PropertyDeclarationSyntax>();
                foreach (var prop in props)
                {
                    IPropertySymbol symbol = model.GetDeclaredSymbol(prop) as IPropertySymbol;
                    string name = symbol?.Type.ContainingAssembly?.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                    if (IsBadApi(name, badApis))
                    {
                        badApi = name;
                        return false;
                    }
                    name = symbol?.Type.ContainingNamespace?.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                    if (IsBadApi(name, badApis))
                    {
                        badApi = name;
                        return false;
                    }
                }
                return true;
            }

        }

        public class Helpers
        {

            public Dictionary<string, object> Storage => RealPlugin.plug.scriptingStorage;

            public RealPlugin Plugin => RealPlugin.plug;

            public Context CurrentContext { get; set; }

            public void Log(int level, string message)
            {
                Log((RealPlugin.DebugLevelEnum)level, message);
            }

            public void Log(RealPlugin.DebugLevelEnum level, string message)
            {
                if (CurrentContext != null && CurrentContext.trig != null && Plugin != null)
                {
                    CurrentContext.trig.AddToLog(Plugin, level, message);
                    return;
                }
                Plugin.FilteredAddToLog(level, message);
            }

            public void PlayTTS(string text)
            {
                Action a = new Action();
                a._UseTTSTextExpression = text;
                CurrentContext.ttshook(CurrentContext, a);
            }

            public void PlaySound(string uri)
            {
                Action a = new Action();
                a._PlaySoundFileExpression = uri;
                CurrentContext.soundhook(CurrentContext, a);
            }

            public string EvaluateStringExpression(string expr)
            {
                return CurrentContext.EvaluateStringExpression(null, CurrentContext, expr);
            }

            public double EvaluateNumericExpression(string expr)
            {
                return CurrentContext.EvaluateNumericExpression(null, CurrentContext, expr);
            }

            public string GetScalarVariable(bool persistent, string varname, string defValue = "") => StaticHelpers.GetScalarVariable(persistent, varname) ?? defValue;
            public VariableList GetListVariable(bool persistent, string varname) => StaticHelpers.GetListVariable(persistent, varname);
            public VariableTable GetTableVariable(bool persistent, string varname) => StaticHelpers.GetTableVariable(persistent, varname);
            public VariableDictionary GetDictVariable(bool persistent, string varname) => StaticHelpers.GetDictVariable(persistent, varname);

            public void SetScalarVariable(bool persistent, string varname, object data) => StaticHelpers.SetScalarVariable(persistent, varname, data);
            public void SetListVariable(bool persistent, string varname, VariableList data) => StaticHelpers.SetListVariable(persistent, varname, data);
            public void SetTableVariable(bool persistent, string varname, VariableTable data) => StaticHelpers.SetTableVariable(persistent, varname, data);
            public void SetDictVariable(bool persistent, string varname, VariableDictionary data) => StaticHelpers.SetDictVariable(persistent, varname, data);


            public string GetRegexMatch(int idx, string defValue = "")
            {
                if (idx >= 0 && idx < CurrentContext.numgroups.Count)
                {
                    string val = CurrentContext.numgroups[idx];
                    if (Plugin != null)
                    {
                        val = Plugin.cfg.PerformSubstitution(val, Configuration.Substitution.SubstitutionScopeEnum.CaptureGroup);
                    }
                    return val;
                }
                return defValue;
            }

            public string GetRegexMatch(string name, string defValue = "")
            {
                if (CurrentContext.namedgroups.ContainsKey(name) == true)
                {
                    string val = CurrentContext.namedgroups[name];
                    if (Plugin != null)
                    {
                        val = Plugin.cfg.PerformSubstitution(val, Configuration.Substitution.SubstitutionScopeEnum.CaptureGroup);
                    }
                    return val;
                }
                return defValue;
            }

        }

        public static class StaticHelpers
        {
            public static Dictionary<string, object> Storage => RealPlugin.plug.scriptingStorage;
            public static Context fakectx = new Context { plug = RealPlugin.plug };

            public static void Log(int level, string message)
                => RealPlugin.plug.FilteredAddToLog((RealPlugin.DebugLevelEnum)level, message);

            public static void Log(RealPlugin.DebugLevelEnum level, string message)
                => RealPlugin.plug.FilteredAddToLog(level, message);

            public static string EvaluateStringExpression(string expr)
                => fakectx.EvaluateStringExpression(null, fakectx, expr);

            public static double EvaluateNumericExpression(string expr)
                => fakectx.EvaluateNumericExpression(null, fakectx, expr);

            public static string GetScalarVariable(bool isPersistent, string varname)
            {
                VariableStore vs = isPersistent ? RealPlugin.plug.cfg.PersistentVariables : RealPlugin.plug.sessionvars;
                lock (vs.Scalar)
                {
                    return vs.Scalar.TryGetValue(varname, out var variable) ? variable.Value : null;
                }
            }

            public static VariableList GetListVariable(bool isPersistent, string varname)
            {
                VariableStore vs = isPersistent ? RealPlugin.plug.cfg.PersistentVariables : RealPlugin.plug.sessionvars;
                lock (vs.List)
                {
                    return vs.List.TryGetValue(varname, out var variable) ? variable : null;
                }
            }

            public static VariableTable GetTableVariable(bool isPersistent, string varname)
            {
                VariableStore vs = isPersistent ? RealPlugin.plug.cfg.PersistentVariables : RealPlugin.plug.sessionvars;
                lock (vs.Table)
                {
                    return vs.Table.TryGetValue(varname, out var variable) ? variable : null;
                }
            }

            public static VariableDictionary GetDictVariable(bool isPersistent, string varname)
            {
                VariableStore vs = isPersistent ? RealPlugin.plug.cfg.PersistentVariables : RealPlugin.plug.sessionvars;
                lock (vs.Dict)
                {
                    return vs.Dict.TryGetValue(varname, out var variable) ? variable : null;
                }
            }

            public static void SetScalarVariable(bool isPersistent, string varname, object data)
            {
                VariableStore vs = isPersistent ? RealPlugin.plug.cfg.PersistentVariables : RealPlugin.plug.sessionvars;
                lock (vs.Scalar)
                {
                    if (data == null)
                        vs.Scalar.Remove(varname);
                    else if (data is VariableScalar variable)
                        vs.Scalar[varname] = variable;
                    else
                        vs.Scalar[varname] = new VariableScalar { Value = data.ToString() };
                }
            }

            public static void SetListVariable(bool isPersistent, string varname, VariableList data)
            {
                VariableStore vs = isPersistent ? RealPlugin.plug.cfg.PersistentVariables : RealPlugin.plug.sessionvars;
                lock (vs.List)
                {
                    if (data == null)
                        vs.List.Remove(varname);
                    else
                        vs.List[varname] = data;
                }
            }

            public static void SetTableVariable(bool isPersistent, string varname, VariableTable data)
            {
                VariableStore vs = isPersistent ? RealPlugin.plug.cfg.PersistentVariables : RealPlugin.plug.sessionvars;
                lock (vs.Table)
                {
                    if (data == null)
                        vs.Table.Remove(varname);
                    else
                        vs.Table[varname] = data;
                }
            }

            public static void SetDictVariable(bool isPersistent, string varname, VariableDictionary data)
            {
                VariableStore vs = isPersistent ? RealPlugin.plug.cfg.PersistentVariables : RealPlugin.plug.sessionvars;
                lock (vs.Dict)
                {
                    if (data == null)
                        vs.Dict.Remove(varname);
                    else
                        vs.Dict[varname] = data;
                }
            }

            public static string Serialize(object o, bool indent = true) 
                => JsonSerializer.Serialize(o, new JsonSerializerOptions { WriteIndented = indent });
            public static T Deserialize<T>(string s) => JsonSerializer.Deserialize<T>(s);

            public static Process XivProcess => Triggernometry.Utilities.Memory.XivProc;
            public static void RegisterXivProcessUpdatedAction(string key, System.Action action) 
                => Triggernometry.Utilities.Memory.RegisterXivProcUpdatedAction(key, action);
        }

        public ScriptOptions _so { get; set; }

        public class Globs
        {

            public Helpers TriggernometryHelpers { get; set; } = null;

        }

        internal bool Ready = false;
        public Interpreter()
        {
            _so = ScriptOptions.Default;
            var asms = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly asm in asms)
            {
                _so = _so.AddMetadataReferenceFromAssembly(asm);
            }
            _so = _so.AddImports("System");
            
            Task.Run(() =>
            {
                try
                {
                    Evaluate("int whee;", null, new Context() { plug = RealPlugin.plug });
                    Ready = true;
                }
                catch (Exception ex)
                {
                    RealPlugin.plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Error, I18n.Translate("internal/Plugin/iniscripterror", "Error when initializing scripting - try changing plugin load order: {0}", ex.Message));
                }
                RealPlugin.plug.scriptingInited = true;
            });
        }

        public bool GetUnsafeUsage(Context ctx)
        {
            Configuration.UnsafeUsageEnum us = ctx.plug.cfg.UnsafeUsage;
            bool isremote = ctx.trig?.Repo != null;
            bool isadmin = ctx.plug.runningAsAdmin;
            if (isadmin == true && (us & Configuration.UnsafeUsageEnum.AllowAdmin) == 0)
            {
                return false;
            }
            if (isremote == false && (us & Configuration.UnsafeUsageEnum.AllowLocal) == 0)
            {
                return false;
            }
            if (isremote == true && (us & Configuration.UnsafeUsageEnum.AllowRemote) == 0)
            {
                return false;
            }
            return true;
        }

        public string[] GetBadApis(Context ctx)
        {
            bool isremote = ctx.trig?.Repo != null;
            bool isadmin = ctx.plug.runningAsAdmin;
            List<string> apis = new List<string>();
            foreach (Configuration.APIUsage a in ctx.plug.cfg.GetAPIUsages())
            {
                if (isadmin == true && a.AllowAdmin == false)
                {
                    apis.Add(a.Name);
                    continue;
                }
                if (isremote == false && a.AllowLocal == false)
                {
                    apis.Add(a.Name);
                    continue;
                }
                if (isremote == true && a.AllowRemote == false)
                {
                    apis.Add(a.Name);
                    continue;
                }
            }
            return apis.ToArray();
        }

        public void Evaluate(string command, string assy, Context ctx)
        {
            Globs g = new Globs() { TriggernometryHelpers = new Helpers() { CurrentContext = ctx } };
            ScriptOptions _myso = _so.WithAllowUnsafe(GetUnsafeUsage(ctx));
            if (assy != null)
            {
                var assys = assy.Split(',').Select(x => x.Trim());
                var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var asmName in assys)
                {
                    var assembly = currentAssemblies.FirstOrDefault(a => a.GetName().Name.Equals(asmName, StringComparison.OrdinalIgnoreCase));
                    // try to first load from current assemblies (including the assemblies loaded into memory by ACT which were not detected during InitPlugin)
                    _myso = (assembly != null) ? _myso.AddMetadataReferenceFromAssembly(assembly) : _myso.AddReferences(asmName);
                }
            }
            string[] badApis = GetBadApis(ctx);
            if (badApis != null && badApis.Length > 0)
            {
                Script<object> scp = CSharpScript.Create(command, _myso, typeof(Globs));
                if (Validator.Validate(scp, out string badApi, badApis) == true)
                {
                    Task<ScriptState<object>> ts = scp.RunAsync(g);
                    try
                    {
                        Task.Run(async () => { await ts; }).Wait();
                    }
                    catch (AggregateException aex)
                    {
                        foreach (var ex in aex.Flatten().InnerExceptions)
                        {
                            g.TriggernometryHelpers.Log(RealPlugin.DebugLevelEnum.Error, I18n.Translate(
                                    "internal/Interpreter/scriptExecutionError",
                                    "Error occurred during script execution: \n{0}", ex.ToString()));
                        }
                    }
                    catch (Exception ex)
                    {
                        g.TriggernometryHelpers.Log(RealPlugin.DebugLevelEnum.Error, I18n.Translate(
                                    "internal/Interpreter/scriptExecutionError",
                                    "Error occurred during script execution: \n{0}", ex.ToString()));
                    }
                }
                else
                {
                    g.TriggernometryHelpers.Log(
                        RealPlugin.DebugLevelEnum.Error,
                        I18n.Translate(
                            "internal/Interpreter/scriptblocked", "Script execution on trigger {0} blocked due to restricted API: {1}",
                            ctx?.trig?.LogName ?? "(null)", badApi
                        )
                    );
                }
            }
            else
            {
                Task<object> t = CSharpScript.EvaluateAsync(command, _myso, g, typeof(Globs));
                try
                {
                    Task.Run(async () => { await t; }).Wait();
                }
                catch (AggregateException aex)
                {
                    foreach (var ex in aex.Flatten().InnerExceptions)
                    {
                        g.TriggernometryHelpers.Log(RealPlugin.DebugLevelEnum.Error, I18n.Translate(
                                "internal/Interpreter/scriptExecutionError",
                                "Error occurred during script execution: \n{0}", ex.ToString()));
                    }
                }
                catch (Exception ex)
                {
                    g.TriggernometryHelpers.Log(RealPlugin.DebugLevelEnum.Error, I18n.Translate(
                                "internal/Interpreter/scriptExecutionError",
                                "Error occurred during script execution: \n{0}", ex.ToString()));
                }
            }
        }

    }

    public static class ScriptOptionsExtensions
    {
        public static ScriptOptions AddMetadataReferenceFromAssembly(this ScriptOptions options, Assembly asm)
        {
            try
            {
                options = options.AddReferences(asm);
            }
            catch (Exception)
            {
                try
                {
                    MethodInfo grb = asm.GetType().GetMethod("GetRawBytes", BindingFlags.Instance | BindingFlags.NonPublic);
                    byte[] asmb = (byte[])grb.Invoke(asm, null);
                    if (asmb == null || asmb.Length == 0)
                    {
                        return options;
                    }
                    PortableExecutableReference pe = MetadataReference.CreateFromImage(asmb);
                    options = options.AddReferences(pe);
                }
                catch (Exception)
                {
                }
            }
            return options;
        }
    }

}
