using System;
using System.Collections.Generic;

namespace GFS_iOS
{
	//DataSource follows the singleton pattern
	public class DataSource
	{
		public bool showRow1 = false; //Controls whether the first PDF Manual Row is hidden
		public bool showRow2 = false; //Controls whether the second PDF Manual Row is hidden
		private HashSet<string> savedListSet; //Each string in the savedList Set is a name of one saved list. (savedLists is a Set, so no duplicates allowed).
		private List<string> allNotes; //Each String is the full text of a note.
		private static DataSource instance; //There can only be one instance of the DataSource.
		private List<Product> productList;
		//Can't be instantiated except by the getInstance method
		protected DataSource()
		{
			//Create the savedList and add the two default lists in the list
			if (savedListSet == null)
			{
				savedListSet = new HashSet<string>();
				//Add the two defaults for now
				addSavedList("cabinets");
				addSavedList("others");
				allNotes = new List<string>();
				addNote("Found these products last week. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras mattis consectetur purus sit amet fermentum. ");
				addNote("Another good find");
			}

			//Create the productList and add the two default products to the list
			if (productList == null)
			{
				productList = new List<Product>();
				productList.Add(new Product("product1.png", "Awesome Fun", "Even More Fun", "1.5 and stuff", "Very readable", "$5,000"));
				productList.Add(new Product("product2.png","Some other prod","YES","ok","readable","$1,000"));
			}
		}

		public List<Product> getProductList() {
			return productList;
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

