using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using Swx.B2B.Ecom.BL.Entities;


namespace GFS_iOS
{
	partial class ProductActionsTableController : UITableViewController
	{
		public ProductActionsTableController actionsTable; //The current controller
		public HashSet<string> actionList;
		UIBarButtonItem menuB15;

		//The actions table is always pushed from a LiveProductPageViewController.
		//selectedProduct is the product that the user was viewing when they "clicked" the circle button
		public Product selectedProduct;

		public ProductActionsTableController (IntPtr handle) : base (handle)
		{
			actionsTable = this;
		}

		public ProductActionsTableController ()
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

			//Create the MainMenu UIBarButtonItem and intialize the flyout Main Menu view
			menuB15 = new MainMenuButton().getButton(this, 0);

			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menuB15, true);

			DownloadButton.TouchUpInside += (o,s) => {
				UIAlertView alert = new UIAlertView ("Download Complete!", "The PDF file was sucessfully saved.", null, "OK");
					alert.Show();
				DataSource data = DataSource.getInstance();

				//Add the product ID to the manual list.
				data.addToManualList(selectedProduct);

				//Add the product to the masterList of saved products
				if(data.getAllProducts().ContainsKey(selectedProduct.getCode()) == false) //don't add duplicate products
					data.getAllProducts().Add(selectedProduct.getCode(), selectedProduct);
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

						//Pass along the product that was originally selected 
						inputView.selectedProduct = selectedProduct;

						//Segue to the text input view
						actionsTable.NavigationController.PushViewController (inputView, false);
					}

					else //The user selected a saved list
					{	
						//Actually Add the product cell to the Saved Lists Table
						DataSource db = DataSource.getInstance();

						Dictionary<String, List<Product>> savedListMap = db.getSavedListMap();
						//initialize list if empty

						//If the list doesn't exist in the map yet, then create it
						if(savedListMap.ContainsKey(selectedItem) == false)
						{
							savedListMap.Add(selectedItem, new List<Product>());
						}

						//Check if the product has alredy been added to the selected list
						//If the product was previously added, don't add it. We don't want duplicate products in the list
						List<Product> savedList = savedListMap[selectedItem];
						if(savedList.Contains(selectedProduct))
						{
							string duplicate = "The product you selected is already in your list: \n\"" + selectedItem +"\"";
							UIAlertView alertView = new UIAlertView(duplicate, "", null, "OK");
							alertView.Show();
							return;
						}

						//Otherwise

						//Add the selected product to the selected list
						savedListMap[selectedItem].Add(selectedProduct);

						//Also add the product to the masterList of saved products
						if(db.getAllProducts().ContainsKey(selectedProduct.getCode()) == false) //don't add duplicate products
							db.getAllProducts().Add(selectedProduct.getCode(), selectedProduct);


						string success = "The product was added to: \"" + selectedItem +"\"";
						UIAlertView alert = new UIAlertView(success, "", null, "OK");
						alert.Show();
					}
				};
			};
		}
	}
}
