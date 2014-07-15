using System;

//A JsonSuggestion represents a single suggested word (a String). 
//Having a whole class for this is overkill, but currently the NewtonJsonReader always instaniates to objects when parsing Json
namespace Swx.B2B.Ecom.BL.Entities
{
	public class JsonSuggestion
	{
		public string value { get; set; }

		public JsonSuggestion()
		{
		}
	}
}

