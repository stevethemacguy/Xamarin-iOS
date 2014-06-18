using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace GFS_iOS
{
	partial class SavedManualsTableViewController : UITableViewController
	{
		DataSource db;
		Boolean showFirst; //Controls whether the first PDF Manual Row is hidden
		Boolean showSecond; //Controls whether the second PDF Manual Row is hidden

		public SavedManualsTableViewController (IntPtr handle) : base (handle)
		{
			db = DataSource.getInstance();
			showFirst = db.showRow1;
			showSecond = db.showRow2;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			manualProdCell1.BackgroundColor = UIColor.Clear;
			manualProdCell2.BackgroundColor = UIColor.Clear;
			manualProdCell1.Hidden = true;
			manualProdCell2.Hidden = true;
			SavedManualsList.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));

			if (showFirst)
			{
				manualProdCell1.Hidden = false;
			}

			if (showSecond)
			{
				manualProdCell2.Hidden = false;
			}
		}
	}
}
