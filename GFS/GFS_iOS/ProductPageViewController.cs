using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace GFS_iOS
{
	partial class ProductPageViewController : UIViewController
	{
		public ProductPageViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ProductPageUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background568.png"));
		}
	}
}
