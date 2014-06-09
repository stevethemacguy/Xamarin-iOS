using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace GFS_iOS
{
	partial class NotesViewController : UIViewController
	{
		String noteText; //The full text of the note currently being viewed
		public List<string> notes; //Each string is the full text of one note. This is created when a NotesTableSource row is selected
		public Boolean addingNote = false; //true if a new note is beeing added.
		//The NotesViewController is created when a cell row is tapped/clicked. This index is the index of the row that was clicked.
		public int index; //Value is passed in from NotesTableSource on segue

		//refrences the table controller. this is passed by NotesTableSource when the table is created and allows us to update the table object
		public NotesTableController tableController; 

		public NotesViewController  (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			if (addingNote)
			{
				NoteTextView.Text = "";
			}
			else
			{
				NoteTextView.Text = notes[index]; //Set the current note text to the Note text passed in (the text that corresponds with the cell that was clicked).
				addingNote = false;
			}

			//Create the Save button and add it to the toolbar
			UIBarButtonItem SavedNoteButton = new UIBarButtonItem();
			SavedNoteButton.Title = "Save";
			this.NavigationItem.SetRightBarButtonItem(SavedNoteButton, false);

			//When the Save button is pressed, save the text.
			SavedNoteButton.Clicked += (o,s) => {
				noteText = NoteTextView.Text; //get the current text
				if(addingNote)
				{
					notes.Add(noteText); //add a new note
				}

				else
				{
					notes[index] = noteText; //Change the Text of the clicked cell to the note we just saved.
				}


				tableController.refreshTable(notes.ToArray(), noteText); //"Refresh" the table using our new list of notes.
			};
		}
	}
}
