using Scarborough.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scarborough
{

    class ScarboroughText : ScarboroughItem
    {

        internal string TextExpression { get; set; }
        internal bool NeedFont { get; set; }
        internal string FontName { get; set; }

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
                    if (_BackgroundColor != System.Drawing.Color.Transparent)
                    {
                        _bgColor.R = _BackgroundColor.R / 255.0f;
                        _bgColor.G = _BackgroundColor.G / 255.0f;
                        _bgColor.B = _BackgroundColor.B / 255.0f;
                    }
                    else
                    {
                        _bgColor = new Color();
                    }
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

        private Font TextFont { get; set; } = null;
        private SolidBrush TextBrush { get; set; } = null;

        public ScarboroughText(Scarborough own) : base(own)
        {
        }

        public override void Free()
        {
            if (TextFont != null)
            {
                TextFont.Dispose();
                TextFont = null;
            }
            if (TextBrush != null)
            {
                TextBrush.Dispose();
                TextBrush = null;
            }
        }

        public void LoadFontOnDemand()
        {
            Free();
            LoadFontData(plug);
            CreateBrush();
        }

        public void CreateBrush()
        {
            TextBrush = new SolidBrush(_graphics.GetRenderTarget());            
        }

        public override void Render()
        {
            if (NeedFont == true)
            {
                if (_window == null)
                {
                    if (AdjustSurface() == false)
                    {
                        AdjustVisibility();
                        return;
                    }
                }
                LoadFontOnDemand();
                NeedFont = false;
                NeedRender = true;
            }
            if (Owner.RenderingActive == false)
            {
                if (WasHidden == false)
                {
                    NeedRender = true;
                    WasHidden = true;
                }
            }
            else
            {
                if (WasHidden == true)
                {
                    NeedRender = true;
                    WasHidden = false;
                }
            }
            if (NeedRender == false)
            {
                return;
            }
            if (AdjustSurface() == false)
            {
                AdjustVisibility();
                return;
            }
            AdjustVisibility();
            NeedRender = false;
            _graphics.BeginScene();
            if (Owner.RenderingActive == false || InvalidSize == true)
            {
                Color tempBgColor = new Color();
                _graphics.ClearScene(tempBgColor);
                _graphics.EndScene();
                return;
            }
            if (BackgroundColor != System.Drawing.Color.Transparent)
            {
                _bgColor.A = Opacity / 100.0f;
            }
            _graphics.ClearScene(_bgColor);
            SharpDX.DirectWrite.ParagraphAlignment pa = SharpDX.DirectWrite.ParagraphAlignment.Center;
            SharpDX.DirectWrite.TextAlignment ta = SharpDX.DirectWrite.TextAlignment.Center;
            switch (TextAlignment)
            {
                case Triggernometry.Action.TextAuraAlignmentEnum.TopLeft:
                    pa = SharpDX.DirectWrite.ParagraphAlignment.Near;
                    ta = SharpDX.DirectWrite.TextAlignment.Leading;
                    break;
                case Triggernometry.Action.TextAuraAlignmentEnum.TopCenter:
                    pa = SharpDX.DirectWrite.ParagraphAlignment.Near;
                    break;
                case Triggernometry.Action.TextAuraAlignmentEnum.TopRight:
                    pa = SharpDX.DirectWrite.ParagraphAlignment.Near;
                    ta = SharpDX.DirectWrite.TextAlignment.Trailing;
                    break;
                case Triggernometry.Action.TextAuraAlignmentEnum.MiddleLeft:
                    ta = SharpDX.DirectWrite.TextAlignment.Leading;
                    break;
                case Triggernometry.Action.TextAuraAlignmentEnum.MiddleCenter:
                    break;
                case Triggernometry.Action.TextAuraAlignmentEnum.MiddleRight:
                    ta = SharpDX.DirectWrite.TextAlignment.Trailing;
                    break;
                case Triggernometry.Action.TextAuraAlignmentEnum.BottomLeft:
                    pa = SharpDX.DirectWrite.ParagraphAlignment.Far;
                    ta = SharpDX.DirectWrite.TextAlignment.Leading;
                    break;
                case Triggernometry.Action.TextAuraAlignmentEnum.BottomCenter:
                    pa = SharpDX.DirectWrite.ParagraphAlignment.Far;
                    break;
                case Triggernometry.Action.TextAuraAlignmentEnum.BottomRight:
                    pa = SharpDX.DirectWrite.ParagraphAlignment.Far;
                    ta = SharpDX.DirectWrite.TextAlignment.Trailing;
                    break;
            }
            if (UseOutline == true)
            {
                TextBrush.Color = new Color(OutlineColor.R, OutlineColor.G, OutlineColor.B, Opacity / 100.0f);
                _graphics.DrawTextEx(TextFont, FontStyle, FontSize * 1.3f, TextBrush, pa, ta, 1, 0, Width, Height, Text);
                _graphics.DrawTextEx(TextFont, FontStyle, FontSize * 1.3f, TextBrush, pa, ta, -1, 0, Width, Height, Text);
                _graphics.DrawTextEx(TextFont, FontStyle, FontSize * 1.3f, TextBrush, pa, ta, 0, 1, Width, Height, Text);
                _graphics.DrawTextEx(TextFont, FontStyle, FontSize * 1.3f, TextBrush, pa, ta, 0, -1, Width, Height, Text);
            }
            TextBrush.Color = new Color(TextColor.R, TextColor.G, TextColor.B, Opacity / 100.0f);
            _graphics.DrawTextEx(TextFont, FontStyle, FontSize * 1.3f, TextBrush, pa, ta, 0, 0, Width, Height, Text);
            _graphics.EndScene();
        }

        internal void LoadFontData(Triggernometry.RealPlugin plug)
        {
            TextFont = _graphics.CreateFont(
                FontName,
                FontSize,
                (FontStyle & System.Drawing.FontStyle.Bold) == System.Drawing.FontStyle.Bold,
                (FontStyle & System.Drawing.FontStyle.Italic) == System.Drawing.FontStyle.Italic,
                true
            );
        }

        public override bool InternalLogic(int numTicks)
        {
            while (numTicks > 0)
            {
                if (GenericLogic() == false)
                {
                    return false;
                }
                numTicks--;
            }
            Text = EvaluateStringExpression(ctx, TextExpression);
            return true;
        }

    }

}
