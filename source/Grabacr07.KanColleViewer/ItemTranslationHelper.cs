using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grabacr07.KanColleViewer
{
    public class ItemTranslationHelper
    {
        public static string TranslateItemName(string name)
        {
            string stripped = KanColleWrapper.TranslationHelper.StripInvalidCharacters(name);
            string translated = (string.IsNullOrEmpty(stripped) ? null : Grabacr07.KanColleViewer.Properties.Resources.ResourceManager.GetString(stripped, Grabacr07.KanColleViewer.Properties.Resources.Culture));

            return (string.IsNullOrEmpty(translated) ? name : translated);
        }
    }
}
