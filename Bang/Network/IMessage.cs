namespace Bang.Networks;
public interface IMessage
{
    public void Serialize(IReadableBuffer buffer);

    public void Deserialize(IWritableBuffer buffer);
}
