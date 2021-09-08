using Bang.Mods;
using Bang.Services;
using System.Diagnostics.CodeAnalysis;

namespace Bang.Core;
public interface IModManager : IInjectable
{
    public void LoadMod([NotNull] FileInfo modFile);

    public void UnloadMod([NotNull] ModEntry mod);

    public void UnloadMod([NotNull] string modName);
}
