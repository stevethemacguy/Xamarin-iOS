using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swx.B2B.Ecom.BL.Entities;

namespace Swx.B2B.Ecom.BL.Managers
{
    /// <summary>
    /// Call here from device UI layer to access Notes
    /// </summary>
    class NoteManager
    {
        static NoteManager ()
        {
            
        }

        public static int SaveNote(Note item)
        {
            Swx.B2B.Ecom.DAL.B2BRepository.SaveNote(item);
            return Swx.B2B.Ecom.DAL.B2BRepository.SaveNote(item);
        }
    }
}
