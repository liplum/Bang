﻿using Bang.Core;
using Bang.Services;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Bang.Networks;
public class Network : INetwork
{
    private readonly Dictionary<string, IMessageChannel> _allChannels = new();
    private IConnection? _network;
    private BangGame? _bang;

    public void Initialize(IServiceProvider serviceProvider)
    {
        _network = serviceProvider.Reslove<IConnection>();
        _bang = serviceProvider.Reslove<BangGame>();
    }

    public IMessageChannel? this[string channelName]
    {
        get => _allChannels.TryGetValue(channelName, out var channel) ? channel : null;
    }

    public IMessageChannel New(string channelName, ChannelDirection direction)
    {
        var channel = new MessageChannel(this, channelName, direction);
        _allChannels[channelName] = channel;
        return channel;
    }

    private void SendMessage([NotNull] NetworkToken target, [NotNull] IMessage msg)
    {
        var buf = new ByteBuffer();
        msg.Serialize(buf);
        _network!.SendMessageTo(target, buf.ToByteArray());
    }

    private void SendMessageToAll([NotNull] IMessage msg)
    {
        var buf = new ByteBuffer();
        msg.Serialize(buf);
        _network!.SendMessageToAll(buf.ToByteArray());
    }

    public void SendDatapackTo([NotNull] IDatapack datapack, [NotNull] NetworkToken token)
    {
        throw new System.NotImplementedException();
    }

    public void RecevieDatapack([NotNull] IDatapack datapack)
    {
        throw new System.NotImplementedException();
    }

    private class MessageChannel : IMessageChannel
    {
        public Network Outter
        {
            get; init;
        }
        public MessageChannel([NotNull] Network outter, [NotNull] string channelName, [NotNull] ChannelDirection channelDirection)
        {
            Outter = outter;
            ChannelName = channelName;
            ChannelDirection = channelDirection;
        }

        public string ChannelName
        {
            get; init;
        }

        public ChannelDirection ChannelDirection
        {
            get; init;
        }

        public void SendMessage([NotNull] NetworkToken target, [NotNull] IMessage msg)
        {
            if (ChannelDirection.CanSend(Outter._bang!.ApplicationSide))
            {
                Outter.SendMessage(target, msg);
            }
        }

        public void SendMessageToAll([NotNull] IMessage msg)
        {
            if (ChannelDirection.CanSend(Outter._bang!.ApplicationSide))
            {
                Outter.SendMessageToAll(msg);
            }
        }
    }
}
