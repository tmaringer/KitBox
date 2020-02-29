using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS.physic_components
{
    public class AngleBracket : CupboardComponents
    {
        private int _height;
        public int height
        {
            get => _height;
            set => _height = value;
        } 
        
        private double _price;
        public double price
        {
            get => _price;
        }

        public AngleBracket() : this(0,"null", "0000", 0, false, 0)
        {
        }

        public AngleBracket(double price,
                     string reference,
                     string code,
                     int size,
                     bool inStock,
                     double height) : base(reference, code, size, inStock, height)
        {
            this._height = 0;
            this._price = price;
        }
    }
}
