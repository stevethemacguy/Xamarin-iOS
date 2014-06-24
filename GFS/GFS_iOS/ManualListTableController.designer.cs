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
		MonoTouch.UIKit.UITableViewCell ManualListCell1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UITableView ManualListView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UILabel ProductManual { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (ManualListCell1 != null) {
				ManualListCell1.Dispose ();
				ManualListCell1 = null;
			}
			if (ManualListView != null) {
				ManualListView.Dispose ();
				ManualListView = null;
			}
			if (ProductManual != null) {
				ProductManual.Dispose ();
				ProductManual = null;
			}
		}
	}
}
