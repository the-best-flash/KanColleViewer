using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grabacr07.KanColleViewer
{
    public static class QuestTranslationHelper
    {
        public static string TranslateQuestTitle(string title)
        {
            string stripped = KanColleWrapper.TranslationHelper.StripInvalidCharacters(title);
            string translated = (string.IsNullOrEmpty(stripped) ? null : Translation.Quests.Resources.ResourceManager.GetString(stripped, Translation.Quests.Resources.Culture));

            return (string.IsNullOrEmpty(translated) ? title : translated);
        }

        public static string TranslateQuestDetail(string title, string detail)
        {
            string stripped = KanColleWrapper.TranslationHelper.StripInvalidCharacters(title) + "_Detail";
            string translated = (string.IsNullOrEmpty(stripped) ? null : Translation.Quests.Resources.ResourceManager.GetString(stripped, Translation.Quests.Resources.Culture));

            // Fallback to try the entire description
            if(string.IsNullOrWhiteSpace(translated))
            {
                stripped = KanColleWrapper.TranslationHelper.StripInvalidCharacters(detail);
                translated = (string.IsNullOrEmpty(stripped) ? null : Translation.Quests.Resources.ResourceManager.GetString(stripped, Translation.Quests.Resources.Culture));
            }

            return (string.IsNullOrEmpty(translated) ? detail : translated);
        }
    }
}
