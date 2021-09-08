using System.Diagnostics.CodeAnalysis;

namespace BangLib.IO;
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


    public static DirectoryInfo GetOrCreateSubFolder([NotNull] this DirectoryInfo directory, [NotNull] string subFolderName)
    {
        var subFolder = new DirectoryInfo($"{directory.FullName}\\{subFolderName}");
        if (!subFolder.Exists)
        {
            subFolder.Create();
        }
        return subFolder;
    }

    public static FileInfo GetOrCreateSubFile([NotNull] this DirectoryInfo directory, [NotNull] string subFileName)
    {
        var subFile = new FileInfo($"{directory.FullName}\\{subFileName}");
        if (!subFile.Exists)
        {
            subFile.Create().Close();
        }
        return subFile;
    }

    public static FileInfo GetSubFile([NotNull] this DirectoryInfo directory, [NotNull] string subFileName)
    {
        var subFile = new FileInfo($"{directory.FullName}\\{subFileName}");
        return subFile;
    }
}
