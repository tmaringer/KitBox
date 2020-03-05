using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectCS;

namespace UnitTest
{
    [TestClass]
    public class AngleBracketTest
    {
        [TestMethod]
        public void newAngleTest()
        {
            AngleBracket a = new AngleBracket();
            AngleBracket az = new AngleBracket(5, "testtest", "codetest", 10, false, 12, Color.white);

            Assert.AreEqual("0000", a.code);
            Assert.AreEqual(5, az.price);
            Assert.AreEqual(12, az.height);
        }
        
        [TestMethod]
        public void cutHeightTest()
        {
            AngleBracket a = new AngleBracket(5, "testtest", "codetest", 10, false, 12, Color.white);

            a.cutHeight(6);

            Assert.AreEqual(6, a.height);
        }
    }
}
