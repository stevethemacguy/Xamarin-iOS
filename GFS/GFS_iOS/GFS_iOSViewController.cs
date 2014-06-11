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
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.   

            mainScrollView = new UIScrollView(
            new RectangleF(0, 64, 320
            , 504));
            RectangleF container = new RectangleF(0, 0, 320, 800);
            mainScrollView.ContentSize = container.Size;

            scrollView = new UIScrollView(
            new RectangleF(0, 207, View.Frame.Width
            , 150));

            imageView = new UIImageView(UIImage.FromFile("itemlist150.png"));
            //imageView.Frame = new RectangleF(0, 0, 600, 130);
            //scrollView.ContentSize = imageView.Frame.Size;
            scrollView.ContentSize = imageView.Image.Size;
            scrollView.AddSubview(imageView);

            //mainScrollView.AddSubview(scrollView);
            View.AddSubview(mainScrollView);

            imageView = new UIImageView(UIImage.FromFile("homeadd.png"));
            mainScrollView.AddSubview(imageView);
            imageView = new UIImageView(UIImage.FromFile("recommandtxt.png"));
            imageView.Frame = new RectangleF(0, 166, 320, 41);
            mainScrollView.AddSubview(imageView);
            imageView = new UIImageView(UIImage.FromFile("viewed.png"));
            imageView.Frame = new RectangleF(0, 357, 320, 350);
            mainScrollView.AddSubview(imageView);
            mainScrollView.AddSubview(scrollView);
			// Perform any additional setup after loading the view, typically from a nib.
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
		}

		#endregion
	}
}

