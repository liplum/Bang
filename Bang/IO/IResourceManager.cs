using Bang.Core;
using System.Diagnostics.CodeAnalysis;

namespace Bang.Services;
public interface IResourceManager : IInjectable
{
    public FileInfo LanguageFile
    {
        get;
    }
    public FileInfo SettingsFile
    {
        get;
    }

    public FileInfo ResolveFile([NotNull] ResLocation location, [NotNull] string suffix = "");
    public DirectoryInfo ResolveDirectory([NotNull] ResLocation location);

    public DirectoryInfo ModsFolder
    {
        get;
    }

    public DirectoryInfo RuntimeFolder
    {
        get;
    }

    public DirectoryInfo BangRootFolder
    {
        get;
    }
}
