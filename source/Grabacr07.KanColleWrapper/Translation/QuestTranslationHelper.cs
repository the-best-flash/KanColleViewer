namespace Grabacr07.KanColleWrapper.Translation
{
    public static class QuestTranslationHelper
    {
        public static string TranslateQuestTitle(string title)
        {
            string stripped = TranslationHelper.StripInvalidCharacters(title);
            string translated = (string.IsNullOrEmpty(stripped) ? null : Quests.Resources.ResourceManager.GetString(stripped, Quests.Resources.Culture));

            return (string.IsNullOrEmpty(translated) ? title : translated);
        }

        public static string TranslateQuestDetail(string title, string detail)
        {
            string stripped = TranslationHelper.StripInvalidCharacters(title) + "_Detail";
            string translated = (string.IsNullOrEmpty(stripped) ? null : Quests.Resources.ResourceManager.GetString(stripped, Quests.Resources.Culture));

            // Fallback to try the entire description
            if(string.IsNullOrWhiteSpace(translated))
            {
                stripped = TranslationHelper.StripInvalidCharacters(detail);
                translated = (string.IsNullOrEmpty(stripped) ? null : Quests.Resources.ResourceManager.GetString(stripped, Quests.Resources.Culture));
            }

            return (string.IsNullOrEmpty(translated) ? detail : translated);
        }
    }
}
