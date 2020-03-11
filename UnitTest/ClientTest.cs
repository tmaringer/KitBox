using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectCS;

namespace UnitTest
{
    [TestClass]
    public class ClientTest
    {
        Client client1;

        private OrderForm order1;
        private OrderForm order2;

        [TestInitialize()]
        public void testsInitialize()
        {
            client1 = new Client();

            order1 = new OrderForm(client1);
            order2 = new OrderForm();
        }

        [TestMethod]
        public void newClientTest()
        {
            Assert.AreEqual("000000000", client1.phoneNumber);
            Assert.AreEqual("name test", client1.name);
            Assert.AreEqual("testClient", client1.firstName);
        }

        /// <summary>
        ///     check if adding an orderForm to client work fine
        /// </summary>
        [TestMethod]
        public void attachToOrderTest()
        {
            Assert.AreEqual(true, client1.hasThisOrderForm(order1));
            Assert.AreEqual(false, client1.hasThisOrderForm(order2));
            Assert.AreEqual(order1, client1.orderFormsList.ElementAt(0));
        }
    }
}
