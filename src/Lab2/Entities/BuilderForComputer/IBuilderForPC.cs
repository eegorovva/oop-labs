using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BuilderForComputer;
public interface IBuilderForPC
{
    public BuildInfo CheckMotherboardWithCPUBySocket();
    public BuildInfo CheckMotherboardWithCPUByBios();
    public BuildInfo CheckMotherboardWithRam();
    public BuildInfo CheckCPUwithCoolingSystemBySocket();
    public BuildInfo CheckCPUwithCollingSystemByTPD();
    public BuildInfo CheckCoolingSystemsWithCaseBySize();
    public BuildInfo CheckMotherboardWithCaseByFormfactor();
    public BuildInfo CheckMotherboardWithRamByDDR();
    public BuildInfo CheckRamAmountWithMotherboard();
    public BuildInfo CheckGraphicsCoreForPC();
    public BuildInfo CheckGraphicsCardWithMotherboardByPCIeAmount();
    public BuildInfo CheckGraphicsCardWithComputerCaseByFormfactor();
    public BuildInfo CheckGraphicsCardWithPowerUnitByPower();
    public BuildInfo CheckHDDandSSDinPC();
    public BuildInfo CheckDOCP();
    public BuildInfo CheckXMP();
    public Computer BuildPC();
}
