using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swx.B2B.Ecom.BL.Entities
{

	public class Price
	{
		public string currencyIso { get; set; }
		public string priceType { get; set; }
		public double value { get; set; }
		public string formattedValue { get; set; }

		public Price()
		{

		}

		public override string ToString()
		{
			return string.Format("[Price: currencyIso={0}, priceType={1}, value={2}, formattedValue={3}]", currencyIso, priceType, value, formattedValue);
		}
	}
}
