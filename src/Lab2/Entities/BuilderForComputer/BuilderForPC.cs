using System;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuilderForComputer;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Builder;
public class BuilderForPC : IBuilderForPC
{
    private string _name;
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

    public BuilderForPC(string name, CPU cpu, GraphicsCard? graphicsCard, HDD? hdd, SSD? ssd, Collection<RAM> ram, Motherboard motherboard, CoolingSystem coolingSystem, WifiAdapter? wifiAdapter, PowerUnit powerUnit, ComputerCase computerCase)
    {
        _name = name;
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
    }

    public BuildInfo CheckMotherboardWithCPUBySocket()
    {
        if (_motherboard is null)
        {
            throw new ArgumentException("MotherBoard cannot be null ", nameof(_motherboard));
        }

        if (_cpu is null)
        {
            throw new ArgumentException("cpu cannot be null ", nameof(_cpu));
        }

        if (_motherboard.CPUsocket == _cpu.Socket && _motherboard.Bios.CPUs.Contains(_cpu))
        {
            return new SuccessfulBuild($"Motherboard: {_motherboard.Name} is compatible wtih CPU: {_cpu}");
        }

        return new BuildError("Motherboard's socket differ from CPU's socket");
    }

    public BuildInfo CheckMotherboardWithCPUByBios()
    {
        if (_motherboard is null)
        {
            throw new ArgumentException("MotherBoard cannot be null ", nameof(_motherboard));
        }

        if (_cpu is null)
        {
            throw new ArgumentException("cpu cannot be null ", nameof(_cpu));
        }

        if (_motherboard.Bios.CPUs.Contains(_cpu))
        {
            return new SuccessfulBuild($"Motherboard: {_motherboard.Name} is compatible wtih CPU: {_cpu}");
        }

        return new BuildError($"Motherboard({_motherboard.Name}) does not support this processor({_cpu.Name})");
    }

    public BuildInfo CheckMotherboardWithRam()
    {
        if (_motherboard is null)
        {
            throw new ArgumentException("MotherBoard cannot be null ", nameof(_motherboard));
        }

        if (_ram is null)
        {
            throw new ArgumentException("RAM cannot be null ", nameof(_ram));
        }

        var ramCompatible = _ram.Where(ram => (ram.Frequency >= _motherboard.Chipset.MinFrequency) && (ram.Frequency <= _motherboard.Chipset.MaxFrequency)).Select(ram => ram.Name).ToList();
        var ramNotCompatible = _ram.Where(ram => (ram.Frequency < _motherboard.Chipset.MinFrequency) || (ram.Frequency > _motherboard.Chipset.MaxFrequency)).Select(ram => ram.Name).ToList();

        if (ramNotCompatible.Count > 0)
        {
            return new BuildError($"MotherBoard's({_motherboard.Name}) is not compatible with Ram({string.Join(" ", ramNotCompatible)}) frequency");
        }

        return new SuccessfulBuild($"MotherBoard's({_motherboard.Name}) is compatible with Ram({string.Join(" ", ramCompatible)}) frequency");
    }

    public BuildInfo CheckCPUwithCoolingSystemBySocket()
    {
        if (_cpu is null)
        {
            throw new ArgumentException("cpu cannot be null ", nameof(_cpu));
        }

        if (_coolingSystem is null)
        {
            throw new ArgumentException("Cooling System cannot be null ", nameof(_coolingSystem));
        }

        if (_coolingSystem.Sockets.Contains(_cpu.Socket))
        {
            return new SuccessfulBuild($"Cooling system's({_coolingSystem.Name}) socket is compatible with CPU's({_cpu.Name}) ");
        }

        return new BuildError($"Cooling system's({_coolingSystem.Name}) socket is differ from CPU's({_cpu.Name})");
    }

