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


            // 0 = code, 1 = in stock, 2 = price
            conn.Open();
            string price = DbUtils.BigMoney(conn, "CustPrice", typeObj, height.ToString(), depth.ToString(), width.ToString(), "")[0];
            conn.Close();
            conn.Open();
            string code = DbUtils.BigMoney(conn, "Code", typeObj, height.ToString(), depth.ToString(), width.ToString(),"")[0];
            conn.Close();
            conn.Open();
            bool inStock = int.Parse(DbUtils.BigMoney(conn, "Instock", typeObj, height.ToString(), depth.ToString(), width.ToString(),"")[0]) > 0;
            conn.Close();
            ComponentSize size = new ComponentSize(height, width, depth);
            

            return new Cleat(double.Parse(price), typeof(Cleat).ToString().Split('.')[1], code, size, inStock);
        }

        public CatalogueComponents createComponents(int height, int width, int depth, ComponentColor color, string typeObj)
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

            return new Door(double.Parse(price), typeof(Door).ToString().Split('.')[1], code, size, inStock, color);
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
    }
}
