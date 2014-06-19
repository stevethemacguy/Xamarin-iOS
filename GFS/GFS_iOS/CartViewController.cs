using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

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

            //setting up menuSubview function
            menuView = new MenuSubView(this, MenuButton3, 0);
            MenuButton3 = menuView.setButton();

			cartUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background568.png"));
		}

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            menuView.clearSubView();
        }
	}
}
