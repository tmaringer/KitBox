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

            crossBarWithParam1 = new CrossBar(10, "referenceTest", "1", new ComponentSize(0, 0, 0), false, CrossBarType.LR);
            crossBarWithParam2 = new CrossBar(10, "referenceTest", "1", new ComponentSize(0, 0, 0), false, CrossBarType.LR);

            cleatWithParam1 = new Cleat(50, "referenceTest", "1", new ComponentSize(0, 0, 0), false);
            cleatWithParam2 = new Cleat(50, "referenceTest", "1", new ComponentSize(0, 0, 0), false);

            doorWithParam1 = new Door(40, "referenceTest", "1", new ComponentSize(0, 0, 0), false, ComponentColor.white);

            locker1.addComponent(new List<CatalogueComponents>() { crossBarWithParam1, cleatWithParam2 });
            locker2.addComponent(new List<CatalogueComponents>() { crossBarWithParam1 });
            locker3.addComponent(new List<CatalogueComponents>() { cleatWithParam1, cleatWithParam2 });
            locker4.addComponent(new List<CatalogueComponents>() { doorWithParam1, cleatWithParam2 });
        }
        
        [TestMethod]
        public void getgetLockerByIDTest()
        {           
            ShoppingCart.addCupboardComponent( locker1);
            ShoppingCart.addCupboardComponent( locker2);
            ShoppingCart.addCupboardComponent( locker3);
            ShoppingCart.getLockerByID(3).doorsColor = ComponentColor.glass;
            ShoppingCart.addCupboardComponent( locker4);

            Assert.AreEqual(3, ShoppingCart.getLockerByID(3).ID);


            ShoppingCart.getLockerByID(3).doorsColor = ComponentColor.galvanised;

            Assert.AreEqual(0, ShoppingCart.getLockerByID(40).price);
        }
    }
}
