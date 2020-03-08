using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS
{
    public class Client
    {
        private string _firstName;
        public string firstName
        {
            get => _firstName;
        }

        private string _name;
        public string name
        {
            get => _name;
        }

        private string _phoneNumber;
        public string phoneNumber
        {
            get => _phoneNumber;
        }

        private List<OrderForm> _orderFormList;
        public List<OrderForm> orderFormsList
        {
            get => _orderFormList;            
        }

        public Client() : this("testClient", "name test", "000000000")
        {
        }

        public Client(string firstName, string name, string phoneNumber)
        {
            this._orderFormList = new List<OrderForm>();
            this._firstName = firstName;
            this._name = name;
            this._phoneNumber = phoneNumber;
        }

        /// <summary>
        ///     Adds an order form to the client.
        /// </summary>
        /// <param name="order">
        ///     Order form in which the customer will be registered.
        /// </param>
        public void addOrderForm(OrderForm order)
        {
            _orderFormList.Add(order);
        }
        
        /// <summary>
        ///     Removes order form from client.
        /// </summary>
        /// <param name="oder">
        ///     Order from from which the client must be removed.
        /// </param>
        public void removeOrderForm(OrderForm oder)
        {
            _orderFormList.Remove(oder);
        }

        /// <summary>
        ///     CheckS if the client has the order form pass in parameter.
        /// </summary>
        /// <param name="order">
        ///     order form to find.
        /// </param>
        /// <returns>
        ///     Returns true if order form is found, false in other case.
        /// </returns>
        public bool hasThisOrderForm(OrderForm order)
        {
            return _orderFormList.Contains(order);
        }
    }
}
