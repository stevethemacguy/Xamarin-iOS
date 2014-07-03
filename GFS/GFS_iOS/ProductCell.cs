using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;

namespace GFS_iOS
{
	//A custom cell to be used by the LiveResultsTable
	public class ProductCell : UITableViewCell
	{
			UILabel headingLabel, subheadingLabel;
			UIImageView imageView;
			public ProductCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
			{
				SelectionStyle = UITableViewCellSelectionStyle.Gray;
				ContentView.BackgroundColor = UIColor.FromRGB (218, 255, 127);
				imageView = new UIImageView();
				headingLabel = new UILabel () {
					Font = UIFont.FromName("Cochin-BoldItalic", 22f),
					TextColor = UIColor.FromRGB (127, 51, 0),
					BackgroundColor = UIColor.Clear
				};
				subheadingLabel = new UILabel () {
					Font = UIFont.FromName("AmericanTypewriter", 12f),
					TextColor = UIColor.FromRGB (38, 127, 0),
					TextAlignment = UITextAlignment.Center,
					BackgroundColor = UIColor.Clear
				};
				ContentView.Add (headingLabel);
				ContentView.Add (subheadingLabel);
				ContentView.Add (imageView);
			}
			//Get this cell it's values
			public void UpdateCell (string caption, string subtitle, String urlString)
			{
				//Create the image from the urlString
				
		
				//Don't create the image if there is none.
				if (urlString != "")
				{
					//Create a url from the string and use it with an NSData object
					NSData data = NSData.FromUrl(new NSUrl(urlString));

					//Create a UIimage using the url to load the image
					imageView.Image = UIImage.LoadFromData(data);
				}
				
				headingLabel.Text = caption;
				subheadingLabel.Text = subtitle;
			}

			//Position the views in the cell
			public override void LayoutSubviews()
			{
				base.LayoutSubviews ();
				imageView.Frame = new RectangleF(ContentView.Bounds.Width - 63, 5, 33, 33);
				headingLabel.Frame = new RectangleF(5, 4, ContentView.Bounds.Width - 63, 25);
				subheadingLabel.Frame = new RectangleF(100, 18, 100, 20);
			}
	}
}

