using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
public class JumpEngineAlpha : JumpEngine
{
    private const double MaxDistanceEngineAlpha = 500;
    private const double FuelCoefficent = 10;

    public JumpEngineAlpha()
        : base(MaxDistanceEngineAlpha)
    {
    }

    public override void Work(double distance)
    {
        if (distance <= 0)
        {
            throw new ArgumentException("Distance cannot be zero or less ", nameof(distance));
        }

        if (distance > MaxDistanceEngineAlpha)
        {
            throw new ArgumentException("Distance cannot be more than max distance: ", nameof(distance));
        }

        ConsumeFuel(distance * FuelCoefficent);
    }
}
