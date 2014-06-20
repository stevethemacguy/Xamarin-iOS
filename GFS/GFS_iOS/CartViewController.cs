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
		UIButton menuButton33;

		public CartViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			cartUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background568.png"));
			//Hide the back button
			this.NavigationItem.HidesBackButton = true;

			//Manually create a menu button and add it to the right side of the menu bar
			menuButton33 = UIButton.FromType(UIButtonType.Custom);
			menuButton33.SetBackgroundImage(UIImage.FromFile("menuIconShifted.png"), UIControlState.Normal);
			menuButton33.Frame = new RectangleF(new PointF(282,11), new SizeF(new PointF((float) 22.0,(float) 22.0)));
			this.NavigationController.NavigationBar.Add(menuButton33);

			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();
			menuButton33.TouchUpInside += (sender, e) => {
				if (menuView.isVisible())
				{
					//Change X image back to the normal menu image
					menuButton33.SetBackgroundImage(UIImage.FromFile("menuIconShifted.png"), UIControlState.Normal);
				}else{
					//Make Button show the X image once it's pressed.
					menuButton33.SetBackgroundImage(UIImage.FromFile("XIcon.png"), UIControlState.Normal);
				}
				menuView.toggleMenu(this, 64);
			};
		}

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
			menuButton33.Hidden = true;
        }
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			menuButton33.Hidden = false;
		}
	}
}
