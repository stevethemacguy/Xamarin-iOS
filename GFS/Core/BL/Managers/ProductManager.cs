﻿using System;
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

        public Product GetProductByID(int id)
        {
            Product product = new Product();
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
    }
}
