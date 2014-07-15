using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Swx.B2B.Ecom.BL.Entities
{	
	//JsonProducts are instantiaed by the NewtonJsonReader as the json feed is deserialized.
	public class JsonProduct
	{
		//public List<Classification> classifications { get; set; }
		//public Stock stock { get; set; }
		//public string name { get; set; }
		//public bool availableForPickup { get; set; }
		public string code { get; set; }
		public string url { get; set; }
		//public string manufacturer { get; set; }
		//public bool volumePricesFlag { get; set; }
		//public List<PotentialPromotion> potentialPromotions { get; set; }

		[JsonProperty("summary")] //The expected Json Value is "summary." This syntax renames the value to title.
		public String title { get; set; }

		[JsonProperty("averageRating")] //The expected Json Value is "averageRating." This syntax renames the value to starRating.
		public double starRating { get; set; }

		public List<Image> imageList { get; set; }
		public String imageFileName = "";
		public Price price { get; set; }

		//public String price = "";
		public String id = "";

		//The full description of the product
		public String description { get; set; }
		public UIImage productImage; //Used by cells in the liveResults tables. This is bad coupling, but creating the images "on the fly" in getCell() causes performance issues.

		//Whether the product should be highlighted in search results, etc.
		private Boolean highlighted = false;

		//This constructor is Used by NewtonJsonReader as the json feed is deserialized.
		public JsonProduct()
		{
			id = RandomNumberGenerator.getInstance().getRandomNumber();
		}

		//Creates this products image since it won't work with the contstructor
		public void createImage()
		{
			if (imageList != null && imageList.Count > 0 )
			{
				//Create the actual image
				//Create a url from the string and use it with an NSData object
				NSData data = NSData.FromUrl(new NSUrl(imageList[0].Url));
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

		public double getRating(){
			return starRating;
		}

		public Price getPrice() {
			return price;
		}

		public override string ToString()
		{
			String s = "";
			s += "\n ID: " + id;
			s += "\n code: " + code;
			s += "\n Title: " + title;
			s += "\n Price: " + price.formattedValue;
			s += "\n Description: " + description;
			s += "\n ImageURL: " + imageFileName;
			s += "\n Currently Highlighted: " + highlighted;
			s += "\n Star Rating: " + starRating;
			return s;
		}
	}
}

