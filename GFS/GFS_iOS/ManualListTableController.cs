using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace GFS_iOS
{
	partial class ManualListTableController : UITableViewController
	{
		public ManualListTableController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ManualListCell1.BackgroundColor = UIColor.Clear;
			ManualListCell2.BackgroundColor = UIColor.Clear;
			ManualListView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));
		}
	}
}
