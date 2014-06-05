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
	[Register ("ListATableViewController")]
	partial class ListATableViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UITableView ListOneUIView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UITableViewCell ListProdCell1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UITableViewCell ListProdCell2 { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (ListOneUIView != null) {
				ListOneUIView.Dispose ();
				ListOneUIView = null;
			}
			if (ListProdCell1 != null) {
				ListProdCell1.Dispose ();
				ListProdCell1 = null;
			}
			if (ListProdCell2 != null) {
				ListProdCell2.Dispose ();
				ListProdCell2 = null;
			}
		}
	}
}
