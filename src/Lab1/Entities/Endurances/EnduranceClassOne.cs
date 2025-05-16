namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Endurances;

public class EnduranceClassOne : Endurance
{
    private const double EnduranceCoefficient = 1;
    private const double HealthClassOne = 100;

    public EnduranceClassOne()
    : base(HealthClassOne, EnduranceCoefficient)
    {
    }
}