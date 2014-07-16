using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swx.B2B.Ecom.BL.Contracts;
using Swx.B2B.Ecom.DL.SQLite;

namespace Swx.B2B.Ecom.BL.Entities
{
    class SearchKeywords : IEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Words { get; set; }
        public string FullWord { get; set; }
    }
}
