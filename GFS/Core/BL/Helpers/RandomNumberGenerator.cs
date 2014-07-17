using System;
using System.Linq;

namespace Swx.B2B.Ecom.BL
{
	public class RandomNumberGenerator
	{
		private static RandomNumberGenerator instance; //There can only be one instance of RandomNumberGenerator.
		private readonly Random numGenerator;

		protected RandomNumberGenerator()
		{
			numGenerator = new Random();
		}

		//Returns the singleton RandomNumberGenerator (or creates and returns it if has not been instantiated).
		public static RandomNumberGenerator getInstance()
		{
			//If the DataSource has not been created, then create it once.
			if(instance == null) {
				instance = new RandomNumberGenerator();
			}
			return instance;
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

