using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace GFS_iOS
{
	partial class SearchViewController : UIViewController
	{
		public SearchViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			string[] hints1 = new string[] {"cabinet", "cabinet door", "cabbage"};
			HintTable.Source = new TableSource(hints1);
			HintTable.ScrollEnabled = true;
			HintTable.Hidden = true;

			//this.SearchBar.OnEditingStarted --- EventArgs
			this.SearchBar.TextChanged += (object sender, UISearchBarTextChangedEventArgs e) =>
			{
				if (SearchBar.Text == "")
				{
					HintTable.Hidden = true;
				}
				else
				{
					if(SearchBar.Text == "c")
					{
						string[] tempHints = new string[] { "cat", "cool", "chrome", "call", "cake", "cab" };
						HintTable.Source = new TableSource(tempHints);
						HintTable.ReloadData();
					}
					if (SearchBar.Text == "ca")
					{
						string[] tempHints = new string[] { "cat", "call", "cake", "cab", "cable", "cabbage" };
						HintTable.Source = new TableSource(tempHints);
						HintTable.ReloadData();
					}
					if (SearchBar.Text == "cab")
					{
						string[] tempHints = new string[] { "cab", "cabin", "cabinet", "cabinetry", "cable", "cabbage" };
						HintTable.Source = new TableSource(tempHints);
						HintTable.ReloadData();
					}
					if (SearchBar.Text == "cabi")
					{
						string[] tempHints = new string[] { "cabin", "cabinet"};
						HintTable.Source = new TableSource(tempHints);
						HintTable.ReloadData();
					}
					if (SearchBar.Text == "cabin")
					{
						string[] tempHints = new string[] { "cabin", "cabinet" };
						HintTable.Source = new TableSource(tempHints);
						HintTable.ReloadData();
					}
					if (SearchBar.Text == "cabine")
					{
						string[] tempHints = new string[] { "cabinet"};
						HintTable.Source = new TableSource(tempHints);
						HintTable.ReloadData();
					}
					if (SearchBar.Text == "cabinet")
					{
						string[] tempHints = new string[] { "cabinet"};
						HintTable.Source = new TableSource(tempHints);
						HintTable.ReloadData();
					}

					HintTable.Hidden = false;
				}
			};

			// Perform any additional setup after loading the view, typically from a nib.
		}
	}

	public class TableSource : UITableViewSource
	{
		string[] tableItems;
		string cellIdentifier = "TableCell";
		public TableSource(string[] items)
		{
			tableItems = items;
		}
		public override int RowsInSection(UITableView tableview, int section)
		{
			return tableItems.Length;
		}
		public override UITableViewCell GetCell(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
			cell.TextLabel.Text = tableItems[indexPath.Row];
			return cell;
		}
	}
}
