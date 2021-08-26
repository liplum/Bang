namespace Bang.Services;
public interface IResourceMangaer : IInjectable
{
    public FileInfo LanguageFile
    {
        get;
    }
    public FileInfo SettingsFile
    {
        get;
    }
}
