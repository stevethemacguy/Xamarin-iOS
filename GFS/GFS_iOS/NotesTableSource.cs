using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace GFS_iOS
{
	public class NotesTableSource : UITableViewSource {

		protected List<string> tableItems; //Each string is the full text of one note
		protected string cellIdentifier = "testCell";
		UIViewController parentController; //Used to store the parent controller of this TableSource

		public NotesTableSource (UIViewController parentController, List<string> notes)
		{
			tableItems = notes;
			this.parentController = parentController;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return tableItems.Count;
		}

		//When the row is clicked, segue to the note view and pass all note data
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, true); // iOS convention is to remove the highlight

			//Get the current storyboard
			UIStoryboard board = UIStoryboard.FromName("MainStoryboard", null); 

			//Get the NotesViewController
			NotesViewController notesView = (NotesViewController) board.InstantiateViewController(  
				"notesViewController"
			);

			//"Pass" along the index of the selected row to the index member variable
			notesView.index = indexPath.Row;  //The index of the row being selected

			//"Pass" along the actual notes
			notesView.notes = tableItems;

			notesView.tableController = (NotesTableController) parentController;

			//Segue to the NotesView
			parentController.NavigationController.PushViewController (notesView, false);
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			// request a recycled cell to save memory
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
			cell.TextLabel.Text = tableItems[indexPath.Row];
			return cell;
		}
	}
}
