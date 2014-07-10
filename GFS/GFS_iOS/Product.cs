using System;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GFS_iOS
{
	//Represents a single product
	public class Product
	{
        public string Summary;
        public string AverageRating;
        public string stocklevelstatuscode;
		private String imageFileName = "";
		private String title = "";
		private String prodClass = "";
		private String capacity = "";
		private String readability = "";
		private String price = "";
		private String segueName = "";
		private String id = "";
		private float starRating;
		//The full description of the product
		private String description = "";
		private UIImage productImage; //Used by cells in the liveResults tables. This is bad coupling, but creating the images "on the fly" in getCell() causes performance issues.

		//Whether the product should be highlighted in search results, etc.
		private Boolean highlighted = false;

		//Used only by webservice
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

		public Product(String imageFileName, String title, String prodClass, String cap, String readability, String price, String segueName, String description = "")
		{
			this.id = RandomNumberGenerator.getInstance().getRandomNumber();
			this.description = description;
			this.segueName = segueName;
			this.readability = readability;
			this.price = price;
			this.imageFileName = imageFileName;

			//If there's an image url, then create the image now so it's already chached.
			if (imageFileName != "")
			{
				//Create a url from the string and use it with an NSData object
				NSData data = NSData.FromUrl(new NSUrl(imageFileName));
				//Create a UIimage using the url to load the image
				productImage = UIImage.LoadFromData(data);
			}

			this.title = title;
			this.prodClass = prodClass;
			this.capacity = cap;
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

		public String getProdClass() {
			return prodClass;
		}

		public String getDescription() {
			return description;
		}

		public String getCapacity() {
			return capacity;
		}

		public String getID() {
			return id;
		}

		public float getRating(){
			return starRating;
		}

		public String getReadability() {
			return readability;
		}

		public String getPrice() {
			return price;
		}

		public String getSegueName() {
			return segueName;
		}

		public override string ToString()
		{
			String s = "";
			s += "\n ID: " + getID();
			s += "\n Title: " + getTitle();
//			s += getProdClass();
//			s += getCapacity();
//			s += getReadability();
			s += "\n Price: " + getPrice();
			s += "\n Description: " + getDescription();
			s += "\n ImageURL: " + getImageFileName();
			s += "\n Currently Highlighted: " + highlighted;
//			s += getSegueName();
			return s;
		}
	}

}

