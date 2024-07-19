using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Serialization;
using Triggernometry.Variables;

namespace Triggernometry.Actions
{

    /// <summary>
    /// File system operations
    /// </summary>
    [ActionCategory(ActionCategory.CategoryTypeEnum.File)]
    [XmlRoot(ElementName = "DiskOperation")]
    internal class ActionDiskOperation : ActionBase
    {

        #region Properties

        /// <summary>
        /// File system operations
        /// </summary>
        private enum OperationEnum
        {
            /// <summary>
            /// Read the contents of a file into a scalar variable
            /// </summary>
            ReadIntoVariable,
            /// <summary>
            /// Read the contents of a file into a list variable, where every line is its own index
            /// </summary>
            ReadIntoListVariable,
            /// <summary>
            /// Read the contents of a CSV file into a table variable
            /// </summary>
            ReadCSVIntoTableVariable
        }

        /// <summary>
        /// Type of the file system operation
        /// </summary>
        [ActionAttribute(ordernum: 1)]
        private OperationEnum _Operation { get; set; } = OperationEnum.ReadIntoVariable;
        [XmlAttribute]
        public string Operation
        {
            get
            {
                if (_Operation != OperationEnum.ReadIntoVariable)
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
        /// File name
        /// </summary>
        [ActionAttribute(ordernum: 2, specialtype: ActionAttribute.SpecialTypeEnum.FileSelector)]
        private string _Filename { get; set; } = "";
        [XmlAttribute]
        public string Filename
        {
            get
            {
                if (_Filename == "")
                {
                    return null;
                }
                return _Filename;
            }
            set
            {
                _Filename = value;
            }
        }

        /// <summary>
        /// Target variable name
        /// </summary>
        [ActionAttribute(ordernum: 3)]
        private string _Variable { get; set; } = "";
        [XmlAttribute]
        public string Variable
        {
            get
            {
                if (_Variable == "")
                {
                    return null;
                }
                return _Variable;
            }
            set
            {
                _Variable = value;
            }
        }

        /// <summary>
        /// If set, instructs Triggernometry to look at its own cache first for the file, reading that instead if found (applies to remote files)
        /// </summary>
        [ActionAttribute(ordernum: 4)]
        private bool _UseCache { get; set; } = false;
        [XmlAttribute]
        public string UseCache
        {
            get
            {
                if (_UseCache == false)
                {
                    return null;
                }
                return _UseCache.ToString();
            }
            set
            {
                _UseCache = Boolean.Parse(value);
            }
        }

        /// <summary>
        /// Indicates whether referenced variable is persistent or not
        /// </summary>
        [ActionAttribute(ordernum: 5)] // todo need to couple this with variable on editor
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
            string persist = I18n.TrlVarPersist(_Persistent);
            string cache = I18n.TrlCacheFile(_UseCache);
            switch (_Operation)
            {
                case OperationEnum.ReadIntoListVariable:
                    return I18n.Translate(
                        "internal/Action/descfilereadlistvar",
                        "read file ({0}) lines into {2}list variable ({1}){3}",
                        _Filename, _Variable, persist, cache
                    );
                case OperationEnum.ReadIntoVariable:
                    return I18n.Translate(
                        "internal/Action/descfilereadvar",
                        "read file ({0}) lines into {2}scalar variable ({1}){3}",
                        _Filename, _Variable, persist, cache
                    );
                case OperationEnum.ReadCSVIntoTableVariable:
                    return I18n.Translate(
                        "internal/Action/descfilereadcsvtable",
                        "read csv file ({0}) into {2}table variable ({1}){3}",
                        _Filename, _Variable, persist, cache
                    );
            }
            return "";
        }        

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            string filename = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Filename);
            string varname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Variable);
            string persist = I18n.TrlVarPersist(_Persistent);
            string cache = I18n.TrlCacheFile(_UseCache);
            VariableStore vs = (_Persistent == false) ? ctx.plug.sessionvars : ctx.plug.cfg.PersistentVariables;
            if (_Operation == OperationEnum.ReadCSVIntoTableVariable || _Operation == OperationEnum.ReadIntoListVariable || _Operation == OperationEnum.ReadIntoVariable)
            {
                Uri u = new Uri(filename);
                if (u.IsFile == false)
                {
                    string fn = Path.Combine(ctx.plug.path, "TriggernometryFileCache");
                    if (Directory.Exists(fn) == false)
                    {
                        Directory.CreateDirectory(fn);
                    }
                    string ext = Path.GetExtension(u.LocalPath);
                    fn = Path.Combine(fn, ctx.plug.GenerateHash(u.AbsoluteUri) + Path.GetExtension(u.LocalPath));
                    bool fromcache = false;
                    if (File.Exists(fn) == true && _UseCache == true)
                    {
                        FileInfo fi = new FileInfo(fn);
                        DateTime dt = DateTime.Now.AddMinutes(0 - ctx.plug.cfg.CacheFileExpiry);
                        if (fi.LastWriteTime > dt)
                        {
                            filename = fn;
                            fromcache = true;
                        }
                    }
                    if (fromcache == false)
                    {
                        using (WebClient wc = new WebClient())
                        {
                            wc.Headers["User-Agent"] = "Triggernometry File Retriever";
                            byte[] data = wc.DownloadData(u.AbsoluteUri);
                            File.WriteAllBytes(fn, data);
                            filename = fn;
                        }
                    }
                }
            }
            switch (_Operation)
            {
                case OperationEnum.ReadCSVIntoTableVariable:
                    {
                        List<string[]> data = new List<string[]>();
                        int datawidth = 0;
                        using (StreamReader sr = new StreamReader(filename))
                        {
                            using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
                            {
                                while (csv.Parser.Read() == true)
                                {
                                    string[] x = csv.Parser.Record;
                                    if (x.Length > datawidth)
                                    {
                                        datawidth = x.Length;
                                    }
                                    data.Add(x);
                                }
                            }
                        }
                        VariableTable vt = vs.GetTableVariable(varname, true);
                        if (data.Count > 0 && datawidth > 0)
                        {
                            string vtchanger;
                            if (ctx.trig != null)
                            {
                                vtchanger = I18n.Translate("internal/Action/changetagtrigaction", "Trigger '{0}' action '{1}'", ctx.trig.LogName, Describe(ctx));
                            }
                            else
                            {
                                vtchanger = I18n.Translate("internal/Action/changetagtestmode", "Action '{0}' test mode", Describe(ctx));
                            }
                            vt.Resize(datawidth, data.Count);
                            int y = 1;
                            foreach (string[] row in data)
                            {
                                for (int x = 0; x < row.Length; x++)
                                {
                                    vt.Set(x + 1, y, row[x], vtchanger);
                                }
                                y++;
                            }
                        }
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/filetableset",
                            "{2}Table variable ({0}) value read from CSV file ({1})", varname, filename, persist));
                    }
                    break;
                case OperationEnum.ReadIntoListVariable:
                    {
                        string[] data = File.ReadAllLines(filename);
                        lock (vs.List) // verified
                        {
                            if (vs.List.ContainsKey(varname) == false)
                            {
                                vs.List[varname] = new VariableList();
                            }
                            VariableList x = vs.List[varname];
                            foreach (string dat in data)
                            {
                                x.Push(new VariableScalar() { Value = dat }, "");
                            }
                            if (ctx.trig != null)
                            {
                                x.LastChanger = I18n.Translate("internal/Action/changetagtrigaction", "Trigger '{0}' action '{1}'", ctx.trig.LogName, Describe(ctx));
                            }
                            else
                            {
                                x.LastChanger = I18n.Translate("internal/Action/changetagtestmode", "Action '{0}' test mode", Describe(ctx));
                            }
                            x.LastChanged = DateTime.Now;
                        }
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/filelistset",
                            "{2}List variable ({0}) value read from file ({1})", varname, filename, persist));
                    }
                    break;
                case OperationEnum.ReadIntoVariable:
                    {
                        string data = File.ReadAllText(filename);
                        lock (vs.Scalar) // verified
                        {
                            if (vs.Scalar.ContainsKey(varname) == false)
                            {
                                vs.Scalar[varname] = new VariableScalar();
                            }
                            VariableScalar x = vs.Scalar[varname];
                            x.Value = data;
                            if (ctx.trig != null)
                            {
                                x.LastChanger = I18n.Translate("internal/Action/changetagtrigaction", "Trigger '{0}' action '{1}'", ctx.trig.LogName, Describe(ctx));
                            }
                            else
                            {
                                x.LastChanger = I18n.Translate("internal/Action/changetagtestmode", "Action '{0}' test mode", Describe(ctx));
                            }
                            x.LastChanged = DateTime.Now;
                        }
                        AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/filescalarset",
                            "{2}Scalar variable ({0}) value read from file ({1})",
                            varname, filename, persist));
                    }
                    break;
            }
        }

        #endregion

    }

}
