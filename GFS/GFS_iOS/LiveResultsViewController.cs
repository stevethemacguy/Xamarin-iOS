using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace GFS_iOS
{
	//NOTE: This is not a table view controller, but we add a TableView with our table sourceat the bottom. 
	//If we used a TableViewController, then we would end up with two tables.
	partial class LiveResultsViewController : UIViewController
	{
		public UITableView table;
		LiveResultsViewController currentController;
		MenuSubView menuView;
		UIBarButtonItem menuB30;
		public Product product; //The product represented by the currently selected row
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
					menuView.toggleMenu(this, 64);
				});

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
		private DataSource dataSource = null;
		protected List<Product> tableItems;
		NSString cellIdentifier = new NSString("productCell");
		LiveResultsViewController parentController;

		public LiveResultsTableSource (LiveResultsViewController parentController)
		{
			this.parentController = parentController;
			dataSource = DataSource.getInstance();
			tableItems = new List<Product>();

			//Get all of the products from the data base and uses these as the table items
			Dictionary<String, Product> prodMap = dataSource.getAllProducts(); 
			foreach (Product p in prodMap.Values)
			{
				tableItems.Add(p); //Items are the actual products
			}
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
			Product product = tableItems[indexPath.Row]; //The cell's product

			//iOS6 way to reuse cells
			//var cell = (ProductCell) tableView.DequeueReusableCell(cellIdentifier, indexPath);

			//"Old way to reuse cells
			//request a recycled cell to save memory
			ProductCell cell = tableView.DequeueReusableCell (cellIdentifier) as ProductCell;
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new ProductCell (cellIdentifier);

			//cell.Opaque = true;

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
			return cell;
		}
	}
}
