using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
public class FileCopyCommand : BaseCommand
{
    public override void Execute(string[] command, IFileSystem fileSystem)
    {
        string commandName = command[0];

        if (commandName == "copy" && command.Length >= 3)
        {
            string sourcePath = command[1];
            string destinationPath = command[2];

            if (AbsolutePath.GetTypeOfPath(sourcePath) == true || AbsolutePath.GetTypeOfPath(sourcePath) == false)
            {
                fileSystem.CopyFile(sourcePath, destinationPath);
            }
        }
        else
        {
            base.Execute(command, fileSystem);
        }
    }
}
