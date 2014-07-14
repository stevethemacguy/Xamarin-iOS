using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swx.B2B.Ecom.BL.Entities;

namespace Swx.B2B.Ecom.SVC
{
    public class ProductService
    {
        public ProductService()
        {
            //WebService webservice = new WebService("http://swx-hybris-ash02.siteworx.com:9001/rest/v1/electronics/products?query=a&pageSize=40", "json");
        }

        public JObject GetJSONProductByID(int id)
        {
            WebServiceBernice webservice = new WebServiceBernice("http://swx-hybris-ash02.siteworx.com:9001/rest/v1/electronics/products/" + id + "?options=BASIC,DESCRIPTION,PRICE", "json");
            var json = JObject.Parse(webservice.GetFeedReader().ReadToEnd());
            return json;
        }

        public JObject GetJsonProductSearchSuggestion(string term)
        {
            WebServiceBernice webservice = new WebServiceBernice("http://swx-hybris-ash02.siteworx.com:9001/rest/v1/electronics/products/suggest?term=" + term + "&max=5", "json");
            var json = JObject.Parse(webservice.GetFeedReader().ReadToEnd());
            return json;     
        }

        public JObject GetJsonProductSearchList(string searchTerm)
        {
            WebServiceBernice webservice = new WebServiceBernice("http://swx-hybris-ash02.siteworx.com:9001/rest/v1/electronics/products?query=freeTextSearch:sort:name:" + searchTerm + ":description:" + searchTerm, "json");
            var json = JObject.Parse(webservice.GetFeedReader().ReadToEnd());
            return json;     
        }

        /*
        // Get product information containing image, detail, name, price, etc.
        public String GetProductName(int id)
        {
            WebService webservice = new WebService("http://swx-hybris-ash02.siteworx.com:9001/rest/v1/electronics/products/" + id + "?options=BASIC", "json");

            //System.Diagnostics.Debug.WriteLine(webservice.GetFeedReader().ReadToEnd());
            var json = JObject.Parse(webservice.GetFeedReader().ReadToEnd());

            String name = json["name"].ToObject<string>();
            return name;
        }

        public String GetProductPrice(int id)
        {
            WebService webservice = new WebService("http://swx-hybris-ash02.siteworx.com:9001/rest/v1/electronics/products/" + id + "?options=PRICE", "json");
            var json = JObject.Parse(webservice.GetFeedReader().ReadToEnd());
            String price = json["price"]["formattedValue"].ToObject<string>();
            return price;
        }

        public String GetProductDescription(int id)
        {
            WebService webservice = new WebService("http://swx-hybris-ash02.siteworx.com:9001/rest/v1/electronics/products/" + id + "?options=DESCRIPTION", "json");
            var json = JObject.Parse(webservice.GetFeedReader().ReadToEnd());
            String description = json["description"].ToObject<string>();
            return description;
        }

        public String GetProductImage(int id)
        {
            WebService webservice = new WebService("http://swx-hybris-ash02.siteworx.com:9001/rest/v1/electronics/products/" + id + "?options=BASIC,DESCRIPTION", "json");
            //System.Diagnostics.Debug.WriteLine(webservice.GetFeedReader().ReadToEnd());
            var json = JObject.Parse(webservice.GetFeedReader().ReadToEnd());
            int imgIndex = 0;

            foreach(Object img in json["images"])
            {
                var images = json["images"][imgIndex]["url"].ToObject<string>();
                System.Diagnostics.Debug.WriteLine(images);
                imgIndex++;
            }

            String imageURL = "";
            return imageURL;
        }
         
        */
    }

}
