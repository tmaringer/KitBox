using projectCS.Tools_class;
using System;

namespace projectCS
{
    public class AngleBracket : CatalogueComponents, ICupboardComponents
    {
        public override ComponentColor color
        {
            set
            {
                Console.WriteLine("else couleur");
                if (value == ComponentColor.transparent)
                {
                    ErrorWindow window = new ErrorWindow(ErrorMessages.invalidColorMsg, ErrorMessages.invalidColorTitle);
                    window.displayWindow();
                }
                else
                    base.color = value;
            }
        }

        public int height
        {
            get => _size.height;
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
            Console.WriteLine("angle construct");
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
