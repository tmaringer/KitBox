using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace projectCS.Tools_class
{
    public class CatalogueDB
    {
        private static string MyConString = "SERVER=db4free.net;" + "DATABASE=kitbox_kewlax;" + "UID=kewlaw;" + "PASSWORD=locomac6; old guids = true";
        private MySqlConnection conn;

        public CatalogueDB()
        {
            
        }

        public CatalogueComponents createComponents(int height, int width, int depth, string typeObj)
        {
            conn = new MySqlConnection(MyConString);
            conn.Open();

            List<string> infos = DbUtils.BigMoney(conn, typeObj, height.ToString(), depth.ToString(), width.ToString(), "");
            string price = infos[0];
            // 0 = code, 1 = in stock, 2 = price
            //component.code = infos[0];
            ComponentSize size = new ComponentSize(height, width, depth);

            switch (typeObj)
            {
                case "CrossBar":
                    return new CrossBar(double.Parse(price), typeof(CrossBar).ToString().Split('.')[1], infos[0], size, Int32.Parse(infos[1]) > 0, 0, CrossBarType.B);
                case "Door":
                    return new Door(double.Parse(price), typeof(Door).ToString().Split('.')[1], infos[0], size, Int32.Parse(infos[1]) > 0, 0, ComponentColor.black);
                case "Panels":
                    return new Panels(double.Parse(price), typeof(Panels).ToString().Split('.')[1], "f", size, 5 > 0, 0, ComponentColor.black, PanelsType.B);
                case "Cleat":
                    return new Cleat(double.Parse(price), typeof(Cleat).ToString().Split('.')[1], "f", size, 5 > 0, 0);
                default:
                    break;
            }
            return new Door();
        }

    }
}
