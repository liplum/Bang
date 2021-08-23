using Bang.Core;
using Bang.I18ns;

namespace Bang.Services;
public static class I18n
{
    public static I18nDetail? I18nDetail
    {
        private get;
        set;
    }

    public static string BeLocalized(this string unlocalizedName, params object[] args)
    {
        var localized = I18nDetail?[unlocalizedName];

        return localized is not null ?
            string.Format(localized, args) :
            unlocalizedName;
    }

    public static string BeLocalized(this INamedObject obj)
    {
        var localized = I18nDetail?[obj.UnlocalizedName];

        return localized is not null ?
           string.Format(localized) :
           obj.UnlocalizedName;
    }
}
