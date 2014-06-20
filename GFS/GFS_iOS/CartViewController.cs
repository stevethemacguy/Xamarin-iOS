using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Drawing;

namespace GFS_iOS
{
	partial class CartViewController : UIViewController
	{
		MenuSubView menuView;
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

			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();

			//Create the Menu button
			menuButton33 = new UIBarButtonItem(UIImage.FromFile("menuIconShifted.png"), UIBarButtonItemStyle.Plain, 
				//When clicked
				(sender, args) => {
					if (menuView.isVisible()) {
						//Change X image back to the normal menu image
						menuButton33.Image = UIImage.FromFile("menuIconShifted.png");
					} else {
						//Make Button show the X image once it's pressed.
						menuButton33.Image = UIImage.FromFile("XIcon.png");
					}
					menuView.toggleMenu(this, 64);
				});
			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menuButton33, true);
		}
	}
}
