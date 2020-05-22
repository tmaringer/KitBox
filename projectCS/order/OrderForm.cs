using System.Collections.Generic;

namespace projectCS
{
    /// <summary>
    ///     This class manages the cupboards, it enables to choice the cupboards to be added,
    ///     to be removed and get the price of them.
    /// </summary>
    public class OrderForm
    {
        /// <summary>
        ///     The first emplacement take the cupboard build by the client, the second take the number of this.
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


        /// <summary>
        ///     Takes a client in parameter otherwise create new one with default values.
        /// </summary>
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


        /// <summary>
        ///     Takes a cupboard to add to the order form, the number of cupboards by default is 1.
        /// </summary>
        /// <param name="cupboard">
        ///     Cupboard to be added to order form.
        /// </param>
        public void addCupboard(Cupboard cupboard)
        {
            _cupboardDictionnary.Add(cupboard, 1);
        }

        /// <summary>
        ///     Takes a cupboard to add to the order form as well as the number of cupboards.
        /// </summary>
        /// <param name="cupboard">
        ///     Cupboard to be added to order form.
        /// </param>
        /// <param name="number">
        ///     Number of cupboards to be added.
        /// </param>
        public void addCupboard(Cupboard cupboard, int number)
        {
            _cupboardDictionnary[cupboard] = number;
        }

        /// <summary>
        ///     Removes a cupboard from order form.
        /// </summary>
        /// <param name="cupboard">
        ///     Cupboard to be removed.
        /// </param>
        public void removeCupboard(Cupboard cupboard)
        {
            _cupboardDictionnary.Remove(cupboard);
        }

        /// <summary>
        ///     Returns the price of all elements from order form.
        /// </summary>
        /// <returns>
        ///     Price of all composants.
        /// </returns>
        public double getPrice()
        {
            double price = 0;
            foreach (KeyValuePair<Cupboard, int> cupboard in _cupboardDictionnary)
            {
                price += cupboard.Key.price * cupboard.Value;
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
