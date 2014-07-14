using System;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Swx.B2B.Ecom.BL.Entities
{
	//Represents a single product
	public class Product
	{
		private String imageFileName = "";
		private String title = "";
		private String price = "";
		private String id = "";
		private float starRating;
		//The full description of the product
		private String description = "";
		private UIImage productImage; //Used by cells in the liveResults tables. This is bad coupling, but creating the images "on the fly" in getCell() causes performance issues.

		//Whether the product should be highlighted in search results, etc.
		private Boolean highlighted = false;

		public Product(String imageFileName, String title, String price, String description, float rating)
	    {
			//At this potin key should be unique
			this.id = RandomNumberGenerator.getInstance().getRandomNumber();
			this.imageFileName = imageFileName;
			this.title = title;
			this.price = price;
			this.description = description;
			this.starRating = rating;

			//If there's an image url, then create the image now so it's already chached.
			if (imageFileName != "")
			{
				//Create a url from the string and use it with an NSData object
				NSData data = NSData.FromUrl(new NSUrl(imageFileName));
				//Create a UIimage using the url to load the image
				productImage = UIImage.LoadFromData(data);
			}
	    }

		public String getImageFileName() {
			return imageFileName;
		}

		public UIImage getProductImage() {
			return productImage;
		}

		public String getTitle() {
			return title;
		}

		public Boolean isHighlighted()
		{
			return highlighted;
		}

		public void toggleHighlight()
		{
			if (highlighted)
				highlighted = false;
			else
				highlighted = true;
		}

		public String getDescription() {
			return description;
		}

		public String getID() {
			return id;
		}

		public float getRating(){
			return starRating;
		}

		public String getPrice() {
			return price;
		}

		public override string ToString()
		{
			String s = "";
			s += "\n ID: " + id;
			s += "\n Title: " + title;
			s += "\n Price: " + price;
			s += "\n Description: " + description;
			s += "\n ImageURL: " + imageFileName;
			s += "\n Currently Highlighted: " + highlighted;
			s += "\n Star Rating: " + starRating;
			return s;
		}
	}

}

