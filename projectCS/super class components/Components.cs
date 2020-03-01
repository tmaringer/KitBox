namespace projectCS
{
    public abstract class Components
    {
        public virtual double price { get; }

        protected string _reference;
        public string reference
        {
            get => _reference;
        }

        protected string _code;
        public string code
        {
            get => _code;
        }

        protected int _size;
        public int size
        {
            get => _size;
        }

        protected bool _inStock;
        public bool inStock
        {
            get => _inStock;
        }

        protected Components(string reference, string code, int size, bool inStock)
        {
            this._reference = reference;
            this._code = code;
            this._size = size;
            this._inStock = inStock;
        }

        /// <summary>
        ///     get from object super class ToString method in order to display internal data object
        /// </summary>
        /// <returns>
        ///     return all object properties in form of string
        /// </returns>
        public override string ToString()
        {
            return base.ToString() + " : " + price + ", " + _reference + ", " + _code + ", " + _size + ", " + _inStock;
        }
    }
}
