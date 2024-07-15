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
        private string _Filename = "";
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
        private string _Volume = "100";
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

        internal override Control GetPropertyEditor()
        {
            // todo
            return null;
        }

        #endregion

    }

}
