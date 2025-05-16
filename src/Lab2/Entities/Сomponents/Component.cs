using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;
public abstract class Component
{
    private string _name;

    protected Component(string name)
    {
        if (name is null)
        {
            throw new ArgumentException("Name cannot be null or less ", nameof(name));
        }

        _name = name;
    }

    public string Name => _name;
}
