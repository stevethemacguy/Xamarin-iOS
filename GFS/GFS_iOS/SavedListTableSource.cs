using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace GFS_iOS
{
	public class SavedListTableSource : UITableViewSource {

		protected List<string> tableItems; 
		protected string cellIdentifier = "testCell";
		private DataSource dataSource = null;
		UIViewController parentController; //Used to store the parent controller of this TableSource

		public SavedListTableSource (UIViewController parentController) //List<string> notes)
		{
			//tableItems = notes;
			tableItems = new List<string>();
			tableItems.Add("cabinets");
			tableItems.Add("others");
			this.parentController = parentController;

			//Get an instance of the datasource
			dataSource = DataSource.getInstance();
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return tableItems.Count;
		}

		//When the row is clicked, segue to the note view and pass all note data
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
			savedListTable.title = tableItems[indexPath.Row];
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
			cell.TextLabel.Text = tableItems[indexPath.Row];

			//Add a Saved List to the DataSource, using the cell row name
			dataSource.addSavedList(tableItems [indexPath.Row]); //Add to the static list of saved lists
			return cell;
		}
	}
}
