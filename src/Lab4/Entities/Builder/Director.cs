using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Builder;
public class Director
{
    private IBuilderHandler _builder;

    public Director(IBuilderHandler builder)
    {
        if (builder is null)
        {
            throw new ArgumentException("builder cannot be null", nameof(builder));
        }

        _builder = builder;
    }

    public ICommandHandler BuildChain()
    {
        _builder.SetCopy();
        _builder.SetDelete();
        _builder.SetMove();
        _builder.SetRename();
        _builder.SetShow();
        _builder.SetTreeList();

        return _builder.BuildChain();
    }
}
