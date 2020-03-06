using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectCS;

namespace UnitTest
{
    [TestClass]
    public class OrderFormTest
    {
        [TestMethod]
        public void newOrderAndIDTest()
        {
            OrderForm order = new OrderForm();
            PrivateObject privOrdre = new PrivateObject(order);

            privOrdre.Invoke("resetID");
            
            Assert.AreEqual(0, order.id);

            order = new OrderForm();
            Assert.AreEqual(1, order.id);

            OrderForm order2 = new OrderForm();
            Assert.AreEqual(2, order2.id);
        }

        /// <summary>
        ///     check if the adding client work fine and if adding a client to an order add also the order to client
        /// </summary>
        [TestMethod]
        public void clientOrderTest()
        {
            Client cl = new Client("testnfirst", "testname", "000000000");
            Client cl2 = new Client();
            OrderForm order = new OrderForm(cl);
            OrderForm order2 = new OrderForm(cl2);
            OrderForm order3 = new OrderForm();

            Assert.AreEqual("testnfirst", order.client.firstName);
            Assert.AreEqual(cl2, order2.client);
            Assert.AreEqual(new Client().firstName, order3.client.firstName);
        }
        
        [TestMethod]
        public void addCupboardTest()
        {
            Cupboard cup = new Cupboard();
            Cupboard cup2 = new Cupboard();
            OrderForm order = new OrderForm();

            Assert.AreEqual(0, order.cupboardDictionnary.Count);

            order.addCupboard(cup);

            Assert.AreEqual(1, order.cupboardDictionnary.Count);
            Assert.AreEqual(cup, order.cupboardDictionnary.Keys.First());
            Assert.AreEqual(7, order.cupboardDictionnary.Keys.First().lockerAvailable);

            order.addCupboard(cup2);

            Assert.AreEqual(2, order.cupboardDictionnary.Count);
            Assert.AreEqual(cup, order.cupboardDictionnary.Keys.First());
            Assert.AreEqual(7, order.cupboardDictionnary.Keys.First().lockerAvailable);
        }
        
        [TestMethod]
        public void removeCupboardTest()
        {
            OrderForm order = new OrderForm();

            Cupboard cup = new Cupboard();
            Cupboard cup2 = new Cupboard();

            AngleBracket a = new AngleBracket(100, "null", "0000", 0, false, 10, Color.white);
            AngleBracket a2 = new AngleBracket(100, "null", "0000", 0, false, 5, Color.white);

            cup.addCupboardComponent(a);
            cup2.addCupboardComponent(a2);

            order.addCupboard(cup);
            order.addCupboard(cup2);
            
            Assert.AreEqual(10, order.cupboardDictionnary.ElementAt(0).Key.getAngleBracket().height);
            Assert.AreEqual(5, order.cupboardDictionnary.ElementAt(1).Key.getAngleBracket().height);

            order.removeCupboard(cup2);

            Assert.AreEqual(10, order.cupboardDictionnary.ElementAt(0).Key.getAngleBracket().height);
        }

        /// <summary>
        ///     check if the selection of cupboards number work fine
        /// </summary>
        [TestMethod]
        public void getPriceTest()
        {
            OrderForm order = new OrderForm();
            OrderForm order2 = new OrderForm();
            AngleBracket a = new AngleBracket(112.3, "null", "0000", 0, false, 10, Color.white);
            AngleBracket a2 = new AngleBracket(146.69, "null", "0000", 0, false, 10, Color.white);
            AngleBracket a3 = new AngleBracket(375, "null", "0000", 0, false, 10, Color.white);
            Cupboard cup = new Cupboard();
            Cupboard cup2 = new Cupboard();

            cup.addCupboardComponent(a);
            cup.addCupboardComponent(a2);
            cup.addCupboardComponent(a3);
            cup2.addCupboardComponent(a3);

            order.addCupboard(cup);
            order.addCupboard(cup2);
            
            Assert.AreEqual(1008.99, order.getPrice());
            order2.addCupboard(cup2);
            order2.addCupboard(cup2, 5);

            Assert.AreEqual(1875, order2.getPrice());

            order.addCupboard(cup,5);
            Assert.AreEqual(3544.95, order.getPrice());
        }

        [TestMethod]
        public void selectNumberOfCupboardTest()
        {
            OrderForm order = new OrderForm();
            Cupboard cup = new Cupboard();
            Cupboard cup2 = new Cupboard();

            order.addCupboard(cup);
            order.addCupboard(cup2);
            
            Assert.AreEqual(1, order.cupboardDictionnary[cup]);

            order.addCupboard(cup,5);

            Assert.AreEqual(5, order.cupboardDictionnary[cup]);
            Assert.AreNotEqual(5, order.cupboardDictionnary[cup2]);
            Assert.AreEqual(1, order.cupboardDictionnary[cup2]);

            order.addCupboard(cup, 3);

            Assert.AreEqual(3, order.cupboardDictionnary[cup]);
            Assert.AreNotEqual(3, order.cupboardDictionnary[cup2]);
            Assert.AreEqual(1, order.cupboardDictionnary[cup2]);
            
            order.addCupboard(cup2, 10);

            Assert.AreEqual(3, order.cupboardDictionnary[cup]);
            Assert.AreNotEqual(3, order.cupboardDictionnary[cup2]);
            Assert.AreEqual(10, order.cupboardDictionnary[cup2]);
        }

    }
}
