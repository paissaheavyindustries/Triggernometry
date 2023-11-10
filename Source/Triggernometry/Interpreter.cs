using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Triggernometry.Variables;

namespace Triggernometry
{

    public class Interpreter
    {

        private class Validator
        {

            private static bool IsBadApi(string assy, params string[] badApis)
            {
                return badApis.Any(x => assy.Contains(x) == true);
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
                    string name = symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                    if (IsBadApi(name, badApis) == true)
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
                    string name = type.ContainingNamespace != null ? type.ContainingNamespace.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat) : null;
                    if (name != null && IsBadApi(name, badApis) == true)
                    {
                        badApi = name;
                        return false;
                    }
                }
                var invocs = srn.DescendantNodes().OfType<InvocationExpressionSyntax>();
                foreach (var invoc in invocs)
                {
                    ISymbol symbol = model.GetSymbolInfo(invoc).Symbol;
                    IAssemblySymbol ia = symbol.ContainingAssembly;
                    INamespaceSymbol ns = symbol.ContainingNamespace;
                    string name = ns.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                    if (IsBadApi(name, badApis) == true)
                    {
                        badApi = name;
                        return false;
                    }
                }
                var methods = srn.DescendantNodes().OfType<MethodDeclarationSyntax>();
                foreach (var method in methods)
                {
                    IMethodSymbol symbol = model.GetDeclaredSymbol(method) as IMethodSymbol;
                    string name = symbol.ContainingAssembly.Name;
                    if (IsBadApi(name, badApis) == true)
                    {
                        badApi = name;
                        return false;
                    }
                }
                var props = srn.DescendantNodes().OfType<PropertyDeclarationSyntax>();
                foreach (var prop in props)
                {
                    IPropertySymbol symbol = model.GetDeclaredSymbol(prop) as IPropertySymbol;                    
                    string name = symbol.Type.ContainingAssembly.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                    if (IsBadApi(name, badApis) == true)
                    {
                        badApi = name;
                        return false;
                    }
                    name = symbol.Type.ContainingNamespace.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                    if (IsBadApi(name, badApis) == true)
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

            public Dictionary<string, object> Storage { get; set; }

            public RealPlugin Plugin { get; set; }

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

            public string GetScalarVariable(bool persistent, string varname, string defValue = "")
            {
                VariableStore vs = persistent == true ? CurrentContext.plug.cfg.PersistentVariables : CurrentContext.plug.sessionvars;
                lock (vs.Scalar)
                {
                    if (vs.Scalar.ContainsKey(varname) == false)
                    {
                        return defValue;
                    }
                    return vs.Scalar[varname].Value;
                }
            }

            public void SetScalarVariable(bool persistent, string varname, string data)
            {
                VariableStore vs = persistent == true ? CurrentContext.plug.cfg.PersistentVariables : CurrentContext.plug.sessionvars;
                lock (vs.Scalar)
                {
                    if (vs.Scalar.ContainsKey(varname) == false)
                    {
                        vs.Scalar[varname] = new VariableScalar();
                    }
                    if (data == null)
                    {
                        vs.Scalar.Remove(varname);
                    }
                    else
                    {
                        VariableScalar x = vs.Scalar[varname];
                        x.Value = data;
                    }
                }
            }

            public VariableList GetListVariable(bool persistent, string varname)
            {
                VariableStore vs = persistent == true ? CurrentContext.plug.cfg.PersistentVariables : CurrentContext.plug.sessionvars;
                lock (vs.List)
                {
                    if (vs.List.ContainsKey(varname) == false)
                    {
                        return null;
                    }
                    return vs.List[varname];
                }
            }

            public void SetListVariable(bool persistent, string varname, VariableList data)
            {
                VariableStore vs = persistent == true ? CurrentContext.plug.cfg.PersistentVariables : CurrentContext.plug.sessionvars;
                lock (vs.List)
                {
                    if (data == null)
                    {
                        vs.List.Remove(varname);
                    }
                    else
                    {
                        vs.List[varname] = data;
                    }
                }
            }

            public VariableTable GetTableVariable(bool persistent, string varname)
            {
                VariableStore vs = persistent == true ? CurrentContext.plug.cfg.PersistentVariables : CurrentContext.plug.sessionvars;
                lock (vs.Table)
                {
                    if (vs.Table.ContainsKey(varname) == false)
                    {
                        return null;
                    }
                    return vs.Table[varname];
                }
            }

            public void SetTableVariable(bool persistent, string varname, VariableTable data)
            {
                VariableStore vs = persistent == true ? CurrentContext.plug.cfg.PersistentVariables : CurrentContext.plug.sessionvars;
                lock (vs.Table)
                {
                    if (data == null)
                    {
                        vs.Table.Remove(varname);
                    }
                    else
                    {
                        vs.Table[varname] = data;
                    }
                }
            }

            public VariableDictionary GetDictVariable(bool persistent, string varname)
            {
                VariableStore vs = persistent == true ? CurrentContext.plug.cfg.PersistentVariables : CurrentContext.plug.sessionvars;
                lock (vs.Dict)
                {
                    if (vs.Dict.ContainsKey(varname) == false)
                    {
                        return null;
                    }
                    return vs.Dict[varname];
                }
            }

            public void SetDictVariable(bool persistent, string varname, VariableDictionary data)
            {
                VariableStore vs = persistent == true ? CurrentContext.plug.cfg.PersistentVariables : CurrentContext.plug.sessionvars;
                lock (vs.Dict)
                {
                    if (data == null)
                    {
                        vs.Dict.Remove(varname);
                    }
                    else
                    {
                        vs.Dict[varname] = data;
                    }
                }
            }

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

        public ScriptOptions _so { get; set; }
        private RealPlugin _plug;

        public class Globs
        {

            public Helpers TriggernometryHelpers { get; set; } = null;

        }

        public Interpreter(RealPlugin plug)
        {
            _plug = plug;
            _so = ScriptOptions.Default;
            var asms = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly asm in asms)
            {
                try
                {
                    _so = _so.AddReferences(asm);
                }
                catch (Exception)
                {
                    try
                    {
                        MethodInfo grb = asm.GetType().GetMethod("GetRawBytes", BindingFlags.Instance | BindingFlags.NonPublic);
                        byte[] asmb = (byte[])grb.Invoke(asm, null);
                        if (asmb == null || asmb.Length == 0)
                        {
                            continue;
                        }
                        PortableExecutableReference pe = MetadataReference.CreateFromImage(asmb);
                        _so = _so.AddReferences(pe);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            _so = _so.AddImports("System");
            Evaluate("int whee;", null, new Context() { plug = plug });
        }

        public string[] GetBadApis(Context ctx)
        {
            bool isremote = ctx.trig != null && ctx.trig.Repo != null;
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
            Globs g = new Globs() { TriggernometryHelpers = new Helpers() { Plugin = ctx != null ? ctx.plug : null, CurrentContext = ctx } };
            g.TriggernometryHelpers.Storage = g.TriggernometryHelpers.Plugin != null ? g.TriggernometryHelpers.Plugin.scriptingStorage : null;
            ScriptOptions _myso = _so;
            if (assy != null)
            {
                string[] assys = assy.Split(',');
                _myso = _myso.AddReferences(assys.Select(x => x.Trim()));
            }
            string[] badApis = GetBadApis(ctx);
            if (badApis != null && badApis.Length > 0)
            {
                Script<object> scp = CSharpScript.Create(command, _myso, typeof(Globs));
                if (Validator.Validate(scp, out string badApi, badApis) == true)
                {
                    Task<ScriptState<object>> ts = scp.RunAsync(g);
                    Task.Run(async () => { await ts; }).Wait();
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
            }
        }

    }

}
