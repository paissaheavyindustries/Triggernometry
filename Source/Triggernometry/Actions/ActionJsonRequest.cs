using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Serialization;
using Triggernometry.Variables;

namespace Triggernometry.Actions
{

    /// <summary>
    /// JSON remote request
    /// </summary>
    [XmlRoot(ElementName = "JsonRequest")]
    internal class ActionJsonRequest : ActionBase
    {

        #region Properties

        /// <summary>
        /// Request method
        /// </summary>
        private enum MethodEnum
        {
            POST,
            GET
        }

        /// <summary>
        /// Request method to use
        /// </summary>
        private MethodEnum _Method { get; set; } = MethodEnum.POST;
        [XmlAttribute]
        public string Method
        {
            get
            {
                if (_Method == MethodEnum.POST)
                {
                    return null;
                }
                return _Method.ToString();
            }
            set
            {
                _Method = (MethodEnum)Enum.Parse(typeof(MethodEnum), value);
            }
        }

        /// <summary>
        /// If set, Triggernometry will check its cache for a similar request and return that
        /// </summary>
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
        /// Scalar variable in which the result of the request will be stored
        /// </summary>
        private string _ResultVariable = "";
        [XmlAttribute]
        public string ResultVariable
        {
            get
            {
                if (_ResultVariable == "")
                {
                    return null;
                }
                return _ResultVariable;
            }
            set
            {
                _ResultVariable = value;
            }
        }

        /// <summary>
        /// Remote endpoint expression
        /// </summary>
        private string _Endpoint = "";
        [XmlAttribute]
        public string Endpoint
        {
            get
            {
                if (_Endpoint == "")
                {
                    return null;
                }
                return _Endpoint;
            }
            set
            {
                _Endpoint = value;
            }
        }

        /// <summary>
        /// Payload expression
        /// </summary>
        private string _Payload = "";
        [XmlAttribute]
        public string Payload
        {
            get
            {
                if (_Payload == "")
                {
                    return null;
                }
                return _Payload;
            }
            set
            {
                _Payload = value;
            }
        }

        /// <summary>
        /// Header expression
        /// </summary>
        private string _Headers = "";
        [XmlAttribute]
        public string Headers
        {
            get
            {
                if (_Headers == "")
                {
                    return null;
                }
                return _Headers;
            }
            set
            {
                _Headers = value;
            }
        }

        /// <summary>
        /// Expression to be used when the result of the request is intended to be fired as a log event
        /// </summary>
        private string _FiringExpression = "";
        [XmlAttribute]
        public string FiringExpression
        {
            get
            {
                if (_FiringExpression == "")
                {
                    return null;
                }
                return _FiringExpression;
            }
            set
            {
                _FiringExpression = value;
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
            string cache = I18n.TrlCacheFile(_UseCache);
            if (_FiringExpression != null && _FiringExpression.Trim().Length > 0)
            {
                return I18n.Translate(
                    "internal/Action/descjsonsendrelay",
                    "send JSON payload to endpoint ({0}){1}, and relaying response for further processing",
                    _Endpoint, cache
                );
            }
            else
            {
                return I18n.Translate(
                    "internal/Action/descjsonsend",
                    "send JSON payload to endpoint ({0}){1} and cache the response",
                    _Endpoint, cache
                );
            }
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            string response = "";
            int responseCode = 0;
            string endpoint = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Endpoint);
            string payload = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Payload);
            string headers = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Headers).Trim();
            string varname = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _ResultVariable);
            string persist = I18n.TrlVarPersist(_Persistent);
            List<string> headerslist = new List<string>();
            if (headers.Length > 0)
            {
                headerslist.AddRange(headers.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
            }
            if (_UseCache == true)
            {
                string endpointh = ctx.plug.GenerateHash(endpoint);
                string payloadh = ctx.plug.GenerateHash(payload);
                string headersh = ctx.plug.GenerateHash(headers);
                string fh = ctx.plug.GenerateHash(endpointh + payloadh + headers);
                string fn = Path.Combine(ctx.plug.path, "TriggernometryJsonCache");
                if (Directory.Exists(fn) == false)
                {
                    Directory.CreateDirectory(fn);
                }
                fn = Path.Combine(fn, fh + ".json");
                bool fromcache = false;
                if (File.Exists(fn) == true)
                {
                    FileInfo fi = new FileInfo(fn);
                    DateTime dt = DateTime.Now.AddMinutes(0 - ctx.plug.cfg.CacheJsonExpiry);
                    if (fi.LastWriteTime > dt)
                    {
                        responseCode = (int)HttpStatusCode.OK;
                        response = File.ReadAllText(fn);
                        fromcache = true;
                    }
                }
                if (fromcache == false)
                {
                    Tuple<int, string> resp = SendJson(ctx, _Method, endpoint, payload, headerslist, false);
                    responseCode = resp.Item1;
                    response = resp.Item2;
                    File.WriteAllText(fn, response);
                }
            }
            else
            {
                Tuple<int, string> resp = SendJson(ctx, _Method, endpoint, payload, headerslist, false);
                responseCode = resp.Item1;
                response = resp.Item2;
            }
            if (varname != "")
            {
                VariableStore vs = (_Persistent == false) ? ctx.plug.sessionvars : ctx.plug.cfg.PersistentVariables;
                lock (vs.Scalar) // verified
                {
                    if (vs.Scalar.ContainsKey(varname) == false)
                    {
                        vs.Scalar[varname] = new VariableScalar();
                    }
                    VariableScalar x = vs.Scalar[varname];
                    x.Value = response;
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
                AddToLog(ctx, RealPlugin.DebugLevelEnum.Verbose, I18n.Translate("internal/Action/scalarsetjson",
                    "{1}Scalar variable ({0}) value set to JSON response", varname, persist));
            }
            ctx.contextResponse = response;
            ctx.contextResponseCode = responseCode;
            if (_FiringExpression != null && _FiringExpression.Trim().Length > 0)
            {
                string firing = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _FiringExpression);
                if (firing.Length > 0)
                {
                    ctx.plug.LogLineQueuer(firing, "", LogEvent.SourceEnum.Log);
                }
            }
        }

        internal override Control GetPropertyEditor()
        {
            return null; // todo
        }

        #endregion

    }

}
