using System;
using System.IO; //For Stream Reader
using System.Json;

namespace GFS_iOS
{
    class JSONReader
    {
        private JsonValue doc;

        public JSONReader(StreamReader feedReader)
        {
            doc = JsonObject.Parse(feedReader.ReadToEnd());
        }

        //Get a collection of nodes specified under root
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

        //Return the value of a node specified if the node exist, otherwise, returns an empty string
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