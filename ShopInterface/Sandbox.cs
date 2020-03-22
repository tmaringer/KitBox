using System;
using System.Collections.Generic;
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

        public static void Depth(string CupboardId, int depth)
        {
            foreach (string i in DBUtils.RefList("BoxeId", "boxes where CupboardId = \"" + CupboardId + "\""))
            {
                foreach (string j in DBUtils.RefList("Position", "crossbars where BoxeId= \"" + i + "\""))
                {
                    if (j == "LL" || j == "HL" || j == "LR" || j == "HR")
                    {
                        string code = DBUtils.RefList("Code", "crossbars where BoxeId = \"" + i + "\" and Position = \"" + j + "\"")[0];
                        string new_code = code.Substring(0, 3) + depth.ToString();
                        DBUtils.UpdateDBV("crossbars", "Code", "Position = \"" + j + "\" and BoxeId = \"" + i + "\"", new_code);
                    }
                }
                foreach (string j in DBUtils.RefList("Position", "panels where BoxeId= \"" + i + "\""))
                {
                    if (j == "H" || j == "L")
                    {
                        string code = DBUtils.RefList("Code", "panels where BoxeId = \"" + i + "\" and Position = \"" + j + "\"")[0];
                        string new_code = code.Substring(0, 3) + depth.ToString() + code.Substring(code.Length - 4, 4);
                        DBUtils.UpdateDBV("panels", "Code", "Position = \"" + j + "\" and BoxeId = \"" + i + "\"", new_code);
                    }
                    else if (j == "RS" || j == "LS")
                    {
                        string code = DBUtils.RefList("Code", "panels where BoxeId = \"" + i + "\" and Position = \"" + j + "\"")[0];
                        string new_code = code.Substring(0, 5) + depth.ToString() + code.Substring(code.Length - 2, 2);
                        DBUtils.UpdateDBV("panels", "Code", "Position = \"" + j + "\" and BoxeId = \"" + i + "\"", new_code);
                    }
                }
            }
            DBUtils.UpdateDBV("cupboards", "Profondeur", "CupboardId= \"" + CupboardId + "\"", depth.ToString());
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
            DBUtils.UpdateDBV("cupboards", "Largeur", "CupboardId= \"" + CupboardId + "\"", width.ToString());
        }
        public static void Height(string BoxeId, int height)
        {
            int specialheight = height - 4;
            string cupboardid = DBUtils.RefList("CupboardId", "boxes where BoxeId= \"" + BoxeId + "\"")[0];
            string backupheight = DBUtils.RefList("Hauteur", "boxes where BoxeId= \"" + BoxeId + "\"")[0];
            int heightCupboard = 0;
            DBUtils.UpdateDBV("boxes", "Hauteur", "BoxeId= \"" + BoxeId + "\"", height.ToString());
            foreach (string i in DBUtils.RefList("Hauteur", "boxes where CupboardId = \"" + cupboardid + "\""))
            {
                heightCupboard += Convert.ToInt32(i);
            }
            if (heightCupboard > 375)
            {
                DBUtils.UpdateDBV("boxes", "Hauteur", "BoxeId= \"" + BoxeId + "\"", backupheight);
            }
            else
            {
                foreach (string i in DBUtils.RefList("Code", "cleats where BoxeId= \"" + BoxeId + "\""))
                {
                    string new_code = i.Substring(0, 3) + (specialheight - 5).ToString();
                    DBUtils.UpdateDBV("cleats", "Code", "BoxeId = \"" + BoxeId + "\"", new_code);
                }
                foreach (string i in DBUtils.RefList("Position", "panels where BoxeId= \"" + BoxeId + "\""))
                {
                    if (i == "B")
                    {
                        string code = DBUtils.RefList("Code", "panels where BoxeId = \"" + BoxeId + "\" and Position = \"" + i + "\"")[0];
                        string width = DBUtils.RefList("Largeur", "kitbox where Code = \"" + code + "\"")[0];
                        string new_code = code.Substring(0, 3) + specialheight.ToString() + width + code.Substring(code.Length - 2, 2);
                        DBUtils.UpdateDBV("panels", "Code", "Position = \"" + i + "\" and BoxeId = \"" + BoxeId + "\"", new_code);
                    }
                    else if (i == "RS" || i == "LS")
                    {
                        string code = DBUtils.RefList("Code", "panels where BoxeId = \"" + BoxeId + "\" and Position = \"" + i + "\"")[0];
                        string width = DBUtils.RefList("Profondeur", "kitbox where Code = \"" + code + "\"")[0];
                        string new_code = code.Substring(0, 3) + specialheight.ToString() + width + code.Substring(code.Length - 2, 2);
                        DBUtils.UpdateDBV("panels", "Code", "Position = \"" + i + "\" and BoxeId = \"" + BoxeId + "\"", new_code);
                    }
                }
                foreach (string i in DBUtils.RefList("DoorId", "doors where BoxeId= \"" + BoxeId + "\""))
                {
                    string code = DBUtils.RefList("Code", "doors where BoxeId = \"" + BoxeId + "\" and DoorId = \"" + i + "\"")[0];
                    string new_code = code.Substring(0, 3) + specialheight.ToString() + code.Substring(code.Length - 4, 4);
                    DBUtils.UpdateDBV("doors", "Code", "DoorId = \"" + i + "\"", new_code);
                }
                if (heightCupboard % 36 == 0 || heightCupboard % 46 == 0 || heightCupboard % 56 == 0)
                {
                    foreach (string i in DBUtils.RefList("AngleId", "angles where CupboardId= \"" + cupboardid + "\""))
                    {
                        string code = DBUtils.RefList("Code", "angles where AngleId = \"" + i + "\"")[0];
                        string new_code;
                        if (code.Length <= 8)
                        {
                            new_code = code.Substring(0, 3) + heightCupboard.ToString() + code.Substring(code.Length - 2, 2);
                        }
                        else
                        {
                            new_code = code.Substring(0, 3) + heightCupboard.ToString() + code.Substring(code.Length - 5, 2);
                        }
                        DBUtils.UpdateDBV("angles", "Code", "AngleId = \"" + i + "\"", new_code);
                    }
                }
                else
                {
                    List<string> All = DBUtils.RefListND("Hauteur", "kitbox where Ref = \"Cornieres\"");
                    List<int> Unstandarded = new List<int>();
                    foreach(string i in All)
                    {
                        int ii = Convert.ToInt32(i);
                        if (ii % 36 != 0 && ii % 46 != 0 && ii % 56 != 0)
                        {
                            Unstandarded.Add(ii);
                        }
                    }
                    int x = 10000;
                    foreach (int value in Unstandarded)
                    {
                        if(value > heightCupboard && value < x)
                        {
                            x = value;
                        }
                    }
                    foreach (string i in DBUtils.RefList("AngleId", "angles where CupboardId= \"" + cupboardid + "\""))
                    {
                        string code = DBUtils.RefList("Code", "angles where AngleId = \"" + i + "\"")[0];
                        string new_code = "";
                        if (code.Length <= 8)
                        {
                            new_code = code.Substring(0, 3) + x.ToString() + code.Substring(code.Length - 2, 2) + "DEC";
                        }
                        else
                        {
                            new_code = code.Substring(0, 3) + x.ToString() + code.Substring(code.Length - 5, 5);
                        }
                        DBUtils.UpdateDBV("angles", "Code", "AngleId = \"" + i + "\"", new_code);
                    }
                }
                DBUtils.UpdateDBV("cupboards", "Hauteur", "CupboardId = \"" + cupboardid + "\"", heightCupboard.ToString());
                DBUtils.UpdateDBV("boxes", "Hauteur", "BoxeId= \"" + BoxeId + "\"", height.ToString());
            }
        }
    }
}