    public BuildInfo CheckCPUwithCollingSystemByTPD()
    {
        if (_cpu is null)
        {
            throw new ArgumentException("cpu cannot be null ", nameof(_cpu));
        }

        if (_coolingSystem is null)
        {
            throw new ArgumentException("Cooling System cannot be null ", nameof(_coolingSystem));
        }

        if (_coolingSystem.TPD >= _cpu.TPD)
        {
            return new SuccessfulBuild($"Cooling system's({_coolingSystem.Name}) TPD is bigger than CPU's({_cpu.Name})");
        }

        return new DisclaimerOfWarranties($"Discailmer of Warranties: Build was successful but cooling system's({_coolingSystem.Name}) TPD is differ from CPU's({_cpu.Name})");
    }

    public BuildInfo CheckCoolingSystemsWithCaseBySize()
    {
        if (_coolingSystem is null)
        {
            throw new ArgumentException("Cooling System cannot be null ", nameof(_coolingSystem));
        }

        if (_computerCase is null)
        {
            throw new ArgumentException("Computer case cannot be null ", nameof(_computerCase));
        }

        if (_coolingSystem.Height < _computerCase.Height && _coolingSystem.Lenght < _computerCase.Lenght && _coolingSystem.Width < _computerCase.Width)
        {
            return new SuccessfulBuild($"Cooling system({_coolingSystem.Name}) fits computer case size");
        }

        return new BuildError($"Cooling system({_coolingSystem.Name}) doesn't fit computer case size");
    }

    public BuildInfo CheckMotherboardWithCaseByFormfactor()
    {
        if (_motherboard is null)
        {
            throw new ArgumentException("MotherBoard cannot be null ", nameof(_motherboard));
        }

        if (_computerCase is null)
        {
            throw new ArgumentException("Computer case cannot be null ", nameof(_computerCase));
        }

        if (_computerCase.Formfactor.Contains(_motherboard.Formfactor))
        {
            return new SuccessfulBuild($"Motherboard's({_motherboard.Name}) formfactor is compatible with case's({_computerCase.Name}) ");
        }

        return new BuildError($"Motherboard's({_motherboard.Name}) formfactor differ from case's({_computerCase.Name}) ");
    }

    public BuildInfo CheckMotherboardWithRamByDDR()
    {
        if (_motherboard is null)
        {
            throw new ArgumentException("MotherBoard cannot be null ", nameof(_motherboard));
        }

        if (_ram is null)
        {
            throw new ArgumentException("RAM cannot be null ", nameof(_ram));
        }

        var ramCompatible = _ram.Where(ram => ram.DDR == _motherboard.DDR).Select(ram => ram.Name).ToList();
        var ramNotCompatible = _ram.Where(ram => ram.DDR != _motherboard.DDR).Select(ram => ram.Name).ToList();

        if (ramNotCompatible.Count > 0)
        {
            return new BuildError($"Motherboard's({_motherboard.Name}) DDR differ from RAM's({string.Join(" ", ramNotCompatible)}) ");
        }

        return new SuccessfulBuild($"Motherboard's({_motherboard.Name}) DDR is compatible with RAM's({string.Join(" ", ramCompatible)})");
    }

    public BuildInfo CheckRamAmountWithMotherboard()
    {
        if (_motherboard is null)
        {
            throw new ArgumentException("MotherBoard cannot be null ", nameof(_motherboard));
        }

        if (_ram is null)
        {
            throw new ArgumentException("RAM cannot be null ", nameof(_ram));
        }

        if (_motherboard.PortsForRam >= _ram.Count)
        {
            return new SuccessfulBuild($"Motherboard's({_motherboard.Name}) ports for RAM is compatible with RAM's");
        }

        return new BuildError($"Motherboard's({_motherboard.Name}) ports differ from RAM' ");
    }

    public BuildInfo CheckGraphicsCoreForPC()
    {
        if (_cpu.GraphicsCoreForCPU != null || _graphicsCard != null)
        {
            return new SuccessfulBuild($"Build was successfull. PC has graphics core");
        }

        return new BuildError($"PC doesn't has any graphics core for work");
    }

