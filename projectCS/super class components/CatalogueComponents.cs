namespace projectCS
{
    public abstract class CatalogueComponents
    {
        protected double _price;
        public double price 
        { 
            get => _price; 
        }

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

        protected int _dimension;
        public int dimension
        {
            get => _dimension;
        }

        protected Color _color;
        public Color color
        {
            get => _color;
        }

        protected CatalogueComponents(double price, string reference, string code, int size, bool inStock, int dimension, Color color)
        {            
            this._price = price;
            this._reference = reference;
            this._code = code;
            this._size = size;
            this._inStock = inStock;
            this._dimension = dimension;
            this._color = color;
        }
        
        /// <summary>
        ///     get from object super class ToString method in order to display internal data object
        /// </summary>
        /// <returns>
        ///     return all object properties in form of string
        /// </returns>
        public override string ToString()
        {
            return base.ToString()
                   + " price : "
                   + price
                   + ", reference : "
                   + _reference
                   + ", code : "
                   + _code
                   + ", size : "
                   + _size
                   + ", in stock : "
                   + _inStock
                   + ", dimension : "
                   + _dimension
                   + ", color : "
                   + _color; 
        }
    }

    /// <summary>
    ///     regroup all color available in catalog
    /// </summary>
    public enum Color
    {
        white,
        brawn,
        galvanized,
        black,
        transparent
    }
}
