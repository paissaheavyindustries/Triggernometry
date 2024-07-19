using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Text-to-speech
    /// </summary>
    [ActionCategory(ActionCategory.CategoryTypeEnum.Audio)]
    [XmlRoot(ElementName = "PlaySpeech")]
    public class ActionPlaySpeech : ActionBase
    {

        #region Properties

        /// <summary>
        /// Audio target where speech will be directed (None means default)
        /// </summary>
        [ActionAttribute(ordernum: 1)]
        private Configuration.AudioRoutingMethodEnum _AudioTarget { get; set; } = Configuration.AudioRoutingMethodEnum.None;
        [XmlAttribute]
        public string AudioTarget
        {
            get
            {
                if (_AudioTarget != Configuration.AudioRoutingMethodEnum.None)
                {
                    return _AudioTarget.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _AudioTarget = (Configuration.AudioRoutingMethodEnum)Enum.Parse(typeof(Configuration.AudioRoutingMethodEnum), value);
            }
        }

        /// <summary>
        /// Message expression
        /// </summary>
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
        /// Volume expression (0 - 100)
        /// </summary>
        [ActionAttribute(ordernum: 3, typeof(float))]
        private string _Volume { get; set; } = "100";
        [XmlAttribute]
        public string Volume
        {
            get
            {
                if (_Volume == "100")
                {
                    return null;
                }
                return _Volume;
            }
            set
            {
                _Volume = value;
            }
        }

        /// <summary>
        /// Rate (speech speed) expression
        /// </summary>
        [ActionAttribute(ordernum: 4, typeof(int))]
        private string _Rate { get; set; } = "0";
        [XmlAttribute]
        public string Rate
        {
            get
            {
                if (_Rate == "0")
                {
                    return null;
                }
                return _Rate;
            }
            set
            {
                _Rate = value;
            }
        }

        // todo remove?
        [ActionAttribute(ordernum: 5)]
        private bool _ExclusivePlayer { get; set; } = true;
        [XmlAttribute]
        public string ExclusivePlayer
        {
            get
            {
                if (_ExclusivePlayer == true)
                {
                    return null;
                }
                return _ExclusivePlayer.ToString();
            }
            set
            {
                _ExclusivePlayer = Boolean.Parse(value);
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            return I18n.Translate("internal/Action/desctts", "say ({0}) at volume ({1}) %, using speed ({2})", _Message, _Volume, _Rate);
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            ctx.ttshook(ctx, null); // todo
        }

        #endregion

    }

}
