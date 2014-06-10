using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

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
			//Create the Save button and add it to the toolbar
			UIBarButtonItem SavedNoteButton = new UIBarButtonItem();
			SavedNoteButton.Title = "Save";
			this.NavigationItem.SetRightBarButtonItem(SavedNoteButton, false);

			//When the Save button is pressed, create a new list with the text.
			SavedNoteButton.Clicked += (o,s) => {
				string newList = InputTextView.Text; //get the current text

				//Don't allow blank notes to be created
				if(newList == "")
				{
					UIAlertView alert = new UIAlertView ("Failed to Save", "Please enter a name for the new saved list.", null, "OK");
					alert.Show();
					return; //Do not segue. Keep the user here until they fix the problem or back out of the note.
				}
				//create the list
				DataSource source = DataSource.getInstance();
				source.addSavedList(newList);

				//refresh the table

				//tableController.refreshTable(notes, noteText); //"Refresh" the table using our new list of notes.
			};
		}

	}
}
