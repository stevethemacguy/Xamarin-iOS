using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.IO;

namespace GFS_iOS
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

	}
}