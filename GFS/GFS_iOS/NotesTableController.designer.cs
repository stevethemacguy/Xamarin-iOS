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
	[Register ("NotesTableController")]
	partial class NotesTableController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView SavedListsUIView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell TestCell { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (SavedListsUIView != null) {
				SavedListsUIView.Dispose ();
				SavedListsUIView = null;
			}
			if (TestCell != null) {
				TestCell.Dispose ();
				TestCell = null;
			}
		}
	}
}
