using System;
using System.IO;
using System.Net;

namespace GFS_iOS
{
    class WebService
    {
        private WebRequest request;
        private StreamReader feedReader;
		private String baseURL = "http://swx-hybris-ash02.siteworx.com:9001/rest/v1/electronics/products/";

		//Initialize the WebService using the paramters passed in the constructor
        public WebService(string urlOptions, string contentType)
        {
			request = HttpWebRequest.Create(baseURL + urlOptions);
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
			
        public JSONReader getJSONReader()
        {
            return new JSONReader(feedReader);
        }
    }
}