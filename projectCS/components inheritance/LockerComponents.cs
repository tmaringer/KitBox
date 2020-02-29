namespace projectCS
{
    public abstract class LockerComponents : Components
    {
        protected double _price;
        public virtual double price
        {
            get => _price;
        }

        protected int _lenght;
        public int lenght
        {
            get => _lenght;
        }

        protected string _orientation;
        public string orientation
        {
            get => _orientation;
        }

        protected LockerComponents(double price,
                                   string reference,
                                   string code,
                                   int size,
                                   bool inStock,
                                   int lenght,
                                   string orientation) : base(reference, code, size, inStock)
        {
            this._price = price;
            this._lenght = lenght;
            this._orientation = orientation;
        }

        public override string ToString()
        {
            return base.ToString() + ", " + _price + ", " + _lenght + ", " + _orientation;
        }
    }
}
