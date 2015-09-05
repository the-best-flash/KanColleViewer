namespace Grabacr07.KanColleWrapper.Translation
{
    public static class MapTranslationHelper
    {
        public static string TranslateMapString(string name)
        {
            string translated = (string.IsNullOrEmpty(name) ? null : Maps.Resources.ResourceManager.GetString(name, Maps.Resources.Culture));

            return (string.IsNullOrEmpty(translated) ? name : translated);
        }
    }
}
