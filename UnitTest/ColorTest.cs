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
            Panels pannel1 = new Panels(0, "reftrest", "testcode", new ComponentSize(0, 0, 0), false, 0, ComponentColor.transparent);
            Panels pannel2 = new Panels();

            Assert.AreEqual(ComponentColor.transparent, pannel1.color);
            Assert.AreEqual(ComponentColor.black, pannel2.color);

            Assert.AreEqual(4, (int)pannel1.color);
            Assert.AreEqual(3, (int)pannel2.color);

            Assert.AreEqual("brown", "" + (ComponentColor)1);
            Assert.AreEqual("black", "" + (ComponentColor)3);
        }
    }
}
