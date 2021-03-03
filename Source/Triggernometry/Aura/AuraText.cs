using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggernometry.Aura
{

    internal sealed class AuraText : Aura
    {

        internal string TextExpression { get; set; }

        private string _Text;
        internal string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                if (value != _Text)
                {
                    Changed = true;
                    _Text = value;
                }
            }
        }

        private Triggernometry.Action.TextAuraAlignmentEnum _TextAlignment;
        internal Triggernometry.Action.TextAuraAlignmentEnum TextAlignment
        {
            get
            {
                return _TextAlignment;
            }
            set
            {
                if (value != _TextAlignment)
                {
                    Changed = true;
                    _TextAlignment = value;
                }
            }
        }

        private bool _UseOutline;
        internal bool UseOutline
        {
            get
            {
                return _UseOutline;
            }
            set
            {
                if (value != _UseOutline)
                {
                    Changed = true;
                    _UseOutline = value;
                }
            }
        }

        private float _FontSize;
        internal float FontSize
        {
            get
            {
                return _FontSize;
            }
            set
            {
                if (value != _FontSize)
                {
                    Changed = true;
                    _FontSize = value;
                }
            }
        }

        private System.Drawing.Color _TextColor;
        internal System.Drawing.Color TextColor
        {
            get
            {
                return _TextColor;
            }
            set
            {
                if (value != _TextColor)
                {
                    Changed = true;
                    _TextColor = value;
                }
            }
        }

        private System.Drawing.Color _OutlineColor;
        internal System.Drawing.Color OutlineColor
        {
            get
            {
                return _OutlineColor;
            }
            set
            {
                if (value != _OutlineColor)
                {
                    Changed = true;
                    _OutlineColor = value;
                }
            }
        }

        private System.Drawing.Color _BackgroundColor;
        internal System.Drawing.Color BackgroundColor
        {
            get
            {
                return _BackgroundColor;
            }
            set
            {
                if (value != _BackgroundColor)
                {
                    Changed = true;
                    _BackgroundColor = value;
                    /* tododoo
                    if (_BackgroundColor != System.Drawing.Color.Transparent)
                    {
                        _bgColor.R = _BackgroundColor.R;
                        _bgColor.G = _BackgroundColor.G;
                        _bgColor.B = _BackgroundColor.B;
                    }
                    else
                    {
                        _bgColor = new Color();
                    }*/
                }
            }
        }

        private System.Drawing.FontStyle _FontStyle;
        internal System.Drawing.FontStyle FontStyle
        {
            get
            {
                return _FontStyle;
            }
            set
            {
                if (value != _FontStyle)
                {
                    Changed = true;
                    _FontStyle = value;
                }
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        internal override bool InternalLogic(int numTicks)
        {
            if (base.InternalLogic(numTicks) == false)
            {
                return false;
            }
            Text = EvaluateStringExpression(ctx, TextExpression);
            return true;
        }

    }

}
