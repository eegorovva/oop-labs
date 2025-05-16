using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Endurances;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.UpdatesForShip;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;

public abstract class Ship
{
    private Endurance _endurance;
    private ImpulsiveEngine _impulsiveEngine;
    private JumpEngine? _jumpEngine;
    private Deflector? _deflector;
    private PhotonDeflector? _photonDeflector;
    private Emitter? _emitter;

    protected Ship(ImpulsiveEngine impulsiveEngine, Endurance endurance, Deflector? deflector = null, PhotonDeflector? photonDeflector = null, Emitter? emitter = null, JumpEngine? jumpEngine = null)
    {
        if (impulsiveEngine == null)
        {
            throw new ArgumentException("Engine cannot be null: ", nameof(impulsiveEngine));
        }

        if (endurance == null)
        {
            throw new ArgumentException("Endurance cannot be null: ", nameof(endurance));
        }

        _jumpEngine = jumpEngine;
        _impulsiveEngine = impulsiveEngine;
        _endurance = endurance;
        _deflector = deflector;
        _photonDeflector = photonDeflector;
        _emitter = emitter;
    }

    public ImpulsiveEngine ImpulsiveEngine => _impulsiveEngine;
    public JumpEngine? JumpEngine => _jumpEngine;
    public Emitter? Emitter => _emitter;
    public PhotonDeflector? PhotonDeflector => _photonDeflector;
    public double EnduranceHealth => _endurance.Health;

    public double DeflectorsHealth
    {
        get
        {
            if (_deflector == null)
            {
                throw new InvalidOperationException("Deflectors health is null");
            }

            return _deflector.Health;
        }
    }

    public bool FindPhotonDeflector()
    {
        if (_photonDeflector == null)
        {
            return false;
        }

        return true;
    }

    public bool FindEmitter()
    {
        if (_emitter == null)
        {
            return false;
        }

        return true;
    }

    public void ActivatePhotonDeflector()
    {
        if (_photonDeflector == null)
        {
            throw new ArgumentException("Photon deflector doesnt exist: ", nameof(_photonDeflector));
        }

        _photonDeflector.ActivatePhotonDeflector();
    }

    public void GetDamage(int damage)
    {
        if (damage <= 0)
        {
            throw new ArgumentException("Invalid damage: ", nameof(damage));
        }

        double dealingDamage = damage * _endurance.Coefficient;

        if (_deflector != null && _deflector.IsWorking())
        {
            dealingDamage = _deflector.GetDamage(dealingDamage);
        }

        if (dealingDamage > 0)
        {
            _endurance.GetDamage(dealingDamage);
        }
    }

    public bool IsDeflectorWorking()
    {
        if (_deflector == null || !_deflector.IsWorking())
        {
            return false;
        }

        return true;
    }

    public bool IsDestroyed()
    {
        return _endurance.IsDestroyed();
    }
}