namespace Grabacr07.KanColleViewer
{
    public static class ShipTranslationHelper
    {
        public static string TranslateShipName(int id, string name)
        {
            string translated = null;

            translated = Translation.Ships.Resources.ResourceManager.GetString(string.Format("Ship{0}", id), Translation.Ships.Resources.Culture);

            if (string.IsNullOrWhiteSpace(translated))
            {
                string fullStrippedName = KanColleWrapper.TranslationHelper.StripInvalidCharacters(name);
                string stripped = KanColleWrapper.TranslationHelper.StripKaiNi(fullStrippedName);

                translated = (string.IsNullOrEmpty(stripped) ? null : Translation.Ships.Resources.ResourceManager.GetString(stripped, Translation.Ships.Resources.Culture));
            
                if (!string.IsNullOrWhiteSpace(translated))
                {
                    translated = KanColleWrapper.TranslationHelper.AppendKaiNi(fullStrippedName, translated, Properties.Resources.Kai, Properties.Resources.Ni);
                }
            }

            return (string.IsNullOrEmpty(translated) ? name : translated);
        }

        public static string TranslateShipTypeName(string name)
        {
            string stripped = KanColleWrapper.TranslationHelper.StripInvalidCharacters(name);
            string translated = (string.IsNullOrEmpty(stripped) ? null : Translation.Ships.Resources.ResourceManager.GetString(stripped, Translation.Ships.Resources.Culture));

            return (string.IsNullOrEmpty(translated) ? name : translated);
        }
    }
}
