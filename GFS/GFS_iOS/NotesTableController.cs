using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace GFS_iOS
{
	partial class NotesTableController : UITableViewController
	{
		UITableView table;
		public string[] allNotes; //An array of strings. Each string is the text of one note
		//The Strings are associated to each cell by their index. So cell0 will have note[0] for it's text.
		//If the segue doesn't handle passing properly, then Make the saved text/note combo public so we can update it.

		NotesTableController currentController; 
		public string[] rowNames; //Used to store the row titles. These are changed to the first line of text when saved.

		public NotesTableController (IntPtr handle) : base (handle)
		{
			allNotes = new String[10];
			allNotes[0] = "Super Awesome Note";
			allNotes[1] = "A very special note";
			currentController = this;
			rowNames = new string[10]; 
			rowNames[0] = "First Row";
			rowNames[1] = "Second Row";
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//Create the table and populate it with two cells
			table = new UITableView(View.Bounds); // defaults to Plain style
			table.AutoresizingMask = UIViewAutoresizing.All;
			table.Source = new NotesTableSource(currentController, rowNames, allNotes);
			Add (table);

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
