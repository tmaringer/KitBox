using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS.Tools_class
{
    /// <summary>
    ///     This class enable to convert all colors from Color enum to str list, in a color to enum and inversely
    /// </summary>
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

        /// <summary>
        ///     Convert color from Color enum to str (ne devrais pas être utilisé mais mise au cas ou)
        /// </summary>
        /// <param name="color">
        ///     color to convert
        /// </param>
        /// <returns>
        ///     String of color passed in argument
        /// </returns>
        public static String parseToStr(ComponentColor color)
        {
            return Enum.GetName(color.GetType(), color);
        }
    }
}
