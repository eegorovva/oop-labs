using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.UpdatesForShip;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;
using Environment = Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments.Environment;
using Path = Itmo.ObjectOrientedProgramming.Lab1.Entities.Path.Path;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class FlightAnalysisTest
{
    private const double _priceForPlasma = 15;
    private const double _priceForGraviton = 40;
    private IFlightAnalysis service;

    public FlightAnalysisTest()
    {
        service = new FlightAnalysis(_priceForPlasma, _priceForGraviton);
    }

    public static IEnumerable<object[]> DataForTestThree =>
        new List<object[]>
        {
            new object[] { new Vaclas() },
            new object[] { new Avgur() },
            new object[] { new Meredian() },
        };

    public static IEnumerable<object[]> DataForTestTwo =>
        new List<object[]>
        {
            new object[] { new Vaclas() },
            new object[] { new Vaclas(new PhotonDeflector()) },
        };

    public static IEnumerable<object[]> DataForTestOne =>
        new List<object[]>
        {
            new object[] { new Avgur() },
            new object[] { new Shuttle() },
        };

    [Fact]
    public void CreationPathWithObstaclesAndWithoutThem()
    {
        IObstacle cosmoWhale = new CosmoWhaleObstacle(550);
        var obstacles = new Collection<IObstacle> { cosmoWhale };
        Environment nebula = new NebulaOfNitrineParticlesEnvironment(200, obstacles);
        Environment space = new SpaceEnvironment(150);
        var environment = new Collection<Environment> { nebula, space };
        var path = new Path(environment);

        Assert.NotNull(path);
    }

    [Fact]
    public void CreationPathInNebulaOfNitrineParticlesAndChooseVaclas()
    {
        Environment nebula = new NebulaOfNitrineParticlesEnvironment(50);
        var environment = new Collection<Environment> { nebula };
        var path = new Path(environment);

        Ship shuttle = new Shuttle();
        Ship vaclas = new Vaclas();
        var ships = new Collection<Ship> { shuttle, vaclas };

        Assert.Equal(vaclas, service.ChooseBestShip(ships, path));
    }

    [Fact]
    public void CreationPathInSpaceAndChooseShuttle()
    {
        Environment space = new SpaceEnvironment(1000);
        var environment = new Collection<Environment> { space };
        var path = new Path(environment);

        Ship shuttle = new Shuttle();
        Ship vaclas = new Vaclas();

        var ships = new Collection<Ship> { shuttle, vaclas };

        Assert.Equal(shuttle, service.ChooseBestShip(ships, path));
    }

    [Fact]
    public void CreationHighDensityNebulaAndChooseStella()
    {
        Environment highDensityNebula = new HighDensityNebulaEnvironment(600);
        var environment = new Collection<Environment> { highDensityNebula };
        var path = new Path(environment);

        Ship stella = new Stella();
        Ship avgur = new Avgur();

        var ships = new Collection<Ship> { stella, avgur };

        Assert.Equal(stella, service.ChooseBestShip(ships, path));
    }

    [Theory]
    [MemberData(nameof(DataForTestThree))]
    public void CreationCosmoWhaleInNebulaOfNitrineParticlesAndAnalysisVaclasAvgurMeridian(Ship ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        IObstacle cosmoWhale = new CosmoWhaleObstacle(600);
        var obstacles = new Collection<IObstacle> { cosmoWhale };
        Environment nebula = new NebulaOfNitrineParticlesEnvironment(200, obstacles);
        var environments = new Collection<Environment> { nebula };
        var path = new Path(environments);

        if (ship is Vaclas)
        {
            Assert.IsType<DestroyShip>(service.Analysis(ship, path));
        }

        if (ship is Avgur)
        {
            double healthBeforeWhale = ship.EnduranceHealth;
            service.Analysis(ship, path);
            Assert.Equal(healthBeforeWhale, ship.EnduranceHealth);
            Assert.False(ship.IsDeflectorWorking());
        }

        if (ship is Meredian)
        {
            double healthBeforeWhale = ship.DeflectorsHealth;
            service.Analysis(ship, path);
            Assert.Equal(healthBeforeWhale, ship.DeflectorsHealth);
        }
    }

    [Theory]
    [MemberData(nameof(DataForTestTwo))]
    public void CreationHighDensityOfNebulaAndAnalysisVaclas(Ship ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        IObstacle flash = new AntimatterFlashObstacle(2);
        var obstacles = new Collection<IObstacle> { flash };
        Environment highDensityNebula = new HighDensityNebulaEnvironment(600, obstacles);
        var environment = new Collection<Environment> { highDensityNebula };
        var path = new Path(environment);

        if (ship.FindPhotonDeflector() == true)
        {
            Assert.IsType<Success>(service.Analysis(ship, path));
        }
        else
        {
            Assert.IsType<DeathOfTheCrew>(service.Analysis(ship, path));
        }
    }

    [Theory]
    [MemberData(nameof(DataForTestOne))]
    public void CreationTwoShipLostsInHighDensityOfNebula(Ship ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        Environment highDensityNebula = new HighDensityNebulaEnvironment(2100);
        var environment = new Collection<Environment> { highDensityNebula };
        var path = new Path(environment);

        Assert.IsType<LostShip>(service.Analysis(ship, path));
    }
}
