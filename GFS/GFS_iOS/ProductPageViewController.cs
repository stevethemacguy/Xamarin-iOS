using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Drawing;

namespace GFS_iOS
{
	partial class ProductPageViewController : UIViewController
	{
		UIScrollView scrollView;
		UIImageView imageView;
		public Boolean fromActionsPage = false; //True if this view is being "loaded" from the actions page (i.e. it's parent controller is TextInputController)
		//UIBarButtonItem mainMenuButton;
        MenuSubView menuView;
		//ProductPageViewController currentController;

		public string saved = "";
		public Boolean failed = false;
		public ProductPageViewController (IntPtr handle) : base (handle)
		{
			//	currentController = this;
			//mainMenuButton = new UIBarButtonItem();
			//mainMenuButton.Title = "Menu";
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();
			MenuB9.TouchUpInside += (sender, e) => {
				if (menuView.isVisible())
				{
					//Change X image back to the normal menu image
					MenuB9.SetBackgroundImage(UIImage.FromFile("menuIconShifted.png"), UIControlState.Normal);
				}else{
					//Make Button show the X image once it's pressed.
					MenuB9.SetBackgroundImage(UIImage.FromFile("XIcon.png"), UIControlState.Normal);
				}
				menuView.toggleMenu(this, 64);
			};

			//"Tell" the database that which product we are currently viewing.
			DataSource db = DataSource.getInstance();
			db.currentProduct = "product1";

			//IF COMING FROM THE ACTIONS then do stuff
//			if (fromActionsPage)
//			{
//				//Hide the back button
//				this.NavigationItem.HidesBackButton = true;
//				//Create the Menu button and add it to LEFT SIDE OF the toolbar
//				this.NavigationItem.SetLeftBarButtonItem(mainMenuButton, false);
//			} 
//			else 
//			{
				//Create the Menu button and add it to the right side of toolbar
//				mainMenuButton = new UIBarButtonItem();
//				mainMenuButton.Title = "Menu";
//				this.NavigationItem.SetRightBarButtonItem(mainMenuButton, false);
			//}

			ProductPageUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background568.png"));

			//Create a scroll view. X, Y, Width, Height. Note that the height MUST be smaller than the image if you want it to scroll!
			scrollView = new UIScrollView (new RectangleF(12, 250, 320, 400));
			View.AddSubview (scrollView);

			//Create the ImageView
			imageView = new UIImageView (UIImage.FromFile ("description-text2.png"));

			//Make the image frame's width smaller than the Image width (of 320) to make (shrink) the image smaller
			imageView.Frame = new RectangleF(0,-78,226, 800); //The negative Y coordinate just moves the image up. For some reason, this doesn't work properly from the scroll view.
			imageView.ContentMode = UIViewContentMode.ScaleAspectFit;

			//Match the widht/height to (roughly) the frame dimensions so you can't scroll horizontal and can't scroll to far vertically.
			scrollView.ContentSize = new SizeF(226, 735); 
			scrollView.AddSubview (imageView);
			scrollView.Bounces = false; //We don't want it to "bounce" when it reaches the bottom.
		}

		//"Unwind Segue". This occurs after a new saved list is saved from the ProductActionsTableController
		[Action ("UnwindToProductPageViewController:")]
		public void UnwindToProductPageViewController (UIStoryboardSegue segue)
		{
			//Access member variable of the source TextInputController
			TextInputController parentControl = (TextInputController) segue.SourceViewController;
			if (parentControl.failed)
			{
				UIAlertView alert = new UIAlertView ("Failed to Save", "The list could not be created. Please try again.", null, "OK");
				alert.Show();
				return;
			}
			else{
				string success = "The product was added to: \"" + parentControl.newList +"\"";
				UIAlertView alert = new UIAlertView(success, "", null, "OK");
				alert.Show();
			}
		}
	}
}
