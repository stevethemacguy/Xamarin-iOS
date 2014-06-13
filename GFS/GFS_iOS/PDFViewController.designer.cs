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
	[Register ("PDFViewController")]
	partial class PDFViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIButton MenuB14 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIWebView PDFWebView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MenuB14 != null) {
				MenuB14.Dispose ();
				MenuB14 = null;
			}
			if (PDFWebView != null) {
				PDFWebView.Dispose ();
				PDFWebView = null;
			}
		}
	}
}
