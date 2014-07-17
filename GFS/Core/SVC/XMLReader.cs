using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace Swx.B2B.Ecom.SVC
{
	public class  XMLReader
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

		//Returns the value of the node passed. If the node does not exist (is null), then an empty string is returned.
		public String getNodeValue(XElement node)
		{
			if (node == null)
			{
				return "";
			}
			else {
				return node.Value;
			}
		}
	}
}