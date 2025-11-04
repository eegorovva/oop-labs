using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Builder;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Test
{
    private ManagerFileSystemService _serives;
    private Collection<BaseCommand> _commands;

    public Test()
    {
        _serives = new ManagerFileSystemService();

        var copy = new FileCopyCommand();
        var delete = new FileDeleteCommand();
        var move = new FileMoveCommand();
        var rename = new FileRenameCommand();
        var show = new FileShowCommand();
        var treelist = new TreeListCommand();
        var treeGoto = new TreeGotoCommand();

        var builder = new BuilderHandler(copy, delete, move, rename, show, treelist, treeGoto);

        _serives.SetBuilder(builder);
        _serives.BuildChain();
        _serives.SetHandler();

        _commands = new Collection<BaseCommand>();
        _commands.Add(copy);
        _commands.Add(delete);
        _commands.Add(move);
        _commands.Add(rename);
        _commands.Add(show);
        _commands.Add(treelist);
        _commands.Add(treeGoto);
    }

    [Fact]
    public void CheckRenameCommand()
    {
        string inputString = "connect C:\\ -m local\nrename C:\\filee.txt file2.txt\ndisconnect";
        var input = new StringReader(inputString);

        System.Console.SetIn(input);

        _serives.Start();

        var renameCommand = _commands.FirstOrDefault(c => c is FileRenameCommand) as FileRenameCommand;

        Assert.NotNull(renameCommand);
    }

    [Fact]
    public void CheckCopyCommand()
    {
        string inputString = "connect C:\\ -m local\ncopy C:\\file2.txt C:\\Game\ndisconnect";
        var input = new StringReader(inputString);

        System.Console.SetIn(input);

        _serives.Start();

        var copy = _commands.FirstOrDefault(c => c is FileCopyCommand) as FileCopyCommand;

        Assert.NotNull(copy);
    }

    [Fact]
    public void CheckDeleteCommand()
    {
        string inputString = "connect C:\\ -m local\ndelete C:\\file3.txt\ndisconnect";
        var input = new StringReader(inputString);

        System.Console.SetIn(input);

        _serives.Start();

        var delete = _commands.FirstOrDefault(c => c is FileDeleteCommand) as FileDeleteCommand;

        Assert.NotNull(delete);
    }

    [Fact]
    public void CheckMoveCommand()
    {
        string inputString = "connect C:\\ -m local\nmove C:\\file4.txt C:\\Game\ndisconnect";
        var input = new StringReader(inputString);

        System.Console.SetIn(input);

        _serives.Start();

        var move = _commands.FirstOrDefault(c => c is FileMoveCommand) as FileMoveCommand;

        Assert.NotNull(move);
    }

    [Fact]
    public void CheckTreeGotoCommand()
    {
        string inputString = "connect C:\\ -m local\tree goto C:\\Game\ndisconnect";
        var input = new StringReader(inputString);

        System.Console.SetIn(input);

        _serives.Start();

        var treegoto = _commands.FirstOrDefault(c => c is TreeGotoCommand) as TreeGotoCommand;

        Assert.NotNull(treegoto);
    }

    [Fact]
    public void CheckConnectCommand()
    {
        string inputString = "connect C:\\ -m local\ndisconnect";
        var input = new StringReader(inputString);

        System.Console.SetIn(input);

        _serives.Start();

        Assert.NotNull(_serives.FileSystem);
        Assert.IsType<LocalFileSystem>(_serives.FileSystem);
    }

    [Fact]
    public void CheckTreeListCommand()
    {
        string inputString = "connect C:\\ -m local\tree list C:\\Game\ndisconnect";
        var input = new StringReader(inputString);

        System.Console.SetIn(input);

        _serives.Start();

        var treelist = _commands.FirstOrDefault(c => c is TreeListCommand) as TreeListCommand;

        Assert.NotNull(treelist);
    }
}
