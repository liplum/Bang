using System.Diagnostics.CodeAnalysis;

namespace Bang.Games;
public class Turn
{
    public Turn(int number, [NotNull] IPlayer owner)
    {
        Number = number;
        Owner = owner;
    }

    public int Number
    {
        get; init;
    }

    [NotNull]
    public IPlayer Owner
    {
        get; init;
    }
}
