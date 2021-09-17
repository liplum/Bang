namespace Bang.Games;
public class PhaseStateMachine
{
    private readonly Stack<IPhaseChainManager> _phaseChains = new();

    public IPhaseChainManager? CurrentPhaseChain
    {
        get => _phaseChains.TryPeek(out var res) ? res : null;
    }

    public bool HasAnyPhaseChain
    {
        get => _phaseChains.Count > 0;
    }

    public bool IsCurrentPhaseChainEnd
    {
        get => CurrentPhaseChain?.IsEnd ?? true;
    }

    public bool RemoveCurrent()
    {
        if (HasAnyPhaseChain)
        {
            _phaseChains.Pop();
        }
        return false;
    }

    public void AddNewPhaseChain(IPhaseChainManager phaseChainManager)
    {
        _phaseChains.Push(phaseChainManager);
    }

}