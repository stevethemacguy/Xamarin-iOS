using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Bson;
using Swx.B2B.Ecom.BL.Contracts;
using Swx.B2B.Ecom.DL.SQLite;

namespace Swx.B2B.Ecom.BL.Entities
{
    public class Note : IEntity
    {
        public Note()
        {
        }

        public Note(Note item)
        {
            Id = item.Id;
            Text = item.Text;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
