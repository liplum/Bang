using System.Diagnostics.CodeAnalysis;

namespace Bang.Games;
public class PhaseChain
{
    [NotNull]
    public readonly LinkedList<IPhase> _allPhase = new();

    public void InsertPhase(int index, [NotNull] IPhase phase)
    {
        if (index <= 0)
        {
            InsertHead(phase);
        }
        else if (index >= _allPhase.Count - 1)
        {
            InsertLast(phase);
        }
        else
        {
            var first = _allPhase.First;
            var currentNode = first;
            for (int i = 0; i < index + 1; i++)
            {
                currentNode = currentNode?.Next;
            }
            if (currentNode is not null)
            {
                _allPhase.AddAfter(currentNode, phase);
            }
        }
    }

    public void InsertLast([NotNull] IPhase phase)
    {
        _allPhase.AddLast(phase);
    }
    public void InsertHead([NotNull] IPhase phase)
    {
        _allPhase.AddFirst(phase);
    }

    public int Count
    {
        get => _allPhase.Count;
    }
}