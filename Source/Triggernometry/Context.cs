using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using Triggernometry.Variables;

namespace Triggernometry
{

    public class Context
    {

        internal Guid id = Guid.NewGuid();
        internal bool testmode;
        internal RealPlugin plug;
        public Trigger trig { get; set; }
        internal Action.TriggerForceTypeEnum force;

        internal RealPlugin.ActionExecutionHook soundhook;
        internal RealPlugin.ActionExecutionHook ttshook;

        // ${...}
        internal static Regex rex = new Regex(@"\$\{(?<id>[^${}]*)\}");
        // ¤{...}
        internal static Regex rox = new Regex(@"¤\{[^${}]*\}");
        // $1 $2
        internal static Regex rexnum = new Regex(@"\$(?<id>[0-9]+)");
        // name[index]
        internal static Regex rexListIdx = new Regex(@"^(?<name>[^[]+)\[(?<index>[^[\]]*?)\]");
        // name[col][row]
        internal static Regex rexTableIdx = new Regex(@"^(?<name>[^[]+)\[(?<column>[^[\]]*?)\]\[(?<row>[^[\]]*?)\] *$");
        // name(arg)?:val
        internal static Regex rexFunc = new Regex(@"^(?<name>[^(:]+)(?:\((?<arg>[^)]*)\))?:(?<val>.*)$");
        // name.prop(arg)?
        internal static Regex rexProp = new Regex(@"^(?<name>[^.]+)\.(?<prop>[^(]+?)(?:\((?<arg>[^)]*)\))? *$");
        // name?[index].prop(arg)?
        internal static Regex rexListProp = new Regex(@"^(?<name>[^[]*)\[(?<index>[^[\]]*?)\]\.(?<prop>[^(]+?)(?:\((?<arg>[^)]*)\))? *$");
        // name?[col][row].prop(arg)?
        internal static Regex rexTableProp = new Regex(@"^(?<name>[^[]*)\[(?<column>[^[\]]*)\]\[(?<row>[^[\]]*)\]\.(?<prop>[^(]+?)(?:\((?<arg>[^)]*)\))? *$");
        
        internal Dictionary<string, string> namedgroups;
		internal List<string> numgroups;
        internal DateTime triggered;
        internal string zoneIdOverride = null;
        internal string contextResponse = "";
        internal int contextResponseCode = 0;
        internal dynamic contextJsonResponse;
        internal bool contextJsonParsed = false;

        internal List<int> ActionResults = new List<int>();
        internal Dictionary<Mutex, int> heldmutices = new Dictionary<Mutex, int>();
        
        internal int loopiterator { get; set; } = 0;
        internal Guid loopcontext { get; set; } = Guid.Empty;
        internal string varName { get; set; } = "";         // for ${_this}
        internal int listIndex { get; set; } = 0;           // for ${_index}
        internal int tableColIndex { get; set; } = 0;       // for ${_col}
        internal int tableRowIndex { get; set; } = 0;       // for ${_row}

        internal const double EORZEA_MULTIPLIER = 3600D / 175D;
        internal const string LINEBREAK_PLACEHOLDER = "⏎";
        internal Random rng = new Random();

        private static MathParser mp = new MathParser();
		
		public Context()
		{
			namedgroups = new Dictionary<string, string>();
			numgroups = new List<string>();
        }

        public override string ToString()
        {
            return id.ToString() + " for " + (trig != null ? trig.LogName : "(no trigger)") + " at " + triggered.ToString();
        }

        internal Context Duplicate()
        {
            Context ctx = (Context)MemberwiseClone();
            return ctx;
        }

        internal void PushActionResult(int i)
        {
            lock (ActionResults)
            {
                ActionResults.Add(i);
            }
        }

        internal int PeekActionResult(bool previous, int i)
        {
            lock (ActionResults)
            {
                if (previous == true)
                {
                    if (ActionResults.Count > 0)
                    {
                        return ActionResults[ActionResults.Count - 1];
                    }
                    return 0;
                }
                else
                {
                    if (i < 1 || i > ActionResults.Count)
                    {
                        return 0;
                    }
                    return ActionResults[i - 1];
                }
            }
        }

        public delegate void LoggerCallback(object o, string message);

        public double EvaluateNumericExpression(LoggerDelegate logger, object o, string expr)
        {
            string exp = ExpandVariables(logger, o, true, expr == null ? "" : expr);
            if (plug != null)
            {
                exp = plug.cfg.PerformSubstitution(exp, Configuration.Substitution.SubstitutionScopeEnum.NumericExpression);
            }
            lock (mp)
            {
                return mp.Parse(exp);
            }
        }

        public string EvaluateStringExpression(LoggerDelegate logger, object o, string expr)
        {            
            string exp = ExpandVariables(logger, o, false, expr == null ? "" : expr);
            if (plug != null)
            {
                exp = plug.cfg.PerformSubstitution(exp, Configuration.Substitution.SubstitutionScopeEnum.StringExpression);
            }
            return exp;
        }

        public delegate void LoggerDelegate(object o, string msg);

        private TimeSpan GetEorzeanTime()
        {
            long epochTicks = DateTime.UtcNow.Ticks - (new DateTime(1970, 1, 1).Ticks);
            long eorzeaTicks = (long)Math.Round(epochTicks * EORZEA_MULTIPLIER);
            return new DateTime(eorzeaTicks).TimeOfDay;
        }

        private VariableScalar GetScalarVariable(VariableStore vs, string varname, bool createNew)
        {
            if (vs.Scalar.ContainsKey(varname) == true)
            {
                return vs.Scalar[varname];
            }
            VariableScalar vl = new VariableScalar();
            if (createNew == true)
            {
                vs.Scalar[varname] = vl;
            }
            return vl;
        }

        private VariableList GetListVariable(VariableStore vs, string varname, bool createNew)
        {
            if (vs.List.ContainsKey(varname) == true)
            {
                return vs.List[varname];
            }
            VariableList vl = new VariableList();
            if (createNew == true)
            {
                vs.List[varname] = vl;
            }
            return vl;
        }

        private VariableTable GetTableVariable(VariableStore vs, string varname, bool createNew)
        {
            if (vs.Table.ContainsKey(varname) == true)
            {
                return vs.Table[varname];
            }
            VariableTable vl = new VariableTable();
            if (createNew == true)
            {
                vs.Table[varname] = vl;
            }
            return vl;
        }

        public static string[] SplitArguments(string args, bool allowEmpty = true)
        {
            if (string.IsNullOrWhiteSpace(args) && allowEmpty)
            {
                return new string[0];
            }
            // (?<=^|,): after a comma or start-of-line
            // ( *\"[^\"]*\" *| *'[^']*' *|[^,]*): string in "", or string in '', or string without comma
            // (?=$|,): before a comma or end-of-line
            var reSingleArg = new Regex("(?<=^|,)( *\"[^\"]*\" *| *'[^']*' *|[^,]*)(?=$|,)");
            var reDQuoted = new Regex("^ *\"(?<arg>[^\"]*)\" *$");
            var reSQuoted = new Regex("^ *'(?<arg>[^']*)' *$");
            var matches = reSingleArg.Matches(args);
            var result = new List<string>();
            foreach (Match match in matches)
            {
                var currentMatch = match.Value;
                var dQuotedMatch = reDQuoted.Match(currentMatch);
                var sQuotedMatch = reSQuoted.Match(currentMatch);
                if (dQuotedMatch.Success)
                {
                    result.Add(dQuotedMatch.Groups["arg"].Value);
                }
                else if (sQuotedMatch.Success)
                {
                    result.Add(sQuotedMatch.Groups["arg"].Value);
                }
                else
                {
                    result.Add(currentMatch.Trim());
                }
            }
            return result.ToArray();
        }

        public string GetArgument(string[] args, int index, string defaultValue, bool setEmptyToDefault = false)
        {
            if (index >= args.Length || (args[index] == "" && setEmptyToDefault))
                return defaultValue;
            else
                return args[index];
        }

