using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;
public class Success : ResultOfJourney
{
    private const string Message = $"Journey was successful";

    public Success(Ship ship)
        : base(Message, ship)
    {
    }
}
