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

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
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

			//Set Background to a solid color. NOTE: the Toolbar is transparent and will ajdust to the "same" color as the background for some reason.
			//MenuView.BackgroundColor = UIColor.FromRGB (60,100,100);

			//Set Background to an image. NOTE: the Toolbar is transparent and will ajdust to the "same" color as the background for some reason.
			MenuView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));
		}

		//"Unwind Segue". 
		[Action ("UnwindToMenu:")]
		public void UnwindToMenu (UIStoryboardSegue segue)
		{
			//do nothing
		}
	}
}