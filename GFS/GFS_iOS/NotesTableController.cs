using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace GFS_iOS
{
	partial class NotesTableController : UITableViewController
	{
		public UITableView table; //Only one table per time
		public string[] allNotes; //An array of strings. Each string is the text of one note
		//The Strings are associated to each cell by their index. So cell0 will have note[0] for it's text.
		//If the segue doesn't handle passing properly, then Make the saved text/note combo public so we can update it.

		NotesTableController currentController; 
		public string[] rowNames; //Used to store the row titles. These are changed to the first line of text when saved.

		public NotesTableController (IntPtr handle) : base (handle)
		{
			currentController = this;

			//If the array does not already exist, create it.
			if (allNotes == null)
			{
				allNotes = new string[10];
				//First time through, use defaults for row names
				allNotes[0] = "A Super Awesome Note that spans multiple lines. Cras mattis consectetur purus sit amet fermentum. Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
				allNotes[1] = "A very special note";
			}

			if (rowNames == null)
			{
				rowNames = new string[10]; 
			}

			//Create a row for each note, using the actual note text as the row name
			for (int i = 0 ;i < allNotes.Length ; i++)
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
			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//Create the table and populate it with two cells
			table = new UITableView(View.Bounds); // defaults to Plain style
			table.AutoresizingMask = UIViewAutoresizing.All;
			//Create the Table rows from the source, passing to it the rowNames and full text for all notes
			table.Source = new NotesTableSource(currentController, rowNames, allNotes);
			Add (table);

			//Create the Add note button and add it to the toolbar
			UIBarButtonItem AddNoteButton = new UIBarButtonItem();
			AddNoteButton.Image = UIImage.FromFile("cross.png");
			AddNoteButton.TintColor = UIColor.FromRGB(120, 181, 4); //Change from default blue to green color.
			this.NavigationItem.SetRightBarButtonItem(AddNoteButton, false);

		}

		public void refreshTable(string[] newRows)
		{
			table = new UITableView(View.Bounds); // defaults to Plain style
			table.AutoresizingMask = UIViewAutoresizing.All;
			table.Source = new NotesTableSource(currentController, newRows, allNotes);

			table.ReloadData();
			Add (table);
		}

		public void createRow()
		{

		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);
			var rowPath = table.IndexPathForSelectedRow;
			var test = segue.DestinationViewController as NotesViewController;
			test.notes = allNotes; //Send the list of "notes" (text) to the NotesViewController
		}

		//prepare for segue... 
		//		Pass the Cell index that was clicked (say index 1)
		//		Pass notes[1] since it corresponds to the cell that was clicked.
		//		When the save button is clicked
		//			1. "Aave" the text to notes[1]
		//			2. Change the title of cell1 to use this text
		//		Alternatively, just send this NotesTableController so it can access the fields directly?
		//

		//      If the saving method above doesn't work, than we may need to create the new note view manually so we can have a reference to the notes and save them some how.
	}
}
