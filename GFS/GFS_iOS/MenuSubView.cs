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
        UIButton MenuButton;
        UIViewController parentController;
        UIViewController menuViewController;
        UIView menuView;
        int X;

        public MenuSubView(UIViewController viewController, UIButton button, int startingX)
        {
            X = startingX;
            parentController = viewController;
            MenuButton = button;
            MenuButton.TouchUpInside += HandleTouchUpInsideMenuUnclciked;
        }

        void HandleTouchUpInsideMenuUnclciked(object sender, EventArgs e)
        {
            MenuButton.TouchUpInside -= HandleTouchUpInsideMenuUnclciked;
            MenuButton.TouchUpInside += HandleTouchUpInsideMenuHide;
            UIStoryboard board = UIStoryboard.FromName("MainStoryboard", null);
            menuViewController = (MenuTableViewController)board.InstantiateViewController(
                "menuTable"
            );

            menuViewController.View.Frame = new RectangleF(0, X, 300, 504);
            //menuViewController.View.Frame = new RectangleF(0, 64, 300, 504);
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