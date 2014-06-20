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

			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();
			MenuB15.TouchUpInside += (sender, e) => {
				if (menuView.isVisible())
				{
					//Change X image back to the normal menu image
					MenuB15.SetBackgroundImage(UIImage.FromFile("menuIconShifted.png"), UIControlState.Normal);
				}else{
					//Make Button show the X image once it's pressed.
					MenuB15.SetBackgroundImage(UIImage.FromFile("XIcon.png"), UIControlState.Normal);
				}
				menuView.toggleMenu(this, 64);
			};

			showPDF();
		}

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            //menuView.clearSubView()();
        }
	}
}
