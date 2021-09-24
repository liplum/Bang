using Bang.Core;
using System.Diagnostics.CodeAnalysis;

namespace Bang.Networks;
public interface IMessageChannel
{
    public void SendMessage([NotNull] NetworkToken target, [NotNull] IMessage msg);
    public void SendMessageToAll([NotNull] IMessage msg);

    public string ChannelName
    {
        get;
    }

    public ChannelDirection ChannelDirection
    {
        get;
    }
}

public enum ChannelDirection
{
    ServerToClient, ClientToServer
}

public static class ChannelDirectionHelper
{
    public static bool CanSend([NotNull] this ChannelDirection direction, [NotNull] Side applicationSide)
    {
        if (direction == ChannelDirection.ClientToServer && applicationSide == Side.Client)
        {
            return true;
        }
        if (direction == ChannelDirection.ServerToClient && applicationSide == Side.Server)
        {
            return true;
        }
        return false;
    }
}