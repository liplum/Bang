namespace Bang.Games;
public interface IPhaseChainManager
{
    public int CurrentIndex
    {
        get;
    }

    public bool GotoNext();


    public int LeftoverPhaseCount
    {
        get => TotalCount - CurrentIndex;
    }

    public int TotalCount
    {
        get;
    }

    public bool HasRest
    {
        get => LeftoverPhaseCount > 0;
    }

    public bool IsEnd
    {
        get => !HasRest;
    }
}