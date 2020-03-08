namespace projectCS
{
    public class AngleBracket : CatalogueComponents, ICupboardComponents
    {
        private int _height;
        public int height
        {
            get => _height;
        }

        private double _price;
        public double price
        {
            get => _price;
        }

        public AngleBracket() : this(0, "null", "0000", 0, false, 0, Color.white)
        {
        }

        public AngleBracket(double price,
                        string reference,
                        string code,
                        int size,
                        bool inStock,
                        int dimension,
                        Color color) : base(price, reference, code, size, inStock, dimension, color)
        {            
            this._price = price;
            this._height = dimension;
        }

        /// <summary>
        ///     resize the angle bracket
        /// </summary>
        /// <param name="size">
        ///     size to cut of the height from angle bracket
        /// </param>
        public void cutHeight(int size)
        {
            _height -= size;
        }
    }
}
