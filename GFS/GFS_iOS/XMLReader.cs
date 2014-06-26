using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GFS_iOS
{
    class  XMLReader
    {
        private XDocument doc;

        public XMLReader(StreamReader feedReader)
        {
            doc = XDocument.Parse(feedReader.ReadToEnd());
        }

        public IEnumerable<XElement> getParentNodes(String parent)
        {
            return doc.Root.Descendants(parent);
        }

    }
}