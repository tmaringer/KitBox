using System;
using projectCS;
namespace ShopInterface
{
    class Sandbox
    {
        public static void SandBox()
        {
            foreach (string i in DBUtils.RefList("CupboardId", "cupboards where OrderId = \"5\""))
            {
                foreach (string j in DBUtils.RefList("BoxeId", "boxes where CupboardId = \"" + i + "\""))
                {
                    foreach (string k in DBUtils.RefList("Code", "doors where BoxeId= \"" + j + "\""))
                    {
                        //Modify door property
                        Console.WriteLine("Cupboard " + i + ", Box " + j + ", Door code: " + k);
                    }
                    foreach (string k in DBUtils.RefList("Code", "crossbars where BoxeId= \"" + j + "\""))
                    {
                        //Modify crossbar property
                        Console.WriteLine("Cupboard " + i + ", Box " + j + ", Crossbar code: " + k);
                    }
                    foreach (string k in DBUtils.RefList("Code", "panels where BoxeId= \"" + j + "\""))
                    {
                        //Modify panels property
                        Console.WriteLine("Cupboard " + i + ", Box " + j + ", Panel code: " + k);
                    }
                    foreach (string k in DBUtils.RefList("Code", "cleats where BoxeId= \"" + j + "\""))
                    {
                        //Modify cleats property
                        Console.WriteLine("Cupboard " + i + ", Box " + j + ", Cleat code: " + k);
                    }
                    //Modify box property
                    Console.WriteLine("Box Height:" + DBUtils.RefList("Hauteur", "boxes where CupboardId= \"" + i + "\"")[0]);
                }
                foreach (string j in DBUtils.RefList("Code", "angles where CupboardId= \"" + i + "\""))
                {
                    //modify Angle bracket property
                    Console.WriteLine("Cupboard " + i + ", Angle bracket " + j);
                }
                //Modify Cupboard property
            }
            Console.ReadLine();
        }
        public static void Width(string CupboardId, int width)
        {
            foreach (string i in DBUtils.RefList("BoxeId", "boxes where CupboardId = \"" + CupboardId + "\""))
            {
                if (Convert.ToInt32(DBUtils.RefList("Largeur", "cupboards where CupboardId = \"" + CupboardId + "\"")[0]) > 60)
                {
                    foreach (string j in DBUtils.RefList("DoorId", "doors where BoxeId= \"" + i + "\""))
                    {
                        string new_code;
                        if (width == 62)
                        {
                            string code = DBUtils.RefList("Code", "doors where DoorId = \"" + j + "\"")[0];
                            new_code = code.Substring(0, 5) + "62" + code.Substring(7, 2);
                        }
                        else
                        {
                            string code = DBUtils.RefList("Code", "doors where DoorId = \"" + j + "\"")[0];
                            int new_largeur = (Convert.ToInt32(code) / 2) + 2;
                            new_code = code.Substring(0, 5) + new_largeur.ToString() + code.Substring(7, 2);
                        }
                        DBUtils.UpdateDBV("doors", "Code", "DoorId = \"" + j + "\"", new_code);
                    }
                }
                foreach (string j in DBUtils.RefList("Position", "crossbars where BoxeId= \"" + i + "\""))
                {
                    if (j == "HB" || j == "HF" || j == "LF" || j == "LB")
                    {
                        string code = DBUtils.RefList("Code", "crossbars where BoxeId = \"" + i + "\" and Position = \"" + j + "\"")[0];
                        string new_code = code.Substring(0, 3) + width.ToString();
                        DBUtils.UpdateDBV("crossbars", "Code", "Position = \"" + j + "\" and BoxeId = \"" + i + "\"", new_code);
                    }
                }
                foreach (string j in DBUtils.RefList("Position", "panels where BoxeId= \"" + i + "\""))
                {
                    if (j == "H" || j == "L" || j == "B")
                    {
                        string code = DBUtils.RefList("Code", "panels where BoxeId = \"" + i + "\" and Position = \"" + j + "\"")[0];
                        string new_code = code.Substring(0, 5) + width.ToString() + code.Substring(code.Length - 2, 2);
                        DBUtils.UpdateDBV("panels", "Code", "Position = \"" + j + "\" and BoxeId = \"" + i + "\"", new_code);
                    }
                }
                
            }
        }
        public static void Height(string BoxeId, int height)
        {
            foreach (string i in DBUtils.RefList("Code", "cleats where BoxeId= \"" + BoxeId + "\""))
            {
                string new_code = i.Substring(0, 3) + (height - 5).ToString();
                DBUtils.UpdateDBV("cleats", "Code", "BoxeId = \"" + BoxeId + "\"", new_code);
            }
            foreach (string i in DBUtils.RefList("Position", "panels where BoxeId= \"" + BoxeId + "\""))
            {
                if (i == "B")
                {
                    string code = DBUtils.RefList("Code", "panels where BoxeId = \"" + BoxeId + "\" and Position = \"" + i + "\"")[0];
                    string width = DBUtils.RefList("Largeur", "kitbox where Code = \"" + code + "\"")[0];
                    string new_code = code.Substring(0, 3) + height.ToString() + width + code.Substring(code.Length - 2, 2);
                    DBUtils.UpdateDBV("panels", "Code", "Position = \"" + i + "\" and BoxeId = \"" + BoxeId + "\"", new_code);
                }
                else if (i == "RS" || i == "LS")
                {
                    string code = DBUtils.RefList("Code", "panels where BoxeId = \"" + BoxeId + "\" and Position = \"" + i + "\"")[0];
                    string width = DBUtils.RefList("Profondeur", "kitbox where Code = \"" + code + "\"")[0];
                    string new_code = code.Substring(0, 3) + height.ToString() + width + code.Substring(code.Length - 2, 2);
                    DBUtils.UpdateDBV("panels", "Code", "Position = \"" + i + "\" and BoxeId = \"" + BoxeId + "\"", new_code);
                }
            }
            foreach (string i in DBUtils.RefList("DoorId", "doors where BoxeId= \"" + BoxeId + "\""))
            {
                string code = DBUtils.RefList("Code", "doors where BoxeId = \"" + BoxeId + "\" and DoorId = \"" + i + "\"")[0];
                string new_code = code.Substring(0, 3) + height.ToString() + code.Substring(i.Length - 4, 4);
                DBUtils.UpdateDBV("Doors", "Code", "DoorId = \"" + i + "\"", new_code);
            }
        }
    }
}