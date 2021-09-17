using Bang.Networks;
using Bang.Services;
using Bang.Settings;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Bang.Core;
public class BangGame
{
    public delegate void ServiceRegisterHandler(IServiceRegistry registry);
    public event ServiceRegisterHandler? ServiceRegisterEvent;

    internal BangGame()
    {

    }

    public static BangGame MainGame
    {
        get;
    } = new();

    public bool Initialized
    {
        get; private set;
    } = false;

    public Side ApplicationSide
    {
        get; init;
    }

    private readonly ServiceContainer _serviceContainer = new();
    private readonly SettingService _settingService = new();
    //private II18nLoadService? _I18NLoadService;
    private IResourceManager? _resourceManager;
    private ILoggerService? _loggerService;
    private IModManager? _modManager;

    public void Initialize()
    {
        LoadAllSettings();
        RegisterServices();
        _serviceContainer.HandleReference();
        LoadI18n();
    }

    public void LoadMods()
    {
        var modsFolder = _resourceManager!.ModsFolder;
        LoadAllMods();

        void LoadAllMods()
        {
            foreach (var modPack in from file in modsFolder.GetFiles() where file.Name.EndsWith(Names.ModPackExtension) select file)
            {
                LoadMod(modPack);
            }
        }
    }

    public void LoadMod([NotNull] FileInfo modFile)
    {
        _modManager!.LoadMod(modFile);
    }

    public void Close()
    {
        DeleteRuntimeFolder();
    }

    public void DeleteRuntimeFolder()
    {
        _resourceManager!.RuntimeFolder.Delete(true);
    }

    private void RegisterServices()
    {
        _serviceContainer.RegisterSingleton<II18nLoadService, I18nLoadService>();
        _serviceContainer.RegisterSingleton<IResourceManager, ResourceManager>();
        _serviceContainer.RegisterSingleton<IModManager, ModManager>();
        _serviceContainer.RegisterSingleton<INetwork, Network>();
        _serviceContainer.RegisterInstance<ISettingService>(_settingService);
        _serviceContainer.RegisterInstance(this);

        ServiceRegisterEvent?.Invoke(_serviceContainer);

        _loggerService = _serviceContainer.Reslove<ILoggerService>();
        _resourceManager = _serviceContainer.Reslove<IResourceManager>();
        _modManager = _serviceContainer.Reslove<IModManager>();

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

public enum Side
{
    Server, Client
}