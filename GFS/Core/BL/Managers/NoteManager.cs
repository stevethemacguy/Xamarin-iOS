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
           // Swx.B2B.Ecom.DAL.B2BRepository.SaveNote(item);
            return Swx.B2B.Ecom.DAL.B2BRepository.SaveNote(item);
        }

        public static List<string> GetNotes()
        {
            //return new List<Note> (Swx.B2B.Ecom.DAL.B2BRepository.GetNotes());
            
            List<Note> temp = new List<Note>(Swx.B2B.Ecom.DAL.B2BRepository.GetNotes());
            List<string> allNotes = new List<string>();
            for (int i = 0; i < temp.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(temp[i].Id);
                allNotes.Add(temp[i].Text);
            }
            return allNotes;
            
        }

        public static Note GetNoteID(string text)
        {
            return Swx.B2B.Ecom.DAL.B2BRepository.GetNoteID(text);
        }
    }
}
