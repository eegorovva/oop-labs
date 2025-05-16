using Itmo.ObjectOrientedProgramming.Lab1.Entities.Endurances;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public class Shuttle : Ship
{
    public Shuttle()
        : base(new ImpulsiveEngineClassC(), new EnduranceClassOne())
    {
    }
}