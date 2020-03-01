using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectCS;
using projectCS.physic_components;

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
            
            Assert.AreEqual(0, order.OrderID);

            order = new OrderForm();
            Assert.AreEqual(1, order.OrderID);

            OrderForm order2 = new OrderForm();
            Assert.AreEqual(2, order2.OrderID);
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

        /// <summary>
        ///     check if the selection of cupboards number work fine
        /// </summary>
        [TestMethod]
        public void selectNumberOfCupboardTest()
        {
            OrderForm order = new OrderForm();
            Cupboard cup = new Cupboard();
            Cupboard cup2 = new Cupboard();

            order.addCupboard(cup);
            order.addCupboard(cup2);
            
            Assert.AreEqual(1, order.cupboardDictionnary[cup]);

            order.choiceNumberOfCupboard(cup,5);

            Assert.AreEqual(5, order.cupboardDictionnary[cup]);
            Assert.AreNotEqual(5, order.cupboardDictionnary[cup2]);
            Assert.AreEqual(1, order.cupboardDictionnary[cup2]);

            order.choiceNumberOfCupboard(cup, 3);

            Assert.AreEqual(3, order.cupboardDictionnary[cup]);
            Assert.AreNotEqual(3, order.cupboardDictionnary[cup2]);
            Assert.AreEqual(1, order.cupboardDictionnary[cup2]);
            
            order.choiceNumberOfCupboard(cup2, 10);

            Assert.AreEqual(3, order.cupboardDictionnary[cup]);
            Assert.AreNotEqual(3, order.cupboardDictionnary[cup2]);
            Assert.AreEqual(10, order.cupboardDictionnary[cup2]);
        }

    }
}
