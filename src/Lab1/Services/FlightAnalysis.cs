using System;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Path = Itmo.ObjectOrientedProgramming.Lab1.Entities.Path.Path;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;
public class FlightAnalysis : IFlightAnalysis
{
    private const int MinimalAmountShipsForChoise = 2;
    private double _priceForActivePlasma;
    private double _priceForGravitonMatter;

    public FlightAnalysis(double priceForActivePlasma, double priceForGravitonMatter)
    {
        if (priceForActivePlasma == 0)
        {
            throw new ArgumentException("priceForActivePlasma cannot be null", nameof(priceForActivePlasma));
        }

        if (priceForGravitonMatter == 0)
        {
            throw new ArgumentException("priceForGravitonMatter cannot be null", nameof(priceForGravitonMatter));
        }

        _priceForActivePlasma = priceForActivePlasma;
        _priceForGravitonMatter = priceForGravitonMatter;
    }

    public double PriceForActivePlasma
    {
        get => _priceForActivePlasma;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("price for active plasma cannot be less zero or zero:  ", nameof(value));
            }

            _priceForActivePlasma = value;
        }
    }

    public double PriceForGravitonMatter
    {
        get => _priceForGravitonMatter;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("price for graviton matter cannot be less zero or zero:  ", nameof(value));
            }

            _priceForGravitonMatter = value;
        }
    }

    public ResultOfJourney Analysis(Ship ship, Path path)
    {
        if (ship == null)
        {
            throw new ArgumentException("Ship cannot be null", nameof(ship));
        }

        if (path == null)
        {
            throw new ArgumentException("Path cannot be null", nameof(path));
        }

        return path.AcceptShip(ship);
    }

    public Ship? ChooseBestShip(Collection<Ship> ships, Path path)
    {
        if (ships == null || ships.Count < MinimalAmountShipsForChoise)
        {
            throw new ArgumentException("Ships cannot be null", nameof(ships));
        }

        if (path == null)
        {
            throw new ArgumentException("Path cannot be null", nameof(path));
        }

        var finishedShips = new Collection<Ship>();

        foreach (Ship ship in ships)
        {
            ResultOfJourney shipResult = Analysis(ship, path);

            if (shipResult is Success)
            {
                finishedShips.Add(shipResult.Ship);
            }
        }

        Ship? bestShip = null;

        bestShip = finishedShips.MinBy(ship => (ship.ImpulsiveEngine.Fuel * PriceForActivePlasma) + (ship.JumpEngine == null ? 0 : ship.JumpEngine.Fuel * PriceForGravitonMatter));

        return bestShip;
    }
}
