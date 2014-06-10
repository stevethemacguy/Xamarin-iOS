using System;
using System.Collections.Generic;

namespace GFS_iOS
{
	public class SavedProductList
	{
		public static HashSet<string> savedList; //Use a set so duplicates are not added.
		public SavedProductList()
		{
		}

		public static void addToList(string tooAdd)
		{
			savedList.Add(tooAdd);
		}

		public static void removeItem(string toRemove)
		{
			savedList.Remove(toRemove);
		}

		public static HashSet<string> getInstance()
		{
			if (savedList == null)
			{
				savedList = new HashSet<string>();
				//Add the two defaults for now
				addToList("cabinets");
				addToList("others");
			}	
			return savedList;
		}
	}
}

