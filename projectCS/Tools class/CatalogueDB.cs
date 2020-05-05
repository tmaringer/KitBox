using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS.Tools_class
{
    public class CatalogueDB
    {
        public CatalogueDB()
        {

        }

        public CatalogueComponents createComponents(int height, int width, string typeObj)
        {
            switch (typeObj)
            {
                case "CrossBar":
                    return new CrossBar();
                case "Door":
                    return new Door();
                case "Panels":
                    return new Panels();
                case "Cleat":
                    return new Cleat();
                default:
                    break;
            }
            return new Door();
        }
    }
}
