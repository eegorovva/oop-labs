using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;
public class DeathOfTheCrew : ResultOfJourney
{
    private const string Message = "Crew is dead";

    public DeathOfTheCrew(Ship ship)
        : base(Message, ship)
    {
    }
}
