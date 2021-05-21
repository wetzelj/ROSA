using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using HWND = System.IntPtr;

namespace ControlFinder
{
	public class WindowPointer
    {
		string WindowName;
		IntPtr WinPointer;
		List<WindowPointer> ChildWindows;

    }

    public static class Finder
    {
        //public static List<string> GetWindows()
        //{
        //    List<string> returnvalue = new List<string>();

        //    var procs = System.Diagnostics.Process.GetProcesses();

        //    foreach (Process proc in procs)
        //    {
        //        if (!String.IsNullOrEmpty(proc.MainWindowTitle))
        //        {
        //            returnvalue.Add(proc.MainWindowTitle);
        //        }

        //    }

        //    return returnvalue;
        //}

        /// <summary>
        /// Returns a list of all open windows.  
        /// https://stackoverflow.com/questions/7268302/get-the-titles-of-all-open-windows
        /// </summary>
        /// <returns></returns>
        public static IDictionary<HWND, string> GetOpenWindows() 
        {
            HWND shellWindow = GetShellWindow();
            Dictionary<HWND, string> windows = new Dictionary<HWND, string>();

            EnumWindows(delegate (HWND hWnd, int lParam)
            {
                if (hWnd == shellWindow) return true;
                if (!IsWindowVisible(hWnd)) return true;

                int length = GetWindowTextLength(hWnd);
                if (length == 0) return true;

                StringBuilder builder = new StringBuilder(length);
                GetWindowText(hWnd, builder, length + 1);

                windows[hWnd] = builder.ToString();
                return true;

            }, 0);

            return windows;
        }

        public static List<string> GetOpenWindowNames()
        {
            var windows = GetOpenWindows();
            var returnlist = windows.Select(x => x.Value).ToList();
            return returnlist;
        }

        public static HWND GetWindowHandle(string windowname)
        {
            var windows = GetOpenWindows();
            var returnpointer =  windows.Where(x => x.Value == windowname).Select(x=>x.Key).FirstOrDefault();
            return returnpointer;
        }

		public static List<IntPtr> GetWindowChildren(HWND pointer)
        {
			List<IntPtr> childHandles = new List<IntPtr>();

			GCHandle gcChildhandlesList = GCHandle.Alloc(childHandles);
			IntPtr pointerChildHandlesList = GCHandle.ToIntPtr(gcChildhandlesList);

			try
			{
				EnumWindowProc childProc = new EnumWindowProc(EnumWindows);
				EnumChildWindows(pointer, childProc, pointerChildHandlesList);
			}
			finally
			{
				
			}

			return childHandles;
		}

		public static void ChangeBackgroundColor(IntPtr pointer)
        {
			///ChangeBackgroundColor of whatever element was passed in. 
        }

		private static bool EnumWindows(IntPtr hWnd, IntPtr lParam)
		{
			GCHandle gcChildhandlesList = GCHandle.FromIntPtr(lParam);

			if (gcChildhandlesList == null || gcChildhandlesList.Target == null)
			{
				return false;
			}

			List<IntPtr> childHandles = gcChildhandlesList.Target as List<IntPtr>;
			if (childHandles != null)
			{
				childHandles.Add(hWnd);
				return true;
			}
			else 
			{
				return false;
			}
		}

		public static void TestingControls(HWND pointer)
        {
			//var test = GetAllChildrenWindowHandles(pointer, 10000, 0);
			var test1 = GetWindowChildren(pointer);
        }

