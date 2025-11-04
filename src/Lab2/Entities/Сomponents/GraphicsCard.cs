using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.AttributesForComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;
public class GraphicsCard : Component
{
    private double _height;
    private double _width;
    private int _graphicsRAM;
    private PCIeVersion _pcieVersion;
    private int _gpuClockSpeed;
    private int _powerConsumption;

    public GraphicsCard(string name, double height, double width, int graphicsRAM, PCIeVersion pcieVersion, int gpuClockSpeed, int powerConsumption)
        : base(name)
    {
        if (name is null)
        {
            throw new ArgumentException("Name cannot be empty", nameof(name));
        }

        if (height <= 0)
        {
            throw new ArgumentException("Height cannot be zero: ", nameof(width));
        }

        if (width <= 0)
        {
            throw new ArgumentException("Width cannot be zero: ", nameof(width));
        }

        if (graphicsRAM <= 0)
        {
            throw new ArgumentException("Graphics RAM cannot be zero: ", nameof(graphicsRAM));
        }

        if (pcieVersion is null)
        {
            throw new ArgumentException("PCI-E version cannot be zero: ", nameof(pcieVersion));
        }

        if (gpuClockSpeed <= 0)
        {
            throw new ArgumentException("GPU Clock Speed cannot be zero: ", nameof(gpuClockSpeed));
        }

        if (powerConsumption <= 0)
        {
            throw new ArgumentException("Power consumption cannot be zero: ", nameof(powerConsumption));
        }

        _height = height;
        _width = width;
        _graphicsRAM = graphicsRAM;
        _pcieVersion = pcieVersion;
        _gpuClockSpeed = gpuClockSpeed;
        _powerConsumption = powerConsumption;
    }

    public double Height => _height;
    public double Width => _width;
    public int GraphicsRam => _graphicsRAM;
    public PCIeVersion PCIEversion => _pcieVersion;
    public int GPUclockSpeed => _gpuClockSpeed;
    public int PowerConsumption => _powerConsumption;
}
