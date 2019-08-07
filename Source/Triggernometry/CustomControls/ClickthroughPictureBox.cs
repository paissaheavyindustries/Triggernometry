using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triggernometry.CustomControls
{

    public partial class ClickthroughPictureBox : PictureBox
    {

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
                try
                {
                    base.WndProc(ref m);
                }
                catch (Exception)
                {
                }
            }
        }

        public ClickthroughPictureBox()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

    }

}
