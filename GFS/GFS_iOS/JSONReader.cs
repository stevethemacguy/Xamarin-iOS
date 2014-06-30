using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GFS_iOS
{
    class JSONReader
    {
        private JsonValue doc;

        public JSONReader(StreamReader feedReader)
        {
            doc = JsonObject.Parse(feedReader.ReadToEnd());
        }

        public JsonValue getParentNodes(String parent)
        {
            if (doc.ContainsKey(parent))
            {
                return doc[parent];
            }
            else
            {
                return null;
            }
        }

        public String GetNodeValue(JsonValue node, string name)
        {
            if (node.ContainsKey(name))
            {
                return node[name].ToString();
            }
            else
            {
                return "";
            }
        }
    }
}