using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.IO;

namespace GFS_iOS
{
	partial class PDFViewControllerTwo : UIViewController
	{
        MenuSubView menuView;

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

			//Show Flyout Menu
			menuView = MenuSubView.getInstance();
			// Convert the MenuButton passed into a Button that toggles between states "Unclicked" and "Clicked"
			////menuView.showMenu(this, MenuB15, 64);
			showPDF();
		}

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            menuView.clearSubView();
        }
	}
}
