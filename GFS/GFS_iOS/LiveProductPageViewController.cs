using System;
using MonoTouch.UIKit;

namespace GFS_iOS
{
	partial class LiveProductPageViewController : UIViewController
	{
		MenuSubView menuView;
		UIBarButtonItem menub101;
		LiveProductPageViewController currentController;

		public int index; //Index of the cell row that pushed to this view
		public String rowName; //Name of the cell row that pushed to this view
		public LiveProductPageViewController()
		{
			currentController = this;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();

			//Create the Menu button
			menub101 = new UIBarButtonItem(UIImage.FromFile("menuIconShifted.png"), UIBarButtonItemStyle.Plain, 
				//When clicked
				(sender, args) => {
					if (menuView.isVisible()) {
						//Change X image back to the normal menu image
						menub101.Image = UIImage.FromFile("menuIconShifted.png");
					} else {
						//Make Button show the X image once it's pressed.
						menub101.Image = UIImage.FromFile("XIcon.png");
					}
					menuView.toggleMenu(this, 64);
				});
			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menub101, true);

			this.View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background568.png"));
		}
	}
}

