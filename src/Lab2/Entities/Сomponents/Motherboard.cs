using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.AttributesForComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;

public class Motherboard : Component
{
    private BIOS _bios;
    private CPUSocket _socket;
    private int _pcieAmount;
    private int _sataAmount;
    private Chipset _chipset;
    private string _ddr;
    private int _portForRam;
    private string _formFactor;
    private double _version;
    private string _type;

    public Motherboard(string name, BIOS bios, CPUSocket socket, int pcieAmount, int sataAmount, Chipset chipset, string ddr, int portForRam, string formFactor, double version, string type)
        : base(name)
    {
        if (socket is null)
        {
            throw new ArgumentException("Socket cannot be less or zero", nameof(socket));
        }

        if (pcieAmount <= 0)
        {
            throw new ArgumentException("PCI-E amount cannot be less or zero", nameof(pcieAmount));
        }

        if (sataAmount <= 0)
        {
            throw new ArgumentException("Sata Amount cannot be less or zero", nameof(sataAmount));
        }

        if (chipset is null)
        {
            throw new ArgumentException("Chipset cannot be less or zero", nameof(chipset));
        }

        if (ddr is null)
        {
            throw new ArgumentException("DDR cannot be less or null", nameof(ddr));
        }

        if (portForRam <= 0)
        {
            throw new ArgumentException("Port For Ram cannot be less or zero", nameof(portForRam));
        }

        if (version <= 0)
        {
            throw new ArgumentException("Version cannot be less or zero", nameof(version));
        }

        if (type is null)
        {
            throw new ArgumentException("Type cannot be less or zero", nameof(type));
        }

        if (bios is null)
        {
            throw new ArgumentException("bios cannot be less or zero", nameof(bios));
        }

        _bios = bios;
        _socket = socket;
        _pcieAmount = pcieAmount;
        _sataAmount = sataAmount;
        _chipset = chipset;
        _ddr = ddr;
        _portForRam = portForRam;
        _formFactor = formFactor;
        _version = version;
        _type = type;
    }

    public int PortsForRam => _portForRam;
    public string DDR => _ddr;
    public string Formfactor => _formFactor;
    public Chipset Chipset => _chipset;
    public CPUSocket CPUsocket => _socket;
    public int PcieAmount => _pcieAmount;
    public BIOS Bios => _bios;
}
