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
		MenuSubView menuView;

		//refrences the table controller. this is passed by NotesTableSource when the table is created and allows us to update the table object
		public NotesTableController tableController;

        UIImagePickerController picker;
        NotesViewController myController;
		DataSource data;

		public NotesViewController  (IntPtr handle) : base (handle)
		{
            myController = this;
			data = DataSource.getInstance();
		}

		private void SaveNote()
		{
			noteText = NoteTextView.Text; //get the current text
			//Don't allow blank notes to be created
			if(noteText == "")
			{
				return; //Do NOT create the note
			}
			if(addingNote)
			{
				data.addNote(noteText);
			}
			else
			{
				//This actually modifies the database 
				notes[index] = noteText; //Overrite the existing note Text of the clicked cell to the new text
			}
			tableController.refreshTable(); //"Refresh" the table using our new list of notes.
		}

		//When the back button is pressed
		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			this.NavigationController.NavigationBar.ViewWithTag(1).RemoveFromSuperview();
			SaveNote();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Manually create a menu button and add it to the right side of the menu bar
			UIButton menuButton33 = UIButton.FromType(UIButtonType.Custom);
			menuButton33.SetBackgroundImage(UIImage.FromFile("menuIconShifted.png"), UIControlState.Normal);
			menuButton33.Frame = new RectangleF(new PointF(282,11), new SizeF(new PointF((float) 22.0,(float) 22.0)));
			menuButton33.Tag = 1;
			this.NavigationController.NavigationBar.Add(menuButton33);

			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();
			menuButton33.TouchUpInside += (sender, e) => {
				if (menuView.isVisible())
				{
					//Change X image back to the normal menu image
					menuButton33.SetBackgroundImage(UIImage.FromFile("menuIconShifted.png"), UIControlState.Normal);
				}else{
					//Make Button show the X image once it's pressed.
					menuButton33.SetBackgroundImage(UIImage.FromFile("XIcon.png"), UIControlState.Normal);
				}
				menuView.toggleMenu(this, 64);
				//Dismiss the keyboard when the menu button is pressed.
				NoteTextView.ResignFirstResponder();
			};

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

			//Add camera icon to the toolbar
			UIToolbar toolbar = new UIToolbar(new RectangleF(0.0f, 0.0f, this.View.Frame.Size.Width, 31.0f));
			UIBarButtonItem cameraButton = new UIBarButtonItem(UIImage.FromFile("camera-icon.png"), UIBarButtonItemStyle.Plain, cameraMode);
            UIBarButtonItem galleryButton = new UIBarButtonItem(UIImage.FromFile("gallery-icon.png"), UIBarButtonItemStyle.Plain, imagePicker);
            UIBarButtonItem searchButton = new UIBarButtonItem(UIImage.FromFile("magnifying-glass-small.png"), UIBarButtonItemStyle.Plain, searchBar);

            toolbar.Items = new UIBarButtonItem[] {
				cameraButton,
                galleryButton,
                searchButton,
				new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
				new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate {
					this.NoteTextView.ResignFirstResponder();
				})
			};

            //this.NoteTextView.KeyboardAppearance = UIKeyboardAppearance.Dark;
            this.NoteTextView.InputAccessoryView = toolbar;

			//******** USE THE TOOLBAR "SAVE" BUTTON******/
			//Create the Save button and add it to the toolbar
			//UIBarButtonItem SavedNoteButton = new UIBarButtonItem();
			//SavedNoteButton.Title = "Save";
			//this.NavigationItem.SetRightBarButtonItem(SavedNoteButton, false);
			//
			////When the Save button is pressed, save the text.
//			SavedNoteButton.Clicked += (o,s) => {
//				SaveNote();
//			};
        }

        private void imagePicker(object sender, EventArgs e)
        {
            picker = new UIImagePickerController();
            picker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
            picker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);
            myController.PresentViewController(picker, true, null);
        }

        private void cameraMode(object sender, EventArgs e)
        {
            picker = new UIImagePickerController();
            picker.SourceType = UIImagePickerControllerSourceType.Camera;
            picker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.Camera);
            myController.PresentViewController(picker, true, null);
        }

        private void searchBar(object sender, EventArgs e)
        {
            UIStoryboard board = UIStoryboard.FromName("MainStoryboard", null);
            //Get the searchViewController
            SearchResultsTableController searchView = (SearchResultsTableController)board.InstantiateViewController(
                "searchResultsController"
            );
			searchView.fromSegue = true;
            myController.NavigationController.PushViewController(searchView, false);
        }
    }
}
