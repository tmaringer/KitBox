using System;

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

        protected ComponentSize _size;
        public ComponentSize size
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


        protected CatalogueComponents(double price,
                                      string reference,
                                      string code,
                                      ComponentSize size,
                                      bool inStock,
                                      int dimension)
        {
            this._price = price;
            this._reference = reference;
            this._code = code;
            this._size = size;
            this._inStock = inStock;
            this._dimension = dimension;
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
                   + _price
                   + ", reference : "
                   + _reference
                   + ", code : "
                   + _code
                   + ", size : {"
                   + " height : " + _size.height
                   + ", width : " + _size.width
                   + ", depth : " + _size.depth
                   + "}"
                   + ", in stock : "
                   + _inStock
                   + ", dimension : "
                   + _dimension;
        }
    }


    public struct ComponentSize
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
            set => _width = value;
        }

        public int depth
        {
            get => _depth;
            set => _depth = value;
        }

        public ComponentSize(int height, int width, int depth)
        {
            _height = height;
            _width = width;
            _depth = depth;
        }
    }
}
