using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Endurances;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.UpdatesForShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
public class Vaclas : Ship
{
    public Vaclas(PhotonDeflector? photonDeflector = null)
        : base(new ImpulsiveEngineClassE(), new EnduranceClassTwo(), new DeflectorClassOne(), photonDeflector, null, new JumpEngineGamma())
    {
    }
}
