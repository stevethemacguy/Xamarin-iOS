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


namespace Swx.B2B.Ecom.SVC
{
    class NewtonJsonReader
    {
		public NewtonJsonReader(StreamReader feedReader)
		{
			String test = feedReader.ReadToEnd();

			//Ignore/skip the root level "products" object
			JObject jo = JObject.Parse(test);
			List<JsonProduct> cool = jo.SelectToken("products", false).ToObject<List<JsonProduct>>();


			//List<TestProduct> deserializedProduct = JsonConvert.DeserializeObject<List<TestProduct>>(test);
			foreach (JsonProduct p in cool)
			{
				Console.WriteLine(p.ToString());
			}
		}

    }

}
