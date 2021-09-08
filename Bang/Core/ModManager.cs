using Bang.Mods;
using Bang.Services;
using BangLib.IO;
using System.Diagnostics.CodeAnalysis;

namespace Bang.Core;
public class ModManager : IModManager
{
    private IResourceManager? _resourceManager;

    public void Initialize(Services.IServiceProvider serviceProvider)
    {
        _resourceManager = serviceProvider.Reslove<IResourceManager>();
    }

    public void LoadMod([NotNull] FileInfo modFile)
    {
        var modFilePath = modFile.FullName;
        if (!modFile.Exists || !modFile.Extension.Equals(Names.ModPackExtension, StringComparison.OrdinalIgnoreCase))
        {
            throw new ModFileNotFoundException(modFilePath);
        }

        var modFileNameWithoutExtension = Path.GetFileNameWithoutExtension(modFilePath);
        var outputFolder = RecreateModRuntimeFolder(modFileNameWithoutExtension);
        ZipUtil.Unzip(modFile, outputFolder);
    }

    private DirectoryInfo RecreateModRuntimeFolder([NotNull] string modFileNameWithoutExtension)
    {
        var runtime = _resourceManager!.RuntimeFolder;
        var modRuntime = new DirectoryInfo($"{runtime.FullName}\\{modFileNameWithoutExtension}");
        if (modRuntime.Exists)
        {
            modRuntime.Delete(true);
            modRuntime.Create();
        }
        return modRuntime;
    }

    public void UnloadMod([NotNull] ModEntry mod)
    {
        throw new NotImplementedException();
    }

    public void UnloadMod([NotNull] string modName)
    {
        throw new NotImplementedException();
    }
}

[Serializable]
public class ModFileNotFoundException : Exception
{
    public ModFileNotFoundException() { }
    public ModFileNotFoundException(string message) : base(message) { }
    public ModFileNotFoundException(string message, Exception inner) : base(message, inner) { }
    protected ModFileNotFoundException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}