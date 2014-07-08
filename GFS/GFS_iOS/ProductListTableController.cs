﻿using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace GFS_iOS
{
	//NOTE: This is not a table view controller, but we add a TableView with our table source at the bottom. 
	//If we used a TableViewController, then we would end up with two tables.
	partial class ProductListTableController : UIViewController
	{
		public UITableView table;
		ProductListTableController currentController;
		MenuSubView menuView;
		UIBarButtonItem menuButton102;

		//The index of the row selected when seguing from the SavedListsTableController
		public int selectedRowindex;

		//The list of products the matches the saved list (i.e. row) selected when seguing from the SavedListsTableController
		public List<Product> selectedSavedList;

		public ProductListTableController()
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
			menuButton102 = new UIBarButtonItem(UIImage.FromFile("menuIconShifted.png"), UIBarButtonItemStyle.Plain, 
				//When clicked
				(sender, args) => {
					if (menuView.isVisible()) {
						//Change X image back to the normal menu image
						menuButton102.Image = UIImage.FromFile("menuIconShifted.png");
					} else {
						//Make Button show the X image once it's pressed.
						menuButton102.Image = UIImage.FromFile("XIcon.png");
					}
					menuView.toggleMenu(this, 64);
				});

			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menuButton102, true);

			//Create the table and populate it with  cells
			table = new UITableView(View.Bounds); // defaults to Plain style

			//Set up the cell for reuse (iOS6 way)
			//table.RegisterClassForCellReuse (typeof(ProductCell), cellIdentifier);

			table.AutoresizingMask = UIViewAutoresizing.All;
			//Create the Table rows from the source
			table.Source = new SavedListViewTableSource(currentController);

			table.SeparatorStyle = UITableViewCellSeparatorStyle.None; //If you don't want seperator lines
			table.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));

			//Sets height of each cell (globally for all cells)
			table.RowHeight = 80; //90 is original row height
			Add(table);
		}
	} //End SavedListViewController

	class SavedListViewTableSource : UITableViewSource
	{
		private DataSource dataSource = null;

		protected List<Product> tableItems;
		NSString cellIdentifier = new NSString("productCell");
		ProductListTableController parentController;

		public SavedListViewTableSource (ProductListTableController parentController)
		{
			this.parentController = parentController;
			//A list of products associated with the saved list that was selected in the previous step.
			tableItems = parentController.selectedSavedList;
//
//			foreach (Product p in tableItems)
//			{
//				tableItems.Add(p); //Items are the actual products
//			}
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
			//cell.Opaque
			///Warning: Setting to clear could cause performance issues
			//cell.BackgroundColor = UIColor.Clear;
			return cell;
		}
	}
}