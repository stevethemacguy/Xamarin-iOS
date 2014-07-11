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
			//Get the suggestionts object
			JsonValue suggestionsObject = jsonReader.AllObjects ["suggestions"];

			List<String> suggestions = new List<String>();
			//Parse through the json and add all search suggestion strings to the suggestions list
			foreach (JsonValue j in suggestionsObject)
			{
				suggestions.Add(jsonReader.getValue(j, "value"));
			}
			return suggestions;
		}
	}
}

