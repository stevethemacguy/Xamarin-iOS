using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace GFS_iOS
{
	partial class ProductDetailsTableController : UITableViewController
	{
		public ProductDetailsTableController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			DetailCell1.BackgroundColor = UIColor.Clear;
			DetailCell2.BackgroundColor = UIColor.Clear;
			DetailCell3.BackgroundColor = UIColor.Clear;
			DetailCell4.BackgroundColor = UIColor.Clear;
			DetailCell5.BackgroundColor = UIColor.Clear;
			ProductDetailsUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));
		}
	}
}
