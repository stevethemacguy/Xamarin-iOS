using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swx.B2B.Ecom.BL.Contracts;

namespace Swx.B2B.Ecom.BL.Entities
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public string ImageType { get; set; }
        public string Format { get; set; }
        public string AltText { get; set; }
        public string Url { get; set; }

		//Default Constructor is used by NewtonJsonReader to create Images for each JsonProduct as the Json results are deserialized.
		public Image()
		{

		}
    }
}
