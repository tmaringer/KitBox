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
            get => Enum.GetNames(typeof(Color)).ToList();
        }

        public static Color parseToEnum(string value)
        {
            return (Color)Enum.Parse(typeof(Color), value, true);
        }
    }
}
