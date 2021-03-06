﻿using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Swx.B2B.Ecom.BL.Entities;

//ImageCache is a singleton object that temporarily caches Product images (i.e UIImages) while the App is running. 

//Background:
//	Caching UIImages dramatically improves scrolling speed when viewing ProductCells (as opposed to creating the UIImages as part of getCell()).
//	The ImageCache is "cleared" whenever the user starts a new search (See SearchViewController). When "clearing the cache,"
//	ImageCache only "keeps" images that persist in the DataSource. ImageCache will never grow larger than the number of saved products + the images temporarily used by a single search.
//	When searching, images used in the search are temporarily cached, but these images are removed every time a new search begins.
namespace GFS_iOS
{
	public class ImageCache
	{
		private static ImageCache instance; //There can only be one instance of the ImageCache.

		//ImageMap stores all the UIImages in ImageCache. Keys are product IDs, values are UIImages
		private Dictionary<String, UIImage> ImageMap;

		protected ImageCache()
		{
			ImageMap = new Dictionary<String, UIImage>();
		}

		//Returns the singleton ImageCache (or creates and returns it if has not been instantiated).
		public static ImageCache getInstance()
		{
			//If the DataSource has not been created, then create it once.
			if(instance == null) {
				instance = new ImageCache();
			}
			return instance;
		}

		//Creates a UIImage from the url passed and adds the UIImage to the image cache
		public void addImage(String productCode, String url)
		{
			//Don't create duplicates
			if (ImageMap.ContainsKey(productCode))
				return;

			UIImage image = new UIImage();

			//If there's an image url, then create the image now so it's already chached.
			if (url != "") {
				//Create a url from the string and use it with an NSData object
				NSData data = NSData.FromUrl(new NSUrl(url));
				//Create a UIimage using the url to load the image
				image = UIImage.LoadFromData(data);

			}
			else //If no image is provided, then use the default image
			{
				image = UIImage.FromFile("noImage.png");
			}

			ImageMap.Add(productCode, image);
		}

		//Removes an image from the cache. Not currently used.
		public void removeImage(String productCode)
		{
			if (ImageMap.ContainsKey(productCode))
				ImageMap.Remove(productCode);
		}

		//Removes all images in the image cache, EXCEPT for images associated with products that persist in the DataSource
		//Images for products in the DataSource are NOT removed. (e.g. Products that were added to a saved list, when manual is saved, etc) 
		public void clearCache()
		{
			//A dictionary to store UIImages we want to save. Keys are product IDs, values are UIImages
			Dictionary<String, UIImage> savedImages = new Dictionary<String, UIImage>();

			//No images for products in the DataSource should be removed, so save these images
			foreach (Product p in DataSource.getInstance().getAllProducts().Values)
			{
				//Add the product code as the key, add the image from the ImageCache as the value
				savedImages.Add(p.getCode(), ImageMap[p.getCode()]);
			}

			//Remove all images from the cache by creating a new ImageMap
			ImageMap = null;
			ImageMap = new Dictionary<String, UIImage>();

			//Add the saved images back into the cache
			foreach (KeyValuePair<String, UIImage> saved in savedImages)
			{
				ImageMap.Add(saved.Key, saved.Value);
			}
		}

		//Retreives an image associated with the productCode passed. If the product has no image, just returns a new, empty UIImage
		public UIImage getImage(String productCode)
		{
			if (ImageMap.ContainsKey(productCode))
				return ImageMap[productCode];
			else
				return new UIImage();
		}

		//Prints all images in the image cache
		public void printImageCache()
		{
			foreach (UIImage img in ImageMap.Values)
				Console.WriteLine(img.ToString());
		}
	}
}