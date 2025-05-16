using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
public class TreeGotoCommand : BaseCommand
{
    public override void Execute(string[] command, IFileSystem fileSystem)
    {
        string firtsCommand = command[0];
        string secondCommand = command[1];

        if (firtsCommand == "tree" && secondCommand == "goto" && command.Length >= 3)
        {
            string path = command[2];

            if (AbsolutePath.GetTypeOfPath(path) == true || AbsolutePath.GetTypeOfPath(path) == false)
            {
                fileSystem.ShowTreeGoto(path);
            }
        }
        else
        {
            base.Execute(command, fileSystem);
        }
    }
}
