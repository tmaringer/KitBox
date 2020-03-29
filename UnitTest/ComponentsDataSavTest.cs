using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectCS;
using projectCS.Tools_class;

namespace UnitTest
{
    [TestClass]
    public class ComponentsDataSavTest
    {
        private AngleBracket angleBracketEmpty1;
        private AngleBracket angleBracketWithParam1;

        [TestInitialize()]
        public void testsInitialize()
        {
            angleBracketWithParam1 = new AngleBracket(10, "referenceTest", "1", new ComponentSize(4, 10, 10), false, 0, ComponentColor.black);
        }

        [TestMethod]
        public void getAngleBracketTest()
        {
            ComponentsDataSav.savData(angleBracketWithParam1);
            angleBracketEmpty1 = ComponentsDataSav.getAngleBracket();
            
            Assert.AreEqual(angleBracketWithParam1.code, angleBracketEmpty1.code);
            Assert.AreEqual(angleBracketWithParam1.color, angleBracketEmpty1.color);
            Assert.AreEqual(angleBracketWithParam1.dimension, angleBracketEmpty1.dimension);
            Assert.AreEqual(angleBracketWithParam1.inStock, angleBracketEmpty1.inStock);
            Assert.AreEqual(angleBracketWithParam1.price, angleBracketEmpty1.price);
            Assert.AreEqual(angleBracketWithParam1.reference, angleBracketEmpty1.reference);
            Assert.AreEqual(angleBracketWithParam1.size, angleBracketEmpty1.size);
            Assert.AreEqual(angleBracketWithParam1.height, angleBracketEmpty1.height);
        }
    }
}
