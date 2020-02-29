using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace DbLibrary
{
    class Program
    {
        static void Main()
        {
            MySqlConnection conn = Connection.GetDBConnection();
            conn.Open();
            Console.WriteLine("largeur: ");
            List<string> WidthBoxList = QueryKitbox.SpecsBoxList(conn, "largeur", "Ref = \"Panneau Ar\"");
            foreach (string i in WidthBoxList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("profondeur: ");
            List<string> DepthBoxList = QueryKitbox.SpecsBoxList(conn, "profondeur", "Ref = \"Panneau GD\"");
            foreach (string i in DepthBoxList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("hauteur: ");
            List<string> HeightBoxList = QueryKitbox.SpecsBoxList(conn, "hauteur", "Ref = \"Panneau GD\"");
            foreach (string i in HeightBoxList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("la couleur des portes: ");
            List<string> ColorBoxList = QueryKitbox.SpecsBoxList(conn, "Couleur", "Ref = \"Porte\"");
            foreach (string i in ColorBoxList)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
            conn.Close();
            conn.Dispose();
        }
    }
}
