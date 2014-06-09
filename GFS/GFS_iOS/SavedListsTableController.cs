using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace GFS_iOS
{
	partial class SavedListsTableController : UITableViewController
	{
		public UITableView table;
		SavedListsTableController currentController;

		public SavedListsTableController (IntPtr handle) : base (handle)
		{
			currentController = this; //Maintain a reference to this controller
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//List1Cell.BackgroundColor = UIColor.Clear;
			//List2Cell.BackgroundColor = UIColor.Clear;
			SavedListsUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));

			//Create the table and populate it with two cells
			table = new UITableView(View.Bounds); // defaults to Plain style
			table.AutoresizingMask = UIViewAutoresizing.All;
			//Create the Table rows from the source, passing the full text for all notes (which will also act as row names), and the current ViewController
			table.Source = new SavedListTableSource(currentController);
			Add(table);


//			//Get the current storyboard
//			UIStoryboard board = UIStoryboard.FromName("MainStoryboard", null); 
//
//			//Get the SavedListsTable view
//			NotesViewController notesView = (NotesViewController) board.InstantiateViewController(  
//				"SavedListsUIView"
//			);

		}

	}
}
