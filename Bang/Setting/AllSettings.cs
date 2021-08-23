using Bang.I18ns;

namespace Bang.Settings;
public class AllSettings
{
    static AllSettings()
    {

    }

    public static readonly Setting Language = new("Language", "en_US")
    {
        UnlocalizedName = I18nKey.Settings.Language
    };

    public static readonly Setting LanguageFilePath = new("LanguageFilePath", "./lang.json")
    {
        UnlocalizedName = I18nKey.Settings.LanguageFilePath
    };

    public static void Load()
    {

    }
}
