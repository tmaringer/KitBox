using projectCS;
using System.Collections.Generic;

namespace projectCS
{
    public class OrderForm
    {
        /// <summary>
        ///     the first emplacement take the cupboard build by the client, the second take the number of this cupboard
        /// </summary>
        private Dictionary<Cupboard, int> _cupboardDictionnary;
        public Dictionary<Cupboard, int> cupboardDictionnary
        {
            get => _cupboardDictionnary;
        }

        private Client _client; 
        public Client client
        {
            get => _client;
        }

        private static int _id = 0;
        public int id
        {
            get => _id;
        }
        
        public OrderForm() : this(new Client())
        {
        }
        
        public OrderForm(Client client)
        {
            this._client = client;
            this._cupboardDictionnary = new Dictionary<Cupboard, int>();
            this._client.addOrderForm(this);
            _id++;
        }

        public void addCupboard(Cupboard cupboard)
        {
            _cupboardDictionnary.Add(cupboard, 1);
        }

        public void addCupboard(Cupboard cupboard, int number)
        {
            _cupboardDictionnary[cupboard] = number;
        }

        public void removeCupboard(Cupboard cupboard)
        {
            _cupboardDictionnary.Remove(cupboard);
        }

        public double getPrice()
        {
            double price = 0;
            foreach(KeyValuePair<Cupboard, int> cupboard in _cupboardDictionnary)
            {
                price += cupboard.Key.getPrice() * cupboard.Value;
            }
            return price;
        }

        /// <summary>
        ///     reset initial id from which it count
        /// </summary>
        private void resetID()
        {
            _id = 0;
        }
    }
}
