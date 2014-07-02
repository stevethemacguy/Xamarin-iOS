using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace GFS_iOS
{
	public class LiveResultsTableSource : UITableViewSource
	{
		private DataSource dataSource = null;
		protected string cellIdentifier = "testCell";

		protected List<string> tableItems; //should actually be a custom cell?
		UIViewController parentController; //Used to store the parent controller of this TableSource

		public LiveResultsTableSource (UIViewController parentController)
		{
			this.parentController = parentController;
			tableItems = new List<string>();
			tableItems.Add("apple");
			tableItems.Add("banana");
			//Get an instance of the datasource
			dataSource = DataSource.getInstance();
			//			dataSource.addSavedList("cabinets");
			//			dataSource.addSavedList("others");
			//			tableItems = dataSource.getSavedListSet().ToList();  //Convert the datasource set to a list for convenience
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return dataSource.getSavedListSet().Count;
		}

		//When the row is clicked, segue to some controller and pass all  data
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, true); // iOS convention is to remove the highlight

			//Get the current storyboard
			UIStoryboard board = UIStoryboard.FromName("MainStoryboard", null); 

			ListATableViewController savedListTable = (ListATableViewController) board.InstantiateViewController(  
				"listATable"
			);

			//"Pass" along the ibndex of the selected row to the index member variable
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

