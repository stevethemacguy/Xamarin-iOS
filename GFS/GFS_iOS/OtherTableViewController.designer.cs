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
	[Register ("OtherTableViewController")]
	partial class OtherTableViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UITableView ListTwoUIView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIButton MenuB6 { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (ListTwoUIView != null) {
				ListTwoUIView.Dispose ();
				ListTwoUIView = null;
			}
			if (MenuB6 != null) {
				MenuB6.Dispose ();
				MenuB6 = null;
			}
		}
	}
}
