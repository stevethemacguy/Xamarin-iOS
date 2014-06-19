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
        MenuSubView menuView;

		public SavedListsTableController (IntPtr handle) : base (handle)
		{
			currentController = this; //Maintain a reference to this controller
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
            menuView = new MenuSubView(currentController, MenuB3, 0);
            MenuB3 = menuView.setButton();
			
            SavedListsUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));

			//Create the table and populate it with two cells
			table = new UITableView(View.Bounds); // defaults to Plain style
			table.AutoresizingMask = UIViewAutoresizing.All;
			//Create the Table rows from the source, passing the full text for all notes (which will also act as row names), and the current ViewController
			table.Source = new SavedListTableSource(currentController);
			Add(table);
			table.BackgroundColor = UIColor.Clear; //Make the table clear
		}

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            menuView.clearSubView();
        }
	}
}
