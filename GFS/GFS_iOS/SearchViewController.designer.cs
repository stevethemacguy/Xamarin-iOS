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
	[Register ("SearchViewController")]
	partial class SearchViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UITableView HintTable { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIButton MenuB1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UISearchBar SearchBar { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UINavigationItem SearchNavItem { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIView SearchUIView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (HintTable != null) {
				HintTable.Dispose ();
				HintTable = null;
			}
			if (MenuB1 != null) {
				MenuB1.Dispose ();
				MenuB1 = null;
			}
			if (SearchBar != null) {
				SearchBar.Dispose ();
				SearchBar = null;
			}
			if (SearchNavItem != null) {
				SearchNavItem.Dispose ();
				SearchNavItem = null;
			}
			if (SearchUIView != null) {
				SearchUIView.Dispose ();
				SearchUIView = null;
			}
		}
	}
}
