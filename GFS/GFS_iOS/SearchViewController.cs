using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Drawing;

namespace GFS_iOS
{
	partial class SearchViewController : UIViewController
	{
		UIButton menuButton31;
		SearchViewController currentController;
        MenuSubView menuView;

		public SearchViewController (IntPtr handle) : base (handle)
		{
			currentController = this;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//Hide the back button
			this.NavigationItem.HidesBackButton = true;

			//Manually create a menu button and add it to the right side of the menu bar
			menuButton31 = UIButton.FromType(UIButtonType.Custom);
			menuButton31.SetBackgroundImage(UIImage.FromFile("menuIconShifted.png"), UIControlState.Normal);
			menuButton31.Frame = new RectangleF(new PointF(282,11), new SizeF(new PointF((float) 22.0,(float) 22.0)));
			this.NavigationController.NavigationBar.Add(menuButton31);

			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();
			menuButton31.TouchUpInside += (sender, e) => {
				if (menuView.isVisible())
				{
					//Change X image back to the normal menu image
					menuButton31.SetBackgroundImage(UIImage.FromFile("menuIconShifted.png"), UIControlState.Normal);
				}else{
					//Make Button show the X image once it's pressed.
					menuButton31.SetBackgroundImage(UIImage.FromFile("XIcon.png"), UIControlState.Normal);
				}
				menuView.toggleMenu(this, 64);
				//Dismiss the keyboard when the menu button is pressed.
				SearchBar.ResignFirstResponder();
			};


			//Set Background to an image. NOTE: the Toolbar is transparent and will ajdust to the "same" color as the background for some reason.
			SearchUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background568.png"));

			string[] hints1 = new string[] {"cabinet", "cabinet door", "cabbage"};
			HintTable.Source = new TableSource(currentController, hints1);
			HintTable.ScrollEnabled = true;
			HintTable.Hidden = true;

			//this.SearchBar.OnEditingStarted --- EventArgs
			this.SearchBar.TextChanged += (object sender, UISearchBarTextChangedEventArgs e) =>
			{
				string[] tempHints;
				if (SearchBar.Text == "")
				{
					HintTable.Hidden = true;
				}
				else
				{
					if(SearchBar.Text == "c")
					{
						tempHints = new string[] { "cat", "cool", "chrome", "call", "cake", "cab" };
						HintTable.Source = new TableSource(currentController, tempHints);
					}
					if (SearchBar.Text == "ca")
					{
						tempHints = new string[] { "cat", "call", "cake", "cab", "cable"};
						HintTable.Source = new TableSource(currentController, tempHints);
					}
					if (SearchBar.Text == "cab")
					{
						tempHints = new string[] { "cab", "cabin", "cabinet", "cabinetry", "cable"};
						HintTable.Source = new TableSource(currentController, tempHints);
					}
					if (SearchBar.Text == "cabi")
					{
						tempHints = new string[] { "cabin", "cabinet"};
						HintTable.Source = new TableSource(currentController, tempHints);
					}
					if (SearchBar.Text == "cabin")
					{
						tempHints = new string[] { "cabin", "cabinet" };
						HintTable.Source = new TableSource(currentController, tempHints);
					}
					if (SearchBar.Text == "cabine")
					{
						tempHints = new string[] { "cabinet"};
						HintTable.Source = new TableSource(currentController, tempHints);
					}
					if (SearchBar.Text == "cabinet")
					{
						tempHints = new string[] { "cabinet"};
						HintTable.Source = new TableSource(currentController, tempHints);
					}
                    HintTable.ReloadData();
					HintTable.Hidden = false;
				}
			};
			// Perform any additional setup after loading the view, typically from a nib.
		}

		//Show the Menu Button
		public override void ViewWillAppear(bool animated)
		{
			menuButton31.Hidden = false;
		}

		//Hide the Menu Button since we now have duplicates
        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
			menuButton31.Hidden = true;
			//Remove the button from the navbar. Otherwise it will appear as a double button when the next view is pushed!
			//this.NavigationController.NavigationBar.ViewWithTag(1).RemoveFromSuperview();
        }
	}

	class TableSource : UITableViewSource
	{
		SearchViewController controller;
		string[] tableItems;
		string cellIdentifier = "TableCell";

		public TableSource(SearchViewController controller, string[] items)
		{
			tableItems = items;
			this.controller = controller;
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

		//When any row is selected
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			//Get the current storyboard
			UIStoryboard test = UIStoryboard.FromName("MainStoryboard", null); 

			//Get the searchResultsController View Controller 
			SearchResultsTableController ok = (SearchResultsTableController) test.InstantiateViewController(  
				"searchResultsController"
			);
			//Segue to the new View
		    controller.NavigationController.PushViewController(ok, true);
		}
	}
}
