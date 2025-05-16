using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class CosmoWhaleObstacle : IObstacle
{
    private const int CriticalDamage = 100000;
    private const int MaxWeight = 1000;
    private const int MinWeight = 500;

    private int _weight;

    public CosmoWhaleObstacle(int weight)
    {
        if (weight < MinWeight || weight > MaxWeight)
        {
            throw new ArgumentException("Weight cannot be less than 500 or more than 1000 ", nameof(weight));
        }

        _weight = weight;
    }

    public ResultOfJourney CollideShip(Ship ship)
    {
        if (ship == null)
        {
            throw new ArgumentException("Ship cannot be null", nameof(ship));
        }

        if (ship.IsDestroyed())
        {
            throw new ArgumentException("Ship already destroyed: ", nameof(ship));
        }

        if (ship.FindEmitter() == false)
        {
            if (ship.IsDeflectorWorking() == false)
            {
                ship.GetDamage(CriticalDamage);
            }

            ship.GetDamage(_weight);
        }

        if (ship.IsDestroyed())
        {
            return new DestroyShip(ship, this);
        }

        return new Success(ship);
    }
}