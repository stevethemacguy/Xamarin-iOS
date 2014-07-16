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
	/// ProductManager provides the device UI layer with methods to access entities in the SQL Database
    /// </summary>
    class ProductManager
    {
        public ProductManager()
        {
        }

		//***************** Methods Currently Used by the iOS App *********************\\
		//*****************************************************************************\\

		//Makes a request to the Webservice to retrieve product search suggestions that match the term entered into the search bar.
		//Returns the resulting List of suggestion words
		public List<String> getProductSearchSuggestions(string term)
		{
			WebService request = new WebService("suggest?term=" + term, "json");

			//Initialize the JSON reader
			NewtonJsonReader jsonReader = request.getJsonReader();

			//Get the suggested words and return them
			return jsonReader.getSuggestedWords();
		}

		//Makes a webservice call to retreive products that match the search term provided.
		//Returns a Dictionary of the Products returned from the NewtonJsonReader (key is the product code, value is the Product)
		public List<Product> getProductsBySearchTerm(string searchTerm)
		{
			WebService request = new WebService("?query=freeTextSearch:sort:name:" + searchTerm + ":description:" + searchTerm, "json");

			//Initialize the JSON reader
			NewtonJsonReader jsonReader = request.getJsonReader();

			Dictionary<String,Product> results = jsonReader.getProductsFromJson();

			//Now that we have a dictionary of Products, move these products into a basic list
			List<Product> prodList = new List<Product>();

			foreach (Product p in results.Values)
			{
				prodList.Add(p);
			}
			return prodList;
		}



		//***************** Bernice's Methods below this line *****************\\
		//**********************************************************************\\

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