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
	[Register ("ManualListTableController")]
	partial class ManualListTableController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell ManualListCell1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell ManualListCell2 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView ManualListView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel ProductManual { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TechnicalSpecification { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (ManualListCell1 != null) {
				ManualListCell1.Dispose ();
				ManualListCell1 = null;
			}
			if (ManualListCell2 != null) {
				ManualListCell2.Dispose ();
				ManualListCell2 = null;
			}
			if (ManualListView != null) {
				ManualListView.Dispose ();
				ManualListView = null;
			}
			if (ProductManual != null) {
				ProductManual.Dispose ();
				ProductManual = null;
			}
			if (TechnicalSpecification != null) {
				TechnicalSpecification.Dispose ();
				TechnicalSpecification = null;
			}
		}
	}
}
