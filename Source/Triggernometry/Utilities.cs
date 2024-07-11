using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Triggernometry.Utilities
{
    public class WindowsUtils
    {

        [Flags]
        public enum MouseEventFlags : uint
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            //XDOWN = 0x00000080,
            //XUP = 0x00000100,
            //WHEEL = 0x00000800,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
        }

        public enum MouseEventDataXButtons : uint
        {
            NONE = 0x00000000,
            XBUTTON1 = 0x00000001,
            XBUTTON2 = 0x00000002,
        }

        const uint WM_KEYUP = 0x101;
        const uint WM_KEYDOWN = 0x100;

        public struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        const int SW_UNKNOWN = -1;
        const UInt32 SW_HIDE = 0;
        const UInt32 SW_SHOWNORMAL = 1;
        const UInt32 SW_NORMAL = 1;
        const UInt32 SW_SHOWMINIMIZED = 2;
        const UInt32 SW_SHOWMAXIMIZED = 3;
        const UInt32 SW_MAXIMIZE = 3;
        const UInt32 SW_SHOWNOACTIVATE = 4;
        const UInt32 SW_SHOW = 5;
        const UInt32 SW_MINIMIZE = 6;
        const UInt32 SW_SHOWMINNOACTIVE = 7;
        const UInt32 SW_SHOWNA = 8;
        const UInt32 SW_RESTORE = 9;

        const int SM_CXSCREEN = 0x0;
        const int SM_CYSCREEN = 0x01;

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        static extern int GetSystemMetrics(int smIndex);
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);

        public static string GetWindowTextFromHandle(IntPtr hWnd)
        {
            int len = GetWindowTextLength(hWnd);
            if (len > 0)
            {
                var builder = new StringBuilder(len + 1);
                GetWindowText(hWnd, builder, len + 1);
                return builder.ToString();
            }
            return String.Empty;
        }

        public static List<IntPtr> FindWindows(string title)
        {
            List<IntPtr> wins = new List<IntPtr>();
            if (title.Trim().Length == 0)
            {
                return wins;
            }
            Regex rex = new Regex(title);
            EnumWindows((hWnd, lParam) =>
            {
                try
                {
                    string t = GetWindowTextFromHandle(hWnd);
                    Match m = rex.Match(t);
                    if (m.Success == true)
                    {
                        wins.Add(hWnd);
                    }
                }
                catch (Exception)
                {
                }
                return true;
            }
                , IntPtr.Zero
            );
            return wins;
        }

        public static void SendMouse(MouseEventFlags flags, MouseEventDataXButtons buttons, int x, int y)
        {
            if ((flags & MouseEventFlags.ABSOLUTE) == MouseEventFlags.ABSOLUTE)
            {
                int mx = GetSystemMetrics(SM_CXSCREEN);
                int my = GetSystemMetrics(SM_CYSCREEN);
                x = (int)(65536.0 / mx * x);
                y = (int)(65536.0 / my * y);
            }
            mouse_event((uint)flags, x, y, (uint)buttons, 0);
        }

        public static void SendKeycodes(string procid, string windowtitle, params int[] keycodes)
        {
            for (int i = 0; i < keycodes.Length; i++)
            {
                SendMessageToWindow(procid, windowtitle, WM_KEYDOWN, keycodes[i], 0);
            }
            Thread.Sleep(10);
            for (int i = keycodes.Length - 1; i >= 0; i--)
            {
                SendMessageToWindow(procid, windowtitle, WM_KEYUP, keycodes[i], 0);
            }
        }

        public static void SendMessageToWindow(string procid, string windowtitle, uint code, int wparam, int lparam)
        {
            List<IntPtr> wins = FindWindows(windowtitle);
            if (wins.Count > 0)
            {
                switch (procid.Trim())
                {
                    case "-1":
                        {
                            foreach (IntPtr win in wins)
                            {
                                SendMessage(win, code, (IntPtr)wparam, (IntPtr)lparam);
                            }
                        }
                        break;
                    case "":
                    case "0":
                        {
                            SendMessage(wins[0], code, (IntPtr)wparam, (IntPtr)lparam);
                        }
                        break;
                    default:
                        {
                            uint procidnum = uint.Parse(procid);
                            uint wpid;
                            foreach (IntPtr win in wins)
                            {
                                GetWindowThreadProcessId(win, out wpid);
                                if (wpid == procidnum)
                                {
                                    SendMessage(win, code, (IntPtr)wparam, (IntPtr)lparam);
                                }
                            }
                        }
                        break;
                }
            }
        }

        public static bool IsInFocus(string windowtitle)
        {
            IntPtr hwnd = FindWindow(null, windowtitle);
            WINDOWPLACEMENT wp = new WINDOWPLACEMENT();
            wp.showCmd = SW_UNKNOWN;
            if (hwnd != IntPtr.Zero)
            {
                wp.length = Marshal.SizeOf(typeof(WINDOWPLACEMENT));
                if (GetWindowPlacement(hwnd, ref wp) == true)
                {
                    if (wp.showCmd == SW_SHOWMINIMIZED)
                    {
                        return false;
                    }
                    IntPtr hwnd2 = GetForegroundWindow();
                    return (hwnd == hwnd2);
                }
            }
            return true;
        }

    }
}
