using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS.Tools_class
{
    /// <summary>
    ///     This class convert a double number rounded to 2 significant digit.
    /// </summary>
    public static class ConvertDoubleToPrice
    {
        public static double convertToPrice(double price)
        {
            return (double)Math.Round(price, 2);
        }
        
        public static double convertToPrice(float price)
        {
            return (double)Math.Round(price, 2);
        }

        public static double convertToPrice(string price)
        {
            return (double)Math.Round(float.Parse(price), 2);
        }
    }
}
