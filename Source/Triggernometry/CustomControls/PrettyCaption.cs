using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Triggernometry.CustomControls
{

    public partial class PrettyCaption : UserControl
    {

        private LinearGradientBrush br = null;

        private Color _CaptionHighlightColor;
        public Color CaptionHighlightColor
        {
            get
            {
                return _CaptionHighlightColor;
            }
            set
            {
                if (_CaptionHighlightColor != value)
                {
                    _CaptionHighlightColor = value;
                    RecreateBrush(true);
                    Invalidate();
                }
            }
        }

        private Color _CaptionShadowColor;
        public Color CaptionShadowColor
        {
            get
            {
                return _CaptionShadowColor;
            }
            set
            {
                if (_CaptionShadowColor != value)
                {
                    _CaptionShadowColor = value;
                    RecreateBrush(true);
                    Invalidate();
                }
            }
        }

        public string Caption
        {
            get
            {
                return lblContent.Text;
            }
            set
            {
                lblContent.Text = value;
            }
        }

        public PrettyCaption()
        {
            InitializeComponent();
            _CaptionHighlightColor = SystemColors.GradientInactiveCaption;
            _CaptionShadowColor = SystemColors.GradientActiveCaption;
            RecreateBrush(false);
            Disposed += new EventHandler(PrettyCaption_Disposed);
            Resize += new EventHandler(PrettyCaption_Resize);
            DoubleBuffered = true;
        }

        void PrettyCaption_Resize(object sender, EventArgs e)
        {
            RecreateBrush(false);
        }

        void RecreateBrush(bool colorChange)
        {
            if (br != null)
            {
                if (br.Rectangle.Height == Height && colorChange == false)
                {
                    return;
                }
                br.Dispose();
                br = null;
            }
            br = new LinearGradientBrush(new Rectangle(0, 0, 20, Height), CaptionShadowColor, CaptionHighlightColor, 270.0f);
        }

        void PrettyCaption_Disposed(object sender, EventArgs e)
        {
            if (br != null)
            {
                br.Dispose();
                br = null;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.FillRectangle(br, e.ClipRectangle);
        }

    }

}
