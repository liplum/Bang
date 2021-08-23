using System.Diagnostics.CodeAnalysis;
using Bang.Registry;
using Bang.Settings;

namespace Bang.Services;
public class SettingService : ISettingService
{
    private readonly Dictionary<Setting, object> _allSettings = new();
    public T? GetSetting<T>(Setting setting)
    {
        if (_allSettings.TryGetValue(setting, out var value))
        {
            if (value is T res)
            {
                return res;
            }
        }
        return default;
    }

    public void SetSetting<T>(Setting setting, [NotNull] T value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }
        _allSettings[setting] = value;
    }

    public void AddAllSettings()
    {
        foreach (var setting in SettingsRegistry.AllSettings)
        {
            _allSettings[setting] = setting.DefaultValue;
        }
    }
}
