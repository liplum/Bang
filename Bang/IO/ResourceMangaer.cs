using Bang.Settings;

namespace Bang.Services;
public class ResourceMangaer : IResourceMangaer
{
    private ISettingService? _settingService;

    public FileInfo LanguageFile
    {
        get
        {
            var lang = _settingService!.GetSetting<string>(AllSettings.Language);
            return new("./Resources/Bang/Lang/" + lang + ".json");
        }
    }

    public FileInfo SettingsFile => new("./settings.json");

    public void Initialize(IServiceProvider serviceProvider)
    {
        _settingService = serviceProvider.Reslove<ISettingService>();
    }
}