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
        private Door door1;
        private CrossBar crossBar1;
        private Panels panel1;

        private CatalogueDB catalogueDB;

        [TestInitialize()]
        public void testsInitialize()
        {
            catalogueDB = new CatalogueDB();
        }

        [TestMethod]
        public void createComponentTest1()
        {
            cleat1 = (Cleat)catalogueDB.createComponents(32, 0, 0, "Cleat");
            Assert.AreEqual(0.2, cleat1.price);
        }

        [TestMethod]
        public void createComponentTest2()
        {
            door1 = (Door)catalogueDB.createComponents(32, 62, 0, ComponentColor.brown, "Door");
            Assert.AreEqual(9.92, door1.price);
        }

        [TestMethod]
        public void createComponentTest3()
        {
            crossBar1 = (CrossBar)catalogueDB.createComponents(0, 32, 0, CrossBarType.B, "Crossbar");
            Assert.AreNotEqual(1, crossBar1.price);
        }

        [TestMethod]
        public void createComponentTest4()
        {
            panel1 = (Panels)catalogueDB.createComponents(32, 100, 0, ComponentColor.brown, PanelsType.B, "Panel");
            Assert.AreEqual(12,8, panel1.price);
        }
    }
}
