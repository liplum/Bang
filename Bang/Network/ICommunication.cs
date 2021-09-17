using Bang.Services;
using System.Diagnostics.CodeAnalysis;

namespace Bang.Networks;
public interface ICommunication : IInjectable
{
    public void SendMessageTo([NotNull] NetworkPositionToken target, byte[] data);

    public void SendMessageToAll(byte[] date);
}
