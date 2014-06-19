using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace GFS_iOS
{
	partial class SearchResultsTableController : UITableViewController
	{
		public Boolean fromSegue = false; //Used when seguing from the "search" icon when typing in the NotesViewController
		public SearchResultsTableController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

            //set up flyout menuSubview
            MenuB7 = new MenuSubView(this, MenuB7, 0).setButton();

			//If coming from the NotesViewController, don't allow users to segue back to the create a note view
			if(fromSegue)
			{
				//Hide the back button
				this.NavigationItem.HidesBackButton = true;
			}

			//Make the Cells have a clear background color
			//Result1 and 2 are featured, so should be green.
			Result3.BackgroundColor = UIColor.Clear;
			Result4.BackgroundColor = UIColor.Clear;
			Result5.BackgroundColor = UIColor.Clear;
			LoadResultsCell.BackgroundColor = UIColor.Clear;
			//Set Background to an image. NOTE: the Toolbar is transparent and will ajdust to the "same" color as the background for some reason.
			SearchResultsUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));
		}
	}
}
