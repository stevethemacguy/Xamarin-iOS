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
		public string[] rowNames; //Used to store the row titles. These are changed to the first line of text when saved.
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
				allNotes.Add("A Super Awesome Note that spans multiple lines. Cras mattis consectetur purus sit amet fermentum. Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
				allNotes.Add("A very special note");
				rowNames = new string[2]; 
			}

			//Create a row for each note, using the actual note text as the row name
			for (int i = 0 ;i < allNotes.Count ; i++)
			{
				string full = allNotes[i];
				string shortName = full;
				//iOS automatically shortens the name and adds an ellipse. If you want to remove the elipses, use the code below:
				//This code shortens the name to 25 chars.
//				if (full != null)
//				{
// 					if(full.Length > 24)
//					{
				//						shortName = shortName.Substring(0, 24); //Limit the row name to 20 charactors
//					}
//				}
				rowNames[i] = shortName; 
				//noteCount++;
			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//Create the table and populate it with two cells
			table = new UITableView(View.Bounds); // defaults to Plain style
			table.AutoresizingMask = UIViewAutoresizing.All;
			//Create the Table rows from the source, passing to it the rowNames, the full text for all notes, and the current ViewController
			table.Source = new NotesTableSource(currentController, rowNames, allNotes);
			Add(table);

			//Create the Add note button and add it to the toolbar
			UIBarButtonItem AddNoteButton = new UIBarButtonItem();
			AddNoteButton.Image = UIImage.FromFile("cross.png");
			AddNoteButton.TintColor = UIColor.FromRGB(120, 181, 4); //Change from default blue to green color.
			this.NavigationItem.SetRightBarButtonItem(AddNoteButton, false);

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
				notesView.addingNote = true;
				//Segue to the NotesView
				currentController.NavigationController.PushViewController (notesView, false);
			};
		}

		//Adds a new note and refreshes the table
		public void refreshTable(string[] newRows, string justAdded)
		{
			//reacreate the allNotes List, now with our new note
			allNotes = new List<string>();
			foreach(string s in newRows){
				allNotes.Add(s);
			}
			table = new UITableView(View.Bounds); // defaults to Plain style
			table.AutoresizingMask = UIViewAutoresizing.All;
			table.Source = new NotesTableSource(currentController, newRows, allNotes);

			table.ReloadData();
			Add (table);
		}

		public void createNote()
		{


			//allNotes.Add(""); //Add an empty note to the note list.

		}
	}
}
