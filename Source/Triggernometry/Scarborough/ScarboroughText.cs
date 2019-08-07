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
        internal Triggernometry.Action.TextAuraAlignmentEnum TextAlignment { get; set; }
        internal bool NeedFont { get; set; }
        internal string FontName { get; set; }
        internal bool UseOutline { get; set; }
        internal float FontSize { get; set; }
        internal string Text { get; set; }
        internal System.Drawing.Color TextColor { get; set; }
        internal System.Drawing.Color OutlineColor { get; set; }
        internal System.Drawing.Color BackgroundColor { get; set; }
        internal System.Drawing.FontStyle FontStyle { get; set; }

        internal Font TextFont { get; set; } = null;
        internal SolidBrush TextBrush { get; set; } = null;

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

        public void LoadFontOnDemand(Graphics g)
        {
            Free();
            LoadFontData(plug, g);
            CreateBrush(g);
        }

        public void CreateBrush(Graphics g)
        {
            TextBrush = new SolidBrush(g.GetRenderTarget());
        }

        public override void Render(Graphics g)
        {
            if (NeedFont == true)
            {
                LoadFontOnDemand(g);
                NeedFont = false;
            }
            int x = FinalOffsetX + Left;
            int y = FinalOffsetY + Top;
            if (BackgroundColor != System.Drawing.Color.Transparent)
            {
                TextBrush.Color = new Color(BackgroundColor.R, BackgroundColor.G, BackgroundColor.B, Opacity / 100.0f);
                g.FillRectangle(TextBrush, x, y, x + Width, y + Height);
            }
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
                g.DrawTextEx(TextFont, FontStyle, FontSize * 1.3f, TextBrush, pa, ta, x + 1, y, Width, Height, Text);
                g.DrawTextEx(TextFont, FontStyle, FontSize * 1.3f, TextBrush, pa, ta, x - 1, y, Width, Height, Text);
                g.DrawTextEx(TextFont, FontStyle, FontSize * 1.3f, TextBrush, pa, ta, x, y + 1, Width, Height, Text);
                g.DrawTextEx(TextFont, FontStyle, FontSize * 1.3f, TextBrush, pa, ta, x, y - 1, Width, Height, Text);
            }
            TextBrush.Color = new Color(TextColor.R, TextColor.G, TextColor.B, Opacity / 100.0f);
            g.DrawTextEx(TextFont, FontStyle, FontSize * 1.3f, TextBrush, pa, ta, x, y, Width, Height, Text);
        }

        internal void LoadFontData(Triggernometry.Plugin plug, Graphics g)
        {
            TextFont = g.CreateFont(
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
