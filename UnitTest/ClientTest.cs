using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectCS;

namespace UnitTest
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void newClientTest()
        {
            Client client = new Client();

            Assert.AreEqual("000000000", client.phoneNumber);
            Assert.AreEqual("name test", client.name);
            Assert.AreEqual("testClient", client.firstName);
        }

        [TestMethod]
        public void attachToOrderTest()
        {
            Client client = new Client();
            OrderForm order = new OrderForm(client);
            OrderForm order2 = new OrderForm();

            Assert.AreEqual(true, client.orderFormIsInList(order));
            Assert.AreEqual(false, client.orderFormIsInList(order2));
            Assert.AreEqual(order, client.orderFormsList.ElementAt(0));
        }
    }
}
