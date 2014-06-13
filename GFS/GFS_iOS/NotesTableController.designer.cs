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
		UIButton MenuB2 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView NoteListUIView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell TestCell { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MenuB2 != null) {
				MenuB2.Dispose ();
				MenuB2 = null;
			}
			if (NoteListUIView != null) {
				NoteListUIView.Dispose ();
				NoteListUIView = null;
			}
			if (TestCell != null) {
				TestCell.Dispose ();
				TestCell = null;
			}
		}
	}
}
