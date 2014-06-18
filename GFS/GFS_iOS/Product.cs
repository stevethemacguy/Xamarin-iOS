using System;
using System.Collections.Generic;

namespace GFS_iOS
{
	//Represents a single product
	public class Product
	{
		private String imageFileName = "";
		private String title = "";
		private String prodClass = "";
		private String capacity = "";
		private String readability = "";
		private String price = "";
		private String segueName = "";
		public Product(String imageFileName, String title, String prodClass, String cap, String readability, String price, String segueName)
		{
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

		public String getCapacity() {
			return capacity;
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
	}

}

