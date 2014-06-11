using System;
using System.Collections.Generic;

namespace GFS_iOS
{
	//DataSource follows the singleton pattern
	public class DataSource
	{
		private HashSet<string> savedListSet; //Each string in the savedList Set is a name of one saved list. (savedLists is a Set, so no duplicates allowed).
		private static DataSource instance; //There can only be one instance of the DataSource.

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
			}	
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

