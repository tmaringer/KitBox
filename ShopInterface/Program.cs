using System;
using projectCS;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopInterface
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            foreach(string i in DBUtils.RefList("CupboardId", "cupboards where OrderId = \"5\""))
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
    }
}
