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
		UITextView InputTextView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (InputTextView != null) {
				InputTextView.Dispose ();
				InputTextView = null;
			}
		}
	}
}
