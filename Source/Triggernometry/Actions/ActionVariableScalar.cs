using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;
using Triggernometry.Variables;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Scalar variable operations
    /// </summary>
    [XmlRoot(ElementName = "VariableScalar")]
    public class ActionVariableScalar : ActionBase
    {

        #region Properties

        /// <summary>
        /// Scalar variable operations
        /// </summary>
        private enum OperationEnum
        {
            /// <summary>
            /// Unset scalar variable
            /// </summary>
            Unset,
            /// <summary>
            /// Set scalar variable value according to string expression
            /// </summary>
            SetString,
            /// <summary>
            /// Set scalar variable value according to numeric expression
            /// </summary>
            SetNumeric,
            /// <summary>
            /// Increment scalar variable by value if defined, 1 otherwise
            /// </summary>
            Increment,
            /// <summary>
            /// Copy value from scalar variable to clipboard
            /// </summary>
            Clipboard,
            /// <summary>
            /// Unset all scalar variables
            /// </summary>
            UnsetAll,
            /// <summary>
            /// Unset all scalar variables with names matching given regex
            /// </summary>
            UnsetRegex,
            // todo should not be here
            UnsetRegexUniversal,
            /// <summary>
            /// Query scalar variable with JSONPath, and store result in scalar variable
            /// </summary>
            QueryJsonPath,
            /// <summary>
            /// Query scalar variable with JSONPath, and store result in list variable
            /// </summary>
            QueryJsonPathList
        }

        /// <summary>
        /// Scalar variable operation type
        /// </summary>
        private OperationEnum _Operation { get; set; } = OperationEnum.Unset;
        [XmlAttribute]
        public string Operation
        {
            get
            {
                if (_Operation != OperationEnum.Unset)
                {
                    return _Operation.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _Operation = (OperationEnum)Enum.Parse(typeof(OperationEnum), value);
            }
        }

        /// <summary>
        /// Name of the scalar variable
        /// </summary>
        private string _Name = "";
        [XmlAttribute]
        public string Name
        {
            get
            {
                if (_Name == "")
                {
                    return null;
                }
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        /// <summary>
        /// Name of the target variable for some JSON operations
        /// </summary>
        private string _JsonTargetName = "";
        [XmlAttribute]
        public string JsonTargetName
        {
            get
            {
                if (_JsonTargetName == "")
                {
                    return null;
                }
                return _JsonTargetName;
            }
            set
            {
                _JsonTargetName = value;
            }
        }

        /// <summary>
        /// Value expression
        /// </summary>
        private string _Value = "";
        [XmlAttribute]
        public string Value
        {
            get
            {
                if (_Value == "")
                {
                    return null;
                }
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }

        /// <summary>
        /// Indicates whether referenced target variable is persistent or not
        /// </summary>
        private bool _JsonTargetPersistent { get; set; } = false;
        [XmlAttribute]
        public string JsonTargetPersistent
        {
            get
            {
                if (_JsonTargetPersistent == false)
                {
                    return null;
                }
                return _JsonTargetPersistent.ToString();
            }
            set
            {
                _JsonTargetPersistent = Boolean.Parse(value);
            }
        }

        /// <summary>
        /// Indicates whether referenced variable is persistent or not
        /// </summary>
        private bool _Persistent { get; set; } = false;
        [XmlAttribute]
        public string Persistent
        {
            get
            {
                if (_Persistent == false)
                {
                    return null;
                }
                return _Persistent.ToString();
            }
            set
            {
                _Persistent = Boolean.Parse(value);
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            string sPersist = I18n.TrlVarPersist(_Persistent);
            string tPersist = I18n.TrlVarPersist(_JsonTargetPersistent);
            switch (_Operation)
            {
                case OperationEnum.SetNumeric:
                case OperationEnum.SetString:
                    string exprType = I18n.TrlExprType(_Operation == OperationEnum.SetString);
                    return I18n.Translate(
                        "internal/Action/descscalarset",
                        "set {1}scalar variable ({0}) value with {3} expression ({2})",
                        _Name, sPersist, _Value, exprType
                    );                    
                case OperationEnum.Increment:
                    string value = string.IsNullOrWhiteSpace(_Value) ? "1" : _Value;
                    return I18n.Translate(
                        "internal/Action/descscalarincrement",
                        "increment the value of {1}scalar variable ({0}) by ({2})",
                        _Name, sPersist, value
                    );                    
                case OperationEnum.Clipboard:
                    bool isName = !string.IsNullOrWhiteSpace(_Name);
                    if (isName)
                    {
                        return I18n.Translate(
                            "internal/Action/descscalarclipboardvar", 
                            "Copy {1}scalar variable ({0}) value to clipboard",
                            _Name, sPersist
                        );
                    }
                    return I18n.Translate(
                        "internal/Action/descscalarclipboardexpr",
                        "Copy string expression ({0}) to clipboard",
                        _Value
                    );
                case OperationEnum.Unset:
                    return I18n.Translate(
                        "internal/Action/descscalarunset",
                        "unset {1}scalar variable ({0})",
                        _Name, sPersist
                    );
                case OperationEnum.UnsetAll:
                    return I18n.Translate(
                        "internal/Action/descscalarunsetall",
                        "unset all {0}scalar variables",
                        sPersist
                    );
                case OperationEnum.UnsetRegex:
                    return I18n.Translate(
                        "internal/Action/descscalarunsetregex",
                        "unset {1}scalar variables matching regular expression ({0})",
                        _Name, sPersist
                    );
                case OperationEnum.UnsetRegexUniversal:
                    return I18n.Translate(
                        "internal/Action/descscalarunsetregexuniversal", 
                        "unset all types of {1}variables matching regular expression ({0})", 
                        _Name, sPersist
                    );
                case OperationEnum.QueryJsonPath:
                    return I18n.Translate(
                        "internal/Action/descscalarqueryjson",
                        "query {1} variable ({0}) with JSON path ({2}) and store result to {4}scalar variable ({3})",
                        _Name, sPersist, _Value, _JsonTargetName, tPersist
                    );
                case OperationEnum.QueryJsonPathList:
                    return I18n.Translate(
                        "internal/Action/descscalarqueryjsonlist",
                        "query {1} variable ({0}) with JSON path ({2}) and store result to {4}list variable ({3})",
                        _Name, sPersist, _Value, _JsonTargetName, tPersist
                    );                    
            }
            return "";
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            string varname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Name);
            string sPersist = I18n.TrlVarPersist(_Persistent);
            string tPersist = I18n.TrlVarPersist(_JsonTargetPersistent);
            string changer;
            if (ctx.trig != null)
            {
                changer = I18n.Translate("internal/Action/changetagtrigaction", "Trigger '{0}' action '{1}'", ctx.trig.LogName, Describe(ctx));
            }
            else
            {
                changer = I18n.Translate("internal/Action/changetagtestmode", "Action '{0}' test mode", Describe(ctx));
            }
            string newval;
            VariableStore vs = (_Persistent == false) ? ctx.plug.sessionvars : ctx.plug.cfg.PersistentVariables;
            switch (_Operation)
            {
                case OperationEnum.UnsetAll:
                    {
                        vs.UnsetAllVariables(vs.Scalar);
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarunsetall",
                            "All {0}scalar variables unset", sPersist));
                        break;
                    }
                case OperationEnum.UnsetRegex:
                    {
                        vs.UnsetVariableRegex(vs.Scalar, _Name);
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarunsetregex",
                            "All {1}scalar variables matching ({0}) unset", _Name, sPersist));
                        break;
                    }
                case OperationEnum.UnsetRegexUniversal:
                    {
                        Regex rx = new Regex(_Name);
                        vs.UnsetVariableRegex(vs.Scalar, rx);
                        vs.UnsetVariableRegex(vs.List, rx);
                        vs.UnsetVariableRegex(vs.Table, rx);
                        vs.UnsetVariableRegex(vs.Dict, rx);
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarunsetregexuniversal",
                            "All {1}variables matching ({0}) unset", _Name, sPersist));
                        break;
                    }
                case OperationEnum.Unset:
                    {
                        vs.UnsetVariable(vs.Scalar, varname);
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarunset",
                            "{1}Scalar variable ({0}) unset", varname, sPersist));
                        break;
                    }
                case OperationEnum.SetString:
                case OperationEnum.SetNumeric:
                    {
                        if (_Operation == OperationEnum.SetString)
                        {
                            newval = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Value);
                        }
                        else
                        {
                            newval = I18n.ThingToString(ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _Value));
                        }

                        VariableScalar x = new VariableScalar();
                        x.Value = newval;
                        x.LastChanger = changer;
                        x.LastChanged = DateTime.Now;
                        lock (vs.Scalar) // verified
                        {
                            vs.Scalar[varname] = x;
                        }
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarset",
                            "{2}Scalar variable ({0}) value set to ({1})", varname, newval, sPersist));
                        break;
                    }
                case OperationEnum.Increment:
                    {
                        double original = 0;
                        double increment = string.IsNullOrWhiteSpace(_Value)
                            ? 1 : ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _Value);
                        VariableScalar x = new VariableScalar { LastChanger = changer, LastChanged = DateTime.Now };
                        lock (vs.Scalar)
                        {
                            if (vs.Scalar.TryGetValue(varname, out VariableScalar originalVar))
                            {
                                if (!string.IsNullOrWhiteSpace(originalVar.Value))
                                {
                                    original = ctx.EvaluateNumericExpression(ActionContextLogger, ctx, originalVar.Value);
                                }
                            }
                            x.Value = I18n.ThingToString(original + increment);
                            vs.Scalar[varname] = x;
                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarset",
                                "{2}Scalar variable ({0}) value set to ({1})", varname, x.Value, sPersist));
                        }
                        break;
                    }
                case OperationEnum.Clipboard:
                    {
                        bool isName = !string.IsNullOrWhiteSpace(_Name);
                        string text = "";
                        if (isName)
                            lock (vs.Scalar)
                            {
                                text = vs.Scalar[varname].Value;
                            }
                        else
                        {
                            text = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Value);
                        }
                        //ClipboardSetText(text); todo
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarclipboard",
                            "Set text ({0}) to clipboard", text));
                        break;
                    }
                case OperationEnum.QueryJsonPath:
                    {
                        newval = "";
                        lock (vs.Scalar) // verified
                        {
                            if (vs.Scalar.ContainsKey(varname) == true)
                            {
                                newval = vs.Scalar[varname].Value;
                            }
                        }
                        string tgtname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _JsonTargetName);
                        VariableStore vs2 = (_JsonTargetPersistent == false) ? ctx.plug.sessionvars : ctx.plug.cfg.PersistentVariables;
                        string query = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Value);
                        JsonPath.JsonPathContext pc = new JsonPath.JsonPathContext();
                        Dictionary<string, object> p = new Parser().Parse(newval);
                        IEnumerable<object> result = pc.Select(p, query);

                        VariableScalar x = new VariableScalar();
                        switch (result.Count())
                        {
                            case 0: x.Value = ""; break;
                            case 1: x.Value = result.First().ToString(); break;
                            default: x.Value = JsonSerializer.Serialize<object[]>(result.ToArray()); break;
                        }
                        x.LastChanger = changer;
                        x.LastChanged = DateTime.Now;

                        lock (vs2.Scalar) // verified
                        {
                            vs2.Scalar[tgtname] = x;
                        }
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarset",
                            "{2}Scalar variable ({0}) value set to ({1})", tgtname, newval, tPersist));
                    }
                    break;
                case OperationEnum.QueryJsonPathList:
                    {
                        newval = "";
                        lock (vs.Scalar) // verified
                        {
                            if (vs.Scalar.ContainsKey(varname) == true)
                            {
                                newval = vs.Scalar[varname].Value;
                            }
                        }
                        string tgtname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _JsonTargetName);
                        VariableStore vs2 = (_JsonTargetPersistent == false) ? ctx.plug.sessionvars : ctx.plug.cfg.PersistentVariables;
                        string query = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Value);
                        JsonPath.JsonPathContext pc = new JsonPath.JsonPathContext();
                        Dictionary<string, object> p = new Parser().Parse(newval);
                        IEnumerable<object> result = pc.Select(p, query);

                        VariableList x = new VariableList();
                        x.LastChanger = changer;
                        x.LastChanged = DateTime.Now;
                        switch (result.Count())
                        {
                            case 0: break;
                            case 1: x.Push(new VariableScalar() { Value = result.First().ToString(), LastChanged = x.LastChanged, LastChanger = changer }, changer); break;
                            default:
                                foreach (object o in result)
                                {
                                    if (o is object[])
                                    {
                                        x.Push(new VariableScalar() { Value = JsonSerializer.Serialize<object[]>((object[])o), LastChanged = x.LastChanged, LastChanger = changer }, changer);
                                    }
                                    else if (o is Dictionary<string, object>)
                                    {
                                        x.Push(new VariableScalar() { Value = JsonSerializer.Serialize<Dictionary<string, object>>((Dictionary<string, object>)o), LastChanged = x.LastChanged, LastChanger = changer }, changer);
                                    }
                                    else
                                    {
                                        x.Push(new VariableScalar() { Value = o.ToString(), LastChanged = x.LastChanged, LastChanger = changer }, changer);
                                    }
                                }
                                break;
                        }
                        lock (vs2.List) // verified
                        {
                            vs2.List[tgtname] = x;
                        }
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/listset",
                            "{2}List variable ({0}) value set to ({1})", tgtname, newval, tPersist));
                    }
                    break;
            }
        }

        internal override Control GetPropertyEditor()
        {
            // todo
            return null;
        }

        #endregion

    }

}
