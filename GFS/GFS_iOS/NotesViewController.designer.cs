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
	[Register ("NotesViewController")]
	partial class NotesViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UITextView NoteTextView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (NoteTextView != null) {
				NoteTextView.Dispose ();
				NoteTextView = null;
			}
		}
	}
}
