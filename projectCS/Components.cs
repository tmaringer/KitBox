using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS
{
    public abstract class Components
    {
        protected double _price;
        public double price
        {
            get => _price;
        }

        protected string _reference;
        public string reference
        {
            get => _reference;
        }

        protected string _code;
        public string code
        {
            get => _code;
        }

        protected int _size;
        public int size
        {
            get => _size;
        }

        protected bool _inStock;
        public bool inStock
        {
            get => _inStock;
        }

        protected Components(double price, string reference, string code, int size, bool inStock)
        {
            this._price = price;
            this._reference = reference;
            this._code = code;
            this._size = size;
            this._inStock = inStock;
        }

        public override string ToString()
        {
            return base.ToString() + " :" + " " + _price + ", " + _reference + ", " + _code + ", " + _size + ", " + _inStock;
        }
    }

    public abstract class LockerComponents : Components
    {
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
                                   string orientation) : base(price, reference, code, size, inStock)
        {            
            this._lenght = lenght;
            this._orientation = orientation;            
        }

        public override string ToString()
        {
            return base.ToString() + ", " + _lenght + ", " + _orientation;
        }
    }
    
    public abstract class CupboardComponents : Components
    {
        protected double _height;
        public double height
        {
            get => _height;
        }

        protected CupboardComponents(double price,
                                     string reference,
                                     string code,
                                     int size,
                                     bool inStock,
                                     double height) : base(price, reference, code, size, inStock)
        {
            this._height = height;
        }

        public override string ToString()
        {
            return base.ToString() + ", " + _height;
        }
    }
}
