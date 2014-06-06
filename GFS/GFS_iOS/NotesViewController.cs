using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace GFS_iOS
{
	partial class NotesViewController : UIViewController
	{
		String noteText;

		public NotesViewController (IntPtr handle) : base (handle)
		{
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
				Console.WriteLine(noteText);
			};
		}
	}
}
