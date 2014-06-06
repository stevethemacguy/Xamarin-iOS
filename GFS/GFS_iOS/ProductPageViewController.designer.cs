// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace GFS_iOS
{
	[Register ("ProductPageViewController")]
	partial class ProductPageViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIView ProductPageUIView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIImageView StarsImage { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (ProductPageUIView != null) {
				ProductPageUIView.Dispose ();
				ProductPageUIView = null;
			}
			if (StarsImage != null) {
				StarsImage.Dispose ();
				StarsImage = null;
			}
		}
	}
}
