using System;
using System.Collections.Generic;

//"Old" version of Product no longer used.
namespace Swx.B2B.Ecom.BL.Entities
{
	//Represents a single product
	public class OldProduct
	{
		private String imageFileName = "";
		private String title = "";
		private String price = "";
		private String id = "";
		private float starRating;
		//The full description of the product
		private String description = "";
		private String code = "";

		//Whether the product should be highlighted in search results, etc.
		private Boolean highlighted = false;

		public OldProduct(String code, String imageFileName, String title, String price, String description, float rating)
	    {
			//At this potin key should be unique
			this.id = RandomNumberGenerator.getInstance().getRandomNumber();
			this.imageFileName = imageFileName;
			this.title = title;
			this.price = price;
			this.description = description;
			this.starRating = rating;
			this.code = code;
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

		public String getCode()
		{
			return code;
		}

		public override string ToString()
		{
			String s = "";
			s += "\n ID: " + id;
			s += "\n Code: " + code;
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