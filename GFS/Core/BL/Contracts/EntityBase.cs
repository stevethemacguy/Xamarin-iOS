using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swx.B2B.Ecom.DL.SQLite;

namespace Swx.B2B.Ecom.BL.Contracts
{
    public abstract class EntityBase : IEntity
    {
        public EntityBase ()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
