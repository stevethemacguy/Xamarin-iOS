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
        int flag; //flag == 0 -> view has not created ||| flag == 1 -> view created

        public MenuSubView(UIViewController viewController, UIButton button, int startingY)
        {
            //MenuSubView constructor, takes parent controller, button and a starting Y coordinate 
            //Y coordinate either be 0 or 64
            Y = startingY;
            parentController = viewController;
            MenuButton = button;
            MenuButton.TouchUpInside += HandleTouchUpInsideMenuUnclciked;
            flag = 0;

        }

        void HandleTouchUpInsideMenuUnclciked(object sender, EventArgs e)
        {
            MenuButton.TouchUpInside -= HandleTouchUpInsideMenuUnclciked;
            MenuButton.TouchUpInside += HandleTouchUpInsideMenuHide;
            UIStoryboard board = UIStoryboard.FromName("MainStoryboard", null);
            menuViewController = (MenuTableViewController)board.InstantiateViewController(
                "menuTable"
            );

            menuViewController.View.Frame = new RectangleF(20, Y, 300, 504);
            menuView = menuViewController.View;
            parentController.AddChildViewController(menuViewController);
            parentController.View.AddSubview(menuView);
            flag = 1;
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

        public void clearSubView()
        {
            if(flag == 1)
            {
                menuView.Hidden = true;
                MenuButton.TouchUpInside -= HandleTouchUpInsideMenuHide;
                MenuButton.TouchUpInside += HandleTouchUpInsideMenuShow;    
            }
        }

        public UIButton setButton()
        {
            return MenuButton;
        }
    }
}