using System.Diagnostics.CodeAnalysis;
using static BangModZipper.ICommand;

namespace BangModZipper;
public interface ICommand
{
    public string Identify
    {
        get;
    }

    public string Name { get; }

    public string Description { get; }

    public void Execute(string[] args);

    public delegate void ExecuteBehavior(string[] args);
}

public class Command : ICommand
{
    public Command([NotNull] string identify, [NotNull] string name, [NotNull] string description, [AllowNull] ExecuteBehavior behavior = null)
    {
        Identify = identify;
        Name = name;
        Description = description;
        Behavior = behavior;
    }

    public ExecuteBehavior? Behavior { get; init; }

    public string Identify
    {
        get; init;
    }

    public string Name
    {
        get; init;
    }

    public string Description
    {
        get; init;
    }

    public virtual void Execute(string[] args)
    {
        Behavior?.Invoke(args);
    }
}
