using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
public class FileDeleteCommand : BaseCommand
{
    public override void Execute(string[] command, IFileSystem fileSystem)
    {
        string commandName = command[0];

        if (commandName == "delete" && command.Length >= 2)
        {
            string path = command[1];

            if (AbsolutePath.GetTypeOfPath(path) == true || AbsolutePath.GetTypeOfPath(path) == false)
            {
                fileSystem.Delete(path);
            }
        }
        else
        {
            base.Execute(command, fileSystem);
        }
    }
}
