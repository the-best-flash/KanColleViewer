namespace Grabacr07.KanColleWrapper.Translation
{
    public static class ItemTranslationHelper
    {
        public static string TranslateItemName(string name)
        {
            string stripped = TranslationHelper.StripInvalidCharacters(name);
            string translated = (string.IsNullOrEmpty(stripped) ? null : Equipment.Resources.ResourceManager.GetString(stripped, Equipment.Resources.Culture));

            return (string.IsNullOrEmpty(translated) ? name : translated);
        }
    }
}
