using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Builder;
public interface IBuilderHandler
{
    public ICommandHandler SetDelete();
    public ICommandHandler SetMove();
    public ICommandHandler SetRename();
    public ICommandHandler SetShow();
    public ICommandHandler SetCopy();
    public ICommandHandler BuildChain();
    public ICommandHandler SetTreeList();
}
