using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.IO;

namespace GFS_iOS
{
	partial class PDFViewController : UIViewController
	{
		UIBarButtonItem menub64;

		public PDFViewController (IntPtr handle) : base (handle)
		{
		}

		public void showPDF()
		{
			string fileName = "articlesFile_6905.pdf";
			string localHtmlUrl = Path.Combine(NSBundle.MainBundle.BundlePath, fileName);
			PDFWebView.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrl, false)));
			PDFWebView.ScalesPageToFit = true;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Create the MainMenu UIBarButtonItem and intialize the flyout Main Menu view
			menub64 = new MainMenuButton().getButton(this, 64);

			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menub64, true);

			showPDF();
		}
	}
}
