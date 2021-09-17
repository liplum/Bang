using Bang.Actor;
using System.Collections.Generic;

namespace Bang.Games;
public class Battle : IBattle
{
    private readonly HashSet<IPlayer> _allPlayers = new();
    private readonly HashSet<IActor> _allActors = new();
    private ITurnManager TurnManager
    {
        get;
    }

    public void SkipToNextPlayer()
    {

    }
}
