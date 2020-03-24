namespace projectCS
{
    /// <summary>
    ///     Super class which group all locker component characteristics as well as angle brackets
    /// </summary>
    public abstract class CatalogueComponents
    {
        protected double _price;
        public double price
        {
            get => _price;
            set => _price = value;
        }

        protected string _reference;
        public string reference
        {
            get => _reference;
            set => _reference = value;
        }

        protected string _code;
        public string code
        {
            get => _code;
            set => _code = value;
        }

        protected Size _size;
        public virtual Size size
        {
            get => _size;
            set => _size = value;
        }

        protected bool _inStock;
        public bool inStock
        {
            get => _inStock;
            set => _inStock = value;
        }

        protected int _dimension;
        public int dimension
        {
            get => _dimension;
            set => _dimension = value;
        }

        protected Color _color;
        public virtual Color color
        {
            get => _color;
            set => _color = value;
        }

        protected CatalogueComponents(double price, string reference, string code, Size size, bool inStock, int dimension, Color color)
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

    public struct Size
    {
        private int _height, _width, _depth;
        public int height
        {
            get => _height;
            set => _height = value;
        }

        public int width
        {
            get => _width;
        }

        public int depth
        {
            get => _depth;
        }

        public Size(int height, int width, int depth)
        {
            _height = height;
            _width = width;
            _depth = depth;
        }
    }

}
