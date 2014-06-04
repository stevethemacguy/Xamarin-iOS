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
		UITableView ProductDetailsUIView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell Result1 { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CellBorder1 != null) {
				CellBorder1.Dispose ();
				CellBorder1 = null;
			}
			if (ProductDetailsUIView != null) {
				ProductDetailsUIView.Dispose ();
				ProductDetailsUIView = null;
			}
			if (Result1 != null) {
				Result1.Dispose ();
				Result1 = null;
			}
		}
	}
}
