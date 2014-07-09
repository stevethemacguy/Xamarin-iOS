using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swx.B2B.Ecom.BL.Contracts;
using Swx.B2B.Ecom.DL.SQLite;

namespace Swx.B2B.Ecom.BL.Entities
{
    public class Note : IEntity
    {
        public Note()
        {
            
        }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
