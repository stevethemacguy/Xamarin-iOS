using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace GFS_iOS
{
	partial class NotesViewController : UIViewController
	{
		String noteText;
		public String[] notes; //An array of strings. Each string is the text of one note //initialized by NotesTableController during prepare to segue
		//The NotesViewController appears when a cell row is tapped/clicked. This index is the index of the row that was clicked.
		public int index; //Value is passed in from NotesTableSource on segue

		//refrences the table controller. this is passed by NotesTableSource when the table is created and allows us to update the table object
		public NotesTableController tableController; 

		public NotesViewController  (IntPtr handle) : base (handle)
		{
			//notes = new String[9];
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Set the current note text to the Note text passed in (which corresponds with the cell that was clicked).
			NoteTextView.Text = notes[index];

			//Create the Save button and add it to the toolbar
			UIBarButtonItem SavedNoteButton = new UIBarButtonItem();
			SavedNoteButton.Title = "Save";
			this.NavigationItem.SetRightBarButtonItem(SavedNoteButton, false);

			//When the Save button is pressed. Save the text!
			SavedNoteButton.Clicked += (o,s) => {

				noteText = NoteTextView.Text; //get the current text
				Console.WriteLine(noteText);
				Console.WriteLine(notes[index]);
				notes[index] = noteText; //Change the Text of the clicked cell to the note we just saved.
				//NotesTableController.allNotes = notes; //Update the static variable of the NotesTableController

				tableController.refreshTable(notes);

				//NotesTableController.table.Source = new NotesTableSource(currentController, rowNames, allNotes);

				//Also keep this instance of this note so that it is never deleted.
			};
		}
//
//		//When we segue "back" to the NotesTableController, pass back the notes so we can imitate updating the row name when "saving" the note
//		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
//		{
//			base.PrepareForSegue (segue, sender);
//			var test = segue.DestinationViewController as NotesTableController;
//			test.allNotes = notes; //Send the list of "notes" (text) to the NotesViewController
//		}
	}
}
