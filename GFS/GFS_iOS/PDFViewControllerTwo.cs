using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.IO;

namespace GFS_iOS
{
	partial class PDFViewControllerTwo : UIViewController
	{
		UIBarButtonItem menu15;

		public PDFViewControllerTwo (IntPtr handle) : base (handle)
		{
		}

		public void showPDF()
		{
			//string fileName = "productSpec.pdf";
			//string localHtmlUrl = Path.Combine(NSBundle.MainBundle.BundlePath, fileName);
			//pdfViewerTwo.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrl, false)));
			//pdfViewerTwo.ScalesPageToFit = true;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Create the MainMenu UIBarButtonItem and intialize the flyout Main Menu view
			menu15 = new MainMenuButton().getButton(this, 64);

			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menu15, true);

			showPDF();
		}
	}
}
