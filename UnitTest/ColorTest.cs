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
            Pannel pannel1 = new Pannel(0, "reftrest", "testcode", new Size(0, 0, 0), false, 0, Color.transparent);
            Pannel pannel2 = new Pannel();

            Assert.AreEqual(Color.transparent, pannel1.color);
            Assert.AreEqual(Color.black, pannel2.color);

            Assert.AreEqual(4, (int)pannel1.color);
            Assert.AreEqual(3, (int)pannel2.color);

            Assert.AreEqual("brawn", ""+(Color)1);
            Assert.AreEqual("black", ""+(Color)3);
        }
    }
}
