namespace Grabacr07.KanColleWrapper.Translation
{
    public static class ItemTranslationHelper
    {
        public static string TranslateItemName(string name)
        {
            string translated = (string.IsNullOrEmpty(name) ? null : Equipment.Resources.ResourceManager.GetString(name, Equipment.Resources.Culture));

            return (string.IsNullOrEmpty(translated) ? name : translated);
        }
    }
}
