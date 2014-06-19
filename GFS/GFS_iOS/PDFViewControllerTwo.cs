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

            //setting up menuSubview function
            menuView = new MenuSubView(this, MenuB15, 0);
            MenuB15 = menuView.setButton();

			showPDF();
		}

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            menuView.clearSubView();
        }
	}
}
