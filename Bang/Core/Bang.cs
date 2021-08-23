using Bang.Services;
using Bang.Settings;

namespace Bang.Core;
public class Bang
{
    internal Bang()
    {

    }

    public static Bang MainGame
    {
        get;
    } = new();

    private readonly ServiceContainer _serviceContainer = new();
    private readonly SettingService _settingService = new();
    //private II18nLoadService? _I18NLoadService;

    public void Initialize()
    {
        LoadAllSettings();
        RegisterServices();
        _serviceContainer.HandleReference();
        LoadI18n();
    }

    private void RegisterServices()
    {
        _serviceContainer.RegisterSingleton<II18nLoadService, I18nLoadService>();
        _serviceContainer.RegisterSingleton<IResourceMangaer, ResourceMangaer>();
        _serviceContainer.RegisterInstance<ISettingService>(_settingService);
    }

    private void LoadAllSettings()
    {
        AllSettings.Load();
        _settingService.AddAllSettings();
    }

    private void LoadI18n()
    {
        var _I18NLoadService = _serviceContainer.Reslove<II18nLoadService>();
        _I18NLoadService.Load();
    }
}