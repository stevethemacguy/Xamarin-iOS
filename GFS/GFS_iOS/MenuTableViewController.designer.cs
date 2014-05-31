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
	[Register ("MenuTableViewController")]
	partial class MenuTableViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel AccountCellText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel SavedListCellText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel SavedManCellText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView SearchCellImage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel SearchCellText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel ViewCellText { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (AccountCellText != null) {
				AccountCellText.Dispose ();
				AccountCellText = null;
			}
			if (SavedListCellText != null) {
				SavedListCellText.Dispose ();
				SavedListCellText = null;
			}
			if (SavedManCellText != null) {
				SavedManCellText.Dispose ();
				SavedManCellText = null;
			}
			if (SearchCellImage != null) {
				SearchCellImage.Dispose ();
				SearchCellImage = null;
			}
			if (SearchCellText != null) {
				SearchCellText.Dispose ();
				SearchCellText = null;
			}
			if (ViewCellText != null) {
				ViewCellText.Dispose ();
				ViewCellText = null;
			}
		}
	}
}
