using Bang.Settings;

namespace Bang.Services;
public interface ISettingService
{
    public T? GetSetting<T>(Setting setting);

    public void SetSetting<T>(Setting setting, T value);
}
