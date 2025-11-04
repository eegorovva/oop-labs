using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Builder;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuilderForComputer;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageForUsers;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;
public static class SalesDepartment
{
    public static IBuilderForPC ParseComponentOrderList(string nameForPC, ComponentOrderList orderList)
    {
        if (orderList is null)
        {
            throw new ArgumentException("OrderList cannot be null: ", nameof(orderList));
        }

        string name = nameForPC;
        CPU? cpu = null;
        GraphicsCard? graphicsCard = null;
        HDD? hdd = null;
        SSD? ssd = null;
        var ram = new Collection<RAM>();
        Motherboard? motherboard = null;
        CoolingSystem? coolingSystem = null;
        WifiAdapter? wifiAdapter = null;
        PowerUnit? powerUnit = null;
        ComputerCase? computerCase = null;

        foreach (Component comp in orderList.ListWithComponents)
        {
            if (comp is CPU)
            {
                if (cpu is not null)
                {
                    throw new ArgumentException("CPU is not null");
                }

                cpu = (CPU)comp;
            }

            if (comp is GraphicsCard)
            {
                if (graphicsCard is not null)
                {
                    throw new ArgumentException("graphicsCard is not null");
                }

                graphicsCard = (GraphicsCard)comp;
            }

            if (comp is HDD)
            {
                if (hdd is not null)
                {
                    throw new ArgumentException("hdd is not null");
                }

                hdd = (HDD)comp;
            }

            if (comp is SSD)
            {
                if (ssd is not null)
                {
                    throw new ArgumentException("ssd is not null");
                }

                ssd = (SSD)comp;
            }

            if (comp is RAM)
            {
                ram.Add((RAM)comp);
            }

            if (comp is Motherboard)
            {
                if (motherboard is not null)
                {
                    throw new ArgumentException("Motherboard is not null");
                }

                motherboard = (Motherboard)comp;
            }

            if (comp is CoolingSystem)
            {
                if (coolingSystem is not null)
                {
                    throw new ArgumentException("coolingSystem is not null");
                }

                coolingSystem = (CoolingSystem)comp;
            }

            if (comp is WifiAdapter)
            {
                if (wifiAdapter is not null)
                {
                    throw new ArgumentException("wifiAdapter is not null");
                }

                wifiAdapter = (WifiAdapter)comp;
            }

            if (comp is PowerUnit)
            {
                if (powerUnit is not null)
                {
                    throw new ArgumentException("powerUnit is not null");
                }

                powerUnit = (PowerUnit)comp;
            }

            if (comp is ComputerCase)
            {
                if (computerCase is not null)
                {
                    throw new ArgumentException("computerCase is not null");
                }

                computerCase = (ComputerCase)comp;
            }
        }

        if (cpu is null)
        {
            throw new ArgumentException("cpu cannot be null");
        }

        if (motherboard is null)
        {
            throw new ArgumentException("motherboard cannot be null");
        }

        if (coolingSystem is null)
        {
            throw new ArgumentException("cooling System cannot be null");
        }

        if (powerUnit is null)
        {
            throw new ArgumentException("powerUnit cannot be null");
        }

        if (computerCase is null)
        {
            throw new ArgumentException("computerCase cannot be null");
        }

        return new BuilderForPC(name, cpu, graphicsCard, hdd, ssd, ram, motherboard, coolingSystem, wifiAdapter, powerUnit, computerCase);
    }
}
