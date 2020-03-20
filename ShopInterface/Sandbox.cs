using System;
using projectCS;
namespace ShopInterface
{
    class Sandbox
    {
        static void Main()
        {
            foreach (string i in DBUtils.RefList("CupboardId", "cupboards where OrderId = \"3\""))
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}