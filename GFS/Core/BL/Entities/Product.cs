using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Swx.B2B.Ecom.BL.Entities
{	
	//Products are instantiaed by the NewtonJsonReader as the json feed is deserialized.
	public class Product
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

		//The name of the saved list to which this product belongs. 
		//A product can be in more than one list, but this is just used for highlighting a product, so any list name will work
		private String savedListName = "";

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
		//public UIImage productImage; //Used by cells in the liveResults tables. This is bad coupling, but creating the images "on the fly" in getCell() causes performance issues.

		//Whether the product should be highlighted in search results, etc.
		private Boolean highlighted = false;

		//This constructor is Used by NewtonJsonReader as the json feed is deserialized.
		public Product()
		{
			id = RandomNumberGenerator.getInstance().getRandomNumber();
		}

		//Returns true if this product is in a saved list. Used to highlight products that are in a saved list
		public Boolean isProductInASavedList()
		{
			if (savedListName == "")
				return false;
			else
				return true;
		}

		public String getCode()
		{
			return code;
		}

		public String getSavedListName() {
			return savedListName;
		}

		public void setSavedListName(String listName) 
		{
			savedListName = listName;
		}

		public String getImageFileName() {
			return imageFileName;
		}

		public String getTitle() {
			return title;
		}

		public Boolean isHighlighted()
		{
			return highlighted;
		}

		public void addHighlight()
		{
			highlighted = true;
		}

		public void removeHighlight()
		{
			highlighted = false;
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

