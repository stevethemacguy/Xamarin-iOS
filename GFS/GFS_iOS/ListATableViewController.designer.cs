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
		UITableView ListOneUIView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell ListProdCell1 { get; set; }

		[Action ("UIButton840_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void UIButton840_TouchUpInside (UIButton sender);

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
		}
	}
}
