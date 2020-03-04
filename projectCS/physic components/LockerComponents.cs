namespace projectCS
{
    // TODO : voir si utile
    public struct Orientation
    {
        private int _height;
        private int _depth;
        private int _width;

        public Orientation(int height, int depth, int width)
        {
            this._height = height;
            this._depth = depth;
            this._width = width;
        }

        public int height { get => _height; set { _height = value; } }
        public int depth { get => _depth; set { _depth = value; } }
        public int width { get=>  _depth; set { _width = value; } }
    }

    public class CrossBar : CatalogueComponents
    {
        public CrossBar() : this(0, "null", "0000", 0, false, 0, Color.black)
        {
        }
        public CrossBar(double price,
                        string reference,
                        string code,
                        int size,
                        bool inStock,
                        int dimension,
                        Color color) : base(price, reference, code, size, inStock, dimension, color)
        {
        }

    }

    public class Pannel : CatalogueComponents
    {
        public Pannel() : this(0, "null", "0000", 0, false, 0, Color.black)
        {
        }
        public Pannel(double price,
                        string reference,
                        string code,
                        int size,
                        bool inStock,
                        int dimension,
                        Color color) : base(price, reference, code, size, inStock, dimension, color)
        {
        }
    }

    public class Door : CatalogueComponents
    {
        public Door() : this(0, "null", "0000", 0, false, 0, Color.black)
        {
        }
        public Door(double price,
                        string reference,
                        string code,
                        int size,
                        bool inStock,
                        int dimension,
                        Color color) : base(price, reference, code, size, inStock, dimension, color)
        {
        }
    }

    public class Cleat : CatalogueComponents
    {
        public Cleat() : this(0, "null", "0000", 0, false, 0, Color.black)
        {
        }
        public Cleat(double price,
                        string reference,
                        string code,
                        int size,
                        bool inStock,
                        int dimension,
                        Color color) : base(price, reference, code, size, inStock, dimension, color)
        {
        }
    }
}