        public static List<IntPtr> GetAllChildrenWindowHandles(IntPtr hParent, int maxCount, int level)
        {
			IntPtr prevChild = IntPtr.Zero;
			IntPtr currChild = IntPtr.Zero;
			while (true)
            {
				StringBuilder window = new StringBuilder();
				int length = GetWindowTextLength(hParent);
				if (length > 0)
				{
					GetWindowText(hParent, window, length + 1);
				}

				int textlength = (int)SendMessage(hParent, (int)Msgs.WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
				StringBuilder value = new StringBuilder(textlength + 1);
				if (textlength > 0)
				{
					SendMessage(hParent, (int)Msgs.WM_GETTEXT, (IntPtr)value.Capacity, value);
				}
				Debug.WriteLine(String.Format("{0} - Window: {1} - Value: {2}", level.ToString(), window.ToString(), value.ToString()));


				currChild = FindWindowEx(hParent, prevChild, null, null);
				if (currChild == IntPtr.Zero) break;


				GetAllChildrenWindowHandles(currChild, 1000, level++);
				prevChild = currChild;

			}

			//List<IntPtr> result = new List<IntPtr>();
   //         int ct = 0;
   //         string childClassWeNeed = "WindowsForms10.EDIT.app.0.";
   //         IntPtr prevChild = IntPtr.Zero;
   //         IntPtr currChild = IntPtr.Zero;
   //         while (true && ct < maxCount)
   //         {
   //             currChild = FindWindowEx(hParent, prevChild, null, null);
   //             if (currChild == IntPtr.Zero) break;


   //             StringBuilder sb = new StringBuilder(1024);
   //             GetClassName(currChild, sb, sb.Capacity);

   //             string currClass = sb.ToString();
   //             //Debug.WriteLine(currClass);
   //             //if (currClass == childClassWeNeed)
   //                 result.Add(currChild);

   //             //if (currClass.StartsWith("WindowsForms10.Window."))
   //             //{
   //                 result.AddRange(GetAllChildrenWindowHandles(currChild, 1000, level++));
   //             //}

   //             prevChild = currChild;

   //             ++ct;
   //         }
            return null;
        }

		/// <summary>
		/// Used specifically to find the children of a window.
		/// </summary>
		/// <param name="hwnd"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		private delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);

		private delegate bool EnumWindowsProc(HWND hWnd, int lParam);

		[DllImport("USER32.DLL")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowText(HWND hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowTextLength(HWND hWnd);

        [DllImport("USER32.DLL")]
        private static extern bool IsWindowVisible(HWND hWnd);

        [DllImport("USER32.DLL")]
        private static extern IntPtr GetShellWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        [DllImport("user32.dll")]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [Out] StringBuilder lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);


		/// <summary>
		/// Windows Event Messages sent to the WindowProc
		/// </summary>
		public enum Msgs
		{
			WM_NULL = 0x0000,
			WM_CREATE = 0x0001,
			WM_DESTROY = 0x0002,
			WM_MOVE = 0x0003,
			WM_SIZE = 0x0005,
			WM_ACTIVATE = 0x0006,
			WM_SETFOCUS = 0x0007,
			WM_KILLFOCUS = 0x0008,
			WM_ENABLE = 0x000A,
			WM_SETREDRAW = 0x000B,
			WM_SETTEXT = 0x000C,
			WM_GETTEXT = 0x000D,
			WM_GETTEXTLENGTH = 0x000E,
			WM_PAINT = 0x000F,
			WM_CLOSE = 0x0010,
			WM_QUERYENDSESSION = 0x0011,
			WM_QUIT = 0x0012,
			WM_QUERYOPEN = 0x0013,
			WM_ERASEBKGND = 0x0014,
			WM_SYSCOLORCHANGE = 0x0015,
			WM_ENDSESSION = 0x0016,
			WM_SHOWWINDOW = 0x0018,
			WM_WININICHANGE = 0x001A,
			WM_SETTINGCHANGE = 0x001A,
			WM_DEVMODECHANGE = 0x001B,
			WM_ACTIVATEAPP = 0x001C,
			WM_FONTCHANGE = 0x001D,
			WM_TIMECHANGE = 0x001E,
			WM_CANCELMODE = 0x001F,
			WM_SETCURSOR = 0x0020,
			WM_MOUSEACTIVATE = 0x0021,
			WM_CHILDACTIVATE = 0x0022,
			WM_QUEUESYNC = 0x0023,
			WM_GETMINMAXINFO = 0x0024,
			WM_PAINTICON = 0x0026,
			WM_ICONERASEBKGND = 0x0027,
			WM_NEXTDLGCTL = 0x0028,
			WM_SPOOLERSTATUS = 0x002A,
			WM_DRAWITEM = 0x002B,
			WM_MEASUREITEM = 0x002C,
			WM_DELETEITEM = 0x002D,
			WM_VKEYTOITEM = 0x002E,
			WM_CHARTOITEM = 0x002F,
			WM_SETFONT = 0x0030,
			WM_GETFONT = 0x0031,
			WM_SETHOTKEY = 0x0032,
			WM_GETHOTKEY = 0x0033,
			WM_QUERYDRAGICON = 0x0037,
			WM_COMPAREITEM = 0x0039,
			WM_GETOBJECT = 0x003D,
			WM_COMPACTING = 0x0041,
			WM_COMMNOTIFY = 0x0044,
			WM_WINDOWPOSCHANGING = 0x0046,
			WM_WINDOWPOSCHANGED = 0x0047,
			WM_POWER = 0x0048,
			WM_COPYDATA = 0x004A,
			WM_CANCELJOURNAL = 0x004B,
			WM_NOTIFY = 0x004E,
			WM_INPUTLANGCHANGEREQUEST = 0x0050,
			WM_INPUTLANGCHANGE = 0x0051,
			WM_TCARD = 0x0052,
			WM_HELP = 0x0053,
			WM_USERCHANGED = 0x0054,
			WM_NOTIFYFORMAT = 0x0055,
			WM_CONTEXTMENU = 0x007B,
			WM_STYLECHANGING = 0x007C,
			WM_STYLECHANGED = 0x007D,
			WM_DISPLAYCHANGE = 0x007E,
			WM_GETICON = 0x007F,
			WM_SETICON = 0x0080,
			WM_NCCREATE = 0x0081,
			WM_NCDESTROY = 0x0082,
			WM_NCCALCSIZE = 0x0083,
			WM_NCHITTEST = 0x0084,
			WM_NCPAINT = 0x0085,
			WM_NCACTIVATE = 0x0086,
			WM_GETDLGCODE = 0x0087,
			WM_SYNCPAINT = 0x0088,
			WM_NCMOUSEMOVE = 0x00A0,
			WM_NCLBUTTONDOWN = 0x00A1,
			WM_NCLBUTTONUP = 0x00A2,
			WM_NCLBUTTONDBLCLK = 0x00A3,
			WM_NCRBUTTONDOWN = 0x00A4,
			WM_NCRBUTTONUP = 0x00A5,
			WM_NCRBUTTONDBLCLK = 0x00A6,
			WM_NCMBUTTONDOWN = 0x00A7,
			WM_NCMBUTTONUP = 0x00A8,
			WM_NCMBUTTONDBLCLK = 0x00A9,
			WM_NCXBUTTONDOWN = 0x00AB,
			WM_NCXBUTTONUP = 0x00AC,
			WM_KEYDOWN = 0x0100,
			WM_KEYUP = 0x0101,
			WM_CHAR = 0x0102,
			WM_DEADCHAR = 0x0103,
			WM_SYSKEYDOWN = 0x0104,
			WM_SYSKEYUP = 0x0105,
			WM_SYSCHAR = 0x0106,
			WM_SYSDEADCHAR = 0x0107,
			WM_KEYLAST = 0x0108,
			WM_IME_STARTCOMPOSITION = 0x010D,
			WM_IME_ENDCOMPOSITION = 0x010E,
			WM_IME_COMPOSITION = 0x010F,
			WM_IME_KEYLAST = 0x010F,
			WM_INITDIALOG = 0x0110,
			WM_COMMAND = 0x0111,
			WM_SYSCOMMAND = 0x0112,
			WM_TIMER = 0x0113,
			WM_HSCROLL = 0x0114,
			WM_VSCROLL = 0x0115,
			WM_INITMENU = 0x0116,
			WM_INITMENUPOPUP = 0x0117,
			WM_MENUSELECT = 0x011F,
			WM_MENUCHAR = 0x0120,
			WM_ENTERIDLE = 0x0121,
			WM_MENURBUTTONUP = 0x0122,
			WM_MENUDRAG = 0x0123,
			WM_MENUGETOBJECT = 0x0124,
			WM_UNINITMENUPOPUP = 0x0125,
			WM_MENUCOMMAND = 0x0126,
			WM_CTLCOLORMSGBOX = 0x0132,
			WM_CTLCOLOREDIT = 0x0133,
			WM_CTLCOLORLISTBOX = 0x0134,
			WM_CTLCOLORBTN = 0x0135,
			WM_CTLCOLORDLG = 0x0136,
			WM_CTLCOLORSCROLLBAR = 0x0137,
			WM_CTLCOLORSTATIC = 0x0138,
			WM_MOUSEMOVE = 0x0200,
			WM_LBUTTONDOWN = 0x0201,
			WM_LBUTTONUP = 0x0202,
			WM_LBUTTONDBLCLK = 0x0203,
			WM_RBUTTONDOWN = 0x0204,
			WM_RBUTTONUP = 0x0205,
			WM_RBUTTONDBLCLK = 0x0206,
			WM_MBUTTONDOWN = 0x0207,
			WM_MBUTTONUP = 0x0208,
			WM_MBUTTONDBLCLK = 0x0209,
			WM_MOUSEWHEEL = 0x020A,
			WM_XBUTTONDOWN = 0x020B,
			WM_XBUTTONUP = 0x020C,
			WM_XBUTTONDBLCLK = 0x020D,
			WM_PARENTNOTIFY = 0x0210,
			WM_ENTERMENULOOP = 0x0211,
			WM_EXITMENULOOP = 0x0212,
			WM_NEXTMENU = 0x0213,
			WM_SIZING = 0x0214,
			WM_CAPTURECHANGED = 0x0215,
			WM_MOVING = 0x0216,
			WM_DEVICECHANGE = 0x0219,
			WM_MDICREATE = 0x0220,
			WM_MDIDESTROY = 0x0221,
			WM_MDIACTIVATE = 0x0222,
			WM_MDIRESTORE = 0x0223,
			WM_MDINEXT = 0x0224,
			WM_MDIMAXIMIZE = 0x0225,
			WM_MDITILE = 0x0226,
			WM_MDICASCADE = 0x0227,
			WM_MDIICONARRANGE = 0x0228,
			WM_MDIGETACTIVE = 0x0229,
			WM_MDISETMENU = 0x0230,
			WM_ENTERSIZEMOVE = 0x0231,
			WM_EXITSIZEMOVE = 0x0232,
			WM_DROPFILES = 0x0233,
			WM_MDIREFRESHMENU = 0x0234,
			WM_IME_SETCONTEXT = 0x0281,
			WM_IME_NOTIFY = 0x0282,
			WM_IME_CONTROL = 0x0283,
			WM_IME_COMPOSITIONFULL = 0x0284,
			WM_IME_SELECT = 0x0285,
			WM_IME_CHAR = 0x0286,
			WM_IME_REQUEST = 0x0288,
			WM_IME_KEYDOWN = 0x0290,
			WM_IME_KEYUP = 0x0291,
			WM_MOUSEHOVER = 0x02A1,
			WM_MOUSELEAVE = 0x02A3,
			WM_CUT = 0x0300,
			WM_COPY = 0x0301,
			WM_PASTE = 0x0302,
			WM_CLEAR = 0x0303,
			WM_UNDO = 0x0304,
			WM_RENDERFORMAT = 0x0305,
			WM_RENDERALLFORMATS = 0x0306,
			WM_DESTROYCLIPBOARD = 0x0307,
			WM_DRAWCLIPBOARD = 0x0308,
			WM_PAINTCLIPBOARD = 0x0309,
			WM_VSCROLLCLIPBOARD = 0x030A,
			WM_SIZECLIPBOARD = 0x030B,
			WM_ASKCBFORMATNAME = 0x030C,
			WM_CHANGECBCHAIN = 0x030D,
			WM_HSCROLLCLIPBOARD = 0x030E,
			WM_QUERYNEWPALETTE = 0x030F,
			WM_PALETTEISCHANGING = 0x0310,
			WM_PALETTECHANGED = 0x0311,
			WM_HOTKEY = 0x0312,
			WM_PRINT = 0x0317,
			WM_PRINTCLIENT = 0x0318,
			WM_HANDHELDFIRST = 0x0358,
			WM_HANDHELDLAST = 0x035F,
			WM_AFXFIRST = 0x0360,
			WM_AFXLAST = 0x037F,
			WM_PENWINFIRST = 0x0380,
			WM_PENWINLAST = 0x038F,
			WM_APP = 0x8000,
			WM_USER = 0x0400,

			// For Windows XP Balloon messages from the System Notification Area
			NIN_BALLOONSHOW = 0x0402,
			NIN_BALLOONHIDE = 0x0403,
			NIN_BALLOONTIMEOUT = 0x0404,
			NIN_BALLOONUSERCLICK = 0x0405
		}

	}
}
