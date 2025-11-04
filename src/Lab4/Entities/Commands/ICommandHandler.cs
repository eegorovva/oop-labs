using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public interface ICommandHandler
{
    ICommandHandler SetNextCommand(ICommandHandler command);
    void Execute(string[] command, IFileSystem fileSystem);
}
