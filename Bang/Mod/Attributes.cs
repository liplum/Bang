using System.Diagnostics.CodeAnalysis;

namespace Bang.Mods;
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class ModAttribute : Attribute
{
    public ModAttribute([NotNull] string modID, [NotNull] string name, [NotNull] Version version, params string[] denpendenceModID)
    {
        ModID = modID;
        Name = name;
        Version = version;
        DependenceModID = denpendenceModID;
    }

    public string ModID
    {
        get; init;
    }

    public string Name
    {
        get; init;
    }

    public Version Version
    {
        get; init;
    }

    public string[] DependenceModID
    {
        get; init;
    }
}

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class CoreModAttribute : Attribute
{
    public CoreModAttribute([NotNull] string modID, [NotNull] string name, [NotNull] Version version)
    {
        ModID = modID;
        Name = name;
        Version = version;
    }

    public string ModID
    {
        get; init;
    }

    public string Name
    {
        get; init;
    }

    public Version Version
    {
        get; init;
    }
}