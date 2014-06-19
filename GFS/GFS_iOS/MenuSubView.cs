using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GFS_iOS
{
    class MenuSubView
    {
        //Initializing variables 
        UIButton MenuButton;
        UIViewController parentController;
        UIViewController menuViewController;
        UIView menuView;
        int Y;

        public MenuSubView(UIViewController viewController, UIButton button, int startingY)
        {
            //MenuSubView constructor, takes parent controller, button and a starting Y coordinate 
            //Y coordinate either be 0 or 64
            Y = startingY;
            parentController = viewController;
            MenuButton = button;
			//Start the button in the unclicked state since it hasn't been clicked yet
            MenuButton.TouchUpInside += HandleTouchUpInsideMenuUnclicked;
        }

		//Sets the button to it's unclicked state.
        void HandleTouchUpInsideMenuUnclicked(object sender, EventArgs e)
        {
            MenuButton.TouchUpInside -= HandleTouchUpInsideMenuUnclicked;
            MenuButton.TouchUpInside += HandleTouchUpInsideMenuHide;
            UIStoryboard board = UIStoryboard.FromName("MainStoryboard", null);
            menuViewController = (MenuTableViewController)board.InstantiateViewController(
                "menuTable"
            );

            menuViewController.View.Frame = new RectangleF(20, Y, 300, 504);
            menuView = menuViewController.View;
            parentController.AddChildViewController(menuViewController);
            parentController.View.AddSubview(menuView);
        }

        void HandleTouchUpInsideMenuShow(object sender, EventArgs e)
        {
            menuView.Hidden = false;
            MenuButton.TouchUpInside -= HandleTouchUpInsideMenuShow;
            MenuButton.TouchUpInside += HandleTouchUpInsideMenuHide;
        }

        void HandleTouchUpInsideMenuHide(object sender, EventArgs e)
        {
            menuView.Hidden = true;
            MenuButton.TouchUpInside -= HandleTouchUpInsideMenuHide;
            MenuButton.TouchUpInside += HandleTouchUpInsideMenuShow;
        }

        public UIButton setButton()
        {
            return MenuButton;
        }
    }
}