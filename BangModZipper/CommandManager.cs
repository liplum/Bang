using BangModZipper.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Text;

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

    private bool _changed = false;

    public void AddCommand([NotNull] ICommand command)
    {
        _commands[command.Identifier] = command;
        _changed = true;
    }

    public void Match([NotNull] string[] args)
    {
        if (args.Length == 0 || !_commands.TryGetValue(args[0], out var cmd))
        {
            throw new NotMatchException();
        }
        var parameters = args.Length == 1 ? Array.Empty<string>() : args[1..^1];
        cmd.Execute(parameters);
    }

    private void GenHelp()
    {
        var str = new StringBuilder();
        foreach (var cmd in from c in _commands.Values orderby c.Identifier select c)
        {
            str.Append($"{cmd.Identifier} {cmd.Name} \n\t{cmd.Description}\n\n");
        }
        _help = str.ToString();
        _changed = false;
    }

    private string _help = string.Empty;

    public string Help
    {
        get
        {
            if (_changed)
            {
                GenHelp();
            }
            return _help;
        }
    }
}
