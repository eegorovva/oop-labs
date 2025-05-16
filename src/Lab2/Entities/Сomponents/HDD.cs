using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;
public class HDD : Component
{
    private int _storage;
    private int _rotationalSpeed;
    private int _powerConsumption;

    public HDD(string name, int storage, int rotationalSpeed, int powerConsumption)
        : base(name)
    {
        if (storage <= 0)
        {
            throw new ArgumentException("Storage cannot be less or zero", nameof(storage));
        }

        if (rotationalSpeed <= 0)
        {
            throw new ArgumentException("Speed cannot be less or zero", nameof(rotationalSpeed));
        }

        if (powerConsumption <= 0)
        {
            throw new ArgumentException("Power cannot be less or zero", nameof(powerConsumption));
        }

        _storage = storage;
        _rotationalSpeed = rotationalSpeed;
        _powerConsumption = powerConsumption;
    }
}
