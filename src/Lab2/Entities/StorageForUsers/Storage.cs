using System;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repoz;
public class Storage
{
    private Collection<Component> _components;
    private Collection<Computer> _computers;

    public Storage()
    {
        _components = new Collection<Component>();
        _computers = new Collection<Computer>();
    }

    public Component? FindComponent(string name)
    {
        if (name is null)
        {
            throw new ArgumentException("Name cannot be null ", nameof(name));
        }

        if (_components.FirstOrDefault(c => c.Name == name) == null)
        {
            return null;
        }

        return _components.FirstOrDefault(comp => comp.Name == name);
    }

    public Computer? FindComputer(string name)
    {
        if (name is null)
        {
            throw new ArgumentException("Name cannot be null ", nameof(name));
        }

        if (_computers.FirstOrDefault(c => c.Name == name) == null)
        {
            return null;
        }

        return _computers.FirstOrDefault(pc => pc.Name == name);
    }

    public void AddComponent(Component component)
    {
        if (component is null)
        {
            throw new ArgumentException("Component cannot be null ", nameof(component));
        }

        if (FindComponent(component.Name) != null)
        {
            throw new ArgumentException("Component already exist", nameof(component));
        }

        _components.Add(component);
    }

    public void AddComputer(Computer computer)
    {
        if (computer is null)
        {
            throw new ArgumentException("Computer cannot be null ", nameof(computer));
        }

        if (FindComponent(computer.Name) != null)
        {
            throw new ArgumentException("Computer already exist", nameof(computer));
        }

        _computers.Add(computer);
    }

    public Component GetComponent(string name)
    {
        Component? componentFound = FindComponent(name);

        if (componentFound == null)
        {
            throw new ArgumentException($"Component does not exist {name}");
        }

        return componentFound;
    }

    public Computer GetComputer(string name)
    {
        Computer? computerFound = FindComputer(name);

        if (computerFound == null)
        {
            throw new ArgumentException($"Computer does not exist {name}");
        }

        return computerFound;
    }
}
