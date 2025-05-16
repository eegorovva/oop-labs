using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
public class ImpulsiveEngineClassE : ImpulsiveEngine
{
    private const double FuelForStartEngineC = 30;

    public ImpulsiveEngineClassE()
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
        ConsumeFuel(Math.Pow(2, distance / 100));
    }
}
