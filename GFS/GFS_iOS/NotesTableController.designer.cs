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
		UILabel FirstNote { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell NoteCell1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell NoteCell2 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView SavedListsUIView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel SecondNote { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (FirstNote != null) {
				FirstNote.Dispose ();
				FirstNote = null;
			}
			if (NoteCell1 != null) {
				NoteCell1.Dispose ();
				NoteCell1 = null;
			}
			if (NoteCell2 != null) {
				NoteCell2.Dispose ();
				NoteCell2 = null;
			}
			if (SavedListsUIView != null) {
				SavedListsUIView.Dispose ();
				SavedListsUIView = null;
			}
			if (SecondNote != null) {
				SecondNote.Dispose ();
				SecondNote = null;
			}
		}
	}
}
