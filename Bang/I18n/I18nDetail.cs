namespace Bang.I18ns;
public class I18nDetail
{
    public Dictionary<string, string> AllDetails
    {
        get; init;
    } = new();

    public void Clear()
    {
        AllDetails.Clear();
    }

    public string? this[string unlocalizedName]
    {
        get
        {
            if (AllDetails.TryGetValue(unlocalizedName, out var res))
            {
                return res;
            }
            return null;
        }
    }
}
