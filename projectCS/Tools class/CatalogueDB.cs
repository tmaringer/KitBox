using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS.Tools_class
{
    public class CatalogueDB
    {
        private static string MyConString = "SERVER=db4free.net;" + "DATABASE=kitbox_kewlax;" + "UID=kewlaw;" + "PASSWORD=locomac6; old guids = true";
        private MySqlConnection conn;

        public CatalogueDB()
        {
            //conn = "quelque chose";
        }

        public CatalogueComponents createComponents(int height, int width, int depth, string typeObj)
        {
            switch (typeObj)
            {
                case "CrossBar":
                    return new CrossBar();
                case "Door":
                    return new Door();
                case "Panels":
                    return new Panels();
                case "Cleat":
                    return new Cleat();
                default:
                    break;
            }
            return new Door();
        }

    }
}
