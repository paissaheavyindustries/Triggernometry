using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triggernometry.CustomControls
{

    public partial class MenuButton : RadioButton
    {

        public TabControl TabControl { get; set; } = null;
        public int TabNumber { get; set; } = 0;
        public string IconCharacter { get; set; } = "";
        public Font IconFont { get; set; } = null;

        private StringFormat _sf = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
        private bool _Hovering = false;
        private bool Hovering
        {
            get
            {
                return _Hovering;
            }
            set
            {
                if (_Hovering != value)
                {
                    _Hovering = value;
                    Invalidate();
                }
            }
        }

        public MenuButton()
        {
            InitializeComponent();
            ForeColor = SystemColors.HighlightText;
            BackColor = SystemColors.WindowFrame;
            FlatStyle = FlatStyle.Flat;
            Appearance = Appearance.Button;
            Dock = DockStyle.Top;
            AutoSize = false;
            Height = 40;
            Disposed += MenuButton_Disposed;
            MouseEnter += MenuButton_MouseEnter;
            MouseLeave += MenuButton_MouseLeave;
        }

        private void MenuButton_MouseLeave(object sender, EventArgs e)
        {
            Hovering = false;
        }

        private void MenuButton_MouseEnter(object sender, EventArgs e)
        {
            Hovering = true;
        }

        private void MenuButton_Disposed(object sender, EventArgs e)
        {
            if (_sf != null)
            {
                _sf.Dispose();
                _sf = null;
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics gr = pevent.Graphics;
            Brush br;
            if (Checked == true)
            {
                br = SystemBrushes.MenuHighlight;
            }
            else if (Hovering == true)
            {
                br = SystemBrushes.HotTrack;
            }
            else
            {
                br = SystemBrushes.WindowFrame;
            }
            gr.FillRectangle(br, pevent.ClipRectangle);
            if (Image != null)
            {
                Rectangle cr = new Rectangle(ClientRectangle.X + (20 + Image.Width), ClientRectangle.Y, ClientRectangle.Width - (20 + Image.Width), ClientRectangle.Height);
                gr.DrawString(Text, Font, SystemBrushes.HighlightText, cr, _sf);
                gr.DrawImage(Image, 10, (ClientRectangle.Height / 2) - (Image.Height / 2));
            }
            else if (IconCharacter != "" && IconFont != null)
            {
                int fs = (int)Math.Ceiling(IconFont.SizeInPoints);
                Rectangle cr = new Rectangle(ClientRectangle.X + (15 + fs), ClientRectangle.Y, ClientRectangle.Width - (15 + fs), ClientRectangle.Height);
                gr.DrawString(Text, Font, SystemBrushes.HighlightText, cr, _sf);
                cr = new Rectangle(ClientRectangle.X + 10, ClientRectangle.Y, fs, ClientRectangle.Height);
                _sf.Alignment = StringAlignment.Center;
                gr.DrawString(IconCharacter, IconFont, SystemBrushes.HighlightText, cr, _sf);
                _sf.Alignment = StringAlignment.Near;
            }
            else 
            {
                Rectangle cr = new Rectangle(ClientRectangle.X + 10, ClientRectangle.Y, ClientRectangle.Width - 10, ClientRectangle.Height);
                gr.DrawString(Text, Font, SystemBrushes.HighlightText, cr, _sf);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {            
        }

    }

}
