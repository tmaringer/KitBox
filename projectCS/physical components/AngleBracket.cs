using projectCS.Tools_class;

namespace projectCS
{
    public class AngleBracket : CatalogueComponents, ICupboardComponents
    {
        public override ComponentColor color
        {
            set
            {
                if (value == ComponentColor.transparent)
                {
                    ErrorWindow window = new ErrorWindow(ErrorMessages.invalidColorMsg, ErrorMessages.invalidColorTitle);
                    window.displayWindow();
                }
                else
                    base.color = value;
            }
        }

        public override ComponentSize size 
        { 
            get => base._size;
            set            
            { 
                base._size = value;
            }
        }

        public int height
        {
            get => _size.height;
        }

        private double _price;
        public double price
        {
            get => _price;
            set => _price = value;
        }

        public AngleBracket() : this(0, "null", "0000", new ComponentSize(0, 0, 0), false, 0, ComponentColor.white)
        {
        }
        public AngleBracket(double price,
                        string reference,
                        string code,
                        ComponentSize size,
                        bool inStock,
                        int dimension,
                        ComponentColor color) : base(price, reference, code, size, inStock, dimension, color)
        {
            this._price = price;
        }

        /// <summary>
        ///     resize the angle bracket
        /// </summary>
        /// <param name="size">
        ///     size to cut of the height from angle bracket
        /// </param>
        public void cutHeight(int size)
        {
            _size.height -= size;
        }

        public override string ToString()
        {
            return base.ToString() + ", height : " + height;
        }
    }
}
