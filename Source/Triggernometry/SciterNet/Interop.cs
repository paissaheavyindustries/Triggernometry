using System;
using System.Runtime.InteropServices;

namespace Triggernometry.SciterNet
{

    public class Interop
    {

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {

            public int top;
            public int left;
            public int right;
            public int bottom;

        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate void LPCWSTR_RECEIVER(IntPtr str, uint str_length, IntPtr param);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate void LPCSTR_RECEIVER(IntPtr str, uint str_length, IntPtr param);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate void LPCBYTE_RECEIVER(IntPtr str, uint num_bytes, IntPtr param);

        [DllImport("sciter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr SciterAPI();

    }

}
