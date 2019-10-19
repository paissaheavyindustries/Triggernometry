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

    class ScarboroughImage : ScarboroughItem
    {

        private int CurrentFrame { get; set; }
        private int CurrentFrameDelay { get; set; }
        private int NumberOfFrames = 1;
        private bool IsAnimated = false;
        public List<int> FrameDelays { get; set; }
        public List<Image> Frames { get; set; }

        internal bool NeedImage { get; set; }
        internal string ImageFilename { get; set; }
        internal string ImageExpression { get; set; }

        private PictureBoxSizeMode _Display;
        internal PictureBoxSizeMode Display
        {
            get
            {
                return _Display;
            }
            set
            {
                if (value != _Display)
                {
                    Changed = true;
                    _Display = value;
                }
            }
        }

        private Image OriginalImage { get; set; } = null;

        private byte[] ImageToByte(System.Drawing.Image img)
        {
            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        internal sealed class GifData
        {

            public int TransparencyIndex { get; set; } = -1;
            public int BackgroundColor { get; set; } = -1;
            public bool HasGCTF { get; set; } = false;
            public int GCTFSize { get; set; } = -1;
            public int GCTFColors { get; set; } = -1;
            public Color[] Palette { get; set; } = null;

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

        internal void LoadImageDataFromFile(Triggernometry.Plugin plug, Graphics g, string fn)
        {
            byte[] data = File.ReadAllBytes(fn);
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

        internal void LoadImageData(Triggernometry.Plugin plug, Graphics g, string ifn)
        {
            Uri u = new Uri(ifn);
            if (u.IsFile == true)
            {
                LoadImageDataFromFile(plug, g, ifn);
            }
            else
            {
                string fn = Path.Combine(plug.path, "TriggernometryRemoteImages");
                if (Directory.Exists(fn) == false)
                {
                    Directory.CreateDirectory(fn);
                }
                string ext = Path.GetExtension(u.LocalPath);
                fn = Path.Combine(fn, plug.HashRepositoryAddress(u.AbsoluteUri) + Path.GetExtension(u.LocalPath));
                if (File.Exists(fn) == false)
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers["User-Agent"] = "Triggernometry Image Retriever";
                        byte[] data = wc.DownloadData(u.AbsoluteUri);
                        File.WriteAllBytes(fn, data);
                    }
                }
                if (File.Exists(fn) == true)
                {
                    LoadImageDataFromFile(plug, g, fn);
                }
            }
        }

        private double TimeAccumulator = 0.0;
        private DateTime LastAdvance = DateTime.MinValue;
        
        public ScarboroughImage(Scarborough own) : base(own)
        {
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

        public void LoadImageOnDemand()
        {
            Free();
            LoadImageData(plug, _graphics, ImageFilename);
        }

        public override void Free()
        {
            if (NumberOfFrames > 1)
            {
                foreach (Image i in Frames)
                {
                    i.Dispose();
                }
                Frames.Clear();
                OriginalImage = null;
            }
            else
            {
                if (OriginalImage != null)
                {
                    OriginalImage.Dispose();
                    OriginalImage = null;
                }
            }
        }

        public override void Render()
        {
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
            switch (Display)
            {
                case PictureBoxSizeMode.Zoom:
                    float mW = (float)Width / OriginalImage.Width;
                    float mH = (float)Height / OriginalImage.Height;
                    float aW, aH;
                    if (mH < mW)
                    {
                        aW = mH * OriginalImage.Width;
                        aH = Height;
                    }
                    else if (mW < mH)
                    {
                        aW = Width;
                        aH = mW * OriginalImage.Height;
                    }
                    else
                    {
                        aW = Width;
                        aH = Height;
                    }
                    _graphics.DrawImage(
                        OriginalImage,
                        ((Width - aW) / 2),
                        ((Height - aH) / 2),
                        ((Width - aW) / 2) + aW,
                        ((Height - aH) / 2) + aH,
                        Opacity / 100.0f
                    );
                    break;
                case PictureBoxSizeMode.Normal:
                    if (OriginalImage.Width <= Width && OriginalImage.Height <= Height)
                    {
                        _graphics.DrawImage(
                            OriginalImage,
                            0,
                            0,
                            OriginalImage.Width,
                            OriginalImage.Height,
                            Opacity / 100.0f
                        );
                    }
                    else
                    {
                        if (OriginalImage.Width <= Width)
                        {
                            _graphics.DrawImageEx(
                                OriginalImage,
                                new Rectangle(0, 0, OriginalImage.Width, Height),
                                new Rectangle(0, 0, OriginalImage.Width, Height),
                                Opacity / 100.0f
                            );
                        }
                        else if (OriginalImage.Height <= Height)
                        {
                            _graphics.DrawImageEx(
                                OriginalImage,
                                new Rectangle(0, 0, Width, OriginalImage.Height),
                                new Rectangle(0, 0, Width, OriginalImage.Height),
                                Opacity / 100.0f
                            );
                        }
                        else
                        {
                            _graphics.DrawImageEx(
                                OriginalImage,
                                new Rectangle(0, 0, Width, Height),
                                new Rectangle(0, 0, Width, Height),
                                Opacity / 100.0f
                            );
                        }
                    }
                    break;
                case PictureBoxSizeMode.CenterImage:
                    if (OriginalImage.Width <= Width && OriginalImage.Height <= Height)
                    {
                        _graphics.DrawImage(
                            OriginalImage,
                            ((Width - OriginalImage.Width) / 2),
                            ((Height - OriginalImage.Height) / 2),
                            ((Width - OriginalImage.Width) / 2) + OriginalImage.Width,
                            ((Height - OriginalImage.Height) / 2) + OriginalImage.Height,
                            Opacity / 100.0f
                        );
                    }
                    else
                    {
                        _graphics.DrawImageEx(
                            OriginalImage,
                            new Rectangle(
                                (OriginalImage.Width / 2) - (Width / 2),
                                (OriginalImage.Height / 2) - (Height / 2),
                                (OriginalImage.Width / 2) + (Width / 2),
                                (OriginalImage.Height / 2) + (Height / 2)
                            ),
                            new Rectangle(
                                0,
                                0,
                                Width,
                                Height
                            ),
                            Opacity / 100.0f
                        );
                    }
                    break;
                case PictureBoxSizeMode.StretchImage:
                    _graphics.DrawImage(
                        OriginalImage,
                        0,
                        0,
                        Width,
                        Height,
                        Opacity / 100.0f
                    );
                    break;
            }
            _graphics.EndScene();
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
            return true;
        }

    }

}
