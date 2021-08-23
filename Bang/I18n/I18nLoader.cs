using Bang.I18ns;

namespace Bang.Services;
public class I18nLoader
{
    public I18nDetail Read(FileInfo languageFile)
    {
        return Read(languageFile.FullName);
    }

    public I18nDetail Read(string languageFilePath)
    {
        using var reader = new StreamReader(languageFilePath);
        return new();
    }
}
