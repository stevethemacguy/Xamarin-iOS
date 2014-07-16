using Swx.B2B.Ecom.BL;
using System;
using System.IO;
using System.Json;

//Parses a Json feed and returns JsonValues using System.Json. The current iOS app no longer uses JSONReader.

//CAUTION: System.Json is a (silverlight) library that can only be used by MonoTouch applications.
//In other words, JSONReader will only work if it is used by Xamarin iOS code in the "presentation layer." 
//NewtonJsonReader, however is a more generic JSON Reader that will work with any C# project, since it uses the JSON.Net library. 
//In most cases, you will use NewtonJsonReader instead. 
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