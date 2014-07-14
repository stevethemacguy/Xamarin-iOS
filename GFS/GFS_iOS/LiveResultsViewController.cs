using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Swx.B2B.Ecom.BL.Entities;

namespace GFS_iOS
{
	//NOTE: This is not a table view controller, but we add a TableView with our table sourceat the bottom. 
	//If we used a TableViewController, then we would end up with two tables.
	partial class LiveResultsViewController : UIViewController
	{
		public UITableView table;
		LiveResultsViewController currentController;
		UIBarButtonItem menuB30;

		//The list of products matching the search term in the SearchViewController.
		public List<Product> jsonResults;

		//Set up the cell for reuse (iOS6 way)
		//static NSString cellIdentifier = new NSString ("productCell");

		public LiveResultsViewController()
		{
			currentController = this; //Maintain a reference to this controller
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Hide the back button
			//this.NavigationItem.HidesBackButton = true;

			//Set the title
			this.Title = "Results";

			//Create the MainMenu UIBarButtonItem and intialize the flyout Main Menu view
			menuB30 = new MainMenuButton().getButton(this, 64); 

			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menuB30, true);

			//Create the table and populate it with  cells
			table = new UITableView(View.Bounds); // defaults to Plain style

			//Set up the cell for reuse (iOS6 way)
			//table.RegisterClassForCellReuse (typeof(ProductCell), cellIdentifier);

			table.AutoresizingMask = UIViewAutoresizing.All;
			//Create the Table rows from the source
			table.Source = new LiveResultsTableSource(currentController);

			table.SeparatorStyle = UITableViewCellSeparatorStyle.None; //If you don't want seperator lines
			table.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));

			//Sets height of each cell (globally for all cells)
			table.RowHeight = 80; //90 is original row height
			Add(table);
		}
	} //End LiveResultsViewController

	class LiveResultsTableSource : UITableViewSource
	{
		protected List<Product> tableItems;
		NSString cellIdentifier = new NSString("productCell");
		LiveResultsViewController parentController;

		public LiveResultsTableSource (LiveResultsViewController parentController)
		{
			this.parentController = parentController;
			tableItems = parentController.jsonResults; //Use the products created from the live results
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return tableItems.Count;
		}

		//When the row is clicked, segue to some controller and pass all  data
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, true); // iOS convention is to remove the highlight

			//The selected product (i.e. selected row)
			Product selectedProduct = tableItems[indexPath.Row];

			LiveProductPageViewController liveProductPage = new LiveProductPageViewController(selectedProduct);

			//"Pass" along the ibndex of the selected row to the index member variable
			liveProductPage.index = indexPath.Row; 
			liveProductPage.rowName = selectedProduct.getTitle();
			//Not needed?
			//liveProductPage.parentController = (LiveProductPageViewController) parentController;

			//Segue
			parentController.NavigationController.PushViewController (liveProductPage, true); //yes, animate the segue 
		}

		//Create the Cells in the table
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{

			Product product = tableItems[indexPath.Row]; //Get the cell's product

			//iOS6 way to reuse cells
			//var cell = (ProductCell) tableView.DequeueReusableCell(cellIdentifier, indexPath);

			//"Old way to reuse cells
			//request a recycled cell to save memory
			ProductCell cell = tableView.DequeueReusableCell (cellIdentifier) as ProductCell;

			// if there are no cells to reuse, create a new one
			if (cell == null)
			{
				//Give each cell a unique identifier so we can target specifics by their index
				NSString cellID = new NSString(cellIdentifier + tableItems.IndexOf(product));
				cell = new ProductCell(cellID);
			}

			//cell.Accessory = UITableViewCellAccessory.DisclosureIndicator; //Add an Arrow to the cell
			//Create (or update) the cell using the Product's title, price, and image url
			cell.UpdateCell (
					product.getTitle(), 
					product.getPrice(), 
					product.getProductImage(),
					UIImage.FromFile("product-result-background.png"),
					UIImage.FromFile("blue-dots.png"),
					UIImage.FromFile("product-devider.png")
				);

			//If the cell is displaying a highlighted product, than highlight the cell
			if(product.isHighlighted())
			{
				cell.highlightCell();
			}

			//cell.Opaque
			///Warning: Setting to clear could cause performance issues
			//cell.BackgroundColor = UIColor.Clear;
			return cell;
		}

		//Highlight specific cells based on their ReuseIdentifier. For example, if the first two cells should have a green background,
		//you could target these cells with (indexPath == 0 || indexPath == 1), but when you scroll, positions 0 and 1 will always be green
		//Using the cellID, however, targets specific cells.
		public override void WillDisplay(UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
		{
			//This highlights the first two cells. This is currently done by checking the product's highlighted flag in getCell(), but
			//this code is a good example of how to do something to a specific cell at a given index.
//			if(cell.ReuseIdentifier == "productCell0" || cell.ReuseIdentifier == "productCell1")
//			{
//				ProductCell theCell = (ProductCell)cell;
//				theCell.highlightCell();
//			}
		}
	}
}
