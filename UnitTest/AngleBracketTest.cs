using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectCS.physic_components;

namespace UnitTest
{
    [TestClass]
    public class AngleBracketTest
    {
        [TestMethod]
        public void newAngleTest()
        {
            AngleBracket a = new AngleBracket();
            AngleBracket az = new AngleBracket(5, "testtest", "codetest", 10, false, 12);

            Assert.AreEqual("0000", a.code);
            Assert.AreEqual(5, az.price);
            Assert.AreEqual(12, az.height);
        }
    }
}
