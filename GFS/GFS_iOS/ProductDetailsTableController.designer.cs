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
	[Register ("ProductDetailsTableController")]
	partial class ProductDetailsTableController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView CellBorder1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView CellBorder4 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell Result1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell Result5 { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CellBorder1 != null) {
				CellBorder1.Dispose ();
				CellBorder1 = null;
			}
			if (CellBorder4 != null) {
				CellBorder4.Dispose ();
				CellBorder4 = null;
			}
			if (Result1 != null) {
				Result1.Dispose ();
				Result1 = null;
			}
			if (Result5 != null) {
				Result5.Dispose ();
				Result5 = null;
			}
		}
	}
}
