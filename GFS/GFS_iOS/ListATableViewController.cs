using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace GFS_iOS
{
	partial class ListATableViewController : UITableViewController
	{
		public int index = 0;
		public string title = ""; //set by SavedListTableSource during the segue.
		public SavedListsTableController currentController;
		public ListATableViewController tableController;
		private DataSource db;

		public ListATableViewController (IntPtr handle) : base (handle)
		{
			tableController = this;
			db = DataSource.getInstance();
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

			Prod1Image.Image = UIImage.FromFile("product2.png");
			Prod1Title.Text = "Fun Fun";
			Prod1Class.Text = "Even More Fun";
			Prod1Capacity.Text = "1.5 and stuff";
			Prod1Readability.Text = "Very Readable";
			Prod1Price.Text = "class?";
				
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
