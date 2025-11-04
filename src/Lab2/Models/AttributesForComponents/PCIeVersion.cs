using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.AttributesForComponents;
public class PCIeVersion
{
    private int _version;
    private int _pcieAmount;

    public PCIeVersion(int pcieAmount, int version)
    {
        if (pcieAmount is 0)
        {
            throw new ArgumentException($"pcie cannot be zero", nameof(pcieAmount));
        }

        if (version is 0)
        {
            throw new ArgumentException($"pcie cannot be zero", nameof(version));
        }

        _pcieAmount = pcieAmount;
        _version = version;
    }

    public int Version => _version;
    public int PcieAmount => _pcieAmount;
}
