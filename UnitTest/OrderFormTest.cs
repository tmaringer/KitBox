using System;
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
        private Client client2;
        private Client clientWithParam1;

        private Cupboard cupboard1;
        private Cupboard cupboard2;

        private AngleBracket angleBracketParam1;
        private AngleBracket angleBracketParam2;
        private AngleBracket angleBracketParam3;
        private AngleBracket angleBracketParam4;
        private AngleBracket angleBracketParam5;

        [TestInitialize()]
        public void testsInitialize()
        {
            client1 = new Client();
            client2 = new Client();
            clientWithParam1 = new Client("testnfirst", "testname", "000000000");

            order1 = new OrderForm();
            order2 = new OrderForm();
            order3 = new OrderForm();
            orderorderWithClient1 = new OrderForm(clientWithParam1);

            cupboard1 = new Cupboard();
            cupboard2 = new Cupboard();

            angleBracketParam1 = new AngleBracket(100, "null", "0000", 0, false, 10, Color.white);
            angleBracketParam2 = new AngleBracket(100, "null", "0000", 0, false, 5, Color.white);
            angleBracketParam3 = new AngleBracket(375, "null", "0000", 0, false, 10, Color.white);
            angleBracketParam4 = new AngleBracket(122.37, "null", "0000", 0, false, 10, Color.white);
            angleBracketParam5 = new AngleBracket(388.96, "null", "0000", 0, false, 10, Color.white);
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
            order2 = new OrderForm(client2);
            order3 = new OrderForm(client2);
            Assert.AreEqual("testClient", order1.client.firstName);
            Assert.AreEqual(client2, order2.client);
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
            cupboard2.addCupboardComponent(angleBracketParam2);

            order1.addCupboard(cupboard1);
            order1.addCupboard(cupboard2);
            
            Assert.AreEqual(10, order1.cupboardDictionnary.ElementAt(0).Key.getAngleBracket().height);
            Assert.AreEqual(5, order1.cupboardDictionnary.ElementAt(1).Key.getAngleBracket().height);

            order1.removeCupboard(cupboard2);

            Assert.AreEqual(10, order1.cupboardDictionnary.ElementAt(0).Key.getAngleBracket().height);
        }

        /// <summary>
        ///     check if the selection of cupboards number work fine
        /// </summary>
        [TestMethod]
        public void getPriceTest()
        {
            // the cupboard1 price is 697.37
            cupboard1.addCupboardComponent(angleBracketParam1);
            cupboard1.addCupboardComponent(angleBracketParam2);
            cupboard1.addCupboardComponent(angleBracketParam3);
            cupboard1.addCupboardComponent(angleBracketParam4);

            // the cupboard1 price is 886.33
            cupboard2.addCupboardComponent(angleBracketParam3);
            cupboard2.addCupboardComponent(angleBracketParam4);
            cupboard2.addCupboardComponent(angleBracketParam5);
            
            order2.addCupboard(cupboard2);
            order2.addCupboard(cupboard2, 5);
            Assert.AreEqual(4431.65, order2.getPrice());

            order1.addCupboard(cupboard1);
            order1.addCupboard(cupboard2);
            order1.addCupboard(cupboard1,5);
            Assert.AreEqual(4373.18, order1.getPrice());
        }

        [TestMethod]
        public void selectNumberOfCupboardTest()
        {
            order1.addCupboard(cupboard1);
            order1.addCupboard(cupboard2);
            
            Assert.AreEqual(1, order1.cupboardDictionnary[cupboard1]);

            order1.addCupboard(cupboard1,5);

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
