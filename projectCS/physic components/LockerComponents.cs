
public enum Color
{
    white,
    brawn,
    galvanized,
    black,
    transparent
}

namespace projectCS
{
    public class CrossBar : LockerComponents
    {
        public CrossBar() : this(0, "null", "0000", 0, false, 0, "no orient")
        {
        }
        public CrossBar(double price,
                        string reference,
                        string code,
                        int size,
                        bool inStock,
                        int lenght,
                        string orientation) : base(price, reference, code, size, inStock, lenght, orientation)
        {
        }
    }

    public class Pannel : LockerComponents
    {
        protected Color _color;
        public Color color
        {
            get => _color;
        }

        public Pannel() : this(0, "null", "0000", 0, false, 0, "no orient", Color.white)
        {
        }
        public Pannel(double price,
                      string reference,
                      string code,
                      int size,
                      bool inStock,
                      int lenght,
                      string orientation,
                      Color color) : base(price, reference, code, size, inStock, lenght, orientation)
        {
            this._color = color;
        }

        public override string ToString()
        {
            return base.ToString() + ", " + _color;
        }
    }

    public class Door : LockerComponents
    {
        protected Color _color;
        public Color color
        {
            get => _color;
        }

        public Door() : this(0, "null", "0000", 0, false, 0, "no orient", Color.white)
        {
        }
        public Door(double price,
                      string reference,
                      string code,
                      int size,
                      bool inStock,
                      int lenght,
                      string orientation,
                      Color color) : base(price, reference, code, size, inStock, lenght, orientation)
        {
            this._color = color;
        }

        public override string ToString()
        {
            return base.ToString() + ", " + _color;
        }
    }

    public class Cleat : LockerComponents
    {
        public Cleat() : this(0, "null", "0000", 0, false, 0, "no orient")
        {
        }
        public Cleat(double price,
                      string reference,
                      string code,
                      int size,
                      bool inStock,
                      int lenght,
                      string orientation) : base(price, reference, code, size, inStock, lenght, orientation)
        {
        }
    }
}
