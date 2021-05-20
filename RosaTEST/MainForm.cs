using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace RosaTEST
{
	public partial class MainForm : Form
	{
		IntPtr _ClipboardViewerNext;
		Queue _hyperlink = new Queue();
		bool IsClipMonON = false;

		static string appSuffix = "";
		
		private UIApps _Apps;

		UIApp _impax;
		IntPtr _impaxWh;

		static List<WindowObjInfo> wino = new List<WindowObjInfo>();

		ActionMenuForm frmActions;
		Point frmMenuPosition;
		public MainForm()
		{
			InitializeComponent();
		}

		#region form and ui events like buttons

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

		private void Form1_Load(object sender, EventArgs e)
		{
			Rectangle workingArea = Screen.GetWorkingArea(this);
			this.Location = new Point(workingArea.Right - Size.Width,
									  workingArea.Bottom - Size.Height);

			frmMenuPosition = new Point(workingArea.Right - 240,
									  workingArea.Bottom - (Size.Height + 250));//170 menuform + mainform.height
			WinAPI.UseImmersiveDarkMode(this.Handle, true);

			var dt = new DataTable();
			dt.Columns.Add("Notifications");
			for (int j = 0; j < 2; j++)
			{
				dt.Rows.Add("");
			}
			this.dataGridView1.DataSource = dt;
			this.dataGridView1.Columns[0].Width = 218;
			this.dataGridView1.RowTemplate.Height = 80;

			DataGridViewCellStyle style = new DataGridViewCellStyle();
			style.BackColor = Color.FromArgb(73, 84, 96);
			style.ForeColor = Color.White;

			var TextBoxCell1 = new DataGridViewTextBoxCell();
			TextBoxCell1.Style = style;
			this.dataGridView1[0, 0] = TextBoxCell1;
			this.dataGridView1[0, 0].Value = "Accession number was detected on the clipboard. [Get Prior Exams]";

			this.AddNotification("Encore My Clipboard");

			/*
			DataGridViewCellStyle style2 = new DataGridViewCellStyle();
			style2.BackColor = Color.FromArgb(73, 84, 96);
			style2.ForeColor = Color.White;
			style2.Alignment = DataGridViewContentAlignment.MiddleCenter;

			var TextBoxCell2 = new DataGridViewButtonCell();
			TextBoxCell2.Style = style2;
			this.dataGridView1[0, 1] = TextBoxCell2;
			this.dataGridView1[0, 1].Value = "Get Prior Studies";
			*/
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			//_Apps = new UIApps(System.Diagnostics.Process.GetProcesses());
			//cmbProcs.BeginUpdate();
			//cmbProcs.DataSource = _Apps;
			//cmbProcs.DisplayMember = "Description";
			//cmbProcs.EndUpdate();

			frmActions = new ActionMenuForm();

			frmActions.StartPosition = FormStartPosition.Manual;
			frmActions.Location = frmMenuPosition;

			frmActions.Owner = this;
			frmActions.Visible = false;
			
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (IsClipMonON) { UnregisterClipboardViewer(); }
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btnClipMon_Click(object sender, EventArgs e)
		{
			if (!IsClipMonON)
			{
				RegisterClipboardViewer();
				IsClipMonON = true;
				btnClipMon.Text = "ClipMon-ON";
				btnClipMon.BackColor = Color.LawnGreen;
			}
			else
			{
				UnregisterClipboardViewer();
				IsClipMonON = false;
				btnClipMon.Text = "ClipMon-OFF";
				btnClipMon.BackColor = Color.DarkOrange;
			}
		}

		private void btnTakeScreenshot_Click(object sender, EventArgs e)
		{
			//IntPtr hWndIMPAX = SearchForWindow("WindowsForms", "IMPAX");
			//this.ckbClientWnd.Checked gives the option to capture only the client area saving some space
			if (_impaxWh != IntPtr.Zero)
			{
				Bitmap bitmap = MakeSnapshot(_impaxWh, true, Win32API.WindowShowStyle.Restore);
				if (bitmap != null)
				{
					pictureBox1.Image = bitmap;
					string savingPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Screenshot_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpeg";
					pictureBox1.Image.Save(savingPath, ImageFormat.Jpeg);
					
				}
					
				else
				{
					//lblHwnd.Text = "Hwnd:";
					//btnSnapSot.Enabled = false;
					Debug.WriteLine("nope");
				}
				//btnSaveImage.Enabled = pictureBox1.Image != null;
				Win32API.SetForegroundWindow(this.Handle);
			}
		}

		private void btnGetUsername_Click(object sender, EventArgs e)
		{
			//IntPtr windowHandle = SearchForWindow("WindowsForms", "IMPAX");
			IntPtr childHandle;
			//String strUrlToReturn = "";

			List<IntPtr> txtWHld = GetAllChildrenWindowHandles(_impaxWh, 20);
			if (txtWHld.Count > 0)
			{
				//Debug.WriteLine("0:" + GetWindowTextRaw(txtWHld[0])+"|");
				Debug.WriteLine("1:" + GetWindowTextRaw(txtWHld[1]) + "|");
				txtUsr.Text = GetWindowTextRaw(txtWHld[1]);
				txtPass.Text = GetWindowTextRaw(txtWHld[0]);
			}

		}

		private void btnFindIMPAX_Click(object sender, EventArgs e)
		{
			_impaxWh = SearchForWindow("WindowsForms", "IMPAX");

			btnGetUsername.Enabled = (_impaxWh != IntPtr.Zero);
			btnTakeScreenshot.Enabled = (_impaxWh != IntPtr.Zero);
		}

		#endregion

		private void btnEnuWins_Click(object sender, EventArgs e)
		{
			//ArrayList wins = GetWindows();
			//Debug.WriteLine(wins.Count);
			wino.Clear();

			//vadim test non based on processes
			/*
			var x = SearchForWindow("", "");

			foreach (var w in wino)
				Debug.WriteLine($"{w.Wndclass}:{w.Title}");
			*/

			_Apps = new UIApps(System.Diagnostics.Process.GetProcesses());
			cmbProcs.BeginUpdate();
			cmbProcs.DataSource = _Apps;
			cmbProcs.DisplayMember = "Description";
			cmbProcs.EndUpdate();
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
			//string strText = "clipmon";

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

				//strText = "Text";

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

				//if (iData.GetDataPresent(DataFormats.Text))
				//{
				//	strText = "RTF";
				//}


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

		private void ShowMenuFrm(ROSAEvent e)
		{
			frmActions.Text = e.Accession;
			frmActions.Visible = true;
			frmActions.Show();
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

		#region window-functions

		public static IntPtr SearchForWindow(string wndclass, string title)
		{
			WindowObjInfo sd = new WindowObjInfo { Wndclass = wndclass, Title = title, hWnd = IntPtr.Zero };
			WinAPI.EnumWindows(new EnumWindowsProc(EnumProc), ref sd);
			return sd.hWnd;
		}

		public static bool EnumProc(IntPtr hWnd, ref WindowObjInfo data)
		{
			// Check classname and title
			
			StringBuilder sb = new StringBuilder(1024);
			WinAPI.GetWindowText(hWnd, sb, sb.Capacity);
			string wTitle = sb.ToString();
			//ui windows usually have titles shown in taskbar

			if (wTitle.StartsWith(data.Title) || (data.Title=="" && wTitle!=""))//found it?
			{
				sb = new StringBuilder(1024);
				WinAPI.GetClassName(hWnd, sb, sb.Capacity);
				string wClass = sb.ToString();

				if (data.Wndclass != "")//filter for class specified
				{
					if (wClass.StartsWith(data.Wndclass)) //check filter if matches 
					{
						data.Wndclass = wClass;
						appSuffix = wClass.Substring(wClass.LastIndexOf(".0.") + 3);
						data.hWnd = hWnd;
						return false;    // Found the wnd, halt enumeration
					}
				}
				else
				{
					if (data.Title == "" && data.Wndclass == "" )//all windows (collection mode)
					{						
						if (wTitle != "" ) //adding to list only windows
						{
							if (UIApp.IsValidUIWnd(hWnd))
							{
								var w = new WindowObjInfo
								{
									hWnd = hWnd,
									Title = wTitle,
									Wndclass = wClass
								};
								wino.Add(w);
							}
							
						}
						
						return true; //keep enumerating...

					}
					

					//if (data.Title != "")
					//{
					//	data.Wndclass = wClass;
					//	data.hWnd = hWnd;
					//}
				
					return false;    // Found the wnd, halt enumeration

				}
				

			}

			return true;//keep 'em coming...

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
		
		public static List<IntPtr> GetAllChildrenWindowHandles(IntPtr hParent, int maxCount)
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
		
		#endregion

		#region screenshot functions

		private static Bitmap MakeSnapshot(IntPtr AppWndHandle, bool IsClientWnd, Win32API.WindowShowStyle nCmdShow)
		{

			if (AppWndHandle == IntPtr.Zero || !Win32API.IsWindow(AppWndHandle) || !Win32API.IsWindowVisible(AppWndHandle))
				return null;
			if (Win32API.IsIconic(AppWndHandle))
				Win32API.ShowWindow(AppWndHandle, nCmdShow);//show it
			if (!Win32API.SetForegroundWindow(AppWndHandle))
				return null;//can't bring it to front
			System.Threading.Thread.Sleep(1000);//give it some time to redraw
			RECT appRect;
			bool res = IsClientWnd ? Win32API.GetClientRect(AppWndHandle, out appRect) : Win32API.GetWindowRect(AppWndHandle, out appRect);
			if (!res || appRect.Height == 0 || appRect.Width == 0)
			{
				return null;//some hidden window
			}
			if (IsClientWnd)
			{
				Point lt = new Point(appRect.Left, appRect.Top);
				Point rb = new Point(appRect.Right, appRect.Bottom);
				Win32API.ClientToScreen(AppWndHandle, ref lt);
				Win32API.ClientToScreen(AppWndHandle, ref rb);
				appRect.Left = lt.X;
				appRect.Top = lt.Y;
				appRect.Right = rb.X;
				appRect.Bottom = rb.Y;
			}
			//Intersect with the Desktop rectangle and get what's visible
			IntPtr DesktopHandle = Win32API.GetDesktopWindow();
			RECT desktopRect;
			Win32API.GetWindowRect(DesktopHandle, out desktopRect);
			RECT visibleRect;
			if (!Win32API.IntersectRect(out visibleRect, ref desktopRect, ref appRect))
			{
				visibleRect = appRect;
			}
			if (Win32API.IsRectEmpty(ref visibleRect))
				return null;

			int Width = visibleRect.Width;
			int Height = visibleRect.Height;
			IntPtr hdcTo = IntPtr.Zero;
			IntPtr hdcFrom = IntPtr.Zero;
			IntPtr hBitmap = IntPtr.Zero;
			try
			{
				Bitmap clsRet = null;

				// get device context of the window...
				hdcFrom = IsClientWnd ? Win32API.GetDC(AppWndHandle) : Win32API.GetWindowDC(AppWndHandle);

				// create dc that we can draw to...
				hdcTo = Win32API.CreateCompatibleDC(hdcFrom);
				hBitmap = Win32API.CreateCompatibleBitmap(hdcFrom, Width, Height);

				//  validate...
				if (hBitmap != IntPtr.Zero)
				{
					// copy...
					int x = appRect.Left < 0 ? -appRect.Left : 0;
					int y = appRect.Top < 0 ? -appRect.Top : 0;
					IntPtr hLocalBitmap = Win32API.SelectObject(hdcTo, hBitmap);
					Win32API.BitBlt(hdcTo, 0, 0, Width, Height, hdcFrom, x, y, Win32API.SRCCOPY);
					Win32API.SelectObject(hdcTo, hLocalBitmap);
					//  create bitmap for window image...
					clsRet = System.Drawing.Image.FromHbitmap(hBitmap);
				}
				//MessageBox.Show(string.Format("rect ={0} \n deskrect ={1} \n visiblerect = {2}",rct,drct,VisibleRCT));
				//  return...
				return clsRet;
			}
			finally
			{
				//  release ...
				if (hdcFrom != IntPtr.Zero)
					Win32API.ReleaseDC(AppWndHandle, hdcFrom);
				if (hdcTo != IntPtr.Zero)
					Win32API.DeleteDC(hdcTo);
				if (hBitmap != IntPtr.Zero)
					Win32API.DeleteObject(hBitmap);
			}


		}

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
			var widget = new ROSAWidget();
			widget.Show();
			
			this.Hide();
		}

        private void pictureBox4_Click(object sender, EventArgs e)
        {
			contextMenuStrip1.Show(Cursor.Position.X - 80, Cursor.Position.Y + 30);
		}

		private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			switch (e.ClickedItem.Name)
			{
				case "exit":
					Application.Exit();
					break;

				case "settings":
					var mainForm = new MainForm();
					mainForm.Show();
					this.Hide();
					break;

				default:
					break;
			}
		}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
			var cellValue = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
			RemoveNotification(e.RowIndex);
        }

		public void AddNotification(string NotificationText)
        {
			DataGridViewCellStyle style = new DataGridViewCellStyle();
			style.BackColor = Color.FromArgb(73, 84, 96);
			style.ForeColor = Color.White;

			var TextBoxCell1 = new DataGridViewTextBoxCell();
			TextBoxCell1.Style = style;
			this.dataGridView1[0, dataGridView1.Rows.Count - 1] = TextBoxCell1;
			this.dataGridView1[0, dataGridView1.Rows.Count - 1].Value = NotificationText;

			RefreshNotificationView();
		}

		public void RemoveNotification(int RowIndex)
        {
			dataGridView1.Rows.Remove(dataGridView1.Rows[RowIndex]);

			RefreshNotificationView();

		}

		public void RefreshNotificationView()
        {
			if (dataGridView1.Rows.Count == 0)
            {
				dataGridView1.Hide();
            }
			else
            {
				dataGridView1.Show();
            }
        }
    }

    public class WindowObjInfo
	{
		public string Wndclass;
		public string Title;
		public IntPtr hWnd;
	}

	public class ROSAEvent : EventArgs
	{
		public string EventName;
		public string EventSender;

		public string PatientID;
		public string Accession;
		public string StudyDate;
		public string StudyUID;
	}
}