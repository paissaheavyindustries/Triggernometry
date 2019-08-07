using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triggernometry.Forms
{

    public partial class AuraDesignForm : Form
    {

        public bool blinky = false;

        private const int
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17;

        const int ResizeThreshold = 10;

        internal AuraContainerForm.AuraTypeEnum AuraType { get; set; }
        internal Action.TextAuraAlignmentEnum TextAlignment { get; set; }
        internal Font AuraFont { get; set; }

        internal SolidBrush Brush = null;

        internal Color TextColor { get; set; }
        internal Color OutlineColor { get; set; }
        internal bool UseOutline { get; set; }

        int DynaLeft { get { return 0; } }
        int DynaTop { get { return 0; } }
        int DynaWidth { get { return ClientSize.Width; } }
        int DynaHeight { get { return ClientSize.Height; } }
        int DynaRight { get { return DynaLeft + DynaWidth; } }
        int DynaBottom { get { return DynaTop + DynaHeight; } }

        Rectangle TopRct { get { return new Rectangle(DynaLeft, DynaTop, DynaWidth, ResizeThreshold); } }
        Rectangle LeftRct { get { return new Rectangle(DynaLeft, DynaTop, ResizeThreshold, DynaHeight); } }
        Rectangle BottomRct { get { return new Rectangle(DynaLeft, DynaBottom - ResizeThreshold, DynaWidth, ResizeThreshold); } }
        Rectangle RightRct { get { return new Rectangle(DynaRight - ResizeThreshold, DynaTop, ResizeThreshold, DynaHeight); } }
        Rectangle TopLeftRct { get { return new Rectangle(DynaLeft, DynaTop, ResizeThreshold, ResizeThreshold); } }
        Rectangle TopRightRct { get { return new Rectangle(DynaRight - ResizeThreshold, DynaTop, ResizeThreshold, ResizeThreshold); } }
        Rectangle BottomLeftRct { get { return new Rectangle(DynaLeft, DynaBottom - ResizeThreshold, ResizeThreshold, ResizeThreshold); } }
        Rectangle BottomRightRct { get { return new Rectangle(DynaRight - ResizeThreshold, DynaBottom - ResizeThreshold, ResizeThreshold, ResizeThreshold); } }

        private void setWidthToImageWidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Width = clickthroughPictureBox1.Image.Width;
        }

        private void setHeightToImageHeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Height = clickthroughPictureBox1.Image.Height;
        }

        private void applyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void discardChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        internal void SetImage(Bitmap i)
        {
            clickthroughPictureBox1.Image = i;
        }

        internal void SetImageMode(PictureBoxSizeMode i)
        {
            clickthroughPictureBox1.SizeMode = i;
        }

        internal PictureBoxSizeMode GetImageDisplay()
        {
            return clickthroughPictureBox1.SizeMode;
        }

        private void onceToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (ctxDisplayNormal.Checked == true)
            {
                clickthroughPictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                ctxDisplayCentered.Checked = false;                
                ctxDisplayStretch.Checked = false;
                ctxDisplayZoomed.Checked = false;
            }
        }

        private void centeredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ctxDisplayCentered.Checked == true)
            {
                clickthroughPictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                ctxDisplayNormal.Checked = false;                
                ctxDisplayStretch.Checked = false;
                ctxDisplayZoomed.Checked = false;
            }
        }

        private void stretchedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ctxDisplayStretch.Checked == true)
            {
                clickthroughPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                ctxDisplayNormal.Checked = false;                
                ctxDisplayCentered.Checked = false;
                ctxDisplayZoomed.Checked = false;
            }
        }

        private void stretchedWithAspectRatioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ctxDisplayZoomed.Checked == true)
            {
                clickthroughPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                ctxDisplayNormal.Checked = false;                
                ctxDisplayStretch.Checked = false;
                ctxDisplayCentered.Checked = false;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            switch (AuraType)
            {
                case AuraContainerForm.AuraTypeEnum.Image:
                    {
                        switch (clickthroughPictureBox1.SizeMode)
                        {
                            case PictureBoxSizeMode.Normal:
                                ctxDisplayNormal.Checked = true;
                                break;
                            case PictureBoxSizeMode.CenterImage:
                                ctxDisplayCentered.Checked = true;
                                break;
                            case PictureBoxSizeMode.StretchImage:
                                ctxDisplayStretch.Checked = true;
                                break;
                            case PictureBoxSizeMode.Zoom:
                                ctxDisplayZoomed.Checked = true;
                                break;
                        }
                        ctxImage.Visible = true;
                        ctxText.Visible = false;
                    }
                    break;
                case AuraContainerForm.AuraTypeEnum.Text:
                    {
                        switch (TextAlignment)
                        {
                            case Action.TextAuraAlignmentEnum.TopLeft:
                                topLeftToolStripMenuItem.Checked = true;
                                break;
                            case Action.TextAuraAlignmentEnum.TopCenter:
                                topCenterToolStripMenuItem.Checked = true;
                                break;
                            case Action.TextAuraAlignmentEnum.TopRight:
                                topRightToolStripMenuItem.Checked = true;
                                break;
                            case Action.TextAuraAlignmentEnum.MiddleLeft:
                                middleLeftToolStripMenuItem.Checked = true;
                                break;
                            case Action.TextAuraAlignmentEnum.MiddleCenter:
                                middleCenterToolStripMenuItem.Checked = true;
                                break;
                            case Action.TextAuraAlignmentEnum.MiddleRight:
                                middleRightToolStripMenuItem.Checked = true;
                                break;
                            case Action.TextAuraAlignmentEnum.BottomLeft:
                                bottomLeftToolStripMenuItem.Checked = true;
                                break;
                            case Action.TextAuraAlignmentEnum.BottomCenter:
                                bottomCenterToolStripMenuItem.Checked = true;
                                break;
                            case Action.TextAuraAlignmentEnum.BottomRight:
                                bottomRightToolStripMenuItem.Checked = true;
                                break;
                        }
                        ctxImage.Visible = false;
                        ctxText.Visible = true;
                    }
                    break;
            }
        }

        private void textToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
        }

        private HatchBrush hb;

        private void onceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void topLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (topLeftToolStripMenuItem.Checked == true)
            {
                TextAlignment = Action.TextAuraAlignmentEnum.TopLeft;
                topCenterToolStripMenuItem.Checked = false;
                topRightToolStripMenuItem.Checked = false;
                middleLeftToolStripMenuItem.Checked = false;
                middleCenterToolStripMenuItem.Checked = false;
                middleRightToolStripMenuItem.Checked = false;
                bottomLeftToolStripMenuItem.Checked = false;
                bottomCenterToolStripMenuItem.Checked = false;
                bottomRightToolStripMenuItem.Checked = false;
                Invalidate();
            }
        }

        private void topCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (topCenterToolStripMenuItem.Checked == true)
            {
                TextAlignment = Action.TextAuraAlignmentEnum.TopCenter;
                topLeftToolStripMenuItem.Checked = false;
                topRightToolStripMenuItem.Checked = false;
                middleLeftToolStripMenuItem.Checked = false;
                middleCenterToolStripMenuItem.Checked = false;
                middleRightToolStripMenuItem.Checked = false;
                bottomLeftToolStripMenuItem.Checked = false;
                bottomCenterToolStripMenuItem.Checked = false;
                bottomRightToolStripMenuItem.Checked = false;
                Invalidate();
            }
        }

        private void topRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (topRightToolStripMenuItem.Checked == true)
            {
                TextAlignment = Action.TextAuraAlignmentEnum.TopRight;
                topLeftToolStripMenuItem.Checked = false;
                topCenterToolStripMenuItem.Checked = false;
                middleLeftToolStripMenuItem.Checked = false;
                middleCenterToolStripMenuItem.Checked = false;
                middleRightToolStripMenuItem.Checked = false;
                bottomLeftToolStripMenuItem.Checked = false;
                bottomCenterToolStripMenuItem.Checked = false;
                bottomRightToolStripMenuItem.Checked = false;
                Invalidate();
            }
        }

        private void middleLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (middleLeftToolStripMenuItem.Checked == true)
            {
                TextAlignment = Action.TextAuraAlignmentEnum.MiddleLeft;
                topLeftToolStripMenuItem.Checked = false;
                topCenterToolStripMenuItem.Checked = false;
                topRightToolStripMenuItem.Checked = false;
                middleCenterToolStripMenuItem.Checked = false;
                middleRightToolStripMenuItem.Checked = false;
                bottomLeftToolStripMenuItem.Checked = false;
                bottomCenterToolStripMenuItem.Checked = false;
                bottomRightToolStripMenuItem.Checked = false;
                Invalidate();
            }
        }

        private void middleCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (middleCenterToolStripMenuItem.Checked == true)
            {
                TextAlignment = Action.TextAuraAlignmentEnum.MiddleCenter;
                topLeftToolStripMenuItem.Checked = false;
                topCenterToolStripMenuItem.Checked = false;
                topRightToolStripMenuItem.Checked = false;
                middleLeftToolStripMenuItem.Checked = false;
                middleRightToolStripMenuItem.Checked = false;
                bottomLeftToolStripMenuItem.Checked = false;
                bottomCenterToolStripMenuItem.Checked = false;
                bottomRightToolStripMenuItem.Checked = false;
                Invalidate();
            }
        }

        private void middleRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (middleRightToolStripMenuItem.Checked == true)
            {
                TextAlignment = Action.TextAuraAlignmentEnum.MiddleRight;
                topLeftToolStripMenuItem.Checked = false;
                topCenterToolStripMenuItem.Checked = false;
                topRightToolStripMenuItem.Checked = false;
                middleLeftToolStripMenuItem.Checked = false;
                middleCenterToolStripMenuItem.Checked = false;
                bottomLeftToolStripMenuItem.Checked = false;
                bottomCenterToolStripMenuItem.Checked = false;
                bottomRightToolStripMenuItem.Checked = false;
                Invalidate();
            }
        }

        private void bottomLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bottomLeftToolStripMenuItem.Checked == true)
            {
                TextAlignment = Action.TextAuraAlignmentEnum.BottomLeft;
                topLeftToolStripMenuItem.Checked = false;
                topCenterToolStripMenuItem.Checked = false;
                topRightToolStripMenuItem.Checked = false;
                middleLeftToolStripMenuItem.Checked = false;
                middleCenterToolStripMenuItem.Checked = false;
                middleRightToolStripMenuItem.Checked = false;
                bottomCenterToolStripMenuItem.Checked = false;
                bottomRightToolStripMenuItem.Checked = false;
                Invalidate();
            }
        }

        private void bottomCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bottomCenterToolStripMenuItem.Checked == true)
            {
                TextAlignment = Action.TextAuraAlignmentEnum.BottomCenter;
                topLeftToolStripMenuItem.Checked = false;
                topCenterToolStripMenuItem.Checked = false;
                topRightToolStripMenuItem.Checked = false;
                middleLeftToolStripMenuItem.Checked = false;
                middleCenterToolStripMenuItem.Checked = false;
                middleRightToolStripMenuItem.Checked = false;
                bottomLeftToolStripMenuItem.Checked = false;
                bottomRightToolStripMenuItem.Checked = false;
                Invalidate();
            }
        }

        private void bottomRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bottomRightToolStripMenuItem.Checked == true)
            {
                TextAlignment = Action.TextAuraAlignmentEnum.BottomRight;
                topLeftToolStripMenuItem.Checked = false;
                topCenterToolStripMenuItem.Checked = false;
                topRightToolStripMenuItem.Checked = false;
                middleLeftToolStripMenuItem.Checked = false;
                middleCenterToolStripMenuItem.Checked = false;
                middleRightToolStripMenuItem.Checked = false;
                bottomLeftToolStripMenuItem.Checked = false;
                bottomCenterToolStripMenuItem.Checked = false;
                Invalidate();
            }
        }

        public AuraDesignForm(AuraContainerForm.AuraTypeEnum at)
        {
            InitializeComponent();
            AuraType = at;
            switch (AuraType)
            {
                case AuraContainerForm.AuraTypeEnum.Image:
                    clickthroughPictureBox1.Visible = true;
                    break;
                case AuraContainerForm.AuraTypeEnum.Text:
                    clickthroughPictureBox1.Visible = false;
                    Brush = new SolidBrush(Color.Black);
                    break;
            }
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            Disposed += AuraDesignForm_Disposed;
            hb = new HatchBrush(HatchStyle.LargeCheckerBoard, Color.FromArgb(120, 120, 170), Color.FromArgb(150, 150, 200));
        }

        private void AuraDesignForm_Disposed(object sender, EventArgs e)
        {
            if (Brush != null)
            {
                Brush.Dispose();
                Brush = null;
            }
            hb.Dispose();
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
                    gr.DrawString("Test", AuraFont, Brush, r, sf);
                    r.Y += 2;
                    gr.DrawString("Test", AuraFont, Brush, r, sf);
                    r.Y -= 1;
                    r.X -= 1;
                    gr.DrawString("Test", AuraFont, Brush, r, sf);
                    r.X += 2;
                    gr.DrawString("Test", AuraFont, Brush, r, sf);
                    r.X -= 1;
                }
                Brush.Color = TextColor;
                gr.DrawString("Test", AuraFont, Brush, r, sf);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle r = new Rectangle(ClientRectangle.Left, ClientRectangle.Top, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            bool bl = blinky;
            g.DrawRectangle(bl == true ? Pens.Red : Pens.Yellow, r);
            r = new Rectangle(ClientRectangle.Left + 1, ClientRectangle.Top + 1, ClientRectangle.Width - 3, ClientRectangle.Height - 3);
            g.DrawRectangle(bl == true ? Pens.Red : Pens.Yellow, r);
            r = new Rectangle(ClientRectangle.Left + 2, ClientRectangle.Top + 2, ClientRectangle.Width - 5, ClientRectangle.Height - 5);
            g.DrawRectangle(bl == true ? Pens.Red : Pens.Yellow, r);
            if (AuraType == AuraContainerForm.AuraTypeEnum.Text)
            {
                PaintText(e.Graphics);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(hb, ClientRectangle);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            blinky = (blinky == false);
            Invalidate();
        }

        protected override void WndProc(ref Message message)
        {
            if (message.Msg == 0xA3)
            {
                message.Result = IntPtr.Zero;
                return;
            }
            else
            {
                base.WndProc(ref message);
            }
            if (message.Msg == 164)
            {
                contextMenuStrip1.Show(this, PointToClient(Cursor.Position));
            }
            else if (message.Msg == 0x84) // WM_NCHITTEST
            {
                var cursor = this.PointToClient(Cursor.Position);
                if (TopLeftRct.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                else if (TopRightRct.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeftRct.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRightRct.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;
                else if (TopRct.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                else if (LeftRct.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (RightRct.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (BottomRct.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
                else
                {
                    if ((int)message.Result == 0x1)
                        message.Result = (IntPtr)0x2;
                }
            }
        }

    }

}
