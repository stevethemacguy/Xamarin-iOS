using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;

namespace GFS_iOS
{
	partial class SavedListsTableController : UITableViewController
	{
		public UITableView table;
		SavedListsTableController currentController;
        MenuSubView menuView;
		UIBarButtonItem menuB30;

		public SavedListsTableController (IntPtr handle) : base (handle)
		{
			currentController = this; //Maintain a reference to this controller
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Hide the back button
			this.NavigationItem.HidesBackButton = true;

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

            SavedListsUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));

			//Create the table and populate it with two cells
			table = new UITableView(View.Bounds); // defaults to Plain style
			table.AutoresizingMask = UIViewAutoresizing.All;
			//Create the Table rows from the source, passing the full text for all notes (which will also act as row names), and the current ViewController
			table.Source = new SavedListTableSource(currentController);
			Add(table);
			table.BackgroundColor = UIColor.Clear; //Make the table clear
		}
	}

	class SavedListTableSource : UITableViewSource {

		protected List<string> tableItems; 
		protected string cellIdentifier = "testCell";
		private DataSource dataSource = null;
		UIViewController parentController; //Used to store the parent controller of this TableSource

		public SavedListTableSource (UIViewController parentController) //List<string> notes)
		{
			this.parentController = parentController;

			//Get an instance of the datasource
			dataSource = DataSource.getInstance();
			dataSource.addSavedList("cabinets");
			dataSource.addSavedList("others");
			tableItems = dataSource.getSavedListSet().ToList();  //Convert the datasource set to a list for convenience
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return dataSource.getSavedListSet().Count;
		}

		//When the row is clicked, segue to the ListATableViewController and pass all  data
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, true); // iOS convention is to remove the highlight

			//Get the current storyboard
			UIStoryboard board = UIStoryboard.FromName("MainStoryboard", null); 

			ListATableViewController savedListTable = (ListATableViewController) board.InstantiateViewController(  
				"listATable"
			);

			//"Pass" along the index of the selected row to the index member variable
			savedListTable.index = indexPath.Row; 
			savedListTable.rowName = tableItems[indexPath.Row];
			savedListTable.currentController = (SavedListsTableController) parentController;

			//Segue to the SavedListTable
			parentController.NavigationController.PushViewController (savedListTable, true); //yes, animate the segue
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			// request a recycled cell to save memory
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);

			//tableItems[0], where zero is the index of the row, would get the first string in the data source SavedListSet.
			cell.TextLabel.Text = tableItems[indexPath.Row]; 

			//Add a Saved List to the DataSource, using the cell row name
			dataSource.addSavedList(tableItems [indexPath.Row]); //Add to the static list of saved lists
			return cell;
		}
	}
}
