using System;
using System.Linq;

namespace GFS_iOS
{
	public class Helpers
	{
		public Helpers()
		{

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

