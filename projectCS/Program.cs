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
            Locker lockd = new Locker();
            CrossBar des = new CrossBar();

            Console.WriteLine(des is Locker);

            Console.WriteLine("\n");
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            */
        }        
    }
}
