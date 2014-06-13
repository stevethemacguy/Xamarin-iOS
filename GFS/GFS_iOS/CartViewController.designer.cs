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
	[Register ("CartViewController")]
	partial class CartViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UINavigationItem CartNavItem { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIView cartUIView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIBarButtonItem MenuButton2 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIButton MenuButton3 { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CartNavItem != null) {
				CartNavItem.Dispose ();
				CartNavItem = null;
			}
			if (cartUIView != null) {
				cartUIView.Dispose ();
				cartUIView = null;
			}
			if (MenuButton2 != null) {
				MenuButton2.Dispose ();
				MenuButton2 = null;
			}
			if (MenuButton3 != null) {
				MenuButton3.Dispose ();
				MenuButton3 = null;
			}
		}
	}
}
