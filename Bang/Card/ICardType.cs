using System.Diagnostics.CodeAnalysis;
using Bang.Contexts;

namespace Bang.Cards;
public interface ICardType
{
    public string ResgisterName
    {
        get;
    }
    public void CanUse([NotNull]CardUsingContext context);

    public int ID{
        get;
    }
}
