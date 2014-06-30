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
       
		//Placeholder for real web service functionality
        public WebService(string url, string contentType)
        {
            //var request = HttpWebRequest.Create("http://swx-hybris-ash02.siteworx.com:9001/rest/v1/electronics/products?query=a&pageSize=40");
            ////request.ContentType = "application/xml";
            //request.ContentType = "application/json";
            //request.Method = "GET";
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //StreamReader reader = new StreamReader(response.GetResponseStream());

            request = HttpWebRequest.Create(url);
            request.ContentType = "application/" + contentType;
            request.Method = "GET";
            feedReader = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream());
        }

        //Read XML from file
        public WebService()
        {
        }

        //Returns a new XML Reader
        public XMLReader getXMLReader()
        {
			feedReader = new StreamReader("Hybris_Product_API_Feed.xml");
            return new XMLReader(feedReader);
        }

		//Placeholder for future JSON Reader
        public JSONReader getJSONReader()
        {
            return new JSONReader(feedReader);
        }
    }
}