using MySql.Data.MySqlClient;

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


            // 0 = code, 1 = in stock, 2 = price
            conn.Open();
            string price = DbUtils.BigMoney(conn, "CustPrice", typeObj, height.ToString(), depth.ToString(), width.ToString(), "")[0];
            conn.Close();
            conn.Open();
            string code = DbUtils.BigMoney(conn, "Code", typeObj, height.ToString(), depth.ToString(), width.ToString(), "")[0];
            conn.Close();
            conn.Open();
            bool inStock = int.Parse(DbUtils.BigMoney(conn, "Instock", typeObj, height.ToString(), depth.ToString(), width.ToString(), "")[0]) > 0;
            conn.Close();
            ComponentSize size = new ComponentSize(height, width, depth);


            return new Cleat(double.Parse(price), typeof(Cleat).ToString().Split('.')[1], code, size, inStock);
        }

        public CatalogueComponents createComponents(int height, int width, int depth, ComponentColor color, bool ifCup, string typeObj)
        {
            conn = new MySqlConnection(MyConString);
            conn.Open();

            // 0 = code, 1 = in stock, 2 = price
            string price = DbUtils.BigMoney(conn, "CustPrice", typeObj, height.ToString(), depth.ToString(), width.ToString(), EnumParse.parseColorEnumToStr(color))[0];
            conn.Close();
            conn.Open();
            string code = DbUtils.BigMoney(conn, "Code", typeObj, height.ToString(), depth.ToString(), width.ToString(), EnumParse.parseColorEnumToStr(color))[0];
            conn.Close();
            conn.Open();
            bool inStock = int.Parse(DbUtils.BigMoney(conn, "Instock", typeObj, height.ToString(), depth.ToString(), width.ToString(), EnumParse.parseColorEnumToStr(color))[0]) > 0;

            ComponentSize size = new ComponentSize(height, width, depth);
            conn.Close();

            return new Door(double.Parse(price), typeof(Door).ToString().Split('.')[1], code, size, inStock, color, ifCup);
        }

        public CatalogueComponents createComponents(int height, int width, int depth, ComponentColor color, PanelsType panelsType, string typeObj)
        {
            conn = new MySqlConnection(MyConString);
            conn.Open();

            // 0 = code, 1 = in stock, 2 = price
            typeObj = typeObj + " " + EnumParse.parseTypeEnumToStr(panelsType);
            string price = DbUtils.BigMoney(conn, "CustPrice", typeObj, height.ToString(), depth.ToString(), width.ToString(), EnumParse.parseColorEnumToStr(color))[0];
            conn.Close();
            conn.Open();
            string code = DbUtils.BigMoney(conn, "Code", typeObj, height.ToString(), depth.ToString(), width.ToString(), EnumParse.parseColorEnumToStr(color))[0];
            conn.Close();
            conn.Open();
            bool inStock = int.Parse(DbUtils.BigMoney(conn, "Instock", typeObj, height.ToString(), depth.ToString(), width.ToString(), EnumParse.parseColorEnumToStr(color))[0]) > 0;

            ComponentSize size = new ComponentSize(height, width, depth);
            conn.Close();

            return new Panels(double.Parse(price), typeof(Panels).ToString().Split('.')[1], code, size, inStock, color, panelsType);
        }

        public CatalogueComponents createComponents(int height, int width, int depth, CrossBarType crossType, string typeObj)
        {
            conn = new MySqlConnection(MyConString);
            conn.Open();

            // 0 = code, 1 = in stock, 2 = price
            typeObj = typeObj + " " + EnumParse.parseTypeEnumToStr(crossType);
            string price = DbUtils.BigMoney(conn, "CustPrice", typeObj, height.ToString(), depth.ToString(), width.ToString(), "")[0];
            conn.Close();
            conn.Open();
            string code = DbUtils.BigMoney(conn, "Code", typeObj, height.ToString(), depth.ToString(), width.ToString(), "")[0];
            conn.Close();
            conn.Open();
            bool inStock = int.Parse(DbUtils.BigMoney(conn, "Instock", typeObj, height.ToString(), depth.ToString(), width.ToString(), "")[0]) > 0;

            ComponentSize size = new ComponentSize(height, width, depth);
            conn.Close();

            return new CrossBar(double.Parse(price), typeof(CrossBar).ToString().Split('.')[1], code, size, inStock, crossType);
        }


        public double getPrice(int height, int width, int depth, string typeObj)
        {
            string a = typeObj;

            conn = new MySqlConnection(MyConString);
            conn.Open();
            string price = DbUtils.BigMoney(conn, "CustPrice", typeObj, height.ToString(), depth.ToString(), width.ToString(), "")[0];
            conn.Close();

            return double.Parse(price);
        }

        public double getPrice(int height, int width, int depth, string color, string typeObj)
        {
            conn = new MySqlConnection(MyConString);
            conn.Open();
            string price = DbUtils.BigMoney(conn, "CustPrice", typeObj, height.ToString(), depth.ToString(), width.ToString(), color)[0];
            conn.Close();

            return double.Parse(price);
        }

        public double getPrice(int height, int width, int depth, string color, PanelsType panelsType, string typeObj)
        {
            conn = new MySqlConnection(MyConString);
            conn.Open();
            typeObj = typeObj + " " + EnumParse.parseTypeEnumToStr(panelsType);
            string price = DbUtils.BigMoney(conn, "CustPrice", typeObj, height.ToString(), depth.ToString(), width.ToString(), color)[0];
            conn.Close();

            return double.Parse(price);
        }

        public double getPrice(int height, int width, int depth, CrossBarType crossType, string typeObj)
        {
            conn = new MySqlConnection(MyConString);
            conn.Open();
            typeObj = typeObj + " " + EnumParse.parseTypeEnumToStr(crossType);
            string price = DbUtils.BigMoney(conn, "CustPrice", typeObj, height.ToString(), depth.ToString(), width.ToString(), "")[0];
            conn.Close();

            return double.Parse(price);
        }

        public double newPrice(int height, string doorsColor, string panelColor, CatalogueComponents compo)
        {
            string typeObj = compo.GetType().ToString().Split('.')[1];
            string rqHeight = "0";
            string rqColor = "";

            if (typeObj == "Panels")
            {
                typeObj = "Panel" + " " + EnumParse.parseTypeEnumToStr(((Panels)compo).type);
                rqColor = panelColor;
                if (EnumParse.parseTypeEnumToStr(((Panels)compo).type) == "HL")
                    rqHeight = "0";
                else
                    rqHeight = height.ToString();
            }
            else if (typeObj == "Door")
            {
                if (doorsColor == "none")
                    return 0;
                rqColor = doorsColor;
                rqHeight = height.ToString();
            }
            else if (typeObj == "CrossBar")
                typeObj += " " + EnumParse.parseTypeEnumToStr(((CrossBar)compo).type);
            else if (typeObj == "Cleat")
                rqHeight = height.ToString();


            conn = new MySqlConnection(MyConString);
            conn.Open();
            //typeObj = typeObj + " " + EnumParse.parseTypeEnumToStr(panelsType);
            string price = DbUtils.BigMoney(conn, "CustPrice", typeObj, rqHeight, compo.size.depth.ToString(), compo.size.width.ToString(), rqColor)[0];
            conn.Close();

            return double.Parse(price);
        }
    }
}
