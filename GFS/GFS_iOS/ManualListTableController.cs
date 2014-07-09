using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace GFS_iOS
{
	partial class ManualListTableController : UITableViewController
	{
		UIBarButtonItem menuB11;

		public ManualListTableController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Create the MainMenu UIBarButtonItem and intialize the flyout Main Menu view
			menuB11 = new MainMenuButton().getButton(this, 0);

			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menuB11, true);

			ManualListCell1.BackgroundColor = UIColor.Clear;
			//ManualListCell2.BackgroundColor = UIColor.Clear;
			ManualListView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));
		}
	}
}
