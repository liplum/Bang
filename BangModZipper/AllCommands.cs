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
    public const string ZipModPack = "Usage:<folder name> \n.Zip a folder to a Mod Pack";
    public const string GenerateModPackInfo = "Usage:<folder name> \nGenerate a Mod Info file.";
}

public static partial class AllCommands
{
    public static readonly Command ZipModPack =
        new(Identifiers.ZipModPack, Names.ZipModPack, Descriptions.ZipModPack, args =>
        {

        });


    public static readonly Command GenerateModPackInfo =
         new(Identifiers.GenerateModPackInfo, Names.GenerateModPackInfo, Descriptions.GenerateModPackInfo, args =>
         {

         });
}