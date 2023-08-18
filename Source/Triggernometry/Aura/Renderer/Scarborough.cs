using Scarborough.Drawing;
using Scarborough.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triggernometry.Aura.Renderer
{

    sealed internal class Scarborough : RendererBase
    {

        #region Generic properties

        private OverlayWindow _window = null;
        private Graphics _graphics = null;
        private Color _bgColor = new Color();

        internal bool NeedRender { get; set; } = true;
        internal bool WasHidden { get; set; } = false;

        internal Int64 Ordinal { get; set; }

        #endregion

        #region Image specific properties

        private int CurrentFrame { get; set; }
        private int CurrentFrameDelay { get; set; }
        private int NumberOfFrames = 1;
        private bool IsAnimated = false;
        public List<int> FrameDelays { get; set; }
        public List<Image> Frames { get; set; }

        internal bool NeedImage { get; set; }

        private Image OriginalImage { get; set; } = null;

        private double TimeAccumulator = 0.0;
        private DateTime LastAdvance = DateTime.MinValue;

        #endregion

        #region Text specific properties


        #endregion

        public override void Dispose()
        {
            if (OriginalImage != null)
            {
                OriginalImage.Dispose();
                OriginalImage = null;
            }
        }

        #region Generic methods

        internal override void Initialize(Aura a)
        {
        }

        internal override void Render(Aura a)
        {
            if (a is AuraImage)
            {
                RenderImage((AuraImage)a);
            }
            if (a is AuraText)
            {
                RenderText((AuraText)a);
            }
        }

        private void AdjustSurface()
        {
            /*
            if (_window == null)
            {
                _window = new OverlayWindow(Left, Top, Width, Height)
                {
                    IsTopmost = true,
                    IsVisible = true
                };
                _graphics = new Graphics
                {
                    MeasureFPS = false,
                    Width = _window.Width,
                    Height = _window.Height,
                    PerPrimitiveAntiAliasing = true,
                    TextAntiAliasing = true,
                    UseMultiThreadedFactories = false,
                    VSync = false,
                    WindowHandle = IntPtr.Zero
                };
                _window.CreateWindow();
                _graphics.WindowHandle = _window.Handle;
                _graphics.Setup();
            }
            else
            {
                if (Left != _window.X || Top != _window.Y)
                {
                    _window.Move(Left, Top);
                }
                if (Width != _window.Width || Height != _window.Height)
                {
                    _window.Resize(Width, Height);
                    _graphics.Resize(Width, Height);
                }
            }*/
        }

        internal void Show()
        {
            if (_window != null)
            {
                _window.Show();
            }
        }

        internal void Hide()
        {
            if (_window != null)
            {
                _window.Hide();
            }
        }

        #endregion

        #region Image specific methods

        internal sealed class GifData
        {

            public int TransparencyIndex { get; set; } = -1;
            public int BackgroundColor { get; set; } = -1;
            public bool HasGCTF { get; set; } = false;
            public int GCTFSize { get; set; } = -1;
            public int GCTFColors { get; set; } = -1;
            public Color[] Palette { get; set; } = null;

        }

        private byte[] ImageToByte(System.Drawing.Image img)
        {
            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        internal GifData GetGifData(byte[] data)
        {
            if ((data[0] == 71) || (data[1] == 73) || (data[2] == 70))
            {
                GifData g = new GifData();
                g.BackgroundColor = data[11];
                int ii = 10;
                g.HasGCTF = ((data[ii] & 0x80) > 0);
                if (g.HasGCTF == true)
                {
                    // if we have a GCTF
                    g.GCTFColors = (int)Math.Pow(2, (data[ii] & 0x07) + 1);
                    g.GCTFSize = 3 * g.GCTFColors;
                    g.Palette = new Color[g.GCTFColors];
                    ii += 3;
                    for (int c = 0; c < g.GCTFColors; c++)
                    {
                        g.Palette[c] = new Color(data[ii], data[ii + 1], data[ii + 2]);
                        ii += 3;
                    }
                }
                while (ii < data.Length)
                {
                    if (data[ii] == 0x21)
                    {
                        if (data[ii + 1] == 0xf9)
                        {
                            g.TransparencyIndex = data[ii + 6];
                            break;
                        }
                        else
                        {
                            int bsize = data[ii + 2];
                            ii += bsize + 3;
                            while (data[ii] != 0)
                            {
                                ii += data[ii] + 1;
                            }
                            ii++;
                        }
                    }
                    else
                    {
                        // out of blocks
                        break;
                    }
                }
                return g;
            }
            return null;
        }

        internal void SetTransparencyIndex(byte[] data, byte idx)
        {
            if ((data[0] == 71) || (data[1] == 73) || (data[2] == 70))
            {
                int ii = 10;
                if ((data[ii] & 0x80) > 0)
                {
                    // if we have a GCTF
                    int gctfsize = 3 * (int)Math.Pow(2, (data[ii] & 0x07) + 1);
                    ii += gctfsize;
                }
                ii += 3;
                // should have application block here now
                if (data[ii] == 0x21 && data[ii + 1] == 0xff)
                {
                    ii += 19;
                    if (data[ii] == 0x21 && data[ii + 1] == 0xf9)
                    {
                        data[ii + 6] = idx;
                    }
                }
            }
        }

        internal void LoadImageDataFromFile(Triggernometry.RealPlugin plug, Graphics g, string fn)
        {
            byte[] data = File.ReadAllBytes(fn);
            LoadImageDataFromByte(plug, g, data);
        }

        internal void LoadImageDataFromByte(Triggernometry.RealPlugin plug, Graphics g, byte[] data)
        {
            GifData gif = GetGifData(data);
            using (MemoryStream ms = new MemoryStream(data))
            {
                using (System.Drawing.Image i = System.Drawing.Image.FromStream(ms))
                {
                    System.Drawing.Bitmap b = (System.Drawing.Bitmap)i;
                    System.Drawing.Imaging.FrameDimension CurrentFd = new System.Drawing.Imaging.FrameDimension(i.FrameDimensionsList[0]);
                    NumberOfFrames = i.GetFrameCount(CurrentFd);
                    IsAnimated = (NumberOfFrames > 1);
                    if (IsAnimated == true)
                    {
                        Frames = new List<Image>();
                        FrameDelays = new List<int>();
                        System.Drawing.Imaging.PropertyItem delay = i.GetPropertyItem(0x5100);
                        Color tc;
                        bool hastc = false;
                        if (gif.TransparencyIndex >= 0)
                        {
                            tc = gif.Palette[gif.TransparencyIndex];
                            hastc = true;
                        }
                        else
                        {
                            tc = gif.Palette[0];
                        }
                        for (int h = 0; h < NumberOfFrames; h++)
                        {
                            int delayn = (delay.Value[h * 4] + (delay.Value[(h * 4) + 1] * 256)) * 10;
                            FrameDelays.Add(delayn);
                            i.SelectActiveFrame(CurrentFd, h);
                            System.Drawing.Image ifa = ((System.Drawing.Image)i.Clone());
                            byte[] idata = ImageToByte(ifa);
                            if (hastc == true)
                            {
                                if (gif.TransparencyIndex != gif.BackgroundColor)
                                {
                                    // hack in case transparency color is different from bgcolor (some gifs have this shit)
                                    SetTransparencyIndex(idata, (byte)gif.BackgroundColor);
                                }
                                else
                                {
                                    for (int j = 0; j < gif.TransparencyIndex; j++)
                                    {
                                        if ((gif.Palette[j].R == tc.R) && (gif.Palette[j].R == tc.G) && (gif.Palette[j].R == tc.B))
                                        {
                                            // net itself might have selected an earlier color as new transparency color
                                            // hack to reset transparency index to match if so
                                            SetTransparencyIndex(idata, (byte)j);
                                            break;
                                        }
                                    }
                                }
                            }
                            Frames.Add(g.CreateImage(idata));
                        }
                        CurrentFrame = -1;
                        AdvanceFrame();
                    }
                    else
                    {
                        OriginalImage = g.CreateImage(data);
                    }
                }
            }
        }

        internal void LoadImageData(Triggernometry.RealPlugin plug, Graphics g, string ifn)
        {
            string fn = AuraImage.GetImageFilename(plug, ifn);
            byte[] data = File.ReadAllBytes(fn);
            LoadImageDataFromByte(plug, g, data);
        }

        internal void RenderImage(AuraImage a)
        {
            /*
            if (NeedImage == true)
            {
                if (_window == null)
                {
                    AdjustSurface();
                }
                LoadImageOnDemand();
                NeedImage = false;
                NeedRender = true;
            }
            if (IsAnimated == true)
            {
                bool af = AdvanceFrame();
                NeedRender = NeedRender || af;
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
            AdjustSurface();
            NeedRender = false;
            _graphics.BeginScene();
            _graphics.ClearScene(_bgColor);
            if (Owner.RenderingActive == false)
            {
                _graphics.EndScene();
                return;
            }
            switch (a.Display)
            {
                case PictureBoxSizeMode.Zoom:
                    float mW = (float)a.Width / OriginalImage.Width;
                    float mH = (float)a.Height / OriginalImage.Height;
                    float aW, aH;
                    if (mH < mW)
                    {
                        aW = mH * OriginalImage.Width;
                        aH = a.Height;
                    }
                    else if (mW < mH)
                    {
                        aW = a.Width;
                        aH = mW * OriginalImage.Height;
                    }
                    else
                    {
                        aW = a.Width;
                        aH = a.Height;
                    }
                    _graphics.DrawImage(
                        OriginalImage,
                        ((a.Width - aW) / 2),
                        ((a.Height - aH) / 2),
                        ((a.Width - aW) / 2) + aW,
                        ((a.Height - aH) / 2) + aH,
                        a.Opacity / 100.0f
                    );
                    break;
                case PictureBoxSizeMode.Normal:
                    if (OriginalImage.Width <= a.Width && OriginalImage.Height <= a.Height)
                    {
                        _graphics.DrawImage(
                            OriginalImage,
                            0,
                            0,
                            OriginalImage.Width,
                            OriginalImage.Height,
                            a.Opacity / 100.0f
                        );
                    }
                    else
                    {
                        if (OriginalImage.Width <= a.Width)
                        {
                            _graphics.DrawImageEx(
                                OriginalImage,
                                new Rectangle(0, 0, OriginalImage.Width, a.Height),
                                new Rectangle(0, 0, OriginalImage.Width, a.Height),
                                a.Opacity / 100.0f
                            );
                        }
                        else if (OriginalImage.Height <= a.Height)
                        {
                            _graphics.DrawImageEx(
                                OriginalImage,
                                new Rectangle(0, 0, a.Width, OriginalImage.Height),
                                new Rectangle(0, 0, a.Width, OriginalImage.Height),
                                a.Opacity / 100.0f
                            );
                        }
                        else
                        {
                            _graphics.DrawImageEx(
                                OriginalImage,
                                new Rectangle(0, 0, a.Width, a.Height),
                                new Rectangle(0, 0, a.Width, a.Height),
                                a.Opacity / 100.0f
                            );
                        }
                    }
                    break;
                case PictureBoxSizeMode.CenterImage:
                    if (OriginalImage.Width <= a.Width && OriginalImage.Height <= a.Height)
                    {
                        _graphics.DrawImage(
                            OriginalImage,
                            ((a.Width - OriginalImage.Width) / 2),
                            ((a.Height - OriginalImage.Height) / 2),
                            ((a.Width - OriginalImage.Width) / 2) + OriginalImage.Width,
                            ((a.Height - OriginalImage.Height) / 2) + OriginalImage.Height,
                            a.Opacity / 100.0f
                        );
                    }
                    else
                    {
                        _graphics.DrawImageEx(
                            OriginalImage,
                            new Rectangle(
                                (OriginalImage.Width / 2) - (a.Width / 2),
                                (OriginalImage.Height / 2) - (a.Height / 2),
                                (OriginalImage.Width / 2) + (a.Width / 2),
                                (OriginalImage.Height / 2) + (a.Height / 2)
                            ),
                            new Rectangle(
                                0,
                                0,
                                a.Width,
                                a.Height
                            ),
                            a.Opacity / 100.0f
                        );
                    }
                    break;
                case PictureBoxSizeMode.StretchImage:
                    _graphics.DrawImage(
                        OriginalImage,
                        0,
                        0,
                        a.Width,
                        a.Height,
                        a.Opacity / 100.0f
                    );
                    break;
            }
            _graphics.EndScene();*/
        }

        public bool AdvanceFrame()
        {
            int prev = CurrentFrame;
            if (CurrentFrame == -1)
            {
                LastAdvance = DateTime.Now;
                TimeAccumulator = 0.0;
                CurrentFrame = 0;
                CurrentFrameDelay = FrameDelays[0];
                OriginalImage = Frames[CurrentFrame];
            }
            else
            {
                TimeAccumulator += (DateTime.Now - LastAdvance).TotalMilliseconds;
                LastAdvance = DateTime.Now;
                while (TimeAccumulator >= CurrentFrameDelay)
                {
                    CurrentFrame++;
                    if (CurrentFrame >= NumberOfFrames)
                    {
                        CurrentFrame = 0;
                    }
                    TimeAccumulator -= CurrentFrameDelay;
                    CurrentFrameDelay = FrameDelays[CurrentFrame];
                    if (CurrentFrameDelay <= 0)
                    {
                        break;
                    }
                }
                OriginalImage = Frames[CurrentFrame];
            }
            return (prev != CurrentFrame);
        }

        #endregion

        #region Text specific methods

        internal void RenderText(AuraText a)
        {
            /*
            if (NeedFont == true)
            {
                if (_window == null)
                {
                    AdjustSurface();
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
            AdjustSurface();
            NeedRender = false;
            _graphics.BeginScene();
            if (Owner.RenderingActive == false)
            {
                Color tempBgColor = new Color();
                _graphics.ClearScene(tempBgColor);
                _graphics.EndScene();
                return;
            }
            if (a.BackgroundColor != System.Drawing.Color.Transparent)
            {
                _bgColor.A = a.Opacity / 100.0f;
            }
            _graphics.ClearScene(_bgColor);
            SharpDX.DirectWrite.ParagraphAlignment pa = SharpDX.DirectWrite.ParagraphAlignment.Center;
            SharpDX.DirectWrite.TextAlignment ta = SharpDX.DirectWrite.TextAlignment.Center;
            switch (a.TextAlignment)
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
            if (a.UseOutline == true)
            {
                TextBrush.Color = new Color(a.OutlineColor.R, a.OutlineColor.G, a.OutlineColor.B, a.Opacity / 100.0f);
                _graphics.DrawTextEx(TextFont, FontStyle, FontSize * 1.3f, TextBrush, pa, ta, 1, 0, a.Width, a.Height, a.Text);
                _graphics.DrawTextEx(TextFont, FontStyle, FontSize * 1.3f, TextBrush, pa, ta, -1, 0, a.Width, a.Height, a.Text);
                _graphics.DrawTextEx(TextFont, FontStyle, FontSize * 1.3f, TextBrush, pa, ta, 0, 1, a.Width, a.Height, a.Text);
                _graphics.DrawTextEx(TextFont, FontStyle, FontSize * 1.3f, TextBrush, pa, ta, 0, -1, a.Width, a.Height, a.Text);
            }
            TextBrush.Color = new Color(a.TextColor.R, a.TextColor.G, a.TextColor.B, a.Opacity / 100.0f);
            _graphics.DrawTextEx(a.TextFont, FontStyle, FontSize * 1.3f, TextBrush, pa, ta, 0, 0, a.Width, a.Height, a.Text);
            _graphics.EndScene();*/
        }

        #endregion

    }

}
