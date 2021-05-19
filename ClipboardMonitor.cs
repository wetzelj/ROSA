using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace RosaTEST
{
	public class ClipboardMonitor
	{
		#region Clipboard Formats

		string[] formatsAll = new string[]
		{
			DataFormats.Bitmap,
			DataFormats.CommaSeparatedValue,
			DataFormats.Dib,
			DataFormats.Dif,
			DataFormats.EnhancedMetafile,
			DataFormats.FileDrop,
			DataFormats.Html,
			DataFormats.Locale,
			DataFormats.MetafilePict,
			DataFormats.OemText,
			DataFormats.Palette,
			DataFormats.PenData,
			DataFormats.Riff,
			DataFormats.Rtf,
			DataFormats.Serializable,
			DataFormats.StringFormat,
			DataFormats.SymbolicLink,
			DataFormats.Text,
			DataFormats.Tiff,
			DataFormats.UnicodeText,
			DataFormats.WaveAudio
		};

		string[] formatsAllDesc = new String[]
		{
			"Bitmap",
			"CommaSeparatedValue",
			"Dib",
			"Dif",
			"EnhancedMetafile",
			"FileDrop",
			"Html",
			"Locale",
			"MetafilePict",
			"OemText",
			"Palette",
			"PenData",
			"Riff",
			"Rtf",
			"Serializable",
			"StringFormat",
			"SymbolicLink",
			"Text",
			"Tiff",
			"UnicodeText",
			"WaveAudio"
		};

		#endregion

		/*
		 * //IntPtr _ClipboardViewerNext;
		//Queue _hyperlink = new Queue();

		//#region Methods - Private

		///// <summary>
		///// Register this form as a Clipboard Viewer application
		///// </summary>
		//private void RegisterClipboardViewer()
		//{
		//	_ClipboardViewerNext = Win32.User32.SetClipboardViewer(this.Handle);
		//}

		///// <summary>
		///// Remove this form from the Clipboard Viewer list
		///// </summary>
		//private void UnregisterClipboardViewer()
		//{
		//	Win32.User32.ChangeClipboardChain(this.Handle, _ClipboardViewerNext);
		//}

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

		///// <summary>
		///// Build the system tray menu from the hyperlink list
		///// </summary>
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
				//MessageBox.Show(this, ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

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
			else
			{
				// 
				// Get Text if it is present
				//
				if (iData.GetDataPresent(DataFormats.Text))
				{
					//ctlClipboardText.Text = (string)iData.GetData(DataFormats.Text);
					Debug.WriteLine((string)iData.GetData(DataFormats.Rtf));

					strText = "Text";

					Debug.WriteLine((string)iData.GetData(DataFormats.Text));
				}
				else
				{
					//
					// Only show RTF or TEXT
					//
					//ctlClipboardText.Text = "(cannot display this format)";
					Debug.WriteLine("(cannot display this format)");
				}
			}

			//notAreaIcon.Tooltip = strText;

			if (ClipboardSearch(iData))
			{
				//
				// Found some new links
				//
				System.Text.StringBuilder strBalloon = new System.Text.StringBuilder(100);

				foreach (string objLink in _hyperlink)
				{
					strBalloon.Append(objLink.ToString() + "\n");
				}

				//FormatMenuBuild(iData);
				//SupportedMenuBuild(iData);
				//ContextMenuBuild();

				//if (_hyperlink.Count > 0)
				//{
				//	notAreaIcon.BalloonDisplay(NotificationAreaIcon.NOTIFYICONdwInfoFlags.NIIF_INFO, "Links", strBalloon.ToString());
				//}
			}
		}

		#endregion


		*/

	}
}
