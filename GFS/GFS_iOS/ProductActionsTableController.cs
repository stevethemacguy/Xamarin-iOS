using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace GFS_iOS
{
	partial class ProductActionsTableController : UITableViewController
	{
		public ProductActionsTableController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			actionCell1.BackgroundColor = UIColor.Clear;
			actionCell2.BackgroundColor = UIColor.Clear;
			actionCell3.BackgroundColor = UIColor.Clear;
			actionCell4.BackgroundColor = UIColor.Clear;
			actionCell5.BackgroundColor = UIColor.Clear;
			actionsView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));
		}
	}
}
