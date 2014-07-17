using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Threading.Tasks;
using Swx.B2B.Ecom.BL.Managers;
using System.Collections.Generic;
using Swx.B2B.Ecom.BL.Entities;

//Initial Search Screen. Words are entered into the search bar to load search results
namespace GFS_iOS
{
	partial class SearchViewController : UIViewController
	{
		SearchViewController currentController;
		UIBarButtonItem menuB2;

		//ProductManager productSuggestions = new ProductManager();

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

			HintTable.ScrollEnabled = true;
			HintTable.Hidden = true;

			//Stores the last search terms returned from the Web Service. See below.
			List<String> cachedSuggestedTerms = new List<String>();

			//this.SearchBar.OnEditingStarted --- EventArgs
			this.SearchBar.TextChanged += (object sender, UISearchBarTextChangedEventArgs e) =>
			{
				if (SearchBar.Text == "")
				{
					HintTable.Hidden = true;
				}
				else
				{
					//Make a call to the Web service to get back suggestions based on the search term.
					ProductManager pm = new ProductManager();
					List<String> suggestedTerms = pm.getProductSearchSuggestions(SearchBar.Text);

					//Web service returns nothing once you type a full word, so when nothing is returned, keeping showing the "previous" suggestions
					if (suggestedTerms.Count == 0)
					{
						//Use the terms from the last search
						suggestedTerms = cachedSuggestedTerms;
					}
					else
					{
						//Cache these words so we don't lose them
						cachedSuggestedTerms = suggestedTerms;
					}

					//Update the Table Source to use the returned words.
					HintTable.Source = new TableSource(currentController, suggestedTerms.ToArray());
                    HintTable.ReloadData();
					HintTable.Hidden = false;
				}
			};
		}

		//Show the loading screen.
		public void showOverlay()
		{
			//Dismiss the keyboard
			SearchBar.ResignFirstResponder();
			loadingOverlay = new LoadingOverlay(UIScreen.MainScreen.Bounds);
			View.Add(loadingOverlay);
		}

		//Hide the loading screen.
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
			//We don't want to permanently cache images for previous searches, so clear the image cache.
			ImageCache.getInstance().clearCache(); 

			////Segue to the new live search results

			//Show the loading screen while we wait for the database to load
			controller.showOverlay();

			//The selected search term (i.e. selected row)
			String searchTerm = tableItems[indexPath.Row];

			//Stores a list of products created from the parsed Json
			List<Product> jsonResults = new List<Product>();

			//Makes a call to the Webservice and returns the products that match the selected search term.
			await Task.Factory.StartNew (() => {
				ProductManager pm = new ProductManager();
				jsonResults = pm.getProductsBySearchTerm(searchTerm);
			});

			//Get a map of all products in the DB (see loop below)
			Dictionary<String, Product> dbProductMap = DataSource.getInstance().getAllProducts();

			// For all of the newly created products:
			//	- Create the product's image in ImageCache
			//	- Highlight products if they are in a saved list
			foreach (Product p in jsonResults)
			{
				//Add the Product's image url to the Image cache to be later used by Product Cells.
				//The addImage() method handles empty urls for products without images.
				ImageCache.getInstance().addImage(p.getCode(), p.getImageFileName());

				//If the search-result Product is already in the Database
				if (dbProductMap.ContainsKey(p.getCode()))
				{
					//Check if the matching product in the DB is in a saved list
					if(dbProductMap[p.getCode()].isProductInASavedList())
					{
						//If the Product is in a saved list, highlight the Product
						p.addHighlight();
					}
					else{
						//If the Product is NOT in a saved list, remove any previous highlight.
						p.removeHighlight();
					}
				}
			}

			//Once the task finishes, hide the loading screen.
			controller.hideOverlay();

			LiveResultsViewController liveResults = new LiveResultsViewController();

			////HIGHLIGHT THE FIRST CELL FOR DEMO ONLY. ////
			//Important to check count or you will get an out of bounds error.
//			if(jsonResults.Count >= 1)
//			{
//				jsonResults [0].addHighlight();
//				//jsonResults [3].addHighlight();
//				//jsonResults [5].addHighlight();
//			}	

			//Pass along the products matched by the search term to the LiveResultsViewController
			liveResults.products = jsonResults;
		
			//Segue
			controller.NavigationController.PushViewController (liveResults, true); //yes, animate the segue 
		}
	}
}
