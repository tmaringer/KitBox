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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Sandbox.SandBox();
            //Sandbox.Height("4", 46);
            //Sandbox.SandBox();
        }
    }
}
