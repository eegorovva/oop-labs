using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuilderForComputer;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repoz;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageForUsers;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;
public class ComputerSevice
{
    private Storage _storage;
    private Director _director;
    private Collection<IOrderList> _orderLists;
    private int _amountOfOrderLists;

    public ComputerSevice()
    {
        _storage = new Storage();
        _amountOfOrderLists = 0;
        _director = new Director();
        _orderLists = new Collection<IOrderList>();
    }

    public Computer? SellComputerFromStorage(string name)
    {
        if (_storage.FindComputer(name) != null)
        {
            _amountOfOrderLists++;
            _orderLists.Add(new ComputerOrderList(_amountOfOrderLists, _storage.GetComputer(name)));
            return _storage.GetComputer(name);
        }

        return null;
    }

    public ComponentOrderList StartSelling()
    {
        var orderList = new ComponentOrderList(++_amountOfOrderLists);
        _orderLists.Add(orderList);

        return orderList;
    }

    public void AddComponentToOrderList(string name, ComponentOrderList orderList)
    {
        if (orderList is null)
        {
            throw new ArgumentException("order List cannot be null: ", nameof(orderList));
        }

        if (!_orderLists.Contains(orderList))
        {
            throw new ArgumentException("order list doesn't exist: ", nameof(orderList));
        }

        orderList.Add(name, _storage);
    }

    public Computer? EndSelling(string name, ComponentOrderList orderList)
    {
        if (orderList is null)
        {
            throw new ArgumentException("order List cannot be null: ", nameof(orderList));
        }

        if (!_orderLists.Contains(orderList))
        {
            throw new ArgumentException("order list doesn't exist: ", nameof(orderList));
        }

        IBuilderForPC builder = SalesDepartment.ParseComponentOrderList(name, orderList);

        return _director.BuildComputer(builder);
    }

    public ReadOnlyCollection<BuildInfo> ReturnBuildInfoFromLastOrder()
    {
        return _director.BuildInfo;
    }

    public void AddComponentInStorage(Component component)
    {
        _storage.AddComponent(component);
    }

    public Computer? SwitchComponent(Computer computer, Component component)
    {
        BuilderForPC? builderForPC = null;

        if (computer is null)
        {
            throw new ArgumentException("Computer cannot be null: ", nameof(computer));
        }

        if (component is null)
        {
            throw new ArgumentException("Component cannot be null: ", nameof(component));
        }

        if (component is Motherboard)
        {
            builderForPC = new BuilderForPC(computer.Name, computer.Cpu, computer.GraphicsCard, computer.Hdd, computer.Ssd, computer.Ram, (Motherboard)component, computer.CoolingSystem, computer.WifiAdapter, computer.PowerUnit, computer.ComputerCase);
        }
        else if (component is CPU)
        {
            builderForPC = new BuilderForPC(computer.Name, (CPU)component, computer.GraphicsCard, computer.Hdd, computer.Ssd, computer.Ram, computer.Motherboard, computer.CoolingSystem, computer.WifiAdapter, computer.PowerUnit, computer.ComputerCase);
        }
        else if (component is ComputerCase)
        {
            builderForPC = new BuilderForPC(computer.Name, computer.Cpu, computer.GraphicsCard, computer.Hdd, computer.Ssd, computer.Ram, computer.Motherboard, computer.CoolingSystem, computer.WifiAdapter, computer.PowerUnit, (ComputerCase)component);
        }
        else if (component is GraphicsCard)
        {
            builderForPC = new BuilderForPC(computer.Name, computer.Cpu, (GraphicsCard)component, computer.Hdd, computer.Ssd, computer.Ram, computer.Motherboard, computer.CoolingSystem, computer.WifiAdapter, computer.PowerUnit, computer.ComputerCase);
        }
        else if (component is HDD)
        {
            builderForPC = new BuilderForPC(computer.Name, computer.Cpu, computer.GraphicsCard, (HDD)component, computer.Ssd, computer.Ram, computer.Motherboard, computer.CoolingSystem, computer.WifiAdapter, computer.PowerUnit, computer.ComputerCase);
        }
        else if (component is PowerUnit)
        {
            builderForPC = new BuilderForPC(computer.Name, computer.Cpu, computer.GraphicsCard, computer.Hdd, computer.Ssd, computer.Ram, computer.Motherboard, computer.CoolingSystem, computer.WifiAdapter, (PowerUnit)component, computer.ComputerCase);
        }
        else if (component is SSD)
        {
            builderForPC = new BuilderForPC(computer.Name, computer.Cpu, computer.GraphicsCard, computer.Hdd, (SSD)component, computer.Ram, computer.Motherboard, computer.CoolingSystem, computer.WifiAdapter, computer.PowerUnit, computer.ComputerCase);
        }
        else if (component is CoolingSystem)
        {
            builderForPC = new BuilderForPC(computer.Name, computer.Cpu, computer.GraphicsCard, computer.Hdd, computer.Ssd, computer.Ram, computer.Motherboard, (CoolingSystem)component, computer.WifiAdapter, computer.PowerUnit, computer.ComputerCase);
        }
        else if (component is HDD)
        {
            builderForPC = new BuilderForPC(computer.Name, computer.Cpu, computer.GraphicsCard, computer.Hdd, computer.Ssd, computer.Ram, computer.Motherboard, computer.CoolingSystem, computer.WifiAdapter, computer.PowerUnit, computer.ComputerCase);
        }
        else if (component is WifiAdapter)
        {
            builderForPC = new BuilderForPC(computer.Name, computer.Cpu, computer.GraphicsCard, computer.Hdd, computer.Ssd, computer.Ram, computer.Motherboard, computer.CoolingSystem, (WifiAdapter)component, computer.PowerUnit, computer.ComputerCase);
        }

        if (builderForPC is null)
        {
            return null;
        }

        return _director.BuildComputer(builderForPC);
    }

    public Computer? SwitchComponent(Computer computer, Collection<RAM> component)
    {
        BuilderForPC? builderForPC;

        if (computer is null)
        {
            throw new ArgumentException("Computer cannot be null: ", nameof(computer));
        }

        if (component is null || component.Count == 0)
        {
            throw new ArgumentException("Component cannot be null: ", nameof(component));
        }

        builderForPC = new BuilderForPC(computer.Name, computer.Cpu, computer.GraphicsCard, computer.Hdd, computer.Ssd, component, computer.Motherboard, computer.CoolingSystem, computer.WifiAdapter, computer.PowerUnit, computer.ComputerCase);

        return _director.BuildComputer(builderForPC);
    }
}