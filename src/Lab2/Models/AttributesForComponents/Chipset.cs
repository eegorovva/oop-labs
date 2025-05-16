using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.AttributesForComponents;
public class Chipset
{
    private string _name;
    private int _minFrequency;
    private int _maxFrequency;
    private XMP? _xmp;
    private DOCP? _docp;

    public Chipset(string name, int minFrequency, int maxFrequency, XMP? xmp, DOCP? docp)
    {
        if (name is null)
        {
            throw new ArgumentException("Name cannot be null", nameof(name));
        }

        if (minFrequency <= 0)
        {
            throw new ArgumentException("Frequency cannot be less or zero", nameof(minFrequency));
        }

        if (maxFrequency <= 0)
        {
            throw new ArgumentException("Frequency cannot be less or zero", nameof(maxFrequency));
        }

        _name = name;
        _minFrequency = minFrequency;
        _maxFrequency = maxFrequency;
        _xmp = xmp;
        _docp = docp;
    }

    public int MinFrequency => _minFrequency;
    public int MaxFrequency => _maxFrequency;
    public XMP? Xmp => _xmp;
    public DOCP? Docp => _docp;
}
