using BangLib.IO;
using BangModZipper.Exceptions;
namespace BangModZipper.Commands;

public static partial class Identifiers
{
    public const string ZipModPack = "-p";
    public const string GenerateModPackInfo = "-i";
}
public static partial class Names
{
    public const string ZipModPack = "Zip Mod Pack";
    public const string GenerateModPackInfo = "Generate Mod Pack Info";
}
public static partial class Descriptions
{
    public const string ZipModPack = "Usage:<folder name>. Zip a folder to a Mod Pack";
    public const string GenerateModPackInfo = "Usage:<folder name>. Generate a Mod Info file.";
}

public static partial class AllCommands
{
    public static readonly Command ZipModPack =
        new(Identifiers.ZipModPack, Names.ZipModPack, Descriptions.ZipModPack, args =>
        {
            if (args.Length == 0)
            {
                throw new CommandWrongUsingException(0, "The folder's path was missed.");
            }
            else if (args.Length > 1)
            {
                throw new CommandWrongUsingException(1, "Too many parameters were given.");
            }
            var folderPath = args[0];
            var folder = new DirectoryInfo(folderPath);
            if (!folder.Exists)
            {
                throw new CommandWrongUsingException(0, "The folder given was not existed.");
            }
            var parentFolder = folder.Parent;
            if (parentFolder is null)
            {
                throw new CommandWrongUsingException(0, "The folder cannot be a root directory.");
            }
            var zipFile = parentFolder.GetSubFile(folder.Name + Names.ZipModPack);
            ZipUtil.Zip(zipFile, folder);
        });


    public static readonly Command GenerateModPackInfo =
         new(Identifiers.GenerateModPackInfo, Names.GenerateModPackInfo, Descriptions.GenerateModPackInfo, args =>
         {

         });
}