using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;


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
            float price = 0;
            // 0 = code, 1 = in stock, 2 = price
            List<string> infos = DbUtils.BigMoney(conn, typeObj, height.ToString(), depth.ToString(), width.ToString(), ColorParse.parseToStr(ComponentColor.black));
            //component.code = infos[0];
            ComponentSize size = new ComponentSize(height, width, depth);

            switch (typeObj)
            {
                case "CrossBar":
                    return new CrossBar(Single.Parse(infos[2]), typeof(CrossBar).ToString().Split('.')[1], infos[0], size, Int32.Parse(infos[1]) > 0, 0, CrossBarType.B);
                case "Door":
                    return new Door(Single.Parse(infos[2]), typeof(Door).ToString().Split('.')[1], infos[0], size, Int32.Parse(infos[1]) > 0, 0, ComponentColor.black);
                case "Panels":
                    return new Panels(Single.Parse(infos[2]), typeof(Panels).ToString().Split('.')[1], infos[0], size, Int32.Parse(infos[1]) > 0, 0, ComponentColor.black, PanelsType.B);
                case "Cleat":
                    return new Cleat(Single.Parse(infos[2]), typeof(Cleat).ToString().Split('.')[1], infos[0], size, Int32.Parse(infos[1]) > 0, 0);
                default:
                    break;
            }
            return new Door();
        }

    }
}
