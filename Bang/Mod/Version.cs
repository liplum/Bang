namespace Bang.Mod;
public struct Version
{
    public readonly int Major;
    public readonly int Minor;
    public readonly int Patch;

    public Version(int major, int minor, int patch)
    {
        Major = major;
        Minor = minor;
        Patch = patch;
    }

    public Version(int major, int minor)
    {
        Major = major;
        Minor = minor;
        Patch = 0;
    }

    public Version(int major)
    {
        Major = major;
        Minor = 0;
        Patch = 0;
    }

    public override bool Equals(object? obj)
    {
        return obj is Version version &&
               Major == version.Major &&
               Minor == version.Minor &&
               Patch == version.Patch;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Major, Minor, Patch);
    }

    public override string? ToString()
    {
        return $"{Major}.{Minor}.{Patch}";
    }

    public static bool operator ==(Version left, Version right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Version left, Version right)
    {
        return !(left == right);
    }

    public static bool operator <(Version left, Version right)
    {
        return left.Major <= right.Major &&
            left.Minor <= right.Minor &&
            left.Patch > right.Patch;
    }

    public static bool operator >(Version left, Version right)
    {
        return left.Major >= right.Major &&
            left.Minor >= right.Minor &&
            left.Patch > right.Patch;
    }
}
