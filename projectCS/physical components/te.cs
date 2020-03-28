using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS.physical_components
{
    class te
    {
        public te() 
        {
        }

        private ComponentSize _size;
        public ComponentSize s
        {
            get => _size;
            set => _size = value;
        }

        public override string ToString()
        {
            return base.ToString() 
                    + ", size : {"
                    + " height : " + _size.height
                    + ", width : " + _size.width
                    + ", depth : " + _size.depth
                    + "}";
        }
    }
}
