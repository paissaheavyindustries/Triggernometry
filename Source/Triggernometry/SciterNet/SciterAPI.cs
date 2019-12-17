using System;
using System.Runtime.InteropServices;

namespace Triggernometry.SciterNet
{

    [StructLayout(LayoutKind.Sequential)]
    public class SciterAPI
    {

        [Flags]
        public enum SCITER_CREATE_WINDOW_FLAGS
        {
            SW_CHILD = (1 << 0), // child window only, if this flag is set all other flags ignored
            SW_TITLEBAR = (1 << 1), // toplevel window, has titlebar
            SW_RESIZEABLE = (1 << 2), // has resizeable frame
            SW_TOOL = (1 << 3), // is tool window
            SW_CONTROLS = (1 << 4), // has minimize / maximize buttons
            SW_GLASSY = (1 << 5), // glassy window - supports "Acrylic" on Windows and "Vibrant" on MacOS. 
            SW_ALPHA = (1 << 6), // transparent window ( e.g. WS_EX_LAYERED on Windows )
            SW_MAIN = (1 << 7), // main window of the app, will terminate the app on close
            SW_POPUP = (1 << 8), // the window is created as topmost window.
            SW_ENABLE_DEBUG = (1 << 9), // make this window inspector ready
            SW_OWNS_VM = (1 << 10), // it has its own script VM
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate IntPtr _D_SciterClassName();
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate uint _D_SciterVersion(int major);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate int _D_SciterDataReady(IntPtr hwnd, IntPtr uri, byte data, uint dataLength);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate int _D_SciterDataReadyAsync(IntPtr hwnd, IntPtr uri, byte data, uint dataLength, IntPtr requestId);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate void _D_Dummy();
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate int _D_SciterLoadFile(IntPtr hWndSciter, IntPtr filename);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate int _D_SciterLoadHtml(IntPtr hWndSciter, byte[] html, uint htmlSize, IntPtr baseUrl);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate IntPtr _D_GetSciterGraphicsAPI();
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate IntPtr _D_GetSciterRequestAPI();
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] public delegate IntPtr _D_SciterCreateWindow(SCITER_CREATE_WINDOW_FLAGS creationFlags, IntPtr frame, IntPtr delegateProc, IntPtr delegateParam, IntPtr parent);

        public uint version;

        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_SciterClassName SciterClassName;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_SciterVersion SciterVersion;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_SciterDataReady SciterDataReady;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_SciterDataReadyAsync SciterDataReadyAsync;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterProc;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterProcND;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_SciterLoadFile SciterLoadFile;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_SciterLoadHtml SciterLoadHtml;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSetCallback;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSetMasterCSS;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterAppendMasterCSS;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSetCSS;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSetMediaType;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSetMediaVars;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetMinWidth;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetMinHeight;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterCall;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterEval;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterUpdateWindow;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterTranslateMessage;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSetOption;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetPPI;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetViewExpando;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterRenderD2D;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterD2DFactory;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterDWFactory;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGraphicsCaps;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSetHomeURL;
        //[MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterCreateNSView; OSX
        //[MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterCreateWidget; LINUX
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_SciterCreateWindow SciterCreateWindow;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSetupDebugOutput;

        // DOM Element API

        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy Sciter_UseElement;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy Sciter_UnuseElement;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetRootElement;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetFocusElement;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterFindElement;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetChildrenCount;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetNthChild;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetParentElement;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetElementHtmlCB;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetElementTextCB;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSetElementText;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetAttributeCount;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetNthAttributeNameCB;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetNthAttributeValueCB;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetAttributeByNameCB;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSetAttributeByName;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterClearAttributes;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetElementIndex;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetElementType;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetElementTypeCB;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetStyleAttributeCB;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSetStyleAttribute;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetElementLocation;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterScrollToView;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterUpdateElement;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterRefreshElementArea;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSetCapture;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterReleaseCapture;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetElementHwnd;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterCombineURL;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSelectElements;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSelectElementsW;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSelectParent;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSelectParentW;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSetElementHtml;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetElementUID;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetElementByUID;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterShowPopup;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterShowPopupAt;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterHidePopup;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetElementState;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSetElementState;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterCreateElement;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterCloneElement;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterInsertElement;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterDetachElement;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterDeleteElement;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSetTimer;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterDetachEventHandler;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterAttachEventHandler;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterWindowAttachEventHandler;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterWindowDetachEventHandler;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSendEvent;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterPostEvent;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterCallBehaviorMethod;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterRequestElementData;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterHttpRequest;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetScrollInfo;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSetScrollPos;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetElementIntrinsicWidths;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetElementIntrinsicHeight;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterIsElementVisible;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterIsElementEnabled;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSortElements;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSwapElements;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterTraverseUIEvent;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterCallScriptingMethod;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterCallScriptingFunction;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterEvalElementScript;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterAttachHwndToElement;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterControlGetType;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetValue;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSetValue;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetExpando;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetObject;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetElementNamespace;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetHighlightedElement;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterSetHighlightedElement;

        // DOM Node API

        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterNodeAddRef;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterNodeRelease;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterNodeCastFromElement;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterNodeCastToElement;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterNodeFirstChild;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterNodeLastChild;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterNodeNextSibling;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterNodePrevSibling;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterNodeParent;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterNodeNthChild;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterNodeChildrenCount;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterNodeType;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterNodeGetText;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterNodeSetText;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterNodeInsert;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterNodeRemove;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterCreateTextNode;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterCreateCommentNode;

        // Value API

        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueInit;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueClear;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueCompare;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueCopy;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueIsolate;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueType;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueStringData;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueStringDataSet;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueIntData;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueIntDataSet;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueInt64Data;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueInt64DataSet;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueFloatData;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueFloatDataSet;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueBinaryData;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueBinaryDataSet;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueElementsCount;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueNthElementValue;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueNthElementValueSet;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueNthElementKey;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueEnumElements;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueSetValueToKey;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueGetValueOfKey;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueToString;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueFromString;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueInvoke;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueNativeFunctorSet;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy ValueIsNativeFunctor;

        // tiscript VM API

        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy TIScriptAPI;

        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetVM;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy Sciter_v2V;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy Sciter_V2v;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterOpenArchive;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetArchiveItem;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterCloseArchive;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterFireEvent;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterGetCallbackParam;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterPostCallback;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_GetSciterGraphicsAPI GetSciterGraphicsAPI;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_GetSciterRequestAPI GetSciterRequestAPI;

        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterCreateOnDirectXWindow;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterRenderOnDirectXWindow;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterRenderOnDirectXTexture;
        [MarshalAs(UnmanagedType.FunctionPtr)] public _D_Dummy SciterProcX;


    }

}
