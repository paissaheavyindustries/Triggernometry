using System;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Discord webhook operation
    /// </summary>
    [XmlRoot(ElementName = "DiscordWebhook")]
    internal class ActionDiscordWebhook : ActionBase
    {

        #region Properties

        private enum MethodEnum
        {
            POST,
            GET
        }

        /// <summary>
        /// Discord webhook URL
        /// </summary>
        private string _WebhookURL = "";
        [XmlAttribute]
        public string WebhookURL
        {
            get
            {
                if (_WebhookURL == "")
                {
                    return null;
                }
                return _WebhookURL;
            }
            set
            {
                _WebhookURL = value;
            }
        }

        /// <summary>
        /// Message to send to the webhook
        /// </summary>
        private string _Message = "";
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
        /// If set, sent telegram will be flagged as a TTS message
        /// </summary>
        private bool _UseTTS { get; set; } = false;
        [XmlAttribute]
        public string UseTTS
        {
            get
            {
                if (_UseTTS == false)
                {
                    return null;
                }
                return _UseTTS.ToString();
            }
            set
            {
                _UseTTS = Boolean.Parse(value);
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            if (_UseTTS == true)
            {
                return I18n.Translate("internal/Action/descdiscordttsmsg", "send TTS message ({0}) to Discord webhook ({1})", _Message, _WebhookURL);
            }
            return I18n.Translate("internal/Action/descdiscordmsg", "send message ({0}) to Discord webhook ({1})", _Message, _WebhookURL);
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            string msg = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _Message);
            string url = ctx.EvaluateStringExpression(ActionContextLogger, ctx, _WebhookURL);
            if (_UseTTS == true)
            {
                if (msg.Length > 1970)
                {
                    msg = msg.Substring(0, 1970);
                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/warndiscordtrunc", "Discord message too long, capping to {0}", msg.Length));
                }
                var wh = new JavaScriptSerializer().Serialize(new { content = msg, tts = true });
                SendJson(ctx, MethodEnum.POST, url, wh, null, true);
            }
            else
            {
                if (msg.Length > 1980)
                {
                    msg = msg.Substring(0, 1980);
                    AddToLog(ctx, RealPlugin.DebugLevelEnum.Warning, I18n.Translate("internal/Action/warndiscordtrunc", "Discord message too long, capping to {0}", msg.Length));
                }
                var wh = new JavaScriptSerializer().Serialize(new { content = msg });
                SendJson(ctx, MethodEnum.POST, url, wh, null, true);
            }
        }

        internal override Control GetPropertyEditor()
        {
            return null; // todo
        }

        #endregion

    }

}
