using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace GFS_iOS
{
	partial class MenuTableViewController : UITableViewController
	{
		//TestView test;
		public MenuTableViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//Make the Cells have a clear background color
			SearchCell.BackgroundColor = UIColor.Clear;
			CartCell.BackgroundColor = UIColor.Clear;
			NotesCell.BackgroundColor = UIColor.Clear;
			SavedListsCell.BackgroundColor = UIColor.Clear;
			SavedManualsCell.BackgroundColor = UIColor.Clear;
			YourAccountCell.BackgroundColor = UIColor.Clear;
			HomeCell.BackgroundColor = UIColor.Clear;

			//Set Background to a solid color. NOTE: the Toolbar is transparent and will ajdust to the "same" color as the background for some reason.
			//MenuView.BackgroundColor = UIColor.FromRGB (60,100,100);

			//Set Background to an image. NOTE: the Toolbar is transparent and will ajdust to the "same" color as the background for some reason.
			MenuView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			//base.RowSelected(tableView, indexPath);

			tableView.DeselectRow (indexPath, true); // iOS convention is to remove the highlight

			//The selected row
			int selectedRow = indexPath.Row;

			//If Saved manuals was pressed, manually push the next view since we're no longer using the storyboard to control segues
			if (selectedRow == 4)
			{
				SavedManualsViewController manualsView = new SavedManualsViewController();

				//Segue
				this.NavigationController.PushViewController (manualsView, true); //yes, animate the segue 
			}
		}

		//When the back button is pressed
		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			MenuSubView menuView = MenuSubView.getInstance();
			//If the back button was pressed while the menu was still visible
			if(menuView.isVisible())
			{
				menuView.toggleMenu(this, 0); //Make sure toggle view is still called to close the menu properly
			}
		}

		//Before seguing to a new view, make sure the menu's "visibility" is set to false
		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);
			MenuSubView mainMenu = MenuSubView.getInstance();
			//After seguing to a new view, the main menu "disappears," but toggleMenu() was never called so menuIsVisible is still true.
			//menuIsVisible should always be false when a new view is loaded, so that clicking the button brings up the menu immediately
			//Thus toggleMenu() needs to be called any time the menu needs to be closed or opened. 
			mainMenu.toggleMenu(this, 64); //The 64 doesn't matter since we're really just closing the menu with this call
		}

		//"Unwind Segue" 
		[Action ("UnwindToMenu:")]
		public void UnwindToMenu (UIStoryboardSegue segue)
		{
			//do nothing
		}
	}
}