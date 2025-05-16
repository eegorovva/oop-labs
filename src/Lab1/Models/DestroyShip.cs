using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;
public class DestroyShip : ResultOfJourney
{
    private const string Message = "Ship was destroyed";
    private IObstacle _obstacle;

    public DestroyShip(Ship ship, IObstacle obstacles)
        : base(Message, ship)
    {
        if (obstacles == null)
        {
            throw new ArgumentException("Obstacles cannot be null or less: ", nameof(obstacles));
        }

        _obstacle = obstacles;
    }

    public IObstacle Obstacles => _obstacle;
}