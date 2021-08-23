using System.Diagnostics.CodeAnalysis;
using Bang.Core;
using Bang.Registry;

namespace Bang.Settings;
public class Setting : INamedObject
{
    public Setting([NotNull] string registerName, [NotNull] object defaultValue)
    {
        RegisterName = registerName;
        DefaultValue = defaultValue;
        SettingsRegistry.Register(this);
    }

    public string RegisterName
    {
        get; init;
    }

    public string UnlocalizedName
    {
        get; init;
    } = string.Empty;

    public object DefaultValue
    {
        get; init;
    }
}
