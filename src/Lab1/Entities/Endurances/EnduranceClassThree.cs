namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Endurances;

public class EnduranceClassThree : Endurance
{
    private const double HealthClassThree = 300;
    private const double EnduranceCoeficient = 0.5;

    public EnduranceClassThree()
        : base(HealthClassThree, EnduranceCoeficient)
    {
    }
}