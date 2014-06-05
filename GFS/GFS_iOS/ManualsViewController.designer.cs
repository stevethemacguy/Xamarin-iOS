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
	[Register ("ManualsViewController")]
	partial class ManualsViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIWebView PDFWebView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (PDFWebView != null) {
				PDFWebView.Dispose ();
				PDFWebView = null;
			}
		}
	}
}
