using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace GFS_iOS
{
	partial class ListATableViewController : UITableViewController
	{
		public int index = 0;
		public string title = ""; //set by SavedListTableSource during the segue.
		public SavedListsTableController currentController;
		public ListATableViewController tableController;
		private DataSource db;
		private List<Product> prodList; //A list of all the products in the "database"
		public ListATableViewController (IntPtr handle) : base (handle)
		{
			tableController = this;
			db = DataSource.getInstance();
			prodList = db.getProductList();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ListProdCell1.BackgroundColor = UIColor.Clear;
			ListProdCell2.BackgroundColor = UIColor.Clear;
			tableController.Title = title; //Set the title in the navigation bar to the selected cell's title
			if (index == 1) //When other stuff is clicked, make things empty
			{
				//Hide the other products
				ListProdCell1.Hidden = true;
				ListProdCell2.Hidden = true;
			}
			//Set product1 properties
			Prod1Image.Image = UIImage.FromFile(prodList[0].getImageFileName());
			Prod1Title.Text = prodList[0].getTitle();
			Prod1Class.Text = prodList [0].getProdClass();
			Prod1Capacity.Text = prodList[0].getCapacity();
			Prod1Readability.Text = prodList[0].getReadability();
			Prod1Price.Text = prodList[0].getPrice();

			//Set product2 properties
			Prod2Image.Image = UIImage.FromFile(prodList[1].getImageFileName());
			Prod2Title.Text = prodList[1].getTitle();
			Prod2Class.Text = prodList [1].getProdClass();
			Prod2Capacity.Text = prodList[1].getCapacity();
			Prod2Readability.Text = prodList[1].getReadability();
			Prod2Price.Text = prodList[1].getPrice();
				
			ListOneUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));
			//Segue to product 2 instead of one.
			segueButton1.TouchUpInside += (o, s) => {
				PerformSegue("Prod2Segue", this);
			};
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
