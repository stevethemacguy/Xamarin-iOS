using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Drawing;

namespace GFS_iOS
{
	partial class SearchResultsTableController : UITableViewController
	{
        MenuSubView menuView;
		public Boolean fromSegue = false;
		UIBarButtonItem menuB71;

 //Used when seguing from the "search" icon when typing in the NotesViewController
		
        public SearchResultsTableController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
//			UIView test = this.NavigationController.NavigationBar.ViewWithTag(1);
//			if (test != null)
//			test.RemoveFromSuperview();
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

//			//Manually create a menu button and add it to the right side of the menu bar
//			MenuB71 = UIButton.FromType(UIButtonType.Custom);
//			MenuB71.SetBackgroundImage(UIImage.FromFile("menuIconShifted.png"), UIControlState.Normal);
//			MenuB71.Frame = new RectangleF(new PointF(282,11), new SizeF(new PointF((float) 22.0,(float) 22.0)));
//			this.NavigationController.NavigationBar.Add(MenuB71);
//
//			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();

			//Create the Menu button
			menuB71 = new UIBarButtonItem(UIImage.FromFile("menuIconShifted.png"), UIBarButtonItemStyle.Plain, 
				//When clicked
				(sender, args) => {
					if (menuView.isVisible()) {
						//Change X image back to the normal menu image
						menuB71.Image = UIImage.FromFile("menuIconShifted.png");
					} else {
						//Make Button show the X image once it's pressed.
						menuB71.Image = UIImage.FromFile("XIcon.png");
					}
					menuView.toggleMenu(this, 0);
				});
			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menuB71, true);
		}
	}
}
