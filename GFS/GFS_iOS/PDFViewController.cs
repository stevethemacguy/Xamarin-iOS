using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.IO;

namespace GFS_iOS
{
	partial class PDFViewController : UIViewController
	{
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

            //set up flyout menuSubview
            MenuB14 = new MenuSubView(this, MenuB14, 0).setButton();

			showPDF();
		}
	}
}
