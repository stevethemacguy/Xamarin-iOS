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
		public List<string> allNotes; //Each String is the full text of a note.

		NotesTableController currentController; 

		public NotesTableController (IntPtr handle) : base (handle)
		{
			currentController = this; //Maintain a reference to this controller

			//If we are contructing the table for the first time
			if (allNotes == null)
			{
				allNotes = new List<string>();
				//First time through, use defaults for row names
				allNotes.Add("Found these products last week. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras mattis consectetur purus sit amet fermentum. ");
				allNotes.Add("Another good find");
			}

			//NO LONGER USED. Row names are now pulled directly from the notes.
//			//Create a row for each note, using the actual note text as the row name
//			for (int i = 0 ;i < allNotes.Count ; i++)
//			{
//				string full = allNotes[i];
//				string shortName = full;
//				//iOS automatically shortens the name and adds an ellipse. If you want to remove the elipses, use the code below:
//				//This code shortens the name to 25 chars.
//				if (full != null)
//			{
//			if(full.Length > 24)
//				{
//				//						shortName = shortName.Substring(0, 24); //Limit the row name to 20 charactors
//				}
//				rowNames.Add(shortName); 
//			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			NoteListUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));

			//Create the table and populate it with two cells
			table = new UITableView(View.Bounds); // defaults to Plain style
			table.AutoresizingMask = UIViewAutoresizing.All;
			//Create the Table rows from the source, passing the full text for all notes (which will also act as row names), and the current ViewController
			table.Source = new NotesTableSource(currentController, allNotes);
			Add(table);
			table.BackgroundColor = UIColor.Clear; //Make the table clear

			//Hide the back button
			this.NavigationItem.HidesBackButton = true;

			//Add Menu Button to the right
//			UIBarButtonItem MenuButton = new UIBarButtonItem();
//			MenuButton.Title = "Menu";
//			this.NavigationItem.SetRightBarButtonItem(MenuButton, false);

			//Create the Add note button and add it to the toolbar
			UIBarButtonItem AddNoteButton = new UIBarButtonItem();
			AddNoteButton.Image = UIImage.FromFile("cross-medium.png");
			AddNoteButton.TintColor = UIColor.FromRGB(120, 181, 4); //Change from default blue to green color.
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
				notesView.index = (allNotes.Count); 
				notesView.notes = allNotes;
				notesView.addingNote = true; //Let the new view know that we're trying to add a note as opposed to a "normal" segue
				//Segue to the NotesView
				currentController.NavigationController.PushViewController (notesView, false);
			};
		}

		//Adds a new note and refreshes the table
		public void refreshTable(List<string> newNotes)
		{
			//reacreate the allNotes List, now with our new note
			allNotes = newNotes;

			table = new UITableView(View.Bounds); // defaults to Plain style
			table.AutoresizingMask = UIViewAutoresizing.All;
			table.Source = new NotesTableSource(currentController, allNotes);

			table.ReloadData();
			Add (table);
		}

	}
}
