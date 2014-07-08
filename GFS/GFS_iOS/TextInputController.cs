using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Collections.Generic;

namespace GFS_iOS
{
	partial class TextInputController : UIViewController
	{
		//TextInputController currentController;
		public bool failed = false;
		public string newList = "";
		MenuSubView menuView;
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

				//Add the product to the saved list
				savedListMap[newList].Add(selectedProduct);
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

			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();

			//Create the Menu button
			menuButton34 = new UIBarButtonItem(UIImage.FromFile("menuIconShifted.png"), UIBarButtonItemStyle.Plain, 
				//When clicked
				(sender, args) => {
					if (menuView.isVisible()) {
						//Change X image back to the normal menu image
						menuButton34.Image = UIImage.FromFile("menuIconShifted.png");
					} else {
						//Make Button show the X image once it's pressed.
						menuButton34.Image = UIImage.FromFile("XIcon.png");
					}
					ListInputField.ResignFirstResponder();
					menuView.toggleMenu(this, 64);
				});
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

			//WITHOUT UNWIND SEGUE
			//When the Save button is pressed, create a new list with the text.
//			CreateListButton.TouchUpInside += (o,s) => {
//							createList();
//
//					//*******NORMAL TRANSITION*****
//					//Transition back to the product page and display an alert saying that it was saved.
//					//Get the current storyboard
//					UIStoryboard board = UIStoryboard.FromName("MainStoryboard", null); 
//
//					//Get the TextInputController
//					ProductPageViewController productView = (ProductPageViewController) board.InstantiateViewController(  
//						"productPageController"
//					);
//
//					//productView.tableController = (NotesTableController) parentController;
//
//					productView.fromActionsPage = true;
//					//Segue to the text input view
//					currentController.NavigationController.PushViewController (productView, true);
//
//				//*******NORMAL TRANSITION*****
//				};

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
