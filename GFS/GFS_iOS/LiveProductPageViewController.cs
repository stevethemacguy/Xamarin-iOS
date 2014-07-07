using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace GFS_iOS
{
	partial class LiveProductPageViewController : UIViewController
	{
		MenuSubView menuView;
		UIBarButtonItem menub101;
		//LiveProductPageViewController currentController;
		public Product product; //Passed to this controller when a ProductCell is selected.
		public int index; //Index of the cell row that pushed to this view
		public String rowName; //Name of the cell row that pushed to this view
		UILabel prodName; 
		UILabel prodDescription;

		//Constructor is always passed the product that should be displayed
		public LiveProductPageViewController(Product p)
		{
		//	currentController = this;
			product = p;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Initialize Flyout Menu
			menuView = MenuSubView.getInstance();

			//Create the Menu button
			menub101 = new UIBarButtonItem(UIImage.FromFile("menuIconShifted.png"), UIBarButtonItemStyle.Plain, 
				//When clicked
				(sender, args) => {
					if (menuView.isVisible()) {
						//Change X image back to the normal menu image
						menub101.Image = UIImage.FromFile("menuIconShifted.png");
					} else {
						//Make Button show the X image once it's pressed.
						menub101.Image = UIImage.FromFile("XIcon.png");
					}
					menuView.toggleMenu(this, 64);
				});
			//Add the Menu button to the navigation bar.
			this.NavigationItem.SetRightBarButtonItem(menub101, true);

			View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("main-background568.png"));
			//Add image and text views

			//Create Product Image view
			UIImageView prodBackground = new UIImageView(UIImage.FromFile("product-result-background.png"));
			prodBackground.Frame = new RectangleF(100, 70, 115, 115);  //X, Y, Width, Height
			View.AddSubview(prodBackground);

			//Create Product Image view
			UIImageView prodImage = new UIImageView();
			prodImage.Image = product.getProductImage();
			prodImage.Frame = new RectangleF(102, 72, 110, 110); 
			View.AddSubview(prodImage);

			//Create circle button
			UIImageView circleButtonView = new UIImageView(UIImage.FromFile("blue-dots.png"));
			circleButtonView.Frame = new RectangleF(278, 200, 30, 30); //new RectangleF(280, 9, 30, 30);
			View.AddSubview(circleButtonView);

			//Create the title label and add it to the main view
			prodName = new UILabel() { 
				Font = UIFont.FromName("Arial",12f), 
				TextColor = UIColor.FromRGB (7, 90, 170),
				Text = product.getTitle(),
				Frame = new RectangleF(11, 198, 242, 33)
				//Opaque = true
				//	BackgroundColor = UIColor.Clear
			};

			//Max number of lines
			prodName.Lines = 2;
			prodName.SizeToFit(); //Shrinks the ImageView to fit the number of text lines (this prevents a single line from appearing centered)
			prodName.LineBreakMode = UILineBreakMode.WordWrap;

			View.AddSubview(prodName);

			//Create the description label and add it to the main view
			prodDescription = new UILabel() { 
				Font = UIFont.FromName("Arial",11f), 
				TextColor = UIColor.Black
					//Opaque = true
					//	BackgroundColor = UIColor.Clear
			};

			prodDescription.Frame = new RectangleF(11, 235, 198, 65);
			prodDescription.Text = product.getDescription();

			//Max number of lines
			prodDescription.Lines = 40;
			prodDescription.SizeToFit(); //Shrinks the ImageView to fit the number of text lines (this prevents a single line from appearing centered)
			prodDescription.LineBreakMode = UILineBreakMode.WordWrap;

			View.AddSubview(prodDescription);

			//UIImage.FromFile("product-result-background.png"),
			//UIImage.FromFile("product-devider.png")
		}
	}
}

