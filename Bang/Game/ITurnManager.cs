namespace Bang.Games;
public interface ITurnManager
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
