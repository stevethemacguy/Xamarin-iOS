using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
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
       
        public WebService(string url, string contentType)
        {
            request = HttpWebRequest.Create(url);
            request.ContentType = "application/" + contentType;
            feedReader = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream());
        }

        //Read XML from file
        public WebService()
        {
            feedReader = new StreamReader("Hybris_Product_API_Feed.xml");
        }

        //Returns a new XML Reader
        public XMLReader getXMLReader()
        {
            return new XMLReader(feedReader);
        }

        //public JSONReader getJSONReader()
        //{
        //    return null;
        //}
    }
}