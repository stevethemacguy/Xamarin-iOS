using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace GFS_iOS
{
	partial class AccountViewController : UIViewController
	{
		public AccountViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			accountUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background568.png"));
			//set up flyout menuSubview
			//MenuB30 = new MenuSubView(this, MenuB30, 0).setButton();
		}
	
	}
}
