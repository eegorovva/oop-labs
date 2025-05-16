using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.AttributesForComponents;
public class PCIE : ConnectivityType
{
    private const string Name = "PCI-E";
    private int _version;

    public PCIE(int version)
        : base(Name)
    {
        if (version <= 0)
        {
            throw new ArgumentException("Version cannot be less or zero", nameof(version));
        }

        _version = version;
    }

    public int PCIeVersion => _version;
}
