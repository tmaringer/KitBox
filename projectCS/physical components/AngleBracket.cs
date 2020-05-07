using projectCS.Tools_class;
using System;

namespace projectCS
{
    public class AngleBracket : CatalogueComponents, ICupboardComponents
    {
        private ComponentColor _color;
        public ComponentColor color
        {
            //toto : demander prof pq si je le rajoute pas, il n'appelle pas dynamiquement
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

        public int height
        {
            get => _size.height;
        }

        public AngleBracket() : this(0, "null", "0000", new ComponentSize(0, 0, 0), false, ComponentColor.white)
        {
        }
        public AngleBracket(double price,
                        string reference,
                        string code,
                        ComponentSize size,
                        bool inStock,
                        ComponentColor color) : base(price, reference, code, size, inStock)
        {
            this.color = color;
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
            return base.ToString() + ", height : " + height + ", color : " + _color;
        }
    }
}
