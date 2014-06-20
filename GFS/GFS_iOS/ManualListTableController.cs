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

			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();
			MenuB11.TouchUpInside += (sender, e) => {
				menuView.toggleMenu(this, 64);
			};

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
