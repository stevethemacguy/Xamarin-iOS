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
		UILabel Cabinets { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell List1Cell { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell List2Cell { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel OtherStuffLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView SavedListsUIView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (Cabinets != null) {
				Cabinets.Dispose ();
				Cabinets = null;
			}
			if (List1Cell != null) {
				List1Cell.Dispose ();
				List1Cell = null;
			}
			if (List2Cell != null) {
				List2Cell.Dispose ();
				List2Cell = null;
			}
			if (OtherStuffLabel != null) {
				OtherStuffLabel.Dispose ();
				OtherStuffLabel = null;
			}
			if (SavedListsUIView != null) {
				SavedListsUIView.Dispose ();
				SavedListsUIView = null;
			}
		}
	}
}
