using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace GFS_iOS
{
	partial class ListATableViewController : UITableViewController
	{
		public ListATableViewController (IntPtr handle) : base (handle)
		{
		}


		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ListProdCell1.BackgroundColor = UIColor.Clear;
			ListProdCell2.BackgroundColor = UIColor.Clear;
			ListOneUIView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));
		}


	}
}
