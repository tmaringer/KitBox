using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS.Tools_class
{
    public static class ColorParse
    {
        public static List<String> colorsList
        {
            get => Enum.GetNames(typeof(ComponentColor)).ToList();
        }

        public static ComponentColor parseToEnum(string value)
        {
            return (ComponentColor)Enum.Parse(typeof(ComponentColor), value, true);
        }
    }
}
