using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS
{
    public class CrossBar : LockerComponents
    {
        public CrossBar(double price,
                        string reference,
                        string code,
                        int size,
                        bool inStock,
                        int lenght,
                        string orientation) : base(price, reference, code, size, inStock, lenght, orientation)
        {
            this._price = price;
            this._reference = reference;
            this._code = code;
            this._size = size;
            this._inStock = inStock;
            this._lenght = lenght;
            this._orientation = orientation;
        }
    }

    public class Pannel : LockerComponents
    {
        protected string _color;
        public string color
        {
            get => _color;
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
            this._price = price;
            this._reference = reference;
            this._code = code;
            this._size = size;
            this._inStock = inStock;
            this._lenght = lenght;
            this._orientation = orientation;
            this._color = color;
        }
    }

    public class Door : LockerComponents
    {
        protected string _color;
        public string color
        {
            get => _color;
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
            this._price = price;
            this._reference = reference;
            this._code = code;
            this._size = size;
            this._inStock = inStock;
            this._lenght = lenght;
            this._orientation = orientation;
            this._color = color;
        }
    }

    public class Cleat : LockerComponents
    {

        public Cleat(double price,
                      string reference,
                      string code,
                      int size,
                      bool inStock,
                      int lenght,
                      string orientation) : base(price, reference, code, size, inStock, lenght, orientation)
        {
            this._price = price;
            this._reference = reference;
            this._code = code;
            this._size = size;
            this._inStock = inStock;
            this._lenght = lenght;
            this._orientation = orientation;
        }
    }
}
