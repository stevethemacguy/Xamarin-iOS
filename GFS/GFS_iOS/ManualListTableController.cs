using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace GFS_iOS
{
	partial class ManualListTableController : UITableViewController
	{
        MenuSubView menuView;

		public ManualListTableController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

            //setting up menuSubview function
            menuView = new MenuSubView(this, MenuB11, 0);
            MenuB11 = menuView.setButton();

			ManualListCell1.BackgroundColor = UIColor.Clear;
			//ManualListCell2.BackgroundColor = UIColor.Clear;
			ManualListView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));
		}

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            menuView.clearSubView();
        }
	}
}
