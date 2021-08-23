using System.Diagnostics.CodeAnalysis;
using Bang.Contexts;

namespace Bang.Cards;
public class CardTypeBase : ICardType
{
    public CardTypeBase()
    {

    }

    public string ResgisterName
    {
        get;set;
    } = "Empty";

    public int ID
    {
        get; set;
    } = 0;

    public void CanUse([NotNull] CardUsingContext context)
    {
        throw new NotImplementedException();
    }

    public override string? ToString()
    {
        return ResgisterName;
    }
}
