using ICSharpCode.SharpZipLib.Zip;

namespace Bang.IO;
public static class ZipUtil
{
    public static IEnumerable<ZipEntry> Entries(this ZipInputStream zipInputStream)
    {
        ZipEntry current;
        while ((current = zipInputStream.GetNextEntry()) is not null)
        {
            yield return current;
        }
    }
}
