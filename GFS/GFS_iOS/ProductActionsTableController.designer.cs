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
	[Register ("ProductActionsTableController")]
	partial class ProductActionsTableController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UITableViewCell actionCell1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UITableViewCell actionCell2 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UITableViewCell actionCell3 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UITableView actionsView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIButton AddToListButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIButton DownloadButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIButton MenuB8 { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (actionCell1 != null) {
				actionCell1.Dispose ();
				actionCell1 = null;
			}
			if (actionCell2 != null) {
				actionCell2.Dispose ();
				actionCell2 = null;
			}
			if (actionCell3 != null) {
				actionCell3.Dispose ();
				actionCell3 = null;
			}
			if (actionsView != null) {
				actionsView.Dispose ();
				actionsView = null;
			}
			if (AddToListButton != null) {
				AddToListButton.Dispose ();
				AddToListButton = null;
			}
			if (DownloadButton != null) {
				DownloadButton.Dispose ();
				DownloadButton = null;
			}
			if (MenuB8 != null) {
				MenuB8.Dispose ();
				MenuB8 = null;
			}
		}
	}
}
