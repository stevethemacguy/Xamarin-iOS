using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Swx.B2B.Ecom.BL.Entities;
using Swx.B2B.Ecom;

namespace Swx.B2B.Ecom.DAL
{
    /*
    public class B2BRepository
    {
        private DL.B2BDB db = null;
        protected static string dbLocation;
        protected static B2BRepository me;

        static B2BRepository()
        {
            me = new B2BRepository();
        }
        		
        protected B2BRepository()
		{
			// set the db location
			dbLocation = DatabaseFilePath;
			
			// instantiate the database	
			db = new DL.B2BDB(dbLocation);
		}



        public static string DatabaseFilePath
        {
            get
            {
                var sqliteFilename = "B2BDB.db3";

#if NETFX_CORE
                //TODO: Windows Phone DB PATH
                var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
#else

#if SILVERLIGHT
                //TODO: Windows Silverlight Phone DB PATH
				// Windows Phone expects a local path, not absolute
	            var path = sqliteFilename;
#else

#if __ANDROID__
                //TODO: Android DB PATH
				// Just use whatever directory SpecialFolder.Personal returns
	            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
#else
                // we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
                // (they don't want non-user-generated data in Documents)
                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
                var libraryPath = Path.Combine(documentsPath, "../Library/"); // Library folder
#endif
                var path = Path.Combine(libraryPath, sqliteFilename);
#endif

#endif
                return path;	

            }
        
        }

        public static Product GetProduct(int id)
        {
            return me.db.GetItem<Product>(id);
        }
    }
     * */
}

