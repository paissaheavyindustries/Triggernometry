using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Triggernometry.CustomControls
{

    public partial class TreeViewEx : TreeView
    {

        // Pinvoke:
        private const int TVM_SETEXTENDEDSTYLE = 0x1100 + 44;
        private const int TVM_GETEXTENDEDSTYLE = 0x1100 + 45;
        private const int TVS_EX_DOUBLEBUFFER = 0x0004;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        protected override void OnHandleCreated(EventArgs e)
        {
            SendMessage(this.Handle, TVM_SETEXTENDEDSTYLE, (IntPtr)TVS_EX_DOUBLEBUFFER, (IntPtr)TVS_EX_DOUBLEBUFFER);
            base.OnHandleCreated(e);
        }

        public TreeViewEx()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x203) // identified double click
            {
                var localPos = PointToClient(Cursor.Position);
                var hitTestInfo = HitTest(localPos);
                if (hitTestInfo.Location == TreeViewHitTestLocations.StateImage)
                {
                    m.Msg = 0x201; // lmb down
                    base.WndProc(ref m);
                    return;
                }
            }
            base.WndProc(ref m);
        }

    }

}
