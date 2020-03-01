namespace projectCS
{
    /// <summary>
    ///     regroup all color available in catalog
    /// </summary>
    public enum Color
    {
        white,
        brawn,
        galvanized,
        black,
        transparent
    }
    // TODO : différent param à spécifier
    public enum Orientation
    {
        height,
        size        
    }

    public class CrossBar : LockerComponents
    {
        public CrossBar() : this(0, "null", "0000", 0, false, 0, Orientation.height)
        {
        }
        public CrossBar(double price,
                        string reference,
                        string code,
                        int size,
                        bool inStock,
                        int lenght,
                        Orientation orientation) : base(price, reference, code, size, inStock, lenght, orientation)
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

        public Pannel() : this(0, "null", "0000", 0, false, 0, Orientation.size, Color.white)
        {
        }
        public Pannel(double price,
                      string reference,
                      string code,
                      int size,
                      bool inStock,
                      int lenght,
                      Orientation orientation,
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

        public Door() : this(0, "null", "0000", 0, false, 0, Orientation.size, Color.white)
        {
        }
        public Door(double price,
                      string reference,
                      string code,
                      int size,
                      bool inStock,
                      int lenght,
                      Orientation orientation,
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
        public Cleat() : this(0, "null", "0000", 0, false, 0, Orientation.height)
        {
        }
        public Cleat(double price,
                      string reference,
                      string code,
                      int size,
                      bool inStock,
                      int lenght,
                      Orientation orientation) : base(price, reference, code, size, inStock, lenght, orientation)
        {
        }
    }
}
