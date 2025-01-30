using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;
using Triggernometry.Variables;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Table variable operations
    /// </summary>
    [ActionCategory(ActionCategory.CategoryTypeEnum.Variable)]
    [XmlRoot(ElementName = "VariableTable")]
    public class ActionVariableTable : ActionBase
    {

        #region Properties

        /// <summary>
        /// Table variable operations
        /// </summary>
        private enum OperationEnum
        {
            Unset,
            Set,
            SetAll,
            SlicesSetAll,
            Resize,
            Build,
            SetLine,
            InsertLine,
            RemoveLine,
            Filter,
            FilterLine,
            Copy,
            Append,
            AppendH,
            SortLine,
            GetAllEntities,
            UnsetAll,
            UnsetRegex,
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
        /// Table variable operation type
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
        /// Type of the value expression
        /// </summary>
        [ActionAttribute(ordernum: 2)]
        private ExpressionTypeEnum _ValueType { get; set; } = ExpressionTypeEnum.String;
        [XmlAttribute]
        public string ValueType
        {
            get
            {
                if (_ValueType != ExpressionTypeEnum.String)
                {
                    return _ValueType.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _ValueType = (ExpressionTypeEnum)Enum.Parse(typeof(ExpressionTypeEnum), value);
            }
        }

        /// <summary>
        /// Name of the table variable
        /// </summary>
        [ActionAttribute(ordernum: 3)]
        private string _Name { get; set; } = "";
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
        /// Name of the target table variable for some operations
        /// </summary>
        [ActionAttribute(ordernum: 4)]
        private string _TargetName { get; set; } = "";
        [XmlAttribute]
        public string TargetName
        {
            get
            {
                if (_TargetName == "")
                {
                    return null;
                }
                return _TargetName;
            }
            set
            {
                _TargetName = value;
            }
        }

        /// <summary>
        /// Value expression
        /// </summary>
        [ActionAttribute(ordernum: 5)]
        private string _Value { get; set; } = "";
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
        /// X (column) reference
        /// </summary>
        [ActionAttribute(ordernum: 6)]
        private string _X { get; set; } = "";
        [XmlAttribute]
        public string X
        {
            get
            {
                if (_X == "")
                {
                    return null;
                }
                return _X;
            }
            set
            {
                _X = value;
            }
        }

        /// <summary>
        /// Y (row) reference
        /// </summary>
        [ActionAttribute(ordernum: 7)]
        private string _Y { get; set; } = "";
        [XmlAttribute]
        public string Y
        {
            get
            {
                if (_Y == "")
                {
                    return null;
                }
                return _Y;
            }
            set
            {
                _Y = value;
            }
        }

        /// <summary>
        /// Indicates whether referenced variable is persistent or not
        /// </summary>
        [ActionAttribute(ordernum: 8)] // todo need to couple this with variable on editor
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

        /// <summary>
        /// Indicates whether referenced target variable is persistent or not
        /// </summary>
        [ActionAttribute(ordernum: 9)] // todo need to couple this with variable on editor
        private bool _TargetPersistent { get; set; } = false;
        [XmlAttribute]
        public string TargetPersistent
        {
            get
            {
                if (_TargetPersistent == false)
                {
                    return null;
                }
                return _TargetPersistent.ToString();
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
            string sPersistT = I18n.TrlVarPersist(_Persistent);
            string tPersistT = I18n.TrlVarPersist(_TargetPersistent);
            string exprTypeT = I18n.TrlExprType(_ValueType == ExpressionTypeEnum.String);
            switch (_Operation)
            {
                case OperationEnum.Set:
                    return I18n.Translate(
                        "internal/Action/desctableset",
                        "set {1}table variable ({0}) value at ({2},{3}) with {5} expression ({4})",
                        _Name, sPersistT, _X, _Y, _Value, exprTypeT
                    );                    
                case OperationEnum.SetAll:
                    {
                        string temp = I18n.Translate(
                            "internal/Action/desctablesetall",
                            "set all values in {1}table ({0}) to {3} expr ({2})",
                            _Name, sPersistT, _Value, exprTypeT
                        );
                        bool givenX = !string.IsNullOrWhiteSpace(_X);
                        bool givenY = !string.IsNullOrWhiteSpace(_Y);
                        if (givenX && givenY)
                        {
                            temp += I18n.Translate(
                                "internal/Action/desctablesetallresizeXY",
                                " (resized to width ({0}) height ({1}))",
                                _X, _Y
                            );
                        }
                        else if (givenX && !givenY)
                        {
                            temp += I18n.Translate(
                                "internal/Action/desctablesetallresizeX",
                                " (resized to width ({0}))",
                                _X
                            );
                        }
                        else if (!givenX && givenY)
                        {
                            temp += I18n.Translate(
                                "internal/Action/desctablesetallresizeY",
                                " (resized to height ({0}))",
                                _Y
                            );
                        }
                        return temp;
                    }                    
                case OperationEnum.SlicesSetAll:
                    return I18n.Translate(
                        "internal/Action/desctableslicessetall",
                        "set all values in column(s) ({4}) and row(s) ({5}) of {1}table ({0}) to {3} expr ({2})",
                        _Name, sPersistT, _Value, exprTypeT, _X, _Y
                    );
                case OperationEnum.Resize:
                    {
                        string temp = I18n.Translate(
                            "internal/Action/desctableresizeprefix",
                            "resize {1}table variable ({0}) to",
                            _Name, sPersistT
                        );
                        bool givenCol = !string.IsNullOrWhiteSpace(_X);
                        bool givenRow = !string.IsNullOrWhiteSpace(_Y);
                        if (!givenCol && !givenRow)
                        {
                            temp += I18n.Translate("internal/Action/desctableresizeunchanged", " (unchanged)");
                        }
                        if (givenCol)
                        {
                            temp += I18n.Translate("internal/Action/desctableresizecol", " width ({0})", _X);
                        }
                        if (givenRow)
                        {
                            temp += I18n.Translate("internal/Action/desctableresizerow", " height ({0})", _Y);
                        }
                        return temp;
                    }
                case OperationEnum.Unset:
                    return I18n.Translate(
                        "internal/Action/desctableunset",
                        "unset {1}table variable ({0})",
                        _Name, sPersistT
                    );
                case OperationEnum.UnsetAll:
                    return I18n.Translate(
                        "internal/Action/desctableunsetall",
                        "unset {0}all table variables",
                        sPersistT
                    );
                case OperationEnum.UnsetRegex:
                    return I18n.Translate(
                        "internal/Action/desctableunsetregex",
                        "unset {1}table variables matching regular expression ({0})",
                        _Name, sPersistT
                    );
                case OperationEnum.Copy:
                    return I18n.Translate(
                        "internal/Action/desctablecopy",
                        "copy {2}table variable ({0}) to {3}table variable ({1})",
                        _Name, _TargetName, sPersistT, tPersistT
                    );
                case OperationEnum.Append:
                    return I18n.Translate("internal/Action/desctableappend",
                        "vertically append {2}table variable ({0}) to {3}table variable ({1})",
                        _Name, _TargetName, sPersistT, tPersistT
                    );
                case OperationEnum.AppendH:
                    return I18n.Translate(
                        "internal/Action/desctableappendh",
                        "horizontally append {2}table variable ({0}) to {3}table variable ({1})",
                        _Name, _TargetName, sPersistT, tPersistT
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
                            "internal/Action/desctablebuild",
                            "build {1}table variable ({0}) from string ({2}) separated by ({3}) ({4})",
                            _TargetName, tPersistT,
                            (_Value.Length < 2) ? "" : _Value.Substring(2),
                            (_Value.Length < 1) ? "" : _Value.Substring(0, 1),
                            (_Value.Length < 2) ? "" : _Value.Substring(1, 1)
                        );
                    }
                    return I18n.Translate(
                        "internal/Action/desctablebuildraw",
                        "build {1}table variable ({0}) from {3} expression ({2}) separated by its first 2 characters",
                        _TargetName, tPersistT, _Value, exprTypeT
                    );
                case OperationEnum.Filter:
                    return I18n.Translate(
                        "internal/Action/desctablefilter",
                        "Use expression ({4}) to filter {1}table ({0}) into {3}list ({2})",
                        _Name, sPersistT, _TargetName, tPersistT, _Value
                    );
                case OperationEnum.FilterLine:
                    {
                        bool isCol = !string.IsNullOrWhiteSpace(_X);
                        string lineType = I18n.TrlTableColOrRow(isCol);
                        return I18n.Translate(
                            "internal/Action/desctablefilterline",
                            "Use expression ({4}) to filter the {5}s in {1}table ({0}) into {3}table ({2})",
                            _Name, sPersistT, _TargetName, tPersistT, isCol ? _X : _Y, lineType
                        );
                    }
                case OperationEnum.SetLine:
                    {
                        string lineType = I18n.TrlTableColOrRow(!string.IsNullOrWhiteSpace(_X));
                        string index = (!string.IsNullOrWhiteSpace(_X)) ? _X : _Y;
                        if (
                            _ValueType == ExpressionTypeEnum.String
                            && !_Value.StartsWith("$") && !_Value.StartsWith("¡è{")
                        )
                        {
                            return I18n.Translate(
                                "internal/Action/desctablesetline",
                                "set {1}table ({0}) {2} #({3}) values from string ({4}) separated by ({5})",
                                _Name, sPersistT, lineType, index,
                                (_Value.Length < 1) ? "" : _Value.Substring(1),
                                (_Value.Length < 1) ? "" : _Value.Substring(0, 1)
                            );
                        }
                        return I18n.Translate(
                            "internal/Action/desctablesetlineraw",
                            "set {1}table ({0}) {2} #({3}) values from {5} expression ({4}) separated by its first character",
                            _Name, sPersistT, lineType, index, _Value, exprTypeT
                        );
                    }
                case OperationEnum.InsertLine:
                    {
                        string lineType = I18n.TrlTableColOrRow(!string.IsNullOrWhiteSpace(_X));
                        string index = (!string.IsNullOrWhiteSpace(_X)) ? _X : _Y;
                        if (
                            _ValueType == ExpressionTypeEnum.String
                            && !_Value.StartsWith("$") && !_Value.StartsWith("¡è{")
                        )
                        {
                            return I18n.Translate(
                                "internal/Action/desctableinsertline",
                                "at {1}table ({0}) {3} #({2}), insert values from string ({4}) separated by ({5})",
                                _Name, sPersistT, lineType, index,
                                (_Value.Length < 1) ? "" : _Value.Substring(1),
                                (_Value.Length < 1) ? "" : _Value.Substring(0, 1)
                            );
                        }
                        return I18n.Translate(
                            "internal/Action/desctableinsertlineraw",
                            "at {1}table ({0}) {3} #({2}), insert values from {5} expression ({4}) separated by its first character",
                            _Name, sPersistT, lineType, index, _Value, exprTypeT
                        );
                    }
                case OperationEnum.RemoveLine:
                    {
                        string lineType = I18n.TrlTableColOrRow(!string.IsNullOrWhiteSpace(_X));
                        string index = (!string.IsNullOrWhiteSpace(_X)) ? _X : _Y;
                        return I18n.Translate(
                            "internal/Action/desctableremoveline",
                            "removed {2} #({3}) from {1}table ({0})",
                            _Name, sPersistT, lineType, index
                        );
                    }
                case OperationEnum.SortLine:
                    {
                        bool isCol = !string.IsNullOrWhiteSpace(_X);
                        string lineType = I18n.TrlTableColOrRow(isCol);
                        return I18n.Translate(
                            "internal/Action/desctablesortline",
                            "sort the {2}s of {1}table variable ({0}) by keys ({3})",
                            _Name, sPersistT, lineType, isCol ? _X : _Y
                        );
                    }
                case OperationEnum.GetAllEntities:
                    {
                        bool hasFilter = string.IsNullOrWhiteSpace(_Y);
                        bool hasSpecifiedProps = !string.IsNullOrWhiteSpace(_X);
                        string keySuffix = (hasFilter ? "1" : "0") + (hasSpecifiedProps ? "1" : "0");
                        string key = $"internal/Action/desctablegetallentities{keySuffix}"; //...00, ...01, ...10, ...11
                        string trl = "";
                        switch (keySuffix)
                        {
                            case "11": trl = "Store ({3}) properties of FFXIV entities matching ({2}) in {1}table ({0})"; break;
                            case "10": trl = "Store all properties of FFXIV entities matching ({2}) in {1}table ({0})"; break;
                            case "01": trl = "Store ({3}) properties of all FFXIV entities in {1}table ({0})"; break;
                            case "00": trl = "Store all properties of all FFXIV entities in {1}table ({0})"; break;
                        }
                        return I18n.Translate(key, trl, _Name, sPersistT, _Y, _X);
                    }
            }
            return "";
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            string sourcename = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Name);
            string targetname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _TargetName);
            VariableStore svs = (_Persistent == false) ? ctx.plug.sessionvars : ctx.plug.cfg.PersistentVariables;
            VariableStore tvs = (_TargetPersistent == false) ? ctx.plug.sessionvars : ctx.plug.cfg.PersistentVariables;
            string sPersist = I18n.TrlVarPersist(_Persistent);
            string tPersist = I18n.TrlVarPersist(_TargetPersistent);
            string expr;
            string ParseExpr()
            {
                if (_ValueType == ExpressionTypeEnum.String)
                    return ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Value);
                else
                    return I18n.ThingToString(ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _Value));
            }

            string vtchanger;
            if (ctx.trig != null)
            {
                vtchanger = I18n.Translate("internal/Action/changetagtrigaction", "Trigger '{0}' action '{1}'", ctx.trig.LogName, Describe(ctx));
            }
            else
            {
                vtchanger = I18n.Translate("internal/Action/changetagtestmode", "Action '{0}' test mode", Describe(ctx));
            }

            switch (_Operation)
            {
                case OperationEnum.UnsetAll:
                    {
                        svs.UnsetAllVariables(svs.Table);
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tableunsetall",
                            "All {0}table variables unset", sPersist));
                        break;
                    }
                case OperationEnum.UnsetRegex:
                    {
                        svs.UnsetVariableRegex(svs.Table, _Name);
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tableunsetregex",
                            "All {1}table variables matching ({0}) unset", _Name, sPersist));
                        break;
                    }
                case OperationEnum.Resize:
                    {
                        int w = string.IsNullOrWhiteSpace(_X) ? int.MinValue : (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _X);
                        int h = string.IsNullOrWhiteSpace(_Y) ? int.MinValue : (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _Y);
                        lock (svs.Table) // verified
                        {
                            VariableTable vt = svs.GetTableVariable(sourcename, createNew: true);
                            w = (w == int.MinValue) ? vt.Width : w;
                            h = (h == int.MinValue) ? vt.Height : h;
                            vt.Resize(w, h, vtchanger);
                        }
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tableresize",
                            "{3}Table variable ({0}) resized to ({1},{2})", sourcename, w, h, sPersist));
                        break;
                    }
                case OperationEnum.Unset:
                    {
                        svs.UnsetVariable(svs.Table, sourcename);
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tableunset",
                            "{1}Table variable ({0}) unset", sourcename, sPersist));
                        break;
                    }
                case OperationEnum.Copy:
                    {
                        VariableTable vt = null;
                        lock (svs.Table) // verified
                        {
                            if (svs.Table.ContainsKey(sourcename) == true)
                            {
                                vt = (VariableTable)svs.Table[sourcename].Duplicate();
                                vt.LastChanged = DateTime.Now;
                                vt.LastChanger = vtchanger;
                            }
                        }
                        if (vt != null)
                        {
                            lock (tvs.Table)
                            {
                                tvs.Table[targetname] = vt;
                            }
                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tablecopy",
                                "{2}Table ({0}) copied to {3}table ({1})",
                                sourcename, targetname, sPersist, tPersist));
                        }
                        else
                        {
                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/tablecopynotexist",
                                "{2}Table variable ({0}) couldn't be copied to {3}table ({1}) since it doesn't exist",
                                sourcename, targetname, sPersist, tPersist));
                        }
                        break;
                    }
                case OperationEnum.Append:
                case OperationEnum.AppendH:
                    {
                        VariableTable tableToAppend;
                        lock (svs.Table) // verified
                        {
                            tableToAppend = svs.Table.TryGetValue(sourcename, out VariableTable svt)
                                ? (VariableTable)svt.Duplicate()
                                : new VariableTable();
                        }
                        lock (tvs.Table)
                        {
                            if (!tvs.Table.ContainsKey(targetname))
                            {
                                tvs.Table.Add(targetname, new VariableTable());
                            }
                            VariableTable tvt = tvs.Table[targetname];
                            if (_Operation == OperationEnum.Append)
                            {
                                tvt.AppendVertical(tableToAppend, vtchanger);
                            }
                            else
                            {
                                tvt.AppendHorizontal(tableToAppend, vtchanger);
                            }
                        }
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tableappend",
                            "{2}Table variable ({0}) appended to {3} table ({1})",
                            sourcename, targetname, sPersist, tPersist));
                        break;
                    }
                case OperationEnum.Set:
                    {
                        string[] invalidExprs = new[] { "${_idx}", "${_key}", "${_val}" };
                        CheckInvalidDymanicExpr(_Value, invalidExprs);

                        int x = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _X);
                        int y = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _Y);

                        lock (svs.Table) // verified
                        {
                            VariableTable vt = svs.GetTableVariable(sourcename, true);
                            int mx = Math.Max(x, vt.Width);
                            int my = Math.Max(y, vt.Height);
                            if (mx != vt.Width || my != vt.Height)
                            {
                                vt.Resize(mx, my);
                            }
                            ctx.varName = (_Persistent ? "ptvar:" : "tvar:") + _Name;
                            ctx.tableColIndex = x;          // for ${_row}
                            ctx.tableRowIndex = y;          // for ${_col}
                            expr = ParseExpr();
                            vt.Set(x, y, expr, vtchanger);
                        }
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tableset",
                            "{4}Table variable ({0}) column ({1}) row ({2}) set to ({3})",
                            sourcename, x, y, expr, sPersist));
                        break;
                    }
                case OperationEnum.SetAll:
                    {
                        string[] invalidExprs = new[] { "${_idx}", "${_key}", "${_val}" };
                        CheckInvalidDymanicExpr(_Value, invalidExprs);
                        int newWidth = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _X);
                        int newHeight = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _Y);
                        VariableTable vtNew = new VariableTable { LastChanger = vtchanger, LastChanged = DateTime.Now };
                        lock (svs.Table)
                        {
                            VariableTable vt = svs.GetTableVariable(sourcename, false);
                            newWidth = (newWidth <= 0) ? vt.Width : newWidth;
                            newHeight = (newHeight <= 0) ? vt.Height : newHeight;
                            ctx.varName = (_Persistent ? "ptvar:" : "tvar:") + _Name;
                            for (int y = 1; y <= newHeight; y++)     // x/y index starts from 1
                            {
                                ctx.tableRowIndex = y;          // for ${_row}
                                vtNew.Rows.Add(new VariableTable.VariableTableRow());
                                for (int x = 1; x <= newWidth; x++)
                                {
                                    ctx.tableColIndex = x;      // for ${_col}
                                    expr = ParseExpr();         // evaluate the expression for every grid
                                    vtNew.Rows[y - 1].Values.Add(new VariableScalar() { Value = expr, LastChanger = vtchanger, LastChanged = DateTime.Now });
                                }
                            }
                            svs.Table[sourcename] = vtNew;
                        }
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tablesetall",
                            "All values in {1}table variable ({0}) set to ({2})",
                            sourcename, sPersist, _Value));
                    }
                    break;
                case OperationEnum.SlicesSetAll:
                    {
                        string[] invalidExprs = new[] { "${_idx}", "${_key}", "${_val}" };
                        CheckInvalidDymanicExpr(_Value, invalidExprs);
                        string colSlicesStr = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _X);
                        string rowSlicesStr = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Y);
                        VariableTable vtNew;
                        lock (svs.Table)
                        {
                            VariableTable vt = svs.GetTableVariable(sourcename, false);
                            vtNew = (VariableTable)vt.Duplicate();
                            // index starts from 0
                            List<int> colIndices = Context.GetSliceIndices(colSlicesStr, vt.Width, _X, startIndex: 1);
                            List<int> rowIndices = Context.GetSliceIndices(rowSlicesStr, vt.Height, _Y, startIndex: 1);
                            ctx.varName = (_Persistent ? "ptvar:" : "tvar:") + _Name;
                            foreach (int rowIndex in rowIndices)
                            {
                                ctx.tableRowIndex = rowIndex + 1;       // for ${_row}
                                foreach (int colIndex in colIndices)
                                {
                                    ctx.tableColIndex = colIndex + 1;   // for ${_col}
                                    expr = ParseExpr();                 // evaluate the expression for every grid
                                    vtNew.Rows[rowIndex].Values[colIndex] = new VariableScalar() { Value = expr, LastChanger = vtchanger, LastChanged = DateTime.Now };
                                }
                            }
                            svs.Table[sourcename] = vtNew;
                        }
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tableslicessetall",
                            "All values in column ({3}) row ({4}) of {1}table variable ({0}) set to ({2})",
                            sourcename, sPersist, _Value, colSlicesStr, rowSlicesStr));
                    }
                    break;
                case OperationEnum.Build:
                    {   // Using the first 2 characters in the expression as the separator to split the remaining part into a new table
                        // e.g. expr = ",|1,2,3|4,5,6|7,8,9"
                        VariableTable vt = new VariableTable();
                        expr = ParseExpr();
                        if (expr.Length > 1)
                        {
                            if (expr[1] == '\n' || expr.Substring(1).StartsWith("\r\n"))
                                expr = Context.ReplaceLineBreak(expr);
                            char colSeparator = expr[0];
                            char rowSeparator = expr[1];
                            string splitval = expr.Substring(2);
                            vt = VariableTable.Build(splitval, colSeparator, rowSeparator, vtchanger);
                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tablebuild",
                                "{1}Table variable ({0}) built from expression ({2}) splitted by ({3}) ({4})",
                                targetname, tPersist, splitval, colSeparator, rowSeparator));
                        }
                        else
                        {
                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/tablebuildfail",
                                "{1}Table variable ({0}) cannot be built since expression ({2}) length < 2",
                                targetname, tPersist, expr));
                        }

                        lock (tvs.Table)
                        {
                            tvs.Table[targetname] = vt;
                        }
                    }
                    break;
                case OperationEnum.Filter:
                    {
                        VariableList vlResult = new VariableList();
                        string[] invalidExprs = new[] { "${_idx}", "${_key}", "${_val}" };
                        CheckInvalidDymanicExpr(_Value, invalidExprs);
                        lock (svs.Table)
                        {
                            VariableTable vt = svs.GetTableVariable(sourcename, false);
                            ctx.varName = (_Persistent ? "ptvar:" : "tvar:") + _Name;  // for ${_this}

                            for (int rowIndex = 0; rowIndex < vt.Height; rowIndex++)
                            {
                                ctx.tableRowIndex = rowIndex + 1;       // for ${_row}
                                for (int colIndex = 0; colIndex < vt.Width; colIndex++)
                                {
                                    ctx.tableColIndex = colIndex + 1;   // for ${_col}
                                    double result = ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _Value);
                                    if (!MathParser.IsZero(result))
                                    {
                                        vlResult.Values.Add(vt.Rows[rowIndex].Values[colIndex].Duplicate());
                                    }
                                }
                            }
                        }
                        vlResult.LastChanger = vtchanger;
                        vlResult.LastChanged = DateTime.Now;
                        lock (tvs.List)
                        {
                            tvs.List[targetname] = vlResult;
                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tablefilter",
                                "Filtered {4} elements from {1}table ({0}) into {3}list ({2})",
                                sourcename, sPersist, targetname, tPersist, vlResult.Size));
                        }
                    }
                    break;
                case OperationEnum.FilterLine:
                    {
                        bool isCol = !string.IsNullOrWhiteSpace(_X);
                        string rawExpr = isCol ? _X : _Y;
                        string[] invalidExprs = isCol
                            ? new[] { "${_this}", "${_row", "${_idx}", "${_key}", "${_val}" }
                            : new[] { "${_this}", "${_col", "${_idx}", "${_key}", "${_val}" };
                        CheckInvalidDymanicExpr(rawExpr, invalidExprs);
                        VariableTable vtResult = new VariableTable();
                        lock (svs.Table)
                        {
                            VariableTable vt = svs.GetTableVariable(sourcename, false);
                            ctx.varName = (_Persistent ? "ptvar:" : "tvar:") + _Name;  // for ${_this}
                            if (isCol)
                            {
                                for (int rowIndex = 0; rowIndex < vt.Height; rowIndex++)
                                {
                                    vtResult.Rows.Add(new VariableTable.VariableTableRow());
                                }
                                for (int colIndex = 0; colIndex < vt.Width; colIndex++)
                                {
                                    ctx.tableColIndex = colIndex + 1;          // for ${_col}
                                    double result = ctx.EvaluateNumericExpression(ActionContextLogger, ctx, rawExpr);
                                    if (!MathParser.IsZero(result))
                                    {
                                        for (int rowIndex = 0; rowIndex < vt.Height; rowIndex++)
                                        {
                                            vtResult.Rows[rowIndex].Values.Add(vt.Rows[rowIndex].Values[colIndex].Duplicate());
                                        }
                                    }
                                }
                                if (vtResult.Width == 0) { vtResult.Rows.Clear(); }
                            }
                            else // is row
                            {
                                for (int rowIndex = 0; rowIndex < vt.Height; rowIndex++)
                                {
                                    ctx.tableRowIndex = rowIndex + 1;      // for ${_row}
                                    double result = ctx.EvaluateNumericExpression(ActionContextLogger, ctx, rawExpr);
                                    if (!MathParser.IsZero(result))
                                    {
                                        var newRow = new VariableTable.VariableTableRow();
                                        for (int colIndex = 0; colIndex < vt.Width; colIndex++)
                                        {
                                            newRow.Values.Add(vt.Rows[rowIndex].Values[colIndex].Duplicate());
                                        }
                                        vtResult.Rows.Add(newRow);
                                    }
                                }
                            }
                        }
                        vtResult.LastChanger = vtchanger;
                        vtResult.LastChanged = DateTime.Now;
                        lock (tvs.Table)
                        {
                            tvs.Table[targetname] = vtResult;
                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tablefilterline",
                                "Filtered {4} {5}s from {1}table ({0}) into {3}table ({2})",
                                sourcename, sPersist, targetname, tPersist,
                                (isCol ? vtResult.Width : vtResult.Height), I18n.TrlTableColOrRow(isCol)));
                        }
                    }
                    break;
                case OperationEnum.SetLine:
                case OperationEnum.InsertLine:
                    {
                        expr = ParseExpr();
                        string separator = (expr.Length > 0) ? expr.Substring(0, 1) : "";
                        string splitval = (expr.Length > 0) ? expr.Substring(1) : "";
                        string[] newValues = (separator.Length > 0) ? splitval.Split(separator[0]) : new string[0];
                        bool isRow = string.IsNullOrWhiteSpace(_X);
                        string lineType = I18n.TrlTableColOrRow(!isRow);
                        int rawIndex = (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, (isRow) ? _Y : _X);

                        lock (svs.Table) // verified
                        {
                            VariableTable vt = svs.GetTableVariable(sourcename, true);
                            int tableLength = (isRow) ? vt.Height : vt.Width;

                            // index start from 0
                            int index = (rawIndex < 0) ? (rawIndex + tableLength) : (rawIndex - 1);
                            if (index < 0)
                                break;

                            if (_Operation == OperationEnum.SetLine)
                            {
                                if (isRow)
                                    vt.SetRow(index, newValues, vtchanger);
                                else
                                    vt.SetColumn(index, newValues, vtchanger);

                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tablesetline",
                                    "{1}Table ({0}) {3} #({2}) set to ({4})",
                                    sourcename, sPersist, index, lineType, splitval));
                            }
                            else // InsertLine
                            {
                                if (isRow)
                                    vt.InsertRow(index, newValues, vtchanger);
                                else
                                    vt.InsertColumn(index, newValues, vtchanger);

                                AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tableinsertline",
                                    "Inserted ({4}) to {1}Table ({0}) {3} #({2})",
                                    sourcename, sPersist, index, lineType, splitval));
                            }
                        }
                    }
                    break;
                case OperationEnum.RemoveLine:
                    {
                        bool isRow = string.IsNullOrWhiteSpace(_X);
                        string lineType = I18n.TrlTableColOrRow(!isRow);

                        lock (svs.Table) // verified
                        {
                            VariableTable vt = svs.GetTableVariable(sourcename, true);
                            int tableLength = (isRow) ? vt.Height : vt.Width;
                            int rawIndex = (isRow) ? (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _Y)
                                                   : (int)ctx.EvaluateNumericExpression(ActionContextLogger, ctx, _X);
                            // index start from 0
                            int index = (rawIndex < 0) ? (rawIndex + tableLength) : (rawIndex - 1);

                            if (isRow) { vt.RemoveRow(index, vtchanger); }
                            else { vt.RemoveColumn(index, vtchanger); }

                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tableremoveline",
                                "Removed {3} #({2}) from {1}table ({0})",
                                sourcename, sPersist, index, lineType));
                        }
                    }
                    break;
                case OperationEnum.SortLine:
                    {
                        bool isCol = !string.IsNullOrWhiteSpace(_X);
                        string lineType = I18n.TrlTableColOrRow(isCol);
                        string rawExpr = isCol ? _X : _Y;
                        string[] invalidExprs = isCol
                            ? new[] { "${_this}", "${_row", "${_idx}", "${_key}", "${_val}" }
                            : new[] { "${_this}", "${_col", "${_idx}", "${_key}", "${_val}" };
                        CheckInvalidDymanicExpr(rawExpr, invalidExprs);

                        // parsing expressions like "n+:key1, s-:key2, s+:key3, ..."
                        ParseSortKeyFunctions(rawExpr, out List<bool> isNumeric, out List<bool> isAscending,
                            out List<string> keysExpr, out List<List<string>> values);
                        int keysCount = keysExpr.Count;

                        lock (svs.Table)
                        {
                            VariableTable vt = svs.GetTableVariable(sourcename, false);
                            ctx.varName = (_Persistent ? "ptvar:" : "tvar:") + _Name; // for ${_row[i]}
                            if (isCol)
                            {
                                // Iterate through the columns and evaluate the key expression in the current context
                                for (int colIndex = 0; colIndex < vt.Width; colIndex++)
                                {
                                    ctx.tableColIndex = colIndex + 1;  // for ${_col}
                                    for (int keyIndex = 0; keyIndex < keysCount; keyIndex++)
                                    {
                                        string keyValue = isNumeric[keyIndex]
                                            ? I18n.ThingToString(ctx.EvaluateNumericExpression(ActionContextLogger, ctx, keysExpr[keyIndex]))
                                            : ctx.EvaluateStringExpression(ActionContextLogger, ctx, keysExpr[keyIndex]);
                                        values[keyIndex].Add(keyValue);
                                    }
                                }

                                IOrderedEnumerable<int> sortedIndices = ApplySorting(vt.Width, isNumeric, isAscending, values);
                                foreach (var row in vt.Rows)
                                {
                                    var sortedValue = sortedIndices.Select(i => row.Values[i]).ToList();
                                    row.Values = sortedValue;
                                }
                            }
                            else // is row
                            {
                                // Iterate through the rows and evaluate the key expression in the current context
                                for (int rowIndex = 0; rowIndex < vt.Height; rowIndex++)
                                {
                                    ctx.tableRowIndex = rowIndex + 1;  // for ${_row}
                                    for (int keyIndex = 0; keyIndex < keysCount; keyIndex++)
                                    {
                                        string keyValue = isNumeric[keyIndex]
                                            ? I18n.ThingToString(ctx.EvaluateNumericExpression(ActionContextLogger, ctx, keysExpr[keyIndex]))
                                            : ctx.EvaluateStringExpression(ActionContextLogger, ctx, keysExpr[keyIndex]);
                                        values[keyIndex].Add(keyValue);
                                    }
                                }

                                IOrderedEnumerable<int> sortedIndices = ApplySorting(vt.Height, isNumeric, isAscending, values);
                                var sortedRows = sortedIndices.Select(i => vt.Rows[i]).ToList();
                                vt.Rows = sortedRows;
                            }

                            vt.LastChanger = vtchanger;
                            vt.LastChanged = DateTime.Now;
                        }

                        for (int i = 0; i < keysCount; i++)
                        {   // logging each sorting keys
                            AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tablesortline",
                                "Sorting {2}s of {1}table ({0}): function ({3}/{4}, {6}) = ({5}). Keys: ({7})",
                                sourcename, sPersist, lineType, i + 1, keysCount, keysExpr[i],
                                (isNumeric[i] ? "n" : "s") + (isAscending[i] ? "+" : "-"),
                                String.Join(", ", values[i])));
                        }
                    }
                    break;
                case OperationEnum.GetAllEntities:
                    {
                        var entities = string.IsNullOrWhiteSpace(_Y)
                            ? FFXIV.Entity.GetEntities()
                            : FFXIV.Entity.GetFilteredEntities(ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Y));

                        var propNames = string.IsNullOrWhiteSpace(_X)
                            ? FFXIV.Entity.RecommendedEntityPropNames.Select(x => x.ToLower()).Concat(FFXIV.Job.LegalJobPropNames).OrderBy(s => s)
                            : (IEnumerable<string>)Context.SplitArguments(ctx.EvaluateStringExpression(ActionContextLogger, ctx, _X), false);
                        if (string.IsNullOrWhiteSpace(_X))
                        {
                            var specialKeys = new List<string> { "id", "name", "x", "y", "z", "h", "bnpcid" };
                            propNames = specialKeys.Concat(propNames.Except(specialKeys));
                        }

                        VariableTable vt = new VariableTable { LastChanger = vtchanger, LastChanged = DateTime.Now };
                        var headerRow = new VariableTable.VariableTableRow
                        {
                            Values = propNames.Select(prop => (Variable)new VariableScalar(prop)).ToList()
                        };
                        vt.Rows.Add(headerRow);

                        foreach (var entity in entities)
                        {
                            if (entity.ID == 0) continue;
                            var row = new VariableTable.VariableTableRow
                            {
                                Values = propNames.Select(prop => (Variable)new VariableScalar(entity.QueryProperty(prop))).ToList()
                            };
                            vt.Rows.Add(row);
                        }
                        lock (svs.Table)
                        {
                            svs.Table[sourcename] = vt;
                        }
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/tablegetallentities",
                            "Saved {2} entities into {1}table variable ({0})",
                            sourcename, sPersist, vt.Rows.Count - 1));
                    }
                    break;
            }
        }

        #endregion

    }

}
