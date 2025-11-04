using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.AttributesForComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;
public class CPU : Component
{
    private int _processorCores;
    private int _baseFrequency;
    private CPUSocket _socket;
    private GraphicsCoreForCPU? _graphicsCore;
    private int _frequencyRam;
    private int _power;
    private int _tpd;

    public CPU(string name, int processorCores, int baseFrequency, CPUSocket socket, GraphicsCoreForCPU? graphicsCore, int frequencyRam, int power, int tpd)
        : base(name)
    {
        if (processorCores <= 0)
        {
            throw new ArgumentException("Processor Core cannot be zero", nameof(processorCores));
        }

        if (baseFrequency <= 0)
        {
            throw new ArgumentException("Frequency cannot be zero", nameof(baseFrequency));
        }

        if (socket is null)
        {
            throw new ArgumentException("Socket cannot be null", nameof(socket));
        }

        if (graphicsCore is null)
        {
            throw new ArgumentException("Graphics core cannot be null", nameof(graphicsCore));
        }

        if (frequencyRam <= 0)
        {
            throw new ArgumentException("Frequency ram cannot be zero", nameof(frequencyRam));
        }

        if (power <= 0)
        {
            throw new ArgumentException("power cannot be zero", nameof(power));
        }

        if (tpd <= 0)
        {
            throw new ArgumentException("tpd cannot be zero", nameof(tpd));
        }

        _processorCores = processorCores;
        _baseFrequency = baseFrequency;
        _socket = socket;
        _graphicsCore = graphicsCore;
        _frequencyRam = frequencyRam;
        _power = power;
        _tpd = tpd;
    }

    public int TPD => _tpd;
    public double Frequency => _baseFrequency;
    public double FrequencyRam => _frequencyRam;
    public CPUSocket Socket => _socket;
    public GraphicsCoreForCPU? GraphicsCoreForCPU => _graphicsCore;
}
