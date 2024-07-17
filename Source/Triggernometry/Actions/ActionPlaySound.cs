using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Sound playback
    /// </summary>
    [XmlRoot(ElementName = "PlaySound")]
    public class ActionPlaySound : ActionBase
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
        /// Sound file name expression
        /// </summary>
        [ActionAttribute(ordernum: 2, specialtype: ActionAttribute.SpecialTypeEnum.AudioSelector)]
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

        // todo remove?
        [ActionAttribute(ordernum: 4)]
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
            return I18n.Translate("internal/Action/descplaysound", "play sound file ({0}) at volume ({1}) %", _Filename, _Volume);
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            ctx.soundhook(ctx, null); // todo
        }

        #endregion

    }

}
