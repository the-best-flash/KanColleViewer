using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grabacr07.KanColleViewer
{
    public static class ShipTranslationHelper
    {
        public static string TranslateShipName(string name)
        {
            string fullStrippedName = KanColleWrapper.TranslationHelper.StripInvalidCharacters(name);
            string stripped = KanColleWrapper.TranslationHelper.StripKaiNi(fullStrippedName);

            string translated = (string.IsNullOrEmpty(stripped) ? null : Grabacr07.KanColleViewer.Properties.Resources.ResourceManager.GetString(stripped, Grabacr07.KanColleViewer.Properties.Resources.Culture));

            if (!string.IsNullOrWhiteSpace(translated))
            {
                translated = KanColleWrapper.TranslationHelper.AppendKaiNi(fullStrippedName, translated, Properties.Resources.Kai, Properties.Resources.Ni);
            }

            return (string.IsNullOrEmpty(translated) ? name : translated);
        }

        public static string TranslateShipTypeName(string name)
        {
            string stripped = KanColleWrapper.TranslationHelper.StripInvalidCharacters(name);
            string translated = (string.IsNullOrEmpty(stripped) ? null : Grabacr07.KanColleViewer.Properties.Resources.ResourceManager.GetString(stripped, Grabacr07.KanColleViewer.Properties.Resources.Culture));

            return (string.IsNullOrEmpty(translated) ? name : translated);
        }
    }
}
