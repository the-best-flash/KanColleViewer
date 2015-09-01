namespace Grabacr07.KanColleViewer
{
    public static class ItemTranslationHelper
    {
        public static string TranslateItemName(string name)
        {
            string stripped = KanColleWrapper.TranslationHelper.StripInvalidCharacters(name);
            string translated = (string.IsNullOrEmpty(stripped) ? null : Translation.Equipment.Resources.ResourceManager.GetString(stripped, Translation.Equipment.Resources.Culture));

            return (string.IsNullOrEmpty(translated) ? name : translated);
        }
    }
}
