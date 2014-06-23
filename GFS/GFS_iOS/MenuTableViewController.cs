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

		//Before seguing to a new view, make sure the menu's "visibility" is set to false
		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);
			MenuSubView mainMenu = MenuSubView.getInstance();
			//After seguing to a new view, the main menu "disappears," but toggleMenu() was never called so menuIsVisible is still true
			//menuIsVisible should always be false when a new view is loaded, so that clicking the button brings up the menu immediately
			mainMenu.setVisibility(false); 
			//mainMenu.toggleMenu(this, 64); //This can be used to do the same thing, but it's more clear to have a setVisibility method.
		}

		//"Unwind Segue". 
		[Action ("UnwindToMenu:")]
		public void UnwindToMenu (UIStoryboardSegue segue)
		{
			//do nothing
		}
	}
}