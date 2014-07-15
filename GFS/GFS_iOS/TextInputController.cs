using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Collections.Generic;
using Swx.B2B.Ecom.BL.Entities;

namespace GFS_iOS
{
	partial class TextInputController : UIViewController
	{
		//TextInputController currentController;
		public bool failed = false;
		public string newList = "";
		UIBarButtonItem menuButton34;

		//The selected product is passed along from the "details" view
		//i.e LiveProductPageViewController > ProductActionsTableController > TextInputController
		public Product selectedProduct;

		public TextInputController (IntPtr handle) : base (handle)
		{
		}

		//Creates a new list from the text entered and adds it to the data source. If the text is empty, does nothing.
		public void createList()
		{
			newList = ListInputField.Text; //get the current text

			//If the user didn't enter anything, then flag as failed.
			if (newList == "") 
			{
				failed = true;
				return;
			} 
			else 
			{
				//create the list
				DataSource db = DataSource.getInstance();
				db.addSavedList(newList);

				//Add the product to the newly created list!
				Dictionary<String, List<Product>> savedListMap = db.getSavedListMap();

				//Since we just created this list, it needs to be added to the map with an empty list
				//But if there is an existing list with the same name, then do not attempt to add a duplicate list
				if(savedListMap.ContainsKey(newList) == false)
				{
					savedListMap.Add(newList, new List<Product>());
				}

				//If the saved list doesn't already contain the product, then Add the product to the saved list
				if (!savedListMap[newList].Contains(selectedProduct))
					savedListMap[newList].Add(selectedProduct);

				//Add the product to the masterList of saved products
				if(db.getAllProducts().ContainsKey(selectedProduct.getCode()) == false) //don't add duplicate products
					db.getAllProducts().Add(selectedProduct.getCode(), selectedProduct);
			}
		}

		//Passing data to the destination view via the "un-wind" segue must be done here, NOT as part of the CreateListButton.TouchUpInside event.
		//For this reason, Creating/saving the list is handled here. (Note: this is NOT called if the "Back" button is clicked).
		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);
			createList();
		}


		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Create the MainMenu UIBarButtonItem and intialize the flyout Main Menu view
			menuButton34 = new MainMenuButton().getButton(this, 64);

			//Hide the keyboard when the main menu button is clicked.
			menuButton34.Clicked += (sender, e) => {
				ListInputField.ResignFirstResponder();
			};

			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menuButton34, true);

			InputUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background568.png"));
			ListInputField.BecomeFirstResponder(); //Put the users cursor in the text field

			//Dismiss the keyboard when the enter key is pressed.
			ListInputField.ShouldReturn = delegate
			{
				ListInputField.ResignFirstResponder();
				return true;
			};

			//SAVE WITHOUT UNWIND SEGUE
			//When the Save button is pressed, create a new list with the text.
			CreateListButton.TouchUpInside += (o,s) => {

				//Create the list
				createList();

				//Dismiss the keyboard
				ListInputField.ResignFirstResponder();

				//Show an error or success method
				if (failed)
				{
					UIAlertView alert = new UIAlertView ("Failed to Save", "The list could not be created. Please try again.", null, "OK");
					alert.Show();
					failed = false;  //reset the flag
					return;
				}
				else
				{
					string success = "The product was added to: \"" + newList +"\"";
					UIAlertView alert = new UIAlertView(success, "", null, "OK");
					alert.Show();
				}
			};

			//*****Create a Save BAR BUTTON instead of the text view and use it to save notes*****
			//Create the Save button and add it to the toolbar
//			UIBarButtonItem SaveListButton = new UIBarButtonItem();
//			SaveListButton.Title = "Save";
//			this.NavigationItem.SetRightBarButtonItem(SaveListButton, false);

			//NOTE: This is when using a TEXTView instead of the current UI View.
//			SaveListButton.Clicked += (o,s) => {
//				string newList = InputTextView.Text; //get the current text
//
//				//Don't allow blank notes to be created
//				if(newList == "")
//				{
//					UIAlertView alert = new UIAlertView ("Failed to Save", "Please enter a name for the new saved list.", null, "OK");
//					alert.Show();
//					return; //Do not segue. Keep the user here until they fix the problem or back out of the note.
//				}
//				//create the list
//				DataSource source = DataSource.getInstance();
//				source.addSavedList(newList);
//			};
		}
	}
}
