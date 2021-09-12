using System.Diagnostics.CodeAnalysis;
using Bang.Games;

namespace Bang.Actor;
public interface ISkill
{
    public bool CanUse([NotNull] IPhase phase);
}
