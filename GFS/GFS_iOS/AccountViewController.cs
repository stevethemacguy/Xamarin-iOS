using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Drawing;

namespace GFS_iOS
{
	partial class AccountViewController : UIViewController
	{
		UIBarButtonItem menuB3;

		public AccountViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			accountUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background568.png"));

			//Hide the back button
			this.NavigationItem.HidesBackButton = true;

			//Leave this code for an example of manually creating/adding a button
//			//Manually create a menu button and add it to the right side of the menu bar
//			menuButton32 = UIButton.FromType(UIButtonType.Custom);
//			menuButton32.SetBackgroundImage(UIImage.FromFile("menuIconShifted.png"), UIControlState.Normal);
//			menuButton32.Frame = new RectangleF(new PointF(282,11), new SizeF(new PointF((float) 22.0,(float) 22.0)));
//			this.NavigationController.NavigationBar.Add(menuButton32);

			//Create the MainMenu UIBarButtonItem and intialize the flyout Main Menu view
			menuB3 = new MainMenuButton().getButton(this, 64);

			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menuB3, true);
		}
	}
}
