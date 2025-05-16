using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class ImpulsiveEngineClassC : ImpulsiveEngine
{
    private const double FuelForStartEngineC = 10;

    public ImpulsiveEngineClassC()
        : base(FuelForStartEngineC)
    {
    }

    public override void Work(double distance)
    {
        if (distance <= 0)
        {
            throw new ArgumentException("Distance cannot be zero or less: ", nameof(distance));
        }

        Start();
        ConsumeFuel(distance);
    }
}