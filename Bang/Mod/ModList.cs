using System.Diagnostics.CodeAnalysis;

namespace Bang.Mods;
public class ModList
{
    private readonly HashSet<ModEntry> _mods = new();
    public void Add([NotNull] ModEntry mod)
    {
        _mods.Add(mod);
    }

    public bool Remove([NotNull] ModEntry mod)
    {
        return _mods.Remove(mod);
    }

    public bool Remove([NotNull] string modName)
    {
        var removedCount = _mods.RemoveWhere(mod => modName.Equals(mod.Info?.Name));
        return removedCount >= 1;
    }

    public bool HasMod([NotNull] string modName)
    {
        foreach (var mod in _mods)
        {
            if (modName.Equals(mod.Info?.Name))
            {
                return true;
            }
        }
        return false;
    }
}
