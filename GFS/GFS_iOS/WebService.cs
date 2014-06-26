using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Net;
using System.Xml.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GFS_iOS
{
    class WebService
    {
        private WebRequest request;
        private StreamReader feedReader;
        private XDocument doc;

        public WebService()
        {
            feedReader = new StreamReader("Hybris_Product_API_Feed.xml");
            doc = XDocument.Parse(feedReader.ReadToEnd());
        }

        public void SetWebServiceSource(string url, string contentType)
        {
            request = HttpWebRequest.Create(url);
            request.ContentType = contentType;
            feedReader = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream());
            doc = XDocument.Parse(feedReader.ReadToEnd());
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var result = doc.Root.Descendants("product").Select(x => new Product()
            {
                Summary = x.GetElementValue("summary"),
                AverageRating = x.GetElementValue("averageRating"),
                stocklevelstatuscode = x.GetElement("stock").GetElement("stockLevelStatus").GetElementValue("code"),

            });
            return result;
        }
    }
}