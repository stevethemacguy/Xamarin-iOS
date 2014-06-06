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

		public ProductPageViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ProductPageUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background568.png"));

			//Create a scroll view. X, Y, Width, Height. Note that the height MUST be smaller than the image if you want it to scroll!
			scrollView = new UIScrollView (new RectangleF(5, 380, 320, 200));
			View.AddSubview (scrollView);

			//Create the ImageView
			imageView = new UIImageView (UIImage.FromFile ("description-text.png"));

			//Make the image frame's width smaller than the Image width (of 320) to make (shrink) the image smaller
			imageView.Frame = new RectangleF(0,0,220, 430);
			imageView.ContentMode = UIViewContentMode.ScaleAspectFit;

			//Match the widht/height to (roughly) the frame dimensions so you can't scroll horizontal and can't scroll to far vertically.
			scrollView.ContentSize = new SizeF(220, 460); 
			scrollView.AddSubview (imageView);
			scrollView.Bounces = false; //We don't want it to "bounce" when it reaches the bottom.


		}
	}
}
