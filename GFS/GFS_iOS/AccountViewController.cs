using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Drawing;

namespace GFS_iOS
{
	partial class AccountViewController : UIViewController
	{
		AccountViewController currentController;
		MenuSubView menuView;

		public AccountViewController (IntPtr handle) : base (handle)
		{
			currentController = this;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			accountUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background568.png"));

			//Manually create a menu button and add it to the right side of the menu bar
			UIButton menuButton32 = UIButton.FromType(UIButtonType.Custom);
			menuButton32.SetBackgroundImage(UIImage.FromFile("menuIconShifted.png"), UIControlState.Normal);
			menuButton32.Frame = new RectangleF(new PointF(282,11), new SizeF(new PointF((float) 22.0,(float) 22.0)));
			this.NavigationController.NavigationBar.Add(menuButton32);

			//set up flyout menuSubview
			menuView = new MenuSubView(currentController, menuButton32, 64);
			menuButton32 = menuView.setButton();


		}
	
	}
}
