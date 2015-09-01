using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grabacr07.KanColleWrapper
{
    public class TranslationHelper
    {
        public static string Kai = "改";
        public static string Ni = "二";

        public static bool NameEndsWithKai(string name)
        {
            return name.TrimEnd().EndsWith(TranslationHelper.Kai);
        }

        public static bool NameEndsWithNi(string name)
        {
            return name.TrimEnd().EndsWith(TranslationHelper.Ni);
        }

        public static bool NameEndsWithKaiNi(string name)
        {
            return name.TrimEnd().EndsWith(TranslationHelper.Kai + TranslationHelper.Ni);
        }

        public static string StripKaiNi(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();

                if (NameEndsWithNi(name))
                {
                    if (NameEndsWithKaiNi(name))
                    {
                        return name.Substring(0, name.Length - 2);
                    }
                    else
                    {
                        return name.Substring(0, name.Length - 1);
                    }
                }
                else if (NameEndsWithKai(name))
                {
                    return name.Substring(0, name.Length - 1);
                }
            }

            return name;
        }

        public static string AppendKaiNi(string baseName, string name, string kai, string ni)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                baseName = baseName.Trim();

                if (NameEndsWithNi(baseName))
                {
                    if (NameEndsWithKaiNi(baseName))
                    {
                        return string.Format("{0} {1} {2}", name, kai, ni);
                    }
                    else
                    {
                        return string.Format("{0} {1}", name, ni);
                    }
                }
                else if (NameEndsWithKai(baseName))
                {
                    return string.Format("{0} {1}", name, kai);
                }

                return name;
            }

            return baseName;
        }

        // TODO: Do this in a more efficent manner
        public static string StripInvalidCharacters(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return str.Replace("「", " ").Replace("」", " ").Replace("" + (char)65281, "").Trim().Replace(" ", "_").Replace("__", "_");
            }
            else
            {
                return str;
            }
        }
    }
}
