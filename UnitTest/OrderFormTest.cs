using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectCS;

namespace UnitTest
{
    [TestClass]
    public class OrderFormTest
    {
        private OrderForm order1;
        private OrderForm order2;
        private OrderForm order3;
        private OrderForm orderorderWithClient1;

        private Client client1;
        private Client clientWithParam1;

        private Cupboard cupboard1;
        private Cupboard cupboard2;

        private Locker locker1;
        private Locker locker2;

        private AngleBracket angleBracketParam1;

        private CrossBar crossBarWithParam1;
        private CrossBar crossBarWithParam2;

        private Cleat cleatWithParam1;
        private Cleat cleatWithParam2;

        private Door doorWithParam1;
        private Door doorWithParam2;

        private List<CatalogueComponents> catalogueComponentsListWith2WithParam;
        private List<CatalogueComponents> catalogueComponentsListWith6WithParam;

        [TestInitialize()]
        public void testsInitialize()
        {
            client1 = new Client();
            clientWithParam1 = new Client("testnfirst", "testname", "000000000");

            order1 = new OrderForm();
            order2 = new OrderForm();
            order3 = new OrderForm();
            orderorderWithClient1 = new OrderForm(clientWithParam1);

            cupboard1 = new Cupboard();
            cupboard2 = new Cupboard();

            locker1 = new Locker();
            locker2 = new Locker();

            angleBracketParam1 = new AngleBracket(100, "null", "0000", new ComponentSize(0, 0, 0), false, 10, ComponentColor.white);

            crossBarWithParam1 = new CrossBar(100, "referenceTest", "1", new ComponentSize(10, 0, 0), false, 0, ComponentColor.white);
            crossBarWithParam2 = new CrossBar(100, "referenceTest", "1", new ComponentSize(0, 0, 0), false, 0, ComponentColor.white);

            cleatWithParam1 = new Cleat(375, "referenceTest", "1", new ComponentSize(0, 0, 0), false, 0, ComponentColor.white);
            cleatWithParam2 = new Cleat(122.37, "referenceTest", "1", new ComponentSize(0, 0, 0), false, 0, ComponentColor.white);

            doorWithParam1 = new Door(388.96, "referenceTest", "1", new ComponentSize(0, 0, 0), false, 0, ComponentColor.white);
            doorWithParam2 = new Door(38.16, "referenceTest", "1", new ComponentSize(0, 0, 0), false, 0, ComponentColor.white);

            catalogueComponentsListWith2WithParam = new List<CatalogueComponents>() { crossBarWithParam1, crossBarWithParam2 };

            catalogueComponentsListWith6WithParam = new List<CatalogueComponents>() { crossBarWithParam1, crossBarWithParam2,
                                                                         cleatWithParam1, cleatWithParam2,
                                                                         doorWithParam1, doorWithParam2};
        }

        [TestMethod]
        public void newOrderAndIDTest()
        {
            PrivateObject privOrdre = new PrivateObject(order1);

            privOrdre.Invoke("resetID");

            Assert.AreEqual(0, order1.id);

            order1 = new OrderForm();
            Assert.AreEqual(1, order1.id);
            order2 = new OrderForm();
            Assert.AreEqual(2, order2.id);
        }

        /// <summary>
        ///     check if the adding client work fine and if adding a client to an order add also the order to client
        /// </summary>
        [TestMethod]
        public void clientOrderTest()
        {
            order2 = new OrderForm(client1);
            order3 = new OrderForm(client1);
            Assert.AreEqual("testClient", order1.client.firstName);
            Assert.AreEqual(client1, order2.client);
            Assert.AreEqual(clientWithParam1.firstName, orderorderWithClient1.client.firstName);
        }

        [TestMethod]
        public void addCupboardTest()
        {
            Assert.AreEqual(0, order1.cupboardDictionnary.Count);

            order1.addCupboard(cupboard1);

            Assert.AreEqual(1, order1.cupboardDictionnary.Count);
            Assert.AreEqual(cupboard1, order1.cupboardDictionnary.Keys.First());
            Assert.AreEqual(7, order1.cupboardDictionnary.Keys.First().lockerAvailable);

            order1.addCupboard(cupboard2);

            Assert.AreEqual(2, order1.cupboardDictionnary.Count);
            Assert.AreEqual(cupboard1, order1.cupboardDictionnary.Keys.First());
            Assert.AreEqual(7, order1.cupboardDictionnary.Keys.First().lockerAvailable);
        }

        [TestMethod]
        public void removeCupboardTest()
        {
            cupboard1.addCupboardComponent(angleBracketParam1);
            cupboard2.addCupboardComponent(locker1);

            order1.addCupboard(cupboard1);

            Assert.AreEqual(cupboard1, order1.cupboardDictionnary.ElementAt(0).Key);
            order1.addCupboard(cupboard2);
            Assert.AreEqual(cupboard2, order1.cupboardDictionnary.ElementAt(1).Key);
        }

        /// <summary>
        ///     check if the selection of cupboards number work fine
        /// </summary>
        [TestMethod]
        public void getPriceTest()
        {
            // locker1 price is 200
            locker1.addComponent(catalogueComponentsListWith2WithParam);
            // locker2 price is 1124.49
            locker2.addComponent(catalogueComponentsListWith6WithParam);

            // the cupboard1 price is 300
            cupboard1.addCupboardComponent(angleBracketParam1);
            cupboard1.addCupboardComponent(locker1);

            // the cupboard1 price is 1224.49
            cupboard2.addCupboardComponent(locker2);
            cupboard2.addCupboardComponent(angleBracketParam1);

            order2.addCupboard(cupboard2);
            order2.addCupboard(cupboard2, 5);
            Assert.AreEqual(6122.45, order2.getPrice());

            order1.addCupboard(cupboard1);
            order1.addCupboard(cupboard2);
            order1.addCupboard(cupboard1, 5);
            Assert.AreEqual(2724.49, order1.getPrice());
        }

        [TestMethod]
        public void selectNumberOfCupboardTest()
        {
            order1.addCupboard(cupboard1);
            order1.addCupboard(cupboard2);

            Assert.AreEqual(1, order1.cupboardDictionnary[cupboard1]);

            order1.addCupboard(cupboard1, 5);

            Assert.AreEqual(5, order1.cupboardDictionnary[cupboard1]);
            Assert.AreNotEqual(5, order1.cupboardDictionnary[cupboard2]);
            Assert.AreEqual(1, order1.cupboardDictionnary[cupboard2]);

            order1.addCupboard(cupboard1, 3);

            Assert.AreEqual(3, order1.cupboardDictionnary[cupboard1]);
            Assert.AreNotEqual(3, order1.cupboardDictionnary[cupboard2]);
            Assert.AreEqual(1, order1.cupboardDictionnary[cupboard2]);

            order1.addCupboard(cupboard2, 10);

            Assert.AreEqual(3, order1.cupboardDictionnary[cupboard1]);
            Assert.AreNotEqual(3, order1.cupboardDictionnary[cupboard2]);
            Assert.AreEqual(10, order1.cupboardDictionnary[cupboard2]);
        }

    }
}
