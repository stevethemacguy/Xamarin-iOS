using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Drawing;
using Swx.B2B.Ecom.BL.Managers;

namespace GFS_iOS
{
	partial class SearchViewController : UIViewController
	{
		SearchViewController currentController;
        MenuSubView menuView;
        Swx.B2B.Ecom.BL.Managers.ProductManager productSuggestions = new ProductManager();

		UIBarButtonItem menuB2;

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
//			menuButton31 = UIButton.FromType(UIButtonType.Custom);
//			menuButton31.SetBackgroundImage(UIImage.FromFile("menuIconShifted.png"), UIControlState.Normal);
//			menuButton31.Frame = new RectangleF(new PointF(282,11), new SizeF(new PointF((float) 22.0,(float) 22.0)));
//			this.NavigationController.NavigationBar.Add(menuButton31);
//
			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();

			//Create the Menu button
			menuB2 = new UIBarButtonItem(UIImage.FromFile("menuIconShifted.png"), UIBarButtonItemStyle.Plain, 
				//When clicked
				(sender, args) => {
					//Dismiss the keyboard when the menu button is pressed.
					SearchBar.ResignFirstResponder();
					if (menuView.isVisible()) {
						//Change X image back to the normal menu image
						menuB2.Image = UIImage.FromFile("menuIconShifted.png");
					} else {
						//Make Button show the X image once it's pressed.
						menuB2.Image = UIImage.FromFile("XIcon.png");
					}
					menuView.toggleMenu(this, 64);
				});
			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menuB2, true);


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
				    string[] suggestedTerms = new string[5];
                    suggestedTerms = productSuggestions.GetProductSearchSuggestions(SearchBar.Text);
                    HintTable.Source = new TableSource(currentController, suggestedTerms);
                    /*
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
                     */
                    HintTable.ReloadData();
					HintTable.Hidden = false;
                     
				}
			};
			// Perform any additional setup after loading the view, typically from a nib.
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
