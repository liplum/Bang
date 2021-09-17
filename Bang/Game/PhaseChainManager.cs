using System.Diagnostics.CodeAnalysis;

namespace Bang.Games;
public class PhaseChainManager : IPhaseChainManager
{
    [NotNull]
    public readonly PhaseChain _phaseChain = new();

    public int CurrentIndex
    {
        get; private set;
    }

    public int TotalCount => _phaseChain.Count;

    public bool GotoNext()
    {
        return false;
    }
}