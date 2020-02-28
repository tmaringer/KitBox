using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS
{
    class Program
    {
        static void Main(string[] args)
        {
            //printPerso.test();
            printPerso.test2();
        }
    }

    public static class printPerso
    {
        public static void test()
        {
            CrossBar t = new CrossBar(0, "referenceTest", "codeTest", 0, false, 0, "orientationTest");
            Console.WriteLine(t);
        }

        public static void test2()
        {
            Locker t = new Locker(0, "referenceTest", "codeTest", 0, false, 0);
            Console.WriteLine(t);
        }
    }
}
