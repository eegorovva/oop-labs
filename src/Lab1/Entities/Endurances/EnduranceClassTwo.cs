namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Endurances;

public class EnduranceClassTwo : Endurance
{
    private const double EnduranceCoefficient = 0.7;
    private const double HealthClassTwo = 200;

    public EnduranceClassTwo()
        : base(HealthClassTwo, EnduranceCoefficient)
    {
    }
}