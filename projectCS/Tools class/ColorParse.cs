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

        public static ComponentColor parseToEnum(string str)
        {
            return (ComponentColor)Enum.Parse(typeof(ComponentColor), str, true);
        }

        public static String parseToStr(ComponentColor color)
        {
            return Enum.GetName(color.GetType(), color);
        }
    }
}
