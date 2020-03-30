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
            
            //printPerso.test2();

            ErrorWindow window = new ErrorWindow(ErrorMessages.invalidColorMsg, ErrorMessages.invalidColorTitle);
            //window.displayWindow();

            //printPerso.test1();
            printPerso.autreTest();


            Console.WriteLine("\n");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
        }

        internal static class printPerso
        {
            public static void test2()
            {
                Locker t = new Locker();

                CrossBar t1 = new CrossBar(10, "referenceTest", "1", new ComponentSize(0, 0, 0), false, 0, ComponentColor.white);
                CrossBar t2 = new CrossBar(100, "referenceTest", "2", new ComponentSize(0, 0, 0), false, 0, ComponentColor.white);
                CrossBar t3 = new CrossBar(1000, "referenceTest", "3", new ComponentSize(0, 0, 0), false, 0, ComponentColor.white);
                CrossBar t4 = new CrossBar(1000, "referenceTest", "4", new ComponentSize(0, 0, 0), false, 0, ComponentColor.white);
                CrossBar t5 = new CrossBar(1000, "referenceTest", "5", new ComponentSize(0, 0, 0), false, 0, ComponentColor.white);

                t.addComponent(t1);
                t.addComponent(t2);
                t.addComponent(t3);
                t.addComponent(t4);
                t.addComponent(t5);

                foreach (CatalogueComponents c in t.componentsList)
                {
                    Console.WriteLine(c.code);
                }

                Console.WriteLine("\n");
                t.removeComponent(t2);
                t.removeComponent(t4);

                foreach (CatalogueComponents c in t.componentsList)
                {
                    Console.WriteLine(c.code);
                }
            }

            public static void test1()
            {
                AngleBracket a = new AngleBracket();
                Console.WriteLine(a);

                a.price = 5455554;
                a.inStock = true;
                a.reference = "deserialize";
                a.size = new ComponentSize(16, 15, 14);
                a.code = "trrddrtd";
                a.color = ComponentColor.brown;
                a.dimension = 47777777;
                Console.WriteLine(a);

            }

            public static void autreTest()
            {
                AngleBracket angleBracketWithParam1 = new AngleBracket(1681480, "referenceTest", "1", new ComponentSize(40, 10, 10), false, 0, ComponentColor.brown);
                ComponentsDataSav.resetFile();

                ComponentsDataSav.savData(angleBracketWithParam1);
                Console.WriteLine(ComponentsDataSav.getAngleBracket());

                /*
                AngleBracket angleBracketEmpty1;
                AngleBracket angleBracketWithParam1 = new AngleBracket(10, "referenceTest", "1", new ComponentSize(4, 10, 10), false, 0, ComponentColor.black); ;

                ComponentsDataSav com = new ComponentsDataSav();

                com.savData(angleBracketWithParam1);
                angleBracketEmpty1 = com.getAngleBracket();
                Console.WriteLine(angleBracketWithParam1);
                Console.WriteLine(angleBracketEmpty1);
                */
            }
        }
        
    }
}
