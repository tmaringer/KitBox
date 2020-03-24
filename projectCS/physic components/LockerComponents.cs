using projectCS.Tools_class;

namespace projectCS
{
    public class CrossBar : CatalogueComponents
    {
        public CrossBar() : this(0, "null", "0000", new ComponentSize(0, 0, 0), false, 0, ComponentColor.black)
        {
        }
        public CrossBar(double price,
                        string reference,
                        string code,
                        ComponentSize size,
                        bool inStock,
                        int dimension,
                        ComponentColor color) : base(price, reference, code, size, inStock, dimension, color)
        {
        }

    }

    public class Pannel : CatalogueComponents
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

        public Pannel() : this(0, "null", "0000", new ComponentSize(0, 0, 0), false, 0, ComponentColor.black)
        {
        }
        public Pannel(double price,
                        string reference,
                        string code,
                        ComponentSize size,
                        bool inStock,
                        int dimension,
                        ComponentColor color) : base(price, reference, code, size, inStock, dimension, color)
        {
        }
    }

    public class Door : CatalogueComponents
    {
        public Door() : this(0, "null", "0000", new ComponentSize(0, 0, 0), false, 0, ComponentColor.black)
        {
        }
        public Door(double price,
                        string reference,
                        string code,
                        ComponentSize size,
                        bool inStock,
                        int dimension,
                        ComponentColor color) : base(price, reference, code, size, inStock, dimension, color)
        {
        }
    }

    public class Cleat : CatalogueComponents
    {
        public Cleat() : this(0, "null", "0000", new ComponentSize(0, 0, 0), false, 0, ComponentColor.black)
        {
        }
        public Cleat(double price,
                        string reference,
                        string code,
                        ComponentSize size,
                        bool inStock,
                        int dimension,
                        ComponentColor color) : base(price, reference, code, size, inStock, dimension, color)
        {
        }
    }
}
