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
	[Register ("ProductDetails")]
	partial class ProductDetails
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell Ok { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell ThirdCell { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (Ok != null) {
				Ok.Dispose ();
				Ok = null;
			}
			if (ThirdCell != null) {
				ThirdCell.Dispose ();
				ThirdCell = null;
			}
		}
	}
}
