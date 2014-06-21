using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace GFS_iOS
{
	partial class NotesTableController : UITableViewController
	{
		public UITableView table;
		//Each string is the text of one note. The Strings "match" to a table row by their index. So cell0 will have note[0] for it's text.
		DataSource db;
		NotesTableController currentController;
        MenuSubView menuView;
		UIBarButtonItem menuB22;

		public NotesTableController (IntPtr handle) : base (handle)
		{
			currentController = this; //Maintain a reference to this controller
			db = DataSource.getInstance();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			NoteListUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));

			//Hide the back button
			this.NavigationItem.HidesBackButton = true;

			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();

			//Create the Menu button
			menuB22 = new UIBarButtonItem(UIImage.FromFile("menuIconShifted.png"), UIBarButtonItemStyle.Plain, 
				//When clicked
				(sender, args) => {
					if (menuView.isVisible()) {
						//Change X image back to the normal menu image
						menuB22.Image = UIImage.FromFile("menuIconShifted.png");
					} else {
						//Make Button show the X image once it's pressed.
						menuB22.Image = UIImage.FromFile("XIcon.png");
					}
					menuView.toggleMenu(this, 0);
				});
			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menuB22, true);

			//Create the table and populate it with two cells
			table = new UITableView(View.Bounds); // defaults to Plain style
			table.AutoresizingMask = UIViewAutoresizing.All;
			//Create the Table rows from the source, passing the full text for all notes (which will also act as row names), and the current ViewController
			table.Source = new NotesTableSource(currentController, db.getAllNotes());
			Add(table);
			table.BackgroundColor = UIColor.Clear; //Make the table clear

			//Hide the back button
			this.NavigationItem.HidesBackButton = true;

			//Use System Add Note
			var AddNoteButton = new UIBarButtonItem(UIBarButtonSystemItem.Compose);
			//AddNoteButton.TintColor = UIColor.FromRGB(120, 181, 4); //Change from default blue to green color.
			this.NavigationItem.SetLeftBarButtonItem(AddNoteButton, false);

			//When the Add button is pressed, "Create" a new note.
			AddNoteButton.Clicked += (o,s) => {
				//Segue to the NotesViewController, but with a "blank" note

				//Get the current storyboard
				UIStoryboard board = UIStoryboard.FromName("MainStoryboard", null); 

				//Get the NotesViewController
				NotesViewController notesView = (NotesViewController) board.InstantiateViewController(  
					"notesViewController"
				);

				notesView.tableController = (NotesTableController) currentController;
				//Normlly the NotesViewController index is the "selected row," but in the case of the add button, no row is selected, so
				//the index is the next "empty" row.  (i.e. if there are 2 rows currently (at 0 and 1), then the next free index is 2)
				notesView.index = (db.getAllNotes().Count); 
				notesView.notes = db.getAllNotes();
				notesView.addingNote = true; //Let the new view know that we're trying to add a note as opposed to a "normal" segue
				//Segue to the NotesView
				currentController.NavigationController.PushViewController (notesView, false);
			};
		}

		//Adds a new note and refreshes the table
		public void refreshTable()
		{
			//reacreate the allNotes List, now with our new note
			table = new UITableView(View.Bounds); // defaults to Plain style
			table.AutoresizingMask = UIViewAutoresizing.All;
			table.Source = new NotesTableSource(currentController, db.getAllNotes());
			table.ReloadData();
			Add(table);
		}
	}
}
