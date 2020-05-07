using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectCS;

namespace UnitTest
{
    [TestClass]
    public class AngleBracketTest
    {
        private AngleBracket angleBracket1;
        private AngleBracket angleBracketParam1;

        [TestInitialize()]
        public void testsInitialize()
        {
            angleBracket1 = new AngleBracket();
            angleBracketParam1 = new AngleBracket(5, "testtest", "codetest", new ComponentSize(12, 0, 0), false, ComponentColor.white);
        }

        [TestMethod]
        public void newAngleTest()
        {
            Assert.AreEqual("0000", angleBracket1.code);
            Assert.AreEqual(5, angleBracketParam1.price);
            Assert.AreEqual(12, angleBracketParam1.height);
        }

        [TestMethod]
        public void cutHeightTest()
        {
            angleBracketParam1.cutHeight(6);

            Assert.AreEqual(6, angleBracketParam1.height);
        }

        [TestMethod]
        public void getPriceTest()
        {
            Assert.AreEqual(5, angleBracketParam1.price);

            angleBracketParam1.price = 86.2;
            Assert.AreEqual(86.2, angleBracketParam1.price);
        }
    }
}
