using BangModZipper.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace BangModZipper.Commands;

public interface ICommandManager
{
    public void AddCommand([NotNull] ICommand command);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <exception cref="NotMatchException"></exception>
    /// <exception cref="CommandException"></exception>
    public void Match([NotNull] string[] args);
}

public class CommandManager : ICommandManager
{
    private readonly Dictionary<string, ICommand> _commands = new();
    public void AddCommand([NotNull] ICommand command)
    {
        _commands[command.Identifier] = command;
    }

    public void Match([NotNull] string[] args)
    {
        if (args.Length == 0 || !_commands.TryGetValue(args[0], out var cmd))
        {
            throw new NotMatchException();
        }
        var parameters = args.Length == 1 ? Array.Empty<string>() : args[1..-1];
        cmd.Execute(parameters);
    }
}
