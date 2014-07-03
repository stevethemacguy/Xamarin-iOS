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
		protected string cellIdentifier = "productCell";

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
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);

			//Add a Saved List to the DataSource, using the cell row name
			//dataSource.addSavedList(tableItems [indexPath.Row]); //Add to the static list of saved lists

			//use the real image url
			String urlString = product.getImageFileName();
			//Don't create the image if there is none.
			Console.WriteLine(urlString);
			if (urlString != "")
			{
				NSUrl url = new NSUrl(urlString);
				NSData data = NSData.FromUrl(url);
				UIImage image = UIImage.LoadFromData(data); 
				UIImageView imageView = new UIImageView(image);
				imageView.Frame = new RectangleF(20, 20, 60, 50);
				cell.Add(imageView);
			}


			UILabel name = new UILabel();
			name.Frame = new RectangleF(90, 20, 150, 50);
			name.Lines = 2;
			name.Text = product.getTitle();
			cell.Add(name);

			UILabel price = new UILabel();
			price.Frame = new RectangleF(90, 80, 100, 20);
			price.Text = product.getPrice();
			cell.Add(price);

			return cell;
		}
	}
}

