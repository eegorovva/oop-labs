using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Path;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;
public interface IFlightAnalysis
{
    public double PriceForActivePlasma { get; set; }

    public double PriceForGravitonMatter { get; set; }

    public ResultOfJourney Analysis(Ship ship, Path path);

    public Ship? ChooseBestShip(Collection<Ship> ships, Path path);
}
