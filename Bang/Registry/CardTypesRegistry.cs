using Bang.Cards;

namespace Bang.Registry;
public static class CardTypesRegistry
{
    private static readonly HashSet<ICardType> _allCardTypes = new();
    private static readonly Dictionary<int, ICardType> _IDMap = new();
    private static readonly Dictionary<string, ICardType> _registerNameMap = new();
    public static T Register<T>(T cardType) where T : ICardType
    {
        _allCardTypes.Add(cardType);
        _IDMap[cardType.ID] = cardType;
        _registerNameMap[cardType.ResgisterName] = cardType;
        return cardType;
    }

    public static bool IsRegistered(this ICardType cardType)
    {
        return _allCardTypes.Contains(cardType);
    }

    public static ICardType GetBy(int id)
    {
        return _IDMap[id];
    }

    public static ICardType GetBy(string registerName)
    {
        return _registerNameMap[registerName];
    }
}