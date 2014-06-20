using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Drawing;

namespace GFS_iOS
{
	partial class AccountViewController : UIViewController
	{
		MenuSubView menuView;
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

			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();

			//Create the Menu button
			menuB3 = new UIBarButtonItem(UIImage.FromFile("menuIconShifted.png"), UIBarButtonItemStyle.Plain, 
				//When clicked
				(sender, args) => {
					if (menuView.isVisible()) {
						//Change X image back to the normal menu image
						menuB3.Image = UIImage.FromFile("menuIconShifted.png");
					} else {
						//Make Button show the X image once it's pressed.
						menuB3.Image = UIImage.FromFile("XIcon.png");
					}
					menuView.toggleMenu(this, 64);
				});
			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menuB3, true);
		}
	}
}
