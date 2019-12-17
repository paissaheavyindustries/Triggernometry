using System;
using System.Runtime.InteropServices;
using static Triggernometry.SciterNet.Interop;

namespace Triggernometry.SciterNet
{

    [StructLayout(LayoutKind.Sequential)]
    public class SciterRequestAPI
    {

        public enum REQUEST_RESULT
        {
            REQUEST_PANIC = -1, // e.g. not enough memory
            REQUEST_OK = 0,
            REQUEST_BAD_PARAM = 1,  // bad parameter
            REQUEST_FAILURE = 2,    // operation failed, e.g. index out of bounds
            REQUEST_NOTSUPPORTED = 3 // the platform does not support requested feature
        }

        public enum REQUEST_RQ_TYPE
        {
            RRT_GET = 1,
            RRT_POST = 2,
            RRT_PUT = 3,
            RRT_DELETE = 4,
            RRT_FORCE_DWORD = -1 //0xffffffff
        }

        public enum SciterResourceType
        {
            RT_DATA_HTML = 0,
            RT_DATA_IMAGE = 1,
            RT_DATA_STYLE = 2,
            RT_DATA_CURSOR = 3,
            RT_DATA_SCRIPT = 4,
            RT_DATA_RAW = 5,
            RT_DATA_FONT,
            RT_DATA_SOUND,    // wav bytes
            RT_DATA_FORCE_DWORD = -1 //0xffffffff
        }

        public enum REQUEST_STATE
        {
            RS_PENDING = 0,
            RS_SUCCESS = 1, // completed successfully
            RS_FAILURE = 2, // completed with failure
            RS_FORCE_DWORD = -1 // 0xffffffff
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestUse(IntPtr rq);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestUnUse(IntPtr rq);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestUrl(IntPtr rq, LPCSTR_RECEIVER rcv, IntPtr rcv_param);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestContentUrl(IntPtr rq, LPCSTR_RECEIVER rcv, IntPtr rcv_param);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestGetRequestType(IntPtr rq, IntPtr pType);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestGetRequestedDataType(IntPtr rq, IntPtr pData);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestGetReceivedDataType(IntPtr rq, LPCSTR_RECEIVER rcv, IntPtr rcv_param);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestGetNumberOfParameters(IntPtr rq, IntPtr pNumber);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestGetNthParameterName(IntPtr rq, uint n, LPCWSTR_RECEIVER rcv, IntPtr rcv_param);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestGetNthParameterValue(IntPtr rq, uint n, LPCWSTR_RECEIVER rcv, IntPtr rcv_param);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestGetTimes(IntPtr rq, IntPtr pStarted, IntPtr pEnded);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestGetNumberOfRqHeaders(IntPtr rq, IntPtr pNumber);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestGetNthRqHeaderName(IntPtr rq, uint n, LPCWSTR_RECEIVER rcv, IntPtr rcv_param);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestGetNthRqHeaderValue(IntPtr rq, uint n, LPCWSTR_RECEIVER rcv, IntPtr rcv_param);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestGetNumberOfRspHeaders(IntPtr rq, IntPtr pNumber);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestGetNthRspHeaderName(IntPtr rq, uint n, LPCWSTR_RECEIVER rcv, IntPtr rcv_param);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestGetNthRspHeaderValue(IntPtr rq, uint n, LPCWSTR_RECEIVER rcv, IntPtr rcv_param);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestGetCompletionStatus(IntPtr rq, IntPtr pState, IntPtr pCompletionStatus);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestGetProxyHost(IntPtr rq, LPCSTR_RECEIVER rcv, IntPtr rcv_param);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestGetProxyPort(IntPtr rq, IntPtr pNumber);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestSetSucceeded(IntPtr rq, uint status, IntPtr dataOrNull, uint dataLength);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestSetFailed(IntPtr rq, uint status, IntPtr dataOrNull, uint dataLength);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestAppendDataChunk(IntPtr rq, IntPtr data, uint dataLength);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestSetRqHeader(IntPtr rq, IntPtr name, IntPtr value);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestSetRspHeader(IntPtr rq, IntPtr name, IntPtr value);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestSetReceivedDataType(IntPtr rq, IntPtr type);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestSetReceivedDataEncoding(IntPtr rq, IntPtr encoding);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate REQUEST_RESULT _D_RequestGetData(IntPtr rq, LPCBYTE_RECEIVER rcv, IntPtr rcv_param);

        [StructLayout(LayoutKind.Sequential)]
        public struct ISciterRequestAPI
        {

            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestUse RequestUse;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestUnUse RequestUnUse;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestUrl RequestUrl;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestContentUrl RequestContentUrl;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestGetRequestType RequestGetRequestType;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestGetRequestedDataType RequestGetRequestedDataType;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestGetReceivedDataType RequestGetReceivedDataType;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestGetNumberOfParameters RequestGetNumberOfParameters;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestGetNthParameterName RequestGetNthParameterName;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestGetNthParameterValue RequestGetNthParameterValue;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestGetTimes RequestGetTimes;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestGetNumberOfRqHeaders RequestGetNumberOfRqHeaders;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestGetNthRqHeaderName RequestGetNthRqHeaderName;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestGetNthRqHeaderValue RequestGetNthRqHeaderValue;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestGetNumberOfRspHeaders RequestGetNumberOfRspHeaders;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestGetNthRspHeaderName RequestGetNthRspHeaderName;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestGetNthRspHeaderValue RequestGetNthRspHeaderValue;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestGetCompletionStatus RequestGetCompletionStatus;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestGetProxyHost RequestGetProxyHost;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestGetProxyPort RequestGetProxyPort;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestSetSucceeded RequestSetSucceeded;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestSetFailed RequestSetFailed;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestAppendDataChunk RequestAppendDataChunk;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestSetRqHeader RequestSetRqHeader;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestSetRspHeader RequestSetRspHeader;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestSetReceivedDataType RequestSetReceivedDataType;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestSetReceivedDataEncoding RequestSetReceivedDataEncoding;
            [MarshalAs(UnmanagedType.FunctionPtr)] public _D_RequestGetData RequestGetData;

        }

    }

}
