using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.AttributesForComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;
public class SSD : Component
{
    private int _storage;
    private int _rotationalSpeed;
    private int _powerConsumption;
    private ConnectivityType _connectivityType;

    public SSD(string name, int storage, int rotationalSpeed, int powerConsumption, ConnectivityType connectivityType)
        : base(name)
    {
        if (storage is 0)
        {
            throw new ArgumentException("Storage cannot be zero", nameof(storage));
        }

        if (rotationalSpeed is 0)
        {
            throw new ArgumentException("Rotational Speed cannot be zero", nameof(rotationalSpeed));
        }

        if (powerConsumption is 0)
        {
            throw new ArgumentException("Power consumption cannot be zero", nameof(powerConsumption));
        }

        if (connectivityType is null)
        {
            throw new ArgumentException("Connectivity type cannot be zero", nameof(connectivityType));
        }

        _storage = storage;
        _rotationalSpeed = rotationalSpeed;
        _powerConsumption = powerConsumption;
        _connectivityType = connectivityType;
    }

    public ConnectivityType ConnectivityType => _connectivityType;
}
