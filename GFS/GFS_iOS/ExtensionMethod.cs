using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GFS_iOS
{
    public static class  ExtensionMethod
    {
        //this method checks if the element exist to avoid nullreference exception, if yes returns the value, if no returns null
        public static string GetElementValue(this XElement parentElement, string elementName)
        {
            var element = parentElement.Element(elementName);
            if (element != null)
            {
                return element.Value;
            }
            else
            {
                return null;
            }
        }

        //this method returns a specified child element.
        public static XElement GetElement(this XElement parentElement, string elementName)
        {
            var element = parentElement.Element(elementName);
            if (element != null)
            {
                return element;
            }
            else
            {
                return null;
            }
        }

        //this method returns a list of images associate with the product.
        public static List<Image> GetImages(this XElement parentElement, string elementName)
        {
            List<Image> images = new List<Image>();
            var imageElements = parentElement.Descendants("image");
            foreach (XElement iElement in imageElements)
            {
                Image img = new Image();
                img.Type = iElement.GetElementValue("imageType");
                img.Format = iElement.GetElementValue("format");
                img.URL = iElement.GetElementValue("url");
                images.Add(img);
            }

            return images;
        }
    }
}