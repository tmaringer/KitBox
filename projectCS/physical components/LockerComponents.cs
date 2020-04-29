using projectCS.Tools_class;
using System.Configuration;

namespace projectCS
{
    public class CrossBar : CatalogueComponents
    {
        private CrossBarType _type;
        public CrossBarType type
        {
            get => _type;
            set => _type = value;
        }

        public CrossBar() : this(0, "null", "0000", new ComponentSize(0, 0, 0), false, 0, CrossBarType.bottom)
        {
        }
        public CrossBar(double price,
                        string reference,
                        string code,
                        ComponentSize size,
                        bool inStock,
                        int dimension,
                        CrossBarType type) : base(price, reference, code, size, inStock, dimension)
        {
            this._type = type;
        }

    }

    public class Panels : CatalogueComponents
    {
        private ComponentColor _color;
        public ComponentColor color
        {
            get => _color;
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

        private PanelsType _type;
        public PanelsType type
        {
            get => _type;
            set => _type = value;
        }

        public Panels() : this(0, "null", "0000", new ComponentSize(0, 0, 0), false, 0, ComponentColor.black, PanelsType.bottom)
        {
        }
        public Panels(double price,
                        string reference,
                        string code,
                        ComponentSize size,
                        bool inStock,
                        int dimension,
                        ComponentColor color,
                        PanelsType type) : base(price, reference, code, size, inStock, dimension)
        {
            this.color = color;
            this._type = type;
        }
    }

    public class Door : CatalogueComponents
    {
        private ComponentColor _color;
        public ComponentColor color
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

    public enum PanelsType
    {
        bottom,
        top,
        back,
        right,
        left
    }

    public enum CrossBarType
    {
        bottom,
        top,
        right,
        left
    }
}
