using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        protected string _color;
        public string color
        {
            get => _color;
        }

        public Pannel() : this(0, "null", "0000", 0, false, 0, "no orient", "no color")
        {
        }
        public Pannel(double price,
                      string reference,
                      string code,
                      int size,
                      bool inStock,
                      int lenght,
                      string orientation,
                      string color) : base(price, reference, code, size, inStock, lenght, orientation)
        {
        }

        public override string ToString()
        {
            return base.ToString() + ", " + _color;
        }
    }

    public class Door : LockerComponents
    {
        protected string _color;
        public string color
        {
            get => _color;
        }

        public Door() : this(0, "null", "0000", 0, false, 0, "no orient", "no color")
        {
        }
        public Door(double price,
                      string reference,
                      string code,
                      int size,
                      bool inStock,
                      int lenght,
                      string orientation,
                      string color) : base(price, reference, code, size, inStock, lenght, orientation)
        {
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
