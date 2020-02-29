namespace projectCS
{
    public abstract class CupboardComponents : Components
    {
        public virtual int height
        {
            get;
            set;
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
