using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.IO;

namespace GFS_iOS
{
	partial class PDFViewController : UIViewController
	{
        MenuSubView menuView;
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

            //setting up menuSubview function
            menuView = new MenuSubView(this, MenuB14, 0);
            MenuB14 = menuView.setButton();

			showPDF();
		}

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            menuView.clearSubView();
        }
	}
}
