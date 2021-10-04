using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace BangLib.IO;
public static class ZipUtil
{
    private static FastZip FastZip
    {
        get;
    } = new();

    public static IEnumerable<ZipEntry> Entries(this ZipInputStream zipInputStream)
    {
        ZipEntry current;
        while ((current = zipInputStream.GetNextEntry()) is not null)
        {
            yield return current;
        }
    }

    public static void Unzip_([NotNull] FileInfo zipFile, [NotNull] DirectoryInfo targetFolder)
    {
        var outputFolderPath = targetFolder.FullName;

        using var zipInputStream = new ZipInputStream(File.OpenRead(zipFile.FullName));

        foreach (var file in zipInputStream.Entries())
        {
            var pathInZip = file.Name;
            var directoryPath = Path.GetDirectoryName(pathInZip);

            var outputFileName = Path.GetFileName(pathInZip);

            Directory.CreateDirectory(outputFolderPath + "\\" + directoryPath);

            using var streamWriter = File.Create(outputFolderPath + "\\" + directoryPath + "\\" + outputFileName);
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

    public static void Unzip([NotNull] FileInfo sourceZipFile, [NotNull] DirectoryInfo targetFolder)
    {
        FastZip.ExtractZip(sourceZipFile.FullName, targetFolder.GetOrCreate().FullName, null);
    }

    public static void Zip([NotNull] FileInfo targetZipFile, [NotNull] DirectoryInfo sourceFolder)
    {
        var targetZipName = targetZipFile.FullName;
        var fullNameWithoutExtension = Path.GetFileNameWithoutExtension(targetZipName);
        var extension = targetZipFile.Extension;
        if (targetZipFile.Exists)
        {
            fullNameWithoutExtension += " " + DateTime.Now.ToString("yyyyMMdd-HH:mm:ss");
        }
        FastZip.CreateZip(fullNameWithoutExtension + extension, sourceFolder.GetOrCreate().FullName, true, null);
    }
}
