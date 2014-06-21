using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace GFS_iOS
{
	partial class SavedManualsTableViewController : UITableViewController
	{
		DataSource db;
		Boolean showFirst; //Controls whether the first PDF Manual Row is hidden
		Boolean showSecond; //Controls whether the second PDF Manual Row is hidden
		private List<String> manualList; //A list of all the products in the "database"
        MenuSubView menuView;
		UIBarButtonItem menuB10;

		public SavedManualsTableViewController (IntPtr handle) : base (handle)
		{
			db = DataSource.getInstance();
			showFirst = db.showRow1;
			showSecond = db.showRow2;
			manualList = db.getManualList();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Hide the back button
			this.NavigationItem.HidesBackButton = true;

			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();

			//Create the Menu button
			menuB10 = new UIBarButtonItem(UIImage.FromFile("menuIconShifted.png"), UIBarButtonItemStyle.Plain, 
				//When clicked
				(sender, args) => {
					if (menuView.isVisible()) {
						//Change X image back to the normal menu image
						menuB10.Image = UIImage.FromFile("menuIconShifted.png");
					} else {
						//Make Button show the X image once it's pressed.
						menuB10.Image = UIImage.FromFile("XIcon.png");
					}
					menuView.toggleMenu(this, 64);
				});
			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menuB10, true);


			manualProdCell1.BackgroundColor = UIColor.Clear;
			manualProdCell2.BackgroundColor = UIColor.Clear;
			manualProdCell1.Hidden = true;
			manualProdCell2.Hidden = true;
			SavedManualsList.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));

			if(manualList.Count >0)
			{
				if (showFirst)
				{
					manualProdCell1.Hidden = false;
					if (db.savedManual1 == "product1")
					{
						//Change the cell to show the actual product selected
						manProd1Image.Image = UIImage.FromFile("product1.png");
						manProd1Title.Text = "Thermo Scientific™ Herasafe™ KS Class II, Type A2 Biological Safety Cabinets";
						manProd1Class.Text = "KS Class II,  A201";
					}
					if (db.savedManual1 == "product2")
					{
						//Change the cell to show the actual product selected
						manProd1Image.Image = UIImage.FromFile("product2.png");
						manProd1Title.Text = "Thermo Scientific™ 1300 Series Class II, Type A2 Biological Safety Cabinets";
						manProd1Class.Text = "XPE 105";
					}
				}

				if (showSecond)
				{
					manualProdCell2.Hidden = false;
					if (db.savedManual2 == "product1")
					{
						//Change the cell to show the actual product selected
						manProd2Image.Image = UIImage.FromFile("product1.png");
						manProd2Title.Text = "Thermo Scientific™ Herasafe™ KS Class II, Type A2 Biological Safety Cabinets";
						manProd2Class.Text = "KS Class II,  A201";
					}
					if (db.savedManual2 == "product2")
					{
						//Change the cell to show the actual product selected
						manProd2Image.Image = UIImage.FromFile("product2.png");
						manProd2Title.Text = "Thermo Scientific™ 1300 Series Class II, Type A2 Biological Safety Cabinets";
						manProd2Class.Text = "XPE 105";
					}
				}
			}
		}
	}
}
