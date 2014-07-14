using Swx.B2B.Ecom.SVC;
using System;
using System.Collections.Generic;
using System.Json;
using System.Xml.Linq;

//DataSource currently maintains all app data while the application is running (i.e. it acts as temporary memory for the IOS App).
//In the future, DataSource's methods will instead make calls to a real SQL Lite database.
namespace Swx.B2B.Ecom.BL.Entities
{
	//DataSource is a singleton object that stores temporary products used by the application when displaying various views
	public class DataSource
	{
		private HashSet<string> savedListSet; //Each string in the savedList Set is a name of one saved list. (savedLists is a Set, so no duplicates allowed).
		private List<string> allNotes; //Each String is the full text of a note.
		private static DataSource instance; //There can only be one instance of the DataSource.
		private List<Product> productList;
		public String currentProduct = "";

		//If a product is in manualList, then the product will appear as a cell in the manual view and link to a single manual.
		private List<Product> manualList; 
		//Since each product can have several downlaoded PDFs, this should actually be a Dictionary where the key is a product ID, 
		//and the value is either a list of Manuals, or a list of Strings (where the string is a filepath for the manual)

		public Boolean alreadyInitialized = false;

		//Each Saved List has a list of associated products.
		//A map where Key is the list name, and value is a list of products associated with that list
		private Dictionary<String, List<Product>> savedListProductMap;

		//Stores all products that are loaded from the webservice (via xml or json)
		//A map where Key is product ID, and value is the product with that ID.
		private Dictionary<String, Product> productMap;

		//Can't be instantiated except by the getInstance method
		protected DataSource()
		{
			//Create the savedList and add the two default lists in the list
			if (savedListSet == null)
			{
				savedListSet = new HashSet<string>();
				savedListProductMap = new Dictionary<string, List<Product>>();
				//Add the two defaults for now
				addSavedList("cameras");
				addSavedList("others");
				allNotes = new List<string>();
				addNote("Found these products last week. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras mattis consectetur purus sit amet fermentum. ");
				addNote("Another good find");
				manualList = new List<Product>();
			}

			//Create the productList and add the two default products to the list
			if (productList == null)
			{
				productList = new List<Product>();
			}

			productMap = new Dictionary<String, Product>();
		}

		//Adds a product to the DB
		public void addLiveProductToDB(Product p)
		{
				//Highlight a couple products for demo purposes only
				//if (index == 1 || i == 2)
				//	p.toggleHighlight();
				productMap.Add(p.getID(), p); //Uses the ID as a key
		}

		//Creates all the products in the database (currently from an XML file)
		public void initializeDBfromJSON()
		{
			//Ensure products are only created once.
			if (alreadyInitialized)
				return;
			//Initialize the webservice.
            WebService webservice = new WebService("http://swx-hybris-ash02.siteworx.com:9001/rest/v1/electronics/products?query=a&pageSize=40", "json");

            //Initialize the JSON reader
            JSONReader jsonReader = webservice.getJSONReader();

			//Get the products object
			JsonValue products = jsonReader.AllObjects["products"];

			///////Limit the results FOR TESTING ONLY//////
			int limit = 0;
            foreach (JsonValue j in products)
            {
				limit++;
				/////FOR DEMO ONLY!//////
				///Filter out "duplicate" items for the demo so the results are nicer
				if ((limit >= 3 && limit <= 9) || limit == 11 )
					continue; //Continue on with the loop, but ignore these 3 results

				////Limit the results to 15 (23 minus the 8 we're skipping) FOR TESTING ONLY//////
				if (limit > 23)
				//if (limit > 10)
					break;

				float starRating = jsonReader.getNumericValue(j, "averageRating");
                String price = "";
                String imageURL = "";
				String title = jsonReader.getValue(j, "summary");
				String description = jsonReader.getValue(j, "description");

				if (title == "")
					title = "Unknown Product";

				if (j.ContainsKey("price"))
                {
					price = jsonReader.getValue(j["price"], "formattedValue");
                }

                //Check if the node exists and get the value if it does
                if (j.ContainsKey("images"))
                {
                    JsonValue tempJsonValue = j["images"][0]; //first image only
					imageURL = "http://swx-hybris-ash02.siteworx.com:9001" + (jsonReader.getValue(tempJsonValue, "url")).Replace("\"", ""); //remove quotes from the stirng 
                }

                //Create the new product from the xml values and add it to the product map
				Product p = new Product(imageURL, title, price, description, starRating);

				//Highlight a couple products for demo purposes only
				if (limit == 1 || limit == 2)
					p.toggleHighlight();

                productMap.Add(p.getID(), p); //Uses the ID as a key
            }

			alreadyInitialized = true;
			//Print out all the product information
			//printAllProducts();
		}

