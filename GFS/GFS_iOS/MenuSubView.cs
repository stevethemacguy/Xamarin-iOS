using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GFS_iOS
{
	public class MenuSubView
    {
		private static MenuSubView instance; //There can only be one instance of the MenuSubView.

        //Initializing variables 
        UIViewController parentController;
        UIViewController menuViewController;
        UIView menuView;
        UIImageView img;
		private Boolean menuIsVisible = false;

		//Can't be instantiated except by the getInstance method
		protected MenuSubView()
        {
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

		public void toggleMenu(UIViewController viewController, int startingY)
		{
			//if the menu is visible, then hide it
			if (menuIsVisible) {
				img.Hidden = true;
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

				//Y coordinate will be either 0 or 64
				parentController = viewController;

				menuViewController.View.Frame = new RectangleF(20, startingY, 300, 504);
				menuView = menuViewController.View;
				img = new UIImageView(UIImage.FromFile("greyTrans.png"));
				img.Frame = new RectangleF(0, startingY, 20, 504);
				img.Hidden = false;
				menuView.Hidden = false;
				parentController.AddChildViewController(menuViewController);
				parentController.View.AddSubview(menuView);
				parentController.View.AddSubview(img);
				menuIsVisible = true;
			}
		}

		public void clearSubView()
		{
			if (menuIsVisible) {
				img.Hidden = true;
				menuView.Hidden = true;
				menuIsVisible = false;
			} 
		}
    }
}