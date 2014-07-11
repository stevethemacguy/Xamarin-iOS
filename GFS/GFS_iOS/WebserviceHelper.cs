using System;
using System.Collections.Generic;
using System.Json;

namespace GFS_iOS
{
	public class WebserviceHelper
	{
		public WebserviceHelper()
		{
		}

		//Makes a request to the Webservice to retrieve product search suggestions that match a term entered into the search bar.
		//Returns a List of search terms
		public List<String> getProductSearchSuggestions(string term)
		{
			WebService request = new WebService("suggest?term=" + term, "json");
			//Initialize the JSON reader
			JSONReader jsonReader = request.getJSONReader();

			//Get the suggestions object
			JsonValue suggestionsObject = jsonReader.AllObjects ["suggestions"];

			List<String> suggestions = new List<String>();
			//Parse through the json and add all search suggestion strings to the suggestions list
			foreach (JsonValue j in suggestionsObject)
			{
				suggestions.Add(jsonReader.getValue(j, "value"));
			}
			return suggestions;
		}

		//Makes a webservice call using the search term provided. Returns the resulting "products" Json object (i.e. JsonValue) to be parsed later.
		public void getProductsBySearchTerm(string searchTerm)
		{
			WebService request = new WebService("?query=freeTextSearch:sort:name:" + searchTerm + ":description:" + searchTerm, "json");
			//Initialize the JSON reader
			JSONReader jsonReader = request.getJSONReader();

			//Get the products object
			JsonValue allProducts = jsonReader.AllObjects ["products"];

			DataSource db = DataSource.getInstance();

			int index = 0;
			//For each JSON product object, get it's values, and add the product to the DB
			foreach (JsonValue j in allProducts) {
				index++;
				//String prodClass="";
				//String cap = ""; 
				//String readability = ""; 
				//String segueName = "";
				float starRating = jsonReader.getNumericValue(j, "averageRating");
				String price = "";
				String imageURL = "";
				String title = jsonReader.getValue(j, "summary");
				String description = jsonReader.getValue(j, "description");

				if (title == "")
					title = "Unknown Product";

				if (j.ContainsKey("price")) {
					price = jsonReader.getValue(j ["price"], "formattedValue");
				}

				//Check if the node exists and get the value if it does
				if (j.ContainsKey("images")) {
					JsonValue tempJsonValue = j ["images"] [0]; //first image only
					imageURL = "http://swx-hybris-ash02.siteworx.com:9001" + (jsonReader.getValue(tempJsonValue, "url")).Replace("\"", ""); //remove quotes from the stirng 
				}  
				//Create the new product from the JSON values and add it to the DB

				Product p = new Product(imageURL, title, price, description, starRating);
				db.addLiveProductToDB(p);
			}
		}
	}
}

