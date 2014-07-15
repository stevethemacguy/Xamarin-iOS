using System;
using System.Linq;

//Various Helper methods used throughout the project.
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
	}
}

