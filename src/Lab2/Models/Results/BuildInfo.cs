using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;
public abstract class BuildInfo
{
    private string _info;

    protected BuildInfo(string info)
    {
        if (info is null)
        {
            throw new ArgumentException("Info cannot be null", nameof(info));
        }

        _info = info;
    }

    public string Info => _info;
}
