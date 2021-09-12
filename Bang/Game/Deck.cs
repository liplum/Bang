using Bang.Cards;
using BangLib.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Bang.Games;
public class Deck : IDeck
{
    private NonNullList<ICard> AllCards
    {
        get;
    } = new();

    public void Clear()
    {
        AllCards.Clear();
    }

    public NonNullList<ICard> FindAll([NotNull] Predicate<ICard> filter)
    {
        var res = new NonNullList<ICard>();
        foreach (var card in AllCards)
        {
            if (filter(card))
            {
                res.Add(card);
            }
        }
        return res;
    }

    public ICard FindFirst([NotNull] Predicate<ICard> filter, bool isForward = true)
    {
        if (isForward)
        {
            foreach (var card in AllCards)
            {
                if (filter(card))
                {
                    return card;
                }
            }
        }
        else
        {
            for (int i = AllCards.Count; i > 0; i--)
            {
                var card = AllCards[i];
                if (filter(card))
                {
                    return card;
                }
            }
        }
        return Card.Empty;
    }

    public ICard GetBottomCard()
    {
        if (IsEmpty)
        {
            return Card.Empty;
        }
        return AllCards[-1];
    }

    public NonNullList<ICard> GetBottomCards(int count)
    {
        return AllCards.GetSubList(AllCards.Count - count, count);
    }
    public ICard GetTopCard()
    {
        if (IsEmpty)
        {
            return Card.Empty;
        }
        return AllCards[0];
    }

    public NonNullList<ICard> GetTopCards(int count)
    {
        return AllCards.GetSubList(count);
    }

    public void InsertAtBottom([NotNull] ICard card)
    {
        AllCards.InsertLast(card);
    }

    public void InsertAtBottom([NotNull] NonNullList<ICard> cards)
    {
        AllCards.Insert(AllCards.LastIndex, cards);
    }

    public void InsertAtTop([NotNull] ICard card)
    {
        AllCards.Insert(0, card);
    }

    public void InsertAtTop([NotNull] NonNullList<ICard> cards)
    {
        AllCards.Insert(0, cards);
    }

    public bool IsEmpty => AllCards.IsEmpty;

    public void Shuffle()
    {
        AllCards.Shuffle();
    }

    public override string? ToString()
    {
        var allNames = AllCards.Select(card => card.ToString()).ToList();
        return $"[{string.Join(',', allNames)}]";
    }
}
