using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;
public class DOCP
{
    private string _timing;
    private double _voltage;
    private double _frequency;

    public DOCP(string timing, double voltage, double frequency)
    {
        if (timing is null)
        {
            throw new ArgumentException("Timing cannot be zero: ", nameof(timing));
        }

        if (voltage <= 0)
        {
            throw new ArgumentException("Voltage cannot be zero: ", nameof(voltage));
        }

        if (frequency <= 0)
        {
            throw new ArgumentException("Frequency cannot be zero: ", nameof(frequency));
        }

        _timing = timing;
        _voltage = voltage;
        _frequency = frequency;
    }
}
