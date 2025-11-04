using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;
public class СoolingSystem : Component
{
    private string _nameCooling;
    private double _size;
    private int _maxTPD;
    private Collection<CPUSocket> _sockets;

    public СoolingSystem(string nameCooling, double size, int maxTPD, Collection<CPUSocket> sockets)
        : base(nameCooling)
    {
        if (size is 0)
        {
            throw new ArgumentException("Size cannot be zero or less", nameof(size));
        }

        if (maxTPD is 0)
        {
            throw new ArgumentException("TPD cannot be zero or less", nameof(maxTPD));
        }

        if (sockets is null)
        {
            throw new ArgumentException("Sockets cannot be null or less", nameof(sockets));
        }

        _nameCooling = nameCooling;
        _size = size;
        _maxTPD = maxTPD;
        _sockets = sockets;
    }
}
