using System;
using System.Linq;

namespace GFS_iOS
{
	public class Helpers
	{
		Random numGenerator;
		public Helpers()
		{

			numGenerator = new Random();
		}

		//Returns a random 12 digit alpha-numeric number
		public String getRandomNumber()
		{
			var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

			var result = new string(
				Enumerable.Repeat(chars, 12)
				.Select(s => s[numGenerator.Next(s.Length)])
				.ToArray());
			return result;
		}
	}
}

