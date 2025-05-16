using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Environment = Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Path;
public class Path
{
    private Collection<Environment> _path;

    public Path(Collection<Environment> path)
    {
        if (path == null || path.Count == 0)
        {
            throw new ArgumentException("Path cannot be null: ", nameof(path));
        }

        _path = path;
    }

    public ResultOfJourney AcceptShip(Ship ship)
    {
        if (ship == null)
        {
            throw new ArgumentException("Ship cannot be null: ", nameof(ship));
        }

        ResultOfJourney result = new Success(ship);

        foreach (Environment environment in _path)
        {
            result = environment.PassObstacles(ship);

            if (result is not Success)
            {
                return result;
            }

            result = environment.PassDistance(ship);

            if (result is not Success)
            {
                return result;
            }
        }

        return result;
    }
}
