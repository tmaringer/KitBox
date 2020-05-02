using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectCS;

namespace UnitTest
{
    [TestClass]
    public class ShoppingCartTest
    {
        private Cupboard cupboard1;

        private Locker locker0;
        private Locker locker1;
        private Locker locker2;
        private Locker locker3;
        private Locker locker4;

        private CrossBar crossBarWithParam1;
        private CrossBar crossBarWithParam2;

        private Cleat cleatWithParam1;
        private Cleat cleatWithParam2;

        private Door doorWithParam1;

        PrivateObject privLocker;

        [TestInitialize()]
        public void testsInitialize()
        {
            ShoppingCart.resetShoppingCard();
            locker0 = new Locker();
            privLocker = new PrivateObject(locker0);
            privLocker.Invoke("resetID");

            cupboard1 = new Cupboard();

            locker1 = new Locker();            
            locker2 = new Locker();
            locker3 = new Locker();
            locker4 = new Locker();

            crossBarWithParam1 = new CrossBar(10, "referenceTest", "1", new ComponentSize(0, 0, 0), false, 0, CrossBarType.side);
            crossBarWithParam2 = new CrossBar(10, "referenceTest", "1", new ComponentSize(0, 0, 0), false, 0, CrossBarType.side);

            cleatWithParam1 = new Cleat(50, "referenceTest", "1", new ComponentSize(0, 0, 0), false, 0);
            cleatWithParam2 = new Cleat(50, "referenceTest", "1", new ComponentSize(0, 0, 0), false, 0);

            doorWithParam1 = new Door(40, "referenceTest", "1", new ComponentSize(0, 0, 0), false, 0, ComponentColor.white);

            locker1.addComponent(new List<CatalogueComponents>() { crossBarWithParam1, cleatWithParam2 });
            locker2.addComponent(new List<CatalogueComponents>() { crossBarWithParam1 });
            locker3.addComponent(new List<CatalogueComponents>() { cleatWithParam1, cleatWithParam2 });
            locker4.addComponent(new List<CatalogueComponents>() { doorWithParam1, cleatWithParam2 });
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

        [TestMethod]
        public void getgetLockerByIDTest()
        {           
            ShoppingCart.addCupboardComponent( locker1);
            ShoppingCart.addCupboardComponent( locker2);
            ShoppingCart.addCupboardComponent( locker3);
            ShoppingCart.getLockerByID(3).doorsColor = ComponentColor.glass;
            ShoppingCart.addCupboardComponent( locker4);

            Assert.AreEqual(ComponentColor.glass, ShoppingCart.getLockerByID(3).doorsColor); 
            Assert.AreEqual(3, ShoppingCart.getLockerByID(3).ID);


            ShoppingCart.getLockerByID(3).doorsColor = ComponentColor.galvanised;
            Assert.AreEqual(ComponentColor.galvanised, ShoppingCart.getLockerByID(3).doorsColor);

            Assert.AreEqual(0, ShoppingCart.getLockerByID(40).price);
        }
    }
}
