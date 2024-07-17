using System;
using System.Globalization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Triggernometry.Actions
{

    /// <summary>
    /// Text overlay operations
    /// </summary>
    [XmlRoot(ElementName = "OverlayText")]
    internal class ActionOverlayText : ActionBase
    {

        #region Properties

        // todo probably needs a custom property editor

        /// <summary>
        /// Text overlay operations
        /// </summary>
        private enum OperationEnum
        {
            /// <summary>
            /// Activate text overlay
            /// </summary>
            Activate,
            /// <summary>
            /// Deactive text overlay with matching name
            /// </summary>
            Deactivate,
            /// <summary>
            /// Deactive all text overlays
            /// </summary>
            DeactivateAll,
            /// <summary>
            /// Deactive all text overlays with name matching given regex
            /// </summary>
            DeactivateRegex,
            /// <summary>
            /// Deactive all text overlays from specified trigger
            /// </summary>
            DeactivateTrigger
        }

        /// <summary>
        /// Text alignment within area
        /// </summary>
        private enum TextAlignmentEnum
        {
            TopLeft,
            TopCenter,
            TopRight,
            MiddleLeft,
            MiddleCenter,
            MiddleRight,
            BottomLeft,
            BottomCenter,
            BottomRight
        }

        /// <summary>
        /// Text effect flags
        /// </summary>
        [Flags]
        private enum EffectEnum
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4,
            Strikeout = 8,
            Outline = 16
        }

        /// <summary>
        /// Type of the text overlay operation
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
        /// Alignment of text within overlay area
        /// </summary>
        private TextAlignmentEnum _Alignment { get; set; } = TextAlignmentEnum.MiddleCenter;
        [XmlAttribute]
        public string Alignment
        {
            get
            {
                if (_Alignment != TextAlignmentEnum.MiddleCenter)
                {
                    return _Alignment.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _Alignment = (TextAlignmentEnum)Enum.Parse(typeof(TextAlignmentEnum), value);
            }
        }

        /// <summary>
        /// Text display effect
        /// </summary>
        private EffectEnum _Effect { get; set; } = EffectEnum.None;
        [XmlAttribute]
        public string Effect
        {
            get
            {
                if (_Effect != EffectEnum.None)
                {
                    return _Effect.ToString();
                }
                else
                {
                    return null;
                }
            }
            set
            {
                EffectEnum tea = (EffectEnum)0;
                string[] ex = value.Split(' ');
                foreach (string exx in ex)
                {
                    tea |= (EffectEnum)Enum.Parse(typeof(EffectEnum), exx.Replace(",", ""));
                }
                _Effect = tea;
            }
        }

        /// <summary>
        /// Font size
        /// </summary>
        private float _FontSize { get; set; } = 10.0f;
        [XmlAttribute]
        public string FontSize
        {
            get
            {
                return I18n.ThingToString(_FontSize);
            }
            set
            {
                _FontSize = float.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Color of the text
        /// </summary>
        private string _ForeColor = "";
        [XmlAttribute]
        public string ForeColor
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_ForeColor))
                {
                    return _ForeColor;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _ForeColor = value;
            }
        }

        /// <summary>
        /// Background color of the overlay
        /// </summary>
        private string _BackColor = "";
        [XmlAttribute]
        public string BackColor
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_BackColor))
                {
                    return _BackColor;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _BackColor = value;
            }
        }

        /// <summary>
        /// Color of the text outline
        /// </summary>
        private string _OutlineColor = "";
        [XmlAttribute]
        public string OutlineColor
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_OutlineColor))
                {
                    return _OutlineColor;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _OutlineColor = value;
            }
        }

        /// <summary>
        /// Name of the text overlay
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
        /// Text expression
        /// </summary>
        private string _Text = "";
        [XmlAttribute]
        public string Text
        {
            get
            {
                if (_Text == "")
                {
                    return null;
                }
                return _Text;
            }
            set
            {
                _Text = value;
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

        /// <summary>
        /// Name of the font to use
        /// </summary>
        private string _Font = "";
        [XmlAttribute]
        public string Font
        {
            get
            {
                if (_Font == "")
                {
                    return null;
                }
                return _Font;
            }
            set
            {
                _Font = value;
            }
        }

        #endregion

        #region Implementation

        internal override string DescribeImplementation(Context ctx)
        {
            switch (_Operation)
            {
                case OperationEnum.Activate:
                    return I18n.Translate("internal/Action/desctextoverlayact", "activate text overlay ({0}) with expression ({1})", _Name, _Text);
                case OperationEnum.Deactivate:
                    return I18n.Translate("internal/Action/desctextoverlaydeact", "deactivate text overlay ({0})", _Name);
                case OperationEnum.DeactivateAll:
                    return I18n.Translate("internal/Action/desctextoverlaydeactall", "deactivate all text overlays");
                case OperationEnum.DeactivateRegex:
                    return I18n.Translate("internal/Action/desctextoverlaydeactrex", "deactivate text overlays matching regular expression ({0})", _Name);
            }
            return "";
        }

        internal override void ExecuteImplementation(ActionInstance ai)
        {
            Context ctx = ai.ctx;
            ctx.plug.TextAuraManagement(ctx, null); // todo supposed to be a reference to this action
        }

        #endregion

    }

}
