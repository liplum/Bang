namespace Bang.Mods;
public class ModEntry
{
    public ModInfo? Info
    {
        get; set;
    }

    public DirectoryInfo? Folder
    {
        get; set;
    }

    public FileInfo? ModFile
    {
        get; set;
    }
}
