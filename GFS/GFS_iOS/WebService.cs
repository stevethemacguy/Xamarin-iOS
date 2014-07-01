using System;
using System.IO;
using System.Net;

namespace GFS_iOS
{
    class WebService
    {
        private WebRequest request;
        private StreamReader feedReader;
       
		//Initialize the WebService using the paramters passed in the constructor
        public WebService(string url, string contentType)
        {
            request = HttpWebRequest.Create(url);
            request.ContentType = "application/" + contentType;
            request.Method = "GET";
            feedReader = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream());
        }

        //Returns a new XML Reader
        public XMLReader getXMLReader()
        {
			//Currently just reads from a flat file.
			feedReader = new StreamReader("Hybris_Product_API_Feed.xml");
            return new XMLReader(feedReader);
        }

		//Returns a new XML Reader
        public JSONReader getJSONReader()
        {
            return new JSONReader(feedReader);
        }
    }
}