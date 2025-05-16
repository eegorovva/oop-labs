using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;
public class CoolingSystem : Component
{
    private double _lenght;
    private double _width;
    private double _height;
    private int _maxTPD;
    private Collection<CPUSocket> _sockets;

    public CoolingSystem(string name, double lenght, double width, double height, int maxTPD, Collection<CPUSocket> sockets)
        : base(name)
    {
        if (lenght is 0)
        {
            throw new ArgumentException("lenght cannot be zero or less", nameof(lenght));
        }

        if (width is 0)
        {
            throw new ArgumentException("width cannot be zero or less", nameof(width));
        }

        if (height is 0)
        {
            throw new ArgumentException("height cannot be zero or less", nameof(height));
        }

        if (maxTPD is 0)
        {
            throw new ArgumentException("TPD cannot be zero or less", nameof(maxTPD));
        }

        if (sockets is null)
        {
            throw new ArgumentException("Sockets cannot be null or less", nameof(sockets));
        }

        _height = height;
        _width = width;
        _lenght = lenght;
        _maxTPD = maxTPD;
        _sockets = sockets;
    }

    public Collection<CPUSocket> Sockets => _sockets;
    public int TPD => _maxTPD;
    public double Height => _height;
    public double Width => _width;
    public double Lenght => _lenght;
}
