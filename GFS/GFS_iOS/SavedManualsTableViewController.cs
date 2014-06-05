using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace GFS_iOS
{
	partial class SavedManualsTableViewController : UITableViewController
	{
		public SavedManualsTableViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			manualProdCell1.BackgroundColor = UIColor.Clear;
			manualProdCell2.BackgroundColor = UIColor.Clear;
			SavedManualsList.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));

		}


	}
}
