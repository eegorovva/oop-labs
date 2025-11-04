using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BuilderForComputer;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Builder;
public class Director
{
    private Collection<BuildInfo> _buildInfo = new Collection<BuildInfo>();

    public ReadOnlyCollection<BuildInfo> BuildInfo => _buildInfo.AsReadOnly();

    public Computer? BuildComputer(IBuilderForPC builderForPC)
    {
        if (builderForPC is null)
        {
            throw new ArgumentException("Builder cannot be null", nameof(builderForPC));
        }

        _buildInfo.Clear();

        _buildInfo.Add(builderForPC.CheckMotherboardWithCPUBySocket());
        _buildInfo.Add(builderForPC.CheckMotherboardWithRam());
        _buildInfo.Add(builderForPC.CheckCPUwithCoolingSystemBySocket());
        _buildInfo.Add(builderForPC.CheckCPUwithCollingSystemByTPD());
        _buildInfo.Add(builderForPC.CheckCoolingSystemsWithCaseBySize());
        _buildInfo.Add(builderForPC.CheckMotherboardWithCaseByFormfactor());
        _buildInfo.Add(builderForPC.CheckMotherboardWithRamByDDR());
        _buildInfo.Add(builderForPC.CheckRamAmountWithMotherboard());
        _buildInfo.Add(builderForPC.CheckGraphicsCoreForPC());
        _buildInfo.Add(builderForPC.CheckGraphicsCardWithMotherboardByPCIeAmount());
        _buildInfo.Add(builderForPC.CheckGraphicsCardWithComputerCaseByFormfactor());
        _buildInfo.Add(builderForPC.CheckGraphicsCardWithPowerUnitByPower());
        _buildInfo.Add(builderForPC.CheckHDDandSSDinPC());
        _buildInfo.Add(builderForPC.CheckDOCP());
        _buildInfo.Add(builderForPC.CheckXMP());
        _buildInfo.Add(builderForPC.CheckMotherboardWithCPUByBios());

        if (_buildInfo.FirstOrDefault(info => info is BuildError) != null)
        {
            return builderForPC.BuildPC();
        }

        return null;
    }
}
