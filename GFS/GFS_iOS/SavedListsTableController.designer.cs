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
		UILabel OtherStuffLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (Cabinets != null) {
				Cabinets.Dispose ();
				Cabinets = null;
			}
			if (OtherStuffLabel != null) {
				OtherStuffLabel.Dispose ();
				OtherStuffLabel = null;
			}
		}
	}
}