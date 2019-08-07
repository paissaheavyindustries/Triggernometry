using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triggernometry.CustomControls
{

    public partial class ColorSelector : UserControl
    {

        public bool ChangeTextColor { get; set; }
        public Color TextColor { get; set; }

        public bool ChangeTextOutlineColor { get; set; }
        public Color TextOutlineColor { get; set; }

        public bool ChangeBackgroundColor { get; set; }
        public Color BackgroundColor { get; set; }

        private StringFormat sf = null;
        private SolidBrush Brush = null;

        public ColorSelector()
        {
            InitializeComponent();
            Disposed += ColorSelector_Disposed;
            Brush = new SolidBrush(Color.Black);
            sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
        }

        private void ColorSelector_Disposed(object sender, EventArgs e)
        {
            if (Brush != null)
            {
                Brush.Dispose();
                Brush = null;
            }
            if (sf != null)
            {
                sf.Dispose();
                sf = null;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics gr = e.Graphics;
            gr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            Rectangle r = new Rectangle(ClientRectangle.Location, ClientRectangle.Size);
            r.Width -= button1.Width;
            string smpl = I18n.Translate("internal/ColorSelector/sample", "Sample");
            if (ChangeTextOutlineColor == true)
            {
                Brush.Color = TextOutlineColor;
                r.Y -= 1;
                gr.DrawString(smpl, Font, Brush, r, sf);
                r.Y += 2;
                gr.DrawString(smpl, Font, Brush, r, sf);
                r.Y -= 1;
                r.X -= 1;
                gr.DrawString(smpl, Font, Brush, r, sf);
                r.X += 2;
                gr.DrawString(smpl, Font, Brush, r, sf);
                r.X -= 1;
            }
            if (ChangeTextColor == true)
            {
                Brush.Color = TextColor;
                gr.DrawString(smpl, Font, Brush, r, sf);
            }
        }

        private void setTextColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = TextColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                TextColor = colorDialog1.Color;
                Invalidate();
            }
        }

        private void setTextOutlineColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = TextOutlineColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                TextOutlineColor = colorDialog1.Color;
                Invalidate();
            }
        }

        private void setBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = BackgroundColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                BackgroundColor = colorDialog1.Color;
                BackColor = colorDialog1.Color;
                Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(button1, new Point(0, 0));
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            ctxSetTextColor.Visible = ChangeTextColor;
            ctxSetTextOutline.Visible = ChangeTextOutlineColor;
            ctxSetBackground.Visible = ChangeBackgroundColor;
            toolStripSeparator1.Visible = ChangeBackgroundColor;
            ctxSetBackgroundTransparent.Visible = ChangeBackgroundColor;
        }

        private void setBackgroundAsTransparentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackgroundColor = Color.Transparent;
            BackColor = Color.Transparent;
            Invalidate();
        }

    }

}
