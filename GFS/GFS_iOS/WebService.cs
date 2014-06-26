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
            //constructor initializing source from local file
			feedReader = new StreamReader("sample.xml");
            doc = XDocument.Parse(feedReader.ReadToEnd());
        }

        //setting web service source(URL) and type(xml, json)
        public void SetWebServiceSource(string url, string contentType)
        {
            request = HttpWebRequest.Create(url);
            request.ContentType = contentType;
            feedReader = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream());
            doc = XDocument.Parse(feedReader.ReadToEnd());
        }

        //this method returns a collection of products with all the fields.
        public IEnumerable<Product> GetAllProducts()
        {
            ExtensionMethod helper = new ExtensionMethod();
            var result = doc.Root.Descendants("product").Select(x => new Product()
            {
                Summary = helper.GetElementValue(x,"summary"),
                AverageRating = helper.GetElementValue(x,"averageRating"),
                stocklevelstatuscode =  new ExtensionMethod().GetElementValue(new ExtensionMethod().GetElement((new ExtensionMethod().GetElement(x,"stock")),"stockLevelStatus"),"code"),
                //stocklevelstatuscode = x.GetElement("stock").GetElement("stockLevelStatus").GetElementValue("code"),

            });
            return result;
        }
    }
}