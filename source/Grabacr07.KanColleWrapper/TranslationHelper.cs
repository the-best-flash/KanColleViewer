using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grabacr07.KanColleWrapper
{
    public class TranslationHelper
    {
        // TODO: Do this in a more efficent manner
        public static string StripInvalidCharacters(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return str.Replace("「", "").Replace("」", "").Replace("" + (char)65281, "").Replace(" ", "_");
            }
            else
            {
                return str;
            }
        }
    }
}
