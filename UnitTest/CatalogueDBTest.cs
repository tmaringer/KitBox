using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectCS;
using projectCS.Tools_class;

namespace UnitTest
{
    [TestClass]
    public class CatalogueDBTest
    {
        private Cleat cleat1;
        private CatalogueDB catalogueDB;

        [TestInitialize()]
        public void testsInitialize()
        {
            catalogueDB = new CatalogueDB();
        }

        [TestMethod]
        public void createComponentTest()
        {
            cleat1 = (Cleat)catalogueDB.createComponents(32, 32, 32, "Cleat");
            Assert.AreEqual(0.2, cleat1);
        }
    }
}
