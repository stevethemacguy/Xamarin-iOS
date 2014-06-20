using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace GFS_iOS
{
	partial class ListATableViewController : UITableViewController
	{
        MenuSubView menuView;
		public int index = 0; //The row that was selected to get to this controller
		public string rowName = ""; //set by SavedListTableSource during the segue.
		public SavedListsTableController currentController;
		public ListATableViewController tableController;
		private DataSource db;
		private List<Product> prodList; //A list of all the products in the "database"
		private Dictionary<String,List<Product>> prodMap; //A list of all the products in the "database"
		public ListATableViewController (IntPtr handle) : base (handle)
		{
			tableController = this;
			db = DataSource.getInstance();
			//prodList = db.getProductList();
			prodMap = db.getProductMap();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Get the menu instace
			menuView = MenuSubView.getInstance();
			// Convert the MenuButton passed into a Button that toggles between states "Unclicked" and "Clicked"
			menuView.initializeMenuSubView(controller, MenuB5, 64);
			MenuB5 = menuView.setButton();

			if (prodMap.ContainsKey(rowName)) {
				prodList = prodMap[rowName]; //Retrieve a List<Product> from the map using the row name as a key
			} else
				prodList = new List<Product>();

			ListProdCell1.BackgroundColor = UIColor.Clear;
			ListProdCell2.BackgroundColor = UIColor.Clear;
			tableController.Title = rowName; //Set the title in the navigation bar to the selected cell's title
			ListProdCell1.Hidden = true;
			ListProdCell2.Hidden = true;
//			if (index == 1) //When other stuff is clicked, make things empty
//			{
//				//Hide the other products
//				ListProdCell1.Hidden = true;
//				ListProdCell2.Hidden = true;
//			}

			//If only one product exists, show the first row only
//			if (prodList.Count >= 1)
//			{
//				ListProdCell1.Hidden = false;
//			}
//			//If 2 or more products exist, also show the second row
//			if (prodList.Count >= 2) 
//			{
//				ListProdCell1.Hidden = false;
//				ListProdCell2.Hidden = false;
//			}

			//If only one product exists, show the first row only
			if (prodList.Count >= 1)
			{
				ListProdCell1.Hidden = false;
			}
			//If 2 or more products exist, also show the second row
			if (prodList.Count >= 2) 
			{
				ListProdCell1.Hidden = false;
				ListProdCell2.Hidden = false;
			}

			//Create the products in each row
			if(prodList.Count > 0)
			{
				for (int ind = 0 ; ind < prodList.Count ; ind++)
				{	
					if (ind == 0)
					{
						Prod1Image.Image = UIImage.FromFile(prodList[ind].getImageFileName());
						Prod1Title.Text = prodList[ind].getTitle();
						Prod1Class.Text = prodList [ind].getProdClass();
						Prod1Capacity.Text = prodList[ind].getCapacity();
						Prod1Readability.Text = prodList[ind].getReadability();
						Prod1Price.Text = prodList[ind].getPrice();
					}
					if (ind == 1)
					{
						Prod2Image.Image = UIImage.FromFile(prodList[ind].getImageFileName());
						Prod2Title.Text = prodList[ind].getTitle();
						Prod2Class.Text = prodList [ind].getProdClass();
						Prod2Capacity.Text = prodList[ind].getCapacity();
						Prod2Readability.Text = prodList[ind].getReadability();
						Prod2Price.Text = prodList[ind].getPrice();
					}
				}
			}

			ListOneUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));

			//Set up segue buttons to segue to the correct product view
			segueButton1.TouchUpInside += (o, s) => {
				UIStoryboard board = UIStoryboard.FromName("MainStoryboard", null);
				UIViewController toPush = new UIViewController();
				//Are we pushing to product A or B?
				if(prodList[0].getSegueName() == "Prod1Segue")
				{
					toPush =  (ProductPageViewController)board.InstantiateViewController(
						"productPageController"
					);
				}
				else{
					toPush =  (ProductPageViewController2)board.InstantiateViewController(
						"productPageController2"
					);
				}
				tableController.NavigationController.PushViewController(toPush, true);
				//PerformSegue(prodList[0].getSegueName(), this);
			};

			segueButton2.TouchUpInside += (o, s) => {
				UIStoryboard board = UIStoryboard.FromName("MainStoryboard", null);
				UIViewController toPush = new UIViewController();
				//Are we pushing to product A or B?
				if(prodList[1].getSegueName() == "Prod1Segue")
				{
					toPush =  (ProductPageViewController)board.InstantiateViewController(
						"productPageController"
					);
				}
				else{
					toPush =  (ProductPageViewController2)board.InstantiateViewController(
						"productPageController2"
					);
				}
				tableController.NavigationController.PushViewController(toPush, true);
				//PerformSegue(prodList[0].getSegueName(), this);
			};

		}

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            menuView.clearSubView();
        }
//		public override row
//		{
//			[self performSegueWithIdentifier:@"addToCartSegue" sender:self];
//		}

//		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
//		{
//			base.PrepareForSegue(segue, sender);
//		}

	}
}
