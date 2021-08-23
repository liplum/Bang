using System.Diagnostics.CodeAnalysis;

namespace Bang.Cards;
public class Card : ICard
{
    [NotNull]
    public static readonly ICard Empty = new Card(EmptyCard.Empty);

    public Card([NotNull] ICardType cardType)
    {
        CardType = cardType;
    }

    public Card()
    {

    }

    public override string? ToString()
    {
        return CardType.ToString();
    }

    [NotNull]
    private ICardType _cardType = EmptyCard.Empty;

    [NotNull]
    public ICardType CardType
    {
        get => _cardType;
        init => _cardType = value;
    }

    public bool IsEmpty => CardType != EmptyCard.Empty;
}
