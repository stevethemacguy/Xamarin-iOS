using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Threading.Tasks;
using Swx.B2B.Ecom.BL.Managers;

namespace GFS_iOS
{
	partial class SearchViewController : UIViewController
	{
		SearchViewController currentController;
		UIBarButtonItem menuB2;

		Swx.B2B.Ecom.BL.Managers.ProductManager productSuggestions = new ProductManager();

		private LoadingOverlay loadingOverlay;

		public SearchViewController (IntPtr handle) : base (handle)
		{
			currentController = this;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//Hide the back button
			this.NavigationItem.HidesBackButton = true;

			//Create the MainMenu UIBarButtonItem and intialize the flyout Main Menu view
			menuB2 = new MainMenuButton().getButton(this, 64); 

			//Hide the keyboard when the main menu button is clicked.
			menuB2.Clicked += (sender, e) => {
				SearchBar.ResignFirstResponder();
			};

			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menuB2, true);

			//Set Background to an image. NOTE: the Toolbar is transparent and will ajdust to the "same" color as the background for some reason.
			SearchUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background568.png"));

			string[] hints = new string[]{""};
			HintTable.Source = new TableSource(currentController, hints);
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
				    string[] suggestedTerms = new string[5];
                    suggestedTerms = productSuggestions.GetProductSearchSuggestions(SearchBar.Text);
                    HintTable.Source = new TableSource(currentController, suggestedTerms);
                    /*
					if(SearchBar.Text == "a")
					{
						hints = new string[] { "apple", "adobe", "adapter", "apature", "addition"};
						HintTable.Source = new TableSource(currentController, hints);
					}
					else{
						hints = new string[] {""};
						HintTable.Source = new TableSource(currentController, hints);
					}
					if (SearchBar.Text == "ap")
					{
						hints = new string[] { "apple", "apature" };
						HintTable.Source = new TableSource(currentController, hints);
					}
					if (SearchBar.Text.StartsWith("apa"))
					{
						hints = new string[] { "apature" };
						HintTable.Source = new TableSource(currentController, hints);
					}
					if (SearchBar.Text.StartsWith("app"))
					{
						hints = new string[] { "apple" };
						HintTable.Source = new TableSource(currentController, hints);
					}
					if (SearchBar.Text == "ad")
					{
						hints = new string[] { "adobe", "adapter", "addition", "adaptive"};
						HintTable.Source = new TableSource(currentController, hints);
					}
					if (SearchBar.Text.StartsWith("ado"))
					{
						hints = new string[] { "adobe"};
						HintTable.Source = new TableSource(currentController, hints);
					}
					if (SearchBar.Text == "ada")
					{
						hints = new string[] { "adapter", "adaptive"};
						HintTable.Source = new TableSource(currentController, hints);
					}
					if (SearchBar.Text.StartsWith("add"))
					{
						hints = new string[] { "addition"};
						HintTable.Source = new TableSource(currentController, hints);
					}
					if (SearchBar.Text == "adap")
					{
						hints = new string[] { "adapter", "adaptive"};
						HintTable.Source = new TableSource(currentController, hints);
					}
					if (SearchBar.Text == "adapt")
					{
						hints = new string[] { "adapter","adaptive"};
						HintTable.Source = new TableSource(currentController, hints);
					}
					if (SearchBar.Text.StartsWith("adapti"))
					{
						hints = new string[] { "adaptive"};
						HintTable.Source = new TableSource(currentController, hints);
					}
					if (SearchBar.Text.StartsWith("adapte"))
					{
						hints = new string[] { "adapter"};
						HintTable.Source = new TableSource(currentController, hints);
					}
                    */

                    HintTable.ReloadData();
					HintTable.Hidden = false;
				}
			};
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public void showOverlay()
		{
			//Dismiss the keyboard
			SearchBar.ResignFirstResponder();
			loadingOverlay = new LoadingOverlay(UIScreen.MainScreen.Bounds);
			View.Add(loadingOverlay);
		}

		public void hideOverlay()
		{
			loadingOverlay.Hide();
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

		//When any row is selected. Async is used so we can stop the code from continuing until the task is complete (see await below).
		public async override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			////Segue to the old search results
//			//Get the current storyboard
//			UIStoryboard test = UIStoryboard.FromName("MainStoryboard", null); 
//
//			//Get the searchResultsController View Controller 
//			SearchResultsTableController ok = (SearchResultsTableController) test.InstantiateViewController(  
//				"searchResultsController"
//			);
//			//Segue to the new View
//		    controller.NavigationController.PushViewController(ok, true);

			////Segue to the new live search results

			//Show the loading screen while we wait for the database to load
			controller.showOverlay();

			//await says to wait until the task is completed before continuing (in this case in initializeDBfromJSON())
			//Creates all the products in the database using JSON	
			await Task.Factory.StartNew (() => {
				DataSource db = DataSource.getInstance();
				//Initialize using JSON
				db.initializeDBfromJSON();
			});

			//Once the task finishes, hide the overlay.
			controller.hideOverlay();


			LiveResultsViewController liveResults = new LiveResultsViewController();

			//Segue
			controller.NavigationController.PushViewController (liveResults, true); //yes, animate the segue 
		}
	}
}
