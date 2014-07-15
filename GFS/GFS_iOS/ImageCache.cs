using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace GFS_iOS
{
	public class ImageCache
	{
		private static ImageCache instance; //There can only be one instance of the DataSource.

		//Keys are product IDs, values are UIImages
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
			UIImage image = new UIImage();
			//If there's an image url, then create the image now so it's already chached.
			if (url != "") {
				//Create a url from the string and use it with an NSData object
				NSData data = NSData.FromUrl(new NSUrl(url));
				//Create a UIimage using the url to load the image
				image = UIImage.LoadFromData(data);

			}
			ImageMap.Add(productCode, image);
		}

		//Deletes all images in the image cache
		public void clearCache()
		{
			ImageMap = null;
			ImageMap = new Dictionary<String, UIImage>();
		}

		//Retreives an image associated with the productCode passed. If the product has no image, just returns a new, empty UIImage
		public UIImage getImage(String productCode)
		{
			if (ImageMap.ContainsKey(productCode))
				return ImageMap[productCode];
			else
				return new UIImage();
		}
	}
}

