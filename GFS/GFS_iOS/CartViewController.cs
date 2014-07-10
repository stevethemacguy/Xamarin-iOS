using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Drawing;

namespace GFS_iOS
{
	partial class CartViewController : UIViewController
	{
		UIBarButtonItem menuButton33;

		public CartViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			cartUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background568.png"));
			//Hide the back button
			this.NavigationItem.HidesBackButton = true;

			//Create the MainMenu UIBarButtonItem and intialize the flyout Main Menu view
			menuButton33 = new MainMenuButton().getButton(this, 64);

			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menuButton33, true);
		}
	}
}
