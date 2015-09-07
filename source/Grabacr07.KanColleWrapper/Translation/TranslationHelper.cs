using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Grabacr07.KanColleWrapper.Translation
{
    public class TranslationHelper
    {
        public const string Kai = "改";
        public const string Ni = "二";
        public const string Kai_Ni = Kai + Ni;

        public static bool NameEndsWithKai(string name)
        {
            return name.TrimEnd().EndsWith(Kai);
        }

        public static bool NameEndsWithNi(string name)
        {
            return name.TrimEnd().EndsWith(Ni);
        }

        public static bool NameEndsWithKaiNi(string name)
        {
            return name.TrimEnd().EndsWith(Kai_Ni);
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

        // TODO: This is unnecessary, convert the quest key strings in the .resx to match the API names or to use the quest ID
        public static string StripInvalidCharacters(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return str.Replace("「", " ").Replace("」", " ").Replace(string.Empty + (char)65281, string.Empty).Trim().Replace(" ", "_").Replace("__", "_");
            }
            else
            {
                return str;
            }
        }

        public static string TranslateShipName(string name)
        {
            string stripped = StripKaiNi(name);
            string translated = (string.IsNullOrEmpty(stripped) ? null : Ships.Resources.ResourceManager.GetString(stripped, Ships.Resources.Culture));

            if (!string.IsNullOrWhiteSpace(translated))
            {
                translated = AppendKaiNi(name, translated, Ships.Resources.Kai, Ships.Resources.Ni);
            }

            return (string.IsNullOrEmpty(translated) ? name : translated);
        }

        public static string TranslateShipTypeName(string name)
        {
            return TranslationOrDefault(name, name, Ships.Resources.ResourceManager, Ships.Resources.Culture);
        }

        public static bool UseShipNameForSorting()
        {
            return Ships.Resources.UseShipNameForSorting == "true";
        }

        public static string TranslateShipTypeName(int id, string name)
        {
            string translated = TranslateShipTypeName((id == 8 && name == "戦艦") ? "巡洋戦艦" : name);

            if (translated == "巡洋戦艦" && name == "戦艦")
            {
                translated = name;
            }

            return translated;
        }

        public static string TranslateQuestTitle(string title)
        {
            string stripped = StripInvalidCharacters(title);
            return TranslationOrDefault(stripped, title, Quests.Resources.ResourceManager, Quests.Resources.Culture);
        }

        public static string TranslateQuestDetail(string title, string detail)
        {
            string stripped = StripInvalidCharacters(title);
            string translated = (string.IsNullOrEmpty(stripped) ? null : Quests.Resources.ResourceManager.GetString(string.Format("{0}_Detail", stripped ), Quests.Resources.Culture));

            // Fallback to try the entire description
            if (string.IsNullOrWhiteSpace(translated))
            {
                stripped = StripInvalidCharacters(detail);
                translated = (string.IsNullOrEmpty(stripped) ? null : Quests.Resources.ResourceManager.GetString(stripped, Quests.Resources.Culture));
            }

            return (string.IsNullOrEmpty(translated) ? detail : translated);
        }

        private static string TranslationOrDefault(string str, string defaultStr, ResourceManager resourceManager, CultureInfo cultureInfo)
        {
            if (!string.IsNullOrWhiteSpace(str) && resourceManager != null)
            {
                string translation = resourceManager.GetString(str, cultureInfo);

                if (!string.IsNullOrWhiteSpace(translation))
                {
                    return translation;
                }
            }

            return defaultStr;
        }

        private static string TranslateExpeditionString(string key, string str)
        {
            return TranslationOrDefault(key, str, Expedition.Resources.ResourceManager, Expedition.Resources.Culture);
        }

        public static string TranslateExpeditionTitle(int id, string title)
        {
            return TranslateExpeditionString(string.Format("{0}", id), title);
        }

        public static string TranslateExpeditionDetail(int id, string details)
        {
            return TranslateExpeditionString(string.Format("{0}_Details", id), details);
        }

        public static string TranslateMapString(string key, string str)
        {
            return TranslationOrDefault(key, str, Maps.Resources.ResourceManager, Maps.Resources.Culture);
        }

        public static string TranslateMapName(int id, string name)
        {
            return TranslateMapString(string.Format("Map{0}", id), name);
        }

        public static string TranslateMapAreaName(int id, string name)
        {
            return TranslateMapString(string.Format("MapArea{0}", id), name);
        }

        public static string TranslateMapOperationName(int id, string name)
        {
            return TranslateMapString(string.Format("Map{0}_OperationName", id), name);
        }

        public static string TranslateMapOperationInfo(int id, string description)
        {
            return TranslateMapString(string.Format("Map{0}_OperationInfo", id), description);
        }

        public static string TranslateItemName(string name)
        {
            return TranslationOrDefault(name, name, Equipment.Resources.ResourceManager, Equipment.Resources.Culture);
        }
    }
}
