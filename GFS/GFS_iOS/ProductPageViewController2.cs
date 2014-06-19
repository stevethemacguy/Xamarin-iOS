using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Drawing;

namespace GFS_iOS
{
	partial class ProductPageViewController2 : UIViewController
	{
		UIScrollView scrollView;
		UIImageView imageView;

		public ProductPageViewController2 (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

            //set up flyout menuSubview
            MenuB16 = new MenuSubView(this, MenuB16, 0).setButton();

			//"Tell" the database that which product we are currently viewing.
			DataSource db = DataSource.getInstance();
			db.currentProduct = "product2";

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
