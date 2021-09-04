namespace Bang.Mods;
public class Mod
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
