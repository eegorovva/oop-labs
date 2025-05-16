using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class Engine
{
    private double _consumedFuel;
    public double Fuel => _consumedFuel;
    public void ConsumeFuel(double fuelToAdd)
    {
        if (fuelToAdd <= 0)
        {
            throw new ArgumentException("Fuel for add cannot be less or zero: ", nameof(fuelToAdd));
        }

        _consumedFuel += fuelToAdd;
    }

    public abstract void Work(double distance);
}