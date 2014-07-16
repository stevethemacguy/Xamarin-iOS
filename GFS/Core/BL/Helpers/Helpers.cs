using System;
using System.Linq;
using Swx.B2B.Ecom.BL.Entities; //Used by sortProductArray
//Various Helper methods used throughout the project.
using System.Collections.Generic;

namespace Swx.B2B.Ecom.BL
{
	public class Helpers
	{
		public Helpers()
		{
		}

		public static String stripQuotes(String s)
		{
			return s.Replace("\"", ""); //remove quotes from the stirng
		}


		public Boolean isNotNull(object toCheck)
		{
			if (toCheck == null)
				return false;
			else
				return true;
		}

		//Given an array of products, brings all highlighted products to the "top" of the array. Returns the sorted array
		//Big-O: In most cases, the algorithm is worse than O(N), but better than O(N)2 (since the loop breaks once an edible swap item is found). 
		//When a Highlighted item is found, it is swapped with the next available index that has a non-highlighted. 
		//To ensure fast sorting speeds that are close to linear, limit the number of highlighted items. For example, allow olny 3 items to be highlighted.
		public static void sortProductArray(List<Product> arrayToSort)
		{
			//Don't attempt to sort the array if it is empty or there is only one item
			if (arrayToSort == null || arrayToSort.Count < 1) 
			{
				return;
			}

			////FOR TESTING ONLY
//			Console.WriteLine("Array at the start:\n");
//			for (int i =0 ; i < arrayToSort.Count; i++)
//			{
//				Console.WriteLine("["+i+"]" +" Highlighted?: " +arrayToSort[i].isHighlighted() + " (" + arrayToSort [i].id + ")");
//			}

			//For every Product in the original array
			for (int index = 0; index < arrayToSort.Count; index++) 
			{
				Product temp = arrayToSort [index]; //get the product at the current index
				//If the current product is highlighted, move it to the top by finding the first (next) "normal" cell in the array and swapping their positions
				if (temp.isHighlighted())
				{
					//Used to store the index of the next row that contains a "normal (non-highlighted) Product
					int nextUnhighlightedItem = 0;

					//Go through the original array until we find the next unhighlighted item (so we can swap it)
					for (int i = 0; i < arrayToSort.Count; i++)
					{
						if (arrayToSort[i].isHighlighted() == false)
						{
							//We found the index of the next "normal" item, so exit the loop
							nextUnhighlightedItem = i; 
							break;
						}
						else
						{
							//No normal product was found
							nextUnhighlightedItem = -1; 
						}
					}

					//Swap the highlighted product with the normal one in the array
					if(nextUnhighlightedItem != -1) //don't try to swap if there are no remaining products to swap with
					{
						Product normalProduct = arrayToSort[nextUnhighlightedItem]; //Save the "normal" Product
						arrayToSort[index] = normalProduct; //Put the normal product where the highlighted product is.
						arrayToSort[nextUnhighlightedItem] = temp;//Put the highlighted product where the normal product used to be.
					}
				}
			}

			////FOR TESTING ONLY
//			Console.WriteLine("****************** The new array after sorting: ******************\n");
//			for (int i =0 ;i < arrayToSort.Count; i++)
//			{
//				Console.WriteLine("["+i+"]" +" Highlighted?: " +arrayToSort[i].isHighlighted() + " (" + arrayToSort [i].id + ")");
//			}
		}
	}
}

