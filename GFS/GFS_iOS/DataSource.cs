using System;
using System.Collections.Generic;

namespace GFS_iOS
{
	//DataSource follows the singleton pattern
	public class DataSource
	{
		public bool showRow1 = false; //Controls whether the first PDF Manual Row is shown
		public bool showRow2 = false; //Controls whether the second PDF Manual Row is shown

		private HashSet<string> savedListSet; //Each string in the savedList Set is a name of one saved list. (savedLists is a Set, so no duplicates allowed).
		private List<string> allNotes; //Each String is the full text of a note.
		private static DataSource instance; //There can only be one instance of the DataSource.
		private List<Product> productList;
		public String currentProduct = "";
		private List<String> manualList; //A list of product names for the manuals view
		public String savedManual1 = null;
		public String savedManual2 = null;

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
				addSavedList("cabinets");
				addSavedList("others");
				allNotes = new List<string>();
				addNote("Found these products last week. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras mattis consectetur purus sit amet fermentum. ");
				addNote("Another good find");
				manualList = new List<String>();
			}

			//Create the productList and add the two default products to the list
			if (productList == null)
			{
				productList = new List<Product>();
			}
		}

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

		public void addToManualList(String productName)
		{
			manualList.Add(productName);
		}

		public List<String> getManualList() {
			return manualList;
		}

		public Dictionary<String, List<Product>> getProductMap(){
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
	}
}

