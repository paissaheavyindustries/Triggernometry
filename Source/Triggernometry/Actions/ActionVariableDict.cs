using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;
using Triggernometry.Variables;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Dictionary variable operations
    /// </summary>
    [ActionCategory(ActionCategory.CategoryTypeEnum.Variable)]
    [XmlRoot(ElementName = "VariableDict")]
    public class ActionVariableDict : ActionBase
    {

        #region Properties

        /// <summary>
        /// Dictionary variable operations
        /// </summary>
        private enum OperationEnum
        {
            Unset,
            Set,
            Remove,
            SetAll,
            Build,
            Filter,
            Merge,
            MergeHard,
            GetEntity,
            UnsetAll,
            UnsetRegex,
            [Obsolete] GetEntityByName, // => GetEntity
            [Obsolete] GetEntityById, // => GetEntity
        }

        /// <summary>
        /// Expression types
        /// </summary>
        private enum ExpressionTypeEnum
        {
            /// <summary>
            /// String expression
            /// </summary>
            String,
            /// <summary>
            /// Numeric expression
            /// </summary>
            Numeric
        }

        /// <summary>
        /// Dictionary variable operation type
        /// </summary>
        [ActionAttribute(ordernum: 1)]
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
        /// Type of the key expression
        /// </summary>
        [ActionAttribute(ordernum: 2)]
        private ExpressionTypeEnum _KeyType { get; set; } = ExpressionTypeEnum.String;
        [XmlAttribute]
        public string KeyType
        {
            get
            {
                return (_KeyType != ExpressionTypeEnum.String) ? _KeyType.ToString() : null;
            }
            set
            {
                _KeyType = (ExpressionTypeEnum)Enum.Parse(typeof(ExpressionTypeEnum), value);
            }
        }

        /// <summary>
        /// Type of the value expression
        /// </summary>
        [ActionAttribute(ordernum: 3)]
        private ExpressionTypeEnum _ValueType { get; set; } = ExpressionTypeEnum.String;
        [XmlAttribute]
        public string ValueType
        {
            get
            {
                return (_ValueType != ExpressionTypeEnum.String) ? _ValueType.ToString() : null;
            }
            set
            {
                _ValueType = (ExpressionTypeEnum)Enum.Parse(typeof(ExpressionTypeEnum), value);
            }
        }

        /// <summary>
        /// Name of the dictionary variable
        /// </summary>
        [ActionAttribute(ordernum: 4)]
        private string _Name { get; set; } = "";
        [XmlAttribute]
        public string Name
        {
            get
            {
                return (_Name == "") ? null : _Name;
            }
            set
            {
                _Name = value;
            }
        }

        /// <summary>
        /// Name of the target variable for some operations
        /// </summary>
        [ActionAttribute(ordernum: 5)]
        private string _TargetVariable { get; set; } = "";
        [XmlAttribute]
        public string TargetVariable
        {
            get
            {
                return (_TargetVariable == "") ? null : _TargetVariable;
            }
            set
            {
                _TargetVariable = value;
            }
        }

        // todo remove?
        [ActionAttribute(ordernum: 6)]
        private string _VariableLength { get; set; } = "";
        [XmlAttribute]
        public string VariableLength
        {
            get
            {
                return (_VariableLength == "") ? null : _VariableLength;
            }
            set
            {
                _VariableLength = value;
            }
        }

        /// <summary>
        /// Key expression
        /// </summary>
        [ActionAttribute(ordernum: 7)]
        private string _Key { get; set; } = "";
        [XmlAttribute]
        public string Key
        {
            get
            {
                return (_Key == "") ? null : _Key;
            }
            set
            {
                _Key = value;
            }
        }

        /// <summary>
        /// Value expression
        /// </summary>
        [ActionAttribute(ordernum: 8)]
        private string _Value { get; set; } = "";
        [XmlAttribute]
        public string Value
        {
            get
            {
                return (_Value == "") ? null : _Value;
            }
            set
            {
                _Value = value;
            }
        }

        /// <summary>
        /// Indicates whether referenced variable is persistent or not
        /// </summary>
        [ActionAttribute(ordernum: 9)] // todo need to couple this with variable on editor
        private bool _Persistent { get; set; } = false;
        [XmlAttribute]
        public string Persistent
        {
            get
            {
                return (_Persistent) ? _Persistent.ToString() : null;
            }
            set
            {
                _Persistent = Boolean.Parse(value);
            }
        }

        /// <summary>
        /// Indicates whether referenced target variable is persistent or not
        /// </summary>
        [ActionAttribute(ordernum: 10)] // todo need to couple this with variable on editor
        private bool _TargetPersistent { get; set; } = false;
        [XmlAttribute]
        public string TargetPersistent
        {
            get
            {
                return (_TargetPersistent) ? _TargetPersistent.ToString() : null;
            }
            set
            {
                _TargetPersistent = Boolean.Parse(value);
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            string sPersistD = I18n.TrlVarPersist(_Persistent);
            string tPersistD = I18n.TrlVarPersist(_TargetPersistent);
            string keyType = I18n.TrlExprType(_KeyType == ExpressionTypeEnum.String);
            string valueType = I18n.TrlExprType(_ValueType == ExpressionTypeEnum.String);
            switch (_Operation)
            {
                case OperationEnum.Unset:
                    return I18n.Translate(
                        "internal/Action/descdictunset",
                        "unset {1}dict variable ({0})",
                        _Name, sPersistD
                    );                    
                case OperationEnum.Set:
                    return I18n.Translate("internal/Action/descdictset",
                        "set the value of {3} key ({2}) in the {1}dict variable ({0}) to {5} expression ({4})",
                        _Name, sPersistD, _Key, keyType, _Value, valueType
                    );
                case OperationEnum.Remove:
                    return I18n.Translate(
                        "internal/Action/descdictremove",
                        "remove the {3} key ({2}) in the {1}dict variable ({0})",
                        _Name, sPersistD, _Key, keyType
                    );
                case OperationEnum.Build:
                    int dollarIndex = _Value.IndexOf("$");
                    int crcIndex = _Value.IndexOf("¡è{");
                    if (
                        _ValueType == ExpressionTypeEnum.String
                        && dollarIndex != 0 && dollarIndex != 1 && crcIndex != 0 && crcIndex != 1
                    )
                    {
                        return I18n.Translate(
                            "internal/Action/descdictbuild",
                            "build {1}dict variable ({0}) from string ({2}) separated by ({3}) ({4})",
                            _TargetVariable, tPersistD,
                            (_Value.Length < 2) ? "" : _Value.Substring(2),
                            (_Value.Length < 1) ? "" : _Value.Substring(0, 1),
                            (_Value.Length < 2) ? "" : _Value.Substring(1, 1)
                        );
                    }
                    return I18n.Translate(
                        "internal/Action/descdictbuildraw",
                        "build {1}dict variable ({0}) from {3} expression ({2}) separated by its first 2 characters",
                        _TargetVariable, tPersistD, _Value, valueType
                    );
                case OperationEnum.Filter:
                    return I18n.Translate(
                        "internal/Action/descdictfilter",
                        "Use expression ({4}) to filter {1}dict ({0}) into {3}dict ({2})",
                        _Name, sPersistD, _TargetVariable, tPersistD, _Value
                    );
                case OperationEnum.SetAll:
                    if (string.IsNullOrWhiteSpace(_VariableLength))
                    {
                        return I18n.Translate(
                            "internal/Action/descdictsetall",
                            "rewrite all key value pairs in {1}dict ({0}) to {3} expr ({2}) : {5} expr ({4})",
                            _Name, sPersistD, _Key, keyType, _Value, valueType
                        );
                    }
                    return I18n.Translate(
                        "internal/Action/descdictsetallbyindex",
                        "set {6} key value pairs in {1}dict ({0}) to {3} expr ({2}) : {5} expr ({4})",
                        _Name, sPersistD, _Key, keyType, _Value, valueType, _VariableLength
                    );
                case OperationEnum.Merge:
                    return I18n.Translate(
                        "internal/Action/descdictmerge",
                        "merge {1}dict variable ({0}) into {3}dict variable ({2}), and keep the values of repeated keys",
                        _Name, sPersistD, _TargetVariable, tPersistD
                    );                    
                case OperationEnum.MergeHard:
                    return I18n.Translate(
                        "internal/Action/descdictmergehard",
                        "merge {1}dict variable ({0}) into {3}dict variable ({2}), and overwrite the values of repeated keys",
                        _Name, sPersistD, _TargetVariable, tPersistD
                    );
                case OperationEnum.GetEntity:
                    {
                        bool hasSpecifiedProps = !string.IsNullOrWhiteSpace(_Key);
                        string key = hasSpecifiedProps ? "internal/Action/descdictgetentitygivenprops"
                                                       : "internal/Action/descdictgetentity";
                        string trl = hasSpecifiedProps ? "Store ({3}) properties of the entity ({2}) in {1}dictionary ({0})"
                                                       : "Store all properties of the entity ({2}) in {1}dictionary ({0})";
                        return I18n.Translate(key, trl, _Name, sPersistD, _Value, _Key);
                    }
                case OperationEnum.UnsetAll:
                    return I18n.Translate(
                        "internal/Action/descdictunsetall",
                        "unset all {0}dict variables",
                        sPersistD
                    );
                case OperationEnum.UnsetRegex:
                    return I18n.Translate(
                        "internal/Action/descdictunsetregex",
                        "unset all {0}dict variables matching regular expression ({1})",
                        sPersistD, _Name
                    );
            }
            return "";
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            string sourcename = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Name);
            string targetname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _TargetVariable);
            VariableStore svs = (_Persistent) ? ctx.plug.cfg.PersistentVariables : ctx.plug.sessionvars;
            VariableStore tvs = (_TargetPersistent) ? ctx.plug.cfg.PersistentVariables : ctx.plug.sessionvars;
            string sPersist = I18n.TrlVarPersist(_Persistent);
            string tPersist = I18n.TrlVarPersist(_TargetPersistent);

            string ParseKey()
            {
                if (_KeyType == ExpressionTypeEnum.String)
                    return ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Key);
                else
                    return I18n.ThingToString(ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _Key));

            }
            string ParseValue()
            {
                if (_ValueType == ExpressionTypeEnum.String)
                    return ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Value);
                else
                    return I18n.ThingToString(ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _Value));
            }

            string vdchanger;
            if (ctx.trig != null)
                vdchanger = I18n.Translate("internal/Action/changetagtrigaction", "Trigger '{0}' action '{1}'", ctx.trig.LogName, Describe(ctx));
            else
                vdchanger = I18n.Translate("internal/Action/changetagtestmode", "Action '{0}' test mode", Describe(ctx));

            switch (_Operation)
            {
                case OperationEnum.UnsetAll:
                    lock (svs.Dict)
                    {
                        svs.Dict.Clear();
                    }
                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictunsetall",
                        "All {0}dict variables unset", sPersist));
                    break;
                case OperationEnum.UnsetRegex:                    
                    svs.UnsetVariableRegex(svs.Dict, _Name);
                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictunsetregex",
                        "All {0}dict variables matching ({1}) unset", sPersist, _Name));
                    break;
                case OperationEnum.Unset:
                    svs.UnsetVariable(svs.Dict, sourcename);
                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictunset",
                        "Unset {1}dict variable ({0})", sourcename, sPersist));
                    break;
                case OperationEnum.Set:
                    {
                        string[] invalidExprs = new[] { "${_row", "${_col", "${_this}", "${_idx}", "${_key}" };
                        CheckInvalidDymanicExpr(_Value, invalidExprs);

                        string key = ParseKey();
                        string value;
                        lock (svs.Dict)
                        {
                            VariableDictionary vd = svs.GetDictVariable(sourcename, true);
                            ctx.dictValue = vd.GetValue(key).ToString(); // for ${_val}
                            value = ParseValue();
                            vd.SetValue(key, value, vdchanger);
                        }
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictset",
                            "Value of key ({2}) in {1}dict variable ({0}) set to ({3})", sourcename, sPersist, key, value));
                    }
                    break;
                case OperationEnum.Remove:
                    {
                        string key = ParseKey();
                        lock (svs.Dict)
                        {
                            VariableDictionary vd = svs.GetDictVariable(sourcename, true);
                            vd.RemoveKey(key, vdchanger);
                        }
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictremove",
                            "Removed key ({2}) from {1}dict variable ({0})", sourcename, sPersist, key));
                    }
                    break;
                case OperationEnum.Merge:
                case OperationEnum.MergeHard:
                    {
                        bool shouldOverwrite = (_Operation == OperationEnum.MergeHard);
                        VariableDictionary svdCopy;
                        lock (svs.Dict)
                        {
                            svdCopy = (VariableDictionary)svs.GetDictVariable(sourcename, false).Duplicate();
                        }
                        lock (tvs.Dict)
                        {
                            VariableDictionary tvd = tvs.GetDictVariable(targetname, true);
                            tvd.Merge(svdCopy, overwriteExistingKeys: shouldOverwrite);
                        }
                        if (shouldOverwrite)
                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictmergehard",
                                "Merged {1}dict variable ({0}) into {3}dict variable ({2}) (overwrite repeated keys)",
                                sourcename, sPersist, targetname, tPersist));
                        else
                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictmerge",
                                "Merged {1}dict variable ({0}) into {3}dict variable ({2}) (keep repeated keys)",
                                sourcename, sPersist, targetname, tPersist));
                    }
                    break;
                case OperationEnum.GetEntity:
                    {
                        string value = ParseValue();

                        var entity = FFXIV.Entity.GetFilteredEntities(value).FirstOrDefault();
                        entity = entity ?? FFXIV.Entity.NullEntity();

                        var propNames = string.IsNullOrWhiteSpace(_Key)
                            ? FFXIV.Entity.RecommendedEntityPropNames.Concat(FFXIV.Job.LegalJobPropNames)
                            : Context.SplitArguments(ParseKey(), false);

                        var vd = new VariableDictionary(propNames.ToDictionary(
                            propName => propName,
                            propName => entity.QueryProperty(propName)
                        ));
                        
                        lock (svs.Dict)
                        {
                            svs.Dict[sourcename] = vd;
                        }
                        if (entity.Exist)
                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictgetentity",
                                "Saved the data of entity ({2}) into {1}dict variable ({0})",
                                sourcename, sPersist, value));
                        else
                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/dictgetentityfail",
                                "Entity ({2}) not found when trying to save into {1}dict variable ({0})",
                                sourcename, sPersist, value));
                    }
                    break;
                case OperationEnum.Build:
                    {   // Using the first 2 characters in the expression as the separator to split the remaining part into a new dict
                        // e.g. expr = ":,aaa:1,bbb:2,ccc:3"
                        VariableDictionary vt = new VariableDictionary();
                        string expr = ParseValue();
                        if (expr.Length > 1)
                        {
                            if (expr[1] == '\n' || expr.Substring(1).StartsWith("\r\n"))
                                expr = Context.ReplaceLineBreak(expr);
                            char kvSeparator = expr[0];
                            char pairSeparator = expr[1];
                            string splitval = expr.Substring(2);
                            vt = VariableDictionary.Build(splitval, kvSeparator, pairSeparator, vdchanger);
                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictbuild",
                                "{1}Dictionary ({0}) built from expression ({2}) splitted by ({3}) ({4})",
                                targetname, tPersist, splitval, kvSeparator, pairSeparator));
                        }
                        else
                        {
                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/dictbuildfail",
                                "{1}Dictionary ({0}) cannot be built since expression ({2}) length < 2",
                                targetname, tPersist, expr));
                        }
                        lock (tvs.Dict)
                        {
                            tvs.Dict[targetname] = vt;
                        }
                    }
                    break;
                case OperationEnum.Filter:
                    {
                        string[] invalidExprs = new[] { "${_row", "${_col", "${_this}", "${_idx}" };
                        CheckInvalidDymanicExpr(_Value, invalidExprs);
                        VariableDictionary vdResult = new VariableDictionary();
                        lock (svs.Dict)
                        {
                            VariableDictionary vd = svs.GetDictVariable(sourcename, false);
                            foreach (var pair in vd.Values)
                            {
                                ctx.dictKey = pair.Key;                 // for ${_key}
                                ctx.dictValue = pair.Value.ToString();  // for ${_val}
                                double result = ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _Value);
                                if (!MathParser.IsZero(result))
                                {
                                    vdResult.Values[pair.Key] = pair.Value.Duplicate();
                                }
                            }
                        }
                        vdResult.LastChanger = vdchanger;
                        vdResult.LastChanged = DateTime.Now;
                        lock (tvs.Dict)
                        {
                            tvs.Dict[targetname] = vdResult;
                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictfilter",
                                "Filtered {4} key-value pairs from {1}dict ({0}) into {3}dict ({2})",
                                sourcename, sPersist, targetname, tPersist, vdResult.Size));
                        }
                    }
                    break;
                case OperationEnum.SetAll:
                    {
                        bool isLengthMode = !string.IsNullOrWhiteSpace(_VariableLength);
                        int length = isLengthMode ? (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _VariableLength) : 0;
                        string[] invalidExprs = new[] { "${_row", "${_col", "${_this}" };
                        CheckInvalidDymanicExpr(_Key, invalidExprs);
                        CheckInvalidDymanicExpr(_Value, invalidExprs);
                        VariableDictionary vdNew = new VariableDictionary();
                        lock (svs.Dict)
                        {
                            VariableDictionary vd = svs.GetDictVariable(sourcename, false);
                            ctx.varName = (_Persistent ? "pdvar:" : "dvar:") + sourcename;

                            if (isLengthMode)
                            {   // should only use ${_idx} to generate each key/value
                                for (int i = 0; i < length; i++)
                                {
                                    ctx.listIndex = i + 1;
                                    ctx.dictKey = (i < vd.Size) ? vd.Values.ElementAt(i).Key : "";
                                    ctx.dictValue = (i < vd.Size) ? vd.Values.ElementAt(i).Value.ToString() : "";
                                    string k = ParseKey();
                                    string v = ParseValue();
                                    vdNew.SetValue(k, v, vdchanger);
                                }
                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictsetallbyindex",
                                    "{4} key value pairs in {1}dictionary ({0}) set to ({2}): ({3})",
                                    sourcename, sPersist, _Key, _Value, length));
                            }
                            else
                            {   // should only use ${_key} and ${_val} to rewrite the list
                                foreach (var pair in vd.Values)
                                {
                                    ctx.dictKey = pair.Key;
                                    ctx.dictValue = pair.Value.ToString();
                                    string k = ParseKey();
                                    string v = ParseValue();
                                    vdNew.SetValue(k, v, vdchanger);
                                }
                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/dictsetall",
                                    "All key value pairs in {1}dictionary ({0}) set to ({2}): ({3})",
                                    sourcename, sPersist, _Key, _Value));
                            }
                            svs.Dict[sourcename] = vdNew;
                        }
                    }
                    break;
            }
        }

        #endregion

    }

}
