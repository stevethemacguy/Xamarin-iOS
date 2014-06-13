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
		MonoTouch.UIKit.UITableViewCell ListCell { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIButton MenuB3 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UITableView SavedListsUIView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (ListCell != null) {
				ListCell.Dispose ();
				ListCell = null;
			}
			if (MenuB3 != null) {
				MenuB3.Dispose ();
				MenuB3 = null;
			}
			if (SavedListsUIView != null) {
				SavedListsUIView.Dispose ();
				SavedListsUIView = null;
			}
		}
	}
}
