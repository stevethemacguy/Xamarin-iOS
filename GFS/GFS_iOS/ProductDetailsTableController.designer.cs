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
	[Register ("ProductDetailsTableController")]
	partial class ProductDetailsTableController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView SearchCellImage { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (SearchCellImage != null) {
				SearchCellImage.Dispose ();
				SearchCellImage = null;
			}
		}
	}
}
