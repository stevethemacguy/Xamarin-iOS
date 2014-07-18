using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swx.B2B.Ecom.BL.Contracts;
using Swx.B2B.Ecom.DL.SQLite;

namespace Swx.B2B.Ecom.BL.Entities
{
    public class ProductBernice : IEntity
    {
        public ProductBernice()
        {
            
        }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Prices { get; set; }
        public double StarRating { get; set; }
        //public List<Price> Prices { get; set; }
        //public List<Image> Images { get; set; }
        public string Images { get; set; }
        public string Code { get; set; }

    }
}
