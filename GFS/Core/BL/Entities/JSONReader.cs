using Swx.B2B.Ecom.BL;
using System;
using System.IO; //For Stream Reader
using System.Json;

//Parses a Json feed and returns JsonValues using System.Json. CAUTION: System.Json is a (silverlight) library that can only be used by MonoTouch applications.
//In other words, JSONReader will only work if it is used by Xamarin iOS code in the "presentation layer." 
//If you need a more generic JSON Reader to work with any C# project, use a NewtonJsonReader instead, since it uses the JSON.Net library.
namespace Swx.B2B.Ecom.SVC
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

		//If obj exists, returns the numerice value of the JSON object, otherwise returns -1
		public float getNumericValue(JsonValue obj, String key)
		{
			if(obj.ContainsKey(key))
			{
				return obj[key];
			}
			else
			{
				return -1;
			}
		}
	}
}