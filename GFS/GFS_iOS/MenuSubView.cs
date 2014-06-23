using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GFS_iOS
{
	//A "Flyout" Subview that appears whener the white Menu button in the navigation bar is tapped.
	//MenuSubView is a Singleton
	public class MenuSubView
    {
		private static MenuSubView instance; //There can only be one instance of the MenuSubView.

		UIViewController menuViewController;
        UIView menuView;
		UIImageView transaparentBackground;
		private Boolean menuIsVisible;

		//Can't be instantiated except by the getInstance method
		protected MenuSubView()
        {
			menuIsVisible = false;
        }

		public void setVisibility(bool trueOrFalse)
		{
			menuIsVisible = trueOrFalse;
		}

		public Boolean isVisible()
		{
			return menuIsVisible;
		}

		public static MenuSubView getInstance()
		{
			//If the MenuSubView has not been created, then create it once.
			if(instance == null) {
				instance = new MenuSubView();
			}
			return instance;
		}

		//startingY coordinate will be either 0 or 64
		public void toggleMenu(UIViewController viewController, int startingY)
		{
			//if the menu is visible, then hide it
			if (menuIsVisible) {
				transaparentBackground.Hidden = true;
				menuView.Hidden = true;
				menuIsVisible = false;
				return;
			} 
			//Otherwise, show the menu
			else
			{
				UIStoryboard board = UIStoryboard.FromName("MainStoryboard", null);
				menuViewController = (MenuTableViewController)board.InstantiateViewController(
					"menuTable"
				);

				menuViewController.View.Frame = new RectangleF(20, startingY, 300, 504);
				menuView = menuViewController.View;
				transaparentBackground = new UIImageView(UIImage.FromFile("greyTrans.png"));
				transaparentBackground.Frame = new RectangleF(0, startingY, 20, 504);

				viewController.AddChildViewController(menuViewController);
				viewController.View.AddSubview(menuView);
				viewController.View.AddSubview(transaparentBackground);

				menuIsVisible = true;
			}
		}
    }
}