using System.Diagnostics.CodeAnalysis;

namespace Bang.Core;
public class ResLocation
{
    public ResLocation([NotNull] string @namespace, [NotNull] string path, [NotNull] char separator = '\\')
    {
        Namespace = @namespace;
        Path = path;
        Separator = separator;
        PathParts = Path.Split(separator);
    }

    public string Namespace
    {
        get; init;
    }

    public string Path
    {
        get; init;
    }

    public string[] PathParts
    {
        get; init;
    }

    public char Separator
    {
        get; init;
    }
}
