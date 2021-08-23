using System.Diagnostics.CodeAnalysis;

namespace Bang.Cards;
public interface ICard
{
    [NotNull]
    public ICardType CardType{
        get;init;
    }

    public bool IsEmpty
    {
        get;
    }
}
