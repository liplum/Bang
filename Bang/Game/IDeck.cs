using Bang.Cards;
using BangLib.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Bang.Game;
public interface IDeck
{
    /// <summary>
    /// Gets some cards at the top.<br/>
    /// e.g.:<top>1 2 3 4 5 6 7 8 9<bottom>.These 3 getton cards are [1,2,3].
    /// </summary>
    /// <param name="count">the amount</param>
    /// <returns>the list of cards</returns>
    public NonNullList<ICard> GetTopCards(int count);

    /// <summary>
    /// Gets some cards at the bottom.<br/>
    /// e.g.:<top>1 2 3 4 5 6 7 8 9<bottom>.These 3 getton cards are [9,8,7].
    /// </summary>
    /// <param name="count">the amount</param>
    /// <returns>the list of cards</returns>
    public NonNullList<ICard> GetBottomCards(int count);

    /// <summary>
    /// Gets one card at the top.
    /// e.g.:<top>1 2 3 4 5 6 7 8 9<bottom>.The gotten card is 1.
    /// </summary>
    /// <returns>the top card</returns>
    public ICard GetTopCard();

    /// <summary>
    /// Gets one card at the bottom.<br/>
    /// e.g.:<top>1 2 3 4 5 6 7 8 9<bottom>.The gotten card is 9.
    /// </summary>
    /// <returns>the bottom card</returns>
    public ICard GetBottomCard();

    /// <summary>
    /// Shuffles the whole deck.
    /// </summary>
    public void Shuffle();

    /// <summary>
    /// Clear all the cards.
    /// </summary>
    public void Clear();

    /// <summary>
    /// Is this Deck Empty?
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty
    {
        get;
    }

    /// <summary>
    /// Insert one card at the top.
    /// </summary>
    /// <param name="card">the card</param>
    public void InsertAtTop([NotNull] ICard card);

    /// <summary>
    /// Insert one card at the bottom.
    /// </summary>
    /// <param name="card">the card</param>
    public void InsertAtBottom([NotNull] ICard card);

    /// <summary>
    /// Insert cards at the top.
    /// </summary>
    /// <param name="cards">the cards</param>
    public void InsertAtTop([NotNull] NonNullList<ICard> cards);

    /// <summary>
    /// Insert cards at the bottom.
    /// </summary>
    /// <param name="cards">the cards</param>
    public void InsertAtBottom([NotNull] NonNullList<ICard> cards);

    /// <summary>
    /// Gets the first card which meets the filter.
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="isForward">true means starting from the top<br/>false means starting from the bottom</param>
    /// <returns>the card</returns>
    public ICard FindFirst([NotNull] Predicate<ICard> filter, bool isForward = true);

    /// <summary>
    /// Gets all card which meet the filter.
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="isForward">true means starting from the top<br/>false means starting from the bottom</param>
    /// <returns>the cards</returns>
    public NonNullList<ICard> FindAll([NotNull] Predicate<ICard> filter);
}
