using System.Diagnostics.CodeAnalysis;

namespace Bang.Networks;
public interface IMessage
{
    public void Serialize(IReadableBuffer buffer);

    public void Deserialize(IWritableBuffer buffer);
}

public interface IMessageHandler<T> where T : IMessage
{

    public void Handler([NotNull] T msg);

}