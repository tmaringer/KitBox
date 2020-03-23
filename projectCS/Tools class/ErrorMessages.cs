using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectCS
{
    // todo : mettre les différentes phrases qu'on utilisera, regroupera les différents champs/mots
    public static class ErrorMessages
    {
        public static string defaultErrorMsg = "default error message";
        public static string defaultErrorTitle = "default error title";

        public static string connectionDBFailed = "connection to data base have failed";

        public static string componentMaxExceedMsg = "The number of components maximum have been reach";
        public static string componentMaxExceedTitle = "Maximum exceed";

        public static string invalidColorMsg = "You have choiced a bad color for this item";
        public static string invalidColorTitle = "Bad Color choice";
    }
}
