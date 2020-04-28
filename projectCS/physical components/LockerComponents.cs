using projectCS.Tools_class;
using System.Configuration;

namespace projectCS
{
    public class CrossBar : CatalogueComponents
    {
        public CrossBar() : this(0, "null", "0000", new ComponentSize(0, 0, 0), false, 0)
        {
        }
        public CrossBar(double price,
                        string reference,
                        string code,
                        ComponentSize size,
                        bool inStock,
                        int dimension) : base(price, reference, code, size, inStock, dimension)
        {
        }

    }

    public class Panels : CatalogueComponents
    {
        protected ComponentColor _color;

        public ComponentColor color 
        { 
            set
            {
                if (value == ComponentColor.transparent)
                {
                    ErrorWindow window = new ErrorWindow(ErrorMessages.invalidColorMsg, ErrorMessages.invalidColorTitle);
                    window.displayWindow();
                }
                else
                    _color = value;
            }
        }


        public Panels() : this(0, "null", "0000", new ComponentSize(0, 0, 0), false, 0, ComponentColor.black)
        {
        }
        public Panels(double price,
                        string reference,
                        string code,
                        ComponentSize size,
                        bool inStock,
                        int dimension,
                        ComponentColor color) : base(price, reference, code, size, inStock, dimension)
        {
            this.color = color;
        }
    }

    public class Door : CatalogueComponents
    {
        protected ComponentColor _color;
        public virtual ComponentColor color
        {
            get => _color;
            set => _color = value;
        }


        public Door() : this(0, "null", "0000", new ComponentSize(0, 0, 0), false, 0, ComponentColor.black)
        {
        }
        public Door(double price,
                        string reference,
                        string code,
                        ComponentSize size,
                        bool inStock,
                        int dimension,
                        ComponentColor color) : base(price, reference, code, size, inStock, dimension)
        {
            this.color = color;
        }
    }

    public class Cleat : CatalogueComponents
    {
        public Cleat() : this(0, "null", "0000", new ComponentSize(0, 0, 0), false, 0)
        {
        }
        public Cleat(double price,
                        string reference,
                        string code,
                        ComponentSize size,
                        bool inStock,
                        int dimension) : base(price, reference, code, size, inStock, dimension)
        {
        }
    }

    /// <summary>
    ///     regroup all color available in catalog
    /// </summary>
    public enum ComponentColor
    {
        white,
        brown,
        galvanised,
        black,
        transparent
    }

}
