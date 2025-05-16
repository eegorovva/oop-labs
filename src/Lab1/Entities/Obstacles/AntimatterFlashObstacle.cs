using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class AntimatterFlashObstacle : IObstacle
{
    private int _flash;

    public AntimatterFlashObstacle(int flash)
    {
        _flash = flash;
    }

    public ResultOfJourney CollideShip(Ship ship)
    {
        if (ship == null)
        {
            throw new ArgumentException("Ship cannot be null", nameof(ship));
        }

        if (ship.PhotonDeflector == null || ship.PhotonDeflector.Charges < _flash)
        {
            return new DeathOfTheCrew(ship);
        }

        ship.ActivatePhotonDeflector();

        return new Success(ship);
    }
}