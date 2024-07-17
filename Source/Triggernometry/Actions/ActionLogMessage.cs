using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Message logging
    /// </summary>
    [XmlRoot(ElementName = "LogMessage")]
    internal class ActionLogMessage : ActionBase
    {

        #region Properties

        /// <summary>
        /// Log levels
        /// </summary>
        public enum LogLevelEnum
        {
            Error,
            Warning,
            Custom,
            Custom2,
            Info,
            Verbose,
        }

        /// <summary>
        /// Target stream for the log event to be inserted into
        /// </summary>
        [ActionAttribute(ordernum: 1)]
        private LogEvent.SourceEnum _Target { get; set; } = LogEvent.SourceEnum.Log;
        [XmlAttribute]
        public string Target
        {
            get
            {
                if (_Target != LogEvent.SourceEnum.Log)
                {
                    return _Target.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _Target = (LogEvent.SourceEnum)Enum.Parse(typeof(LogEvent.SourceEnum), value);
            }
        }

        [ActionAttribute(ordernum: 2)]
        private string _Message { get; set; } = "";
        [XmlAttribute]
        public string Message
        {
            get
            {
                if (_Message == "")
                {
                    return null;
                }
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        /// <summary>
        /// If set, the logged message will be processed as if it came to Triggernometry from the specified target
        /// </summary>
        [ActionAttribute(ordernum: 3)]
        private bool _ProcessAsLogline { get; set; } = false;
        [XmlAttribute]
        public string ProcessAsLogline
        {
            get
            {
                if (_ProcessAsLogline == false)
                {
                    return null;
                }
                return _ProcessAsLogline.ToString();
            }
            set
            {
                _ProcessAsLogline = Boolean.Parse(value);
            }
        }

        /// <summary>
        /// If set, the logged message will be inserted into ACT's encounter log
        /// </summary>
        [ActionAttribute(ordernum: 4)]
        private bool _AddToACTEncounter { get; set; } = false;
        [XmlAttribute]
        public string AddToACTEncounter
        {
            get
            {
                if (_AddToACTEncounter == false)
                {
                    return null;
                }
                return _AddToACTEncounter.ToString();
            }
            set
            {
                _AddToACTEncounter = Boolean.Parse(value);
            }
        }

        /// <summary>
        /// Level for the logged message
        /// </summary>
        [ActionAttribute(ordernum: 5)]
        private LogLevelEnum _Level { get; set; } = LogLevelEnum.Error;
        [XmlAttribute]
        public string Level
        {
            get
            {
                if (_Level != LogLevelEnum.Error)
                {
                    return _Level.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _Level = (LogLevelEnum)Enum.Parse(typeof(LogLevelEnum), value);
                if ((int)_Level == -1)
                {
                    _Level = LogLevelEnum.Error;
                }
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            if (_ProcessAsLogline == true)
            {
                string srcType = "";
                switch (_Target)
                {
                    case LogEvent.SourceEnum.ACT: srcType = "ACT event"; break;
                    case LogEvent.SourceEnum.NetworkFFXIV: srcType = "FFXIV network event"; break;
                    case LogEvent.SourceEnum.Log: srcType = "Normal log line"; break;
                }
                srcType = I18n.Translate($"ActionForm/cbxLogMessageTarget[{srcType}]", srcType);
                return I18n.Translate(
                    "internal/Action/descprocessmessage",
                    "process message ({0}) as {1}", _Message, srcType
                );
            }
            string level = "";
            switch (_Level)
            {
                case LogLevelEnum.Error: level = "Error"; break;
                case LogLevelEnum.Info: level = "Info"; break;
                case LogLevelEnum.Verbose: level = "Verbose"; break;
                case LogLevelEnum.Warning: level = "Warning"; break;
                case LogLevelEnum.Custom: level = "Custom"; break;
                case LogLevelEnum.Custom2: level = "Custom 2"; break;
            }
            level = I18n.Translate($"ActionForm/cbxLogMessageLevel[{level}]", level);
            return I18n.Translate(
                "internal/Action/desclogmessage",
                "log message ({0}) with {1} level", _Message, level
            );
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            string message = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Message);

            if (_ProcessAsLogline)
            {
                string zone = ctx.EvaluateStringExpression(ActionContextLogger, ctx, ctx.plug.currentZone);
                ctx.plug.LogLineQueuer(message, zone, _Target);
            }
            else
            {
                RealPlugin.DebugLevelEnum debugLevel = RealPlugin.DebugLevelEnum.Error;
                switch (_Level)
                {
                    case LogLevelEnum.Custom: debugLevel = RealPlugin.DebugLevelEnum.Custom; break;
                    case LogLevelEnum.Custom2: debugLevel = RealPlugin.DebugLevelEnum.Custom2; break;
                    case LogLevelEnum.Error: debugLevel = RealPlugin.DebugLevelEnum.Error; break;
                    case LogLevelEnum.Info: debugLevel = RealPlugin.DebugLevelEnum.Info; break;
                    case LogLevelEnum.Verbose: debugLevel = RealPlugin.DebugLevelEnum.Verbose; break;
                    case LogLevelEnum.Warning: debugLevel = RealPlugin.DebugLevelEnum.Warning; break;
                }
                AddToLog(ctx, debugLevel, message);
            }
            if (_AddToACTEncounter)
            {
                ctx.plug.ACTEncounterLogHook(message);
            }
        }

        #endregion

    }

}
