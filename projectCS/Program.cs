using projectCS.Tools_class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectCS
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            CatalogueDB catalogueDB = new CatalogueDB();
            Cleat cleat1;
            cleat1 = (Cleat)catalogueDB.createComponents(32, 32, 32, "Cleat");
            */
            double x = ConvertDoubleToPrice.convertToPrice(6.145);
            Console.WriteLine(Math.Round(x,3));
            Console.WriteLine("\n");
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            */
        }        
    }
}
