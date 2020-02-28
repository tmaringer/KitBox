using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS
{
    public class Locker : CupboardComponents
    {
        private int _width;
        public int width
        {
            get => _width;
        }

        private int _depth;
        public int depth
        {
            get => _depth;
        }

        private List<LockerComponents> _componentsList;
        public List<LockerComponents> componentsList
        {
            get => _componentsList;
        }

        public Locker(double price,
                     string reference,
                     string code,
                     int size,
                     bool inStock,
                     double height) : base(price, reference, code, size, inStock, height)
        {
            _width = 0;
            _depth = 0;
            _componentsList = new List<LockerComponents>();
        }

    }
}
