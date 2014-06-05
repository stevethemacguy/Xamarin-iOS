using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.IO;

namespace GFS_iOS
{
	partial class ManualsViewController : UIViewController
	{
        public void showPDF()
        {
            UIWebView webView = new UIWebView(View.Bounds);
            View.AddSubview(webView);

            string fileName = "articlesFile_6905.pdf";
            //string fileName = "saved-list-icon.png";
            string localHtmlUrl = Path.Combine(NSBundle.MainBundle.BundlePath, fileName);
            //string url = "http://xamarin.com";
            //webView.LoadRequest(new NSUrlRequest(new NSUrl(url)));
            webView.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrl, false)));
            webView.ScalesPageToFit = true;
        }

		public ManualsViewController (IntPtr handle) : base (handle)
		{
		}
	}
}
