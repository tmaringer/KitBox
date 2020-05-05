using MySql.Data.MySqlClient;
using System.Collections.Generic;
using kitbox_user_interface_V1;

namespace projectCS.Tools_class
{
    public class CatalogueDB
    {
        private static string MyConString = "SERVER=db4free.net;" + "DATABASE=kitbox_kewlax;" + "UID=kewlaw;" + "PASSWORD=locomac6; old guids = true";
        private MySqlConnection conn;

        public CatalogueDB()
        {
            conn = new MySqlConnection(MyConString);
            conn.Open();
        }

        public CatalogueComponents createComponents(int height, int width, int depth, string typeObj)
        {
            float pricewidth;
            List<string> infos = QueryKitbox.BigMoney(conn, typeObj, height, depth, width, ComponentColor.black);

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
