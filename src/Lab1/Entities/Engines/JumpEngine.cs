using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
public abstract class JumpEngine : Engine
{
    private double _limitForDistance; // максимальный прыжок двигателя

    protected JumpEngine(double limitForDistance)
    {
        if (limitForDistance <= 0)
        {
            throw new ArgumentException("Distance cannot be zero or less: ", nameof(limitForDistance));
        }

        _limitForDistance = limitForDistance;
    }

    public double LimitForDistance => _limitForDistance;
}
