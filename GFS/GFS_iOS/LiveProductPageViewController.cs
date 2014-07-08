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

			//Use the number of lines in the Product Ttitle to determine where to position the description text
			//I.e., if the title is only one long line, then we want the description higher than if the title is two lines long
			SizeF size = new SizeF(prodName.Frame.Size);
			//Devide the height of title by the height of the font, to roughly determine how many lines of text there are
			float numberOfLines = size.Height/ UIFont.FromName("Arial",11f).LineHeight;

			View.AddSubview(prodName);

			//Get the description string and add a new line after each hyphen in the string. Only add a newline in certain cases (so words "like-this" don't break):
			String descriptionText = product.getDescription();
			//Note: The order of these lines does matter.
			descriptionText = descriptionText.Replace("- ", System.Environment.NewLine + System.Environment.NewLine + "-"); 
			descriptionText = descriptionText.Replace(".-", "." + System.Environment.NewLine + System.Environment.NewLine + "-"); 
			descriptionText = descriptionText.Replace(". -", "." + System.Environment.NewLine + System.Environment.NewLine + "-"); 
			descriptionText = descriptionText.Replace(" -", System.Environment.NewLine + System.Environment.NewLine + "-"); 
			descriptionText = descriptionText.Replace(":-", ":" + System.Environment.NewLine + System.Environment.NewLine + "-"); 
			//If we added too much whitespace to the start of the string, then remove it.
			descriptionText = descriptionText.TrimStart();

			//Create the description label and add it to the main view
			prodDescription = new UILabel() { 
				Font = UIFont.FromName("Arial",11f), 
				TextColor = UIColor.Black,
				Text = descriptionText
				//Opaque = true
			};

			//Max number of lines
			prodDescription.Lines = 0; //unlimited number of lines
			prodDescription.SizeToFit(); //Shrinks the ImageView to fit the number of text lines (this prevents a single line from appearing centered)
			prodDescription.LineBreakMode = UILineBreakMode.WordWrap;

			//Y is at 0 since we're putting this in a scroll view that is already repositioned
			prodDescription.Frame = new RectangleF(11, 0, 260, 65);

			//Create a scroll view for the product description in case it's very long
			UIScrollView scrollView;

			//245 is remaining viewable screen height. This number must be smaller than the descriptionText height or it won't scroll
			//Use the numberOfLines of the Product Title to determine the Y-coordinate for the scrollView.  

			//For each line of text, Add 11 points to the y-axis so the description text moves down appropiately
			int yAxis = 214;
			yAxis += (int)numberOfLines * 11;

			scrollView = new UIScrollView(new RectangleF(0, yAxis, View.Frame.Width, 340));
			scrollView.ContentSize = prodDescription.Frame.Size; //Make the scrollview's size big enough to fit the description text
			scrollView.AddSubview(prodDescription);

			//Add the scroll view
			View.AddSubview(scrollView);


			UIButton circleButton = UIButton.FromType(UIButtonType.Custom);
			circleButton.Frame = new RectangleF(278, 190, 30, 30);
			circleButton.SetImage(UIImage.FromFile("blue-dots.png"), UIControlState.Normal);

			//Push to the actions view when the circle button is clicked
			circleButton.TouchUpInside += (sender, e) => 
			{
				UIStoryboard board = UIStoryboard.FromName("MainStoryboard", null);
				ProductActionsTableController actions = (ProductActionsTableController)board.InstantiateViewController(
					"productActionsTable"
				);
				actions.selectedProduct = product;
				this.NavigationController.PushViewController(actions, true);
			};

			View.Add(circleButton);

		
		}
	}
}

