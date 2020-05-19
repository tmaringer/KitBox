using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectCS;

namespace UnitTest
{
    [TestClass]
    public class DoorTest
    {
        [TestMethod]
        public void priceTest()
        {
            Door door1 = new Door(110, "null", "0000", new ComponentSize(0, 0, 0), false, ComponentColor.black, false);
            Door door2 = new Door(110, "null", "0000", new ComponentSize(0, 0, 0), false, ComponentColor.black, true);

            Assert.AreEqual(110, door1.price);
            Assert.AreEqual(110.01, door2.price);
        }
    }
}
