using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RosaTEST
{
	public class ROSAEvent : EventArgs
	{
		public string EventName;
		public string EventSender;
		
		public string PatientID;
		public string Accession;
		public string StudyDate;
		public string StudyUID;
	}

	public partial class Form1 : Form
	{
		IntPtr _ClipboardViewerNext;
		Queue _hyperlink = new Queue();
		bool IsClipMonON = false;
		static string appSuffix = "";

		event EventHandler ContextChanged;


		public Form1()
		{
			InitializeComponent();
		}
		


		private void Form1_Load(object sender, EventArgs e)
		{
			Rectangle workingArea = Screen.GetWorkingArea(this);
			this.Location = new Point(workingArea.Right - Size.Width,
									  workingArea.Bottom - Size.Height);

			WinAPI.UseImmersiveDarkMode(this.Handle, true);
		}

		protected override void WndProc(ref Message m)
		{
			switch ((WinAPI.Msgs)m.Msg)
			{
				//
				// The WM_DRAWCLIPBOARD message is sent to the first window 
				// in the clipboard viewer chain when the content of the 
				// clipboard changes. This enables a clipboard viewer 
				// window to display the new content of the clipboard. 
				//
				case WinAPI.Msgs.WM_DRAWCLIPBOARD:

					//Debug.WriteLine("WindowProc DRAWCLIPBOARD: " + m.Msg, "WndProc");

					GetClipboardData();
					Debug.WriteLine("clipmon-done");
					//
					// Each window that receives the WM_DRAWCLIPBOARD message 
					// must call the SendMessage function to pass the message 
					// on to the next window in the clipboard viewer chain.
					//
					WinAPI.SendMessage(_ClipboardViewerNext, m.Msg, m.WParam, m.LParam);
					break;


				//
				// The WM_CHANGECBCHAIN message is sent to the first window 
				// in the clipboard viewer chain when a window is being 
				// removed from the chain. 
				//
				case WinAPI.Msgs.WM_CHANGECBCHAIN:
					//Debug.WriteLine("WM_CHANGECBCHAIN: lParam: " + m.LParam, "WndProc");

					// When a clipboard viewer window receives the WM_CHANGECBCHAIN message, 
					// it should call the SendMessage function to pass the message to the 
					// next window in the chain, unless the next window is the window 
					// being removed. In this case, the clipboard viewer should save 
					// the handle specified by the lParam parameter as the next window in the chain. 

					//
					// wParam is the Handle to the window being removed from 
					// the clipboard viewer chain 
					// lParam is the Handle to the next window in the chain 
					// following the window being removed. 
					if (m.WParam == _ClipboardViewerNext)
					{
						//
						// If wParam is the next clipboard viewer then it
						// is being removed so update pointer to the next
						// window in the clipboard chain
						//
						_ClipboardViewerNext = m.LParam;
					}
					else
					{
						WinAPI.SendMessage(_ClipboardViewerNext, m.Msg, m.WParam, m.LParam);
					}
					break;

				default:
					//
					// Let the form process the messages that we are
					// not interested in
					//
					base.WndProc(ref m);
					break;

			}

		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void btnEnuWins_Click(object sender, EventArgs e)
		{
			//ArrayList wins = GetWindows();
			//Debug.WriteLine(wins.Count);
			IntPtr hWndIMPAX = SearchForWindow("WindowsForms", "IMPAX");

		}
		//public static ArrayList GetWindows()
		//{
		//	ArrayList windowHandles = new ArrayList();
		//	Win32.EnumedWindow callBackPtr = GetWindowHandle;
		//	Win32.User32.EnumWindows(callBackPtr, windowHandles);

		//	return windowHandles;
		//}

		//private static bool GetWindowHandle(IntPtr windowHandle, ArrayList windowHandles)
		//{
		//	//var lpString = new StringBuilder(512);
		//	//User32.GetClassName(hwnd, lpString, lpString.Capacity);
		//	windowHandles.Add(windowHandle);
		//	return true;
		//}

		public static IntPtr SearchForWindow(string wndclass, string title)
		{
			SearchData sd = new SearchData { Wndclass = wndclass, Title = title,hWnd=IntPtr.Zero };
			WinAPI.EnumWindows(new EnumWindowsProc(EnumProc), ref sd);
			return sd.hWnd;
		}
		public static bool EnumProc(IntPtr hWnd, ref SearchData data)
		{
			// Check classname and title
			// This is different from FindWindow() in that the code below allows partial matches
			StringBuilder sb = new StringBuilder(1024);
			WinAPI.GetClassName(hWnd, sb, sb.Capacity);

			string wClass = sb.ToString();
			
			sb = new StringBuilder(1024);
			WinAPI.GetWindowText(hWnd, sb, sb.Capacity);
			string wTitle = sb.ToString();
			//Debug.WriteLine($"[{wClass}]:{wTitle}");
			
			if (wTitle.StartsWith(data.Title) && wClass.StartsWith(data.Wndclass))
			{
				data.Wndclass = wClass;
				appSuffix = wClass.Substring(wClass.LastIndexOf(".0.") + 3);
				data.hWnd = hWnd;
				return false;    // Found the wnd, halt enumeration
			}
			return true;
			/*
			if (sb.ToString().StartsWith(data.Wndclass))
			{
				sb = new StringBuilder(1024);
				Win32.User32.GetWindowText(hWnd, sb, sb.Capacity);

				if (sb.ToString().StartsWith(data.Title))
				{
					data.hWnd = hWnd;
					return false;    // Found the wnd, halt enumeration
				}
			}
			return true;*/
		}
		/*
				public static IReadOnlyList<int> ListWindows()
				{
					var windowList = new List<int>();
					User32.EnumWindows(OnWindowEnum, 0);
					return windowList;

					bool OnWindowEnum(int hwnd, int lparam)
					{
						// you can add some conditions here.
						windowList.Add(hwnd);
						return true;
					}
				}

				public static IReadOnlyList<int> FindWindowByClassName(string className)
				{
					var windowList = new List<int>();
					User32.EnumWindows(OnWindowEnum, 0);
					return windowList;

					bool OnWindowEnum(int hwnd, int lparam)
					{
						var lpString = new StringBuilder(512);
						User32.GetClassName(hwnd, lpString, lpString.Capacity);
						if (lpString.ToString().Equals(className, StringComparison.InvariantCultureIgnoreCase))
						{
							windowList.Add(hwnd);
						}

						return true;
					}
				}*/

		private void btnClipMon_Click(object sender, EventArgs e)
		{
			if (!IsClipMonON)
			{
				RegisterClipboardViewer();
				IsClipMonON = true;
				btnClipMon.Text = "ClipMon-ON";
			}
			else
			{
				UnregisterClipboardViewer();
				IsClipMonON = false;
				btnClipMon.Text = "ClipMon-OFF";
			}
		}


		#region ClipMon

		/// <summary>
		/// Register this form as a Clipboard Viewer application
		/// </summary>
		private void RegisterClipboardViewer()
		{
			_ClipboardViewerNext = WinAPI.SetClipboardViewer(this.Handle);
		}

		/// <summary>
		/// Remove this form from the Clipboard Viewer list
		/// </summary>
		private void UnregisterClipboardViewer()
		{
			WinAPI.ChangeClipboardChain(this.Handle, _ClipboardViewerNext);
		}

		///// <summary>
		///// Build a menu listing the formats supported by the contents of the clipboard
		///// </summary>
		///// <param name="iData">The current clipboard data object</param>
		//private void FormatMenuBuild(IDataObject iData)
		//{
		//	string[] astrFormatsNative = iData.GetFormats(false);
		//	string[] astrFormatsAll = iData.GetFormats(true);

		//	Hashtable formatList = new Hashtable(10);

		//	mnuFormats.MenuItems.Clear();

		//	for (int i = 0; i <= astrFormatsAll.GetUpperBound(0); i++)
		//	{
		//		formatList.Add(astrFormatsAll[i], "Converted");
		//	}

		//	for (int i = 0; i <= astrFormatsNative.GetUpperBound(0); i++)
		//	{
		//		if (formatList.Contains(astrFormatsNative[i]))
		//		{
		//			formatList[astrFormatsNative[i]] = "Native/Converted";
		//		}
		//		else
		//		{
		//			formatList.Add(astrFormatsNative[i], "Native");
		//		}
		//	}

		//	foreach (DictionaryEntry item in formatList)
		//	{
		//		MenuItem itmNew = new MenuItem(item.Key.ToString() + "\t" + item.Value.ToString());
		//		mnuFormats.MenuItems.Add(itmNew);
		//	}
		//}

		///// <summary>
		///// list the formats that are supported from the default clipboard formats.
		///// </summary>
		///// <param name="iData">The current clipboard contents</param>
		//private void SupportedMenuBuild(IDataObject iData)
		//{
		//	mnuSupported.MenuItems.Clear();

		//	for (int i = 0; i <= formatsAll.GetUpperBound(0); i++)
		//	{
		//		MenuItem itmFormat = new MenuItem(formatsAllDesc[i]);
		//		//
		//		// Get supported formats
		//		//
		//		if (iData.GetDataPresent(formatsAll[i]))
		//		{
		//			itmFormat.Checked = true;
		//		}
		//		mnuSupported.MenuItems.Add(itmFormat);

		//	}
		//}

		/// <summary>
		/// Search the clipboard contents for hyperlinks and unc paths, etc
		/// </summary>
		/// <param name="iData">The current clipboard contents</param>
		/// <returns>true if new links were found, false otherwise</returns>
		private bool ClipboardSearch(IDataObject iData)
		{
			bool FoundNewLinks = false;
			//
			// If it is not text then quit
			// cannot search bitmap etc
			//
			if (!iData.GetDataPresent(DataFormats.Text))
			{
				return false;
			}

			string strClipboardText;

			try
			{
				strClipboardText = (string)iData.GetData(DataFormats.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}

			// Hyperlinks e.g. http://www.server.com/folder/file.aspx
			Regex rxURL = new Regex(@"(\b(?:http|https|ftp|file)://[^\s]+)", RegexOptions.IgnoreCase);
			rxURL.Match(strClipboardText);

			foreach (Match rm in rxURL.Matches(strClipboardText))
			{
				if (!_hyperlink.Contains(rm.ToString()))
				{
					_hyperlink.Enqueue(rm.ToString());
					FoundNewLinks = true;
				}
			}

			// Files and folders - \\servername\foldername\
			// TODO needs work
			Regex rxFile = new Regex(@"(\b\w:\\[^ ]*)", RegexOptions.IgnoreCase);
			rxFile.Match(strClipboardText);

			foreach (Match rm in rxFile.Matches(strClipboardText))
			{
				if (!_hyperlink.Contains(rm.ToString()))
				{
					_hyperlink.Enqueue(rm.ToString());
					FoundNewLinks = true;
				}
			}

			// UNC Files 
			// TODO needs work
			Regex rxUNC = new Regex(@"(\\\\[^\s/:\*\?\" + "\"" + @"\<\>\|]+)", RegexOptions.IgnoreCase);
			rxUNC.Match(strClipboardText);

			foreach (Match rm in rxUNC.Matches(strClipboardText))
			{
				if (!_hyperlink.Contains(rm.ToString()))
				{
					_hyperlink.Enqueue(rm.ToString());
					FoundNewLinks = true;
				}
			}

			// UNC folders
			// TODO needs work
			Regex rxUNCFolder = new Regex(@"(\\\\[^\s/:\*\?\" + "\"" + @"\<\>\|]+\\)", RegexOptions.IgnoreCase);
			rxUNCFolder.Match(strClipboardText);

			foreach (Match rm in rxUNCFolder.Matches(strClipboardText))
			{
				if (!_hyperlink.Contains(rm.ToString()))
				{
					_hyperlink.Enqueue(rm.ToString());
					FoundNewLinks = true;
				}
			}

			// Email Addresses
			Regex rxEmailAddress = new Regex(@"([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)", RegexOptions.IgnoreCase);
			rxEmailAddress.Match(strClipboardText);

			foreach (Match rm in rxEmailAddress.Matches(strClipboardText))
			{
				if (!_hyperlink.Contains(rm.ToString()))
				{
					_hyperlink.Enqueue("mailto:" + rm.ToString());
					FoundNewLinks = true;
				}
			}

			return FoundNewLinks;
		}

		/// <summary>
		/// Build the system tray menu from the hyperlink list
		/// </summary>
		//private void ContextMenuBuild()
		//{
		//	//
		//	// Only show the last 10 items
		//	//
		//	while (_hyperlink.Count > 10)
		//	{
		//		_hyperlink.Dequeue();
		//	}

		//	cmnuTray.MenuItems.Clear();

		//	foreach (string objLink in _hyperlink)
		//	{
		//		cmnuTray.MenuItems.Add(objLink.ToString(), new EventHandler(itmHyperlink_Click));
		//	}
		//	cmnuTray.MenuItems.Add("-");
		//	cmnuTray.MenuItems.Add("Cancel Menu", new EventHandler(itmCancelMenu_Click));
		//	cmnuTray.MenuItems.Add("-");
		//	cmnuTray.MenuItems.Add(itmHide.Text, new EventHandler(itmHide_Click));
		//	cmnuTray.MenuItems.Add("-");
		//	cmnuTray.MenuItems.Add("E&xit", new EventHandler(itmExit_Click));
		//}


		/// <summary>
		/// Called when an item is chosen from the menu
		/// </summary>
		/// <param name="pstrLink">The link that was clicked</param>
		private void OpenLink(string pstrLink)
		{
			try
			{
				//
				// Run the link
				//

				// TODO needs more work to check for missing files etc
				System.Diagnostics.Process.Start(pstrLink);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

		}

		private bool IsAccession(string testString)
		{
			return (testString.Length == 9 
				&& (testString.StartsWith("10") || testString.StartsWith("11") || testString.StartsWith("12")));
		}


		/// <summary>
		/// Show the clipboard contents in the window 
		/// and show the notification balloon if a link is found
		/// </summary>
		private void GetClipboardData()
		{
			//
			// Data on the clipboard uses the 
			// IDataObject interface
			//
			IDataObject iData = new DataObject();
			string strText = "clipmon";

			try
			{
				iData = Clipboard.GetDataObject();
			}
			catch (System.Runtime.InteropServices.ExternalException externEx)
			{
				// Copying a field definition in Access 2002 causes this sometimes?
				Debug.WriteLine("InteropServices.ExternalException: {0}", externEx.Message);
				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return;
			}


			// 
			// Get Text if it is present
			//
			if (iData.GetDataPresent(DataFormats.Text))
			{
				//ctlClipboardText.Text = (string)iData.GetData(DataFormats.Text);
				string clipBoardText = ((string)iData.GetData(DataFormats.Text)).Trim();
				Debug.WriteLine(clipBoardText);
				if (IsAccession(clipBoardText))
				{
					
					var e = new ROSAEvent
					{
						Accession = clipBoardText,
						EventName = "ClipboardAccession",
						EventSender = "Clipboard"
					};
					ShowMenuFrm(e);

				}

				strText = "Text";

				//Debug.WriteLine((string)iData.GetData(DataFormats.Text));
				return;
			}

			// 
			// Get RTF if it is present
			//
			if (iData.GetDataPresent(DataFormats.Rtf))
			{
				//ctlClipboardText.Rtf = (string)iData.GetData(DataFormats.Rtf);
				Debug.WriteLine((string)iData.GetData(DataFormats.Rtf));

				if (iData.GetDataPresent(DataFormats.Text))
				{
					strText = "RTF";
				}

				
			}
			//else
			//{
				
			//	else
			//	{
			//		//
			//		// Only show RTF or TEXT
			//		//
			//		//ctlClipboardText.Text = "(cannot display this format)";
			//		Debug.WriteLine("(cannot display this format)");
			//	}
			//}

			//notAreaIcon.Tooltip = strText;

			//if (ClipboardSearch(iData))
			//{
			//	//
			//	// Found some new links
			//	//
			//	System.Text.StringBuilder strBalloon = new System.Text.StringBuilder(100);

			//	foreach (string objLink in _hyperlink)
			//	{
			//		strBalloon.Append(objLink.ToString() + "\n");
			//	}

			//	FormatMenuBuild(iData);
			//	SupportedMenuBuild(iData);
			//	ContextMenuBuild();

			//	if (_hyperlink.Count > 0)
			//	{
			//		notAreaIcon.BalloonDisplay(NotificationAreaIcon.NOTIFYICONdwInfoFlags.NIIF_INFO, "Links", strBalloon.ToString());
			//	}
			//}
		}

		#endregion

		private void btnGetUsername_Click(object sender, EventArgs e)
		{
			IntPtr windowHandle = SearchForWindow("WindowsForms", "IMPAX");
			IntPtr childHandle;
			String strUrlToReturn = "";

			List <IntPtr> txtWHld = GetAllChildrenWindowHandles(windowHandle, 20);
			if (txtWHld.Count > 0)
			{
				//Debug.WriteLine("0:" + GetWindowTextRaw(txtWHld[0])+"|");
				Debug.WriteLine("1:" + GetWindowTextRaw(txtWHld[1]) + "|");
				txtUsr.Text = GetWindowTextRaw(txtWHld[1]);
				txtPass.Text = GetWindowTextRaw(txtWHld[0]);
			}
							////try to get a handle to IE's toolbar container
							//childHandle = FindWindowEx(windowHandle, IntPtr.Zero, "WorkerW", IntPtr.Zero);
							//if (childHandle != IntPtr.Zero)
							//{
							//	//get a handle to address bar
							//	childHandle = FindWindowEx(childHandle, IntPtr.Zero, "ReBarWindow32", IntPtr.Zero);
							//	if (childHandle != IntPtr.Zero)
							//	{
							//		// get a handle to combo boxex
							//		childHandle = FindWindowEx(childHandle, IntPtr.Zero, "ComboBoxEx32", IntPtr.Zero);
							//		if (childHandle != IntPtr.Zero)
							//		{
							//			// get a handle to combo box
							//			childHandle = FindWindowEx(childHandle, IntPtr.Zero, "ComboBox", IntPtr.Zero);
							//			if (childHandle != IntPtr.Zero)
							//			{
							//get handle to edit
				//			childHandle = Win32.User32.FindWindowEx(windowHandle, IntPtr.Zero, "WindowsForms10.EDIT.app.0."+ appSuffix, null);
				//			if (childHandle != IntPtr.Zero)
				//			{
				//				strUrlToReturn = GetText(childHandle);
				//Debug.WriteLine(strUrlToReturn);
					//		}
			//			}
			//		}
			//	}
			//}
			//return strUrlToReturn;
		}
		public static string GetWindowTextRaw(IntPtr hwnd)
		{
			// Allocate correct string length first
			int length = (int)WinAPI.SendMessage(hwnd, (int)WinAPI.Msgs.WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
			if (length == 0)
				return "";

			StringBuilder sb = new StringBuilder(length + 1);
			WinAPI.SendMessage(hwnd, (int)WinAPI.Msgs.WM_GETTEXT, (IntPtr)sb.Capacity, sb);
			return sb.ToString();
		}
		public static List<IntPtr> GetAllChildrenWindowHandles(IntPtr hParent,  int maxCount)
		{
			List<IntPtr> result = new List<IntPtr>();
			int ct = 0;
			string childClassWeNeed = "WindowsForms10.EDIT.app.0." + appSuffix;
			IntPtr prevChild = IntPtr.Zero;
			IntPtr currChild = IntPtr.Zero;
			while (true && ct < maxCount)
			{
				currChild = WinAPI.FindWindowEx(hParent, prevChild, null, null);
				if (currChild == IntPtr.Zero) break;

				
				StringBuilder sb = new StringBuilder(1024);
				WinAPI.GetClassName(currChild, sb, sb.Capacity);

				string currClass = sb.ToString();
				Debug.WriteLine(currClass);
				if (currClass == childClassWeNeed)
					result.Add(currChild);

				if (currClass.StartsWith("WindowsForms10.Window."))
				{
					result.AddRange(GetAllChildrenWindowHandles(currChild, 20));
				}
								
				prevChild = currChild;

				++ct;
			}
			return result;
		}

		//public static string GetWindowTextRaw(IntPtr hwnd)
		//{
		//	// Allocate correct string length first
		//	int length = (int)Win32.User32.SendMessage(hwnd, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
		//	StringBuilder sb = new StringBuilder(length + 1);
		//	SendMessage(hwnd, WM_GETTEXT, (IntPtr)sb.Capacity, sb);
		//	return sb.ToString();
		//}

		public static string GetText(IntPtr hWnd)
		{
			// Allocate correct string length first
			int length = 10;// Win32.User32.GetWindowTextLength(hWnd);
			StringBuilder sb = new StringBuilder(length + 1);
			WinAPI.GetWindowText(hWnd, sb, sb.Capacity);
			return sb.ToString();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (IsClipMonON) { UnregisterClipboardViewer(); }
		}

		private void ShowMenuFrm(ROSAEvent e)
		{
			ActionMenuForm pgm = new ActionMenuForm();
			 pgm.Owner = this;
			 pgm.ShowDialog();
			////this.Enabled = false;
			//Task.Factory.StartNew(() =>
			//{
			//	ActionMenuForm pgm = new ActionMenuForm();
			//	pgm.Owner = this;
			//	pgm.Show();
			//	Debug.WriteLine("action-menu-shown");

			//	//System.Threading.Thread.Sleep(5000);

			//});
			////).ContinueWith(_ =>
			////{
			////	pgm.Close();
			////	//this.Enabled = true;
			////}, TaskScheduler.FromCurrentSynchronizationContext());
		}

		

	}

	public class SearchData
	{
		public string Wndclass;
		public string Title;
		public IntPtr hWnd;
	}
}
