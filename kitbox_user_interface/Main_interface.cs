using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace kitbox_user_interface_V1
{
    static class Main_interface
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            MySqlConnection conn = Connection.GetDBConnection();
            conn.Open();
            
            List<string> WidthBoxList = QueryKitbox.SpecsBoxList(conn, "largeur", "Ref = \"Panneau Ar\"");
            
            foreach (string i in WidthBoxList)
            {
                Console.WriteLine(i);
                

            }
            WidthBoxList.Select(int.Parse).ToList();
            WidthBoxList.Sort();//ne fonctionne pas, essayer autrement
            foreach(string j in WidthBoxList)
            {
                Console.WriteLine(j);


            }

            conn.Close();
            conn.Open();
            List<string> DepthBoxList = QueryKitbox.SpecsBoxList(conn, "profondeur", "Ref = \"Panneau GD\"");
            
            conn.Close();
            conn.Open();
            List<string> HeightBoxList = QueryKitbox.SpecsBoxList(conn, "hauteur", "Ref = \"Panneau GD\"");
            
            conn.Close();
            conn.Open();
            List<string> ColorBoxList = QueryKitbox.SpecsBoxList(conn, "Couleur", "Ref = \"Porte\"");
            
            Console.ReadLine();
            conn.Close();
            conn.Dispose();
            */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
