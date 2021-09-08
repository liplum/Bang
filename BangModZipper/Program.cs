//zipper.exe -x <folder name> <mod name> <version>
//-x:
//  -p:Makes a mod pack.
//  -i:Generates a mod info file.
using BangLib.Strings;
using BangModZipper.Commands;
using BangModZipper.Exceptions;
using System.Text;

var manager = new CommandManager();
manager.AddCommand(AllCommands.ZipModPack);
manager.AddCommand(AllCommands.GenerateModPackInfo);

var cmd = Console.ReadLine();
string[] paras = cmd?.Split(" ") ?? Array.Empty<string>();

try
{
    manager.Match(paras);
}
catch (NotMatchException)
{
    Console.WriteLine($"{cmd} was not match any command.");
    Console.WriteLine(manager.Help);
}
catch (CommandWrongUsingException e)
{
    var index = e.WrongParameterIndex;
    Console.WriteLine(e.Tip);
    Console.WriteLine(cmd);
    var str = new StringBuilder();
    for (int i = 0; i <= index; i++)
    {
        str.Append(" ".Repeat(paras[i].Length) + " ");
    }
    str.Append('^');
    Console.WriteLine(str.ToString());
    Console.WriteLine(manager.Help);
}
