using System;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class NebulaOfNitrineParticlesEnvironment : Environment
{
    private const double ReducedEffectForEngine = 5;

    public NebulaOfNitrineParticlesEnvironment(double distance, Collection<IObstacle>? obstacles = null)
        : base(distance, obstacles)
    {
        if (obstacles != null && obstacles.FirstOrDefault(obst => obst is not CosmoWhaleObstacle) != null)
        {
            throw new ArgumentException("The type of obstacle cannot be in this environment: ", nameof(obstacles));
        }
    }

    public override ResultOfJourney PassDistance(Ship ship)
    {
        if (ship == null)
        {
            throw new ArgumentException("Ship cannot be null or less: ", nameof(ship));
        }

        if (ship.ImpulsiveEngine is ImpulsiveEngineClassE)
        {
            ship.ImpulsiveEngine.Work(Distance);
        }
        else
        {
            ship.ImpulsiveEngine.Work(Distance * ReducedEffectForEngine);
        }

        return new Success(ship);
    }
}