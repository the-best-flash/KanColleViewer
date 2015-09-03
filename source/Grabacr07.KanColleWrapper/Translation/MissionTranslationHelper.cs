namespace Grabacr07.KanColleWrapper.Translation
{
    public static class MissionTranslationHelper
    {
        private static string DefaultTranslation(string str, string defaultStr)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                string translation = Expedition.Resources.ResourceManager.GetString(str, Expedition.Resources.Culture);

                if (!string.IsNullOrWhiteSpace(translation))
                {
                    return translation;
                }
            }

            return defaultStr;
        }

        public static string TranslateTitle(int id, string title)
        {
            return DefaultTranslation(string.Format("{0}", id), title);
        }

        public static string TranslateDetail(int id, string details)
        {
            return DefaultTranslation(string.Format("{0}_Details", id), details);
        }
    }
}