		//Establishes a connection with the Webservice and creates all products by parsing the returned XML.
		public void initializeDBfromXML()
		{
			if (alreadyInitialized)
				return;
			Helpers helper = new Helpers();

			//Initialize the webservice. Just reads from flat XML file for now
			WebService webservice = new WebService("http://swx-hybris-ash02.siteworx.com:9001/rest/v1/electronics/products?query=a&pageSize=40", "xml");

			//Initialize the XML reader
			XMLReader xmlReader = webservice.getXMLReader();

			//Get all parent "product" nodes so we can loop over them
			IEnumerable<XElement> productNodes = xmlReader.getParentNodes("product");
			foreach (XElement x in productNodes)
			{
				//String prodClass="";
				//String cap = ""; 
				//String readability = ""; 
				//String segueName = ""; 
				String price = "";
				String imageURL = "";
				String title = xmlReader.getNodeValue(x.Element("summary"));
				String description = xmlReader.getNodeValue(x.Element("description"));
				float starRating = -1;

				//Check if the node exists and get the value if it does
				if (helper.isNotNull(x.Element("price")))
				{
					price = xmlReader.getNodeValue(x.Element("price").Element("formattedValue"));
				}

				//Check if the node exists and get the value if it does
				if (helper.isNotNull(x.Element("images")))
				{
					if (helper.isNotNull(x.Element("images").Element("image"))) 
					{
						imageURL = "http://swx-hybris-ash02.siteworx.com:9001" + xmlReader.getNodeValue(x.Element("images").Element("image").Element("url"));
					}
				}

				//Create the new product from the xml values and add it to the product map
				Product p = new Product(imageURL, title, price, description, starRating);
				productMap.Add(p.getID(), p); //Uses the ID as a key
			}

			alreadyInitialized = true;
			printAllProducts();

		} //End initializeDBFromXML

		public List<Product> getProductList() {
			return productList;
		}

		//Returns a map of all products from the database, where the key is the product's unique ID and the value is the product
		public Dictionary<String, Product> getAllProducts()
		{
			return productMap;
		}

		//Adds a product to the database using the product's unique ID as a key in the map
		public void addProductToDB(String productID, Product toAdd)
		{
			productMap.Add(productID, toAdd);
		}

		//Removes product with an id of productID from the database.
		public void removeProductFromDB(String productID)
		{
			productMap.Remove(productID);
		}

		public void addToManualList(Product product)
		{
			if (manualList.Contains(product)) //don't add duplicates
				return;
			else
				manualList.Add(product);
		}

		public List<Product> getManualList() {
			return manualList;
		}

		public Dictionary<String, List<Product>> getSavedListMap(){
			return savedListProductMap;
		}

		public void addSavedList(string tooAdd)
		{
			savedListSet.Add(tooAdd);
		}

		public void removeSavedList(string toRemove)
		{
			savedListSet.Remove(toRemove);
		}

		//Returns a set of all saved lists
		public HashSet<string> getSavedListSet()
		{
			return savedListSet;
		}

		public void addNote(string tooAdd)
		{
			allNotes.Add(tooAdd);
		}

		public void removeNote(string toRemove)
		{
			allNotes.Remove(toRemove);
		}

		//Returns a set of all saved lists
		public List<string> getAllNotes()
		{
			return allNotes;
		}

		//Returns the singleton DataSource (or creates and returns it if has not been instantiated).
		public static DataSource getInstance()
		{
			//If the DataSource has not been created, then create it once.
			if(instance == null) {
				instance = new DataSource();
			}
			return instance;
		}

		//Prints out the products using their toString
		public void printAllProducts()
		{
			var allProds = getAllProducts();
			foreach (Product prod in allProds.Values) {
				Console.WriteLine(prod);
				Console.WriteLine("\n");
			}
		}
	}
}

