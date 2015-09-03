namespace Grabacr07.KanColleWrapper.Translation
{
    public static class ShipTranslationHelper
    {
        public static string TranslateShipName(string name)
        {
            string fullStrippedName = TranslationHelper.StripInvalidCharacters(name);
            string stripped = TranslationHelper.StripKaiNi(fullStrippedName);

            string translated = (string.IsNullOrEmpty(stripped) ? null : Ships.Resources.ResourceManager.GetString(stripped, Ships.Resources.Culture));
            
            if (!string.IsNullOrWhiteSpace(translated))
            {
                translated = TranslationHelper.AppendKaiNi(fullStrippedName, translated, Ships.Resources.Kai, Ships.Resources.Ni);
            }

            return (string.IsNullOrEmpty(translated) ? name : translated);
        }

        public static string TranslateShipTypeName(string name)
        {
            string stripped = TranslationHelper.StripInvalidCharacters(name);
            string translated = (string.IsNullOrEmpty(stripped) ? null : Ships.Resources.ResourceManager.GetString(stripped, Ships.Resources.Culture));

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
