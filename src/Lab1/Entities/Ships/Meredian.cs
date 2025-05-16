using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Endurances;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.UpdatesForShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
public class Meredian : Ship
{
    public Meredian(PhotonDeflector? photonDeflector = null)
        : base(new ImpulsiveEngineClassE(), new EnduranceClassTwo(), new DeflectorClassTwo(), photonDeflector, new Emitter(), null)
    {
    }
}
