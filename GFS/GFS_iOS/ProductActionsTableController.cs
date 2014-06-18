using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;


namespace GFS_iOS
{
	partial class ProductActionsTableController : UITableViewController
	{
		public ProductActionsTableController actionsTable; //The current controller
		public HashSet<string> actionList;

		public ProductActionsTableController (IntPtr handle) : base (handle)
		{
			actionsTable = this;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			actionCell1.BackgroundColor = UIColor.Clear;
			actionCell2.BackgroundColor = UIColor.Clear;
			actionCell3.BackgroundColor = UIColor.Clear;
			//actionCell4.BackgroundColor = UIColor.Clear;
			//actionCell5.BackgroundColor = UIColor.Clear;
			actionsView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));

			DownloadButton.TouchUpInside += (o,s) => {
				UIAlertView alert = new UIAlertView ("Download Complete!", "The PDF file was sucessfully saved.", null, "OK");
					alert.Show();
				DataSource data = DataSource.getInstance();
				//We have two hardcoded PDFs for this prototype. If the user clicks to download, we just show the first row (with the first PDF)
				if (data.showRow1 == false)
				{
					data.showRow1 = true;
				}
				else  //If showRow1 is already showing, then just reveal row 2 now.
				{
					data.showRow2 = true;
				}

			};

			//Create an action sheet that comes up from the bottom.
			AddToListButton.TouchUpInside += (o,s) => {
				UIActionSheet actionSheet = new UIActionSheet ("Your Saved Lists");
				actionList = (DataSource.getInstance()).getSavedListSet(); //Get the savedLists Set from the datasource

				//Add buttons for each item in the savedList
				foreach (string item in actionList)
				{
					actionSheet.AddButton(item);
				}

				actionSheet.AddButton ("Create List");
				actionSheet.AddButton ("Cancel");
				actionSheet.ShowInView (View);
				actionSheet.Clicked += delegate(object a, UIButtonEventArgs b) {
					string selectedItem = actionSheet.ButtonTitle(b.ButtonIndex); //The string label on the button that was clicked
					if (selectedItem == "Cancel")
					{
						//do nothing, it cancels automatically
					}
					else if (selectedItem == "Create List")
					{
						//Get the current storyboard
						UIStoryboard board = UIStoryboard.FromName("MainStoryboard", null); 

						//Get the TextInputController
						TextInputController inputView = (TextInputController) board.InstantiateViewController(  
							"textInputController"
						);

						//inputView.tableController = (NotesTableController) parentController;

						//Segue to the text input view
						actionsTable.NavigationController.PushViewController (inputView, false);
					}

					else //The user selected a saved list
					{	
						string success = "The product was added to: \"" + selectedItem +"\"";
						UIAlertView alert = new UIAlertView(success, "", null, "OK");
						alert.Show();

						//Actually Add the product cell to the Saved Lists Table
						DataSource db = DataSource.getInstance();
						List<Product> prodlist = db.getProductList();

						//if the product selected is A, then add prod A
						if (db.currentProduct == "product1")
						{
							prodlist.Add(new Product("product1.png", 
								"Thermo Scientific™ Herasafe™ KS Class II, Type A2 Biological Safety Cabinets", 
								"KS Class II,  A201", 
								"Capacity: 120g", 
								"Readability: 0.01mg", 
								"Price: $12,381.00", "Prod1Segue"));
						}
						else //the second product was selected, so add the second product
						{
							prodlist.Add(new Product("product2.png", 
								"Thermo Scientific™ 1300 Series Class II, Type A2 Biological Safety Cabinets", 
								"XPE 105", 
								"Capacity: 520g", 
								"Readability: 0.1mg", 
								"Price: $8,272.03", "Prod1Segue"));
						}

						//Console.WriteLine(selectedItem + " was clicked.");
						//Console.WriteLine ("Button " + b.ButtonIndex.ToString () + " clicked");
					}
						
				};
			};
		}
	}
}
