using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.StorageForUsers;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Сomponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.AttributesForComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Test
{
    private ComputerSevice _computerSevice;

    public Test()
    {
        _computerSevice = new ComputerSevice();

        var xmp = new XMP("11-12-10", 12, 1200);
        var chipset = new Chipset("chipset", 100, 5000, xmp, null);
        var socket = new CPUSocket("1");
        var graphicscCore = new GraphicsCoreForCPU();
        var cpu1 = new CPU("INTEL", 8, 2200, socket, graphicscCore, 2000, 300, 500);
        var bios = new BIOS("1", "1", new Collection<CPU> { cpu1 });
        var pcieVersion = new PCIeVersion(4, 16);
        var card = new GraphicsCard("RTX3050", 50, 40, 8, pcieVersion, 100, 300);
        var cooler = new CoolingSystem("cooler", 30, 20, 10, 700, new Collection<CPUSocket> { socket });
        var hdd = new HDD("hdd", 500, 100, 100);
        var motherboard = new Motherboard("motherboard", bios, socket, 4, 4, chipset, "ddr4", 4, "form1", 12, "type1");
        var powerUnit = new PowerUnit("powerUnit", 800);
        var ram = new RAM("ram", 16, 2000, "11-12-10", 12, xmp, null, "type1", "ddr4", 50);
        var ram2 = new RAM("ram2", 16, 2000, "11-12-10", 12, xmp, null, "type1", "ddr4", 50);
        var caseForPc = new ComputerCase("case", new Collection<string> { "form1" }, 100, 100, 100, 100, 100);

        _computerSevice.AddComponentInStorage(cpu1);
        _computerSevice.AddComponentInStorage(card);
        _computerSevice.AddComponentInStorage(cooler);
        _computerSevice.AddComponentInStorage(hdd);
        _computerSevice.AddComponentInStorage(motherboard);
        _computerSevice.AddComponentInStorage(powerUnit);
        _computerSevice.AddComponentInStorage(ram);
        _computerSevice.AddComponentInStorage(ram2);
        _computerSevice.AddComponentInStorage(caseForPc);
    }

    [Fact]
    public void CreateNormalPC()
    {
        ComponentOrderList orderList = _computerSevice.StartSelling();

        _computerSevice.AddComponentToOrderList("INTEL", orderList);
        _computerSevice.AddComponentToOrderList("RTX3050", orderList);
        _computerSevice.AddComponentToOrderList("cooler", orderList);
        _computerSevice.AddComponentToOrderList("hdd", orderList);
        _computerSevice.AddComponentToOrderList("motherboard", orderList);
        _computerSevice.AddComponentToOrderList("powerUnit", orderList);
        _computerSevice.AddComponentToOrderList("ram", orderList);
        _computerSevice.AddComponentToOrderList("ram2", orderList);
        _computerSevice.AddComponentToOrderList("case", orderList);
        _computerSevice.EndSelling("PC1", orderList);

        Assert.All(_computerSevice.ReturnBuildInfoFromLastOrder(), buildinfo => Assert.IsNotType<BuildError>(buildinfo));
        Assert.All(_computerSevice.ReturnBuildInfoFromLastOrder(), buildinfo => Assert.IsNotType<DisclaimerOfWarranties>(buildinfo));
    }

    [Fact]
    public void CreateFailedBuild()
    {
        ComponentOrderList orderList = _computerSevice.StartSelling();

        var pcieVersion2 = new PCIeVersion(8, 16);
        var card2 = new GraphicsCard("GTX1060", 50, 40, 4, pcieVersion2, 100, 300);
        var caseForPc2 = new ComputerCase("case2", new Collection<string> { "form1" }, 45, 30, 100, 100, 100);

        _computerSevice.AddComponentInStorage(card2);
        _computerSevice.AddComponentInStorage(caseForPc2);

        _computerSevice.AddComponentToOrderList("INTEL", orderList);
        _computerSevice.AddComponentToOrderList("GTX1060", orderList);
        _computerSevice.AddComponentToOrderList("cooler", orderList);
        _computerSevice.AddComponentToOrderList("hdd", orderList);
        _computerSevice.AddComponentToOrderList("motherboard", orderList);
        _computerSevice.AddComponentToOrderList("powerUnit", orderList);
        _computerSevice.AddComponentToOrderList("ram", orderList);
        _computerSevice.AddComponentToOrderList("ram2", orderList);
        _computerSevice.AddComponentToOrderList("case2", orderList);

        _computerSevice.EndSelling("PC4", orderList);

        Assert.NotNull(_computerSevice.ReturnBuildInfoFromLastOrder().FirstOrDefault(buildInfo => buildInfo is BuildError));
    }

    [Fact]
    public void CreatePCWithDisclaimer()
    {
        ComponentOrderList orderList = _computerSevice.StartSelling();

        var pcieVersion3 = new PCIeVersion(4, 16);
        var card3 = new GraphicsCard("RTX4090", 50, 40, 4, pcieVersion3, 100, 900);

        _computerSevice.AddComponentInStorage(card3);

        _computerSevice.AddComponentToOrderList("INTEL", orderList);
        _computerSevice.AddComponentToOrderList("RTX4090", orderList);
        _computerSevice.AddComponentToOrderList("cooler", orderList);
        _computerSevice.AddComponentToOrderList("hdd", orderList);
        _computerSevice.AddComponentToOrderList("motherboard", orderList);
        _computerSevice.AddComponentToOrderList("powerUnit", orderList);
        _computerSevice.AddComponentToOrderList("ram", orderList);
        _computerSevice.AddComponentToOrderList("ram2", orderList);
        _computerSevice.AddComponentToOrderList("case", orderList);

        _computerSevice.EndSelling("PC3", orderList);

        Assert.NotNull(_computerSevice.ReturnBuildInfoFromLastOrder().FirstOrDefault(buildInfo => buildInfo is DisclaimerOfWarranties));
    }

    [Fact]
    public void CreatePCWithComments()
    {
        ComponentOrderList orderList = _computerSevice.StartSelling();

        var socket = new CPUSocket("1");
        var cooler2 = new CoolingSystem("cooler3", 30, 20, 10, 450, new Collection<CPUSocket> { socket });

        _computerSevice.AddComponentInStorage(cooler2);

        _computerSevice.AddComponentToOrderList("INTEL", orderList);
        _computerSevice.AddComponentToOrderList("RTX3050", orderList);
        _computerSevice.AddComponentToOrderList("cooler3", orderList);
        _computerSevice.AddComponentToOrderList("hdd", orderList);
        _computerSevice.AddComponentToOrderList("motherboard", orderList);
        _computerSevice.AddComponentToOrderList("powerUnit", orderList);
        _computerSevice.AddComponentToOrderList("ram", orderList);
        _computerSevice.AddComponentToOrderList("ram2", orderList);
        _computerSevice.AddComponentToOrderList("case", orderList);

        _computerSevice.EndSelling("PC2", orderList);

        Assert.NotNull(_computerSevice.ReturnBuildInfoFromLastOrder().FirstOrDefault(buildInfo => buildInfo is Comments));
    }
}
