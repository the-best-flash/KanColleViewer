namespace Grabacr07.KanColleWrapper.Translation
{
    public static class MapTranslationHelper
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

        public static string TranslateMapName(int id, string name)
        {
            return DefaultTranslation(string.Format("Map{0}", id), name);
        }

        public static string TranslateMapAreaName(int id, string name)
        {
            return DefaultTranslation(string.Format("MapArea{0}", id), name);
        }

        public static string TranslateMapOperationName(int id, string name)
        {
            return DefaultTranslation(string.Format("Map{0}_OperationName", id), name);
        }

        public static string TranslateMapOperationInfo(int id, string description)
        {
            return DefaultTranslation(string.Format("Map{0}_OperationInfo", id), description);
        }
    }
}