    public BuildInfo CheckGraphicsCardWithMotherboardByPCIeAmount()
    {
        if (_motherboard is null)
        {
            throw new ArgumentException("MotherBoard cannot be null ", nameof(_motherboard));
        }

        if (_graphicsCard is null)
        {
            throw new ArgumentException("Graphics Card cannot be null ", nameof(_graphicsCard));
        }

        if (_graphicsCard.PCIEversion.PcieAmount == _motherboard.PcieAmount)
        {
            return new SuccessfulBuild($"Graphics card's({_graphicsCard.Name}) pcie amount is compatible with motherboard's({_motherboard.Name}) pcie amount");
        }

        return new BuildError($"Graphics card's({_graphicsCard.Name}) pcie amount is differ from motherboard's({_motherboard.Name}) pcie amount");
    }

    public BuildInfo CheckGraphicsCardWithComputerCaseByFormfactor()
    {
        if (_graphicsCard is null)
        {
            throw new ArgumentException("Graphics Card cannot be null ", nameof(_graphicsCard));
        }

        if (_computerCase is null)
        {
            throw new ArgumentException("Computer case cannot be null ", nameof(_computerCase));
        }

        if (_graphicsCard.Width < _computerCase.WidthForCard && _graphicsCard.Height < _computerCase.HeightForCard)
        {
            return new SuccessfulBuild($"Graphics card's({_graphicsCard.Name}) size fits computer case");
        }

        return new BuildError($"Graphics card's({_graphicsCard.Name}) size doesn't fit computer case");
    }

    public BuildInfo CheckGraphicsCardWithPowerUnitByPower()
    {
        if (_graphicsCard is null)
        {
            throw new ArgumentException("Graphics Card cannot be null ", nameof(_graphicsCard));
        }

        if (_powerUnit is null)
        {
            throw new ArgumentException("Power unit  cannot be null ", nameof(_powerUnit));
        }

        if (_graphicsCard.PowerConsumption <= _powerUnit.MaxPower)
        {
            return new SuccessfulBuild($"Graphics card's({_graphicsCard.PowerConsumption}) power consumption is compatible with power unit's({_powerUnit.Name}) ");
        }
        else if (_graphicsCard.PowerConsumption > _powerUnit.MaxPower)
        {
            return new DisclaimerOfWarranties($"Graphics card's({_graphicsCard.PowerConsumption}) power equal power unit's({_powerUnit.Name}.Energy may not be enouqh.");
        }

        return new BuildError($"Graphics card's({_graphicsCard.PowerConsumption}) power consumption is differ from power unit's({_powerUnit.Name})");
    }

    public BuildInfo CheckHDDandSSDinPC()
    {
        if (_ssd is null && _hdd is null)
        {
            return new BuildError($"PC must have a hard driver.");
        }

        return new SuccessfulBuild($"HDD and SSD were checked.");
    }

    public BuildInfo CheckXMP()
    {
        if (_motherboard.Chipset.Xmp != null)
        {
            if (_ram.Where(xmp => xmp.XMP != null) != null && _cpu.Frequency >= _motherboard.Chipset.MinFrequency && _cpu.Frequency <= _motherboard.Chipset.MaxFrequency)
            {
                return new SuccessfulBuild($"XMP profiles were checked");
            }
        }
        else if (_motherboard.Chipset.Docp != null)
        {
            return new Comments("XMP profile is not supported, docp is supported");
        }

        return new BuildError($"XMP profiles are not supported");
    }

    public BuildInfo CheckDOCP()
    {
        if (_motherboard.Chipset.Docp != null)
        {
            if (_ram.Where(xmp => xmp.DOCP != null) != null && _cpu.Frequency >= _motherboard.Chipset.MinFrequency && _cpu.Frequency <= _motherboard.Chipset.MaxFrequency)
            {
                return new SuccessfulBuild($"DOCP profiles were checked");
            }
        }
        else if (_motherboard.Chipset.Xmp != null)
        {
            return new Comments("DOCP profile is not supported, xmp is supported");
        }

        return new BuildError($"DOCP profiles are not supported");
    }

    public Computer BuildPC()
    {
        return new Computer(_name, _cpu, _graphicsCard, _hdd, _ssd, _ram, _motherboard, _coolingSystem, _wifiAdapter, _powerUnit, _computerCase);
    }
}