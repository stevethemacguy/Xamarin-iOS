using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace GFS_iOS
{
	partial class ManualListTableController : UITableViewController
	{
        MenuSubView menuView;
		UIBarButtonItem menuB11;

		public ManualListTableController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();

			//Create the Menu button
			menuB11 = new UIBarButtonItem(UIImage.FromFile("menuIconShifted.png"), UIBarButtonItemStyle.Plain, 
				//When clicked
				(sender, args) => {
					if (menuView.isVisible()) {
						//Change X image back to the normal menu image
						menuB11.Image = UIImage.FromFile("menuIconShifted.png");
					} else {
						//Make Button show the X image once it's pressed.
						menuB11.Image = UIImage.FromFile("XIcon.png");
					}
					menuView.toggleMenu(this, 0);
				});
			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menuB11, true);

			ManualListCell1.BackgroundColor = UIColor.Clear;
			//ManualListCell2.BackgroundColor = UIColor.Clear;
			ManualListView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));
		}
	}
}
