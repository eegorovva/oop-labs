using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Builder;
public class BuilderHandler : IBuilderHandler
{
    private FileCopyCommand _copy;
    private FileDeleteCommand _delete;
    private FileRenameCommand _rename;
    private FileShowCommand _show;
    private FileMoveCommand _move;
    private TreeListCommand _treeList;
    private TreeGotoCommand _treegoto;

    public BuilderHandler(FileCopyCommand copy, FileDeleteCommand delete, FileMoveCommand move, FileRenameCommand rename, FileShowCommand show, TreeListCommand treeList, TreeGotoCommand treegoto)
    {
        if (copy is null)
        {
            throw new ArgumentException("Copy cannot be null", nameof(copy));
        }

        if (delete is null)
        {
            throw new ArgumentException("delete cannot be null", nameof(delete));
        }

        if (move is null)
        {
            throw new ArgumentException("move cannot be null", nameof(move));
        }

        if (rename is null)
        {
            throw new ArgumentException("rename cannot be null", nameof(rename));
        }

        if (treeList is null)
        {
            throw new ArgumentException("tree list cannot be null", nameof(treeList));
        }

        if (treegoto is null)
        {
            throw new ArgumentException("tree goto cannot be null", nameof(treegoto));
        }

        _copy = copy;
        _delete = delete;
        _rename = rename;
        _move = move;
        _show = show;
        _treeList = treeList;
        _treegoto = treegoto;
    }

    public ICommandHandler SetCopy()
    {
        _copy.SetNextCommand(_delete);
        return _copy;
    }

    public ICommandHandler SetDelete()
    {
        _delete.SetNextCommand(_move);
        return _delete;
    }

    public ICommandHandler SetMove()
    {
        _move.SetNextCommand(_rename);
        return _move;
    }

    public ICommandHandler SetRename()
    {
        _rename.SetNextCommand(_show);
        return _rename;
    }

    public ICommandHandler SetShow()
    {
        _show.SetNextCommand(_treeList);
        return _show;
    }

    public ICommandHandler SetTreeList()
    {
        _treeList.SetNextCommand(_treegoto);
        return _treeList;
    }

    public ICommandHandler BuildChain()
    {
        return _copy;
    }
}
