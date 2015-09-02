namespace Grabacr07.KanColleViewer
{
    public static class ShipTranslationHelper
    {
        public static string TranslateShipName(int id, string name)
        {
            string fullStrippedName = KanColleWrapper.TranslationHelper.StripInvalidCharacters(name);
            string stripped = KanColleWrapper.TranslationHelper.StripKaiNi(fullStrippedName);

            string translated = (string.IsNullOrEmpty(stripped) ? null : Translation.Ships.Resources.ResourceManager.GetString(stripped, Translation.Ships.Resources.Culture));
            
            if (!string.IsNullOrWhiteSpace(translated))
            {
                translated = KanColleWrapper.TranslationHelper.AppendKaiNi(fullStrippedName, translated, Properties.Resources.Kai, Properties.Resources.Ni);
            }

            return (string.IsNullOrEmpty(translated) ? name : translated);
        }

        public static string TranslateShipTypeName(string name)
        {
            string stripped = KanColleWrapper.TranslationHelper.StripInvalidCharacters(name);
            string translated = (string.IsNullOrEmpty(stripped) ? null : Translation.Ships.Resources.ResourceManager.GetString(stripped, Translation.Ships.Resources.Culture));

            return (string.IsNullOrEmpty(translated) ? name : translated);
        }

        public static string TranslateShipTypeName(int id, string name)
        {
            string translated = TranslateShipTypeName((id == 8 && name == "戦艦") ? "巡洋戦艦" : name);

            if(translated == "巡洋戦艦" && name == "戦艦")
            {
                translated = name;
            }

            return translated;
        }
    }
}
