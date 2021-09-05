namespace BangModZipper.Exceptions;


[Serializable]
public class CommandException : Exception
{

}


[Serializable]
public class CommandWrongUsingException : CommandException
{
    public CommandWrongUsingException(int wrongParameterIndex)
    {
        WrongParameterIndex = wrongParameterIndex;
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