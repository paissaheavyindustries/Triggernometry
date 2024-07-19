using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Image overlay operations
    /// </summary>
    [ActionCategory(ActionCategory.CategoryTypeEnum.Overlay)]
    [XmlRoot(ElementName = "OverlayImage")]
    internal class ActionOverlayImage : ActionBase
    {

        #region Properties

        // todo probably needs a custom property editor

        /// <summary>
        /// Image overlay operations
        /// </summary>
        private enum OperationEnum
        {
            /// <summary>
            /// Activate image overlay
            /// </summary>
            Activate,
            /// <summary>
            /// Deactive image overlay with matching name
            /// </summary>
            Deactivate,
            /// <summary>
            /// Deactive all image overlays
            /// </summary>
            DeactivateAll,
            /// <summary>
            /// Deactive all image overlays with name matching given regex
            /// </summary>
            DeactivateRegex,
            /// <summary>
            /// Deactive all image overlays from specified trigger
            /// </summary>
            DeactivateTrigger
        }

        /// <summary>
        /// Type of the image overlay operation
        /// </summary>
        private OperationEnum _Operation { get; set; } = OperationEnum.Activate;
        [XmlAttribute]
        public string Operation
        {
            get
            {
                if (_Operation != OperationEnum.Activate)
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
        /// Image sizing mode within overlay
        /// </summary>
        private PictureBoxSizeMode _SizeMode { get; set; } = PictureBoxSizeMode.Normal;
        [XmlAttribute]
        public string SizeMode
        {
            get
            {
                if (_SizeMode != PictureBoxSizeMode.Normal)
                {
                    return _SizeMode.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _SizeMode = (PictureBoxSizeMode)Enum.Parse(typeof(PictureBoxSizeMode), value);
            }
        }

        /// <summary>
        /// Name of the image overlay
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
        /// Image file name expression
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
        /// Exoression for initializing overlay X position
        /// </summary>
        private string _XIniExpression = "";
        [XmlAttribute]
        public string XIniExpression
        {
            get
            {
                if (_XIniExpression == "")
                {
                    return null;
                }
                return _XIniExpression;
            }
            set
            {
                _XIniExpression = value;
            }
        }

        /// <summary>
        /// Exoression for initializing overlay Y position
        /// </summary>
        private string _YIniExpression = "";
        [XmlAttribute]
        public string YIniExpression
        {
            get
            {
                if (_YIniExpression == "")
                {
                    return null;
                }
                return _YIniExpression;
            }
            set
            {
                _YIniExpression = value;
            }
        }

        /// <summary>
        /// Exoression for initializing overlay width
        /// </summary>
        private string _WIniExpression = "";
        [XmlAttribute]
        public string WIniExpression
        {
            get
            {
                if (_WIniExpression == "")
                {
                    return null;
                }
                return _WIniExpression;
            }
            set
            {
                _WIniExpression = value;
            }
        }

        /// <summary>
        /// Exoression for initializing overlay height
        /// </summary>
        private string _HIniExpression = "";
        [XmlAttribute]
        public string HIniExpression
        {
            get
            {
                if (_HIniExpression == "")
                {
                    return null;
                }
                return _HIniExpression;
            }
            set
            {
                _HIniExpression = value;
            }
        }

        /// <summary>
        /// Exoression for initializing overlay opacity
        /// </summary>
        private string _OIniExpression = "";
        [XmlAttribute]
        public string OIniExpression
        {
            get
            {
                if (_OIniExpression == "")
                {
                    return null;
                }
                return _OIniExpression;
            }
            set
            {
                _OIniExpression = value;
            }
        }

        /// <summary>
        /// Exoression for updating overlay X position
        /// </summary>
        private string _XTickExpression = "";
        [XmlAttribute]
        public string XTickExpression
        {
            get
            {
                if (_XTickExpression == "")
                {
                    return null;
                }
                return _XTickExpression;
            }
            set
            {
                _XTickExpression = value;
            }
        }

        /// <summary>
        /// Exoression for updating overlay Y position
        /// </summary>
        private string _YTickExpression = "";
        [XmlAttribute]
        public string YTickExpression
        {
            get
            {
                if (_YTickExpression == "")
                {
                    return null;
                }
                return _YTickExpression;
            }
            set
            {
                _YTickExpression = value;
            }
        }

        /// <summary>
        /// Exoression for updating overlay width
        /// </summary>
        private string _WTickExpression = "";
        [XmlAttribute]
        public string WTickExpression
        {
            get
            {
                if (_WTickExpression == "")
                {
                    return null;
                }
                return _WTickExpression;
            }
            set
            {
                _WTickExpression = value;
            }
        }

        /// <summary>
        /// Exoression for updating overlay height
        /// </summary>
        private string _HTickExpression = "";
        [XmlAttribute]
        public string HTickExpression
        {
            get
            {
                if (_HTickExpression == "")
                {
                    return null;
                }
                return _HTickExpression;
            }
            set
            {
                _HTickExpression = value;
            }
        }

        /// <summary>
        /// Exoression for updating overlay opacity
        /// </summary>
        private string _OTickExpression = "";
        [XmlAttribute]
        public string OTickExpression
        {
            get
            {
                if (_OTickExpression == "")
                {
                    return null;
                }
                return _OTickExpression;
            }
            set
            {
                _OTickExpression = value;
            }
        }

        /// <summary>
        /// Exoression for checking overlay life cycle
        /// </summary>
        private string _TTLTickExpression = "";
        [XmlAttribute]
        public string TTLTickExpression
        {
            get
            {
                if (_TTLTickExpression == "")
                {
                    return null;
                }
                return _TTLTickExpression;
            }
            set
            {
                _TTLTickExpression = value;
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            switch (_Operation)
            {
                case OperationEnum.Activate:
                    return I18n.Translate("internal/Action/descimgoverlayact", "activate image overlay ({0}) with image ({1})", _Name, _Filename);
                case OperationEnum.Deactivate:
                    return I18n.Translate("internal/Action/descimgoverlaydeact", "deactivate image overlay ({0})", _Name);
                case OperationEnum.DeactivateAll:
                    return I18n.Translate("internal/Action/descimgoverlaydeactall", "deactivate all image overlays");
                case OperationEnum.DeactivateRegex:
                    return I18n.Translate("internal/Action/descimgoverlaydeactrex", "deactivate image overlays matching regular expression ({0})", _Name);
            }
            return "";
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            ctx.plug.ImageAuraManagement(ctx, null); // todo supposed to be a reference to this action
        }

        #endregion

    }

}
