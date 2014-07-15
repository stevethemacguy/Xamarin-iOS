using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;
using Swx.B2B.Ecom.BL.Entities;
using System.IO;
using Newtonsoft.Json.Linq;

///NewtonJsonReader constructs JsonProducts by parsing through the json feed passed in the constructor.
///It uses the Newtonsoft.Json (i.e. JSON.Net) library.
namespace Swx.B2B.Ecom.SVC
{
    class NewtonJsonReader
    {
		public NewtonJsonReader(StreamReader feedReader)
		{
			//Get full json string
			String jsonResultString = feedReader.ReadToEnd();

			//Create a JObject from the json string
			JObject jo = JObject.Parse(jsonResultString);

			//Deserialize the Json and automatically create JsonProducts directly from the Json Object properties.
			//Note: Using SelectToken("products") essentially "Ignores" the root level object. We are concerned with the contents of "products," but not the object itself.
			List<JsonProduct> jsonProductList = jo.SelectToken("products", false).ToObject<List<JsonProduct>>();

			//Continue parsing the Json feed, adding the images to products that have images.
			parseImages(jo, jsonProductList);
		}

		//There appears to be a bug in the JSON.Net reader that prevents a List of Images from being instantiated automatically.
		//parseImages() instaniates these image objects manually, and associates them with the JsonProducts by matchin their IDs.
		//parseImages() is called as part of the parsing process whenever a NewtonJsonReader is instantiated.
		private void parseImages(JObject jo, List<JsonProduct> jsonProductList)
		{
			//Create a map where the key is the product code and the value is the product itself.
			Dictionary<string, JsonProduct> prdMap = new Dictionary<string, JsonProduct>();

			//Add each (recentantly instantiated) JsonProduct to the map, using the product's code as a key 
			foreach(JsonProduct j in jsonProductList)
			{
				prdMap.Add(j.code, j);
			}

			//Continue parsing the Json stream, this time focusing on the images object only.
			//For each product in the jsonProductList
			for (int count = 0; count < jsonProductList.Count; count++)
			{
				//if the product has a list of images
				if(jo.SelectToken("products["+count+"].images",false) != null)
				{
					//Get the product's "images" list
					List<Image> imgList = jo.SelectToken("products["+count+"].images", false).ToObject<List<Image>>();

					//Get the product's ID
					String prodCode = jo.SelectToken("products["+count+"].code", false).ToObject<String>();

					//Add the image list to the actual JsonProduct
					prdMap[prodCode].imageList = imgList;

					//Create the product's image url from the first image in the list
					prdMap[prodCode].imageFileName = "http://swx-hybris-ash02.siteworx.com:9001" + imgList[0].Url.Replace("\"", ""); //remove quotes from the stirng 
				}
			}

			//Print the results
			foreach (JsonProduct p in jsonProductList)
			{
				Console.WriteLine(p.ToString());
			}
		}
    }
}
