using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;
public class LostShip : ResultOfJourney
{
    private const string Message = "The ship was lost";

    public LostShip(Ship ship)
        : base(Message, ship)
    {
    }
}
