using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS
{
    public abstract class Components
    {
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

        protected Components(string reference, string code, int size, bool inStock)
        {
            this._reference = reference;
            this._code = code;
            this._size = size;
            this._inStock = inStock;
        }

        public override string ToString()
        {
            return base.ToString() + " :" + ", " + _reference + ", " + _code + ", " + _size + ", " + _inStock;
        }
    }
}
