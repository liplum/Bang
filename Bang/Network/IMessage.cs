namespace Bang.Networks;
public interface IMessage
{
    public void Serialize(IBuffer cahce);

    public void Deserialize(IBuffer cache);
}
