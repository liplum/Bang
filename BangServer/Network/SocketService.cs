using Bang.Networks;
using Bang.Services;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;

namespace BangServer.Networks;
public class SocketService : ICommunication
{
    private readonly Dictionary<NetworkPositionToken, Socket> _allClient = new();

    public void Initialize(IServiceProvider serviceProvider)
    {

    }

    public void SendMessageTo([NotNull] NetworkPositionToken target, byte[] data)
    {

    }

    public void SendMessageToAll(byte[] date)
    {

    }

    public void Connet()
    {

    }
}
