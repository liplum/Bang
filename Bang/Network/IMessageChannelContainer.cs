namespace Bang.Networks;
public interface IMessageChannelContainer
{
    public IMessageChannel New(string channelName, ChannelDirection direction);
}
