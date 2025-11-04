using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.AttributesForComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;
public class RAM : Component
{
    private int _memory;
    private int _frequencyJedec;
    private string _timingJedec;
    private double _voltage;
    private XMP? _xmp;
    private DOCP? _docp;
    private string _formfactor;
    private string _ddr;
    private int _power;

    public RAM(string name, int memory, int frequencyJedec, string timingJedec, double voltage, XMP? xmp, DOCP? docp, string formfactor, string ddr, int power)
        : base(name)
    {
        if (memory <= 0)
        {
            throw new ArgumentException("Memory is cannot be zero", nameof(memory));
        }

        if (frequencyJedec <= 0)
        {
            throw new ArgumentException("Frequency is cannot be zero", nameof(frequencyJedec));
        }

        if (timingJedec is null)
        {
            throw new ArgumentException("Timing is cannot be zero", nameof(timingJedec));
        }

        if (voltage <= 0)
        {
            throw new ArgumentException("Voltage is cannot be zero", nameof(voltage));
        }

        if (formfactor is null)
        {
            throw new ArgumentException("formfactor is cannot be zero", nameof(formfactor));
        }

        if (ddr is null)
        {
            throw new ArgumentException("DDR is cannot be null", nameof(ddr));
        }

        if (power <= 0)
        {
            throw new ArgumentException("Power is cannot be zero", nameof(power));
        }

        _memory = memory;
        _frequencyJedec = frequencyJedec;
        _timingJedec = timingJedec;
        _voltage = voltage;
        _xmp = xmp;
        _docp = docp;
        _formfactor = formfactor;
        _ddr = ddr;
        _power = power;
    }

    public string DDR => _ddr;
    public int Frequency => _frequencyJedec;
    public XMP? XMP => _xmp;
    public DOCP? DOCP => _docp;
}
