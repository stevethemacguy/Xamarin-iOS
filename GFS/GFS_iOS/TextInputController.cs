using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Drawing;

namespace GFS_iOS
{
	partial class TextInputController : UIViewController
	{
		public TextInputController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ListInputField.BecomeFirstResponder(); //Put the users cursor in the text field

			//Dismiss the keyboard when the enter key is pressed.
			ListInputField.ShouldReturn = delegate
			{
				ListInputField.ResignFirstResponder();
				return true;
			};

			//When the Save button is pressed, create a new list with the text.
			CreateListButton.TouchUpInside += (o,s) => {
				string newList = ListInputField.Text; //get the current text

				//Don't allow blank notes to be created
				if(newList == "")
				{
					UIAlertView alert = new UIAlertView ("Failed to Save", "Please enter a name for the new saved list.", null, "OK");
					alert.Show();
					return; //Do not segue. Keep the user here until they fix the problem or back out of the note.
				}
				else{
					//create the list
					DataSource source = DataSource.getInstance();
					source.addSavedList(newList);
					//Now transition back to the product page and display an alert saying that it was saved.
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
