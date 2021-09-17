namespace Bang.Games;
public class TurnManager
{
    public Turn? CurrentTurn
    {
        get;
    }

    public IPlayer ControlPowerOwner
    {
        get;
    }
}
