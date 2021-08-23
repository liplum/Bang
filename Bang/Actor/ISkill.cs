using System.Diagnostics.CodeAnalysis;
using Bang.Game;

namespace Bang.Actor;
public interface ISkill
{
    public bool CanUse([NotNull] IPhase phase);
}
