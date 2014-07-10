using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;

namespace GFS_iOS
{
	//A custom cell to be used by the LiveResultsTable
	public class ProductCell : UITableViewCell
	{
		UILabel title;
		//UILabel	price;
		UIImageView productImageView;
		UIImageView whiteBoxImageView;
		UIImageView cellBorder;
		UIImageView circleButtonView;

		//"New" way to do cell reuse
		//public ProductCell(IntPtr p):base(p)

		//"Old" way to do cell reuse
		public ProductCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
			ContentView.BackgroundColor = UIColor.Clear; //UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));?
			//ContentView.Opaque = true;
			productImageView = new UIImageView();
			cellBorder = new UIImageView();
			whiteBoxImageView = new UIImageView();
			circleButtonView = new UIImageView();
			//imageView.Opaque = true;
			title = new UILabel() { Font = UIFont.FromName("Arial",12f), TextColor = UIColor.FromRGB (7, 90, 170),
				//Opaque = true
			//	BackgroundColor = UIColor.Clear
			};
			
			//price = new UILabel() { Font = UIFont.FromName("Arial", 12f), TextColor = UIColor.FromRGB (102, 102, 102),
				//TextAlignment = UITextAlignment.Center,
			//	Opaque = true
			//	BackgroundColor = UIColor.Clear
			//};
			
			ContentView.Add(whiteBoxImageView);
			ContentView.Add(productImageView);
			ContentView.Add(title);
			ContentView.Add(circleButtonView);
			ContentView.Add(cellBorder);
			//ContentView.Add (price);
		}
		//Get this cell it's values
		public void UpdateCell(String prodTitle, String prodPrice, UIImage img, UIImage box, UIImage circles, UIImage cellBackground)
		{
			productImageView.Image = img;
			title.Text = prodTitle;
			whiteBoxImageView.Image = box;
			circleButtonView.Image = circles;
			cellBorder.Image = cellBackground;
			//price.Text = prodPrice;
		}

		public void highlightCell()
		{
			ContentView.BackgroundColor = UIColor.FromRGB(231, 247, 205);
		}

		//Position the views in the cell
		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			//X, Y, Width, Height
			productImageView.Frame = new RectangleF(6, 9, 55, 55);
			whiteBoxImageView.Frame = new RectangleF(4, 7, 60, 60);
			title.Frame = new RectangleF(70, 9, 198, 65); //Don't know why I need a negative y value
			//Max number of lines
			title.Lines = 4;
			title.SizeToFit(); //Shrinks the ImageView to fit the number of text lines (this prevents a single line from appearing centered)
			title.LineBreakMode = UILineBreakMode.WordWrap;

			circleButtonView.Frame = new RectangleF(280, 9, 30, 30);
			//price.Frame = new RectangleF(45, 40, 80, 65);
			cellBorder.Frame = new RectangleF(0, 79, 360, 1);
		}
	}
}

