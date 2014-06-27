using System;
using System.Collections.Generic;

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
		//The full description of the product

		private String description = "";

		//Used only by webservice
		public Product(String imageFileName, String title, String price, String description)
	    {
			//At this potin key should be unique
			this.id = RandomNumberGenerator.getInstance().getRandomNumber();
			this.imageFileName = imageFileName;
			this.title = title;
			this.price = price;
			this.description = description;
	    }

		public Product(String imageFileName, String title, String prodClass, String cap, String readability, String price, String segueName, String description = "")
		{
			this.id = RandomNumberGenerator.getInstance().getRandomNumber();
			this.description = description;
			this.segueName = segueName;
			this.readability = readability;
			this.price = price;
			this.imageFileName = imageFileName;
			this.title = title;
			this.prodClass = prodClass;
			this.capacity = cap;
		}

		public String getImageFileName() {
			return imageFileName;
		}

		public String getTitle() {
			return title;
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
//			s += getSegueName();
			return s;
		}
	}

}

