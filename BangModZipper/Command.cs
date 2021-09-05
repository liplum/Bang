using System.Diagnostics.CodeAnalysis;

namespace BangModZipper.Commands;
public interface ICommand
{
    public string Identifier
    {
        get;
    }

    public string Name { get; }

    public string Description { get; }

    public void Execute(string[] args);

}

public delegate void ExecuteBehavior(string[] args);

public class Command : ICommand
{
    public Command([NotNull] string identifier, [NotNull] string name, [NotNull] string description, [AllowNull] ExecuteBehavior behavior = null)
    {
        Identifier = identifier;
        Name = name;
        Description = description;
        Behavior = behavior;
    }

    private ExecuteBehavior? Behavior { get; init; }

    public string Identifier
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
