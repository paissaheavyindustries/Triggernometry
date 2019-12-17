using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triggernometry.Forms
{

    public partial class testi : Form
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
                base.WndProc(ref m);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x08000000; // ws_ex_noactivate
                //createParams.ExStyle |= 0x80000; // layered
                createParams.ExStyle |= 0x20; // no hit test
                createParams.ExStyle |= 0x80; // parent dc / hide from alt tab
                createParams.ExStyle |= 0x00000008; // topmost
                return createParams;
            }
        }

        public testi()
        {
            InitializeComponent(); 
            TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel htmlPanel = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            htmlPanel.Text = "<p><h1>Hello World</h1>This is html rendered text</p><img src='C:/Users/Moskau/AppData/Roaming/Advanced Combat Tracker/Config/TriggernometryRemoteImages/eb1888cce428cd451d039b0dc03ca9aa.png' /></p><img src='C:/Users/Moskau/AppData/Roaming/Advanced Combat Tracker/Config/TriggernometryRemoteImages/dd99012d2fb7540b7cfc70456b729fca.gif' />";
            htmlPanel.Dock = DockStyle.Fill;
            htmlPanel.IsContextMenuEnabled = false;
            Controls.Add(htmlPanel);
        }

    }

}
