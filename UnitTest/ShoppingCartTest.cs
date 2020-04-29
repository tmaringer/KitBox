using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectCS;

namespace UnitTest
{
    [TestClass]
    public class ShoppingCartTest
    {

        private Cupboard cupboard1;

        private Locker locker1;
        private Locker locker2;

        private CrossBar crossBarWithParam1;
        private CrossBar crossBarWithParam2;

        private Cleat cleatWithParam1;
        private Cleat cleatWithParam2;

        private Door doorWithParam1;

        [TestInitialize()]
        public void testsInitialize()
        {
            cupboard1 = new Cupboard();

            crossBarWithParam1 = new CrossBar(10, "referenceTest", "1", new ComponentSize(0, 0, 0), false, 0, CrossBarType.bottom);
            crossBarWithParam2 = new CrossBar(10, "referenceTest", "1", new ComponentSize(0, 0, 0), false, 0, CrossBarType.bottom);

            cleatWithParam1 = new Cleat(50, "referenceTest", "1", new ComponentSize(0, 0, 0), false, 0);
            cleatWithParam2 = new Cleat(50, "referenceTest", "1", new ComponentSize(0, 0, 0), false, 0);

            doorWithParam1 = new Door(40, "referenceTest", "1", new ComponentSize(0, 0, 0), false, 0, ComponentColor.white);
        }

        [TestMethod]
        public void buildLockerTest()
        {
            ShoppingCart.addCatalogueComponent(crossBarWithParam1);
            ShoppingCart.addCatalogueComponent(crossBarWithParam2);
            ShoppingCart.addCatalogueComponent(cleatWithParam1);
            ShoppingCart.addCatalogueComponent(cleatWithParam2);
            ShoppingCart.addCatalogueComponent(doorWithParam1);

            locker1 = ShoppingCart.buildLocker();

            Assert.AreEqual(160, locker1.price);
            Assert.AreEqual(5, locker1.componentsList.Count);

            locker1.removeComponent(crossBarWithParam1);

            Assert.AreEqual(150, locker1.price);
            Assert.AreEqual(4, locker1.componentsList.Count);
        }

        // test if when you add catalogue components in excess, the building of locker remove correctly the components added to the locker from catalogue components list
        [TestMethod]
        public void buildLockerWithExcessComponentTest()
        {
            ShoppingCart.addCatalogueComponent(crossBarWithParam1);
            ShoppingCart.addCatalogueComponent(crossBarWithParam2);
            ShoppingCart.addCatalogueComponent(cleatWithParam1);
            ShoppingCart.addCatalogueComponent(cleatWithParam2);
            ShoppingCart.addCatalogueComponent(doorWithParam1);

            locker1 = ShoppingCart.buildLocker();

            Assert.AreEqual(160, locker1.price);
            Assert.AreEqual(5, locker1.componentsList.Count);
            Assert.AreEqual(0, ShoppingCart.catalogueComponentsList.Count);

            ShoppingCart.addCatalogueComponent(cleatWithParam2);
            ShoppingCart.addCatalogueComponent(cleatWithParam2);
            ShoppingCart.addCatalogueComponent(cleatWithParam2);
            ShoppingCart.addCatalogueComponent(cleatWithParam2);
            ShoppingCart.addCatalogueComponent(cleatWithParam2);
            ShoppingCart.addCatalogueComponent(cleatWithParam2);

            locker1 = ShoppingCart.buildLocker();

            Assert.AreEqual(2, ShoppingCart.catalogueComponentsList.Count);
        }

        [TestMethod]
        public void buildCupboardTest()
        {
            ShoppingCart.addCatalogueComponent(crossBarWithParam1);
            ShoppingCart.addCatalogueComponent(crossBarWithParam2);
            ShoppingCart.addCatalogueComponent(cleatWithParam1);
            ShoppingCart.addCatalogueComponent(cleatWithParam2);
            ShoppingCart.addCatalogueComponent(doorWithParam1);

            // price of locker1 is 160
            locker1 = ShoppingCart.buildLocker();

            ShoppingCart.addCatalogueComponent(crossBarWithParam2);
            ShoppingCart.addCatalogueComponent(cleatWithParam1);
            ShoppingCart.addCatalogueComponent(cleatWithParam2);

            // price of locker2 110
            locker2 = ShoppingCart.buildLocker();

            ShoppingCart.addCupboardComponent(locker1);
            ShoppingCart.addCupboardComponent(locker2);

            ShoppingCart.buildCupboard();
            cupboard1 = ShoppingCart.cupboard;

            Assert.AreEqual(270, cupboard1.getPrice());
        }
    }
}
