namespace projectCS
{
    public abstract class CupboardComponents : Components
    {
        public abstract int height
        {
            get;
        }

        protected CupboardComponents(string reference,
                                     string code,
                                     int size,
                                     bool inStock) : base(reference, code, size, inStock)
        {
        }

        public override string ToString()
        {
            return base.ToString() + ", " + height;
        }
    }
}