        public List<int> GetSliceIndices(string slicesStr, int totalLength, int startIndex = 0)
        {   // startIndex = 0 for strings; startIndex = 1 for lists/tables. (Triggernometry definition)
            List<int> indices = new List<int>();

            if (totalLength <= 0)
            {
                return indices;
            }

            string[] slices = SplitArguments(slicesStr, allowEmpty: false);
            foreach (string slice in slices)
            {   // parse slice string to int start/end/step
                string[] sliceArgs = slice.Split(':').Select(s => s.Trim()).ToArray();
                if (sliceArgs.Length > 3)
                {
                    throw new ArgumentException(I18n.Translate("internal/Context/sliceformaterror",
                        "The given slice ({0}) from slices ({1}) could not be parsed.", slice, slicesStr));
                }
                string startStr = GetArgument(sliceArgs, 0, "", true);
                string endStr = GetArgument(sliceArgs, 1, "", true);
                string stepStr = GetArgument(sliceArgs, 2, "1", true);
                int start; int end; int step;
                try
                {
                    if (sliceArgs.Length == 1 && startStr.Trim() != "")
                    {   // sliceArgs.Length = 1:  a single index i => i:(i+1):1
                        start = int.Parse(startStr);
                        start = (start >= 0) ? (start - startIndex) : (start + totalLength);
                        end = start + 1;
                        step = 1;
                    }
                    else
                    {   // sliceArgs.Length = 3:  a:b:c, a:b:, a::c, :b:c, a::, :b:, ::c
                        // sliceArgs.Length = 2:  a:b, a:, :b
                        // sliceArgs.Length = 0:  ""
                        step = int.Parse(stepStr);
                        if (step == 0)
                        {
                            throw new ArgumentException(I18n.Translate("internal/Context/slicestepzeroerror",
                                "Step length is 0 in the slice ({0}) from slices ({1}).", slice, slicesStr));
                        }
                        if (startStr != "")
                        {
                            start = int.Parse(startStr);
                            start = (start >= 0) ? (start - startIndex) : (start + totalLength);
                        }
                        else
                        {
                            start = (step > 0) ? int.MinValue : int.MaxValue;
                        }
                        if (endStr != "")
                        {
                            end = int.Parse(endStr);
                            end = (end >= 0) ? (end - startIndex) : (end + totalLength);
                        }
                        else
                        {
                            end = (step > 0) ? int.MaxValue : int.MinValue;
                        }
                    }
                }
                catch
                {
                    throw new ArgumentException(I18n.Translate("internal/Context/sliceformaterror",
                        "The given slice ({0}) from slices ({1}) could not be parsed.", slice, slicesStr));
                }

                // fix the out-of-range early start value / late end value 
                if (step > 0)
                {
                    start = (start < 0) ? 0 : start;
                    end = (end > totalLength) ? totalLength : end;
                }
                else
                {
                    start = (start > totalLength - 1) ? (totalLength - 1) : start;
                    end = (end < -1) ? -1 : end;
                }

                // get indices
                int sign = Math.Sign(step);
                int index = start;
                while (sign * index >= sign * start && sign * index < sign * end)
                {
                    if (index >= 0 && index < totalLength)
                    {
                        indices.Add(index);
                    }
                    index += step;
                }
            }

            return indices;
        }

        public string ReplaceLineBreak(string str, string placeholder = LINEBREAK_PLACEHOLDER)
        {
            // use "⏎" as a single-digit placeholder for linebreaks
            // to parse linebreaks as regular characters
            return str.Replace("\r\n", placeholder).Replace("\r", placeholder).Replace("\n", placeholder);
        }

        public char GetReplacedChar(int charcode)
        {   // replace linebreaks with the placeholder when converting charcode to char
            return (charcode == 10 || charcode == 13) ? LINEBREAK_PLACEHOLDER[0] : (char)charcode;
        }

