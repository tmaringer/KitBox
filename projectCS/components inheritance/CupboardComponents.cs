namespace projectCS
{
    public abstract class CupboardComponents : Components
    {
        protected double _height;
        public double height
        {
            get => _height;
        }

        protected CupboardComponents(string reference,
                                     string code,
                                     int size,
                                     bool inStock,
                                     double height) : base(reference, code, size, inStock)
        {
            this._height = height;
        }

        public override string ToString()
        {
            return base.ToString() + ", " + _height;
        }
    }
}
