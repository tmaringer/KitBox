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

        public void addOrderForm(OrderForm order)
        {
            _orderFormList.Add(order);
        }
        
        public void removeFromOrderForm(OrderForm oder)
        {
            _orderFormList.Remove(oder);
        }

        public bool orderFormIsInList(OrderForm order)
        {
            return _orderFormList.Contains(order);
        }
    }
}
