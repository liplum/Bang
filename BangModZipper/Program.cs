// See https://aka.ms/new-console-template for more information

//zipper.exe -x <folder name> <mod name> <version>
//-x:
//  -p:Makes a mod pack.
//  -i:Generates a mod info file.
using BangModZipper.Commands;

var manager = new CommandManager();
manager.AddCommand(AllCommands.ZipModPack);
manager.AddCommand(AllCommands.GenerateModPackInfo);

manager.Match(new string[] { "-p" });
