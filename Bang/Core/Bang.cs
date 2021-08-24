﻿using Bang.Services;
using Bang.Settings;

namespace Bang.Core;
public class Bang
{
    public delegate void ServiceRegisterHandler(IServiceRegistry registry);
    public event ServiceRegisterHandler? ServiceRegisterEvent;

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
    private ILoggerService? _loggerService;

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

        ServiceRegisterEvent?.Invoke(_serviceContainer);

        _loggerService = _serviceContainer.Reslove<ILoggerService>();
        _loggerService?.SendMessage("Service Component is Initialized successfully.");
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