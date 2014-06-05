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
		UITableViewCell ListProdCell1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell ListProdCell2 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView SavedManualsList { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (ListProdCell1 != null) {
				ListProdCell1.Dispose ();
				ListProdCell1 = null;
			}
			if (ListProdCell2 != null) {
				ListProdCell2.Dispose ();
				ListProdCell2 = null;
			}
			if (SavedManualsList != null) {
				SavedManualsList.Dispose ();
				SavedManualsList = null;
			}
		}
	}
}
