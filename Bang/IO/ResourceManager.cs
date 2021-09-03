using Bang.Core;
using Bang.IO;
using Bang.Settings;
using System.Diagnostics.CodeAnalysis;

namespace Bang.Services;
public class ResourceManager : IResourceManager
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

    public DirectoryInfo ModsFolder => new DirectoryInfo($".\\{Names.ModsFolderName}").GetOrCreate();

    public void Initialize(IServiceProvider serviceProvider)
    {
        _settingService = serviceProvider.Reslove<ISettingService>();
    }

    public DirectoryInfo ResolveDirectory([NotNull] ResLocation location)
    {
        var path = $".\\Resources\\{location.Namespace}";
        foreach (var part in location.PathParts)
        {
            path += "\\" + part;
        }
        return new(path);
    }

    public FileInfo ResolveFile([NotNull] ResLocation location, [NotNull] string suffix = "")
    {
        var path = $".\\Resources\\{location.Namespace}";
        foreach (var part in location.PathParts)
        {
            path += "\\" + part;
        }
        path += suffix;
        return new(path);
    }
}