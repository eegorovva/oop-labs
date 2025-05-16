using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Builder;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services;
public class ManagerFileSystemService
{
    private ConsoleParser _parser;
    private Director? _director;
    private ICommandHandler? _chain;

    public ManagerFileSystemService()
    {
        _parser = new ConsoleParser();
    }

    public IFileSystem? FileSystem => _parser.FileSystem;

    public void SetBuilder(IBuilderHandler builder)
    {
        _director = new Director(builder);
    }

    public void BuildChain()
    {
        if (_director != null)
        {
            _chain = _director.BuildChain();
        }
    }

    public void SetHandler()
    {
        if (_chain != null)
        {
            _parser.SetHanlder(_chain);
        }
    }

    public void Start()
    {
        _parser.Parse();
    }
}
