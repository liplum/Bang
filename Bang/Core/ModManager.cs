using Bang.IO;
using Bang.Mods;
using Bang.Services;
using ICSharpCode.SharpZipLib.Zip;
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
        var outputFolderPath = outputFolder.FullName;

        using var zipInputStream = new ZipInputStream(File.OpenRead(modFilePath));

        foreach (var file in zipInputStream.Entries())
        {
            var pathInZip = file.Name;
            var directoryPath = Path.GetDirectoryName(pathInZip);

            var outFileName = Path.GetFileName(pathInZip);

            Directory.CreateDirectory(outputFolderPath + "\\" + directoryPath);

            using var streamWriter = File.Create(outputFolderPath + "\\" + directoryPath + "\\" + outFileName);
            int size = 2048;
            var data = new byte[2048];
            while (true)
            {
                size = zipInputStream.Read(data, 0, data.Length);

                if (size > 0)
                    streamWriter.Write(data, 0, size);
                else
                    break;
            }
        }
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

    public void UnloadMod([NotNull] Mod mod)
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