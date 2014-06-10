using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;

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

            //Alternating the keyboard to add camera icon
            UIToolbar toolbar = new UIToolbar(new RectangleF(0.0f, 0.0f, this.View.Frame.Size.Width, 44.0f));

            toolbar.TintColor = UIColor.White;
            toolbar.BarStyle = UIBarStyle.Black;

            toolbar.Translucent = true;

            UIBarButtonItem cameraButton = new UIBarButtonItem(UIImage.FromFile("camera.png"), UIBarButtonItemStyle.Plain, null);

            toolbar.Items = new UIBarButtonItem[]{
             cameraButton,
             new UIBarButtonItem("", UIBarButtonItemStyle.Plain, null),
             new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
             new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate {
             this.NoteTextView.ResignFirstResponder();
    })
     };

            this.NoteTextView.KeyboardAppearance = UIKeyboardAppearance.Dark;
            this.NoteTextView.InputAccessoryView = toolbar;

			//If we're adding a new note, make the text view empty.
			if (addingNote)
			{
				NoteTextView.Text = "";
			}
			else //Otherwise, use the existing note text
			{
				NoteTextView.Text = notes[index]; //Set the current note text to the Note text passed in (the text that corresponds with the cell that was clicked).
				addingNote = false; //We're editing an existing note, not adding one.
			}

			//Create the Save button and add it to the toolbar
			UIBarButtonItem SavedNoteButton = new UIBarButtonItem();
			SavedNoteButton.Title = "Save";
			this.NavigationItem.SetRightBarButtonItem(SavedNoteButton, false);

			//When the Save button is pressed, save the text.
			SavedNoteButton.Clicked += (o,s) => {
				noteText = NoteTextView.Text; //get the current text

				//Don't allow blank notes to be created
				if(noteText == "")
				{
					UIAlertView alert = new UIAlertView ("Failed to Save", "You can not save an empty note.", null, "OK");
					alert.Show();
					return; //Do not segue. Keep the user here until they fix the problem or back out of the note.
				}

				if(addingNote)
				{
					notes.Add(noteText); //add a new note
				}
				else
				{
					notes[index] = noteText; //Overrite the existing note Text of the clicked cell to the new text
				}

				tableController.refreshTable(notes, noteText); //"Refresh" the table using our new list of notes.
			};
		}
	}
}
