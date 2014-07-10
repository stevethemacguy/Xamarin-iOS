using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swx.B2B.Ecom.BL.Contracts;

namespace Swx.B2B.Ecom.BL.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        //TODO: other properties

        public string Prices { get; set; }
        //public List<Price> Prices { get; set; }
        public List<Image> Images { get; set; }
        //public List<Manual> Manuals { get; set; }
    }
}
