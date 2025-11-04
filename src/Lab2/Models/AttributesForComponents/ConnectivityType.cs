using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.AttributesForComponents;

public abstract class ConnectivityType
{
    private string _name;

    protected ConnectivityType(string name)
    {
        if (name is null)
        {
            throw new ArgumentException("Name cannot be null: ", nameof(name));
        }

        _name = name;
    }

    public string NameType => _name;
}
