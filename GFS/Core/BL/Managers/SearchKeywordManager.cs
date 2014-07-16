using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swx.B2B.Ecom.BL.Entities;

namespace Swx.B2B.Ecom.BL.Managers
{
    class SearchKeywordManager
    {
        //TODO: fix these and add to the B2BRepository functions
        public int SaveKeyword(SearchKeywords item)
        {
            return Swx.B2B.Ecom.DAL.B2BRepository.SaveKeyword(item);
        }

        public static List<SearchKeywords> GetKeyword()
        {
            return new List<SearchKeywords>(Swx.B2B.Ecom.DAL.B2BRepository.GetKeyword());
        }

        public static SearchKeywords GetProduct(int id)
        {
            return Swx.B2B.Ecom.DAL.B2BRepository.GetKeyword(id);
        }
    }
}
