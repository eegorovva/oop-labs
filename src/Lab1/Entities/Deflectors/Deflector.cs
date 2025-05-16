using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class Deflector
{
   private const int HealthBroken = 0;

   private double _healthPoint;

   protected Deflector(double healthPoint)
   {
      if (healthPoint <= 0)
      {
         throw new ArgumentException("Invalid health: ", nameof(healthPoint));
      }

      _healthPoint = healthPoint;
   }

   public double Health => _healthPoint;

   public bool IsWorking()
   {
      return _healthPoint > HealthBroken;
   }

   public double GetDamage(double damage)
   {
      double damageToEndurance = 0;

      if (damage <= 0)
      {
         throw new ArgumentException("Invalid damage: ", nameof(damage));
      }

      _healthPoint -= damage;

      if (_healthPoint < HealthBroken)
      {
         damageToEndurance = double.Abs(_healthPoint);
         _healthPoint = HealthBroken;
      }

      return damageToEndurance;
   }
}