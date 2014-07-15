using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swx.B2B.Ecom.BL.Entities;
using Swx.B2B.Ecom.SVC;

namespace Swx.B2B.Ecom.BL.Managers
{
    /// <summary>
    /// Call here from device UI layer to access Products
    /// </summary>
    class ProductManager
    {
        public ProductManager()
        {
        }

		//***************** Steve's Methods *********************

		//	Makes a request to the Webservice to retrieve product search suggestions that match a term entered into the search bar.
		//	Returns the resulting List of search terms
		public List<String> getProductSearchSuggestions(string term)
		{
			WebService request = new WebService("suggest?term=" + term, "json");
			Console.WriteLine(request.ToString());

			//Initialize the JSON reader
			NewtonJsonReader jsonReader = request.getJsonReader();

			//get the words
			return jsonReader.getSuggestedWords();
		}

		public void test()
		{
			WebService request = new WebService("?query=freeTextSearch:sort:name:" + "camera" + ":description:" + "camera", "json");
			//Initialize the JSON reader
			NewtonJsonReader jsonReader = request.getJsonReader();

			Dictionary<String, JsonProduct> productMap = jsonReader.getProductsFromJson();

			//Print the results
			foreach (JsonProduct p in productMap.Values)
			{
				Console.WriteLine(p.ToString());
			}

		}

		//Makes a webservice call using the search term provided. Parses the Json object, creating a product for each results, and 
		//Returns a list of the resulting products.
//		public List<Product> getProductsBySearchTerm(string searchTerm)
//		{
//			WebService request = new WebService("?query=freeTextSearch:sort:name:" + searchTerm + ":description:" + searchTerm, "json");
//			//Initialize the JSON reader
//			JSONReader jsonReader = request.getJSONReader();
//
//			//Get the products object
//			JsonValue allProducts = jsonReader.AllObjects ["products"];
//
//			List<Product> products = new List<Product>();
//
//			int index = 0;
//			//For each JSON product object, create a product using it's values and add the product to the list of products
//			foreach (JsonValue j in allProducts){
//				index++;
//				float starRating = jsonReader.getNumericValue(j, "averageRating");
//				String price = "";
//				String imageURL = "";
//				String title = jsonReader.getValue(j, "summary");
//				String code = jsonReader.getValue(j, "code");
//				String description = jsonReader.getValue(j, "description");
//
//				if (title == "")
//					title = "Unknown Product";
//
//				if (j.ContainsKey("price")) {
//					price = jsonReader.getValue(j ["price"], "formattedValue");
//				}
//
//				//Check if the node exists and get the value if it does
//				if (j.ContainsKey("images")) {
//					JsonValue tempJsonValue = j ["images"] [0]; //first image only
//					imageURL = "http://swx-hybris-ash02.siteworx.com:9001" + (jsonReader.getValue(tempJsonValue, "url")).Replace("\"", ""); //remove quotes from the stirng 
//				}  
//
//				//Create the new product from the JSON values and add it to the product list
//				Product p = new Product(code,imageURL, title, price, description, starRating);
//				products.Add(p);
//
//				//Add the Products image url to the Image cache to be later used by Product Cells.
//				ImageCache.getInstance().addImage(code, imageURL);
//			}
//
//			//For testing only
//			ImageCache.getInstance().printImageCache();
//			return products;
//		}



		//*********Bernice's Methods below this line*************
        
		public ProductBernice GetProductByID(int id)
        {
            ProductBernice product = new ProductBernice();
            product.Images = new List<Image>();

            ProductService jsonWS = new ProductService();
            var json = jsonWS.GetJSONProductByID(id);

            // Add product information
            product.Id = id;
            product.Name = json["name"].ToObject<string>();
            product.Prices = json["price"]["formattedValue"].ToObject<string>();
            product.Description = json["description"].ToObject<string>();

            int imgIndex = 0;
            foreach (Object img in json["images"])
            {
                Image productImage = new Image();

                productImage.Id = id;
                productImage.ImageType = json["images"][imgIndex]["imageType"].ToObject<string>();
                productImage.Format = json["images"][imgIndex]["format"].ToObject<string>();
                productImage.AltText = json["images"][imgIndex]["altText"].ToObject<string>();
                productImage.Url = json["images"][imgIndex]["url"].ToObject<string>();
                
                // Add image to the product
                product.Images.Add(productImage);
                imgIndex++;
            }

            return product;
        }

//        public string[] GetProductSearchSuggestions(string term)
//        {
//            ProductService jsonWS = new ProductService();
//            string[] suggestedTerms = new string[5];
//            var json = jsonWS.GetJsonProductSearchSuggestion(term);
//            int index = 0;
//            foreach (Object values in json["suggestions"])
//            {
//                //System.Diagnostics.Debug.WriteLine(json["suggestions"][index]["value"].ToObject<string>());
//                suggestedTerms[index] = json["suggestions"][index]["value"].ToObject<string>();
//                index++;
//            }
//
//            return suggestedTerms;
//        }

        public List<ProductBernice> GetProductSearchList(string term)
        {
            List<ProductBernice> productList = new List<ProductBernice>();

            ProductService jsonWS = new ProductService();
            var json = jsonWS.GetJsonProductSearchList(term);
            int index = 0;
            //System.Diagnostics.Debug.WriteLine(json);
            foreach (Object values in json)
            {
                ProductBernice product = new ProductBernice();
                product.Images = new List<Image>();

                product.Id = json["products"][index]["code"].ToObject<int>();
                product.Name = json["products"][index]["name"].ToObject<string>();
                product.Prices = json["products"][index]["price"]["formattedValue"].ToObject<string>();
                product.Description = json["products"][index]["description"].ToObject<string>();
                //productImage.Url = json["images"][imgIndex]["url"].ToObject<string>();

                int imgIndex = 0;
                foreach (Object img in json["products"][index]["images"])
                {
                    Image productImage = new Image();

                    productImage.Id = json["products"][index]["code"].ToObject<int>();
                    productImage.ImageType = json["products"][index]["images"][imgIndex]["imageType"].ToObject<string>();
                    productImage.Format = json["products"][index]["images"][imgIndex]["format"].ToObject<string>();
                    productImage.AltText = "";
                    //productImage.AltText = json["products"][index]["images"][imgIndex]["altText"].ToObject<string>();
                    productImage.Url = json["products"][index]["images"][imgIndex]["url"].ToObject<string>();
                    // Add image to the product
                    product.Images.Add(productImage);
                    imgIndex++;
                }
                // Add image to the product
                productList.Add(product);
                index++;
            }

            return productList;
        }
    }
}
