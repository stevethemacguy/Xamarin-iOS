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
	[Register ("SavedListsTableController")]
	partial class SavedListsTableController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell DetailCell2 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell DetailCell3 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell DetailCell4 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell DetailCell5 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView ProductDetailsUIView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (DetailCell2 != null) {
				DetailCell2.Dispose ();
				DetailCell2 = null;
			}
			if (DetailCell3 != null) {
				DetailCell3.Dispose ();
				DetailCell3 = null;
			}
			if (DetailCell4 != null) {
				DetailCell4.Dispose ();
				DetailCell4 = null;
			}
			if (DetailCell5 != null) {
				DetailCell5.Dispose ();
				DetailCell5 = null;
			}
			if (ProductDetailsUIView != null) {
				ProductDetailsUIView.Dispose ();
				ProductDetailsUIView = null;
			}
		}
	}
}
