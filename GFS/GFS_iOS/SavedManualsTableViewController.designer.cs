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
	[Register ("SavedManualsTableViewController")]
	partial class SavedManualsTableViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UITableViewCell manualProdCell1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UITableViewCell manualProdCell2 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UITableView SavedManualsList { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (manualProdCell1 != null) {
				manualProdCell1.Dispose ();
				manualProdCell1 = null;
			}
			if (manualProdCell2 != null) {
				manualProdCell2.Dispose ();
				manualProdCell2 = null;
			}
			if (SavedManualsList != null) {
				SavedManualsList.Dispose ();
				SavedManualsList = null;
			}
		}
	}
}
