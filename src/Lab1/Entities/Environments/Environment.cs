using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public abstract class Environment
{
    private double _distance;
    private Collection<IObstacle>? _obstacles;

    protected Environment(double distance, Collection<IObstacle>? obstacles = null)
    {
        if (distance <= 0)
        {
            throw new ArgumentException("Distance cannot be zero or less:  ", nameof(distance));
        }

        if (obstacles != null && obstacles.Count == 0)
        {
            throw new ArgumentException("Obstacles cannot be null or less:  ", nameof(obstacles));
        }

        _distance = distance;
        _obstacles = obstacles;
    }

    public double Distance => _distance;

    public ResultOfJourney PassObstacles(Ship ship)
    {
        if (ship == null)
        {
            throw new ArgumentException("Ship cannot be null: ", nameof(ship));
        }

        if (_obstacles == null)
        {
            return new Success(ship);
        }

        foreach (IObstacle obstacle in _obstacles)
        {
            ResultOfJourney resultOfCollideWithShip = obstacle.CollideShip(ship);

            if (resultOfCollideWithShip is not Success)
            {
                return resultOfCollideWithShip;
            }
        }

        return new Success(ship);
    }

    public abstract ResultOfJourney PassDistance(Ship ship);
}