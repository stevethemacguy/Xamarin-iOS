using System;
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
        UIViewController controller;
        MenuSubView menuView;

		public GFS_iOSViewController(IntPtr handle) : base(handle)
		{
            controller = this;
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

			// Convert the MenuButton passed into a Button that toggles between states "Unclicked" and "Clicked"
            menuView = new MenuSubView(controller, MenuButton1, 64);
            MenuButton1 = menuView.setButton();
            ///MenuButton.TouchUpInside += HandleTouchUpInsideMenuUnclciked;

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
          
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
            menuView.clearSubView();
		}

		//"Unwind Segue". 
		[Action ("UnwindToHome:")]
		public void UnwindToHome (UIStoryboardSegue segue)
		{
			menuView.clearSubView();
		}

		#endregion
	}
}

