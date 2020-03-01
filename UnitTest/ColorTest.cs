using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectCS;

namespace UnitTest
{
    [TestClass]
    public class ColorTest
    {
        [TestMethod]
        public void colorTest()
        {
            Pannel p = new Pannel(0, "reftrest", "testcode", 0, false, 0, "noorient", Color.transparent);
            Pannel p2 = new Pannel();

            Assert.AreEqual(Color.transparent, p.color);
            Assert.AreEqual(Color.white, p2.color);

            Assert.AreEqual(4, (int)p.color);
            Assert.AreEqual(0, (int)p2.color);

            Assert.AreEqual("brawn", ""+(Color)1);
            Assert.AreEqual("black", ""+(Color)3);
        }
    }
}
