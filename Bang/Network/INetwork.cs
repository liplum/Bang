using Bang.Services;
using System.Diagnostics.CodeAnalysis;

namespace Bang.Networks;
public interface INetwork : IInjectable, IMessageChannelContainer
{
    public void SendDatapackTo([NotNull] IDatapack datapack, [NotNull] NetworkToken token);

    public void RecevieDatapack([NotNull] IDatapack datapack);
}
