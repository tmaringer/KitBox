using projectCS.Tools_class;

namespace projectCS
{
    public class CrossBar : CatalogueComponents
    {
        public CrossBar() : this(0, "null", "0000", new Size(0, 0, 0), false, 0, Color.black)
        {
        }
        public CrossBar(double price,
                        string reference,
                        string code,
                        Size size,
                        bool inStock,
                        int dimension,
                        Color color) : base(price, reference, code, size, inStock, dimension, color)
        {
        }

    }

    public class Pannel : CatalogueComponents
    {
        public override Color color 
        { 
            set
            {
                if (value == Color.transparent)
                {
                    ErrorWindow window = new ErrorWindow(ErrorMessages.invalidColorMsg, ErrorMessages.invalidColorTitle);
                    window.displayWindow();
                }
                else
                    base.color = value;
            }
        }

        public Pannel() : this(0, "null", "0000", new Size(0, 0, 0), false, 0, Color.black)
        {
        }
        public Pannel(double price,
                        string reference,
                        string code,
                        Size size,
                        bool inStock,
                        int dimension,
                        Color color) : base(price, reference, code, size, inStock, dimension, color)
        {
        }
    }

    public class Door : CatalogueComponents
    {
        public Door() : this(0, "null", "0000", new Size(0, 0, 0), false, 0, Color.black)
        {
        }
        public Door(double price,
                        string reference,
                        string code,
                        Size size,
                        bool inStock,
                        int dimension,
                        Color color) : base(price, reference, code, size, inStock, dimension, color)
        {
        }
    }

    public class Cleat : CatalogueComponents
    {
        public Cleat() : this(0, "null", "0000", new Size(0, 0, 0), false, 0, Color.black)
        {
        }
        public Cleat(double price,
                        string reference,
                        string code,
                        Size size,
                        bool inStock,
                        int dimension,
                        Color color) : base(price, reference, code, size, inStock, dimension, color)
        {
        }
    }
}
