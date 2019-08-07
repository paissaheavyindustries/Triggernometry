using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Net;

namespace Triggernometry.Forms
{

    public partial class AuraContainerForm : Form
    {

        public enum AuraTypeEnum
        {
            Image,
            Text
        }

        internal AuraTypeEnum AuraType { get; set; }
        internal string ImageExpression { get; set; }
        internal string XExpression { get; set; }
        internal string YExpression { get; set; }
        internal string WExpression { get; set; }
        internal string HExpression { get; set; }
        internal string OExpression { get; set; }
        internal string TTLExpression { get; set; }
        internal PictureBoxSizeMode Display { get; set; }
        internal Context ctx { get; set; }

        internal string TextExpression { get; set; }
        internal Action.TextAuraAlignmentEnum TextAlignment { get; set; }
        internal Color TextColor { get; set; }
        internal Color OutlineColor { get; set; }
        internal Color BackgroundColor { get; set; }
        internal bool UseOutline { get; set; }

        internal string CurrentText { get; set; }
        internal string NewText { get; set; }
        internal string AuraName { get; set; }
        private SolidBrush Brush = null;
        internal Font AuraFont = null;

        internal double PresentableOpacity
        {
            get
            {
                return Opacity * 100.0;
            }
            set
            {
                Opacity = value / 100.0;
            }
        }

        internal Plugin plug;
        
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        internal static ImageConverter ic = new ImageConverter();

        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x0084;
            const int HTTRANSPARENT = (-1);
            if (m.Msg == WM_NCHITTEST && DesignMode == false)
            {
                m.Result = (IntPtr)HTTRANSPARENT;
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {                
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x08000000; // ws_ex_noactivate
                createParams.ExStyle |= 0x80000; // layered
                createParams.ExStyle |= 0x20; // no hit test
                createParams.ExStyle |= 0x80; // parent dc / hide from alt tab
                createParams.ExStyle |= 0x00000008; // topmost
                return createParams;
            }
        }

        public AuraContainerForm(AuraContainerForm.AuraTypeEnum at)
        {
            InitializeComponent();
            PresentableOpacity = 50;
            TransparencyKey = BackColor;
            AuraType = at;
            switch (at)
            {
                case AuraTypeEnum.Image:                    
                    break;
                case AuraTypeEnum.Text:
                    Brush = new SolidBrush(Color.Black);
                    break;
            }
            Disposed += AuraContainerForm_Disposed;
            Resize += AuraContainerForm_Resize;
        }

        private void AuraContainerForm_Resize(object sender, EventArgs e)
        {
            
        }

        private const int SW_SHOWNOACTIVATE = 4;
        private const int HWND_TOPMOST = -1;
        private const uint SWP_NOACTIVATE = 0x0010;

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(
             int hWnd,             // Window handle
             int hWndInsertAfter,  // Placement-order handle
             int X,                // Horizontal position
             int Y,                // Vertical position
             int cx,               // Width
             int cy,               // Height
             uint uFlags);         // Window positioning flags

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public void ShowMe()
        {
            ShowWindow(Handle, SW_SHOWNOACTIVATE);
            SetWindowPos(Handle.ToInt32(), HWND_TOPMOST, Left, Top, Width, Height, SWP_NOACTIVATE);
        }

        private void AuraContainerForm_Disposed(object sender, EventArgs e)
        {
            if (Brush != null)
            {
                Brush.Dispose();
                Brush = null;
            }
            if (AuraFont != null)
            {
                AuraFont.Dispose();
                AuraFont = null;
            }
        }

        internal void AuraPrepare()
        {
            Hide();
        }

        private static Bitmap LoadImage(string fn)
        {
            byte[] buf = File.ReadAllBytes(fn);
            Bitmap bm = (Bitmap)ic.ConvertFrom(buf);
            if (bm != null && (bm.HorizontalResolution != (int)bm.HorizontalResolution || bm.VerticalResolution != (int)bm.VerticalResolution))
            {
                // Correct a strange glitch that has been observed in the test program when converting 
                //  from a PNG file image created by CopyImageToByteArray() - the dpi value "drifts" 
                //  slightly away from the nominal integer value
                bm.SetResolution((int)(bm.HorizontalResolution + 0.5f), (int)(bm.VerticalResolution + 0.5f));
            }
            return bm;
        }

        internal static Image LoadImageData(Plugin plug, string ifn)
        {
            Uri u = new Uri(ifn);
            if (u.IsFile == true)
            {
                return LoadImage(u.LocalPath);
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
                    return LoadImage(fn);
                }
            }
            return null;
        }

