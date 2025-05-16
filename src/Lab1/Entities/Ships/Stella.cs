using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Endurances;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.UpdatesForShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
public class Stella : Ship
{
    public Stella(PhotonDeflector? photonDeflector = null)
        : base(new ImpulsiveEngineClassC(), new EnduranceClassOne(), new DeflectorClassOne(), photonDeflector, null, new JumpEngineOmega())
    {
    }
}
