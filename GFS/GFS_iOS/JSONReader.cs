using System;
using System.IO; //For Stream Reader
using System.Json;

namespace GFS_iOS
{
    class JSONReader
    {
		//The "parent" JSON object returned from the feedReader that contains all other objects
		public JsonValue AllObjects;

        public JSONReader(StreamReader feedReader)
        {
            AllObjects = JsonObject.Parse(feedReader.ReadToEnd());
        }

        //If obj exists, returns the value of the JSON object, otherwise returns an empty string
		//Returned string is stripped of quotations
		public String getValue(JsonValue obj, String key)
        {
			if(obj.ContainsKey(key))
			{
				return Helpers.stripQuotes(obj[key].ToString());
			}
			else
			{
				return "";
			}
        }
	}
}