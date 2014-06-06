using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace GFS_iOS
{

	public class NotesTableSource : UITableViewSource {
		protected string[] tableItems;
		protected string cellIdentifier = "testCell";
		UIViewController parentController;

		public NotesTableSource (UIViewController parentController, string[] items)
		{
			tableItems = items;
			this.parentController = parentController;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return tableItems.Length;
		}

		//When the row is clicked, segue to the note view.
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			//tableItems[indexPath] the actual text of the row
			Console.WriteLine(indexPath.Row); //the row number
			tableView.DeselectRow (indexPath, true); // iOS convention is to remove the highlight

			var index = indexPath.Row;
			//Do the segue
			//Get the current storyboard
			UIStoryboard board = UIStoryboard.FromName("MainStoryboard", null); 

			//Get the NotesViewController
			NotesViewController notesView = (NotesViewController) board.InstantiateViewController(  
				"notesViewController"
			);
			//Segue to the new View
			parentController.NavigationController.PushViewController (notesView, false);
			notesView.index = indexPath.Row;
			//segue.Perform;
			//UINavigationController.PushViewController("NotesViewController");
			//PerformSegue("MyRowSelectedSegue", indexPath);
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
