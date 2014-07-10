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

			//Create the MainMenu UIBarButtonItem and intialize the flyout Main Menu view
			menuB30 = new MainMenuButton().getButton(this, 0);

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

			ProductListTableController productTable = new ProductListTableController();
			//"Pass" along the index of the selected row to the ProductListTableController
			productTable.selectedRowindex = indexPath.Row; 

			//Get the name of the selected saved list (a String)
			String selectedSavedList = tableItems[indexPath.Row];

			//"Pass" along the name of the selected row to the ProductListTableController
			productTable.selectedRowName = selectedSavedList;

			//Get a list of products associated with the savedlist, send this list to the next view
			if (dataSource.getSavedListMap().ContainsKey(selectedSavedList))
			{
				productTable.selectedSavedList = dataSource.getSavedListMap() [selectedSavedList];
			}
			else  //If there are no products associated with the saved list, then just send an empty list
			{
				productTable.selectedSavedList = new List<Product>();
			}

			parentController.NavigationController.PushViewController(productTable, true);
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
