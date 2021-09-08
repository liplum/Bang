namespace BangModZipper.Exceptions;


[Serializable]
public class CommandException : Exception
{

}


[Serializable]
public class CommandWrongUsingException : CommandException
{
    public CommandWrongUsingException(int wrongParameterIndex, string tip)
    {
        WrongParameterIndex = wrongParameterIndex;
        Tip = tip;
    }

    public string Tip
    {
        get; init;
    }

    public int WrongParameterIndex
    {
        get; init;
    }
}


[Serializable]
public class NotMatchException : Exception
{
    public NotMatchException() { }
}