        internal void AuraActivate()
        {
            int wx = Width;
            int hx = Height;
            switch (AuraType)
            {
                case AuraTypeEnum.Image:
                default:
                    string img = ctx.EvaluateStringExpression(ctx.trig != null ? ctx.trig.TriggerContextLogger : (Context.LoggerDelegate)null, ctx.plug, PreprocessExpression(ImageExpression));
                    pictureBox1.Image = LoadImageData(plug, img);
                    pictureBox1.SizeMode = Display;
                    wx = Width;
                    hx = Height;
                    break;
                case AuraTypeEnum.Text:
                    if (BackgroundColor != Color.Transparent)
                    {
                        BackColor = BackgroundColor;
                    }
                    break;
            }
            if (ctx.trig != null)
            {
                ctx.trig.AddToLog(plug, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/AuraContainer/displayingaura", "Displaying aura window"));
            }
            else
            {
                plug.FilteredAddToLog(Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/AuraContainer/displayingaura", "Displaying aura window"));
            }            
            //Show();
            ShowMe();
            if (Width != wx || Height != hx)
            {
                Size = new Size(Width, Height);
            }
        }

        internal void AuraDeactivateForm()
        {
            if (ctx.trig != null)
            {
                ctx.trig.AddToLog(plug, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/AuraContainer/closingaura", "Closing aura window"));
            }
            else
            {
                plug.FilteredAddToLog(Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/AuraContainer/closingaura", "Closing aura window"));
            }
            Close();
        }

        internal void AuraDeactivate()
        {
            if (AuraType == AuraTypeEnum.Image)
            {
                lock (ctx.plug.imageauras)
                {
                    if (ctx.plug.imageauras.ContainsKey(AuraName) == true)
                    {
                        ctx.plug.imageauras.Remove(AuraName);
                    }
                }
            }
            if (AuraType == AuraTypeEnum.Text)
            {
                lock (ctx.plug.textauras)
                {
                    if (ctx.plug.textauras.ContainsKey(AuraName) == true)
                    {
                        ctx.plug.textauras.Remove(AuraName);
                    }
                }
            }
            AuraDeactivateForm();
        }

        private bool NextPending = false;
        int NextLeft = 0, NextTop = 0, NextWidth = 0, NextHeight = 0;
        double NextPresentableOpacity = 0.0;

        private string PreprocessExpression(string exp)
        {
            if (NextPending == true)
            {
                exp = exp.Replace("${_x}", NextLeft.ToString());
                exp = exp.Replace("${_y}", NextTop.ToString());
                if (AuraType == AuraTypeEnum.Image)
                {
                    exp = exp.Replace("${_width}", NextWidth.ToString());
                    exp = exp.Replace("${_height}", NextHeight.ToString());
                }
                exp = exp.Replace("${_opacity}", NextPresentableOpacity.ToString());
            }
            else
            {
                exp = exp.Replace("${_x}", Left.ToString());
                exp = exp.Replace("${_y}", Top.ToString());
                if (AuraType == AuraTypeEnum.Image)
                {
                    exp = exp.Replace("${_width}", Width.ToString());
                    exp = exp.Replace("${_height}", Height.ToString());
                }
                exp = exp.Replace("${_opacity}", PresentableOpacity.ToString());
            }
            return exp;
        }

        internal int EvaluateNumericExpression(Context c, string exp)
        {
            return (int)c.EvaluateNumericExpression((c.trig != null) ? c.trig.TriggerContextLogger : (Context.LoggerDelegate)null, c.plug, PreprocessExpression(exp));
        }

        internal bool UpdateAura(int numTicks)
        {
            NextPending = false;
            bool chLeft = false, chTop = false, chWidth = false, chHeight = false, chOpacity = false;
            //Plugin.DebugLevelEnum levelFilter = Plugin.DebugLevelEnum.None;
            try
            {
                while (numTicks > 0)
                {
                    int i;
                    if (XExpression != null && XExpression.Length > 0)
                    {
                        NextLeft = EvaluateNumericExpression(ctx, XExpression);
                        chLeft = (Left != NextLeft);
                    }
                    if (YExpression != null && YExpression.Length > 0)
                    {
                        NextTop = EvaluateNumericExpression(ctx, YExpression);
                        chTop = (Top != NextTop);
                    }
                    if (WExpression != null && WExpression.Length > 0)
                    {
                        i = EvaluateNumericExpression(ctx, WExpression);
                        if (i < 0)
                        {
                            i = 0;
                        }
                        NextWidth = i;
                        chWidth = (Width != NextWidth);
                    }
                    if (HExpression != null && HExpression.Length > 0)
                    {
                        i = EvaluateNumericExpression(ctx, HExpression);
                        if (i < 0)
                        {
                            i = 0;
                        }
                        NextHeight = i;
                        chHeight = (Height != NextHeight);
                    }
                    if (AuraType == AuraTypeEnum.Text)
                    {
                        if (TextExpression != null && TextExpression.Length > 0)
                        {
                            NewText = ctx.EvaluateStringExpression(ctx.trig != null ? ctx.trig.TriggerContextLogger : (Context.LoggerDelegate)null, ctx.plug, TextExpression);
                            if (NewText != CurrentText)
                            {
                                CurrentText = NewText;
                                Invalidate();
                            }
                        }
                    }
                    if (OExpression != null && OExpression.Length > 0)
                    {
                        i = EvaluateNumericExpression(ctx, OExpression);
                        if (i < 0)
                        {
                            i = 0;
                        }
                        if (i > 100)
                        {
                            i = 100;
                        }
                        NextPresentableOpacity = i;
                        chOpacity = (PresentableOpacity != NextPresentableOpacity);
                    }
                    if (TTLExpression != null && TTLExpression.Length > 0)
                    {
                        if (EvaluateNumericExpression(ctx, TTLExpression) < 0)
                        {
                            if (ctx.trig != null)
                            {
                                ctx.trig.AddToLog(plug, Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/AuraContainer/deactaurattl", "Deactivating aura due to TTL expression"));
                            }
                            else
                            {
                                plug.FilteredAddToLog(Plugin.DebugLevelEnum.Verbose, I18n.Translate("internal/AuraContainer/deactaurattl", "Deactivating aura due to TTL expression"));
                            }
                            AuraDeactivateForm();
                            return false;
                        }
                    }
                    numTicks--;
                    NextPending = true;
                }
            }
            catch (Exception ex)
            {
                if (ctx.trig != null)
                {
                    ctx.trig.AddToLog(plug, Plugin.DebugLevelEnum.Error, I18n.Translate("internal/AuraContainer/updateerror", String.Format("Deactivating aura due to update exception: {0}", ex.Message)));
                }
                else
                {
                    plug.FilteredAddToLog(Plugin.DebugLevelEnum.Error, I18n.Translate("internal/AuraContainer/updateerror", String.Format("Deactivating aura due to update exception: {0}", ex.Message)));
                }
                AuraDeactivateForm();
                return false;
            }
            SuspendLayout();
            if (chLeft == true || chTop == true || chWidth == true || chHeight == true || chOpacity == true)
            {
                if (chLeft == true || chTop == true)
                {
                    Location = new Point(chLeft == true ? NextLeft : Left, chTop == true ? NextTop : Top);
                }
                if (chWidth == true || chHeight == true)
                {
                    Size = new Size(chWidth == true ? NextWidth : Width, chHeight == true ? NextHeight : Height);
                }
                if (chOpacity == true)
                {
                    PresentableOpacity = NextPresentableOpacity;
                }
            }
            ResumeLayout();
            return true;
        }

        internal void PaintText(Graphics gr)
        {
            using (StringFormat sf = new StringFormat())
            {
                Rectangle r = new Rectangle(ClientRectangle.Location, ClientRectangle.Size);
                switch (TextAlignment)
                {
                    case Action.TextAuraAlignmentEnum.TopLeft:
                        sf.Alignment = StringAlignment.Near;
                        sf.LineAlignment = StringAlignment.Near;
                        break;
                    case Action.TextAuraAlignmentEnum.TopCenter:
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Near;
                        break;
                    case Action.TextAuraAlignmentEnum.TopRight:
                        sf.Alignment = StringAlignment.Far;
                        sf.LineAlignment = StringAlignment.Near;
                        break;
                    case Action.TextAuraAlignmentEnum.MiddleLeft:
                        sf.Alignment = StringAlignment.Near;
                        sf.LineAlignment = StringAlignment.Center;
                        break;
                    case Action.TextAuraAlignmentEnum.MiddleCenter:
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        break;
                    case Action.TextAuraAlignmentEnum.MiddleRight:
                        sf.Alignment = StringAlignment.Far;
                        sf.LineAlignment = StringAlignment.Center;
                        break;
                    case Action.TextAuraAlignmentEnum.BottomLeft:
                        sf.Alignment = StringAlignment.Near;
                        sf.LineAlignment = StringAlignment.Far;
                        break;
                    case Action.TextAuraAlignmentEnum.BottomCenter:
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Far;
                        break;
                    case Action.TextAuraAlignmentEnum.BottomRight:
                        sf.Alignment = StringAlignment.Far;
                        sf.LineAlignment = StringAlignment.Far;
                        break;
                }
                gr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
                if (UseOutline == true)
                {
                    Brush.Color = OutlineColor;
                    r.Y -= 1;
                    gr.DrawString(CurrentText, AuraFont, Brush, r, sf);
                    r.Y += 2;
                    gr.DrawString(CurrentText, AuraFont, Brush, r, sf);
                    r.Y -= 1;
                    r.X -= 1;
                    gr.DrawString(CurrentText, AuraFont, Brush, r, sf);
                    r.X += 2;
                    gr.DrawString(CurrentText, AuraFont, Brush, r, sf);
                    r.X -= 1;
                }
                Brush.Color = TextColor;
                gr.DrawString(CurrentText, AuraFont, Brush, r, sf);                
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            switch (AuraType)
            {
                case AuraTypeEnum.Text:
                    base.OnPaint(e);
                    PaintText(e.Graphics);
                    break;
                case AuraTypeEnum.Image:
                default:
                    base.OnPaint(e);
                    break;
            }            
        }

    }

}
