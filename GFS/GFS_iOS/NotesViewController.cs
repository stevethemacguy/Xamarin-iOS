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
		public int index;
		public NotesViewController  (IntPtr handle) : base (handle)
		{
			notes = new String[9];
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Create the Save button and add it to the toolbar
			UIBarButtonItem SavedNoteButton = new UIBarButtonItem();
			SavedNoteButton.Title = "Save";
			this.NavigationItem.SetRightBarButtonItem(SavedNoteButton, false);

			//When the Save button is pressed. Save the text!
			SavedNoteButton.Clicked += (o,s) => {

				noteText = NoteTextView.Text; //get the current text
				//Console.WriteLine(notes[0]);
				Console.WriteLine(index);
				//Find which cell was clicked (pass from previous view)
				//Change the text of the cell to the noteText
				//Also keep this instance of this note so that it is never deleted.
			};
		}
	}
}
