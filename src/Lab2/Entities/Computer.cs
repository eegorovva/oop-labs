using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models.AttributesForComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;
public class Computer
{
    private string _name;
    private BIOS _bios;
    private CPU _cpu;
    private GraphicsCard? _graphicsCard;
    private HDD? _hdd;
    private SSD? _ssd;
    private Collection<RAM> _ram;
    private Motherboard _motherboard;
    private CoolingSystem _coolingSystem;
    private WifiAdapter? _wifiAdapter;
    private PowerUnit _powerUnit;
    private ComputerCase _computerCase;
    private XMP? _xmp;
    private DOCP? _docp;

    public Computer(string name, CPU cpu, GraphicsCard? graphicsCard, HDD? hdd, SSD? ssd, Collection<RAM> ram, Motherboard motherboard, CoolingSystem coolingSystem, WifiAdapter? wifiAdapter, PowerUnit powerUnit, ComputerCase computerCase)
    {
        if (motherboard is null)
        {
            throw new ArgumentException("Motherboard cannot be null", nameof(motherboard));
        }

        _name = name;
        _bios = motherboard.Bios;
        _cpu = cpu;
        _graphicsCard = graphicsCard;
        _hdd = hdd;
        _ssd = ssd;
        _ram = ram;
        _motherboard = motherboard;
        _coolingSystem = coolingSystem;
        _wifiAdapter = wifiAdapter;
        _powerUnit = powerUnit;
        _computerCase = computerCase;
        _xmp = motherboard.Chipset.Xmp;
        _docp = motherboard.Chipset.Docp;
    }

    public string Name => _name;
    public BIOS Bios => _bios;
    public CPU Cpu => _cpu;
    public GraphicsCard? GraphicsCard => _graphicsCard;
    public HDD? Hdd => _hdd;
    public SSD? Ssd => _ssd;
    public Collection<RAM> Ram => _ram;
    public Motherboard Motherboard => _motherboard;
    public CoolingSystem CoolingSystem => _coolingSystem;
    public WifiAdapter? WifiAdapter => _wifiAdapter;
    public PowerUnit PowerUnit => _powerUnit;
    public ComputerCase ComputerCase => _computerCase;
    public XMP? Xmp => _xmp;
    public DOCP? Docp => _docp;
}
