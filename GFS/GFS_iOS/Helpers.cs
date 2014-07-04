using System;
using System.Linq;

namespace GFS_iOS
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

