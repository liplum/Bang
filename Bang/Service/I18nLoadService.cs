using Newtonsoft.Json.Linq;

namespace Bang.Services;
public class I18nLoadService : II18nLoadService
{
    private IResourceMangaer? _resourceMangaer;

    public I18nLoadService()
    {

    }

    public void Initialize(IServiceProvider serviceProvider)
    {
        _resourceMangaer = serviceProvider.Reslove<IResourceMangaer>();
    }

    public void Load()
    {
        var languageFile = _resourceMangaer!.LanguageFile;
        var originalContent = File.ReadAllText(languageFile.FullName);
        var lang = JObject.Parse(originalContent);
        var detailContent = new Dictionary<string, string>();
        foreach (var entry in lang.Properties())
        {
            detailContent[entry.Name] = entry.Value.ToString();
        }
        I18n.I18nDetail = new()
        {
            AllDetails = detailContent
        };
    }
}