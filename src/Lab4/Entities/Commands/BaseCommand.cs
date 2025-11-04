using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

    public abstract class BaseCommand : ICommandHandler
    {
        private ICommandHandler? _nextCommand;

        public ICommandHandler SetNextCommand(ICommandHandler command)
        {
            _nextCommand = command;

            return command;
        }

        public virtual void Execute(string[] command, IFileSystem fileSystem)
        {
            _nextCommand?.Execute(command, fileSystem);
        }
    }