﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Net;
using System.Xml.Linq;

using Swx.B2B.Ecom.SVC;

namespace Swx.B2B.Ecom.SVC
{
    class WebServiceBernice
    {
        private WebRequest request;
        private StreamReader feedReader;

        //Placeholder for real web service functionality
        public WebServiceBernice(string url, string contentType)
        {
            request = HttpWebRequest.Create(url);
            request.ContentType = "application/" + contentType;
            feedReader = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream());
        }

        //Read XML from file
        public WebServiceBernice()
        {
        }

        public StreamReader GetFeedReader()
        {
            return feedReader;
        }
    }
}