using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class MeteoritObstacle : IObstacle
{
    private const int MaxWeight = 100;
    private const int MinWeight = 51;

    private int _weight;

    public MeteoritObstacle(int weight)
    {
        if (weight < MinWeight || weight > MaxWeight)
        {
            throw new ArgumentException("Weight cannot be less than 51 or more than 100 ", nameof(weight));
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

        ship.GetDamage(_weight);

        if (ship.IsDestroyed())
        {
            return new DestroyShip(ship, this);
        }

        return new Success(ship);
    }
}