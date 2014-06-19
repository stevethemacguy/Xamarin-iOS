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
        UIImageView img;
        int Y;
        int flag; //flag == 0 -> view has not created ||| flag == 1 -> view created

        public MenuSubView(UIViewController viewController, UIButton button, int startingY)
        {
            //MenuSubView constructor, takes parent controller, button and a starting Y coordinate 
            //Y coordinate either be 0 or 64
            Y = startingY;
            parentController = viewController;
            MenuButton = button;

			//Start the button in the unclicked state since it hasn't been clicked yet
			MenuButton.TouchUpInside += HandleTouchUpInsideMenuUnclicked;
            flag = 0;

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
            img = new UIImageView(UIImage.FromFile("greyTrans.png"));
            img.Frame = new RectangleF(0, Y, 20, 504);
            parentController.AddChildViewController(menuViewController);
            parentController.View.AddSubview(menuView);
            parentController.View.AddSubview(img);
            flag = 1;
        }

        void HandleTouchUpInsideMenuShow(object sender, EventArgs e)
        {
            img.Hidden = false;
            menuView.Hidden = false;
            MenuButton.TouchUpInside -= HandleTouchUpInsideMenuShow;
            MenuButton.TouchUpInside += HandleTouchUpInsideMenuHide;
        }

        void HandleTouchUpInsideMenuHide(object sender, EventArgs e)
        {
            img.Hidden = true;
            menuView.Hidden = true;
            MenuButton.TouchUpInside -= HandleTouchUpInsideMenuHide;
            MenuButton.TouchUpInside += HandleTouchUpInsideMenuShow;
        }

        public void clearSubView()
        {
            if(flag == 1)
            {
                img.Hidden = true;
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