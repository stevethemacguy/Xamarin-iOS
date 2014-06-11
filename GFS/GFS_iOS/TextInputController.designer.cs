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
	[Register ("TextInputController")]
	partial class TextInputController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton CreateListButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView InputUIView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField ListInputField { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CreateListButton != null) {
				CreateListButton.Dispose ();
				CreateListButton = null;
			}
			if (InputUIView != null) {
				InputUIView.Dispose ();
				InputUIView = null;
			}
			if (ListInputField != null) {
				ListInputField.Dispose ();
				ListInputField = null;
			}
		}
	}
}
