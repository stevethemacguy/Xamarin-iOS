using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;

namespace GFS_iOS
{
	public class LiveResultsTableSource : UITableViewSource
	{
		private DataSource dataSource = null;
		protected NSString cellIdentifier = new NSString("productCell");

		//protected List<string> tableItems; //should actually be a custom cell?
		protected List<Product> tableItems;
		UIViewController parentController; //Used to store the parent controller of this TableSource

		public LiveResultsTableSource (UIViewController parentController)
		{
			dataSource = DataSource.getInstance();
			tableItems = new List<Product>();

			//Get all of the products from the data base and uses these as the table items
			Dictionary<String, Product> prodMap = dataSource.getAllProducts(); 
			foreach (Product p in prodMap.Values)
				tableItems.Add(p); //Items are the actual products

			this.parentController = parentController;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return tableItems.Count;
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
			savedListTable.rowName = tableItems[indexPath.Row].getTitle();
			savedListTable.currentController = (SavedListsTableController) parentController;

			//Segue to the SavedListTable
			parentController.NavigationController.PushViewController (savedListTable, true); //yes, animate the segue
		}

		//Create the Cells in the table
		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			Product product = tableItems[indexPath.Row]; //The cell's product

			// request a recycled cell to save memory
			ProductCell cell = tableView.DequeueReusableCell (cellIdentifier) as ProductCell;
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new ProductCell (cellIdentifier);

			//Create (or update) the cell using the Product's title, price, and image url
			cell.UpdateCell (product.getTitle(), product.getPrice(), product.getImageFileName());

			return cell;
		}
	}
}

