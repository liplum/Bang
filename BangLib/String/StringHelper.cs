using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BangLib.Strings;
public static class StringHelper
{
    public static string Repeat([AllowNull] this string? str, int count)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }

        if (count <= 0)
        {
            return str;
        }

        var b = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            b.Append(str);
        }
        return b.ToString();
    }
}
