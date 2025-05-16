using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Endurances;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.UpdatesForShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
public class Avgur : Ship
{
    public Avgur(PhotonDeflector? photonDeflector = null)
        : base(new ImpulsiveEngineClassE(), new EnduranceClassThree(), new DeflectorClassThree(), photonDeflector, null, new JumpEngineAlpha())
    {
    }
}