        public string ExpandVariables(LoggerDelegate logger, object o, bool numeric, string expr)
        {            
            Match m, mx;
            string newexpr = expr;
            newexpr = ReplaceLineBreak(newexpr);
            
            int i = 1;
            while (true)
            {
                m = rex.Match(newexpr);
                if (m.Success == false)
                {
                    m = rexnum.Match(newexpr);
                    if (m.Success == false)
                    {
                        break;
                    }
                }
                string x = m.Groups["id"].Value;
                string val = "";
                bool found = false;
                if (testmode == true)
                {
                    if (x == "_since")
                    {
                        val = ((int)Math.Floor((DateTime.UtcNow - triggered).TotalSeconds)).ToString();                        
                    }
                    else if (x == "_sincems")
                    {
                        val = ((int)Math.Floor((DateTime.UtcNow - triggered).TotalMilliseconds)).ToString();                        
                    }
                    else
                    {
                        val = (numeric == true ? "1" : "test");
                    }
                    found = true;
                }
                else
                {
                    int gn;
                    if (Int32.TryParse(x, out gn) == true)
                    {
                        if (gn >= 0 && gn < numgroups.Count)
                        {
                            val = numgroups[gn];
                            if (plug != null)
                            {
                                val = plug.cfg.PerformSubstitution(val, Configuration.Substitution.SubstitutionScopeEnum.CaptureGroup);
                            }
                            found = true;
                        }
                    }
                    if (found == false)
                    {
                        if (namedgroups.ContainsKey(x) == true)
                        {
                            val = namedgroups[x];
                            if (plug != null)
                            {
                                val = plug.cfg.PerformSubstitution(val, Configuration.Substitution.SubstitutionScopeEnum.CaptureGroup);
                            }
                            found = true;
                        }
                    }
                    if (found == false)
                    {
                        if (x == "_since")
                        {
                            val = ((int)Math.Floor((DateTime.UtcNow - triggered).TotalSeconds)).ToString();
                            found = true;
                        }
                        else if (x == "_sincems")
                        {
                            val = ((int)Math.Floor((DateTime.UtcNow - triggered).TotalMilliseconds)).ToString();
                            found = true;
                        }
                        else if (x == "_systemtime")
                        {
                            val = ((long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds).ToString();
                            found = true;
                        }
                        else if (x == "_systemtimems")
                        {
                            val = ((long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds).ToString();
                            found = true;
                        }
                        else if (x == "_ffxivplayer" || x == "_me")
                        {
                            VariableDictionary vc = PluginBridges.BridgeFFXIV.GetMyself();
                            if (vc != null)
                            {
                                val = vc.GetValue("name").ToString();
                            }
                            found = true;
                        }
                        else if (x == "_ffxivzoneid")
                        {
                            if (zoneIdOverride != null)
                            {
                                val = zoneIdOverride;
                            }
                            else
                            {
                                val = PluginBridges.BridgeFFXIV.ZoneID.ToString();
                            }
                            found = true;
                        }
                        else if (x == "_ffxivpartyorder")
                        {
                            val = plug.cfg.FfxivPartyOrdering + " " + plug.cfg.FfxivCustomPartyOrder;
                            found = true;
                        }
                        else if (x == "_ffxivprocid")
                        {
                            val = PluginBridges.BridgeFFXIV.GetProcessId().ToString();
                            found = true;
                        }
                        else if (x == "_ffxivprocname")
                        {
                            val = PluginBridges.BridgeFFXIV.GetProcessName();
                            found = true;
                        }
                        else if (x == "_incombat")
                        {
                            val = plug != null && plug.InCombatHook() ? "1" : "0";
                            found = true;
                        }
                        else if (x == "_duration")
                        {
                            try
                            {
                                if (plug != null && plug.InCombatHook() == true)
                                {
                                    val = ((int)Math.Floor(plug.EncounterDurationHook())).ToString();
                                }
                                else
                                {
                                    val = "0";
                                }
                            }
                            catch (Exception)
                            {
                                val = "0";
                            }
                            found = true;
                        }
                        else if (x == "_response")
                        {
                            val = contextResponse;
                            found = true;
                        }
                        else if (x == "_responsecode")
                        {
                            val = contextResponseCode.ToString();
                            found = true;
                        }
                        else if (x == "_triggername")
                        {
                            val = trig != null ? trig.Name : "(null)";
                            found = true;
                        }
                        else if (x == "_triggerid")
                        {
                            val = trig != null ? trig.Id.ToString() : "(null)";
                            found = true;
                        }
                        else if (x == "_loopiterator")
                        {
                            val = loopiterator.ToString();
                            found = true;
                        }
                        else if (x == "_index")
                        {
                            val = listIndex.ToString();
                            found = true;
                        }
                        else if (x == "_col")
                        {
                            val = tableColIndex.ToString();
                            found = true;
                        }
                        else if (x == "_row")
                        {
                            val = tableRowIndex.ToString();
                            found = true;
                        }
                        else if (x == "_this")
                        {
                            if (varName.StartsWith("tvar:") || varName.StartsWith("ptvar:"))
                            {
                                val = $"${{{varName}[{tableColIndex}][{tableRowIndex}]}}";
                            }
                            else
                            {
                                val = $"${{{varName}[{listIndex}]}}";
                            }
                            found = true;
                        }
                        else if (x.StartsWith("_actionhistory"))
                        {
                            mx = rexListIdx.Match(x);
                            if (mx.Success == true)
                            {
                                string idx = mx.Groups["index"].Value;
                                if (idx == "previous")
                                {
                                    val = PeekActionResult(true, 0).ToString();
                                }
                                else
                                {
                                    val = PeekActionResult(false, Int32.Parse(idx)).ToString();
                                }
                                found = true;
                            }
                        }
                        else if (x.StartsWith("_env"))
                        {
                            mx = rexListIdx.Match(x);
                            if (mx.Success == true)
                            {
                                string idx = mx.Groups["index"].Value;
                                val = System.Environment.GetEnvironmentVariable(idx);
                                found = true;
                            }
                        }
                        else if (x.StartsWith("_job[")) // ${_job[jobid].prop} or ${_job[GLA].prop}
                        {
                            mx = rexListProp.Match(x);
                            if (mx.Success)
                            {
                                string job = mx.Groups["index"].Value.Trim();
                                if (Entity.jobEN3ToIdMap.ContainsKey(job.ToUpper()))
                                {   // convert "GLA" to "1"
                                    job = Entity.jobEN3ToIdMap[job.ToUpper()];
                                }
                                string prop = mx.Groups["prop"].Value;
                                val = Entity.jobs[job][prop].ToString();
                            }
                            found = true;
                        }
                        else if (x.StartsWith("_const"))
                        {
                            mx = rexListIdx.Match(x);
                            if (mx.Success == true)
                            {
                                string idx = mx.Groups["index"].Value;
                                lock (plug.cfg.Constants)
                                {
                                    if (plug.cfg.Constants.ContainsKey(idx) == true)
                                    {
                                        val = plug.cfg.Constants[idx].Value;
                                    }
                                    else
                                    {
                                        val = "";
                                    }
                                }
                                found = true;
                            }
                        }
                        else if (x.StartsWith("_jsonresponse"))
                        {
                            mx = rexListIdx.Match(x);
                            if (mx.Success == true)
                            {
                                string pathspec = mx.Groups["index"].Value;
                                if (contextJsonParsed == false)
                                {
                                    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                                    contextJsonResponse = jsonSerializer.Deserialize<dynamic>(contextResponse);
                                    contextJsonParsed = true;
                                }
                                string[] path = pathspec.Split("/".ToCharArray());
                                dynamic curdir = contextJsonResponse;
                                foreach (string px in path)
                                {
                                    curdir = curdir[px];
                                }
                                val = curdir.ToString();
                                found = true;
                            }
                        }
                        // check if scalar variable exists
                        else if ((x.StartsWith("evar:")) || (x.StartsWith("epvar:")))
                        {
                            Variables.VariableStore store;
                            string varname;
                            if (x.StartsWith("evar:"))
                            {
                                store = plug.sessionvars;
                                varname = x.Substring(5);
                            }
                            else
                            {
                                store = plug.cfg.PersistentVariables;
                                varname = x.Substring(6);
                            }
                            lock (store.Scalar) // verified
                            {
                                if (store.Scalar.ContainsKey(varname) == true)
                                {
                                    val = "1";
                                }
                                else
                                {
                                    val = "0";
                                }
                                found = true;
                            }
                        }
                        // check if list variable exists
                        else if ((x.StartsWith("elvar:")) || (x.StartsWith("eplvar:")))
                        {
                            Variables.VariableStore store;
                            string varname;
                            if (x.StartsWith("elvar:"))
                            {
                                store = plug.sessionvars;
                                varname = x.Substring(6);
                            }
                            else
                            {
                                store = plug.cfg.PersistentVariables;
                                varname = x.Substring(7);
                            }
                            lock (store.List) // verified
                            {
                                if (store.List.ContainsKey(varname) == true)
                                {
                                    val = "1";
                                }
                                else
                                {
                                    val = "0";
                                }
                                found = true;
                            }
                        }
                        // check if table variable exists
                        else if ((x.StartsWith("etvar:")) || (x.StartsWith("eptvar:")))
                        {
                            Variables.VariableStore store;
                            string varname;
                            if (x.StartsWith("etvar:"))
                            {
                                store = plug.sessionvars;
                                varname = x.Substring(6);
                            }
                            else
                            {
                                store = plug.cfg.PersistentVariables;
                                varname = x.Substring(7);
                            }
                            lock (store.Table) // verified
                            {
                                if (store.Table.ContainsKey(varname) == true)
                                {
                                    val = "1";
                                }
                                else
                                {
                                    val = "0";
                                }
                                found = true;
                            }
                        }
                        // retrieve scalar variable value
                        else if ((x.StartsWith("var:")) || (x.StartsWith("pvar:")))
                        {
                            Variables.VariableStore store;
                            string varname;
                            if (x.StartsWith("var:"))
                            {
                                store = plug.sessionvars;
                                varname = x.Substring(4);
                            }
                            else
                            {
                                store = plug.cfg.PersistentVariables;
                                varname = x.Substring(5);
                            }
                            lock (store.Scalar) // verified
                            {
                                VariableScalar vs = GetScalarVariable(store, varname, false);
                                val = vs.Value;
                                found = true;
                            }
                        }
                        // retrieve list variable value
                        else if ((x.StartsWith("lvar:")) || (x.StartsWith("plvar:")))
                        {
                            Variables.VariableStore store;
                            string varname;
                            if (x.StartsWith("lvar:"))
                            {
                                store = plug.sessionvars;
                                varname = x.Substring(5);
                            }
                            else
                            {
                                store = plug.cfg.PersistentVariables;
                                varname = x.Substring(6);
                            }
                            mx = rexProp.Match(varname);
                            if (mx.Success == true)
                            {
                                string gname = mx.Groups["name"].Value;
                                string gprop = mx.Groups["prop"].Value;
                                string garg = mx.Groups["arg"].Value;
                                string[] args = SplitArguments(garg);
                                int argc = args.Length;

                                switch (gprop)
                                {
                                    case "size":
                                    case "length":
                                        {
                                            lock (store.List)
                                            {
                                                VariableList vl = GetListVariable(store, gname, false);
                                                val = vl.Size().ToString();
                                                found = true;
                                            }
                                        }
                                        break;
                                    case "indexof":
                                    case "i":
                                    case "lastindexof":
                                    case "li":
                                        if (argc != 1)
                                        {
                                            throw new ArgumentException(I18n.Translate("internal/Context/argCountError",
                                                "({0}) requires {1} arguments, {2} were given. Expr: ({3})", gprop, "1", argc, x));
                                        }
                                        lock (store.List)
                                        {
                                            VariableList vl = GetListVariable(store, gname, false);
                                            val = (gprop.StartsWith("i")) ? vl.IndexOf(args[0]).ToString() : vl.LastIndexOf(args[0]).ToString();
                                            found = true;
                                        }
                                        break;
                                    case "sumslice":
                                    case "sum":  // lvar:list.sum(slices = "")
                                        if (argc > 1)
                                        {
                                            throw new ArgumentException(I18n.Translate("internal/Context/argCountError",
                                                "({0}) requires {1} arguments, {2} were given. Expr: ({3})", gprop, "0-1", argc, x));
                                        }
                                        lock (store.List)
                                        {
                                            VariableList vl = GetListVariable(store, gname, false);
                                            string sliceStr = GetArgument(args, 0, "");
                                            var indices = GetSliceIndices(sliceStr, vl.Size(), startIndex: 1);
                                            val = vl.SumSlice(indices).ToString();
                                            found = true;
                                        }
                                        break;
                                    case "joinslice":   // = join
                                    case "join":        // lvar:list.join(joiner = ",", slices = "")
                                    case "randjoin":    // lvar:list.randjoin(joiner = ",", slices = "")
                                        if (argc > 2)
                                        {
                                            throw new ArgumentException(I18n.Translate("internal/Context/argCountError",
                                                "({0}) requires {1} arguments, {2} were given. Expr: ({3})", gprop, "0-2", argc, x));
                                        }
                                        lock (store.List)
                                        {
                                            VariableList vl = GetListVariable(store, gname, false);
                                            string joiner = GetArgument(args, 0, ",");
                                            string sliceStr = GetArgument(args, 1, "");
                                            List<int> indices = GetSliceIndices(sliceStr, vl.Size(), startIndex: 1);
                                            if (gprop == "randjoin")
                                            {
                                                indices = indices.OrderBy(_ => rng.Next()).ToList();
                                            }
                                            val = vl.JoinSlice(joiner, indices).ToString();
                                            found = true;
                                        }
                                        break;
                                    case "count": // count(targetStr, slices = "")
                                        if (argc != 1 && argc != 2)
                                        {
                                            throw new ArgumentException(I18n.Translate("internal/Context/argCountError",
                                                "({0}) requires {1} arguments, {2} were given. Expr: ({3})", gprop, "1-2", argc, x));
                                        }
                                        lock (store.List)
                                        {
                                            VariableList vl = GetListVariable(store, gname, false);
                                            val = vl.Count(args[0]).ToString();
                                            found = true;
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                mx = rexListIdx.Match(varname);
                                if (mx.Success == true)
                                {
                                    string gname = mx.Groups["name"].Value;
                                    string gindex = mx.Groups["index"].Value;
                                    lock (store.List)
                                    {
                                        VariableList vl = GetListVariable(store, gname, false);
                                        gindex = (gindex == "last") ? "-1" : gindex;

                                        int iindex;
                                        if (!Int32.TryParse(gindex, out iindex) == true)
                                        {
                                            throw new ArgumentException(I18n.Translate("internal/Context/parseTypeError",
                                                "{0} ({1}) could not be parsed into {2}. Expr: ({3})", "index", gindex, "int", x));
                                        }
                                        val = vl.Peek(iindex).ToString();
                                        found = true;
                                    }
                                    found = true;
                                }
                            }
                        }
                        // retrieve table variable value
                        else if ((x.StartsWith("tvar:")) || (x.StartsWith("ptvar:")))
                        {
                            Variables.VariableStore store;
                            string varname;
                            if (x.StartsWith("tvar:"))
                            {
                                store = plug.sessionvars;
                                varname = x.Substring(5);
                            }
                            else
                            {
                                store = plug.cfg.PersistentVariables;
                                varname = x.Substring(6);
                            }
                            mx = rexProp.Match(varname);
                            if (mx.Success == true)
                            {
                                string gname = mx.Groups["name"].Value;
                                string gprop = mx.Groups["prop"].Value;
                                string[] args = SplitArguments(mx.Groups["arg"].Value);
                                int argc = args.Length;
                                switch (gprop)
                                {
                                    case "w":
                                    case "width":
                                        {
                                            lock (store.Table)
                                            {
                                                VariableTable vt = GetTableVariable(store, gname, false);
                                                val = vt.Width.ToString();
                                                found = true;
                                            }
                                        }
                                        break;
                                    case "h":
                                    case "height":
                                        {
                                            lock (store.Table)
                                            {
                                                VariableTable vt = GetTableVariable(store, gname, false);
                                                val = vt.Height.ToString();
                                                found = true;
                                            }
                                        }
                                        break;
                                    case "hjoin": // .hjoin(joiner1 = ",", joiner2 = LINEBREAK_PLACEHOLDER, colSlices = "", rowSlices = "")
                                    case "vjoin": // .vjoin(joiner1 = ",", joiner2 = LINEBREAK_PLACEHOLDER, colslices = "", rowslices = "")
                                        lock (store.List)
                                        {
                                            if (argc > 4)
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/argCountError",
                                                   "({0}) requires {1} arguments, {2} were given. Expr: ({3})", gprop, "0-4", argc, x));
                                            }
                                            VariableTable vt = GetTableVariable(store, gname, false);
                                            string joiner1 = GetArgument(args, 0, ",", false);
                                            string joiner2 = GetArgument(args, 1, LINEBREAK_PLACEHOLDER, false);
                                            string colSlicesStr = GetArgument(args, 2, "");
                                            string rowSlicesStr = GetArgument(args, 3, "");
                                            var colIndices = GetSliceIndices(colSlicesStr, vt.Width, startIndex: 1);
                                            var rowIndices = GetSliceIndices(rowSlicesStr, vt.Height, startIndex: 1);
                                            if (gprop.StartsWith("hj"))
                                            {
                                                val = vt.HJoin(joiner1, joiner2, colIndices, rowIndices);
                                            }
                                            else
                                            {
                                                val = vt.VJoin(joiner1, joiner2, colIndices, rowIndices);
                                            }
                                            found = true;
                                        }
                                        break;

                                    case "hl":
                                    case "hlookup": // .hlookup(targetStr, rowIndex, colslices = "") => colIndex
                                    case "vl":
                                    case "vlookup": // .vlookup(targetStr, colIndex, rowslices = "") => rowIndex
                                        lock (store.List)
                                        {
                                            if (argc != 2 && argc != 3)
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/argCountError",
                                                   "({0}) requires {1} arguments, {2} were given. Expr: ({3})", gprop, "2-3", argc, x));
                                            }

                                            VariableTable vt = GetTableVariable(store, gname, false);

                                            string targetStr = args[0];

                                            if (!int.TryParse(args[1], out int rawIndex))
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/parseTypeError",
                                                    "{0} ({1}) could not be parsed into {2}. Expr: ({3})", "string", args[1], "int", x));
                                            }
                                            int maxLength = (gprop.StartsWith("hl")) ? vt.Height : vt.Width;
                                            int index = (rawIndex < 0) ? (rawIndex + maxLength) : (rawIndex - 1);
                                            string slicesStr = GetArgument(args, 2, "");

                                            List<int> indices;
                                            if (gprop.StartsWith("hl"))
                                            {
                                                indices = GetSliceIndices(slicesStr, vt.Width, startIndex: 1);
                                                val = vt.HLookup(targetStr, index, indices).ToString();
                                            }
                                            else
                                            {
                                                indices = GetSliceIndices(slicesStr, vt.Height, startIndex: 1);
                                                val = vt.VLookup(targetStr, index, indices).ToString();
                                            }
                                            found = true;
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                mx = rexTableIdx.Match(varname);
                                if (mx.Success == true)
                                {
                                    string gname = mx.Groups["name"].Value;
                                    string gcol = mx.Groups["column"].Value;
                                    string grow = mx.Groups["row"].Value;
                                    lock (store.Table)
                                    {
                                        VariableTable vt = GetTableVariable(store, gname, false);
                                        gcol = (gcol == "last") ? "-1" : gcol;
                                        grow = (grow == "last") ? "-1" : grow;
                                        int xindex, yindex;
                                        if (Int32.TryParse(gcol, out xindex) == true)
                                        {
                                            if (Int32.TryParse(grow, out yindex) == true)
                                            {
                                                val = vt.Peek(xindex, yindex).ToString();
                                            }
                                        }
                                    }
                                    found = true;
                                }
                            }
                        }
                        // row-based table lookup
                        else if ((x.StartsWith("tvarrl:")) || (x.StartsWith("ptvarrl:")))
                        {
                            Variables.VariableStore store;
                            string varname;
                            if (x.StartsWith("tvarrl:"))
                            {
                                store = plug.sessionvars;
                                varname = x.Substring(7);
                            }
                            else
                            {
                                store = plug.cfg.PersistentVariables;
                                varname = x.Substring(8);
                            }
                            mx = rexTableIdx.Match(varname);
                            if (mx.Success == true)
                            {
                                string gname = mx.Groups["name"].Value;
                                string gheader = mx.Groups["column"].Value;
                                string gindex = mx.Groups["row"].Value;
                                lock (store.Table)
                                {
                                    VariableTable vt = GetTableVariable(store, gname, false);
                                    gindex = (gindex == "last") ? "-1" : gindex;
                                    int xindex;
                                    if (Int32.TryParse(gindex, out xindex) == true)
                                    {
                                        // index starts from 1; 0 if not found
                                        int yindex = vt.SeekRow(gheader);
                                        if (yindex > 0)
                                        {
                                            if (xindex > 0)
                                            {
                                                val = vt.Peek(xindex + 1, yindex).ToString();
                                            }
                                            else if (xindex < 0)
                                            {
                                                val = vt.Peek(xindex, yindex).ToString();
                                            }
                                            else if (xindex == 0)
                                            {
                                                val = yindex.ToString();
                                            }
                                        }
                                    }
                                }
                                found = true;
                            }
                        }
                        // column-based table lookup
                        else if ((x.StartsWith("tvarcl:")) || (x.StartsWith("ptvarcl:")))
                        {
                            Variables.VariableStore store;
                            string varname;
                            if (x.StartsWith("tvarcl:"))
                            {
                                store = plug.sessionvars;
                                varname = x.Substring(7);
                            }
                            else
                            {
                                store = plug.cfg.PersistentVariables;
                                varname = x.Substring(8);
                            }
                            mx = rexTableIdx.Match(varname);
                            if (mx.Success == true)
                            {
                                string gname = mx.Groups["name"].Value;
                                string gheader = mx.Groups["column"].Value;
                                string gindex = mx.Groups["row"].Value;
                                lock (store.Table)
                                {
                                    VariableTable vt = GetTableVariable(store, gname, false);
                                    gindex = (gindex == "last") ? "-1" : gindex;
                                    int yindex;
                                    if (Int32.TryParse(gindex, out yindex) == true)
                                    {
                                        // index starts from 1; 0 if not found
                                        int xindex = vt.SeekColumn(gheader);
                                        if (xindex > 0)
                                        {
                                            if (yindex > 0)
                                            {
                                                val = vt.Peek(xindex, yindex + 1).ToString();
                                            }
                                            else if (yindex < 0)
                                            {
                                                val = vt.Peek(xindex, yindex).ToString();
                                            }
                                            else if (yindex == 0)
                                            {
                                                val = xindex.ToString();
                                            }
                                        }
                                    }
                                }
                                found = true;
                            }
                        }
                        // double-based lookup based on col/row names
                        else if ((x.StartsWith("tvardl:")) || (x.StartsWith("ptvardl:")))
                        {
                            Variables.VariableStore store;
                            string param;
                            if (x.StartsWith("tvardl:"))
                            {
                                store = plug.sessionvars;
                                param = x.Substring(7);
                            }
                            else
                            {
                                store = plug.cfg.PersistentVariables;
                                param = x.Substring(8);
                            }
                            mx = rexTableIdx.Match(param);
                            if (mx.Success)
                            {
                                string varName = mx.Groups["name"].Value;
                                string colHeader = mx.Groups["column"].Value;
                                string rowHeader = mx.Groups["row"].Value;

                                lock (store.Table)
                                {
                                    VariableTable vt = GetTableVariable(store, varName, false);

                                    // index starts from 1; 0 if not found
                                    int xindex = vt.SeekColumn(colHeader);
                                    int yindex = vt.SeekRow(rowHeader);

                                    if (xindex > 0 && yindex > 0)
                                    {
                                        val = vt.Peek(xindex, yindex).ToString();
                                    }
                                }
                                found = true;
                            }
                        }
                        else if (x.StartsWith("numeric:") || x.StartsWith("n:"))
                        {
                            string numexpr = (x.StartsWith("numeric:")) ? x.Substring(8) : x.Substring(2);
                            val = I18n.ThingToString(EvaluateNumericExpression(logger, o, numexpr));
                            found = true;
                        }
                        else if (x.StartsWith("string:") || x.StartsWith("s:"))
                        {
                            string strexpr = (x.StartsWith("string:")) ? x.Substring(7) : x.Substring(2);
                            val = EvaluateStringExpression(logger, o, strexpr);
                            found = true;
                        }
                        else if (x.StartsWith("func:") || x.StartsWith("f:"))
                        {
                            val = "";
                            found = true;
                            string funcexpr = (x.StartsWith("func:")) ? x.Substring(5) : x.Substring(2);
                            Match rxm = rexFunc.Match(funcexpr);
                            if (rxm.Success == true)
                            {
                                string funcname = rxm.Groups["name"].Value.ToLower();
                                string funcarg = rxm.Groups["arg"].Value;
                                string funcval = rxm.Groups["val"].Value;
                                string[] args = SplitArguments(funcarg);
                                int argc = args.Count();
                                switch (funcname)
                                {
                                    case "toupper": // toupper()
                                        val = funcval.ToUpper();
                                        break;
                                    case "tolower": // tolower()
                                        val = funcval.ToLower();
                                        break;
                                    case "length": // length()
                                        val = funcval.Length.ToString();
                                        break;
                                    case "hex2dec":    // hex2dec()
                                    case "hex2float":  // hex2float()
                                    case "hex2double": // hex2double()
                                        {
                                            funcval = funcval.Trim();
                                            if (!new Regex("^[0-9A-Fa-f]+$").IsMatch(funcval))
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/invalidValueError",
                                                    "In ({0}), {1} ({2}) is invalid. Expr: ({3})", funcname, "funcval", funcval, x));
                                            }

                                            switch (funcname)
                                            {
                                                case "hex2dec":
                                                    val = "" + int.Parse(funcval, NumberStyles.HexNumber);
                                                    break;
                                                case "hex2float":
                                                    Int32 bytesArrayFloat = Int32.Parse(funcval, NumberStyles.HexNumber);
                                                    val = "" + BitConverter.ToSingle(BitConverter.GetBytes(bytesArrayFloat), 0);
                                                    break;
                                                case "hex2double":
                                                    Int64 bytesArrayDouble = Int64.Parse(funcval, NumberStyles.HexNumber);
                                                    val = "" + BitConverter.ToDouble(BitConverter.GetBytes(bytesArrayDouble), 0);
                                                    break;
                                            }
                                        }
                                        break;
                                    case "parsedmg": // parse the hex damage in ACT loglines to dec value
                                        {
                                            funcval = funcval.Trim();
                                            if (!new Regex("^(?:[0-9A-Fa-f]{5,8}|0{1,4})$").IsMatch(funcval))
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/invalidValueError",
                                                    "In ({0}), {1} ({2}) is invalid. Expr: ({3})", funcname, "funcval", funcval, x));
                                            }
                                            funcval = funcval.PadLeft(8, '0');
                                            string hexDmg = funcval.Substring(6, 2) + funcval.Substring(0, 4);
                                            Int32 decDmg = Int32.Parse(hexDmg, NumberStyles.HexNumber);
                                            val = decDmg.ToString();
                                        }
                                        break;
                                    case "float2hex":
                                        {
                                            if (!float.TryParse(funcval, out float floatValue))
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/parseTypeError",
                                                    "{0} ({1}) could not be parsed into {2}. Expr: ({3})", "string", funcval, "float", x));
                                            }
                                            byte[] bytesArray = BitConverter.GetBytes(floatValue);
                                            Array.Reverse(bytesArray, 0, bytesArray.Length);
                                            val = BitConverter.ToString(bytesArray).Replace("-", "");
                                        }
                                        break;
                                    case "double2hex":
                                        {
                                            if (!double.TryParse(funcval, out double doubleValue))
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/parseTypeError",
                                                    "{0} ({1}) could not be parsed into {2}. Expr: ({3})", "string", funcval, "double", x));
                                            }
                                            Int64 bytesArray = BitConverter.DoubleToInt64Bits(doubleValue);
                                            val = bytesArray.ToString("X");
                                        }
                                        break;
                                    case "dec2hex": // dec2hex()
                                    case "dec2hex2": // dec2hex2()
                                    case "dec2hex4": // dec2hex4()
                                    case "dec2hex8": // dec2hex8()
                                        {
                                            if (!int.TryParse(funcval, out int intValue))
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/parseTypeError",
                                                    "{0} ({1}) could not be parsed into {2}. Expr: ({3})", "string", funcval, "int", x));
                                            }
                                            string format = funcname.Substring(6).ToUpper(); // "X" "X2" "X4" "X8"
                                            val = intValue.ToString(format);
                                        }
                                        break;
                                    case "padleft":
                                    case "padright":
                                        {
                                            if (argc != 2)
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/argCountError",
                                                    "({0}) requires {1} arguments, {2} were given. Expr: ({3})", funcname, "2", argc, x));
                                            }
                                            char paddingChar = (args[0].Length == 1) ? args[0][0] : GetReplacedChar(Int32.Parse(args[0]));
                                            int length = Int32.Parse(args[1]);

                                            if (funcname == "padleft")
                                                val = funcval.PadLeft(length, paddingChar);
                                            else
                                                val = funcval.PadRight(length, paddingChar);
                                        }
                                        break;
                                    case "repeat": // repeat(times, joiner = "")
                                        {
                                            if (argc != 1 && argc != 2)
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/argCountError",
                                                    "({0}) requires {1} arguments, {2} were given. Expr: ({3})", funcname, "1-2", argc, x));
                                            }

                                            int times;
                                            if (!Int32.TryParse(args[0], out times))
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/parseTypeError",
                                                    "{0} ({1}) could not be parsed into {2}. Expr: ({3})", "times", times, "int", x));
                                            }
                                            string joiner = GetArgument(args, 1, "");
                                            if (times == 0)
                                            {
                                                val = "";
                                            }
                                            else
                                            {
                                                if (times < 0)
                                                {
                                                    times = -times;
                                                    funcval = new string(funcval.Reverse().ToArray());
                                                }
                                                StringBuilder sb = new StringBuilder(funcval);
                                                string repeatedUnit = joiner + funcval;
                                                for (int repeatCount = 1; repeatCount < times; repeatCount++)
                                                {
                                                    sb.Append(repeatedUnit);
                                                }
                                                val = $"{sb}";
                                            }
                                        }
                                        break;
                                    case "replace": // replace(oldStr, newStr = "", isLooped = 0)
                                        {
                                            if (argc != 1 && argc != 2 && argc != 3)
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/argCountError",
                                                    "({0}) requires {1} arguments, {2} were given. Expr: ({3})", funcname, "1-3", argc, x));
                                            }

                                            string oldStr = args[0];
                                            if (oldStr == "")
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/invalidValueError",
                                                    "In ({0}), {1} ({2}) is invalid. Expr: ({3})", funcname, "oldString", oldStr, x));
                                            }

                                            string newStr = GetArgument(args, 1, "");
                                            string isLoopedStr = GetArgument(args, 2, "0");

                                            if (!int.TryParse(isLoopedStr, out int isLooped))
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/parseTypeError",
                                                    "{0} ({1}) could not be parsed into {2}. Expr: ({3})", isLooped, isLoopedStr, "int", x));
                                            }
                                            if (newStr.Contains(oldStr) && isLooped > 0)
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/infiniteRepeatError",
                                                    "In the repeat function, new string ({0}) cannot contain old string ({1}) in loop mode. Expr: ({2})", newStr, oldStr, x));
                                            }

                                            if (isLooped > 0)
                                            {
                                                val = funcval;
                                                if (newStr == oldStr)
                                                {
                                                    break;
                                                }
                                                while (val.Contains(oldStr))
                                                {
                                                    val = val.Replace(oldStr, newStr);
                                                }
                                            }
                                            else
                                            {
                                                val = funcval.Replace(oldStr, newStr);
                                            }
                                        }
                                        break;
                                    case "substring": // substring(startindex, length) or substring(startindex)
                                        {
                                            if (argc != 1 && argc != 2)
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/argCountError",
                                                    "({0}) requires {1} arguments, {2} were given. Expr: ({3})", funcname, "1-2", argc, x));
                                            }
                                            int startIndex = Int32.Parse(args[0]);
                                            if (startIndex < 0)
                                            {
                                                startIndex += funcval.Length;
                                            }
                                            switch (argc)
                                            {
                                                case 1:
                                                    val = funcval.Substring(startIndex);
                                                    break;
                                                case 2:
                                                    val = funcval.Substring(startIndex, Int32.Parse(args[1]));
                                                    break;
                                            }
                                            break;
                                        }
                                    case "slice":  // slice(slices = "") 
                                        {
                                            if (argc != 0 && argc != 1)
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/argCountError",
                                                    "({0}) requires {1} arguments, {2} were given. Expr: ({3})", funcname, "1-2", argc, x));
                                            }
                                            string slicesStr = GetArgument(args, 0, "");
                                            var indices = GetSliceIndices(slicesStr, funcval.Length, startIndex: 0);
                                            StringBuilder sb = new StringBuilder();
                                            foreach (int index in indices)
                                            {
                                                sb.Append(funcval[index]);
                                            }
                                            val = $"{sb}";
                                            break;
                                        }
                                    case "pick": // pick(index, splitter = ",")
                                        {
                                            if (argc != 1 && argc != 2)
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/argCountError",
                                                    "({0}) requires {1} arguments, {2} were given. Expr: ({3})", funcname, "1-2", argc, x));
                                            }
                                            else
                                            {
                                                string separator = GetArgument(args, 1, ",");
                                                string[] strArray = funcval.Split(new string[] { separator }, StringSplitOptions.None);
                                                int index = Int32.Parse(args[0]);
                                                int normIndex = (index < 0) ? (index + strArray.Length) : index;

                                                if (normIndex < 0 || normIndex >= strArray.Length)
                                                {
                                                    val = "";
                                                    //throw new ArgumentException(I18n.Translate("internal/Context/normalizedIndexRangeError",
                                                    //    "Index {0} parsed (from raw index {1}) out of range {2}-{3}. Expr: ({4})", index, normIndex, 0, strArray.Length-1, x));
                                                }
                                                else
                                                {
                                                    val = strArray[normIndex];
                                                }
                                            }
                                            break;
                                        }
                                    case "args":
                                        val = "(" + string.Join(")\n(", args) + ")";
                                        break;
                                    case "i":
                                    case "indexof":      // indexof(stringtosearch)
                                    case "li":
                                    case "lastindexof":  // lastindexof(stringtosearch)
                                        if (argc != 1)
                                        {
                                            throw new ArgumentException(I18n.Translate("internal/Context/argCountError",
                                                "({0}) requires {1} arguments, {2} were given. Expr: ({3})", funcname, "1", argc, x));
                                        }
                                        else
                                        {
                                            int index = (funcname.StartsWith("i")) ? funcval.IndexOf(args[0]) : funcval.LastIndexOf(args[0]);
                                            val = index.ToString();
                                        }
                                        break;
                                    case "compare": // compare(stringtocompare) or compare(stringtocompare, ignorecase)
                                        if (argc != 1 && argc != 2)
                                        {
                                            throw new ArgumentException(I18n.Translate("internal/Context/argCountError",
                                                "({0}) requires {1} arguments, {2} were given. Expr: ({3})", funcname, "1-2", argc, x));
                                        }
                                        else
                                        {
                                            switch (argc)
                                            {
                                                case 1:
                                                    val = "" + String.Compare(funcval, args[0], true);
                                                    break;
                                                case 2:
                                                    bool ignoreCase = bool.Parse(args[1]);
                                                    val = "" + String.Compare(funcval, args[0], ignoreCase);
                                                    break;
                                            }
                                        }
                                        break;
                                    case "trim":        // trim() or trim(charcode/char, charcode/char, ...)
                                    case "trimleft":    // trimleft() or trimleft(charcode/char, charcode/char, ...)
                                    case "trimright":   // trimright() or trimright(charcode/char, charcode/char, ...)
                                        string trimChars = "";
                                        if (argc > 0)
                                        {
                                            foreach (string arg in args)
                                            {
                                                // length == 1: char    length != 1: charcode
                                                if (arg.Length == 1)
                                                {
                                                    trimChars += arg;
                                                }
                                                else if (arg.Length == 0)
                                                {
                                                    throw new ArgumentException(I18n.Translate("internal/Context/invalidValueError",
                                                        "In ({0}), {1} ({2}) is invalid. Expr: ({3})", funcname, "char/charcode", funcval, x));
                                                }
                                                else if (arg.Length > 1)
                                                {
                                                    if (!int.TryParse(arg, out int charcode))
                                                    {
                                                        throw new ArgumentException(I18n.Translate("internal/Context/parseTypeError",
                                                            "{0} ({1}) could not be parsed into {2}. Expr: ({3})", "charcode", arg, "int", x));
                                                    }
                                                    trimChars += GetReplacedChar(charcode).ToString();
                                                }
                                            }
                                        }

                                        char[] trimCharsArray = trimChars.ToCharArray();

                                        switch (funcname)
                                        {
                                            case "trim":
                                                val = argc == 0 ? funcval.Trim() : funcval.Trim(trimCharsArray);
                                                break;
                                            case "trimleft":
                                                val = argc == 0 ? funcval.TrimStart() : funcval.TrimStart(trimCharsArray);
                                                break;
                                            case "trimright":
                                                val = argc == 0 ? funcval.TrimEnd() : funcval.TrimEnd(trimCharsArray);
                                                break;
                                        }
                                        break;
                                    case "format": // format(type,formatstring)
                                        if (argc != 2)
                                        {
                                            throw new ArgumentException(I18n.Translate("internal/Context/argCountError",
                                                "({0}) requires {1} arguments, {2} were given. Expr: ({3})", funcname, "2", argc, x));
                                        }
                                        else
                                        {
                                            Type type = Type.GetType(args[0]);
                                            object converted = Convert.ChangeType(funcval, type, CultureInfo.InvariantCulture);
                                            val = String.Format("{0:" + args[1] + "}", converted);
                                        }
                                        break;
                                    case "utctime": // utctime(formatstring)
                                        {
                                            Int64 ts = Int64.Parse(funcval);
                                            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                                            dt = dt.AddSeconds(ts);
                                            if (argc == 0 || args[0] == "")
                                            {
                                                val = dt.ToString();
                                            }
                                            else
                                            {
                                                val = dt.ToString(args[0]);
                                            }
                                        }
                                        break;
                                    case "localtime": // localtime(formatstring)
                                        {
                                            Int64 ts = Int64.Parse(funcval);
                                            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                                            dt = dt.AddSeconds(ts);
                                            dt = dt.ToLocalTime();
                                            if (argc == 0 || args[0] == "")
                                            {
                                                val = dt.ToString();
                                            }
                                            else
                                            {
                                                val = dt.ToString(args[0]);
                                            }
                                        }
                                        break;
                                    case "nextetms": // func:nextETms:01:30 or func:nextETms:90
                                        {
                                            if (argc > 0)
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/argCountError",
                                                    "({0}) requires {1} arguments, {2} were given. Expr: ({3})", "nextETms", "0", argc, x));
                                            }
                                            string etString = funcval;
                                            double totalMin;
                                            try
                                            {
                                                if (etString.Contains(':'))
                                                {
                                                    double etHour = int.Parse(etString.Substring(0, etString.IndexOf(':')));
                                                    double etMin = double.Parse(etString.Substring(etString.IndexOf(':') + 1));
                                                    totalMin = etHour * 60.0 + etMin;
                                                    if (etHour < 0 || etMin < 0 || etMin > 60)
                                                    {
                                                        throw new Exception();
                                                    }
                                                }
                                                else
                                                {
                                                    totalMin = double.Parse(etString);
                                                }
                                                if (totalMin < 0 || totalMin > 1440)
                                                {
                                                    throw new Exception();
                                                }
                                            }
                                            catch
                                            {
                                                throw new ArgumentException(I18n.Translate("internal/Context/parseTypeError",
                                                        "{0} ({1}) could not be parsed into {2}. Expr: ({3})", "", etString, "time", x));
                                            }

                                            TimeSpan ez = GetEorzeanTime();
                                            val = Math.Round((totalMin - ez.TotalMinutes + 1440) % 1440 * 70 / 24 * 1000).ToString();
                                            found = true;
                                        }
                                        break;
                                }
                            }
                        }
                        else if (x.StartsWith("_ffxivparty[") || x.StartsWith("_party["))
                        {
                            mx = rexListProp.Match(x);
                            if (mx.Success == true)
                            {
                                string gindex = mx.Groups["index"].Value.Trim();
                                string gprop = mx.Groups["prop"].Value.Trim();
                                int iindex = 0;
                                VariableDictionary vc = null;
                                bool foundid = false;
                                if (Int64.TryParse(gindex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out Int64 honk) == true)
                                {
                                    vc = PluginBridges.BridgeFFXIV.GetIdPartyMember(gindex, out foundid);
                                }
                                if (foundid == false)
                                {
                                    if (Int32.TryParse(gindex, out iindex) == true)
                                    {
                                        vc = PluginBridges.BridgeFFXIV.GetPartyMember(iindex);
                                    }
                                    else
                                    {
                                        vc = PluginBridges.BridgeFFXIV.GetNamedPartyMember(gindex);
                                    }
                                }
                                if (vc != null)
                                {
                                    if (Entity.jobs["1"].ContainsKey(gprop))
                                    {
                                        string jobid = vc.GetValue("jobid").ToString();
                                        val = Entity.jobs[jobid][gprop].ToString();
                                    }
                                    else
                                    {
                                        val = vc.GetValue(gprop).ToString();
                                    }
                                }
                            }
                            found = true;
                        }
                        /*else if (x.StartsWith("_ffxiventity[") || x.StartsWith("_entity["))
                        {
                            mx = rexListProp.Match(x);
                            if (mx.Success == true)
                            {
                                string gindex = mx.Groups["index"].Value;
                                string gprop = mx.Groups["prop"].Value;
                                VariableDictionary vc = null;
                                bool foundid = false;
                                if (Int64.TryParse(gindex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out Int64 honk) == true)
                                {
                                    vc = PluginBridges.BridgeFFXIV.GetIdEntity(gindex, out foundid);
                                }
                                if (foundid == false)
                                {
                                    vc = PluginBridges.BridgeFFXIV.GetNamedEntity(gindex);
                                }
                                if (vc != null)
                                {
                                    if (Entity.jobs["1"].ContainsKey(gprop))
                                    {
                                        string jobid = vc.GetValue("jobid").ToString();
                                        val = Entity.jobs[jobid][gprop].ToString();
                                    }
                                    else
                                    {
                                        val = vc.GetValue(gprop).ToString();
                                    }
                                }
                            }
                            found = true;
                        }*/
                        else if (x.StartsWith("_ffxiventity[") || x.StartsWith("_entity["))
                        {
                            mx = rexListProp.Match(x);
                            if (mx.Success == true)
                            {
                                string gindex = mx.Groups["index"].Value;
                                string gprop = mx.Groups["prop"].Value;
                                VariableDictionary vc = null;
                                bool foundid = false;
                                if (Int64.TryParse(gindex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out Int64 honk) == true)
                                {
                                    vc = PluginBridges.BridgeFFXIV.GetIdEntity(gindex, out foundid);
                                }
                                if (foundid == false)
                                {
                                    vc = PluginBridges.BridgeFFXIV.GetNamedEntity(gindex);
                                }
                                if (vc != null)
                                {
                                    if (Entity.jobs["1"].ContainsKey(gprop))
                                    {
                                        string jobid = vc.GetValue("jobid").ToString();
                                        val = Entity.jobs[jobid][gprop].ToString();
                                    }
                                    else
                                    {
                                        val = vc.GetValue(gprop).ToString();
                                    }
                                }
                            }
                            found = true;
                        }
                        else if (x.StartsWith("_me."))
                        {
                            string prop = x.Substring(4);
                            val = "${_ffxiventity[${_me}]." + prop + "}";
                            found = true;
                        }
                        else if (x == "_ffxivtime" || x == "_ET")
                        {
                            TimeSpan ez = GetEorzeanTime();
                            int mins = (int)Math.Floor(ez.TotalMinutes);
                            val = mins.ToString();
                            found = true;
                        }
                        else if (x == "_ETprecise")
                        {
                            TimeSpan ez = GetEorzeanTime();
                            val = ez.TotalMinutes.ToString();
                            found = true;
                        }
                        else if (x == "_lastencounter")
                        {
                            val = plug != null ? plug.LastEncounterHook() : "";
                            found = true;
                        }
                        else if (x == "_activeencounter")
                        {
                            val = plug != null ? plug.ActiveEncounterHook() : "";
                            found = true;
                        }
                        else if (x.StartsWith("_textaura"))
                        {
                            mx = rexListProp.Match(x);
                            if (mx.Success == true)
                            {
                                string gindex = mx.Groups["index"].Value;
                                string gprop = mx.Groups["prop"].Value.ToLower();
                                val = "";
                                if (plug.sc != null)
                                {
                                    lock (plug.sc.textitems)
                                    {
                                        Scarborough.ScarboroughText item = plug.sc.GetText(gindex);
                                        if (item != null)
                                        {
                                            switch (gprop)
                                            {
                                                case "x":
                                                    val = item.Left.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                                case "y":
                                                    val = item.Top.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                                case "w":
                                                case "width":
                                                    val = item.Width.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                                case "h":
                                                case "height":
                                                    val = item.Height.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                                case "opacity":
                                                    val = item.Opacity.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                                case "text":
                                                    val = item.Text;
                                                    break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    lock (plug.textauras)
                                    {
                                        if (plug.textauras.ContainsKey(gindex) == true)
                                        {
                                            Forms.AuraContainerForm acf = plug.textauras[gindex];
                                            switch (gprop)
                                            {
                                                case "x":
                                                    val = acf.Left.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                                case "y":
                                                    val = acf.Top.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                                case "w":
                                                case "width":
                                                    val = acf.Width.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                                case "h":
                                                case "height":
                                                    val = acf.Height.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                                case "opacity":
                                                    val = acf.PresentableOpacity.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                                case "text":
                                                    val = acf.CurrentText;
                                                    break;
                                            }
                                        }
                                    }
                                }
                                found = true;
                            }
                        }
                        else if (x.StartsWith("_imageaura"))
                        {
                            mx = rexListProp.Match(x);
                            if (mx.Success == true)
                            {
                                string gindex = mx.Groups["index"].Value;
                                string gprop = mx.Groups["prop"].Value.ToLower();
                                val = "";
                                if (plug.sc != null)
                                {
                                    lock (plug.sc.imageitems)
                                    {
                                        Scarborough.ScarboroughImage item = plug.sc.GetImage(gindex);
                                        if (item != null)
                                        {
                                            switch (gprop)
                                            {
                                                case "x":
                                                    val = item.Left.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                                case "y":
                                                    val = item.Top.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                                case "w":
                                                case "width":
                                                    val = item.Width.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                                case "h":
                                                case "height":
                                                    val = item.Height.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                                case "opacity":
                                                    val = item.Opacity.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    lock (plug.imageauras)
                                    {
                                        if (plug.imageauras.ContainsKey(gindex) == true)
                                        {
                                            Forms.AuraContainerForm acf = plug.imageauras[gindex];
                                            switch (gprop)
                                            {
                                                case "x":
                                                    val = acf.Left.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                                case "y":
                                                    val = acf.Top.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                                case "w":
                                                case "width":
                                                    val = acf.Width.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                                case "h":
                                                case "height":
                                                    val = acf.Height.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                                case "opacity":
                                                    val = acf.PresentableOpacity.ToString(CultureInfo.InvariantCulture);
                                                    break;
                                            }
                                        }
                                    }
                                }
                                found = true;
                            }
                        }
                        else if (x == "_screenwidth")
                        {
                            System.Windows.Forms.Screen scr = System.Windows.Forms.Screen.PrimaryScreen;
                            val = scr.WorkingArea.Width.ToString(CultureInfo.InvariantCulture);
                            found = true;
                        }
                        else if (x == "_screenheight")
                        {
                            System.Windows.Forms.Screen scr = System.Windows.Forms.Screen.PrimaryScreen;
                            val = scr.WorkingArea.Height.ToString(CultureInfo.InvariantCulture);
                            found = true;
                        }
                        else if (x == "_screenminx")
                        {
                            val = plug.MinX.ToString(CultureInfo.InvariantCulture);
                            found = true;
                        }
                        else if (x == "_screenminy")
                        {
                            val = plug.MinY.ToString(CultureInfo.InvariantCulture);
                            found = true;
                        }
                        else if (x == "_screenmaxx")
                        {
                            val = plug.MaxX.ToString(CultureInfo.InvariantCulture);
                            found = true;
                        }
                        else if (x == "_screenmaxy")
                        {
                            val = plug.MaxY.ToString(CultureInfo.InvariantCulture);
                            found = true;
                        }
                    }
                }
                newexpr = newexpr.Substring(0, m.Index) + val + newexpr.Substring(m.Index + m.Length);
                i++;
            };
            while (true)
            {
                m = rox.Match(newexpr);
                if (m.Success == true)
                {
                    newexpr = newexpr.Substring(0, m.Index) + "$" + newexpr.Substring(m.Index + 1);
                }
                else
                {
                    break;
                }
            }

            // replace back linebreaks
            newexpr = newexpr.Replace(LINEBREAK_PLACEHOLDER, "\n");

            if (trig != null)
            {
                if (trig._DebugLevel == RealPlugin.DebugLevelEnum.Inherit)
                {
                    if (plug != null)
                    {
                        if (plug.cfg.DebugLevel < RealPlugin.DebugLevelEnum.Verbose)
                        {
                            return newexpr;
                        }
                    }
                }
                else
                {
                    if (trig._DebugLevel < RealPlugin.DebugLevelEnum.Verbose)
                    {
                        return newexpr;
                    }
                }
            }
            if (plug != null)
            {
                if (plug.cfg.LogVariableExpansions == false)
                {
                    return newexpr;
                }
            }
            if (newexpr.CompareTo(expr) != 0)
            {
                if (logger != null)
                {
                    logger(o, I18n.Translate("internal/Context/expansion", "Variable expansion from '{0}' to '{1}'", expr, newexpr));
                }
                else if (plug != null)
                {
                    plug.FilteredAddToLog(RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Context/expansion", "Variable expansion from '{0}' to '{1}'", expr, newexpr));
                }
            }
            return newexpr;
        }

    }

}
