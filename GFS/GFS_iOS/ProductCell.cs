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
			UILabel	price;
			UIImageView imageView;
			public ProductCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
			{
				SelectionStyle = UITableViewCellSelectionStyle.Gray;
				ContentView.BackgroundColor = UIColor.Clear; //UIColor.FromPatternImage(UIImage.FromFile("main-background-resized.png"));?
				
				imageView = new UIImageView();
				title = new UILabel() {
					Font = UIFont.FromName("Arial",12f),		//UIFont.FromName("Cochin-BoldItalic", 12f),
					TextColor = UIColor.FromRGB (127, 51, 0),
					BackgroundColor = UIColor.Clear
				};
				price = new UILabel () {
					Font = UIFont.FromName("Arial", 12f),
					TextColor = UIColor.FromRGB (38, 127, 0),
					TextAlignment = UITextAlignment.Center,
					BackgroundColor = UIColor.Clear
				};
				ContentView.Add (title);
				ContentView.Add (price);
				ContentView.Add (imageView);
			}
			//Get this cell it's values
			public void UpdateCell (string prodTitle, string prodPrice, String urlString)
			{
				//Don't create the image if there is none.
				if (urlString != "")
				{
					//Create a url from the string and use it with an NSData object
					NSData data = NSData.FromUrl(new NSUrl(urlString));

					//Create a UIimage using the url to load the image
					imageView.Image = UIImage.LoadFromData(data);
				}
				
				title.Text = prodTitle;
				price.Text = prodPrice;
			}

			//Position the views in the cell
			public override void LayoutSubviews()
			{
				base.LayoutSubviews();
				//X, Y, Width, Height
				imageView.Frame = new RectangleF(5, 5, 35, 35);
				title.Frame = new RectangleF(45, 5, ContentView.Bounds.Width - 63, 25);
				price.Frame = new RectangleF(45, 40, 35, 65);

				//Demo defaults
//				imageView.Frame = new RectangleF(ContentView.Bounds.Width - 63, 5, 33, 33);
//				title.Frame = new RectangleF(5, 4, ContentView.Bounds.Width - 63, 25);
//				price.Frame = new RectangleF(100, 18, 100, 20);
			}
	}
}

