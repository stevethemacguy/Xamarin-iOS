using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace GFS_iOS
{
	partial class LiveResultsTableViewController : UITableViewController
	{
		public UITableView table;
		LiveResultsTableViewController currentController;
		MenuSubView menuView;
		UIBarButtonItem menuB30;

		public LiveResultsTableViewController()
		{
			currentController = this; //Maintain a reference to this controller
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//			//Hide the back button
			//			this.NavigationItem.HidesBackButton = true;

			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();

			//Create the Menu button
			menuB30 = new UIBarButtonItem(UIImage.FromFile("menuIconShifted.png"), UIBarButtonItemStyle.Plain, 
				//When clicked
				(sender, args) => {
					if (menuView.isVisible()) {
						//Change X image back to the normal menu image
						menuB30.Image = UIImage.FromFile("menuIconShifted.png");
					} else {
						//Make Button show the X image once it's pressed.
						menuB30.Image = UIImage.FromFile("XIcon.png");
					}
					menuView.toggleMenu(this, 0);
				});

			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menuB30, true);

			//SavedListsUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));

			//Create the table and populate it with  cells
			table = new UITableView(View.Bounds); // defaults to Plain style
			table.AutoresizingMask = UIViewAutoresizing.All;
			//Create the Table rows from the source, passing the full text for all notes (which will also act as row names), and the current ViewController
			table.Source = new LiveResultsTableSource(currentController);
			Add(table);
			table.BackgroundColor = UIColor.Clear; //Make the table clear
		}
	}
}
