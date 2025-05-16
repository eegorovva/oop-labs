using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Endurances;

public abstract class Endurance
{
    private const int HealthOfDestroyed = 0;
    private double _enduranceCoefficient;
    private double _health;

    protected Endurance(double health, double enduranceCoefficient)
    {
        if (health <= 0)
        {
            throw new ArgumentException("Health cannot be zero or less: ",  nameof(health));
        }

        if (enduranceCoefficient <= 0 && enduranceCoefficient > 1)
        {
            throw new ArgumentException("Endurance must be in (0; 1] ", nameof(health));
        }

        _health = health;
        _enduranceCoefficient = enduranceCoefficient;
    }

    public double Coefficient
    {
        get
        {
            return _enduranceCoefficient;
        }
    }

    public double Health
    {
        get
        {
            return _health;
        }
    }

    public void GetDamage(double damage)
    {
        if (damage <= 0)
        {
            throw new ArgumentException("Invalid damage: ", nameof(damage));
        }

        _health -= damage;

        if (_health < HealthOfDestroyed)
        {
            _health = HealthOfDestroyed;
        }
    }

    public bool IsDestroyed()
    {
        return _health <= HealthOfDestroyed;
    }
}