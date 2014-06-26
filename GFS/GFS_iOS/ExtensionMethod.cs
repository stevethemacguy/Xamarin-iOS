using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GFS_iOS
{
    class  ExtensionMethod
    {
        //this method checks if the element exist to avoid nullreference exception, if yes returns the value, if no returns null
        private string GetElementValue(XElement parentElement, string elementName)
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
        private XElement GetElement(XElement parentElement, string elementName)
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
        private List<Image> GetImages(XElement parentElement, string elementName)
        {
            List<Image> images = new List<Image>();
            var imageElements = parentElement.Descendants("image");
            foreach (XElement iElement in imageElements)
            {
                Image img = new Image();
                img.Type = GetElementValue(iElement, "imageType");
                img.Format = GetElementValue(iElement,"format");
                img.URL = GetElementValue(iElement, "url");
                images.Add(img);
            }

            return images;
        }
    }
}