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

			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();

			//Create the Menu button
			menub64 = new UIBarButtonItem(UIImage.FromFile("menuIconShifted.png"), UIBarButtonItemStyle.Plain, 
				//When clicked
				(sender, args) => {
					if (menuView.isVisible()) {
						//Change X image back to the normal menu image
						menub64.Image = UIImage.FromFile("menuIconShifted.png");
					} else {
						//Make Button show the X image once it's pressed.
						menub64.Image = UIImage.FromFile("XIcon.png");
					}
					menuView.toggleMenu(this, 64);
				});
			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menub64, true);

			showPDF();
		}
	}
}
