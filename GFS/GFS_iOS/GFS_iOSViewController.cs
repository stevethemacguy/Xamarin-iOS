﻿using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GFS_iOS
{
	public partial class GFS_iOSViewController : UIViewController
	{
        UIScrollView scrollView;
        UIImageView imageView;
        UIScrollView mainScrollView;
        MenuSubView menuView;

		public GFS_iOSViewController(IntPtr handle) : base(handle)
		{
		}

		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle


		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			var navBar = this.NavigationController.NavigationBar;

			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();
			MenuB41.TouchUpInside += (sender, e) => {
				if (menuView.isVisible())
				{
					//Change X image back to the normal menu image
					MenuB41.SetBackgroundImage(UIImage.FromFile("menuIconShifted.png"), UIControlState.Normal);
				}else{
					//Make Button show the X image once it's pressed.
					MenuB41.SetBackgroundImage(UIImage.FromFile("XIcon.png"), UIControlState.Normal);
				}
				menuView.toggleMenu(this, 64);
			};

			//Create the NavBar image
			navBar.SetBackgroundImage(UIImage.FromFile("navBarReversed.png"),UIBarMetrics.Default);

			navBar.TintColor = UIColor.White; //Make the text color white.
			//Make the controller title text white
			UITextAttributes test = new UITextAttributes();
			test.TextColor = UIColor.White;
			navBar.SetTitleTextAttributes(test);

			//Add the new menu button
//			this.NavigationItem.SetRightBarButtonItem(
//				new UIBarButtonItem(UIImage.FromFile("menuButton.png")
//					, UIBarButtonItemStyle.Plain
//					, (sender,args) => {
//						// button was clicked
//					})
//				, true);

			//this.SetNeedsStatusBarAppearanceUpdate();


			//this.ParentViewController.NavigationItem.back
			//HomePageNavItem;
            // Perform any additional setup after loading the view, typically from a nib.   

            //generate main scroll view
            mainScrollView = new UIScrollView(new RectangleF(0, 64, 320, 504));
            //initial a container to set content size for the scroll view
            RectangleF container = new RectangleF(0, 0, 320, 775);
            mainScrollView.ContentSize = container.Size;

            //generate sub scroll view
            scrollView = new UIScrollView(new RectangleF(0, 207, View.Frame.Width, 150));
            //adding an image view to sub scroll view
            imageView = new UIImageView(UIImage.FromFile("itemlists.png"));
            scrollView.ContentSize = imageView.Image.Size;
            scrollView.AddSubview(imageView);

            //adding main scroll view to the controllerview
            View.AddSubview(mainScrollView);

            //adding images to specified location in main scroll view
            imageView = new UIImageView(UIImage.FromFile("homeadd.png"));
            mainScrollView.AddSubview(imageView);
            imageView = new UIImageView(UIImage.FromFile("recommandtxt.png"));
            imageView.Frame = new RectangleF(0, 166, 320, 41);
            mainScrollView.AddSubview(imageView);
            imageView = new UIImageView(UIImage.FromFile("viewed.png"));
            imageView.Frame = new RectangleF(0, 357, 320, 350);
            mainScrollView.AddSubview(imageView);

            //adding sub scroll view into main scroll view
            mainScrollView.AddSubview(scrollView);

		}

		//"Unwind Segue". 
		[Action ("UnwindToHome:")]
		public void UnwindToHome (UIStoryboardSegue segue)
		{
			menuView.toggleMenu(this, 64);
			//Change X image back to the normal menu image
			MenuB41.SetBackgroundImage(UIImage.FromFile("menuIconShifted.png"), UIControlState.Normal);
		}

		#endregion
	}
}

