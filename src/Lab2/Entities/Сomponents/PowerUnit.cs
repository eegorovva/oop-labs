using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;
public class PowerUnit : Component
{
    private const int MinPower = 300;
    private int _maxPower;

    public PowerUnit(string name, int maxPower)
        : base(name)
    {
        if (maxPower < MinPower)
        {
            throw new ArgumentException("Power cannot be less than 300-watt", nameof(maxPower));
        }

        _maxPower = maxPower;
    }

    public int MaxPower => _maxPower;
}
