using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
public class FileShowCommand : BaseCommand
{
    public override void Execute(string[] command, IFileSystem fileSystem)
    {
        string commandName = command[0];

        if (commandName == "show" && command.Length >= 3)
        {
            string path = command[1];
            string mode = command[2];

            if (AbsolutePath.GetTypeOfPath(path) == true || AbsolutePath.GetTypeOfPath(path) == false)
            {
                fileSystem.Show(path, mode);
            }
        }
        else
        {
            base.Execute(command, fileSystem);
        }
    }
}
