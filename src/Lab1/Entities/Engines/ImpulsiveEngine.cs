using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
public abstract class ImpulsiveEngine : Engine
{
    private double _fuelForStart;

    protected ImpulsiveEngine(double fuelForStart)
    {
        if (fuelForStart <= 0)
        {
            throw new ArgumentException("Fuel for start cannot be zero or less: ", nameof(fuelForStart));
        }

        _fuelForStart = fuelForStart;
    }

    public double FuelForStart => _fuelForStart;

    public void Start()
    {
        ConsumeFuel(FuelForStart);
    }
}
