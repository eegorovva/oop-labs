using System;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class SpaceEnvironment : Environment
{
    public SpaceEnvironment(double distance, Collection<IObstacle>? obstacles = null)
        : base(distance, obstacles)
    {
        if (obstacles != null && obstacles.FirstOrDefault(obst => obst is not AsteroidObstacle && obst is not MeteoritObstacle) != null)
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

        ship.ImpulsiveEngine.Work(Distance);

        return new Success(ship);
    }
}