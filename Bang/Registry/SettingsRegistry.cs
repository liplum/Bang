using Bang.Settings;

namespace Bang.Registry;
public static class SettingsRegistry
{
    private static readonly Dictionary<string, Setting> _allSettings = new();
    public static Setting Register(Setting setting)
    {
        _allSettings[setting.RegisterName] = setting;
        return setting;
    }

    public static bool IsRegistered(this Setting setting)
    {
        return _allSettings.ContainsValue(setting);
    }

    public static bool IsRegistered(string settingName)
    {
        return _allSettings.ContainsKey(settingName);
    }

    public static IEnumerable<Setting> AllSettings
    {
        get
        {
            foreach (var setting in _allSettings.Values)
            {
                yield return setting;
            }
        }
    }
}