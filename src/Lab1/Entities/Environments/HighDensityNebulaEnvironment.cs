using System;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class HighDensityNebulaEnvironment : Environment
{
    public HighDensityNebulaEnvironment(double distanceForChannel, Collection<IObstacle>? obstacles = null)
        : base(distanceForChannel, obstacles)
    {
        if (obstacles != null && obstacles.FirstOrDefault(obst => obst is not AntimatterFlashObstacle) != null)
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

        if (ship.JumpEngine == null || ship.JumpEngine.LimitForDistance < Distance)
        {
            return new LostShip(ship);
        }

        ship.JumpEngine.Work(Distance);

        return new Success(ship);
    }
}