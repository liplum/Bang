namespace Bang.I18ns;
public static class I18nKey
{
    public const string Bang = "Bang";
    public static class Lang
    {
        private const string Prefix = Bang + "." + "Lang";
        public const string en_US = Prefix + "." + "en_US";
    }
    public static class Settings
    {
        private const string Prefix = Bang + "." + "Settings";
        public const string LanguageFilePath = Prefix + "." + "LanguageFilePath";
        public const string Language = Prefix + "." + "Language";
    }
}
