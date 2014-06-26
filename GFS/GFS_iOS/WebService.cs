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
            request = HttpWebRequest.Create(url);
            request.ContentType = "application/" + contentType;
            feedReader = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream());
        }

        //Read XML from file
        public WebService()
        {
        }

        //Returns a new XML Reader
        public XMLReader getXMLReader()
        {
			feedReader = new StreamReader("sample.xml");
            return new XMLReader(feedReader);
        }

		//Placeholder for future JSON Reader
        //public JSONReader getJSONReader()
        //{
        //    return null;
        //}
    }
}