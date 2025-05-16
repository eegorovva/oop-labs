using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
public class TreeListCommand : BaseCommand
{
    public override void Execute(string[] command, IFileSystem fileSystem)
    {
        string firtsCommand = command[0];
        string secondCommand = command[1];

        if (firtsCommand == "tree" && secondCommand == "list" && command.Length >= 3)
        {
            string path = command[2];

            if (AbsolutePath.GetTypeOfPath(path) == true || AbsolutePath.GetTypeOfPath(path) == false)
            {
                fileSystem.ShowTreeList(path);
            }
        }
        else
        {
            base.Execute(command, fileSystem);
        }
    }
}
