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
			UIButton menuButton33 = UIButton.FromType(UIButtonType.Custom);
			menuButton33.SetBackgroundImage(UIImage.FromFile("menuIconShifted.png"), UIControlState.Normal);
			menuButton33.Frame = new RectangleF(new PointF(282,11), new SizeF(new PointF((float) 22.0,(float) 22.0)));
			this.NavigationController.NavigationBar.Add(menuButton33);

			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();
			menuButton33.TouchUpInside += (sender, e) => {
				menuView.toggleMenu(this, 64);
			};
		}

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            menuView.clearSubView();
        }
	}
}
