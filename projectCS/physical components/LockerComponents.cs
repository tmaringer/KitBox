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

        public CrossBar() : this(0, "null", "0000", new ComponentSize(0, 0, 0), false, CrossBarType.LR)
        {
        }
        public CrossBar(double price,
                        string reference,
                        string code,
                        ComponentSize size,
                        bool inStock,
                        CrossBarType type) : base(price, reference, code, size, inStock)
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
                if (value == ComponentColor.glass)
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

        public Panels() : this(0, "null", "0000", new ComponentSize(0, 0, 0), false, ComponentColor.black, PanelsType.LR)
        {
        }
        public Panels(double price,
                        string reference,
                        string code,
                        ComponentSize size,
                        bool inStock,
                        ComponentColor color,
                        PanelsType type) : base(price, reference, code, size, inStock)
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

        private bool _cup;
        public bool cup
        {
            get => _cup;
        }

        public override double price
        {
            get
            {
                double tempPrice = _price;

                if (_cup)
                    tempPrice += 0.005;

                return tempPrice;
            }
        }

        
        public Door() : this(0, "null", "0000", new ComponentSize(0, 0, 0), false, ComponentColor.black)
        {
        }
        public Door(double price,
                        string reference,
                        string code,
                        ComponentSize size,
                        bool inStock,
                        ComponentColor color) : this(price, reference, code, size, inStock, color, false)
        {
        }
        public Door(double price,
                        string reference,
                        string code,
                        ComponentSize size,
                        bool inStock,
                        ComponentColor color,
                        bool cup) : base(price, reference, code, size, inStock)
        {
            this.color = color;
            this._cup = cup;
        }
        
    }

    public class Cleat : CatalogueComponents
    {
        public Cleat() : this(0, "null", "0000", new ComponentSize(0, 0, 0), false)
        {
        }
        public Cleat(double price,
                        string reference,
                        string code,
                        ComponentSize size,
                        bool inStock) : base(price, reference, code, size, inStock)
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
        glass
    }

    public enum PanelsType
    {
        HL,
        B,
        LR
    }

    public enum CrossBarType
    {
        F,
        B,
        LR
    }
}
