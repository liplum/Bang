using System.Diagnostics.CodeAnalysis;

namespace Bang.IO;
public static class IoUtil
{
    public static DirectoryInfo GetOrCreate([NotNull] this DirectoryInfo directory)
    {
        if (!directory.Exists)
        {
            directory.Create();
        }
        return directory;
    }
}
