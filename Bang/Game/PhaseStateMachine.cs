using System.Diagnostics.CodeAnalysis;

namespace Bang.Games;
public class PhaseStateMachine
{
    [NotNull]
    public readonly PhaseChain _phaseChain = new();

    public int CurrentIndex
    {
        get; private set;
    }

    public void GotoNext()
    {

    }

    public int LeftoverPhaseCount
    {
        get => _phaseChain.Count - CurrentIndex;
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