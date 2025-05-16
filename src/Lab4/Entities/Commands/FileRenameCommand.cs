using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
public class FileRenameCommand : BaseCommand
{
    public override void Execute(string[] command, IFileSystem fileSystem)
    {
        string commandName = command[0];

        if (commandName == "rename" && command.Length >= 3)
        {
            string path = command[1];
            string newName = command[2];

            if (AbsolutePath.GetTypeOfPath(path) == true || AbsolutePath.GetTypeOfPath(path) == false)
            {
                fileSystem.Rename(path, newName);
            }
        }
        else
        {
            base.Execute(command, fileSystem);
        }
    }
}
